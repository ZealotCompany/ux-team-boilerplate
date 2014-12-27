(function () {
    var controllerId = 'app.views.orders';
    angular.module('app').controller(controllerId, [
        '$scope', 'mvOrderService', function ($scope, mvOrderService) {
            var vm = this;

            $scope.genderOptions = [
                {
                    name: "Male"
                },
                {
                    name: "Female"
                }
            ];
            $scope.selectedGender = $scope.genderOptions[0].name;

            $scope.carTypeOptions = [
                {
                    id: 0,
                    name: "All Cars"
                },
                {
                    id: 1,
                    name: "BMW"
                },
                {
                    id: 2,
                    name: "Mersedec"
                }
            ];
            $scope.selectedCarType = $scope.carTypeOptions[0].name;

            $scope.successOrder = false;
            console.log($scope.successOrder);
            $scope.makeOrder = function () {
                var newOrderData = {
                    locationFrom: $scope.locationFrom,
                    locationTo: $scope.locationTo,
                    orderDate: $scope.orderDate,
                    driverExperiance: $scope.driverExperiance,
                    suggestedPrice: $scope.suggestedPrice,
                    carType: $scope.selectedCarType,
                    gender: $scope.selectedGender
                };

                console.log(newOrderData);
                mvOrderService.makeOrder(newOrderData).then(
                    function (data) {
                        $scope.successOrder = true;
                        console.log('Order made successfully!');
                    },
                    function (response) {
                        $scope.successOrder = false;
                        console.log('Order failed');
                    });

                
            };

        }])
})();