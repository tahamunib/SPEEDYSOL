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
    
    public partial class PurchaseRecievingChallanItems
    {
        public long sysSerial { get; set; }
        public long ItemID { get; set; }
        public int PRCID { get; set; }
        public long Ctn { get; set; }
        public long Pcs { get; set; }
    
        public virtual Item Items { get; set; }
        public virtual PurchaseRecievingChallan PurchaseRecievingChallan { get; set; }
    }
}
