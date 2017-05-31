admin.controller("mathangController", ['$scope', '$http', function ($scope, $http) {
    //---VAR---
    //Nhóm mặt hàng
    $scope.nhomMatHangs = [];
    $scope.nhomMatHang = {};
    $scope.selectedNhomMatHang = {};
    var apiNhomMatHang = "/API/DM_NhomMatHangAPI";

    //Mặt hàng
    $scope.mathangs = [];
    $scope.mathang = {};
    $scope.selectedMatHangs = [];
    var apiMatHang = "/API/DM_MatHangAPI";

    //Đơn vị tính
    $scope.donvitinhs = [];
    $scope.donvitinh = {};
    var apiDonViTinh = "/API/DM_DonViTinhAPI";

    //---POPUP---
    //Nhóm mặt hàng
    $scope.modifyNhomMatHang = false;
    $scope.deleteNhomMatHang = false;
    $scope.titlePopupModifyNhomMatHang = "Thêm nhóm mặt hàng";
    $scope.popupModifyNhomMatHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyNhomMatHang",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyNhomMatHang",
            visible: "modifyNhomMatHang",
        }
    };
    $scope.popupDeleteNhomMatHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteNhomMatHang",
        showTitle: false,
        bindingOptions: {
            visible: "deleteNhomMatHang",
        }
    };
    //Mặt hàng
    $scope.modifyMatHang = false;
    $scope.deleteMatHang = false;
    $scope.titlePopupModifyMatHang = "Thêm mặt hàng";
    $scope.popupModifyMatHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyMatHang",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyMatHang",
            visible: "modifyMatHang",
        }
    };
    $scope.popupDeleteMatHang = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteMatHang",
        showTitle: false,
        bindingOptions: {
            visible: "deleteMatHang",
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

    //---CONTROL CONFIG---
    //Nhóm mặt hàng
    $scope.controlNhomMatHang = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "nhomMatHang.ten"
            }
        }
    }
    //Mặt hàng
    $scope.controlMatHang = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "mathang.ten"
            }
        },
        //SelectBox
        nhomMatHang: {
            displayExpr: "ten",
            valueExpr: "id",
            searchEnabled: true,
            noDataText: "Không có dữ liệu",
            placeholder: "Chọn ...",
            bindingOptions: {
                items: "nhomMatHangs",
                value: "mathang.idNhomMatHang"
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
                value: "mathang.donvitinh"
            }
        },
        //Button
        addNhomMatHang: {
            icon: "plus",
            onClick: function (e) {
                $scope.AddNhomMatHang();
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
    //Nhóm mặt hàng
    $scope.listNhomMatHangs = {
        bindingOptions: {
            dataSource: 'nhomMatHangs',
        },
        height: "490",
        nextButtonText: "Xem thêm",
        onItemClick: function (e) {
            $scope.selectedNhomMatHang = angular.copy(e.itemData);
            GetMatHang();
        },
        onItemContextMenu: function (e) {
            $scope.nhomMatHang = angular.copy(e.itemData);
        }
    };
    //Mặt hàng
    $scope.gridMatHangs = {
        bindingOptions: {
            dataSource: 'mathangs'
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
                caption: "Tên mặt hàng",
                dataField: "ten",
                dataType: "string",
            },
            {//2
                alignment: "left",
                caption: "ĐVT",
                dataField: "donvitinh",
                dataType: "string",
            },
            {//3
                alignment: "right",
                caption: "Giá nhập",
                dataField: "dongia",
                format: {
                    type: "fixedPoint",
                    precision: 0
                }
            },
            {//4
                alignment: "right",
                caption: "Tồn",
                dataField: "ton",
                format: {
                    type: "fixedPoint",
                    precision: 3
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
            fileName: "Danh sách Mặt hàng",
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
            emptyPanelText: "MẶT HÀNG",
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
                            $scope.AddMatHang();
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
                            $scope.EditMatHang();
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
                            $scope.DeleteMatHang();
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
                            GetMatHang();
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
                    $scope.mathang = angular.copy(e.data);
                    $scope.EditMatHang();
                }

                // Reset your click info
                component.clickCount = 0;
                component.lastClickTime = 0;
            }
        },
        //Select Row
        onSelectionChanged: function (e) {
            $scope.selectedMatHangs = angular.copy(e.selectedRowsData);
        }
    };

    //---CONTEXTMENU---
    var itemContextMenus = [
        { value: 'add', text: ' Thêm', icon: 'fa fa-plus' },
        { value: 'edit', text: ' Sửa', icon: 'fa fa-pencil' },
        { value: 'delete', text: ' Xóa', icon: 'fa fa-times' }
    ];
    //Nhóm mặt hàng
    $scope.contextMenuNhomMatHang = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#nhomMatHang',
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
                        $scope.AddNhomMatHang();
                        break;
                    case "edit":
                        $scope.EditNhomMatHang();
                        break;
                    case "delete":
                        $scope.DeleteNhomMatHang();
                        break;
                }
                
            }
        }
    };
    //Mặt hàng
    $scope.contextMenuMatHang = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#mathang',
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
                        $scope.AddMatHang();
                        break;
                    case "edit":
                        $scope.EditMatHang();
                        break;
                    case "delete":
                        $scope.DeleteMatHang();
                        break;
                }

            }
        }
    };

    Init();
    
    //---FUNCTION---
    function Init() {
        GetAllNhomMatHang();
        GetMatHang();
        GetAllDonViTinh();
    }

    //Nhóm mặt hàng
    function GetAllNhomMatHang() {
        $http.get(apiNhomMatHang)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.nhomMatHangs = response.data;
                }
            })
    }
    $scope.AddNhomMatHang = function () {
        $scope.nhomMatHang = {};
        $scope.titlePopupModifyNhomMatHang = "Thêm nhóm mặt hàng";
        $scope.modifyNhomMatHang = true;
    }
    $scope.EditNhomMatHang = function () {
        $scope.titlePopupModifyNhomMatHang = "Sửa nhóm mặt hàng";
        $scope.modifyNhomMatHang = true;
    }
    $scope.SaveNhomMatHang = function (e) {
        //Thêm
        if (!angular.isDefined($scope.nhomMatHang.id)) {
            $http.post(apiNhomMatHang, $scope.nhomMatHang)
                .then(function (response) {
                    if (response.status == 201) {
                        GetAllNhomMatHang();
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyNhomMatHang = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiNhomMatHang + "/" + $scope.nhomMatHang.id, $scope.nhomMatHang)
                .then(function (response) {
                    if (response.status == 204) {
                        GetAllNhomMatHang();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyNhomMatHang = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveNhomMatHang = function () {
        $scope.modifyNhomMatHang = false;
    }
    $scope.DeleteNhomMatHang = function () {
        $scope.deleteNhomMatHang = true;
    }
    $scope.ConfirmDeleteNhomMatHang = function () {
        $http.delete(apiNhomMatHang + "/" + $scope.nhomMatHang.id)
            .then(function (response) {
                if (response.status == 200) {
                    GetAllNhomMatHang();
                    toastr.success("Thành công", "Xóa");
                    $scope.deleteNhomMatHang = false;
                } else {
                    toastr.error("Thất bại", "Xóa");
                }
            })
    };
    $scope.CancelDeleteNhomMatHang = function () {
        $scope.deleteNhomMatHang = false;
    };

    //Mặt hàng
    function GetMatHang() {
        if ($scope.selectedNhomMatHang.id == null) {
            $http.get(apiMatHang)
                .then(function (response) {
                    if (response.status == 200) {
                        $scope.mathangs = response.data;
                    }
                })
        } else {
            $http.get(apiMatHang + "?att=idNhomMatHang&&value=" + $scope.selectedNhomMatHang.id)
                .then(function (response) {
                    if (response.status == 200) {
                        $scope.mathangs = response.data;
                    }
                })
        }
    }
    $scope.GetAllMatHang = function () {
        $scope.selectedNhomMatHang = {};
        GetMatHang();
    }
    $scope.AddMatHang = function () {
        $scope.mathang = {
            dongia: 0,
            ton: 0,
            donvitinh: "Hộp"
        };
        if ($scope.selectedNhomMatHang.id == null) {
            
        } else {
            $scope.mathang.idNhomMatHang = $scope.selectedNhomMatHang.id
        }

        $scope.titlePopupModifyMatHang = "Thêm mặt hàng";
        $scope.modifyMatHang = true;
    }
    $scope.EditMatHang = function () {
        if ($scope.selectedMatHangs.length == 0) {
            toastr.error("Chọn 1 dòng để sửa");
        } else {
            $scope.mathang = angular.copy($scope.selectedMatHangs[0]);
            $scope.titlePopupModifyMatHang = "Sửa mặt hàng";
            $scope.modifyMatHang = true;
        }
    }
    $scope.SaveMatHang = function (e) {
        //Thêm
        if (!angular.isDefined($scope.mathang.id)) {
            $http.post(apiMatHang, $scope.mathang)
                .then(function (response) {
                    if (response.status == 201) {
                        GetMatHang();
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyMatHang = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
            //Sửa
        else {
            $http.put(apiMatHang + "/" + $scope.mathang.id, $scope.mathang)
                .then(function (response) {
                    if (response.status == 204) {
                        GetMatHang();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyMatHang = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveMatHang = function () {
        $scope.modifyMatHang = false;
    }
    $scope.DeleteMatHang = function () {
        if ($scope.selectedMatHangs.length == 0) {
            toastr.error("Chọn dòng để xóa");
        } else {
            $scope.deleteMatHang = true;
        }
    }
    $scope.ConfirmDeleteMatHang = function () {
        angular.forEach($scope.selectedMatHangs, function (value, index) {
            $http.delete(apiMatHang + '/' + value.id)
                .then(function (response) {
                    if (response.status == 200) {
                        angular.forEach($scope.mathangs, function (valueMH, indexMH) {
                            if (value.id === valueMH.id) {
                                $scope.mathangs.splice(indexMH, 1);
                            }
                        });
                    } else {
                        toastr.error("Thất bại", "Xóa");
                    }
                })
        });
        toastr.success("Thành công", "Xóa");
        $scope.deleteMatHang = false;
    };
    $scope.CancelDeleteMatHang = function () {
        $scope.deleteMatHang = false;
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

}]);