var app = angular.module('app', ['ngRoute']);

app.controller('MainController', MainController);
app.controller('GridController', GridController);


var configFunction = function ($routeProvider, $httpProvider) {
//    $routeProvider.when('/grid', {
//        templateURL: 'app/Views/Grid.html',
//        controller: GridController
    //})
    $routeProvider.when('/map', {
        templateURL: 'app/Views/Map.html',
        controller: GridController
    })
    .otherwise({
        redirectTo: function () {
            return '/grid';
        }
    })
}

configFunction.$inject = ['$routeProvider', '$httpProvider'];
    
app.config(configFunction);


