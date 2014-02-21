'use strict';
/*
TODO:
1. save results to cache
2. retrieve results from db
3. save results to db
*/
angular
    .module('geocoder', [])
    .factory('localGeoService', [
        '$timeout', function ($timeout) {
            var cached = [
                {
                    address: 'dc',
                    googleResponse: {
                        "results": [
                            {
                                /*"address_components": [
                                    {
                                        "long_name": "Washington",
                                        "short_name": "Washington",
                                        "types": ["locality", "political"]
                                    },
                                    {
                                        "long_name": "District of Columbia",
                                        "short_name": "District of Columbia",
                                        "types": ["administrative_area_level_2", "political"]
                                    },
                                    {
                                        "long_name": "District of Columbia",
                                        "short_name": "DC",
                                        "types": ["administrative_area_level_1", "political"]
                                    },
                                    {
                                        "long_name": "United States",
                                        "short_name": "US",
                                        "types": ["country", "political"]
                                    }
                                ],*/
                                "formatted_address": "Washington, DC, USA",
                                "geometry": {
                                    "bounds": {
                                        "northeast": {
                                            "lat": 38.995548,
                                            "lng": -76.90939299999999
                                        },
                                        "southwest": {
                                            "lat": 38.7916449,
                                            "lng": -77.119759
                                        }
                                    },
                                    "location": {
                                        "lat": 38.90723089999999,
                                        "lng": -77.0364641
                                    },
                                    "location_type": "APPROXIMATE",
                                    "viewport": {
                                        "northeast": {
                                            "lat": 38.995548,
                                            "lng": -76.90939299999999
                                        },
                                        "southwest": {
                                            "lat": 38.7916449,
                                            "lng": -77.119759
                                        }
                                    }
                                },
                                "types": ["locality", "political"]
                            },
                            {
                                /*"address_components": [
                                    {
                                        "long_name": "District of Columbia",
                                        "short_name": "DC",
                                        "types": ["administrative_area_level_1", "political"]
                                    },
                                    {
                                        "long_name": "United States",
                                        "short_name": "US",
                                        "types": ["country", "political"]
                                    }
                                ],*/
                                "formatted_address": "District of Columbia, USA",
                                "geometry": {
                                    "bounds": {
                                        "northeast": {
                                            "lat": 38.995548,
                                            "lng": -76.90939299999999
                                        },
                                        "southwest": {
                                            "lat": 38.7916449,
                                            "lng": -77.119759
                                        }
                                    },
                                    "location": {
                                        "lat": 38.9059849,
                                        "lng": -77.03341790000002
                                    },
                                    "location_type": "APPROXIMATE",
                                    "viewport": {
                                        "northeast": {
                                            "lat": 38.995548,
                                            "lng": -76.90939299999999
                                        },
                                        "southwest": {
                                            "lat": 38.7916449,
                                            "lng": -77.119759
                                        }
                                    }
                                },
                                "types": ["administrative_area_level_1", "political"]
                            }
                        ],
                        "status": "OK"
                    }
                }
            ];
            var geocode = function(options, callback) {
                if (!options || !callback) return;
                var address = options.address;
                var found = $.grep(cached, function(item) {
                    return item && item.address && address && item.address.toUpperCase() === address.toUpperCase();
                });
                if (found && found.length) {
                    var response = found[0].googleResponse;
                    $timeout(function() {
                        callback(response.results, response.status);
                    });
                    return;
                }
                $timeout(function() {
                    callback(null, window.google.maps.GeocoderStatus.ZERO_RESULTS);
                });
            };
            return {
                geocode: geocode
            };
        }
    ])
    .factory('geocoderService', [
        '$timeout', 'localGeoService', function($timeout, localGeoService) {
            var services = [
                { name: 'localGeoService', obj: localGeoService }
                //,{ name: 'google.maps.Geocoder', obj: new window.google.maps.Geocoder() }
            ];
            var validate = function (results, status) {
                return results && results.length && status === window.google.maps.GeocoderStatus.OK;
            };

            var getLatLong = function(nearBy, callback) {
                var addressWrapper = { address: nearBy };
                var tryService = function(i) {
                    if (i >= services.length) {
                        //all services have been tried
                        //no results found
                        if (callback) {
                            $timeout(function() {
                                callback(null, window.google.maps.GeocoderStatus.ZERO_RESULTS);
                            });
                        }
                        return;
                    }
                    var service = services[i].obj;
                    service.geocode(addressWrapper, function(results, status) {
                        /*
                        The status code may return one of the following values:
                        google.maps.GeocoderStatus.OK indicates that the geocode was successful.
                        google.maps.GeocoderStatus.ZERO_RESULTS indicates that the geocode was successful but returned no results. This may occur if the geocode was passed a non-existent address or a latng in a remote location.
                        google.maps.GeocoderStatus.OVER_QUERY_LIMIT indicates that you are over your quota. Refer to the Usage limits exceeded article in the Maps for Business documentation, which also applies to non-Business users, for more information.
                        google.maps.GeocoderStatus.REQUEST_DENIED indicates that your request was denied for some reason.
                        google.maps.GeocoderStatus.INVALID_REQUEST generally indicates that the query (address or latLng) is missing.
                        */
                        if (!validate(results, status)) {
                            $timeout(function() {
                                tryService(++i);
                            });
                            return;
                        }
                        if (callback) {
                            $timeout(function() {
                                callback(results, status);
                            });
                        }
                    });
                };
                tryService(0);
            };

       
            return {
                getLatLong: getLatLong,
                validate: validate
            };
        }
    ]);