Imports System.IO
Imports System.Windows.Forms.ListViewItem
Imports Path = System.IO.Path

Public Class Find

    Private fileName As String
    Public Property ListViewSubItem As ListViewSubItem
    Public Property Bytes As Double
    Public Property TaillesEnKo As New List(Of Integer)()
    Public Property TailleEnOctets As Long
    Public Property Taille As New List(Of String)
    Public Property PositionsStr As String
    Public Property Offsets As New List(Of Integer)
    Public Property LineNo As Integer

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView.Click

        Dim list As New List(Of String)

        'Chemin du répertoire "Librairies".
        Dim directoryPath As String = My.Application.Info.DirectoryPath & "\Librairies\"

        'Obtenir la liste de tous les fichiers dans le répertoire.
        Dim fileNames As String() = Directory.GetFiles(directoryPath)

        For Each fileName As String In fileNames
            Dim reader As New StreamReader(fileName, System.Text.Encoding.UTF8)

            'Lire le contenu du fichier ligne par ligne et l'ajouter à la liste.
            Dim line As String = reader.ReadLine
            Do While line IsNot Nothing
                list.Add(line)
                'Afficher le contenu de chaque ligne dans une boîte de message.
                line = reader.ReadLine
            Loop

            reader.Close()
            reader.Dispose()
        Next

        Dim searchWord As String = Trim(TextBox1.Text)

        If TaillesEnKo.Count > 0 Then
            'Afficher les positions trouvées.
            Dim PositionsStr As String = String.Join(", ", TaillesEnKo)
            Dim msgBoxResult = MsgBox("Le prénom " & searchWord & " a été trouvé.")
        Else
            Dim msgBoxResult = MsgBox("Le prénom '" & searchWord & "' n'a pas été trouvé dans le tableau.")
        End If

    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ListView.Items.Clear()

        Try

            Cursor = Cursors.WaitCursor

            'Chemin du répertoire "Librairies".
            Dim directoryPath As String = My.Application.Info.DirectoryPath & "\Librairies\"

            If Not String.IsNullOrWhiteSpace(Trim(TextBox1.Text)) Then
                Dim matches As String = Trim(TextBox1.Text)
                Dim list As ObjectModel.ReadOnlyCollection(Of String)

                list = Computer.FileSystem.FindInFiles(directoryPath, matches, True, FileIO.SearchOption.SearchTopLevelOnly)

                'Vérifier si la liste ne contient pas d'éléments
                If list.Count = 0 Then
                    Dim dialogResult1 = MessageBox.Show("Le prénom recherché n'a pas été trouvé dans les fichiers.", "Aucun résultat")
                    Button2.PerformClick()
                End If

                If list.Count > 0 Then
                    Dim c As Integer = 1
                    Dim i As Integer

                    For Each fileName In list

                        Dim ByteBuffer As Byte() = File.ReadAllBytes(fileName)
                        Dim StringBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(matches)

                        For i = 0 To ByteBuffer.Length - StringBytes.Length
                            If ByteBuffer(i) = StringBytes(0) Then
                                Dim j As Integer = 1

                                While j < StringBytes.Length AndAlso ByteBuffer(i + j) = StringBytes(j)
                                    j += 1
                                End While

                                If j = StringBytes.Length Then
                                    'Ajouter toutes les positions en octets.
                                    Offsets.Add(i)
                                End If
                            End If
                        Next
                    Next

                    'Fichier à consulter.
                    Dim searchWord As String = Trim(TextBox1.Text)

                    Dim texte As String = searchWord
                    Dim premiereLettre = texte.Substring(0, 1)
                    Dim src = directoryPath & searchWord.Substring(0, 1) & ".librairie"

                    For k As Integer = 0 To list.Count - 1
                        If list(k).Contains(searchWord) Then
                            'Ajouter l'index à la liste des Tailles.
                            Taille.Add(CStr(k))
                            Dim TailleEnOctets As Long = FileLen(directoryPath & premiereLettre & ".librairie")
                            Dim tailleEnKo As Double = ConvertOctetsToKiloOctets(TailleEnOctets)
                            TaillesEnKo.Add(k)
                        End If
                    Next

                    'Texte à trouver.
                    Dim find = Trim(TextBox1.Text)

                    Dim lineNum = FindLineNumber(src, find, Function(a, b) a.Contains(b))

                    If lineNum > 0 Then
                        Dim unused = MsgBox($"""{find}"" trouvé à la ligne {lineNum}.")
                    Else
                        Dim unused1 = MsgBox($"""{find}"" non trouvé.")
                    End If

                    'Calcul de la somme des positions en octets.
                    Dim totalOffsetSum As Long = 0
                    For Each offset In Offsets
                        totalOffsetSum += offset
                    Next

                    If Offsets.Count > 0 Then
                        Dim listViewItem = ListView.Items.Add(Path.GetFileName(directoryPath & premiereLettre & ".librairie"))
                        Dim fileSizeInBytes As Long = New FileInfo(directoryPath & premiereLettre & ".librairie").Length

                        'Utilisez les sous-colonnes existantes pour afficher les valeurs.
                        Dim listViewSubItem = listViewItem.SubItems.Add(BytesToString(fileSizeInBytes))

                        Dim lignes() As String = File.ReadAllLines(directoryPath & premiereLettre & ".librairie")
                        Dim nLignes = lignes.Length

                        Dim listViewSubItem1 = listViewItem.SubItems.Add(CStr(nLignes))

                        'Calcul de la moyenne des positions en octets.
                        Dim result As Long = CInt(Math.Floor(totalOffsetSum / Offsets.Count / 3188) + 1)

                        'Chemin vers votre fichier texte.
                        Dim filePath As String = My.Application.Info.DirectoryPath & "\Librairies\" & premiereLettre & ".librairie"

                        'Lire toutes les lignes du fichier dans un tableau.
                        Dim lines As String() = File.ReadAllLines(filePath)

                        'Vérifier si la dernière ligne est vide.
                        If lines.Length > 0 AndAlso String.IsNullOrWhiteSpace(lines(lines.Length - 1)) Then
                            Dim listViewSubItem2 = listViewItem.SubItems.Add(CStr(CInt(lineNum.ToString()) - 1))
                            ' Console.WriteLine("La dernière ligne est vide.")
                            Dim unused6 = MessageBox.Show("La dernière ligne est vide.")
                        Else
                            Dim listViewSubItem2 = listViewItem.SubItems.Add(lineNum.ToString())
                            ' Console.WriteLine("La dernière ligne n'est pas vide.")
                            Dim unused7 = MessageBox.Show("La dernière ligne n'est pas vide.")
                        End If

                        c += 1
                    End If

                    c += 1
                End If
            Else
                Dim unused5 = MessageBox.Show("Aucun résultat.")

            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Dim unused2 = MessageBox.Show(ex.Message)
            Dim unused3 = MessageBox.Show("Stack Trace :    " & vbCrLf & ex.StackTrace)
        Finally
            Dim unused4 = MessageBox.Show("L'exécution du processus est terminée.")
        End Try

    End Sub

    Public Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Height = 410
        ListView.Clear()
        Dim columnHeader = ListView.Columns.Add("Noms des fichiers contenant le texte spécifié", 225, HorizontalAlignment.Left)
        Dim columnHeader5 = ListView.Columns.Add("Taille", 100, HorizontalAlignment.Center)
        Dim columnHeader6 = ListView.Columns.Add("Enregistrements", 90, HorizontalAlignment.Center)
        Dim columnHeader7 = ListView.Columns.Add("Positions", 50, HorizontalAlignment.Center)

    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView.DrawItem

        e.DrawDefault = True

        If e.ItemIndex Mod 2 = 1 Then
            e.Item.BackColor = Color.AliceBlue '.FromArgb(230, 230, 255)
            e.Item.UseItemStyleForSubItems = True
        End If

    End Sub

    Private Sub ListView1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView.DrawColumnHeader

        Using sf = New StringFormat()

            sf.Alignment = StringAlignment.Center

            Using headerFont = New Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
                e.Graphics.FillRectangle(Brushes.Lavender, e.Bounds)
                e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf)
            End Using
        End Using

    End Sub

    Private Sub Find_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Mettre le focus sur le TextBox au démarrage de l'application.

        Dim unused = TextBox1.Focus()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ListView.Clear()

        Main.Visible = True
        Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Height = 410
        ListView.Clear()
        Dim columnHeader = ListView.Columns.Add("Noms des fichiers contenant le texte spécifié", 225, HorizontalAlignment.Left)
        Dim columnHeader5 = ListView.Columns.Add("Taille", 100, HorizontalAlignment.Center)
        Dim columnHeader6 = ListView.Columns.Add("Enregistrements", 90, HorizontalAlignment.Center)
        Dim columnHeader7 = ListView.Columns.Add("Positions", 50, HorizontalAlignment.Center)

        Dim v = TextBox1.Focus()
        TextBox1.Text = ""

    End Sub

    Public Sub Find_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Select Case MessageBox.Show("Êtes-vous sûr de vouloir quitter ?", "Prénommer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes
            'Rien à faire ici le formulaire se ferme déjà.
            Case DialogResult.No
                'Annuler l'événement de fermeture du formulaire.
                e.Cancel = True
            Case DialogResult.None
                Exit Select
            Case DialogResult.OK
                Exit Select
            Case DialogResult.Cancel
                Exit Select
            Case DialogResult.Abort
                Exit Select
            Case DialogResult.Retry
                Exit Select
            Case DialogResult.Ignore
                Exit Select
            Case Else
                Exit Select
        End Select

    End Sub

    'Conversion d'une String en Double.
    Public Function CSD(NombreString As String) As Double

        CSD = 0
        Dim v = Double.TryParse(NombreString.Replace(CChar("."), (1 / 2).ToString.Substring(1, 1)).ToString(), CSD)

    End Function

    Private Function ConvertOctetsToKiloOctets(octets As Long) As Double

        '1 ko = 1024 octets.
        Return octets / 1024.0

    End Function

    Public Function KiloToOctet(kilo As Long) As Long

        'Un kilo-octet équivaut à 1024 octets.
        Return kilo * 1024

    End Function

    Public Function BytesToString(bytes As Long) As String

        Dim suffixes() As String = {"B", "Ko", "MB", "GB", "TB"}
        Dim i As Integer = 0
        Dim dblBytes As Double = bytes

        While dblBytes >= 1024 AndAlso i < suffixes.Length - 1
            dblBytes /= 1024
            i += 1
        End While

        Return String.Format("{0:0.##} {1}", dblBytes, suffixes(i))

    End Function

    Public Function FindLineNumber(sourceFile As String, textToFind As String, predicate As Func(Of String, String, Boolean)) As Integer

        Dim LineNo = 1

        For Each l In File.ReadLines(sourceFile)
            If predicate(l, textToFind) Then
                Return LineNo
            End If
            LineNo += 1
        Next

        Return -1

    End Function

    Private Sub ListView_ItemMouseHover(sender As Object, e As ListViewItemMouseHoverEventArgs) Handles ListView.ItemMouseHover

        If e.Item IsNot Nothing Then
            Dim positionsValue As Integer

            e.Item.ToolTipText = If(Integer.TryParse(e.Item.SubItems(3).Text, positionsValue) AndAlso positionsValue > 0,
                                    "",
                                    positionsValue & " (Positions) signifie que le prénom " & TextBox1.Text & " n'a pas été trouvé.")
        End If

    End Sub

End Class