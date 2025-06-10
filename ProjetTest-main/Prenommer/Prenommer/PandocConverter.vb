Imports System.IO

Public Class PandocConverter

    Private ReadOnly pandocPath As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\AppData\Local\Pandoc\pandoc.exe"

    ' Méthode générique pour exécuter une commande Pandoc
    Private Sub ExecutePandoc(arguments As String)

        If Not IO.File.Exists(pandocPath) Then
            Throw New FileNotFoundException($"Pandoc introuvable : {pandocPath}")
        End If

        Dim process As New Process() With {
                .StartInfo = New ProcessStartInfo() With {
                .FileName = pandocPath,
                .Arguments = arguments,
                .UseShellExecute = False,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .CreateNoWindow = True
                }
            }

        process.Start()
        Dim [error] As String = process.StandardError.ReadToEnd()
        process.WaitForExit()

        If Not String.IsNullOrEmpty([error]) Then

        End If

    End Sub

    ' Conversion Markdown vers Word
    Public Sub ConvertMarkdownToWord(inputMarkdown As String, outputDocx As String, referenceDocxPath As String)

        Dim arguments As String = $"""{inputMarkdown}"" -f markdown -t docx -o ""{outputDocx}"""
        ExecutePandoc(arguments)

    End Sub

    ' Conversion Word vers Markdown
    Public Sub ConvertWordToMarkdown(inputDocx As String, outputMarkdown As String)

        Dim arguments As String = $"""{inputDocx}"" -f docx -t markdown -o ""{outputMarkdown}"""
        ExecutePandoc(arguments)

    End Sub

End Class