<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Jack.Master" CodeBehind="ModelTableForm.aspx.vb" Inherits="Jack.Presentation.ModelTableForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="engine/engine.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div ng-controller="ngAppDemoController">
<div class="Titulo">Title Form</div><br /><br />
<div class="SubTitulo">Edição de Dados</div>
<table class="table table-striped">
      <thead>
        <tr>
          <th>#</th>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Username</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row">1</th>
          <td>Mark</td>
          <td>Otto</td>
          <td>@mdo</td>
        </tr>
        <tr>
          <th scope="row">2</th>
          <td>Jacob</td>
          <td>Thornton</td>
          <td>@fat</td>
        </tr>
        <tr>
          <th scope="row">3</th>
          <td>Larry</td>
          <td>the Bird</td>
          <td>@twitter</td>
        </tr>
      </tbody>
    </table>
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
        <div class="col-form-right" style="text-align:left;"><input type="email" value="" class="form-control" style="width:400px;"  maxlength="100" id="txtEMail" placeholder="Email" /></div>
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
            <input type="text" value="" class="form-control" style="width:70px; display:table-cell;"size="2" maxlength="3" id="txtDDDCel" placeholder="DDD" />&nbsp;
            <input type="text" value="" class="form-control" style="width:150px; display:table-cell;" maxlength="10" id="txtCelular" placeholder="Celular" />
        </div>
        <div style="width:10px;">&nbsp;</div>
    </div>
    <div style="display:table-row; height:150px;" class="form-group">
        <div style="width:10px;">&nbsp;</div>
        <div class="col-form-left" style="text-align:right;"><label class="control-label" id="labelMensagem" for="txtMensagem">Mensagem</label></div>
        <div style="width:10px;">&nbsp;</div>
        <div class="col-form-right" style="text-align:left;"><textarea class="form-control" style="width:400px; height:120px;"  id="txtMensagem" placeholder="Mensagem"></textarea></div>
        <div style="width:10px;">&nbsp;</div>
    </div>
    <div style="display:table-row;">&nbsp;</div>
    <div style="display:table-row;" class="form-group">
        <div style="width:10px;">&nbsp;</div>
        <div class="col-form-left" style="text-align:right;"><button type="button" class="btn btn-success btn-lg">Enviar</button></div>
        <div style="width:10px;">&nbsp;</div>
        <div class="col-form-right" style="text-align:left;"><button type="button" class="btn btn-danger btn-lg">Limpar</button></div>
        <div style="width:10px;">&nbsp;</div>
    </div>
    <div style="display:table-row;">&nbsp;</div>
</div>
</div>
</asp:Content>
