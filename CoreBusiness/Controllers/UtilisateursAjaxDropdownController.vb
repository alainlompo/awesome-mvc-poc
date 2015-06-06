Imports Omu.AwesomeMvc

Public Class UtilisateursAjaxDropdownController
    Inherits System.Web.Mvc.Controller

    Private db As New GlobalDbContext


    Function GetUsers(v As String) As ActionResult

        If (v = Nothing) Then
            v = String.Empty
        End If

        Dim items = db.Utilisateurs.ToList().Where( _
            Function(u As Utilisateur) u.Login.Length > 1) _
                .Select( _
                    Function(u As Utilisateur) New SelectableItem(u.ID, u.Login, v = u.ID.ToString()))




        Return Json(items)


    End Function


    Function GetItems(v As String) As ActionResult

        If (v = Nothing) Then
            v = String.Empty
        End If

        'Dim items = Db.BookGenres.Select(Function(bg As BookGenre) New SelectableItem(bg.Id, bg.GenreName, v = bg.Id.ToString()))
        Dim items = db.Utilisateurs.ToList().Select( _
            Function(u As Utilisateur) _
                New SelectableItem(u.ID, u.Prenom & _
                                   " " & u.Nom & _
                                   " [" & u.Login & "]", v = u.ID.ToString()))

        'Dim dataQuery As IEnumerator(Of Utilisateur) = db.Utilisateurs.SqlQuery("SELECT * FROM DBO.UTILISATEURS").GetEnumerator()




        'Dim listDatas As List(Of Utilisateur) = New List(Of Utilisateur)
        'Dim u1 As Utilisateur = New Utilisateur()
        'u1.ID = 1
        'u1.Login = "alainlompo"
        'u1.Nom = "lompo"
        'u1.Prenom = "alain"
        'u1.TypeAccess = "ADMIN"

        'Dim u2 As Utilisateur = New Utilisateur()
        'u2.ID = 2
        'u2.Login = "elsam"
        'u2.Nom = "elsam"
        'u2.Prenom = "mohamed"
        'u2.TypeAccess = "USER"

        'listDatas.Add(u1)
        'listDatas.Add(u2)

        'Dim items = listDatas.ToArray().Select(Function(u As Utilisateur) New SelectableItem(u.ID, u.Login, v = u.ID.ToString()))


        Return Json(items)
    End Function

End Class