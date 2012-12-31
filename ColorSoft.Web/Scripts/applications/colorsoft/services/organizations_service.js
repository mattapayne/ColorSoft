angular.module('organizations', ['ngResource']).
    factory('OrganizationService', function ($resource) {
        var res = $resource('api/organizations/:action/:id', {}, {
            query: { method: 'GET', isArray: true, params: { action: 'Index'} },
            save: { method: 'POST', params: { action: 'create'} },
            update: { method: 'PUT', params: { action: 'update'} },
            remove: { method: 'DELETE', params: { action: 'delete', id: '@Id'} },
            editing: false,
            selected: false
        });

        //since this is not a resourceful operation, we'll fallback on $http
        res.removeAll = function (ids) {
            return $http.post('api/organizations/deleteAll', ids);
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

        res.prototype.inEditMode = function () {
            return this.editing;
        };

        res.prototype.inViewMode = function () {
            return !this.editing;
        };

        res.prototype.setEditing = function (editing) {
            this.editing = editing;
        };

        return res;
    });