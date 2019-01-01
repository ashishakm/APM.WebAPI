(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",["productResource",
        ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;
       vm.SearchCriteria = "GDN";
      // productResource.query({search:vm.SearchCriteria},function (data) {
      // productResource.query({ $skip: 1, $top: 3 }, function (data) {
       productResource.query({
         $filter: "Price ge 5 and Price le 20", 
          // $filter: "contains(ProductCode,'"+vm.SearchCriteria+"') and Price ge 5 and Price le 20",  
            $orderby:"Price desc"},
           function (data) {
            vm.products = data;
        });
       
       
    }
}());