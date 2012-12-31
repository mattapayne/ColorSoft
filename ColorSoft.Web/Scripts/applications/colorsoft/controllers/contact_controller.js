angular.module('colorSoft').controller('ContactCtrl', ['$scope', 'MessageService', function ($scope, MessageService) {
    $scope.$emit("navigation:changed", { selectedTab: 'contact' });
    $scope.message = null;
    $scope.notifications = [];

    $scope.hasNotifications = function () {
        return $scope.notifications.length > 0;
    };

    $scope.messageSentSuccessfully = function () {
        return $scope.hasNotifications() && _.every($scope.notifications, function (notification) {
            return notification.success == true;
        });
    };

    $scope.getAlertClass = function () {
        return $scope.messageSentSuccessfully() ? "alert-success" : "alert-error";
    };

    $scope.submitMessage = function () {
        $scope.notifications = [];
        var model = MessageService.create($scope.message);
        model.$save({}, function () {
            //success
            $scope.notifications.push({
                success: true, value: "Successfully sent your message."
            });
            $scope.message = null;
        }, function (response) {
            //error
            $scope.notifications.push({
                success: false, value: response.data.Message
            });
        });
    };

    $scope.reset = function () {
        $scope.message = null;
        $scope.notifications = [];
    };

    $scope.isUnchanged = function () {
        return $scope.message == null;
    };

    $scope.isFormInvalid = function () {
        return $scope.form.$invalid;
    };
} ]);