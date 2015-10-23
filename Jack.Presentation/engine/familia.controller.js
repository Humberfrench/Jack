/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="familia.js" />
/// <reference path="status.js" />

angular.module('CECAMApp', []).controller('ngFamiliaController', function ($scope)
{
    $scope.itens = Familia.Load();

    $scope.StatusItens = Status.LoadForFamily();

    $scope.Edit = function (itemDados)
    {
        $("#txtCodigo").val(itemDados._Codigo);
        $("#txtNome").val(itemDados._Familia);
        $("#txtContato").val(itemDados._Contato);
        $("#ddlStatus").val(itemDados._Status).trigger('change');
        $("#ddlNivel").val(itemDados._Nivel).trigger('change');
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
        Familia.Delete(itemDados.Codigo);
        //reload
        $scope.itens = familia.Load();
    }

    $scope.Salvar = function (itemDados)
    {
    	//saving
    	itemDados._Nivel = $("#txtNivel").val();
    	itemDados._Status = $("#txtStatus").val();
        Familia.Salvar(itemDados);
        //reload
        $scope.itens = familia.Load();
    }

});