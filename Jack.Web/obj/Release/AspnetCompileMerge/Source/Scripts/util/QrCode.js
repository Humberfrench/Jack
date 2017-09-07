var QrCode = new Object;

QrCode.Gerar = function (width, height, crianca, divImagem, url)
{
    var opcoes = new Object;
    opcoes.url = url;

    opcoes.callBackSuccess = function (response)
    {
        //var dataObj = eval(response);
        var image = new Image();
        image.src = "data:image/png;base64," + response;
        $(divImagem).html(image);
    }

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.width = width;
    opcoes.dadoEnvio.height = height;
    opcoes.dadoEnvio.crianca = crianca;

    Ajax.Post(opcoes);
}