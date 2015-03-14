


//Angular App Module and Controller
angular.module('mapsApp', [])
    .factory('AlertasService', function ($http) {
        return {
            getAlertas: function () {
                return $http.get('http://www.json-generator.com/api/json/get/bQjJFsuUpu?indent=2')
            }
        }
    })
.controller('MapCtrl', function ($scope,AlertasService) {
    AlertasService.getAlertas().success(function (data) {
        $scope.jsons = data;
    })
    //$scope.jsons = [
    //    {
    //        "CodAlerta": 6,
    //        "CodUsuario": 2,
    //        "Latitud": 34.0500,
    //        "Longitud": -118.2500,
    //        "Fecha": "2005-12-21T00:00:00",
    //        "HusoHorario": 4321,
    //        "Tipo": 0
    //    }
    //]
    var mapOptions = {
        zoom: 4,
        center: new google.maps.LatLng(40.0000, -98.0000),
        mapTypeId: google.maps.MapTypeId.TERRAIN
    }

    $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

    $scope.markers = [];

    var infoWindow = new google.maps.InfoWindow();

    var createMarker = function (info) {

        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(info.Latitud, info.Longitud),
            CodAlerta: "   Cod  :  " + info.CodAlerta,
            CodUsuario: info.CodUsuario,
            Latitud: info.Latitud,
            Longitud: info.Longitud,
            Fecha: info.Fecha,
            HusoHorario: info.HusoHorario,
            Tipo: info.Tipo
        });
        marker.content = '<div class="infoWindowContent">  Fecha : ' + info.Fecha + '    Ususario :  ' + info.CodUsuario + '    Tipo Alerta : ' + info.Tipo + '</div>';

        google.maps.event.addListener(marker, 'click', function () {
            infoWindow.setContent('<h2>' + 'Long : ' + marker.Longitud + ' - Lat : ' + marker.Latitud + '</h2>' + marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);

    }

    //for (i = 0; i < cities.length; i++) {
    //    createMarker(cities[i]);
    //}
    for (i = 0; i < $scope.jsons.length; i++) {
        createMarker($scope.jsons[i]);
    }

    $scope.openInfoWindow = function (e, selectedMarker) {
        e.preventDefault();
        google.maps.event.trigger(selectedMarker, 'click');
    }
    //angular.module("CombineModule", ["mapsApp"]);
});

//angular.module('myApp', []).
//directive('myMap', function () {
//    // directive link function
//    var link = function (scope, element, attrs) {
//        var map, infoWindow;
//        var markers = [];

//        // map config
//        var mapOptions = {
//            center: new google.maps.LatLng(50, 2),
//            zoom: 4,
//            mapTypeId: google.maps.MapTypeId.ROADMAP,
//            scrollwheel: false
//        };

//        // init the map
//        function initMap() {
//            if (map === void 0) {
//                map = new google.maps.Map(element[0], mapOptions);
//            }
//        }

//        // place a marker
//        function setMarker(map, position, title, content) {
//            var marker;
//            var markerOptions = {
//                position: position,
//                map: map,
//                title: title,
//                icon: 'https://maps.google.com/mapfiles/ms/icons/green-dot.png'
//            };

//            marker = new google.maps.Marker(markerOptions);
//            markers.push(marker); // add marker to array

//            google.maps.event.addListener(marker, 'click', function () {
//                // close window if not undefined
//                if (infoWindow !== void 0) {
//                    infoWindow.close();
//                }
//                // create new window
//                var infoWindowOptions = {
//                    content: content
//                };
//                infoWindow = new google.maps.InfoWindow(infoWindowOptions);
//                infoWindow.open(map, marker);
//            });
//        }

//        // show the map and place some markers
//        initMap();

//        setMarker(map, new google.maps.LatLng(51.508515, -0.125487), 'London', 'Just some content');
//        setMarker(map, new google.maps.LatLng(52.370216, 4.895168), 'Amsterdam', 'More content');
//        setMarker(map, new google.maps.LatLng(48.856614, 2.352222), 'Paris', 'Text here');
//    };

//    return {
//        restrict: 'A',
//        template: '<div id="gmaps"></div>',
//        replace: true,
//        link: link
//    };
//});