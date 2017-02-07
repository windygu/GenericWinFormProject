using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    /// <summary>
    /// Ajouter un nouveau Entité 
    /// </summary>
    public partial class EntityManagementControl
    {
        #region Filtre
        private void BaseFilterControl_RefreshEvent(object sender, EventArgs e)
        {
            this.Actualiser();
        }
        /// <summary>
        /// Afficher ou désafficher le filtre
        /// </summary>
        /// <param name="v"></param>
        private void ShowFilter(bool visible)
        {


            if (visible == true) throw new NotImplementedException("Cette méthode n'est pas implémenter pour la valeur True");

            this.Controls.Add(panelDataGrid);

            this.panelDataGrid.Dock = DockStyle.Fill;
            this.tabControl_MainManager.Dock = DockStyle.Fill;
            // this.panelDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Visible = visible;
        }
        #endregion
    }
}
