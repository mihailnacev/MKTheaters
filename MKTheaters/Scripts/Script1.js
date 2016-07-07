$(document).ready(function ()
{
    if ($(window).width() < 750)
    {
        $("#menu a").addClass("menuItem2");
        $("#logo").addClass("logoPosition1");
        $("#menu").addClass("menuPosition");
    }
    else if ($(window).width() < 1100)
    {
        $("#menu a").addClass("menuItem3");
        $("#logo").addClass("logoPosition1");
        $("#menu").addClass("menuPosition");
    }
    else
    {
        $("#menu a").addClass("menuItem1");
        $("#logo").addClass("logoPosition2");
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
        }
        else if (w < 1100)
        {
            $("#menu a").removeClass("menuItem1");
            $("#menu a").removeClass("menuItem2");
            $("#menu a").addClass("menuItem3");
            $("#logo").addClass("logoPosition1");
            $("#logo").removeClass("logoPosition2");
            $("#menu").addClass("menuPosition");
        }
        else
        {
            $("#menu a").addClass("menuItem1");
            $("#menu a").removeClass("menuItem2");
            $("#menu a").removeClass("menuItem3");
            $("#logo").addClass("logoPosition2");
            $("#logo").removeClass("logoPosition1");
            $("#menu").removeClass("menuPosition");
        }
    });
})