Imports System.Data.Entity

Public Class TachesController
    Inherits System.Web.Mvc.Controller

    Private db As New GlobalDbContext

    '
    ' GET: /Taches/

    Function Index() As ActionResult
        Return View(db.Taches.ToList())
    End Function

    '
    ' GET: /Taches/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tache As Tache = db.Taches.Find(id)
        If IsNothing(tache) Then
            Return HttpNotFound()
        End If
        Return View(tache)
    End Function

    '
    ' GET: /Taches/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Taches/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal tache As Tache) As ActionResult
        If ModelState.IsValid Then
            db.Taches.Add(tache)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(tache)
    End Function

    '
    ' GET: /Taches/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tache As Tache = db.Taches.Find(id)
        If IsNothing(tache) Then
            Return HttpNotFound()
        End If
        Return View(tache)
    End Function

    '
    ' POST: /Taches/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal tache As Tache) As ActionResult
        If ModelState.IsValid Then
            db.Entry(tache).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(tache)
    End Function

    '
    ' GET: /Taches/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tache As Tache = db.Taches.Find(id)
        If IsNothing(tache) Then
            Return HttpNotFound()
        End If
        Return View(tache)
    End Function

    '
    ' POST: /Taches/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim tache As Tache = db.Taches.Find(id)
        db.Taches.Remove(tache)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class