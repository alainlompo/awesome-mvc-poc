@ModelType CoreBusiness.RegisterExternalLoginModel
@Code
    ViewData("Title") = "S'inscrire"
End Code

<hgroup class="title">
    <h1>@ViewData("Title").</h1>
    <h2>Associez votre compte @ViewData("ProviderDisplayName").</h2>
</hgroup>

@Using Html.BeginForm("ExternalLoginConfirmation", "Account", New With {.ReturnUrl = ViewData("ReturnUrl")})
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(true)

    @<fieldset>
        <legend>Formulaire d’association</legend>
        <p>
            Vous êtes authentifié avec <strong>@ViewData("ProviderDisplayName")</strong>.
            Veuillez entrer un nom d’utilisateur pour le site ci-dessous, puis cliquer sur le bouton Confirmer pour terminer
            la connexion.
        </p>
        <ol>
            <li class="name">
                @Html.LabelFor(Function(m) m.UserName)
                @Html.TextBoxFor(Function(m) m.UserName)
                @Html.ValidationMessageFor(Function(m) m.UserName)
            </li>
        </ol>
        @Html.HiddenFor(Function(m) m.ExternalLoginData)
        <input type="submit" value="S'inscrire" />
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
