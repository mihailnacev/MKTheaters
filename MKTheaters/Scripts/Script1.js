$(document).ready(function ()
{
    if ($(window).width() < 1000)
    {
        $("#menu a").addClass("menuItem1");
    }
    else
    {
        $("#menu a").addClass("menuItem2");
    }
    $("a").hover(function () {
        $(this).css({ "background-color": "#BA252A", "color": "#F0CB01" });
    }, function () {
        $(this).css({ "background-color": "#FFFFFF", "color": "#BA252A" });
    });

    $(window).resize(function () {
        var w = $(window).width();
        if (w < 1000)
        {
            $("#menu a").removeClass("menuItem1");
            $("#menu a").addClass("menuItem2");
            $("a").css("width", w - 25);
            $("#logo").css("width", "100%");
            $("#logo").css("text-align", "center");
            //$("#logo").addClass("logoPosition1");
            //$("#logo").removeClass("logoPosition2");
        }
        else
        {
            $("#menu a").addClass("menuItem1");
            $("#menu a").removeClass("menuItem2");
            $("#logo").css("width", "30%");
            //$("#logo").addClass("logoPosition2");
            //$("#logo").removeClass("logoPosition1");
        }
    });
})