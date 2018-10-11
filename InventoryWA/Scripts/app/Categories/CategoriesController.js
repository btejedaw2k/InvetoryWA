var app = angular.module('InventoryWA');

app.
    controller('CategorieController', ['$scope', 'ServiceCategorie', function ($scope, ServiceCategorie) {
        $scope.categories = [];
        GetAllData();

        function GetAllData() {
            ServiceCategorie.GetAllData().then(function (result) {
                $scope.categories = result;
            });
        };
    }])
    .controller('CategorieControllerCreate', ['$scope', '$location', 'ServiceCategorie', function ($scope, $location, ServiceCategorie) {
        $scope.SaveData = function (categorie) {
            ServiceCategorie.SaveData(categorie).then(function () {
                toastr.success('Categoria guardado correctament.', 'Informacion guardada.');
                $location.path('/Categories');
            }, function () {
            });
        };
    }]);