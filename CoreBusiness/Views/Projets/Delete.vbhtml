@ModelType CoreBusiness.Projet

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Projet</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DescriptionProjet)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DescriptionProjet)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateDebutPrevue)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateDebutPrevue)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateDebutReelle)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateDebutReelle)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateFinPrevue)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateFinPrevue)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateFinReelle)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateFinReelle)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.CommentaireProjet)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.CommentaireProjet)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Budget)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Budget)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.BudgetReel)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.BudgetReel)
    </div>
</fieldset>
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
