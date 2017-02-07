using App.Shared.AttributesManager;
using App.WinForm.Attributes;
using App.WinForm.Fields;
using App.WinForm.Entities;
using App.WinFrom.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    /// <summary>
    /// Lire 
    /// </summary>
    public partial class BaseEntryForm
    {
                            
        public virtual void WriteEntityToField()
        {
            this.WriteEntityToField(null);
        }
 
        /// <summary>
        /// Affiher l'entité dans le formulaire avec 
        /// les valeurs initiaux de l'objet
        /// et les initiaux de filtre avec la priéorité pour le filtre
        /// </summary>
        public virtual void WriteEntityToField(Dictionary<string, object> CritereRechercheFiltre)
        {
            // Generate the the form if is note generated
            GenerateFormIfNotGenerated();

            // début de la phase d'initialisation, pour ne pas lancer les evénement 
            // de changement des valeurs des contôle
            isStepInitializingValues = true;

            BaseEntity entity = this.Entity;
            Type typeEntity = this.Service.TypeEntity;

            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                
                ConfigProperty attributesOfProperty = new ConfigProperty(item, this.ConfigEntity);

                Type typePropriete = item.PropertyType;
                string NomPropriete = item.Name;

                switch (typePropriete.Name)
                {
                    case "String":
                        {
                            string valeur = (string)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                valeur = CritereRechercheFiltre[item.Name].ToString();
                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = valeur;
                            }
                            else
                            {
                                TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                                txtBox.Text = valeur;
                            }
                        }
                        break;
                    case "Int32":
                        {
                            int valeur = (int)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                valeur = Convert.ToInt32( CritereRechercheFiltre[item.Name]);

                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = valeur;
                            }
                            else
                            {
                                TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                                txtBox.Text = valeur.ToString();
                            }

                        }
                        break;
                    case "DateTime":
                        {
                            DateTime valeur = (DateTime)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                valeur = Convert.ToDateTime(CritereRechercheFiltre[item.Name]);


                            
                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = valeur;
                            }
                            else
                            {
                                DateTimePicker dateTimePicker = (DateTimePicker)this.FindPersonelField(item.Name, "DateTimePicker");
                                dateTimePicker.Value = valeur;
                            }

                        }
                        break;
                    default:
                        if (attributesOfProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToOne)
                        {
                            BaseEntity valeur = (BaseEntity)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                            if (valeur == null) continue;
                            Int64 valeur_id = valeur.Id;
                            // La valeur Iniale de filtre
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                valeur_id = Convert.ToInt64(CritereRechercheFiltre[item.Name]);

                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = valeur_id;
                            }
                            else
                            {
                                ComboBox comboBox =(ComboBox) this.FindPersonelField(item.Name, "ComboBox");
                                comboBox.CreateControl();
                                if (valeur.Id != 0)
                                comboBox.SelectedValue = valeur.Id;
                            }
                        }
                        if (attributesOfProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToMany)
                        {
                            List<Object> ls_object = typeEntity.GetProperty(NomPropriete).GetValue(entity) as List<object>;
                            if (ls_object == null) continue;
                            List<BaseEntity> ls_valeur = ls_object.Cast<BaseEntity>().ToList();
                            if (ls_valeur == null) continue;
                            
                            // La valeur Iniale de filtre
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                throw new NotImplementedException();

                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = ls_valeur;
                            }
                            else
                            {
                                ListBox listBox = (ListBox)this.FindPersonelField(item.Name, "ListBox");
                                listBox.CreateControl();
                                foreach (var item2 in ls_valeur)
                                {
                                    listBox.SelectedItems.Add(item2);
                                }
                               
                                   
                            }
                        }
                        break;
                }
 
            }

            // Fin de la phase d'initialisaiton
            this.isStepInitializingValues = false;
        }
        private Control FindPersonelField(string name, String TypeControl)
        {
            String PossibiliteNomControle1 = char.ToLower(name[0]) + name.Substring(1) + TypeControl;
            Control[] recherche1 = this.ConteneurFormulaire.Controls.Find(PossibiliteNomControle1, true);
            if (recherche1.Count() > 0) return recherche1.First();
            throw new FieldNotExistInFormException();
        }
        /// <summary>
        /// Trouver un controle dans l'interface du formlaire 
        /// </summary>
        /// <param name="name">Le nom de la propriété</param>
        /// <param name="TypeControl">Le type de control qui est en relation avec le type de la propriété</param>
        /// <returns></returns>
        private BaseField FindGenerateField(string name)
        {
            Control[] recherche = this.ConteneurFormulaire.Controls.Find(name, true);
            if (recherche.Count() > 0) return (BaseField)recherche.First();
            throw new FieldNotExistInFormException();
        }




    }
}
