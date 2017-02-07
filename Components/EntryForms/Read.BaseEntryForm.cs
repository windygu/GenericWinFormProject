using App.Shared.AttributesManager;
using App.WinForm.Attributes;
using App.WinForm.Fields;
using App.WinForm.Entities;
using App.WinFrom.Fields;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class BaseEntryForm
    {
        /// <summary>
        /// Lire les informations du formulaire vers l'Entity
        /// </summary>
        protected virtual void ReadFormToEntity()
        {
            BaseEntity entity = this.Entity;
            Type typeEntity = this.Service.TypeEntity;
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                
                ConfigProperty attributesOfProperty = new ConfigProperty(item, this.ConfigEntity);

                Type typePropriete = item.PropertyType;
                string NomPropriete = item.Name;

                #region Read :String Field
                if (typePropriete.Name == "String")
                {
                    string value = "";
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        value = baseField.Value.ToString();
                    }
                    else
                    {
                        TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                        value = txtBox.Text;
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, value);
                }
                #endregion

                #region Read : Int32 Field
                if (item.PropertyType.Name == "Int32")
                {
                    int Nombre = 0;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        Nombre = Convert.ToInt32(baseField.Value);
                    }
                    else
                    {
                        TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                        if (!int.TryParse(txtBox.Text, out Nombre))
                            MessageBox.Show("Impossible de lire un nombre :" + txtBox.Text);
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, Nombre);

                }
                #endregion

                #region Read : DateTime Field
                if (typePropriete.Name == "DateTime")
                {
                    DateTime date = DateTime.MinValue;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        date = Convert.ToDateTime(baseField.Value);
                    }
                    else
                    {
                        DateTimePicker dateTimePicker = (DateTimePicker)this.FindPersonelField(item.Name, "TextBox");
                        date = dateTimePicker.Value;
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, date);
                }
                #endregion

                #region Read : ManyToOne Field
                if (attributesOfProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToOne)
                {
                    Int64 id;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        id = Convert.ToInt64(baseField.Value);
                    }
                    else
                    {
                        ComboBox comboBox = (ComboBox)this.FindPersonelField(item.Name, "ComboBox");
                        id = Convert.ToInt64(comboBox.SelectedValue);

                    }
                    IBaseRepository ServicesEntity = this.Service.CreateInstance_Of_Service_From_TypeEntity(item.PropertyType);
                    BaseEntity ManyToOneEntity = ServicesEntity.GetBaseEntityByID(Convert.ToInt32(id));
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, ManyToOneEntity);
                }
                #endregion

                #region  Read : ManyToMany
                if (attributesOfProperty.Relationship?.Relation == RelationshipAttribute.Relations.ManyToMany)
                {
                    List<BaseEntity> ls = null;
                    if (this.AutoGenerateField)
                    {
                        ManyToManyField manyToManyField = null;
                        if (attributesOfProperty.EntryForm?.TabPage == true)
                        {
                           
                            Control[] recherche = this.tabControlForm.Controls.Find(item.Name, true);
                            if (recherche.Count() > 0)
                                manyToManyField = (ManyToManyField)recherche.First();
                            else
                                throw new FieldNotExistInFormException();
                        }else
                        {
                            Control[] recherche = this.ConteneurFormulaire.Controls.Find(item.Name, true);
                            if (recherche.Count() > 0) {
                                manyToManyField = (ManyToManyField)recherche.First();
                            }
                            else
                            throw new FieldNotExistInFormException();
                        }

                        ls = manyToManyField.Value as List<BaseEntity>;
                    }
                    else
                    {
                        ListBox comboBox = (ListBox)this.FindPersonelField(item.Name, "ListBox");
                        ls = comboBox.Items.Cast<BaseEntity>().ToList<BaseEntity>();

                    }

                  
                    IBaseRepository ServicesEntity =  this.Service.CreateInstance_Of_Service_From_TypeEntity(item.PropertyType.GetGenericArguments()[0], this.Service.Context());


                    Type TypeListeObjetValeur = typeof(List<>).MakeGenericType(item.PropertyType.GetGenericArguments()[0]);
                    IList ls_valeur = (IList)Activator.CreateInstance(TypeListeObjetValeur);



                    foreach (BaseEntity b in ls)
                    {
                        var entity_valeur = ServicesEntity.GetBaseEntityByID(b.Id);
                        ls_valeur.Add(entity_valeur);

                    }


                    typeEntity.GetProperty(NomPropriete).SetValue(entity, ls_valeur);

                }
                #endregion

            }
        }
    }
}
