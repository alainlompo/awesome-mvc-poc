@ModelType CoreBusiness.Utilisateur

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
