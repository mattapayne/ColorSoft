ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.UsersCtrl = function ($scope, $routeParams, User) {
    $scope.users = User.query();
    $scope.deleteDialogVisible = false;
    $scope.addDialogVisible = false;
    $scope.newUser = null;

    $scope.showAddDialog = function () {
        $scope.newUser = new User();
        $scope.addDialogVisible = true;
    };

    $scope.closeAddDialog = function () {
        $scope.newUser = null;
        $scope.addDialogVisible = false;
    };

    $scope.createUser = function () {
        var user = $scope.newUser;
        if (user != null) {
            user.$save({}, function () {
                $scope.users.push(user);
                $scope.closeAddDialog();
            });
        }
    };
}