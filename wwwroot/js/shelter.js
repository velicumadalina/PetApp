let shelterImage = document.getElementById("shelter-image");
let shelterName = document.getElementById("shelter-name");
let shelterEmail = document.getElementById("shelter-email");
let capacity = document.getElementById("capacity");
let userId = document.getElementById("userId").value;


function sendData(endpoint, data) {
    fetch(endpoint,
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json;charset=utf-8',
                'Accept-Encoding': 'gzip, deflate, br'
            },
            method: "POST",
            body: JSON.stringify(data)
            
        })
        .then(function (res) { console.log(res) })
        .catch(function (res) { console.log(res) })
}


//$("#submitBtnShelter").click(function (e) {
//    if ($(this).hasClass('prevented')) {
//        if (sendShelter()) {
//            $(this).removeClass('prevented');
//        }
//    } else {
//        $(this).addClass('prevented');
//        e.preventDefault();
//        sendShelter();
//    }
//});

function sendShelter() {
    
    let data = {
            "Image": shelterImage.value.split("\\")[2],
            "Name": shelterName.value,
            "Email": shelterEmail.value,
            "Capacity": parseInt(capacity.value),
            "UserId": parseInt(userId)
    }
    return validateCreatedShelter(data);
        
   
}


function validateEmail(email) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function validateCreatedShelter(object) {
    let invalid = 0;
    Object.keys(object).forEach(function (e) { if (object[e] === "" || object[e] === null) { invalid++; document.getElementById("isEmpty").style.display = "block"; } });
    console.log(validateEmail(shelterEmail.value));
    if (validateEmail(shelterEmail.value) === false) { document.getElementById("wrongEmail").style.display = "block"; invalid++; }
    else { document.getElementById("wrongEmail").style.display = "none"; }
    if (isNaN(capacity.value) || parseInt(capacity.value) < 1 ) { document.getElementById("wrongCapacity").style.display = "block"; invalid++; }
    else { document.getElementById("wrongCapacity").style.display = "none"; }
    return invalid <= 0;
}
