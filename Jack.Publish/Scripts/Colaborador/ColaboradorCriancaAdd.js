/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />

var Colaborador = new Object();

Colaborador.URLListaSacolas = '';


$(document).ready(function ()
{
    Colaborador.URLListaSacolas = $("#URLListaSacolas").val();
});

Colaborador.Pesquisar = function ()
{
    if (($("#Ano").val() === '') || ($("#Ano").val() === '0'))
    {
        Mensagens.Erro("Ano não preenchido", "Erro na Pesquisa");
        return false;
    }

    var opcoes = new Object;
    opcoes.url = Colaborador.URLListaSacolas;
    opcoes.callBackSuccess = function (response)
    {
        $("#divListaSacolas").html(response);
        Colaborador.MontarTabela();
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.ano = $("#Ano").val();
    opcoes.dadoEnvio.familia = $("#Familia").val();
    opcoes.dadoEnvio.sexo = $("#Sexo").val();
    opcoes.dadoEnvio.nivel = $("#Nivel").val();
    opcoes.dadoEnvio.kit = $("#Kit").val();

    var liberado = $("#Liberado").val();

    switch (liberado)
    {
    case '1':
        opcoes.dadoEnvio.liberado = true;
        break;
    case '2':
        opcoes.dadoEnvio.liberado = true;
        break;
    default:
        opcoes.dadoEnvio.liberado = null;
        break;
    }

    Ajax.Get(opcoes);
}
 

Colaborador.MontarTabela = function ()
{
    $('#TableFamilia').DataTable({
        "searching": false,
        "autoWidth": false,
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
            { "aTargets": [6], "bSortable": true },
            { "aTargets": [7], "bSortable": true },
            { "aTargets": [8], "bSortable": false }
        ]
    });
}

