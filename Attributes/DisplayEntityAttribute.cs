using System;

namespace App.WinForm.Attributes
{
    /// <summary>
    /// The display of the entity
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DisplayEntityAttribute : BaseAttribute
    {
        /// <summary>
        /// The name of the property that represents the entity
        /// </summary>
      
        public string DisplayMember { get; set; }
        /// <summary>
        /// The plural name
        /// </summary>
        public string PluralName { get; set; }
        /// <summary>
        /// The singular name
        /// </summary>
        public string SingularName { get; set; }
        /// <summary>
        /// Indicates whether the name is male
        /// </summary>
        public bool isMaleName { set; get; }
    }
}