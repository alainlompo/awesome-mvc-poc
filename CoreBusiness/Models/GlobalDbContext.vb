Imports System.Data.Entity.DbContext

Imports System.Data.Entity


Public Class GlobalDbContext
    Inherits System.Data.Entity.DbContext

    Public Property Projets As DbSet(Of Projet)
    Public Property Entites As DbSet(Of Entite)
    Public Property Taches As DbSet(Of Tache)
    Public Property Utilisateurs As DbSet(Of Utilisateur)
    Public Property Etapes As DbSet(Of Etape)
    Public Property StatutPETs As DbSet(Of StatutPET)
    Public Property TacheDeReferences As DbSet(Of TacheDeReference)





End Class
