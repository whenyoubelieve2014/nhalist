angular
    .module('search', ['ajax', 'geocoder'])
    .controller('searchPageCtrlr', [
        '$scope', '$routeParams', 'geocoderService', '$location', 'ajaxService',
        function ($scope, $routeParams, geocoderService, $location, ajaxService) {
            $scope.handleSubmit = function() {
                $location.path('/view/search/' + $scope.nearBy);
            };
            if ($routeParams.nearBy && $routeParams.nearBy !== $scope.nearBy)
                $scope.nearBy = $routeParams.nearBy;
            if ($scope.nearBy) {
                $scope.searching = true;
                geocoderService.getLatLong($scope.nearBy, function(latLongs, status) {
                    $scope.noGeoResults = !geocoderService.validate(latLongs, status);
                    if (!$scope.noGeoResults) {
                        geocoderService.getBoundary(latLongs, function (boundary) {
                            ajaxService.postSearch(boundary, function(collection) {
                                if (collection && collection.Count) {
                                    $scope.posts = collection.Posts;
                                    $scope.count = collection.Count;
                                    $scope.searching = false;
                                }
                            });
                        });
                    } else {
                        $scope.searching = false;
                    }
                });
            }
        }
    ]);