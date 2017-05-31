using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Winform.Controllers.DanhMuc;
using Winform.Models;
using Winform.Views.QLKho.HangHoa.Nhap;

namespace Winform.Views.DanhMuc.NhomHang
{
    public partial class fNhapHangHoaUpdate : Form
    {
        CultureInfo _culture = new CultureInfo("vi-VN");
        public int _id;
        public List<KT_ChiTietNhapHang> _chitietNhapHangs = new List<KT_ChiTietNhapHang>();
        

        public fNhapHangHoaUpdate()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = _culture;
        }


        #region Method

        //Check tên
        private bool CheckTen()
        {
            bool validate = false;
            //Check required
            //if (txtTen.Text.Trim().Equals(string.Empty))
            //{
            //    dxErrorProvider1.SetError(txtTen, "Vui lòng nhập Tên");
            //    validate = false;
            //}
            //else
            //{
            //    //Check exited
            //    if (HangHoaController.Instance.CheckTenExist(_id, txtTen.Text.Trim()))
            //    {
            //        dxErrorProvider1.SetError(txtTen, "Tên đã tồn tại");
            //        validate = false;
            //    }
            //    else
            //    {
            //        dxErrorProvider1.SetError(txtTen, "");
            //        validate = true;
            //    }
            //}

            return validate;
        }

        //Check Data
        private bool CheckData()
        {
            bool checkTen = CheckTen();
            if (checkTen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //InitLookupNhomHang
        private void InitLookupNhomHang(int? id)
        {
            grlupNhomHang.Properties.DataSource = NhomHangController.Instance.GetAll();
            grlupNhomHang.Properties.DisplayMember = "ten";
            grlupNhomHang.Properties.ValueMember = "id";
            grlupNhomHang.EditValue = id;
        }
        //InitLookupDonViTinh
        private void InitLookupHangHoa(int? id)
        {
            grlupHangHoa.Properties.DataSource = HangHoaController.Instance.GetAll();
            grlupHangHoa.Properties.DisplayMember = "ten";
            grlupHangHoa.Properties.ValueMember = "id";
            grlupHangHoa.EditValue = id;
        }

        #endregion

        #region Event
        //Load form
        /// <summary>
        /// Thay đổi tên form
        /// Nạp dữ liệu vào form (nếu có)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fNhapHangHoaUpdate_Load(object sender, EventArgs e)
        {
            if (_id == -1)
            {
                this.Text = "Thêm phiếu nhập hàng";
                txtThoiGian.EditValue = DateTime.Now;
                InitLookupNhomHang(-1);
                InitLookupHangHoa(-1);
            }
            else
            {
                //this.Text = "Cập nhật phiếu nhập hàng";
                //var data = HangHoaController.Instance.GetHangHoa(_id);
                //if (data != null)
                //{
                //    txtMa.Text = data.ma;
                //    txtTen.Text = data.ten;
                //    InitLookupNhomHang(data.idNhomHang);
                //    InitLookupDonViTinh(data.idDonViTinh);
                //    txtGiaNhap.Text = data.giaVon.ToString();
                //    txtGiaBan.Text = data.giaLe.ToString();
                //    txtGhiChu.Text = data.ghichu;
                //}
            }
        }

        //Lưu
        private void bbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!CheckData())
            //{
            //    return;
            //}
            //else
            //{
            //    KT_HangHoa data = new KT_HangHoa()
            //    {
            //        ma = txtMa.Text.Trim(),
            //        ten = txtTen.Text.Trim(),
            //        idNhomHang = int.Parse(grlupNhomHang.EditValue.ToString()),
            //        idDonViTinh = int.Parse(grlupDonViTinh.EditValue.ToString()),
            //        ghichu = txtGhiChu.Text.Trim()
            //    };
            //    double giaVon;
            //    if (double.TryParse(txtGiaNhap.Text.Trim(), out giaVon))
            //    {
            //        data.giaVon = giaVon;
            //    }
            //    else
            //    {
            //        data.giaVon = 0;
            //    }
            //    double giaLe;
            //    if (double.TryParse(txtGiaBan.Text.Trim(), out giaLe))
            //    {
            //        data.giaLe = giaLe;
            //    }
            //    else
            //    {
            //        data.giaLe = 0;
            //    }
            //    if (_id > -1)
            //    {
            //        data.id = _id;
            //    }
            //    HangHoaController.Instance.Save(data);

            //    this.Close();
            //}
        }

        //Đóng
        private void bbtnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Validate
        //Validate Ten
        private void txtTen_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckTen())
            {
                e.Cancel = true;
            }
        }

        //Chọn nhóm hàng
        private void grlupNhomHang_EditValueChanged(object sender, EventArgs e)
        {
            if(int.Parse(grlupNhomHang.EditValue.ToString()) > 0)
            {
                var hanghoas = HangHoaController.Instance.GetByNhomHang(int.Parse(grlupNhomHang.EditValue.ToString()));

                grlupHangHoa.Properties.DataSource = hanghoas;
            }
        }

        //Chọn hàng hóa
        private void grlupHangHoa_EditValueChanged(object sender, EventArgs e)
        {
            if(int.Parse(grlupHangHoa.EditValue.ToString()) > 0)
            {
                var hanghoa = HangHoaController.Instance.GetHangHoa(int.Parse(grlupHangHoa.EditValue.ToString()));

                if (hanghoa != null)
                {
                    using (fSoLuongNhapHangHoa f = new fSoLuongNhapHangHoa())
                    {
                        f._idHangHoa = hanghoa.id;
                        f.ShowDialog();
                        grlupHangHoa.EditValue = -1;
                    }
                }
            }
        }


        #endregion


    }
}
