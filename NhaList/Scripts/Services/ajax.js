'use strict';
angular
    .module('ajax', [])
    .factory('ajaxService', [
        '$http', function($http) {
            var models = ['GeoSearch', 'Post'];
            var service = {};
            $.each(models, function(index, model) {
                var postFunc = function(data, callbackSucess, callbackError) {
                    $http.post('/api/' + model, data).success(callbackSucess).error(callbackError);
                };
                service['post' + model] = postFunc;

                var getFunc = function(data, callbackSucess, callbackError) {
                    $http.get('/api/' + model + '/' + data).success(callbackSucess).error(callbackError);
                };
                service['get' + model] = getFunc;

            });
            return service;
        }
    ]);