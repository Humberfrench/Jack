/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var TipoItem = new Object();

TipoItem.URLObterTodos = '';
TipoItem.URLFiltrar = '';
TipoItem.URLEdit = '';
TipoItem.URLGravar = '';
TipoItem.URLExcluir = '';
TipoItem.URLAutoComplete = '';

$(document).ready(function ()
{
    TipoItem.MontarTabela();
    TipoItem.URLObterTodos = $("#URLObterTodos").val();
    TipoItem.URLFiltrar = $("#URLFiltrar").val();
    TipoItem.URLEdit = $("#URLEdit").val();
    TipoItem.URLGravar = $("#URLGravar").val();
    TipoItem.URLExcluir = $("#URLExcluir").val();
    TipoItem.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        TipoItem.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        TipoItem.Gravar();
    });

    $("#Novo").click(function ()
    {
        TipoItem.LimparForm();
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

    TipoItem.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    TipoItem.LimparForm();
    TipoItem.Edit(id);
    $("#modalEdicao").modal('show');
}

TipoItem.MontarTabela = function ()
{
    $('#TableTipoItem').DataTable({
        "searching": false,
        "autoWidth": false,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
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
            { "aTargets": [3], "bSortable": false }
    ]    });
}

TipoItem.Pesquisar = function (nome)
{

    if (nome === '')
    {
        TipoItem.PesquisarTodos();
    }
    else
    {
        location.href = TipoItem.URLFiltrar + '/' + nome;
    }
}

TipoItem.PesquisarTodos = function ()
{
    location.href = TipoItem.URLObterTodos;
}

TipoItem.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
    $("#Opcional").prop('checked', '');
}

TipoItem.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = TipoItem.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        TipoItem.LimparForm();
        $("#Codigo").val(codigo);
        $("#Descricao").val(dataObj.Descricao);
        if (dataObj.Opcional)
        {
            $("#Opcional").prop('checked', 'checked');
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

TipoItem.Gravar = function ()
{
    if (TipoItem.Consistir())
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var opcional = $("#Opcional").prop('checked');

        var opcoes = new Object;
        opcoes.url = TipoItem.URLGravar;
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
                TipoItem.LimparForm();
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
        opcoes.dadoEnvio.Opcional = opcional;
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

TipoItem.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = TipoItem.URLExcluir;

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
            TipoItem.LimparForm();
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

TipoItem.Consistir = function (nome)
{
    var mensagemErro = '';
    if(nome === '')
    {
        mensagemErro = 'O Campo Nome é Obrigatório';
    }
    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}


