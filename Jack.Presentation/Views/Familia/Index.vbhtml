@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/SharedFolder/_JackLayoutPage.vbhtml
End Code
<script src="~/engine/familia.js"></script>
<div ng-controller="ngFamiliaController">
    <div class="Titulo">Família</div><br /><br />
    <div class="SubTitulo">Lista</div>
    <table class="table table-striped" style="width:1024px">
        <thead>
            <tr class="">
                <td style="width:60px;">Cód.</td>
                <td style="width:364px;">Nome da Mãe</td>
                <td style="width:180px;">Contato</td>
                <td style="width:40px;">Nivel</td>
                <td style="width:40px;text-align:center;"><img style="vertical-align:middle;" alt="Sacolinha?" title="Sacolinha?" width="24" height="24" src="Imagens/bag.png" /></td>
                <td style="width:40px;text-align:center;"><img style="vertical-align:middle;" alt="Dados OK?" title="Dados OK?" width="24" height="24" src="Imagens/ok.png" /></td>
                <td style="width:220px;">Status</td>
                <td style="width:40px;"><img style="vertical-align:middle;" alt="" title="" src="Imagens/editar.png" /></td>
                <td style="width:40px;"><img style="vertical-align:middle;" alt="" title="" src="Imagens/excluir.png" /></td>
            </tr>
        </thead>
    </table>
    <div id="divDadosGrid" style="width:980px; height:418px;overflow-y:auto;">
        <table class="table table-striped" style="width:1000px">
            <tbody id="tBodyDados" class="filterable">
                <tr class="" ng-repeat="item in itens">
                    <td style="width:60px;">{{item.Codigo}}</td>
                    <td style="width:340px;">{{item.Familia}}</td>
                    <td style="width:180px;">{{item.Contato}}</td>
                    <td style="width:40px;">Nivel{{item.Nivel}}</td>
                    <td style="width:40px;text-align:center;">
                        <div ng-switch on="item.IsSacolinha">
                            <div ng-switch-when="S"><img style="vertical-align:middle;" alt="Sim Sacolinha" title="Sim Sacolinha" width="24" height="24" src="Imagens/ok.png" /></div>
                            <div ng-switch-when="N"><img style="vertical-align:middle;" alt="Não Sacolinha" title="Não Sacolinha" width="24" height="24" src="Imagens/no.png" /></div>
                        </div>
                    </td>
                    <td style="width:40px;text-align:center;">
                        <div ng-switch on="item.IsConsistente">
                            <div ng-switch-when="S"><img style="vertical-align:middle;" alt="Dados OK" title="Dados OK" width="24" height="24" src="Imagens/ok.png" /></div>
                            <div ng-switch-when="N"><img style="vertical-align:middle;" alt="Dados Não OK" title="Dados Não OK" width="24" height="24" src="Imagens/no.png" /></div>
                        </div>
                    </td>
                    <td style="width:220px;">{{item.StatusNome}}</td>
                    <td style="width:40px;"><button class="btn btn-primary" ng-click="Edit(item)"><img style="vertical-align:middle;" alt="" title="" src="Imagens/editar.png" /></button></</td>
                    <td style="width:40px;"><button class="btn btn-primary" ng-click="Delete(item)"><img style="vertical-align:middle;" alt="" title="" src="Imagens/excluir.png" /></button></td>
                </tr>
            </tbody>
        </table>
    </div>
    <br /><br />
    <div id="divForm" class="container-form">
        <div class="SubTitulo">Edição de Dados</div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelNome" for="txtNome">Nome</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;"><input type="text" value="" class="form-control" style="width:400px;" maxlength="100" id="txtNome" placeholder="Nome" /></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelEmpresa" for="txtEmpresa">Empresa</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;"><input type="text" value="" class="form-control" style="width:400px;" maxlength="100" id="txtEmpresa" placeholder="Empresa" /></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelRamoAtividade" for="txtRamoAtividade">Ramo de Atividade</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;"><input type="text" value="" class="form-control" style="width:400px;" maxlength="100" id="txtRamoAtividade" placeholder="NomeRamo de Atividade" /></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelEMail" for="txtEMail">E-Mail</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;"><input type="email" value="" class="form-control" style="width:400px;" maxlength="100" id="txtEMail" placeholder="Email" /></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelTelefone" for="txtTelefone">Telefone</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;">
                <input type="text" value="" class="form-control" style="width:70px; display:table-cell;" maxlength="3" id="txtDDDTel" placeholder="DDD" />&nbsp;
                <input type="text" value="" class="form-control" style="width:150px; display:table-cell" maxlength="10" id="txtTelefone" placeholder="Telefone" />
            </div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelCelular" for="txtCelular">Celular</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;">
                <input type="text" value="" class="form-control" style="width:70px; display:table-cell;" size="2" maxlength="3" id="txtDDDCel" placeholder="DDD" />&nbsp;
                <input type="text" value="" class="form-control" style="width:150px; display:table-cell;" maxlength="10" id="txtCelular" placeholder="Celular" />
            </div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row; height:150px;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelMensagem" for="txtMensagem">Mensagem</label></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;"><textarea class="form-control" style="width:400px; height:120px;" id="txtMensagem" placeholder="Mensagem"></textarea></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;">&nbsp;</div>
        <div style="display:table-row;" class="form-group">
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-left" style="text-align:right;"><button id="btnGravar" type="button" class="btn btn-success btn-lg">Gravar</button></div>
            <div style="width:10px;">&nbsp;</div>
            <div class="col-form-right" style="text-align:left;"><button id="btnCancelar"type="button" class="btn btn-danger btn-lg">Cancelar</button></div>
            <div style="width:10px;">&nbsp;</div>
        </div>
        <div style="display:table-row;">&nbsp;</div>
    </div>
</div>

