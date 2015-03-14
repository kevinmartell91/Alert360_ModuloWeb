var eventModule = angular.module("eventModule", []).config(function ($routeProvider, $locationProvider) {
    //Path - it should be same as href link
    $routeProvider.when('/Events/Talks', { templateUrl: '/Templates/Talk.html', controller: 'eventController' });
    $routeProvider.when('/Events/Speakers', { templateUrl: '/Templates/Speaker.html', controller: 'speakerController' });
    $locationProvider.html5Mode(true);
});