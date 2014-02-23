angular
    .module('home', [])
    .controller('homePageCtrlr', function() {})
    .controller('searchCtrlr', [
        '$scope', '$location', function($scope, $location) {
            $scope.handleSubmit = function() {
                if (!$scope.nearBy) return false;

                $location.path('/view/search/' + $scope.nearBy);
                return true;
            };
        }
    ])
    .controller('postCtrlr', [
        '$scope', '$timeout', function ($scope, $timeout) {
            $scope.handleSubmit = function() {
                $scope.validating = true;
                var isComplete = function () {
                    return $scope.validating && $scope.phone && $scope.email && $scope.nearBy && $scope.text;
                };
                var isValid = function() {
                    return true;
                };
                if (!isComplete() || !isValid()) return false;
                $scope.posting = true;

                $timeout(function() {
                    $scope.validating = false;
                    $scope.posted = true;
                }, 1000);
                return true;
            };
        }
    ]);