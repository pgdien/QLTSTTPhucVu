using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winform.Views.DanhMuc.NhomHang;

namespace Winform
{
    public partial class fLayout : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fLayout()
        {
            InitializeComponent();
        }


        #region Method
        /// <summary>
        /// Kiểm tra nếu form show rồi thì active không thì show lên
        /// </summary>
        /// <param name="form"></param>
        private void ShowForm(Form form)
        {
            foreach (var item in MdiChildren)
            {
                if (item.Name == form.Name)
                {
                    item.Activate();
                    return;
                }
            }

            form.MdiParent = this;
            form.Show();
        }


        #endregion




        #region Ribbon Menu

        //Nhóm hàng
        private void bbtnNhomHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fNhomHang f = new fNhomHang();
            ShowForm(f);
        }

        //Hàng hóa
        private void bbtnHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fHangHoa f = new fHangHoa();
            ShowForm(f);
        }

        //Nhập hàng hóa
        private void bbtnNhapHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fNhapHangHoa f = new fNhapHangHoa();
            ShowForm(f);
        }

        #endregion


    }
}
