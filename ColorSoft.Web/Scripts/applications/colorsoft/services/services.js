angular.module('colorsoftServices', ['ngResource']).
    factory('Message', function ($resource) {
        return $resource('api/messages', {}, {
            getAll: { method: 'GET', isArray: true }
        });
    }).
    factory('User', function ($resource) {
        return $resource('api/users', {}, {
            getAll: { method: 'GET', isArray: true }
        });
    });