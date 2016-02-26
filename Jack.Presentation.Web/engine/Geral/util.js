/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="status.js" />

var Util = new Object


function Select2OnChange(evt, object)
{
    object.value = evt.params.data.id;
}

Util.Anos = function ()
{
    var objRet = null;

    $.ajax({
        type: 'GET',
        url: '/api/Anos/',
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