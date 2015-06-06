@ModelType CoreBusiness.Utilisateur

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Utilisateur</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Login)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Login)
            @Html.ValidationMessageFor(Function(model) model.Login)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Password)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Password)
            @Html.ValidationMessageFor(Function(model) model.Password)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Nom)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Nom)
            @Html.ValidationMessageFor(Function(model) model.Nom)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Prenom)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Prenom)
            @Html.ValidationMessageFor(Function(model) model.Prenom)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.TypeAccess)
        </div>
        <div class="editor-field">
            @Html.Awe().AjaxDropdownFor(Function(model) model.TypeAccess).Url(Url.Action("GetTypesAccess", "TypesAccess"))
            @Html.ValidationMessageFor(Function(model) model.TypeAccess)
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
