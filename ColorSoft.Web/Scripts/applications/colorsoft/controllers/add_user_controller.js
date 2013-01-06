angular.module("colorSoft").controller('AddUserCtrl', ['$scope', '$routeParams', 'UserService', 'OrganizationService', 'User',
    function ($scope, $routeParams, UserService, OrganizationService, User) {
        $scope.user = null;
        $scope.addDialogVisible = false;
        $scope.errors = [];
        $scope.organizations = [];

        OrganizationService.query().then(function (response) {
            $scope.organizations = response;
        });

        $scope.$on("users:show-add-dialog", function () {
            $scope.user = new User();
            $scope.addDialogVisible = true;
            $scope.errors = [];
        });

        $scope.errorsVisible = function () {
            return $scope.errors.length > 0;
        };

        $scope.closeAddDialog = function () {
            $scope.user = null;
            $scope.addDialogVisible = false;
            $scope.errors = [];
        };

        $scope.createUser = function () {
            var user = $scope.user;
            if (user != null) {
                UserService.save(user).success(function (response) {
                    user.Id = response.NewID;
                    $scope.closeAddDialog();
                    $scope.$emit("users:created", { user: user });
                }).error(function (response) {
                    $scope.errors = response;
                });
            }
        };
    } ]);