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


var Reuniao = new Object;

Reuniao.LoadDatas = function (intAno)
{
    var objRet = null;
    $.ajax({
        type: 'GET',
        url: '/api/DataReuniao/' + intAno,
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