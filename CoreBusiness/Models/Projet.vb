Public Class Projet
    Inherits BaseModel

    Public Property DescriptionProjet As String
    Public Property DateDebutPrevue As Date
    Public Property DateDebutReelle As Date
    Public Property DateFinPrevue As Date
    Public Property DateFinReelle As Date

    Public Property EntiteProjet As Entite
    Public Property User As Utilisateur
    Public Property Statut As StatutPET
    Public Property CommentaireProjet As String
    Public Property Budget As String
    Public Property BudgetReel As String


End Class
