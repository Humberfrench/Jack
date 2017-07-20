/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />
/// <reference path="ColaboradorCriancaAdd.js" />

Colaborador.URLAdicionarSacolas = '';

$(document).ready(function ()
{
    Colaborador.URLAdicionarSacola = $("#URLAdicionarSacola").val();
    Colaborador.URLAdicionarSacolas = $("#URLAdicionarSacolas").val();

});

Colaborador.Adicionar = function (crianca)
{

    if (($("#Ano").val() === '') || ($("#Ano").val() === '0'))
    {
        Mensagens.Erro("Ano não preenchido", "Erro na Gravação");
        return false;
    }

    if (($("#Colaborador").val() === '') || ($("#Colaborador").val() === '0'))
    {
        Mensagens.Erro("Colaborador não preenchido", "Erro na Gravação");
        return false;
    }

    var opcoes = new Object;
    opcoes.url = Colaborador.URLAdicionarSacola;
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
            Colaborador.Pesquisar();
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.ano = $("#Ano").val();
    opcoes.dadoEnvio.crianca = crianca;
    opcoes.dadoEnvio.colaborador = $("#Colaborador").val();

    Ajax.Post(opcoes);
}


Colaborador.AdicionarVarios = function ()
{

    if (($("#Ano").val() === '') || ($("#Ano").val() === '0'))
    {
        Mensagens.Erro("Ano não preenchido", "Erro na Gravação");
        return false;
    }

    if (($("#Colaborador").val() === '') || ($("#Colaborador").val() === '0'))
    {
        Mensagens.Erro("Colaborador não preenchido", "Erro na Gravação");
        return false;
    }

    $('#TableFamilia').DataTable().destroy();
    var checks = $('input:checkbox[name=AddCrianca]:checked').length;
    var sacolas = "";

    if (checks === 0)
    {
        Mensagens.Erro("Não foi selecionado nenhuma Sacola", "Erro na Gravação");
        return false;
    }

    $("input:checkbox[name=AddCrianca]:checked").each(function ()
    {
        sacolas = sacolas + $(this).val() + ',';
    });

    sacolas = sacolas.substring(0, (sacolas.length - 1));

    var opcoes = new Object;
    opcoes.url = Colaborador.URLAdicionarSacolas;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Erro)
        {
            Mensagens.Erro(dataObj.Mensagem);
            Colaborador.MontarTabela();
        }
        else
        {
            Mensagens.Sucesso(dataObj.Mensagem);
            Colaborador.MontarTabela();
            Colaborador.Pesquisar();
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.ano = $("#Ano").val();
    opcoes.dadoEnvio.sacolas = sacolas;
    opcoes.dadoEnvio.colaborador = $("#Colaborador").val();

    Ajax.Post(opcoes);

}
