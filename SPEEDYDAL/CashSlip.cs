//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPEEDYDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CashSlip
    {
        public long sysSerial { get; set; }
        public string Code { get; set; }
        public long DSRNumber { get; set; }
        public int Den5000 { get; set; }
        public int Den1000 { get; set; }
        public int Den500 { get; set; }
        public int Den100 { get; set; }
        public int Den50 { get; set; }
        public int Den20 { get; set; }
        public int Den10 { get; set; }
        public int Den5 { get; set; }
        public int Den2 { get; set; }
        public int Den1 { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public long Amount { get; set; }
    
        public virtual DailySales DailySales { get; set; }
    }
}
