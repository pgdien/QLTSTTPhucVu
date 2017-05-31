namespace Winform
{
    partial class fLayout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLayout));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbtnNhomHang = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnHangHoa = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnKhuVuc = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnPhongHat = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnNhapHangHoa = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnXuatHangHoa = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbtnNhomHang,
            this.bbtnHangHoa,
            this.bbtnKhachHang,
            this.bbtnKhuVuc,
            this.bbtnPhongHat,
            this.bbtnNhapHangHoa,
            this.bbtnXuatHangHoa});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1367, 146);
            // 
            // bbtnNhomHang
            // 
            this.bbtnNhomHang.Caption = "Nhóm hàng";
            this.bbtnNhomHang.Id = 1;
            this.bbtnNhomHang.LargeGlyph = global::Winform.Properties.Resources.category;
            this.bbtnNhomHang.Name = "bbtnNhomHang";
            this.bbtnNhomHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnNhomHang_ItemClick);
            // 
            // bbtnHangHoa
            // 
            this.bbtnHangHoa.Caption = "Hàng hóa";
            this.bbtnHangHoa.Id = 2;
            this.bbtnHangHoa.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnHangHoa.LargeGlyph")));
            this.bbtnHangHoa.Name = "bbtnHangHoa";
            this.bbtnHangHoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnHangHoa_ItemClick);
            // 
            // bbtnKhachHang
            // 
            this.bbtnKhachHang.Caption = "Khách hàng";
            this.bbtnKhachHang.Glyph = ((System.Drawing.Image)(resources.GetObject("bbtnKhachHang.Glyph")));
            this.bbtnKhachHang.Id = 3;
            this.bbtnKhachHang.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnKhachHang.LargeGlyph")));
            this.bbtnKhachHang.Name = "bbtnKhachHang";
            // 
            // bbtnKhuVuc
            // 
            this.bbtnKhuVuc.Caption = "Khu vực";
            this.bbtnKhuVuc.Id = 4;
            this.bbtnKhuVuc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnKhuVuc.LargeGlyph")));
            this.bbtnKhuVuc.Name = "bbtnKhuVuc";
            // 
            // bbtnPhongHat
            // 
            this.bbtnPhongHat.Caption = "Phòng hát";
            this.bbtnPhongHat.Id = 5;
            this.bbtnPhongHat.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbtnPhongHat.LargeGlyph")));
            this.bbtnPhongHat.Name = "bbtnPhongHat";
            // 
            // bbtnNhapHangHoa
            // 
            this.bbtnNhapHangHoa.Caption = "Nhập Hàng hóa";
            this.bbtnNhapHangHoa.Glyph = global::Winform.Properties.Resources.import;
            this.bbtnNhapHangHoa.Id = 6;
            this.bbtnNhapHangHoa.LargeGlyph = global::Winform.Properties.Resources.import;
            this.bbtnNhapHangHoa.Name = "bbtnNhapHangHoa";
            this.bbtnNhapHangHoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnNhapHangHoa_ItemClick);
            // 
            // bbtnXuatHangHoa
            // 
            this.bbtnXuatHangHoa.Caption = "Xuất Hàng hóa";
            this.bbtnXuatHangHoa.Id = 7;
            this.bbtnXuatHangHoa.LargeGlyph = global::Winform.Properties.Resources.export;
            this.bbtnXuatHangHoa.Name = "bbtnXuatHangHoa";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Bán hàng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbtnNhomHang);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbtnHangHoa);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbtnKhachHang);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbtnKhuVuc);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbtnPhongHat);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Danh mục";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Quản lý Kho";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.bbtnNhapHangHoa);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbtnXuatHangHoa);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "Phiếu Nhập - Xuất hàng hóa";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // fLayout
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 714);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "fLayout";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Quán Karoke";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbtnNhomHang;
        private DevExpress.XtraBars.BarButtonItem bbtnHangHoa;
        private DevExpress.XtraBars.BarButtonItem bbtnKhachHang;
        private DevExpress.XtraBars.BarButtonItem bbtnKhuVuc;
        private DevExpress.XtraBars.BarButtonItem bbtnPhongHat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem bbtnNhapHangHoa;
        private DevExpress.XtraBars.BarButtonItem bbtnXuatHangHoa;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}

