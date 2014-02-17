﻿angular.module('appRoutes', [])
    .config([
        '$routeProvider', '$locationProvider',
        function($routeProvider, $locationProvider) {

            $routeProvider

                // home page
                .when('/', {
                    templateUrl: '/Angular/Home',
                    controller: 'homeCtrlr'
                });

            $locationProvider.html5Mode(true);

        }
    ]);