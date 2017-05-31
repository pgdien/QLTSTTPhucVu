namespace Winform.Views.DanhMuc.NhomHang
{
    partial class fNhomHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNhomHang));
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
            this.barDockControlTop.Size = new System.Drawing.Size(926, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 527);
            this.barDockControlBottom.Size = new System.Drawing.Size(926, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 487);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(926, 40);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 487);
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
            this.gcData.Size = new System.Drawing.Size(926, 487);
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
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Ma,
            this.Ten,
            this.GhiChu});
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.Editable = false;
            this.gvData.OptionsPrint.RtfPageHeader = resources.GetString("gvData.OptionsPrint.RtfPageHeader");
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowFooter = true;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "id";
            this.ID.Name = "ID";
            this.ID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "id", "{0}")});
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 100;
            // 
            // Ma
            // 
            this.Ma.Caption = "Mã";
            this.Ma.FieldName = "ma";
            this.Ma.Name = "Ma";
            this.Ma.Visible = true;
            this.Ma.VisibleIndex = 1;
            this.Ma.Width = 120;
            // 
            // Ten
            // 
            this.Ten.Caption = "Tên";
            this.Ten.FieldName = "ten";
            this.Ten.Name = "Ten";
            this.Ten.Visible = true;
            this.Ten.VisibleIndex = 2;
            this.Ten.Width = 250;
            // 
            // GhiChu
            // 
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "ghichu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 3;
            this.GhiChu.Width = 438;
            // 
            // fNhomHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 527);
            this.Controls.Add(this.gcData);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "fNhomHang";
            this.Text = "Nhóm hàng";
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
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Ma;
        private DevExpress.XtraGrid.Columns.GridColumn Ten;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraBars.BarButtonItem bbtnIn;
    }
}