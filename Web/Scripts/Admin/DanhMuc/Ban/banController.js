admin.controller("banController", ['$scope', '$http', function ($scope, $http) {
    $scope.khuvucs = [];
    $scope.khuvuc = {};
    $scope.bans = [];
    $scope.ban = {};

    var apiKhuVuc = "/API/DM_KhuVucAPI/";
    var apiBan = "/API/DM_BanAPI";

    //---POPUP---
    //Khu vực
    $scope.modifyKhuVuc = false;
    $scope.deleteKhuVuc = false;
    $scope.titlePopupModifyKhuVuc = "Thêm khu vực";
    $scope.popupModifyKhuVuc = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyKhuVuc",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyKhuVuc",
            visible: "modifyKhuVuc",
        }
    };
    $scope.popupDeleteKhuVuc = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteKhuVuc",
        showTitle: false,
        bindingOptions: {
            visible: "deleteKhuVuc",
        }
    };
    //Bàn
    $scope.modifyBan = false;
    $scope.deleteBan = false;
    $scope.titlePopupModifyBan = "Thêm bàn";
    $scope.popupModifyBan = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateModifyBan",
        showTitle: true,
        resizeEnabled: true,
        bindingOptions: {
            title: "titlePopupModifyBan",
            visible: "modifyBan",
        }
    };
    $scope.popupDeleteBan = {
        width: "auto",
        height: "auto",
        contentTemplate: "templateDeleteBan",
        showTitle: false,
        bindingOptions: {
            visible: "deleteBan",
        }
    };

    //---CONTROL CONFIG---
    //Khu vực
    $scope.controlKhuVuc = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "khuvuc.ten"
            }
        }
    }
    //Bàn
    $scope.controlBan = {
        //TextBox
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "ban.ten"
            }
        },
        //SelectBox
        khuvuc: {
            displayExpr: "ten",
            valueExpr: "id",
            searchEnabled: true,
            noDataText: "Không có dữ liệu",
            placeholder: "Chọn ...",
            bindingOptions: {
                items: "khuvucs",
                value: "ban.idKhuVuc"
            }
        },
        //Button
        addKhuVuc: {
            icon: "plus",
            onClick: function (e) {
                $scope.modifyKhuVuc = true;
            }
        }
    }

    //---LIST---
    //Khu vực
    $scope.listKhuVucs = {
        bindingOptions: {
            dataSource: 'khuvucs',
        },
        height: "100%",
        onItemClick: function (e) {
            $scope.khuvuc = angular.copy(e.itemData);
            GetBan();
        },
        onItemContextMenu: function (e) {
            $scope.khuvuc = angular.copy(e.itemData);
        }
    };
    //Bàn
    $scope.tileViewBans = {
        width: 800,
        height: 500,
        baseItemHeight: 117,
        baseItemWidth: 120,
        itemMargin: 10,
        direction: "vertical",
        bindingOptions: {
            items: "bans",
        },
        onItemContextMenu: function (e) {
            $scope.ban = angular.copy(e.itemData);
        }
    };

    //---CONTEXTMENU---
    var itemContextMenus = [
        { value: 'add', text: ' Thêm', icon: 'fa fa-plus' },
        { value: 'edit', text: ' Sửa', icon: 'fa fa-pencil' },
        { value: 'delete', text: ' Xóa', icon: 'fa fa-times' }
    ];
    //Khu vực
    $scope.contextMenuKhuVuc = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#khuvuc',
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
                        $scope.AddKhuVuc();
                        break;
                    case "edit":
                        $scope.EditKhuVuc();
                        break;
                    case "delete":
                        $scope.DeleteKhuVuc();
                        break;
                }
                
            }
        }
    };
    //Bàn
    $scope.contextMenuBan = {
        dataSource: itemContextMenus,
        width: 100,
        target: '#ban',
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
                        $scope.AddBan();
                        break;
                    case "edit":
                        $scope.EditBan();
                        break;
                    case "delete":
                        $scope.DeleteBan();
                        break;
                }

            }
        }
    };

    Init();
    
    //---FUNCTION---
    function Init() {
        GetAllKhuVuc();
        GetBan();
    }

    //Khu vực
    function GetAllKhuVuc() {
        $http.get(apiKhuVuc)
            .then(function (response) {
                if (response.status == 200) {
                    $scope.khuvucs = response.data;
                }
            })
    }
    $scope.AddKhuVuc = function () {
        $scope.khuvuc = {};
        $scope.titlePopupModifyKhuVuc = "Thêm khu vực";
        $scope.modifyKhuVuc = true;
    }
    $scope.EditKhuVuc = function () {
        $scope.titlePopupModifyKhuVuc = "Sửa khu vực";
        $scope.modifyKhuVuc = true;
    }
    $scope.SaveKhuVuc = function (e) {
        //Thêm
        if (!angular.isDefined($scope.khuvuc.id)) {
            $http.post(apiKhuVuc, $scope.khuvuc)
                .then(function (response) {
                    if (response.status == 201) {
                        GetAllKhuVuc();
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyKhuVuc = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiKhuVuc + $scope.khuvuc.id, $scope.khuvuc)
                .then(function (response) {
                    if (response.status == 204) {
                        GetAllKhuVuc();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyKhuVuc = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveKhuVuc = function () {
        $scope.modifyKhuVuc = false;
    }
    $scope.DeleteKhuVuc = function () {
        $scope.deleteKhuVuc = true;
    }
    $scope.ConfirmDeleteKhuVuc = function () {
        $http.delete(apiKhuVuc + $scope.khuvuc.id)
            .then(function (response) {
                if (response.status == 200) {
                    GetAllKhuVuc();
                    toastr.success("Thành công", "Xóa");
                    $scope.deleteKhuVuc = false;
                } else {
                    toastr.error("Thất bại", "Xóa");
                }
            })
    };
    $scope.CancelDeleteKhuVuc = function () {
        $scope.deleteKhuVuc = false;
    };

    //Bàn
    function GetBan() {
        if ($scope.khuvuc.id == null) {
            $http.get(apiBan)
                .then(function (response) {
                    if (response.status == 200) {
                        $scope.bans = response.data;
                    }
                })
        } else {
            $http.get(apiBan + "?att=idKhuVuc&&value=" + $scope.khuvuc.id)
                .then(function (response) {
                    if (response.status == 200) {
                        $scope.bans = response.data;
                    }
                })
        }
    }
    $scope.GetAllBan = function () {
        $scope.khuvuc = {};
        GetBan();
    }
    $scope.AddBan = function () {
        if ($scope.khuvuc.id == null) {
            $scope.ban = {};
        } else {
            $scope.ban = {
                idKhuVuc: $scope.khuvuc.id
            };
        }
        $scope.titlePopupModifyBan = "Thêm bàn";
        $scope.modifyBan = true;
    }
    $scope.EditBan = function () {
        $scope.titlePopupModifyBan = "Sửa bàn";
        $scope.modifyBan = true;
    }
    $scope.SaveBan = function (e) {
        //Thêm
        if (!angular.isDefined($scope.ban.id)) {
            $http.post(apiBan, $scope.ban)
                .then(function (response) {
                    if (response.status == 201) {
                        GetBan();
                        toastr.success("Thành công", "Thêm");
                        $scope.modifyBan = false;
                    } else {
                        toastr.error("Thất bại", "Thêm");
                    }
                });
        }
        //Sửa
        else {
            $http.put(apiBan + "/" + $scope.ban.id, $scope.ban)
                .then(function (response) {
                    if (response.status == 204) {
                        GetBan();
                        toastr.success("Thành công", "Sửa");
                        $scope.modifyBan = false;
                    } else {
                        toastr.error("Thất bại", "Sửa");
                    }
                });
        }
    };
    $scope.CancelSaveBan = function () {
        $scope.modifyBan = false;
    }
    $scope.DeleteBan= function () {
        $scope.deleteBan = true;
    }
    $scope.ConfirmDeleteBan = function () {
        $http.delete(apiBan + "/" + $scope.ban.id)
            .then(function (response) {
                if (response.status == 200) {
                    GetBan();
                    toastr.success("Thành công", "Xóa");
                    $scope.deleteBan = false;
                } else {
                    toastr.error("Thất bại", "Xóa");
                }
            })
    };
    $scope.CancelDeleteBan = function () {
        $scope.deleteBan = false;
    };
    


}]);