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
    
    public partial class SalesDamageChallan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesDamageChallan()
        {
            this.SalesDamageChallanItems = new HashSet<SalesDamageChallanItems>();
        }
    
        public long sysSerial { get; set; }
        public string Code { get; set; }
        public long DSRNumber { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public long GodownID { get; set; }
    
        public virtual DailySales DailySales { get; set; }
        public virtual Godowns Godowns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesDamageChallanItems> SalesDamageChallanItems { get; set; }
    }
}
