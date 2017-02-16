using App.WinForm.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.ModelData
{
    public class EntitiesModel
    {

        public List<Assembly> GetAll_Assembly_Contains_Entities()
        {
          return   AppDomain.CurrentDomain.GetAssemblies()
                   .Where(a => (!a.FullName.Contains("DynamicProxies")
                   && (a.FullName.Contains("Entities") || a.FullName.Contains(this.GetType().Assembly.FullName)))
                   ).Cast<Assembly>().ToList<Assembly>();
        }

        public Dictionary<Type, MenuAttribute> Get_All_Type_And_MenuAttributes()
        {
            Dictionary<Type, MenuAttribute> Dictionary_Type_MenyAttribute = new Dictionary<Type, MenuAttribute>();
            var ls_Type_MenyAttribute = (from assembly in this.GetAll_Assembly_Contains_Entities()
                                            from type in assembly.GetTypes()
                                            let attributes = type.GetCustomAttributes(typeof(MenuAttribute), true)
                                            where attributes != null && attributes.Length > 0
                                            select new { Type = type, ApplicationMenu = attributes.Cast<MenuAttribute>().First() }
           ).ToList();

            foreach (var item in ls_Type_MenyAttribute)
            {
                Dictionary_Type_MenyAttribute.Add(item.Type, item.ApplicationMenu);
            }
            return Dictionary_Type_MenyAttribute;
        }
    }
}
