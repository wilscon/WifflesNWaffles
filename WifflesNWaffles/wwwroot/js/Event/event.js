const elements = {
    RSVPButton: $('[data-selector="RSVP"]'),
}

const resources = {
    address: "2799-2705 N Park Dr, Bellingham, WA 98225",
    latitude: 37.4221,
    longitude: -122.0841,

}
const initialize = function () {
    elements.RSVPButton.click(RSVP);
    initMap();
}
const RSVP = function () {
    document.location.href = "/home/RSVP";
}

const initMap = function() {

    var address = resources.address;


    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 15,
        center: { lat: resources.latitude, lng: resources.longitude }
    });

    var geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === 'OK') {

            map.setCenter(results[0].geometry.location);

            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}
initialize();