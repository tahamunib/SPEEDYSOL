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
    
    public partial class AccountCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountCategory()
        {
            this.SSAccounts = new HashSet<SSAccounts>();
        }
    
        public int sysSerial { get; set; }
        public string Name { get; set; }
        public int GroupID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string Code { get; set; }
    
        public virtual AccountGroup AccountGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SSAccounts> SSAccounts { get; set; }
    }
}
