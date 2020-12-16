using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SisWebViaje.Models
{
    public class PasajerosC
    {
        [Display(Name = "Nro Boleto")]
        public string BOLNRO { get; set; }

        [Display(Name = "Nro Viaje")]
        public string VIANRO { get; set; }

        [Display(Name = "Pasajero")]
        public string NOM_PAS { get; set; }

        [Display(Name = "Asiento")]
        public Nullable<int> NRO_ASI { get; set; }

        [Display(Name = "Tipo")]
        public string TIPO { get; set; }

        [Display(Name = "Pago")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public Nullable<decimal> PAGO { get; set; }
    }
    [MetadataType(typeof(PasajerosC))]
    public partial class Pasajeros { 
    }
}