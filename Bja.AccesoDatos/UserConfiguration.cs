using Bja.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.AccesoDatos
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(u => u.Id);
            Property(u => u.IdSession).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.Status).IsRequired();
            Property(u => u.UserName).IsRequired().HasMaxLength(250);
            Property(u => u.CompleteName).HasMaxLength(1000);            
        }
    }
}
