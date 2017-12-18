var concat = new Array();
var lineSymbol;
$(document).ready(function () {
    setDate();
    initMap();
   /* var flightFrom = $("#datalistFrom option[value='" + $('#srchFrom').val() + "']").attr('data-id');
    var flightTo = $("#datalistFrom option[value='" + $('#srchTo').val() + "']").attr('data-id');*/

});

var locations = new Array();
function initMap() {
   
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 7,
        center: new google.maps.LatLng(50.088, 14.4208),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var infowindow = new google.maps.InfoWindow({});

    var marker, i;
    lineSymbol = {
        path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW,
        scale: 8,
        strokeColor: '#125'
    };

    markers = locations.map(function (location, i) {
        marker = new google.maps.Marker({
            position: locations[i],
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindow.setContent(locations[i].value);
                infowindow.open(map, marker);
               
            }
        })(marker, i));
        return marker;
    });

    console.log(locations);




    var markerCluster = new MarkerClusterer(map, markers,
        { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });
    markerCluster.setMap(map);
}

function setTrack() {
    getFlightRoute();
    animateCircle(flightPath);
    flightPath.setMap(map);
}
function clearTrack() {
    flightPath.setMap(null);
}

function getFlightRoute() {
    flightPath = new google.maps.Polyline({
        path: concat,
        icons: [{
            icon: lineSymbol,
            offset: '100%'
        }],
        geodesic: true,
        strokeColor: '#FF0000',
        strokeOpacity: 1.0,
        strokeWeight: 2
    });

    return flightPath;

}

function animateCircle(line) {
    var count = 0;
    window.setInterval(function () {
        count = (count + 1) % 200;
        var icons = line.get('icons');
        icons[0].offset = (count / 2) + '%';
        line.set('icons', icons);
    }, 20);
}

function setDate() {
    var dates = $("#departure").datepicker({
        defaultDate: "+2w",
        changeMonth: true,
        numberOfMonths: 2,
        dateFormat: 'dd/mm/yy',
        onSelect: function (selectedDate) {
            var option = this.id === "departure" ? "minDate" : "maxDate",
                instance = $(this).data("datepicker");
            date = $.datepicker.parseDate(
                instance.settings.dateFormat ||
                $.datepicker._defaults.dateFormat,
                selectedDate, instance.settings);
            dates.not(this).datepicker("option", option, date);

            console.log($("#departure").datepicker().val());
        }
    });
}