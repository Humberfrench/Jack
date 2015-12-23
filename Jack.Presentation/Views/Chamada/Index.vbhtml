@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/SharedFolder/_JackLayoutPage.vbhtml"
End Code
@System.Web.Optimization.Scripts.Render("~/bundles/Angular")
@System.Web.Optimization.Scripts.Render("~/bundles/Presenca")

<div ng-controller="ngFamiliaController">
    <div class="Titulo">Famílias</div><br /><br />
    <div class="SubTitulo">Lista</div>
    <div style="width:980px; margin: 0 auto;">
        <table class="table" style="width:640px; margin: 0 auto;">
            <tr class="label-primary table-row">
                <td style="width:150px">&nbsp;</td>
                <td style="width:450px">Nome da Mãe</td>
            </tr>
        </table>
        <div id="divDadosGrid" style="width:980px;  margin: 0 auto;height:368px;overflow-y:auto;">
            <table class="table table-striped" style="width: 600px;">
                <tr>
                    <td style="width:150px"><button type="button" class="btn btn-success" ng-click="Presenca(item)">Presente</button> </td>
                    <td style="width:450px">{{campo}}</td>
                </tr>
            </table>
        </div>
