using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcCACSLA.Models;
using mvcCACSLA.Security;
using PagedList;
using System.IO;



namespace mvcCACSLA.Controllers
{
    [Authorize]
    [AuthorizeRoles("Administrador")]
    public class CoordinacionesController : Controller
    {
        private DB_9F6318_fcacacslav2Entities1 db = new DB_9F6318_fcacacslav2Entities1();

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var coord = db.Coordinaciones.OrderBy(a => a.IdCoordinacion);
            return View(coord.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordinaciones coordinaciones = db.Coordinaciones.Find(id);
            if (coordinaciones == null)
            {
                return HttpNotFound();
            }
            return View(coordinaciones);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCoordinacion,Descripcion")] Coordinaciones coordinaciones)
        {
            if (ModelState.IsValid)
            {
                db.Coordinaciones.Add(coordinaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coordinaciones);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordinaciones coordinaciones = db.Coordinaciones.Find(id);
            if (coordinaciones == null)
            {
                return HttpNotFound();
            }
            return View(coordinaciones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCoordinacion,Descripcion")] Coordinaciones coordinaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coordinaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coordinaciones);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordinaciones coordinaciones = db.Coordinaciones.Find(id);
            if (coordinaciones == null)
            {
                return HttpNotFound();
            }
            return View(coordinaciones);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coordinaciones coordinaciones = db.Coordinaciones.Find(id);
            db.Coordinaciones.Remove(coordinaciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
