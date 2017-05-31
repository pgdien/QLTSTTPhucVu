admin.controller("donvitinhController", ['$scope', '$http', function ($scope, $http) {
    //---VAR---
    //Đơn vị tính
    $scope.donvitinhs = [];
    $scope.donvitinh = {};
    $scope.selectedDonViTinhs = [];
    var apiDonViTinh = "/API/DM_DonViTinhAPI";
    //Đơn vị thời gian
    $scope.donviThoiGians = [];
    $scope.donviThoiGian = {};
    $scope.selectedDonViThoiGians = [];
    var apiDonViThoiGian = "/API/DM_DonViThoiGianAPI";

    //---POPUP---
    //Đơn vị tính
    $scope.modifyDonViTinh = false;
    $scope.deleteDonViTinh = false;
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
    $scope.popupDeleteDonViTinh = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteDonViTinh",
        showTitle: false,
        bindingOptions: {
            visible: "deleteDonViTinh",
        }
    };
    //Đơn vị thời gian
    $scope.modifyDonViThoiGian = false;
    $scope.deleteDonViThoiGian = false;
    $scope.titlePopupModifyDonViThoiGian = "Thêm đơn vị thời gian";
    $scope.popupModifyDonViThoiGian = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyDonViThoiGian",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyDonViThoiGian",
            visible: "modifyDonViThoiGian",
        }
    };
    $scope.popupDeleteDonViThoiGian = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteDonViThoiGian",
        showTitle: false,
        bindingOptions: {
            visible: "deleteDonViThoiGian",
        }
    };


    //---CONTROL CONFIG---
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
    //Đơn vị thời gian
    $scope.controlDonViThoiGian = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "donviThoiGian.ten"
            }
        }
    }

    //---LIST---
    //Đơn vị tính
    $scope.gridDonViTinhs = {
        bindingOptions: {
            dataSource: 'donvitinhs'
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
                fixed: true,
                fixedPosition: "left",
                width: 90
            },
            {//1
                alignment: "left",
                caption: "Tên đơn vị tính",
                dataField: "ten",
                dataType: "string",
                fixed: true,
                fixedPosition: "left",
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
            fileName: "Danh sách Đơn vị tính",
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
            emptyPanelText: "ĐƠN VỊ TÍNH",
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
                            $scope.AddDonViTinh();
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
                            $scope.EditDonViTinh();
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
                            $scope.DeleteDonViTinh();
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
                            GetAllDonViTinh();
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
                    $scope.donvitinh = angular.copy(e.data);
                    $scope.EditDonViTinh();
                }

                // Reset your click info
                component.clickCount = 0;
                component.lastClickTime = 0;
            }
        },
        //Select Row
        onSelectionChanged: function (e) {
            $scope.selectedDonViTinhs = angular.copy(e.selectedRowsData);
        }
    };
    //Đơn vị thời gian
    $scope.gridDonViThoiGians = {
        bindingOptions: {
            dataSource: 'donviThoiGians'
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
                fixed: true,
                fixedPosition: "left",
                width: 90
            },
            {//1
                alignment: "left",
                caption: "Tên đơn vị thời gian",
                dataField: "ten",
                dataType: "string",
                fixed: true,
                fixedPosition: "left",
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
            fileName: "Danh sách Đơn vị thời gian",
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
            emptyPanelText: "ĐƠN VỊ THỜI GIAN",
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
                            $scope.AddDonViThoiGian();
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
                            $scope.EditDonViThoiGian();
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
                            $scope.DeleteDonViThoiGian();
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
                            GetAllDonViThoiGian();
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
                    $scope.donviThoiGian = angular.copy(e.data);
                    $scope.EditDonViThoiGian();
                }

                // Reset your click info
                component.clickCount = 0;
                component.lastClickTime = 0;
            }
        },
        //Select Row
        onSelectionChanged: function (e) {
            $scope.selectedDonViThoiGians = angular.copy(e.selectedRowsData);
        }
    };

    //---CONTEXTMENU---
    var itemContextMenus = [
        { value: 'add', text: ' Thêm', icon: 'fa fa-plus' },
        { value: 'edit', text: ' Sửa', icon: 'fa fa-pencil' },
        { value: 'delete', text: ' Xóa', icon: 'fa fa-times' }
    ];
    //Đơn vị tính
    $scope.contextMenuDonViTinh = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#donvitinh',
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
                        $scope.AddDonViTinh();
                        break;
                    case "edit":
                        $scope.EditDonViTinh();
                        break;
                    case "delete":
                        $scope.DeleteDonViTinh();
                        break;
                }

            }
        }
    };
    //Đơn vị thời gian
    $scope.contextMenuDonViThoiGian = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#donviThoiGian',
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
                        $scope.AddDonViThoiGian();
                        break;
                    case "edit":
                        $scope.EditDonViThoiGian();
                        break;
                    case "delete":
                        $scope.DeleteDonViThoiGian();
                        break;
                }

            }
        }
    };


    Init();

    //---FUNCTION---
    function Init() {
        GetAllDonViTinh();
        GetAllDonViThoiGian();
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
    $scope.EditDonViTinh = function () {
        if ($scope.selectedDonViTinhs.length == 0) {
            toastr.error("Chọn 1 dòng để sửa");
        } else {
            $scope.donvitinh = angular.copy($scope.selectedDonViTinhs[0]);
            $scope.titlePopupModifyDonViTinh = "Sửa đơn vị tính";
            $scope.modifyDonViTinh = true;
        }
    }
    $scope.SaveDonViTinh = function (e) {
        //Thêm
        if (!angular.isDefined($scope.donvitinh.id)) {
            $http.post(apiDonViTinh, $scope.donvitinh)
                .then(function (response) {
                    if (response.status == 201) {
                        $scope.donvitinhs.push(response.data);
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
                        angular.forEach($scope.donvitinhs, function (value, index) {
                            if (value.id == $scope.donvitinh.id) {
                                $scope.donvitinhs[index] = angular.copy($scope.donvitinh);
                                toastr.success("Thành công", "Sửa");
                                $scope.modifyDonViTinh = false;
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveDonViTinh = function () {
        $scope.modifyDonViTinh = false;
    }
    $scope.DeleteDonViTinh = function () {
        if ($scope.selectedDonViTinhs.length == 0) {
            toastr.error("Chọn dòng để xóa");
        } else {
            $scope.deleteDonViTinh = true;
        }
    }
    $scope.ConfirmDeleteDonViTinh = function () {
        angular.forEach($scope.selectedDonViTinhs, function (value, index) {
            $http.delete(apiDonViTinh + '/' + value.id)
                .then(function (response) {
                    if (response.status == 200) {
                        angular.forEach($scope.donvitinhs, function (valueDVT, indexDVT) {
                            if (value.id === valueDVT.id) {
                                $scope.donvitinhs.splice(indexDVT, 1);
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Xóa");
                    }
                })
        });
        toastr.success("Thành công", "Xóa");
        $scope.deleteDonViTinh = false;
    };
    $scope.CancelDeleteDonViTinh = function () {
        $scope.deleteDonViTinh = false;
    };
    //Đơn vị thời gian
    function GetAllDonViThoiGian() {
        $http.get(apiDonViThoiGian)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.donviThoiGians = response.data;
                }
            })
    }
    $scope.AddDonViThoiGian = function () {
        $scope.donviThoiGian = {};
        $scope.titlePopupModifyDonViThoiGian = "Thêm đơn vị thời gian";
        $scope.modifyDonViThoiGian = true;
    }
    $scope.EditDonViThoiGian = function () {
        if ($scope.selectedDonViThoiGians.length == 0) {
            toastr.error("Chọn 1 dòng để sửa");
        } else {
            $scope.donviThoiGian = angular.copy($scope.selectedDonViThoiGians[0]);
            $scope.titlePopupModifyDonViThoiGian = "Sửa đơn vị thời gian";
            $scope.modifyDonViThoiGian = true;
        }
    }
    $scope.SaveDonViThoiGian = function (e) {
        //Thêm
        if (!angular.isDefined($scope.donviThoiGian.id)) {
            $http.post(apiDonViThoiGian, $scope.donviThoiGian)
                .then(function (response) {
                    if (response.status == 201) {
                        $scope.donviThoiGians.push(response.data);
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyDonViThoiGian = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiDonViThoiGian + "/" + $scope.donviThoiGian.id, $scope.donviThoiGian)
                .then(function (response) {
                    if (response.status == 204) {
                        angular.forEach($scope.donviThoiGians, function (value, index) {
                            if (value.id == $scope.donviThoiGian.id) {
                                $scope.donviThoiGians[index] = angular.copy($scope.donviThoiGian);
                                toastr.success("Thành công", "Sửa");
                                $scope.modifyDonViThoiGian = false;
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveDonViThoiGian = function () {
        $scope.modifyDonViThoiGian = false;
    }
    $scope.DeleteDonViThoiGian = function () {
        if ($scope.selectedDonViThoiGians.length == 0) {
            toastr.error("Chọn dòng để xóa");
        } else {
            $scope.deleteDonViThoiGian = true;
        }
    }
    $scope.ConfirmDeleteDonViThoiGian = function () {
        angular.forEach($scope.selectedDonViThoiGians, function (value, index) {
            $http.delete(apiDonViThoiGian + '/' + value.id)
                .then(function (response) {
                    if (response.status == 200) {
                        angular.forEach($scope.donviThoiGians, function (valueDVTG, indexDVTG) {
                            if (value.id === valueDVTG.id) {
                                $scope.donviThoiGians.splice(indexDVTG, 1);
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Xóa");
                    }
                })
        });
        toastr.success("Thành công", "Xóa");
        $scope.deleteDonViThoiGian = false;
    };
    $scope.CancelDeleteDonViThoiGian = function () {
        $scope.deleteDonViThoiGian = false;
    };

}]);