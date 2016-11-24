/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />

var Crianca = new Object();

Crianca.URLObterTodos = '';
Crianca.URLEdit = '';
Crianca.URLGravar = '';
Crianca.URLExcluir = '';
Crianca.URLObterCriancas = '';
Crianca.URLObterRepresentantes = '';
Crianca.URLObterPresencas = '';

$(document).ready(function ()
{
    Crianca.MontarTabela();
    if ($("#CodigoFamilia").val() !== 0)
    {
        $("#Familia").val($("#CodigoFamilia").val()); 
    }
    $("#Status").val(14);
    Crianca.UpdateCalendario();

});

Crianca.UpdateCalendario = function ()
{

    $("#DataNascimento").datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true
    });

    var dataValue = moment().format("DD/MM/YYYY");

    $("#DataNascimento").datepicker('setDate', dataValue);
    $("#DataNascimento").datepicker('update');
    $("#DataNascimento").val('');

}
$("#Novo").click(function ()
{
    Crianca.LimparForm();
    $("#modalEdicao").modal('show');
});

Crianca.LimparForm = function ()

{
    $("#Status").val(14);
}

Crianca.Pesquisar = function ()
{
    if (($("#Familia").val() === '') || ($("#Familia").val() === '0'))
    {
        return false;
    }
    
    location.href = '/Crianca/' + $("#Familia").val();
}

Crianca.MontarTabela = function ()
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
        ]
    });
}