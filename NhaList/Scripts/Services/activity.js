'use strict';
angular.module('activity', [])
    .factory('activityService', function() {
        var searchCount = 0;

        function searchClass(nearBy) {
            var c = this;
            c.id = searchCount;
            c.nearBy = nearBy;
        }

        function then(callbackSuccess) {
            if (callbackSuccess) {
                setTimeout(function() {
                    callbackSuccess(currentSearch);
                });
            }
        };

        var currentSearch;
        var createSearch = function(nearBy, callbackSuccess) {
            then(function() {
                searchCount++;
                currentSearch = new searchClass(nearBy);
                then(callbackSuccess);
            });
        };

        var retrieveSearch = function(nearBy, callbackSuccess) {
            if (currentSearch) {
                then(callbackSuccess);
                return;
            }
            createSearch(nearBy, callbackSuccess);
        };

        //returning new instance of activityService
        return {
            createSearch: createSearch,
            retrieveSearch: retrieveSearch
        };
    });