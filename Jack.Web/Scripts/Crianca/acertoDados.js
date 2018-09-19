/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />

var AcertoDados = new Object();

AcertoDados.URLObterTodos = '';
AcertoDados.URLEdit = '';
AcertoDados.URLGravar = '';
AcertoDados.URLExcluir = '';
AcertoDados.URLObterAcertoDados = '';
AcertoDados.URLObterRepresentantes = '';
AcertoDados.URLObterPresencas = '';

AcertoDados.NumeroMaximoCricancas = 0;
AcertoDados.CalcadoLimite = 0;

$(document).ready(function ()
{
    if ($("#CodigoFamilia").val() !== 0)
    {
        $("#Familia").val($("#CodigoFamilia").val()); 
    }

    $("#Familia").select2({
        theme: "classic"
    });

    $("select[name=TipoParentesco]").select2(
        {
            minimumResultsForSearch: Infinity,
            theme: "classic"
        });

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

AcertoDados.AcertarDado = function (newValue, campo)
{
    $(campo).val(newValue);
}


AcertoDados.Pesquisar = function ()
{
    if (($("#Familia").val() === '') || ($("#Familia").val() === '0'))
    {
        Mensagens.Erro("Familia não preenchida", "Erro na Pesquisa");
        return false;
    }
    
    location.href = '/Crianca/Acerto/Dados/' + $("#Familia").val();
}

AcertoDados.Gravar = function (codigo, campoCalcado, campoRoupa, campoTipoParentesco)
{
    var opcoes = new Object;
    opcoes.url = '/Crianca/Acerto/Dados/Gravar' ;
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
    opcoes.dadoEnvio.tipoParentesco = $(campoTipoParentesco).val();

    Ajax.Get(opcoes);

}


