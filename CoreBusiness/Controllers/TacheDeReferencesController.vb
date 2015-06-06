Imports System.Data.Entity

Public Class TacheDeReferencesController
    Inherits System.Web.Mvc.Controller

    Private db As New GlobalDbContext

    '
    ' GET: /TacheDeReferences/

    Function Index() As ActionResult
        Return View(db.TacheDeReferences.ToList())
    End Function

    '
    ' GET: /TacheDeReferences/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tachedereference As TacheDeReference = db.TacheDeReferences.Find(id)
        If IsNothing(tachedereference) Then
            Return HttpNotFound()
        End If
        Return View(tachedereference)
    End Function

    '
    ' GET: /TacheDeReferences/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /TacheDeReferences/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal tachedereference As TacheDeReference) As ActionResult
        If ModelState.IsValid Then
            db.TacheDeReferences.Add(tachedereference)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(tachedereference)
    End Function

    '
    ' GET: /TacheDeReferences/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tachedereference As TacheDeReference = db.TacheDeReferences.Find(id)
        If IsNothing(tachedereference) Then
            Return HttpNotFound()
        End If
        Return View(tachedereference)
    End Function

    '
    ' POST: /TacheDeReferences/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal tachedereference As TacheDeReference) As ActionResult
        If ModelState.IsValid Then
            db.Entry(tachedereference).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(tachedereference)
    End Function

    '
    ' GET: /TacheDeReferences/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tachedereference As TacheDeReference = db.TacheDeReferences.Find(id)
        If IsNothing(tachedereference) Then
            Return HttpNotFound()
        End If
        Return View(tachedereference)
    End Function

    '
    ' POST: /TacheDeReferences/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim tachedereference As TacheDeReference = db.TacheDeReferences.Find(id)
        db.TacheDeReferences.Remove(tachedereference)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class