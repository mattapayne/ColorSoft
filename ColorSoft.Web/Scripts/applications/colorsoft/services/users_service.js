angular.module('colorSoft').
    service("UserService", ['$http', 'ApplicationUrls', 'User', function ($http, ApplicationUrls, User) {
        this.query = function () {
            return $http.get(ApplicationUrls.ListUsersUrl).then(function (response) {
                return _.map(response.data, function (r) {
                    return new User(r);
                });
            });
        };

        this.save = function (user) {
            return $http.post(ApplicationUrls.CreateUserUrl, user.asJson());
        };

        this.update = function (user) {
            return $http.put(ApplicationUrls.UpdateUserUrl, user.asJson());
        };

        this.remove = function (ids) {
            if (!angular.isArray(ids)) {
                ids = [ids];
            }
            return $http.post(ApplicationUrls.DeleteUsersUrl, angular.toJson(ids));
        };
        
    } ]);