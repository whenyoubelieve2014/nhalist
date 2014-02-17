angular.module('appRoutes', [])
    .config([
        '$routeProvider', '$locationProvider',
        function($routeProvider, $locationProvider) {

            $routeProvider

                // home page
                .when('/', {
                    templateUrl: '/Angular/Home',
                    controller: 'homeCtrlr'
                })
                // search page
                .when('/search', {
                    templateUrl: '/Angular/Search',
                    controller: 'searchCtrlr'
                });

            $locationProvider.html5Mode(true);

        }
    ]);