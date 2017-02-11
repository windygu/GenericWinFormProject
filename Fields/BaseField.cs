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
using App.Shared.AttributesManager;
using App.WinForm.Attributes;

namespace App.WinFrom.Fields
{
    public partial class BaseField : UserControl, IBaseField
    {

        #region Enumération
        #endregion

        #region Evénement
        public event EventHandler FieldChanged;
        protected void onFieldChanged(object sender, EventArgs e)
        {
            if (FieldChanged != null)
                FieldChanged(sender, e);
        }
        public event EventHandler<CancelEventArgs> ValidatingFiled;
        protected void onValidatingFiled(object sender, CancelEventArgs e)
        {
            if (ValidatingFiled != null)
                ValidatingFiled(sender, e);
        }
        #endregion

        #region Propriété

        /// <summary>
        /// Le type de l'objet à entrer par ce contôle
        /// </summary>
        protected Type TypeOfObject { set; get; }

        /// <summary>
        /// La propriété Info de du champs
        /// </summary>
        protected PropertyInfo PropertyInfo { set; get; }

        /// <summary>
        /// The configuration of the property
        /// </summary>
        public ConfigProperty configProperty { get; set; }


        /// <summary>
        /// La direction d'affichage, il est soit vertical soit horizontale
        /// </summary>
        protected Orientation orientationFiled;
        protected Orientation OrientationFiled
        {
            set
            {
                orientationFiled = value;
                this.splitContainer.Orientation = orientationFiled;

            }
            get
            {
                return orientationFiled;
            }
        }

        /// <summary>
        /// Définire le texte du label 
        /// </summary>
        public string Text_Label
        {
            set
            {
                this.labelField.Text = value;


            }
        }


        public int HeightField { set; get; }
        public Size SizeLabel { get; private set; }
        public Size SizeControl { get; private set; }
        public virtual object Value { get; set; }
        public ConfigEntity ConfigEntity { get;  set; }

        #endregion

        #region Constructeurs
        public BaseField()
        {
            InitializeComponent();
        }

        public BaseField(
            Type TypeObjet, 
            PropertyInfo PropertyInfo, 
            Orientation OrientationFiled, 
            Size SizeLabel, 
            Size SizeControl, 
            ConfigEntity ConfigEntity)
        {
            InitializeComponent();
            this.Config(TypeObjet, PropertyInfo, OrientationFiled, SizeLabel, SizeControl, ConfigEntity);
        }
       
        public BaseField(Type TypeObjet, Orientation OrientationFiled, Size SizeLabel, Size SizeControl, ConfigEntity ConfigEntity = null)
            : this(TypeObjet, null, OrientationFiled, SizeLabel, SizeControl, ConfigEntity) { }

        public BaseField(PropertyInfo PropertyInfo, Orientation OrientationFiled, Size SizeLabel, Size SizeControl, ConfigEntity ConfigEntity = null)
           : this(null, PropertyInfo, OrientationFiled, SizeLabel, SizeControl, ConfigEntity) { }




        #endregion

        public void Config(Type TypeObjet,
           PropertyInfo PropertyInfo,
           Orientation OrientationFiled,
           Size SizeLabel,
           Size SizeControl,
           ConfigEntity ConfigEntity)
        {
            // Paramétre de données 
            this.PropertyInfo = PropertyInfo;
            this.TypeOfObject = TypeObjet;
            this.ConfigEntity = ConfigEntity;
            // Paramètre d'affichage
            this.OrientationFiled = OrientationFiled;
            this.SizeLabel = SizeLabel;
            this.SizeControl = SizeControl;

            if(PropertyInfo != null)
                this.configProperty = new ConfigProperty(PropertyInfo, this.ConfigEntity);
            InitSizeField();
        }


        /// <summary>
        /// Initialisation des paramétres
        /// </summary>
        protected void InitSizeField()
        {
            // Label
            labelField.Size = this.SizeLabel;
            labelField.AutoSize = false;
            // Containner
            this.splitContainer.Orientation = this.OrientationFiled;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.TabStop = false;

            if (OrientationFiled == Orientation.Vertical)
            {
                // Field
                int width_field = this.SizeLabel.Width + this.SizeControl.Width;
                int height_field = this.SizeControl.Height;
                this.Size = new Size(width_field, height_field);
                // Containner
                this.splitContainer.Size = new Size(width_field, height_field);
                this.splitContainer.SplitterDistance = this.SizeLabel.Width;
            }
            else
            {
                // Field
                int width_field = this.SizeControl.Width;
                int height_field = this.SizeLabel.Height + this.SizeControl.Height;
                this.Size = new Size(width_field, height_field);
                // Containner
                this.splitContainer.Size = new Size(width_field, height_field);
                this.splitContainer.SplitterDistance = this.SizeLabel.Height;
            }
        }
    }
}
