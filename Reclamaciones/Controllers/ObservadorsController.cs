using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reclamaciones.Models;

namespace Reclamaciones.Controllers
{
    public class ObservadorsController : Controller
    {
        private DB_ReclamacionesEntities2 db = new DB_ReclamacionesEntities2();

        // GET: Observadors
        public ActionResult Index()
        {
            return View(db.Observadors.ToList());
        }

        // GET: Observadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observador observador = db.Observadors.Find(id);
            if (observador == null)
            {
                return HttpNotFound();
            }
            return View(observador);
        }

        // GET: Observadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Observadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Observador,Nombre,Apellido,Email,Estado")] Observador observador)
        {
            if (ModelState.IsValid)
            {
                db.Observadors.Add(observador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(observador);
        }

        // GET: Observadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observador observador = db.Observadors.Find(id);
            if (observador == null)
            {
                return HttpNotFound();
            }
            return View(observador);
        }

        // POST: Observadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Observador,Nombre,Apellido,Email,Estado")] Observador observador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(observador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(observador);
        }

        // GET: Observadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Observador observador = db.Observadors.Find(id);
            if (observador == null)
            {
                return HttpNotFound();
            }
            return View(observador);
        }

        // POST: Observadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Observador observador = db.Observadors.Find(id);
            db.Observadors.Remove(observador);
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
