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
    public class ModeloEncargado
    {
        BjaContext db = new BjaContext();

        public List<Encargado> Listar()
        {
            return db.Encargados.ToList();
        }

        public void Crear(Encargado encargado)
        {
            db.Encargados.Add(encargado);
            db.SaveChanges();
        }

        public Encargado Buscar(long id = 0)
        {
            Encargado encargado = db.Encargados.Find(id);
            if (encargado == null)
            {
                return null;
            }
            return encargado;
        }

        public void Editar(Encargado encargado)
        {
            db.Entry(encargado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Eliminar(long id)
        {
            Encargado encargado = this.Buscar(id);
            db.Encargados.Remove(encargado);
            db.SaveChanges();
        }
    }
}
