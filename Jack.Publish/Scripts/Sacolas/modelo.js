
var Modelo = new Object();
Modelo.URLGerarQrCode = '';

$(document).ready(function ()
{

    URLGerarQrCode.URLGerarQrCode = $("#URLGerarQrCode").val();

    if ($("#Crianca1").val() !== 0)
    {
        Modelo.Gerar(128,128, $("#Crianca1").val());
    }
    
});

Modelo.Gerar = function (width, height, crianca)
{
    var opcoes = new Object;
    opcoes.url = URLGerarQrCode.URLGerarQrCode;

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