using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace App.WinFrom.Fields.Controls
{

    /// <summary>
    /// Représente Le contôle DateTime 
    /// il support la culture Arabe
    /// </summary>
    public partial class DateTimeControl : UserControl
    {

        #region Evénement
        public event EventHandler ValueChanged;
        protected void onValueChanged(object sender, EventArgs e)
        {
            if(ValueChanged != null)
            ValueChanged(sender, e);
        }

        #endregion

        #region Propriété 
        public DateTime Value
        {
            get
            {
                
                return this.dateTimePicker.Value;
            }
            set
            {
                this.dateTimePicker.Value = value;
            }
        }
        #endregion


        List<CultureInfo> ListCultureInfo { get; set; }

        /// <summary>
        /// Format de la date 
        /// dddd/MMMM/yyyy h:m:s
        /// </summary>
        String Formet { get; set; }
        /// <summary>
        /// Indicate if the configuration of DateTime Cilture is true or false
        /// </summary>
        public bool Show_Config_Culture { get; private set; }


        #region Constructeurs

        public DateTimeControl(List<CultureInfo> ListCultureInfo)
        {
            InitializeComponent();
            if (ListCultureInfo != null)
            {
                this.Show_Config_Culture = true;
                this.ListCultureInfo = ListCultureInfo;
            }
            else
            {
                this.Show_Config_Culture = false;
                this.AutoSize = true;
                this.Controls.Clear();
                
                dateTimePicker.Dock = DockStyle.Fill;
                this.Controls.Add(dateTimePicker);
                this.Size = dateTimePicker.Size;
            }
        }
        public DateTimeControl() : this(null) { }
        #endregion
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            onValueChanged(sender, e);
        }

        private void DateTimeControl_Resize(object sender, EventArgs e)
        {
           
        }

        public void ChangeSize(Size size)
        {
            if (this.Show_Config_Culture)
                this.Size = new Size(size.Width, size.Height + 20);
            else
                this.Size = size;
        }
    }
}
