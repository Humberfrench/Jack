
$(function ()
{
    // Load Combo
    Familia.LoadStatus(ddlStatus, Status.LoadForFamily());

    $("#txtNivel").val($("#ddlNivel").val());
    $("#txtStatus").val($("#ddlStatus").val());

    $("#ddlStatus").select2();
    $("#ddlNivel").select2();

    $("#ddlNivel").on("select2:select", function (e) { Select2OnChange(e, txtNivel); });
    $("#ddlStatus").on("select2:select", function (e) { Select2OnChange(e, txtStatus); });

});
