Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class AddTRDescII
        Inherits DbMigration
    
        Public Overrides Sub Up()
            'AddColumn("dbo.TacheDeReferences", "DescriptionTache", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            'DropColumn("dbo.TacheDeReferences", "DescriptionTache")
        End Sub
    End Class
End Namespace
