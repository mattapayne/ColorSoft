angular.module('colorSoft').controller('MessagesCtrl', ['$scope', 'MessageService', function ($scope, MessageService) {
    $scope.messages = [];

    MessageService.query().then(function (result) {
        $scope.messages = result;
    });

    $scope.sortValue = 'CreatedAt';
    $scope.reverseSort = true;

    $scope.$on("messages:deleted", function (event, args) {
        $scope.messages = _.removalAll($scope.messages, args.messages, function (item, itemToRemove) {
            return item.Id == itemToRemove.Id;
        });
    });

    $scope.selectedMessages = function () {
        return _.filter($scope.messages, function (msg) {
            return msg.isSelected();
        });
    };

    $scope.anySelected = function () {
        return $scope.selectedMessages().length > 0;
    };

    $scope.allSelected = function () {
        return $scope.messages.length > 0 && _.every($scope.messages, function (msg) {
            return msg.isSelected();
        });
    };

    $scope.toggleAllSelected = function () {
        var allCurrentlySelected = $scope.allSelected();
        _.each($scope.messages, function (message) {
            message.setSelected(!allCurrentlySelected);
        });
    };

    $scope.updateSelection = function ($event, message) {
        var checkbox = $event.target;
        message.setSelected(checkbox.checked);
    };

    $scope.showDeleteDialog = function (message) {
        $scope.$broadcast("messages:show-delete-dialog", { messages: [message] });
    };

    $scope.showDeleteAllDialog = function () {
        $scope.$broadcast("messages:show-delete-dialog", { messages: $scope.selectedMessages() });
    };
} ]);