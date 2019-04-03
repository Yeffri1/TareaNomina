using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NominaTarea.fonts
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El Apellido no puede tener mas de 50 caracteres")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El Codigo no puede tener mas de 50 caracteres")]
        public string Codigo { get; set; }


        [Required(ErrorMessage ="Este campo es obligatorio")]
        [StringLength(10, ErrorMessage = "El telefono no puede tener mas de 10 caracteres")]
        [Phone(ErrorMessage = "Debes ingresar 1 telefono")]
        public string Codigo { get; set; }
    }
}