/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="status.js" />

var Status = new Object;


Status.LoadForChildrem = function ()
{
    var objRet = null;
    $.ajax({
        type: 'GET',
        url: '/api/status/Get/LoadForChildrem/',
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
}

Status.LoadForFamily = function ()
{
    var objRet = null;
    $.ajax({
        type: 'GET',
        url: '/api/status/Get/LoadForFamily/',
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
}
