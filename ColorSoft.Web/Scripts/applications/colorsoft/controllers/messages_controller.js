ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.MessagesCtrl = function ($scope, $routeParams, Message) {
    $scope.messages = Message.query();
    $scope.selectedMessages = [];
    $scope.sortValue = 'CreatedAt';

    $scope.$on("messages:deleted", function (event, args) {
        _.each(args.messages, function (message) {
            $scope.messages.remove(message);
        });
    });

    $scope.anySelected = function () {
        return $scope.selectedMessages.length > 0;
    };

    $scope.allSelected = function () {
        return ($scope.messages.length > 0) &&
            ($scope.messages.length == $scope.selectedMessages.length);
    };

    $scope.toggleAllSelected = function () {
        var all = $scope.allSelected();
        if (all) {
            $scope.selectedMessages = [];
        } else {
            _.each($scope.messages, function (message) {
                $scope.selectedMessages.push(message);
            });
        }
    };

    $scope.updateSelection = function ($event, message) {
        var checkbox = $event.target;
        if (checkbox.checked) {
            $scope.selectedMessages.push(message);
        } else {
            $scope.selectedMessages.remove(message);
        }
    };

    $scope.isSelected = function (message) {
        return _.contains($scope.selectedMessages, message);
    };

    $scope.showDeleteDialog = function (message) {
        $scope.$broadcast("messages:show-delete-dialog", { messages: [message] });
    };

    $scope.showDeleteAllDialog = function () {
        var messages = $scope.selectedMessages;
        $scope.$broadcast("messages:show-delete-dialog", { messages: messages });
    };
}