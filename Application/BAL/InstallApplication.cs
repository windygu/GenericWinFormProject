using App.WinForm.Attributes;
using App.WinForm.Entities.Application;
using App.WinForm.ModelData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Application.BAL
{
    public class InstallApplication
    {
       

       
        private Type TypeModelContext { get;  set; }

        public InstallApplication(Type type_model_context)
        {
            this.TypeModelContext = type_model_context;
           

        }



        /// <summary>
        /// Must be executed befor the first use of the application
        /// </summary>
        public void Install()
        {

        }
        /// <summary>
        /// Must be executed after the modification of the application
        /// </summary>
        public void Update()
        {
            //Update Table Menu form Entities
            var ModelContext = Activator.CreateInstance(TypeModelContext);
            IBaseRepository service = new GenericWinAppBaseRepository<MenuItemApplication>((DbContext)ModelContext);

            DbSet<MenuItemApplication> MenuItemApplicationSet =(DbSet < MenuItemApplication >) this.TypeModelContext.GetProperty("MenuItemApplications").GetValue(ModelContext);
            EntitiesModel entitiesModel = new EntitiesModel();
            Dictionary<Type, MenuAttribute> Dictionary_Type_MenyAttribute = entitiesModel.Get_All_Type_And_MenuAttributes();
            foreach (var item in Dictionary_Type_MenyAttribute.Values)
            {
             if (item.Group == null) continue;
                if (service.Recherche(new Dictionary<string, object> { { "Name", item.Group } }).Count == 0)
                    service.Save(new MenuItemApplication { Name = item.Group });
            }


        }
    }
}
