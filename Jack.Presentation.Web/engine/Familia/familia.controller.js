/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="familia.js" />
/// <reference path="familia.presentation.js" />
/// <reference path="/engine/geral/status.js" />
/// <reference path="/engine/geral/mensagem.js" />
/// <reference path="/engine/geral/util.js" />

angular.module('CECAMApp', []).controller('ngFamiliaController', function ($scope)
{
    $scope.itens = Familia.Load();
    $scope.item = '';

    $scope.StatusItens = Status.LoadForFamily();

    $scope.Edit = function (itemDados)
    {
        $("#txtCodigo").val(itemDados.Codigo); 
        $("#txtNome").val(itemDados.Nome); 
        $("#txtContato").val(itemDados.Contato);

        $("#ddlStatus").val(itemDados.StatusCodigo);

        $("#ddlNivel").val(itemDados.Nivel);

        if (itemDados.IsConsistente)
        {
            $("#chkIsSacolinha").prop('checked', true);
        }
        else
        {
            $("#chkIsSacolinha").prop('checked', false);
        }

        if (itemDados.IsSacolinha)
        {
            $("#chkDadosOK").prop('checked', true);
        }
        else
        {
            $("#chkDadosOK").prop('checked', false);
        }

        $("#txtData").val(itemDados.DataAtualizacao);
        
    }

    $scope.Delete = function (itemDados)
    {
        //deleting
        Familia.Delete(itemDados.Codigo);
        //reload
        $scope.itens = familia.Load();
    }

    $scope.Salvar = function ()
    {
        var itemDados = new Object();;

        itemDados.Codigo = $("#txtCodigo").val();
        itemDados.Nome = $("#txtNome").val();
        itemDados.Contato = $("#txtContato").val();
        itemDados.StatusCodigo = $("#ddlStatus").val();
        itemDados.Nivel = $("#ddlNivel").val();
        itemDados.IsConsistente = $("#chkSacola").is(':checked') ? 'S' : 'N';;
        itemDados.IsSacolinha = $("#chkDadosOK").is(':checked') ? 'S' : 'N';;
        itemDados.DataAtualizacao = $("#txtData").val();
        itemDados.Status = $("#ddlStatus").val();

        //saving
        if (Familia.Consistir())
        {
            Familia.Salvar(itemDados);
            //reload
            $scope.itens = familia.Load();
        }
    }

});