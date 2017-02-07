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


        #region Constructeurs

        public DateTimeControl(List<CultureInfo> ListCultureInfo)
        {
            InitializeComponent();
            if (ListCultureInfo != null)
            {
                this.ListCultureInfo = ListCultureInfo;
            }
            else
            {
                this.AutoSize = true;
                this.Controls.Clear();
                
                dateTimePicker.Dock = DockStyle.Fill;
                this.Controls.Add(dateTimePicker);
            }
        }
        public DateTimeControl() : this(null) { }
        #endregion
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            onValueChanged(sender, e);
        }
    }
}
