angular.module('colorSoft').controller('OrganizationsCtrl', ['$scope', 'OrganizationService', function($scope, OrganizationService) {
    $scope.organizations = OrganizationService.query();
    $scope.sortValue = 'Name';

    $scope.showAddDialog = function () {
        $scope.$broadcast("organizations:show-add-dialog");
    };

    $scope.selectedOrganizations = function () {
        return _.filter($scope.organizations, function (org) {
            return org.isSelected();
        });
    };

    $scope.showDeleteDialog = function (org) {
        $scope.$broadcast("organizations:show-delete-dialog", { organizations: [org] });
    };

    $scope.showDeleteAllDialog = function () {
        $scope.$broadcast("organizations:show-delete-dialog", { organizations: $scope.selectedOrganizations() });
    };

    $scope.allSelected = function () {
        return $scope.organizations.length > 0 && _.every($scope.organizations, function (org) {
            return org.isSelected();
        });
    };

    $scope.$on("organizations:created", function (event, args) {
        $scope.organizations.push(args.organization);
    });

    $scope.$on("organizations:deleted", function (event, args) {
        $scope.organizations = _.removalAll($scope.organizations, args.organizations, function (item, itemToRemove) {
            return item.Id == itemToRemove.Id;
        });
    });

    $scope.updateSelection = function ($event, org) {
        var checkbox = $event.target;
        org.setSelected(checkbox.checked);
    };

    $scope.saveOrganization = function (org) {
        org.$update({}, function () {
            org.setEditing(false);
        });
    };

    $scope.editOrganization = function (org) {
        org.setEditing(true);
    };

    $scope.cancelEdit = function (org) {
        org.setEditing(false);
    };

    $scope.toggleAllSelected = function () {
        var allCurrentlySelected = $scope.allSelected();
        _.each($scope.organizations, function (org) {
            org.setSelected(!allCurrentlySelected);
        });
    };

    $scope.anySelected = function () {
        return $scope.selectedOrganizations().length > 0;
    };
}]);