using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bja.AccesoDatos;
using Bja.Entidades;

namespace Bja.Modelo
{
    public class ModeloMedico
    {
        BjaContext db = new BjaContext();
        //
        //Sugerencia de rrsc 01/08/2013
        //BjaContext context = new BjaContext();
        //

        public List<Medico> Listar()
        {
            return db.Medicos.ToList();
        }

        public void Crear(Medico medico)
        {
            db.Medicos.Add(medico);
            db.SaveChanges();
        }

        public Medico Buscar(long id = 0)
        {
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return null;
            }
            return medico;
        }

        public void Editar(Medico medico)
        {
            db.Entry(medico).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(long id)
        {
            Medico medico = this.Buscar(id);
            db.Medicos.Remove(medico);
            db.SaveChanges();
        }
    }
}
