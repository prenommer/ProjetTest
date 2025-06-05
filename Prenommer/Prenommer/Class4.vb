Imports System.IO

Public Class Class4

    Public Class RecentFile

        Public Property FilePath As String
        Public Property FileName As String

        ' Cette méthode est destinée à être utilisée pour ajouter un fichier récent.
        Public Sub AddRecent(filePath As String)
            Me.FilePath = filePath
            ' Autres actions à effectuer lors de l'ajout d'un fichier récent.
        End Sub
    End Class

    ' Propriété pour accéder à FichiersRecentsMenuItem.
    Public Property FichiersRecentsMenuItem As ToolStripMenuItem

    ' Procédure pour mettre à jour le menu des fichiers récents.
    Private Sub UpdateRecentFilesMenu(recentFiles As List(Of String))
        ' Effacer les anciens éléments de menu.
        FichiersRecentsMenuItem.DropDownItems.Clear()

        ' Ajouter les nouveaux éléments de menu pour chaque fichier récent.
        For Each filePath As String In recentFiles
            Dim fileName As String = Path.GetFileName(filePath)
            Dim menuItem As New ToolStripMenuItem(fileName)

            ' Ajouter un gestionnaire d'événements pour le clic sur l'élément de menu.
            AddHandler menuItem.Click, AddressOf FichiersRecentsMenuItem_Click

            ' Stocker le chemin du fichier dans la propriété Tag de l'élément de menu.
            menuItem.Tag = filePath
            Dim unused = FichiersRecentsMenuItem.DropDownItems.Add(menuItem)
        Next

    End Sub

    ' Gestionnaire d'événements pour le clic sur l'élément de menu.
    Private Sub FichiersRecentsMenuItem_Click(sender As Object, e As EventArgs)
        ' Votre implémentation.

        Try

            ' Assurez-vous que l'élément cliqué est un ToolStripMenuItem.
            ' Récupérer le chemin du fichier associé à l'élément cliqué.
            Dim filePath As String = TryCast(DirectCast(sender, ToolStripMenuItem)?.Tag, String)?.ToString()

            ' Vérifier si le fichier existe avant de l'ouvrir.
            ' Code pour obtenir filePath.
            filePath = Path.Combine(My.Application.Info.DirectoryPath, "Resources", "Recent.txt")

            ' Vérifier si le chemin du fichier est null ou vide.
            If String.IsNullOrEmpty(filePath) Then
                Dim unused1 = MessageBox.Show("Le chemin du fichier est null ou vide.")
            Else
                ' Le chemin du fichier est valide, écrire une chaîne vide dans le fichier.
                File.WriteAllText(filePath, String.Empty)
            End If

            If File.Exists(filePath) Then
                ' Mettre à jour le menu des fichiers récents.
                Main.SetupRecentFilesMenu()

                ' Extraire la lettre alphabétique du chemin du fichier.
                Dim firstLetter As Char = Path.GetFileNameWithoutExtension(filePath)(0)

                ' Rechercher le nœud correspondant dans le TreeView1.
                Dim node As TreeNode = Main.FindNodeByFirstLetter(Main.TreeView1.Nodes, firstLetter)

                ' Si le nœud est trouvé, le sélectionner.
                If node IsNot Nothing Then
                    Main.TreeView1.SelectedNode = node
                End If
            Else
                ' Afficher un message d'erreur si le fichier n'existe pas.
                Dim unused = MessageBox.Show($"Le fichier récent n'existe pas : {filePath}")
            End If

        Catch ex As NullReferenceException
            ' Gérer l'exception ici, vous pouvez afficher un message d'erreur ou effectuer d'autres actions.
            Dim unused2 = MessageBox.Show($"Une exception de référence null s'est produite : {ex.Message}")
        End Try

    End Sub

    '... Autres procédures et membres de la classe.

    Public Shared Sub MyStaticMethod()

        ' Code de votre méthode statique

        'Dim logFilePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Prenommer", "logfile.txt")
        Dim logFilePath As String = $"{My.Application.Info.DirectoryPath}\Resources\logfile.txt"

        ' Assurez-vous que le dossier existe

        Dim logDir As String = Path.GetDirectoryName(logFilePath)
        If Not Directory.Exists(logDir) Then
            Dim unused = Directory.CreateDirectory(logDir)
        End If

    End Sub

    Public Sub WriteLog(message As String)

        Try
            Using writer As New StreamWriter(logFilePath, True)
                writer.WriteLine($"{Date.Now}: {message}")
            End Using
        Catch ex As Exception
            ' Gestion d'erreur de base; pourrait être améliorée
            Dim unused = MessageBox.Show("Erreur lors de l'écriture dans le fichier de log : " & ex.Message)
        End Try

    End Sub

    Public Class CustomLogger

        Public Shared Sub Log(message As String)

            ' Code pour gérer la sortie du message, par exemple écrire dans un fichier
            Using writer As New StreamWriter($"{My.Application.Info.DirectoryPath}\Resources\logfile.txt", True)
                writer.WriteLine($"{Date.Now}: {message}")
            End Using
        End Sub

    End Class

End Class