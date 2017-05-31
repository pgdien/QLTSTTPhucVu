using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class MatHangController : Controller
    {
        // GET: MatHang
        public ActionResult Index()
        {
            return View();
        }

        //NhapHang
        public int NhapHang(string id)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (id != "")
                {
                    int idChiTietXuatHang;
                    if (int.TryParse(id, out idChiTietXuatHang))
                    {
                        var chitietXuatHang = db.KT_ChiTietNhapHang.Where(p => p.id == idChiTietXuatHang).FirstOrDefault();
                        if(chitietXuatHang != null)
                        {
                            var mathang = db.DM_MatHang.Where(p => p.id == chitietXuatHang.idMatHang).FirstOrDefault();
                            if(mathang != null)
                            {
                                mathang.ton += chitietXuatHang.soluong;
                            }
                            db.SaveChanges();
                            return 1;
                        }                        
                        
                    }
                }
                return 0;
            }
        }

        //XuatHang
        public int XuatHang(string id)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (id != "")
                {
                    int idChiTietXuatHang;
                    if (int.TryParse(id, out idChiTietXuatHang))
                    {
                        var chitietXuatHang = db.KT_ChiTietXuatHang.Where(p => p.id == idChiTietXuatHang).FirstOrDefault();
                        if (chitietXuatHang != null)
                        {
                            var mathang = db.DM_MatHang.Where(p => p.id == chitietXuatHang.idMatHang).FirstOrDefault();
                            if (mathang != null)
                            {
                                mathang.ton -= chitietXuatHang.soluong;
                            }
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