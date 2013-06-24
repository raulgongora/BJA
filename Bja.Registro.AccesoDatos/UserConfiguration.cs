using Bja.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Registro.AccesoDatos
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.IdInstance).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.Status).IsRequired();
            Property(u => u.UserName).IsRequired().HasMaxLength(250);
            Property(u => u.CompleteName).HasMaxLength(1000);            
        }
    }
}
