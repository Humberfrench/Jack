/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="status.js" />

//TO SELECT 2 LOOK AT https://select2.github.io/examples.html


var Familia = new Object;

$(function ()
{
    // Load Combo
    Familia.LoadStatus(ddlStatus, Status.LoadForFamily());
    
    $("#ddlStatus").select2();
    $("#ddlNivel").select2();

    //set status
    $("ddlStatus").change( function (){
        $("txtStatus").val($("ddlStatus").val());
    });
    //set nivel
    $("ddlNivel").change( function (){
        $("txtNivel").val($("ddlNivel").val());
    });
});

angular.module('CECAMApp', []).controller('ngFamiliaController', function ($scope)
{
    $scope.itens = Familia.Load();

    $scope.StatusItens = Status.LoadForFamily();

    $scope.Edit = function (itemDados)
    {
        $("#txtCodigo").val(itemDados._Codigo);
        $("#txtNome").val(itemDados._Familia);
        $("#txtContato").val(itemDados._Contato);
        $("#ddlStatus").val(itemDados._Status);
        $("#ddlNivel").val(itemDados._Nivel);
        $("#txtStatus").val(itemDados._Status);
        $("#txtNivel").val(itemDados._Nivel);

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
            Mensagem.Erro(xhr.responseText);
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
