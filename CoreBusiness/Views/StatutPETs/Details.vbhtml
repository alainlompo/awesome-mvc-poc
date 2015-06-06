@ModelType CoreBusiness.StatutPET

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
