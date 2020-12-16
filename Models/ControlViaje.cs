using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SisWebViaje.Models
{
    public class ControlViaje
    {
        public string VIANRO { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> VIAFCH { get; set; }
        public string VIAFCHA { get; set; }
        public string VIAHRS { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public Nullable<decimal> COSVIA { get; set; }
        public string BUSPLA { get; set; }
        public string CHONOM { get; set; }
        public string RUTNOM { get; set; }
    }
}