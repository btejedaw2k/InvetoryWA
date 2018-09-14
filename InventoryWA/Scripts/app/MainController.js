var app = angular.module('InventoryWA');

var mainController = function ($scope) {
    $scope.name = 'Hello';
    $scope.studen = 'Me';
};

app.controller('MainController', ['$scope', mainController]);