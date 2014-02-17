'use strict';
angular.module('activity', [])
    .factory('activityService', function() {
        var currentCityOrZip = undefined;
        var createSearch = function(nearBy) {
            currentCityOrZip = nearBy;
        };
        var retrieveSearch = function() {
            return currentCityOrZip;
        };
        return {
            createSearch: createSearch,
            retrieveSearch: retrieveSearch
        };
    });