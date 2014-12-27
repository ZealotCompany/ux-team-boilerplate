(function () {
    angular.module('app').factory('mvOrder', [
        '$resource', function ($resource) {
            var OrderResource = $resource('/api/orders', { id: '@id' }, {
                update: { method: 'PUT', isArray: false}
            });

            return OrderResource;
        }
    ]);

})();