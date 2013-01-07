angular.module("colorSoft").controller('AddOrganizationCtrl', ['$scope', 'OrganizationService', 'Organization',
    function ($scope, OrganizationService, Organization) {

        $scope.organization = null;
        $scope.addDialogVisible = false;
        $scope.errors = [];

        $scope.errorsVisible = function () {
            return $scope.errors.length > 0;
        };

        $scope.$on("organizations:show-add-dialog", function () {
            $scope.organization = new Organization();
            $scope.addDialogVisible = true;
            $scope.errors = [];
        });

        $scope.closeAddDialog = function () {
            $scope.organization = null;
            $scope.addDialogVisible = false;
            $scope.errors = [];
        };

        $scope.createOrganization = function () {
            var org = $scope.organization;
            OrganizationService.save(org).success(function (response) {
                org = new Organization(response);
                $scope.closeAddDialog();
                $scope.$emit("organizations:created", { organization: org });
            }).error(function (response) {
                $scope.errors = response;
            });
        };
    } ]);