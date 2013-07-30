using Bja.Entidades;
using Bja.AccesoDatos;
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

      BjaContext context = new BjaContext();

      public void AdicionMadre()
      {
      }

      public void ModificacionMadre()
      {
      }

      public void EliminacionMadre()
      {
      }
  
      public ResultadoPaginacion listaPaginada(long saltarRegistros = 0, long tamañoPagina = 20, string criterioBusqueda = "")
      {
          //buscar lista de registros paginados en base al criterio de búsqueda
          //en linq usar skip y take para la paginación
          //ej:myDataSource.Skip(saltarRegistros).Take(tamañoPagina)

          

          Int64 totalRegistrosEncontrados = 0;
          Int64 totalRegistros = 0;

          var lista = (from m in context.Madres
                           where m.Nombres.Contains(criterioBusqueda) || 
                           m.PrimerApellido.Contains(criterioBusqueda) || 
                           m.SegundoApellido.Contains(criterioBusqueda)
                           select m).ToList();

          //var lista = BuscarConveniosMantenimientoPaginada(ref totalRegistrosEncontrados, ref totalRegistros, saltarRegistros, tamañoPagina, criterioBusqueda);

          //crear la lista de objetos de tipo RegistroGrid
          
          var listaRegistroGrid = (from il in lista
                                    select new RegistroGrid(il.Id, il.Nombres + " " + il.PrimerApellido, il)).ToList();
            
          //crear resultado paginación
          var result = new ResultadoPaginacion();
          result.resultados = listaRegistroGrid;
          result.totalEncontrados = totalRegistrosEncontrados;
          result.totalRegistros = totalRegistros;
          return result;
            
      }

      public long totalRegistros()
      {
          //retorna el total de registros en la tabla madre
          return context.Madres.Count(); 
      }
    }
}
