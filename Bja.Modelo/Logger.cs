using Bja.AccesoDatos;
using Bja.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Modelo
{
    public class Logger
    {
        public static void log(object clase)
        {
            BjaContext context = new BjaContext();

            Type tipoClase = clase.GetType();

            switch (tipoClase.Name)
            {
                case "Madre":
                    MadreLog madreLog = new MadreLog();
                    
                    object madrelogobj = (object)madreLog;
                    SoporteObjetos.CopiarDatosObjetos(clase, ref madrelogobj);
                    
                    madreLog.IdLog = IdentifierGenerator.NewId();
                    madreLog.Enviado = false;

                    context.MadresLog.Add(madreLog);
                    context.SaveChanges();

                    break;
            }

            /*
            object claseDestino = System.Activator.CreateInstance(Type.GetType(tipoClase.FullName + "Log"));

            claseDestino = clase;

            var class1Type = Type.GetType(tipoClase.FullName + "Log"); //typeof(claseDestino);

            class1Type.GetProperty("IdLog").SetValue(claseDestino, IdentifierGenerator.NewId());

            class1Type.GetProperty("Enviado").SetValue(claseDestino, false);

            var class2Type = Type.GetType();
             * */


        }
    }
}
