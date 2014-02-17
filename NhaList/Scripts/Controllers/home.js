var app = angular.module('app', ['ngRoute', 'appRoutes', 'ngStorage', 'geocoder'])
    .controller('homeCtrlr', function($scope) {
        }
    );
app.controller('searchCtrlr', [
            '$scope', 'geocoderService', function ($scope, geocoderService) {
                console.log('geocoderService', geocoderService);
                //$scope.status = geocoderService.status();
            }
        ]
    );