using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Attributes
{
    [AttributeUsage(AttributeTargets.Property,  AllowMultiple = false)]
    public class DisplayPropertyAttribute : Attribute
    {
        public DisplayPropertyAttribute()
        {
            
        }


        #region Display

        /// <summary>
        /// Indicates whether the property name exists in the glossary
        /// </summary>
        public bool isInGlossary;


        /// <summary>
        /// Indique le nom à afficher
        /// </summary>
        public string Titre { set; get; }
        /// <summary>
        /// Indique la description à afficher
        /// </summary>
        public string Description { set; get; }
        /// <summary>
        /// Le nom de la propriété à afficher dans ComBoBox
        /// </summary>
        public string DisplayMember { get; set; }
        #endregion

       

      

      

       
    }
}
