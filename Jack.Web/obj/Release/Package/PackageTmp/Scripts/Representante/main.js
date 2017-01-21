/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />

var Representante = new Object();

Representante.URLObterTodos = '';
Representante.URLGravar = '';
Representante.URLExcluir = '';
Representante.URLAtivar = '';
Representante.URLDesativar = '';
Representante.URLObterListaRepresentantes = '';

$(document).ready(function ()
{
    Representante.MontarTabela();

    Representante.URLObterListaRepresentantes = $("#URLObterListaRepresentantes").val();
    Representante.URLAtivar = $("#URLAtivar").val();
    Representante.URLDesativar = $("#URLDesativar").val();
    Representante.URLGravar = $("#URLGravar").val();
    Representante.URLExcluir = $("#URLExcluir").val();

    $("#Familia").val(null);
    if ($("#CodigoFamilia").val() !== '0')
    {
        $("#Familia").val($("#CodigoFamilia").val());
    }

    if ($("#Familia").val() === null)
    {
        $("#Adicionar").prop('disabled', 'disabled');
    }

    $("#Status").val(14);

    $("#PercentualCriancas").knob(
        {
            'min': 0,
            'max': 100,
            'width':50,
            'height': 50,
            'stopper' : false
        });


    $("#Adicionar").click(function ()
    {
        $("#modalRepresentantes").modal('show');
        Representante.Carregar();
    });

});

Representante.Carregar = function ()
{
    $("#divRepresentantes").html('');

    var opcoes = new Object;
    opcoes.url = Representante.URLObterListaRepresentantes;
    opcoes.callBackSuccess = function (response)
    {
        $("#divRepresentantes").html(response);
        $('#TableRepresentante').DataTable(Representante.DefaultDefinitionOfTable);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = $("#CodigoFamilia").val();

    Ajax.Get(opcoes);

}

Representante.Pesquisar = function ()
{
    if (($("#Familia").val() === '') || ($("#Familia").val() === '0'))
    {
        Mensagens.Erro("Familia não preenchida", "Erro na Pesquisa");
        return false;
    }

    location.href = '/Representante/' + $("#Familia").val();
}
Representante.LimparForm = function ()
{

}

Representante.Gravar = function (idRepsesentada)
{
    var idRepresentante = $("#CodigoFamilia").val();
    
    var opcoes = new Object;
    opcoes.url = Representante.URLGravar;
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
            Representante.Carregar();
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.familiaRepresentante = idRepresentante;
    opcoes.dadoEnvio.familiaRepresentada = idRepsesentada;
    opcoes.dadoEnvio.tipoParentesco = $("#TipoParentesco").val();

    Ajax.Execute(opcoes);
}

Representante.MontarTabela = function ()
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


Representante.DefaultDefinitionOfTable = {
    "bSort": false,
    "searching": true,
    "autoWidth": false,
    "lengthMenu": [[4, 8, 12, -1], [4, 8, 12, "Todos"]],
    "order": [],
    "language": {
        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sLoadingRecords": "Carregando...",
        "sLengthMenu": "_MENU_ resultados por página",
        "sProcessing": "Processando...",
        "sZeroRecords": "<div class='col-xs-12 tabela-contas no-pad'>Nenhum registro encontrado</div>",
    },
    "classes": {
        "sFilterInput": "form-control campo-busca",
        "sInfo": "num-pag col-xs-12 text-right no-pad hidden-xs",
        "sEmptyTable": "num-pag col-xs-12 text-right no-pad hidden-xs",
        "sPaging": "text-center",
        "sPageButtonActive": "active"
    },
    "dom": '<"top"li>rt<"bottom"p><"clear">',
    "pagingType": "numbers"
}

Representante.Ativar = function (id)
{
    var opcoes = new Object;
    opcoes.url = Representante.URLAtivar;
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
Representante.Desativar = function (id)
{
    var opcoes = new Object;
    opcoes.url = Representante.URLDesativar;
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

Representante.Excluir = function (id)
{
    var opcoes = new Object;
    opcoes.url = Representante.URLExcluir;
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