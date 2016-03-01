/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="/engine/geral/status.js" />
/// <reference path="/engine/geral/mensagem.js" />
/// <reference path="/engine/geral/util.js" />
/// <reference path="chamada.controller.js" />
/// <reference path="chamada.presentation.js" />

//TO SELECT 2 LOOK AT https://select2.github.io/examples.html


var Chamada = new Object;

Chamada.Load = function (ID)
{
    var objRet = null;
    if (ID == 0)
    {
        return;
    }
    $.ajax({
        type: 'GET',
        url: '/api/chamada/' + ID,
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

Chamada.LoadMneumonicos = function (ID, Letter)
{
    var objRet = null;
    if (ID == 0)
    {
        return;
    }
    if (Letter == '')
    {
        return;
    }
    else if (Letter == 'Todos')
    {
        return Chamada.Load(ID);
    }

    var stringChamada = '?ID=' + ID + '&letter=' + Letter
    $.ajax({
        type: 'GET',
        url: '/api/ChamadaFiltro/' + stringChamada,
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
Chamada.LoadFiltro = function (ID)
{
    var objRet = null;
    if (ID == 0)
    {
        return;
    }
    $.ajax({
        type: 'GET',
        url: '/api/ChamadaFiltro/' + ID,
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

Chamada.Registrar = function ()
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
