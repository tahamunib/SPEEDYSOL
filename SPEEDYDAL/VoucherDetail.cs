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
    
    public partial class VoucherDetail
    {
        public long sysSerial { get; set; }
        public Nullable<long> VoucherID { get; set; }
        public Nullable<long> AccountID { get; set; }
        public string VoucherCode { get; set; }
        public string RefNo { get; set; }
        public string Description { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual SSAccount SSAccount { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
