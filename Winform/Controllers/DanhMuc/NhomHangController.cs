using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winform.Models;

namespace Winform.Controllers.DanhMuc
{
    public class NhomHangController
    {
        private static NhomHangController instance;

        public static NhomHangController Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhomHangController();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private NhomHangController() { }

        public void Save(DM_NhomHang data)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (data.id > 0)
                {
                    var nhomHang = db.DM_NhomHang.Find(data.id);
                    nhomHang.ma = data.ma;
                    nhomHang.ten = data.ten;
                    nhomHang.ghichu = data.ghichu;
                    db.SaveChanges();
                }
                else
                {
                    db.DM_NhomHang.Add(data);
                    db.SaveChanges();
                }
            }

        }

        public bool Delete(int? id)
        {
            if (id != null)
            {
                using (Karaoke2017Entities db = new Karaoke2017Entities())
                {
                    var data = db.DM_NhomHang.Find(id);
                    if (data != null)
                    {
                        db.DM_NhomHang.Remove(data);
                        db.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }
        public bool Delete(List<int> array)
        {
            if (array.Count() > 0)
            {
                using (Karaoke2017Entities db = new Karaoke2017Entities())
                {
                    var data = db.DM_NhomHang.Where(p => array.Contains(p.id)).ToList();
                    if (data.Count > 0)
                    {
                        db.DM_NhomHang.RemoveRange(data);
                        db.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }

        public List<DM_NhomHang> GetAll()
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                return db.DM_NhomHang.ToList();
            }
        }
        public DM_NhomHang GetNhomHang(int? id)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (id != null)
                {
                    return db.DM_NhomHang.Find(id);
                }
            }

            return null;
        }
        public bool CheckTenExist(int id, string ten)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (db.DM_NhomHang.Where(p => p.id != id && p.ten.Equals(ten)).FirstOrDefault() == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
