/// <reference path="/scripts/angular.js" />
/// <reference path="/Scripts/jquery-2.1.4.js" />
/// <reference path="/Scripts/jquery-2.1.4.intellisense.js" />
/// <reference path="/Scripts/bootstrap.js" />
/// <reference path="/Scripts/toastr.js" />
/// <reference path="/Scripts/select2.js" />
/// <reference path="chamada.js" />
/// <reference path="/engine/geral/status.js" />
/// <reference path="/engine/geral/mensagem.js" />
/// <reference path="/engine/geral/util.js" />

angular.module('CECAMApp', []).controller('ngFamiliaController', function ($scope)
{
	$scope.itens = Familia.Load();

	$scope.DatasReuniao = Reuniao.LoadDatas();

	$scope.Presenca = function (itemDados)
	{
		//deleting
		Familia.Delete(itemDados.Codigo);
		//reload
		$scope.itens = familia.Load();
	}

});