using App.Shared.AttributesManager;
using App.WinForm.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace App.WinFrom.Fields
{
    public partial class StringField : App.WinFrom.Fields.BaseField
    {
        #region Propriété
        /// <summary>
        /// Obient la valeur de TexteBox du champs String
        /// </summary>
        public override object Value
        {
            get
            {
                return textBoxField.Text;
            }
            set
            {
                if(value != null)
                textBoxField.Text = value.ToString();
            }
        }

        /// <summary>
        /// Obtien si la Zone de Texte est multi_ligne
        /// </summary>
        public bool MultiLinge { get; private set; }
        
    
        #endregion

        public StringField(PropertyInfo propertyInfo,Orientation OrientationField, Size SizeLabel, Size SizeControl, ConfigEntity ConfigEntity ) 
            :base(propertyInfo,OrientationField, SizeLabel, SizeControl, ConfigEntity)
        {
            InitializeComponent();
            InitSizeStringFiled();
        }

     

        public StringField() : this(null,Orientation.Horizontal, new Size(50, 20), new Size(50, 20), null)
        {
       
        }
        private void textBoxField_TextChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
        /// <summary>
        /// Initialisation spécifique à zone de texte
        /// Exécuter aprés l'initialisation de du Size Field
        /// </summary>
        private void InitSizeStringFiled()
        {
            if (this.configProperty.EntryForm?.MultiLine == true)
            {
                this.textBoxField.Multiline = true;
                this.textBoxField.Size = new Size(this.SizeControl.Width, 10 * this.configProperty.EntryForm.NombreLigne);
                // Modification de Size de Field
                // [Bug] est ce que il faut augmenter aussi la taille Layout ?
                this.Size = new Size(this.Size.Width, this.Size.Height + 10 * (this.configProperty.EntryForm.NombreLigne));
            }
        }
    }
}
