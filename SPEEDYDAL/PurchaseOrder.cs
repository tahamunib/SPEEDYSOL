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
    
    public partial class PurchaseOrder 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            this.PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }
    
        public long sysSerial { get; set; }
        public Nullable<long> GodownID { get; set; }
        public Nullable<long> ClientID { get; set; }
        public string InvType { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> TotalQtyPack { get; set; }
        public Nullable<int> TotalQtyLoose { get; set; }
        public Nullable<int> TotalQty { get; set; }
        public Nullable<int> TotalQtyBonus { get; set; }
        public Nullable<int> TotalDiscountPercentage { get; set; }
        public Nullable<long> TotalFlatDiscount { get; set; }
        public Nullable<long> TotalGST { get; set; }
        public Nullable<long> TotalExclTax { get; set; }
        public Nullable<long> TotalInclTax { get; set; }
        public Nullable<long> GrandTotal { get; set; }
        public Nullable<bool> isPosted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string POrderID { get; set; }
    
        public virtual Godown Godown { get; set; }
        public virtual SSClient SSClient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
