(function () {
    angular.module('app').factory('mvOrder', [
        '$resource', function ($resource) {
            var OrderResource = $resource('/api/services/taxiapp/order/makeOrder', { id: '@id' }, {
                update: { method: 'PUT', isArray: false}
            });

            return OrderResource;
        }
    ]);

})();