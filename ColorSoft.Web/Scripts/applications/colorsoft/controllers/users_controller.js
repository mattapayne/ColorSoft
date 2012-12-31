angular.module('colorSoft').controller('UsersCtrl', ['$scope', 'UserService', function ($scope, UserService) {
    $scope.users = UserService.query();
    $scope.sortValue = 'CreatedAt';

    $scope.showAddDialog = function () {
        $scope.$broadcast("users:show-add-dialog");
    };

    $scope.selectedUsers = function () {
        return _.filter($scope.users, function (user) {
            return user.isSelected();
        });
    };

    $scope.showDeleteDialog = function (user) {
        $scope.$broadcast("users:show-delete-dialog", { users: [user] });
    };

    $scope.showDeleteAllDialog = function () {
        $scope.$broadcast("users:show-delete-dialog", { users: $scope.selectedUsers() });
    };

    $scope.allSelected = function () {
        return $scope.users.length > 0 && _.every($scope.users, function (user) {
            return user.isSelected();
        });
    };

    $scope.$on("users:created", function (event, args) {
        $scope.users.push(args.user);
    });

    $scope.$on("users:deleted", function (event, args) {
        $scope.users = _.removalAll($scope.users, args.users, function (item, itemToRemove) {
            return item.Id == itemToRemove.Id;
        });
    });

    $scope.updateSelection = function ($event, user) {
        var checkbox = $event.target;
        user.setSelected(checkbox.checked);
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

    $scope.toggleAllSelected = function () {
        var allCurrentlySelected = $scope.allSelected();
        _.each($scope.users, function (user) {
            user.setSelected(!allCurrentlySelected);
        });
    };

    $scope.anySelected = function () {
        return $scope.selectedUsers().length > 0;
    };
} ]);