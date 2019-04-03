using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NominaTarea.Models
{
    [Table("Salida")]
    public class Salida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdEmpleado { get; set; }

        [Required]
        public DateTime FechaSalida { get; set; }

        [Required]
        public string TipoSalida { get; set; }


        [Required]
        public string Motivo { get; set; }

        [ForeignKey("IdEmpleado")]
        public virtual Empleado Empleado { get; set; }
    }
}