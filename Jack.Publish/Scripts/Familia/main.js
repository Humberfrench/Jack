/// <reference path="../util/mensagens.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />

var Familia = new Object();

Familia.URLObterTodos = '';
Familia.URLFiltrar = '/Familia/Filtrar/';
Familia.URLEdit = '';
Familia.URLGravar = '';
Familia.URLExcluir = '';
Familia.URLObterCriancas = '';
Familia.URLObterRepresentantes = '';
Familia.URLObterPresencas = '';
Familia.URLProcessar = '';
Familia.URLProcessarCriancas = '';
Familia.URLProcessarPresenca = '';

$(document).ready(function ()
{
    Familia.MontarTabela();
    Familia.URLObterTodos = $("#URLObterTodos").val();
    Familia.URLEdit = $("#URLEdit").val();
    Familia.URLGravar = $("#URLGravar").val();
    Familia.URLExcluir = $("#URLExcluir").val();
    Familia.URLAutoComplete = $("#URLAutoComplete").val();
    Familia.URLObterCriancas = $("#URLObterCriancas").val();
    Familia.URLObterPresencas = $("#URLObterPresencas").val();
    Familia.URLObterRepresentantes = $("#URLObterRepresentantes").val();
    Familia.URLProcessar = $("#URLProcessar").val();
    Familia.URLProcessarCriancas = $("#URLProcessarCriancas").val();
    Familia.URLProcessarPresenca = $("#URLProcessarPresenca").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        Familia.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        Familia.Gravar();
    });

    $("#Novo").click(function ()
    {
        Familia.LimparForm();
        $("#modalEdicao").modal('show');
    });

    $("#BlacklistPasso1").change(function ()
    {
        $("#BlacklistPasso2").prop('disabled', 'disabled');
        if ($(this).prop('checked'))
        {
            $("#BlacklistPasso2").prop('disabled', '');
        }
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

    Familia.Excluir($("#codigoExclusao").val());
}

Familia.MontarTabela = function ()
{
    $('#TableFamilia').DataTable({
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
            { "aTargets": [0], "bSortable": true },
            { "aTargets": [1], "bSortable": true },
            { "aTargets": [2], "bSortable": false },
            { "aTargets": [3], "bSortable": false },
            { "aTargets": [4], "bSortable": false },
            { "aTargets": [5], "bSortable": false },
            { "aTargets": [6], "bSortable": false },
            { "aTargets": [7], "bSortable": false },
            { "aTargets": [8], "bSortable": false }
    ]    });
}

Familia.Pesquisar = function (nome)
{

    if (nome === '')
    {
        Familia.PesquisarTodos();
    }
    else
    {
        location.href = Familia.URLFiltrar + nome;
    }
}

Familia.PesquisarTodos = function ()
{
    location.href = Familia.URLObterTodos;
}

Familia.LimparForm = function ()
{
    $("#divReuniao").show();
    $("#Codigo").val('0');
    $("#Nome").val('');
    $("#Contato").val('');
    $("#DataAtualizacao").val('');
    $("#DataCriacao").val('');

    $("#Nivel").prop('disabled', 'disabled');
    $("#Nivel").val('99');
    $("#Status").prop('disabled', 'disabled');
    $("#Status").val('14');

    $("#Sacolinha").prop('checked', '');
    $("#Consistente").prop('checked', '');
    $("#PermiteExcedente").prop('checked', '');
    $("#PresencaJustificada").prop('checked', '');
    $("#Fake").prop('checked', '');

    $("#BlackListPasso1").prop('checked', '');
    $("#BlackListPasso2").prop('checked', '');
    $("#BlackListPasso2").prop('disabled', 'disabled');

}

Familia.Editar = function (codigo)
{

    $("#modalEdicao").modal('show');
    var opcoes = new Object;
    opcoes.url = Familia.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        var dataValueAlt = '';
        var dataValueInc = '';

        Familia.LimparForm();
        $("#divReuniao").hide();
        $("#Codigo").val(codigo);
        $("#Nome").val(dataObj.Nome);
        $("#Contato").val(dataObj.Contato);

        if (dataObj.DataAtualizacao !== null)
        {
            dataValueAlt = moment(dataObj.DataAtualizacao.toString()).format("DD/MM/YYYY HH:mm");
        }

        if (dataObj.DataCriacao !== null)
        {
            dataValueInc = moment(dataObj.DataCriacao.toString()).format("DD/MM/YYYY HH:mm");
        }

        $("#DataAtualizacao").val(dataValueAlt);
        $("#DataCriacao").val(dataValueInc);
        $("#Nivel").val(dataObj.Nivel.Codigo);
        $("#Status").val(dataObj.Status.Codigo);
        $("#Nivel").prop('disabled', 'disabled');
        $("#Status").prop('disabled', 'disabled');

        if (dataObj.Sacolinha)
        {
            $("#Sacolinha").prop('checked', 'checked');
        }

        if (dataObj.Consistente)
        {
            $("#Consistente").prop('checked', 'checked');
        }

        if (dataObj.PermiteExcedenteCrianca)
        {
            $("#PermiteExcedenteCrianca").prop('checked', 'checked');
        }

        if (dataObj.PermiteExcedenteRepresentante)
        {
            $("#PermiteExcedenteRepresentante").prop('checked', 'checked');
        }

        if (dataObj.Fake)
        {
            $("#Fake").prop('checked', 'checked');
        }

        if (dataObj.PresencaJustificada)
        {
            $("#PresencaJustificada").prop('checked', 'checked');
        }

        if (dataObj.BlackListPasso1)
        {
            $("#BlackListPasso1").prop('checked', 'checked');
            $("#BlackListPasso2").prop('disabled', '');
        }

        if (dataObj.BlackListPasso2)
        {
            $("#BlackListPasso2").prop('checked', 'checked');
        }

    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

Familia.Gravar = function ()
{
    if (Familia.Consistir())
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var opcional = $("#Opcional").prop('checked');

        var opcoes = new Object;
        opcoes.url = Familia.URLGravar;
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
                Familia.LimparForm();
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
        opcoes.dadoEnvio.Contato = $("#Contato").val();
        opcoes.dadoEnvio.DataCriacao = $("#DataCriacao").val();

        opcoes.dadoEnvio.Nivel = new Object;
        opcoes.dadoEnvio.Nivel.Codigo = $("#Nivel").val();

        opcoes.dadoEnvio.Status = new Object;
        opcoes.dadoEnvio.Status.Codigo = $("#Status").val();

        opcoes.dadoEnvio.Sacolinha = $("#Sacolinha").prop('checked');
        opcoes.dadoEnvio.Consistente = $("#Consistente").prop('checked');
        opcoes.dadoEnvio.PermiteExcedenteCrianca = $("#PermiteExcedenteCrianca").prop('checked');
        opcoes.dadoEnvio.PermiteExcedenteRepresentante = $("#PermiteExcedenteRepresentante").prop('checked');
        opcoes.dadoEnvio.PresencaJustificada = $("#PresencaJustificada").prop('checked');
        opcoes.dadoEnvio.Fake = $("#Fake").prop('checked');
        opcoes.dadoEnvio.BlackListPasso1 = $("#BlackListPasso1").prop('checked');
        opcoes.dadoEnvio.BlackListPasso2 = $("#BlackListPasso2").prop('checked');

        var reuniao = 0;
        if ($("#Codigo").val() === '0')
        {
            if ($("#MarcarPresenca").prop('checked'))
            {
                reuniao = $("#Reunioes").val();
            }
        }

        opcoes.dadoEnvio.reuniao = reuniao;

        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

Familia.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Familia.URLExcluir;

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
            Familia.LimparForm();
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

Familia.Consistir = function (nome)
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

Familia.Criancas = function (codigo)
{
    $("#divDados").html('');
    $("#Titulo").html('');

    var opcoes = new Object;
    opcoes.url = Familia.URLObterCriancas;
    opcoes.callBackSuccess = function (response)
    {
        $("#Titulo").html('Crianças');
        $("#divDados").html(response);
        $('#TableCriancas').DataTable(Familia.DefaultDefinitionOfTable);
        $("#modalPopDados").modal('show');
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.codigo = codigo;

    Ajax.Get(opcoes);
}

Familia.Presencas = function (codigo)
{
    $("#divDados").html('');
    $("#Titulo").html('');

    var opcoes = new Object;
    opcoes.url = Familia.URLObterPresencas;
    opcoes.callBackSuccess = function (response)
    {
        $("#Titulo").html('Presencas');
        $("#divDados").html(response);
        $('#TablePresencas').DataTable(Familia.DefaultDefinitionOfTable);
        $("#modalPopDados").modal('show');
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.codigo = codigo;

    Ajax.Get(opcoes);
}

Familia.Representantes = function (codigo)
{
    $("#divDados").html('');
    $("#Titulo").html('');

    var opcoes = new Object;
    opcoes.url = Familia.URLObterRepresentantes;
    opcoes.callBackSuccess = function (response)
    {
        $("#Titulo").html('Representantes');
        $("#divDados").html(response);
        $('#TableRepresentantes').DataTable(Familia.DefaultDefinitionOfTable);
        $("#modalPopDados").modal('show');
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.codigo = codigo;

    Ajax.Get(opcoes);
}

Familia.Processar = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Familia.URLProcessar;

    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Erro)
        {
            if (dataObj.Warning)
            {
                Mensagens.Info(dataObj.Mensagem);
            }
            else
            {
                Mensagens.Erro(dataObj.Mensagem);
            }
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

Familia.ProcessarCriancas = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Familia.URLProcessarCriancas;

    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Erro)
        {
            if (dataObj.Warning)
            {
                Mensagens.Info(dataObj.Mensagem);
            }
            else
            {
                Mensagens.Erro(dataObj.Mensagem);
            }
        }
        else
        {
            Mensagens.Sucesso(dataObj.Mensagem);
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;
    opcoes.type = 'POST';
    opcoes.async = false;

    Ajax.Execute(opcoes);

}

Familia.ProcessarPresenca = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Familia.URLProcessarPresenca;

    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        if (dataObj.Erro)
        {
            if (dataObj.Warning)
            {
                Mensagens.Info(dataObj.Mensagem);
            }
            else
            {
                Mensagens.Erro(dataObj.Mensagem);
            }
        }
        else
        {
            Mensagens.Sucesso(dataObj.Mensagem);
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;
    opcoes.type = 'POST';
    opcoes.async = false;

    Ajax.Execute(opcoes);

}


Familia.DefaultDefinitionOfTable = {
    "bSort": false,
    "searching": false,
    "autoWidth": false,
    "lengthMenu": [[6, 12, 20, -1], [6, 12, 20, "Todos"]],
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