angular.module('colorSoft').
    service("DashboardService", ['$http', 'ApplicationUrls', function ($http, ApplicationUrls) {
        this.query = function () {
            return $http.get(ApplicationUrls.ListDashboardPermissionsUrl);
        };
    } ]);