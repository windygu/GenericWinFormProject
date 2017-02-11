using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.WinForm.Attributes;
using App.WinForm.EntityManagement;
using System.Reflection;

namespace App.WinForm
{
    /// <summary>
    /// Interface de mise à jour d'une entity
    /// </summary>
    public partial class EntityManagementControl : UserControl
    {

        #region Propriétés
        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service { set; get; }

        /// <summary>
        /// Instance de filtre controle
        /// </summary>
        public EntityFilterControl FilterControl { set; get; }

        /// <summary>
        /// Le formulaire de l'édition et d'insertion
        /// </summary>
        protected BaseEntryForm Formulaire { set; get; }

        /// <summary>
        /// La formulaire MdiParent de l'application
        /// il est utiliser pour afficher une interface de gestion
        /// </summary>
        protected Form MdiParent { set; get; }


        /// <summary>
        /// Obient ou définire la liste des propriété de l'entity en cours de gestion
        /// </summary>
        protected List<PropertyInfo> ListePropriete { set; get; }

        /// <summary>
        /// définir les valeurs initiaux du filtre
        /// </summary>
        Dictionary<string, object> ValeursFiltre { set; get; }


        public ConfigEntity ConfigEntity { get; private set; }
        #endregion

        #region Controls
        /// <summary>
        /// L'objet Binding source la classe hérité
        /// </summary>
        protected BindingSource BaseObjetBindingSource { set; get; }

        /// <summary>
        /// L'objet DataGrid de la classe hérité
        /// </summary>
        protected DataGridView BaseDataGridView { set; get; }

        /// <summary>
        /// Le formulaire MDI de l'application
        /// il sert à afficher 
        /// </summary>
        Form FormApplicationMdi { set; get; }

        /// <summary>
        /// Instance de filter control
        /// </summary>
    

        /// <summary>
        /// Instance de EntiteDataGridControl
        /// </summary>
        public EntityDataGridControl DataGridControl { get; private set; }
        #endregion

        #region Evénement
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }
        #endregion

        #region Constructeur
        /// <summary>
        ///  Création d'une interface de gestion des entity 
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        /// <param name="formulaire">
        /// Le formulaire spécifique à l'objet Entity, 
        /// pour ne pas utiliser le formulaire générique
        /// </param>
        /// <param name="ValeursFiltre">Les valeurs de filtre</param>
        public EntityManagementControl(
            IBaseRepository Service,
            BaseEntryForm Formulaire,
            EntityFilterControl FilterControl,
            EntityDataGridControl EntityDataGridControl,
            Dictionary<string, object> ValeursFiltre,
            Form FormApplicationMdi)
        {
            InitializeComponent();
            this.Service = Service;
            this.Formulaire = Formulaire;
            this.FilterControl = FilterControl;
            this.DataGridControl = EntityDataGridControl;
            this.ValeursFiltre = ValeursFiltre;
            this.FormApplicationMdi = FormApplicationMdi;

            

            initControls();
        }

        /// <summary>
        /// Création d'une formulaire de gestion avec l'objet Service et 
        /// le formulaire générique
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        /// <param name="ValeursFiltre">Les valeurs de filtre</param>
        public EntityManagementControl(IBaseRepository Service,
            Dictionary<string, object> ValeursFiltre, Form FormApplicationMdi)
            : this(Service, null,null,null, ValeursFiltre, FormApplicationMdi)
        {
        }


        /// <summary>
        /// Création d'une gestion des entity avec Une Instance de l'objet Service
        /// et la formulaire généique et sans valeurs de filtre
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        public EntityManagementControl(IBaseRepository Service, Form FormApplicationMdi) 
            : this(Service, null, null,null,null, FormApplicationMdi)
        {
        }


        /// <summary>
        /// Création d'une gestion avec une formulaire personalisé
        /// </summary>
        /// <param name="Formulaire">Une instance de formulaire de saisie, il est utilisr 
        /// pour la creation des autres instance en cas d'édition des objet
        /// </param>
        public EntityManagementControl(IBaseRepository Service,
            BaseEntryForm Formulaire, Form FormApplicationMdi) : this(Service, Formulaire,null,null, null, FormApplicationMdi)
        {
        }



        #endregion

      
        #region Actualiser
        /// <summary>
        /// Affichage des information dans DataGrid selon le filtre s'il exsiste
        /// </summary> 
        public void Actualiser()
        {
            this.DataGridControl.Actualiser(this.FilterControl.CritereRechercheFiltre());
        }
        #endregion

        #region EntityManagementControl 
       
        private void EntityManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Solution de problème de fermiture de la forme en cas de validation
            // car le formulaire ne veut pas se fermer si il y a des validation active dans 
            // le formilaire
            e.Cancel = false;
        }

        #endregion

      

    }
}
