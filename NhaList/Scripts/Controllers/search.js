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
                geocoderService.getLatLong($scope.nearBy, function(latLongs, status) {
                    $scope.noGeoResults = !geocoderService.validate(latLongs, status, 'setting $scope.noGeoResults');
                    if ($scope.noGeoResults) return;
                    geocoderService.getBoundary(latLongs, function (boundary) {
                        ajaxService.postSearch(boundary, function (collection) {
                            if (collection && collection.Count) {
                                $scope.posts = collection.Posts;
                                $scope.count = collection.Count;
                            }
                        });
                    });
                });
            }
        }
    ]);