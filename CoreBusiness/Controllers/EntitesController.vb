Imports System.Data.Entity

Public Class EntitesController
    Inherits System.Web.Mvc.Controller

    Private db As New GlobalDbContext

    '
    ' GET: /Entites/

    Function Index() As ActionResult
        Return View(db.Entites.ToList())
    End Function

    '
    ' GET: /Entites/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim entite As Entite = db.Entites.Find(id)
        If IsNothing(entite) Then
            Return HttpNotFound()
        End If
        Return View(entite)
    End Function

    '
    ' GET: /Entites/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Entites/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal entite As Entite) As ActionResult
        If ModelState.IsValid Then
            db.Entites.Add(entite)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(entite)
    End Function

    '
    ' GET: /Entites/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim entite As Entite = db.Entites.Find(id)
        If IsNothing(entite) Then
            Return HttpNotFound()
        End If
        Return View(entite)
    End Function

    '
    ' POST: /Entites/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal entite As Entite) As ActionResult
        If ModelState.IsValid Then
            db.Entry(entite).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(entite)
    End Function

    '
    ' GET: /Entites/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim entite As Entite = db.Entites.Find(id)
        If IsNothing(entite) Then
            Return HttpNotFound()
        End If
        Return View(entite)
    End Function

    '
    ' POST: /Entites/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim entite As Entite = db.Entites.Find(id)
        db.Entites.Remove(entite)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class