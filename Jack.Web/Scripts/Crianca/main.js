/// <reference path="../util/mensagens.js" />
/// <reference path="../util/util.js" />
/// <reference path="../util/ajax.js" />
/// <reference path="../moment.js" />
/// <reference path="../plugins/sweetalert/sweetalert.min.js" />

var Crianca = new Object();

Crianca.URLObterTodos = '';
Crianca.URLEdit = '';
Crianca.URLGravar = '';
Crianca.URLExcluir = '';
Crianca.URLObterCriancas = '';
Crianca.URLObterParametro = '';
Crianca.URLObterPresencas = '';
Crianca.URLProcessarCriancas = '';
Crianca.URLProcessarCrianca = '';
Crianca.URLProcessarPresenca = '';
Crianca.URLProcessarFamilia = '';

Crianca.NumeroMaximoCricancas = 0;
Crianca.CalcadoLimite = 0;

$(document).ready(function ()
{
    Crianca.URLProcessarCriancas = $("#URLProcessarCriancas").val();
    Crianca.URLProcessarCrianca = $("#URLProcessarCrianca").val();
    Crianca.URLProcessarPresenca = $("#URLProcessarPresenca").val();
    Crianca.URLProcessarFamilia = $("#URLProcessarFamilia").val();
    Crianca.URLObterTodos = $("#URLObterTodos").val();
    Crianca.URLEdit = $("#URLEdit").val();
    Crianca.URLGravar = $("#URLGravar").val();
    Crianca.URLExcluir = $("#URLExcluir").val();
    Crianca.URLObterParametro = $("#URLObterParametro").val();
    Crianca.MontarTabela();

    $("#Familia").val(null);
    if ($("#CodigoFamilia").val() !== 0)
    {
        $("#Familia").val($("#CodigoFamilia").val());
    }
    if ($("#Familia").val() === null)
    {
        $("#Novo").prop('disabled', 'disabled');
    }

    $("#ProcessarFamilia").click(function ()
    {
        Familia.ProcessarFamilia($("#CodigoFamilia").val());
    });

    $("#ProcessarPresenca").click(function ()
    {
        Familia.ProcessarPresenca($("#CodigoFamilia").val());
    });

    $("#ProcessarCriancas").click(function ()
    {
        Familia.ProcessarCriancas($("#CodigoFamilia").val());
    });

    $("#Status").val(14);
    Crianca.UpdateCalendario();
    Crianca.ObterParametros();

    $("#PercentualCriancas").knob(
        {
            'min': 0,
            'max': 100,
            'width':50,
            'height': 50,
            'stopper' : false
        });

    $("#ValidarCrianca").click(function ()
    {

        if ($("#DataNascimento").val() === '')
        {
            Mensagens.Erro('Não é possivel validar, preencha a Data de Nascimento.', 'Problemas na Validação');
            return false;
        }

        if ($("#Sexo").val() === '')
        {
            Mensagens.Erro('Não é possivel validar, preencha o Campo Sexo.', 'Problemas na Validação');
            return false;
        }

        var validaCrianca = new Object;
        validaCrianca.dataNasc = $("#DataNascimento").val();
        validaCrianca.sexo = $("#Sexo").val();
        validaCrianca.cadastroNovo = $("#Codigo").val() === '0' ? true : false;
        validaCrianca.necessidadeEspecial = $("#NecessidadeEspecial").prop('checked');
        validaCrianca.criancaGrande = $("#CriancaGrande").prop('checked');

        Crianca.ValidaCrianca(validaCrianca);

    });

    $("#Gravar").click(function ()
    {
        if (Crianca.Consistir() === false)
        {
            return false;
        }
        if (Crianca.VerificarCalcado())
        {
            Crianca.Gravar();
        }
    });

    $("#Limpa").click(function ()
    {
        $("#Calcado").val('99');
        $("#Roupa").val('99');
    });

    $("#UsaPadraoCalcado").click(function ()
    {
        if ($("#CalcadoPadrao").val() !== '')
        {
            $("#Calcado").val($("#CalcadoPadrao").val());
        }
    });

    $("#UsaPadraoRoupa").click(function ()
    {
        if ($("#RoupaPadrao").val() !== '')
        {
            $("#Roupa").val($("#RoupaPadrao").val());
        }
    });

    $("#Novo").click(function ()
    {
        if (($("#Familia").val() === null) || ($("#CodigoFamilia").val() === 0))
        {
            Mensagens.Erro('Selecione a Família', 'Erro');
            return false;
        }
        Crianca.LimparForm();
        $("#modalEdicao").modal('show');
    });

});

Crianca.ObterParametros = function ()
{
    var opcoes = new Object;
    opcoes.url = Crianca.URLObterParametro;

    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        Crianca.NumeroMaximoCricancas = dataObj.NumeroMaximoCricancas;
        Crianca.CalcadoLimite = dataObj.NumeroMaximoCricancas;
    }

    Ajax.Get(opcoes);

}

Crianca.UpdateCalendario = function ()
{

    $("#DataNascimento").datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        calendarWeeks: true,
        autoclose: true
    });

    var dataValue = moment().format("DD/MM/YYYY");

    $("#DataNascimento").datepicker('setDate', dataValue);
    $("#DataNascimento").datepicker('update');
    $("#DataNascimento").val('');

}

Crianca.LimparForm = function ()
{
    $("#Codigo").val('0');
    $("#Nome").val('');
    $("#Idade").val('');
    $("#MedidaIdade").val('');
    $("#IdadeNominal").val('');
    $("#IdadeNominalReduzida").val('');
    $("#Kit").val(0);
    $("#Status").val(14);
    $("#TipoParentesco").val(0);
    $("#Calcado").val('99');
    $("#Roupa").val('99');
    $("#CalcadoPadrao").val('99');
    $("#RoupaPadrao").val('99');
    $("#DataNascimento").val('');
    $("#DataCriacao").val('');
    $("#DataAtualizacao").val('');

    $("#CriancaGrande").prop('checked', '');
    $("#NecessidadeEspecial").prop('checked', '');
    $("#Consistente").prop('checked', '');
    $("#Sacolinha").prop('checked', '');
    $("#MoralCrista").prop('checked', '');
    $("#DocumentoOk").prop('checked', '');

}

Crianca.Pesquisar = function ()
{
    if (($("#Familia").val() === '') || ($("#Familia").val() === '0'))
    {
        Mensagens.Erro("Familia não preenchida", "Erro na Pesquisa");
        return false;
    }

    location.href = '/Crianca/' + $("#Familia").val();
}

Crianca.ValidaCrianca = function (validaCrianca)
{
    var opcoes = new Object;
    opcoes.url = '/Crianca/ValidaCrianca';

    if (validaCrianca.obterSoVestimenta === undefined)
    {
        validaCrianca.obterSoVestimenta = false;
    }


    if ($("#Sexo").val() === '')
    {
        Mensagens.Erro('Preencher o campo Sexo');
        $("#Sexo").focus();
    }
    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);

        $("#Kit").val(dataObj.Kit.Codigo);
        $("#Idade").val(dataObj.Idade);
        $("#MedidaIdade").val(dataObj.MedidaIdade);
        $("#IdadeNominal").val(dataObj.IdadeNominal);
        $("#IdadeNominalReduzida").val(dataObj.IdadeNominalReduzida);

        validaCrianca.idade = dataObj.Idade;
        validaCrianca.medidaIdade = dataObj.MedidaIdade;

        Crianca.ObterVestimentaPadrao(validaCrianca);
    }

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.DataNascimento = moment(validaCrianca.dataNasc, "DD/MM/YYYY").format("MM/DD/YYYY");
    opcoes.dadoEnvio.Sexo = validaCrianca.sexo;
    opcoes.dadoEnvio.CadastroNovo = validaCrianca.cadastroNovo;
    opcoes.dadoEnvio.CriancaGrande = validaCrianca.criancaGrande;
    opcoes.dadoEnvio.NescessidadeEspecial = validaCrianca.necessidadeEspecial;

    Ajax.Get(opcoes);

}

Crianca.ObterVestimentaPadrao = function (validaCrianca)
{
    var opcoes = new Object;
    opcoes.url = '/Crianca/ObterVestimentaPadrao';

    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        $("#CalcadoPadrao").val(dataObj.calcado);
        $("#RoupaPadrao").val(dataObj.roupa);
    }

    //ObterVestimentaPadrao(int idade, string medidaIdade, string sexo, bool isCriancaGrande = false)

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.idade = validaCrianca.idade;
    opcoes.dadoEnvio.medidaIdade = validaCrianca.medidaIdade;
    opcoes.dadoEnvio.sexo = validaCrianca.sexo;
    opcoes.dadoEnvio.isCriancaGrande = validaCrianca.criancaGrande;

    Ajax.Get(opcoes);
}

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

    Crianca.Excluir($("#codigoExclusao").val());
}

Crianca.Consistir = function ()
{
    var mensagem = '';
    if ($("#Nome").val() === '')
    {
        mensagem = mensagem + 'Preencher o Campo Nome <br />';
    }

    if ($("#TipoParentesco").val() === '0')
    {
        mensagem = mensagem + 'Preencher o Campo Tipo de Parentesco <br />';
    }

    if ($("#DataNascimento").val() === '')
    {
        mensagem = mensagem + 'Preencher o Campo Data de Nascimento <br />';
    }

    if ($("#Calcado").val() === '')
    {
        mensagem = mensagem + 'Preencher o Campo Calcado <br />';
    }

    if ($("#Roupa").val() === '')
    {
        mensagem = mensagem + 'Preencher o Campo Roupa <br />';
    }

    if (mensagem !== '')
    {
        Mensagens.Erro(mensagem, 'Problemas no Formulário.');
        return false;
    }
    return true;
}

Crianca.Editar = function (id)
{
    var opcoes = new Object;
    opcoes.url = '/Crianca/Edit';
    Crianca.LimparForm();
    $("#modalEdicao").modal('show');

    opcoes.callBackSuccess = function (response)
    {
        var dataObj = eval(response);
        var dataValueAlt = '';
        var dataValueInc = '';
        var dataNascimento = '';

        if (dataObj.DataNascimento !== null)
        {
            dataNascimento = moment(dataObj.DataNascimento.toString()).format("DD/MM/YYYY");
        }

        if (dataObj.DataAtualizacao !== null)
        {
            dataValueAlt = moment(dataObj.DataAtualizacao.toString()).format("DD/MM/YYYY");
        }

        if (dataObj.DataCriacao !== null)
        {
            dataValueInc = moment(dataObj.DataCriacao.toString()).format("DD/MM/YYYY");
        }

        $("#Codigo").val(dataObj.Codigo);
        $("#Nome").val(dataObj.Nome);
        $("#TipoParentesco").val(dataObj.TipoParentesco.Codigo);

        $("#DataAtualizacao").val(dataValueAlt);
        $("#DataCriacao").val(dataValueInc);

        $("#DataNascimento").val(dataNascimento);
        $("#Sexo").val(dataObj.Sexo);

        if (dataObj.NecessidadeEspecial)
        {
            $("#NecessidadeEspecial").prop('checked', 'checked');
        }
        if (dataObj.CriancaGrande)
        {
            $("#CriancaGrande").prop('checked', 'checked');
        }

        $("#Status").val(dataObj.Status.Codigo);
        $("#Status").prop('disabled', 'disabled');

        $("#Kit").val(dataObj.Kit.Codigo);
        $("#Idade").val(dataObj.Idade);
        $("#MedidaIdade").val(dataObj.MedidaIdade);
        $("#IdadeNominal").val(dataObj.IdadeNominal);
        $("#IdadeNominalReduzida").val(dataObj.IdadeNominalReduzida);
        $("#Calcado").val(dataObj.Calcado);
        $("#Roupa").val(dataObj.Roupa);

        if (dataObj.Consistente)
        {
            $("#ConsistenteEdit").prop('checked', 'checked');
        }

        if (dataObj.Sacolinha)
        {
            $("#SacolinhaEdit").prop('checked', 'checked');
        }

        if (dataObj.DocumentoOk)
        {
            $("#DocumentoOk").prop('checked', 'checked');
        }

        if (dataObj.MoralCrista)
        {
            $("#MoralCristaEdit").prop('checked', 'checked');
        }

        //obter apenas calçado e roupa padrão
        var validaCrianca = new Object;
        validaCrianca.sexo = $("#Sexo").val();
        validaCrianca.idade = $("#Idade").val();
        validaCrianca.medidaIdade = $("#MedidaIdade").val();
        validaCrianca.criancaGrande = dataObj.CriancaGrande;

        Crianca.ObterVestimentaPadrao(validaCrianca);

        $("#modalEdicao").modal('show');

    }

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.id = id;

    Ajax.Get(opcoes);
}

Crianca.Gravar = function ()
{
    var token = $('input[name="__RequestVerificationToken"]').val();
    var opcional = $("#Opcional").prop('checked');

    var opcoes = new Object;
    opcoes.url = Crianca.URLGravar;
    opcoes.headers = {};
    opcoes.headers['__RequestVerificationToken'] = token;
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
            Crianca.LimparForm();
            $("#modalEdicao").modal('hide');
            setTimeout(function ()
            {
                location.reload();
            }, 1500);
        }
    };

    opcoes.url = '/Crianca/Gravar';

    opcoes.dadoEnvio = new Object;
    opcoes.dadoEnvio.Codigo = $("#Codigo").val();
    opcoes.dadoEnvio.Nome = $("#Nome").val();
    opcoes.dadoEnvio.Familia = {};
    opcoes.dadoEnvio.Familia.Codigo = $("#Familia").val();
    opcoes.dadoEnvio.Idade = $("#Idade").val();
    opcoes.dadoEnvio.MedidaIdade = $("#MedidaIdade").val();
    opcoes.dadoEnvio.IdadeNominal = $("#IdadeNominal").val();
    opcoes.dadoEnvio.IdadeNominalReduzida = $("#IdadeNominalReduzida").val();
    opcoes.dadoEnvio.TipoParentesco = {};
    opcoes.dadoEnvio.TipoParentesco.Codigo = $("#TipoParentesco").val();
    opcoes.dadoEnvio.Kit = {};
    opcoes.dadoEnvio.Kit.Codigo = $("#Kit").val();
    opcoes.dadoEnvio.Status = {};
    opcoes.dadoEnvio.Status.Codigo = $("#Status").val();
    opcoes.dadoEnvio.Calcado = $("#Calcado").val();
    opcoes.dadoEnvio.Roupa = $("#Roupa").val();
    opcoes.dadoEnvio.Sexo = $("#Sexo").val();
    opcoes.dadoEnvio.DataNascimento = $("#DataNascimento").val();

    opcoes.dadoEnvio.CriancaGrande = $("#CriancaGrande").prop('checked');
    opcoes.dadoEnvio.NecessidadeEspecial = $("#NecessidadeEspecialEdit").prop('checked');
    opcoes.dadoEnvio.Consistente = $("#ConsistenteEdit").prop('checked');
    opcoes.dadoEnvio.Sacolinha = $("#SacolinhaEdit").prop('checked');
    opcoes.dadoEnvio.MoralCrista = $("#MoralCristaEdit").prop('checked');
    opcoes.dadoEnvio.DocumentoOk = $("#DocumentoOk").prop('checked');

    Ajax.Execute(opcoes);
}

Crianca.Acertar = function ()
{
    $("#Calcado").val($("#CalcadoPadrao").val());
    $("#Roupa").val($("#RoupaPadrao").val());
    Crianca.Gravar();
}

Crianca.MontarTabela = function ()
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
            { "aTargets": [0], "bSortable": true },
            { "aTargets": [1], "bSortable": true },
            { "aTargets": [2], "bSortable": false },
            { "aTargets": [3], "bSortable": false },
            { "aTargets": [4], "bSortable": false },
            { "aTargets": [5], "bSortable": false },
            { "aTargets": [6], "bSortable": false },
            { "aTargets": [7], "bSortable": false },
            { "aTargets": [8], "bSortable": false },
            { "aTargets": [9], "bSortable": false }
        ]
    });
}

Crianca.VerificarCalcado = function ()
{
    var idade = parseInt($("#Idade").val());
    var calcado = parseInt($("#Calcado").val());
    var calcadoPadrao = parseInt($("#CalcadoPadrao").val());
    var erroCalcadoGrande = 'Não é permitido que escolha um número muito grande de calçado.\n';
    erroCalcadoGrande = erroCalcadoGrande + 'O limite é de ' + Crianca.CalcadoLimite.toString() + ' números.\n';
    erroCalcadoGrande = erroCalcadoGrande + 'Favor Verificar.';
    var moralCrista = $("#MoralCrista").prop('checked');

    //Temp para Crianças MAIORES e Moral Cristã
    //Para ficar OK, deve ser acertado a tabela de calçados
    if ((calcadoPadrao === '99') || (calcadoPadrao === 99))
    {
        if ((moralCrista) && idade > 10)
        {
            return true;
        }
    }

    if (calcado === calcadoPadrao)
    {
        return true;
    }

    if ((calcado === '99') || (calcado === 99))
    {
        return true;
    }

    if (Math.abs(calcado - calcadoPadrao) > Crianca.CalcadoLimite)
    {
        //Erro - Calçado Muito Grande
        Mensagens.Erro(erroCalcadoGrande, 'Inconsistencias no preenchimento');
        return false;
    }
    else
    {
        // aviso, para confirmar.
        Crianca.ShowAviso();
        return false;
    }
}

Crianca.ShowAviso = function ()
{
    $("#modalMensagem").modal();
}

Crianca.Excluir = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Crianca.URLExcluir;

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

Crianca.ProcessarCrianca = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Crianca.URLProcessarCrianca;

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

Crianca.ProcessarPresenca = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Crianca.URLProcessarPresenca;

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

Crianca.ProcessarCriancas = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Crianca.URLProcessarCriancas;

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

Crianca.ProcessarFamilia = function (codigo)
{
    var opcoes = new Object;
    opcoes.url = Crianca.URLProcessarFamilia;

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

