@ModelType IEnumerable(Of CoreBusiness.Projet)

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
            @Html.DisplayNameFor(Function(model) model.DescriptionProjet)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateDebutPrevue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateDebutReelle)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateFinPrevue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateFinReelle)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CommentaireProjet)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Budget)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BudgetReel)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DescriptionProjet)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DateDebutPrevue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DateDebutReelle)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DateFinPrevue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.DateFinReelle)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.CommentaireProjet)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Budget)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.BudgetReel)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.ID})
        </td>
    </tr>
Next

</table>
</br>
</br>
<h5>Projects Grid</h5>
@(Html.Awe().Grid("ProjectsGrid").Url(Url.Action("GetProjectsGrid", "Projets")).Columns(
    New Column() With {.Name = "Description projet", .ClientFormat = ".Description"},
    New Column() With {.Name = "Budget", .ClientFormat = ".Budget", .Header = "Budget"},
    New Column() With {.Name = "Date de début", .ClientFormat = ".DateDebut", .Header = "Debut"}))

<br />
<h5>Demo PopUp</h5>
<button type="button" onclick="@Url.Awe().PopupAction().Content("<b>Presentation du projet</b><br/><h3>Projet initie par FakeCompanyName pour un montant de 30000000 MAD</h3><br/><br/><p>Il convient de le developper prorement</p>")" class="awe-btn">Description du projet</button>

<br />
<br />
<br />
<h5>Ajax List Demo</h5>
@Html.Awe().AjaxList("ProjectsDescriptionList").Url(Url.Action("GetProjectsDescriptionList","Projets"))

<br />
<br />
<br />
<h5>Auto complete sur la description des projets</h5>
<h5>Autocomplete</h5>
@Html.Awe().Autocomplete("ProjectsDescriptionAuto").Url(Url.Action("GetProjectsDescriptionAuto", "Projets")).Placeholder("saisissez le début de description du projet ...")

