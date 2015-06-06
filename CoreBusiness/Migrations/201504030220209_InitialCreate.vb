Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Projets",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .DescriptionProjet = c.String(),
                        .DateDebutPrevue = c.DateTime(nullable := False),
                        .DateDebutReelle = c.DateTime(nullable := False),
                        .DateFinPrevue = c.DateTime(nullable := False),
                        .DateFinReelle = c.DateTime(nullable := False),
                        .CommentaireProjet = c.String(),
                        .Budget = c.String(),
                        .BudgetReel = c.String(),
                        .EntiteProjet_ID = c.Int(),
                        .User_ID = c.Int(),
                        .Statut_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Entites", Function(t) t.EntiteProjet_ID) _
                .ForeignKey("dbo.Utilisateurs", Function(t) t.User_ID) _
                .ForeignKey("dbo.StatutPETs", Function(t) t.Statut_ID) _
                .Index(Function(t) t.EntiteProjet_ID) _
                .Index(Function(t) t.User_ID) _
                .Index(Function(t) t.Statut_ID)
            
            CreateTable(
                "dbo.Entites",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .DescriptionEntite = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Utilisateurs",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Login = c.String(),
                        .Password = c.String(),
                        .Nom = c.String(),
                        .Prenom = c.String(),
                        .TypeAccess = c.String(),
                        .EntiteUtilisateur_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Entites", Function(t) t.EntiteUtilisateur_ID) _
                .Index(Function(t) t.EntiteUtilisateur_ID)
            
            CreateTable(
                "dbo.StatutPETs",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .DescriptionStatut = c.String(),
                        .Couleur = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Taches",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .NumeroEtape = c.Int(nullable := False),
                        .OrdreTache = c.Int(nullable := False),
                        .DateDebutPrevue = c.DateTime(nullable := False),
                        .DateFinPrevue = c.DateTime(nullable := False),
                        .DateDebutReelle = c.DateTime(nullable := False),
                        .DateFinReelle = c.DateTime(nullable := False),
                        .NumeroStatut = c.Int(nullable := False),
                        .CommentaireTache = c.String(),
                        .ReferenceTache_ID = c.Int(),
                        .User_ID = c.Int(),
                        .ResponsableEntite_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.TacheDeReferences", Function(t) t.ReferenceTache_ID) _
                .ForeignKey("dbo.Utilisateurs", Function(t) t.User_ID) _
                .ForeignKey("dbo.Utilisateurs", Function(t) t.ResponsableEntite_ID) _
                .Index(Function(t) t.ReferenceTache_ID) _
                .Index(Function(t) t.User_ID) _
                .Index(Function(t) t.ResponsableEntite_ID)
            
            CreateTable(
                "dbo.TacheDeReferences",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Etapes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .DescriptionEtape = c.String(),
                        .OrdreEtape = c.Int(nullable := False),
                        .DateDebutPrevue = c.DateTime(nullable := False),
                        .DateFinPrevue = c.DateTime(nullable := False),
                        .DateDebutReelle = c.DateTime(nullable := False),
                        .DateFinReelle = c.DateTime(nullable := False),
                        .CommentaireEtape = c.String(),
                        .ProjetAssocie_ID = c.Int(),
                        .User_ID = c.Int(),
                        .ResponsableEntite_ID = c.Int(),
                        .Statut_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Projets", Function(t) t.ProjetAssocie_ID) _
                .ForeignKey("dbo.Utilisateurs", Function(t) t.User_ID) _
                .ForeignKey("dbo.Utilisateurs", Function(t) t.ResponsableEntite_ID) _
                .ForeignKey("dbo.StatutPETs", Function(t) t.Statut_ID) _
                .Index(Function(t) t.ProjetAssocie_ID) _
                .Index(Function(t) t.User_ID) _
                .Index(Function(t) t.ResponsableEntite_ID) _
                .Index(Function(t) t.Statut_ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.Etapes", New String() { "Statut_ID" })
            DropIndex("dbo.Etapes", New String() { "ResponsableEntite_ID" })
            DropIndex("dbo.Etapes", New String() { "User_ID" })
            DropIndex("dbo.Etapes", New String() { "ProjetAssocie_ID" })
            DropIndex("dbo.Taches", New String() { "ResponsableEntite_ID" })
            DropIndex("dbo.Taches", New String() { "User_ID" })
            DropIndex("dbo.Taches", New String() { "ReferenceTache_ID" })
            DropIndex("dbo.Utilisateurs", New String() { "EntiteUtilisateur_ID" })
            DropIndex("dbo.Projets", New String() { "Statut_ID" })
            DropIndex("dbo.Projets", New String() { "User_ID" })
            DropIndex("dbo.Projets", New String() { "EntiteProjet_ID" })
            DropForeignKey("dbo.Etapes", "Statut_ID", "dbo.StatutPETs")
            DropForeignKey("dbo.Etapes", "ResponsableEntite_ID", "dbo.Utilisateurs")
            DropForeignKey("dbo.Etapes", "User_ID", "dbo.Utilisateurs")
            DropForeignKey("dbo.Etapes", "ProjetAssocie_ID", "dbo.Projets")
            DropForeignKey("dbo.Taches", "ResponsableEntite_ID", "dbo.Utilisateurs")
            DropForeignKey("dbo.Taches", "User_ID", "dbo.Utilisateurs")
            DropForeignKey("dbo.Taches", "ReferenceTache_ID", "dbo.TacheDeReferences")
            DropForeignKey("dbo.Utilisateurs", "EntiteUtilisateur_ID", "dbo.Entites")
            DropForeignKey("dbo.Projets", "Statut_ID", "dbo.StatutPETs")
            DropForeignKey("dbo.Projets", "User_ID", "dbo.Utilisateurs")
            DropForeignKey("dbo.Projets", "EntiteProjet_ID", "dbo.Entites")
            DropTable("dbo.Etapes")
            DropTable("dbo.TacheDeReferences")
            DropTable("dbo.Taches")
            DropTable("dbo.StatutPETs")
            DropTable("dbo.Utilisateurs")
            DropTable("dbo.Entites")
            DropTable("dbo.Projets")
        End Sub
    End Class
End Namespace
