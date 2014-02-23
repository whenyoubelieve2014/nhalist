angular
    .module('home', ['ajax'])
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
        '$scope', '$timeout', 'ajaxService', function ($scope, $timeout, ajaxService) {
            $scope.handleSubmit = function() {
                $scope.validating = true;
                var count = 0;
                $scope.updateAddress = function () {
                    $scope.formattedAddress = ++count;
                    $scope.noGeoResults = $scope.nearBy && false;
                };
                var checkCompletion = function () {
                    return $scope.validating && $scope.phone && $scope.email && $scope.nearBy && $scope.text;
                };
                var checkValidity = function() {
                    return checkCompletion() && true;
                };
                if (!checkValidity()) return false;
                $scope.posting = true;
                $scope.validating = false;

                ajaxService.createPost({
                    phone: $scope.phone,
                    email: $scope.email,
                    address: {},
                    text: $scope.text
                }, function() {
                    $scope.posting = false;
                    $scope.posted = true;
                });
                return true;
            };
        }
    ]);