(function () {
    var app = angular.module('gemStore');

    app.controller("StoreController", function ($scope, $http) {
        var resultPromise = $http.get('http://localhost:1664/api/alertas');
        resultPromise.success(function (data) {
            $scope.jsons = data;
        });
    });

    app.controller('ReviewController', function () {
        this.review = {};

        this.addReview = function (product) {
            product.reviews.push(this.review);

            this.review = {};
        };
    });
})();
