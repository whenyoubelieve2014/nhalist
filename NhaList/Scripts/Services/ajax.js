'use strict';
angular
    .module('ajax', [])
    .factory('ajaxService', [
        '$http', function($http) {
            var models = ['GeoSearch', 'Post', 'Search'];
            var config = { timeout: 10000 /*milliseconds*/ };
            var service = {};
            $.each(models, function(index, model) {
                var postFunc = function(data, callbackSuccess, callbackError) {
                    $http.post('/api/' + model, data, config).success(callbackSuccess).error(callbackError);
                };
                service['post' + model] = postFunc;

                var getFunc = function(data, callbackSuccess, callbackError) {
                    $http.get('/api/' + model + '/' + data, config).success(callbackSuccess).error(callbackError);
                };
                service['get' + model] = getFunc;

            });
            return service;
        }
    ]);