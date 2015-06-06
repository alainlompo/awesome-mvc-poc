@ModelType CoreBusiness.TacheDeReference

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>TacheDeReference</legend>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
