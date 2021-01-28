$(".button").click(function () {
    
	$(".button").removeClass("selected");
	$(this).addClass("selected");

    $(this).find("input").focus();
    console.log(document.getElementsByClassName("selected")[0]);
});

let cost;
$("#pay").click(function () {
    console.log("aaa");
    let price = document.getElementsByClassName("selected")[0];
    console.log(price);
    if (price == null) { document.getElementById("paylink").removeAttribute("href"); }
    else { document.getElementById("paylink").href = "#popup1"; }
    cost = parseInt(price.textContent.substring(1));
    //if (cost == null) { document.getElementById("paylink").href = "#"; }
    //else { document.getElementById("paylink").href = "#popup1";}
    console.log(cost);
}
    )

let modal = document.getElementById("popup1");
function turnModalToThankYou(name)
{
    let modal = document.getElementById("popup1");
    let thankYouModal = `<div class="popup">
        <h2><i class="fa fa-check-circle fa-5x"></i></h2>
        <a class="close" href="#">&times;</a>
        <div class="content">
            <div style="text-align:center">Thank you for your donation, ` + name + `!</div>
        </div>
    </div>`
    modal.innerHTML = thankYouModal;
}



paypal.Buttons({

    // Set up the transaction
    createOrder: function (data, actions) {
        return actions.order.create({
            purchase_units: [{
                amount: {
                    value: cost
                }
            }]
        });
    },

    // Finalize the transaction
    onApprove: function (data, actions) {
        return actions.order.capture().then(function (details) {
            turnModalToThankYou(details.payer.name.given_name);
            //alert('Transaction completed by ' + details.payer.name.given_name + '!');
        });
    }


}).render('#paypal-button-container');