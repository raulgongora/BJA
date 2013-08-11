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
    public class MunicipiosController : Controller
    {
        private BjaContext db = new BjaContext();

        //
        // GET: /Municipios/

        public ActionResult Index()
        {
            var municipios = db.Municipios.Include(m => m.Provincia);
            return View(municipios.ToList());
        }

        //
        // GET: /Municipios/Details/5

        public ActionResult Details(long id = 0)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        //
        // GET: /Municipios/Create

        public ActionResult Create()
        {
            ViewBag.IdProvincia = new SelectList(db.Provincias, "Id", "Codigo");
            return View();
        }

        //
        // POST: /Municipios/Create

        [HttpPost]
        public ActionResult Create(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipios.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProvincia = new SelectList(db.Provincias, "Id", "Codigo", municipio.IdProvincia);
            return View(municipio);
        }

        //
        // GET: /Municipios/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProvincia = new SelectList(db.Provincias, "Id", "Codigo", municipio.IdProvincia);
            return View(municipio);
        }

        //
        // POST: /Municipios/Edit/5

        [HttpPost]
        public ActionResult Edit(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProvincia = new SelectList(db.Provincias, "Id", "Codigo", municipio.IdProvincia);
            return View(municipio);
        }

        //
        // GET: /Municipios/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        //
        // POST: /Municipios/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Municipio municipio = db.Municipios.Find(id);
            db.Municipios.Remove(municipio);
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