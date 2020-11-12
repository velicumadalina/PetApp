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
let showIfAlreadyAdopted = document.getElementById("asd1");
let hideIfShelter = document.getElementById("hide");



function formAction()
{
    validateFormData();
    let data = getFormData();
    console.log(data);
    sendData("/adopt-pet", data);
    hideDiv();
}
window.onload = () =>
{
    getIsUserShelter();
    getIsRequestMade();

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
        .then(data => { if (data == true) { console.log(data); hideIfShelter.style.display = "none"; showIfAlreadyAdopted.style.display = "block"; } })
        .catch(function (res) { console.log(res) })
}

function validateFormData() {
    if (fname.value == "") {
        fname.parentNode.appendChild(createValidationErrorMessage("Field cannot be empty!"));
    }
    if (lname.value == "") {
        lname.parentNode.appendChild(createValidationErrorMessage("Field cannot be empty!"));
    }
    if (phone.value == "") {
        phone.parentNode.appendChild(createValidationErrorMessage("Field cannot be empty!"));
    }
    if (email.value == "") {
        email.parentNode.appendChild(createValidationErrorMessage("Field cannot be empty!"));
    }
    if (message.value == "") {
        message.parentNode.appendChild(createValidationErrorMessage("Field cannot be empty!"));
    }
    if (isNaN(phone.value)) {
        phone.parentNode.appendChild(createValidationErrorMessage("Phone number cannot contain letters!"));
    }
    if (validateEmail(email.value) != true) {
        email.parentNode.appendChild(createValidationErrorMessage("Please enter a valid email!"));
    }
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
        .then(function (res) { console.log(res); window.location.href = "https://localhost:44335/favorites" })
        .catch(function (res) { console.log(res) })
}