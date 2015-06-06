@ModelType ICollection(Of CoreBusiness.ExternalLogin)

@If Model.Count > 0 Then
    @<h3>Connexions externes enregistrées</h3>
    @<table>
        <tbody>
        @For Each externalLogin As CoreBusiness.ExternalLogin In Model
            @<tr>
                <td>@externalLogin.ProviderDisplayName</td>
                <td>
                    @If ViewData("ShowRemoveButton") Then
                            Using Html.BeginForm("Disassociate", "Account")
                            @Html.AntiForgeryToken()
                            @<div>
                                @Html.Hidden("provider", externalLogin.Provider)
                                @Html.Hidden("providerUserId", externalLogin.ProviderUserId)
                                <input type="submit" value="Supprimer" title="Supprimer ces informations d'identification @externalLogin.ProviderDisplayName de votre compte" />
                            </div>
                        End Using
                    Else
                        @: &nbsp;
                    End If
                </td>
            </tr>
        Next
        </tbody>
    </table>
End If