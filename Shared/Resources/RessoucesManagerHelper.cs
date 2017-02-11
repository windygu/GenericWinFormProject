using App.WinForm.Application.Presentation.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.WinForm.Shared.Resources
{
    public class RessoucesManagerHelper
    {
        static List<string> resourceNames = new List<string>();

        /// <summary>
        /// Check if resource existe
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public  Boolean ResourceExists(string resourceName)
        {
           
            if (resourceNames.Count == 0)
            {

                Assembly.GetExecutingAssembly();
                foreach (Assembly item in 
                    AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a=>(a.FullName.Contains("Entities") || a.FullName.Contains(this.GetType().Assembly.FullName))))
                {
                    resourceNames.AddRange(item.GetManifestResourceNames());
                }
            }
            return resourceNames.Contains(resourceName + ".resources");
        }

        /// <summary>
        /// Set Ressouce Manager of the entity and All its BaseEntity
        /// </summary>
        public static void FillResourcesManager(Type type_entity, Dictionary<string, ResourceManager> RessoucesManagers)
        {
            
            string RessouceFullName = type_entity.Namespace + ".Resources." + type_entity.Name + "." + type_entity.Name;
            if (new RessoucesManagerHelper().ResourceExists(RessouceFullName))
                RessoucesManagers.Add(type_entity.Name, new ResourceManager(RessouceFullName, type_entity.Assembly));
            else
            {
                MessageToUser.AddMessage(MessageToUser.Category.BusinessRule, "The resource file does not exist : " + RessouceFullName);
                return;
            }
            if (type_entity.BaseType != typeof(object))
                FillResourcesManager(type_entity.BaseType, RessoucesManagers);
        }

        internal static void FillResourcesManager(Type typeEntity, object ressoucesManagers)
        {
            throw new NotImplementedException();
        }
    }
}
