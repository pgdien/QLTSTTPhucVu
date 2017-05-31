using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class XuatHangController : Controller
    {
        // GET: XuatHang
        public ActionResult Index()
        {
            return View();
        }

        //Delete
        public int Delete(string id)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (id != null)
                {
                    int idXuatHang;
                    if (int.TryParse(id, out idXuatHang))
                    {
                        //Delte ChiTiet
                        var chitiets = db.KT_ChiTietXuatHang.Where(p => p.idXuatHang == idXuatHang);
                        if (chitiets.Count() > 0)
                        {
                            db.KT_ChiTietXuatHang.RemoveRange(chitiets);
                        }

                        var xuathang = db.KT_XuatHang.Where(p => p.id == idXuatHang).FirstOrDefault();
                        db.KT_XuatHang.Remove(xuathang);

                        db.SaveChanges();

                        return 1;
                    }
                }

                return 0;
            }
        }
    }
}