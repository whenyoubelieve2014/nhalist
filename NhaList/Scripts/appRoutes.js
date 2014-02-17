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
                .when('/view/search/:nearBy', {
                    templateUrl: '/Angular/Search',
                    controller: 'searchPageCtrlr'
                })
            ;

            $locationProvider.html5Mode(true);

        }
    ]);