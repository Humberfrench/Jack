/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />

var AdicionarCrianca = new Object();

AdicionarCrianca.URLObterTodos = '';
AdicionarCrianca.URLEdit = '';
AdicionarCrianca.URLGravar = '';
AdicionarCrianca.URLExcluir = '';
AdicionarCrianca.URLObterAdicionarCriancas = '';
AdicionarCrianca.URLObterRepresentantes = '';
AdicionarCrianca.URLObterPresencas = '';

AdicionarCrianca.NumeroMaximoCricancas = 0;
AdicionarCrianca.CalcadoLimite = 0;

$(document).ready(function ()
{
    AdicionarCrianca.URLGravar = $("#URLGravar").val();
    AdicionarCrianca.MontarTabela();
    if ($("#CodigoFamilia").val() !== 0)
    {
        $("#Familia").val($("#CodigoFamilia").val());
    }

});

AdicionarCrianca.Pesquisar = function ()
{
    if (($("#Familia").val() === '') || ($("#Familia").val() === '0'))
    {
        Mensagens.Erro("Familia não preenchida", "Erro na Pesquisa");
        return false;
    }

    location.href = '/Sacolas/AdicionarCrianca/' + $("#Familia").val();
}

AdicionarCrianca.AdicionarCriancaNaSacola = function (id)
{

    var opcoes = new Object;
    opcoes.url = AdicionarCrianca.URLGravar;
    opcoes.type = "POST";
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
            AdicionarCrianca.LimparForm();
            setTimeout(function ()
            {
                location.reload();
            }, 1500);
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = id;

    Ajax.Execute(opcoes);
}

AdicionarCrianca.MontarTabela = function ()
{
    $('#TableFamilia').DataTable({
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

