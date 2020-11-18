
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
    sendData("/my-perfect-pet", turnToObject());
    
})

function turnToObject()
{
    let vals = { "Id": 1 };
    let keyNames = ["Type", "Breed", "Age", "EnergyLevel", "Size", "Gender","Hair", "FriendlyWithDogs", "FriendlyWithCats", "FriendlyWithKids", "SpecialNeeds"]
    let selected = $(".clicked");
    for (let i = 0; i < keyNames.length; i++) {
        let divs = $(selected).filter(function () {
            return $(this).data("title") == i + 1;
        })
        let divValues = []
        for (val of divs) {
            divValues.push(val.dataset.val);
        }
        if (divValues.length < 1) {
            vals[keyNames[i]] = ["false"];
        }
        else {
            vals[keyNames[i]] = divValues;
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
                'Content-Type': 'application/json',
            },
            method: "POST",
            body: JSON.stringify(data),
        })
        .then(function (res) { console.log(res); window.location.href = "https://localhost:44335/my-perfect-pets"})
        .catch(function (res) { console.log(res) })
    //$.post(endpoint, data).then(function (res) { console.log(res); })
}
