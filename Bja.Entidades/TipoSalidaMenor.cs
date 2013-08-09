using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    public enum TipoSalidaMenor
    {
        //Por que hay que agregar una opción en la aplicación
        //por que puede suceder de que al usuario selecciones una opción de la que
        //no pueda salir
        AunEnProceso = 0,
        Cumplimiento,
        Transferencia,
        Fallecimiento,
        Incumplimiento
    }
}
