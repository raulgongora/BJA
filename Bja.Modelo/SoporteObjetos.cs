using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Modelo
{
    public class SoporteObjetos
    {
        /// <summary>
        /// Copia las propiedades públicas del objeto origen al objeto destino
        /// </summary>
        /// <param name="objetoOrigen">Objeto Origen</param>
        /// <param name="objetoDestino">Objeto Destino</param>
        /// <returns></returns>
        public static void CopiarDatosObjetos(object objetoOrigen, ref object objetoDestino)
        {
            if (objetoOrigen == null || objetoDestino == null) return;

            Type tipoOrigen = objetoOrigen.GetType();

            PropertyInfo[] propiedadesObjetoOrigen = tipoOrigen.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Type tipoDestino = objetoDestino.GetType();

            foreach (PropertyInfo propiedadObjetoOrigen in propiedadesObjetoOrigen)
            {
                //TypeCode typeCode = Type.GetTypeCode(propiedadEntidad.PropertyType);
                //buscamos la propiedad publica en el objeto derivado
                PropertyInfo propiedadObjetoDestino = tipoDestino.GetProperty(propiedadObjetoOrigen.Name);
                //compara tipos
                //propiedadObjetoDerivado.PropertyType == propiedadObjetoBase.PropertyType
                var tipoPropiedadObjetoOrigen = propiedadObjetoOrigen.PropertyType;

                if (propiedadObjetoDestino != null && (tipoPropiedadObjetoOrigen == propiedadObjetoDestino.PropertyType))
                {
                    //propiedad existe, copiar datos
                    //ambos deben ser del mismo tipo
                    propiedadObjetoDestino.SetValue(objetoDestino, propiedadObjetoOrigen.GetValue(objetoOrigen, null), null);

                }
            }
        }
    }
}
