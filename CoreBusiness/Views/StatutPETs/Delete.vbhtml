@ModelType CoreBusiness.StatutPET

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>StatutPET</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DescriptionStatut)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DescriptionStatut)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Couleur)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Couleur)
    </div>
</fieldset>
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
