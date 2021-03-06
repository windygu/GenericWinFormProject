﻿using App.WinForm.Attributes;
using App.WinForm.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Entities.Security
{
    [DisplayEntity(DisplayMember = "Name")]
    [Menu(Group = "configurationToolStripMenuItem")]
    public class Role : BaseEntity
    {
        [DisplayProperty(Titre ="Name")]
        [EntryForm(Ordre = 1)]
        [Filter]
        [DataGrid]
        public string Name { set; get; }

        [DisplayProperty(Titre = "Description")]
        [EntryForm(Ordre = 2,MultiLine = true)]
        [Filter]
        [DataGrid]
        public string Description { set; get; }

        /// <summary>
        /// indicate that the role is hidden
        /// </summary>
        public bool Hidden { set; get; }

        public virtual List<Authorization> Authorizations { set; get; }

        public  List<MenuItemApplication> MenuItemApplications { set; get; }

    }
}
