/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var TipoParentesco = new Object();

TipoParentesco.URLObterTodos = '';
TipoParentesco.URLFiltrar = '/TipoParentesco/Filtrar/';
TipoParentesco.URLEdit = '';
TipoParentesco.URLGravar = '';
TipoParentesco.URLExcluir = '';
TipoParentesco.URLAutoComplete = '';

$(document).ready(function ()
{
    TipoParentesco.MontarTabela();
    TipoParentesco.URLObterTodos = $("#URLObterTodos").val();
    TipoParentesco.URLEdit = $("#URLEdit").val();
    TipoParentesco.URLGravar = $("#URLGravar").val();
    TipoParentesco.URLExcluir = $("#URLExcluir").val();
    TipoParentesco.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        TipoParentesco.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        TipoParentesco.Gravar();
    });

    $("#Novo").click(function ()
    {
        TipoParentesco.LimparForm();
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

    TipoParentesco.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    TipoParentesco.LimparForm();
    TipoParentesco.Edit(id);
    $("#modalEdicao").modal('show');
}

TipoParentesco.MontarTabela = function ()
{
    $('#TableTipoParentesco').DataTable({
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
            { "aTargets": [0], "bSortable": true },
            { "aTargets": [1], "bSortable": true },
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [3], "bSortable": true },
            { "aTargets": [4], "bSortable": false }
    ]    });
}

TipoParentesco.Pesquisar = function (nome)
{

    if (nome === '')
    {
        TipoParentesco.PesquisarTodos();
    }
    else
    {
        location.href = TipoParentesco.URLFiltrar + nome;
    }
}

TipoParentesco.PesquisarTodos = function ()
{
    location.href = TipoParentesco.URLObterTodos;
}

TipoParentesco.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
    $("#GrauParentesco").val('1');
    $("#Parente").prop('checked', '');
}

TipoParentesco.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = TipoParentesco.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        TipoParentesco.LimparForm();
        $("#Codigo").val(codigo);
        $("#Descricao").val(dataObj.Descricao);
        $("#GrauParentesco").val(dataObj.GrauParentesco);
        if (dataObj.Parente)
        {
            $("#Parente").prop('checked', 'checked');
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

TipoParentesco.Gravar = function ()
{
    if (TipoParentesco.Consistir($("#Descricao").val()))
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var parente = $("#Parente").prop('checked');

        var opcoes = new Object;
        opcoes.url = TipoParentesco.URLGravar;
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
                TipoParentesco.LimparForm();
                $("#modalEdicao").modal('hide');
                setTimeout(function ()
                {
                    location.reload();
                }, 1500);
            }
        };

        opcoes.dadoEnvio = new Object;
        opcoes.dadoEnvio.Codigo = $("#Codigo").val();
        opcoes.dadoEnvio.Descricao = $("#Descricao").val();
        opcoes.dadoEnvio.GrauParentesco = $("#GrauParentesco").val();
        opcoes.dadoEnvio.Parente = parente;
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

TipoParentesco.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = TipoParentesco.URLExcluir;

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
            TipoParentesco.LimparForm();
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

TipoParentesco.Consistir = function ()
{
    var mensagemErro = '';
    if ($("#Descricao").val() === '')
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


