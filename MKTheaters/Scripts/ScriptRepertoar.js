$(document).ready(function () {
    $("#RequiredFieldValidator1").tooltip();

    $("#btnRezerviraj").hide();

    $("#imeSkrieno").hide();

    $("#terminSkrieno").hide();

    $("#gvPretstavi>tbody>tr>td:nth-child(2)").each(function () {
        var val = $(this).text();
        var val2 = val.replace(/;/g, ", ");
        $(this).text(val2);
    })

    $("#gvPretstavi>tbody>tr>td:nth-child(3)").each(function () {
        var val = $(this).text();
        var val2 = val.replace(/;/g, ", ");
        $(this).text(val2);
    })

    $("#gvPretstavi>tbody>tr>td:nth-child(4)").each(function () {
        var val = $(this).text();
        var val2 = val.replace(/;/g, ", ");
        $(this).text(val2);
    })

    $("#dvPretstavi>tbody>tr>td:nth-child(2)").each(function () {
        var val = $(this).text();
        var val2 = val.replace(/;/g, ", ");
        $(this).text(val2);
    })

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

    $(".modalOpener").on("click", function () {
        $("#termin").val($(this).parent().prev().find("select option:selected").text());
        $("#terminSkrieno").val($(this).parent().prev().find("select option:selected").text());
        $("#ime").text($(this).parent().parent().find(".ime").text());
        $("#imeSkrieno").val($(this).parent().parent().find(".ime").text());
        $("#modal").dialog("open");
    })
})

function pageLoad() {
    $(".modalOpener").on("click", function () {
        $("#termin").val($(this).parent().prev().find("select option:selected").text());
        $("#terminSkrieno").val($(this).parent().prev().find("select option:selected").text());
        $("#ime").text($(this).parent().parent().find(".ime").text());
        $("#imeSkrieno").val($(this).parent().parent().find(".ime").text());
        $("#modal").dialog("open");
    })

    $("#gvPretstavi>tbody>tr>td:nth-child(2)").each(function () {
        var val = $(this).text();
        var val2 = val.replace(/;/g, ", ");
        $(this).text(val2);
    })

    $("#gvPretstavi>tbody>tr>td:nth-child(3)").each(function () {
        var val = $(this).text();
        var val2 = val.replace(/;/g, ", ");
        $(this).text(val2);
    })

    $("#gvPretstavi>tbody>tr>td:nth-child(4)").each(function () {
        var val = $(this).text();
        var val2 = val.replace(/;/g, ", ");
        $(this).text(val2);
    })

    $("#dvPretstavi>tbody>tr>td:nth-child(2)").each(function () {
        var val = $(this).text();
        var val2 = val.replace(/;/g, ", ");
        $(this).text(val2);
    })
}