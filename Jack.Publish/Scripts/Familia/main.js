/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />

var Familia = new Object();

Familia.URLObterTodos = '';
Familia.URLFiltrar = '';
Familia.URLEdit = '';
Familia.URLGravar = '';
Familia.URLExcluir = '';
Familia.URLObterCriancas = '';
Familia.URLObterRepresentantes = '';
Familia.URLObterPresencas = '';

$(document).ready(function ()
{
    Familia.MontarTabela();
    Familia.URLObterTodos = $("#URLObterTodos").val();
    Familia.URLFiltrar = $("#URLFiltrar").val();
    Familia.URLEdit = $("#URLEdit").val();
    Familia.URLGravar = $("#URLGravar").val();
    Familia.URLExcluir = $("#URLExcluir").val();
    Familia.URLAutoComplete = $("#URLAutoComplete").val();
    Familia.URLObterCriancas = $("#URLObterCriancas").val();
    Familia.URLObterPresencas = $("#URLObterPresencas").val();
    Familia.URLObterRepresentantes = $("#URLObterRepresentantes").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        Familia.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        Familia.Gravar();
    });

    $("#Novo").click(function ()
    {
        Familia.LimparForm();
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

    Familia.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Familia.LimparForm();
    Familia.Edit(id);
    $("#modalEdicao").modal('show');
}

Familia.MontarTabela = function ()
{
    $('#TableFamilia').DataTable({
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
            { "aTargets": [2], "bSortable": false },
            { "aTargets": [3], "bSortable": false },
            { "aTargets": [4], "bSortable": false },
            { "aTargets": [5], "bSortable": false },
            { "aTargets": [6], "bSortable": false },
            { "aTargets": [7], "bSortable": false },
            { "aTargets": [8], "bSortable": false }
    ]    });
}

Familia.Pesquisar = function (nome)
{

    if (nome === '')
    {
        Familia.PesquisarTodos();
    }
    else
    {
        location.href = Familia.URLFiltrar + '/' + nome;
    }
}

Familia.PesquisarTodos = function ()
{
    location.href = Familia.URLObterTodos;
}

Familia.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
    $("#Opcional").prop('checked', '');
}

Familia.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = Familia.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        Familia.LimparForm();
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

Familia.Gravar = function ()
{
    if (Familia.Consistir())
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var opcional = $("#Opcional").prop('checked');

        var opcoes = new Object;
        opcoes.url = Familia.URLGravar;
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
                Familia.LimparForm();
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

Familia.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Familia.URLExcluir;

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
            Familia.LimparForm();
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

Familia.Consistir = function (nome)
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


Familia.Criancas = function (codigo)
{
    $("#divDados").html('');
    $("#Titulo").html('');

    var opcoes = new Object;
    opcoes.url = Familia.URLObterCriancas;
    opcoes.callBackSuccess = function (response)
    {
        $("#Titulo").html('Crianças');
        $("#divDados").html(response);
        $('#TableCriancas').DataTable(Familia.DefaultDefinitionOfTable);
        $("#modalPopDados").modal('show');
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.codigo = codigo;

    Ajax.Get(opcoes);
}


Familia.Presencas = function (codigo)
{
    $("#divDados").html('');
    $("#Titulo").html('');

    var opcoes = new Object;
    opcoes.url = Familia.URLObterPresencas;
    opcoes.callBackSuccess = function (response)
    {
        $("#Titulo").html('Presencas');
        $("#divDados").html(response);
        $('#TablePresencas').DataTable(Familia.DefaultDefinitionOfTable);
        $("#modalPopDados").modal('show');
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.codigo = codigo;

    Ajax.Get(opcoes);
}

Familia.Representantes = function (codigo)
{
    $("#divDados").html('');
    $("#Titulo").html('');

    var opcoes = new Object;
    opcoes.url = Familia.URLObterRepresentantes;
    opcoes.callBackSuccess = function (response)
    {
        $("#Titulo").html('Representantes');
        $("#divDados").html(response);
        $('#TableRepresentantes').DataTable(Familia.DefaultDefinitionOfTable);
        $("#modalPopDados").modal('show');
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.codigo = codigo;

    Ajax.Get(opcoes);
}

Familia.DefaultDefinitionOfTable = {
    "bSort": false,
    "searching": false,
    "autoWidth": false,
    "lengthMenu": [[6, 12, 20, -1], [6, 12, 20, "Todos"]],
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
    "dom": '<"top"li>rt<"bottom"p><"clear">',
    "pagingType": "numbers"
}