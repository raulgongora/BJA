using Bja.Soporte.Paginacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Modelo
{
    public class ModeloMadre : IGrillaPaginada
    {

        public ResultadoPaginacion listaPaginada(long saltarRegistros = 0, long tamañoPagina = 20, string criterioBusqueda = "")
        {
            //buscar lista de registros paginados en base al criterio de búsqueda
            //en linq usar skip y take para la paginación
            //ej:myDataSource.Skip(saltarRegistros).Take(tamañoPagina)


            Int64 totalRegistrosEncontrados = 0;
            Int64 totalRegistros = 0;

            //var lista = BuscarConveniosMantenimientoPaginada(ref totalRegistrosEncontrados, ref totalRegistros, saltarRegistros, tamañoPagina, criterioBusqueda);

            //crear la lista de objetos de tipo RegistroGrid
            /*
            var listaRegistroGrid = (from il in lista
                                     select new RegistroGrid(il.id, il.descripcion + " Pago:" + SoporteEnumerador.nombreEnumerador((EnumTipoPeriodo)il.id_periodo_pago) + " Fecha inicio:" + il.fecha_inicio.ToString(), il)).ToList();
            */  
            //crear resultado paginación
            var result = new ResultadoPaginacion();
            result.resultados = new List<RegistroGrid>();//listaRegistroGrid;
            result.totalEncontrados = totalRegistrosEncontrados;
            result.totalRegistros = totalRegistros;
            return result;
            
        }

        public long totalRegistros()
        {
            //retorna el total de registros en la tabla madre
            //return totalregistros;
            return 0;
        }
    }
}
