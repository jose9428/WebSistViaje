using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SisWebViaje.Models
{
    public class BusC
    {
        [Display(Name = "Nro Bus")]
        public int BUSNRO { get; set; }

        [Display(Name = "Nro Placa")]
        public string BUSPLA { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public Nullable<decimal> BUSCAP { get; set; }
    }

    [MetadataType(typeof(BusC))]
    public partial class Bus { 
    }
}