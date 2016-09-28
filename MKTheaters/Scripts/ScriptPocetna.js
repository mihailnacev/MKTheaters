$(document).ready(function () {
    $("#SiteMap").hide();

    $("#skrienoKopche").hide();

    $("#skrienTextBox").hide();

    $(".carouselButton").click(function () {
        $("#skrienTextBox").val($(this).attr("title"));
        event.preventDefault();
        $("#skrienoKopche").trigger("click");
    })
})

$('.carousel').carousel();