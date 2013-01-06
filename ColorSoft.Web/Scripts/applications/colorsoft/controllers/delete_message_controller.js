angular.module('colorSoft').controller('DeleteMessageCtrl', ['$scope', 'MessageService', function ($scope, MessageService) {
    $scope.selectedMessages = [];
    $scope.deleteDialogVisible = false;
    $scope.errors = [];

    $scope.errorsVisible = function () {
        return $scope.errors.length > 0;
    };

    $scope.$on("messages:show-delete-dialog", function (event, args) {
        $scope.selectedMessages = args.messages;
        $scope.deleteDialogVisible = true;
        $scope.errors = [];
    });

    $scope.deleteMessagesText = function () {
        var prefix = "Are you sure you want to delete ";
        var ending = $scope.selectedMessages.length > 1 ? "these messages?" : "this message?";
        return prefix + ending;
    };

    $scope.closeDeleteDialog = function () {
        $scope.deleteDialogVisible = false;
        $scope.selectedMessages = [];
        $scope.errors = [];
    };

    $scope.deleteMessages = function() {
        if ($scope.selectedMessages.length > 0) {
            var messages = $scope.selectedMessages;
            var ids = _.pluck($scope.selectedMessages, "Id");
            MessageService.remove(ids).success(function() {
                $scope.closeDeleteDialog();
                $scope.$emit("messages:deleted", { messages: messages });
            }).error(function(response) {
                $scope.errors = response;
            });
        }
    };
} ]);