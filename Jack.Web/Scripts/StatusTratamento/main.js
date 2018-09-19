/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var StatusTratamento = new Object();

StatusTratamento.URLObterTodos = '';
StatusTratamento.URLFiltrar = '/StatusTratamento/Filtrar/';
StatusTratamento.URLEdit = '';
StatusTratamento.URLGravar = '';
StatusTratamento.URLExcluir = '';
StatusTratamento.URLAutoComplete = '';

$(document).ready(function ()
{
    StatusTratamento.MontarTabela();
    StatusTratamento.URLObterTodos = $("#URLObterTodos").val();
    StatusTratamento.URLEdit = $("#URLEdit").val();
    StatusTratamento.URLGravar = $("#URLGravar").val();
    StatusTratamento.URLExcluir = $("#URLExcluir").val();
    StatusTratamento.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        StatusTratamento.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        StatusTratamento.Gravar();
    });

    $("#Novo").click(function ()
    {
        StatusTratamento.LimparForm();
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

    StatusTratamento.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    StatusTratamento.LimparForm();
    StatusTratamento.Edit(id);
    $("#modalEdicao").modal('show');
}

StatusTratamento.MontarTabela = function ()
{
    $('#TableStatusTratamento').DataTable({
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
            { "aTargets": [2], "bSortable": false }
    ]    });
}

StatusTratamento.Pesquisar = function (nome)
{

    if (nome === '')
    {
        StatusTratamento.PesquisarTodos();
    }
    else
    {
        location.href = StatusTratamento.URLFiltrar + nome;
    }
}

StatusTratamento.PesquisarTodos = function ()
{
    location.href = StatusTratamento.URLObterTodos;
}

StatusTratamento.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
}

StatusTratamento.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = StatusTratamento.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        StatusTratamento.LimparForm();
        $("#Codigo").val(codigo);
        $("#Descricao").val(dataObj.Descricao);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

StatusTratamento.Gravar = function ()
{
    if (StatusTratamento.Consistir($("#Descricao").val()))
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var permiteSacola = $("#PermiteSacola").prop('checked');
        var processaStatus = $("#ProcessaStatus").prop('checked');

        var opcoes = new Object;
        opcoes.url = StatusTratamento.URLGravar;
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
                StatusTratamento.LimparForm();
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
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

StatusTratamento.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = StatusTratamento.URLExcluir;

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
            StatusTratamento.LimparForm();
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

StatusTratamento.Consistir = function (descricao)
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


