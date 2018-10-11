var app = angular.module('InventoryWA', ['ngRoute', 'ngResource']);

app
    .config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when('/Categories', { templateUrl: '/templates/categories/main.html', controller: 'CategorieController' })
                .when('/Categories/Create', { templateUrl: '/templates/categories/create.html', controller: 'CategorieControllerCreate' })
                .otherwise({ redirectTo: '/Categories' });
        }]
    );