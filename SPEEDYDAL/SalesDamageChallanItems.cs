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
    
    public partial class SalesDamageChallanItems
    {
        public int sysSerial { get; set; }
        public long DamCID { get; set; }
        public long ItemID { get; set; }
        public int CTN { get; set; }
        public Nullable<int> PC { get; set; }
    
        public virtual SalesDamageChallan SalesDamageChallan { get; set; }
    }
}