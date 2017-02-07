using App.Shared.AttributesManager;
using App.WinForm.Attributes;
using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class EntityManagementControl
    {
        #region DataGrid
        /// <summary>
        /// Exécuter aprés un click sur le button editer dans DataGrid
        /// </summary>
        private void EntityDataGridControl_EditClick(object sender, EventArgs e)
        {
            BaseEntity entity = (BaseEntity)this.DataGridControl.SelectedEntity;
            string tabEditerName = "TabEditer-" + entity.Id;

            if (tabControl_MainManager.TabPages.IndexOfKey(tabEditerName) == -1)
            {
                // Création de Tab
                TabPage tabEditer = new TabPage();
                tabEditer.Text = entity.ToString();
                tabEditer.Name = tabEditerName;
                tabControl_MainManager.TabPages.Add(tabEditer);
                tabControl_MainManager.CausesValidation = false;
                // Insertion du formulaire de mise à jour
                BaseEntryForm form = Formulaire.CreateInstance(this.Service, entity, null);
                form.Name = "EntityForm";
                form.Dock = DockStyle.Fill;
                this.tabControl_MainManager.TabPages[tabEditerName].Controls.Add(form);
                tabControl_MainManager.SelectedTab = tabEditer;
                form.WriteEntityToField(this.FilterControl.CritereRechercheFiltre());
                form.EnregistrerClick += Form_EditerClick;
                form.AnnulerClick += Form_AnnulerEditerClick;

            }
            else
            {
                TabPage tabEditer = this.tabControl_MainManager.TabPages[tabEditerName];
                tabControl_MainManager.SelectedTab = tabEditer;
            }
        }

        /// <summary>
        /// Edit the collection OneToMany
        /// </summary>
        private void DataGridControl_EditManyToOneCollection(object sender, EventArgs e)
        {
            // Params
            BaseEntity obj = this.DataGridControl.SelectedEntity;
            PropertyInfo item = this.DataGridControl.SelectedProperty;

            // Annuler si la collection en Edition
            if (tabControlManagers.TabPages.ContainsKey(obj + item.Name))
            {
                tabControlManagers.SelectedTab = tabControlManagers.TabPages[obj + item.Name];
                return;
            }

            // Obient le Service de l'objet de Collection<Objet>
            Type type_objet_of_collection = item.PropertyType.GetGenericArguments()[0];
            IBaseRepository service_objet_of_collection = this.Service.CreateInstance_Of_Service_From_TypeEntity(type_objet_of_collection);
            // Valeur Initial du Filtre
            Dictionary<string, object> ValeursFiltre = new Dictionary<string, object>();
            ValeursFiltre[item.DeclaringType.Name] = obj.Id;
            EntityManagementControl form = new EntityManagementControl(service_objet_of_collection, ValeursFiltre, this.MdiParent);
            form.ShowFilter(false);
            // Insertion de la gestion à l'interface
            this.AddManyToOneManager(form, item, obj);

        }

        /// <summary>
        /// Ajouter une gestion ManyToOne à l'interface
        /// </summary>
        /// <param name="form"></param>
        private void AddManyToOneManager(EntityManagementControl form, PropertyInfo item, BaseEntity obj)
        {

            // Annotation de l'propriété
            DisplayPropertyAttribute affichageProperty = new ConfigProperty(item, this.ConfigEntity)
                .DisplayProperty;


            // Préparation de l'interface s'il n'est pas encors préparer
            if (this.tabControlManagers.Visible == false)
            {
                this.tabControlManagers.Visible = true;
                this.tabControl_MainManager.Dock = DockStyle.Fill;
                this.tabControlManagers.TabPages["main"].Text = this.ConfigEntity.ManagementForm.FormTitle;
                this.tabControlManagers.TabPages["main"].Controls.Add(this.tabControl_MainManager);
                this.tabControlManagers.Dock = DockStyle.Fill;
                this.panelDataGrid.Controls.Add(this.tabControlManagers);
            }

            // Création d'une TabPage dans TabControlManagers
            TabPage TabPageManyToOne = new TabPage();
            TabPageManyToOne.Name = obj + item.Name;
            TabPageManyToOne.Text = affichageProperty.Titre + " : " + obj;

            this.tabControlManagers.TabPages.Add(TabPageManyToOne);

            // Insertion du formulaire
            form.Dock = DockStyle.Fill;
            TabPageManyToOne.Controls.Add(form);
            this.tabControlManagers.SelectedTab = TabPageManyToOne;

        }

        private void DataGridControl_EditManyToManyCollection(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
