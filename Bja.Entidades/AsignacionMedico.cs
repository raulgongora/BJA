using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    public class AsignacionMedico
    {
        public long Id { get; set; }
        public long IdSesion { get; set; }
        public DateTime FechaUltimaTransaccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public TipoEstadoRegistro EstadoRegistro { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Observaciones { get; set; }

        public long IdMedico { get; set; }
        public virtual Medico Medico { get; set; }

        public long IdEstablecimientoMedico { get; set; }
        public virtual EstablecimientoMedico EstablecimientoMedico { get; set; }
    }
}
