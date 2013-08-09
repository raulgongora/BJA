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
    public class ModeloReclamo
    {
        BjaContext db = new BjaContext();
        
        public List<Reclamo> Listar()
        {
            return db.Reclamos.ToList();
        }

        public void Crear(Reclamo reclamo)
        {
            db.Reclamos.Add(reclamo);
            db.SaveChanges();
        }

        public Reclamo Buscar(long id = 0)
        {
            Reclamo reclamo = db.Reclamos.Find(id);
            if (reclamo == null)
            {
                return null;
            }
            return reclamo;
        }

        public void Editar(Reclamo reclamo)
        {
            db.Entry(reclamo).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(long id)
        {
            Reclamo reclamo = this.Buscar(id);
            db.Reclamos.Remove(reclamo);
            db.SaveChanges();
        }
    }
}
