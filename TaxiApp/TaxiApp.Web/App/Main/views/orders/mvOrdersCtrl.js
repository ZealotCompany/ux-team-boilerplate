(function () {
    var controllerId = 'app.views.orders';
    angular.module('app').controller(controllerId, [
        // '$scope', 'mvOrderService', function ($scope, mvOrderService) {
        '$scope', 'abp.services.taxiapp.order', function ($scope, orderService) {

            var vm = this;

            $scope.hideAdditionalSearch = true;
            $scope.orderDate = new Date();

            $scope.genderOptions = [
                {
                    name: "All Genders"
                },
                {
                    name: "Male"
                },
                {
                    name: "Female"
                }
            ];
            //$scope.selectedGender = $scope.genderOptions[0];
            

            $scope.carTypeOptions = [
                {
                    id: 0,
                    name: "All Cars"
                },
                {
                    id: 1,
                    name: "Sedan"
                },
                {
                    id: 2,
                    name: "Jeep"
                }
            ];
            $scope.selectedCarType = $scope.carTypeOptions[0];

            $scope.carBrandOptions = [
                {
                    id: 0,
                    name: "All Brands"
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
            $scope.selectedCarBrandType = $scope.carBrandOptions[0];

            $scope.orderDateOptions = [
                {
                    id: 0,
                    name: "Near Time",
                    value: new Date()
                },
                {
                    id: 1,
                    name: "In 15 minutes",
                    value: Date.now
                },
                {
                    id: 2,
                    name: "In 30 minutes",
                    value: Date.now
                },
                {
                    id: 9,
                    name: "Pick a Date",
                    value: undefined
                }
            ];
            $scope.selectedOrderDateType = $scope.orderDateOptions[0];

            $scope.showOrderDateTimePicker = false;
            $scope.dateOptionChanged = function (selectedDateOption) {
                console.log($scope.selectedOrderDateType.value);
                if ($scope.selectedOrderDateType.id === 9) {
                    $scope.showOrderDateTimePicker = true;
                } else {
                    $scope.showOrderDateTimePicker = false;
                }
            }


            $scope.minimumCarProductionYear = 1990;

            $scope.successOrder = false;
            console.log($scope.successOrder);

            $scope.makeOrder = function () {
                var newOrderData = {
                    locationFrom: {
                        place: $scope.locationFrom
                    },
                    locationTo: {
                        place: $scope.locationTo
                    },
                    orderDate: $scope.orderDate,
                    suggestedPrice: $scope.suggestedPrice,

                    carBrandId: $scope.selectedCarBrandType.id === 0 ? undefined : $scope.selectedCarBrandType.id,
                    carTypeId: $scope.selectedCarType.id === 0 ? undefined : $scope.selectedCarType.id,
                    minimumCarProductionYear: $scope.minimumCarProductionYear,

                    driverExperiance: $scope.driverExperiance,
                    gender: $scope.selectedGender
                };

                console.log(newOrderData);
                //mvOrderService.makeOrder(newOrderData).then(
                //    function (data) {
                //        $scope.successOrder = true;
                //        console.log('Order made successfully!');
                //    },
                //    function (response) {
                //        $scope.successOrder = false;
                //        console.log('Order failed');
                //    });

                orderService.makeOrder({
                    order: newOrderData
                }).success(function (data) {
                    $scope.successOrder = true;
                    console.log('Order made successfully!');
                });
                
            };

            $scope.showAdditionalOptions = function () {
                $scope.hideAdditionalSearch = false;
            };

            $scope.hideAdditionalOptions = function () {
                $scope.hideAdditionalSearch = true;
            };
        }])
})();