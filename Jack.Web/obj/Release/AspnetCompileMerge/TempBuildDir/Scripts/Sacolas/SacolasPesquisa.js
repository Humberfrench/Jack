/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../util/QrCode.js" />
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

    $("#Nivel").change(function()
    {
        if ($(this).val() === '0')
        {
            $("#Familia").html('');
            return false;
        }
        SacolasPesquisa.ObterFamilias($(this).val());
            return false;
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
            { "aTargets": [4], "bSortable": false },
            { "aTargets": [5], "bSortable": false }
        ]
    });
}

SacolasPesquisa.ObterFamilias = function (nivel)
{
    //carregar os dados do grid
    var opcoes = new Object;
    opcoes.url = '/Sacolas/Pesquisar/ObterFamilias/' + nivel;

    opcoes.callBackSuccess = function (response)
    {
        var listaFamilias = eval(response);

        var optionData = '';
        for (var intCont = 0; intCont < listaFamilias.length; intCont++) {
            optionData += Util.ObterLista(listaFamilias[intCont].Codigo, listaFamilias[intCont].Nome);
        }
        $("#Familia").html(optionData);

        if ($("#FamiliaId").val() !== '') {
            $("#Familia").val($("#FamiliaId").val());
        }

    }

    //opcoes.dadoEnvio = new Object;
    //opcoes.dadoEnvio.nivel = nivel;

    Ajax.Get(opcoes);


}

SacolasPesquisa.Pesquisar = function ()
{
    var familia = $("#Familia").val();
    if (familia === null)
    {
        familia = 0;
    }

    if (familia !== 0)
    {
        location.href = '/Sacolas/Pesquisar/Familia/' + $("#Familia").val() + '/Nivel/' + $("#Nivel").val() ;
    }
    else
    {
        location.href = '/Sacolas/Pesquisar/Nivel/' + $("#Nivel").val() + '/Kit/' + $("#Kit").val();
    }
}

SacolasPesquisa.ImprimirSelecionados = function ()
{

}

SacolasPesquisa.Imprimir = function(codigoSacola)
{
    
}

SacolasPesquisa.GerarQrCode = function (width, height, crianca, url)
{

    QrCode.Gerar(width, height, crianca, '#divImagemChave', url);
    $("#modalQrCode").modal('show');

}

SacolasPesquisa.PopUpColaborador = function (sacola)
{
    //carregar os dados do grid
    var opcoes = new Object;
    opcoes.url = '/Sacolas/Pesquisar/AdicionarColaboradores/' + sacola;

    opcoes.callBackSuccess = function (response)
    {
        $("#divDados").html(response);
        $("#modalAdicionaColaborador").modal();

    }

    Ajax.Get(opcoes);

}

SacolasPesquisa.AdicionarColaborador = function (colaborador, sacola)
{
    //carregar os dados do grid
    var opcoes = new Object;
    opcoes.url = '/Sacolas/Pesquisar/AdicionarColaborador/';

    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Erro) {
            Mensagens.Erro(dataObj.Mensagem);
        }
        else {
            Mensagens.Sucesso(dataObj.Mensagem);
            $("#modalAdicionaColaborador").modal('hide');
            setTimeout(function ()
            {
                location.reload();
            }, 1500);
        }


    }

    Ajax.Post(opcoes);
}
