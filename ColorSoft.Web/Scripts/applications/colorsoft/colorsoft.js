angular.module('colorsoft', ['colorsoftServices', 'ui']).config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/', { }).
        when('/Users', { templateUrl: 'Templates/users/index.html', controller: ColorSoft.Controllers.UsersCtrl }).
        when('/Messages', { templateUrl: 'Templates/messages/index.html', controller: ColorSoft.Controllers.MessagesCtrl }).
        otherwise({ redirectTo: '#/' });
} ]);