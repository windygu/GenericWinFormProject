using App.WinForm.Attributes;
using App.WinForm.Entities;
using App.WinForm.Fields.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace App.WinForm.Fields
{
    public partial class ManyToManyField : App.WinFrom.Fields.BaseField
    {
        public IBaseRepository Service { get; set; }

        private SelectionFilterManager SelectionFilterManager { set; get; }
        public ManyToManyField() : base()
        {
            InitializeComponent();
        }

        public ManyToManyField(
            PropertyInfo propertyInfo,
            Orientation OrientationField,
            Size SizeLabel,
            Size SizeControl,
            ConfigEntity ConfigEntity,
            Control MainContainer, IBaseRepository Service)
            : base(propertyInfo, OrientationField, SizeLabel, SizeControl, ConfigEntity)
        {
            InitializeComponent();
            this.Service = Service;
            this.SelectionFilterManager = new SelectionFilterManager(this.Service,
                this.PropertyInfo,
                MainContainer,
                SizeLabel, SizeControl, OrientationField, ConfigEntity);
            if (this.SelectionFilterManager.isHasFilter)
            {
                this.SelectionFilterManager.ValueChanged += SelectionFilterManager_ValueChanged;
            }else
            {
                // Fill the listBox with the possible values
                Type TypeGenericList = this.PropertyInfo.PropertyType.GetGenericArguments()[0];
                IBaseRepository ServiceTypeGenericList = this.Service.CreateInstance_Of_Service_From_TypeEntity(TypeGenericList);
                List<Object> ls_possible_value = ServiceTypeGenericList.GetAll();
                listBoxChoices.Items.AddRange(ls_possible_value.ToArray());

            }
           

        }

        private void SelectionFilterManager_ValueChanged(object sender, EventArgs e)
        {
            BaseEntity ValueEntity = this.SelectionFilterManager.ValueEntity;

            Type Type_ValueEntity = ObjectContext.GetObjectType(ValueEntity.GetType());
            if (ValueEntity == null) return;

            Type TypeGenericList = this.PropertyInfo.PropertyType.GetGenericArguments()[0];
            IBaseRepository ServiceTypeGenericList = this.Service.CreateInstance_Of_Service_From_TypeEntity(TypeGenericList);
            List<Object> ls_entity_in_filter = ServiceTypeGenericList.Recherche(
                 new Dictionary<string, object>() {
                    { Type_ValueEntity.Name, ValueEntity.Id }
                   });

            listBoxChoices.Items.AddRange(ls_entity_in_filter.ToArray());



        }

        public override object Value
        {
            get
            {
                return listBoxChoices.SelectedItems.Cast<BaseEntity>().ToList<BaseEntity>();
            }

            set
            {
                List<BaseEntity> ls_values = value as List<BaseEntity>;
                // Update Filter selection
                if (this.SelectionFilterManager.isHasFilter && ls_values != null && ls_values.Count > 0)
                    this.SelectionFilterManager.Value = ls_values.First().Id;


                // Update Value
                foreach (var item in ls_values)
                {
                    listBoxChoices.DataSource = ls_values;
                    listBoxChoices.SelectedItems.Add(item);
                }


               
            }
        }


    }
}
