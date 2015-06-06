@ModelType CoreBusiness.Projet

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
