angular.module('colorSoft').
    service("RolesService", ['$http', 'ApplicationUrls', function ($http, ApplicationUrls) {
        this.query = function () {
            return $http.get(ApplicationUrls.ListRolesUrl).then(function (response) {
                return response.data;
            });
        };
    } ]);