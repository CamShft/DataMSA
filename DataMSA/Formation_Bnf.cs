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
    
    public partial class Formation_Bnf
    {
        public int Formation_Bnf_ID { get; set; }
        public int Bnf_ID { get; set; }
        public int Formation_ID { get; set; }
    
        public virtual Beneficiaire Beneficiaire { get; set; }
        public virtual Formation Formation { get; set; }
    }
}
