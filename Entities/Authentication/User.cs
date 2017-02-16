using App.WinForm.Attributes;
using App.WinForm.Entities.Persons;
using App.WinForm.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Entities.Authentication
{
    [DisplayEntity(Localizable =true,isMaleName =true, DisplayMember = "Login")]
    [Menu]
    public class User: Person
    {

        public User() : base()
        {

        }

        public override string ToString() => base.ToString();
        public static string ROLE_STAGIAIRE = "STAGIAIRE";
        public static string ROLE_ADMIN = "ADMIN";

        // Authentification
        // La création d'un index dans la classe Utilisateur
        // créer un index pour chaque classe fille comme 
        // la classe Stagiaire et Formateur
        // ce qui générer une exéception lors de la Migration automatique 
        // de la base de donénes 
        // parceque les tous les index des tables prend le même nom
        // comme solution il faut nommer l'index selon le type de la classe
        // [Index("LoginIndex"  , IsUnique = true)]
         //[StringLength(450)]

        [DisplayProperty(isInGlossary =true)]
        [EntryForm(GroupeBox ="authentication")]
        public string Login { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(GroupeBox = "authentication")]
        public string Password { set; get; }


        public List<Role> Roles { set; get; }

        
    }
}
