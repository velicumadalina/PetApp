﻿let shelterImage = document.getElementById("shelter-image");
let shelterName = document.getElementById("shelter-name");
let shelterEmail = document.getElementById("shelter-email");
let capacity = document.getElementById("capacity");

function addShelter() {
    let ShelterObject =
    {
        "Image": shelterImage.value.split("\\")[2],
        "Name": shelterName.value,
        "Email": shelterEmail.value,
        "Capacity": parseInt(capacity.value)
    }
    return ShelterObject;
}

function sendData(endpoint, data) {
    fetch(endpoint,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json;charset=utf-8',
                'Accept-Encoding': 'gzip, deflate, br'
            },
            method: "POST",
            body: JSON.stringify(data),
        })
        .then(function (res) { console.log(res); window.location.replace("/login") })
        .catch(function (res) { console.log(res) })
}

function sendShelter() {
    let data = addShelter();
    console.log(data);
    sendData("https://localhost:44306/api/shelter/add", data);
}
