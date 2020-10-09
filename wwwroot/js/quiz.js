$(document).ready(function () {
	// When someone clicks an answer...
	$(".answer").click(function () {
		if (
			!$(this).hasClass("clicked")
		) {
			$(this).addClass("clicked");
		}
	})
})