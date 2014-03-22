angular
    .module('home', ['ajax', 'geocoder'])
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
        '$scope', '$timeout', 'ajaxService', 'geocoderService', function($scope, $timeout, ajaxService, geocoderService) {

            $scope.updateAddress = function() {
                geocoderService.getFormattedAddress($scope.nearBy, function(formatted, lat, lng) {
                    $scope.original = $scope.nearBy;
                    $scope.nearBy = formatted;
                    $scope.lat = lat;
                    $scope.lng = lng;
                }, function(error) {
                    $scope.noGeoResults = error;
                });
            };

            $scope.handleSubmit = function() {
                $scope.validating = true;

                var checkCompletion = function() {
                    return $scope.validating && $scope.phone && $scope.email && $scope.nearBy && $scope.text;
                };
                var checkValidity = function() {
                    return checkCompletion() && true;
                };
                if (!checkValidity()) return false;
                $scope.posting = true;
                $scope.validating = false;
                ajaxService.postPost({
                    Phone: $scope.phone,
                    Email: $scope.email,
                    Text: $scope.text,
                    ApproximateAddress: $scope.original || $scope.nearBy,
                    FormattedAddress: $scope.original != $scope.nearBy ? $scope.nearBy : null,
                    Latitude: $scope.lat,
                    Longtitude: $scope.lng
                }, function() {
                    $scope.posting = false;
                    $scope.posted = true;
                });
                return true;
            };
        }
    ]);