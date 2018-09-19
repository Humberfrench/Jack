/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/chartist/chartist.min.js" />

var Presenca = new Object();

Presenca.URLObterDadosPresenca = $("#URLObterDadosPresenca").val();
Presenca.URLObterReunioes = $("#URLObterReunioes").val();

$(document).ready(function ()
{
    Presenca.MontarTabela();

    $("#Ano").select2({
        theme: "classic"
    });

    $("#Reuniao").select2({
        theme: "classic"
    });

    $("select.form-control.input-sm").select2(
        {
            minimumResultsForSearch: Infinity,
            theme: "classic"
        });

    $("#Ano").val($("#AnoPresenca").val());

    if (($("#Ano").val() !== '') || ($("#Ano").val() !== '0'))
    {
        Presenca.ObterReunioes($("#Ano").val());
    }

    $("#Reuniao").val($("#ReuniaoSelecionada").val());
    $("#Ano").change(function ()
    {
        Presenca.ObterReunioes($("#Ano").val());
    });

    $("#Pesquisar").click(function ()
    {
        var reuniao = $("#Reuniao").val();
        if (reuniao === undefined)
        {
            Mensagens.Erro('Parametros da Pesquisa inconsistentes e ou faltando', 'Problemas no Formulário');
            return false;
        }
        Presenca.Pesquisar();
    });

});

Presenca.MontarTabela = function ()
{
    $('#TablePresencaReunioes').DataTable({
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
            { "aTargets": [5], "bSortable": true }
        ]
    });
}

Presenca.ObterReunioes = function (ano)
{

    if ((ano !== '0') && (ano !== null))
    {

        var opcoes = new Object;
        opcoes.url = Presenca.URLObterReunioes;
        opcoes.callBackSuccess = function (response)
        {
            var listaReunioes = eval(response);

            var optionData = '';
            for (var intCont = 0; intCont < listaReunioes.length; intCont++)
            {
                optionData += Util.ObterLista(listaReunioes[intCont].Codigo, listaReunioes[intCont].DataTexto);
            }
            $("#Reuniao").html(optionData);

            if (($("#ReuniaoSelecionada").val() !== undefined) ||
                ($("#ReuniaoSelecionada").val() !== null) ||
                ($("#ReuniaoSelecionada").val() !== ''))
            {
                $("#Reuniao").val($("#ReuniaoSelecionada").val());
            }

        };

        opcoes.dadoEnvio = new Object;
        opcoes.dadoEnvio.ano = ano;

        Ajax.Get(opcoes);
    }
}


Presenca.Pesquisar = function ()
{
    if (($("#Reuniao").val() === '') || ($("#Reuniao").val() === '0'))
    {
        Mensagens.Erro("Reuniao não preenchida", "Erro na Pesquisa");
        return false;
    }
    location.href = '/Presenca/Reunioes/' + $("#Reuniao").val();
}



