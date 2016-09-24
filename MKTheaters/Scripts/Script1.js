$(document).ready(function () {
    if ($(window).width() < 800) {
        $("#menu a").addClass("menuItem2");
        $("#logo").addClass("logoPosition1");
        $("#menu").addClass("menuPosition");
        $("#header").addClass("headerHeight3");
    }
    else if ($(window).width() < 1130) {
        $("#menu a").addClass("menuItem3");
        $("#logo").addClass("logoPosition1");
        $("#menu").addClass("menuPosition");
        $("#header").addClass("headerHeight2");
    }
    else {
        $("#menu a").addClass("menuItem1");
        $("#logo").addClass("logoPosition2");
        $("#header").addClass("headerHeight1");
        $("#menu").addClass("menuPadding");
    }

    $("#menu a").hover(function () {
        $(this).css({ "background-color": "#F0CB01", "border": "3px solid darkred" });
    }, function () {
        $(this).css({ "background-color": "#FFFFFF", "border": "none" });
    });

    $("#status a").hover(function () {
        $(this).css({ "font-size": "19px" });
    }, function () {
        $(this).css({ "font-size": "18px" });
    });

    $(".Node").hover(function () {
        $(this).css({ "color": "#BA252A" });
    }, function () {
        $(this).css({ "color": "#F0CB01" });
    });

    $(window).load(function () {
        $(".se-pre-con").delay(250).fadeOut("slow");;
    });

    $(window).resize(function () {
        var w = $(window).width();
        if (w < 800) {
            $("#menu a").removeClass("menuItem1");
            $("#menu a").addClass("menuItem2");
            $("#menu a").removeClass("menuItem3");
            $("#logo").addClass("logoPosition1");
            $("#logo").removeClass("logoPosition2");
            $("#menu").addClass("menuPosition");
            $("#header").removeClass("headerHeight1");
            $("#header").removeClass("headerHeight2");
            $("#header").addClass("headerHeight3");
            $("#menu").removeClass("menuPadding");
        }
        else if (w < 1130) {
            $("#menu a").removeClass("menuItem1");
            $("#menu a").removeClass("menuItem2");
            $("#menu a").addClass("menuItem3");
            $("#logo").addClass("logoPosition1");
            $("#logo").removeClass("logoPosition2");
            $("#menu").addClass("menuPosition");
            $("#header").removeClass("headerHeight1");
            $("#header").addClass("headerHeight2");
            $("#header").removeClass("headerHeight3");
            $("#menu").removeClass("menuPadding");
        }
        else {
            $("#menu a").addClass("menuItem1");
            $("#menu a").removeClass("menuItem2");
            $("#menu a").removeClass("menuItem3");
            $("#logo").removeClass("logoPosition1");
            $("#logo").addClass("logoPosition2");
            $("#menu").removeClass("menuPosition");
            $("#header").addClass("headerHeight1");
            $("#header").removeClass("headerHeight2");
            $("#header").removeClass("headerHeight3");
            $("#menu").addClass("menuPadding");
        }
    });
})