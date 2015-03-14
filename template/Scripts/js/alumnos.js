function Hello($scope, $http) {
    $http.get('http://alert360-001-site1.smarterasp.net/api/usuarios').
        success(function (data) {
            $scope.greeting = data;
        });
}


