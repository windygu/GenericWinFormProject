using App.WinForm.Attributes;
using App.WinForm.Entities.Authentication;
using App.WinForm.Entities.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Entities.Application
{
    [DisplayEntity(Localizable =true, DisplayMember = "Name",isMaleName =true)]
    [ManagementForm(FormTitle ="MenuManager")]
    [Menu(Group ="Admin")]
    public class MenuItemApplication : BaseEntity
    {
        // Name & Description
        [DisplayProperty(isInGlossary =true)]
        [EntryForm(Ordre = 2,GroupeBox = "Description")]
        [Filter]
        [DataGrid]
        public string Name { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 3, MultiLine = true, GroupeBox = "Description")]
        [DataGrid]
        public string Description { set; get; }



        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 2,GroupeBox ="Title")]
        [Filter]
        [DataGrid]
        public string TitleArabic { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 2,GroupeBox = "Title")]
        [Filter]
        [DataGrid]
        public string TitleFrench { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 2, GroupeBox = "Title")]
        [Filter]
        [DataGrid]
        public string TitleEnglish { set; get; }

        [DisplayProperty(isInGlossary = true)]
        [EntryForm(Ordre = 2, GroupeBox = "Authorisation")]
        [Filter]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany,EditMode= RelationshipAttribute.EditingModes.Selection_With_Check_Box)]
        public virtual List<Role> Roles { set; get; }


        public string TitrleCulture(CultureInfo cultureInfo)
        {
            string title = "";
            switch (cultureInfo.TwoLetterISOLanguageName)
            {
                case "fr": title = this.TitleFrench; break;
                case "ar": title = this.TitleArabic; break;
                case "en": title = this.TitleEnglish; break;
            }
            if (title == null) return cultureInfo.TwoLetterISOLanguageName + "_" + this.Name;
            else return title;
        }
    }
}
