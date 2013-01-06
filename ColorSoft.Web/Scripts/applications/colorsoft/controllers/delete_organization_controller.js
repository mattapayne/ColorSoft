angular.module("colorSoft").controller('DeleteOrganizationCtrl', ['$scope', 'OrganizationService',
    function ($scope, OrganizationService) {
        $scope.deleteDialogVisible = false;
        $scope.selectedOrganizations = [];
        $scope.errors = [];

        $scope.errorsVisible = function () {
            return $scope.errors.length > 0;
        };

        $scope.$on("organizations:show-delete-dialog", function (event, args) {
            $scope.selectedOrganizations = args.organizations;
            $scope.deleteDialogVisible = true;
            $scope.errors = [];
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
            $scope.errors = [];
        };

        $scope.deleteOrganizations = function () {
            if ($scope.selectedOrganizations.length > 0) {
                var orgs = $scope.selectedOrganizations;
                var ids = _.pluck(orgs, "Id");
                OrganizationService.remove(ids).success(function () {
                    $scope.closeDeleteDialog();
                    $scope.$emit("organizations:deleted", { organizations: orgs });
                }).error(function (response) {
                    $scope.errors = response;
                });
            }
        };
    } ]);