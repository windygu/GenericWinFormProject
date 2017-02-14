using App.Shared.AttributesManager;
using App.WinForm.Attributes;
using App.WinFrom.Fields.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace App.WinForm.Fields
{
    public partial class DateTimeField : App.WinFrom.Fields.BaseField
    {
        #region Propriété
        /// <summary>
        /// Obient la valeur de DateTimePicker
        /// </summary>
        public override object Value
        {
            get
            {
                return dateTimeControl.Value;
            }
            set
            {
                dateTimeControl.Value = Convert.ToDateTime(value);
            }
        }

        /// <summary>
        /// Get the DateTimeControl included in this field
        /// </summary>
        public DateTimeControl DateTimeControl {
            get
            {
                return this.dateTimeControl;
            }
        }
        #endregion


        public DateTimeField(PropertyInfo PropertyInfo, Orientation OrientationFiled, Size SizeLabel, Size SizeControl, ConfigEntity ConfigEntity) : base(PropertyInfo, OrientationFiled, SizeLabel, SizeControl, ConfigEntity)
        {
            Size size_control = base.Size;
            InitializeComponent();
            dateTimeControl.ChangeSize(SizeControl)  ;
            this.Size = size_control;
        }
        public DateTimeField() : this(null, Orientation.Horizontal, new Size(50, 20), new Size(50, 20), null)
        {

        }

        private void dateTimeControl_ValueChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
    }
}
