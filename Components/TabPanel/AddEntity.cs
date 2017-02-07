using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.EntityManagement
{
    /// <summary>
    /// Ajouter un nouveau Entité 
    /// </summary>
    public partial class EntityTabControl
    {
        //#region Ajouter un entité

        ///// <summary>
        ///// Boutton Ajouter un nouveau entité
        ///// </summary>
        //public void bt_Ajouter_Click(object sender, EventArgs e)
        //{

        //    // Insertion de la page TabAjouter s'il n'existe pas
        //    if (tabControl.TabPages.IndexOfKey("TabAjouter") == -1)
        //    {
        //        // 
        //        // Création de TabPage - Ajouter 
        //        //
        //        TabPage tabAjouter = new TabPage();
        //        tabAjouter.Text = this.Service.getAttributesOfEntity().AddButton?.Title;
        //        tabAjouter.Name = "TabAjouter";
        //        tabControl.TabPages.Add(tabAjouter);
        //        tabControl.CausesValidation = false;

        //        //
        //        // Insertion du formulaire 
        //        //
        //        BaseEntity Entity = (BaseEntity)this.Service.CreateInstanceObjet();
        //        BaseEntryForm form = Formulaire.CreateInstance(Service, Entity, this.BaseFilterControl.CritereRechercheFiltre());
        //        form.Name = "Form";
        //        form.Dock = DockStyle.Fill;
        //        form.WriteEntityToField(this.BaseFilterControl.CritereRechercheFiltre());


        //        this.tabControl.TabPages["TabAjouter"].Controls.Add(form);
        //        tabControl.SelectedTab = tabAjouter;
        //        form.EnregistrerClick += Form_EnregistrerClick;
        //        form.AnnulerClick += Form_AnnulerAjouterClick;
        //    }
        //}
        ///// <summary>
        ///// Enregistrer un Stagiaire
        ///// </summary>
        //private void Form_EnregistrerClick(object sender, EventArgs e)
        //{
        //    TabPage tabAjouter = this.tabControl.TabPages["TabAjouter"];
        //    BaseEntryForm form = (BaseEntryForm)tabAjouter.Controls
        //        .Find("Form", false).First();
        //    this.tabControl.TabPages.Remove(tabAjouter);
        //    this.Actualiser();
        //}
        ///// <summary>
        ///// Annuler l'insertion d'un stagiaire
        ///// </summary>
        //private void Form_AnnulerAjouterClick(object sender, EventArgs e)
        //{
        //    TabPage tabAjouter = this.tabControl.TabPages["TabAjouter"];
        //    tabControl.TabPages.Remove(tabAjouter);
        //}

        #endregion
    }
}
