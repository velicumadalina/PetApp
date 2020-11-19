function validateEmail(email) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}
let email = document.getElementById("email");
let errorDiv = document.getElementById("wrongEmailU");

function validateRegister() {
    if (!validateEmail(email.value)) { errorDiv.style.display = "block" }
    else { errorDiv.style.display = "none"}
    return validateEmail(email.value);
}