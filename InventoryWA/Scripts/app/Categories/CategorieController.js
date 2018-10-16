var app = angular.module('InventoryWA');

app.
    controller('CategorieController', ['$scope', 'ngDialog', 'ServiceCategorie', function ($scope, ngDialog, ServiceCategorie) {
        $scope.categories = [];
        GetAllData();

        function GetAllData() {
            ServiceCategorie.GetAllData().then(function (result) {
                $scope.categories = result;
            });
        };

        $scope.DeleteCategorie = function (id, Nombre) {
            $('#toast-container').remove();
            toastr.warning(
                "Usted esta eliminando la categoria. <b>" + Nombre + "</b><br />Desea continuar?<br />" +
                "<button type='button' id='confirmationRevertYes' class='btn btn-primary' value='yes'>Eliminar</button>",
                '<h4>Eliminando Categoria.</h4>',
                {
                    tapToDismiss: false,
                    timeOut: 0,
                    extendedTimeOut: 0,
                    closeButton: true,
                    allowHtml: true,
                    preventOpenDuplicates: true,
                    newestOnTop: true,
                    onShown: function (toast) {
                        $("#confirmationRevertYes").click(function () {
                            ServiceCategorie.DeleteCategorie(id, Nombre).then(function () {
                                toastr.success('Categria eliminada correctamente', 'Informacion eliminada');
                                $('#toast-container').remove();
                                GetAllData();
                            }, function () {
                                toastr.error('No se pudo eliminar la categoria');
                            });
                        });
                    }
                },
            );
            
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