angular.module("colorSoft").controller('DeleteOrganizationCtrl', ['$scope', 'OrganizationService',
    function($scope, OrganizationService) {
        $scope.deleteDialogVisible = false;
        $scope.selectedOrganizations = [];

        $scope.$on("organizations:show-delete-dialog", function (event, args) {
            $scope.selectedOrganizations = args.organizations;
            $scope.deleteDialogVisible = true;
        });

        $scope.selectedOrganizationNames = function () {
            return _.map($scope.selectedOrganizations,
            function (org) {
                return org.Name;
            }).join(" and ");
        };

        $scope.closeDeleteDialog = function () {
            $scope.selectedOrganizations = [];
            $scope.deleteDialogVisible = false;
        };

        $scope.deleteUsers = function () {
            if ($scope.selectedOrganizations.length > 0) {
                var orgs = $scope.selectedOrganizations;
                var ids = _.pluck(orgs, "Id");
                OrganizationService.removeAll(ids).success(function () {
                    $scope.$emit("organizations:deleted", { organizations: orgs });
                    $scope.selectedOrganizations = [];
                    $scope.closeDeleteDialog();
                });
            }
        };
    }]);