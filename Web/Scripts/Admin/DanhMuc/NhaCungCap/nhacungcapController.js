admin.controller("nhacungcapController", ['$scope', '$http', function ($scope, $http) {
    //---VAR---
    //Nhà cung cấp
    $scope.nhacungcaps = [];
    $scope.nhacungcap = {};
    $scope.selectedNhaCungCaps = [];
    var apiNhaCungCap = "/API/DM_NhaCungCapAPI";

    //---POPUP---
    //Nhà cung cấp
    $scope.modifyNhaCungCap = false;
    $scope.deleteNhaCungCap = false;
    $scope.titlePopupModifyNhaCungCap = "Thêm nhà cung cấp";
    $scope.popupModifyNhaCungCap = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyNhaCungCap",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyNhaCungCap",
            visible: "modifyNhaCungCap",
        }
    };
    $scope.popupDeleteNhaCungCap = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteNhaCungCap",
        showTitle: false,
        bindingOptions: {
            visible: "deleteNhaCungCap",
        }
    };


    //---CONTROL CONFIG---
    //Nhà cung cấp
    $scope.controlNhaCungCap = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhacungcap.ten"
            }
        },
        dienthoai: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhacungcap.dienthoai"
            }
        },
        diachi: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhacungcap.diachi"
            }
        },
        email: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhacungcap.email"
            }
        },
        congty: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhacungcap.congty"
            }
        },
        masoThue: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhacungcap.masoThue"
            }
        },
        //TextArea
        ghichu: {
            height: 80,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhacungcap.ghichu"
            }
        },
    }

    //---LIST---
    //Nhà cung cấp
    $scope.gridNhaCungCaps = {
        bindingOptions: {
            dataSource: 'nhacungcaps'
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
                caption: "Tên NCC",
                dataField: "ten",
                dataType: "string",
                fixed: true,
                fixedPosition: "left",
            },
            {//2
                alignment: "left",
                caption: "Điện thoại",
                dataField: "dienthoai",
                dataType: "string"
            },
            {//3
                alignment: "left",
                caption: "Địa chỉ",
                dataField: "diachi",
                dataType: "string"
            },
            {//4
                alignment: "left",
                caption: "Email",
                dataField: "email",
                dataType: "string"
            },
            {//5
                alignment: "left",
                caption: "Công ty",
                dataField: "congty",
                dataType: "string"
            },
            {//6
                alignment: "left",
                caption: "Mã số thuế",
                dataField: "masoThue",
                dataType: "string"
            },
            {//7
                alignment: "left",
                caption: "Ghi chú",
                dataField: "ghichu",
                dataType: "string"
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
            fileName: "Danh sách Nhà cung cấp",
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
                            $scope.AddNhaCungCap();
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
                            $scope.EditNhaCungCap();
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
                            $scope.DeleteNhaCungCap();
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
                            GetAllNhaCungCap();
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
                    $scope.nhacungcap = angular.copy(e.data);
                    $scope.EditNhaCungCap();
                }

                // Reset your click info
                component.clickCount = 0;
                component.lastClickTime = 0;
            }
        },
        //Select Row
        onSelectionChanged: function (e) {
            $scope.selectedNhaCungCaps = angular.copy(e.selectedRowsData);
        }
    };

    //---CONTEXTMENU---
    var itemContextMenus = [
        { value: 'add', text: ' Thêm', icon: 'fa fa-plus' },
        { value: 'edit', text: ' Sửa', icon: 'fa fa-pencil' },
        { value: 'delete', text: ' Xóa', icon: 'fa fa-times' }
    ];
    //Nhà cung cấp
    $scope.contextMenuNhaCungCap = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#nhacungcap',
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
                        $scope.AddNhaCungCap();
                        break;
                    case "edit":
                        $scope.EditNhaCungCap();
                        break;
                    case "delete":
                        $scope.DeleteNhaCungCap();
                        break;
                }

            }
        }
    };


    Init();

    //---FUNCTION---
    function Init() {
        GetAllNhaCungCap();
    }

    //Nhà cung cấp
    function GetAllNhaCungCap() {
        $http.get(apiNhaCungCap)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.nhacungcaps = response.data;
                }
            })
    }
    $scope.AddNhaCungCap = function () {
        $scope.nhacungcap = {};
        $scope.titlePopupModifyNhaCungCap = "Thêm nhà cung cấp";
        $scope.modifyNhaCungCap = true;
    }
    $scope.EditNhaCungCap = function () {
        if ($scope.selectedNhaCungCaps.length == 0) {
            toastr.error("Chọn 1 dòng để sửa");
        } else {
            $scope.nhacungcap = angular.copy($scope.selectedNhaCungCaps[0]);
            $scope.titlePopupModifyNhaCungCap = "Sửa nhà cung cấp";
            $scope.modifyNhaCungCap = true;
        }
    }
    $scope.SaveNhaCungCap = function (e) {
        //Thêm
        if (!angular.isDefined($scope.nhacungcap.id)) {
            $http.post(apiNhaCungCap, $scope.nhacungcap)
                .then(function (response) {
                    if (response.status == 201) {
                        $scope.nhacungcaps.push(response.data);
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyNhaCungCap = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiNhaCungCap + "/" + $scope.nhacungcap.id, $scope.nhacungcap)
                .then(function (response) {
                    if (response.status == 204) {
                        angular.forEach($scope.nhacungcaps, function (value, index) {
                            if (value.id == $scope.nhacungcap.id) {
                                $scope.nhacungcaps[index] = angular.copy($scope.nhacungcap);
                                toastr.success("Thành công", "Sửa");
                                $scope.modifyNhaCungCap = false;
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveNhaCungCap = function () {
        $scope.modifyNhaCungCap = false;
    }
    $scope.DeleteNhaCungCap = function () {
        if ($scope.selectedNhaCungCaps.length == 0) {
            toastr.error("Chọn dòng để xóa");
        } else {
            $scope.deleteNhaCungCap = true;
        }
    }
    $scope.ConfirmDeleteNhaCungCap = function () {
        angular.forEach($scope.selectedNhaCungCaps, function (value, index) {
            $http.delete(apiNhaCungCap + '/' + value.id)
                .then(function (response) {
                    if (response.status == 200) {
                        angular.forEach($scope.nhacungcaps, function (valueDVT, indexDVT) {
                            if (value.id === valueDVT.id) {
                                $scope.nhacungcaps.splice(indexDVT, 1);
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Xóa");
                    }
                })
        });
        toastr.success("Thành công", "Xóa");
        $scope.deleteNhaCungCap = false;
    };
    $scope.CancelDeleteNhaCungCap = function () {
        $scope.deleteNhaCungCap = false;
    };
    
}]);