using NominaTarea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NominaTarea.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mantenimientos()
        {
            return View();
        }
        public ActionResult Procesos()
        {
            return View();
        }
       

        public ActionResult CalculoNomina()
        {
            Contexto db = new Contexto();
            decimal totalPagar = db.Empleado.Where(x1 => x1.Estado == true).Sum(x => x.Salario);
            Nomina nomina = new Nomina()
            {
                MontoTotal = totalPagar,
                Anio = DateTime.Now.Year,
                Mes = DateTime.Now.Month,
                estado = true
            };
            db.Nomina.Add(nomina);
            db.SaveChanges();
            return View(nomina);
        }
    }
}