angular.module('dashboard', ['ngResource']).
    factory('DashboardService', function($resource) {
        return $resource('api/dashboardpermissions/:action', { }, {
            query: { method: 'GET', isArray: true, params: { action: 'Index' } }
        });
    });