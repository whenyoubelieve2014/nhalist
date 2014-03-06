'use strict';
/*
TODO:
. save results to cache
. retrieve results from db
. save results to db
*/
angular
    .module('geocoder', ['ajax'])
    .factory('localGeoService', [
        '$timeout', function($timeout) {
            var cachedResults = [
                {
                    address: 'dc',
                    googleResponse: {
                        "results": [
                            {
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
                        ]
                    }
                }
            ];
            var geocode = function(data, callback) {
                if (!data || !callback) return;
                var address = data.address;
                var found = $.grep(cachedResults, function(item) {
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
            var save = function(address, results) {
                var newItem = {
                    address: address,
                    googleResponse: {
                        results: results
                    }
                };
                cachedResults.push(newItem);
            };
            return {
                geocode: geocode,
                save: save
            };
        }
    ])
    .factory('dbGeoService', [
        'ajaxService', function(ajaxService) {
            var geocode = function(data, callback) {
                if (!data || !callback) return;
                var returnZeroResultsToCallback = function() {
                    callback(null, window.google.maps.GeocoderStatus.ZERO_RESULTS);
                };
                ajaxService.getGeoSearch(data.address, function(success) {
                    if (success && success.GoogleResponse) {
                        //unwrapping
                        var results = $.parseJSON(success.GoogleResponse).results;

                        callback(results, window.google.maps.GeocoderStatus.OK);
                        return;
                    }
                    returnZeroResultsToCallback();
                }, returnZeroResultsToCallback);
            };
            var formatResults = function(results) {
                $.each(results, function(index, result) {
                    if (index!==0) {
                        return;
                    }
                    var geo = result.geometry;
                    var bounds = geo.bounds;
                    var ne = bounds.northeast || bounds.getNorthEast();
                    var sw = bounds.southwest || bounds.getSouthWest();
                    geo.bounds.northeast = { lat: ne.lat(), lng: ne.lng() };
                    geo.bounds.southwest = { lat: sw.lat(), lng: sw.lng() };
                });
                return results;
            };
            var save = function(address, results) {
                //NhaList.Models.GeoSearch
                var formattedResults = formatResults(results);
                var newItem = {
                    ApproximateAddress: address,
                    GoogleResponse:
                        //wrapping
                        JSON.stringify({
                            results: formattedResults
                        })
                };
                ajaxService.postGeoSearch(newItem);
            };
            return {
                geocode: geocode,
                save: save
            };
        }
    ])
    .factory('geocoderService', [
        '$timeout', 'localGeoService', 'dbGeoService', function($timeout, localGeoService, dbGeoService) {
            var googleServiceName = 'google.maps.Geocoder';
            var services = [
                { name: 'localGeoService', obj: localGeoService },
                { name: 'dbGeoService', obj: dbGeoService },
                { name: googleServiceName, obj: new window.google.maps.Geocoder() }
            ];
            var validate = function(results, status) {
                var ok = results && results.length && status === window.google.maps.GeocoderStatus.OK;
                return ok;
            };

            var getLatLong = function(nearBy, callback) {
                var addressWrapper = { address: nearBy };

                var save = function(address, results) {
                    $.each(services, function(index, service) {
                        if (service.obj.save) {
                            service.obj.save(address, results);
                        }
                    });
                };

                var tryService = function(i) {
                    if (i >= services.length) {
                        //all services have been tried
                        //no results found
                        if (callback) {
                            callback(null, window.google.maps.GeocoderStatus.ZERO_RESULTS);
                        }
                        return;
                    }
                    var serviceName = services[i].name;
                    var service = services[i].obj;
                    service.geocode(addressWrapper, function(results, status) {
                        //results must be an array of locations

                        /*
                        The status code may return one of the following values:
                        google.maps.GeocoderStatus.OK indicates that the geocode was successful.
                        google.maps.GeocoderStatus.ZERO_RESULTS indicates that the geocode was successful but returned no results. This may occur if the geocode was passed a non-existent address or a latng in a remote location.
                        google.maps.GeocoderStatus.OVER_QUERY_LIMIT indicates that you are over your quota. Refer to the Usage limits exceeded article in the Maps for Business documentation, which also applies to non-Business users, for more information.
                        google.maps.GeocoderStatus.REQUEST_DENIED indicates that your request was denied for some reason.
                        google.maps.GeocoderStatus.INVALID_REQUEST generally indicates that the query (address or latLng) is missing.
                        */

                        //results must be an array of locations
                        var noResults = !validate(results, status);
                        if (noResults) {
                            tryService(++i);
                            return;
                        }
                        if (callback) {
                            callback(results, status);
                            if (serviceName === 'google.maps.Geocoder') {
                                save(addressWrapper.address, results);
                            }
                        }
                    });
                };
                tryService(0);
            };
        var getBoundary = function(results, callback) {
            results = results || [];
            if (!results.length) {
                return;
            }
            var result = results[0] || {};
            var geometry = result.geometry || {};
            var bounds = geometry.bounds|| {};
            var ne = bounds.northeast || {};
            var sw = bounds.southwest || {};
            var boundary = {
                minLat: Math.min(ne.lat, sw.lat),
                minLong: Math.min(ne.lng, sw.lng),
                maxLat: Math.max(ne.lat, sw.lat),
                maxLong: Math.max(ne.lng, sw.lng)
            };
            if (callback) {
                callback(boundary);
            }
            //"results": [
            //                {
            //                    "formatted_address": "Washington, DC, USA",
            //                    "geometry": {
            //                        "bounds": {
            //                            "northeast": {
            //                                "lat": 38.995548,
            //                                "lng": -76.90939299999999
            //                            },
            //                            "southwest": {
            //                                "lat": 38.7916449,
            //                                "lng": -77.119759
            //                            }
            //                        },
        };
        var getFormattedAddress = function(nearBy, onSuccess, onError) {
            getLatLong(nearBy, function(results, status) {
                var noResults = !validate(results, status);
                if (noResults) {
                    if (onError) onError('No Results');
                    return;
                }
                if (onSuccess) {
                    var first = results[0] || {};
                    var formatted = first.formatted_address || {};
                    //"location": {
                    //    "lat": 38.90723089999999,
                    //    "lng": -77.0364641
                    //},
                    var geo = first.geometry || {};
                    var location = geo.location || {};
                    var lat = location.lat || location.d;
                    var lng = location.lng || location.e;
                    onSuccess(formatted, lat, lng);
                }
            });
        };
            return {
                getLatLong: getLatLong,
                //getBoundary: getBoundary,
                getFormattedAddress: getFormattedAddress,
                validate: validate
            };
        }
    ]);