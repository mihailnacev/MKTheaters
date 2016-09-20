$(document).ready(function () {
    $(".options").hover(function () {
        $(this).css({ "background-color": "#F0CB01", "border": "3px solid darkred" });
    }, function () {
        $(this).css({ "background-color": "#FFFFFF", "border": "none" });
    });

    $("#btnOcena").hide();
    $("#ocenaHidden").hide();

    $("#btnOcenaClickable").click(function () {
        var counter = 0;
        $(".star").each(function () {
            var v = $(this).attr("star");
            if (v == "true") {
                counter++;
            }
        });
        if (counter != 0) {
            $("#ocenaHidden").val(counter + 5);
            $("#btnOcena").trigger("click");
        }
    });

    $("#ddlPretstavi").change(function () {
        $(".star").text("☆");
        $(".star").attr("star", "false");
    });

    $(".star").click(function () {
        $(this).css({ "color": "darkred" });
        $(this).text("★");
        $(this).attr("star", "true");
        $(this).nextAll().css({ "color": "darkred" });
        $(this).nextAll().text("★");
        $(this).nextAll().attr("star", "true");
        $(this).prevAll().css({ "color": "#BA252A" });
        $(this).prevAll().text("☆");
        $(this).prevAll().attr("star", "false");
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