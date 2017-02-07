using App.WinForm.Attributes;
using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Entities.Application
{
    [DisplayEntity(Localizable =true,isMaleName =false,DisplayMember ="Name",PluralName ="Applications",SingularName = "Application")]
    public class ApplicationName : BaseEntity
    {
        [DisplayProperty()]
        [Relationship()]
        [EntryForm()]
        [Filter()]
        [DataGrid()]
        string Name { set; get; }

        string Description { set; get; }

        
    }
}
