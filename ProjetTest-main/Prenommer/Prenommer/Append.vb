Imports System.IO
Imports System.IO.Compression
Imports System.Windows
Imports Microsoft.Win32

Public Class Append

    ' Déclarations des contrôles
    Friend WithEvents Button11 As Button

    Public Property ZipFilePath As String
    Public Property NewFileName As String
    Public Property ZipFileName As String
    Public Property FilePath As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ' Lister les fichiers dans le dossier.
            ListFiles(FolderBrowserDialog1.SelectedPath)
            SetEnabled()
        End If

    End Sub

    Private Sub Append_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Définissez le répertoire par défaut du navigateur sur le répertoire actuel.
        FolderBrowserDialog1.SelectedPath =
            Directory.GetCurrentDirectory()

        SetEnabled()

    End Sub

    Private Sub ListFiles(folderPath As String)

        ListBox1.Enabled = True
        ListBox1.Items.Clear()

        Dim fileNames As String() =
            Directory.GetFiles(folderPath,
                "*.*", SearchOption.TopDirectoryOnly)

        For Each fileName As String In fileNames
            Dim v = ListBox1.Items.Add(fileName)
        Next

    End Sub

    Private Function GetTextForOutput(FilePath As String) As String

        ' Vérifiez que le fichier existe.
        If Not File.Exists(FilePath) Then
            Throw New Exception("Fichier non trouvé : " & FilePath)
        End If

        ' Créez un nouveau StringBuilder, utilisé pour créer efficacement des chaînes.
        Dim sb As New Text.StringBuilder()

        ' Obtenir des informations sur le fichier.
        Dim thisFile As New FileInfo(FilePath)

        ' Ajouter des attributs de fichier.
        Dim stringBuilder = sb.Append("Fichier : " & thisFile.FullName)
        Dim stringBuilder1 = sb.Append(vbCrLf)
        Dim stringBuilder2 = sb.Append("Modifié : " & thisFile.LastWriteTime.ToString)
        Dim stringBuilder3 = sb.Append(vbCrLf)
        Dim stringBuilder4 = sb.Append("Taille : " & thisFile.Length.ToString & " bytes")
        Dim stringBuilder5 = sb.Append(vbCrLf)

        ' Ouvrez le fichier texte.
        Dim sr As StreamReader =
            File.OpenText(FilePath)

        ' Ajouter la première ligne du fichier.
        If sr.Peek() >= 0 Then
            Dim stringBuilder6 = sb.Append("Première ligne : " & sr.ReadLine())
        End If
        sr.Close()

        Return sb.ToString

    End Function

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        SetEnabled()

        TextBox1.Text = ListBox1.SelectedItem.ToString

        If TextBox1.Text = Nothing Then
            Dim msgBoxResult = MsgBox("Veuillez sélectionner un fichier, avant de continuer !", vbCritical, "Erreur")

        Else
            If Not CheckBox1.CheckState = CheckState.Unchecked Then
                Dim unmega As Integer = 1024 * 1024
                Dim ungiga As Integer = 1024 * 1024 * 1024

                Dim info As New FileInfo(TextBox1.Text)
                Dim msgBoxResult = MsgBox(info.Name & vbCrLf & info.Extension & vbCrLf & ((info.Length / unmega).ToString("0.00") + " Mo") & vbCrLf & info.CreationTime & vbCrLf & info.LastAccessTime & vbCrLf & info.DirectoryName, vbOKOnly, My.Application.Info.Title)
            End If

        End If

    End Sub

    Private Sub SetEnabled()

        Dim anySelected As Boolean =
            ListBox1.SelectedItem IsNot Nothing

        Button7.Enabled = anySelected
        CheckBox1.Enabled = anySelected

    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged

        Button7.Enabled = CheckState.Unchecked = CType(True, Global.System.Windows.Forms.CheckState)

    End Sub

    Public Sub Append_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim result As DialogResult = CType(MessageBox.Show("Êtes-vous sûr de fermer cette application ?", "Fermer", CType(MessageBoxButtons.YesNo, MessageBoxButton), CType(MessageBoxIcon.Question, MessageBoxImage)), DialogResult)

        ' Si l'utilisateur clique sur "Non", annuler la fermeture du formulaire.
        If result = DialogResult.No Then
            e.Cancel = True
        Else
            ' L'utilisateur a choisi de fermer l'application, appelez Application.Exit().
            Hide()
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox2.Enabled = True
        ListBox1.Items.Clear()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim myDialog As New FolderBrowserDialog()
        Dim path As String

        Button2.Enabled = False

        If myDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            path = myDialog.SelectedPath
        Else
            Exit Sub
        End If

        ListBox1.Items.Clear()
        Dim v = ListBox1.Items.Add(path)
        TextBox2.Text = path
        ListBox1.Enabled = False

    End Sub

    Private Shared Sub CopyDirectory(sourcePath As String, destPath As String)

        If File.Exists(sourcePath) Then

            File.Copy(sourcePath, destPath)
            Dim msgBoxResult = MsgBox("Fichier copié")

        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim SourceFile, DestinationFile As String
        SourceFile = TextBox1.Text
        DestinationFile = TextBox2.Text
        Dim Msg, Style, Title As String
        Dim Réponse As Integer

        Msg = "Etes-vous sûr de vouloir copier ce fichier ?"
        Style = CStr(vbYesNo + vbQuestion + vbDefaultButton1)
        Title = My.Application.Info.Title

        If Computer.FileSystem.FileExists(SourceFile) Then
            Réponse = MsgBox(Msg, CType(Style, MsgBoxStyle), Title)
            If Réponse = vbYes Then
                Computer.FileSystem.CopyFile(
                SourceFile,
                DestinationFile & "\" & Path.GetFileName(SourceFile),
                FileIO.UIOption.AllDialogs,
                FileIO.UICancelOption.DoNothing)
                Visible = True
            End If
        Else
            Exit Sub
        End If

        Dim cheminDossierLibrairies As String
        cheminDossierLibrairies = My.Application.Info.DirectoryPath & "\Librairies\"
        Main.ListView1.Items.Clear()

        ' Charger les fichiers du dossier des librairies dans le ListView.
        For Each fichier As String In Directory.GetFiles(cheminDossierLibrairies)
            Dim nomFichier As String = Path.GetFileName(fichier)
            Dim item As New ListViewItem(nomFichier)

            ' Ajouter l'icône associée au fichier à ImageList1.
            Main.ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fichier))

            ' Utiliser l'index de l'icône dans ImageList1 pour l'élément ListViewItem.
            item.ImageIndex = 0

            ' Ajouter l'élément à Main.ListView1.
            Dim unused = Main.ListView1.Items.Add(item)
        Next
        Main.ListView1.Refresh()

        Button2.Enabled = True
        Button5_Click(Button5, Nothing)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Dim SourceFile, DestinationFile As String
        SourceFile = TextBox1.Text
        DestinationFile = TextBox2.Text

        If Computer.FileSystem.FileExists(SourceFile) Then
            If MsgBox("Êtes-vous sûr de vouloir déplacer le fichier ?", MsgBoxStyle.YesNo, My.Application.Info.Title) = MsgBoxResult.Yes Then
                Computer.FileSystem.MoveFile(SourceFile, DestinationFile & "\" & Path.GetFileName(SourceFile), FileIO.UIOption.AllDialogs)
            End If
        Else
            Exit Sub
        End If

        Button5_Click(Button5, Nothing)

        Dim extension As String = Path.GetFileName(SourceFile).TrimStart("."c).ToUpper() 'GetExtension

        ' Utilisation de For Each pour itérer à travers les éléments du ListView1.
        For Each item As ListViewItem In Main.ListView1.Items
            ' Utilisez .Text si l'extension est dans le texte de l'élément.
            If item.Text.ToUpper() = extension Then

                ' Supprimer l'élément du ListView1 dans le formulaire principal (Main).
                Main.ListView1.Items.Remove(item)

                For i As Integer = 0 To Main.ListView1.Items.Count - 1
                    Main.ListView1.Items(i).BackColor = If(CBool(i Mod 2), Color.LightBlue, Color.White)
                Next

            End If
        Next

        Dim files As String() = Directory.GetFiles(My.Application.Info.DirectoryPath & "\Librairies", "*", SearchOption.TopDirectoryOnly)
        Dim count As Integer = files.Length

        ' Mettre à jour le texte ou l'emplacement où vous affichez le comptage.
        Main.ToolStripStatusLabel1.Text = count & " librairies chargées"

        Select Case Main.ListView1.Items.Count
            Case 0
                GroupBox1.Text = " Aucun fichier de données "

            Case 1
                GroupBox1.Text = count & " fichier de données "

            Case Else
                GroupBox1.Text = count & " fichiers de données "
        End Select

        Button7.Enabled = False
        CheckBox1.Enabled = False

    End Sub

    Public Function FileNameWithoutExtension(Chaine As String) As String

        Return Path.GetFileNameWithoutExtension(Chaine)

    End Function

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Dim OpenFileDialog1 As New OpenFileDialog With {
            .Title = "Sélectionnez le fichier à supprimer"
        }

        If CType(OpenFileDialog1.ShowDialog(), Global.System.Windows.Forms.DialogResult) = CType(True, Global.System.Windows.Forms.DialogResult) Then
            Dim FilePath As String = OpenFileDialog1.FileName

            Try
                Dim fileInfo As New FileInfo(FilePath)

                ' Vérifier si le fichier existe.
                If fileInfo.Exists Then
                    ' Demander une confirmation à l'utilisateur avant de supprimer le fichier.
                    Dim result As MessageBoxResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le fichier sélectionné ?",
                                                              "Confirmation de suppression",
                                                              MessageBoxButton.YesNo,
                                                              MessageBoxImage.Question)

                    If result = MessageBoxResult.Yes Then

                        ' Supprimer le fichier.
                        FileIO.FileSystem.DeleteFile(FilePath, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)

                        Dim unused = MessageBox.Show("Le fichier a été supprimé avec succès.", "Succès")
                    End If
                Else
                    Dim unused1 = MessageBox.Show("Le fichier sélectionné n'existe pas.", "Erreur")
                End If
            Catch ex As Exception
                Dim unused2 = MessageBox.Show("Une erreur s'est produite lors de la suppression du fichier : " & ex.Message, "Erreur")
            End Try
        Else
            Exit Sub
        End If

        Dim cheminDossierLibrairies As String
        cheminDossierLibrairies = My.Application.Info.DirectoryPath & "\Librairies\"
        Main.ListView1.Items.Clear()

        ' Charger les fichiers du dossier des librairies dans la ListView.
        For Each fichier As String In Directory.GetFiles(cheminDossierLibrairies)
            Dim nomFichier As String = Path.GetFileName(fichier)
            Dim item As New ListViewItem(nomFichier)

            Main.ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fichier))

            item.ImageIndex = 0

            Dim unused = Main.ListView1.Items.Add(item)
        Next
        Main.ListView1.Refresh()

        Main.ToolStripStatusLabel1.Text = Main.ListView1.Items.Count & " librairies chargées"
        Button5_Click(Button5, Nothing)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        ' Configuration de l'OpenFileDialog.
        Dim OpenFileDialog1 As New OpenFileDialog With {
            .Title = "Sélectionnez le fichier à renommer",
            .Filter = "Tous les fichiers (*.*)|*.*"
        }

        ' Ouverture de l'OpenFileDialog.
        Dim result As Boolean? = OpenFileDialog1.ShowDialog()

        ' Vérification du résultat de l'OpenFileDialog.
        If result Then
            Dim ancienChemin As String = OpenFileDialog1.FileName

            ' Demander le nouveau nom du fichier.
            Dim nouveauNom As String = InputBox("Entrez le nouveau nom du fichier :", "Renommer le fichier", Path.GetFileName(ancienChemin))

            ' Vérifier si le nouveau nom n'est pas vide.
            If Not String.IsNullOrEmpty(nouveauNom) Then
                Dim nouveauChemin As String = Path.Combine(Path.GetDirectoryName(ancienChemin), nouveauNom)

                Try
                    ' Renommer le fichier.
                    File.Move(ancienChemin, nouveauChemin)
                    Dim unused = MessageBox.Show("Le fichier a été renommé avec succès.", "Succès")
                Catch ex As Exception
                    Dim unused1 = MessageBox.Show("Une erreur s'est produite lors du renommage du fichier : " & ex.Message, "Erreur")
                End Try
            End If
        Else
            Exit Sub
        End If

        Dim cheminDossierLibrairies As String
        cheminDossierLibrairies = My.Application.Info.DirectoryPath & "\Librairies\"
        Main.ListView1.Items.Clear()

        ' Charger les fichiers du dossier des librairies dans la ListView.
        For Each fichier As String In Directory.GetFiles(cheminDossierLibrairies)
            Dim nomFichier As String = Path.GetFileName(fichier)
            Dim item As New ListViewItem(nomFichier)

            Main.ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fichier))

            item.ImageIndex = 0

            Dim unused = Main.ListView1.Items.Add(item)
        Next

        Main.ListView1.Refresh()
        Button5_Click(Button5, Nothing)

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        ' Masquer la fenêtre actuelle
        Visible = False

        ' Afficher le formulaire principal
        Main.Show()

        ' Redémarrer l'application
        Forms.Application.Restart()

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim OpenFileDialog1 As New OpenFileDialog With {
       .InitialDirectory = My.Application.Info.DirectoryPath & "\Librairies\",
       .Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*|Fichiers librairie (*.librairie)|*.librairie|Fichiers zip (*.zip)|*.zip",
       .FilterIndex = 3,
       .RestoreDirectory = True
   }

        Dim result As DialogResult = CType(OpenFileDialog1.ShowDialog(), DialogResult)

        If result = CType(True, Global.System.Windows.Forms.DialogResult) Then

            Dim filePathToCompress As String = OpenFileDialog1.FileName

            Dim resultInputBox As String = InputBox("Entrez le nouveau nom du fichier :", "Compresser le fichier", Path.GetFileNameWithoutExtension(filePathToCompress) & ".zip")

            Dim fileName As String = OpenFileDialog1.FileName
            Dim fileExtension As String = Path.GetExtension(fileName)
            Dim fileNameWithoutExtension As String = Path.GetFileNameWithoutExtension(fileName)

            ' Définir le chemin du fichier source.
            Dim FilePath As String = My.Application.Info.DirectoryPath & "\Librairies\" & fileNameWithoutExtension & fileExtension

            ' Définir le chemin du fichier .zip.
            Dim ZipFileName As String = fileNameWithoutExtension & ".zip"

            ' Chemin et nom du fichier .zip à créer.
            Dim ZipFilePath As String = My.Application.Info.DirectoryPath & "\Archives\" & resultInputBox

            ' Vérifier si le fichier .zip existe.
            If File.Exists(ZipFilePath) Then
                ' Fermer le fichier existant s'il est ouvert.
                Using fs As FileStream = File.Open(ZipFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                    ' Le bloc Using assure que le fichier est fermé correctement.
                End Using

                ' Supprimer le fichier existant.
                File.Delete(ZipFilePath)
            End If

            Try
                ' Vérifier si le fichier source existe.
                If File.Exists(FilePath) Then
                    ' Création du fichier .zip à partir du fichier.
                    Using archive As ZipArchive = ZipFile.Open(ZipFilePath, ZipArchiveMode.Create)
                        Dim unused1 = archive.CreateEntryFromFile(FilePath, Path.GetFileName(FilePath), CompressionLevel.Fastest)
                    End Using

                    ' Autres actions après la création du fichier .zip
                    ' ...

                    ' Afficher le message de succès.
                    Dim unused2 = MessageBox.Show("L'exécution du processus est terminée.")
                Else
                    ' Afficher un message si le fichier source n'existe pas.
                    Dim unused = MessageBox.Show("Le fichier source n'existe pas : " & FilePath)
                End If

            Catch ex As Exception
                ' Afficher le message d'erreur en cas d'exception.
                Dim unused3 = MessageBox.Show($"Une erreur s'est produite : {ex.Message}")
            End Try
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If MessageBox.Show("Voulez-vous vraiment fermer le formulaire ?", "Confirmation", CType(MessageBoxButtons.YesNo, MessageBoxButton)) = DialogResult.Yes Then
            Dispose(False)
        Else
            ' Annuler la fermeture du formulaire.
            Return
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If ListBox1.SelectedItem Is Nothing Then
            Dim dialogResult1 = MessageBox.Show("Veuillez sélectionner un fichier.")

            Return ' La procédure se termine ici.

        End If

        ' Obtenir le chemin du fichier à partir de la sélection de la zone de liste.
        Dim FilePath = ListBox1.SelectedItem.ToString

        ' Vérifiez que le fichier n'a pas été supprimé depuis que le bouton Parcourir a été cliqué.
        If Not File.Exists(FilePath) Then
            Dim dialogResult1 = MessageBox.Show("Fichier non trouvé : " & FilePath)

            Return

        End If

        ' Obtenir des informations sur le fichier dans une chaîne.
        Dim fileInfoText As String = GetTextForOutput(FilePath)

        ' Afficher les informations du fichier.
        Dim dialogResult2 = MessageBox.Show(fileInfoText)

        If CheckBox1.Checked Then

            ' Ajouter du texte au fichier journal.
            Dim logText As String = "Enregistré le : " & Date.Now.ToString &
            vbCrLf & fileInfoText & vbCrLf & vbCrLf
            Dim logFolder As String = $"{My.Application.Info.DirectoryPath}\Resources"
            Dim logFilePath As String = Path.Combine(logFolder, "log.txt")

            File.AppendAllText(logFilePath, logText)

            Dim destinationPath As String = My.Application.Info.DirectoryPath & "\Resources\log.txt"

            If Not File.Exists(destinationPath) Then
                Computer.FileSystem.MoveFile(logFilePath, destinationPath)
            Else
                ' Gérer le cas où le fichier de destination existe déjà
                Dim unused2 = MessageBox.Show("Le fichier de destination existe déjà.", "Avertissement", CType(MessageBoxButtons.OK, MessageBoxButton), CType(MessageBoxIcon.Warning, MessageBoxImage))
            End If

            ' Le fichier de destination existe, comparez les contenus.
            Dim sourceContent As String = File.ReadAllText(logFilePath)
            Dim destinationContent As String = File.ReadAllText(destinationPath)

            If sourceContent <> destinationContent Then
                ' Les contenus sont différents, remplacez le contenu du fichier de destination.
                File.WriteAllText(destinationPath, sourceContent)
                Dim unused = MessageBox.Show("Le contenu du fichier a été mis à jour.", "Information", CType(MessageBoxButtons.OK, MessageBoxButton), CType(MessageBoxIcon.Information, MessageBoxImage))
            Else
                ' Les contenus sont identiques, vous n'avez peut-être rien à faire ici.
                Dim unused1 = MessageBox.Show("Les contenus des fichiers sont identiques.", "Information", CType(MessageBoxButtons.OK, MessageBoxButton), CType(MessageBoxIcon.Information, MessageBoxImage))
            End If
        End If

        Button7.Enabled = False
        CheckBox1.Enabled = False

    End Sub

End Class