Public Class Etape
    Inherits BaseModel

    Public Property DescriptionEtape As String
    Public Property ProjetAssocie As Projet
    Public Property User As Utilisateur
    Public Property OrdreEtape As Integer

    Public Property DateDebutPrevue As Date
    Public Property DateFinPrevue As Date
    Public Property DateDebutReelle As Date
    Public Property DateFinReelle As Date
    Public Property ResponsableEntite As Utilisateur
    Public Property Statut As StatutPET
    Public Property CommentaireEtape As String



End Class
