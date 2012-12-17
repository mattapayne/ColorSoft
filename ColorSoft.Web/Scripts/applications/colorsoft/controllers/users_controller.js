ColorSoft.Controllers = ColorSoft.Controllers || {};

ColorSoft.Controllers.UsersCtrl = function ($scope, $routeParams, User) {
    $scope.users = User.query();
    $scope.deleteDialogVisible = false;
    $scope.addDialogVisible = false;
    $scope.newUser = null;
    $scope.selectedUsers = [];
    $scope.allSelected = false;
    $scope.selectedUser = null;

    $scope.updateSelection = function ($event, user) {
        var checkbox = $event.target;
        if (checkbox.checked) {
            $scope.selectedUsers.push(user);
        } else {
            $scope.allSelected = false;
            $scope.selectedUsers.remove(user);
        }
    };

    $scope.saveUser = function (user) {
        user.$update({}, function () {
            user.setEditing(false);
        });
    };

    $scope.promptForDeleteAll = function () {
        $scope.deleteDialogVisible = true;
    };

    $scope.promptForDelete = function (user) {
        $scope.selectedUser = user;
        $scope.deleteDialogVisible = true;
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

    $scope.deleteAllSelected = function () {
        if ($scope.selectedUsers.length > 0) {
            var ids = _.pluck($scope.selectedUsers, "Id");
            User.removeAll(ids).success(function () {
                _.each($scope.selectedUsers, function (user) {
                    $scope.users.remove(user);
                });
                $scope.selectedUsers = [];
                $scope.closeDeleteDialog();
            });
        }
    };

    $scope.toggleAllSelected = function () {
        $scope.allSelected = !$scope.allSelected;
        $scope.selectedUsers = [];
        if ($scope.allSelected) {
            _.each($scope.users, function (user) {
                $scope.selectedUsers.push(user);
            });
        }
    };

    $scope.anySelected = function () {
        return $scope.selectedUsers.length > 0;
    };

    $scope.showAddDialog = function () {
        $scope.newUser = new User();
        $scope.addDialogVisible = true;
    };

    $scope.closeAddDialog = function () {
        $scope.newUser = null;
        $scope.addDialogVisible = false;
    };

    $scope.closeDeleteDialog = function () {
        $scope.selectedUser = null;
        $scope.deleteDialogVisible = false;
    };

    $scope.createUser = function () {
        var user = $scope.newUser;
        if (user != null) {
            user.$save({}, function () {
                $scope.users.push(user);
                $scope.closeAddDialog();
            });
        }
    };

    $scope.deleteUsers = function () {
        if ($scope.selectedUser != null) {
            var user = $scope.selectedUser;
            user.$remove({ Id: user.Id }, function () {
                $scope.users.remove(user);
                $scope.selectedUsers.remove(user);
                $scope.selectedUser = null;
                $scope.closeDeleteDialog();
            });
        } else if ($scope.selectedUsers.length > 0) {
            $scope.deleteAllSelected();
        }
    };
}