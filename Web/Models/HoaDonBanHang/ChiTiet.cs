using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.HoaDonBanHang
{
    public class ChiTiet
    {
        public List<ORDER_ChiTietHoaDonBanHang> ChiTietThucDons { get; set; }
        public List<ORDER_ChiTietNhanVienHoaDonBanHang> ChiTietNhanViens { get; set; }
    }
}