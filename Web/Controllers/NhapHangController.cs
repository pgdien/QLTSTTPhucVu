using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class NhapHangController : Controller
    {
        // GET: NhapHang
        public ActionResult Index()
        {
            return View();
        }

        //Delete
        public int Delete(string id)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (id != null)
                {
                    int idNhapHang;
                    if (int.TryParse(id, out idNhapHang))
                    {
                        //Delte ChiTiet
                        var chitiets = db.KT_ChiTietNhapHang.Where(p => p.idNhapHang == idNhapHang);
                        if(chitiets.Count() > 0)
                        {
                            db.KT_ChiTietNhapHang.RemoveRange(chitiets);
                        }

                        var nhaphang = db.KT_NhapHang.Where(p => p.id == idNhapHang).FirstOrDefault();
                        db.KT_NhapHang.Remove(nhaphang);

                        db.SaveChanges();

                        return 1;
                    }
                }

                return 0;
            }
        }
    }
}