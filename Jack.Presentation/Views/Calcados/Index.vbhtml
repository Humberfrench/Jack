@ModelType IEnumerable(Of Jack.Model.Calcado)
@Code
    ViewData("Title") = "Calçados"
    Layout = "~/Views/SharedFolder/_JackLayoutPage.vbhtml"
End Code

<h2 class="Titulo">Calçados</h2>
<br /><br />
<table class="table" style="width:980px; margin: 0 auto;">
    <tr class="label-primary table-row">
        <td style="width:300px">Sexo</td>
        <td style="width:100px">Idade Inicial</td>
        <td style="width:100px">Idade Final</td>
        <td style="width:100px">Medida</td>
        <td style="width:100px">Numero</td>
        <td style="width:100px">Numero Inicio</td>
        <td style="width:100px">Numero Fim</td>
        <td style="width:80px">&nbsp;</td>
    </tr>
</table>
<div id="divDadosGrid" style="width:980px;  margin: 0 auto;height:418px;overflow-y:auto;">
    <table class="table table-striped" style="width: 960px;">
        @For Each item In Model
        @<tr>
             <td style="width:300px">
                 @code
                     If item.Sexo = "M" Then
                        @Html.Display("Masculino")
                     Else
                        @Html.Display("Feminino")
                     End If
                End code

             </td>
    <td style="width:100px">
        @Html.DisplayFor(Function(modelItem) item.IdadeInicial)
    </td>
    <td style="width:100px">
        @Html.DisplayFor(Function(modelItem) item.IdadeFinal)
    </td>
    <td style="width:100px">
        @Html.DisplayFor(Function(modelItem) item.MedidaIdade)
    </td>
    <td style="width:100px">
        @Html.DisplayFor(Function(modelItem) item.Numero)
    </td>
    <td style="width:100px">
        @Html.DisplayFor(Function(modelItem) item.NumeroInicio)
    </td>
    <td style="width:100px">
        @Html.DisplayFor(Function(modelItem) item.NumeroFim)
    </td>
    <td>&nbsp;</td>
</tr>
        Next
    </table>
</div>