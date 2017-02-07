using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Attributes
{
    public class BaseAttribute :Attribute
    {
        /// <summary>
        /// Determine whether the annotation is locatable
        /// </summary>
        public bool Localizable { set; get; }



    }
}
