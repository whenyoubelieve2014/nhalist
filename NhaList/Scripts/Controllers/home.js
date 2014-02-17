angular
    .module('home', ['activity'])
    .controller('homePageCtrlr', function() {})
    .controller('searchCtrlr', [
        '$scope', '$location', 'activityService', function($scope, $location, activityService) {
            $scope.handleSubmit = function() {
                if (!$scope.nearBy) return false;
                activityService.createSearch($scope.nearBy);
                $location.path('view/search');
                return true;
            };
        }
    ]);