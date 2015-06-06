@ModelType CoreBusiness.Etape

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Etape</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DescriptionEtape)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DescriptionEtape)
            @Html.ValidationMessageFor(Function(model) model.DescriptionEtape)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.OrdreEtape)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.OrdreEtape)
            @Html.ValidationMessageFor(Function(model) model.OrdreEtape)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateDebutPrevue)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateDebutPrevue)
            @Html.ValidationMessageFor(Function(model) model.DateDebutPrevue)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateFinPrevue)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateFinPrevue)
            @Html.ValidationMessageFor(Function(model) model.DateFinPrevue)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateDebutReelle)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateDebutReelle)
            @Html.ValidationMessageFor(Function(model) model.DateDebutReelle)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateFinReelle)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateFinReelle)
            @Html.ValidationMessageFor(Function(model) model.DateFinReelle)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.CommentaireEtape)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.CommentaireEtape)
            @Html.ValidationMessageFor(Function(model) model.CommentaireEtape)
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
