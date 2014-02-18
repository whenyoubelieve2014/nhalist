angular
    .module('home', [])
    .controller('homePageCtrlr', function() {})
    .controller('searchCtrlr', [
        '$scope', '$location',  function($scope, $location) {
            $scope.handleSubmit = function() {
                if (!$scope.nearBy) return false;
                
                $location.path('/view/search/' + $scope.nearBy);
                return true;
            };
        }
    ]);