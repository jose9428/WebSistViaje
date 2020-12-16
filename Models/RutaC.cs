using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SisWebViaje.Models
{
    public class RutaC
    {

        [Required]
        [Display(Name = "Codigo")]
        [MinLength(4, ErrorMessage = "Longitud minima de 4 caracteres")]
        [MaxLength(8, ErrorMessage = "Longitud maxima de 8 caracteres")]
        public string RUTCOD { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MinLength(5, ErrorMessage = "Longitud minima de 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Longitud maxima de 20 caracteres")]
        public string RUTNOM { get; set; }

        [Required]
        [Display(Name = "Pago")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public Nullable<decimal> PAGOOCHO { get; set; }

        [Display(Name = "Imagen")]
        public string RUTIMG { get; set; }
    }

    [MetadataType(typeof(RutaC))]
    public partial class Ruta
    {
    }
}