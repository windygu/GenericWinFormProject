using App.WinForm.Attributes;
using App.WinForm.EntityManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace App.WinForm.Fields
{
    public partial class ManyToOneField : App.WinFrom.Fields.BaseField
    {

        #region Propriété
        /// <summary>
        /// Obient la valeur de ComBox du champs ManyToOne
        /// </summary>
        /// 
        private Int64 value_id;
        public override Object Value
        {
            get
            {
                return comboBoxManyToOne.SelectedValue;
            }
            
            set
            {

                this.setAllValuesBySelectedValue((Int64)value);
                

                //comboBoxManyToOne.SelectedValue = value; 

                //// Affectation de la valeur une seul fois pour eviter l'appelle StackOverFlow
                //if (comboBoxManyToOne.SelectedValue == null
                //    || (Int64)comboBoxManyToOne.SelectedValue == 0
                //    || value_id != (Int64)value)
                //{
                //    value_id = (Int64)value;
                //    comboBoxManyToOne.SelectedValue = value_id;
                //    this.setAllValuesBySelectedValue((Int64)value);
                //}
            }
        }

        /// <summary>
        /// Intiliaser les valeurs des autres critère 
        /// </summary>
        /// <param name="value"></param>
        public void setAllValuesBySelectedValue(Int64 value)
        {
            this.CalculeValeursInitiaux(Convert.ToInt64(value));
            this.ViewingData();
        }

        /// <summary>
        /// Le champs accepte une des valeurs pardéfaut pour chaque ComboBox de son filtre 
        /// personnel
        /// </summary>
        Int64 DefaultValues { set; get; }

        #endregion

        #region Propriété : ComboBox

        public string ValueMember
        {
            get { return this.comboBoxManyToOne.ValueMember; }
            set { this.comboBoxManyToOne.ValueMember = value; }
        }
        public string DisplayMember
        {
            get { return this.comboBoxManyToOne.DisplayMember; }
            set { this.comboBoxManyToOne.DisplayMember = value; }
        }

        public object DataSource
        {
            get { return this.comboBoxManyToOne.DataSource; }
            set { this.comboBoxManyToOne.DataSource = value; }
        }

        public int SelectedIndex
        {
            get { return this.comboBoxManyToOne.SelectedIndex; }
            set { this.comboBoxManyToOne.SelectedIndex = value; }
        }

        public Object SelectedValue
        {
            get { return this.comboBoxManyToOne.SelectedValue; }
            set { this.comboBoxManyToOne.SelectedValue = value; }
        }

        public object SelectedItem
        {
            get { return this.comboBoxManyToOne.SelectedItem; }
        }


        public string TextCombobox
        {
            get { return this.comboBoxManyToOne.Text; }
            set { this.comboBoxManyToOne.Text = value; }
        }
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

        #endregion

        #region evénements
        private void comboBoxManyToOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
        #endregion

        #region Constructeurs

        public ManyToOneField(IBaseRepository Service,
            Type TypeObjet,
            PropertyInfo propertyInfo, 
            Control MainContainner, 
            Orientation OrientationFiled, 
            Size SizeLabel, 
            Size SizeControl,
            Int64 DefaultValues,ConfigEntity ConfigEntity) 
            :base(TypeObjet,propertyInfo, OrientationFiled, SizeLabel, SizeControl, ConfigEntity)
        {
            InitializeComponent();
            this.MainContainner = MainContainner;



            this.Service = Service;
            this.ListeComboBox = new Dictionary<string, ManyToOneField>();
            this.ListeValeursInitiaux = new Dictionary<string, long>();
            this.LsiteTypeObjetCritere = new Dictionary<string, Type>();
            this.DefaultValues = DefaultValues;
            

            InitAndLoadData();
            CalculeValeursInitiaux(DefaultValues);
            ViewingData();
        }

      
        public ManyToOneField(IBaseRepository Service, 
            PropertyInfo propertyInfo, 
            Control MainContainner, 
            Orientation OrientationFiled, 
            Size SizeLabel, Size SizeControl, 
            Int64 DefaultFiltreValues,
            ConfigEntity ConfigEntity)
          : this(Service,null, propertyInfo, MainContainner, OrientationFiled, SizeLabel, SizeControl, DefaultFiltreValues, ConfigEntity)
        {

        }

        public ManyToOneField() : this(null,null, null, Orientation.Horizontal, new Size(50, 20), new Size(50, 20), 0,null)
        {

        }

        private ManyToOneField(IBaseRepository Service, Type TypeObjet, ConfigEntity ConfigEntity) : this(Service,TypeObjet, null,null, Orientation.Horizontal, new Size(50, 20), new Size(50, 20),0, ConfigEntity)
        {
            
        }

        #endregion

    }
}
