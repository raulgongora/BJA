using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    public class Envio
    {
        public long Id { get; set; }
        public long IdSesion { get; set; }
        public DateTime FechaUltimaTransaccion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public long IdEstablecimientoMedico { get; set; }
        public long IdMedico { get; set; }
        public DateTime FechaEnvio { get; set; }
        public String CodigoVerificacion { get; set; } //md5, sha
        public int NuevasMadres { get; set; }
        public int NuevosTutores { get; set; }
        public int NuevosMenores { get; set; }
        public int NuevosControlMadre { get; set; }
        public int NuevosControlMenor { get; set; }
        public int NuevaCorresponsabilidadMenor { get; set; }
        public int NuevaCorresponsabilidadMadre { get; set; }
        public int ModificacionMadres { get; set; }
        public int ModificacionTutores { get; set; }
        public int ModificacionMenores { get; set; }
        public int ModificacionControlMenor { get; set; }
        public int ModificacionControlMadre { get; set; }
        public int ModificacionCorresponsabilidadMenor { get; set; }
        public int ModificacionCorresponsabilidadMadre { get; set; }
        public int BorradoMadres { get; set; }
        public int BorradoTutores { get; set; }
        public int BorradoMenores { get; set; }
    }
}
