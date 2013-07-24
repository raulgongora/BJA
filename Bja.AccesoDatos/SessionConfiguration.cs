using Bja.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.AccesoDatos
{
    public class SessionConfiguration : EntityTypeConfiguration<Session>
    {
        public SessionConfiguration()
        {
            HasKey(s => s.Id);
            Property(s => s.IdUser).IsRequired();
            Property(s => s.UserName).IsRequired().HasMaxLength(250);
            Property(s => s.CompleteName).HasMaxLength(1000);
            Property(s => s.InitDate).IsRequired();
        }
    }
}
