Imports System.Data.Entity
Imports Omu.AwesomeMvc

Public Class ProjetsController
    Inherits System.Web.Mvc.Controller

    Private db As New GlobalDbContext

    Function GetProjectsDescriptionAuto(v As String)
        v = If(v, String.Empty).ToLower().Trim()

        Dim items = db.Projets.ToList().Where(Function(o) o.DescriptionProjet.ToLower().Contains(v)) _
                    .Take(5) _
                    .Select(Function(o) New KeyContent(o.ID, o.DescriptionProjet)).ToArray()

        Return Json(items)
    End Function


    Function GetProjectsDescriptionList(page As Integer)
        Dim pageSize = 5
        Dim items = db.Projets.ToList().Skip((page - 1) * pageSize).Take(pageSize).Select(Function(o) New KeyContent(o.ID, o.DescriptionProjet))
        Return Json(New AjaxListResult With {.Items = items, .More = db.Projets.ToList().Count() > page * pageSize})
    End Function



    Function GetProjectsGrid(g As GridParams)
        Return Json(New GridModelBuilder(Of Projet)(db.Projets.ToList().AsQueryable(), g) _
                With {.Map = Function(o) New With {o.ID, .Description = o.DescriptionProjet, .Budget = o.BudgetReel, .DateDebut = o.DateDebutReelle.ToShortDateString
                                                  }}.Build())

    End Function

    '
    ' GET: /Projets/

    Function Index() As ActionResult
        Return View(db.Projets.ToList())
    End Function

    '
    ' GET: /Projets/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim projet As Projet = db.Projets.Find(id)
        If IsNothing(projet) Then
            Return HttpNotFound()
        End If
        Return View(projet)
    End Function

    '
    ' GET: /Projets/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Projets/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal projet As Projet) As ActionResult
        If ModelState.IsValid Then
            db.Projets.Add(projet)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(projet)
    End Function

    '
    ' GET: /Projets/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim projet As Projet = db.Projets.Find(id)
        If IsNothing(projet) Then
            Return HttpNotFound()
        End If
        Return View(projet)
    End Function

    '
    ' POST: /Projets/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal projet As Projet) As ActionResult
        If ModelState.IsValid Then
            db.Entry(projet).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(projet)
    End Function

    '
    ' GET: /Projets/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim projet As Projet = db.Projets.Find(id)
        If IsNothing(projet) Then
            Return HttpNotFound()
        End If
        Return View(projet)
    End Function

    '
    ' POST: /Projets/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim projet As Projet = db.Projets.Find(id)
        db.Projets.Remove(projet)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class