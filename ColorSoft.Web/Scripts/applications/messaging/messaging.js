angular.module('messaging', ['messagingServices', 'ui.directives']).config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', { templateUrl: 'Templates/messages/new.html', controller: Messaging.Controllers.MessagesCtrl });
} ]);