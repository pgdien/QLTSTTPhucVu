//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDER_ChuyenBan
    {
        public int id { get; set; }
        public string idNhanVien { get; set; }
        public Nullable<int> idHoaDonTuBan { get; set; }
        public Nullable<int> idTuBan { get; set; }
        public Nullable<int> idHoaDonDenBan { get; set; }
        public Nullable<int> idDenBan { get; set; }
        public bool isChuyenHet { get; set; }
        public Nullable<System.DateTime> thoigian { get; set; }
    }
}