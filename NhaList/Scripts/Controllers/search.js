angular
    .module('search', ['activity'])
    .controller('searchPageCtrlr', [
        '$scope', '$routeParams', 'activityService', function($scope, $routeParams, activityService) {
            $scope.noResults = false;

            $scope.handleSubmit = function() {
                $scope.searching = true;
                setTimeout(function() {
                    $scope.$apply(function () {
                        $scope.searching = false;
                        $scope.noResults = true;
                    });
                },1000);
            };

            activityService.retrieveSearch(
                $routeParams.nearBy,
                function(search) {
                    $scope.$apply(function() {
                        $scope.nearBy = search.nearBy;
                        $scope.handleSubmit();
                    });

                });


        }
    ]);