using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SisWebViaje.Models
{
    public class UsuariosC
    {
        public int codusr { get; set; }
        public string Nombre { get; set; }

        [Required]
        [MinLength(4 , ErrorMessage = "Longitud minina es de 4 caracteres")]
        [MaxLength(10, ErrorMessage = "Longitud maxima es de 10 caracteres")]

        public string usuario { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Longitud minina es de 4 caracteres")]
        [MaxLength(10, ErrorMessage = "Longitud maxima es de 10 caracteres")]
        public string clave { get; set; }
    }

    [MetadataType(typeof(UsuariosC))]
    public partial class Usuarios { 
    }
}