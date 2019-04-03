using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NominaTarea.Models
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El Codigo no tener mas de 50 caracteres")]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El nombre no tener mas de 50 caracteres")]
        public string Nombre { get; set; }

        public virtual List<Empleado> Empleados { get; set; }

    }
}