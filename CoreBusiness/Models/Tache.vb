Public Class Tache
    Inherits BaseModel

    Public Property ReferenceTache As TacheDeReference
    Public Property NumeroEtape As Integer

    Public Property User As Utilisateur
    Public Property OrdreTache As Integer
    Public Property DateDebutPrevue As Date
    Public Property DateFinPrevue As Date
    Public Property DateDebutReelle As Date
    Public Property DateFinReelle As Date

    Public Property ResponsableEntite As Utilisateur
    Public Property NumeroStatut As Integer
    Public Property CommentaireTache As String




End Class
