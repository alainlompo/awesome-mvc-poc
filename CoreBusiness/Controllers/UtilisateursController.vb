Imports System.Data.Entity

Public Class UtilisateursController
    Inherits System.Web.Mvc.Controller

    Private db As New GlobalDbContext

    '
    ' GET: /Utilisateurs/

    Function Index() As ActionResult
        Return View(db.Utilisateurs.ToList())
    End Function

    '
    ' GET: /Utilisateurs/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim utilisateur As Utilisateur = db.Utilisateurs.Find(id)
        If IsNothing(utilisateur) Then
            Return HttpNotFound()
        End If
        Return View(utilisateur)
    End Function

    '
    ' GET: /Utilisateurs/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Utilisateurs/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal utilisateur As Utilisateur) As ActionResult
        If ModelState.IsValid Then
            db.Utilisateurs.Add(utilisateur)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(utilisateur)
    End Function

    '
    ' GET: /Utilisateurs/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim utilisateur As Utilisateur = db.Utilisateurs.Find(id)
        If IsNothing(utilisateur) Then
            Return HttpNotFound()
        End If
        Return View(utilisateur)
    End Function

    '
    ' POST: /Utilisateurs/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal utilisateur As Utilisateur) As ActionResult
        If ModelState.IsValid Then
            db.Entry(utilisateur).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(utilisateur)
    End Function

    '
    ' GET: /Utilisateurs/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim utilisateur As Utilisateur = db.Utilisateurs.Find(id)
        If IsNothing(utilisateur) Then
            Return HttpNotFound()
        End If
        Return View(utilisateur)
    End Function

    '
    ' POST: /Utilisateurs/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim utilisateur As Utilisateur = db.Utilisateurs.Find(id)
        db.Utilisateurs.Remove(utilisateur)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class