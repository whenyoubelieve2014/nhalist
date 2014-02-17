angular
    .module('home', [])
    .controller('homePageCtrlr', function() {})
    .controller('searchCtrlr', [
        '$scope', '$location', function ($scope, $location) {
            $scope.handleSubmit = function() {
                if (!$scope.nearby) return false;
                $location.path('/search');
                return true;
            };
        }
    ]);