//let accept = document.getElementById("animalNameFav");
//let animalImageFav = document.getElementById("animalImageFav");
//let userIdFav = document.getElementById("userIdFav");



//function createFav() {
//    let favPetObject =
//    {
//        "AnimalId": parseInt(animalId.value),
//        "AnimalName": animalName.value,
//        "AnimalImage": animalImage.value,
//        "UserId": parseInt(userId.value),
//    }
//    return favPetObject;
//}

//function sendData(endpoint, data) {
//    fetch(endpoint,
//        {
//            headers: {
//                'Accept': 'application/json',
//                'Content-Type': 'application/json',
//            },
//            method: "POST",
//            body: JSON.stringify(data)
//        })
//        .then(function (res) { console.log(res); window.location.href = "https://localhost:44335/favorites" })
//        .catch(function (res) { console.log(res) })
//}

//function sendFavorite() {
//    let data = createFav();
//    console.log(data);
//    sendData("/favorite-pet", data);
//}
//function deny()
//{
//    console.log(this);
//}

$('.deny').click(function () {
    console.log($(this).data("animal"));
    let data = { "id": $(this).data("animal") };
    console.log(data);
    sendData("https://localhost:44335/AdoptionRequests/Delete/" + $(this).data("animal"))
    window.location.reload();
});

function sendData(endpoint) {
    fetch(endpoint,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            method: "POST",
            
        })
        .then(function (res) { console.log(res)})
        .catch(function (res) { console.log(res) })
}

