using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NominaTarea.Models
{
    [Table("Nomina")]
    public class Nomina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Anio { get; set; }
        public int Mes { get; set; }

        public bool estado { get; set; }
        public decimal MontoTotal { get; set; }
    }
}