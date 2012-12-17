angular.module('colorsoftServices', ['ngResource']).
    factory('Message', function ($resource, $http) {
        var messageResource = $resource('api/messages', {}, {
            query: { method: 'GET', isArray: true, params: { action: "Index"} },
            remove: { method: 'DELETE', params: { id: '@Id', action: 'delete'} },
            save: { method: 'POST', params: { action: 'create'} },
            update: { method: 'PUT', params: { action: 'update'} }
        });
        //since this is not a resourceful operation, we'll fallback on $http
        messageResource.removeAll = function (ids) {
            return $http.post('api/messages/deleteAll', ids);
        };
        return messageResource;
    }).
    factory('User', function ($resource, $http) {
        var userResource = $resource('api/users/:action/:id', {}, {
            query: { method: 'GET', isArray: true, params: { action: "Index"} },
            save: { method: 'POST', params: { action: 'create'} },
            update: { method: 'PUT', params: { action: 'update'} },
            remove: { method: 'DELETE', params: { action: 'delete', id: '@Id'} },
            editing: false
        });

        //since this is not a resourceful operation, we'll fallback on $http
        userResource.removeAll = function (ids) {
            return $http.post('api/users/deleteAll', ids);
        };

        //define some properties on the model
        userResource.prototype.inEditMode = function () {
            return this.editing;
        };

        userResource.prototype.inViewMode = function () {
            return !this.editing;
        };

        userResource.prototype.setEditing = function (editing) {
            this.editing = editing;
        };
        return userResource;
    });