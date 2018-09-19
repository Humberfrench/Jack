/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />

var Colaborador = new Object();

Colaborador.URLObterTodos = '';
Colaborador.URLEdit = '';
Colaborador.URLGravar = '';
Colaborador.URLExcluirSacola = '';
Colaborador.URLDevolver = '';
Colaborador.URLObterColaboradors = '';
Colaborador.URLObterRepresentantes = '';
Colaborador.URLObterPresencas = '';


$(document).ready(function ()
{

    $("select.form-control.input-sm").select2(
        {
            minimumResultsForSearch: Infinity,
            theme: "classic"
    });

    $("#Colaborador").select2({
        theme: "classic"
    });
    
    $("#Ano").select2({
        theme: "classic"
    });
    
    if ($("#ColaboradorId").val() !== 0)
    {
        $("#Colaborador").val($("#ColaboradorId").val());
    }
    if ($("#AnoValue").val() !== 0)
    {
        $("#Ano").val($("#AnoValue").val());
    }
    Colaborador.MontarTabela();
    Colaborador.URLExcluirSacola = $("#URLExcluirSacola").val();
    Colaborador.URLDevolver = $("#URLDevolver").val();


});

Colaborador.Pesquisar = function ()
{
    if (($("#Colaborador").val() === '') || ($("#Colaborador").val() === '0'))
    {
        Mensagens.Erro("Familia não preenchida", "Erro na Pesquisa");
        return false;
    }
    if (($("#Ano").val() === '') || ($("#Ano").val() === '0'))
    {
        Mensagens.Erro("Ano não preenchido", "Erro na Pesquisa");
        return false;
    }

    location.href = '/Colaborador/Crianca/' + $("#Colaborador").val() + '/Ano/' + $("#Ano").val()  ;
}
 
Colaborador.MontarTabela = function ()
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
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [3], "bSortable": true },
            { "aTargets": [4], "bSortable": true },
            { "aTargets": [5], "bSortable": true },
            { "aTargets": [6], "bSortable": true },
            { "aTargets": [7], "bSortable": false }
        ]
    });
}


Colaborador.Devolver = function (id, colaborador, ano)
{
    var opcoes = new Object;
    opcoes.url = Colaborador.URLDevolver;

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
            setTimeout(function ()
            {
                location.reload();
            }, 1500);
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = id;
    opcoes.dadoEnvio.colaborador = colaborador;
    opcoes.dadoEnvio.ano = ano;
    opcoes.type = 'POST';
    opcoes.async = false;

    Ajax.Execute(opcoes);
}

Colaborador.ExcluirSacola = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Colaborador.URLExcluirSacola;

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

