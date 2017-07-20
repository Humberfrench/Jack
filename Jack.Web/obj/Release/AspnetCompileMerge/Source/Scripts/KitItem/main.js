/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var KitItem = new Object();

KitItem.URLObterTodos = '';
KitItem.URLFiltrar = '/KitItem/Filtrar/';
KitItem.URLEdit = '';
KitItem.URLGravar = '';
KitItem.URLExcluir = '';
KitItem.URLAutoComplete = '';

$(document).ready(function ()
{
    KitItem.MontarTabela();
    KitItem.URLObterTodos = $("#URLObterTodos").val();
    KitItem.URLEdit = $("#URLEdit").val();
    KitItem.URLGravar = $("#URLGravar").val();
    KitItem.URLExcluir = $("#URLExcluir").val();
    KitItem.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        KitItem.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        KitItem.Gravar();
    });

    $("#Novo").click(function ()
    {
        KitItem.LimparForm();
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

    KitItem.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    KitItem.LimparForm();
    KitItem.Edit(id);
    $("#modalEdicao").modal('show');
}

KitItem.MontarTabela = function ()
{
    $('#TableKitItem').DataTable({
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


KitItem.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#TipoItem").val('');
    $("#Ordem").val('1');
    $("#Observacao").val('');
    $("#Opcional").prop('checked', '');
}

KitItem.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = KitItem.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        KitItem.LimparForm();
        $("#Codigo").val(codigo);
        $("#TipoItem").val(dataObj.TipoItem.Codigo);
        $("#Ordem").val(dataObj.Ordem);
        $("#Observacao").val(dataObj.Observacao);
        if (dataObj.Opcional)
        {
            $("#Opcional").prop('checked', 'checked');
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

KitItem.Gravar = function ()
{
    if (KitItem.Consistir())
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var opcional = $("#Opcional").prop('checked');

        var opcoes = new Object;
        opcoes.url = KitItem.URLGravar;
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
                KitItem.LimparForm();
                $("#modalEdicao").modal('hide');
                setTimeout(function ()
                {
                    location.reload();
                }, 1500);
            }
        };

        opcoes.dadoEnvio = new Object;
        opcoes.dadoEnvio.Kit = new Object;
        opcoes.dadoEnvio.TipoItem = new Object;
        opcoes.dadoEnvio.Codigo = $("#Codigo").val();
        opcoes.dadoEnvio.Kit.Codigo = $("#CodigoKit").val();
        opcoes.dadoEnvio.TipoItem.Codigo = $("#TipoItem").val();
        opcoes.dadoEnvio.Ordem = $("#Ordem").val();
        opcoes.dadoEnvio.Observacao = $("#Observacao").val();
        opcoes.dadoEnvio.Opcional = opcional;
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

KitItem.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = KitItem.URLExcluir;

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
            KitItem.LimparForm();
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

KitItem.Consistir = function ()
{
    var mensagemErro = '';

    if (($("#TipoItem").val() === '') || ($("#TipoItem").val() === '0'))
    {
        mensagemErro = mensagemErro + 'O Campo Tipo de Item é Obrigatório <br />';
    }

    if (($("#Ordem").val() === '') || ($("#Ordem").val() === '0'))
    {
        mensagemErro = mensagemErro + 'O Campo Ordem é Obrigatório <br />';
    }

    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}

//KitItem.DefaultDefinitionOfTable = {
//    "bSort": false,
//    "searching": false,
//    "paging": false,
//    "autoWidth": false,
//    "order": [],
//    "language": {
//        "sEmptyTable": "Nenhum registro encontrado",
//        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
//        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
//        "sLoadingRecords": "Carregando...",
//        "sLengthMenu": "_MENU_ resultados por página",
//        "sProcessing": "Processando...",
//        "sZeroRecords": "<div class='col-xs-12 tabela-contas no-pad'>Nenhum registro encontrado</div>",
//    },
//    "classes": {
//        "sFilterInput": "form-control campo-busca",
//        "sInfo": "num-pag col-xs-12 text-right no-pad hidden-xs",
//        "sEmptyTable": "num-pag col-xs-12 text-right no-pad hidden-xs",
//        "sPaging": "text-center",
//        "sPageButtonActive": "active"
//    },
//    "dom": '<"top"li>rt<"bottom"><"clear">'
//}