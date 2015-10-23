
$(function ()
{
    // Load Combo
    Familia.LoadStatus(ddlStatus, Status.LoadForFamily());

    $("#ddlStatus").select2();
    $("#ddlNivel").select2();
    $("#ddlNivel").on("select2:select", function (e) { Select2OnChange(e, txtNivel); });
    $("#ddlStatus").on("select2:select", function (e) { Select2OnChange(e, txtStatus); });
});
