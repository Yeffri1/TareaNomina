using NominaTarea.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NominaTarea.Controllers
{
    public class InformesController : Controller
    {
        private Contexto _context = new Contexto();
        private SqlCommand command = null;
        private String _conexion = null;
        public InformesController()
        {
            _conexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        // GET: Informes
        public ActionResult Index(string informe)
        {
            DataTable table = null;
            if (!string.IsNullOrEmpty(informe))
            {
                table = GetDataTable("proc_informes", informe,null,null,null,null);
            }
            return View(table);
        }
        [HttpGet]
        public ViewResult Formularios(string informe)
        {
        
            switch (informe)
            {
                case "EmpleadosActivos":
                    ViewBag.Dptos = new SelectList(_context.Departamento, "Id", "Codigo");
                    break;
                case "PermisosEmpleados":
                    ViewBag.Empleados = new SelectList(_context.Empleado, "Id", "Nombre");
                    break;
                default:
                    break;
            }
            return View("~/Views/Informes/Formularios.cshtml","~/Views/Shared/_Layout.cshtml",informe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Formularios(int? IdDpto,string informe, string busq,int? IdEmpleado,int? anio,int? mes)
        {
            DataTable table  = GetDataTable("proc_informes", informe, busq, IdDpto, mes, anio);
            return View("~/Views/Informes/Index.cshtml", "~/Views/Shared/_Layout.cshtml", table);
        }

        /// <summary>
        /// EJECUTAR PROCEDIMIENTO CONSULTA QUE NO RECIBE PARAMETRO
        /// </summary>
        /// <param name="procedimiento"></param>
        /// <param name="parametros"></param>
        /// <returns>RETORNA UNA TABLA DATATABLE*</returns>
        internal DataTable GetDataTable(string procedimiento, params object[] parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sCon = new SqlConnection(_conexion))
                {
                    sCon.Open();

                    command = sCon.CreateCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedimiento;
                    SqlCommandBuilder.DeriveParameters(command);

                    int i = 0;

                    foreach (SqlParameter parametro in command.Parameters)
                    {
                        if (parametro.Direction == ParameterDirection.Input
                            || parametro.Direction == ParameterDirection.InputOutput)
                        {
                            parametro.Value = parametros[i];
                            i++;
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    sCon.Close();
                    return dt;
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}