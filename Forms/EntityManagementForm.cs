using App.WinForm.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    /// <summary>
    /// Interface de mise à jour d'une entity
    /// </summary>
    public partial class EntityManagementForm : BaseForm
    {
        #region Contrôles
        public EntityManagementControl EntityManagementControl;
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
        public EntityManagementForm(
            IBaseRepository Service,
            BaseEntryForm formulaire,
            Dictionary<string, object> ValeursFiltre,
            Form FormApplicationMdi)
        {
            InitializeComponent();
            EntityManagementControl = new EntityManagementControl(Service,
                formulaire,
                null,null,
                ValeursFiltre, FormApplicationMdi);
            EntityManagementControl.Dock = DockStyle.Fill;

            this.Name = Service.GetType().ToString();
            this.Text = Service.getAttributesOfEntity().ManagementForm?.FormTitle;
            this.Controls.Add(EntityManagementControl);

        }

        /// <summary>
        /// Création d'une formulaire de gestion avec l'objet Service et 
        /// le formulaire générique
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        /// <param name="ValeursFiltre">Les valeurs de filtre</param>
        public EntityManagementForm(IBaseRepository Service,
            Dictionary<string, object> ValeursFiltre, Form FormApplicationMdi)
            :this(Service, null, ValeursFiltre, FormApplicationMdi)
        {
        }


        /// <summary>
        /// Création d'une gestion des entity avec Une Instance de l'objet Service
        /// et la formulaire généique et sans valeurs de filtre
        /// </summary>
        /// <param name="Service">Le service de gestion</param>
        public EntityManagementForm(IBaseRepository Service, Form FormApplicationMdi) :this(Service, null,null, FormApplicationMdi)
        {
        }


        /// <summary>
        /// Création d'une gestion avec une formulaire personalisé
        /// </summary>
        /// <param name="Formulaire">Une instance de formulaire de saisie, il est utilisr 
        /// pour la creation des autres instance en cas d'édition des objet
        /// </param>
        public EntityManagementForm(IBaseRepository Service,
            BaseEntryForm Formulaire, Form FormApplicationMdi) :this(Service, Formulaire, null, FormApplicationMdi)
        {
        }

        /// <summary>
        /// On ne pas Créer ce formulaire sans Paramétre
        /// ce Constructeur est ajouter seuelement pour supproer le mode désigne de Visual Studio 2015
        /// </summary>
        [Obsolete]
        public EntityManagementForm()
        {
            InitializeComponent();

        }

        #endregion

    }
}
