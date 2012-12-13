ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.UsersCtrl = function ($scope, $routeParams, User) {
    $scope.users = User.getAll();
}