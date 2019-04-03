using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NominaTarea.Models
{
    [Table("Licencias")]

    public class Licencias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdEmpleado { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Desde { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Hasta { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "No puede tener mas de 500 caracteres.")]
        public string Comentario { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "No puede tener mas de 500 caracteres.")]
        public string Motivo { get; set; }

        [ForeignKey("IdEmpleado")]
        public virtual Empleado Empleado { get; set; }
    }
}