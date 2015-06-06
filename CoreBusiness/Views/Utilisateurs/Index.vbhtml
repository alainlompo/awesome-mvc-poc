@ModelType IEnumerable(Of CoreBusiness.Utilisateur)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<br /><br />
<h4>Utilisateurs depuis Db par AJaxDropDown</h4>
<hr />
@Html.Awe().AjaxDropdown("Utilisateurs")
<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Login)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Password)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nom)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Prenom)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TypeAccess)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Login)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Password)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Nom)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Prenom)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.TypeAccess)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next

</table>
