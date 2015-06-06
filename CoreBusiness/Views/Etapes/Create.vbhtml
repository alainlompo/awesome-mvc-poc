@ModelType CoreBusiness.Etape

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

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

         <div class="editor-label">
            @Html.LabelFor(Function(model) model.ResponsableEntite)
        </div>
        <div class="editor-field">
            @Html.Awe().AjaxDropdownFor(Function(model) model.ResponsableEntite).Url(Url.Action("GetUsers","Utilisateurs"))
              @Html.ValidationMessageFor(Function(model) model.ResponsableEntite)
            
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
