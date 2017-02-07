using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.WinForm.Annotation;
using System.Reflection;
using System.Collections;

namespace App.WinForm
{
    public partial class InputComboBox : UserControl
    {
        #region Enumération
        /// <summary>
        /// Détermine la direction de contrôle
        /// </summary>
        public enum Directions
        {
            Horizontal,
            Vertical
        }

        public enum MainContainers
        {
            GroupeBox,
            Panel
        }
        #endregion

        #region Variables


        public int height { set; get; }
        /// <summary>
        /// Evénement Value Chnager de ComboBox
        /// </summary>
        public event EventHandler ValueChanged;
        /// <summary>
        /// Direction : Horizontale ou Virtical
        /// </summary>
        public Directions Direction { set; get; }

        /// <summary>
        /// Le controle qui contient toute l'interface graphique
        /// </summary>
        public Control MainContainer { set; get; }

        /// <summary>
        /// Le type de l'objet à entrer par ce contôle
        /// </summary>
        Type TypeOfObject { set; get; }

        // ------------------------------------------------

        SelectionCriteriaAttribute MetaSelectionCriteria { set; get; }

        /// <summary>
        /// L'objet qui contient les valeus
        /// </summary>
        BaseEntity EntityDefautlValue { set; get; }

        /// <summary>
        /// Meta donnés d'affichage de la classe
        /// </summary>
        public AffichageClasseAttribute MetaAffichageClasse { get;  set; }

        /// <summary>
        /// Définit ou Obient la valeur de Selected Value de Dernier ComboBox
        /// </summary>
        public Object SelectedValue {
            get
            {
                if (this.ListeComboBox.Count > 1)
                    return this.ListeComboBox.Last().Value.SelectedValue;
                else
                    return 0;
            }
            set
            {
                if (this.ListeComboBox.Count > 1)
                     this.ListeComboBox.Last().Value.SelectedValue = value;

            }
              }

        public Object SelectedItem {

            get
            {
                if (this.ListeComboBox.Count > 1)
                    return this.ListeComboBox.Last().Value.SelectedItem;
                else
                    return 0;
            }
            set
            {
                if (this.ListeComboBox.Count > 1)
                    this.ListeComboBox.Last().Value.SelectedItem = value;

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

        /// <summary>
        /// Liste des Types de critère 
        /// </summary>
        Dictionary<string, Type> LsiteTypeObjetCritere = new Dictionary<string, Type>();
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TypeOfObject">Le type de l'objet à entrer par ce contôle</param>
        /// <param name="EntityValeur">L'entity qui contient les valeur par défaut</param>
        /// <param name="Direction"></param>
        public InputComboBox(Type TypeOfObject, 
            BaseEntity EntityDefautlValue,
            MainContainers MainContainer,
            Directions Direction = Directions.Vertical)
        {
            InitializeComponent();
            this.TypeOfObject = TypeOfObject;
            this.EntityDefautlValue = EntityDefautlValue;
            this.Direction = Direction;

            this.InitMetaAnnotation();

            // Création et Initalisation de conteneur de l'interface
            this.DesigneMainContainner(MainContainer);

            if(EntityDefautlValue != null ) this.CalculatesDefaultValues();

            this.CreateInterface();

            this.ViewingData();
        }

        /// <summary>
        /// Initialisation des Meta données
        /// </summary>
        private void InitMetaAnnotation()
        {
            this.MetaSelectionCriteria = (SelectionCriteriaAttribute)this.TypeOfObject.GetCustomAttribute(typeof(SelectionCriteriaAttribute));

            List<Type> ls = MetaSelectionCriteria.Criteria.ToList<Type>();
            ls.Add(TypeOfObject);
            MetaSelectionCriteria.Criteria = ls.ToArray<Type>();
           
            // Meta information d'affichage du de Critère
            this.MetaAffichageClasse = (AffichageClasseAttribute)TypeOfObject.GetCustomAttribute(typeof(AffichageClasseAttribute));

        }

        /// <summary>
        /// Création et Initalisation de conteneur de l'interface
        /// </summary>
        /// <param name="mainContainer"></param>
        private void DesigneMainContainner(MainContainers mainContainer)
        {
            switch (mainContainer)
            {
                case MainContainers.GroupeBox:
                    {
                        GroupBox groupeBox = new GroupBox();
                        MainContainer = groupeBox;
                    }  break;
                case MainContainers.Panel:
                    Panel panel = new Panel();
                    MainContainer = panel;
                    break;
                default:
                    break;
            }

            MainContainer.Dock = DockStyle.Fill;
            MainContainer.Name = "groupBoxFilter_" + this.TypeOfObject.Name;
            MainContainer.TabIndex = 1;
            MainContainer.TabStop = false;
            MainContainer.Text = this.MetaAffichageClasse.Minuscule;
            this.Controls.Add(MainContainer);
        }

        /// <summary>
        /// Trouver les valeurs par défaut de chaque critère de filtre, 
        /// depuis l'objet qui déclare la collection
        /// </summary> 
        protected void CalculatesDefaultValues()
        {
            //if (MetaSelectionCriteria == null) return;
            //foreach (Type item in MetaSelectionCriteria.Criteria)
            //{
            //    // Trouver si la classe de critère de filtre existe déja comme Membre 
            //    // de la classe qui déclare la collection
            //    Type DeclaringType = PropertyInfoOfCollection.DeclaringType;
            //    PropertyInfo PropertyInfo_value = DeclaringType.GetProperties().Where(p => p.PropertyType.Name == item.Name).SingleOrDefault();
            //    if (PropertyInfo_value != null && Entity != null)
            //    {
            //        BaseEntity BaseEntityValue = (BaseEntity)PropertyInfo_value.GetValue(Entity);
            //        if (BaseEntityValue != null)
            //        {
            //            ListeValeursCritere[item.Name] = BaseEntityValue;

            //            // si la critère a une valeur par défaut
            //            // on cherche les valeurs par défaut des critère précédent 
            //            int index = MetaSelectionCriteria.Criteria.ToList().IndexOf(item);
            //            ValeurParen(index, BaseEntityValue);

            //        }



            //    }
            //}
        }


        /// <summary>
        /// Affichage du filtre dans l'interface
        /// Remplissage de ListeComboBox
        /// </summary>
        private void CreateInterface()
        {
            //
            // Création de l'interface
            //
            // Positions
            int index = 0;
            int y = 0;
            // Si un objet du critère de selection exite dans la classe 
            // Nous cherchons sa valeur pour l'utiliser
            foreach (Type item in MetaSelectionCriteria.Criteria)
            {
                // Meta information d'affichage du de Critère
                AffichageClasseAttribute MetaAffichageClasseCritere = (AffichageClasseAttribute)item.GetCustomAttribute(typeof(AffichageClasseAttribute));

                // 
                // label1
                // 
                Label label_comboBox = new Label();
                label_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
          | System.Windows.Forms.AnchorStyles.Left)
          | System.Windows.Forms.AnchorStyles.Right)));
                label_comboBox.AutoSize = true;
                label_comboBox.Location = new System.Drawing.Point(0, y);
                label_comboBox.Name = "label_" + item.Name;
                label_comboBox.Size = new System.Drawing.Size(50, 20);
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
                comboBox.Location = new System.Drawing.Point(0, y + 25);
                comboBox.Name = "comboBoxFilter_" + item.Name; ;
                comboBox.Size = new System.Drawing.Size(100, 20);
                comboBox.ValueMember = "Id";
                comboBox.DisplayMember = MetaAffichageClasseCritere.DisplayMember;
                comboBox.TabIndex = ++index; ;
                comboBox.SelectedIndexChanged += Value_SelectedIndexChanged;


                this.MainContainer.Controls.Add(label_comboBox);
                this.MainContainer.Controls.Add(comboBox);

                ListeComboBox.Add(item.Name, comboBox);
                LsiteTypeObjetCritere.Add(item.Name, item);
                y += 50;
            }

            MainContainer.Location = new Point(12, 5);
            MainContainer.Size = new System.Drawing.Size(188, y);
            height = y + 10;
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
            IBaseRepository service = new BaseRepository<BaseEntity>()
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
                IList ls_source = null;
                if (PropertyChild != null)
                {
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
            IBaseRepository service = new BaseRepository<BaseEntity>()
                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);
            comboBox.DataSource = service.GetAll();
        }

    }
}
