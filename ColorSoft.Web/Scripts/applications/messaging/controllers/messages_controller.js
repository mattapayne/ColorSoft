Messaging.Controllers = Messaging.Controllers || {};

Messaging.Controllers.MessagesCtrl = function ($scope, Message) {
    $scope.master = new Message();

    $scope.submit = function (message) {
        $scope.master = angular.copy(message);
        $scope.master.$save();
    };

    $scope.reset = function() {
        $scope.message = angular.copy($scope.master);
    };

    $scope.isUnchanged = function (message) {
        return angular.equals(message, $scope.master);
    };

    $scope.disableFormSubmit = function (message) {
        return $scope.form.$invalid || $scope.isUnchanged(message);
    };
};
