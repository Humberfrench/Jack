/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />

var QrCode = new Object();

$("#Gerar").click(function ()
{
    QrCode.Obter(128, 128, 151);
});

QrCode.Obter = function (width, height, crianca)
{

    var opcoes = new Object;
    opcoes.url = '/Sacolas/GerarQrCode/';

    opcoes.callBackSuccess = function (response)
    {
        //var dataObj = eval(response);
        var image = new Image();
        image.src = "data:image/png;base64," + response;
        $("#divImagemChave").html(image);
    }

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.width = width;
    opcoes.dadoEnvio.height = height;
    opcoes.dadoEnvio.crianca = crianca;

    Ajax.Post(opcoes);

}