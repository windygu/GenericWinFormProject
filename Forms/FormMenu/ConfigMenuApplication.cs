using App.WinForm.Attributes;
using App.WinForm.Entities;
using App.WinForm.Entities.Application;
using App.WinForm.ModelData;
using App.WinForm.Security;
using App.WinFrom.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace App.WinForm.Forms.FormMenu
{
    /// <summary>
    /// Configuration de Menu d'application
    /// </summary>
    public class ConfigMenuApplication
    {
        #region Params
        private IApplicationMenu formMenu;
        private ShowEntityManagementForm ShowManagementForm { set; get; }
        #endregion
        #region Variables
        private MenuStrip menuStrip;
        private Dictionary<string, Type> MenuItems { set; get; }
        private IBaseRepository Service { get;  set; }
        #endregion

        public ConfigMenuApplication(IBaseRepository Service, IApplicationMenu formMenu)
        {
            this.formMenu = formMenu;
            this.menuStrip = formMenu.getMenuStrip();
            this.Service = Service;
            MenuItems = new Dictionary<string, Type>();
            this.ShowManagementForm = new ShowEntityManagementForm(Service, formMenu);
            this.CreateMenu();
        }


        private void CreateMenu()
        {
            // Create Parent Menu from ManuItemApplication Table
            foreach (MenuItemApplication menuItemApplication in this.Service.GetAll())
            {
                // ToolStripMenu
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = "toolStripMenuItem" + menuItemApplication.Name;
                toolStripMenuItem.Size = new System.Drawing.Size(82, 20);
                toolStripMenuItem.Text = menuItemApplication.TitrleCulture(ApplicationInstance.Session.CultureInfo);
                this.menuStrip.Items.Add(toolStripMenuItem);
            }



            Dictionary<Type, MenuAttribute> MenuAttributes_And_Types = new EntitiesModel().Get_All_Type_And_MenuAttributes();

 
            foreach (var menuAttributes_And_Types in MenuAttributes_And_Types)
            {

                ConfigEntity attributesOfEntity = new ConfigEntity(menuAttributes_And_Types.Key);

                // ToolStripMenu
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = "toolStripMenuItem" + attributesOfEntity.Menu.Title;
                toolStripMenuItem.Size = new System.Drawing.Size(82, 20);
                toolStripMenuItem.Text = attributesOfEntity.Menu.Title;
                toolStripMenuItem.Click += ToolStripMenuItem_Click;
                MenuItems.Add(toolStripMenuItem.Name, menuAttributes_And_Types.Key);

                // Find groupe
                if (attributesOfEntity.Menu.Group != null) {
                    ToolStripItem GroupeToolStripItem = this.menuStrip.Items.Find("toolStripMenuItem" + attributesOfEntity.Menu.Group, true).SingleOrDefault();
                    ToolStripMenuItem GroupeToolStripMenuItem = GroupeToolStripItem as ToolStripMenuItem;
                    if(GroupeToolStripMenuItem != null)
                      GroupeToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                }else
                {
                    this.menuStrip.Items.Add(toolStripMenuItem);
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            this.ShowManagementForm.AfficherUneGestion(MenuItems[item.Name]);
        }
    }
}