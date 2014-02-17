// /Scripts/appRoutes.js
angular.module('appRoutes', []).config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider

        // home page
        .when('/', {
            templateUrl: '/Views/Angular/Home',
            controller: 'HomeController'
        });

		//// nerds page that will use the NerdController
		//.when('/nerds', {
		//    templateUrl: 'views/partials/nerd.html',
		//    controller: 'NerdController'
		//})

		//// 
		//.when('/geeks', {
		//    templateUrl: 'views/partials/geek.html',
		//    controller: 'GeekController'
		//});

    $locationProvider.html5Mode(true);

}]);