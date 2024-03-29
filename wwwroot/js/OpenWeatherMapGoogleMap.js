﻿
var map;
var geoJSON;
var request;
var gettingData = false;
var myLatlng;
var mapOptions;
var openWeatherMapKey;

function initMap() {

    console.log("InitMap");
    console.log(string);
/* Parse incoming string to get lat & longitude co-ordinates */
    var coordinates = JSON.parse(string);
    var latitude = coordinates.latitude;
    var longitude = coordinates.longitude;
    console.log("Coordinates: " + latitude + " " + longitude);
    
    myLatlng = new google.maps.LatLng(latitude, longitude);
    mapOptions = {
        zoom: 10,
        center: myLatlng
    };

    console.log("Google maps - new google maps.Map");
    map = new google.maps.Map(document.getElementById("map-canvas"),
        mapOptions);

    console.log("Google maps - google.maps.Marker");
    var marker = new google.maps.Marker({
        position: myLatlng,
        title: "FET location"
    });

    console.log("Google maps - setMap");
    marker.setMap(map);

    var infowindow = new google.maps.InfoWindow();

    // Add interaction listeners to make weather requests
    google.maps.event.addListener(map, 'idle', checkIfDataRequested);

    // Sets up and populates the info window with details
    map.data.addListener('click', function (event) {
        infowindow.setContent(
            "<img src=" + event.feature.getProperty("icon") + ">"
            + "<br /><strong>" + event.feature.getProperty("city") + "</strong>"
            + "<br />" + event.feature.getProperty("temperature") + "&deg;C"
            + "<br />" + event.feature.getProperty("weather")
        );
        infowindow.setOptions({
            position: {
                lat: event.latLng.lat(),
                lng: event.latLng.lng()
            },
            pixelOffset: {
                width: 0,
                height: -15
            }
        });
        infowindow.open(map);
    });

}

var checkIfDataRequested = function () {
    // Stop extra requests being sent
    while (gettingData === true) {
        request.abort();
        gettingData = false;
    }
    getCoords();
};

// Get the coordinates from the Map bounds
var getCoords = function () {
    var bounds = map.getBounds();
    var NE = bounds.getNorthEast();
    var SW = bounds.getSouthWest();
    getWeather(NE.lat(), NE.lng(), SW.lat(), SW.lng());
};

// Make the weather request
var getWeather = function (northLat, eastLng, southLat, westLng) {
    gettingData = true;
    var requestString = "https://api.openweathermap.org/data/2.5/box/city?bbox="
        + westLng + "," + northLat + "," //left top
        + eastLng + "," + southLat + "," //right bottom
        + map.getZoom()
        + "&cluster=yes&format=json"
        + "&APPID=" + openWeatherMapKey;
    console.log("getWeather: This is the v19 request String: " + requestString);
    request = new XMLHttpRequest();
    request.onload = proccessResults;
    request.open("get", requestString, true);
    request.send();
};

// Clear data layer and geoJSON
var resetData = function () {
    geoJSON = {
        type: "FeatureCollection",
        features: []
    };
    map.data.forEach(function (feature) {
        map.data.remove(feature);
    });
};


// Add the markers to the map
var drawIcons = function (weather) {
    map.data.addGeoJson(geoJSON);
    // Set the flag to finished
    gettingData = false;
};

// For each result that comes back, convert the data to geoJSON
var jsonToGeoJson = function (weatherItem) {
    var feature = {
        type: "Feature",
        properties: {
            city: weatherItem.name,
            weather: weatherItem.weather[0].main,
            temperature: weatherItem.main.temp,
            min: weatherItem.main.temp_min,
            max: weatherItem.main.temp_max,
            humidity: weatherItem.main.humidity,
            pressure: weatherItem.main.pressure,
            windSpeed: weatherItem.wind.speed,
            windDegrees: weatherItem.wind.deg,
            windGust: weatherItem.wind.gust,
            icon: "https://openweathermap.org/img/w/"
                + weatherItem.weather[0].icon + ".png",
            coordinates: [weatherItem.coord.Lon, weatherItem.coord.Lat]
        },
        geometry: {
            type: "Point",
            coordinates: [weatherItem.coord.Lon, weatherItem.coord.Lat]
        }
    };
    // Set the custom marker icon
    map.data.setStyle(function (feature) {
        return {
            icon: {
                url: feature.getProperty('icon'),
                size: new google.maps.Size(100, 100),
                anchor: new google.maps.Point(0, 0)
            }
        };
    });
    // returns object
    return feature;
};


// Take the JSON results and proccess them
var proccessResults = function () {
    console.log("proccessResults: Response text" + this.responseText);
    var results;
    try {
        results = JSON.parse(this.responseText);
    } catch (e) {
        console.log("JSON.parse exception: " + e);
        return;
    }

    // Check if the resultant object is null; can happen if the response string is empty.
    console.log("processResults: check for null object and empty typeof undefined  string");

    if (typeof results !== 'undefined') {
        if (typeof results.list !== 'undefined') {
            if (results.list.length > 0) {
                resetData();
                for (var i = 0; i < results.list.length; i++) {
                    geoJSON.features.push(jsonToGeoJson(results.list[i]));
                }
                drawIcons(geoJSON);
            }
        }
        else {
            console.log("processResults: parsed object results.list undefined");
        }
    }
    else {
        console.log("processResults: parsed object undefined");
    }
};