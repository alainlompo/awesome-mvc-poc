Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Data.Entity

Public Class UsersContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub

    Public Property UserProfiles As DbSet(Of UserProfile)
End Class

<Table("UserProfile")> _
Public Class UserProfile
    <Key()> _
    <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
    Public Property UserId As Integer

    Public Property UserName As String
End Class

Public Class RegisterExternalLoginModel
    <Required()> _
    <Display(Name:="Nom d'utilisateur")> _
    Public Property UserName As String

    Public Property ExternalLoginData As String
End Class

Public Class LocalPasswordModel
    <Required()> _
    <DataType(DataType.Password)> _
    <Display(Name:="Mot de passe actuel")> _
    Public Property OldPassword As String

    <Required()> _
    <StringLength(100, ErrorMessage:="La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength:=6)> _
    <DataType(DataType.Password)> _
    <Display(Name:="Nouveau mot de passe")> _
    Public Property NewPassword As String

    <DataType(DataType.Password)> _
    <Display(Name:="Confirmer le nouveau mot de passe")> _
    <Compare("NewPassword", ErrorMessage:="Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")> _
    Public Property ConfirmPassword As String
End Class

Public Class LoginModel
    <Required()> _
    <Display(Name:="Nom d'utilisateur")> _
    Public Property UserName As String

    <Required()> _
    <DataType(DataType.Password)> _
    <Display(Name:="Mot de passe")> _
    Public Property Password As String

    <Display(Name:="Mémoriser le mot de passe ?")> _
    Public Property RememberMe As Boolean
End Class

Public Class RegisterModel
    <Required()> _
    <Display(Name:="Nom d'utilisateur")> _
    Public Property UserName As String

    <Required()> _
    <StringLength(100, ErrorMessage:="La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength:=6)> _
    <DataType(DataType.Password)> _
    <Display(Name:="Mot de passe")> _
    Public Property Password As String

    <DataType(DataType.Password)> _
    <Display(Name:="Confirmer le mot de passe ")> _
    <Compare("Password", ErrorMessage:="Le mot de passe et le mot de passe de confirmation ne correspondent pas.")> _
    Public Property ConfirmPassword As String
End Class

Public Class ExternalLogin
    Public Property Provider As String
    Public Property ProviderDisplayName As String
    Public Property ProviderUserId As String
End Class
