﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NominaTarea.Models;

namespace NominaTarea.Controllers
{
    public class VacacionesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Vacaciones
        public ActionResult Index()
        {
            var vacaciones = db.Vacaciones.Include(v => v.Empleado);
            return View(vacaciones.ToList());
        }

        // GET: Vacaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacaciones vacaciones = db.Vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // GET: Vacaciones/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "Id", "Nombre");
            return View();
        }

        // POST: Vacaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpleado,Desde,Hasta,Comentario")] Vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.Vacaciones.Add(vacaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleado, "Id", "Nombre", vacaciones.IdEmpleado);
            return View(vacaciones);
        }

        // GET: Vacaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacaciones vacaciones = db.Vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "Id", "Nombre", vacaciones.IdEmpleado);
            return View(vacaciones);
        }

        // POST: Vacaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpleado,Desde,Hasta,Comentario")] Vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "Id", "Nombre", vacaciones.IdEmpleado);
            return View(vacaciones);
        }

        // GET: Vacaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacaciones vacaciones = db.Vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // POST: Vacaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacaciones vacaciones = db.Vacaciones.Find(id);
            db.Vacaciones.Remove(vacaciones);
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
