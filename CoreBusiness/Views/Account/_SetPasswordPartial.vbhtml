@ModelType CoreBusiness.LocalPasswordModel

<p>
    Vous n’avez pas de mot de passe local pour ce site. Ajoutez un mot de passe
    local, pour pouvoir vous connecter sans connexion externe.
</p>

@Using Html.BeginForm("Manage", "Account")
    @Html.AntiForgeryToken()
    @Html.ValidationSummary()

    @<fieldset>
        <legend>Formulaire de définition de mot de passe</legend>
        <ol>
            <li>
                @Html.LabelFor(Function(m) m.NewPassword)
                @Html.PasswordFor(Function(m) m.NewPassword)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.ConfirmPassword)
                @Html.PasswordFor(Function(m) m.ConfirmPassword)
            </li>
        </ol>
        <input type="submit" value="Définir un mot de passe" />
    </fieldset>
End Using
