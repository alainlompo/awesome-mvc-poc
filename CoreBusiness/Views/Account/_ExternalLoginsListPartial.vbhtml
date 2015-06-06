@ModelType ICollection(Of AuthenticationClientData)

@If Model.Count = 0 Then
    @<div class="message-info">
        <p>Aucun service d’authentification externe n’est configuré. Consultez <a href="http://go.microsoft.com/fwlink/?LinkId=252166">cet article</a>
        pour obtenir des informations sur la configuration de cette application ASP.NET pour la prise en charge de la connexion via des services externes.</p>
    </div>
Else
    Using Html.BeginForm("ExternalLogin", "Account", New With { .ReturnUrl = ViewData("ReturnUrl") })
    @Html.AntiForgeryToken()
    @<fieldset id="socialLoginList">
        <legend>Se connecter en utilisant un autre service</legend>
        <p>
        @For Each p as AuthenticationClientData in Model
            @<button type="submit" name="provider" value="@p.AuthenticationClient.ProviderName" title="Se connecter en utilisant votre compte @p.DisplayName">@p.DisplayName</button>
        Next
        </p>
    </fieldset>
    End Using
End If
