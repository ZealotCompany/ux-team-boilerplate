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
                },
                {
                    id: 1,
                    name: "In 15 minutes",
                },
                {
                    id: 2,
                    name: "In 30 minutes",
                },
                {
                    id: 9,
                    name: "Pick a Date",
                }
            ];
            $scope.selectedOrderDateType = $scope.orderDateOptions[0];

            $scope.showOrderDateTimePicker = false;
            $scope.dateOptionChanged = function (selectedDateOption) {
                var currentTime = new Date();
                console.log(currentTime);
                switch ($scope.selectedOrderDateType.id) {
                    case 0:
                        $scope.orderDate = currentTime;
                        console.log($scope.orderDate);
                        break;
                    case 1:
                        currentTime.setTime(currentTime.getTime() + 15 * 60000);
                        $scope.orderDate = currentTime;
                        console.log($scope.orderDate);
                        break;
                    case 2:
                        currentTime.setTime(currentTime.getTime() + 30 * 60000);
                        $scope.orderDate = currentTime;
                        console.log($scope.orderDate);
                        break;
                    case 9:
                        if ($scope.selectedOrderDateType.id === 9) {
                            $scope.showOrderDateTimePicker = true;
                        } else {
                            $scope.showOrderDateTimePicker = false;
                        }
                        break;
                }
            }

            $scope.serviceType = "Taxi";
            $scope.changeServiceTo = function (newServiceType) {
                console.log('New service type ' + newServiceType);
                $scope.serviceType = newServiceType;
            };


            $scope.minimumCarProductionYear = 1990;

            $scope.successOrder = false;
            console.log($scope.successOrder);

            $scope.makeOrder = function () {
                // if the date and time are custom, then collapse them into one orderDate
                if ($scope.showOrderDateTimePicker) {
                    console.log($("#datetimepicker5").find("input").val());
                    console.log($("#datetimepicker4").find("input").val());
                    console.log($("#datetimepicker4").data("date"));
                    console.log($("#datetimepicker5").data("date"));

                    //console.log($("#datetimepicker5").data("datetimepicker").getDate());
                    $scope.orderDate = new Date($("#datetimepicker5").data("date"));
                    console.log($scope.orderDate);

                    $scope.orderDate.setTime($("#datetimepicker4").data("date"));
                    console.log($scope.orderDate);

                }

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

            $scope.today = function () {
                $scope.dt = new Date();
            };
            $scope.today();

            $scope.clear = function () {
                $scope.dt = null;
            };

            // Disable weekend selection
            $scope.disabled = function (date, mode) {
                return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
            };

            $scope.toggleMin = function () {
                $scope.minDate = $scope.minDate ? null : new Date();
            };
            $scope.toggleMin();

            $scope.open = function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                $scope.opened = true;
            };

            $scope.dateOptions = {
                formatYear: 'yy',
                startingDay: 1
            };

            $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
            $scope.format = $scope.formats[0];

            $scope.changed = function () {
                console.log('Time changed to: ' + $scope.dt);
            };
            $scope.hstep = 1;
            $scope.mstep = 15;
        }])
})();