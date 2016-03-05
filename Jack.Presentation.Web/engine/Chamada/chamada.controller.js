/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="/engine/geral/status.js" />
/// <reference path="/engine/geral/mensagem.js" />
/// <reference path="/engine/geral/util.js" />
/// <reference path="chamada.presentation.js" />
/// <reference path="chamada.js" />

angular.module('CECAMApp', []).controller('ngChamadaController', function ($scope)
{
    //campos
    $scope.Reuniao = 0;
    $scope.Ano = 0 // $("#ddlAno").val();
    $scope.Anos = Util.Anos();

    $scope.ReuniaoLista = Reuniao.LoadDatas($scope.Ano);

    $scope.itens = Chamada.Load($scope.Reuniao);

    $scope.Mneumonicos = Chamada.LoadMneumonicos($scope.Reuniao);
	    $scope.Mneumonico = '';

	$scope.LoadReuniao = function (ID)
	{
	    if (ID == 0)
	    {
	        return;
	    }
	        
	    $scope.Reuniao = ID;
	    $scope.itens = Chamada.Load($scope.Reuniao);
	    $scope.Mneumonicos = Chamada.LoadFiltro($scope.Reuniao);
	    $scope.Mneumonico = '';

	};

	$scope.LoadDatas = function (ID)
	{
	    if (ID == 0)
	    {
	        return;
	    }

	    $scope.Ano = ID;
	    $scope.ReuniaoLista = Reuniao.LoadDatas($scope.Ano);
	};

	$scope.FiltroChamadas = function (item)
	{
	    if (item.Mneumonico == '')
	    {
	        return;
	    }
	    $scope.itens = Chamada.LoadMneumonicos(item.Reuniao, item.Mneumonico);
	};
	$scope.GravarPresenca = function (item)
	{
	    //alert($scope.Reuniao);
	    //alert(item.Codigo);
	    Chamada.Registrar($scope.Reuniao, item.Codigo)

	    $scope.itens = Chamada.Load($scope.Reuniao);
	    $scope.Mneumonicos = Chamada.LoadFiltro($scope.Reuniao);
	    $scope.Mneumonico = '';

	};

});