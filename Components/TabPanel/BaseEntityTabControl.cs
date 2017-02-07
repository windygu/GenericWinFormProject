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
using System.Reflection;
using App.WinFrom.Menu;
using App.WinForm.Entities;
using App.WinForm.Forms;

namespace App.WinForm.EntityManagement
{
    public partial class BaseEntityTabControl : UserControl
    {

        #region Propriétés
        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service { set; get; }

        /// <summary>
        /// Instance de filtre controle
        /// </summary>
        protected EntityFilterControl BaseFilterControl { set; get; }

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
        #endregion

        #region Evénement
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }
        #endregion

        #region Constructeur
        public BaseEntityTabControl()
        {
            InitializeComponent();
            
        }
        public BaseEntityTabControl(IBaseRepository Service,EntityFilterControl BaseFilterControl,Form MdiParent, BaseEntryForm Formulaire)
        {
            InitializeComponent();
            this.Service = Service;
            this.BaseFilterControl = BaseFilterControl;
            this.MdiParent = MdiParent;
            this.Formulaire = Formulaire;
            InitPropertyListDataGrid();
        }

        [Obsolete]
        protected void InitPropertyListDataGrid()
        {
            // [Bug]
            // Ajoutez la condition filtre 
            var requete = from i in Service.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(DataGridAttribute)) != null 
                          orderby ((DataGridAttribute)i.GetCustomAttribute(typeof(DataGridAttribute))).Ordre
                          select i;
            this.ListePropriete = requete.ToList<PropertyInfo>();
        }

        #endregion

        #region Load

        #endregion

        #region Editer une liste OneToMany


        /// <summary>
        /// Editer la collection OneToMany
        /// </summary>
        /// <param name="item">PropertyInfo de de la collection</param>
        /// <param name="obj">L'objet qui contient la collection</param>
        [Obsolete]
        protected void EditerCollection(PropertyInfo item, BaseEntity obj)
        {
            // Obient le Service de l'objet de Collection<Objet>
            Type type_objet_of_collection = item.PropertyType.GetGenericArguments()[0];
            IBaseRepository service_objet_of_collection = this.Service.CreateInstance_Of_Service_From_TypeEntity(type_objet_of_collection);

            // Valeur Initial du Filtre
            Dictionary<string, object> ValeursFiltre = new Dictionary<string, object>();
            ValeursFiltre[item.DeclaringType.Name] = obj.Id;
            EntityManagementForm form = new EntityManagementForm(service_objet_of_collection,null, ValeursFiltre, this.MdiParent);

            // Affichage de Fomulaire de gestion de la collection ManytoOne
            ShowEntityManagementForm Menu = new ShowEntityManagementForm(this.Service, (IBaseForm) this.MdiParent);
            Menu.Afficher(form);
        }
        #endregion
 

    }
}
