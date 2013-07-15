﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    public class Permission
    {
        public long Id { get; set; }
        public long IdSession { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public List<Role> Roles { get; set; }
    }
}
