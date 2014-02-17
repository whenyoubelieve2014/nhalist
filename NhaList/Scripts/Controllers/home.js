angular.module('app', ['ngRoute', 'appRoutes', 'ngStorage', 'geocoder'])
    .controller('homeCtrlr', function($scope) {
        }
    ).controller('searchCtrlr', [
            '$scope', 'geocoderService', function ($scope, geocoderService) {
            $scope.handleSubmit = function() {
                if (!$scope.nearby) return false;
                $location.path('/search');
                return true;
            };
        }
        ]
    );