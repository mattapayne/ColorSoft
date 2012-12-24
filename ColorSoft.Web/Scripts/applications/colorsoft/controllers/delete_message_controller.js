ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.DeleteMessageCtrl = function ($scope, $routeParams, Message) {
    $scope.selectedMessages = [];
    $scope.deleteDialogVisible = false;

    $scope.$on("messages:show-delete-dialog", function (event, args) {
        $scope.selectedMessages = args.messages;
        $scope.deleteDialogVisible = true;
    });

    $scope.deleteMessagesText = function () {
        var prefix = "Are you sure you want to delete ";
        var ending = $scope.selectedMessages.length > 1 ? "these messages?" : "this message?";
        return prefix + ending;
    };

    $scope.closeDeleteDialog = function () {
        $scope.deleteDialogVisible = false;
        $scope.selectedMessages = [];
    };

    $scope.deleteMessages = function () {
        if ($scope.selectedMessages.length > 0) {
            var messages = $scope.selectedMessages;
            var ids = _.pluck($scope.selectedMessages, "Id");
            Message.removeAll(ids).success(function () {
                $scope.$emit("messages:deleted", { messages: messages });
                $scope.closeDeleteDialog();
            });
        }
    };
};