using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SisWebViaje.Models
{
    public class ChoferC
    {
        [Display(Name = "Codigo")]
        public string IDCOD { get; set; }

        [Required]
        [Display(Name = "Chofer")]
        [MaxLength(30, ErrorMessage = "Longitud maxima de 30 caracteres")]
        public string CHONOM { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CHOFIN { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string CHOCAT { get; set; }

        [Required]
        [Display(Name = "Costo")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        //  [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public Nullable<decimal> CHOSBA { get; set; }

        [Display(Name = "Imagen")]
        public string CHOIMG { get; set; }
    }

    [MetadataType(typeof(ChoferC))]
    public partial class Chofer { 
    }
}