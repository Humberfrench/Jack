/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="status.js" />
/// <reference path="familia.controller.js" />

//TO SELECT 2 LOOK AT https://select2.github.io/examples.html


var Familia = new Object;

Familia.Load = function ()
{
    var objRet = null;
    $.ajax({
        type: 'GET',
        url: '/api/familia/',
        dataType: 'json',
        cache: 'false',
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (data, textStatus, xhr)
        {
            objRet = data;
        },
        error: function (xhr, msg, e)
        {
            Mensagem.Erro(xhr.responseText);
        }
    });

    return objRet;

};

Familia.Salvar = function (objFamilia)
{
    var intCodigo;
    var strConsistente = Familia.TratarCheck(objFamilia._IsConsistente);
    var strSacola = Familia.TratarCheck(objFamilia._IsSacolinha);

    if (objFamilia._Codigo == undefined)
    {
        intCodigo = 0;
    }
    else 
    {
        intCodigo = parseInt(objFamilia._Codigo);
    }

    var sData = ''
    sData = sData + '?Codigo=' + intCodigo;
    sData = sData + '&Familia=' + objFamilia._Familia;
    sData = sData + '&Contato=' + objFamilia._Contato;
    sData = sData + '&Status=' + objFamilia._Status;
    sData = sData + '&Nivel=' + objFamilia._Nivel;
    sData = sData + '&IsSacolinha=' + strSacola;
    sData = sData + '&IsConsistente=' + strConsistente;
    $.ajax({
        type: 'POST',
        url: '/api/familia/Salvar/' + sData,
        dataType: 'json',
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

Familia.LoadStatus = function (comboBox, listaDados)
{
    comboBox.innerHTML = '';
    for (intCont = 0; intCont < listaDados.length; intCont++)
    {
        var opt = document.createElement("option");
        opt.value = listaDados[intCont]._Codigo;
        opt.innerHTML = listaDados[intCont]._Descricao; // whatever property it has

        // then append it to the select element
        comboBox.appendChild(opt);
    }
}
