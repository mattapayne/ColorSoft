angular.module('colorSoft').controller('LoginCtrl', ['$scope', function ($scope) {
    $scope.UserName = "";
    $scope.Password = "";
    $scope.errorsVisible = false;
    $scope.errors = [];

    $scope.login = function () {
        $scope.clearErrors();
        $scope.$emit("login:requested", { UserName: $scope.UserName, Password: $scope.Password });
    };

    $scope.closeLoginDialog = function () {
        $scope.clearErrors();
        $scope.$emit("login:cancelled");
    };

    $scope.$on("login:failed", function (event, data) {
        $scope.errorsVisible = true;
        $scope.errors = data.Errors;
    });

    $scope.clearErrors = function () {
        $scope.errorsVisible = false;
        $scope.errors = [];
    };
} ]);