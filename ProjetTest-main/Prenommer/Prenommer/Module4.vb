Imports System.IO
Imports Markdig

Friend Module Module4

    Sub Main()
        ' Chemin vers le fichier Markdown
        Dim markdownPath As String = "test.md"

        ' Vérification si le fichier existe
        If Not File.Exists(markdownPath) Then
            Console.WriteLine("Fichier Markdown introuvable : " & markdownPath)
            Return
        End If

        ' Lecture du contenu du fichier Markdown
        Dim markdownContent As String = File.ReadAllText(markdownPath)

        ' Création du pipeline Markdig (configuration pour extensions avancées)
        Dim pipeline = New MarkdownPipelineBuilder().UseAdvancedExtensions().Build()

        ' Conversion du Markdown en HTML
        Dim htmlContent As String = Markdown.ToHtml(markdownContent, pipeline)

        ' Affichage du résultat HTML dans la console
        Console.WriteLine(htmlContent)

        ' Facultatif : écrire le HTML dans un fichier pour visualisation
        Dim htmlOutputPath As String = "output.html"
        File.WriteAllText(htmlOutputPath, htmlContent)
        Console.WriteLine("Le HTML a été généré dans : " & htmlOutputPath)
    End Sub

End Module