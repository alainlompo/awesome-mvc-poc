@ModelType CoreBusiness.Utilisateur

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Utilisateur</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Login)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Login)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Password)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Password)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Nom)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Nom)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Prenom)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Prenom)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.TypeAccess)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.TypeAccess)
    </div>
</fieldset>
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
