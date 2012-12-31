angular.module('colorSoft').controller('DeleteUserCtrl', ['$scope', 'UserService', function ($scope, UserService) {
    $scope.deleteDialogVisible = false;
    $scope.selectedUsers = [];

    $scope.$on("users:show-delete-dialog", function(event, args) {
        $scope.selectedUsers = args.users;
        $scope.deleteDialogVisible = true;
    });

    $scope.selectedUserNames = function() {
        return _.map($scope.selectedUsers,
            function(user) {
                return user.FullName();
            }).join(" and ");
    };

    $scope.closeDeleteDialog = function() {
        $scope.selectedUsers = [];
        $scope.deleteDialogVisible = false;
    };

    $scope.deleteUsers = function() {
        if ($scope.selectedUsers.length > 0) {
            var users = $scope.selectedUsers;
            var ids = _.pluck(users, "Id");
            UserService.removeAll(ids).success(function () {
                $scope.$emit("users:deleted", { users: users });
                $scope.selectedUsers = [];
                $scope.closeDeleteDialog();
            });
        }
    };
}]);