$(document).ready(function ()
{
    $(".menuItem").hover(function () {
        $(this).css({ "background-color": "#BA252A", "color": "#F0CB01" });
    }, function () {
        $(this).css({ "background-color": "#FFFFFF", "color": "#BA252A" });
    });
})