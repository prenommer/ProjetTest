Imports System.IO
Imports System.Net

Public Class Class10

    Public Sub Télécharger(url As String, destination As String)

        Dim client As New WebClient()
        client.DownloadFile(url, destination)

    End Sub

    Friend Class Program
        Private Shared Sub Main()

            Dim cheminFichier = "C:\Prenommer\tmp\prenommer_setup_3.7.0.0.7z"

            If File.Exists(cheminFichier) Then
                Try
                    ' Supprime le flux de données alternatif qui bloque le fichier
                    Dim zoneIdentifierPath = cheminFichier & ":Zone.Identifier"
                    If File.Exists(zoneIdentifierPath) Then
                        File.Delete(zoneIdentifierPath)
                        Console.WriteLine("Le fichier a été débloqué !")
                    Else
                        Console.WriteLine("Le fichier n'était pas bloqué.")
                    End If
                Catch ex As Exception
                    Console.WriteLine("Erreur lors du déblocage : " & ex.Message)
                End Try
            Else
                Console.WriteLine("Le fichier n'existe pas.")
            End If
        End Sub

    End Class

End Class