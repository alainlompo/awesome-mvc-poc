@ModelType CoreBusiness.Entite

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Entite</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.DescriptionEntite)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.DescriptionEntite)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
