using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class EntityManagementControl
    {
        #region Formulaire de mise à jour
        /// <summary>
        /// Exécuter aprés un click sur le button éditer sur le formulaire de mise à jour
        /// </summary>
        private void Form_EditerClick(object sender, EventArgs e)
        {
            BaseEntryForm form = (BaseEntryForm)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;


            TabPage tabEditer = this.tabControl_MainManager.TabPages[tabEditerName];
            // Suppression de la page Editer
            this.tabControl_MainManager.TabPages.Remove(tabEditer);
            this.Actualiser();
        }

        /// <summary>
        /// Exécuter aprés un click sur le button annuler sur le formulaire de mise à jour
        /// </summary>
        private void Form_AnnulerEditerClick(object sender, EventArgs e)
        {
            BaseEntryForm form = (BaseEntryForm)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;
            TabPage tabEditer = this.tabControl_MainManager.TabPages[tabEditerName];
            tabControl_MainManager.TabPages.Remove(tabEditer);
        }
        #endregion
    }
}
