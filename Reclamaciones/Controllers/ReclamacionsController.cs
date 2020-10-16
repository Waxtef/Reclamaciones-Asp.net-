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
    public class ReclamacionsController : Controller
    {
        private DB_ReclamacionesEntities2 db = new DB_ReclamacionesEntities2();

        // GET: Reclamacions
        public ActionResult Index()
        {
            var reclamacions = db.Reclamacions.Include(r => r.Categoria1).Include(r => r.Observador1).Include(r => r.Tipo_Reclamacion1).Include(r => r.Usuario1);
            return View(reclamacions.ToList());
        }

        // GET: Reclamacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamacion reclamacion = db.Reclamacions.Find(id);
            if (reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(reclamacion);
        }

        // GET: Reclamacions/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.Categorias, "Id_Categoria", "Descripcion");
            ViewBag.Observador = new SelectList(db.Observadors, "Id_Observador", "Nombre");
            ViewBag.Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "Id_Tipo", "Descripcion");
            ViewBag.Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre");
            return View();
        }

        // POST: Reclamacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Reclamacion,Tipo_Reclamacion,Categoria,Descripcion,Detalle,Ubicacion_Campus,Ubicacion_Edificio,Observador,Usuario,Fecha_Reclamacion,Estado")] Reclamacion reclamacion)
        {
            if (ModelState.IsValid)
            {
                db.Reclamacions.Add(reclamacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.Categorias, "Id_Categoria", "Descripcion", reclamacion.Categoria);
            ViewBag.Observador = new SelectList(db.Observadors, "Id_Observador", "Nombre", reclamacion.Observador);
            ViewBag.Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "Id_Tipo", "Descripcion", reclamacion.Tipo_Reclamacion);
            ViewBag.Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", reclamacion.Usuario);
            return View(reclamacion);
        }

        // GET: Reclamacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamacion reclamacion = db.Reclamacions.Find(id);
            if (reclamacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "Id_Categoria", "Descripcion", reclamacion.Categoria);
            ViewBag.Observador = new SelectList(db.Observadors, "Id_Observador", "Nombre", reclamacion.Observador);
            ViewBag.Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "Id_Tipo", "Descripcion", reclamacion.Tipo_Reclamacion);
            ViewBag.Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", reclamacion.Usuario);
            return View(reclamacion);
        }

        // POST: Reclamacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Reclamacion,Tipo_Reclamacion,Categoria,Descripcion,Detalle,Ubicacion_Campus,Ubicacion_Edificio,Observador,Usuario,Fecha_Reclamacion,Estado")] Reclamacion reclamacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "Id_Categoria", "Descripcion", reclamacion.Categoria);
            ViewBag.Observador = new SelectList(db.Observadors, "Id_Observador", "Nombre", reclamacion.Observador);
            ViewBag.Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "Id_Tipo", "Descripcion", reclamacion.Tipo_Reclamacion);
            ViewBag.Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", reclamacion.Usuario);
            return View(reclamacion);
        }

        // GET: Reclamacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamacion reclamacion = db.Reclamacions.Find(id);
            if (reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(reclamacion);
        }

        // POST: Reclamacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclamacion reclamacion = db.Reclamacions.Find(id);
            db.Reclamacions.Remove(reclamacion);
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
