using System;
using System.Globalization;
using System.Resources;

namespace App.WinForm.Attributes
{
    /// <summary>
    ///  The configuration of the management interface
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ManagementFormAttribute : BaseAttribute
    {

        public Type RessourceType {
            set;
            get; }

        #region Order By
        /// <summary>
        /// The property to use to sort it in order
        /// </summary>
        public string OrderByProperty { get; set; }

        /// <summary>
        /// Indicates whether the display of objects in dataGrid is done with the order
        /// </summary>
        public bool isDisplayWithOrder { get; set; }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public string FormTitle { get; set; }
        public string TitreButtonAjouter { get; set; }
        public string TitrePageGridView { get; set; }

        



    }
}