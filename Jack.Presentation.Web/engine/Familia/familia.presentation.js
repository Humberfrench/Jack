/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="familia.js" />
/// <reference path="familia.controler.js" />
/// <reference path="/engine/geral/status.js" />
/// <reference path="/engine/geral/mensagem.js" />
/// <reference path="/engine/geral/util.js" />

$(function ()
{
    // Load Combo3
    Familia.LoadStatus(ddlStatus, Status.LoadForFamily());

    //$("#txtNivel").val($("#ddlNivel").val());
    //$("#txtStatus").val($("#ddlStatus").val());

    //$("#ddlStatus").select2();
    //$("#ddlNivel").select2();

    //$("#ddlNivel").on("select2:select", function (e) { Select2OnChange(e, txtNivel); });
    //$("#ddlStatus").on("select2:select", function (e) { Select2OnChange(e, txtStatus); });

});
