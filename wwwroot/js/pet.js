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
            var questionCount = $(this).data("title");
            count -= 1;
            $(this).removeClass("clicked");
        } else {
            var questionCount = $(this).data("title");
            var options = $(this).data("opts");
            $(this).addClass("clicked");
            $("#preselected" + questionCount).removeClass("clicked");
            var elements = $("*").filter(function () {
                return $(this).data("title") == questionCount;
            });
            console.log(elements);

            for (element of elements) {
                console.log(element);
                console.log(element.classList.contains("clicked"))
                if (element.classList.contains("clicked")) {
                    count += 1;
                    console.log(count);
                }

            }
            if (count == options) {
                for (element of elements) {
                    element.classList.remove("clicked");
                }
                $("#preselected" + questionCount).addClass("clicked");
                count = 0;
            }
        }
    })
})




$("#subBtn").click(function () {
    turnToObject();
    sendData("https://localhost:44306/api/animal/add", turnToObject());

})


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
        "ShelterId": 4
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
        if (divValues.length < 1) {
            vals[keyNames[i]] = false;
        }
        else {
            vals[keyNames[i]] = divValues[0];
        }
        console.log(vals);
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
        .then(function (res) { console.log(res) })
        .catch(function (res) { console.log(res) })
}