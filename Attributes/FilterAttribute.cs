using System;
using System.Runtime.CompilerServices;

namespace App.WinForm.Attributes
{
    public class FilterAttribute : Attribute
    {
        #region Filter
        /// <summary>
        /// Indique si la proriété fait partie du filtre de recherhe 
        /// l'attribut doit être dans DataGrid
        /// </summary>
        public bool Filtre { get; set; }
        /// <summary>
        /// Si la valeur est vide dans le filtre
        /// </summary>
        public bool isValeurFiltreVide { get; set; }


        public int Ordre { get; set; }


        public int WidthControl { set; get; }


        #endregion

        public FilterAttribute([CallerMemberName] string propertyName = null)
        {
            
        }
    }
}