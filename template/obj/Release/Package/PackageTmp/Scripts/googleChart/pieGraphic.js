// Code goes here

var app = angular.module('myApp', ['googlechart']);

app.controller('MainCtrlTipoAlerta', function ($scope, $http) {

    //var resultPromise = $http.get('http://www.json-generator.com/api/json/get/bUDFyyUdHC?indent=2')
    var resultPromise = $http.get('http://alert360-001-site1.smarterasp.net/api/alertas?tipo=XXXX')
    //var resultPromise = $http.get('http://localhost:1664/api/alertas?tipo=cualquiercosa')
    resultPromise.success(function (data) {
        $scope.jsons = data;

        var chart1 = {};
        chart1.type = "PieChart";
        chart1.data = [
           ['Componentffff', 'costffff'],
           ['Prefieren el Botón', $scope.jsons.Boton],
           ['Prefieren el Acelerómetro', $scope.jsons.Acelerometro]
        ];
        //chart1.data.push(['Services', 20000]);
        chart1.options = {
            displayExactValues: true,
            width: 400,
            height: 200,
            is3D: true,
            chartArea: { left: 100, top: 10, bottom: 0, height: "100%" }
        };

        chart1.formatters = {
            number: [{
                columnNum: 1,
                //pattern: "$ #,##0.00"
                pattern: "#,## usuarios"
            }]
        };

        $scope.chart = chart1;


    })
});
app.controller('MainCtrlTipoAlertaFecha', function ($scope, $http) {

    //var resultPromise = $http.get('http://www.json-generator.com/api/json/get/bUDFyyUdHC?indent=2')
    var resultPromise = $http.get('http://alert360-001-site1.smarterasp.net/api/alertas?fecha=XXXX')
    //var resultPromise = $http.get('http://localhost:1664/api/alertas?fecha=cualquiercosa')
    resultPromise.success(function (data) {
        $scope.jsons = data;

        var chart1 = {};
        chart1.type = "PieChart";
        chart1.data = [
           ['Componentffff', 'costffff'],
           ['Enviaron en la Mañana', $scope.jsons.Dia],
           ['Enviaron en la Noche', $scope.jsons.Noche]
        ];
        //chart1.data.push(['Services', 20000]);
        chart1.options = {
            displayExactValues: true,
            width: 400,
            height: 200,
            is3D: true,
            chartArea: { left: 100, top: 10, bottom: 0, height: "100%" }
        };

        chart1.formatters = {
            number: [{
                columnNum: 1,
                //pattern: "$ #,##0.00"
                pattern: "#,## usuarios"
            }]
        };

        $scope.chart = chart1;


    })
});


