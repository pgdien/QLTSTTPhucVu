using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DinhLuongController : Controller
    {
        // GET: DinhLuong
        public ActionResult Index()
        {
            return View();
        }

        //DeleteByThucDon
        public int DeleteByThucDon(string id)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if(id != "")
                {
                    int idThucDon;
                    if(int.TryParse(id, out idThucDon))
                    {
                        var dinhluongs = db.KT_DinhLuong.Where(p => p.idThucDon == idThucDon);
                        db.KT_DinhLuong.RemoveRange(dinhluongs);
                        db.SaveChanges();
                        return 1;
                    }
                }

                return 0;
            }
        }
    }
}