(function () {
    angular.module('app').factory('authQrService', [
        '$http', function ($http) {
            var vm = this;
            vm.baseUrl = "http://localhost:6234/QRImages/b12249db-a259-44a4-8bf9-c267da66d428.png";
            //Home logic...
            vm.getQRImage = function () {



            };
        }
    ]);
})();