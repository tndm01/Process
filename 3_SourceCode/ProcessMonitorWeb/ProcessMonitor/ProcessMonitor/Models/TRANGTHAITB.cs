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
    
    public partial class TRANGTHAITB
    {
        public int ID { get; set; }
        public string MaTB { get; set; }
        public Nullable<System.DateTime> ThoiGian { get; set; }
        public string MoTa { get; set; }
        public double TrangThai { get; set; }
        public string MaTrangThai { get; set; }
    
        public virtual THIETBI THIETBI { get; set; }
        public virtual TRANGTHAI TRANGTHAI1 { get; set; }
    }
}
