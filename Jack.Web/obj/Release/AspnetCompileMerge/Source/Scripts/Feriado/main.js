/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />

var Feriado = new Object();

Feriado.URLObterTodos = '';
Feriado.URLFiltrar = '';
Feriado.URLEdit = '';
Feriado.URLGravar = '';
Feriado.URLExcluir = '';
Feriado.URLAutoComplete = '';

$(document).ready(function ()
{
    Feriado.MontarTabela();
    Feriado.UpdateCalendario();

    Feriado.URLObterTodos = $("#URLObterTodos").val();
    Feriado.URLEdit = $("#URLEdit").val();
    Feriado.URLFiltrar = $("#URLFiltrar").val();
    Feriado.URLGravar = $("#URLGravar").val();
    Feriado.URLExcluir = $("#URLExcluir").val();
    Feriado.URLAutoComplete = $("#URLAutoComplete").val();

    $("#Pesquisar").click(function ()
    {
        var nome = $("#PesquisarNome").val();
        Feriado.Pesquisar(nome);
    });

    $("#Gravar").click(function ()
    {
        Feriado.Gravar();
    });

    $("#Novo").click(function ()
    {
        Feriado.LimparForm();
        $("#modalEdicao").modal('show');
    });

});

function ExcluirConfirmar(codigo, nome, ano, data)
{
    $("#spnCodigo").html(codigo);
    $("#spnNome").html(nome);
    $("#spnAno").html(ano);
    $("#spnData").html(data);
    $("#codigoExclusao").val(codigo);
    $("#modalExclusao").modal('show');
}

function Excluir()
{
    if ($("#codigoExclusao").val() === '')
    {
        return false;
    }

    Feriado.Excluir($("#codigoExclusao").val());
}

Feriado.UpdateCalendario = function ()
{

    $("#Data").datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true
    });

    var dataValue = moment().format("DD/MM/YYYY");

    $("#Data").datepicker('setDate', dataValue);
    $("#Data").datepicker('update');
    $("#Data").val('');

    $("#ProximaReuniao").datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true
    });

    var proximaReuniaoValue = moment().format("DD/MM/YYYY");

    $("#ProximaReuniao").datepicker('setDate', proximaReuniaoValue);
    $("#ProximaReuniao").datepicker('update');
    $("#ProximaReuniao").val('');


    $("#ReuniaoAnterior").datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true
    });

    var reuniaoAnteriorValue = moment().format("DD/MM/YYYY");

    $("#ReuniaoAnterior").datepicker('setDate', reuniaoAnteriorValue);
    $("#ReuniaoAnterior").datepicker('update');
    $("#ReuniaoAnterior").val('');

}

function Edit(id)
{
    Feriado.LimparForm();
    Feriado.Edit(id);
    $("#modalEdicao").modal('show');
}

Feriado.MontarTabela = function ()
{
    $('#TableFeriado').DataTable({
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
            { "aTargets": [0], "bSortable": true },
            { "aTargets": [1], "bSortable": true },
            { "aTargets": [2], "bSortable": true },
            { "aTargets": [3], "bSortable": true },
            { "aTargets": [4], "bSortable": true },
            { "aTargets": [5], "bSortable": true },
            { "aTargets": [6], "bSortable": true },
            { "aTargets": [7], "bSortable": false }
    ]    });
}

Feriado.Pesquisar = function (nome)
{

    if (nome === '')
    {
        Feriado.PesquisarTodos();
    }
    else
    {
        location.href = Feriado.URLFiltrar + nome;
    }
}

Feriado.PesquisarTodos = function ()
{
    location.href = Feriado.URLObterTodos;
}

Feriado.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Nome").val('');
    $("#Data").val('');
    $("#AnoEfetivo").val('0');
    $("#ProximaReuniao").val('');
    $("#ReuniaoAnterior").val('');
    $("#PodeTerReuniao").prop('checked', '');
}

Feriado.Edit = function (codigo)
{

    var opcoes = new Object;
    opcoes.url = Feriado.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        var data = '';
        var proximaReuniao = '';
        var reuniaoAnterior = '';
        Feriado.LimparForm();
        $("#Codigo").val(codigo);
        $("#Nome").val(dataObj.Nome);
        if (dataObj.PodeTerReuniao)
        {
            $("#PodeTerReuniao").prop('checked', 'checked');
        }

        if (dataObj.Data !== null)
        {
            data = moment(dataObj.Data.toString()).format("DD/MM/YYYY");
            $("#Data").datepicker('setDate', data);
            $("#Data").datepicker('update');
            $("#Data").val('');
            $("#Data").val(data);
        }

        if (dataObj.ProximaReuniao !== null)
        {
            proximaReuniao = moment(dataObj.ProximaReuniao.toString()).format("DD/MM/YYYY");
            $("#ProximaReuniao").datepicker('setDate', proximaReuniao);
            $("#ProximaReuniao").datepicker('update');
            $("#ProximaReuniao").val('');
            $("#ProximaReuniao").val(proximaReuniao);
        }

        if (dataObj.ReuniaoAnterior !== null)
        {
            reuniaoAnterior = moment(dataObj.ReuniaoAnterior.toString()).format("DD/MM/YYYY");
            $("#ReuniaoAnterior").datepicker('setDate', reuniaoAnterior);
            $("#ReuniaoAnterior").datepicker('update');
            $("#ReuniaoAnterior").val('');
            $("#ReuniaoAnterior").val(reuniaoAnterior);
        }

        $("#Ano").val(dataObj.AnoEfetivo);

    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

Feriado.Gravar = function ()
{
    if (Feriado.Consistir())
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var reuniaoAnterior = $("#PodeTerReuniao").prop('checked');

        var opcoes = new Object;
        opcoes.url = Feriado.URLGravar;
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
                Feriado.LimparForm();
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
        opcoes.dadoEnvio.PodeTerReuniao = reuniaoAnterior;
        opcoes.dadoEnvio.AnoEfetivo = $("#Ano").val();
        opcoes.dadoEnvio.ReuniaoAnterior = $("#ReuniaoAnterior").val();
        opcoes.dadoEnvio.ProximaReuniao = $("#ProximaReuniao").val();
        opcoes.dadoEnvio.Data = $("#Data").val();
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

Feriado.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Feriado.URLExcluir;

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
            Feriado.LimparForm();
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

Feriado.Consistir = function ()
{
    var mensagemErro = '';
    if ($("#Nome").val() === '')
    {
        mensagemErro = 'O Campo Descrição é Obrigatório';
    }

    if ($("#Data").val() === '')
    {
        mensagemErro = 'O Campo Data é Obrigatório';
    }

    if ($("#ReuniaoAnterior").val() === '')
    {
        mensagemErro = 'O Campo Reunião Anterior é Obrigatório';
    }

    if ($("#ProximaReuniao").val() === '')
    {
        mensagemErro = 'O Campo Próxima Reunião é Obrigatório';
    }

    if ($("#Ano").val() === '0')
    {
        mensagemErro = 'O Campo Ano Efetivo é Obrigatório';
    }

    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}


