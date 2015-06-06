Imports Omu.AwesomeMvc

Public Class TypesAccessController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /TypesAccess

    Function GetListTypes() As List(Of String)

        Dim result As New List(Of String)
        result.Add("DEV")
        result.Add("TEST")
        result.Add("ADMIN")
        Return result

    End Function

    Function Index() As ActionResult
        Return View()
    End Function

    Function GetTypesAccess(v As String) As ActionResult

        v = If(v, String.Empty)

        Dim items = GetListTypes().Select(Function(s As String) _
            New SelectableItem(s, s, v = s))
        Return Json(items)

    End Function

End Class