angular.module('messages', ['ngResource']).
    factory('MessageService', function ($resource, $http) {
        var res = $resource('api/:controller/:action', {}, {
            query: { method: 'GET', isArray: true, params: { action: "Index", controller: 'messages'} },
            remove: { method: 'DELETE', params: { id: '@Id', action: 'delete', controller: 'messages'} },
            save: { method: 'POST', params: { action: 'create', controller: 'contact'} },
            selected: false
        });
        //since this is not a resourceful operation, we'll fallback on $http
        res.removeAll = function (ids) {
            return $http.post('api/messages/deleteAll', ids);
        };

        res.create = function (args) {
            return new res(args);
        };

        res.prototype.isSelected = function () {
            return this.selected;
        };

        res.prototype.setSelected = function (selected) {
            this.selected = selected;
        };

        return res;
    });