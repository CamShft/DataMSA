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
    
    public partial class Medicament_Ins
    {
        public int Medicament_Ins_ID { get; set; }
        public decimal MedicamentIns_Mg { get; set; }
        public Nullable<int> Medicament_ID { get; set; }
        public int Ins_ID { get; set; }
        public string MedicamentIns_FreqDesc { get; set; }
    
        public virtual Inscription Inscription { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
