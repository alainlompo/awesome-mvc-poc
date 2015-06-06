@ModelType CoreBusiness.RegisterModel
@Code
    ViewData("Title") = "S'inscrire"
End Code

<hgroup class="title">
    <h1>@ViewData("Title").</h1>
    <h2>Créez un nouveau compte.</h2>
</hgroup>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary()

    @<fieldset>
        <legend>Formulaire d'inscription</legend>
        <ol>
            <li>
                @Html.LabelFor(Function(m) m.UserName)
                @Html.TextBoxFor(Function(m) m.UserName)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.Password)
                @Html.PasswordFor(Function(m) m.Password)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.ConfirmPassword)
                @Html.PasswordFor(Function(m) m.ConfirmPassword)
            </li>
        </ol>
        <input type="submit" value="S'inscrire" />
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
