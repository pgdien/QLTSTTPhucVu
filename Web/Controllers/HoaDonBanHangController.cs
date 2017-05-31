using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Models.HoaDonBanHang;

namespace Web.Controllers
{
    public class HoaDonBanHangController : Controller
    {
        // GET: HoaDonBanHang
        public ActionResult Index()
        {
            return View();
        }

        //ThanhToan
        public int ThanhToan(string id)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if(id != null)
                {
                    int idHoaDonBanHang;
                    if(int.TryParse(id, out idHoaDonBanHang))
                    {
                        var hoadonBanHang = db.ORDER_HoaDonBanHang.Where(p => p.id == idHoaDonBanHang).FirstOrDefault();
                        if(hoadonBanHang != null)
                        {
                            hoadonBanHang.isThanhToan = true;
                            var ban = db.DM_Ban.Where(p => p.id == hoadonBanHang.idBan).FirstOrDefault();
                            ban.trangthai = false;

                            //Trừ mặt hàng, tính tiền vốn
                            var chitiets = db.ORDER_ChiTietHoaDonBanHang.Where(p => p.idHoaDonBanHang == hoadonBanHang.id);
                            float tienVon = 0;
                            foreach (var chitiet in chitiets)
                            {
                                var dinhluongs = db.KT_DinhLuong.Where(p => p.idThucDon == chitiet.idThucDon);
                                foreach (var dinhluong in dinhluongs)
                                {
                                    var mathang = db.DM_MatHang.Where(p => p.id == dinhluong.idMatHang).FirstOrDefault();
                                    tienVon += float.Parse((mathang.dongia * dinhluong.soluong * chitiet.soluong).ToString());
                                    mathang.ton = mathang.ton - (dinhluong.soluong * chitiet.soluong);
                                }
                            }

                            hoadonBanHang.tienVon = tienVon;

                            db.SaveChanges();

                            return 1;
                        }
                    }
                }

                return 0;
            }
        }

        //CancelBan
        public int Cancel(string id)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if(id != null)
                {
                    int idHoaDonBanHang;
                    if(int.TryParse(id, out idHoaDonBanHang))
                    {
                        var hoadonBanHang = db.ORDER_HoaDonBanHang.Where(p => p.id == idHoaDonBanHang).FirstOrDefault();

                        if(hoadonBanHang != null)
                        {
                            var ban = db.DM_Ban.Where(p => p.id == hoadonBanHang.idBan).FirstOrDefault();

                            ban.trangthai = false;

                            db.SaveChanges();

                            return 1;
                        }


                    }
                }


                return 0;
            }
        }

        //GetChiTiet
        public JsonResult GetChiTiet(string id)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if(id != null)
                {
                    int idHoaDonBanHang;
                    if(int.TryParse(id, out idHoaDonBanHang))
                    {
                        ChiTiet model = new ChiTiet();
                        model.ChiTietThucDons = db.ORDER_ChiTietHoaDonBanHang.Where(p => p.idHoaDonBanHang == idHoaDonBanHang).ToList();
                        model.ChiTietNhanViens = db.ORDER_ChiTietNhanVienHoaDonBanHang.Where(p => p.idHoaDonBanHang == idHoaDonBanHang).ToList();

                        return Json(model, JsonRequestBehavior.AllowGet);
                    }
                }

                return null;
            }
        }

        //DeleteChiTiet
        public int DeleteChiTiet(string id)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if(id != null)
                {
                    int idHoaDonBanHang;
                    if(int.TryParse(id, out idHoaDonBanHang))
                    {
                        var hoadonBanHang = db.ORDER_HoaDonBanHang.Where(p => p.id == idHoaDonBanHang).FirstOrDefault();

                        if(hoadonBanHang != null)
                        {
                            var chitietThucDons = db.ORDER_ChiTietHoaDonBanHang.Where(p => p.idHoaDonBanHang == hoadonBanHang.id);
                            var chitietNhanViens = db.ORDER_ChiTietNhanVienHoaDonBanHang.Where(p => p.idHoaDonBanHang == hoadonBanHang.id);

                            db.ORDER_ChiTietHoaDonBanHang.RemoveRange(chitietThucDons);
                            db.ORDER_ChiTietNhanVienHoaDonBanHang.RemoveRange(chitietNhanViens);

                            db.SaveChanges();

                            return 1;
                        }
                    }
                }

                return 0;
            }
        }
    }
}