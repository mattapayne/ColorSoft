var colorsoftApplication = angular.module('colorSoft', ['ui']).
    config(['$routeProvider', 'TemplateUrls', '$locationProvider', '$httpProvider',
        function ($routeProvider, TemplateUrls, $locationProvider, $httpProvider) {
            $routeProvider.
                when('/', { templateUrl: TemplateUrls.HomeUrl, controller: 'HomeCtrl' }).
                when('/Dashboard', { templateUrl: TemplateUrls.DashboardUrl, controller: 'DashboardCtrl' }).
                when('/About', { templateUrl: TemplateUrls.AboutUrl, controller: 'AboutCtrl' }).
                when('/Contact', { templateUrl: TemplateUrls.ContactUrl, controller: 'ContactCtrl' }).
                when('/Register', { templateUrl: TemplateUrls.RegisterUrl, controller: 'RegisterCtrl' }).
                otherwise({ redirectTo: '/' });

            var interceptor = ['$rootScope', '$q', function ($rootScope, $q) {

                function success(response) {
                    return response;
                }

                function error(response) {
                    var status = response.status;
                    if (status == 401) {
                        var deferred = $q.defer();
                        var req = {
                            config: response.config,
                            deferred: deferred
                        };
                        $rootScope.requests401.push(req);
                        $rootScope.$broadcast("login:required");
                        return deferred.promise;
                    }
                    return $q.reject(response);
                }

                return function (promise) {
                    return promise.then(success, error);
                };
            } ];

            $httpProvider.responseInterceptors.push(interceptor);
        } ]).
    run(['$rootScope', '$http', 'ApplicationUrls', '$location', function ($rootScope, $http, ApplicationUrls, $location) {

        $rootScope.requests401 = [];
        $rootScope.loggedIn = false;
        $rootScope.userName = "";

        $rootScope.isLoggedIn = function () {
            return $rootScope.loggedIn == true;
        };

        $rootScope.$on("login:confirmed", function (event, data) {
            $rootScope.loggedIn = data.LoggedIn;
            $rootScope.userName = data.Username;

            var i, requests = $rootScope.requests401;
            for (i = 0; i < requests.length; i++) {
                retry(requests[i]);
            }

            $rootScope.requests401 = [];

            function retry(req) {
                $http(req.config).then(function (response) {
                    req.deferred.resolve(response);
                });
            }
        });

        $rootScope.$on("login:required", function () {
            $rootScope.loginDialogVisible = true;
        });

        $rootScope.$on("login:requested", function (event, args) {
            $http.post(ApplicationUrls.LoginUrl, { username: args.UserName, password: args.Password }).success(function (data) {
                if (data.LoggedIn) {
                    $rootScope.$broadcast("login:confirmed", data);
                    $rootScope.loginDialogVisible = false;
                } else {
                    $rootScope.$broadcast("login:failed", data);
                }
            });
        });

        $rootScope.$on("login:cancelled", function () {
            $rootScope.loginDialogVisible = false;
        });

        $rootScope.$on("logout:requested", function () {
            $http.post(ApplicationUrls.LogoutUrl).success(function () {
                $rootScope.loggedIn = false;
                $rootScope.userName = "";
                $location.path("/");
                ping();
            });
        });

        function ping() {
            $http.get(ApplicationUrls.LoginCheckUrl).success(function (data) {
                if (data.LoggedIn == true) {
                    $rootScope.$broadcast("login:confirmed", data);
                }
            });
        }

        ping();
    } ]);