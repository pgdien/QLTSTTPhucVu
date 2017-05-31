using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winform.Models;
using Winform.Models.AltModels.HangHoa;

namespace Winform.Controllers.DanhMuc
{
    public class HangHoaController
    {
        private static HangHoaController instance;

        public static HangHoaController Instance
        {
            get
            {
                if (instance == null)
                    instance = new HangHoaController();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private HangHoaController() { }

        public void Save(KT_HangHoa data)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (data.id > 0)
                {
                    var model = db.KT_HangHoa.Find(data.id);
                    model.idNhomHang = data.idNhomHang;
                    model.idDonViTinh = data.idDonViTinh;
                    model.ten = data.ten;
                    model.giaVon = data.giaVon;
                    model.giaLe = data.giaLe;
                    model.ghichu = data.ghichu;
                    
                    db.SaveChanges();
                }
                else
                {
                    data.soluong = 0;
                    db.KT_HangHoa.Add(data);
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
                    var data = db.KT_HangHoa.Find(id);
                    if (data != null)
                    {
                        db.KT_HangHoa.Remove(data);
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
                    var data = db.KT_HangHoa.Where(p => array.Contains(p.id)).ToList();
                    if (data.Count > 0)
                    {
                        db.KT_HangHoa.RemoveRange(data);
                        db.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }

        public List<KT_HangHoa> GetAll()
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                return db.KT_HangHoa.ToList();
            }
        }

        public List<AltHangHoaTable> GetTable()
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                List<AltHangHoaTable> model = new List<AltHangHoaTable>();

                var hanghoas = db.KT_HangHoa.ToList();
                if(hanghoas.Count > 0)
                {
                    foreach (var item in hanghoas)
                    {
                        AltHangHoaTable hanghoa = new AltHangHoaTable(item);
                        model.Add(hanghoa);
                    }
                }

                return model;
            }
        }

        public KT_HangHoa GetHangHoa(int? id)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (id != null)
                {
                    return db.KT_HangHoa.Find(id);
                }
            }

            return null;
        }
        public bool CheckTenExist(int id, string ten)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (db.KT_HangHoa.Where(p => p.id != id && p.ten.Equals(ten)).FirstOrDefault() == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public List<KT_HangHoa> GetByNhomHang(int idNhomHang)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                return db.KT_HangHoa.Where(p => p.idNhomHang == idNhomHang).ToList();
            }
        }
    }
}
