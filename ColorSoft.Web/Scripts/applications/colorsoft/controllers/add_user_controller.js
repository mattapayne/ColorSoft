angular.module("colorSoft").controller('AddUserCtrl', ['$scope', '$routeParams', 'UserService', 'OrganizationService', 'RolesService', 'User',
    function ($scope, $routeParams, UserService, OrganizationService, RolesService, User) {
        $scope.user = null;
        $scope.addDialogVisible = false;
        $scope.errors = [];
        $scope.organizations = [];
        $scope.roles = [];

        OrganizationService.query().then(function (response) {
            $scope.organizations = response;
        });

        RolesService.query().then(function (response) {
            $scope.roles = response;
        });

        $scope.$on("users:show-add-dialog", function () {
            $scope.user = new User();
            $scope.addDialogVisible = true;
            $scope.errors = [];
        });

        $scope.isColorSoftAdmin = function () {
            if ($scope.user == null || $scope.roles.length == 0) {
                return false;
            }
            
            var colorsoftAdminRole = _.find($scope.roles, function (role) {
                return role.Rank == 0;
            });

            return $scope.user.RoleId == colorsoftAdminRole.Id;
        };

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
                    user = new User(response);
                    $scope.closeAddDialog();
                    $scope.$emit("users:created", { user: user });
                }).error(function (response) {
                    $scope.errors = response;
                });
            }
        };
    } ]);