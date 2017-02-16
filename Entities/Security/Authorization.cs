using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Entities.Security
{
    public class Authorization : BaseEntity
    {
        public string Name { set; get; }

        public string Description { set; get; }

        public virtual Action Action { set; get; }

        public string Entity { set; get; }

    }
}
