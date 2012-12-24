ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.UsersCtrl = function ($scope, $routeParams, User) {
    $scope.users = User.query();
    $scope.selectedUsers = [];
    $scope.sortValue = 'CreatedAt';

    $scope.showAddDialog = function () {
        $scope.$broadcast("users:show-add-dialog");
    };

    $scope.showDeleteDialog = function (user) {
        $scope.$broadcast("users:show-delete-dialog", { users: [user] });
    };

    $scope.showDeleteAllDialog = function () {
        var users = $scope.selectedUsers;
        $scope.$broadcast("users:show-delete-dialog", { users: users });
    };

    $scope.allSelected = function () {
        return ($scope.users.length > 0) && ($scope.users.length == $scope.selectedUsers.length);
    };

    $scope.$on("users:created", function (event, args) {
        $scope.users.push(args.user);
    });

    $scope.$on("users:deleted", function (event, args) {
        _.each(args.users, function (user) {
            $scope.users.remove(user);
        });
    });

    $scope.updateSelection = function ($event, user) {
        var checkbox = $event.target;
        if (checkbox.checked) {
            $scope.selectedUsers.push(user);
        } else {
            $scope.selectedUsers.remove(user);
        }
    };

    $scope.saveUser = function (user) {
        user.$update({}, function () {
            user.setEditing(false);
        });
    };

    $scope.editUser = function (user) {
        user.setEditing(true);
    };

    $scope.cancelEdit = function (user) {
        user.setEditing(false);
    };

    $scope.isSelected = function (user) {
        return _.contains($scope.selectedUsers, user);
    };

    $scope.toggleAllSelected = function () {
        var all = $scope.allSelected();
        if (all) {
            $scope.selectedUsers = [];
        } else {
            _.each($scope.users, function (user) {
                $scope.selectedUsers.push(user);
            });
        }
    };

    $scope.anySelected = function () {
        return $scope.selectedUsers.length > 0;
    };
}