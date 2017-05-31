using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winform.Models;
using Winform.Models.AltModels.HangHoa;

namespace Winform.Controllers.DanhMuc
{
    public class NhapHangHoaController
    {
        private static NhapHangHoaController instance;

        public static NhapHangHoaController Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhapHangHoaController();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private NhapHangHoaController() { }

        public void Save(KT_NhapHang data)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (data.id > 0)
                {
                    var model = db.KT_NhapHang.Find(data.id);
                    model.nguoiNhan = data.nguoiNhan;
                    model.nguoiGiao = data.nguoiGiao;
                    model.thoigian = data.thoigian;
                    model.tongTien = data.tongTien;
                    model.ghichu = data.ghichu;

                    db.SaveChanges();
                }
                else
                {
                    db.KT_NhapHang.Add(data);
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
                    var data = db.KT_NhapHang.Find(id);
                    if (data != null)
                    {
                        db.KT_NhapHang.Remove(data);
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
                    var data = db.KT_NhapHang.Where(p => array.Contains(p.id)).ToList();
                    if (data.Count > 0)
                    {
                        db.KT_NhapHang.RemoveRange(data);
                        db.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }

        public List<KT_NhapHang> GetAll()
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                return db.KT_NhapHang.ToList();
            }
        }

        //public List<AltHangHoaTable> GetTable()
        //{
        //    using(Karaoke2017Entities db = new Karaoke2017Entities())
        //    {
        //        List<AltHangHoaTable> model = new List<AltHangHoaTable>();

        //        var hanghoas = db.KT_NhapHang.ToList();
        //        if(hanghoas.Count > 0)
        //        {
        //            foreach (var item in hanghoas)
        //            {
        //                AltHangHoaTable hanghoa = new AltHangHoaTable(item);
        //                model.Add(hanghoa);
        //            }
        //        }

        //        return model;
        //    }
        //}

        public KT_NhapHang GetNhapHang(int? id)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                if (id != null)
                {
                    return db.KT_NhapHang.Find(id);
                }
            }

            return null;
        }

        public KT_ChiTietNhapHang CheckExistChiTiet(int idNhapHang, int idHangHoa)
        {
            using (Karaoke2017Entities db = new Karaoke2017Entities())
            {
                return db.KT_ChiTietNhapHang.Where(p => p.idNhapHang == idNhapHang && p.idHangHoa == idHangHoa).FirstOrDefault();
            }
        }


        //public bool CheckTenExist(int id, string ten)
        //{
        //    using(Karaoke2017Entities db = new Karaoke2017Entities())
        //    {
        //        if (db.KT_NhapHang.Where(p => p.id != id && p.ten.Equals(ten)).FirstOrDefault() == null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}

        //public List<KT_NhapHang> GetByNhomHang(int idNhomHang)
        //{
        //    using(Karaoke2017Entities db = new Karaoke2017Entities())
        //    {
        //        return db.KT_NhapHang.Where(p => p.idNhomHang == idNhomHang).ToList();
        //    }
        //}
    }
}
