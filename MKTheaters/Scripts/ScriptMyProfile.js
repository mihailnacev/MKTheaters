$(document).ready(function ()
{
    $(".options").hover(function () {
        $(this).css({ "background-color": "#F0CB01", "border": "3px solid darkred" });
    }, function () {
        $(this).css({ "background-color": "#FFFFFF", "border": "none" });
    });

    $(".TextBoxes").hide();
    $(".PassTextBoxes").hide();
    $("#btnOtkazi").hide();
    $("#btnZachuvaj").hide();
    $("#btnPromeniLozinka").hide();
    $("#btnPromeni").click(function () {
        $(".TextBoxes").toggle();
        $(".Labels").toggle();
        $("#btnOtkazi").toggle();
        $("#btnZachuvaj").toggle();
        $("#btnPromeniLozinka").toggle();
        $(this).toggle();
    });

    $("#btnOtkazi").click(function () {
        $(".TextBoxes").toggle();
        $(".Labels").toggle();
        $("#btnZachuvaj").toggle();
        $("#btnPromeniLozinka").toggle();
        $(this).toggle();
        $("#btnPromeni").toggle();
        $(".PassTextBoxes").hide();
        $("#revEmail:visible").css({ "visibility": "hidden" });
        $("#revPass:visible").css({ "visibility": "hidden" });
        $("#cvLozinki:visible").css({ "visibility": "hidden" });
        $("#txtFirstNameText").val($("#lblFirstNameText").text());
        $("#txtLastNameText").val($("#lblLastNameText").text());
        $("#txtEmailText").val($("#lblEmailText").text());
    });

    $("#btnPromeniLozinka").click(function () {
        $(".PassTextBoxes").toggle();
        $("#cvLozinki:visible").css({ "visibility": "hidden" });
        $("#revPass:visible").css({ "visibility": "hidden" });
    });

    $("#revEmail").tooltip();
    $("#revPass").tooltip();
    $("#cvLozinki").tooltip();
})