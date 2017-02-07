using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.EntityManagement
{
    public partial class EntityTabControl
    {
        //#region Editer 
        ///// <summary>
        ///// Editer un objet séléctioné du DataGridView
        ///// </summary>
        //private void EditerObjet()
        //{
        //    BaseEntity entity = (BaseEntity)ObjetBindingSource.Current;
        //    string tabEditerName = "TabEditer-" + entity.Id;

        //    if (tabControl.TabPages.IndexOfKey(tabEditerName) == -1)
        //    {
        //        // Création de Tab
        //        TabPage tabEditer = new TabPage();
        //        tabEditer.Text = entity.ToString();
        //        tabEditer.Name = tabEditerName;
        //        tabControl.TabPages.Add(tabEditer);
        //        tabControl.CausesValidation = false;

        //        // Insertion du formulaire 
        //        BaseEntryForm form = Formulaire.CreateInstance(this.Service, entity, null);
        //        form.Name = "EntityForm";
        //        form.Dock = DockStyle.Fill;

        //        this.tabControl.TabPages[tabEditerName].Controls.Add(form);
        //        tabControl.SelectedTab = tabEditer;

        //        form.WriteEntityToField(this.BaseFilterControl.CritereRechercheFiltre());
        //        form.EnregistrerClick += Form_EditerClick;
        //        form.AnnulerClick += Form_AnnulerEditerClick;

        //    }
        //    else
        //    {
        //        TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
        //        tabControl.SelectedTab = tabEditer;
        //    }


        //}
        //private void Form_EditerClick(object sender, EventArgs e)
        //{
        //    BaseEntryForm form = (BaseEntryForm)sender;
        //    BaseEntity entity = form.Entity;
        //    string tabEditerName = "TabEditer-" + entity.Id;


        //    TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
        //    // Suppression de la page Editer
        //    this.tabControl.TabPages.Remove(tabEditer);
        //    this.Actualiser();
        //}

        //private void Form_AnnulerEditerClick(object sender, EventArgs e)
        //{
        //    BaseEntryForm form = (BaseEntryForm)sender;
        //    BaseEntity entity = form.Entity;
        //    string tabEditerName = "TabEditer-" + entity.Id;
        //    TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
        //    tabControl.TabPages.Remove(tabEditer);
        //}
        //#endregion
    }
}
