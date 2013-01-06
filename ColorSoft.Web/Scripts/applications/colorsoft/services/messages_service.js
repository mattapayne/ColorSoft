angular.module('colorSoft').
    service("MessageService", ['$http', 'ApplicationUrls', 'Message', function ($http, ApplicationUrls, Message) {
        this.query = function () {
            return $http.get(ApplicationUrls.ListMessagesUrl).then(function (response) {
                return _.map(response.data, function (r) {
                    return new Message(r);
                });
            });
        };

        this.remove = function (ids) {
            if (!angular.isArray(ids)) {
                ids = [ids];
            }
            return $http.post(ApplicationUrls.DeleteMessagesUrl, angular.toJson(ids));
        };
    } ]);