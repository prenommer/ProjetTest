Imports Microsoft.VisualBasic.FileIO

Public Module Module5
    Sub Main()
        Console.WriteLine("Menu Analyse des fichiers librairies")
        Console.WriteLine("1. Analyser un fichier librairie")
        Console.WriteLine("2. Quitter")
        Console.Write("Choisissez une option: ")

        Dim choice As String = Console.ReadLine()
        Select Case choice
            Case "1"
                Console.Write("Entrez le chemin du fichier à analyser: ")
                Dim cheminFichier As String = Console.ReadLine()
                Module5.AnalyserFichierLibrairie(cheminFichier)
            Case "2"
                Console.WriteLine("Au revoir!")
            Case Else
                Console.WriteLine("Option invalide.")
        End Select

    End Sub

    Public Sub AnalyserFichierLibrairie(ByVal cheminFichier As String)

        Using parser As New TextFieldParser(cheminFichier, System.Text.Encoding.UTF8)
            parser.TextFieldType = FieldType.FixedWidth
            parser.SetFieldWidths(18, 90, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 1200, 120, 200)

            While Not parser.EndOfData
                Try
                    Dim fields As String() = parser.ReadFields()
                    ' Traitez chaque champ ici
                    Console.WriteLine($"Champ 1: {fields(0)}, Champ 2: {fields(1)}, Champ 3: {fields(2)}, Champ 4: {fields(3)}, Champ 5: {fields(4)}, Champ 6: {fields(5)}, Champ 7 : {fields(6)}, Champ 8: {fields(7)}, Champ 9: {fields(8)}, Champ 10: {fields(9)}, Champ 11: {fields(10)}, Champ 12: {fields(11)}, Champ 13: {fields(12)}, Champ 14: {fields(13)}, Champ 15: {fields(14)}, Champ 16: {fields(15)}, Champ 17: {fields(16)}")
                Catch ex As MalformedLineException
                    Console.WriteLine($"Ligne mal formée à {parser.LineNumber}: {ex.Message}")
                End Try
            End While
        End Using
    End Sub

End Module