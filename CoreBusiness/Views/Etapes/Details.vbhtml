@ModelType CoreBusiness.Etape

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Etape</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DescriptionEtape)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DescriptionEtape)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.OrdreEtape)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.OrdreEtape)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateDebutPrevue)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateDebutPrevue)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateFinPrevue)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateFinPrevue)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateDebutReelle)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateDebutReelle)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DateFinReelle)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DateFinReelle)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.CommentaireEtape)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.CommentaireEtape)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
