$(document).ready(function () {
    $("#termin").val($("#ddlDatumi option:selected").text());

    $("#btnRezerviraj").hide();

    $("#ddlDatumi").change(function () {
        $("#termin").val($("#ddlDatumi option:selected").text());
    });

    $("#btnShowModal").click(function () {
        $("#modal").dialog("open");
    });

    $("#modal").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            Резервирај: function () {
                $("#btnRezerviraj").trigger("click");
            },
            Откажи: function () {
                $("#modal").dialog("close");
            }
        }
    });

})