var app = angular.module('InventoryWA');

app.directive('wcUnique', ['ServiceCategorie', function (ServiceCategorie) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            element.bind('blur', function (e) {
                if (!ngModel || !element.val()) {
                    return;
                }
                var keyProperty = scope.$eval(attrs.wcUnique);
                var currentValue = element.val();
                ServiceCategorie.GetCodeExiste(keyProperty.id, keyProperty.property, currentValue)
                    .then(
                        function (result) {
                            if (currentValue == element.val()) {
                                ngModel.$setValidity('unique', result);
                            }
                        },
                        function () {
                            ngModel.$setValidity('unique', true);
                        }
                    );
            })
        }
    }
}]);