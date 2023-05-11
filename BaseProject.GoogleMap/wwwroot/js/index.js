// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Initialize and add the map

let map;

async function initMap() {
    // The location of Uluru
    const position = { lat: 10.7934612, lng: 106.4211922 };
    // Request needed libraries.
    //@ts-ignore
    // HUY (ha)
    const { Map } = await google.maps.importLibrary("maps");
    const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");

    // The map, centered at Uluru
    map = new Map(document.getElementById("map"), {
        zoom: 8,
        center: position,
        mapId: "DEMO_MAP_ID",
    });

    // The marker, positioned at Uluru
    const marker = new AdvancedMarkerElement({
        map: map,
        position: position,
        title: "Hutech",
    });

    var u = { lat: 10.7934612, lng: 106.4211922 };
    var map = new google.map.Map(document.getElementById('mapp'), {
        zoom: 13,
        center: u,
        mapTypeId: google.maps.MapTypepId.HYBRID,
        zoomControl: true,
        zoomControlOptions: {
            position: google.maps.ControlPosition.LEFT_BOTTOM
        },
        streetViewControl: true,
        streetViewControlOptions: {
            position: google.maps.ControlPosition.LEFT_BOTTOM
        },
        mapTypeControlOptions: {
            position: google.maps.ControlPosition.RIGHT_CENTER
        },
    });

    var tra = new google.maps.TrafficLayer();
    tra.setMap(map);


}


window.initMap();


//{ lat: 10.7905024, lng: 106.6827776 },
//{ lat: 10.8141091, lng: 170.463352 },