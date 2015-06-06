Imports System.Data.Entity

Public Class EtapesController
    Inherits System.Web.Mvc.Controller

    Private db As New GlobalDbContext

    '
    ' GET: /Etapes/

    Function Index() As ActionResult
        Return View(db.Etapes.ToList())
    End Function

    '
    ' GET: /Etapes/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim etape As Etape = db.Etapes.Find(id)
        If IsNothing(etape) Then
            Return HttpNotFound()
        End If
        Return View(etape)
    End Function

    '
    ' GET: /Etapes/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Etapes/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal etape As Etape) As ActionResult
        If ModelState.IsValid Then
            db.Etapes.Add(etape)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(etape)
    End Function

    '
    ' GET: /Etapes/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim etape As Etape = db.Etapes.Find(id)
        If IsNothing(etape) Then
            Return HttpNotFound()
        End If
        Return View(etape)
    End Function

    '
    ' POST: /Etapes/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal etape As Etape) As ActionResult
        If ModelState.IsValid Then
            db.Entry(etape).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(etape)
    End Function

    '
    ' GET: /Etapes/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim etape As Etape = db.Etapes.Find(id)
        If IsNothing(etape) Then
            Return HttpNotFound()
        End If
        Return View(etape)
    End Function

    '
    ' POST: /Etapes/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim etape As Etape = db.Etapes.Find(id)
        db.Etapes.Remove(etape)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class