//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reclamaciones.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            this.Reclamacions = new HashSet<Reclamacion>();
        }
    
        public int Id_Categoria { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public Nullable<int> Tipo_Reclamacion { get; set; }
    
        public virtual Tipo_Reclamacion Tipo_Reclamacion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamacion> Reclamacions { get; set; }
    }
}
