
Partial Public Class MainWindow

    Private ReadOnly _fiche As New Fiche()
    Private _memento As Memento

    ' ... autres membres de la classe

    Public Sub SauvegarderEtatHandler(sender As Object, e As EventArgs)

        ' Logique de sauvegarde d'état
        ' Sauvegarde de l'état actuel dans l'objet _memento
        _memento = New Memento With {
            .Titre = _fiche.Titre,
            .Nom = _fiche.Nom,
            .Charge = _fiche.CHarge,
            .Institut = _fiche.Institut,
            .Fete = _fiche.Fete,
            .Naissance = _fiche.Naissance,
            .Mort = _fiche.Mort,
            .Autrep = _fiche.Autrep,
            .Autren = _fiche.Autren,
            .Venera = _fiche.Venera,
            .Beatification = _fiche.Beatification,
            .Canonisation = _fiche.Canonisation,
            .Soustitre = _fiche.Soustitre,
            .Saintpatron = _fiche.Saintpatron,
            .Lien = _fiche.Lien,
            .Biographie = _fiche.Biographie,
            .Portrait = _fiche.Portrait,
            .Source = CType(_fiche.Source, Source)
        }
        ' ... autres propriétés à sauvegarder

    End Sub

    Public Sub RestaurerEtatHandler(sender As Object, e As EventArgs)

        ' Logique de restauration d'état
        ' Restauration de l'état à partir de l'objet _memento
        If _memento IsNot Nothing Then
            _fiche.Titre = _memento.Titre
            _fiche.Nom = _memento.Nom
            _fiche.CHarge = _memento.Charge
            _fiche.Institut = _memento.Institut
            _fiche.Fete = _memento.Fete
            _fiche.Naissance = _memento.Naissance
            _fiche.Mort = _memento.Mort
            _fiche.Autrep = _memento.Autrep
            _fiche.Autren = _memento.Autren
            _fiche.Venera = _memento.Venera
            _fiche.Beatification = _memento.Beatification
            _fiche.Canonisation = _memento.Canonisation
            _fiche.Soustitre = _memento.Soustitre
            _fiche.Saintpatron = _memento.Saintpatron
            _fiche.Lien = _memento.Lien
            _fiche.Biographie = _memento.Biographie
            _fiche.Portrait = _memento.Portrait
            _fiche.Source = _memento.Source
            ' ... autres propriétés à restaurer
        End If

    End Sub

    ' ... autres membres de la classe

    Public Class Fiche
        Friend ReadOnly IDUnique As String
        Public Property Titre As Object
        Public Property Nom As Object
        ' Ajoutez d'autres propriétés et logique associée
        Public Property CHarge As Object
        Public Property Institut As Object
        Public Property Fete As Object
        Public Property Naissance As Object
        Public Property Mort As Object
        Public Property Autrep As Object
        Public Property Autren As Object
        Public Property Venera As Object
        Public Property Beatification As Object
        Public Property Canonisation As Object
        Public Property Soustitre As Object
        Public Property Saintpatron As Object
        Public Property Lien As Object
        Public Property Biographie As Object
        Public Property Portrait As Object
        Public Property Source As Object
        Public Event RestaurerEtat(sender As Object, e As EventArgs)
        Public Event SauvegarderEtat(sender As Object, e As EventArgs)

    End Class

    Friend Class Memento

        Public Property Titre As Object
        Public Property Nom As Object
        Public Property Charge As Object
        Public Property Institut As Object
        Public Property Fete As Object
        Public Property Naissance As Object
        Public Property Mort As Object
        Public Property Autrep As Object
        Public Property Autren As Object
        Public Property Venera As Object
        Public Property Beatification As Object
        Public Property Canonisation As Object
        Public Property Soustitre As Object
        Public Property Saintpatron As Object
        Public Property Lien As Object
        Public Property Biographie As Object
        Public Property Portrait As Object
        Public Property Source As Source

    End Class

    ' ...
    Public Sub SauvegarderEtat()
        _memento = New Memento With {
            .Titre = _fiche.Titre,
            .Nom = _fiche.Nom,
            .Charge = _fiche.CHarge,
            .Institut = _fiche.Institut,
            .Fete = _fiche.Fete,
            .Naissance = _fiche.Naissance,
            .Mort = _fiche.Mort,
            .Autrep = _fiche.Autrep,
            .Autren = _fiche.Autren,
            .Venera = _fiche.Venera,
            .Beatification = _fiche.Beatification,
            .Canonisation = _fiche.Canonisation,
            .Soustitre = _fiche.Soustitre,
            .Saintpatron = _fiche.Saintpatron,
            .Lien = _fiche.Lien,
            .Biographie = _fiche.Biographie,
            .Portrait = _fiche.Portrait,
            .Source = CType(_fiche.Source, Source)
        }

    End Sub

    Public Sub RestaurerEtat()

        If _memento IsNot Nothing Then
            _fiche.Titre = _memento.Titre
            _fiche.Nom = _memento.Nom
            _fiche.CHarge = _memento.Charge
            _fiche.Institut = _memento.Institut
            _fiche.Fete = _memento.Fete
            _fiche.Naissance = _memento.Naissance
            _fiche.Mort = _memento.Mort
            _fiche.Autrep = _memento.Autrep
            _fiche.Autren = _memento.Autren
            _fiche.Venera = _memento.Venera
            _fiche.Beatification = _memento.Beatification
            _fiche.Canonisation = _memento.Canonisation
            _fiche.Soustitre = _memento.Soustitre
            _fiche.Saintpatron = _memento.Saintpatron
            _fiche.Lien = _memento.Lien
            _fiche.Biographie = _memento.Biographie
            _fiche.Portrait = _memento.Portrait
            _fiche.Source = _memento.Source
            ' Restaurez les autres propriétés nécessaires

        End If

    End Sub

    ' ...

End Class
