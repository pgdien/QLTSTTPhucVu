using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winform.Models;

namespace Winform.Controllers.DanhMuc
{
    public class DonViTinhController
    {
        private static DonViTinhController instance;

        public static DonViTinhController Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonViTinhController();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private DonViTinhController() { }

        public void Save(DM_DonViTinh data)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                //if (data.id > 0)
                //{
                //    var nhomHang = db.DM_DonViTinh.Find(data.id);
                //    nhomHang.ma = data.ma;
                //    nhomHang.ten = data.ten;
                //    nhomHang.ghichu = data.ghichu;
                //    db.SaveChanges();
                //}
                //else
                //{
                //    db.DM_DonViTinh.Add(data);
                //    db.SaveChanges();
                //}
            }

        }

        public bool Delete(int? id)
        {
            if (id != null)
            {
                using (Karaoke2017Entities db = new Karaoke2017Entities())
                {
                    var data = db.DM_DonViTinh.Find(id);
                    if (data != null)
                    {
                        db.DM_DonViTinh.Remove(data);
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
                    var data = db.DM_DonViTinh.Where(p => array.Contains(p.id)).ToList();
                    if (data.Count > 0)
                    {
                        db.DM_DonViTinh.RemoveRange(data);
                        db.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }

        public List<DM_DonViTinh> GetAll()
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                return db.DM_DonViTinh.ToList();
            }
        }
        public DM_DonViTinh GetNhomHang(int? id)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (id != null)
                {
                    return db.DM_DonViTinh.Find(id);
                }
            }

            return null;
        }
        public bool CheckTenExist(int id, string ten)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (db.DM_DonViTinh.Where(p => p.id != id && p.ten.Equals(ten)).FirstOrDefault() == null)
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
