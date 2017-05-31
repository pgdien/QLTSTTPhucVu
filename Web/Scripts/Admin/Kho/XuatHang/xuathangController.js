admin.controller("xuathangController", ['$scope', '$http', function ($scope, $http) {
    //---VAR---
    //Phiếu xuất hàng
    $scope.xuathangs = [];
    $scope.xuathang = {};
    $scope.xuathangReview = {};
    $scope.selectedXuatHangs = [];
    $scope.filterXuatHang = {};
    var apiXuatHang = "/API/KT_XuatHangAPI";
    //Chi tiết xuất hàng
    $scope.chitietXuatHangs = [];
    $scope.chitietXuatHang = {};
    $scope.chitietXuatHangReviews = [];
    var apiChiTietXuatHang = "/API/KT_ChiTietXuatHangAPI";
    //Mặt hàng
    $scope.mathangs = [];
    $scope.mathang = {};
    $scope.selectedMatHangs = [];
    var apiMatHang = "/API/DM_MatHangAPI";
    //Đơn vị tính
    $scope.donvitinhs = [];
    $scope.donvitinh = {};
    var apiDonViTinh = "/API/DM_DonViTinhAPI";
    //Lý do xuất
    $scope.lydoXuats = [];
    $scope.lydoXuat = {};
    var apiLyDoXuat = "/API/DM_LyDoXuatAPI";

    //---POPUP---
    //Phiếu xuất hàng
    $scope.modifyXuatHang = false;
    $scope.deleteXuatHang = false;
    $scope.reviewXuatHang = false;
    $scope.titlePopupModifyXuatHang = "Thêm Phiếu xuất hàng";
    $scope.popupModifyXuatHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyXuatHang",
        showTitle: true,
        resizeEnabled: true,
        fullScreen: true,
        bindingOptions: {
            title: "titlePopupModifyXuatHang",
            visible: "modifyXuatHang",
        }
    };
    $scope.popupDeleteXuatHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteXuatHang",
        showTitle: false,
        bindingOptions: {
            visible: "deleteXuatHang",
        }
    };
    $scope.popupReviewXuatHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateReviewXuatHang",
        showTitle: true,
        resizeEnabled: true,
        fullScreen: true,
        title: "Xem phiếu Xuất hàng",
        bindingOptions: {
            visible: "reviewXuatHang",
        }
    };
    //Đơn vị tính
    $scope.modifyDonViTinh = false;
    $scope.titlePopupModifyDonViTinh = "Thêm đơn vị tính";
    $scope.popupModifyDonViTinh = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyDonViTinh",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyDonViTinh",
            visible: "modifyDonViTinh",
        }
    };
    //Lý do xuất
    $scope.modifyLyDoXuat = false;
    $scope.titlePopupModifyLyDoXuat = "Thêm lý do xuất";
    $scope.popupModifyLyDoXuat = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyLyDoXuat",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyLyDoXuat",
            visible: "modifyLyDoXuat",
        }
    };


    //---CONTROL CONFIG---
    //Phiếu xuất hàng
    $scope.controlXuatHang = {
        //TextBox
        nguoiXuat: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "xuathang.nguoiXuat"
            }
        },
        //SelectBox
        lydoXuat: {
            displayExpr: "ten",
            valueExpr: "id",
            searchEnabled: true,
            noDataText: "Không có dữ liệu",
            placeholder: "Chọn ...",
            bindingOptions: {
                items: "lydoXuats",
                value: "xuathang.idLyDoXuat"
            }
        },
        //DateBox
        thoigian: {
            type: "date",
            displayFormat: "dd/MM/yyyy",
            bindingOptions: {
                value: "xuathang.thoigian"
            }
        },
        //TextArea
        ghichu: {
            height: 40,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "xuathang.ghichu"
            }
        },
        //Button
        addLyDoXuat: {
            icon: "plus",
            onClick: function (e) {
                $scope.AddLyDoXuat();
            }
        }
    }
    $scope.controlXuatHangReview = {
        //TextBox
        nguoiXuat: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "xuathangReview.nguoiXuat"
            }
        },
        //SelectBox
        lydoXuat: {
            displayExpr: "ten",
            valueExpr: "id",
            searchEnabled: true,
            noDataText: "Không có dữ liệu",
            placeholder: "Chọn ...",
            readOnly: true,
            bindingOptions: {
                items: "lydoXuats",
                value: "xuathangReview.idLyDoXuat"
            }
        },
        //DateBox
        thoigian: {
            type: "date",
            displayFormat: "dd/MM/yyyy",
            readOnly: true,
            bindingOptions: {
                value: "xuathangReview.thoigian"
            }
        },
        //TextArea
        ghichu: {
            height: 40,
            valueChangeEvent: "keyup",
            readOnly: true,
            bindingOptions: {
                value: "xuathangReview.ghichu"
            }
        }
    }
    //Đơn vị tính
    $scope.controlDonViTinh = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "donvitinh.ten"
            }
        }
    }
    //Lý do xuất
    $scope.controlLyDoXuat = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "lydoXuat.ten"
            }
        }
    }

    //---LIST---
    //Phiếu xuất hàng
    $scope.gridXuatHangs = {
        bindingOptions: {
            dataSource: 'xuathangs',
            'columns[2].lookup.dataSource': 'lydoXuats',
        },
        allowColumnResizing: true,
        columnAutoWidth: true,
        columnChooser: {
            emptyPanelText: "Kéo và thả cột muốn ẩn vào đây",
            enabled: true,
            mode: "select",
            title: "Lựa chọn cột"
        },
        columnFixing: {
            enabled: true,
            texts: {
                fix: "Cố định cột",
                leftPosition: "Bên trái",
                rightPosition: "Bên phải",
                unfix: "Hủy cố định"
            }
        },
        columns: [
            {//0
                alignment: "left",
                allowEditing: false,
                caption: "ID",
                dataField: "id",
            },
            {//1
                alignment: "left",
                caption: "Thời gian",
                dataField: "thoigian",
                dataType: "date",
                format: "dd/MM/yyyy",
                customizeText: function (cellInfo) {
                    return cellInfo.valueText;
                },
            },
            {//2
                caption: "Lý do xuất",
                dataField: "idLyDoXuat",
                lookup: {
                    displayExpr: 'ten',
                    valueExpr: 'id'
                },
            },
            {//3
                alignment: "left",
                caption: "Người xuất",
                dataField: "nguoiXuat",
                dataType: "string",
            },
            {//4
                alignment: "right",
                caption: "Tổng tiền",
                dataField: "tongTien",
                format: {
                    type: "fixedPoint",
                    precision: 0
                }
            },
            {//5
                alignment: "left",
                caption: "Ghi chú",
                dataField: "ghichu",
                dataType: "string"
            },
        ],
        editing: {
            mode: "cell",
            allowAdding: false,
            allowDeleting: false,
            allowUpdating: false,
            texts: {
                addRow: "Thêm",
                cancelAllChanges: "Không thay đổi",
                cancelRowChanges: "Hủy",
                confirmDeleteMessage: "Bạn có chắc chắn muốn xóa?",
                deleteRow: "Xóa",
                editRow: "Sửa",
                saveAllChanges: "Lưu thay đổi",
                saveRowChanges: "Lưu",
                undeleteRow: "Không xóa",
                validationCancelChanges: "Hủy thay đổi"
            }
        },
        export: {
            allowExportSelectedData: true,
            enabled: true,
            excelFilterEnabled: true,
            excelWrapTextEnabled: true,
            fileName: "Danh sách Phiếu xuất hàng",
            texts: {
                exportAll: "Xuất toàn bộ Dữ liệu",
                exportSelectedRows: "Xuất dữ liệu đang chọn",
                exportTo: "Trích xuất"
            }
        },
        filterRow: {
            applyFilterText: "Áp dụng bộ lọc",
            betweenEndText: "Kết thúc",
            betweenStartText: "Bắt đầu",
            resetOperationText: "Thiết lập lại",
            showAllText: "(Tất cả)",
            visible: true
        },
        grouping: {
            contextMenuEnabled: true,
            expandMode: "rowClick",
            texts: {
                groupByThisColumn: "Nhóm theo Cột này",
                groupContinuedMessage: "Tiếp tục từ trang trước",
                groupContinuesMessage: "Tiếp tục trên các trang tiếp theo",
                ungroup: "Bỏ nhóm",
                ungroupAll: "Bỏ tất cả nhóm"
            }
        },
        groupPanel: {
            emptyPanelText: "Kéo một cột vào đây để nhóm theo cột đó",
            visible: false
        },
        headerFilter: {
            texts: {
                cancel: "Hủy",
                emptyValue: "(Trống)",
                ok: "Đồng ý"
            },
            visible: true
        },
        hoverStateEnabled: true,
        loadPanel: {
            enabled: true,
            text: "Đang tải ..."
        },
        noDataText: "Không có dữ liệu",
        pager: {
            infoText: "Trang {0} của {1}",
            showInfo: true,
            showNavigationButtons: true,
            showPageSizeSelector: true,
            visible: true
        },
        paging: {
            enabled: true,
            pageIndex: 0,
            pageSize: 50
        },
        remoteOperations: {
            grouping: false,
            summary: false
        },
        rowAlternationEnabled: false,
        scrolling: {
            preloadEnabled: true
        },
        searchPanel: {
            placeholder: "Tìm kiếm ..."
        },
        selection: {
            mode: "multiple",
            showCheckBoxesMode: "onClick"
        },
        showBorders: true,
        showRowLines: true,
        sorting: {
            ascendingText: "Sắp xếp Tăng dần",
            clearText: "Xóa Sắp xếp",
            descendingText: "Sắp xếp Giảm dần"
        },
        summary: {
            texts: {
                count: "{0}",
                sum: "{0}"
            },
            groupItems: [
                {
                    column: "id",
                    summaryType: "count"
                },
            ],
            totalItems: [
                {
                    column: "id",
                    summaryType: "count"
                },
                {
                    column: "tongTien",
                    summaryType: "sum",
                    valueFormat: 'fixedPoint'
                }
            ]
        },
        wordWrapEnabled: false,
        //METHOD
        //Toolbar
        onToolbarPreparing: function (e) {
            var dataGrid = e.component;

            e.toolbarOptions.items.unshift(
                {//Từ ngày
                    location: "before",
                    widget: "dxDateBox",
                    options: {
                        bindingOptions: {
                            value: "filterXuatHang.tuNgay"
                        },
                        type: "date",
                        displayFormat: "dd/MM/yyyy",
                        hint: "Từ ngày",
                        placeholder: "Từ ngày",
                        max: new Date()
                    }
                },
                {//Đến ngày
                    location: "before",
                    widget: "dxDateBox",
                    options: {
                        bindingOptions: {
                            value: "filterXuatHang.denNgay",
                            min: "filterXuatHang.tuNgay"
                        },
                        type: "date",
                        displayFormat: "dd/MM/yyyy",
                        hint: "Đến ngày",
                        placeholder: "Đến ngày",
                        max: new Date()
                    }
                },
                {//Lọc
                    location: "before",
                    widget: "dxButton",
                    options: {
                        hint: "Lọc",
                        icon: "search",
                        type: "primary",
                        onClick: function () {
                            FilterXuatHang();
                        }
                    }
                },
                {//Thêm
                    location: "after",
                    widget: "dxButton",
                    options: {
                        hint: "Thêm",
                        icon: "add",
                        type: "success",
                        onClick: function () {
                            $scope.AddXuatHang();
                        }
                    }
                },
                {//Review
                    location: "after",
                    widget: "dxButton",
                    options: {
                        hint: "Xem",
                        icon: "search",
                        type: "default",
                        onClick: function () {
                            $scope.ReviewXuatHang();
                        }
                    }
                },
                {//Xóa
                    location: "after",
                    widget: "dxButton",
                    options: {
                        hint: "Xóa",
                        icon: "trash",
                        type: "danger",
                        onClick: function () {
                            $scope.DeleteXuatHang();
                        }
                    }
                },
                {//Load lại
                    location: "after",
                    widget: "dxButton",
                    options: {
                        hint: "Load lại Dữ liệu",
                        icon: "refresh",
                        onClick: function () {
                            FilterXuatHang();
                        }
                    }
                }
           )
        },
        //DoubleClick Row
        onRowClick: function (e) {
            var component = e.component;

            if (!component.clickCount)
                component.clickCount = 1;
            else
                component.clickCount = component.clickCount + 1;

            if (component.clickCount == 1) {
                component.lastClickTime = new Date();
                setTimeout(function () { component.lastClickTime = 0; component.clickCount = 0; }, 350);
            }
            else if (component.clickCount == 2) {
                if (((new Date()) - component.lastClickTime) < 300) {
                    $scope.xuathangReview = angular.copy(e.data);
                    $scope.ReviewXuatHang();
                }

                // Reset your click info
                component.clickCount = 0;
                component.lastClickTime = 0;
            }
        },
        //Select Row
        onSelectionChanged: function (e) {
            $scope.selectedXuatHangs = angular.copy(e.selectedRowsData);
        }
    };
    //Chi tiết xuất hàng
    $scope.gridChiTietXuatHangs = {
        bindingOptions: {
            dataSource: 'chitietXuatHangs',
            'columns[0].lookup.dataSource': 'mathangs',
            'columns[1].lookup.dataSource': 'mathangs',
        },
        allowColumnResizing: true,
        columnAutoWidth: true,
        columnChooser: {
            emptyPanelText: "Kéo và thả cột muốn ẩn vào đây",
            enabled: false,
            mode: "select",
            title: "Lựa chọn cột"
        },
        columnFixing: {
            enabled: true,
            texts: {
                fix: "Cố định cột",
                leftPosition: "Bên trái",
                rightPosition: "Bên phải",
                unfix: "Hủy cố định"
            }
        },
        columns: [
            {//0
                caption: "Mặt hàng",
                dataField: "idMatHang",
                lookup: {
                    displayExpr: 'ten',
                    valueExpr: 'id'
                },
                allowEditing: false
            },
            {//1
                caption: "ĐVT",
                dataField: "idMatHang",
                lookup: {
                    displayExpr: 'donvitinh',
                    valueExpr: 'id'
                },
                allowEditing: false
            },
            {//2
                alignment: "right",
                caption: "Đơn giá",
                dataField: "dongia",
                format: {
                    type: "fixedPoint",
                    precision: 0
                }
            },
            {//3
                alignment: "right",
                caption: "SL",
                dataField: "soluong",
                format: {
                    type: "fixedPoint",
                    precision: 3
                }
            },
            {//4
                alignment: "right",
                caption: "Thành tiền",
                dataField: "thanhtien",
                format: {
                    type: "fixedPoint",
                    precision: 0
                },
                allowEditing: false
            },
        ],
        editing: {
            mode: "cell",
            allowAdding: false,
            allowDeleting: true,
            allowUpdating: true,
            texts: {
                addRow: "Thêm",
                cancelAllChanges: "Không thay đổi",
                cancelRowChanges: "Hủy",
                confirmDeleteMessage: "Bạn có chắc chắn muốn xóa?",
                deleteRow: "Xóa",
                editRow: "Sửa",
                saveAllChanges: "Lưu thay đổi",
                saveRowChanges: "Lưu",
                undeleteRow: "Không xóa",
                validationCancelChanges: "Hủy thay đổi"
            }
        },
        export: {
            allowExportSelectedData: true,
            enabled: false,
            excelFilterEnabled: true,
            excelWrapTextEnabled: true,
            fileName: "Danh sách Hàng hóa",
            texts: {
                exportAll: "Xuất toàn bộ Dữ liệu",
                exportSelectedRows: "Xuất dữ liệu đang chọn",
                exportTo: "Trích xuất"
            }
        },
        filterRow: {
            applyFilterText: "Áp dụng bộ lọc",
            betweenEndText: "Kết thúc",
            betweenStartText: "Bắt đầu",
            resetOperationText: "Thiết lập lại",
            showAllText: "(Tất cả)",
            visible: false
        },
        grouping: {
            contextMenuEnabled: false,
            expandMode: "rowClick",
            texts: {
                groupByThisColumn: "Nhóm theo Cột này",
                groupContinuedMessage: "Tiếp tục từ trang trước",
                groupContinuesMessage: "Tiếp tục trên các trang tiếp theo",
                ungroup: "Bỏ nhóm",
                ungroupAll: "Bỏ tất cả nhóm"
            }
        },
        groupPanel: {
            emptyPanelText: "Kéo một cột vào đây để nhóm theo cột đó",
            visible: false
        },
        headerFilter: {
            texts: {
                cancel: "Hủy",
                emptyValue: "(Trống)",
                ok: "Đồng ý"
            },
            visible: false
        },
        hoverStateEnabled: false,
        loadPanel: {
            enabled: true,
            text: "Đang tải ..."
        },
        noDataText: "Không có dữ liệu",
        pager: {
            infoText: "Trang {0} của {1}",
            showInfo: true,
            showNavigationButtons: true,
            showPageSizeSelector: true,
            visible: true
        },
        paging: {
            enabled: true,
            pageIndex: 0,
            pageSize: 50
        },
        remoteOperations: {
            grouping: false,
            summary: false
        },
        rowAlternationEnabled: false,
        scrolling: {
            preloadEnabled: true
        },
        searchPanel: {
            placeholder: "Tìm kiếm ..."
        },
        selection: {
            mode: "multiple",
            showCheckBoxesMode: "none"
        },
        showBorders: true,
        showRowLines: true,
        sorting: {
            ascendingText: "Sắp xếp Tăng dần",
            clearText: "Xóa Sắp xếp",
            descendingText: "Sắp xếp Giảm dần"
        },
        summary: {
            texts: {
                count: "{0}",
                sum: "{0}"
            },
            groupItems: [
                {
                    column: "id",
                    summaryType: "count"
                }
            ],
            totalItems: [
                {
                    column: "id",
                    summaryType: "count"
                }
            ]
        },
        wordWrapEnabled: false,
        //Event
        onRowInserted: function (e) {
            TinhTien();
        },
        onRowRemoved: function (e) {
            TinhTien();
        },
        onRowUpdated: function (e) {
            TinhTien();
        }
    };
    $scope.gridChiTietXuatHangReviews = {
        bindingOptions: {
            dataSource: 'chitietXuatHangReviews',
            'columns[0].lookup.dataSource': 'mathangs',
            'columns[1].lookup.dataSource': 'mathangs',
        },
        allowColumnResizing: true,
        columnAutoWidth: true,
        columnChooser: {
            emptyPanelText: "Kéo và thả cột muốn ẩn vào đây",
            enabled: false,
            mode: "select",
            title: "Lựa chọn cột"
        },
        columnFixing: {
            enabled: true,
            texts: {
                fix: "Cố định cột",
                leftPosition: "Bên trái",
                rightPosition: "Bên phải",
                unfix: "Hủy cố định"
            }
        },
        columns: [
            {//0
                caption: "Mặt hàng",
                dataField: "idMatHang",
                lookup: {
                    displayExpr: 'ten',
                    valueExpr: 'id'
                },
                allowEditing: false
            },
            {//1
                caption: "ĐVT",
                dataField: "idMatHang",
                lookup: {
                    displayExpr: 'donvitinh',
                    valueExpr: 'id'
                },
                allowEditing: false
            },
            {//2
                alignment: "right",
                caption: "Đơn giá",
                dataField: "dongia",
                format: {
                    type: "fixedPoint",
                    precision: 0
                }
            },
            {//3
                alignment: "right",
                caption: "SL",
                dataField: "soluong",
                format: {
                    type: "fixedPoint",
                    precision: 3
                }
            },
            {//4
                alignment: "right",
                caption: "Thành tiền",
                dataField: "thanhtien",
                format: {
                    type: "fixedPoint",
                    precision: 0
                },
                allowEditing: false
            },
        ],
        editing: {
            mode: "cell",
            allowAdding: false,
            allowDeleting: false,
            allowUpdating: false,
            texts: {
                addRow: "Thêm",
                cancelAllChanges: "Không thay đổi",
                cancelRowChanges: "Hủy",
                confirmDeleteMessage: "Bạn có chắc chắn muốn xóa?",
                deleteRow: "Xóa",
                editRow: "Sửa",
                saveAllChanges: "Lưu thay đổi",
                saveRowChanges: "Lưu",
                undeleteRow: "Không xóa",
                validationCancelChanges: "Hủy thay đổi"
            }
        },
        export: {
            allowExportSelectedData: true,
            enabled: false,
            excelFilterEnabled: true,
            excelWrapTextEnabled: true,
            fileName: "Danh sách Thực đơn",
            texts: {
                exportAll: "Xuất toàn bộ Dữ liệu",
                exportSelectedRows: "Xuất dữ liệu đang chọn",
                exportTo: "Trích xuất"
            }
        },
        filterRow: {
            applyFilterText: "Áp dụng bộ lọc",
            betweenEndText: "Kết thúc",
            betweenStartText: "Bắt đầu",
            resetOperationText: "Thiết lập lại",
            showAllText: "(Tất cả)",
            visible: false
        },
        grouping: {
            contextMenuEnabled: false,
            expandMode: "rowClick",
            texts: {
                groupByThisColumn: "Nhóm theo Cột này",
                groupContinuedMessage: "Tiếp tục từ trang trước",
                groupContinuesMessage: "Tiếp tục trên các trang tiếp theo",
                ungroup: "Bỏ nhóm",
                ungroupAll: "Bỏ tất cả nhóm"
            }
        },
        groupPanel: {
            emptyPanelText: "Kéo một cột vào đây để nhóm theo cột đó",
            visible: false
        },
        headerFilter: {
            texts: {
                cancel: "Hủy",
                emptyValue: "(Trống)",
                ok: "Đồng ý"
            },
            visible: false
        },
        hoverStateEnabled: false,
        loadPanel: {
            enabled: true,
            text: "Đang tải ..."
        },
        noDataText: "Không có dữ liệu",
        pager: {
            infoText: "Trang {0} của {1}",
            showInfo: true,
            showNavigationButtons: true,
            showPageSizeSelector: true,
            visible: true
        },
        paging: {
            enabled: true,
            pageIndex: 0,
            pageSize: 50
        },
        remoteOperations: {
            grouping: false,
            summary: false
        },
        rowAlternationEnabled: false,
        scrolling: {
            preloadEnabled: true
        },
        searchPanel: {
            placeholder: "Tìm kiếm ..."
        },
        selection: {
            mode: "multiple",
            showCheckBoxesMode: "none"
        },
        showBorders: true,
        showRowLines: true,
        sorting: {
            ascendingText: "Sắp xếp Tăng dần",
            clearText: "Xóa Sắp xếp",
            descendingText: "Sắp xếp Giảm dần"
        },
        summary: {
            texts: {
                count: "{0}",
                sum: "{0}"
            },
            groupItems: [
                {
                    column: "id",
                    summaryType: "count"
                }
            ],
            totalItems: [
                {
                    column: "id",
                    summaryType: "count"
                }
            ]
        },
        wordWrapEnabled: false,
        //Event
        onRowInserted: function (e) {
            TinhTien();
        },
        onRowRemoved: function (e) {
            TinhTien();
        },
        onRowUpdated: function (e) {
            TinhTien();
        }
    };
    //Mặt hàng
    $scope.lookupMatHangs = {
        bindingOptions: {
            items: "mathangs",
            value: "mathang.id"
        },
        cancelButtonText: "Đóng",
        clearButtonText: "Xóa",
        displayExpr: "ten",
        nextButtonText: "Thêm",
        noDataText: "Không có dữ liệu",
        valueExpr: "id",
        title: "Chọn mặt hàng",
        pageLoadingText: "Đang tải...",
        placeholder: "Chọn mặt hàng",
        searchPlaceholder: "Tìm kiếm",
        onItemClick: function (e) {
            ChooseMatHang(e.itemData);
        },
        onClosed: function () {
            var lookup = $("#lookupMatHangs").dxLookup("instance");
            lookup.reset();
        }
    };

    //---CONTEXTMENU---
    var itemContextMenus = [
        { value: 'add', text: ' Thêm', icon: 'fa fa-plus' },
        { value: 'review', text: ' Xem', icon: 'fa fa-search' },
        { value: 'delete', text: ' Xóa', icon: 'fa fa-times' }
    ];
    //Phiếu xuất hàng
    $scope.contextMenuXuatHang = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#xuathang',
        itemTemplate: function (itemData, itemIndex, itemElement) {
            var template = $('<div></div>');
            if (itemData.icon) {
                template.append('<span class="' + itemData.icon + '"><span>');
            }
            template.append(itemData.text);
            return template;
        },
        onItemClick: function (e) {
            if (!e.itemData.items) {
                switch (e.itemData.value) {
                    case "add":
                        $scope.AddXuatHang();
                        break;
                    case "review":
                        $scope.ReviewXuatHang();
                        break;
                    case "delete":
                        $scope.DeleteXuatHang();
                        break;
                }

            }
        }
    };

    Init();

    //---FUNCTION---
    function Init() {
        GetXuatHangThisMonth();
        GetAllDonViTinh();
        GetAllLyDoXuat();
        GetAllMatHang();
    }

    //Phiếu xuất hàng
    function GetXuatHangThisMonth() {
        var now = new Date();
        $scope.filterXuatHang.denNgay = now;
        $scope.filterXuatHang.tuNgay = new Date(now.getFullYear(), now.getMonth(), 1);
        FilterXuatHang();
    }
    $scope.AddXuatHang = function () {
        $scope.xuathang = {
            thoigian: new Date(),
            idLyDoXuat: 1,
            tongTien: 0
        };
        $scope.chitietXuatHangs = [];
        $scope.chitietXuatHang = {};

        $scope.titlePopupModifyXuatHang = "Thêm Phiếu xuất hàng";
        $scope.modifyXuatHang = true;
    }
    function ChooseMatHang(mathang) {
        var existed = false;
        angular.forEach($scope.chitietXuatHangs, function (value, index) {
            if (value.idMatHang == mathang.id) {
                existed = true;
                toastr.warning("Đã tồn tại", "Mặt hàng");
            }
        });

        if (existed == false) {
            var chitietXuatHang = {
                idMatHang: mathang.id,
                idXuatHang: $scope.xuathang.id,
                soluong: 1,
                dongia: mathang.dongia
            }
            $scope.chitietXuatHangs.push(chitietXuatHang);
        }

        TinhTien();
    }
    $scope.SaveXuatHang = function (e) {
        //Thêm
        //Lưu phiếu xuất hàng
        $http.post(apiXuatHang, $scope.xuathang)
            .then(function (response) {
                if (response.status == 201) {
                    $scope.xuathang = angular.copy(response.data);
                    //Lưu chi tiết xuất hàng
                    angular.forEach($scope.chitietXuatHangs, function (value, index) {
                        value.idXuatHang = $scope.xuathang.id;
                        $http.post(apiChiTietXuatHang, value)
                            .then(function (response) {
                                //Tăng số lượng mặt hàng trong kho
                                $http.get('/MatHang/XuatHang/' + response.data.id)
                                    .then(function (response) { });
                            });
                    });
                    $scope.modifyXuatHang = false;
                    toastr.success("Thành công", "Lưu");
                    FilterXuatHang();
                } else {
                    toastr.error("Thất bại", "Lưu");
                }
            })
    };
    $scope.CancelSaveXuatHang = function () {
        $scope.xuathang = {};
        $scope.chitietXuatHangs = [];
        $scope.chitietXuatHang = {};
        $scope.modifyXuatHang = false;
    }
    $scope.DeleteXuatHang = function () {
        if ($scope.selectedXuatHangs.length == 0) {
            toastr.error("Chọn dòng để xóa");
        } else {
            $scope.deleteXuatHang = true;
        }
    }
    $scope.ConfirmDeleteXuatHang = function () {
        angular.forEach($scope.selectedXuatHangs, function (value, index) {
            $http.delete("/XuatHang/Delete/" + value.id)
                .then(function (response) {
                    if (response.status == 200 && response.data == 1) {
                        angular.forEach($scope.xuathangs, function (valueXH, indexXH) {
                            if (value.id === valueXH.id) {
                                $scope.xuathangs.splice(indexXH, 1);
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Xóa");
                    }
                })
        });
        toastr.success("Thành công", "Xóa");
        $scope.deleteXuatHang = false;
    };
    $scope.CancelDeleteXuatHang = function () {
        $scope.deleteXuatHang = false;
    };


    function TinhTien() {
        var tongTien = 0;
        angular.forEach($scope.chitietXuatHangs, function (value, index) {
            $scope.chitietXuatHangs[index].thanhtien = parseFloat(value.dongia) * parseFloat(value.soluong);
            tongTien = parseFloat(tongTien) + parseFloat($scope.chitietXuatHangs[index].thanhtien);
        });
        $scope.xuathang.tongTien = tongTien;
    }
    function FilterXuatHang() {
        if ($scope.filterXuatHang.tuNgay == null || $scope.filterXuatHang.denNgay == null) {
            toastr.warning("Vui lòng chọn Từ ngày - Đến ngày")
        } else {
            var tuNgay = $scope.filterXuatHang.tuNgay;
            var denNgay = $scope.filterXuatHang.denNgay;
            $http.get(apiXuatHang + '?tuNgayDay=' + tuNgay.getDate() + '&&tuNgayMonth=' + (tuNgay.getMonth() + 1) + '&&tuNgayYear=' + tuNgay.getFullYear() + '&&denNgayDay=' + denNgay.getDate() + '&&denNgayMonth=' + (denNgay.getMonth() + 1) + '&&denNgayYear=' + denNgay.getFullYear())
                .then(function (response) {
                    if (response.status == 200) {
                        $scope.xuathangs = response.data;
                    }
                });
        }
    }
    
    $scope.ReviewXuatHang = function () {
        if ($scope.selectedXuatHangs.length == 0) {
            toastr.error("Chọn 1 dòng để xem");
        } else {
            $scope.xuathangReview = angular.copy($scope.selectedXuatHangs[0]);
            GetChiTietByXuatHang($scope.xuathangReview.id);
            $scope.reviewXuatHang = true;
        }
    }
    function GetChiTietByXuatHang(idXuatHang) {
        if (idXuatHang != null) {
            $http.get(apiChiTietXuatHang + "?att=idXuatHang&&value=" + idXuatHang)
                .then(function (response) {
                    if (response.status == 200) {
                        $scope.chitietXuatHangReviews = angular.copy(response.data);
                    }
                })
        }
    }


    //Đơn vị tính
    function GetAllDonViTinh() {
        $http.get(apiDonViTinh)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.donvitinhs = response.data;
                }
            })
    }
    $scope.AddDonViTinh = function () {
        $scope.donvitinh = {};
        $scope.titlePopupModifyDonViTinh = "Thêm đơn vị tính";
        $scope.modifyDonViTinh = true;
    }
    $scope.SaveDonViTinh = function (e) {
        //Thêm
        if (!angular.isDefined($scope.donvitinh.id)) {
            $http.post(apiDonViTinh, $scope.donvitinh)
                .then(function (response) {
                    if (response.status == 201) {
                        GetAllDonViTinh();
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyDonViTinh = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiDonViTinh + "/" + $scope.donvitinh.id, $scope.donvitinh)
                .then(function (response) {
                    if (response.status == 204) {
                        GetAllDonViTinh();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyDonViTinh = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveDonViTinh = function () {
        $scope.modifyDonViTinh = false;
    }

    //Mặt hàng
    function GetAllMatHang() {
        $http.get(apiMatHang)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.mathangs = response.data;
                }
            })
    }

    //Lý do xuất
    function GetAllLyDoXuat() {
        $http.get(apiLyDoXuat)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.lydoXuats = response.data;
                }
            })
    }
    $scope.AddLyDoXuat = function () {
        $scope.lydoXuat = {};
        $scope.titlePopupModifyLyDoXuat = "Thêm lý do xuất";
        $scope.modifyLyDoXuat = true;
    }
    $scope.SaveLyDoXuat = function (e) {
        //Thêm
        if (!angular.isDefined($scope.lydoXuat.id)) {
            $http.post(apiLyDoXuat, $scope.lydoXuat)
                .then(function (response) {
                    if (response.status == 201) {
                        GetAllLyDoXuat();
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyLyDoXuat = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiLyDoXuat + "/" + $scope.lydoXuat.id, $scope.lydoXuat)
                .then(function (response) {
                    if (response.status == 204) {
                        GetAllLyDoXuat();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyLyDoXuat = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveLyDoXuat = function () {
        $scope.modifyLyDoXuat = false;
    }


}]);