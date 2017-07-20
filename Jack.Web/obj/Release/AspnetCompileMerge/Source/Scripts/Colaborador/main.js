/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
var Colaborador = new Object();

Colaborador.URLObterTodos = '';
Colaborador.URLFiltrar = '/Colaborador/Filtrar/';
Colaborador.URLEdit = '';
Colaborador.URLGravar = '';
Colaborador.URLExcluir = '';
Colaborador.URLAutoComplete = '';

$(document).ready(function ()
{
    Colaborador.MontarTabela();
    Colaborador.URLObterTodos = $("#URLObterTodos").val();
    Colaborador.URLEdit = $("#URLEdit").val();
    Colaborador.URLGravar = $("#URLGravar").val();
    Colaborador.URLExcluir = $("#URLExcluir").val();
    Colaborador.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        Colaborador.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        Colaborador.Gravar();
    });

    $("#Novo").click(function ()
    {
        Colaborador.LimparForm();
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

    Colaborador.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Colaborador.LimparForm();
    Colaborador.Edit(id);
    $("#modalEdicao").modal('show');
}

Colaborador.MontarTabela = function ()
{
    $('#TableColaborador').DataTable({
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
]
    });
}

Colaborador.Pesquisar = function (nome)
{

    if (nome === '')
    {
        Colaborador.PesquisarTodos();
    }
    else
    {
        location.href = Colaborador.URLFiltrar + nome;
    }
}

Colaborador.PesquisarTodos = function ()
{
    location.href = Colaborador.URLObterTodos;
}

Colaborador.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Nome").val('');
    $("#Telefone").val('');
    $("#Celular").val('');
    $("#CPF").val('');
    $("#Email").val('');
}

Colaborador.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = Colaborador.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        Colaborador.LimparForm();
        $("#Codigo").val(codigo);
        $("#Nome").val(dataObj.Nome);
        $("#Telefone").val(dataObj.Telefone);
        $("#Celular").val(dataObj.Celular);
        $("#CPF").val(dataObj.Cpf);
        $("#Email").val(dataObj.Email);
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

Colaborador.Gravar = function ()
{
    if (Colaborador.Consistir($("#Nome").val()))
    {
        var token = $('input[name="__RequestVerificationToken"]').val();

        var opcoes = new Object;
        opcoes.url = Colaborador.URLGravar;
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
                Colaborador.LimparForm();
                $("#modalEdicao").modal('hide');
                setTimeout(function ()
                {
                    location.reload();
                }, 1500);
            }
        };

        opcoes.dadoEnvio = new Object;
        opcoes.dadoEnvio.Codigo = $("#Codigo").val();
        opcoes.dadoEnvio.Nome = $("#Nome").val();
        opcoes.dadoEnvio.Telefone = $("#Telefone").val();
        opcoes.dadoEnvio.Celular = $("#Celular").val();
        opcoes.dadoEnvio.Cpf = $("#CPF").val();
        opcoes.dadoEnvio.Email = 'naotem@french.com.br';
        if ($("#Email").val() !== '')
        {
            opcoes.dadoEnvio.Email = $("#Email").val();
        }
        
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

Colaborador.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Colaborador.URLExcluir;

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
            Colaborador.LimparForm();
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

Colaborador.Consistir = function (nome)
{
    var mensagemErro = '';
    if(nome === '')
    {
        mensagemErro = 'O Campo Nome é Obrigatório';
    }
    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}


