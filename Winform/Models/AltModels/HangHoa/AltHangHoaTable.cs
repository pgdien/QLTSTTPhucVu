using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Models.AltModels.HangHoa
{
    public class AltHangHoaTable
    {
        public int id { get; set; }
        public string ma { get; set; }
        public string donvitinh { get; set; }
        public string nhomHang { get; set; }
        public string ten { get; set; }
        public float giaLe { get; set; }
        public float giaVon { get; set; }
        public float soluong { get; set; }
        public string ghichu { get; set; }

        public AltHangHoaTable() { }

        public AltHangHoaTable(KT_HangHoa hanghoa)
        {
            using(Karaoke2017Entities db = new Karaoke2017Entities())
            {
                this.id = hanghoa.id;
                this.ma = hanghoa.ma;
                this.ten = hanghoa.ten;
                var nhomHang = db.DM_NhomHang.Where(p => p.id == hanghoa.idNhomHang).FirstOrDefault();
                if(nhomHang != null)
                {
                    this.nhomHang = nhomHang.ten;
                }
                var donvitinh = db.DM_DonViTinh.Where(p => p.id == hanghoa.idDonViTinh).FirstOrDefault();
                if (donvitinh != null)
                {
                    this.donvitinh = donvitinh.ten;
                }
                float giaVon;
                if(float.TryParse(hanghoa.giaVon.ToString(), out giaVon))
                {
                    this.giaVon = giaVon;
                }
                else
                {
                    this.giaVon = 0;
                }
                float giaLe;
                if (float.TryParse(hanghoa.giaLe.ToString(), out giaLe))
                {
                    this.giaLe = giaLe;
                }
                else
                {
                    this.giaLe = 0;
                }
                float soluong;
                if (float.TryParse(hanghoa.soluong.ToString(), out soluong))
                {
                    this.soluong = soluong;
                }
                else
                {
                    this.soluong = 0;
                }
                this.ghichu = hanghoa.ghichu;
            }
        }
    }
}
