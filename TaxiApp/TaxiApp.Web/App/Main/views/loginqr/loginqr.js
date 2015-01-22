(function () {
    var controllerId = 'app.views.loginqr';
    angular.module('app').controller(controllerId, [
        '$scope', '$http', '$interval', '$location' , function ($scope, $http, $interval, $location) {
            var vm = this;
            vm.baseUrl = $location.protocol() + '://' + $location.host() + ':' + $location.port() + '/QRImages/';
            //Home logic...
            var stop;
            
            $scope.getQRImage = function () {
                $scope.timer = 60;
                $scope.isAuthenticated = false;
                if (stop) {
                    $scope.stopFight();
                }

                $http.get('api/qrcode/GetQRImage').
                    success(function (data) {
                        $scope.requestId = data.imageUrl;
                        console.log(data.imageUrl);
                        $scope.qrImageUrl = vm.baseUrl + data.imageUrl + '.png';

                        stop = $interval(function () {
                            if ($scope.timer > 0) {
                                $scope.timer--;
                                $scope.isQRAuthenticated();
                            } else {
                                $scope.stopFight();
                            }
                        }, 1000);

                    }).
                    error(function () {

                    });
                
            };

            $scope.isAuthenticated = false;
            $scope.isQRAuthenticated = function () {
                $http.get('api/qrcode/IsAuthenticated/' + $scope.qrCodeName).
                    success(function (data) {
                        if (data.isAuthenticated) {
                            $scope.isAuthenticated = true;
                            $scope.username = data.subjectName;
                            $scope.serialNumber = data.certificateSerialNumber;
                            $scope.timer = 0;
                            $scope.stopFight();
                        } else {
                            console.log('Failed to authenticate!!');
                            $scope.isAuthenticated = false;
                        }
                    }).
                    error(function () {

                    });
            };

            $scope.stopFight = function () {
                if (angular.isDefined(stop)) {
                    $interval.cancel(stop);
                    stop = undefined;
                }
            };

            $scope.$on('$destroy', function () {
                // Make sure that the interval is destroyed too
                $scope.stopFight();
            })

            $scope.getQRImage();

            
        }
    ]);
})();