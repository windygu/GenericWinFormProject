using System;

namespace App.WinForm.Attributes { 
    public class DataGridAttribute : Attribute
    {
        #region DataGrid
        /// <summary>
        /// Indique si la propriété fait partie de DataGrid
        /// </summary>
        public bool isGridView { set; get; }
        public int Ordre { get; set; }

        /// <summary>
        /// Indique la taille de la colonne dans DataGrid
        /// </summary>
        public int WidthColonne { get; set; }
        #endregion
    }
}