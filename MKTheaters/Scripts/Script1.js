$(document).ready(function ()
{
    $(".menuItem").hover(function () {
        $(this).css("background-color", "lightGrey");
    }, function () {
        $(this).css("background-color", "white");
    });
});