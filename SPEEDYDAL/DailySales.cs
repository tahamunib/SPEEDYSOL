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
    
    public partial class DailySales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DailySales()
        {
            this.SalesDeliveryChallan = new HashSet<SalesDeliveryChallan>();
            this.SalesReturnChallan = new HashSet<SalesReturnChallan>();
        }
    
        public long DSRNumber { get; set; }
        public long SalesManID { get; set; }
        public System.DateTime CreatedOn { get; set; }
    
        public virtual Salesman Salesman { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesDeliveryChallan> SalesDeliveryChallan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturnChallan> SalesReturnChallan { get; set; }
    }
}