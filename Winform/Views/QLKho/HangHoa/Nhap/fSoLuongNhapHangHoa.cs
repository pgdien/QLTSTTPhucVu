using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Controllers.DanhMuc;
using Winform.Models;
using Winform.Views.DanhMuc.NhomHang;

namespace Winform.Views.QLKho.HangHoa.Nhap
{
    public partial class fSoLuongNhapHangHoa : Form
    {
        CultureInfo _culture = new CultureInfo("vi-VN");
        public int _idHangHoa;
        public int _idNhapHang;

        public fSoLuongNhapHangHoa()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = _culture;
        }





        #region Method
        //LoadForm
        private void LoadForm()
        {
            rbTang.Checked = true;
            if (NhapHangHoaController.Instance.CheckExistChiTiet(_idNhapHang, _idHangHoa) == null)
            {
                rbGiam.Enabled = false;
                numSoLuong.Value = 1;
            }

            
        }


        //Tăng
        private void Tang()
        {
            using(fNhapHangHoaUpdate f = new fNhapHangHoaUpdate())
            {
                
            }
        }
        #endregion


        #region Event
        //Load form
        private void fSoLuongNhapHangHoa_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        //Check Tăng
        private void rbTang_CheckedChanged(object sender, EventArgs e)
        {
            numSoLuong.Maximum = 999;
            numSoLuong.Minimum = 0;
        }

        //Check Giảm
        private void rbGiam_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
