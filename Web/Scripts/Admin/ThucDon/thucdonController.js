admin.controller("thucdonController", ['$scope', '$http', function ($scope, $http) {
    //---VAR---
    //Nhóm thuốc đơn
    $scope.nhomThucDonTemplates = [];
    $scope.nhomThucDons = [];
    $scope.nhomThucDon = {};
    $scope.filterNhomThucDon = "";
    $scope.selectedNhomThucDon = {};
    var apiNhomThucDon = "/API/DM_NhomThucDonAPI";

    //Thực đơn
    $scope.thucdons = [];
    $scope.thucdon = {};
    $scope.selectedThucDons = [];
    var apiThucDon = "/API/DM_ThucDonAPI";

    //Mặt hàng
    $scope.mathangs = [];
    $scope.mathang = {};
    $scope.selectedMatHangs = [];
    var apiMatHang = "/API/DM_MatHangAPI";

    //Đơn vị tính
    $scope.donvitinhs = [];
    $scope.donvitinh = {};
    var apiDonViTinh = "/API/DM_DonViTinhAPI";

    //Định lượng
    $scope.dinhluongs = [];
    $scope.dinhluong = {};
    $scope.dinhluongEdits = [];
    var apiDinhLuong = "/API/KT_DinhLuongAPI";

    //---POPUP---
    //Nhóm thuốc đơn
    $scope.modifyNhomThucDon = false;
    $scope.deleteNhomThucDon = false;
    $scope.titlePopupModifyNhomThucDon = "Thêm nhóm thuốc đơn";
    $scope.popupModifyNhomThucDon = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyNhomThucDon",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyNhomThucDon",
            visible: "modifyNhomThucDon",
        }
    };
    $scope.popupDeleteNhomThucDon = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteNhomThucDon",
        showTitle: false,
        bindingOptions: {
            visible: "deleteNhomThucDon",
        }
    };
    //Thực đơn
    $scope.modifyThucDon = false;
    $scope.deleteThucDon = false;
    $scope.titlePopupModifyThucDon = "Thêm thuốc đơn";
    $scope.popupModifyThucDon = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyThucDon",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyThucDon",
            visible: "modifyThucDon",
        }
    };
    $scope.popupDeleteThucDon = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteThucDon",
        showTitle: false,
        bindingOptions: {
            visible: "deleteThucDon",
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
    //Định lượng
    $scope.modifyDinhLuong = false;
    $scope.titlePopupModifyDinhLuong = "Định lượng";
    $scope.popupModifyDinhLuong = {
        width: "600",
        height: "auto",
        contentTemplate: "templateModifyDinhLuong",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyDinhLuong ",
            visible: "modifyDinhLuong",
        }
    };

    //---CONTROL CONFIG---
    //Nhóm thuốc đơn
    $scope.controlNhomThucDon = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhomThucDon.ten"
            }
        },
        filter: {
            valueChangeEvent: "keyup",
            placeholder: "Tìm kiếm",
            mode: "search",
            bindingOptions: {
                value: "filterNhomThucDon"
            },
            onEnterKey: function (e) {
                FilterNhomThucDon($scope.filterNhomThucDon);
            }
        }
    }
    //Thực đơn
    $scope.controlThucDon = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "thucdon.ten"
            }
        },
        //SelectBox
        nhomThucDon: {
            displayExpr: "ten",
            valueExpr: "id",
            searchEnabled: true,
            noDataText: "Không có dữ liệu",
            placeholder: "Chọn ...",
            bindingOptions: {
                items: "nhomThucDonTemplates",
                value: "thucdon.idNhomThucDon"
            }
        },
        donvitinh: {
            displayExpr: "ten",
            valueExpr: "ten",
            searchEnabled: true,
            noDataText: "Không có dữ liệu",
            placeholder: "Chọn ...",
            bindingOptions: {
                items: "donvitinhs",
                value: "thucdon.donvitinh"
            }
        },
        //TextArea
        mavach: {
            height: 100,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "thucdon.mavach",
            }
        },
        huongdan: {
            height: 100,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "thucdon.huongdan",
            }
        },
        //Button
        addNhomThucDon: {
            icon: "plus",
            onClick: function (e) {
                $scope.AddNhomThucDon();
            }
        },
        addDonViTinh: {
            icon: "plus",
            onClick: function (e) {
                $scope.AddDonViTinh();
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


    //---LIST---
    //Nhóm thuốc đơn
    $scope.listNhomThucDons = {
        bindingOptions: {
            dataSource: 'nhomThucDons',
        },
        height: "490",
        nextButtonText: "Xem thêm",
        onItemClick: function (e) {
            $scope.selectedNhomThucDon = angular.copy(e.itemData);
            $scope.thucdon = {};
            $scope.dinhluongs = [];
            GetThucDon();
        },
        onItemContextMenu: function (e) {
            $scope.nhomThucDon = angular.copy(e.itemData);
        }
    };
    //Thực đơn
    $scope.gridThucDons = {
        bindingOptions: {
            dataSource: 'thucdons'
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
                dataField: "id"
            },
            {//1
                alignment: "left",
                caption: "Tên thuốc đơn",
                dataField: "ten",
                dataType: "string"
            },
            {//2
                alignment: "left",
                caption: "ĐVT",
                dataField: "donvitinh",
                dataType: "string"
            },
            {//3
                alignment: "right",
                caption: "Giá nhập",
                dataField: "dongia",
                format: {
                    type: "fixedPoint",
                    precision: 0
                }
            }
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
            fileName: "Danh sách đơn thuốc",
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
            emptyPanelText: "THUỐC ĐƠN",
            visible: true
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
        //METHOD
        //Toolbar
        onToolbarPreparing: function (e) {
            var dataGrid = e.component;

            e.toolbarOptions.items.unshift(
                {//Thêm
                    location: "after",
                    widget: "dxButton",
                    options: {
                        hint: "Thêm",
                        icon: "add",
                        type: "success",
                        onClick: function () {
                            $scope.AddThucDon();
                        }
                    }
                },
                {//Sửa
                    location: "after",
                    widget: "dxButton",
                    options: {
                        hint: "Sửa",
                        icon: "edit",
                        type: "default",
                        onClick: function () {
                            $scope.EditThucDon();
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
                            $scope.DeleteThucDon();
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
                            GetThucDon();
                            GetAllNhomThucDon();
                            GetAllMatHang();
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
                    $scope.thucdon = angular.copy(e.data);
                    $scope.EditThucDon();
                }

                // Reset your click info
                component.clickCount = 0;
                component.lastClickTime = 0;
            }
        },
        //Select Row
        onSelectionChanged: function (e) {
            $scope.selectedThucDons = angular.copy(e.selectedRowsData);
            GetDinhLuong();
        }
    };
    //Định lượng
    $scope.gridDinhLuongs = {
        bindingOptions: {
            dataSource: 'dinhluongs',
            'columns[0].lookup.dataSource': 'mathangs',
            'columns[2].lookup.dataSource': 'mathangs',
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
                }
            },
            {//1
                alignment: "right",
                caption: "SL",
                dataField: "soluong",
                format: {
                    type: "fixedPoint",
                    precision: 3
                }
            },
            {//2
                caption: "ĐVT",
                dataField: "idMatHang",
                lookup: {
                    displayExpr: 'donvitinh',
                    valueExpr: 'id'
                }
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
            emptyPanelText: "ĐỊNH LƯỢNG",
            visible: true
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
        //METHOD
        //Toolbar
        onToolbarPreparing: function (e) {
            var dataGrid = e.component;

            e.toolbarOptions.items.unshift(
                {//Sửa
                    location: "after",
                    widget: "dxButton",
                    options: {
                        hint: "Định lượng",
                        icon: "food",
                        type: "default",
                        onClick: function () {
                            $scope.DinhLuong();
                        }
                    }
                }
           )
        },
    };
    $scope.gridDinhLuongEdits = {
        bindingOptions: {
            dataSource: 'dinhluongEdits',
            'columns[0].lookup.dataSource': 'mathangs',
            'columns[2].lookup.dataSource': 'mathangs',
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
                alignment: "right",
                caption: "SL",
                dataField: "soluong",
                format: {
                    type: "fixedPoint",
                    precision: 3
                }
            },
            {//2
                caption: "ĐVT",
                dataField: "idMatHang",
                lookup: {
                    displayExpr: 'donvitinh',
                    valueExpr: 'id'
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
            ChooseMatHang(e.itemData.id);
        },
        onClosed: function () {
            var lookup = $("#lookupMatHangs").dxLookup("instance");
            lookup.reset();
        }
    };

    //---CONTEXTMENU---
    var itemContextMenus = [
        { value: 'add', text: ' Thêm', icon: 'fa fa-plus' },
        { value: 'edit', text: ' Sửa', icon: 'fa fa-pencil' },
        { value: 'delete', text: ' Xóa', icon: 'fa fa-times' }
    ];
    //Nhóm thuốc đơn
    $scope.contextMenuNhomThucDon = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#nhomThucDon',
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
                        $scope.AddNhomThucDon();
                        break;
                    case "edit":
                        $scope.EditNhomThucDon();
                        break;
                    case "delete":
                        $scope.DeleteNhomThucDon();
                        break;
                }

            }
        }
    };
    //Thực đơn
    $scope.contextMenuThucDon = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#thucdon',
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
                        $scope.AddThucDon();
                        break;
                    case "edit":
                        $scope.EditThucDon();
                        break;
                    case "delete":
                        $scope.DeleteThucDon();
                        break;
                }

            }
        }
    };

    Init();

    //---FUNCTION---
    function Init() {
        GetAllNhomThucDon();
        GetThucDon();
        GetAllDonViTinh();
        GetAllMatHang();
    }

    $scope.AutoDinhLuong = function () {
        console.log($scope.thucdons.length);
        angular.forEach($scope.thucdons, function (thucdon, indexTD) {
            var count = 0;
            angular.forEach($scope.mathangs, function (mathang, indexMH) {
                if (thucdon.ten == mathang.ten && count == 0) {
                    var dinhluong = {
                        idThucDon: thucdon.id,
                        idMatHang: mathang.id,
                        soluong: 1
                    };
                    $http.post(apiDinhLuong, dinhluong)
                        .then(function (response) {
                            count++;
                        });
                }
            });
        })
    }

    //Nhóm thuốc đơn
    function GetAllNhomThucDon() {
        $http.get(apiNhomThucDon)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.nhomThucDonTemplates = angular.copy(response.data);
                    $scope.nhomThucDons = angular.copy($scope.nhomThucDonTemplates);

                }
            })
    }
    $scope.AddNhomThucDon = function () {
        $scope.nhomThucDon = {};
        $scope.titlePopupModifyNhomThucDon = "Thêm nhóm thuốc đơn";
        $scope.modifyNhomThucDon = true;
    }
    $scope.EditNhomThucDon = function () {
        $scope.titlePopupModifyNhomThucDon = "Sửa nhóm thuốc đơn";
        $scope.modifyNhomThucDon = true;
    }
    $scope.SaveNhomThucDon = function (e) {
        //Thêm
        if (!angular.isDefined($scope.nhomThucDon.id)) {
            $http.post(apiNhomThucDon, $scope.nhomThucDon)
                .then(function (response) {
                    if (response.status == 201) {
                        GetAllNhomThucDon();
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyNhomThucDon = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
            //Sửa
        else {
            $http.put(apiNhomThucDon + "/" + $scope.nhomThucDon.id, $scope.nhomThucDon)
                .then(function (response) {
                    if (response.status == 204) {
                        GetAllNhomThucDon();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyNhomThucDon = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveNhomThucDon = function () {
        $scope.modifyNhomThucDon = false;
    }
    $scope.DeleteNhomThucDon = function () {
        $scope.deleteNhomThucDon = true;
    }
    $scope.ConfirmDeleteNhomThucDon = function () {
        $http.delete(apiNhomThucDon + "/" + $scope.nhomThucDon.id)
            .then(function (response) {
                if (response.status == 200) {
                    GetAllNhomThucDon();
                    toastr.success("Thành công", "Xóa");
                    $scope.deleteNhomThucDon = false;
                } else {
                    toastr.error("Thất bại", "Xóa");
                }
            })
    };
    $scope.CancelDeleteNhomThucDon = function () {
        $scope.deleteNhomThucDon = false;
    };
    function FilterNhomThucDon(text) {
        $scope.nhomThucDons = [];
        angular.forEach($scope.nhomThucDonTemplates, function (value, index) {
            if (value.ten.toLowerCase().includes(text.toLowerCase())) {
                $scope.nhomThucDons.push(value);
            }
        });
    }

    //Thực đơn
    function GetThucDon() {
        if ($scope.selectedNhomThucDon.id == null) {
            $http.get(apiThucDon)
                .then(function (response) {
                    if (response.status == 200) {
                        $scope.thucdons = response.data;
                    }
                })
        } else {
            $http.get(apiThucDon + "?att=idNhomThucDon&&value=" + $scope.selectedNhomThucDon.id)
                .then(function (response) {
                    if (response.status == 200) {
                        $scope.thucdons = response.data;
                    }
                })
        }
    }
    $scope.GetAllThucDon = function () {
        $scope.selectedNhomThucDon = {};
        GetThucDon();
    }
    $scope.AddThucDon = function () {
        $scope.thucdon = {
            dongia: 0,
            donvitinh: "Hộp",
            ton: 0
        };
        if ($scope.selectedNhomThucDon.id == null) {

        } else {
            $scope.thucdon.idNhomThucDon = $scope.selectedNhomThucDon.id
        }

        $scope.titlePopupModifyThucDon = "Thêm thuốc đơn";
        $scope.modifyThucDon = true;
    }
    $scope.EditThucDon = function () {
        if ($scope.selectedThucDons.length == 0) {
            toastr.error("Chọn 1 dòng để sửa");
        } else {
            $scope.thucdon = angular.copy($scope.selectedThucDons[0]);
            $scope.titlePopupModifyThucDon = "Sửa thuốc đơn";
            $scope.modifyThucDon = true;
        }
    }
    $scope.SaveThucDon = function (e) {
        //Thêm
        if (!angular.isDefined($scope.thucdon.id)) {
            //Sản phẩm có mã vạch
            if ($scope.thucdon.mavach != null) {
                $http.post(apiThucDon, $scope.thucdon)
                    .then(function (response) {
                        if (response.status == 201) {
                            GetThucDon();
                            toastr.success("Thành công", "Thêm");
                            $scope.modifyThucDon = false;
                        } else {
                            toastr.error("Thất bại", "Thêm");
                        }
                    });
            } else {
                //Sản phẩm không có mã vạch
                $http.post(apiThucDon, $scope.thucdon)
                    .then(function (response) {
                        if (response) {
                            $http.get('/API/DM_ThucDonAPI?att=getSPCuoi')
                            .then(function (response) {
                                if (response.data) {
                                    var DM_ThucDon2 = {
                                        id: response.data.id,
                                        mavach: 'SP' + pad(response.data.id, 7),
                                        idNhomThucDon: response.data.idNhomThucDon,
                                        donvitinh: response.data.donvitinh,
                                        ten: response.data.ten,
                                        dongia: response.data.dongia,
                                        huongdan: response.data.huongdan,
                                        hinhanh: response.data.hinhanh,
                                        ghichu: response.data.ghichu,
                                    };

                                    $http.put(apiThucDon + '/' + response.data.id, DM_ThucDon2)
                                }
                                console.log(DM_ThucDon2);
                            });
                            GetThucDon();
                            toastr.success("Thành công", "Thêm");
                            $scope.modifyThucDon = false;
                        } else {
                            toastr.error("Thất bại", "Thêm");
                        }
                    });
            }
        }
            //Sửa
        else {
            //Sản phẩm có mã vạch
            if ($scope.thucdon.mavach != null) {
                $http.put(apiThucDon + "/" + $scope.thucdon.id, $scope.thucdon)
                .then(function (response) {
                    if (response.status == 204) {
                        GetThucDon();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyThucDon = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
            } else {
                //Sản phẩm không có mã vạch
                $scope.thucdon.mavach = 'SP' + pad($scope.thucdon.id, 7);
                $http.put(apiThucDon + '/' + $scope.thucdon.id, $scope.thucdon)
                .then(function (response) {
                    if (response.status == 204) {
                        GetThucDon();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyThucDon = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
            }
        }
    };
    $scope.CancelSaveThucDon = function () {
        $scope.modifyThucDon = false;
    }
    $scope.DeleteThucDon = function () {
        if ($scope.selectedThucDons.length == 0) {
            toastr.error("Chọn dòng để xóa");
        } else {
            $scope.deleteThucDon = true;
        }
    }
    $scope.ConfirmDeleteThucDon = function () {
        angular.forEach($scope.selectedThucDons, function (value, index) {
            $http.delete(apiThucDon + '/' + value.id)
                .then(function (response) {
                    if (response.status == 200) {
                        angular.forEach($scope.thucdons, function (valueMH, indexMH) {
                            if (value.id === valueMH.id) {
                                $scope.thucdons.splice(indexMH, 1);
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Xóa");
                    }
                })
        });
        toastr.success("Thành công", "Xóa");
        $scope.deleteThucDon = false;
    };
    $scope.CancelDeleteThucDon = function () {
        $scope.deleteThucDon = false;
    };

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

    //Định lượng
    function GetDinhLuong() {
        if ($scope.selectedThucDons.length > 0) {
            $scope.thucdon = angular.copy($scope.selectedThucDons[0]);
            if ($scope.thucdon.id != null) {
                $http.get(apiDinhLuong + "?att=idThucDon&&value=" + $scope.thucdon.id)
                    .then(function (response) {
                        if (response.status == 200) {
                            $scope.dinhluongs = response.data;
                        }
                    })
            }
        }
    }
    $scope.DinhLuong = function () {
        if ($scope.thucdon.id == null) {
            toastr.warning("Chưa chọn thuốc đơn", "Cảnh báo");
        } else {
            $scope.dinhluongEdits = angular.copy($scope.dinhluongs);
            $scope.titlePopupModifyDinhLuong = "Định lượng " + $scope.thucdon.ten;
            $scope.modifyDinhLuong = true;
        }
    }
    $scope.CancelSaveDinhLuong = function () {
        $scope.modifyDinhLuong = false;
    }
    function ChooseMatHang(idMatHang) {
        var existed = false;
        angular.forEach($scope.dinhluongEdits, function (value, index) {
            if (value.idMatHang == idMatHang) {
                existed = true;
                toastr.warning("Đã tồn tại", "Mặt hàng");
            }
        });

        if (existed == false) {
            var dinhluong = {
                idMatHang: idMatHang,
                idThucDon: $scope.thucdon.id,
                soluong: 1
            }
            $scope.dinhluongEdits.push(dinhluong);
        }
    }
    $scope.SaveDinhLuong = function () {
        //Xóa định lượng cũ
        $http.get('/DinhLuong/DeleteByThucDon/' + $scope.thucdon.id)
            .then(function (response) {
                if (response.status == 200 && response.data == 1) {
                    //Lưu định lượng
                    angular.forEach($scope.dinhluongEdits, function (value, index) {
                        $http.post(apiDinhLuong, value)
                            .then(function (response) {
                                console.log(response);
                            })
                    });
                    $scope.dinhluongs = angular.copy($scope.dinhluongEdits);
                    $scope.modifyDinhLuong = false;
                    toastr.success("Thành công", "Định lượng");
                } else {
                    toastr.error("Thất bại", "Định lượng");
                }
            });
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

    //Sinh mã vạch CODE128
    function pad(str, max) {
        str = str.toString();
        return str.length < max ? pad("0" + str, max) : str;
    }

    //MÃ VẠCH
    $scope.InMaVach = function () { }

    $scope.mavach = {
        width: 2,
        height: 100,
        displayValue: true,
        font: 'monospace',
        textAlign: 'center',
        fontSize: 40,
        backgroundColor: '#fff',
        lineColor: '#000'
    }

}]);