/// <reference path="admin.js" />
admin.config(function ($routeProvider, $locationProvider) {
    $routeProvider
    .when('/', {
        redirectTo: function () {
            return '/ban-hang';
        }
    })
    .when('/dashboard', {
        templateUrl: '/Scripts/Admin/Dashboard/Dashboard.min.html',
        controller: 'dashboardController'
    })
    .when('/ban-hang', {
        templateUrl: '/Scripts/Admin/BanHang/BanHangLe.min.html',
        controller: 'banhangController'
    })
    //Danh mục
    .when('/ban', {
        templateUrl: '/Scripts/Admin/DanhMuc/Ban/Ban.min.html',
        controller: 'banController'
    })
    .when('/don-vi-tinh', {
        templateUrl: '/Scripts/Admin/DanhMuc/DonViTinh/DonViTinh.min.html',
        controller: 'donvitinhController'
    })
    .when('/khach-hang', {
        templateUrl: '/Scripts/Admin/DanhMuc/KhachHang/KhachHang.min.html',
        controller: 'khachhangController'
    })
    .when('/nha-cung-cap', {
        templateUrl: '/Scripts/Admin/DanhMuc/NhaCungCap/NhaCungCap.min.html',
        controller: 'nhacungcapController'
    })
    .when('/nhan-vien-phuc-vu', {
        templateUrl: '/Scripts/Admin/DanhMuc/NhanVienPhucVu/NhanVienPhucVu.min.html',
        controller: 'nhanvienphucvuController'
    })
    //Kho
    .when('/mat-hang', {
        templateUrl: '/Scripts/Admin/Kho/MatHang/MatHang.min.html',
        controller: 'mathangController'
    })
    .when('/nhap-hang', {
        templateUrl: '/Scripts/Admin/Kho/NhapHang/NhapHang.min.html',
        controller: 'nhaphangController'
    })
    .when('/xuat-hang', {
        templateUrl: '/Scripts/Admin/Kho/XuatHang/XuatHang.min.html',
        controller: 'xuathangController'
    })
    //Thực đơn
    .when('/thuoc-don', {
        templateUrl: '/Scripts/Admin/ThucDon/ThucDon.min.html',
        controller: 'thucdonController'
    })
    //Báo cáo
    .when('/bao-cao-ban-hang', {
        templateUrl: '/Scripts/Admin/BaoCao/BaoCaoBanHang/BaoCaoBanHang.min.html',
        controller: 'baocaobanhangController'
    })
});