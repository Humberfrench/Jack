@ModelType IEnumerable(Of Jack.Model.Calcado)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/SharedFolder/_JackLayoutPage.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Codigo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Numero)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Sexo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NumeroInicio)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NumeroFim)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MedidaIdade)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IdadeInicial)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IdadeFinal)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SexoDescricao)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Codigo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Numero)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Sexo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NumeroInicio)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NumeroFim)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MedidaIdade)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IdadeInicial)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IdadeFinal)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SexoDescricao)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
