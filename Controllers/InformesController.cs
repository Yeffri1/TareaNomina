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
        public ActionResult Formularios(string informe)
        {
            switch (informe)
            {
                case "EmpleadosActivos":
                    ViewBag.Dptos = new SelectList(_context.Departamento, "Id", "Codigo");
                    break;
                default:
                    break;
            }
            return View(informe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Formularios(int IdDpto,string busq)
        {
            return View();
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