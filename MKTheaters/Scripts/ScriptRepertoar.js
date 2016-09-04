/*$(function () {*/
//skriptata ne beshe vkluchena vo Repertoar.aspx, pa staviv vo /**/ za da ne napravam problemi :D
    /*
      $( "#dialog" ).dialog({
        autoOpen: true,
        show: {
          effect: "blind",
          duration: 1000
        },
        hide: {
          effect: "explode",
          duration: 1000
        }
      });
   
      $( "#opener" ).click(function() {
        $( "#dialog" ).dialog( "open" );
      });
      */

    /*$("#dialog").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            ok: function () {
                console.log("OK");
                $("#dialog").dialog("close");
            },
            cancel: function () {
                console.log("cancel");
                $("#dialog").dialog("close");
            }
        }
    });

    $(".OPP").click(function () {
        $("#dialog").dialog("open");
    });
});*/
$(document).ready(function ()
{
    $("#RequiredFieldValidator1").tooltip();
})