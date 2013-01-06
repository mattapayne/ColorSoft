angular.module('colorSoft').controller('DashboardCtrl', ['$scope', 'DashboardService',
    function ($scope, DashboardService) {

        $scope.$emit("navigation:changed", { selectedTab: 'dashboard' });
        $scope.templates = [];

        DashboardService.query().success(function (result) {
            $scope.templates = result;
        });

        $scope.setView = function (id) {
            $scope.selectedTemplate = _.find($scope.templates, function (tmp) {
                return tmp.Id == id;
            });
        };
    } ]);