var app = angular.module('InventoryWA', ['ngRoute', 'ngResource', 'ngMaterial', 'ngMessages', 'material.svgAssetsCache']);

app
    .config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when('/Categories/', { templateUrl: '/templates/categories/main.html', controller: 'CategorieController' })
                .when('/Categories/Create/', { templateUrl: '/templates/categories/create.html', controller: 'CategorieControllerCreate' })
                .when('/Categories/Edit/:id', { templateUrl: '/templates/categories/edit.html', controller: 'CategorieControllerEdit' })
                .otherwise({ redirectTo: '/Categories/' });
        }]
    );