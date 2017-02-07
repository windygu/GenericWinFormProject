using App.WinForm.Attributes;
using App.WinForm.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Entities.Application
{
    [DisplayEntity(Localizable =true, DisplayMember = "Name",isMaleName =true)]
    [ManagementForm(FormTitle ="MenuManager")]
    [Menu]
    public class MenuItemApplication : BaseEntity
    {
        [DisplayProperty(isInGlossary =true)]
        [EntryForm(Ordre = 2)]
        [Filter]
        [DataGrid]
        public string Name { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 3, MultiLine = true)]
        [DataGrid]
        public string Description { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 2)]
        [Filter]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany,EditMode= RelationshipAttribute.EditingModes.Selection_With_Check_Box)]
        public virtual List<Role> Roles { set; get; }
    }
}
