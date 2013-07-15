using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    public class ControlMenor
    {
        public long Id { get; set; }
        public long IdSesion { get; set; }
        public DateTime FechaUltimaTransaccion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public long IdCorresponsabilidadMenor { get; set; }
        public long IdMedico { get; set; }
        public long IdTutor { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaControl { get; set; }
        public int TallaCm { get; set; }
        public float PesoKg { get; set; }
        public int NumeroControl { get; set; }
        public String Observaciones { get; set; }
        public String EstadoPago { get; set; } //char(1)
    }
}
