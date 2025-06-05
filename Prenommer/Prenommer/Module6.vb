Imports System.IO

Module Module6

    Sub Main()
        ' Chemins pour les fichiers d'entrée et de sortie
        Dim inputFilePath As String = "C:\Prenomme\Prenommer\Prenommer\bin\Debug\Librairies\Y.librairie"
        Dim outputFilePath As String = "C:\Prenomme\Prenommer\Prenommer\bin\Debug\Librairies\Y_output.txt"
        Dim tabSize As Integer = 4 ' Taille des tabulations

        ' Tentative d'ouverture du fichier de sortie
        Using writer As New StreamWriter(outputFilePath)
            Using reader As New StreamReader(inputFilePath)
                ' Redirection de la sortie standard de la console vers le fichier de sortie
                Console.SetOut(writer)
                ' Redirection de l'entrée standard de la console vers le fichier d'entrée
                Console.SetIn(reader)

                Dim line As String = Console.ReadLine()
                While line IsNot Nothing
                    Dim newLine As String = line.Replace("".PadRight(tabSize, " "c), ControlChars.Tab)
                    Console.WriteLine(newLine)
                    line = Console.ReadLine()
                End While
            End Using
        End Using
    End Sub

End Module