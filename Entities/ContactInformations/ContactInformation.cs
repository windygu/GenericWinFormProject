using App.WinForm.Attributes;
using App.WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Entities.ContactInformations
{
    [DisplayEntity(Localizable =true,isMaleName =false, DisplayMember = "Email")]
    public class ContactInformation : BaseEntity
    {


        [EntryForm(Ordre = 10)]
        public String Email { set; get; }


        [EntryForm(Ordre = 11)]
        public String PhoneNumber { set; get; }


        [EntryForm(Ordre = 12, MultiLine = true)]
        public String Address { set; get; }

        [EntryForm(Ordre = 13)]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public City City { set; get; }
 
        [EntryForm(Ordre = 14)]
        public string Cellphone { set; get; }

        [EntryForm(Ordre = 15)]
        public string FaceBook { set; get; }

        [EntryForm(Ordre = 16)]
        public string WebSite { set; get; }
    }
}
