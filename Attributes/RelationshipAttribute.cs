using System;

namespace App.WinForm.Attributes
{
    public class RelationshipAttribute : Attribute
    {

        public enum EditingModes
        {
            Creation,
            Selection_With_Check_Box
        }

        public enum Relations
        {
            Empty,
            ManyToOne,
            OneToMany,
            ManyToMany,
            OneToOne
        }
        /// <summary>
        /// Edit mode
        /// </summary>
        public EditingModes EditMode { get; set; }

        /// <summary>
        /// Indique le type de la relation, ManyToOne ou ManyToMany
        /// </summary>
        public Relations Relation { set; get; }
        
    }
}