using App.WinForm.Attributes;
using App.WinForm.Entities;
using App.WinForm.Fields.Controls;
using System;
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
            this.SelectionFilterManager.ValueChanged += SelectionFilterManager_ValueChanged;

        }

        private void SelectionFilterManager_ValueChanged(object sender, EventArgs e)
        {
            BaseEntity ValueEntity =  this.SelectionFilterManager.ValueEntity;
            
            Type Type_ValueEntity = ObjectContext.GetObjectType(ValueEntity.GetType());
            if (ValueEntity == null) return;
           Type TypeGenericList = this.PropertyInfo.PropertyType.GetGenericArguments()[0];
           IBaseRepository ServiceTypeGenericList = this.Service.CreateInstance_Of_Service_From_TypeEntity(TypeGenericList);
            
           listBoxChoices.DataSource = ServiceTypeGenericList.Recherche(
                new Dictionary<string, object>() {
                    { Type_ValueEntity.Name, ValueEntity.Id }
                  });



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
                if (ls_values != null && ls_values.Count > 0)
                    this.SelectionFilterManager.Value =  ls_values.First().Id;

                throw new NotImplementedException();
            }
        }

       
    }
}
