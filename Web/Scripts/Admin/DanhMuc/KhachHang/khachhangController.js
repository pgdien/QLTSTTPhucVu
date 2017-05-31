admin.controller("khachhangController", ['$scope', '$http', function ($scope, $http) {
    //---VAR---
    //Khách hàng
    $scope.khachhangs = [];
    $scope.khachhang = {};
    $scope.selectedKhachHangs = [];
    var apiKhachHang = "/API/DM_KhachHangAPI";

    //---POPUP---
    //Khách hàng
    $scope.modifyKhachHang = false;
    $scope.deleteKhachHang = false;
    $scope.titlePopupModifyKhachHang = "Thêm khách hàng";
    $scope.popupModifyKhachHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyKhachHang",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyKhachHang",
            visible: "modifyKhachHang",
        }
    };
    $scope.popupDeleteKhachHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteKhachHang",
        showTitle: false,
        bindingOptions: {
            visible: "deleteKhachHang",
        }
    };


    //---CONTROL CONFIG---
    //Khách hàng
    $scope.controlKhachHang = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "khachhang.ten"
            }
        },
        dienthoai: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "khachhang.dienthoai"
            }
        },
        diachi: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "khachhang.diachi"
            }
        },
        email: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "khachhang.email"
            }
        },
        masoThue: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "khachhang.masoThue"
            }
        }
    }

    //---LIST---
    //Khách hàng
    $scope.gridKhachHangs = {
        bindingOptions: {
            dataSource: 'khachhangs'
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
                caption: "Tên khách hàng",
                dataField: "ten",
                dataType: "string",
                fixed: true,
                fixedPosition: "left",
            },
            {//2
                alignment: "left",
                caption: "Điện thoại",
                dataField: "dienthoai",
                dataType: "string",
                fixed: true,
                fixedPosition: "left",
            },
            {//3
                alignment: "left",
                caption: "Email",
                dataField: "email",
                dataType: "string",
                fixed: true,
                fixedPosition: "left",
            },
            {//4
                alignment: "left",
                caption: "Mã số thuế",
                dataField: "masoThue",
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
            fileName: "Danh sách Khách hàng",
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
                            $scope.AddKhachHang();
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
                            $scope.EditKhachHang();
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
                            $scope.DeleteKhachHang();
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
                            GetAllKhachHang();
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
                    $scope.khachhang = angular.copy(e.data);
                    $scope.EditKhachHang();
                }

                // Reset your click info
                component.clickCount = 0;
                component.lastClickTime = 0;
            }
        },
        //Select Row
        onSelectionChanged: function (e) {
            $scope.selectedKhachHangs = angular.copy(e.selectedRowsData);
        }
    };

    //---CONTEXTMENU---
    var itemContextMenus = [
        { value: 'add', text: ' Thêm', icon: 'fa fa-plus' },
        { value: 'edit', text: ' Sửa', icon: 'fa fa-pencil' },
        { value: 'delete', text: ' Xóa', icon: 'fa fa-times' }
    ];
    //Khách hàng
    $scope.contextMenuKhachHang = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#khachhang',
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
                        $scope.AddKhachHang();
                        break;
                    case "edit":
                        $scope.EditKhachHang();
                        break;
                    case "delete":
                        $scope.DeleteKhachHang();
                        break;
                }

            }
        }
    };


    Init();

    //---FUNCTION---
    function Init() {
        GetAllKhachHang();
    }

    //Khách hàng
    function GetAllKhachHang() {
        $http.get(apiKhachHang)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.khachhangs = response.data;
                }
            })
    }
    $scope.AddKhachHang = function () {
        $scope.khachhang = {};
        $scope.titlePopupModifyKhachHang = "Thêm khách hàng";
        $scope.modifyKhachHang = true;
    }
    $scope.EditKhachHang = function () {
        if ($scope.selectedKhachHangs.length == 0) {
            toastr.error("Chọn 1 dòng để sửa");
        } else {
            $scope.khachhang = angular.copy($scope.selectedKhachHangs[0]);
            $scope.titlePopupModifyKhachHang = "Sửa khách hàng";
            $scope.modifyKhachHang = true;
        }
    }
    $scope.SaveKhachHang = function (e) {
        //Thêm
        if (!angular.isDefined($scope.khachhang.id)) {
            $http.post(apiKhachHang, $scope.khachhang)
                .then(function (response) {
                    if (response.status == 201) {
                        $scope.khachhangs.push(response.data);
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyKhachHang = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiKhachHang + "/" + $scope.khachhang.id, $scope.khachhang)
                .then(function (response) {
                    if (response.status == 204) {
                        angular.forEach($scope.khachhangs, function (value, index) {
                            if (value.id == $scope.khachhang.id) {
                                $scope.khachhangs[index] = angular.copy($scope.khachhang);
                                toastr.success("Thành công", "Sửa");
                                $scope.modifyKhachHang = false;
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveKhachHang = function () {
        $scope.modifyKhachHang = false;
    }
    $scope.DeleteKhachHang = function () {
        if ($scope.selectedKhachHangs.length == 0) {
            toastr.error("Chọn dòng để xóa");
        } else {
            $scope.deleteKhachHang = true;
        }
    }
    $scope.ConfirmDeleteKhachHang = function () {
        angular.forEach($scope.selectedKhachHangs, function (value, index) {
            $http.delete(apiKhachHang + '/' + value.id)
                .then(function (response) {
                    if (response.status == 200) {
                        angular.forEach($scope.khachhangs, function (valueDVT, indexDVT) {
                            if (value.id === valueDVT.id) {
                                $scope.khachhangs.splice(indexDVT, 1);
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Xóa");
                    }
                })
        });
        toastr.success("Thành công", "Xóa");
        $scope.deleteKhachHang = false;
    };
    $scope.CancelDeleteKhachHang = function () {
        $scope.deleteKhachHang = false;
    };
    
}]);