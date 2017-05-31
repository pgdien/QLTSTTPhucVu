admin.controller("nhanvienphucvuController", ['$scope', '$http', function ($scope, $http) {
    //---VAR---
    //Nhân viên phục vụ
    $scope.nhanvienPhucVus = [];
    $scope.nhanvienPhucVu = {};
    $scope.selectedNhanVienPhucVus = [];
    var apiNhanVienPhucVu = "/API/DM_NhanVienPhucVuAPI";

    //---POPUP---
    //Nhân viên phục vụ
    $scope.modifyNhanVienPhucVu = false;
    $scope.deleteNhanVienPhucVu = false;
    $scope.titlePopupModifyNhanVienPhucVu = "Thêm nhân viên phục vụ";
    $scope.popupModifyNhanVienPhucVu = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyNhanVienPhucVu",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyNhanVienPhucVu",
            visible: "modifyNhanVienPhucVu",
        }
    };
    $scope.popupDeleteNhanVienPhucVu = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteNhanVienPhucVu",
        showTitle: false,
        bindingOptions: {
            visible: "deleteNhanVienPhucVu",
        }
    };


    //---CONTROL CONFIG---
    //Nhân viên phục vụ
    $scope.controlNhanVienPhucVu = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhanvienPhucVu.ten"
            }
        },
        tenHoaDon: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhanvienPhucVu.tenHoaDon"
            }
        },
        sdt: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhanvienPhucVu.sdt"
            }
        },
        diachi: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhanvienPhucVu.diachi"
            }
        },
        //TextArea
        //DateBox
        ngayVaoLam: {
            type: "date",
            displayFormat: "dd/MM/yyyy",
            bindingOptions: {
                value: "nhanvienPhucVu.ngayVaoLam"
            }
        }
    }

    //---LIST---
    //Nhân viên phục vụ
    $scope.gridNhanVienPhucVus = {
        bindingOptions: {
            dataSource: 'nhanvienPhucVus'
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
                width: 90,
                visible: false
            },
            {//1
                alignment: "left",
                caption: "Tên nhân viên",
                dataField: "ten",
                dataType: "string"
            },
            {//2
                alignment: "left",
                caption: "Tên trên HĐ",
                dataField: "tenHoaDon",
                dataType: "string"
            },
            {//3
                alignment: "left",
                caption: "SĐT",
                dataField: "sdt",
                dataType: "string"
            },
            {//4
                alignment: "left",
                caption: "Địa chỉ",
                dataField: "diachi",
                dataType: "string"
            },
            {//5
                alignment: "left",
                caption: "Ngày vào làm",
                dataField: "ngayVaoLam",
                dataType: "date",
                format: "dd/MM/yyyy",
                customizeText: function (cellInfo) {
                    return cellInfo.valueText;
                }
            },
            {//6
                alignment: "right",
                caption: "Giá DV(vnđ/phút)",
                dataField: "dongia",
                format: {
                    type: "fixedPoint",
                    precision: 0
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
            enabled: true,
            excelFilterEnabled: true,
            excelWrapTextEnabled: true,
            fileName: "Danh sách Nhân viên phục vụ",
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
                            $scope.AddNhanVienPhucVu();
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
                            $scope.EditNhanVienPhucVu();
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
                            $scope.DeleteNhanVienPhucVu();
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
                            GetAllNhanVienPhucVu();
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
                    $scope.nhanvienPhucVu = angular.copy(e.data);
                    $scope.EditNhanVienPhucVu();
                }

                // Reset your click info
                component.clickCount = 0;
                component.lastClickTime = 0;
            }
        },
        //Select Row
        onSelectionChanged: function (e) {
            $scope.selectedNhanVienPhucVus = angular.copy(e.selectedRowsData);
        }
    };

    //---CONTEXTMENU---
    var itemContextMenus = [
        { value: 'add', text: ' Thêm', icon: 'fa fa-plus' },
        { value: 'edit', text: ' Sửa', icon: 'fa fa-pencil' },
        { value: 'delete', text: ' Xóa', icon: 'fa fa-times' }
    ];
    //Nhân viên phục vụ
    $scope.contextMenuNhanVienPhucVu = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#nhanvienPhucVu',
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
                        $scope.AddNhanVienPhucVu();
                        break;
                    case "edit":
                        $scope.EditNhanVienPhucVu();
                        break;
                    case "delete":
                        $scope.DeleteNhanVienPhucVu();
                        break;
                }

            }
        }
    };


    Init();

    //---FUNCTION---
    function Init() {
        GetAllNhanVienPhucVu();
    }

    //Nhân viên phục vụ
    function GetAllNhanVienPhucVu() {
        $http.get(apiNhanVienPhucVu)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.nhanvienPhucVus = response.data;
                }
            })
    }
    $scope.AddNhanVienPhucVu = function () {
        $scope.nhanvienPhucVu = {};
        $scope.titlePopupModifyNhanVienPhucVu = "Thêm nhân viên phục vụ";
        $scope.modifyNhanVienPhucVu = true;
    }
    $scope.EditNhanVienPhucVu = function () {
        if ($scope.selectedNhanVienPhucVus.length == 0) {
            toastr.error("Chọn 1 dòng để sửa");
        } else {
            $scope.nhanvienPhucVu = angular.copy($scope.selectedNhanVienPhucVus[0]);
            $scope.titlePopupModifyNhanVienPhucVu = "Sửa nhân viên phục vụ";
            $scope.modifyNhanVienPhucVu = true;
        }
    }
    $scope.SaveNhanVienPhucVu = function (e) {
        //Thêm
        if (!angular.isDefined($scope.nhanvienPhucVu.id)) {
            $http.post(apiNhanVienPhucVu, $scope.nhanvienPhucVu)
                .then(function (response) {
                    if (response.status == 201) {
                        $scope.nhanvienPhucVus.push(response.data);
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyNhanVienPhucVu = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiNhanVienPhucVu + "/" + $scope.nhanvienPhucVu.id, $scope.nhanvienPhucVu)
                .then(function (response) {
                    if (response.status == 204) {
                        angular.forEach($scope.nhanvienPhucVus, function (value, index) {
                            if (value.id == $scope.nhanvienPhucVu.id) {
                                $scope.nhanvienPhucVus[index] = angular.copy($scope.nhanvienPhucVu);
                                toastr.success("Thành công", "Sửa");
                                $scope.modifyNhanVienPhucVu = false;
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveNhanVienPhucVu = function () {
        $scope.modifyNhanVienPhucVu = false;
    }
    $scope.DeleteNhanVienPhucVu = function () {
        if ($scope.selectedNhanVienPhucVus.length == 0) {
            toastr.error("Chọn dòng để xóa");
        } else {
            $scope.deleteNhanVienPhucVu = true;
        }
    }
    $scope.ConfirmDeleteNhanVienPhucVu = function () {
        angular.forEach($scope.selectedNhanVienPhucVus, function (value, index) {
            $http.delete(apiNhanVienPhucVu + '/' + value.id)
                .then(function (response) {
                    if (response.status == 200) {
                        angular.forEach($scope.nhanvienPhucVus, function (valueDVT, indexDVT) {
                            if (value.id === valueDVT.id) {
                                $scope.nhanvienPhucVus.splice(indexDVT, 1);
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Xóa");
                    }
                })
        });
        toastr.success("Thành công", "Xóa");
        $scope.deleteNhanVienPhucVu = false;
    };
    $scope.CancelDeleteNhanVienPhucVu = function () {
        $scope.deleteNhanVienPhucVu = false;
    };
    
}]);