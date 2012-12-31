angular.module("colorSoft").controller('AddUserCtrl', ['$scope', '$routeParams', 'UserService', 'OrganizationService',
    function ($scope, $routeParams, UserService, OrganizationService) {
    $scope.user = null;
    $scope.addDialogVisible = false;
    $scope.organizations = OrganizationService.query();
    
    $scope.$on("users:show-add-dialog", function () {
        $scope.user = new UserService.create();
        $scope.addDialogVisible = true;
    });

    $scope.closeAddDialog = function () {
        $scope.user = null;
        $scope.addDialogVisible = false;
    };

    $scope.createUser = function () {
        var user = $scope.user;
        if (user != null) {
            user.$save({}, function () {
                $scope.closeAddDialog();
                $scope.$emit("users:created", { user: user });
            });
        }
    };
} ]);