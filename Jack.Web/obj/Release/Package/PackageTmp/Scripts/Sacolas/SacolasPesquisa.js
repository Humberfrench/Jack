/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />

var SacolasPesquisa = new Object();

$(document).ready(function ()
{
    SacolasPesquisa.MontarTabela();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        SacolasPesquisa.Pesquisar(nome);
    });



});

SacolasPesquisa.MontarTabela = function ()
{
    $('#TableSacolaPesquisa').DataTable({
        "searching": false,
        "autoWidth": false,
        "order": [],
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
            { "aTargets": [0], "bSortable": false },
            { "aTargets": [1], "bSortable": false },
            { "aTargets": [2], "bSortable": false },
            { "aTargets": [3], "bSortable": false },
            { "aTargets": [4], "bSortable": false }
        ]
    });
}
{
    
}

SacolasPesquisa.Pesquisar = function (nome)
{
    if ($("#Ano").val() === 0)
    {
        Mensagens.Erro('Ano não preenchido.');
        return false;
    }
    //        [Route("Pesquisar/{ano},{familia},{kit},{nivel}")]
    location.href = '/Sacolas/Pesquisar/' + $("#Ano").val() + '/' + $("#Familia").val() + '/' + $("#Kit").val() + '/' + $("#Nivel").val() + '/';
}