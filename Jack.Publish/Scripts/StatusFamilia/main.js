/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var StatusFamilia = new Object();

StatusFamilia.URLObterTodos = '';
StatusFamilia.URLFiltrar = '/StatusFamilia/Filtrar/';
StatusFamilia.URLEdit = '';
StatusFamilia.URLGravar = '';
StatusFamilia.URLExcluir = '';
StatusFamilia.URLAutoComplete = '';

$(document).ready(function ()
{
    StatusFamilia.MontarTabela();
    StatusFamilia.URLObterTodos = $("#URLObterTodos").val();
    StatusFamilia.URLEdit = $("#URLEdit").val();
    StatusFamilia.URLGravar = $("#URLGravar").val();
    StatusFamilia.URLExcluir = $("#URLExcluir").val();
    StatusFamilia.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        StatusFamilia.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        StatusFamilia.Gravar();
    });

    $("#Novo").click(function ()
    {
        StatusFamilia.LimparForm();
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

    StatusFamilia.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    StatusFamilia.LimparForm();
    StatusFamilia.Edit(id);
    $("#modalEdicao").modal('show');
}

StatusFamilia.MontarTabela = function ()
{
    $('#TableStatusFamilia').DataTable({
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

StatusFamilia.Pesquisar = function (nome)
{

    if (nome === '')
    {
        StatusFamilia.PesquisarTodos();
    }
    else
    {
        location.href = StatusFamilia.URLFiltrar + nome;
    }
}

StatusFamilia.PesquisarTodos = function ()
{
    location.href = StatusFamilia.URLObterTodos;
}

StatusFamilia.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Descricao").val('');
    $("#PermiteSacola").prop('checked', '');
    $("#ProcessaStatus").prop('checked', '');
}

StatusFamilia.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = StatusFamilia.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        StatusFamilia.LimparForm();
        $("#Codigo").val(codigo);
        $("#Descricao").val(dataObj.Descricao);
        if (dataObj.PermiteSacola)
        {
            $("#PermiteSacola").prop('checked', 'checked');
        }
        if (dataObj.ProcessaStatus)
        {
            $("#ProcessaStatus").prop('checked', 'checked');
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

StatusFamilia.Gravar = function ()
{
    if (StatusFamilia.Consistir($("#Descricao").val()))
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var permiteSacola = $("#PermiteSacola").prop('checked');
        var processaStatus = $("#ProcessaStatus").prop('checked');

        var opcoes = new Object;
        opcoes.url = StatusFamilia.URLGravar;
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
                StatusFamilia.LimparForm();
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
        opcoes.dadoEnvio.PermiteSacola = permiteSacola;
        opcoes.dadoEnvio.ProcessaStatus = processaStatus;
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

StatusFamilia.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = StatusFamilia.URLExcluir;

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
            StatusFamilia.LimparForm();
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

StatusFamilia.Consistir = function (descricao)
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


