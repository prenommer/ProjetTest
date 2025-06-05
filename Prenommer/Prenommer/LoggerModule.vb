Imports System.IO

Friend Module LoggerModule

    ' Déclaration de la variable de module pour le chemin du fichier de journalisation.
    Public loggerFilePath As String = $"{My.Application.Info.DirectoryPath}\Resources\Logging.txt"
    Public logFilePath As String = $"{My.Application.Info.DirectoryPath}\Resources\logfile.txt"

    Public Sub TracingTest(fileName As String)

        Try
            ' Créez le fichier de journalisation s'il n'existe pas.
            If Not File.Exists(loggerFilePath) Then
                Using fs As FileStream = File.Create(loggerFilePath)
                    fs.Close()
                End Using
            End If

            ' Ouvrez le fichier de journalisation en mode append.
            Using sw As StreamWriter = File.AppendText(loggerFilePath)
                ' Enregistrez le début de l'opération dans le journal.
                sw.WriteLine($"Saisie de TracingTest le {Date.Now} {fileName}.")

                Dim stackTrace As String = New StackTrace().ToString()
                sw.WriteLine($"StackTrace: '{stackTrace}'")

                ' Enregistrez la fin de l'opération dans le journal.
                sw.WriteLine($"Sortie de TracingTest le {Date.Now} {fileName}.")

                ' Fermez le fichier.
                sw.Close()
            End Using

        Catch ex As Exception
            ' Gérez les exceptions et enregistrez-les dans le journal.
            My.Application.Log.WriteException(ex, TraceEventType.Error, "Une erreur s'est produite.")
        End Try

    End Sub

End Module
