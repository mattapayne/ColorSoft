ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.MessagesCtrl = function ($scope, $routeParams, Message) {
    $scope.messages = Message.query();

    $scope.deleteDialogVisible = false;
    $scope.currentMessage = null;
    $scope.allSelected = false;
    $scope.selectedMessages = [];

    $scope.anySelected = function () {
        return $scope.selectedMessages.length > 0;
    };

    $scope.toggleAllSelected = function () {
        $scope.allSelected = !$scope.allSelected;
        $scope.selectedMessages = [];
        if ($scope.allSelected) {
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
            $scope.allSelected = false;
            $scope.selectedMessages.remove(message);
        }
    };

    $scope.isSelected = function (message) {
        return _.contains($scope.selectedMessages, message);
    };

    $scope.showDeleteDialog = function (message) {
        $scope.deleteDialogVisible = true;
        $scope.currentMessage = message;
    };

    $scope.closeDeleteDialog = function () {
        $scope.deleteDialogVisible = false;
        $scope.currentMessage = null;
    };

    $scope.deleteCurrentMessage = function () {
        if ($scope.currentMessage != null) {
            var message = $scope.currentMessage;
            $scope.currentMessage.$remove({}, (function () {
                $scope.messages.remove(message);
            }));
        }
        $scope.closeDeleteDialog();
    };

    $scope.deleteAllSelected = function () {
        if ($scope.selectedMessages.length > 0) {
            var ids = _.pluck($scope.selectedMessages, "Id");
            Message.removeAll(ids).success(function () {
                _.each($scope.selectedMessages, function (message) {
                    $scope.messages.remove(message);
                });
                $scope.selectedMessages = [];
            });
        }
    };
}