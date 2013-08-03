using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bja.Entidades;
using Bja.Modelo;

namespace Bja.Central.Web.Controllers
{
    public class ReclamosController : Controller
    {
        private ModeloReclamo modReclamo = new ModeloReclamo();

        //
        // GET: /Reclamos/

        public ActionResult Index()
        {
            return View(modReclamo.Listar());
        }

        //
        // GET: /Reclamos/Details/5

        public ActionResult Details(long id = 0)
        {
            Reclamo reclamo = modReclamo.Buscar(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        //
        // GET: /Reclamos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Reclamos/Create

        [HttpPost]
        public ActionResult Create(Reclamo reclamo)
        {
            reclamo.IdSesion = 1;
            reclamo.FechaUltimaTransaccion = System.DateTime.Now;
            reclamo.FechaRegistro = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                modReclamo.Crear(reclamo);
                return RedirectToAction("Index");
            }
            return View(reclamo);
        }

        //
        // GET: /Reclamos/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Reclamo reclamo = modReclamo.Buscar(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        //
        // POST: /Reclamos/Edit/5

        [HttpPost]
        public ActionResult Edit(Reclamo reclamo)
        {
            if (ModelState.IsValid)
            {
                reclamo.IdSesion = 1;
                reclamo.FechaUltimaTransaccion = System.DateTime.Now;
                reclamo.FechaRegistro = System.DateTime.Now;

                modReclamo.Editar(reclamo);
                return RedirectToAction("Index");
            }
            return View(reclamo);
        }

        //
        // GET: /Reclamos/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Reclamo reclamo = modReclamo.Buscar(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        //
        // POST: /Reclamos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            modReclamo.Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            
        }
    }
}