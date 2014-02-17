angular.module('appRoutes', [])
    .config([
        '$routeProvider', '$locationProvider',
        function($routeProvider, $locationProvider) {

            $routeProvider

                // home page
                .when('/', {
                    templateUrl: '/Angular/Home',
                    controller: 'homePageCtrlr'
                })
                // search page
                .when('/search', {
                    templateUrl: '/Angular/Search',
                    controller: 'searchPageCtrlr'
                })
            ;

            $locationProvider.html5Mode(true);

        }
    ]);