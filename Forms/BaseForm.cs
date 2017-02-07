
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Forms
{
    public class BaseForm : Form , IBaseForm
    {
        /// <summary>
        /// Reload the form
        /// </summary>
       public virtual void Reload() { } 
        

      
        
    }
}
