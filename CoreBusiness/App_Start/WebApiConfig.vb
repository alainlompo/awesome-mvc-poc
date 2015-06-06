Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Class WebApiConfig
    Public Shared Sub Register(ByVal config As HttpConfiguration)
        config.Routes.MapHttpRoute( _
            name:="DefaultApi", _
            routeTemplate:="api/{controller}/{id}", _
            defaults:=New With {.id = RouteParameter.Optional} _
        )
        
        'Supprimez les commentaires de la ligne de code suivante pour activer la prise en charge des requêtes pour les actions ayant un type de retour IQueryable ou IQueryable(Of T).
        ' Pour éviter le traitement de requêtes inattendues ou malveillantes, utilisez les paramètres de validation définis sur QueryableAttribute pour valider les requêtes entrantes.
        'Pour plus d’informations, visitez http://go.microsoft.com/fwlink/?LinkId=279712.
        'config.EnableQuerySupport()
    End Sub
End Class