(function () {
    "use strict";
    angular.module("common.services",["ngResource"])
            .constant("appSettings",
            {
                servertPath: "http://localhost:60133/"
            });
}());