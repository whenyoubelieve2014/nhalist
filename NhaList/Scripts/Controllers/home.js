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
                if (console) console.log('postCtrlr.updateAddress');
                try {

                    var nearBy = new String($scope.nearBy);
                    geocoderService.getFormattedAddress(nearBy, function(formatted, lat, lng) {

                        $timeout(function() {
                            $scope.$apply(function() {
                                //lastFormatted = formatted;
                                $scope.original = $scope.nearBy;
                                $scope.nearBy = formatted;
                                $scope.lat = lat;
                                $scope.lng = lng;
                                if (console) console.log($scope.lat, $scope.lng);
                            });
                        }, 50);

                    }, function(error) {
                        try {
                            if (console) console.log('postCtrlr.updateAddress.noGeoResults');
                            $scope.noGeoResults = error;
                        } catch (errorUpdatingScopeNoResult) {
                            if (console) console.log('postCtrlr.updateAddress.errorUpdatingScopeNoResult', errorUpdatingScopeNoResult);
                        }
                    });
                } catch (errorGettingFormattedAddress) {
                    if (console) console.log('$scope.updateAddress.geocoderService.errorGettingFormattedAddress', errorGettingFormattedAddress);
                }
            };

            $scope.handleSubmit = function() {
                $scope.validating = true;

                var checkCompletion = function() {
                    return 1; //$scope.validating && ($scope.phone || $scope.email) && $scope.nearBy && $scope.text;
                };
                var checkValidity = function() {
                    return checkCompletion() && true;
                };
                if (!checkValidity()) return false;
                $scope.posting = true;
                $scope.validating = false;
                if (console) console.log($scope.lat, $scope.lng);
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