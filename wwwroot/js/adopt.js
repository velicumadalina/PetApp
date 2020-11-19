function showDiv() { document.getElementById("adoptionForm").style = "display:flex" };
function hideDiv() { document.getElementById("adoptionForm").style = "display:none" };
let fname = document.getElementById("fname");
let lname = document.getElementById("lname");
let phone = document.getElementById("phone");
let email = document.getElementById("email");

let animalId = document.getElementById("animalId");
let animalName = document.getElementById("animalName");
let animalImage = document.getElementById("animalImage");
let shelterId = document.getElementById("shelterId");
let userName = document.getElementById("userName");
let userId = document.getElementById("userId");
let status = "Pending";
let showIfAlreadyAdopted = document.getElementById("showAdopt");
let hideIfShelter = document.getElementById("hideAdopt");

let showIfAlreadyFav = document.getElementById("showFav");
let hideIfShelterFav = document.getElementById("hideFav");


function sendAdoption()
{
    if (validateAdoption()) {
        let data = getFormData();
        sendData("/adopt-pet", data);
        hideDiv();
    }
}
window.onload = () =>
{
    getIsUserShelter();
    getIsRequestMade();
    getIsUserShelterFav();
    getIsRequestMadeFav();

}

function getIsUserShelter() {
    fetch("/is-user-shelter/" + userId.value,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "GET",
        })
        .then(response => response.json())
        .then(data => { if (data == false) { hideIfShelter.style.display = "block"; showIfAlreadyAdopted.style.display = "none"; getIsRequestMade() } })
        .catch(function (res) { console.log(res) })
}

function getIsRequestMade() {
    fetch("/is-request-already-made/" + userId.value + "/" + animalId.value,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "GET",
        })
        .then(response => response.json())
        .then(data => { if (data == true) { hideIfShelter.style.display = "none"; showIfAlreadyAdopted.style.display = "block"; } })
        .catch(function (res) { console.log(res) })
}

function validateAdoption() {
    let wrongFields = false;
    if (!validateEmail(email.value)) { document.getElementById("emailValidate").style.display = "block"; wrongFields = true; }
    else { document.getElementById("emailValidate").style.display = "none"}
    if (isNaN(phone.value) || phone.value == "" || (!isNaN(phone.value) && phone.value.length != 10) ) { document.getElementById("phoneValidate").style.display = "block"; wrongFields = true; }
    else { document.getElementById("phoneValidate").style.display = "none"}
    if (fname.value == "") {
        document.getElementById("fnValidate").style.display = "block"; wrongFields = true;
    }
    else { document.getElementById("fnValidate").style.display = "none" }
    if (lname.value == "") {
        document.getElementById("lnValidate").style.display = "block"; wrongFields = true;
    }
    else { document.getElementById("lnValidate").style.display = "none"}
    if (message.value == "") {
        document.getElementById("messageValidate").style.display = "block"; wrongFields = true;
    }
    else { document.getElementById("messageValidate").style.display = "none"}
    if (wrongFields) { return false; }
    return true;
}
function getFormData() {
    let adoptionRequestObject =
    {
        "AnimalId": parseInt(animalId.value),
        "AnimalName": animalName.value,
        "AnimalImage": animalImage.value,
        "ShelterId": parseInt(shelterId.value),
        "UserId": parseInt(userId.value),
        "UserName": userName.value,
        "PhoneNumber": phone.value.toString(),
        "Email": email.value,
        "AdoptionMessasge": message.value,
        "AdoptionStatus": status
    }
    return adoptionRequestObject;
}

function validateEmail(email) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function createValidationErrorMessage(message) {
    let p = document.createElement("p");
    p.style = "color:red";
    p.innerText = message
    return p;
}

function sendData(endpoint, data) {
    fetch(endpoint,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "POST",
            body: JSON.stringify(data)
        })
        .then(function (res) { window.location.href = "https://localhost:44335/requests" })
        .catch(function (res) { console.log(res) })
}

function getIsUserShelterFav() {
    fetch("/is-user-shelter/" + userId.value,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "GET",
        })
        .then(response => response.json())
        .then(data => { if (data == false) { hideIfShelterFav.style.display = "block"; showIfAlreadyFav.style.display = "none"; getIsRequestMadeFav() } })
        .catch(function (res) { console.log(res) })
}

function getIsRequestMadeFav() {
    fetch("/is-request-already-made-favorite/" + userId.value + "/" + animalId.value,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "GET",
        })
        .then(response => response.json())
        .then(data => { if (data == true) { console.log(data); hideIfShelterFav.style.display = "none"; showIfAlreadyFav.style.display = "block"; } })
        .catch(function (res) { console.log(res) })
}



function deleteFav() {
    sendDeleteFav();
    setTimeout(function () { location.reload() }, 500);
}





function sendDeleteFav() {
    fetch("/favorite/delete/" + parseInt(animalId.value),
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "GET",
        })
        .then(response => response.json())
        .then(data => { hideIfShelterFav.style.display = "block"; showIfAlreadyFav.style.display = "none" })
        .catch(function (res) { console.log(res) })
}












let animalIdFav = document.getElementById("animalIdFav");
let animalNameFav = document.getElementById("animalNameFav");
let animalImageFav = document.getElementById("animalImageFav");
let userIdFav = document.getElementById("userIdFav");


function createFav() {
    let favPetObject =
    {
        "AnimalId": parseInt(animalId.value),
        "AnimalName": animalName.value,
        "AnimalImage": animalImage.value,
        "UserId": parseInt(userId.value),
    }
    return favPetObject;
}


function sendDataFav(endpoint, data) {
    fetch(endpoint,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "POST",
            body: JSON.stringify(data)
        })
        .then(function (res) { })
        .catch(function (res) { console.log(res) })
}

function sendFavorite() {
    let data = createFav();
    sendDataFav("/favorite-pet", data);
    setTimeout(function () { location.reload() }, 500);
}



