//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataMSA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Type_Hebergment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type_Hebergment()
        {
            this.Inscriptions = new HashSet<Inscription>();
        }
    
        public int Hebergement_ID { get; set; }
        public string Hebergement_Type { get; set; }
        public int Hebergement_Min { get; set; }
        public int Hebergement_Max { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
