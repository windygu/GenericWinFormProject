using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm
{
    /// <summary>
    /// Le contôle DataGrid pour l'affichage et l'édition d'une liste des entités
    /// </summary>
    public interface IEntityDataGrideControl
    {
        #region Evénements
        /// <summary>
        /// Evénement Editer Click
        /// </summary>
        event EventHandler EditClick;

        /// <summary>
        /// Evénement Editer ManyToOneCollection Click
        /// </summary>
        event EventHandler EditManyToOneCollection;

        /// <summary>
        /// Evénement Editer ManyToOneCollection Click
        /// </summary>
        event EventHandler EditManyToManyCollection;
        #endregion

        /// <summary>
        /// l'entité selectioné dans le DataGridView
        /// </summary>
        /// <returns></returns>
        BaseEntity SelectedEntity {  get; }
    }
}
