ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.MessagesCtrl = function ($scope, $routeParams, Message) {
    $scope.messages = Message.getAll();
}