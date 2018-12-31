(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("productResource", ["$resource", "appSettings", productResource])
    function productResource($resource, appSettings) {
        return $resource("http://localhost:60133/api/products/:id");
    }
}());