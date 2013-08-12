using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bja.Entidades;
using Bja.AccesoDatos;

namespace Bja.Central.Web.Controllers
{
    public class EstablecimientosMedicoController : Controller
    {
        private BjaContext db = new BjaContext();

        //
        // GET: /EstablecimientosMedico/

        public ActionResult Index()
        {
            var establecimientosmedico = db.EstablecimientosMedico.Include(e => e.Municipio);
            return View(establecimientosmedico.ToList());
        }

        //
        // GET: /EstablecimientosMedico/Details/5

        public ActionResult Details(long id = 0)
        {
            EstablecimientoMedico establecimientomedico = db.EstablecimientosMedico.Find(id);
            if (establecimientomedico == null)
            {
                return HttpNotFound();
            }
            return View(establecimientomedico);
        }

        //
        // GET: /EstablecimientosMedico/Create

        public ActionResult Create()
        {
            ViewBag.IdMunicipio = new SelectList(db.Municipios, "Id", "Codigo");
            return View();
        }

        //
        // POST: /EstablecimientosMedico/Create

        [HttpPost]
        public ActionResult Create(EstablecimientoMedico establecimientomedico)
        {
            if (ModelState.IsValid)
            {
                db.EstablecimientosMedico.Add(establecimientomedico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMunicipio = new SelectList(db.Municipios, "Id", "Codigo", establecimientomedico.IdMunicipio);
            return View(establecimientomedico);
        }

        //
        // GET: /EstablecimientosMedico/Edit/5

        public ActionResult Edit(long id = 0)
        {
            EstablecimientoMedico establecimientomedico = db.EstablecimientosMedico.Find(id);
            if (establecimientomedico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMunicipio = new SelectList(db.Municipios, "Id", "Codigo", establecimientomedico.IdMunicipio);
            return View(establecimientomedico);
        }

        //
        // POST: /EstablecimientosMedico/Edit/5

        [HttpPost]
        public ActionResult Edit(EstablecimientoMedico establecimientomedico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establecimientomedico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMunicipio = new SelectList(db.Municipios, "Id", "Codigo", establecimientomedico.IdMunicipio);
            return View(establecimientomedico);
        }

        //
        // GET: /EstablecimientosMedico/Delete/5

        public ActionResult Delete(long id = 0)
        {
            EstablecimientoMedico establecimientomedico = db.EstablecimientosMedico.Find(id);
            if (establecimientomedico == null)
            {
                return HttpNotFound();
            }
            return View(establecimientomedico);
        }

        //
        // POST: /EstablecimientosMedico/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            EstablecimientoMedico establecimientomedico = db.EstablecimientosMedico.Find(id);
            db.EstablecimientosMedico.Remove(establecimientomedico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}