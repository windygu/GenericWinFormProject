using System.Windows.Forms;

namespace App.WinForm.Forms.FormMenu
{
    public interface IApplicationMenu : IBaseForm
    {
        /// <summary>
        /// Obtient le l'objet menu d'application
        /// </summary>
        /// <returns></returns>
        MenuStrip getMenuStrip();
    }
}