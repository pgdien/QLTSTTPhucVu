using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Controllers.DanhMuc;
using Winform.Models;

namespace Winform.Views.DanhMuc.NhomHang
{
    public partial class fNhomHangUpdate : Form
    {
        public int _id;

        public fNhomHangUpdate()
        {
            InitializeComponent();
        }


        #region Method

        //Check tên
        private bool CheckTen()
        {
            bool validate = false;
            //Check required
            if (txtTen.Text.Trim().Equals(string.Empty))
            {
                dxErrorProvider1.SetError(txtTen, "Vui lòng nhập Tên");
                validate = false;
            }
            else
            {
                //Check exited
                if (NhomHangController.Instance.CheckTenExist(_id, txtTen.Text.Trim()))
                {
                    dxErrorProvider1.SetError(txtTen, "Tên đã tồn tại");
                    validate = false;
                }
                else
                {
                    dxErrorProvider1.SetError(txtTen, "");
                    validate = true;
                }
            }

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
        #endregion

        #region Event
        //Load form
        /// <summary>
        /// Thay đổi tên form
        /// Nạp dữ liệu vào form (nếu có)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fNhomHangUpdate_Load(object sender, EventArgs e)
        {
            if(_id == -1)
            {
                this.Text = "Thêm nhóm hàng";
            }
            else
            {
                this.Text = "Cập nhật Nhóm hàng";
                var data = NhomHangController.Instance.GetNhomHang(_id);
                if(data != null)
                {
                    txtMa.Text = data.ma;
                    txtTen.Text = data.ten;
                    txtGhiChu.Text = data.ghichu;
                }
            }
        }

        //Lưu
        private void bbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckData())
            {
                return;
            }
            else
            {
                DM_NhomHang data = new DM_NhomHang()
                {
                    ma = txtMa.Text.Trim(),
                    ten = txtTen.Text.Trim(),
                    ghichu = txtGhiChu.Text.Trim()
                };
                if (_id > -1)
                {
                    data.id = _id;
                }
                NhomHangController.Instance.Save(data);

                this.Close();
            }
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



        #endregion

        
    }
}
