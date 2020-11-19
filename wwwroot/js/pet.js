$(document).ready(function () {

    $(".toggle").click(function () {
        if (
            $(this).hasClass("clicked")
        ) {
            $(this).removeClass("clicked");
        }
        else { $(this).addClass("clicked") }
    })

    $(".answer").click(function () {
        var count = 0;
        if (
            $(this).hasClass("clicked")
        ) {
            $(this).removeClass("clicked");
        } else {
            $(this).addClass("clicked");
        }
    })
})




$("#subBtn").click(function () {
    let animal = turnToObject();
    if (validateCreatedObject(animal)) {
        sendData("/add-animal", turnToObject());
    }
})

function validateCreatedObject(object) {
    let isValid = true;
    Object.keys(object).forEach(function (e) { if (object[e] === "" || object[e] === null) { isValid = false; document.getElementById("val").style.display = "block"; } });
    return isValid;
}



let shelterId = document.getElementById("shelterId");
let petImage = document.getElementById("pet-image");
let petName = document.getElementById("pet-name");
let petBreed = document.getElementById("pet-breed");
let characteristics = document.getElementById("characteristics");
let description = document.getElementById("description");


function turnToObject() {
    let vals = {
        "Image": petImage.value.split("\\")[2],
        "Name": petName.value,
        "Breed": petBreed.value,
        "Characteristics": characteristics.value,
        "Description": description.value,
        "ShelterId": parseInt(shelterId.value)
    };
    let keyNames = ["Type", "Age", "Gender", "Size", "EnergyLevel", "Hair", "FriendlyWithDogs", "FriendlyWithCats", "FriendlyWithKids", "SpecialNeeds"]
    let selected = $(".clicked");
    for (let i = 0; i < keyNames.length; i++) {
        let divs = $(selected).filter(function () {
            return $(this).data("title") == i + 1;
        })
        let divValues = []
        for (val of divs) {
            if (val.dataset.val === "true") {
                let trueVal = true;
                divValues.push(trueVal);
            }
            else {
                divValues.push(val.dataset.val);
            }
        }
        if (divValues.length < 1 && ( i >=6)) {
            vals[keyNames[i]] = false;
        }
        else {
            
            vals[keyNames[i]] = divValues[0];
        }
    }
    return vals;
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
        .then(function (res) { console.log(res); window.location.href = "https://localhost:44335/shelter-profile"})
        .catch(function (res) { console.log(res) })
}