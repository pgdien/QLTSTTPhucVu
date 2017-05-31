namespace Winform.Views.DanhMuc.NhomHang
{
    partial class fNhapHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNhapHangHoa));
            this.barManagerMainMenu = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtnThem = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnSua = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnTaiLai = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnIn = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Winform.Views.Wait.fWait), true, true, true);
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NhomHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // barManagerMainMenu
            // 
            this.barManagerMainMenu.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManagerMainMenu.Controller = this.barAndDockingController1;
            this.barManagerMainMenu.DockControls.Add(this.barDockControlTop);
            this.barManagerMainMenu.DockControls.Add(this.barDockControlBottom);
            this.barManagerMainMenu.DockControls.Add(this.barDockControlLeft);
            this.barManagerMainMenu.DockControls.Add(this.barDockControlRight);
            this.barManagerMainMenu.Form = this;
            this.barManagerMainMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtnThem,
            this.bbtnSua,
            this.bbtnXoa,
            this.bbtnTaiLai,
            this.bbtnIn});
            this.barManagerMainMenu.MainMenu = this.bar2;
            this.barManagerMainMenu.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 4";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbtnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbtnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbtnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbtnTaiLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbtnIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 4";
            // 
            // bbtnThem
            // 
            this.bbtnThem.Caption = "Thêm";
            this.bbtnThem.Glyph = global::Winform.Properties.Resources.add;
            this.bbtnThem.Id = 1;
            this.bbtnThem.Name = "bbtnThem";
            this.bbtnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnThem_ItemClick);
            // 
            // bbtnSua
            // 
            this.bbtnSua.Caption = "Sửa";
            this.bbtnSua.Glyph = global::Winform.Properties.Resources.edit;
            this.bbtnSua.Id = 2;
            this.bbtnSua.Name = "bbtnSua";
            this.bbtnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnSua_ItemClick);
            // 
            // bbtnXoa
            // 
            this.bbtnXoa.Caption = "Xóa";
            this.bbtnXoa.Glyph = global::Winform.Properties.Resources.remove1;
            this.bbtnXoa.Id = 3;
            this.bbtnXoa.Name = "bbtnXoa";
            this.bbtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnXoa_ItemClick);
            // 
            // bbtnTaiLai
            // 
            this.bbtnTaiLai.Caption = "Tải lại";
            this.bbtnTaiLai.Glyph = global::Winform.Properties.Resources.reload1;
            this.bbtnTaiLai.Id = 4;
            this.bbtnTaiLai.Name = "bbtnTaiLai";
            this.bbtnTaiLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnTaiLai_ItemClick);
            // 
            // bbtnIn
            // 
            this.bbtnIn.Caption = "In";
            this.bbtnIn.Glyph = global::Winform.Properties.Resources.printer;
            this.bbtnIn.Id = 5;
            this.bbtnIn.Name = "bbtnIn";
            this.bbtnIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnIn_ItemClick);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Office2003";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1054, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 576);
            this.barDockControlBottom.Size = new System.Drawing.Size(1054, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 536);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1054, 40);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 536);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcData.Location = new System.Drawing.Point(0, 40);
            this.gcData.MainView = this.gvData;
            this.gcData.MenuManager = this.barManagerMainMenu;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(1054, 536);
            this.gcData.TabIndex = 4;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            this.gcData.DoubleClick += new System.EventHandler(this.gcData_DoubleClick);
            // 
            // gvData
            // 
            this.gvData.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvData.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvData.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvData.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.DetailTip.Options.UseFont = true;
            this.gvData.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.Empty.Options.UseFont = true;
            this.gvData.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.EvenRow.Options.UseFont = true;
            this.gvData.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvData.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.FilterPanel.Options.UseFont = true;
            this.gvData.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.FixedLine.Options.UseFont = true;
            this.gvData.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.FocusedCell.Options.UseFont = true;
            this.gvData.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.FocusedRow.Options.UseFont = true;
            this.gvData.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gvData.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gvData.Appearance.FooterPanel.Options.UseFont = true;
            this.gvData.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvData.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.GroupButton.Options.UseFont = true;
            this.gvData.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.GroupFooter.Options.UseFont = true;
            this.gvData.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.GroupPanel.Options.UseFont = true;
            this.gvData.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.GroupRow.Options.UseFont = true;
            this.gvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvData.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvData.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.HorzLine.Options.UseFont = true;
            this.gvData.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.OddRow.Options.UseFont = true;
            this.gvData.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.Preview.Options.UseFont = true;
            this.gvData.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.Row.Options.UseFont = true;
            this.gvData.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.RowSeparator.Options.UseFont = true;
            this.gvData.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.SelectedRow.Options.UseFont = true;
            this.gvData.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.TopNewRow.Options.UseFont = true;
            this.gvData.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.VertLine.Options.UseFont = true;
            this.gvData.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.Appearance.ViewCaption.Options.UseFont = true;
            this.gvData.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.AppearancePrint.EvenRow.Options.UseFont = true;
            this.gvData.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gvData.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.AppearancePrint.Lines.Options.UseFont = true;
            this.gvData.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.AppearancePrint.Preview.Options.UseFont = true;
            this.gvData.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvData.AppearancePrint.Row.Options.UseFont = true;
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Ma,
            this.Ten,
            this.NhomHang,
            this.DVT,
            this.GiaNhap,
            this.GiaBan,
            this.SoLuong,
            this.GhiChu});
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.Editable = false;
            this.gvData.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvData.OptionsPrint.RtfPageHeader = resources.GetString("gvData.OptionsPrint.RtfPageHeader");
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowFooter = true;
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ID.AppearanceHeader.Options.UseFont = true;
            this.ID.AppearanceHeader.Options.UseTextOptions = true;
            this.ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID.Caption = "ID";
            this.ID.FieldName = "id";
            this.ID.Name = "ID";
            this.ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "id", "{0}")});
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 103;
            // 
            // Ma
            // 
            this.Ma.AppearanceHeader.Options.UseTextOptions = true;
            this.Ma.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Ma.Caption = "Mã";
            this.Ma.FieldName = "ma";
            this.Ma.Name = "Ma";
            this.Ma.Visible = true;
            this.Ma.VisibleIndex = 1;
            this.Ma.Width = 124;
            // 
            // Ten
            // 
            this.Ten.AppearanceHeader.Options.UseTextOptions = true;
            this.Ten.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Ten.Caption = "Tên";
            this.Ten.FieldName = "ten";
            this.Ten.Name = "Ten";
            this.Ten.Visible = true;
            this.Ten.VisibleIndex = 2;
            this.Ten.Width = 150;
            // 
            // NhomHang
            // 
            this.NhomHang.AppearanceHeader.Options.UseTextOptions = true;
            this.NhomHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NhomHang.Caption = "Nhóm hàng";
            this.NhomHang.FieldName = "nhomHang";
            this.NhomHang.Name = "NhomHang";
            this.NhomHang.Visible = true;
            this.NhomHang.VisibleIndex = 3;
            this.NhomHang.Width = 94;
            // 
            // DVT
            // 
            this.DVT.AppearanceCell.Options.UseTextOptions = true;
            this.DVT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DVT.AppearanceHeader.Options.UseTextOptions = true;
            this.DVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DVT.Caption = "ĐVT";
            this.DVT.FieldName = "donvitinh";
            this.DVT.Name = "DVT";
            this.DVT.Visible = true;
            this.DVT.VisibleIndex = 4;
            this.DVT.Width = 94;
            // 
            // GiaNhap
            // 
            this.GiaNhap.AppearanceHeader.Options.UseTextOptions = true;
            this.GiaNhap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GiaNhap.Caption = "Giá nhập";
            this.GiaNhap.DisplayFormat.FormatString = "c0";
            this.GiaNhap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.GiaNhap.FieldName = "giaVon";
            this.GiaNhap.Name = "GiaNhap";
            this.GiaNhap.Visible = true;
            this.GiaNhap.VisibleIndex = 5;
            this.GiaNhap.Width = 113;
            // 
            // GiaBan
            // 
            this.GiaBan.AppearanceHeader.Options.UseTextOptions = true;
            this.GiaBan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GiaBan.Caption = "Giá bán";
            this.GiaBan.DisplayFormat.FormatString = "c0";
            this.GiaBan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.GiaBan.FieldName = "giaLe";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Visible = true;
            this.GiaBan.VisibleIndex = 6;
            this.GiaBan.Width = 106;
            // 
            // SoLuong
            // 
            this.SoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.SoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SoLuong.Caption = "Số lượng";
            this.SoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SoLuong.FieldName = "soluong";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Visible = true;
            this.SoLuong.VisibleIndex = 7;
            this.SoLuong.Width = 83;
            // 
            // GhiChu
            // 
            this.GhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.GhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "ghichu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 8;
            this.GhiChu.Width = 169;
            // 
            // fNhapHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 576);
            this.Controls.Add(this.gcData);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "fNhapHangHoa";
            this.Text = "QL Phiếu nhập Hàng hóa";
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMainMenu;
        private DevExpress.XtraBars.BarButtonItem bbtnThem;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbtnSua;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbtnXoa;
        private DevExpress.XtraBars.BarButtonItem bbtnTaiLai;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraBars.BarButtonItem bbtnIn;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Ten;
        private DevExpress.XtraGrid.Columns.GridColumn Ma;
        private DevExpress.XtraGrid.Columns.GridColumn NhomHang;
        private DevExpress.XtraGrid.Columns.GridColumn DVT;
        private DevExpress.XtraGrid.Columns.GridColumn GiaNhap;
        private DevExpress.XtraGrid.Columns.GridColumn GiaBan;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
    }
}