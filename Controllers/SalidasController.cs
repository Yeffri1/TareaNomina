using System;
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
    public class SalidasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Salidas
        public ActionResult Index()
        {
            var salida = db.Salida.Include(s => s.Empleado);
            return View(salida.ToList());
        }

        // GET: Salidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salida.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // GET: Salidas/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "Id", "Nombre");
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Despido",
                    Value = "Despido"
                },
                new SelectListItem()
                {
                     Text = "Desahusio",
                    Value = "Desahusio"
                },
                new SelectListItem()
                {
                     Text = "Renuncia",
                    Value = "Renuncia"
                }
            };
            ViewBag.TipoSalida = new SelectList(items, "Value", "Text");
            return View();
        }

        // POST: Salidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpleado,FechaSalida,TipoSalida,Motivo,Empleado")] Salida salida)
        {
            salida.Empleado = db.Empleado.Find(salida.IdEmpleado);
            salida.Empleado.Estado = false;
            if (ModelState.IsValid)
            {
                db.Salida.Add(salida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Despido",
                    Value = "Despido"
                },
                new SelectListItem()
                {
                     Text = "Desahusio",
                    Value = "Desahusio"
                },
                new SelectListItem()
                {
                     Text = "Renuncia",
                    Value = "Renuncia"
                }
            };
            ViewBag.TipoSalida = new SelectList(items, "Value", "Text");
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "Id", "Nombre", salida.IdEmpleado);
            return View(salida);
        }

        // GET: Salidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salida.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Despido",
                    Value = "Despido"
                },
                new SelectListItem()
                {
                     Text = "Desahusio",
                    Value = "Desahusio"
                },
                new SelectListItem()
                {
                     Text = "Renuncia",
                    Value = "Renuncia"
                }
            };
            ViewBag.TipoSalida = new SelectList(items, "Value", "Text");
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "Id", "Nombre", salida.IdEmpleado);
            return View(salida);
        }

        // POST: Salidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpleado,FechaSalida,TipoSalida,Motivo")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Despido",
                    Value = "Despido"
                },
                new SelectListItem()
                {
                     Text = "Desahusio",
                    Value = "Desahusio"
                },
                new SelectListItem()
                {
                     Text = "Renuncia",
                    Value = "Renuncia"
                }
            };
            ViewBag.TipoSalida = new SelectList(items, "Value", "Text");
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "Id", "Nombre", salida.IdEmpleado);
            return View(salida);
        }

        // GET: Salidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salida.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // POST: Salidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salida salida = db.Salida.Find(id);
            db.Salida.Remove(salida);
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
