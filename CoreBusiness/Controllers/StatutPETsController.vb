Imports System.Data.Entity

Public Class StatutPETsController
    Inherits System.Web.Mvc.Controller

    Private db As New GlobalDbContext

    '
    ' GET: /StatutPETs/

    Function Index() As ActionResult
        Return View(db.StatutPETs.ToList())
    End Function

    '
    ' GET: /StatutPETs/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim statutpet As StatutPET = db.StatutPETs.Find(id)
        If IsNothing(statutpet) Then
            Return HttpNotFound()
        End If
        Return View(statutpet)
    End Function

    '
    ' GET: /StatutPETs/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /StatutPETs/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal statutpet As StatutPET) As ActionResult
        If ModelState.IsValid Then
            db.StatutPETs.Add(statutpet)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(statutpet)
    End Function

    '
    ' GET: /StatutPETs/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim statutpet As StatutPET = db.StatutPETs.Find(id)
        If IsNothing(statutpet) Then
            Return HttpNotFound()
        End If
        Return View(statutpet)
    End Function

    '
    ' POST: /StatutPETs/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal statutpet As StatutPET) As ActionResult
        If ModelState.IsValid Then
            db.Entry(statutpet).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(statutpet)
    End Function

    '
    ' GET: /StatutPETs/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim statutpet As StatutPET = db.StatutPETs.Find(id)
        If IsNothing(statutpet) Then
            Return HttpNotFound()
        End If
        Return View(statutpet)
    End Function

    '
    ' POST: /StatutPETs/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim statutpet As StatutPET = db.StatutPETs.Find(id)
        db.StatutPETs.Remove(statutpet)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class