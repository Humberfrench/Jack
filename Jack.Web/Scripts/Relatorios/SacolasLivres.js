var SacolasLivres = new Object;

$(function ()
{
    $("#Ano").select2({
        minimumResultsForSearch: Infinity,
        theme: "classic"
    });
    $("#Liberado").select2({
        minimumResultsForSearch: Infinity,
        theme: "classic"
    });
    $("#Kit").select2({
        minimumResultsForSearch: Infinity,
        theme: "classic"
    });
    $("#Nivel").select2({
        minimumResultsForSearch: Infinity,
        theme: "classic"
    });

    $("#Pesquisar").click(function ()
    {
        var ano;
        var liberado = 1;
        var kit = 0;
        var nivel = 0;

        if (($("#Ano").val() === 0) || ($("#Ano").val() === undefined))
        {
            Mensagens.Erro('Preencher Campo do Ano!', 'Inconsistencia');
            $("#Ano").focus();
            return;
        }
        ano = $("#Ano").val();

        if (($("#Liberado").val() === 0) || ($("#Liberado").val() === undefined))
        {
            if ($("#Liberado").val() === 2)
            {
                liberado = 0;
            }
        }

        if (($("#Kit").val() === 0) || ($("#Kit").val() === undefined))
        {
            kit = $("#Kit").val();
        }

        if (($("#Nivel").val() === 0) || ($("#Nivel").val() === undefined))
        {
            nivel = $("#Nivel").val();
        }

        window.open('/Relatorios/SacolasLivres/' + ano + '/Liberado/' + liberado + '/Nivel/' + nivel + '/Kit/' + kit, '_new');

    });

});