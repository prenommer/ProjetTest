Public Class Class2

    Public Class Fich
        <JsonProperty("Title")>
        Public Property Titre As String ' En français

        <JsonProperty("Name")>
        Public Property Nom As String ' En français

        <JsonProperty("Charge")>
        Public Property Charge As String

        <JsonProperty("Institute")>
        Public Property Institut As String ' En français

        <JsonProperty("Celebration")>
        Public Property Celebration As String

        <JsonProperty("Birth")>
        Public Property Naissance As String ' En français

        <JsonProperty("Death")>
        Public Property Deces As String ' En français

        <JsonProperty("Otherparties")>
        Public Property Autresfetes As String ' En français

        <JsonProperty("Othernames")>
        Public Property Autresnoms As String ' En français

        <JsonProperty("Venerable")>
        Public Property Venerable As String

        <JsonProperty("Beatified")>
        Public Property Beatification As String ' En français

        <JsonProperty("Canonized")>
        Public Property Canonisation As String ' En français

        <JsonProperty("Heading")>
        Public Property TitrePrincipal As String ' En français

        <JsonProperty("Patron")>
        Public Property Patron As String

        <JsonProperty("Link")>
        Public Property Lien As String ' En français

        <JsonProperty("Image")>
        Public Property Image As String

        <JsonProperty("Biography")>
        Public Property Biographie As String ' En français

        <JsonProperty("Origin")>
        Public Property Origine As String ' En français

    End Class

    Public Class Fiche
        <JsonProperty("fiches")>
        Public Property IDUnique As String
        Public Property Nom As String
    End Class

    Public Class Prenommer
        <JsonProperty("fiches")>
        Public Property Fiches As Fiche()
    End Class

End Class