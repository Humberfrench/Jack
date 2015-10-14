﻿<!DOCTYPE html>
<html ng-app="CECAMApp">
<head>
    <meta name="viewport" content="width=device-width" />
    <title>@ViewData("Title")</title>
    <link href="/Content/Jack.css" rel="stylesheet" />
    <link href="/Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/toastr.min.css" rel="stylesheet" />
    <link href="/content/awesomplete.css" rel="stylesheet" />
    <script src="/Scripts/jquery-2.1.4.min.js"></script>
    <script src="/Scripts/angular.min.js"></script>
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/awesomplete.js" async="async"></script>
    <script type="text/javascript">
        $(document).ready(function ()
        {
            $("#divPrincipal").fadeIn('slow');
        });
    </script>
</head>
<body>
    <div id="divPrincipal" style="display:none;">
        <div id="header">
            <img src=@Url.Content("~/imagens/topo.jpg") alt="header" width="1024"  height="150" />
        </div>
        <div id="divMenu" style="width:1024px;" class="menuContent dropdown theme-dropdown clearfix">
            <div role="navigation">
                <ul class="nav nav-pills">
                    <li id="lnkCadastros" style="width:150px;text-align:center;" role="presentation" class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Cadastros <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li id="Item101"><a id="lnkCalcados" href="Calcados.aspx">Calçados</a></li>
                            <li id="Item102"><a id="lnkRoupas" href="Roupas.aspx">Roupas</a></li>
                            <li id="Item103"><a id="lnkColaborador" href="#.aspx">Colaborador</a></li>
                            <li id="Item104"><a id="lnkKits" href="Kit.aspx">Kits</a></li>
                            <li id="Item105"><a id="lnkKitsItem" href="KitItem.aspx">Item dos Kits</a></li>
                            <li id="Item106"><a id="lnkColocation" href="TipoItem.aspx">Tipo de Item</a></li>
                            <li id="Item107"><a id="lnkDatasReuniao" href="DatasReuniao.aspx">Datas de Reunião</a></li>
                        </ul>
                    </li>
                    <li id="lnkSacolas" style="width:150px;text-align:center;" role="presentation" class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Sacolas <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li id="Item201"><a id="lnkFamilia" href="Familia.aspx">Familia</a></li>
                            <li id="Item202"><a id="lnkFamiliaLote" href="FamiliaLote.aspx">Familia - Lote</a></li>
                            <li id="Item203"><a id="lnkCriancas" href="Criancas.aspx">Crianças</a></li>
                            <li id="Item204"><a id="lnkCriancasUpdate" href="AlteraDadosCrianca.aspx">Alterar Dados Crianças</a></li>
                            <li id="Item205"><a id="lnkCopyCriancas" href="CopyCriancas.aspx"> Transferir Crianças</a></li>
                            <li id="Item206"><a id="lnkCadPresenca" href="CadastroPresenca.aspx">Cadastro de Presença</a></li>
                            <li id="Item207"><a id="lnkSacolasColaborador" href="SacolinaColaboradorCadastro.aspx">Sacolas p/ Colaborador</a></li>
                            <li id="Item208"><a id="lnkSacolasAdd" href="SacolinaAdd.aspx">Adicionar Sacolas</a></li>
                            <li id="Item209"><a id="lnkRepresentantes" href="Representantes.aspx">Representantes</a></li>
                        </ul>
                    </li>
                    <li id="lnkConsultas" style="width:150px;text-align:center;" role="presentation" class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Consulta <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li id="Item211"><a id="lnkCriancasConsulta" href="CriancasConsulta.aspx">Consulta Crianças</a></li>
                            <li id="Item212"><a id="lnkCriancasFamilia" href="CriancasFamilia.aspx">Crianças Por Familia</a></li>
                            <li id="Item213"><a id="lnkCriancasFamiliaRep" href="CriancasFamiliaRep.aspx">Crianças Por Familia/Representante</a></li>
                            <li id="Item214"><a id="lnkSacolasdoLivres" href="SacolasLivres.aspx">Sacolas Livres</a></li>
                            <li id="Item215"><a id="lnkSacolasdoColaborador" href="SacolaColaboradorView.aspx">Sacolas do Colaborador</a></li>
                            <li id="Item216"><a id="lnkQtdeSacolasdoColaborador" href="SacolaColaboradorQtdeView.aspx">Qtde. Sacolas do Colaborador</a></li>
                            <li id="Item217"><a id="lnkPresencaPorReuniao" href="PresencaPorReuniao.aspx">Presença Por Reunião</a></li>
                            <li id="Item218"><a id="lnkPresencaPorReuniaoMae" href="PresencaMae.aspx">Presença de Mães</a></li>
                        </ul>
                    </li>
                    <li id="lnkProcessos" style="width:150px;text-align:center;" role="presentation" class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Processos <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li id="Item301" class="Item"><a id="lnkProcessa" href="ProcessaSacola.aspx">Procesar e Gerar Sacolinhas</a></li>
                            <li id="Item302" class="Item"><a id="lnkPrint" href="PrintSacolas.aspx">Imprimir Sacolinhas</a></li>
                            <li id="Item303" class="Item"><a id="lnkPresença" href="ProcessaPresenca.aspx">Presenças de Representante</a></li>
                            <li id="Item304" class="Item"><a id="lnkAnaliseMaes" href="AnaliseProcesso.aspx">Processar Atualizações</a></li>
                            <li id="Item305" class="Item"><a id="lnkNotificaColaborador" href="AnaliseProcesso.aspx">Notifica Colaborador</a></li>
                        </ul>
                    </li>
                    <li id="lnkRelatorios" style="width:150px;text-align:center;" role="presentation" class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Relatorios <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li id="Item501" class="Item"><a id="lnkListaSacolas" href="RelSacolas.aspx">Lista de Sacolinhas</a></li>
                            <li id="Item502" class="Item"><a id="lnkEstatisticasSacolas" href="#.aspx">Estatística de Sacolas</a></li>
                            <li id="Item503" class="Item"><a id="lnkPresenca" href="RelatorioPresenca.aspx">Relatório de Presença</a></li>
                            <li id="Item504" class="Item"><a id="lnkChamada" href="ListaChamada.aspx">Lista de Chamada</a></li>
                            <li id="Item505" class="Item"><a id="lnkInconsistencia1" href="InconsistenciaFamilia.aspx">Inconsistências Famílias</a></li>
                            <li id="Item506" class="Item"><a id="lnkInconsistencia2" href="InconsistenciaCrianca.aspx">Inconsistências Crianças</a></li>
                            <li id="Item507" class="Item"><a id="lnkInconsistencia3" href="FamiliaSemCrianca.aspx">Famílias Sem Crianças</a></li>
                            <li id="Item508" class="Item" style="display:none;"><a id="#2" href="#">A Definir</a></li>
                            <li id="Item509" class="Item" style="display:none;"><a id="#3" href="#">A Definir</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
        <div id="divCorpoPagina" class="corpoPagina">
            @RenderBody()
        </div>
        <div id="rodape" class="rodape-bar">
            &nbsp;
        </div>
    </div>
</body>
</html>