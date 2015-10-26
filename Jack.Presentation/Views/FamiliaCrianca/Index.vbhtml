@Code
    ViewData("Title") = "Criancas por Famílias"
    Layout = "~/Views/SharedFolder/_JackLayoutPage.vbhtml"
End Code
@System.Web.Optimization.Scripts.Render("~/bundles/familia")
@System.Web.Optimization.Scripts.Render("~/bundles/status")
<div ng-controller="ngCriancasFamiliaController">
    <div class="Titulo">Criancas por Famílias</div><br /><br />
    <div class="SubTitulo">Lista</div>
    <div id="divForm" class="container-form">
        <div class="SubTitulo">Edição de Dados</div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelNivel" for="ddlNivel">Nível</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;">
                <select id="ddlNivel" style="width:320px;"></select>
                <input type="text" value="" class="form-control" style="width:60px;" maxlength="100" id="txtCodigo" readonly="readonly" />
            </div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;">&nbsp;</div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="margin:0 auto; text-align:right;"><button id="btnGravar" type="button" class="btn btn-success btn-lg" ng-click="Salvar(item)">Gravar</button></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="margin:0 auto; text-align:center;"><button id="btnCancelar" type="button" class="btn btn-danger btn-lg">Cancelar</button></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;">&nbsp;</div>
    </div>


    <table class="" style="width:980px">
        <thead>
            <tr class="label-primary table-row" style="">
                <td style="width:40px;">Cód.</td>
                <td style="width:300px;">Nome da Mãe</td>
                <td style="width:160px;">Contato</td>
                <td style="width:40px;">&nbsp;</td>
                <td style="width:40px;text-align:center;"><img style="vertical-align:middle;" alt="Sacolinha?" title="Sacolinha?" width="24" height="24" src="@Url.Content("~/Imagens/bag.png")" /></td>
                <td style="width:40px;text-align:center;"><img style="vertical-align:middle;" alt="Dados OK?" title="Dados OK?" width="24" height="24" src="@Url.Content("~/Imagens/ok.png")" /></td>
                <td style="width:220px;">Status</td>
                <td style="">&nbsp;</td>
                <td style="">&nbsp;</td>
            </tr>
        </thead>
    </table>
    <div id="divDadosGrid" style="width:980px; height:418px;overflow-y:auto;">
        <table class="table table-striped" style="width: 960px;">
            <tbody id="tBodyDados" class="filterable">
                <tr class="" ng-repeat="item in itens">
                    <td style="width: 50px;">{{item._Codigo}}</td>
                    <td style="width:300px;">{{item._Familia}}</td>
                    <td style="width:170px;">{{item._Contato}}</td>
                    <td style="width:40px;">
                        <img style="vertical-align:middle;" width="24" height="24" alt="Nível" title="Nível {{item._Nivel}}" src="@Url.Content("~/Imagens/{{item._Nivel}}.png")" />
                    </td>
                    <td style="width:40px;text-align:center;">
                        <div ng-switch on="item._IsSacolinha">
                            <div ng-switch-when="S"><img style="vertical-align:middle;" alt="Sim Sacolinha" title="Sim Sacolinha" width="24" height="24" src="@Url.Content("~/Imagens/ok.png")" /></div>
                            <div ng-switch-when="N"><img style="vertical-align:middle;" alt="Não Sacolinha" title="Não Sacolinha" width="24" height="24" src="@Url.Content("~/Imagens/no.png")" /></div>
                        </div>
                    </td>
                    <td style="width:40px;text-align:center;">
                        <div ng-switch on="item._IsConsistente">
                            <div ng-switch-when="S"><img style="vertical-align:middle;" alt="Dados OK" title="Dados OK" width="24" height="24" src="@Url.Content("~/Imagens/ok.png")" /></div>
                            <div ng-switch-when="N"><img style="vertical-align:middle;" alt="Dados Não OK" title="Dados Não OK" width="24" height="24" src="@Url.Content("~/Imagens/no.png")" /></div>
                        </div>
                    </td>
                    <td style="width:220px;">{{item._Status}}</td>
                    <td style="width:50px;text-align:center;"><button class="btn btn-default" ng-click="Edit(item)"><img style=" vertical-align:middle;" alt="" title="" src="@Url.Content("~/Imagens/editar.png")" /></button></</td>
                    <td style="width:50px;text-align:center;"><button class="btn btn-default" ng-click="Delete(item)"><img style="vertical-align:middle;" alt="" title="" src="@Url.Content("~/Imagens/excluir.png")" /></button></td>
                </tr>
            </tbody>
        </table>
    </div>
    <br /><br />
</div>

