/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />

var GerarSacolas = new Object();

GerarSacolas.URLLiberar = '';


$(document).ready(function ()
{
    if ($("#NivelId").val() !== 0)
    {
        $("#Nivel").val($("#NivelId").val());
    }
    if ($("#AnoValue").val() !== 0)
    {
        $("#Ano").val($("#AnoValue").val());
    }
    //GerarSacolas.MontarTabela();
    //GerarSacolas.URLExcluirSacola = $("#URLExcluirSacola").val();
    //GerarSacolas.URLDevolver = $("#URLDevolver").val();


});

GerarSacolas.Pesquisar = function ()
{
    var ano = $("#AnoPesquisa").val();

    if ((ano === 0) && (ano === 0))
    {
        location.href = '/Sacolas/GerarSacolas';
    }
    else
    {
        location.href = '/Sacolas/GerarSacolas/' + ano ;
    }
}