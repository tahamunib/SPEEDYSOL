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
    
    public partial class Vouchers
    {
        public long sysSerial { get; set; }
        public string VoucherCode { get; set; }
        public long AccountID { get; set; }
        public long Amount { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string RefNo { get; set; }
        public int VoucherTypeID { get; set; }
        public long AcHead { get; set; }
    
        public virtual SSAccounts SSAccounts { get; set; }
        public virtual SSAccounts SSAccounts1 { get; set; }
    }
}
