//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SisWebViaje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Viaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Viaje()
        {
            this.Pasajeros = new HashSet<Pasajeros>();
        }
    
        public string VIANRO { get; set; }
        public Nullable<int> BUSNRO { get; set; }
        public string RUTCOD { get; set; }
        public string IDCOD { get; set; }
        public string VIAHRS { get; set; }
        public Nullable<System.DateTime> VIAFCH { get; set; }
        public Nullable<decimal> COSVIA { get; set; }
    
        public virtual Bus Bus { get; set; }
        public virtual Chofer Chofer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pasajeros> Pasajeros { get; set; }
        public virtual Ruta Ruta { get; set; }
    }
}
