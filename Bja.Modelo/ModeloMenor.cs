using Bja.Entidades;
using Bja.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Modelo
{
  public class ModeloMenor
  {
  
    BjaContext context = new BjaContext();

    public void AdicionMenor(Menor menor, long? sessionId = null)
    {
      menor.Id = IdentifierGenerator.NewId();
      menor.IdSesion = (sessionId == null) ? SessionManager.getCurrentSession().Id : (long)sessionId;
      menor.FechaUltimaTransaccion = DateTime.Now;
      menor.FechaRegistro = DateTime.Now;
      menor.Defuncion = false;
      menor.Observaciones = "";
      context.Menores.Add(menor);
      context.SaveChanges();
    }

    public void ModificacionMenor(int Id, Menor menor, long? sessionId = null)
    {
      Menor _menor = null;
      _menor = (from p in context.Menores
                where p.Id == Id
                select p).FirstOrDefault();
      _menor.IdSesion = (sessionId == null) ? SessionManager.getCurrentSession().Id : (long)sessionId;
      _menor.FechaUltimaTransaccion = DateTime.Now;
      _menor.FechaRegistro = DateTime.Now;
      _menor.Nombres = menor.Nombres;
      _menor.PrimerApellido = menor.PrimerApellido;
      _menor.SegundoApellido = menor.SegundoApellido;
      _menor.DocumentoIdentidad = menor.DocumentoIdentidad;
      _menor.IdTipoDocumentoIdentidad = menor.IdTipoDocumentoIdentidad;
      _menor.IdLocalidadNacimiento = menor.IdLocalidadNacimiento;
      _menor.FechaNacimiento = menor.FechaNacimiento;
      _menor.Sexo = menor.Sexo;
      menor.Defuncion = false;
      menor.Observaciones = "";
      context.SaveChanges();
    }

    public void EliminacionMenor(int Id)
    {
      Menor _menor = null;
      _menor = (from p in context.Menores
                where p.Id == Id
                select p).FirstOrDefault();
      context.Menores.Remove(_menor);
      context.SaveChanges();
    }

  }
}
