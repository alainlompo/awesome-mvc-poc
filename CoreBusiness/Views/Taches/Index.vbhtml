@ModelType IEnumerable(Of CoreBusiness.Tache)

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
            @Html.DisplayNameFor(Function(model) model.NumeroEtape)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.OrdreTache)
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
            @Html.DisplayNameFor(Function(model) model.NumeroStatut)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CommentaireTache)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.NumeroEtape)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.OrdreTache)
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
            @Html.DisplayFor(Function(modelItem) currentItem.NumeroStatut)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.CommentaireTache)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next

</table>
