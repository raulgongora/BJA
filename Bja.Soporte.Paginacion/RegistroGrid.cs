using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bja.Soporte.Paginacion
{
    public class RegistroGrid
    {
        public Int64 id { get; set; }
        public string descripcion { get; set; }
        public object dato { get; set; }

        public RegistroGrid(Int64 id, string descripcion, object dato)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.dato = dato;
        }
    }
}
