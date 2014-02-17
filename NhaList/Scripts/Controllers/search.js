angular
    .module('search', ['activity'])
    .controller('searchPageCtrlr', [
        '$scope', 'activityService', function($scope, activityService) {
            $scope.nearBy = activityService.retrieveSearch();
        }
    ]);