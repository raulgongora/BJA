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
        public static void defineTipoInicializacionBD()
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<BjaContext>());
        }
    }
}
