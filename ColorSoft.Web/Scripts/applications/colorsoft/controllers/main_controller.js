angular.module('colorSoft').controller('MainCtrl', ['$scope', function ($scope) {
    $scope.currentNavTab = "";

    $scope.$on("navigation:changed", function (event, args) {
        $scope.currentNavTab = args.selectedTab;
    });

    $scope.promptForLogin = function () {
        $scope.$emit("login:required");
    };

    $scope.logout = function () {
        $scope.$emit("logout:requested");
    };

    $scope.isCurrentNavigationItem = function (navigationItem) {
        return $scope.currentNavTab == navigationItem;
    };

    $scope.getNavigationItemClass = function (navigationItem) {
        return $scope.isCurrentNavigationItem(navigationItem) ? "active" : "";
    };

} ]);