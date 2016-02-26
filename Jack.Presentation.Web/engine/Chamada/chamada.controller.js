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
    $scope.Ano = $("#ddlAno").val();
    $scope.Reuniao = 0;

    $scope.ReuniaoLista = Reuniao.LoadDatas($scope.Ano);

    $scope.itens = Chamada.Load($scope.Reuniao);

	//$scope.Presenca = function (itemDados)
	//{
	//	//reload
	//	$scope.itens = familia.Load();
	//}

	$scope.LoadReuniao = function (ID)
	{
	    $scope.Reuniao = ID;
	    $scope.itens = Chamada.Load($scope.Reuniao);
	};

	$scope.LoadDatas = function (ID)
	{
	    $scope.Ano = ID;
	    $scope.itens = Reuniao.LoadDatas($scope.Ano);
	};

});