using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bja.Soporte.Paginacion
{
    public interface IGrillaPaginada
	{
        ResultadoPaginacion listaPaginada(long saltarRegistros = 0, long tamañoPagina = 20, string criterioBusqueda = ""); //filtro, ordernar);   
        Int64 totalRegistros(); 
	}
}
