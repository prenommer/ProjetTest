Imports System.Windows.Forms

Namespace Prenommer.Class7

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

End Namespace

Partial Class MainForm
    Inherits Form

    Private menuPrincipal As Prenommer.Class7.MenuPrincipal
    Private isAdmin As Boolean
    Private ToolStripMenuItem8 As ToolStripMenuItem
    Private EnregistrerToolStripButton As ToolStripButton

    ' Constructeur de MainForm
    Public Sub New(isAdmin As Boolean)

        InitializeComponent()
        ' Logique pour l'utilisateur administrateur ou non

    End Sub

    Private Sub InitializeComponent()

        ' Code généré par l'IDE pour initialiser les composants
        EnregistrerToolStripButton = New ToolStripButton With {
            .Text = "Enregistrer"
        }

    End Sub

    ' Déclaration du bouton dans la classe
    Private WithEvents EnregistrerToolStripButton As ToolStripButton

    ' Événement du bouton "Enregistrer"
    Private Sub EnregistrerToolStripButton_Click(sender As Object, e As EventArgs) Handles EnregistrerToolStripButton.Click

        ' Logique pour gérer l'événement de clic sur le bouton "Enregistrer"

    End Sub

End Class

' MainForm.Designer.vb
Partial Friend Class MainForm

    Dim mainForm As New MainForm(True) ' Passez True si l'utilisateur est administrateur, False sinon.
    'mainForm.Show

    Private Sub InitializeComponent()
        ' Code généré par l'IDE pour initialiser les composants
    End Sub

End Class


' Point d'entrée principal de l'application
Module MainModule

    Public Sub Main()
        ' Créez une nouvelle instance de MainForm en passant le paramètre isAdmin
        Dim mainForm As New MainForm(True) ' Passez True si l'utilisateur est administrateur, False sinon.
        System.Windows.Forms.Application.Run(mainForm) ' Affichez le formulaire principal
    End Sub

End Module

Friend Class Enregistrer

    Public Shared Property Visible As Boolean

    Public Shared Narrowing Operator CType(v As Control) As Enregistrer
        Throw New NotImplementedException()
    End Operator
End Class

Public Class Program

    Public Shared Sub Main()

        System.Windows.Forms.Application.EnableVisualStyles()
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(False)

        ' Créez une instance de MainForm
        Dim mainForm As New MainForm(True)

        ' Démarrez l'application avec MainForm
        System.Windows.Forms.Application.Run(mainForm)

    End Sub

    ' Méthode pour gérer la visibilité des éléments
    Public Sub HandleMenuVisibility()
        ' Vérification si l'utilisateur est un administrateur.
        If isAdmin Then
            ToolStripMenuItem8.Visible = True ' Afficher le menu si l'utilisateur est un administrateur.
            EnregistrerToolStripButton.Visible = True ' Afficher le bouton Enregistrer si l'utilisateur est un administrateur.
        Else
            ToolStripMenuItem8.Visible = False ' Cacher le menu sinon.
            EnregistrerToolStripButton.Visible = False ' Cacher le bouton Enregistrer sinon.
        End If
    End Sub

End Class