using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SisWebViaje.Models
{
    public class ViajeC
    {
        [Display(Name = "Nro Viaje")]
        public string VIANRO { get; set; }
        public Nullable<int> BUSNRO { get; set; }
        public string RUTCOD { get; set; }
        public string IDCOD { get; set; }

        [Required]
        [Display(Name = "Hora viaje")]
        public string VIAHRS { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> VIAFCH { get; set; }

        [Required]
        [Display(Name = "Costo")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public Nullable<decimal> COSVIA { get; set; }
    }
    [MetadataType(typeof(ViajeC))]
    public partial class Viaje { 
    }
}