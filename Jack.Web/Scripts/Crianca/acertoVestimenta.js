/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />

var AcertoVestimenta = new Object();

AcertoVestimenta.URLObterTodos = '';
AcertoVestimenta.URLEdit = '';
AcertoVestimenta.URLGravar = '';
AcertoVestimenta.URLExcluir = '';
AcertoVestimenta.URLObterAcertoVestimentas = '';
AcertoVestimenta.URLObterRepresentantes = '';
AcertoVestimenta.URLObterPresencas = '';

AcertoVestimenta.NumeroMaximoCricancas = 0;
AcertoVestimenta.CalcadoLimite = 0;

$(document).ready(function ()
{
    if ($("#CodigoFamilia").val() !== 0)
    {
        $("#Familia").val($("#CodigoFamilia").val()); 
    }
    $("#Status").val(14);

    $("#PercentualCriancas").knob(
        {
            'min': 0,
            'max': 100,
            'width': 50,
            'height': 50,
            'stopper': false
        });


});

AcertoVestimenta.AcertarDado = function (newValue, campo)
{
    $(campo).val(newValue);
}


AcertoVestimenta.Pesquisar = function ()
{
    if (($("#Familia").val() === '') || ($("#Familia").val() === '0'))
    {
        Mensagens.Erro("Familia não preenchida", "Erro na Pesquisa");
        return false;
    }
    
    location.href = '/Crianca/Acerto/Vestimentas/' + $("#Familia").val();
}

AcertoVestimenta.Gravar = function (codigo, campoCalcado, campoRoupa)
{
    var opcoes = new Object;
    opcoes.url = '/Crianca/Acerto/Vestimentas/Gravar' ;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Erro)
        {
            Mensagens.Erro(dataObj.Mensagem);
        }
        else
        {
            Mensagens.Sucesso(dataObj.Mensagem);
        }

    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.crianca = codigo;
    opcoes.dadoEnvio.calcado = $(campoCalcado).val();
    opcoes.dadoEnvio.roupa = $(campoRoupa).val();

    Ajax.Get(opcoes);

}


