@ModelType CoreBusiness.StatutPET

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

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

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
