using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
 
    public partial class BaseEntryForm
    {

        #region Enregistrer et Annuler
        /// <summary>
        /// Le button d'enregistremnet du formulaire de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btEnregistrer_Click(object sender, EventArgs e)
        {
            // Varéfier la validation 
            bool validation = true;
            if (ValidationManager.hasValidationErrors(this.Controls))
                return;

            this.ReadFormToEntity();

            if (validation)
            {
                if (Service.Save(this.Entity) > 0)
                {
                    MessageBox.Show(string.Format("'{0}' a été bien enregistrer", this.Entity.ToString()));
                    onEnregistrerClick(this, e);
                }
                else
                {
                    MessageBox.Show(
                        string.Format("L'information n'est pas enregistrer car il n'y a pas des modifications"
                        , this.Entity.ToString())
                        , "Il n'y a pas des modification"

                        );
                }

            }
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {

            onAnnulerClick(this, e);

        }

        void IBaseEntryForm.Lire()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
