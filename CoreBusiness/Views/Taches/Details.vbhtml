@ModelType CoreBusiness.Tache

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Tache</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.NumeroEtape)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.NumeroEtape)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.OrdreTache)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.OrdreTache)
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
        @Html.DisplayNameFor(Function(model) model.NumeroStatut)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.NumeroStatut)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.CommentaireTache)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.CommentaireTache)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
