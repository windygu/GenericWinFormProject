using App.WinForm.Attributes;
using App.WinForm.Entities.ContactInformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Entities.Persons
{
   
    public class Person : BaseEntity
    {

        public override string ToString() =>  this.Name + " " + this.FirstName;


        // Civil status
        [DisplayProperty(Titre = "Nom")]
        [EntryForm(Ordre = 1,GroupeBox = "Civil status")]
        [Filter()]
        [DataGrid(WidthColonne = 100)]
        public String Name { set; get; }

        [DisplayProperty(Titre = "Prénom")]
        [EntryForm(Ordre = 2, GroupeBox = "Civil status")]
        [Filter()]
        [DataGrid(WidthColonne = 100)]
        public String FirstName { set; get; }

        [DisplayProperty(Titre = "CIN")]
        [EntryForm(Ordre = 3, GroupeBox = "Civil status")]
        [Filter()]
        [DataGrid(WidthColonne = 50)]
        public String CIN { set; get; }

        [DisplayProperty(Titre = "Date de naissance" )]
        [EntryForm(Ordre = 3, GroupeBox = "Civil status")]
        public DateTime DateOfBirth { set; get; }

        [DisplayProperty(Titre = "Sexe")]
        [EntryForm(Ordre = 3, GroupeBox = "Civil status")]
        public bool Sex { set; get; }
       
        public String ProfilePhoto { set; get; }

 
        #region Contact Information

        [EntryForm(Ordre = 10,GroupeBox = "Contact Information")]
        public String Email { set; get; }


        [EntryForm(Ordre = 11,GroupeBox = "Contact Information")]
        public String PhoneNumber { set; get; }


        [EntryForm(Ordre = 12, MultiLine = true, GroupeBox = "Contact Information")]
        public String Address { set; get; }

        [EntryForm(Ordre = 13, GroupeBox = "Contact Information")]
        [Filter]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public City City { set; get; }

        [EntryForm(Ordre = 14, GroupeBox = "Contact Information")]
        public string Cellphone { set; get; }

        [EntryForm(Ordre = 15, GroupeBox = "Contact Information")]
        public string FaceBook { set; get; }

        [EntryForm(Ordre = 16, GroupeBox = "Contact Information")]
        public string WebSite { set; get; }
        #endregion



        public Person()
        {
            this.DateOfBirth = DateTime.Now.AddYears(-23);
        }
    }
}
