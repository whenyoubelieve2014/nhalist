angular
    .module('search', ['geocoder'])
    .controller('searchPageCtrlr', [
        '$scope', '$routeParams', 'geocoderService', '$location', 
        function($scope, $routeParams, geocoderService, $location) {
            $scope.nearBy = $routeParams.nearBy;
            $scope.handleSubmit = function() {
                $location.path('/view/search/' + $scope.nearBy);
            };
            if ($scope.nearBy) {
                $scope.searching = true;
                geocoderService.getLatLong($scope.nearBy, function (results, status) {
                    try {
                        $scope.searching = false;
                        $scope.noResults = !geocoderService.validate(results, status);
                    } catch (e) {
                        console.log('here');
                    }
                   
                    //geocoderService.getBoundary(results, function(boundary) {
                    //    console.log(boundary);
                    //});
                });
            }
        }
    ]);