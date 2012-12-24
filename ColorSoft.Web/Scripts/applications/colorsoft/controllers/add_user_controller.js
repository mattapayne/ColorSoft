ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.AddUserCtrl = function ($scope, $routeParams, User) {
    $scope.newUser = null;
    $scope.addDialogVisible = false;

    $scope.$on("users:show-add-dialog", function () {
        $scope.newUser = new User();
        $scope.addDialogVisible = true;
    });

    $scope.closeAddDialog = function () {
        $scope.newUser = null;
        $scope.addDialogVisible = false;
    };

    $scope.createUser = function () {
        var user = $scope.newUser;
        if ($scope.newUser != null) {
            $scope.newUser.$save({}, function () {
                $scope.closeAddDialog();
                $scope.$emit("users:created", { user: user });
            });
        }
    };
};