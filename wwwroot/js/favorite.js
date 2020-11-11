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
        .then(function (res) { console.log(res); window.location.href = "https://localhost:44335/requests" })
        .catch(function (res) { console.log(res) })
}

function sendFavorite() {
    let data = createFav();
    console.log(data);
    sendData("/favorite-pet", data);
}
