Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows

Public Class Create

    Public Declare Function PathFileExists Lib "shlwapi.dll" Alias "PathFileExistsA" (pszPath As String) As Long
    Public Property CursorsWaitCursor As Cursor
    Public Property Path As String
    Public Property StrShortPath As String
    Public Property Extension As String
    Public Property Library As String
    Public Property GetExtension As String
    Public Property FullPath As String
    Public Property Ligne As Integer
    Public Property NumberOfLine As Integer
    Private WithEvents CreateFileButton As New Button

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim PathLibrairies As String

        Cursor = CursorsWaitCursor

        StrShortPath = My.Application.Info.DirectoryPath

        Label1.Text = StrShortPath & "\Librairies"
        PathLibrairies = Label1.Text

        Button2.Enabled = False
        Button5.Enabled = False
        Button4.Enabled = False
        Button7.Enabled = False

        Initialise()
        Path = Label1.Text

        Dim columnHeader = ListView1.Columns.Add("Librairies ", 200, CType(HorizontalAlignment.Left, Forms.HorizontalAlignment))
        ListView1.View = Forms.View.Details
        ListView1.GridLines = True
        Dim columnHeader1 = ListView1.Columns.Add("Taille", 125, CType(HorizontalAlignment.Left, Forms.HorizontalAlignment))
        Dim columnHeader2 = ListView1.Columns.Add("Date de création", 150, CType(HorizontalAlignment.Left, Forms.HorizontalAlignment))

        ExtractAssociatedIcon()

        Dim comptage As Integer = ListView1.Items.Count

        Select Case ListView1.Items.Count

            Case 0
                TabPage1.Text = " Aucun fichier de données "

            Case 1
                TabPage1.Text = comptage & " fichier de données "

            Case Else
                TabPage1.Text = comptage & " fichiers de données "
        End Select

        ListView1.ShowItemToolTips = True
        For Each item As ListViewItem In ListView1.Items
            item.ToolTipText = item.Text
        Next

        Button5.Enabled = False

        Cursor = Cursors.Default

    End Sub

    Private Sub Initialise()

        ListView1.Items.Clear()
        ListView1.ArrangeIcons()

        ListView1.SmallImageList = Nothing
        ImageList1.Images.Clear()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If ListView1.SelectedItems.Count > 0 Then
            ' Obtenir l'élément sélectionné.
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            ' Obtenir le chemin d'accès complet du fichier à partir de Text.
            Dim fullPath As String = selectedItem.Text

            ' Obtenir le nom du fichier sans le chemin d'accès.
            Dim fileName As String = IO.Path.GetFileName(fullPath)

            ' Obtenir l'extension du fichier.
            Dim fileExtension As String = IO.Path.GetExtension(fullPath)

            ' Exemple d'utilisation : Afficher le nom et l'extension dans une MessageBox.
            Dim unused3 = MessageBox.Show(messageBoxText:=$"Nom du fichier : {fileName}{Environment.NewLine}Extension du fichier : {fileExtension}")
        End If

        Dim unused4 = MessageBox.Show(ListView1.SelectedItems(0).Text)
        Dim sFichier As String = ListView1.SelectedItems(0).Text

        If ListView1.SelectedItems.Count = 0 Then
            Dim msgBoxResult = MsgBox("Vous devez sélectionner un élément pour pouvoir le supprimer !", CType(vbYes, MsgBoxStyle), My.Application.Info.Title)
        Else

            sFichier = ListView1.SelectedItems(0).Text

            Try
                Using fs As New StreamWriter(My.Application.Info.DirectoryPath & "\Resources\ListView.txt")
                    For Each lvi As ListViewItem In ListView1.Items
                        Dim line As String = ""
                        For Each item As ListViewItem.ListViewSubItem In lvi.SubItems
                            line &= item.Text & "|"
                        Next
                        line = line.Remove(line.Length - 1, 1)
                        fs.WriteLine(line)
                    Next
                End Using

            Catch ex As IOException
                Dim msgBoxResult1 = MsgBox("""" & sFichier & """ déjà ouvert" & Environment.NewLine & ex.Message)
            Catch ex As Exception
                Dim dialogResult1 = MessageBox.Show("Erreur inconnue" & Environment.NewLine & ex.Message)
            End Try

            Dim NumeroDeLigne As Integer
            NumeroDeLigne = ListView1.SelectedIndices(0)

            Dim filePath As String = IO.Path.Combine(StrShortPath, "Librairies", sFichier)

            Try
                Computer.FileSystem.DeleteFile(filePath,
            FileIO.UIOption.AllDialogs,
                    FileIO.RecycleOption.SendToRecycleBin,
            FileIO.UICancelOption.DoNothing)

            Catch ex As Exception
                ' Gérer l'exception ici.
                Dim unused = MessageBox.Show($"Une erreur s'est produite lors de la suppression du fichier : {ex.Message}")
            End Try

        End If

        ' Afficher un message de succès.
        Dim unused2 = MsgBox($"Le fichier {IO.Path.GetFileName(FullPath)} a été supprimé avec succès.", MsgBoxStyle.Information, My.Application.Info.Title)

        Button6_Click(Button6, Nothing)
        TextBox1.Text = ""

        ImageList1.Images.Add("librairie.ico", Icon.ExtractAssociatedIcon("C:\Prenommer\librairie.ico"))

        ' Supprimer tous les éléments sélectionnés du ListView dans le formulaire Create.
        For Each selectedItem As ListViewItem In ListView1.SelectedItems
            selectedItem.Remove()
        Next

        ' Supprimer tous les éléments du ListView dans le formulaire principal (Main).
        Main.ListView1.Items.Clear()

        ' Parcourir les éléments du ListView dans le formulaire Create.
        For Each item As ListViewItem In ListView1.Items
            ' Ajouter un nouvel élément à Main.ListView1 avec les mêmes données.
            Dim newItem As New ListViewItem(item.Text)
            newItem.SubItems.AddRange(item.SubItems.Cast(Of ListViewItem.ListViewSubItem)().Select(Function(subItem) subItem.Text).ToArray())

            ' Attribuer une icône à l'élément.
            newItem.ImageKey = "librairie.ico" ' Utilisez le nom de l'image dans l'ImageList.

            ' Ajouter l'élément à Main.ListView1.
            Dim unused1 = Main.ListView1.Items.Add(newItem)
        Next

        ' Rafraîchir le ListView dans le formulaire principal.
        Main.ListView1.Refresh()

        Main.ToolStripStatusLabel1.Text = Main.ListView1.Items.Count & " librairies chargées"

        Dim comptage As Integer = ListView1.Items.Count
        Select Case ListView1.Items.Count

            Case 0
                TabPage1.Text = " Aucun fichier de données "

            Case 1
                TabPage1.Text = comptage & " fichier de données "

            Case Else
                TabPage1.Text = comptage & " fichiers de données "

        End Select

        Main.Visible = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' Copier la collection des formulaires ouverts.
        Dim formsToClose As New List(Of Form)
        For Each form As Form In My.Application.OpenForms
            formsToClose.Add(form)
        Next

        ' Boucler à travers tous les formulaires copiés.
        For Each form As Form In formsToClose
            ' Vérifier si le formulaire est de type "Create".
            If TypeOf form Is Create Then
                ' Fermer le formulaire.
                form.Close()
            End If
        Next

        ' Montrer le formulaire principal.
        Main.Visible = True

        ' Mettre le formulaire principal au premier plan.
        Main.BringToFront()

    End Sub

    Public Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        Button4.Enabled = True
        If ListView1.SelectedItems.Count > 0 Then
            Label1.Text = StrShortPath & "\Librairies"
            Label5.Text = ListView1.SelectedItems(0).Text
            RichTextBox1.Text = ""
            Button2.Enabled = True
            Button7.Enabled = True
        End If

        ' On verifie d'abord s'il y a eu une ligne selectionnée.
        If ListView1.SelectedIndices.Count > 0 Then

            Ligne = CInt(ListView1.SelectedIndices(0).ToString()) ' Recuperation de la ligne selectionnée.

            ' Récuperation de données se trouvant dans la première colonne et le mettre dans mon textbox1.
            TextBox1.Text = ListView1.Items(Ligne).SubItems(0).Text

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim msgBoxResult = MsgBox("Actualisation des données")

        Initialise()

        If MsgBox("Fichiers des librairies actualisés (" & ListView1.Items.Count & " médias) !", CType(vbYes + vbDirectory, Global.Microsoft.VisualBasic.MsgBoxStyle), My.Application.Info.Title) = vbYes Then
            System.Threading.Thread.Sleep(500)
        End If

        ListView1.BeginUpdate()
        ListView1.Items.Clear()
        If Not Computer.FileSystem.FileExists(Path) Then
            For Each fileName As String In Directory.GetFiles(Path)
                ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName))
                Dim listViewItem = ListView1.Items.Add(IO.Path.GetFileName(fileName), 0)
            Next
        End If
        ListView1.EndUpdate()

        ExtractAssociatedIcon()
        ListView1.Refresh()

        TextBox1.Text = ""

        Label1.Text = StrShortPath & "\Librairies"
        Button5.Enabled = True
        Button7.Enabled = True
        Button2.Enabled = False

        Main.Visible = True

    End Sub

    Public Sub ExtractAssociatedIcon()

        Button6.Enabled = True
        ImageList1.Images.Clear()
        ListView1.SmallImageList = ImageList1

        Dim dirInfo As DirectoryInfo
        Dim fileInfo As FileInfo

        ListView1.BeginUpdate()
        ListView1.Items.Clear()

        dirInfo = New DirectoryInfo(StrShortPath & "\Librairies")

        For Each fileInfo In dirInfo.GetFiles
            If Not String.IsNullOrEmpty(fileInfo.Extension) Then

                ' Ajouter l'icône à l'ImageList et obtenir l'index.
                Dim iconIndex As Integer = AddIconToImageList(fileInfo.FullName)

                Dim listViewItem = ListView1.Items.Add(fileInfo.Name, iconIndex)
                Dim listViewSubItem = listViewItem.SubItems.Add(fileInfo.Length & " octets")
                Dim listViewSubItem1 = listViewItem.SubItems.Add(fileInfo.CreationTime.ToString())
            End If
        Next

        ListView1.Sorting = SortOrder.Ascending
        ListView1.EndUpdate()

    End Sub

    Public Function AddIconToImageList(filePath As String) As Integer

        Try
            Dim defaultIcon As Icon = IconExtractor.GetDefaultIcon()

            If defaultIcon IsNot Nothing Then

                ' Ajouter l'icône à l'ImageList et renvoyer l'index.
                ImageList1.Images.Add(defaultIcon.ToBitmap())
                Return ImageList1.Images.Count - 1
            Else
                ' Retourner un index d'image par défaut si l'icône n'est pas disponible.
                Return 0
            End If
        Catch ex As Exception
            ' En cas d'erreur, retourner un index d'image par défaut.
            Return 0
        End Try

    End Function

    Public Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If ListView1.SelectedItems.Count = 0 Then
            Dim msgBoxResult1 = MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", CType(vbYes, MsgBoxStyle), "Erreur")
            Exit Sub

        Else

            If ListView1.SelectedItems.Count > 0 Then
                ChercheItem = ListView1.SelectedItems(0).Text
            End If

            Dim ArticleRecherché As String
            ArticleRecherché = IO.Path.GetFileNameWithoutExtension(ChercheItem)
            Dim msgBoxResult1 = MsgBox(ArticleRecherché)

            If CBool(PathFileExists(StrShortPath & "\Index\" & ArticleRecherché & ".article")) Then
                Dim msgBoxResult = MsgBox("L'objet " & ArticleRecherché & ".article" & " est un réperoire ou fichier valide")
                Exit Sub
            Else

                NumberOfLine = ListView1.SelectedIndices(0)

                Dim Msg As String, Style, Title As String, Response As Double, MyString As String
                Msg = "Indexer le fichier ?" & ListView1.Items(ListView1.FocusedItem.Index).Text & " ?"
                Style = CStr(vbYesNo + vbCritical + vbDefaultButton2)
                Title = My.Application.Info.Title
                Response = CDbl(CStr(MsgBox(Msg, CType(Style, MsgBoxStyle), Title)))
                MyString = If(Response = vbYes, "Oui", "Non")

                If MyString Is "Oui" Then
                    Cursor = Cursors.WaitCursor

                    If Not Computer.FileSystem.DirectoryExists("Index") Then
                        Computer.FileSystem.CreateDirectory("Index")
                    End If

                    Dim fileWExt As String = IO.Path.GetFileNameWithoutExtension(ListView1.Items(ListView1.FocusedItem.Index).Text)

                    Dim path As String = StrShortPath & "\Index\" & fileWExt & ".article"
                    Dim fs As FileStream = File.Create(path)
                    fs.Close()

                    Dim msgBoxResult = MsgBox("Fichier article créé !")

                    Dim resultat As String
                    Main.ToolStripComboBox1.Items.Clear()
                    Dim fileNames = Computer.FileSystem.GetFiles(StrShortPath & "\Index\", FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                    For Each fileName As String In fileNames
                        resultat = IO.Path.GetFileName(fileName)
                        Dim v = Main.ToolStripComboBox1.Items.Add(resultat)
                    Next

                    Button7.Enabled = False

                    Dim ContrôleLV As ListView = Main.ListView1

                    Dim index As Integer
                    If ListView1.SelectedIndices.Count <> 0 Then
                        index = ListView1.SelectedIndices(0)
                        Dim dialogResult1 = MessageBox.Show(index.ToString)
                    End If

                    selectionné = ListView1.Items(ListView1.FocusedItem.Index).Text

                    If ListView1.Items(Ligne).Selected Then
                        Dim listViewSubItem = ContrôleLV.Items(Main.ListView1.Items.Count - 1).SubItems.Add(selectionné)
                    End If
                    Dim msgBoxResult2 = MsgBox(Ligne)
                    ContrôleLV.Refresh()

                    TextBox1.Text = ""

                    Cursor = Cursors.Default

                ElseIf MyString Is "Non" Then
                    Exit Sub

                End If
            End If
        End If

        Button2.Enabled = True
        Cursor = Cursors.Default

    End Sub

    Public Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Cursor = Cursors.WaitCursor
        Try
            Dim chaine As String = TextBox1.Text

            Using sw As New StreamWriter(My.Application.Info.DirectoryPath & "\Resources\ListView.txt")
                For Each lvi As ListViewItem In ListView1.Items
                    Dim line As String = ""
                    For Each item As ListViewItem.ListViewSubItem In lvi.SubItems
                        line &= item.Text & "|"
                    Next
                    line = line.Remove(line.Length - 1, 1)
                    sw.WriteLine(line)
                Next
            End Using

            Button7.Enabled = True
            Dim msgBoxResult = MsgBox(chaine.Length, CType(vbYes, MsgBoxStyle), "Longueur de chaîne de caractères")
            If chaine.Length < 11 Then
                TextBox1.Text = ""
                Exit Sub
            End If

            If Not GetIsValidName(chaine) Then
                Dim msgBoxResult1 = MsgBox("NOM DU FICHIER INVALIDE !")
                Exit Sub
            End If

            If chaine.Substring(chaine.Length - 10) = ".librairie" Then
                GetExtension = "librairie"

            ElseIf chaine.Substring(chaine.Length - 10) <> ".librairie" Then

                Dim msgBoxResult1 = MsgBox("Nommage .librairie de l'extension du fichier !")
                Dim Nouveau As String = IO.Path.GetExtension(chaine)
                Dim FullPath As String = chaine
                Dim fileName As String = IO.Path.GetFileNameWithoutExtension(FullPath)

                FullPath = fileName & ".librairie"
                TextBox1.Text = FullPath

            End If

            Cursor = Cursors.Default

            If FileExists(Path & "\" & chaine) Then
                Const Prompt As String = "Le nom du fichier à créer existe déjà !"
                Dim msgBoxResult1 = MsgBox(Prompt)

                Cursor = Cursors.WaitCursor

                TextBox1.Text = ""
                Dim v = TextBox1.Focus()
                TextBox1.Select()
                Exit Sub

            Else

                Dim msgBoxResult1 = MsgBox("Le fichier n'existe pas !")
                Dim listViewItem = ListView1.Items.Add(TextBox1.Text)

                Dim path As String = My.Application.Info.DirectoryPath & "\Librairies\"
                Dim msgBoxResult2 = MsgBox(path & FullPath)

                Dim NewFile As String = $"{path}{TextBox1.Text}"

                If Not File.Exists(NewFile) Then
                    Using sw As New StreamWriter(NewFile, True, Encoding.UTF8)
                        ListView1.EnsureVisible(ListView1.Items.Count - 1)
                    End Using
                End If

                File.WriteAllText(NewFile, Regex.Replace(File.ReadAllText(NewFile), "(?m)^\s+^", ""))

                Button5.Enabled = False
                Button6.Enabled = True
                Library = TextBox1.Text
                Extension = GetExtension

                Button6.PerformClick()

                ImageList1.Images.Add("librairie.ico", Icon.ExtractAssociatedIcon("C:\Prenommer\librairie.ico"))

                ' Supprimer tous les éléments du ListView dans le formulaire principal (Main).
                Main.ListView1.Items.Clear()

                ' Parcourir les éléments du ListView dans le formulaire actuel.
                For Each item As ListViewItem In ListView1.Items

                    ' Ajouter un nouvel élément à Main.ListView1 avec les mêmes données.
                    Dim newItem As New ListViewItem(item.Text)
                    newItem.SubItems.AddRange(item.SubItems.Cast(Of ListViewItem.ListViewSubItem)().Select(Function(subItem) subItem.Text).ToArray())

                    ' Attribuer une icône à l'élément.
                    newItem.ImageKey = "librairie.ico" ' Utilisez le nom de l'image dans l'ImageList.

                    ' Ajouter l'élément à Main.ListView1.
                    Dim unused1 = Main.ListView1.Items.Add(newItem)
                Next

                ' Rafraîchir le ListView dans le formulaire principal.
                Main.ListView1.Refresh()

                TextBox1.Text = ""
                Main.ToolStripStatusLabel1.Text = Main.ListView1.Items.Count & " librairies chargées"

                Dim comptage As Integer = ListView1.Items.Count
                Select Case ListView1.Items.Count

                    Case 0
                        TabPage1.Text = " Aucun fichier de données "

                    Case 1
                        TabPage1.Text = comptage & " fichier de données "

                    Case Else
                        TabPage1.Text = comptage & " fichiers de données "
                End Select

            End If

            ListView1.Sorting = SortOrder.Ascending
            Button7.Enabled = False

        Catch ex As Exception
            ' Gérer l'exception.
            Dim unused = MessageBox.Show(ex.Message, Text, CType(MessageBoxButtons.OK, MessageBoxButton), CType(MessageBoxIcon.Error, MessageBoxImage))
        Finally
            ' Assurez-vous que le curseur est remis à sa valeur par défaut.
            Cursor = Cursors.Default
        End Try

        'Main.UpdateForm()

        Main.Visible = True

    End Sub

    Public Function FileExists(sSource As String) As Boolean

        FileExists = PathFileExists(sSource) = 1

    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Button5.Enabled = True
        If TextBox1.Text = "" Then Button5.Enabled = False

    End Sub

    Private Function GetIsValidName(strFileName As String) As Boolean

        Dim lngI As Long
        Const strInterdit As String = "\/:*?""<>|"

        For lngI = 1 To Len(strInterdit)
            If CBool(InStr(strFileName, Mid$(strInterdit, CInt(lngI), &H1))) Then
                GetIsValidName = True
                Exit For
            End If
        Next lngI
        GetIsValidName = Not GetIsValidName

    End Function

    Private Sub GroupBox1_Paint(sender As Object, e As PaintEventArgs) Handles GroupBox1.Paint

        Dim g As Graphics = e.Graphics
        Dim pen As New Pen(Color.LightGray, 2.0)

        g.DrawRectangle(pen, New Drawing.Rectangle(TextBox1.Location,
                     TextBox1.Size))
        pen.Dispose()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim tmpContenu As String = ""

        For Each I As ListViewItem In ListView1.Items
            tmpContenu = tmpContenu & I.Text & vbCrLf
        Next

        RichTextBox1.Text = tmpContenu

        Dim TextRecherche As String = Label5.Text

        RichTextBox1.WordWrap = False
        RichTextBox1.SelectAll()
        RichTextBox1.SelectionBackColor = RichTextBox1.BackColor

        Dim indexof As Integer = RichTextBox1.Find(TextRecherche,
        RichTextBoxFinds.WholeWord)
        If indexof >= 0 Then
            Dim idxline As Integer = RichTextBox1.GetLineFromCharIndex(indexof)
            RichTextBox1.SelectionStart = indexof
            RichTextBox1.SelectionLength = RichTextBox1.Lines(idxline).Length
            RichTextBox1.SelectionBackColor = Color.Yellow
        End If

        Dim message, title, defaultValue As String
        Dim myValue As Object

        message = "Entrez une valeur avec extension (.librairie)"

        title = "Zone de saisie"
        defaultValue = ".librairie"

        myValue = InputBox(message, title, defaultValue)
        If myValue Is "" Then
            Exit Sub
        End If

        Dim fileExtension As String = IO.Path.GetExtension(CStr(myValue))
        If fileExtension <> ".librairie" Then
            Dim msgBoxResult = MsgBox("L’extension de nom de fichier ne correspond pas au format de fichier réel. Le fichier a une extension de nom de fichier .librairie")
            Exit Sub
        End If

        Dim fileWExt As String = IO.Path.GetFileNameWithoutExtension(CStr(myValue))
        If fileWExt = "" Then Exit Sub
        If FileExists(CStr(myValue)) Then Exit Sub

        If Not GetIsValidName(CStr(myValue)) Then Exit Sub

        ' Renommer le fichier.
        Computer.FileSystem.RenameFile(StrShortPath & "\Librairies\" & Label5.Text, CStr(myValue))

        ' Mettre à jour le texte de l'élément sélectionné dans le formulaire Create.
        For Each item As ListViewItem In ListView1.Items
            If item.Text = Label5.Text Then
                item.Text = CStr(myValue)
                Exit For
            End If
        Next

        Button6_Click(Button6, Nothing)
        RichTextBox1.Text = ""

        ImageList1.Images.Add("librairie.ico", Icon.ExtractAssociatedIcon("C:\Prenommer\librairie.ico"))

        ' Supprimer tous les éléments du ListView dans le formulaire principal (Main).
        Main.ListView1.Items.Clear()

        'Parcourir les éléments du ListView dans le formulaire actuel.
        For Each item As ListViewItem In ListView1.Items

            ' Ajouter un nouvel élément à Main.ListView1 avec les mêmes données.
            Dim newItem As New ListViewItem(item.Text)
            newItem.SubItems.AddRange(item.SubItems.Cast(Of ListViewItem.ListViewSubItem)().Select(Function(subItem) subItem.Text).ToArray())

            ' Attribuer une icône à l'élément.
            newItem.ImageKey = "librairie.ico" ' Utilisez le nom de l'image dans l'ImageList.

            ' Ajouter l'élément à Main.ListView1.
            Dim unused1 = Main.ListView1.Items.Add(newItem)
        Next

        ' Rafraîchir le ListView dans le formulaire principal.
        Main.ListView1.Refresh()

        TextBox1.Text = ""
        Main.ToolStripStatusLabel1.Text = Main.ListView1.Items.Count & " librairies chargées"

        Dim comptage As Integer = ListView1.Items.Count
        Select Case ListView1.Items.Count

            Case 0
                TabPage1.Text = " Aucun fichier de données "

            Case 1
                TabPage1.Text = comptage & " fichier de données "

            Case Else
                TabPage1.Text = comptage & " fichiers de données "
        End Select

        Main.Visible = True

    End Sub

    Public Function IsValidFileNameOrPath(name As String) As Boolean

        ' Détermine si le nom est Nothing.
        If name Is Nothing Then
            Return False
        End If

        ' Détermine s'il y a de mauvais caractères dans le nom.
        For Each badChar As Char In IO.Path.GetInvalidPathChars
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next

        ' Le nom passe la validation de base.
        Return True

    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim LibrairiesPath As String = My.Application.Info.DirectoryPath & "\Librairies\"

        ' Vérifier s'il y a un élément sélectionné dans le formulaire Create.
        If ListView1.SelectedItems.Count > 0 Then

            ' Récupérer l'élément sélectionné dans le formulaire Create.
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            ' Demander à l'utilisateur le dossier de destination.
            Dim destinationFolder As String = ""
            Using folderBrowser As New FolderBrowserDialog()
                If folderBrowser.ShowDialog() = DialogResult.OK Then
                    destinationFolder = folderBrowser.SelectedPath
                Else
                    Exit Sub ' L'utilisateur a annulé la sélection du dossier.
                End If
            End Using

            ' Construire le chemin du fichier source.
            Dim sourceFilePath As String = LibrairiesPath & "\" & selectedItem.Text

            ' Construire le chemin du fichier de destination.
            Dim destinationFilePath As String = destinationFolder & "\" & selectedItem.Text

            ' Déplacer le fichier.
            Try
                File.Move(sourceFilePath, destinationFilePath)

                ' Supprimer l'élément du ListView dans le formulaire Main.
                Dim itemToRemove As ListViewItem = Main.ListView1.Items.Cast(Of ListViewItem)().FirstOrDefault(Function(item) item.Text = selectedItem.Text)
                If itemToRemove IsNot Nothing Then
                    Main.ListView1.Items.Remove(itemToRemove)
                End If

                ' Supprimer l'élément du ListView dans le formulaire Create.
                ListView1.Items.Remove(selectedItem)

                If Not Computer.FileSystem.FileExists(LibrairiesPath) Then
                    For Each fileName As String In Directory.GetFiles(LibrairiesPath)
                        ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName))
                        Dim listViewItem = ListView1.Items.Add(IO.Path.GetFileName(fileName), 0)
                    Next
                End If

                Button6.PerformClick()
                TextBox1.Text = ""

                For i As Integer = 0 To Main.ListView1.Items.Count - 1
                    Main.ListView1.Items(i).BackColor = If(CBool(i Mod 2), Color.LightBlue, Color.White)
                Next

                Main.ToolStripStatusLabel1.Text = ListView1.Items.Count & " librairies chargées"
                Dim comptage As Integer = ListView1.Items.Count
                Select Case ListView1.Items.Count

                    Case 0
                        TabPage1.Text = " Aucun fichier de données "

                    Case 1
                        TabPage1.Text = comptage & " fichier de données "

                    Case Else
                        TabPage1.Text = comptage & " fichiers de données "

                End Select

                Main.Visible = True

            Catch ex As Exception
                ' Gérer les erreurs de déplacement de fichier.
                Dim unused = MessageBox.Show("Erreur lors du déplacement du fichier : " & ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        Else
            ' Aucun élément sélectionné dans le formulaire Create.
            Dim unused1 = MessageBox.Show("Aucun fichier sélectionné.", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning)
        End If

    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView1.DrawItem

        e.DrawDefault = True

        If e.ItemIndex Mod 2 = 1 Then
            e.Item.BackColor = Color.FromArgb(230, 230, 255)
            e.Item.UseItemStyleForSubItems = True
        End If

    End Sub

    Private Sub ListView1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader

        e.DrawDefault = True

    End Sub

    Public Sub SetFileIconAssociation(extension As String, iconPath As String, iconIndex As Integer)

        ' Exemple de clé de registre pour .librairie.
        Dim keyPath As String = $"Software\Classes\.librairie\DefaultIcon"

        ' Modifier la clé du registre pour définir l'icône.
        Computer.Registry.SetValue(keyPath, "", $"{iconPath},{iconIndex}")

    End Sub

    Public Sub CreateFileButton_Click(sender As Object, e As EventArgs) Handles CreateFileButton.Click

        ' Votre code pour créer le fichier.
        Button5.PerformClick()

        ' Spécifiez le motif du nom du fichier (avec le caractère générique *).
        Dim filePattern As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "Librairies", "*.librairie")

        ' Recherchez tous les fichiers correspondant au motif dans le répertoire.
        Dim matchingFiles() As String = Directory.GetFiles(IO.Path.GetDirectoryName(filePattern), IO.Path.GetFileName(filePattern))

        If matchingFiles.Length > 0 Then
            ' Ajoutez chaque fichier correspondant à la liste partagée.
            For Each filePath As String In matchingFiles
                FileListManager.AddFile(filePath)

                ' Associez l'icône à l'extension .librairie.
                SetFileIconAssociation(".librairie", "C:\Prenommer\librairie.ico", 0)

                ' Ajoutez l'élément au ListView1 de CreateForm avec le nom du fichier comme texte.
                Dim newItem As New ListViewItem(IO.Path.GetFileName(filePath))
                Dim unused = ListView1.Items.Add(newItem)

                ' Mise à jour du ListView1 dans MainForm.
                Dim mainFormInstance As New Main()
                mainFormInstance.UpdateFileList()
            Next
        Else
            Dim unused1 = MessageBox.Show("Aucun fichier correspondant trouvé.")
        End If

    End Sub

    ' Fonction pour créer le fichier texte des fichiers librairie.
    Public Sub CreateLibrairieFileList()

        ' Arrêter l'application immédiatement.
        Environment.Exit(0)

        ' Spécifiez le répertoire où se trouvent les fichiers librairie.
        Dim directoryPath As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "Librairies")

        ' Vérifiez si le répertoire existe.
        If Not Directory.Exists(directoryPath) Then
            ' Affichez un message si le répertoire n'existe pas.
            Dim unused1 = MessageBox.Show($"Le répertoire {directoryPath} n'existe pas.", "Répertoire inexistant", CType(MessageBoxButtons.OK, MessageBoxButton), CType(MessageBoxIcon.Information, MessageBoxImage))
            Return
        End If

        ' Obtenez la liste des fichiers avec l'extension .librairie dans le répertoire.
        Dim librairieFiles As String() = Directory.GetFiles(directoryPath, "*.librairie")

        ' Vérifiez si des fichiers .librairie existent.
        If librairieFiles.Length = 0 Then
            ' Affichez un message si aucun fichier .librairie n'est trouvé.
            Dim unused = MessageBox.Show($"Aucun fichier .librairie trouvé dans {directoryPath}.", "Aucun fichier trouvé", CType(MessageBoxButtons.OK, MessageBoxButton), CType(MessageBoxIcon.Information, MessageBoxImage))
            Return
        End If

        ' Spécifiez le chemin complet pour le fichier texte.
        Dim filePath As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources", "LibFileList.txt")

        ' Créez un objet StreamWriter pour écrire dans le fichier.
        Using writer As New StreamWriter(filePath)
            ' Parcourez la liste des fichiers .librairie.
            For Each librairieFile As String In librairieFiles
                ' Ajoutez le nom du fichier à la liste.
                writer.WriteLine(IO.Path.GetFileName(librairieFile))
            Next
        End Using

        ' Affichez un message pour indiquer que la création du fichier est terminée.
        Dim unused2 = MessageBox.Show($"La liste des fichiers librairie a été enregistrée dans {filePath}", "Fichier créé", CType(MessageBoxButtons.OK, MessageBoxButton), CType(MessageBoxIcon.Information, MessageBoxImage))

    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click

        If ListView1.SelectedItems.Count > 0 Then
            ' Récupérer l'élément sélectionné.
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            ' Afficher le texte de l'élément dans une boîte de message.
            TextBox1.Clear()
            Dim unused = MessageBox.Show("Élément sélectionné : " & selectedItem.Text)
        End If

    End Sub

End Class