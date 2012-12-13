angular.module('colorsoftServices', ['ngResource']).
    factory('Message', function ($resource, $http) {
        var messageResource = $resource('api/messages/:action/:id', { id: '@id' }, {
            query: { method: 'GET', isArray: true },
            remove: { method: 'POST', params: { id: '@id', action: 'delete'} }
        });
        //since this is not a resourceful operation, we'll fallback on $http
        messageResource.removeAll = function (ids) {
            return $http.post('api/messages/deleteAll', ids);
        };
        return messageResource;
    }).
    factory('User', function ($resource, $http) {
        var userResource = $resource('api/users', {}, {
            query: { method: 'GET', isArray: true }
        });
        //since this is not a resourceful operation, we'll fallback on $http
        userResource.removeAll = function (ids) {
            return $http.post('api/users/deleteAll', ids);
        };
        return userResource;
    });