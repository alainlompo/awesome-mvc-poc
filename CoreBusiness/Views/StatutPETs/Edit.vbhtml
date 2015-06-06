@ModelType CoreBusiness.StatutPET

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>StatutPET</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DescriptionStatut)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DescriptionStatut)
            @Html.ValidationMessageFor(Function(model) model.DescriptionStatut)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Couleur)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Couleur)
            @Html.ValidationMessageFor(Function(model) model.Couleur)
        </div>

        @Html.HiddenFor(Function(model) model.ID)

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
