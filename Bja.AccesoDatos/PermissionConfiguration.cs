using Bja.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.AccesoDatos
{
    public class PermissionConfiguration : EntityTypeConfiguration<Permission>
    {
        public PermissionConfiguration()
        {
            ToTable("Permissions");
            HasKey(p => p.Id);
            Property(p => p.IdSession).IsRequired();
            Property(p => p.Name).IsRequired().HasMaxLength(250);
            Property(p => p.Description).HasMaxLength(1000);
        }
    }
}
