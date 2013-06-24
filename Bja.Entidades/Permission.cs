using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    public class Permission
    {
        public Int32 Id { get; set; }
        public Int32 IdInstance { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public List<Role> Roles { get; set; }
    }
}
