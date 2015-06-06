Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Threading
Imports WebMatrix.WebData

<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method, AllowMultiple:=False, Inherited:=True)>
Public NotInheritable Class InitializeSimpleMembershipAttribute
    Inherits ActionFilterAttribute

    Private Shared _initializer As SimpleMembershipInitializer
    Private Shared _initializerLock As New Object
    Private Shared _isInitialized As Boolean

    Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
        ' S'assurer qu'ASP.NET Simple Membership est initialisé une seule fois par démarrage d'application
        LazyInitializer.EnsureInitialized(_initializer, _isInitialized, _initializerLock)
    End Sub

    Private Class SimpleMembershipInitializer
        Public Sub New()
            Database.SetInitializer(Of UsersContext)(Nothing)

            Try
                Using context As New UsersContext()
                    If Not context.Database.Exists() Then
                        ' Créer la base de données SimpleMembership sans schéma de migration Entity Framework
                        CType(context, IObjectContextAdapter).ObjectContext.CreateDatabase()
                    End If
                End Using

                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables:=True)
            Catch ex As Exception
                Throw New InvalidOperationException("Impossible d'initialiser la base de données ASP.NET Simple Membership. Pour plus d'informations, consultez la page http://go.microsoft.com/fwlink/?LinkId=256588", ex)
            End Try
        End Sub
    End Class
End Class
