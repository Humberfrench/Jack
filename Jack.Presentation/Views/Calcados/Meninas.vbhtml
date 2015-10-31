@ModelType List(Of Jack.Model.Calcado)
@Code
    ViewData("Title") = "Meninas"
    Layout = "~/Views/SharedFolder/_JackLayoutPage.vbhtml"
End Code
<h2 class="Titulo">Calçados - Meninos</h2>
<br />
<div style="width:980px; margin: 0 auto;">
    <div class="dropdown">
        <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
            Filtro
            <span class="caret"></span>
        </button>
        <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
            <li>@Html.ActionLink("Meninos", "Meninos", "Calcados")</li>
            <li>@Html.ActionLink("Todos", "Index", "Calcados")</li>
        </ul>
    </div>
</div>
<table class="table" style="width:980px; margin: 0 auto;">
    <tr class="label-primary table-row">
        <td style="width:350px">Sexo</td>
        <td style="width:150px">Numero</td>
        <td style="width:150px">Idade Inicial</td>
        <td style="width:150px">Idade Final</td>
        <td style="width:180px">&nbsp;</td>
    </tr>
</table>
<div id="divDadosGrid" style="width:980px;  margin: 0 auto;height:368px;overflow-y:auto;">
    <table class="table table-striped" style="width: 960px;">
        @For Each item In Model
            @<tr>
                <td style="width:350px">
                    @Html.Raw(item.SexoDescricao)
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
