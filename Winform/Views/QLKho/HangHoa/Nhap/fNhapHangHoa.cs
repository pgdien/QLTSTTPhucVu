using DevExpress.XtraEditors;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using Winform.Controllers.DanhMuc;
using System.Globalization;
using System.Threading;

namespace Winform.Views.DanhMuc.NhomHang
{
    public partial class fNhapHangHoa : XtraForm
    {
        CultureInfo _culture = new CultureInfo("vi-VN");

        public fNhapHangHoa()
        {
            InitializeComponent();
            LoadData();
            Thread.CurrentThread.CurrentCulture = _culture;
        }




        #region Method
        //Load data
        private void LoadData()
        {
            splashScreenManager1.ShowWaitForm();
            gcData.DataSource = HangHoaController.Instance.GetTable();
            splashScreenManager1.CloseWaitForm();

        }

        //Load Edit
        private void ShowUpdateForm()
        {
            int index = gvData.FocusedRowHandle;
            var id = gvData.GetRowCellValue(index, "id").ToString();
            if (id != null)
            {
                fNhapHangHoaUpdate f = new fNhapHangHoaUpdate();
                f._id = int.Parse(id.ToString());
                f.ShowDialog();
                LoadData();
            }
            gvData.FocusedRowHandle = index;
        }

        //Load add
        private void ShowAddForm()
        {
            fNhapHangHoaUpdate f = new fNhapHangHoaUpdate();
            f._id = -1;
            f.ShowDialog();
            LoadData();
            gvData.FocusedRowHandle = gvData.RowCount - 1;
        }

        #endregion

        #region Event
        //Click Thêm
        /// <summary>
        /// Nhấn vào thêm thì mở form thêm, sau khi đóng form thêm thì load lại dữ liệu datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAddForm();
        }

        //Click sửa
        private void bbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowUpdateForm();
        }

        //Double Click sửa
        private void gcData_DoubleClick(object sender, EventArgs e)
        {
            ShowUpdateForm();
        }

        //Click Xóa
        private void bbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<int> listId = new List<int>();
                foreach (var item in gvData.GetSelectedRows())
                {
                    int id = int.Parse(gvData.GetRowCellValue(item, "id").ToString());
                    listId.Add(id);
                }

                if (NhomHangController.Instance.Delete(listId))
                {
                    XtraMessageBox.Show("Xóa thành công", "Thông báo");
                    LoadData();
                }
                else
                {
                    XtraMessageBox.Show("Xóa thất bại", "Thông báo");
                }
            }
        }

        //Click Tải lại
        private void bbtnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        //Click In
        private void bbtnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!gcData.IsPrintingAvailable)
            {
                XtraMessageBox.Show("Chức năng không được hỗ trợ", "Thông báo");
                return;
            }

            gcData.ShowPrintPreview();
        }


        #endregion
    }
}
