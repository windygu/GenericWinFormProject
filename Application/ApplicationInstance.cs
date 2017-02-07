using App.WinForm.Application.Security;
using App.WinForm.Entities;
using App.WinForm.Entities.Authentication;
using App.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Security
{
    public class  ApplicationInstance
    {
        private static Session _Session;
        public static Session Session {
            set { _Session = value; }
            get {
                // si la session est null, on initialise l'application
                if (_Session == null) initApplication();
                return _Session;
            }
        }

        static ApplicationInstance()
        {
     


        }

        /// <summary>
        /// Exécuter pour faire appelle au Constructeur 
        /// </summary>
        public static void initApplication()
        {
            User user = new User();
            user.Name = "ES-SARRAJ";
            user.FirstName = "Fouad";

            BaseForm MdiForm = new BaseForm();
            MdiForm.IsMdiContainer = true;

            ApplicationInstance.Session = new Session(MdiForm, user, Thread.CurrentThread.CurrentCulture);
        }
    }
}
