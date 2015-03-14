var app = angular.module('mapsApp', [])


app.controller('MapCtrl', function ($scope, $http) {

    $scope.jsons = [];
    //var resultPromise = $http.get('http://www.json-generator.com/api/json/get/bUDFyyUdHC?indent=2')
    var resultPromise = $http.get('http://alert360-001-site1.smarterasp.net/api/alertas')
    resultPromise.success(function (data) {
       $scope.jsons = data;
       /* $scope.jsons = [{
            "Latitud": -12.103857,
            "Tipo": 0,
            "CodUsuario": 182,
            "Fecha": "21/12/2005 12:00:00 a.m.",
            "CodAlerta": 6,
            "HusoHorario": "UPC",
            "Longitud": -76.962927
        }]
       */
        var mapOptions = {
            zoom: 12,
            center: new google.maps.LatLng(-12.054251, -77.042022),
            //mapTypeId: google.maps.MapTypeId.TERRAIN
        }

        $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

        $scope.markers = [];
   
        var infoWindow = new google.maps.InfoWindow();

        var createMarker = function (info) {
           
            var marker = new google.maps.Marker({
                animation: google.maps.Animation.DROP,
                map: $scope.map,
                position: new google.maps.LatLng(info.Latitud, info.Longitud),
                CodAlerta: "   Cod  :  " + info.CodAlerta,
                CodUsuario  : info.CodUsuario,
                Latitud     : info.Latitud,
                Longitud    : info.Longitud,
                Fecha       : info.Fecha,
                HusoHorario : info.HusoHorario,
                Tipo        : info.Tipo
            });
           
            marker.content = '<div class="infoWindowContent">  Fecha : ' + info.Fecha + '<br>' +
                                                        '    Usuario :  '  +info.CodUsuario + '<br>' +
                                                        //'    Usuario :  ' + $scope.usuario +
                                                        '    Tipo Alerta : ' + info.Tipo +
                                                        '</div>';

            google.maps.event.addListener(marker, 'click', function () {
                //infoWindow.setContent('<h2> ' + marker.HusoHorario + '   Long : ' + marker.Longitud + ' - Lat : ' + marker.Latitud + '</h2>' + marker.content);
                infoWindow.setContent('<h2>Long : ' + marker.Longitud + ' - Lat : ' + marker.Latitud + '</h2>' + marker.content);
                infoWindow.open($scope.map, marker);
            });

            $scope.markers.push(marker);

        }

        for (i = 0; i < $scope.jsons.length; i++) {
            createMarker($scope.jsons[i]);
        }
       
        $scope.openInfoWindow = function (e, selectedMarker) {
            var resultPromise = $http.get('http://alert360-001-site1.smarterasp.net/api/usuarios?CodUsuario=' + selectedMarker.CodUsuario)
           //var resultPromise = $http.get('http://localhost:1664/api/usuarios?codUsuario='+ selectedMarker.CodUsuario)          
            resultPromise.success(function (data) {
                $scope.user = data;
            });
            
            e.preventDefault();
            google.maps.event.trigger(selectedMarker, 'click');
        }

       
    })


})
