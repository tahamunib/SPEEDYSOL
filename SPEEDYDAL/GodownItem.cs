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
    
    public partial class GodownItem
    {
        public long sysSerial { get; set; }
        public long godownID { get; set; }
        public long itemID { get; set; }
        public long Qty { get; set; }
    
        public virtual Godown Godown { get; set; }
        public virtual Item Item { get; set; }
    }
}
