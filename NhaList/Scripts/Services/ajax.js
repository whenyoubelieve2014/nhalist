'use strict';
angular
    .module('ajax', [])
    .factory('ajaxService', [
        '$http', function ($http) {
            var createPost = function (data, callbackSucess, callbackError) {
                $http.post('/api/Post', data).success(callbackSucess).error(callbackError);
            };
            return {
                createPost: createPost
            };
        }
    ]);