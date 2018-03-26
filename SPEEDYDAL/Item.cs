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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            this.SaleOrderDetails = new HashSet<SaleOrderDetail>();
            this.GodownItems = new HashSet<GodownItem>();
            this.PurchaseDamageChallanItems = new HashSet<PurchaseDamageChallanItems>();
            this.PurchaseRecievingChallanItems = new HashSet<PurchaseRecievingChallanItems>();
            this.PurchaseReturnChallanItems = new HashSet<PurchaseReturnChallanItems>();
            this.SalesDeliveryChallanItems = new HashSet<SalesDeliveryChallanItems>();
            this.SalesReturnChallanItems = new HashSet<SalesReturnChallanItems>();
        }
    
        public long sysSerial { get; set; }
        public string Name { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public string Remarks { get; set; }
        public int PackUnit { get; set; }
        public Nullable<int> UnitWeight { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public int RetailPrice { get; set; }
        public int ManufacturerID { get; set; }
        public int GroupID { get; set; }
        public int BrandID { get; set; }
        public int CTNSize { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleOrderDetail> SaleOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GodownItem> GodownItems { get; set; }
        public virtual ItemBrand ItemBrand { get; set; }
        public virtual ItemGroup ItemGroup { get; set; }
        public virtual ItemManufacturer ItemManufacturer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDamageChallanItems> PurchaseDamageChallanItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseRecievingChallanItems> PurchaseRecievingChallanItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseReturnChallanItems> PurchaseReturnChallanItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesDeliveryChallanItems> SalesDeliveryChallanItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturnChallanItems> SalesReturnChallanItems { get; set; }
    }
}
