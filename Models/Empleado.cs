using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NominaTarea.Models
{
    [Table("Empleado")]
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
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }


        public bool  Estado { get; set; }

        //LLAVES
        [Display(Name = "Departamento",Description = "Departamento")]
        public int IdDpto { get; set; }
        [ForeignKey("IdDpto")]
        public virtual Departamento Departamento { get; set; }

        [Display(Name = "Cargo", Description = "Cargo")]
        public int IdCargo { get; set; }
        [ForeignKey("IdCargo")]
        public virtual Cargo Cargo { get; set; }


        //NAVEGACIONES
        public virtual List<Salida> Salidas { get; set; }
        public virtual List<Licencias> Licencias { get; set; }
        public virtual List<Permisos> Permisos { get; set; }
        public virtual List<Vacaciones> Vacaciones { get; set; }
    }
}