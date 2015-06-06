@ModelType CoreBusiness.Projet

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Projet</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DescriptionProjet)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DescriptionProjet)
            @Html.ValidationMessageFor(Function(model) model.DescriptionProjet)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateDebutPrevue)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateDebutPrevue)
            @Html.ValidationMessageFor(Function(model) model.DateDebutPrevue)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateDebutReelle)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateDebutReelle)
            @Html.ValidationMessageFor(Function(model) model.DateDebutReelle)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateFinPrevue)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateFinPrevue)
            @Html.ValidationMessageFor(Function(model) model.DateFinPrevue)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.DateFinReelle)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.DateFinReelle)
            @Html.ValidationMessageFor(Function(model) model.DateFinReelle)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.CommentaireProjet)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.CommentaireProjet)
            @Html.ValidationMessageFor(Function(model) model.CommentaireProjet)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Budget)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Budget)
            @Html.ValidationMessageFor(Function(model) model.Budget)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.BudgetReel)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.BudgetReel)
            @Html.ValidationMessageFor(Function(model) model.BudgetReel)
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
