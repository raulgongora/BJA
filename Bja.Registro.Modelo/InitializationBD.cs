using Bja.Registro.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Registro.Modelo
{
    public class InicializacionBD
    {
        public static void inicializarBD()
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<BjaContext>());

            var rbac = new Rbac();

            if (!rbac.authenticate("admin", "admin"))
            {
                rbac.insertUser("admin", "Admin", "admin", 1);
            }
        }
    }
}
