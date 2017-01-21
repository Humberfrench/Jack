/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />

var Reuniao = new Object();

Reuniao.URLObterTodos = '';
Reuniao.URLMontarDataReuniao = '';
Reuniao.URLEdit = '';
Reuniao.URLGravar = '';
Reuniao.URLExcluir = '';
Reuniao.URLAutoComplete = '';

$(document).ready(function ()
{
    Reuniao.MontarTabela();
    Reuniao.UpdateCalendario();

    Reuniao.URLObterTodos = $("#URLObterTodos").val();
    Reuniao.URLEdit = $("#URLEdit").val();
    Reuniao.URLGravar = $("#URLGravar").val();
    Reuniao.URLExcluir = $("#URLExcluir").val();
    Reuniao.URLAutoComplete = $("#URLAutoComplete").val();
    Reuniao.URLMontarDataReuniao = $("#URLMontarDataReuniao").val();

    $("#AnoPesquisa").val($("#AnoValue").val());

    $("#Gravar").click(function ()
    {
        Reuniao.Gravar();
    });

    $("#Novo").click(function ()
    {
        Reuniao.LimparForm();
        $("#modalEdicao").modal('show');
    });

});

Reuniao.UpdateCalendario = function ()
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

}

function ExcluirConfirmar(codigo, ano, anoCorrente, data)
{
    $("#spnCodigo").html(codigo);
    $("#spnAno").html(ano);
    $("#spnAnoCorrente").html(anoCorrente);
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

    Reuniao.Excluir($("#codigoExclusao").val());
}

function Edit(id)
{
    Reuniao.LimparForm();
    Reuniao.Edit(id);
    $("#modalEdicao").modal('show');
}

Reuniao.MontarTabela = function ()
{
    $('#TableReuniao').DataTable({
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
            { "aTargets": [6], "bSortable": false }
        ]
    });
}

Reuniao.Pesquisar = function ()
{

    if ($("#AnoPesquisa").val() !== '0')
    {
        location.href = Reuniao.URLObterTodos + "/" + $("#AnoPesquisa").val();
    }
}

Reuniao.PesquisarTodos = function ()
{
    location.href = Reuniao.URLObterTodos;
}

Reuniao.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Ano").val('0');
    $("#AnoCorrente").val('0');
    $("#Data").val('');
}

Reuniao.Edit = function (codigo)
{

    var opcoes = new Object;
    var data = '';
    opcoes.url = Reuniao.URLEdit;
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        Reuniao.LimparForm();
        $("#Codigo").val(codigo);
        $("#Ano").val(dataObj.Ano);
        $("#AnoCorrente").val(dataObj.AnoCorrente);
        if (dataObj.Data !== null)
        {
            data = moment(dataObj.Data.toString()).format("DD/MM/YYYY");
            $("#Data").datepicker('setDate', data);
            $("#Data").datepicker('update');
            $("#Data").val('');
            $("#Data").val(data);
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = codigo;

    Ajax.Get(opcoes);

}

Reuniao.Gravar = function ()
{
    if (Reuniao.Consistir($("#Descricao").val()))
    {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var opcional = $("#Opcional").prop('checked');

        var opcoes = new Object;
        opcoes.url = Reuniao.URLGravar;
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
                Reuniao.LimparForm();
                $("#modalEdicao").modal('hide');
                setTimeout(function ()
                {
                    location.reload();
                }, 1500);
            }
        };

        opcoes.dadoEnvio = new Object;
        opcoes.dadoEnvio.Codigo = $("#Codigo").val();
        opcoes.dadoEnvio.Ano = $("#Ano").val();
        opcoes.dadoEnvio.AnoCorrente = $("#AnoCorrente").val();
        opcoes.dadoEnvio.Data = $("#Data").val();
        opcoes.type = 'POST';
        opcoes.async = false;

        Ajax.Execute(opcoes);

    }
}

Reuniao.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Reuniao.URLExcluir;

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
            Reuniao.LimparForm();
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

Reuniao.MontarDataReuniao = function ()
{

    if ($("#AnoPesquisa").val() === '0')
    {
        Mensagens.Erro('O Campo Ano é Obrigatório <br />');
        return false;
    }

    var opcoes = new Object;
    opcoes.url = Reuniao.URLMontarDataReuniao;

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
                Reuniao.Pesquisar();
            }, 1500);
        }
    };

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.ano = $("#AnoPesquisa").val();
    opcoes.async = false;

    Ajax.Get(opcoes);

}

Reuniao.Consistir = function ()
{
    var mensagemErro = '';

    if ($("#Ano").val() === '0')
    {
        mensagemErro = mensagemErro + 'O Campo Ano é Obrigatório <br />';
    }

    if ($("#AnoCorrente").val() === '0')
    {
        mensagemErro = mensagemErro + 'O Campo Ano Corrente é Obrigatório <br />';
    }
    if ($("#Data").val() === '')
    {
        mensagemErro = mensagemErro + 'O Campo Data é Obrigatório <br />';
    }
    else
    {
        if (($("#Ano").val() === '0') && ($("#AnoCorrente").val() === '0'))
        {
            var diaDaSemana = moment($("#Data").val()).format("DD/MM/YYYY").isoWeekday();
            var ano = moment($("#Data").val(), "DD/MM/YYYY").format("YYYY");
            //ver se a Data é do Ano Atual.

            if (ano !== $("#Ano").val())
            {
                if (ano !== $("#AnoCorrente").val())
                {
                    mensagemErro = mensagemErro + 'A Data deve ser no Ano ou no Ano Corrente <br />';
                }
            }
            if (diaDaSemana !== 6)
            {
                mensagemErro = mensagemErro + 'A Data deve ser sempre em um sábado! <br />';
            }
        }

    }
    if (mensagemErro !== '')
    {
        Mensagens.Erro(mensagemErro);
        return false;
    }
    return true;
}


