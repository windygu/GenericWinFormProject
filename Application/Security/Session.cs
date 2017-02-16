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

namespace App.WinForm.Application.Security
{
    public class Session
    {
        #region Params
        /// <summary>
        /// Application Menu
        /// </summary>
        public BaseForm ApplicationMenu { set; get; }
        /// <summary>
        /// The connected user
        /// </summary>
        public  User user { set; get; }
        #endregion

        #region Properties
        private CultureInfo cultureInfo;
        /// <summary>
        /// The language of the user
        /// </summary>
        public  CultureInfo CultureInfo {
            set
            {
                if(cultureInfo != value)
                {
                    cultureInfo = value;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                }
            }
            get
            {
                return cultureInfo;
            }
        }
        #endregion

        #region Constructor
        public Session(BaseForm ApplicationMenu, User user,CultureInfo CultureInfo)
        {
            this.ApplicationMenu = ApplicationMenu;
            this.user = user;
            this.CultureInfo = CultureInfo;

          
        }

        #endregion

        /// <summary>
        /// Change the cultue of Application
        /// </summary>
        /// <param name="cultureInfo"></param>
        public void Change_Culture(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            this.cultureInfo = cultureInfo;

            this.ApplicationMenu.Reload();

            //List<Form> OpenForm = Application.OpenForms.Cast<Form>().ToList<Form>();
            //foreach (Form item in OpenForm)
            //{
            //    BaseForm baseForm = item as BaseForm;
            //    if(baseForm != null)
            //    {
            //        baseForm.Reload();
            //    }
            //}

        }
 
    }
}
