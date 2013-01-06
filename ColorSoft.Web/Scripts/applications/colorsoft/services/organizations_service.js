angular.module('colorSoft').
    service("OrganizationService", ['$http', 'ApplicationUrls', 'Organization', function ($http, ApplicationUrls, Organization) {
        this.query = function () {
            return $http.get(ApplicationUrls.ListOrganizationsUrl).then(function (response) {
                return _.map(response.data, function (r) {
                    return new Organization(r);
                });
            });
        };

        this.save = function (organization) {
            return $http.post(ApplicationUrls.CreateOrganizationUrl, organization.asJson());
        };

        this.update = function (organization) {
            return $http.put(ApplicationUrls.UpdateOrganizationUrl, organization.asJson());
        };

        this.remove = function (ids) {
            if (!angular.isArray(ids)) {
                ids = [ids];
            }
            return $http.post(ApplicationUrls.DeleteOrganizationsUrl, angular.toJson(ids));
        };
    } ]);
    
        