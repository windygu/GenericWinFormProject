using App.Shared.AttributesManager;
using App.WinForm.Attributes;
using App.WinForm.Fields;
using App.WinForm.Entities;
using App.WinFrom.Fields;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.WinForm.Shared.Resources;
using System.Resources;

namespace App.WinForm
{
    public partial class BaseEntryForm
    {

        /// <summary>
        /// Création et Initalisation des contrôles du formulaire
        /// </summary>
        private void GenerateFormIfNotGenerated()
        {
            // Generate if not generated
            if (!this.AutoGenerateField || this.isGeneratedForm) return;

            this.isGeneratedForm = true;

            #region Taille par défaut
            // Positions et Tailles par défaut
            int y_field = 0;
            int x_field = 0;
            int width_label = 100;
            int height_label = 10;
            int width_control = 200;
            int height_control = 25;
            int width_groueBox = 100;
            int height_groueBox = 200; // il ne sera pas utilisé 

            // Orientation par défaut
            Orientation orientation = Orientation.Vertical;
            #endregion

            #region Préparation de l'interface par Panel et GroupeBox
            // Initalisation de l'interface avec TabControl 
            this.InitTabPageInterface();

            // Création des groupBox s'il existe
            Dictionary<string, Control> GroupesBoxMainContainers = new Dictionary<string, Control>();
            this.CreateGroupesBoxes(GroupesBoxMainContainers, width_groueBox, height_groueBox);
            #endregion

            // L'index de la touche Entrer
            int TabIndex = 0;

            var listeProprite = from i in this.Service.TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(EntryFormAttribute)) != null
                                orderby ((EntryFormAttribute)i.GetCustomAttribute(typeof(EntryFormAttribute))).Ordre
                                select i;



            // Affichage des champs par leurs type
            foreach (PropertyInfo item in listeProprite)
            {
                #region Recalcule des valeurs pardéfaut selon l'annotation de chauqe champs
                // l'annotation 
                ConfigProperty configProperty = new ConfigProperty(item, this.ConfigEntity);

                // Taile du Field
                int width_control_config = width_control;
                if (configProperty.EntryForm?.WidthControl != 0)
                    width_control_config = configProperty.EntryForm.WidthControl;

                // Orientation
                Orientation orientation_config = orientation;
                if (configProperty.EntryForm?.UseOrientationField == true)
                    orientation_config = configProperty.EntryForm.OrientationField;
                #endregion

                Control field_control = null;
                Control FiledContainner = this.ConteneurFormulaire ;
                if (configProperty.EntryForm?.GroupeBox != null && configProperty.EntryForm?.GroupeBox != string.Empty)
                    FiledContainner = GroupesBoxMainContainers[configProperty.EntryForm?.GroupeBox];


                switch (item.PropertyType.Name)
                {
                    #region Champs String
                    case "String":


                        StringField stringFiled = new StringField(
                            item,
                            orientation_config,
                            new Size(width_label, height_label),
                            new Size(width_control_config, height_control),
                            this.ConfigEntity);
                        stringFiled.Location = new System.Drawing.Point(x_field, y_field);
                        stringFiled.Name = item.Name;
                        stringFiled.TabIndex = ++TabIndex;
                        stringFiled.Text_Label = configProperty.DisplayProperty.Titre;
                        stringFiled.FieldChanged += ControlPropriete_ValueChanged;
                        if (configProperty.EntryForm?.isOblegatoir == true)
                            stringFiled.ValidatingFiled += textBoxString_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(stringFiled);
                        field_control = stringFiled;

                        break;
                    #endregion

                    #region Champs Int32
                    case "Int32":

                        Int32Filed int32Filed = new Int32Filed(
                           item,
                           orientation_config,
                           new Size(width_label, height_label),
                           new Size(width_control_config, height_control),
                           this.ConfigEntity);
                        int32Filed.Location = new System.Drawing.Point(x_field, y_field);
                        int32Filed.Name = item.Name;
                        int32Filed.TabIndex = ++TabIndex;
                        int32Filed.Text_Label = configProperty.DisplayProperty.Titre;
                        int32Filed.FieldChanged += ControlPropriete_ValueChanged;
                        if (configProperty.EntryForm?.isOblegatoir == true)
                            int32Filed.ValidatingFiled += TextBoxInt32_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(int32Filed);
                        field_control = int32Filed;
                        break;
                    #endregion

                    #region Champs DateTime
                    case "DateTime":

                        DateTimeField dateTimeField = new DateTimeField(
                         item,
                         orientation_config,
                         new Size(width_label, height_label),
                         new Size(width_control_config, height_control),
                         this.ConfigEntity);
                         
                        dateTimeField.Location = new System.Drawing.Point(x_field, y_field);
                        dateTimeField.Name = item.Name;
                        dateTimeField.TabIndex = ++TabIndex;
                        dateTimeField.Text_Label = configProperty.DisplayProperty.Titre;
                        dateTimeField.FieldChanged += ControlPropriete_ValueChanged;
                        if (configProperty.EntryForm?.isOblegatoir == true)
                            dateTimeField.ValidatingFiled += DateTimePicker_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(dateTimeField);
                        field_control = dateTimeField;
                        break;
                    #endregion

                    default:
                        {
                            #region Champs : ManyToOne
                            if (configProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToOne)
                            {

                                // Déterminer le contenue du Field ManyToOne : GroupeBox ou Panel
                                Control ConteneurManyToMany = this.ConteneurFormulaire;
                                if (configProperty.EntryForm?.GroupeBox != null && configProperty.EntryForm?.GroupeBox != string.Empty)
                                    ConteneurManyToMany = GroupesBoxMainContainers[configProperty.EntryForm?.GroupeBox];

                                // Création de champs ManyToOneField
                                Int64 InitValue = 0;
                                //if (ValeursFiltre != null && ValeursFiltre.Keys.Contains(properperty.DisplayProperty.TitretyInfo.Name))
                                //    default_value = (Int64)ValeursFiltre[propertyInfo.Name];

                                ManyToOneField manyToOneField = new ManyToOneField(this.Service, item,
                                   ConteneurManyToMany, orientation_config,
                                    new Size(width_label, height_label),
                                   new Size(width_control_config, height_control), InitValue, this.ConfigEntity
                                    );
                                manyToOneField.Location = new System.Drawing.Point(x_field, y_field);
                                manyToOneField.Name = item.Name;
                                manyToOneField.TabIndex = ++TabIndex;
                                manyToOneField.Text_Label = configProperty.DisplayProperty.Titre;
                                manyToOneField.FieldChanged += ControlPropriete_ValueChanged;
                                if (configProperty.EntryForm?.isOblegatoir == true)
                                    manyToOneField.Validating += ComboBox_Validating;
                                this.ConteneurFormulaire.Controls.Add(manyToOneField);
                                field_control = manyToOneField;
                            }
                            #endregion

                            #region Champs ManyToMany
                            if (configProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToMany)
                            {
                                
                                if (configProperty.EntryForm?.TabPage == true)
                                {
                                    TabPage tabPage = new TabPage();
                                    tabPage.Name = "tabPage" + item.Name;
                                    tabPage.Text = configProperty.DisplayProperty.Titre;
                                    tabControlForm.TabPages.Add(tabPage);
                                    FiledContainner = tabPage;
                                }
                                
 
                                //Trouver les Valeurs par défaut
                                List<BaseEntity> ls_default_value = null;
                                if (this.Entity != null)
                                {
                                    IList ls_obj = item.GetValue(this.Entity) as IList;

                                    if (ls_obj != null) ls_default_value = ls_obj.Cast<BaseEntity>().ToList();
                                }



                                ManyToManyField manyToManyField = new ManyToManyField(item,
                                                                    orientation_config,
                                                                    new Size(width_label, height_label),
                                                                    new Size(width_control_config, height_control),
                                                                    this.ConfigEntity,
                                                                    FiledContainner,
                                                                    this.Service);
                                manyToManyField.Name = item.Name;
                                manyToManyField.FieldChanged += ControlPropriete_ValueChanged;

                               

                                if (configProperty.EntryForm?.TabPage == true)
                                {
                                    manyToManyField.Dock = DockStyle.Fill;
                                }
                                
                                field_control = manyToManyField;

                            }
                            #endregion
                        }
                        break;
                } // Fin de suitch
                FiledContainner.Controls.Add(field_control);
                // Insertion du Champs dans sa GroupeBox si il existe
                // [Bug] il n'est pas supprimé de l'inrface, car il est déja ajouté

            }// Fin de for

            // TabControl sur Enregistrer et Annuler
            this.btEnregistrer.TabIndex = ++TabIndex;
            this.btAnnuler.TabIndex = ++TabIndex;


            foreach (GroupBox item in this.ConteneurFormulaire.Controls.Cast<Control>().Where(c => c.GetType() == typeof(GroupBox)))
            {
                // item.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                item.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));

            }
            foreach (FlowLayoutPanel item in GroupesBoxMainContainers.Values)
            {
                item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));


            }
        }


        /// <summary>
        /// Création des groupes Box
        /// </summary>
        /// <param name="groupesBoxMainContainers"></param>
        private void CreateGroupesBoxes(Dictionary<string, Control> groupesBoxMainContainers, int width, int height)
        {
            // trouver la liste des groupes box
            var listeProprite = from i in this.Service.TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(EntryFormAttribute)) != null
                                && ((EntryFormAttribute)i.GetCustomAttribute(typeof(EntryFormAttribute))).GroupeBox != string.Empty
                                 && ((EntryFormAttribute)i.GetCustomAttribute(typeof(EntryFormAttribute))).GroupeBox != null

                                select ((EntryFormAttribute)i.GetCustomAttribute(typeof(EntryFormAttribute))).GroupeBox;
            if (listeProprite.Distinct().Count() > 0)
            {
                foreach (var item in listeProprite.Distinct())
                {
                    //
                    // CombBox
                    //
                    GroupBox groupeBox = new GroupBox();
                    groupeBox.Text = item;
                    groupeBox.AutoSize = true;
                    groupeBox.Size = new Size(width, height);
                    this.ConteneurFormulaire.Controls.Add(groupeBox);


                    // FlowLayout
                    FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                    flowLayoutPanel.Dock = DockStyle.Fill;
                    flowLayoutPanel.AutoSize = true;
                    flowLayoutPanel.FlowDirection = FlowDirection.TopDown;

                    groupeBox.Controls.Add(flowLayoutPanel);
                    groupesBoxMainContainers[item] = flowLayoutPanel;


                }
            }
            else
            {
                GroupBox groupeBox = new GroupBox();
                groupeBox.Text = this.ConfigEntity.DisplayEntity.SingularName;
                groupeBox.AutoSize = true;
                groupeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));

                //groupeBox.Size = new Size(width, height);
                this.ConteneurFormulaire.Controls.Add(groupeBox);


                // FlowLayout
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Dock = DockStyle.Fill;
                flowLayoutPanel.AutoSize = true;
                flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));

                groupeBox.Controls.Add(flowLayoutPanel);

                this.ConteneurFormulaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));

                this.ConteneurFormulaire = flowLayoutPanel;
            }

        }

        /// <summary>
        /// Préparation de conteneurs pour une interface qui contient une relation 
        /// ManytoMany
        /// </summary>
        private void InitTabPageInterface()
        {
            var listeProprite = from i in this.Service.TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(EntryFormAttribute)) != null
                                && ((EntryFormAttribute)i.GetCustomAttribute(typeof(EntryFormAttribute))).TabPage
                                select i;

            // Si l'interface contient des Relation ManyToMany avec TabPage = true
            if (listeProprite.Count() > 0)
            {

                flowLayoutPanelForm.Parent.Controls.Remove(flowLayoutPanelForm);
                flowLayoutPanelForm.Dock = DockStyle.Fill;
                tabControlForm.TabPages["TabPageForm"].Controls.Add(flowLayoutPanelForm);
                tabControlForm.Dock = DockStyle.Fill;
                tabControlForm.TabPages["TabPageForm"].Text = this.ConfigEntity.DisplayEntity.SingularName;

            }
            // Si l'interface ne contient pas des relation ManyToMany
            else
            {
                tabControlForm.Parent.Controls.Remove(tabControlForm);
            }

            flowLayoutPanelForm.Dock = DockStyle.Fill;
            flowLayoutPanelForm.Padding = new Padding(10);

        }

        /// <summary>
        /// Exécuter aprés le changement de chaque propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ControlPropriete_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isStepInitializingValues)
            {
                // Lecture informations
                this.ReadFormToEntity();
                this.Service.ValueChanged(sender, this.Entity);
                this.isStepInitializingValues = true;
                this.WriteEntityToField();
                this.isStepInitializingValues = false;
                // Re-Initialisation des valeurs
            }
        }

        #region Validation
        protected void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            // déja le combobox propose le premiere élément séléctioné
        }

        protected void DateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.DateTimePicker(sender, e);
        }

        protected void TextBoxInt32_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.TextBoxInt32(sender, e);
        }

        protected void textBoxString_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.TextBoxString(sender, e);
        }
        #endregion

    }
}
