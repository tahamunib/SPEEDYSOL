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
    
    public partial class SSAccounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SSAccounts()
        {
            this.Vouchers = new HashSet<Vouchers>();
            this.Vouchers1 = new HashSet<Vouchers>();
        }
    
        public long sysSerial { get; set; }
        public string AccNo { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Name { get; set; }
        public long BalanceLimit { get; set; }
        public Nullable<int> DiscountInPercentage { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        public virtual AccountCategory AccountCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vouchers> Vouchers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vouchers> Vouchers1 { get; set; }
    }
}