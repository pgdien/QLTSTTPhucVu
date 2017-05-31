admin.controller("dashboardController", ['$scope', '$http', function ($scope, $http) {
    $scope.name = "KT LK";
    $scope.control = {
        ten: {
            showClearButton: true,
            valueChangeEvent: "keyup",
            bindingOptions: {
                value: "name"
            }
        }
    }
}]);