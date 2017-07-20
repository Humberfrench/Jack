/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var Kit = new Object();

Kit.URLObterTodos = '';
Kit.URLFiltrar = '/Kit/Filtrar/';
Kit.URLEdit = '';
Kit.URLGravar = '';
Kit.URLExcluir = '';
Kit.URLAutoComplete = '';

$(document).ready(function ()
{
    Kit.MontarTabela();
    Kit.URLObterTodos = $("#URLObterTodos").val();
    Kit.URLEdit = $("#URLEdit").val();
    Kit.URLGravar = $("#URLGravar").val();
    Kit.URLExcluir = $("#URLExcluir").val();
    Kit.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        Kit.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        Kit.Gravar();
    });

    $("#Novo").click(function ()
    {
        Kit.LimparForm();
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

    Kit.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Kit.LimparForm();
    Kit.Edit(id);
    $("#modalEdicao").modal('show');
}

Kit.MontarTabela = function ()
{
    $('#TableKit').DataTable({
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
            { "aTargets": [3], "bSortable": true },
            { "aTargets": [4], "bSortable": true },
            { "aTargets": [5], "bSortable": true },
            { "aTargets": [6], "bSortable": false }
    ]    });
}

Kit.Pesquisar = function (nome)
{

    if (nome === '')
    {
        Kit.PesquisarTodos();
    }
    else
    {
        location.href = Kit.URLFiltrar + nome;
    }
}

Kit.PesquisarTodos = function ()
{
    location.href = Kit.URLObterTodos;
}

Kit.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
    $("#IdadeMinima").val('');
    $("#IdadeMaxima").val('');
    $("#Sexo").val('');
    $("#NecessidadeEspecial").prop('checked', '');
}

Kit.VerItens = function (codigo)
{
    $("#divDados").html('');
    $("#Titulo").html('');

    var opcoes = new Object;
    opcoes.url = '/Kit/Item/Ver/' + codigo;
    opcoes.callBackSuccess = function (response)
    {
        $("#Titulo").html('Itens do Kit');
        $("#divDados").html(response);
        $('#TableKitItens').DataTable(Kit.DefaultDefinitionOfTable);
        $("#modalPopDados").modal('show');
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.codigo = codigo;

    Ajax.Get(opcoes);
}

Kit.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = Kit.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        Kit.LimparForm();
        $("#Codigo").val(codigo);
        $("#Descricao").val(dataObj.Descricao);
        $("#IdadeMinima").val(dataObj.IdadeMinima);
        $("#IdadeMaxima").val(dataObj.IdadeMaxima);
        $("#Sexo").val(dataObj.Sexo);
        if (dataObj.NecessidadeEspecial)
        {
            $("#NecessidadeEspecial").prop('checked', 'checked');
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

Kit.Gravar = function ()
{
    if (Kit.Consistir())
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var necessidadeEspecial = $("#NecessidadeEspecial").prop('checked');

        var opcoes = new Object;
        opcoes.url = Kit.URLGravar;
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
                Kit.LimparForm();
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
        opcoes.dadoEnvio.IdadeMinima = $("#IdadeMinima").val();
        opcoes.dadoEnvio.IdadeMaxima = $("#IdadeMaxima").val();
        opcoes.dadoEnvio.Sexo = $("#Sexo").val();
        opcoes.dadoEnvio.NecessidadeEspecial = necessidadeEspecial;
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

Kit.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Kit.URLExcluir;

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
            Kit.LimparForm();
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

Kit.Consistir = function ()
{
    var mensagemErro = '';

    if ($("#Descricao").val() === '')
    {
        mensagemErro = mensagemErro + 'O Campo Descrição é Obrigatório <br />';
    }

    if ($("#IdadeMinima").val() === '')
    {
        mensagemErro = mensagemErro + 'O Campo Idade Mínima é Obrigatório <br />';
    }

    if ($("#IdadeMaxima").val() === '')
    {
        mensagemErro = mensagemErro + 'O Campo Idade Máxima é Obrigatório <br />';
    }

    if ($("#Sexo").val() === '')
    {
        mensagemErro = mensagemErro + 'O Campo Sexo é Obrigatório <br />';
    }

    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}

Kit.DefaultDefinitionOfTable = {
    "bSort": false,
    "searching": false,
    "paging": false,
    "autoWidth": false,
    "order": [],
    "language": {
        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sLoadingRecords": "Carregando...",
        "sLengthMenu": "_MENU_ resultados por página",
        "sProcessing": "Processando...",
        "sZeroRecords": "<div class='col-xs-12 tabela-contas no-pad'>Nenhum registro encontrado</div>",
    },
    "classes": {
        "sFilterInput": "form-control campo-busca",
        "sInfo": "num-pag col-xs-12 text-right no-pad hidden-xs",
        "sEmptyTable": "num-pag col-xs-12 text-right no-pad hidden-xs",
        "sPaging": "text-center",
        "sPageButtonActive": "active"
    },
    "dom": '<"top"li>rt<"bottom"><"clear">'
}