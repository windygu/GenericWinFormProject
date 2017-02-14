using App.WinForm.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using App.WinForm.Entities;
using System.Collections;

namespace App.WinForm.Fields.Controls
{
    /// <summary>
    /// Manage the the selection filter of Filed
    /// </summary>
    public class SelectionFilterManager
    {
        #region Params
        private Orientation OrientationFiled;
        /// <summary>
        /// Indicate if the selection filter has somme CombBox filter
        /// </summary>
        public bool isHasFilter;

        public Size SizeLabel { get; private set; }
        public Size SizeControl { get; private set; }
        public ConfigEntity ConfigEntity { get; private set; }

        #endregion

        #region Propriété
        /// <summary>
        /// Obient  la valeur de filtre
        /// </summary>
        /// 
        public object Value
        {
           
            get
            {

                return ListeComboBox.Last().Value.Value;
            }

            set
            {
                CalculeValeursInitiaux((Int64)value);
                ViewingData();
            }
        }
        public BaseEntity ValueEntity 
        {
            get
            {

                return ListeComboBox.Last().Value.SelectedItem as BaseEntity;
            }
        }



        /// <summary>
        /// Le champs accepte une des valeurs pardéfaut pour chaque ComboBox de son filtre 
        /// personnel
        /// </summary>
        Int64 DefaultValues { set; get; }

        #endregion

        #region Variables

        private IBaseRepository Service { set; get; }
        /// <summary>
        /// Indique si le programme en état de changement de la vlaeurs pardéfaut du champs
        /// dans cette étape il aura l'éxécution seulement des événement d'initialisation
        /// et les événement de changement des valeurs ne seront pas exécuter
        /// </summary>
        public bool StopEventSelectedIndexChange { get; private set; }


        /// <summary>
        /// Le conteneur de l'interface, our que le Filed ajoute son filtre personnelle à l'interface 
        /// sous Forme des Field avant son Field
        /// </summary>
        public Control MainContainner { set; get; }

        #endregion

        #region Critères
        /// <summary>
        /// Lite des ComboBox 
        /// </summary>
        Dictionary<string, ManyToOneField> ListeComboBox { set; get; }

        /// <summary>
        /// Liste des Types de critère 
        /// </summary>
        Dictionary<string, Type> LsiteTypeObjetCritere { set; get; }

        Dictionary<string, Int64> ListeValeursInitiaux { set; get; }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public PropertyInfo PropertyInfo { get; set; }


        #endregion

        #region Evénement
        public event EventHandler ValueChanged;
        protected void onValueChaned(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }
        #endregion

        #region Constructeur
        public SelectionFilterManager(
            IBaseRepository Service,
            PropertyInfo PropertyInfo,
            Control MainContainner,
            Size SizeLabel,
             Size SizeControl,
              Orientation OrientationFiled,
             ConfigEntity ConfigEntity
            )
        {
            this.PropertyInfo = PropertyInfo;
            this.MainContainner = MainContainner;
            this.SizeLabel = SizeLabel;
            this.SizeControl = SizeControl;
            this.OrientationFiled = OrientationFiled;
            this.ConfigEntity = ConfigEntity;

            this.Service = Service;
            this.ListeComboBox = new Dictionary<string, ManyToOneField>();
            this.ListeValeursInitiaux = new Dictionary<string, long>();
            this.LsiteTypeObjetCritere = new Dictionary<string, Type>();

            InitInterface();
        }
        #endregion

        #region InitInterface
        /// <summary>
        /// Affichage du filtre dans l'interface
        /// Remplissage de ListeComboBox
        /// </summary>
        private void InitInterface()
        {

            this.DisplayMember = "";
            this.ValueMember = "Id";

            Attribute selectionCriteriaAttribute = this.PropertyInfo.PropertyType.GetGenericArguments()[0]
                .GetCustomAttribute(typeof(SelectionCriteriaAttribute));

            if (selectionCriteriaAttribute == null) return;


            SelectionCriteriaAttribute MetaSelectionCriteria =
              (SelectionCriteriaAttribute)selectionCriteriaAttribute;

            if(MetaSelectionCriteria == null)
            {
                this.isHasFilter = false;
            }else
            {
                this.isHasFilter = true;
            }

       
            int index = 10;

            // Si un objet du critère de selection exite dans la classe 
            // Nous cherchons sa valeur pour l'utiliser
            foreach (Type item in MetaSelectionCriteria.Criteria)
            {
                // Meta information d'affichage du de Critère
                DisplayEntityAttribute DisplayEntityAttributeCritere = (DisplayEntityAttribute)item.GetCustomAttribute(typeof(DisplayEntityAttribute));


                ManyToOneField manyToOneFilter = new ManyToOneField(this.Service, item, null, null,
                    this.OrientationFiled,
                     this.SizeLabel,
                    this.SizeControl, 0, this.ConfigEntity
                    );
                manyToOneFilter.Name = item.Name;
                //manyToOneFilter.Size = new System.Drawing.Size(this.widthField, this.HeightField);

                manyToOneFilter.TabIndex = ++index;
                manyToOneFilter.Text_Label = item.Name;

                manyToOneFilter.ValueMember = "Id";
                manyToOneFilter.DisplayMember = DisplayEntityAttributeCritere.DisplayMember;
                // pour le chargement de comboBox Suivant
                manyToOneFilter.FieldChanged += Value_SelectedIndexChanged;

                manyToOneFilter.Visible = true;

                // [bug] Le contôle ne s'affiche pas dans le formilaire ??
                //Form f = new Form();
                //f.Controls.Add(manyToOneFilter);
                //f.Show();

                this.MainContainner.Controls.Add(manyToOneFilter);

                ListeComboBox.Add(item.Name, manyToOneFilter);
                LsiteTypeObjetCritere.Add(item.Name, item);
            }
        }

        #endregion

        #region Calcule des valeurs initiaux
        /// <summary>
        ///  Calcule des valeurs initiaux
        /// </summary>
        private void CalculeValeursInitiaux(Int64 Value)
        {

            if (Value == 0) return;


            /// Le ComboBox précédent prend les valeurs de l'Entite actuel de comboBox 
            /// car l'entité actuel doit avoir une prorpiété de type type  de l'entityé précédent
            /// Le nom de cette propiété égale Nom d'entité 
            /// si cette propiété n'existe pas la méthode lance une exception
            /// 

            // Initialisation de la liste des valeurs par défaux
            if (ListeValeursInitiaux.Count() < this.LsiteTypeObjetCritere.Count())
                for (int i = 0; i < this.LsiteTypeObjetCritere.Count(); i++)
                {
                    ListeValeursInitiaux.Add(ListeComboBox.Keys.ElementAt(i), 0);
                }
            // Init la de la vlaeur de comboBox Actuel
            if(ListeValeursInitiaux.Count > 0)
            ListeValeursInitiaux[ListeValeursInitiaux.Last().Key] = Value;

            IBaseRepository curentService = this.Service
                  .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[ListeValeursInitiaux.Last().Key]);
            BaseEntity curentEntity = curentService.GetBaseEntityByID(Value);

            BaseEntity previousEntity = null;
            for (int i = this.LsiteTypeObjetCritere.Count() - 1; i >= 1; i--)
            {

                string curentKey = LsiteTypeObjetCritere.Keys.ElementAt(i);
                string Previouskey = ListeComboBox.Keys.ElementAt(i - 1);

                PropertyInfo PropertyPrevious = curentEntity.GetType()
                                                .GetProperties()
                                                .Where(p => p.Name == Previouskey)
                                                .SingleOrDefault();
                if (PropertyPrevious == null)
                    throw new PropertyNotExistInEntityException();

                // Affectation des valeurs au ComboBox précédent
                previousEntity = PropertyPrevious.GetValue(curentEntity) as BaseEntity;
                ListeValeursInitiaux[Previouskey] = previousEntity.Id;

                curentEntity = previousEntity;
            }






        }
        #endregion

        #region Affichage des données
        /// <summary>
        /// Chargement des comboBox suivants
        /// il s'exécute aprés le changement du valeur de chaque comboBox
        /// à chaque changement d'un comboBox on charge les données de comboBox suivant
        /// </summary>
        private void Value_SelectedIndexChanged(object sender, EventArgs e)
        {
            // n'exécuter pas cette événement, si nous somme à l'étape d'initialisation 
            // des chmpas de critères
            if (this.StopEventSelectedIndexChange) return;


            // Initialisation de ComboBox, Service, Entite qui a ête changé
            ManyToOneField comboBoxChanged = (ManyToOneField)sender;
            comboBoxChanged.CreateControl();
            int indexComboBoxChanged = ListeComboBox.Values.ToList<ManyToOneField>().IndexOf(comboBoxChanged);
            string keyComboBoxCanged = ListeComboBox.Keys.ElementAt(indexComboBoxChanged);
            IBaseRepository serviceComboBoxActuel = this.Service
                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[keyComboBoxCanged]);
            BaseEntity EntiteActuel = serviceComboBoxActuel.GetBaseEntityByID(Convert.ToInt64(comboBoxChanged.SelectedValue));

            /// Actualisation de ComboBox suivant s'il existe
            /// Le ComboBox suivant prend les valeurs de l'Entite actuel de comboBox 
            /// car l'entité actuel doit avoir une prorpiété de type type Collection de l'entityé suivant
            /// Le nom de cette propiété égale Nom d'entité suivant + "s"
            /// si cette propiété n'existe pas la méthode lance une exception
            if (comboBoxChanged.SelectedValue != null && (ListeComboBox.Values.Count() - 1) >= (indexComboBoxChanged + 1))
            {

                // ComboBox suivant 
                ManyToOneField nextComboBox = ListeComboBox.Values.ElementAt(indexComboBoxChanged + 1);
                string keyNexComboBox = ListeComboBox.Keys.ElementAt(indexComboBoxChanged + 1);

                PropertyInfo PropertyContenantValeursComboSuivant = EntiteActuel.GetType()
                                                .GetProperties()
                                                .Where(p => p.Name == keyNexComboBox + "s")
                                                .SingleOrDefault();
                if (PropertyContenantValeursComboSuivant == null)
                    throw new PropertyNotExistInEntityException(keyNexComboBox + "s");

                // Affectation des valeurs au ComboBox suivant
                IList ls_source = null;
                if (PropertyContenantValeursComboSuivant != null)
                {
                    ls_source = PropertyContenantValeursComboSuivant.GetValue(EntiteActuel) as IList;


                    // Initalisation avec la valeur par défaux s'il existe
                    if (this.ListeValeursInitiaux != null && this.ListeValeursInitiaux.Keys.Contains(keyNexComboBox))
                    {
                        this.StopEventSelectedIndexChange = true;
                        nextComboBox.DataSource = null;
                        nextComboBox.DataSource = ls_source;
                        this.StopEventSelectedIndexChange = false;
                        nextComboBox.SelectedValue = this.ListeValeursInitiaux[keyNexComboBox];
                    }
                    else
                    {
                        nextComboBox.DataSource = ls_source;
                    }



                }

                // Si ce Combo n'a pas d'information alors vider les combBobx suivant 
                if (ls_source == null || ls_source.Count == 0)
                    for (int i = (indexComboBoxChanged + 1); i < ListeComboBox.Values.Count(); i++)
                    {
                        ManyToOneField comboBox_suivant2 = ListeComboBox.Values.ElementAt(i);
                        comboBox_suivant2.DataSource = null;
                        comboBox_suivant2.TextCombobox = "";
                    }
            }else
            {
                // si la selection de dernier ComboBox on lance l'événement ValueChanged
                onValueChaned(this, null);
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
            ManyToOneField comboBox = ListeComboBox.Values.ElementAt(0);
            string key = ListeComboBox.Keys.ElementAt(0);
            IBaseRepository service = this.Service
                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);


            // Initalisation avec la valeur par défaux s'il existe
            if (this.ListeValeursInitiaux != null && this.ListeValeursInitiaux.Keys.Contains(key))
            {
                this.StopEventSelectedIndexChange = true;
                comboBox.DataSource = service.GetAll();
                this.StopEventSelectedIndexChange = false;
                comboBox.SelectedValue = this.ListeValeursInitiaux[key];
            }
            else
            {
                comboBox.DataSource = service.GetAll();
            }

        }
        #endregion
    }
}
