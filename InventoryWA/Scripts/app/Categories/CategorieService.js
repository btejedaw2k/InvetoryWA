var app = angular.module('InventoryWA');
    app.factory('ServiceCategorie', ['$http', '$q', function ($http, $q) {
        var service = {};
        
        service.SaveData = function (categorie) {
            var deferred = $q.defer();
            $http.post(
                '/Categories/SaveCategorie/', categorie
            ).then(function () {
                deferred.resolve();
            }, function () {
                deferred.reject();
            });
            return deferred.promise;
        };

        service.GetCategorie = function (id) {
            var deferred = $q.defer();
            $http.get(
                '/Categories/Details/' + id
            ).then(function (result) {
                deferred.resolve(result.data);
            }, function () {
                deferred.reject();
            });
            return deferred.promise;
        };

        service.GetAllData = function () {
            var deferred = $q.defer();
            $http.get(
                '/Categories/GetAllCategories/'
            ).then(function (result) {
                deferred.resolve(result.data);
            }, function () {
                deferred.reject();
            });
            return deferred.promise;
        };

        service.EditCategorie = function (categorie) {
            var deferred = $q.defer();
            $http.post(
                '/Categories/Edit/', categorie
            ).then(function () {
                deferred.resolve();
            }, function () {
                deferred.reject;
            });
            return deferred.promise;
        }

        service.DeleteCategorie = function (id, Nombre) {
            var deferred = $q.defer();
            if (confirm('Seguro que desea eliminar la categoria <<' + Nombre + '>>?')) {
                $http.post(
                    '/Categories/Delete/', { id: id }
                ).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject;
                });
            }
            return deferred.promise;
        }

        service.GetCodeExiste = function (id, property, value) {
            var deferred = $q.defer();
            $http.get(
                '/Categories/GetCategorieExist/' + id + "?property=" + property + "&value=" + value
            ).then(function (result) {
                console.log(result);
                deferred.resolve(result.data.status);
            }, function () {
                deferred.reject();
            });
            return deferred.promise;
        };
                
        return service;
    }]);