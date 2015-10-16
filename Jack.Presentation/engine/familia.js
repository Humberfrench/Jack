/// <reference path="/scripts/angular.js" />

var familia = new Object;

angular.module('CECAMApp', []).controller('ngFamiliaController', function ($scope)
{
    $scope.itens = familia.Get();
});

familia.Get = function ()
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


};
