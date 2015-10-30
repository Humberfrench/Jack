@ModelType IEnumerable(Of Jack.Model.Calcado)
@Code
    ViewData("Title") = "Calçados"
    Layout = "~/Views/SharedFolder/_JackLayoutPage.vbhtml"
End Code

<h2 class="Titulo">Calçados</h2>
<br /><br />
<table class="table" style="width:980px; margin: 0 auto;">
    <tr class="label-primary table-row">
        <td style="width:350px">Sexo</td>
        <td style="width:150px">Numero</td>
        <td style="width:150px">Idade Inicial</td>
        <td style="width:150px">Idade Final</td>
        <td style="width:180px">&nbsp;</td>
    </tr>
</table>
<div id="divDadosGrid" style="width:980px;  margin: 0 auto;height:418px;overflow-y:auto;">
    <table class="table table-striped" style="width: 960px;">
        @For Each item In Model
        @<tr>
             <td style="width:350px">
                 @code
                     If item.Sexo = "M" Then
                        @Html.Raw("<spam style='color:midnightblue;'> Masculino</span>")
                     Else
                        @Html.Raw("<spam style='color:red;'> Feminino</span>")
                     End If
                End code

             </td>
             <td style="width:150px">
                 @Html.DisplayFor(Function(modelItem) item.Numero)
             </td>
    <td style="width:150px">
        @Html.DisplayFor(Function(modelItem) item.IdadeInicial)
    </td>
    <td style="width:150px">
        @Html.DisplayFor(Function(modelItem) item.IdadeFinal)
    </td>
    <td>&nbsp;</td>
</tr>
                     Next
    </table>
</div>