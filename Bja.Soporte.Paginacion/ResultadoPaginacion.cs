using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bja.Soporte.Paginacion
{
    public class ResultadoPaginacion
    {
        /// <summary>
        /// Lista de resultados retornados en la busqueda
        /// </summary>
        public List<RegistroGrid> resultados { get; set; }

        /// <summary>
        /// Total de registros encontrados en la busqueda
        /// </summary>
        public Int64 totalEncontrados { get; set; }
        
        /// <summary>
        /// Total de registros en la base de datos
        /// </summary>
        public Int64 totalRegistros { get; set; }

    }
}
