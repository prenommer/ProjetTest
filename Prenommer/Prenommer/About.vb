Imports Microsoft.Win32

Public Class About

    ' Variable pour la position de défilement du label
    Private scrollSpeed As Integer = 1 ' Vitesse de défilement
    Private labelStartPosition As Integer

    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Initialiser les propriétés du Label
        Label11.Width = Panel2.Width ' Ajuster la largeur du Label à celle du Panel
        Label15.Width = Panel2.Width
        Label16.Width = Panel2.Width

        ' Positionner les labels au départ, hors de la vue (en bas du Panel)
        Label11.Top = Panel2.Height
        Label15.Top = Panel2.Height + Label11.Height + 10 ' +10 pour espacer les labels
        Label16.Top = Panel2.Height + Label11.Height + Label15.Height + 20 ' +20 pour espacer encore plus

        ' Définir le texte des labels
        Label11.Text = "LE PROGRAMME ET LA DOCUMENTATION ASSOCIÉS"
        Label15.Text = "VOUS SONT FOURNIS EN L'ÉTAT, AVEC LEURS DÉFAUTS"
        Label16.Text = "ET SANS GARANTIE D’AUCUNE SORTE."

        ' Démarrer le Timer pour le défilement
        Timer1.Interval = 100 ' Ajuster l'intervalle pour un défilement fluide
        Timer1.Start()

        'Utiliser la fonction GetAppVersion de Main pour obtenir la version
        LabelVersionAbout.Text = $"Build {Main.GetAppVersion()}"

        Label9.Text = Computer.Info.OSFullName

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' Faire défiler les labels vers le haut
        Label11.Top -= 1
        Label15.Top -= 1
        Label16.Top -= 1

        ' Si le premier label est entièrement sorti du Panel, repositionner tous les labels en bas
        If Label16.Top + Label16.Height < 0 Then
            Label11.Top = Panel2.Height
            Label15.Top = Panel2.Height + Label11.Height + 10
            Label16.Top = Panel2.Height + Label11.Height + Label15.Height + 20
        End If

    End Sub

    Private Sub CmdSysInfo_Click(sender As Object, e As EventArgs) Handles CmdSysInfo.Click

        Dim key As Object = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Shared Tools\MSInfo", "Path", Nothing)

        If key IsNot Nothing Then
            Dim unused = Process.Start(key.ToString)
        End If

    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click

        Dim iCount As Integer
        For iCount = 90 To 10 Step -10
            Opacity = iCount / 100
            Refresh()
            Threading.Thread.Sleep(50)
        Next

        Close()

    End Sub

    Private Sub About_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        Dim v = ProcessDialogKey(Keys.Escape)

    End Sub

    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean

        If Form.ModifierKeys = Keys.None AndAlso keyData = Keys.Escape Then
            Close()
            Return True
        End If

        Return MyBase.ProcessDialogKey(keyData)

    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        LinkLabel1.LinkVisited = True
        Dim process = Diagnostics.Process.Start("https://www.prenommer.com")

    End Sub

End Class