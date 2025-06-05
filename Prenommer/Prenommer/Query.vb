Imports System.IO

Public Class Class3

    Public Function GetFileText(name As String) As String

        Dim fileContents = String.Empty

        If File.Exists(name) Then
            fileContents = File.ReadAllText(name)
        End If

        Return fileContents

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button1.Enabled = True

        'Modifiez ce chemin si nécessaire.
        Dim startFolder = My.Application.Info.DirectoryPath & "\Librairies\"

        'Prenez un instantané du contenu du dossier.
        Dim dir As New DirectoryInfo(startFolder)
        Dim fileList = dir.GetFiles("*.*", SearchOption.AllDirectories)

        Dim searchTerm = TextBox1.Text

        'Recherchez le contenu de chaque fichier.
        'Une expression régulière créée avec la classe RegEx peut être utilisée à la place de la méthode Contains.
        Dim queryMatchingFiles = From file In fileList
                                 Where file.Extension = ".librairie"
                                 Let fileText = GetFileText(file.FullName)
                                 Where fileText.Contains(searchTerm)
                                 Select file.FullName

        Dim a As Integer

        a = 0

        'Exécuter la requête.
        For Each currentFilename As String In queryMatchingFiles
            Dim listViewItem = ListView1.Items.Add(Path.GetFileName(currentFilename))
            Dim lineCount = File.ReadAllLines(currentFilename, System.Text.Encoding.UTF8).Length
            Dim listViewSubItem = ListView1.Items(a).SubItems.Add(CStr(lineCount))
            a += 1
        Next

        If ListView1.Items.Count = 0 Then Dim dialogResult1 = MessageBox.Show("Aucun résultat lors de l'exécution de la requête...")

        Button1.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Main.Visible = True
        Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ListView1.Clear()
        Dim columnHeader = ListView1.Columns.Add("Noms des fichiers contenant le texte spécifié", 250, HorizontalAlignment.Left)
        Dim columnHeader6 = ListView1.Columns.Add("Nombre d'enregistrements", 200, HorizontalAlignment.Center)

        TextBox1.Clear()
        SetCueText(TextBox1, "Rechercher")

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint

        ControlPaint.DrawBorder(e.Graphics, PictureBox1.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid)

    End Sub

    Private Sub Query_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        ListView1.Clear()
        Dim columnHeader = ListView1.Columns.Add("Noms des fichiers contenant le texte spécifié", 250, HorizontalAlignment.Left)
        Dim columnHeader6 = ListView1.Columns.Add("Nombre d'enregistrements", 200, HorizontalAlignment.Center)

    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView1.DrawItem

        e.DrawDefault = True

        If e.ItemIndex Mod 2 = 1 Then
            e.Item.BackColor = Color.AliceBlue '.FromArgb(230, 230, 255)
            e.Item.UseItemStyleForSubItems = True
        End If

    End Sub

    Private Sub ListView1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader

        Using sf = New StringFormat()

            sf.Alignment = StringAlignment.Center

            Using headerFont = New Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
                e.Graphics.FillRectangle(Brushes.Lavender, e.Bounds)
                e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf)
            End Using
        End Using

    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick

        Dim info As ListViewHitTestInfo = ListView1.HitTest(e.X, e.Y)
        Dim unused = MessageBox.Show(info.SubItem.Text) 'Location.ToString())

        Dim dgv As String
        dgv = info.SubItem.Text

        For i As Integer = 0 To Main.ListView1.Items.Count - 1
            If Main.ListView1.Items(i).Text = dgv Then
                Main.ListView1.Items(i).Selected = True
                Exit For
            End If
        Next
        Exit Sub

        Main.ListeToolStripButton.PerformClick()

    End Sub

    Private Sub Query_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetCueText(TextBox1, "Rechercher")

    End Sub

End Class