using System;

namespace App.WinForm.Attributes
{
    /// <summary>
    /// Displaying the object in the application menu
    /// </summary>
    public class MenuAttribute : BaseAttribute
    {
        /// <summary>
        /// The group name
        /// </summary>
        public string Group { get; set; }
        public string ParentGroup { get; set; }

        /// <summary>
        /// The item name
        /// </summary>
        public string Title { get; set; }
    }
}