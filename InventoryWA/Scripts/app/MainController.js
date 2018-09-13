var app = angular.module('InventoryWA');

var mainController = function ($scope) {
    $scope.name = 'hello';
};

app.controller('MainController', ['$scope', mainController]);