﻿$(document).ready(function ()
{
    if ($(window).width() < 750)
    {
        $("#menu a").addClass("menuItem2");
        $("#logo").addClass("logoPosition1");
        $("#menu").addClass("menuPosition");
        $("#header").addClass("headerHeight3");
    }
    else if ($(window).width() < 1100)
    {
        $("#menu a").addClass("menuItem3");
        $("#logo").addClass("logoPosition1");
        $("#menu").addClass("menuPosition");
        $("#header").addClass("headerHeight2");
    }
    else
    {
        $("#menu a").addClass("menuItem1");
        $("#logo").addClass("logoPosition2");
        $("#header").addClass("headerHeight1");
    }
    $("a").hover(function () {
        $(this).css({ "background-color": "#F0CB01", "border": "3px solid #BA252A" });
    }, function () {
        $(this).css({ "background-color": "#FFFFFF", "border": "none" });
    });

    $(window).resize(function ()
    {
        var w = $(window).width();
        if (w < 750)
        {
            $("#menu a").removeClass("menuItem1");
            $("#menu a").addClass("menuItem2");
            $("#menu a").removeClass("menuItem3");
            $("#logo").addClass("logoPosition1");
            $("#logo").removeClass("logoPosition2");
            $("#menu").addClass("menuPosition");
            $("#header").removeClass("headerHeight1");
            $("#header").removeClass("headerHeight2");
            $("#header").addClass("headerHeight3");
        }
        else if (w < 1100)
        {
            $("#menu a").removeClass("menuItem1");
            $("#menu a").removeClass("menuItem2");
            $("#menu a").addClass("menuItem3");
            $("#logo").addClass("logoPosition1");
            $("#logo").removeClass("logoPosition2");
            $("#menu").addClass("menuPosition");
            $("#header").removeClass("headerHeight1");
            $("#header").addClass("headerHeight2");
            $("#header").removeClass("headerHeight3");
        }
        else
        {
            $("#menu a").addClass("menuItem1");
            $("#menu a").removeClass("menuItem2");
            $("#menu a").removeClass("menuItem3");
            $("#logo").removeClass("logoPosition1");
            $("#logo").addClass("logoPosition2");
            $("#menu").removeClass("menuPosition");
            $("#header").addClass("headerHeight1");
            $("#header").removeClass("headerHeight2");
            $("#header").removeClass("headerHeight3");
        }
    });
})