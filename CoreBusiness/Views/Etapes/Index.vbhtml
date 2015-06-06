@ModelType IEnumerable(Of CoreBusiness.Etape)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.DescriptionEtape)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.OrdreEtape)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateDebutPrevue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateFinPrevue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateDebutReelle)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateFinReelle)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CommentaireEtape)
        </th>

         <th>
            @Html.DisplayNameFor(Function(model) model.ResponsableEntite)
        </th>

        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DescriptionEtape)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.OrdreEtape)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DateDebutPrevue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DateFinPrevue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DateDebutReelle)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DateFinReelle)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.CommentaireEtape)
        </td>

        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.ResponsableEntite.Login)
        </td>

        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next

</table>
