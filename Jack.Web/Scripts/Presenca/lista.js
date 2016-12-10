/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/chartist/chartist.min.js" />

var Presenca = new Object();

Presenca.URLObterDadosPresenca = $("#URLObterDadosPresenca").val();

$(document).ready(function ()
{
    if ($("#CodigoFamilia").val() !== 0)
    {
        $("#Familia").val($("#CodigoFamilia").val());

        Presenca.ObterDadosPresenca($("#CodigoFamilia").val());
    }
    if ($("#CodigoFamilia").val() !== 0)
    {
        $("#Ano").val($("#AnoPresenca").val());
    }

    $("#PercentualCriancas").knob(
        {
            'min': 0,
            'max': 100,
            'width': 100,
            'height': 100,
            'stopper': false
        });

    $("#PercentualPresencas").knob(
        {
            'min': 0,
            'max': 100,
            'width': 100,
            'height': 100,
            'stopper': false
        });

});

Presenca.ObterDadosPresenca = function (familia)
{
    
    var opcoes = new Object;
    opcoes.url = Presenca.URLObterDadosPresenca;

    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);

        var data = {
            labels: dataObj.AnosPresenca,
            series: [ dataObj.ValoresPresenca ]
        };

        var options = {
            high: 25,
            ticks: [2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24],
            width: 550,
            height: 150,
            horizontalBars: true,
            low: 0,
            axisX: {
                labelInterpolationFnc: function (value, index)
                {
                    return index % 2 === 0 ? value : null;
                }
            }
        };

        var chart = new Chartist.Bar('.ct-chart', data, options);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.familia = familia;

    Ajax.Get(opcoes);


}

Presenca.Pesquisar = function ()
{
    if (($("#Familia").val() === '') || ($("#Familia").val() === '0'))
    {
        Mensagens.Erro("Família não preenchida", "Erro na Pesquisa");
        return false;
    }

    if (($("#Ano").val() === '') || ($("#Ano").val() === '0'))
    {
        Mensagens.Erro("Ano não preenchido", "Erro na Pesquisa");
        return false;
    }

    location.href = '/Presenca/Familias/' + $("#Familia").val() + '/Ano/' + $("#Ano").val();
}



