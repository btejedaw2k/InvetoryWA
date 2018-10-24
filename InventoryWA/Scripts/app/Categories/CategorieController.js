var app = angular.module('InventoryWA');

app.
    controller('CategorieController', ['$scope', '$filter', '$uibModal', 'ServiceCategorie', function ($scope, $filter, $uibModal, ServiceCategorie) {
        $scope.categories = [];
        $scope.currentPage = 1;
        $scope.itemsPerPage = 10;

        GetAllData();

        $('.active').removeClass('active');
        $('#menu-categories').addClass('active');

        function GetAllData() {
            ServiceCategorie.GetAllData().then(function (result) {
                $scope.$watch('seachCategories', function (term) {
                    $scope.categories = $filter('filter')(result, term);
                });
                //$scope.categories = result;
            });
        };

        $scope.DeleteCategorie = function (id, Nombre) {
            var strNombre = Nombre.replace(/ /g, "_");
            $uibModal.open({
                template: '<div class="modal-header"><h3 class="modal-title">Elimiando Categoria</h3>' +
                    '<div class="modal-body">' +
                    'Seguro que desesa eliminar la categoria <b>' + Nombre + '</b>?' +
                    '</div>' +
                    '</div><div class="modal-footer">' +
                    "<button class='btn btn-primary' type='button' ng-click='ok(" + id + ", " + strNombre + ")'>OK</button>" +
                    '<button class="btn btn-warning" type="button" ng-click="cancel()">Cancel</button>' +
                    '</div>',
                //size: 'sm',
                windowClass: 'confirm-window',
                controller: function ($scope, $uibModalInstance) {
                    $scope.ok = function () {
                        ServiceCategorie.DeleteCategorie(id, Nombre).then(function () {
                            var realName = Nombre.replace(/_/g, " ");
                            toastr.warning("Categoria <b>" + realName + "</b> eliminada satisfactoriamente.", "Categoria Eliminada");
                            GetAllData();
                        }, function () {
                            toastr.error('No se pudo eliminar la categoria');
                        });
                        $uibModalInstance.close();
                    };

                    $scope.cancel = function () {
                        $uibModalInstance.close();
                    };
                }
            }).result.then(function () { }, function (res) { });
        };

        $scope.sortBy = function (column) {
            $scope.sortColumn = column;
            $scope.reverse = !$scope.reverse;
        }
    }])
    .controller('CategorieControllerCreate', ['$scope', '$location', 'ServiceCategorie', function ($scope, $location, ServiceCategorie) {

        $scope.SaveData = function (categorie) {
            ServiceCategorie.SaveData(categorie).then(function () {
                toastr.success('Categoria guardado correctament.', 'Informacion guardada.');
                $location.path('/Categories');
            }, function () {
            });
        };
    }])
    .controller('CategorieControllerEdit', ['$scope', '$routeParams', '$location', 'ServiceCategorie', function ($scope, $routeParams, $location, ServiceCategorie) {
        $scope.categorie = {};
        ServiceCategorie.GetCategorie($routeParams.id).then(function (result) {
            $scope.categorie = result;
        }, function () {
            toastr.error('Error al obtener la Categira ' + $routeParams.nombre);
        });

        $scope.EditCategorie = function (categorie) {
            ServiceCategorie.EditCategorie(categorie).then(function () {
                toastr.success('Categoria actualizada correctament.', 'Informacion Actualizada.');
                $location.path('/Categories');
            }, function () {
                toastr.error('Error al obtener la actualizar ' + $routeParams.nombre);
            });
        }
    }]);