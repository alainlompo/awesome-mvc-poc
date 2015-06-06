@ModelType CoreBusiness.Etape

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
