/// <reference path="../util/util.js" />
/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var Presenca = new Object();


Presenca.URLObterReunioes = '';
Presenca.URLListaFamilias = '';
Presenca.URLGravar = '';

$(document).ready(function ()
{
    Presenca.URLObterReunioes = $("#URLObterReunioes").val();
    Presenca.URLListaFamilias = $("#URLListaFamilias").val();
    Presenca.URLGravar = $("#URLGravar").val();

    $("#Ano").change(function ()
    {
        Presenca.ObterReunioes($("#Ano").val());
    });

    $("#Pesquisar").click(function ()
    {
        var reuniao = $("#Reuniao").val();
        var letra = $("#Letra").val();
        if (reuniao == undefined)
        {
            Mensagens.Erro('Parametros da Pesquisa inconsistentes e ou faltando', 'Problemas no Formulário');
            return false;
        }
        Presenca.Pesquisar(reuniao, letra);
    });

});


Presenca.MontarTabela = function ()
{
    $('#TablePresenca').DataTable({
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
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [3], "bSortable": false }
        ]
    });
}

Presenca.Pesquisar = function (reuniao, letra)
{
    var opcoes = new Object;
    opcoes.url = Presenca.URLListaFamilias;
    opcoes.callBackSuccess = function (response)
    {
        $("#divReuniao").html(response);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.reuniao = reuniao;
    opcoes.dadoEnvio.letra = letra;

    Ajax.Get(opcoes);
}

Presenca.ObterReunioes = function (ano)
{

    if (ano !== '0')
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

        };

        opcoes.dadoEnvio = new Object;
        opcoes.dadoEnvio.ano = ano;

        Ajax.Get(opcoes);
    }
}

Presenca.Gravar = function (familia)
{
    var opcoes = new Object;
    var reuniao = $("#Reuniao").val();
    
    opcoes.url = Presenca.URLGravar;
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
            var reuniao = $("#Reuniao").val();
            Presenca.Pesquisar(reuniao);
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.familia = familia;
    opcoes.dadoEnvio.reuniao = reuniao;

    Ajax.Post(opcoes);
}


