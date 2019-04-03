using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NominaTarea.Models
{
    public class Contexto : DbContext
    {
      
        public Contexto() : base("DefaultConnection")
        {
        }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Salida> Salida { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Licencias> Licencias { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Vacaciones> Vacaciones { get; set; }
        public virtual DbSet<Nomina> Nomina { get; set; }
    }
}