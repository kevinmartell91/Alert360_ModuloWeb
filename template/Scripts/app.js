'use strict';

// declare modules
angular.module('Authentication', []);
angular.module('Home', []);
angular.module('mapsApp', []);


angular.module('BasicHttpAuthExample', [
    'Authentication',
    'Home',
    'mapsApp',
    'ngRoute',
    'ngCookies'
])

.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/login', {
            controller: 'LoginController',
            templateUrl: 'Scripts/authentication/views/login.html',
            hideMenus: true
        })

        .when('/home', {
            controller: 'MapCtrl',
            templateUrl: '/Home/SplitPanel'
            //templateUrl: 'Templates/Speaker.html'
        })

        .when('/', {
            controller: 'HomeController',
            templateUrl: 'Scripts/authentication/views/home.html'
        })

        .otherwise({ redirectTo: '/login' });
        $locationProvider.html5Mode(true);
}])

.run(['$rootScope', '$location', '$cookieStore', '$http',
    function ($rootScope, $location, $cookieStore, $http) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$routeChangeStart', function (event, next, current) {
            // redirect to login page if not logged in
            if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
                $location.path('/login');
            }
        });
    }]);