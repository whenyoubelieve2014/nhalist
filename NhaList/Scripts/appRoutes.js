angular.module('appRoutes', [])
    .config([
        '$routeProvider', '$locationProvider',
        function($routeProvider, $locationProvider) {

            $routeProvider

                // home page
                .when('/', {
                    templateUrl: '/Angular/Home',
                    controller: 'homeCtrlr'
                });

            //// nerds page that will use the NerdController
            //.when('/nerds', {
            //    templateUrl: 'views/partials/nerd.html',
            //    controller: 'NerdController'
            //})

            //// 
            //.when('/geeks', {
            //    templateUrl: 'views/partials/geek.html',
            //    controller: 'GeekController'
            //});

            $locationProvider.html5Mode(true);

        }
    ]);