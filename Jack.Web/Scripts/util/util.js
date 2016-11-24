/// <reference path="mensagens.js" />

var Util = new Object;

Util.SomenteNumeros = function (eventField)
{
    evt = (eventField) ? eventField : window.event;
    var charCode = (eventField.which) ? eventField.which : eventField.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
    {
        return false;
    }
    return true;
};

Util.ObterLista = function (value, text)
{
    var optionData = "";
    optionData += '<option value="' + value + '">' + text + '</option>';
    return optionData;
};

Util.ValidaEmail = function (strEmail)
{
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

    if (!emailReg.test(strEmail))
    {
        return false;
    }

    return true;
};

Util.FormatarString = function ()
{
    var retornoString = arguments[0];
    for (var i = 1; i < arguments.length; i++)
    {
        var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        retornoString = retornoString.replace(regEx, arguments[i]);
    }

    return retornoString;
};

Util.SomenteCaracteres = function (e)
{
    var expressao = /[a-zA-Z]/;

    if (expressao.test(String.fromCharCode(e.keyCode)))
    {
        return true;
    }
    return false;
}

Util.SomenteCaracteresENumeros = function (e)
{
    var expressao = /[a-zA-Z0-9]/;

    if (expressao.test(String.fromCharCode(e.keyCode)))
    {
        return true;
    }
    return false;
}

Util.GetBase64 = function (file)
{
    var reader = new FileReader();

    reader.readAsDataURL(file);

    reader.onload = function ()
    {
        return reader.result;
    };
    reader.onerror = function (error)
    {
        Mensagens.Erro('Error: ', error);
    };
}

Util.VerificaCaracteresIndesejados = function (textForm)
{

    if (textForm.match(['[-@!#$%¨&*+_´`^~;:?áÁéÉíÍóÓúÚãÃçÇ|\?,./{}"<>()]']))
    {
        return true;
    }
    else
    {
        return false;
    }

}
Util.VerificaCaracteresIndesejadosSemEspacos = function (textForm)
{

    if (textForm.match(['[-@!#$%¨&*+_´`^~;:?áÁéÉíÍóÓúÚãÃçÇ|\?,./{}"<>() ]']))
    {
        return true;
    }
    else
    {
        return false;
    }

}

Util.TesteOverloading = function (dados)
{
    alert(dados.valor1);
    alert(dados.valor2);
    alert(dados.valor3);

}