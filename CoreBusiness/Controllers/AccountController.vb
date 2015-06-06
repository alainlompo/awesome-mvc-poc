Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Transactions
Imports System.Web.Routing
Imports DotNetOpenAuth.AspNet
Imports Microsoft.Web.WebPages.OAuth
Imports WebMatrix.WebData

<Authorize()> _
<InitializeSimpleMembership()> _
Public Class AccountController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Account/Login

    <AllowAnonymous()> _
    Public Function Login(ByVal returnUrl As String) As ActionResult
        ViewData("ReturnUrl") = returnUrl
        Return View()
    End Function

    '
    ' POST: /Account/Login

    <HttpPost()> _
    <AllowAnonymous()> _
    <ValidateAntiForgeryToken()> _
    Public Function Login(ByVal model As LoginModel, ByVal returnUrl As String) As ActionResult
        If ModelState.IsValid AndAlso WebSecurity.Login(model.UserName, model.Password, persistCookie:=model.RememberMe) Then
            Return RedirectToLocal(returnUrl)
        End If

        ' Si nous sommes arrivés là, quelque chose a échoué, réafficher le formulaire
        ModelState.AddModelError("", "Le nom d'utilisateur ou mot de passe fourni est incorrect.")
        Return View(model)
    End Function

    '
    ' POST: /Account/LogOff

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Public Function LogOff() As ActionResult
        WebSecurity.Logout()

        Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Account/Register

    <AllowAnonymous()> _
    Public Function Register() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Account/Register

    <HttpPost()> _
    <AllowAnonymous()> _
    <ValidateAntiForgeryToken()> _
    Public Function Register(ByVal model As RegisterModel) As ActionResult
        If ModelState.IsValid Then
            ' Tentative d'inscription de l'utilisateur
            Try
                WebSecurity.CreateUserAndAccount(model.UserName, model.Password)
                WebSecurity.Login(model.UserName, model.Password)
                Return RedirectToAction("Index", "Home")
            Catch e As MembershipCreateUserException

                ModelState.AddModelError("", ErrorCodeToString(e.StatusCode))
            End Try
        End If

        ' Si nous sommes arrivés là, quelque chose a échoué, réafficher le formulaire
        Return View(model)
    End Function

    '
    ' POST: /Account/Disassociate

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Public Function Disassociate(ByVal provider As String, ByVal providerUserId As String) As ActionResult
        ' Encapsuler une transaction pour empêcher l'utilisateur de dissocier accidentellement tous ses comptes en une fois.

        Dim ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId)
        Dim message As ManageMessageId? = Nothing

        ' Dissocier uniquement le compte si l'utilisateur actuellement connecté est le propriétaire
        If ownerAccount = User.Identity.Name Then
            ' Utiliser une transaction pour empêcher l'utilisateur de supprimer ses dernières informations d'identification de connexion
            Using scope As New TransactionScope(TransactionScopeOption.Required, New TransactionOptions With {.IsolationLevel = IsolationLevel.Serializable})
                Dim hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name))
                If hasLocalAccount OrElse OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1 Then
                    OAuthWebSecurity.DeleteAccount(provider, providerUserId)
                    scope.Complete()
                    message = ManageMessageId.RemoveLoginSuccess
                End If
            End Using
        End If

        Return RedirectToAction("Manage", New With {.Message = message})
    End Function

    '
    ' GET: /Account/Manage

    Public Function Manage(ByVal message As ManageMessageId?) As ActionResult
        ViewData("StatusMessage") =
            If(message = ManageMessageId.ChangePasswordSuccess, "Votre mot de passe a été modifié.", _
                If(message = ManageMessageId.SetPasswordSuccess, "Votre mot de passe a été défini.", _
                    If(message = ManageMessageId.RemoveLoginSuccess, "La connexion externe a été supprimée.", _
                        "")))

        ViewData("HasLocalPassword") = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name))
        ViewData("ReturnUrl") = Url.Action("Manage")
        Return View()
    End Function

    '
    ' POST: /Account/Manage

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Public Function Manage(ByVal model As LocalPasswordModel) As ActionResult
        Dim hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name))
        ViewData("HasLocalPassword") = hasLocalAccount
        ViewData("ReturnUrl") = Url.Action("Manage")
        If hasLocalAccount Then
            If ModelState.IsValid Then
                ' ChangePassword va lever une exception plutôt que de renvoyer la valeur False dans certains scénarios de défaillance.
                Dim changePasswordSucceeded As Boolean

                Try
                    changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword)
                Catch e As Exception
                    changePasswordSucceeded = False
                End Try

                If changePasswordSucceeded Then
                    Return RedirectToAction("Manage", New With {.Message = ManageMessageId.ChangePasswordSuccess})
                Else
                    ModelState.AddModelError("", "Le mot de passe actuel est incorrect ou le nouveau mot de passe n'est pas valide.")
                End If
            End If
        Else
            ' L'utilisateur n'a pas de mot de passe local. Veuillez donc supprimer les erreurs de validation provoquées par un
            ' champ OldPassword manquant
            Dim state = ModelState("OldPassword")
            If state IsNot Nothing Then
                state.Errors.Clear()
            End If

            If ModelState.IsValid Then
                Try
                    WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword)
                    Return RedirectToAction("Manage", New With {.Message = ManageMessageId.SetPasswordSuccess})
                Catch e As Exception
                    ModelState.AddModelError("", String.Format("Le compte local ne peut pas être créé. Un compte portant le même nom ""{0}"" existe peut-être déjà.", User.Identity.Name))
                End Try
            End If
        End If

        ' Si nous sommes arrivés là, quelque chose a échoué, réafficher le formulaire 
        Return View(model)
    End Function

    '
    ' POST: /Account/ExternalLogin

    <HttpPost()> _
    <AllowAnonymous()> _
    <ValidateAntiForgeryToken()> _
    Public Function ExternalLogin(ByVal provider As String, ByVal returnUrl As String) As ActionResult
        Return New ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", New With {.ReturnUrl = returnUrl}))
    End Function

    '
    ' GET: /Account/ExternalLoginCallback

    <AllowAnonymous()> _
    Public Function ExternalLoginCallback(ByVal returnUrl As String) As ActionResult
        Dim result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", New With {.ReturnUrl = returnUrl}))
        If Not result.IsSuccessful Then
            Return RedirectToAction("ExternalLoginFailure")
        End If

        If OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie:=False) Then
            Return RedirectToLocal(returnUrl)
        End If

        If User.Identity.IsAuthenticated Then
            ' Si l'utilisateur actuel est connecté, ajoutez le nouveau compte
            OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name)
            Return RedirectToLocal(returnUrl)
        Else
            ' L'utilisateur est nouveau. Demander le nom d'appartenance souhaité
            Dim loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId)
            ViewData("ProviderDisplayName") = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName
            ViewData("ReturnUrl") = returnUrl
            Return View("ExternalLoginConfirmation", New RegisterExternalLoginModel With {.UserName = result.UserName, .ExternalLoginData = loginData})
        End If
    End Function

    '
    ' POST: /Account/ExternalLoginConfirmation

    <HttpPost()> _
    <AllowAnonymous()> _
    <ValidateAntiForgeryToken()> _
    Public Function ExternalLoginConfirmation(ByVal model As RegisterExternalLoginModel, ByVal returnUrl As String) As ActionResult
        Dim provider As String = Nothing
        Dim providerUserId As String = Nothing

        If User.Identity.IsAuthenticated OrElse Not OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, provider, providerUserId) Then
            Return RedirectToAction("Gérer")
        End If

        If ModelState.IsValid Then
            ' Insérer un nouvel utilisateur dans la base de données
            Using db As New UsersContext()
                Dim user = db.UserProfiles.FirstOrDefault(Function(u) u.UserName.ToLower() = model.UserName.ToLower())
                ' Vérifier si l'utilisateur n'existe pas déjà
                If user Is Nothing Then
                    ' Insérer le nom dans la table des profils
                    db.UserProfiles.Add(New UserProfile With {.UserName = model.UserName})
                    db.SaveChanges()

                    OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName)
                    OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie:=False)

                    Return RedirectToLocal(returnUrl)
                Else
                    ModelState.AddModelError("UserName", "Le nom d'utilisateur existe déjà. Entrez un nom d'utilisateur différent.")
                End If
            End Using
        End If

        ViewData("ProviderDisplayName") = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName
        ViewData("ReturnUrl") = returnUrl
        Return View(model)
    End Function

    '
    ' GET: /Account/ExternalLoginFailure

    <AllowAnonymous()> _
    Public Function ExternalLoginFailure() As ActionResult
        Return View()
    End Function

    <AllowAnonymous()> _
    <ChildActionOnly()> _
    Public Function ExternalLoginsList(ByVal returnUrl As String) As ActionResult
        ViewData("ReturnUrl") = returnUrl
        Return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData)
    End Function

    <ChildActionOnly()> _
    Public Function RemoveExternalLogins() As ActionResult
        Dim accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name)
        Dim externalLogins = New List(Of ExternalLogin)()
        For Each account As OAuthAccount In accounts
            Dim clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider)

            externalLogins.Add(New ExternalLogin With { _
                .Provider = account.Provider, _
                .ProviderDisplayName = clientData.DisplayName, _
                .ProviderUserId = account.ProviderUserId _
            })
        Next

        ViewData("ShowRemoveButton") = externalLogins.Count > 1 OrElse OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name))
        Return PartialView("_RemoveExternalLoginsPartial", externalLogins)
    End Function

#Region "Applications auxiliaires"
    Private Function RedirectToLocal(ByVal returnUrl As String) As ActionResult
        If Url.IsLocalUrl(returnUrl) Then
            Return Redirect(returnUrl)
        Else
            Return RedirectToAction("Index", "Home")
        End If
    End Function

    Public Enum ManageMessageId
        ChangePasswordSuccess
        SetPasswordSuccess
        RemoveLoginSuccess
    End Enum

    Friend Class ExternalLoginResult
        Inherits System.Web.Mvc.ActionResult

        Private ReadOnly _provider As String
        Private ReadOnly _returnUrl As String

        Public Sub New(ByVal provider As String, ByVal returnUrl As String)
            _provider = provider
            _returnUrl = returnUrl
        End Sub

        Public ReadOnly Property Provider() As String
            Get
                Return _provider
            End Get
        End Property

        Public ReadOnly Property ReturnUrl() As String
            Get
                Return _returnUrl
            End Get
        End Property

        Public Overrides Sub ExecuteResult(ByVal context As ControllerContext)
            OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl)
        End Sub
    End Class

    Public Function ErrorCodeToString(ByVal createStatus As MembershipCreateStatus) As String
        ' Consultez http://go.microsoft.com/fwlink/?LinkID=177550 pour
        ' obtenir la liste complète des codes d'état.
        Select Case createStatus
            Case MembershipCreateStatus.DuplicateUserName
                Return "Le nom d'utilisateur existe déjà. Entrez un nom d'utilisateur différent."

            Case MembershipCreateStatus.DuplicateEmail
                Return "Un nom d'utilisateur pour cette adresse de messagerie existe déjà. Entrez une adresse de messagerie différente."

            Case MembershipCreateStatus.InvalidPassword
                Return "Le mot de passe fourni n'est pas valide. Entrez une valeur de mot de passe valide."

            Case MembershipCreateStatus.InvalidEmail
                Return "L'adresse de messagerie fournie n'est pas valide. Vérifiez la valeur et réessayez."

            Case MembershipCreateStatus.InvalidAnswer
                Return "La réponse de récupération du mot de passe fournie n'est pas valide. Vérifiez la valeur et réessayez."

            Case MembershipCreateStatus.InvalidQuestion
                Return "La question de récupération du mot de passe fournie n'est pas valide. Vérifiez la valeur et réessayez."

            Case MembershipCreateStatus.InvalidUserName
                Return "Le nom d'utilisateur fourni n'est pas valide. Vérifiez la valeur et réessayez."

            Case MembershipCreateStatus.ProviderError
                Return "Le fournisseur d'authentification a retourné une erreur. Vérifiez votre entrée et réessayez. Si le problème persiste, contactez votre administrateur système."

            Case MembershipCreateStatus.UserRejected
                Return "La demande de création d'utilisateur a été annulée. Vérifiez votre entrée et réessayez. Si le problème persiste, contactez votre administrateur système."

            Case Else
                Return "Une erreur inconnue s'est produite. Vérifiez votre entrée et réessayez. Si le problème persiste, contactez votre administrateur système."
        End Select
    End Function
#End Region

End Class
