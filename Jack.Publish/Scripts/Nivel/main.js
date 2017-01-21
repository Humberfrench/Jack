/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var Nivel = new Object();

Nivel.URLObterTodos = '';
Nivel.URLEdit = '';
Nivel.URLGravar = '';

$(document).ready(function ()
{
    Nivel.MontarTabela();
    Nivel.URLObterTodos = $("#URLObterTodos").val();
    Nivel.URLEdit = $("#URLEdit").val();
    Nivel.URLGravar = $("#URLGravar").val();

    $("#Gravar").click(function ()
    {
        Nivel.Gravar();
    });

    $("#Novo").click(function ()
    {
        Nivel.LimparForm();
        $("#modalEdicao").modal('show');
    });

});

function ExcluirConfirmar(codigo, nome)
{
    $("#spnCodigo").html(codigo);
    $("#spnNome").html(nome);
    $("#codigoExclusao").val(codigo);
    $("#modalExclusao").modal('show');
}

function Excluir()
{
    if ($("#codigoExclusao").val() === '')
    {
        return false;
    }

    Nivel.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Nivel.LimparForm();
    Nivel.Edit(id);
    $("#modalEdicao").modal('show');
}

Nivel.MontarTabela = function ()
{
    $('#TableNivel').DataTable({
        "searching": false,
        "autoWidth": false,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
        "order": [],
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "<div class='col-xs-12 tabela-contas no-pad'>Nenhum registro encontrado</div>",
            "sSearchPlaceholder": "Busque pelo nome da empresa, agencia e conta, CNPJ ou apelido."
        },
        "classes": {
            "sFilterInput": "form-control campo-busca",
            "sInfo": "num-pag col-xs-12 text-right no-pad hidden-xs",
            "sEmptyTable": "num-pag col-xs-12 text-right no-pad hidden-xs",
            "sPaging": "text-center",
            "sPageButtonActive": "active"
        },
        "dom": '<"top"li>rt<"bottom"p><"clear">',
        "pagingType": "numbers",
        "aoColumnDefs": [
            { "aTargets": [0], "asSorting": ["asc"], "bSortable": true },
            { "aTargets": [1], "bSortable": true },
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [3], "bSortable": true },
            { "aTargets": [4], "bSortable": true },
            { "aTargets": [5], "bSortable": true },
            { "aTargets": [6], "bSortable": true },
            { "aTargets": [7], "bSortable": true },
            { "aTargets": [8], "bSortable": false }
    ]    });
}

Nivel.Pesquisar = function (nome)
{

    if (nome === '')
    {
        Nivel.PesquisarTodos();
    }
    else
    {
        location.href = Nivel.URLFiltrar + nome;
    }
}

Nivel.PesquisarTodos = function ()
{
    location.href = Nivel.URLObterTodos;
}

Nivel.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Nome").val('');
    $("#Descricao").val('');
    $("#PercentualInicial").val('');
    $("#PercentualFinal").val('');
    $("#NuncaGerarSacola").prop('checked', '');
    $("#ListaDeEspera").prop('checked', '');
    $("#SacolaGarantida").prop('checked', '');
}

Nivel.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = Nivel.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        Nivel.LimparForm();

        $("#Codigo").val(codigo);
        $("#Nome").val(dataObj.Nome);
        $("#Descricao").val(dataObj.Descricao);
        $("#PercentualInicial").val(dataObj.PercentualInicial);
        $("#PercentualFinal").val(dataObj.PercentualFinal);

        if (dataObj.NuncaGerarSacola)
        {
            $("#NuncaGerarSacola").prop('checked', 'checked');
        }

        if (dataObj.ListaDeEspera)
        {
            $("#ListaDeEspera").prop('checked', 'checked');
        }

        if (dataObj.SacolaGarantida)
        {
            $("#SacolaGarantida").prop('checked', 'checked');
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

Nivel.Gravar = function ()
{
    if (Nivel.Consistir($("#Descricao").val()))
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var nuncaGerarSacola = $("#NuncaGerarSacola").prop('checked');
        var listaDeEspera = $("#ListaDeEspera").prop('checked');
        var sacolaGarantida = $("#SacolaGarantida").prop('checked');

        var opcoes = new Object;
        opcoes.url = Nivel.URLGravar;
        opcoes.headers = {};
        opcoes.headers['__RequestVerificationToken'] = token;
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
                Nivel.LimparForm();
                $("#modalEdicao").modal('hide');
                setTimeout(function ()
                {
                    location.reload();
                }, 1500);
            }
        };

        opcoes.dadoEnvio = new Object;
        opcoes.dadoEnvio.Codigo = $("#Codigo").val();
        opcoes.dadoEnvio.Nome = $("#Nome").val();
        opcoes.dadoEnvio.Descricao = $("#Descricao").val();
        opcoes.dadoEnvio.PercentualInicial = $("#PercentualInicial").val();
        opcoes.dadoEnvio.PercentualFinal = $("#PercentualFinal").val();
        opcoes.dadoEnvio.NuncaGerarSacola = nuncaGerarSacola;
        opcoes.dadoEnvio.ListaDeEspera = listaDeEspera;
        opcoes.dadoEnvio.SacolaGarantida = sacolaGarantida;
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

Nivel.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Nivel.URLExcluir;

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
            Nivel.LimparForm();
            setTimeout(function ()
            {
                location.reload();
            }, 1500);
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;
    opcoes.type = 'POST';
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

Nivel.Consistir = function (descricao)
{
    var mensagemErro = '';
    if(descricao === '')
    {
        mensagemErro = 'O Campo Descrição é Obrigatório';
    }
    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}


