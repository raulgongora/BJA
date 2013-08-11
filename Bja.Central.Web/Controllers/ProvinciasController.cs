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
    public class ProvinciasController : Controller
    {
        private BjaContext db = new BjaContext();

        //
        // GET: /Provincias/

        public ActionResult Index()
        {
            var provincias = db.Provincias.Include(p => p.Departamento);
            return View(provincias.ToList());
        }

        //
        // GET: /Provincias/Details/5

        public ActionResult Details(long id = 0)
        {
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        //
        // GET: /Provincias/Create

        public ActionResult Create()
        {
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "Id", "Codigo");
            return View();
        }

        //
        // POST: /Provincias/Create

        [HttpPost]
        public ActionResult Create(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Provincias.Add(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "Id", "Codigo", provincia.IdDepartamento);
            return View(provincia);
        }

        //
        // GET: /Provincias/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "Id", "Codigo", provincia.IdDepartamento);
            return View(provincia);
        }

        //
        // POST: /Provincias/Edit/5

        [HttpPost]
        public ActionResult Edit(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "Id", "Codigo", provincia.IdDepartamento);
            return View(provincia);
        }

        //
        // GET: /Provincias/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        //
        // POST: /Provincias/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Provincia provincia = db.Provincias.Find(id);
            db.Provincias.Remove(provincia);
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