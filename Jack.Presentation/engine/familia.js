/// <reference path="/scripts/angular.js" />
/// <reference path=/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="status.js" />

var Familia = new Object;

angular.module('CECAMApp', []).controller('ngFamiliaController', function ($scope)
{
    $scope.itens = familia.Load();

    $scope.Edit = function (itemDados)
    {
        $("#txtCodigo").val(itemDados._Codigo);
        $("#txtNome").val(itemDados._Familia);
        $("#txtContato").val(itemDados._Contato);
        $("#ddlStatus").val(itemDados._Status);
        $("#ddlNivel").val(itemDados._Nivel);

        if (itemDados._IsConsistente)
        {
            $("#chkIsSacolinha").prop('checked', true);
        }
        else
        {
            $("#chkIsSacolinha").prop('checked', false);
        }

        if (itemDados._IsSacolinha)
        {
            $("#chkDadosOK").prop('checked', true);
        }
        else
        {
            $("#chkDadosOK").prop('checked', false);
        }

        $("#txtData").val(itemDados._DataAtualizacao);

        //chkIsSacolinha
        //chkDadosOK
    }

    $scope.Delete = function (itemDados)
    {
        //deleting
        familia.Delete(itemDados.Codigo);
        //reload
        $scope.itens = familia.Load();
    }

    $scope.Save = function (itemDados)
    {
        //deleting
        familia.Save(itemDados);
        //reload
        $scope.itens = familia.Load();
    }

});

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
            alert(xhr.responseText);
        }
    });

    return objRet;

};

Familia.Save = function (objFamilia)
{

};

Familia.Delete = function (intItem)
{

};