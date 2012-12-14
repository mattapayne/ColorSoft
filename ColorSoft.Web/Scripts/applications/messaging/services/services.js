angular.module('messagingServices', ['ngResource']).
    factory('Message', function($resource) {
        return $resource('api/contact/create');
    });