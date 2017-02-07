using App.WinForm.Attributes;
using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Entities.ContactInformations
{
    [DisplayEntity(Localizable =true,isMaleName =true,DisplayMember = "Name")]
    [Menu(Group = "configurationToolStripMenuItem")]
    public class Country : BaseEntity
    {
        [DisplayProperty(isInGlossary=true)]
        [EntryForm]
        [Filter]
        [DataGrid]
        public string Name { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(MultiLine =true)]
        [DataGrid]
        public string Description { set; get; }

        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.OneToMany)]
        public virtual List<City> Citys { set; get; }
    }
}
