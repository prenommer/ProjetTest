Public Class Read

    Private Sub Read_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Initialisation d'un contrôle WebBrowser
        Dim webBrowser1 As New WebBrowser With {
            .Dock = DockStyle.Fill,
            .Width = Width,
            .Height = Height,
            .Url = New Uri("https://www.prenommer.com"),
            .ScrollBarsEnabled = True,
            .Visible = True,
            .ScriptErrorsSuppressed = True
        }

        ' Ajout du WebBrowser au formulaire
        Controls.Add(webBrowser1)
    End Sub

End Class