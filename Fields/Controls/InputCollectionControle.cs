using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using App.WinForm.Attributes;
using System.Collections;
using App.WinForm.Entities;

namespace App.WinForm
{
    /// <summary>
    /// Permet la saisie d'une collection d'entity dans une relation ManyToMany
    /// 
    /// </summary>
    public partial class InputCollectionControle : UserControl, IInputCollectionControle
    {
        #region Variables
        /// <summary>
        /// The service of the management in progress, it contains the context
        /// </summary>
        private IBaseRepository Service { set; get; }

        /// <summary>
        /// Evenement de changement de la valeur
        /// </summary>
        public event EventHandler ValueChanged;

        private void onValueChanger(object sender,EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }


        /// <summary>
        /// Les critères de filtre
        /// Le filtre permet de filtre la liste de collection de choix
        /// </summary>
        List<Type> Criteria { set; get; }

        /// <summary>
        /// Lire et obient la liste de choix
        /// </summary>
        List<BaseEntity> SelectionList { set; get; }

        /// <summary>
        /// Les valeurs pardéfaut de chaque comboBox
        /// </summary>
        List<BaseEntity> DefaultValueList { set; get; }

        /// <summary>
        /// Type de l'objet de la collection
        /// </summary>
        Type TypeObjetOfCollection { set; get; }

        /// <summary>
        /// L'objet ProtpertyInfo de la collection
        /// </summary>
        PropertyInfo PropertyInfoOfCollection { set; get; }

        SelectionCriteriaAttribute MetaSelectionCriteria { set; get; }

        /// <summary>
        /// L'objet qui contient la collection
        /// </summary>
        BaseEntity Entity { set; get; }
        public List<BaseEntity> Value {
            get
            {
                return listBoxChoices.SelectedItems.Cast<BaseEntity>().ToList<BaseEntity>();
            }
        }


        /// <summary>
        /// Lite des ComboBox 
        /// </summary>
        Dictionary<string, ComboBox> ListeComboBox = new Dictionary<string, ComboBox>();

        /// <summary>
        /// Lite des Valeur de critère Initial de comboBox
        /// </summary>
        Dictionary<string, BaseEntity> ListeValeursCritere = new Dictionary<string, BaseEntity>();
        List<BaseEntity> ListeDefaultValues = new List<BaseEntity>();
        /// <summary>
        /// Liste des Types de critère 
        /// </summary>
        Dictionary<string, Type> LsiteTypeObjetCritere = new Dictionary<string, Type>();


        #endregion

        #region Constructeur
        public InputCollectionControle()
        {
            InitializeComponent();
        }
        public InputCollectionControle(IBaseRepository Service,
            PropertyInfo propertyInfo,
            List<BaseEntity> DefaultValueList,
            BaseEntity Entity)
        {
            InitializeComponent();
            this.Config(Service, propertyInfo, DefaultValueList, Entity);

        }
 
        /// <summary>
        /// Configuration de Contôle
        /// </summary>
        /// <param name="Service"></param>
        /// <param name="propertyInfo">L'objet propertyInfo de la collection de la classe de déclaration</param>
        /// <param name="DefaultValueList">
        ///  Liste des objet BaseEntity qui représente la valeur de chaque 
        ///  ComboBox de critère de filtrage
        /// </param>
        /// <param name="Entity">L'objet qui contient la collection</param>
        public void Config(IBaseRepository Service,
            PropertyInfo propertyInfo,
            List<BaseEntity> DefaultValueList,
            BaseEntity Entity)
        {
            // Paramétres
            this.Service = Service;
            this.DefaultValueList = DefaultValueList;
            this.PropertyInfoOfCollection = propertyInfo;
            this.Entity = Entity;

            this.TypeObjetOfCollection = PropertyInfoOfCollection.PropertyType.GetGenericArguments()[0];
            this.MetaSelectionCriteria = (SelectionCriteriaAttribute)PropertyInfoOfCollection.GetCustomAttribute(typeof(SelectionCriteriaAttribute));

            // Trouver les valeurs par défaut
            this.CalculatesDefaultValues();

            // Création de l'interface
            this.CreateInterface();

            // Affichage des données
            this.ViewingData();

            // Affecter les valeurs par défaut
            // this.SetDefaullValues();

            this.Show_List_Of_Choices();
            this.Show_Display_Selected_Entity();
        }


        #endregion

        /// <summary>
        /// Trouver les valeurs par défaut de chaque critère de filtre, 
        /// depuis l'objet qui déclare la collection
        /// </summary> 
        protected void CalculatesDefaultValues()
        {
            if (MetaSelectionCriteria == null) return;
            foreach (Type item in MetaSelectionCriteria.Criteria)
            {
                // Trouver si la classe de critère de filtre existe déja comme Membre 
                // de la classe qui déclare la collection
                Type DeclaringType = PropertyInfoOfCollection.DeclaringType;
                PropertyInfo PropertyInfo_value = DeclaringType.GetProperties().Where(p => p.PropertyType.Name == item.Name).SingleOrDefault();
                if (PropertyInfo_value != null && Entity != null)
                {
                    BaseEntity BaseEntityValue = (BaseEntity)PropertyInfo_value.GetValue(Entity);
                    if (BaseEntityValue != null)
                    {
                        ListeValeursCritere[item.Name] = BaseEntityValue;

                        // si la critère a une valeur par défaut
                        // on cherche les valeurs par défaut des critère précédent 
                        int index = MetaSelectionCriteria.Criteria.ToList().IndexOf(item);
                        ValeurParen(index, BaseEntityValue);

                    }



                }
            }
        }

        public void ValeurParen(int index, BaseEntity BaseEntityValue)
        {
            if (index == 0) return;
            Type type_prent = MetaSelectionCriteria.Criteria[index-1];
            PropertyInfo propertyInfoParent = BaseEntityValue.GetType().GetProperties().Where(p => p.Name == type_prent.Name).SingleOrDefault();

            if (propertyInfoParent == null) throw new PropertyDoesNotExistException(type_prent.Name + "Dans " + BaseEntityValue.GetType());
            BaseEntity BaseEntityParent = (BaseEntity)propertyInfoParent.GetValue(BaseEntityValue);

            ListeValeursCritere[type_prent.Name] = BaseEntityParent;

            ValeurParen(index - 1, BaseEntityParent);
        }

        /// <summary>
        /// Affichage du filtre dans l'interface
        /// Remplissage de ListeComboBox
        /// </summary>
        private void CreateInterface()
        {
            // 
            // Suppresion de la zone de filtre si les critères de filtrage n'existe pas  
            //
            if (this.MetaSelectionCriteria == null)
            {
                groupBoxFilter.Visible = false;
                groupBoxListChoices.Location = new Point(12, 0);
                groupBoxDisplaySelected.Location = new Point(12, groupBoxListChoices.Location.Y + groupBoxListChoices.Size.Height + 10);
                return;
            }

            //
            // Création de l'interface
            //
            // Positions
            int index = 0;
            int y = 20;
            // Si un objet du critère de selection exite dans la classe 
            // Nous cherchons sa valeur pour l'utiliser
            foreach (Type item in MetaSelectionCriteria.Criteria)
            {
                // Meta information d'affichage du de Critère
                 DisplayEntityAttribute MetaAffichageClasseCritere = (DisplayEntityAttribute)item.GetCustomAttribute(typeof(DisplayEntityAttribute));

                // 
                // label1
                // 
                Label label_comboBox = new Label();
                label_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
          | System.Windows.Forms.AnchorStyles.Left)
          | System.Windows.Forms.AnchorStyles.Right)));
                label_comboBox.AutoSize = true;
                label_comboBox.Location = new System.Drawing.Point(6, y);
                label_comboBox.Name = "label_" + item.Name;
                label_comboBox.Size = new System.Drawing.Size(35, 13);
                label_comboBox.TabIndex = ++index;
                label_comboBox.Text = item.Name;

                //
                // ComBobox
                //
                ComboBox comboBox = new ComboBox();
                comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
                comboBox.FormattingEnabled = true;
                comboBox.Location = new System.Drawing.Point(6, y + 20);
                comboBox.Name = "comboBoxFilter_" + item.Name; ;
                comboBox.Size = new System.Drawing.Size(250, 21);
                comboBox.ValueMember = "Id";
                comboBox.DisplayMember = MetaAffichageClasseCritere.DisplayMember;
                comboBox.TabIndex = ++index; ;
                comboBox.SelectedIndexChanged += Value_SelectedIndexChanged;


                this.groupBoxFilter.Controls.Add(label_comboBox);
                this.groupBoxFilter.Controls.Add(comboBox);

                ListeComboBox.Add(item.Name, comboBox);
                LsiteTypeObjetCritere.Add(item.Name, item);
                y += 40;
            }

            //
            // Redimention de l'interface
            //
            groupBoxFilter.Location = new Point(12, 5);
            groupBoxFilter.Size = new System.Drawing.Size(188, y);
            groupBoxListChoices.Location = new Point(12, groupBoxFilter.Location.Y + groupBoxFilter.Size.Height + 10);
            groupBoxDisplaySelected.Location = new Point(12, groupBoxListChoices.Location.Y + groupBoxListChoices.Size.Height + 10);




        }

        /// <summary>
        /// Affichage des données dans les ComboBox
        /// </summary>
        protected void ViewingData()
        {
            // Affichage des données du premiere comboBox
            // les autres comboBox sont afficher par l'événement ValueChange du ComboBox
            if (ListeComboBox.Values.Count() <= 0) return;
            ComboBox comboBox = ListeComboBox.Values.ElementAt(0);
            string key = ListeComboBox.Keys.ElementAt(0);
            IBaseRepository service = this.Service
                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);
            comboBox.DataSource = service.GetAll();
        }

        /// <summary>
        /// Affectation des valeurs par défaut
        /// </summary>
        protected void SetDefaullValues()
        { 
            for (int i = 0; i < ListeComboBox.Count; i++)
            {
                ComboBox comboBox = ListeComboBox.Values.ElementAt(i);
                string key = ListeComboBox.Keys.ElementAt(i);
                // Valeur par défaut
                if (ListeValeursCritere.ContainsKey(key) && ListeValeursCritere[key].Id != 0)
                {
                    comboBox.CreateControl();
                    comboBox.SelectedValue = ListeValeursCritere[key].Id;
                       

                    // Actualisation de ComboBoxs suivant
                    IBaseRepository EntityPereService = this.Service
                                                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);
                    BaseEntity EntityPere = EntityPereService.GetBaseEntityByID(ListeValeursCritere[key].Id);


                    ComboBox comboBox_suivant = ListeComboBox.Values.ElementAt(i + 1);
                    string key_suivant = ListeComboBox.Keys.ElementAt(i + 1);

                    
                    PropertyInfo PropertyFils = EntityPere.GetType()
                                                    .GetProperties()
                                                    .Where(p => p.Name == key_suivant + "s")
                                                    .SingleOrDefault();
                    if(PropertyFils ==null)  throw new PropertyDoesNotExistException("La classe " + EntityPere.GetType().Name + " ne contient pas la propriété " + key_suivant + "s");
                    comboBox_suivant.DataSource = PropertyFils.GetValue(EntityPere);
                }
            }
 
        }

        /// <summary>
        /// SelectedIndexChanged qui Actualise de tous les comboBoxs déscendantes
        /// </summary>
        private void Value_SelectedIndexChanged(object sender, EventArgs e)
        {
            // à chaque changement d'un combo on charge les donnée de comboBox suivant
            ComboBox comboBox = (ComboBox)sender;
            comboBox.CreateControl();
            int index_comboBox = ListeComboBox.Values.ToList<ComboBox>().IndexOf(comboBox);

            // Le Service de l'objet de ComboBox
            string key = ListeComboBox.Keys.ElementAt(index_comboBox);
            IBaseRepository service = this.Service
                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);

            // Actualisation de ComboBox suivant s'il existe, et le comboBox actual a une valeur
            if (comboBox.SelectedValue != null && (ListeComboBox.Values.Count() - 1) >= (index_comboBox + 1))
            {
                //
                // Actualisation de combobBox suivant
                //
                ComboBox comboBox_suivant = ListeComboBox.Values.ElementAt(index_comboBox + 1);
                string key_suivant = ListeComboBox.Keys.ElementAt(index_comboBox + 1);

                BaseEntity EntityPere = service.GetBaseEntityByID(Convert.ToInt64(comboBox.SelectedValue));
                PropertyInfo PropertyChild = EntityPere.GetType()
                                                .GetProperties()
                                                .Where(p => p.Name == key_suivant + "s")
                         
                                                .SingleOrDefault();
                IList ls_source  = null;
                if (PropertyChild != null) {
                    ls_source = PropertyChild.GetValue(EntityPere) as IList;
                    comboBox_suivant.DataSource = ls_source;
                }
                // Si ce Combo n'a pas d'information 
                // alors vider les combBobx suivant 
                if (ls_source == null || ls_source.Count == 0)
                    for (int i = (index_comboBox + 1); i < ListeComboBox.Values.Count(); i++)
                    {
                        ComboBox comboBox_suivant2 = ListeComboBox.Values.ElementAt(i);
                        comboBox_suivant2.DataSource = null;
                        comboBox_suivant2.Text = "";
                    }
            }

            // si le Dernier ComboBox on actualise la ListeBox
            if ((ListeComboBox.Values.Count() - 1) == index_comboBox )
            {
                if (comboBox.SelectedValue != null)
                {
                    BaseEntity EntityPere = service.GetBaseEntityByID(Convert.ToInt64(comboBox.SelectedValue));
                    PropertyInfo PropertyChild = EntityPere.GetType()
                                                    .GetProperties()
                                                    .Where(p => p.Name == PropertyInfoOfCollection.PropertyType.GetGenericArguments()[0].Name + "s")
                                                    .SingleOrDefault();

                    if (PropertyChild == null) throw new PropertyDoesNotExistException("La classe " + EntityPere.GetType().Name + " ne contient pas la propriété " + PropertyInfoOfCollection.PropertyType.GetGenericArguments()[0].Name + "s");
                    {
                        listBoxChoices.DataSource = null;
                        listBoxChoices.DataSource = PropertyChild.GetValue(EntityPere);
                        listBoxChoices.SelectedItems.Clear();
                    }
                  
                }
                else
                {
                    listBoxChoices.DataSource = null;
                }

            }





        }

        /// <summary>
        /// Afficher la liste de choix
        /// </summary>
        private void Show_List_Of_Choices()
        {

            IBaseRepository service = this.Service.CreateInstance_Of_Service_From_TypeEntity(this.TypeObjetOfCollection);
       //     this.listBoxChoices.DataSource = service.GetAll();

            if (DefaultValueList == null) return;
            for (int i = 0; i < this.listBoxChoices.Items.Count; i++)

            {
                BaseEntity item = (BaseEntity)this.listBoxChoices.Items[i];
                if (this.DefaultValueList.Contains(item))
                    this.listBoxChoices.SelectedItems.Add(item);
            }


        }

        /// <summary>
        /// Affichage du détaille de l'entity selectionné
        /// </summary>
        private void Show_Display_Selected_Entity()
        {

        }

        private void listBoxChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            onValueChanger(this, e);
        }
    }
}
