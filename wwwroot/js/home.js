$(document).ready(function(){
    $('.customer-logos').slick({
        slidesToShow: 6,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1500,
        arrows: false,
        dots: false,
        pauseOnHover: false,
        responsive: [{
            breakpoint: 768,
            settings: {
                slidesToShow: 4
            }
        }, {
            breakpoint: 520,
            settings: {
                slidesToShow: 3
            }
        }]
    });
});


var firstName = "";
var lastName = "";
var email = "";
var dType = "";
var receipt = "";
var anon = "";
var list = "";
var amount = "";

$('.set-amount').autoGrow(0);

/*
	if(isiPad || jQuery.browser.mobile){
		$('#team').hide()
		$('.team-mobile').show();	
	}else{
		$('#team').show()
		$('.team-mobile').hide();
	}
*/

