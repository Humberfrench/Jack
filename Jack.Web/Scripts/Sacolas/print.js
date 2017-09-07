/// <reference path="QrCode.js" />
var PrintSacola = new Object;

PrintSacola.Crianca = '';

$(function ()
{

    PrintSacola.Crianca = $("#Crianca").val();

    if (PrintSacola.Crianca === '')
    {
        return;
    }

    QrCode.Obter(160, 160, PrintSacola.Crianca, "#divImagemChave");

});