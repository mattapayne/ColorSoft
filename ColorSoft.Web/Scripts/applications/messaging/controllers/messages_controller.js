window.Messaging = window.Messaging || {};

Messaging.Controllers = Messaging.Controllers || {};

Messaging.Controllers.MessagesCtrl = function ($scope, Message) {
    $scope.master = {};

    $scope.submit = function (message) {
        $scope.master = angular.copy(message);
        var model = new Message($scope.master);
        model.$save({}, function () {
            alert("Saved");
        });
    };

    $scope.reset = function () {
        $scope.message = angular.copy($scope.master);
    };

    $scope.isUnchanged = function (message) {
        return angular.equals(message, $scope.master);
    };

    $scope.disableFormSubmit = function (message) {
        return $scope.form.$invalid || $scope.isUnchanged(message);
    };
};
