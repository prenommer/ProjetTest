Public Class Class6

    Public Class LibreOfficeAutomation
        ''' <summary>
        ''' Convertit un fichier DOCX en ODT à l'aide de LibreOffice.
        ''' </summary>
        ''' <param name="sourceFilePath">Chemin du fichier source DOCX</param>
        ''' <param name="outputDirectory">Répertoire de destination pour le fichier ODT</param>
        Public Sub ConvertirDocxEnOdt(sourceFilePath As String, outputDirectory As String)
            ' Chemin complet vers soffice.exe
            Dim sofficePath As String = "C:\Program Files\LibreOffice\program\soffice.exe"

            If Not IO.File.Exists(sourceFilePath) Then
                Dim unused = MessageBox.Show("Fichier source introuvable : " & sourceFilePath, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Not IO.Directory.Exists(outputDirectory) Then
                Dim unused3 = IO.Directory.CreateDirectory(outputDirectory)
            End If

            Dim process As New Process()
            process.StartInfo.FileName = sofficePath
            process.StartInfo.Arguments = $"--headless --convert-to odt ""{sourceFilePath}"" --outdir ""{outputDirectory}"""
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            process.StartInfo.CreateNoWindow = True

            Try
                Dim unused4 = process.Start()
                process.WaitForExit()

                Dim output As String = process.StandardOutput.ReadToEnd()
                Dim [error] As String = process.StandardError.ReadToEnd()

                If Not String.IsNullOrEmpty([error]) Then
                    Dim unused1 = MessageBox.Show("Erreur lors de la conversion : " & [error], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim unused2 = MessageBox.Show("Conversion réussie ! Le fichier a été enregistré dans : " & outputDirectory, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                Dim unused5 = MessageBox.Show("Une exception s'est produite : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

    End Class

End Class