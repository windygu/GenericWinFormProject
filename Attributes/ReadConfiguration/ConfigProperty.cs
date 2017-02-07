using App.WinForm;
using App.WinForm.Application.Presentation.Messages;
using App.WinForm.Attributes;
using App.WinForm.Entities.Resources.Glossary;
using App.WinForm.Security;
using App.WinForm.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.AttributesManager
{
    /// <summary>
    /// Read Property Configuration
    /// </summary>
    public class ConfigProperty
    {
        #region Property
        public DisplayPropertyAttribute DisplayProperty { set; get; }
        public RelationshipAttribute Relationship { set; get; }

        public EntryFormAttribute EntryForm { set; get; }
        public FilterAttribute Filter { set; get; }
        public DataGridAttribute DataGrid { set; get; }
        #endregion

        #region Variables
        private Type TypeOfEntity { set; get; }
        public bool Localizable { get; private set; }
        public CultureInfo CultureInfo { get; private set; }
        public PropertyInfo PropertyInfo { get; private set; }
        public ConfigEntity ConfigEntity { get; private set; }



        /// <summary>
        ///  Resource Manager of the Entity and its BaseType
        /// </summary>
        Dictionary<string, ResourceManager> RessoucesManagers = new Dictionary<string, ResourceManager>();
        #endregion

        public ConfigProperty(PropertyInfo propertyInfo, ConfigEntity configEntity)
        {

            this.PropertyInfo = propertyInfo;
            this.ConfigEntity = configEntity;
            //Fill RessouceManager
            this.RessoucesManagers = this.ConfigEntity.RessoucesManagers;


            // Culture Info
            this.CultureInfo = ApplicationInstance.Session.CultureInfo;

            // Localizable
            this.TypeOfEntity = propertyInfo.ReflectedType;
            this.Localizable = this.ConfigEntity.DisplayEntity.Localizable;

            
           
            //
            // DisplayProperty
            //
            #region DisplayProperty
            Attribute DisplayProperty = propertyInfo.GetCustomAttribute(typeof(DisplayPropertyAttribute));
            this.DisplayProperty = DisplayProperty as DisplayPropertyAttribute;
            if (this.DisplayProperty == null)
            {
                if (this.Localizable == false)
                    throw new AnnotationNotExistException("DisplayPropertyAttribute :" + propertyInfo.ToString());
                this.DisplayProperty = new DisplayPropertyAttribute();
            }
            if (this.DisplayProperty.isInGlossary)
            {
                string GlossaryRessouceFullName = "App.WinForm.Entities.Resources.Glossary.Glossary";
                ResourceManager GlossaryResourceManager = null;
                GlossaryResourceManager = new ResourceManager(GlossaryRessouceFullName, typeof(Glossary).Assembly);
                string title = GlossaryResourceManager.GetString(propertyInfo.Name, this.CultureInfo);
                if (title == null)
                    this.DisplayProperty.Titre = this.CultureInfo.Name + "_Glossary_" + propertyInfo.Name;
                else
                    this.DisplayProperty.Titre = title;
            }
            else
            {
                this.DisplayProperty.Titre = GetStringFromRessource(propertyInfo.Name);
            }
            #endregion

            //
            // EntryForm
            //
            Attribute EntryForm = propertyInfo.GetCustomAttribute(typeof(EntryFormAttribute));
            this.EntryForm = EntryForm as EntryFormAttribute;

            //
            // DataGrid
            //
            Attribute DataGrid = propertyInfo.GetCustomAttribute(typeof(DataGridAttribute));
            this.DataGrid = DataGrid as DataGridAttribute;
            // Order 
            if (this.EntryForm != null && this.EntryForm.Ordre > 0
                && this.DataGrid != null && this.DataGrid.Ordre == 0)
                this.DataGrid.Ordre = this.EntryForm.Ordre;

            //
            // Filter
            //
            Attribute Filter = propertyInfo.GetCustomAttribute(typeof(FilterAttribute));
            this.Filter = Filter as FilterAttribute;

            //
            // Relationship
            //
            Attribute Relationship = propertyInfo.GetCustomAttribute(typeof(RelationshipAttribute));
            this.Relationship = Relationship as RelationshipAttribute;
        }

       

        private string GetStringFromRessource(string key, bool return_null_if_nat_exist = false)
        {
            string msg = null;
            foreach (var item in RessoucesManagers.Values)
            {
              string text;
              text = item.GetString(key, this.CultureInfo);
              if(text != null)
                {
                    msg = text;
                    break;
                }
            }

            if (msg == null && !return_null_if_nat_exist)
                msg = this.CultureInfo.Name + "_" + key;
            return msg;
        }
    }
}
