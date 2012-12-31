angular.module('colorSoft').controller('AboutCtrl', ['$scope', function($scope) {
    $scope.$emit("navigation:changed", { selectedTab: 'about' });
}]);