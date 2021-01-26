let locations = [
    ['Shelter 1', 44.08758502824518, 25.993652343750004],
    ['Shelter 2', 46.619261036171515, 27.729492187500004],
    ['Shelter 3', 46.81509864599243, 24.982910156250004],
    ['Shelter 4', 46.392411189814645, 23.334960937500004],
    ['Shelter 5', 45.44471679159555, 23.258056640625]
];
let map;
let marker;
let infowindow;
let count;
function initMap() {
    var center = { lat: 44.439663, lng: 26.096306 },
        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 6,
            center: center
        });
    marker = new google.maps.Marker({
        position: center,
        map: map
    });
    infowindow = new google.maps.InfoWindow({});
    for (count = 0; count < locations.length; count++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[count][1], locations[count][2]),
            map: map,
            title: locations[count][0]
        });
        google.maps.event.addListener(marker, 'click', (function (marker, count) {
            return function () {
                infowindow.setContent(locations[count][0]);
                infowindow.open(map, marker);
            }
        })(marker, count));
    }
}





