/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var StatusCrianca = new Object();

StatusCrianca.URLObterTodos = '';
StatusCrianca.URLFiltrar = '/StatusCrianca/Filtrar/';
StatusCrianca.URLEdit = '';
StatusCrianca.URLGravar = '';
StatusCrianca.URLExcluir = '';
StatusCrianca.URLAutoComplete = '';

$(document).ready(function ()
{
    StatusCrianca.MontarTabela();
    StatusCrianca.URLObterTodos = $("#URLObterTodos").val();
    StatusCrianca.URLEdit = $("#URLEdit").val();
    StatusCrianca.URLGravar = $("#URLGravar").val();
    StatusCrianca.URLExcluir = $("#URLExcluir").val();
    StatusCrianca.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        StatusCrianca.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        StatusCrianca.Gravar();
    });

    $("#Novo").click(function ()
    {
        StatusCrianca.LimparForm();
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

    StatusCrianca.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    StatusCrianca.LimparForm();
    StatusCrianca.Edit(id);
    $("#modalEdicao").modal('show');
}

StatusCrianca.MontarTabela = function ()
{
    $('#TableStatusCrianca').DataTable({
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
            { "aTargets": [3], "bSortable": false }
    ]    });
}

StatusCrianca.Pesquisar = function (nome)
{

    if (nome === '')
    {
        StatusCrianca.PesquisarTodos();
    }
    else
    {
        location.href = StatusCrianca.URLFiltrar + nome;
    }
}

StatusCrianca.PesquisarTodos = function ()
{
    location.href = StatusCrianca.URLObterTodos;
}

StatusCrianca.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
    $("#PermiteSacola").prop('checked', '');
}

StatusCrianca.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = StatusCrianca.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        StatusCrianca.LimparForm();
        $("#Codigo").val(codigo);
        $("#Descricao").val(dataObj.Descricao);
        if (dataObj.PermiteSacola)
        {
            $("#PermiteSacola").prop('checked', 'checked');
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

StatusCrianca.Gravar = function ()
{
    if (StatusCrianca.Consistir($("#Descricao").val()))
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var opcional = $("#PermiteSacola").prop('checked');

        var opcoes = new Object;
        opcoes.url = StatusCrianca.URLGravar;
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
                StatusCrianca.LimparForm();
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
        opcoes.dadoEnvio.PermiteSacola = opcional;
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

StatusCrianca.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = StatusCrianca.URLExcluir;

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
            StatusCrianca.LimparForm();
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

StatusCrianca.Consistir = function (descricao)
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


