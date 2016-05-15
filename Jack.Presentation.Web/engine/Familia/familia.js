/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="/engine/geral/status.js" />
/// <reference path="/engine/geral/mensagem.js" />
/// <reference path="/engine/geral/util.js" />
/// <reference path="familia.controller.js" />
/// <reference path="familia.presentation.js" />

//TO SELECT 2 LOOK AT https://select2.github.io/examples.html


var Familia = new Object;
var urlApi = 'http://localhost:7107';


Familia.Consistir = function()
{
    var blnRetorno = true;
    var strMensagem = '';

    if ($("#txtCodigo").val() == '')
    {
        $("#txtCodigo").val() = 0;
    }

    if ($("#txtNome").val() == '')
    {
        strMensagem = strMensagem + 'Preencher campo Nome';
        blnRetorno = false;
    }

    if (strMensagem != '')
    {
        Mensagem.Erro(strMensagem);
    }

    return blnRetorno;
}

Familia.Salvar = function (objFamilia)
{
    var intCodigo;
    var strConsistente = Familia.TratarCheck(objFamilia.IsConsistente);
    var strSacola = Familia.TratarCheck(objFamilia.IsSacolinha);

    if (objFamilia.Codigo == undefined)
    {
        intCodigo = 0;
    }
    else 
    {
        intCodigo = parseInt(objFamilia.Codigo);
    }

    //var sData = ''
    //sData = sData + '?Codigo=' + intCodigo;
    //sData = sData + '&Familia=' + objFamilia._Familia;
    //sData = sData + '&Contato=' + objFamilia._Contato;
    //sData = sData + '&Status=' + objFamilia._Status;
    //sData = sData + '&Nivel=' + objFamilia._Nivel;
    //sData = sData + '&IsSacolinha=' + strSacola;
    //sData = sData + '&IsConsistente=' + strConsistente;

    $.ajax({
        type: 'POST',
        url: '/api/familia/Salvar/',
        dataType: 'json',
        data: JSON.stringify(objFamilia),
        cache: 'false',
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data, textStatus, xhr)
        {
            Mensagem.Sucesso("Dados Salvos comn Sucesso!");
        },
        error: function (xhr, msg, e)
        {
            Mensagem.Erro(xhr.responseText);
        }
    });

};

Familia.TratarCheck = function (oCampoCheck)
{
    var strValor = '';
    if (oCampoCheck == undefined)
    {
        strValor = 'N';
    }
    else
    {
        if (oCampoCheck)
        {
            strValor = 'S';
        }
        else
        {
            strValor = 'N'
        }
    }
    return strValor;
};

Familia.Delete = function (intItem)
{

};

Familia.LoadStatus = function ()
{
    var objRet = null;
    var url = '/Status/Familia/';
    var opt = '<option value="-1">Selecione</option>';
    $.get(url).success(function (data)
    {
        var listaDados = eval(data);
        $("#selStatus").innerHTML = '';
        for (intCont = 0; intCont < listaDados.length; intCont++)
        {
            opt = opt + '<option value="' + listaDados[intCont].Codigo + '"><'
            opt = opt + listaDados[intCont].Descricao + '>'

        }
        // then append it to the select element
        $("#selStatus").innerHTML(opt);
    }).fail(function (xhr, msg, e)
    {
        Mensagem.Erro(xhr.statusText);
    });

}
