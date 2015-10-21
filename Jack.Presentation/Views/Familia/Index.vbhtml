@Code
    ViewData("Title") = "Família"
    Layout = "~/Views/SharedFolder/_JackLayoutPage.vbhtml"
End Code
@System.Web.Optimization.Scripts.Render("~/bundles/mensagens")
@System.Web.Optimization.Scripts.Render("~/bundles/familia")
@System.Web.Optimization.Scripts.Render("~/bundles/status")
<div ng-controller="ngFamiliaController">
    <div class="Titulo">Família</div><br /><br />
    <div class="SubTitulo">Lista</div>
    <table class="table table-striped" style="width:980px">
        <thead>
            <tr class="">
                <td style="width:60px;">Cód.</td>
                <td style="width:320px;">Nome da Mãe</td>
                <td style="width:180px;">Contato</td>
                <td style="width:40px;">Nivel</td>
                <td style="width:40px;text-align:center;"><img style="vertical-align:middle;" alt="Sacolinha?" title="Sacolinha?" width="24" height="24" src="@Url.Content("~/Imagens/bag.png")" /></td>
                <td style="width:40px;text-align:center;"><img style="vertical-align:middle;" alt="Dados OK?" title="Dados OK?" width="24" height="24" src="@Url.Content("~/Imagens/ok.png")" /></td>
                <td style="width:220px;">Status</td>
                <td style="width:40px;"><img style="vertical-align:middle;" alt="" title="" src="@Url.Content("~/Imagens/editar.png")" /></td>
                <td style="width:40px;"><img style="vertical-align:middle;" alt="" title="" src="@Url.Content("~/Imagens/excluir.png")" /></td>
            </tr>
        </thead>
    </table>
    <div id="divDadosGrid" style="width:980px; height:418px;overflow-y:auto;">
        <table class="table table-striped" style="width:960px">
            <tbody id="tBodyDados" class="filterable">
                <tr class="" ng-repeat="item in itens">
                    <td style="width:60px;">{{item._Codigo}}</td>
                    <td style="width:300px;">{{item._Familia}}</td>
                    <td style="width:180px;">{{item._Contato}}</td>
                    <td style="width:40px;"><img style="vertical-align:middle;" width="24" height="24"  alt="Nível" title="Nível {{item._Nivel}}" src="@Url.Content("~/Imagens/{{item._Nivel}}.png")" /></td>
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
                    <td style="width:220px;">{{item._StatusNome}}</td>
                    <td style="width:40px;"><button class="btn btn-primary" ng-click="Edit(item)"><img style="vertical-align:middle;" alt="" title="" src="@Url.Content("~/Imagens/editar.png")" /></button></</td>
                    <td style="width:40px;"><button class="btn btn-primary" ng-click="Delete(item)"><img style="vertical-align:middle;" alt="" title="" src="@Url.Content("~/Imagens/excluir.png")" /></button></td>
                </tr>
            </tbody>
        </table>
    </div>
    <br /><br />
    <div id="divForm" class="container-form">
        <div class="SubTitulo">Edição de Dados</div> <!-- IsConsistente DataAtualizacao IsSacolinha -->
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelNome" for="txtNome">Nome</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;">
                <input type="hidden" ng-model="item._Codigo" />
                <input type="text" value="" class="form-control" style="width:400px;" maxlength="100" id="txtNome" placeholder="Nome" ng-model="item._Familia" />
            </div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelContato" for="txtEmpresa">Contato</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;"><input type="text" value="" class="form-control" style="width:400px;" maxlength="100" id="txtContato" placeholder="Contato" ng-model=""/></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelStatus" for="ddlStatus">Status</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;">
                <select id="ddlStatus" class="form-control" style="width:400px;"></select>
                <input type="hidden" id="txtStatus" ng-model="item._Status" value="{{item._Status}}" />
            </div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelNivel" for="ddlNivel">Nível</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;">
                <select id="ddlNivel" class="form-control" style="width:320px;">
                    <option value="1">Nível 1</option>
                    <option value="2">Nível 2</option>
                    <option value="3">Nível 3</option>
                    <option value="4">Nível 4</option>
                    <option value="5">Nível 5</option>
                    <option value="6">Nível 6</option>
                    <option value="99">Nível 99</option>
                </select>
                <input type="hidden" id="txtNivel" ng-model="item._Nivel" value="{{item._Nivel}}" />
                <div ng-if="item._Nivel > 0">
                    <img style="vertical-align:middle; display:none" width="24" height="24" alt="Nível" title="Nível {{item._Nivel}}" src="@Url.Content("~/Imagens/{{item._Nivel}}.png")" />
                </div>
            </div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;">&nbsp;</div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;">
                <label class="control-label" id="labelIsSacolinha" for="chkIsSacolinha">Habilitado Sacolinha?</label>
                <input type="checkbox" id="chkIsSacolinha" ng-model="item._IsSacolinha" />
                <label class="control-label" id="labelDadosOK" for="chkDadosOK">Dados Estão OK?</label>
                <input type="checkbox" id="chkDadosOK" ng-model="item._IsConsistente" />
            </div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelData" for="txtData">Ultima Atualização</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;"><input type="text" readonly="readonly" class="form-control" style="width:400px;" id="txtData" placeholder="" ng-model="item._DataAtualizacao" /></div>
            <div style="width:10px;">&nbsp;</div>
        </div>        <div style="display:table-row;">&nbsp;</div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="margin:0 auto; text-align:right;"><button id="btnGravar" type="button" class="btn btn-success btn-lg">Gravar</button></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="margin:0 auto; text-align:center;"><button id="btnCancelar" type="button" class="btn btn-danger btn-lg">Cancelar</button></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;">&nbsp;</div>
    </div>
</div>
