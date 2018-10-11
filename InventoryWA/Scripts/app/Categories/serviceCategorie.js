angular.module('InventoryWA')
    .factory('ServiceCategorie', ['$http', '$q', function ($http, $q) {
        var service = {};
        service.GetAllData = function () {
            var deferred = $q.defer();
            $http.get(
                '/Categories/GetAllCategories'
            ).then(function (result) {
                deferred.resolve(result.data);
            }, function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        service.SaveData = function (categorie) {
            var deferred = $q.defer();
            $http.post(
                '/Categories/SaveCategorie', categorie
            ).then(function () {
                deferred.resolve();
            }, function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        
        return service;
    }]);