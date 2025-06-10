Public Class Class8

    Public Class FichierRecentMenuItem
        Inherits ToolStripMenuItem

        Public Sub New()

            MyBase.New("Fichiers Récents")
            ' Ajoutez des éléments de menu déroulant ici
            Me.DropDownItems.Add("Fichier1.txt")
            Me.DropDownItems.Add("Fichier2.txt")

        End Sub

    End Class

    Public Class MainForm
        Inherits Form

        Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            Try
                Dim fichiersRecents As New FichierRecentMenuItem()
                ' Ajoutez le menu déroulant Fichiers Récents à un menu Strip principal
                Dim menuStrip As New MenuStrip()
                menuStrip.Items.Add(fichiersRecents)
                Me.MainMenuStrip = menuStrip
                Me.Controls.Add(menuStrip)
            Catch ex As Exception
                MessageBox.Show("Erreur : " & ex.Message)
            End Try
        End Sub

    End Class

    Public Class Program

        Public Shared Sub Main()
            System.Windows.Forms.Application.EnableVisualStyles()
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(False)

            ' Créez une instance de MainForm
            Dim mainForm As New MainForm()

            ' Démarrez l'application avec MainForm
            System.Windows.Forms.Application.Run(mainForm)
        End Sub

    End Class

    Public Class MenuPrincipal
        Inherits Form

        ' Déclarez le bouton Enregistrer comme une variable de classe
        Private WithEvents Enregistrer As New Button

        Public Sub New()
            ' Initialisez le bouton Enregistrer
            Enregistrer.Text = "Enregistrer"
            Enregistrer.Visible = True
            Enregistrer.Size = New Size(100, 30) ' Définissez la taille du bouton (optionnel)
            Enregistrer.Location = New Drawing.Point(10, 10) ' Définissez la position du bouton (optionnel)

            ' Ajoutez le bouton à la forme ou au conteneur de votre menu principal
            Controls.Add(Enregistrer)
        End Sub

        ' Déclarez la méthode RendreInvisibleEnregistrer comme publique
        Public Sub RendreInvisibleEnregistrer()
            ' Vérifiez si le bouton Enregistrer est initialisé
            If Enregistrer IsNot Nothing Then
                ' Mettez à jour la propriété Visible pour le rendre invisible
                Enregistrer.Visible = False
            End If
        End Sub

    End Class

End Class