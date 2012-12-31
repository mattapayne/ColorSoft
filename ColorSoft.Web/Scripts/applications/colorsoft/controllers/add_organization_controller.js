angular.module("colorSoft").controller('AddOrganizationCtrl', ['$scope', 'OrganizationService',
    function($scope, OrganizationService) {
        $scope.organization = null;
        $scope.addDialogVisible = false;

        $scope.$on("organizations:show-add-dialog", function () {
            $scope.organization = new OrganizationService.create();
            $scope.addDialogVisible = true;
        });

        $scope.closeAddDialog = function () {
            $scope.organization = null;
            $scope.addDialogVisible = false;
        };

        $scope.createOrganization = function () {
            var org = $scope.organization;
            if (org != null) {
                org.$save({}, function () {
                    $scope.closeAddDialog();
                    $scope.$emit("organizations:created", { organization: org });
                });
            }
        };
    }]);