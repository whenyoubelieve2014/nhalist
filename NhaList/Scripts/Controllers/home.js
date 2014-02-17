angular.module('app', ['ngRoute', 'appRoutes'])
    .controller('homeCtrlr', [
        '$scope', function($scope) {
        }
    ])
    .controller('searchCtrlr', [
        '$scope', function($scope) {
            $scope.status = 'Dang Dinh Nghia';
        }
    ]);