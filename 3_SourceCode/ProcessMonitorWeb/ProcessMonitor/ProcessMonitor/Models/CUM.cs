//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProcessMonitor.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUM()
        {
            this.Heads = new HashSet<Head>();
            this.MAYTINHs = new HashSet<MAYTINH>();
        }
    
        public string MSCum { get; set; }
        public string MSTram { get; set; }
        public string TenCum { get; set; }
    
        public virtual TRAM TRAM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Head> Heads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MAYTINH> MAYTINHs { get; set; }
    }
}
