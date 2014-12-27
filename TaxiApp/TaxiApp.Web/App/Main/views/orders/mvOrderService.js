(function () {
    angular.module('app').factory('mvOrderService', [
        '$http', '$q', 'mvOrder', function ($http, $q, mvOrder) {
            var vm = this;

            return {
                makeOrder: function(orderData) {
                    var dfd = $q.defer();

                    var newOrder = new mvOrder(orderData);
                    newOrder.$save({}).then(
                        function () {
                            dfd.resolve();
                        },
                        function (response) {
                            dfd.reject("Failed to make an order");
                        });

                    return dfd.promise;
                }
            }
        }
    ]);

})();