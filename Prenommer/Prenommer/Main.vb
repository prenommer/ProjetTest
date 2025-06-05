Option Infer On

Imports System.Text.RegularExpressions
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Web
Imports System.Windows
Imports System.Windows.Controls
Imports System.Xml
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Vml
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Markdig
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Win32
Imports Newtonsoft.Json
Imports OpenXmlPowerTools
Imports Prenommer.Class2
Imports Prenommer.Class4
Imports Prenommer.Class6
Imports Umbraco.Core
Imports A = DocumentFormat.OpenXml.Drawing
Imports DW = DocumentFormat.OpenXml.Drawing.Wordprocessing
Imports Fiche = Prenommer.Class2.Fiche
Imports FontSize = DocumentFormat.OpenXml.Wordprocessing.FontSize
Imports ListViewItem = System.Windows.Forms.ListViewItem
Imports Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph
Imports PIC = DocumentFormat.OpenXml.Drawing.Pictures
Imports Run = DocumentFormat.OpenXml.Wordprocessing.Run
Imports RunProperties = DocumentFormat.OpenXml.Wordprocessing.RunProperties
Imports Text = DocumentFormat.OpenXml.Wordprocessing.Text
Imports TreeNode = System.Windows.Forms.TreeNode
Imports Word = Microsoft.Office.Interop.Word

<DebuggerDisplay("{GetDebuggerDisplay(),nq}")>
Public Module Prenommer_Module5
    Public Sub AnalyserFichierLibrairie(chemin As String)

        ' Déclaration de la variable TextBox
        Dim myTextBox As New Forms.TextBox()

        ' Exemple d'analyse de fichier
        Dim analyseResultat As String = "Analyse du fichier : " & chemin & Environment.NewLine & "Ligne d'exemple 1" & Environment.NewLine & "Ligne d'exemple 2"

        ' Afficher le résultat de l'analyse dans la MyTextBox
        myTextBox.AppendText(analyseResultat & Environment.NewLine)

    End Sub

    Private Function GetDebuggerDisplay() As String

        Return "Module5"

    End Function

End Module

Public Class Main

    Private Const WorkingDirectory As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements\"

    ' Constantes pour les messages
    Private Const MESSAGE_PROCESS_COMPLETED As String = "Le processus s'est terminé avec succès."
    Private Const MESSAGE_ERROR_OCCURRED As String = "Une erreur est survenue lors de l'exécution."
    Private Const MESSAGE_FILE_NOT_FOUND As String = "Le fichier n'a pas été trouvé."
    Private Const MESSAGE_DIRECTORY_NOT_FOUND As String = "Le répertoire n'a pas été trouvé."
    Private Const MESSAGE_IO_ERROR As String = "Erreur d'entrée/sortie."
    Private Const MESSAGE_GENERIC_ERROR As String = "Une erreur s'est produite. Veuillez contacter le support technique."

    ' Variable pour suivre si le formulaire est en cours de fermeture
    Private isFormClosing As Boolean = False

    ' Déclarez FichiersRecentsMenuItem au niveau de la classe.
    Private Property FichiersRecentsMenuItem As ToolStripMenuItem

    Private Property EffacerFichiersRecentsMenuItem As ToolStripMenuItem

    ' Déclarez cette variable au niveau de la classe/formulaire.
    Private filePath As String

    Private clickedMenuItem As ToolStripMenuItem

    Public Property Var1 As String
    Public Property TexteChaine As String
    Public Property OuvrirFichier As String
    Public Property OuvrirXML As String
    Public Property Sfichier As String
    Public Property Helpfile As String
    Public Property FileXml As String
    Public Property Listem As String
    Public Property EXTListem As String
    Public Property AuxFile As String
    Public Property Json As String
    Public Property Account As Fich

    Public lstOfStrings(17) As String
    Public Property FileOne As String
    Public Property Foo As String
    Public Property OMyFile As String
    Public Property Filepath1 As String
    Public Property Fiche As Boolean

    Public Event SauvegarderEtat As EventHandler

    Public Event RestaurerEtat As EventHandler
    Private Property RecentFiles As List(Of String)
    Public Property StrFile As String

    Public Property LogDirectory As String

    Private selectedFilePath As String

    Private inExceptionHandling As Boolean = False

    Private isAdmin As Boolean = True

    Private TextBoxOriginal As UI.WebControls.TextBox
    Private TextBoxNew As UI.WebControls.TextBox
    Private modifiedNodeText As String = String.Empty
    Private textBoxHistory As TextBoxHistory
    Private SelectedRootNode As TreeNode

    ' Définir les constantes de version
    Private Const VERSION_MAJOR As Integer = 3
    Private Const VERSION_MINOR As Integer = 5
    Private Const VERSION_PATCH As Integer = 2
    Private Const VERSION_BUILD As Integer = 0
    Private Const VERSION_RC As String = "" ' Mettez "" pour la version stable

    Public Property WdDoc As Object
    Private isProcessing As Boolean = False
    Public Property BaseDirectory As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements\"
    Public Property OutputFile As String
    Public Property ImageFileName As String

    Private activControl As Forms.Control

    'Public WithEvents AddNode As System.Windows.Forms.TextBox

    ' Déclarez une variable pour mémoriser le nœud récemment créé
    Private recentNode As TreeNode

    Private previousText As String = String.Empty

    Private textHistory As New Stack(Of String)()

    ' Dictionnaire pour stocker l'historique de chaque contrôle
    Private controlHistories As New Dictionary(Of Forms.Control, Stack(Of String))()

    Private controlUndoHistories As New Dictionary(Of Forms.Control, Stack(Of String))()
    Private controlRedoHistories As New Dictionary(Of Forms.Control, Stack(Of String))()

    Private lastAction As String

    Private isUpdating As Boolean = False

    Private cheminFichier As String '= ListView1.SelectedItems(0).Text

    Public nativeImage As System.Drawing.Image

    Private listeDeDonnees As New List(Of String)()

    Private hlpProviderMain As New HelpProvider()

    Public Class FreeImageInterop
        <DllImport("FreeImage.dll", EntryPoint:="FreeImage_Initialise", SetLastError:=True)>
        Public Shared Sub FreeImage_Initialise(loadLocalPluginsOnly As Boolean)
        End Sub

        <DllImport("FreeImage.dll", EntryPoint:="FreeImage_DeInitialise", SetLastError:=True)>
        Public Shared Sub FreeImage_DeInitialise()
        End Sub

        <DllImport("FreeImage.dll", EntryPoint:="FreeImage_Load", SetLastError:=True)>
        Public Shared Function FreeImage_Load(format As Integer, filename As String, flags As Integer) As IntPtr
        End Function

        <DllImport("FreeImage.dll", EntryPoint:="FreeImage_Save", SetLastError:=True)>
        Public Shared Function FreeImage_Save(format As Integer, dib As IntPtr, filename As String, flags As Integer) As Boolean
        End Function

        <DllImport("FreeImage.dll", EntryPoint:="FreeImage_Unload", SetLastError:=True)>
        Public Shared Sub FreeImage_Unload(dib As IntPtr)
        End Sub

        ' Enumération des formats FreeImage
        Public Const FIF_WEBP As Integer = 34 ' Format WebP
        Public Const FIF_PNG As Integer = 13  ' Format PNG

    End Class

    Public Sub New()

        ' Appeler InitializeComponent pour créer et initialiser tous les contrôles du formulaire
        InitializeComponent()

        ' Désactiver des fonctionnalités non finies (si applicable)
        DésactiverFonctionnalitésNonFinies()

        ' Associer l'événement Click au menu "Enregistrer"
        AddHandler EnregistrerToolStripButton.Click, AddressOf Enregistrer
        'AddHandler enregistrerMenuItem.Click, AddressOf Enregistrer

        ' Configurer et associer l'événement Click pour "GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem"
        AddHandler GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem.Click, AddressOf GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem_Click
        GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem.Enabled = True
        GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem.Visible = True

        ' Créer et configurer le menu "Supprimer les fichiers JSON"
        SupprimerlesfichiersJSONToolStripMenuItem = New ToolStripMenuItem("Supprimer les fichiers JSON")
        AddHandler SupprimerlesfichiersJSONToolStripMenuItem.Click, AddressOf SupprimerlesfichiersJSONToolStripMenuItem_Click

        ' Ajouter le menu "Supprimer les fichiers JSON" au MenuStrip existant
        Dim unused = MenuStrip1.Items.Add(SupprimerlesfichiersJSONToolStripMenuItem)

        ' Autres initialisations nécessaires...

    End Sub

    Private Sub ConvertirDuTexteMarkdownEnDOCXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertirDuTexteMarkdownEnDOCXToolStripMenuItem.Click

        Try

            OpenFileDialog.Multiselect = False
            OpenFileDialog.Filter = "Fichiers Markdown (*.md)|*.md"
            OpenFileDialog.Title = "Sélectionnez un fichier Markdown"

            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                Dim fileName As String = System.IO.Path.GetFileName(OpenFileDialog.FileName)
                Dim filePath As String = OpenFileDialog.FileName
                Dim unused6 = Forms.MessageBox.Show(fileName & " - " & filePath)

                Dim markdownPath As String = OpenFileDialog.FileName
                Dim docxPath As String = System.IO.Path.ChangeExtension(markdownPath, ".docx")
                Dim referenceDocxPath As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Documents\style_reference.docx"

                ' Validation des chemins
                If Not File.Exists(markdownPath) Then
                    Dim unused5 = Forms.MessageBox.Show($"Le fichier Markdown sélectionné n'existe pas : {markdownPath}",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                If Not File.Exists(referenceDocxPath) Then
                    Dim unused4 = Forms.MessageBox.Show($"Le fichier de style de référence n'existe pas : {markdownPath}",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                'Lancer la conversion
                Dim converter As New PandocConverter()
                converter.ConvertMarkdownToWord(markdownPath, docxPath, referenceDocxPath)

                Dim unused1 = MsgBox($"Conversion réussie : {docxPath}")
            Else
                Dim unused3 = MsgBox("Aucun fichier sélectionné.")
            End If
        Catch ex As Exception
            Dim unused2 = MsgBox($"Erreur lors de la conversion : {ex.Message}")
        Finally
            ' Cette ligne s'exécute dès que l'exception se produit ou non.
            Dim unused = Forms.MessageBox.Show("L'exécution du processus est terminée.", "Prenommer", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub

    Public Sub EnsureUtf8Encoding(filePath As String)

        If File.Exists(filePath) Then
            Dim content As String = File.ReadAllText(filePath, Encoding.Default)
            File.WriteAllText(filePath, content, Encoding.UTF8)
            Dim unused = MsgBox($"Le fichier {filePath} a été converti en UTF-8.")
        Else
            Dim unused1 = MsgBox($"Le fichier spécifié n'existe pas : {filePath}")
        End If

    End Sub

    Public Sub ConvertToUtf8(filePath As String)

        If File.Exists(filePath) Then
            Dim content As String = File.ReadAllText(filePath, Encoding.Default)
            File.WriteAllText(filePath, content, Encoding.UTF8)
            Dim unused = MsgBox($"Le fichier {filePath} a été converti en UTF-8.")
        Else
            Dim unused1 = MsgBox($"Le fichier spécifié n'existe pas : {filePath}")
        End If

    End Sub

    Private Sub ExecutePandoc(arguments As String)

        Try
            Dim process As New Process With {
.StartInfo = New ProcessStartInfo("C:\Programmes\Pandoc\pandoc.exe") With {
    .Arguments = arguments,
    .UseShellExecute = False,
    .RedirectStandardOutput = True,
    .RedirectStandardError = True,
    .CreateNoWindow = True
}
}

            Dim unused = process.Start()
            Dim output = process.StandardOutput.ReadToEnd()
            Dim [error] = process.StandardError.ReadToEnd()
            process.WaitForExit()

            If Not String.IsNullOrEmpty([error]) Then
                Throw New Exception($"Erreur Pandoc : {[error]}")
            End If
        Catch ex As Exception
            Throw New Exception($"Erreur lors de l'exécution de Pandoc : {ex.Message}")
        End Try

    End Sub

    Public Sub ConvertMarkdownToWord(inputMarkdown As String, outputDocx As String, Optional referenceDocx As String = Nothing)

        ' Assurez-vous que le fichier Markdown est encodé en UTF-8 avant conversion
        ConvertToUtf8(inputMarkdown)

        ' Construire les arguments pour Pandoc
        Dim arguments As String = If(referenceDocx <> "",
    $"""{inputMarkdown}"" -f markdown -t docx --reference-doc=""{referenceDocx}"" -o ""{outputDocx}""",
    $"""{inputMarkdown}"" -f markdown -t docx -o ""{outputDocx}""")

        ' Exécuter Pandoc via ProcessStartInfo
        Dim processInfo As New ProcessStartInfo("pandoc.exe") With {
.Arguments = arguments,
.UseShellExecute = False,
.CreateNoWindow = True,
.RedirectStandardOutput = True,
.RedirectStandardError = True
}

        ' Lire la sortie pour vérifier les erreurs
        Dim process As New Process() With {.StartInfo = processInfo}
        Dim unused = process.Start() ' Démarrer le processus

        Dim output As String = process.StandardOutput.ReadToEnd() ' Lire la sortie standard
        Dim [error] As String = process.StandardError.ReadToEnd() ' Lire les erreurs
        process.WaitForExit() ' Attendre la fin du processus

        If Not String.IsNullOrEmpty([error]) Then
            Throw New Exception($"Erreur Pandoc : {[error]}")
        End If

    End Sub

    Public Sub DésactiverFonctionnalitésNonFinies()

        ' Désactiver les options MD ↔ HTML
        ConvertirDuTexteMarkdownEnHTML.Visible = False
        ConvertirDuTexteMarkdownEnHTML.Enabled = False

        CréerUnDocumentMarkDownMDToolStripMenuItem.Visible = True
        CréerUnDocumentMarkDownMDToolStripMenuItem.Enabled = True

        ' Définir les propriétés au chargement du formulaire
        'VérificationetsauvegardefichiersToolStripMenuItem.Enabled = True
        'VérificationetsauvegardefichiersToolStripMenuItem.Visible = True

    End Sub

    Private Sub ConvertMarkdownMenu_Click(sender As Object, e As EventArgs) Handles ConvertirDuTexteMarkdownEnHTML.Click

        If isProcessing Then Return ' Évite un double appel
        isProcessing = True

        Try
            Dim unused = MsgBox("Menu Convertir Markdown en HTML détecté !")

            ' Exemple de conversion Markdown
            Dim markdownText As String = "# Exemple Markdown"
            Dim htmlText As String = ConvertMarkdownToHtml(markdownText)
            Dim unused1 = MsgBox($"HTML généré : {htmlText}")
        Catch ex As Exception
            Dim unused2 = MsgBox($"Erreur : {ex.Message}")
        Finally
            isProcessing = False
        End Try

    End Sub

    Public Sub InitializeCustomComponents()

        AddHandler CréerUnDocumentAuFormatOOXMLToolStripMenuItem.Click, AddressOf CréerUnDocumentAuFormatOOXMLToolStripMenuItem_Click
        AddHandler GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem.Click, AddressOf GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem_Click

        ' Associer l'événement de clic à la méthode Enregistrer
        ' AddHandler ToolStripMenuItem.Click, AddressOf EnregistrerToolStripMenuItem_Click

        ' Ajouter d'autres personnalisations ici, si nécessaire
        AddHandler EnregistrerToolStripButton.Click, AddressOf EnregistrerToolStripButton_Click

        ' Vous pouvez ensuite ajouter des sous-menus ou d'autres options ici si nécessaire.

    End Sub

    Private Sub EnregistrerToolStripButton_Click(sender As Object, e As EventArgs)

        Try
            ' Votre code pour enregistrer les données ici
            ' Par exemple, sauvegarder dans un fichier ou une base de données

            Dim unused = Forms.MessageBox.Show("Les données ont été enregistrées avec succès.")
        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show("Une erreur est survenue lors de l'enregistrement des données : " & ex.Message)
        End Try

    End Sub

    Private Sub BtnConvertirODT_Click(sender As Object, e As EventArgs) 'Handles BtnConvertirODT.Click

        Try

            Dim sourceFile As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements"
            Dim outputDir As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements"
            Dim automation As New LibreOfficeAutomation()

            automation.ConvertirDocxEnOdt(sourceFile, outputDir)

            Dim unused = Forms.MessageBox.Show("Conversion terminée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show($"Erreur lors de la conversion : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' Gestionnaire de l'événement Load du formulaire
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            LancerMiseAJour()

            Dim VérificationetsauvegardefichiersToolStripMenuItem As New ToolStripMenuItem With {
                .Name = "VérificationetsauvegardefichiersToolStripMenuItem",
                .Text = "Vérification et sauvegarde fichiers"
            }
            Dim unused12 = OutilsToolStripMenuItem.DropDownItems.Add(VérificationetsauvegardefichiersToolStripMenuItem)

            AddHandler VérificationetsauvegardefichiersToolStripMenuItem.Click, AddressOf VerifierFichier

            ' Exécuter le script PowerShell dès le démarrage de l'application
            Dim psi As New ProcessStartInfo With {
                .FileName = "powershell.exe",
                .Arguments = "-ExecutionPolicy Bypass -WindowStyle Hidden -File ""C:\Scripts\mise_a_jour.ps1""",
                .UseShellExecute = False,
                .CreateNoWindow = True ' Empêcher la fenêtre de s'afficher
                }
            Dim unused13 = Process.Start(psi)

            Dim cheminDossier As String = "C:\Prenommer\Updates"
            If Not Directory.Exists(cheminDossier) Then
                Dim unused14 = Directory.CreateDirectory(cheminDossier)
            End If

            TreeView1.DrawMode = TreeViewDrawMode.OwnerDrawText

            hlpProviderMain.HelpNamespace = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Aide\Prenommer.chm"

            ' Configuration du TreeView
            TreeView1.HideSelection = False ' Important pour que la sélection reste visible quand le contrôle perd le focus

            ToolStripMenuItem9.Visible = True
            ToolStripMenuItem9.Enabled = True

            'textBoxHistory = New TextBoxHistory(MyTextBox)

            ' Définir le texte du ToolTip
            ToolTipVersion.SetToolTip(StatusStrip1, $"Version {AppVersion}")

            ' Initialisation nécessaire si vous utilisez WithEvents

            ' Configurez les propriétés de LabelNotification
            ConfigureLabelNotification()

            ' Assurez-vous que le TreeView est complètement chargé avant de sélectionner un nœud
            TreeView1.ExpandAll()

            '================================================================================
            ' Sélectionnez le premier nœud enfant si le nœud racine est sélectionné par défaut
            'If TreeView1.Nodes.Count > 0 AndAlso TreeView1.Nodes(0).Nodes.Count > 0 Then
            'TreeView1.SelectedNode = TreeView1.Nodes(0).Nodes(0)
            'End If
            '=================================================================================

            ' Associer les événements (si cela n'est pas déjà fait dans le concepteur)
            AddHandler TextBox5.LostFocus, AddressOf TextBox5_LostFocus

            HandleMenuVisibility()

            CustomLogger.Log("Starting application...")
            'MyStaticMethod()
            'CustomLogger.Log("Application finished.")

            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalExceptionHandler

            ' Assurez-vous que logFilePath est correctement initialisé.
            Dim basePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources")
            Dim logFilePath = System.IO.Path.Combine(basePath, "logfile.txt")
            logFilePath = $"{My.Application.Info.DirectoryPath}\Resources\logfile.txt"

            If Not File.Exists(logFilePath) Then
                File.Create(logFilePath).Dispose()
                ' Vous pouvez éventuellement effectuer d'autres opérations sur le fichier ici si nécessaire.
            End If

            Try

                ' Initialisez un StringBuilder pour le contenu Markdown
                Dim markdownContent As New StringBuilder()

                Dim markdownImage = GetImageMarkdown("TextBox1.Text")
                Dim unused15 = markdownContent.AppendLine($"- **Représentation** : {markdownImage}")

                ' Spécifiez le chemin du répertoire parent de l'application.
                'Dim parentDirectory As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\"

                ' Construisez le chemin complet du répertoire de ressources.
                'Dim logDirectory As String = IO.Path.Combine(parentDirectory, "Resources")

                ' Obtenez le chemin du répertoire de ressources relatif à l'emplacement de l'exécutable
                Dim logDirectory As String = System.IO.Path.Combine(Forms.Application.StartupPath, "Resources")

                ' Vérifiez si le répertoire existe, sinon créez-le.
                If Not Directory.Exists(logDirectory) Then
                    Dim unused8 = Directory.CreateDirectory(logDirectory)
                End If

                ' Définissez le chemin complet du fichier journal.
                logFilePath = System.IO.Path.Combine(logDirectory, "logfile.txt")

                ' Vérifiez si le fichier journal existe, sinon créez-le et écrivez les informations initiales.
                If Not File.Exists(logFilePath) Then
                    Using fs As FileStream = File.Create(logFilePath)
                        ' Vous pouvez éventuellement effectuer d'autres opérations sur le flux ici si nécessaire.
                        Using writer As New StreamWriter(fs)
                            writer.WriteLine($"Date : {Date.Now}")
                            writer.WriteLine("Application started.")
                        End Using
                    End Using
                End If

            Catch ex As Exception
                ' Affichez les détails de l'erreur.
                CustomLogger.Log("Exception caught: " & ex.Message & " Stack Trace: " & ex.StackTrace)
                Dim unused6 = Forms.MessageBox.Show($"Erreur lors de la création du fichier : {ex.Message}")
            End Try

            TracingTest("logFilePath")

            ' Placez ce code dans la méthode Main() de votre application.
            AddHandler AppDomain.CurrentDomain.FirstChanceException, Sub(exceptionSender, exceptionEventArgs)
                                                                         If Not inExceptionHandling Then
                                                                             Try
                                                                                 inExceptionHandling = True
                                                                                 Dim ex As Exception = exceptionEventArgs.Exception
                                                                                 If Not (TypeOf ex Is FileNotFoundException AndAlso ex.Message.Contains("System.XmlSerializers")) Then
                                                                                     Dim msg As New StringBuilder()
                                                                                     Dim unused1 = msg.AppendLine("Date : " & Date.UtcNow)
                                                                                     Dim unused2 = msg.AppendLine(ex.GetType().FullName)
                                                                                     Dim unused3 = msg.AppendLine(ex.Message)
                                                                                     Dim unused4 = msg.AppendLine(ex.StackTrace)
                                                                                     Dim unused5 = msg.AppendLine()

                                                                                     Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                                                                                     If String.IsNullOrEmpty(desktopPath) Then '
                                                                                         Throw New Exception("Impossible d'obtenir le chemin du bureau.")
                                                                                     End If

                                                                                     Dim directoryPath As String = My.Application.Info.DirectoryPath

                                                                                     If String.IsNullOrEmpty(directoryPath) Then
                                                                                         Throw New Exception("Impossible d'obtenir le chemin du répertoire de l'application.")
                                                                                     End If

                                                                                     Try
                                                                                         Dim logDirectory As String = System.IO.Path.Combine(directoryPath, "Resources") '

                                                                                         ' Vérifier si le répertoire existe, sinon le créer.
                                                                                         If Not Directory.Exists(logDirectory) Then
                                                                                             Dim unused = Directory.CreateDirectory(logDirectory)
                                                                                         End If

                                                                                         ' Chemin absolu vers le fichier journal
                                                                                         logFilePath = System.IO.Path.Combine(logDirectory, "logfile.txt")

                                                                                         ' Vérifier si le fichier n'existe pas.
                                                                                         If Not File.Exists(logFilePath) Then
                                                                                             Using fs As FileStream = File.Create(logFilePath)
                                                                                                 ' Vous pouvez éventuellement effectuer d'autres opérations sur le flux ici si nécessaire.
                                                                                                 Using writer As New StreamWriter(logFilePath, True)
                                                                                                     writer.WriteLine($"Date : {Date.Now}")
                                                                                                     writer.WriteLine(ex.GetType().FullName)
                                                                                                     writer.WriteLine(ex.Message)
                                                                                                     writer.WriteLine(ex.StackTrace)
                                                                                                     writer.WriteLine()
                                                                                                 End Using
                                                                                             End Using
                                                                                         End If

                                                                                     Catch excep As Exception
                                                                                         ' Affichez les détails de l'erreur.
                                                                                         Dim unused6 = Forms.MessageBox.Show($"Erreur lors de la création du fichier : {excep.Message}")
                                                                                     End Try

                                                                                     Try
                                                                                         File.AppendAllText(logFilePath, msg.ToString())
                                                                                     Catch exc As Exception
                                                                                         Dim unused7 = Forms.MessageBox.Show("Échec de l'écriture dans le fichier journal : " & exc.ToString())
                                                                                     End Try

                                                                                 End If
                                                                             Finally
                                                                                 inExceptionHandling = False
                                                                             End Try
                                                                         End If
                                                                     End Sub

            Icon = beos

            Dim path As String = $"{My.Application.Info.DirectoryPath}\Librairies\"
            Dim chemin As String = $"{My.Application.Info.DirectoryPath}\Xml\"
            Dim Helpfile As String = $"{My.Application.Info.DirectoryPath}\Aide\"
            Dim records As String = $"{My.Application.Info.DirectoryPath}\Archives\"

            ' Appeler la méthode pour initialiser le menu des fichiers récents
            InitializeForm()

            ' Configurer le menu "Fichiers récents" au lancement de l'application.
            SetupRecentFilesMenu()

            ' Appel de la fonction pour les opérations sur le registre.
            RegistryFunction()

            '' Initialiser FichiersRecentsMenuItem.
            'FichiersRecentsMenuItem = New ToolStripMenuItem("Fichiers récents")

            ' Initialisation du formulaire
            'Text = "Analyse des fichiers librairies"  'Menu...

            If My.Settings.RecentFiles Is Nothing Then
                My.Settings.RecentFiles = New StringCollection()
            End If

            ToolStripStatusLabel1.Text = "" : ToolStripStatusLabel4.Text = "" : ToolStripStatusLabel7.Text = ""
            TreeView1.Hide()
            TreeView1.DrawMode = TreeViewDrawMode.OwnerDrawText

            If Not Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Temp") Then
                Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Temp")
            End If

            Dim pathway As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images")

            If Not Directory.Exists(pathway) Then
                ' Le dossier "Images" n'existe pas, demander à l'utilisateur s'il doit être recréé
                Dim msgBoxResult = MsgBox("Le dossier Images n'existe pas. Voulez-vous le recréer ?", vbYesNo, "Prenommer")

                If msgBoxResult = MsgBoxResult.Yes Then
                    Try
                        Dim unused9 = Directory.CreateDirectory(pathway)
                        Dim unused10 = MsgBox("Le dossier Images a été créé avec succès.", vbInformation, "Prenommer")
                    Catch ex As Exception
                        Dim unused11 = MsgBox("Erreur lors de la création du dossier Images : " & ex.Message, vbExclamation, "Erreur")
                    End Try
                End If
            End If

            ListView1.BeginUpdate()
            If Not Computer.FileSystem.FileExists(path) Then
                For Each fileName As String In Directory.GetFiles(path)
                    ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName))
                    If System.IO.Path.GetExtension(fileName) = ".librairie" Then
                        Dim listViewItem = ListView1.Items.Add(System.IO.Path.GetFileName(fileName), 0) ' ImageList1.Images.Count - 1)
                        ListView1.Refresh()
                    End If
                Next
            End If
            ListView1.EndUpdate()

            Dim resultat As String
            ToolStripComboBox1.Items.Clear()
            Dim fileNames = Computer.FileSystem.GetFiles(chemin & "\", FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            For Each fileName As String In fileNames
                resultat = System.IO.Path.GetFileName(fileName)
                Dim v = ToolStripComboBox1.Items.Add(resultat)
                Dim v1 = ListBox1.Items.Add(resultat)
            Next

            ToolStripStatusLabel1.Text = ListView1.Items.Count & " librairies chargées"
            ToolStripStatusLabel3.Text = "Aucun fichier sélectionné"
            ToolStripStatusLabel5.Text = ""

            ToolStripStatusLabel3.Image = If(ToolStripStatusLabel3.Text = "Aucun fichier sélectionné", DocumentError_16x, DocumentOK_16x)

            ComboBox1.Items.AddRange(New Object() {"Bienheureuse ", "Bienheureuses ", "Bienheureux ", "Fête mariale ", "Fête religieuse ", "Saint ", "Sainte ", "Saintes ", "Saints ", "Sanctuaire marial ", "Servante de Dieu ", "Servantes de Dieu ", "Servants de Dieu ", "Serviteur de Dieu ", "Serviteurs de Dieu ", "Vénérable ", "Vénérables "})
            ComboBox2.Items.AddRange(New Object() {"A.A. | Assomptionnistes (Congrégation des Augustins de l'Assomption)", "B. | Barnabites (Clercs réguliers de Saint-Paul)", "Brig. | Brigittin(e)s (Frères et Sœurs du Saint-Sauveur et de Sainte Brigitte)", "C.I.C.M | Scheutistes (Congrégation du Cœur Immaculé de Marie)", "C.J.M | Eudistes (Congrégation de Jésus et Marie)", "Clar. | Clarisses", "C.M. | Lazaristes (Congrégation de la Mission)", "C.M.F. | Missionnaires Clarétains", "C.P. | Passionistes (Congrégation de la Passion de Jésus-Christ)", "C.Ss.R. | Rédemptoristes ou Liguoriens (Congrégation du Très Saint Rédempteur)", "F.C. | Fils de la charité", "F.D.M. | Frères de Notre-Dame de Miséricorde", "F.d.S. | Filles de la Sagesse de Saint-Laurent-sur-Sèvre", "F.E.C. / F.S.C. | Lasalliens (Frères des Écoles Chrétiennes)", "F.M.M. | Franciscaines Missionnaires de Marie (de Rome)", "F.M.S. | Frères Maristes (Petits Frères de Marie)", "I.C.M. | Missionnaires du Cœur Immaculé de Marie", "L.S.N.S. | Apostolines du Très Saint-Sacrement (Dames de Sainte-Julienne)", "M.Afr. | Pères Blancs (Société des Missionnaires d'Afrique)", "M.R. | Société de Marie Réparatrice", "M.S.C. | Missionnaires du Sacré-Cœur de Jésus", "M.S.F. | Missionnaires de la Sainte-Famille", "O.Bas. | Basiliens", "O.C. | Grands carmes (Carmes de l’Antique Observance, Carmélites de la Primitive Observance)", "O.Cart. | Chartreux, chartreuses (ou chartreusines)", "O.C.D. | Carmes Déchaux, carmélites déchaussées", "O.Cist. | Cisterciens, cisterciennes", "O.C.S.O. | Trappistes, trappistines (Ordre Cistercien de la Stricte Observance)", "O.D.V. | Visitandines (Ordre de la Visitation)", "O.F.M. | Franciscain(e)s (sauf clarisses) (Ordre des Frères Mineurs)", "O.F.M.Conv. | Franciscains conventuels (Ordre des Frères Mineurs conventuels)", "O.F.M.Cap. | Capucins (Frères Mineurs Capucins)", "O.H. | Ordre Hospitalier de Saint-Jean de Dieu (Frères de Saint Jean de Dieu)", "O. de M. | Mercédaires (Ordre de Notre-Dame de la Miséricorde)", "O.M.I. | Missionnaires Oblats de Marie Immaculée", "O.M. | Minimes (Ordre des Minimes)", "O.P. | Dominicains, Frères Prêcheurs (Ordre de Prédicateurs)", "O.Praem. | Prémontrés (Chanoines Réguliers de Prémontré)", "Orat. | Oratoriens (Confédération de l’Oratoire de Saint-Philippe Néri)", "O.S.A. | Augustin(e)s (Ordre de Saint-Augustin ou des Augustins)", "O.S.B. | Bénédictin(e)s (Ordre de Saint-Benoît)", "O.S.B.Cam. | Camaldules (Congrégation Bénédictine des Moines-ermites Camaldules)", "O.S.B.Cél. | Célestins (Congrégation Bénédictine des Célestins)", "O.S.B.Sil. | Silvestrins (Congrégation Bénédictine des Silvestrins)", "O.S.B.Val. | Vallombrosans (Congrégation Bénédictine de Vallombreuse)", "O.S.B.Hum. | Humiliés (Congrégation Bénédictine de l’Humiliation)", "O.S.B.Mont | Montevirginiens (Congrégation Bénédictine de Monte Virgine)", "O.S.B.Oliv. | Olivétains (Congrégation Bénédictine de Monte Oliveto)", "O.S.M. | Servites (Ordre des Serviteurs de Marie)", "O.SS.T. | Trinitaires (Ordre de la Très-Sainte-Trinité)", "Paul. | Paulistes (Ordre de Saint-Paul l’Ermite)", "P.F.J. | Petits Frères de Jésus du Père de Foucauld", "P.I.M.E. | Institut pontifical pour les missions étrangères", "P.S.S. | Sulpiciens (Prêtres de Saint-Sulpice)", "R.S.C.J. | Religieuses du Sacré-Cœur de Jésus (Société du Sacré-Cœur de Jésus)", "Sal. / S.D.B. | Salésiens (Congrégation des Salésiens de Don Bosco)", "S.C. | Crucistes (Congrégation de la Sainte-Croix)", "S.C.J. | Prêtres du Sacré-Cœur de Jésus", "S.D.S. | Salvatoriens (Société du Divin Sauveur)", "S.G. | Frères de Saint-Gabriel (Frères de l'Instruction Chrétienne de Saint-Gabriel)", "S.P. | Piaristes (Congrégation des écoles pies)", "S.J. ou d.C.d.G. | Jésuites (Compagnie de Jésus)", "S.M. | Pères Maristes (Société de Marie)", "S.M.A. | Société des Missions Africaines", "S.M.M. | Missionnaires Montfortains", "SS.CC. | Pères des Sacrés-Cœurs / Picpus (Congrégation des Sacrés-Cœurs de Jésus et de Marie et de l'Adoration Perpétuelle du Très-Saint-Sacrement de l'Autel)", "S.U.S.C. | Religieuses de la Sainte-Union des Sacrés-Cœurs", "Urs. | Ursulines (Ordre de Sainte-Ursule)"})
            DateTimePicker1.CustomFormat = "d MMMM"
            DateTimePicker1.Value = Now()
            TextBox5.Text = ""

            For Each txt In {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}
                txt.ReadOnly = True
            Next
            RichTextBox1.ReadOnly = True

            lit = 0 : modifié = 0 : sauvé = 0 : ajouté = 0 : supprimé = 0
            ListeToolStripMenuItem.Enabled = False : ModifierToolStripMenuItem1.Enabled = False : NouvelleficheToolStripMenuItem.Enabled = False : SupprimerToolStripMenuItem.Enabled = False
            NouveauToolStripButton.Enabled = False : EnregistrerToolStripButton.Enabled = False : ListeToolStripButton.Enabled = False : ToolStripButton5.Enabled = False
            ComboBox1.Enabled = False : ComboBox2.Enabled = False : DateTimePicker1.Enabled = False : GenererunfichierdocxToolStripMenuItem.Enabled = False
            ComboBox2.DrawMode = DrawMode.OwnerDrawFixed
            Dim numbers As Long
            Dim di As New DirectoryInfo(My.Application.Info.DirectoryPath & "\Librairies\")
            Dim fiArr As FileInfo() = di.GetFiles()
            Dim fri As FileInfo
            For Each fri In fiArr
                numbers = CLng(numbers + (fri.Length / 3188))
            Next fri
            ToolStripStatusLabel6.Text = $"Affichage du nombre total d'enregistrements : {numbers}"

            ' Appeler la fonction pour récupérer le rôle de l'utilisateur
            Dim userRole As String = GetCurrentUserRole()

            ' Afficher ou masquer le menu en fonction du rôle de l'utilisateur
            ProcessusdetraitementdesdonnéesToolStripMenuItem.Visible = userRole = "Admin"

        Catch exc As FileNotFoundException
            UpdateLabelNotification($"Le fichier n'a pas été trouvé : '{exc.Message}'")
        Catch exc As DirectoryNotFoundException
            UpdateLabelNotification($"Le répertoire n'a pas été trouvé : '{exc.Message}'")
        Catch exc As IOException
            UpdateLabelNotification($"Erreur d'entrée/sortie : '{exc.Message}'")
        Catch exc As Exception
            ' Logguer l'exception pour le débogage
            CustomLogger.Log("Exception caught: " & exc.Message & " Stack Trace: " & exc.StackTrace)
            ' Afficher un message générique pour l'utilisateur
            UpdateLabelNotification("Une erreur s'est produite. Veuillez contacter le support technique.")
        Finally
            ' Mise à jour du Label dynamique
            UpdateLabelNotification(MESSAGE_PROCESS_COMPLETED)

        End Try

    End Sub

    <STAThread()>
    Public Shared Sub Main()

        Forms.Application.EnableVisualStyles()
        Forms.Application.SetCompatibleTextRenderingDefault(False)
        Forms.Application.Run(New Form)

    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Refresh()

        Dim urlDropbox As String = "https://www.dropbox.com/scl/fi/gvtz6a3dk0epo09yu4lqv/version.txt?rlkey=bzfvcsj59g9veql82bt7tdt8x&st=996khrfy&raw=1"
        Dim cheminLocal As String = "C:\Prenommer\Updates\version.txt"

        ' Télécharger le fichier avant de le lire
        If DownloadFileFromURL(urlDropbox, cheminLocal) Then
            Dim versionLogiciel As String = GetVersion()
            Dim versionFichier As String = ReadVersionFromFile(cheminLocal)

            If versionLogiciel < versionFichier Then
                ShowUpdateNotification()
            Else
                Dim unused = MsgBox("Pas de mise à jour requise.")
            End If
        Else
            Dim unused1 = MsgBox("Échec du téléchargement du fichier.")
        End If

    End Sub

    Public Function TéléchargerSiNouvelleVersion(url As String, cheminLocal As String) As Boolean

        Try
            Dim client As New WebClient()
            Dim tempFile As String = cheminLocal & ".tmp" ' Fichier temporaire

            client.DownloadFile(url, tempFile) ' Télécharge en tant que fichier temporaire
            Dim newFileSize As Long = New FileInfo(tempFile).Length
            Dim oldFileSize As Long = If(File.Exists(cheminLocal), New FileInfo(cheminLocal).Length, 0)

            If newFileSize <> oldFileSize Then
                File.Delete(cheminLocal)
                File.Move(tempFile, cheminLocal)
                Return True ' Mise à jour effectuée
            Else
                File.Delete(tempFile)
                Return False ' Pas de changement
            End If
        Catch ex As Exception
            Dim unused = MsgBox("Erreur de mise à jour : " & ex.Message)
            Return False
        End Try

    End Function

    Public Function DownloadFileFromURL(url As String, destinationPath As String) As Boolean

        Try
            Dim client As New WebClient()
            client.DownloadFile(url, destinationPath) ' Télécharge le fichier et le sauvegarde localement
            Return True
        Catch ex As Exception
            Dim unused = MsgBox("Erreur de téléchargement : " & ex.Message)
            Return False
        End Try

    End Function

    Public Function ReadVersionFromFile(filePath As String) As String

        If File.Exists(filePath) Then
            Return File.ReadAllText(filePath).Trim() ' Lit et nettoie le contenu du fichier
        Else
            Return ""
        End If

    End Function

    Public Sub SelectNodeByText(nodeText As String)

        TreeView1.SelectedNode = Nothing ' Désélectionne tout
        'Forms.Application.DoEvents()

        Dim nodeToSelect = FindNodeByText(TreeView1.Nodes, nodeText)

        If nodeToSelect IsNot Nothing Then
            TreeView1.SelectedNode = nodeToSelect
            nodeToSelect.EnsureVisible()
            Dim unused1 = TreeView1.Focus()

            ' 🔥 Forcer la mise en surbrillance manuellement
            nodeToSelect.BackColor = System.Drawing.Color.Yellow

        Else
            Dim unused = Forms.MessageBox.Show("Nœud non trouvé : " & nodeText)
        End If

    End Sub

    Public Shared ReadOnly Property AppVersion As String

        Get
            Dim version As String = $"{VERSION_MAJOR}.{VERSION_MINOR}.{VERSION_PATCH}.{VERSION_BUILD}"
            If Not String.IsNullOrEmpty(VERSION_RC) Then
                version &= $"-{VERSION_RC}"
            End If

            Return version
        End Get

    End Property

    Public Property FolderBrowserImport As Object
    Public Property NewNode As TreeNode

    Private Sub ConfigureLabelNotification()

        ' Assurez-vous que LabelNotification existe
        If LabelNotification IsNot Nothing Then
            LabelNotification.Text = ""
            LabelNotification.Visible = False
            LabelNotification.ForeColor = System.Drawing.Color.Red
            LabelNotification.Font = New System.Drawing.Font(LabelNotification.Font.FontFamily, LabelNotification.Font.Size)
        End If

    End Sub

    Private Sub UpdateLabelNotification(message As String)

        If LabelNotification IsNot Nothing Then
            LabelNotification.Text = message
            LabelNotification.Visible = True
        Else
            Dim unused = Forms.MessageBox.Show("LabelNotification n'existe pas sur le formulaire.")
        End If

    End Sub

    Private Sub HandleMenuVisibility()

        ' Vérification si l'utilisateur est un administrateur.
        If isAdmin Then
            ToolStripMenuItem8.Visible = True ' Afficher le menu si l'utilisateur est un administrateur.
        Else
            ToolStripMenuItem8.Visible = False ' Cacher le menu sinon.
        End If

    End Sub

    ' Gestionnaire d'exception global
    Private Sub GlobalExceptionHandler(sender As Object, e As UnhandledExceptionEventArgs)

        Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)

        CustomLogger.Log("Unhandled Exception: " & ex.Message & " Stack Trace: " & ex.StackTrace)

    End Sub

    Private Sub InitializeForm()

        ' Initialiser FichiersRecentsMenuItem
        FichiersRecentsMenuItem = New ToolStripMenuItem("Fichiers récents")

        ' Ajouter les éléments au menu
        Dim unused = FichiersRecentsMenuItem.DropDownItems.Add(New ToolStripSeparator())

        ' Ajouter Effacer fichiers récents
        Dim EffacerFichiersRecentsMenuItem As New ToolStripMenuItem("Effacer fichiers récents")
        AddHandler EffacerFichiersRecentsMenuItem.Click, AddressOf EffacerFichiersRecentsMenuItem_Click
        EffacerFichiersRecentsMenuItem.Name = "EffacerFichiersRecentsMenuItem"
        Dim unused1 = FichiersRecentsMenuItem.DropDownItems.Add(EffacerFichiersRecentsMenuItem)

        ' Associe l'événement Click des boutons

    End Sub

    Public Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        ' Clé AES sous forme de tableau d'octets
        Dim aesKeyHex As String = "52-2E-A3-76-1C-B3-05-90-90-FE-8D-F6-49-17-F1-DB-57-FB-40-9C-07-05-98-90-5B-B8-16-D5-30-58-59-C4"
        Dim aesKey As Byte() = ConvertHexStringToByteArray(aesKeyHex)
        Dim ivHex As String = "E0-8B-1D-E1-AD-95-A1-17-F9-E3-0F-DA-54-EA-BF-30"
        Dim iv As Byte() = ConvertHexStringToByteArray(ivHex)

        ' Chemin vers le fichier log à chiffrer.
        Dim logFilePath As String = $"{My.Application.Info.DirectoryPath}\Resources\logfile.txt"

        ' Vérifier si le fichier d'origine existe.
        If Not File.Exists(logFilePath) Then
            Dim unused = Forms.MessageBox.Show("Le fichier d'origine n'existe pas.")
            Return
        End If

        ' Chiffrer le contenu du fichier log
        Dim originalContent As String = File.ReadAllText(logFilePath)
        Dim encryptedContent As Byte() = AesExample.EncryptStringToBytes_Aes(originalContent, aesKey, iv)

        ' Enregistrer le contenu chiffré dans un fichier
        Dim encryptedFilePath As String = $"{My.Application.Info.DirectoryPath}\Resources\encrypted_logfile.txt"
        File.WriteAllBytes(encryptedFilePath, encryptedContent)

        Dim unused1 = Forms.MessageBox.Show("Le fichier log a été chiffré avec succès.")

    End Sub

    ' Méthode pour convertir une chaîne hexadécimale en tableau d'octets
    Private Function ConvertHexStringToByteArray(hexString As String) As Byte()

        ' Supprimer les caractères non valides de la chaîne hexadécimale
        hexString = New String(hexString.Where(Function(c) "0123456789ABCDEFabcdef".Contains(c)).ToArray())

        ' Vérifier si la longueur de la chaîne hexadécimale est paire
        If hexString.Length Mod 2 <> 0 Then
            Throw New ArgumentException("La chaîne hexadécimale doit avoir une longueur paire.")
        End If

        ' Convertir la chaîne hexadécimale en tableau de bytes
        Dim bytes As Byte() = New Byte((hexString.Length \ 2) - 1) {}
        For i As Integer = 0 To bytes.Length - 1
            bytes(i) = Convert.ToByte(hexString.Substring(i * 2, 2), 16)
        Next
        Return bytes

    End Function

    ' Méthode pour générer des octets aléatoires pour l'IV
    Private Function GetRandomBytes(length As Integer) As Byte()

        Dim randomBytes As Byte() = New Byte(length - 1) {}
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(randomBytes)
        End Using
        Return randomBytes

    End Function

    Public Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click

        Dim aesKey As Byte() = ConvertHexStringToByteArray("52-2E-A3-76-1C-B3-05-90-90-FE-8D-F6-49-17-F1-DB-57-FB-40-9C-07-05-98-90-5B-B8-16-D5-30-58-59-C4")
        Dim iv As Byte() = ConvertHexStringToByteArray("E0-8B-1D-E1-AD-95-A1-17-F9-E3-0F-DA-54-EA-BF-30")

        ' Appeler la procédure pour déchiffrer le fichier log.
        Dim EncryptedFilePath As String = $"{My.Application.Info.DirectoryPath}\Resources\encrypted_logfile.txt"
        Dim decryptedFilePath As String = $"{My.Application.Info.DirectoryPath}\Resources\decrypted_logfile.txt"

        ' Lire les données chiffrées sous forme de tableau de bytes.
        Dim encryptedBytes As Byte() = File.ReadAllBytes(EncryptedFilePath)

        ' Appeler la méthode de déchiffrement.
        Dim decryptedContent As String = AesExample.DecryptStringFromBytes_Aes(encryptedBytes, aesKey, iv)

        ' Écrire le contenu déchiffré dans un fichier.
        File.WriteAllText(decryptedFilePath, decryptedContent)

        ' Afficher le contenu déchiffré.
        Dim unused = Forms.MessageBox.Show($"Contenu déchiffré :{Environment.NewLine}{decryptedContent}", "Information")

    End Sub

    Public Function GetCurrentUserRole() As String

        ' Récupérer le nom d'utilisateur actuel
        Dim currentUser As String = GetUserName()

        ' Vérifier si l'utilisateur actuel est l'administrateur
        If currentUser.ToLower() = "admin" Then
            Return "Admin"
        Else
            ' Si ce n'est pas l'administrateur, retourner un rôle par défaut
            Return "DefaultRole"
        End If

    End Function

    Private Sub ÀproposdeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÀproposdeToolStripMenuItem.Click

        Dim number As Integer = 4
        Select Case number
            Case 1

            Case 2

            Case 3

            Case Else
                Dim oForm As About
                oForm = New About()
                oForm.Show()
        End Select

    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click

        If Forms.MessageBox.Show("Quitter l'application ?", "Prenommer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            Forms.Application.Exit()
        End If

    End Sub

    ' Gestionnaire de l'événement FormClosing du formulaire
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim efface, SUPPRIME As Integer
        Dim Msg As String
        Dim Cancel As Boolean
        Dim UnloadMode As Object = Nothing
        Dim vbFormControlMenu As Object = Nothing
        Dim vbAppWindows As Object = Nothing
        Dim vbAppTaskManager As Object = Nothing

        Try

            ' Si le formulaire est déjà en cours de fermeture, ne rien faire
            If isFormClosing Then
                Return
            End If

            ' Marquer le formulaire comme étant en cours de fermeture
            isFormClosing = True

            ' Réinitialiser la couleur de fond de TextBox5 à blanche
            'TextBox5.BackColor = System.Drawing.Color.White

            ' Ajoutez une instruction de débogage pour afficher la valeur de logFilePath.
            'Debug.WriteLine("logFilePath avant TracingTest : " & logFilePath)

            ' Appel de TracingTest avec le chemin réel du fichier de journalisation.
            TracingTest(logFilePath)

            ' Ajoutez une instruction de débogage pour afficher un message lorsque l'événement est déclenché.
            Dim unused3 = Forms.MessageBox.Show("Le formulaire se ferme !", "Prénommer")

            ' Sauvegarder les paramètres de l'application.
            My.Settings.Save()

            If UnloadMode Is vbFormControlMenu Or UnloadMode Is vbAppWindows Or UnloadMode Is vbAppTaskManager Then
                Msg = "Voulez-vous vraiment quitter l'application en cours ?"
                If MsgBox(Msg, CType(vbYesNo + vbQuestion, Global.Microsoft.VisualBasic.MsgBoxStyle), My.Application.Info.Title) = vbNo Then
                    Cancel = True

                    For Each f As Form In My.Application.OpenForms
                        If f.Name = "Main" Then
                            e.Cancel = True
                        End If
                    Next

                Else

                    Cancel = False
                    quitté = 1

                    Dim formTitles As New Collection
                    Try
                        For Each f As Form In My.Application.OpenForms
                            ' Utilisez une méthode thread-safe pour obtenir tous les titres de formulaire.
                            formTitles.Add(GetFormTitle(f))
                        Next
                    Catch ex As Exception
                        formTitles.Add("Erreur : " & ex.Message)
                    End Try
                    ListBox3.DataSource = formTitles

                    If Clipboard.GetDataObject.GetDataPresent(DataFormats.Text) Then
                        efface = MsgBox("Voulez-vous effacer les données de type texte du Presse-papiers ?", CType(4 + 48 + 0, MsgBoxStyle), "Effacer le Presse-papiers")
                        If efface = 6 Then Clipboard.Clear()
                    End If

                    Dim directoryPath1 As String = My.Application.Info.DirectoryPath

                    If Computer.FileSystem.DirectoryExists(directoryPath1 & "\Temp\") Then
                        Dim msgBoxResult As MsgBoxResult = MsgBox("Voulez-vous supprimer les fichiers temporaires créés par le programme ?", CType(4 + 48 + 0, MsgBoxStyle), My.Application.Info.Title)
                        SUPPRIME = msgBoxResult

                        Try
                            If SUPPRIME = 6 Then
                                Dim PATHDOSSIER As String = My.Application.Info.DirectoryPath & "\Temp\"
                                Dim paths() As String = Directory.GetFiles(PATHDOSSIER, "*.*")
                                If paths.Length > 0 Then
                                    For Each f As String In paths
                                        File.Delete(f)
                                    Next
                                End If
                            End If
                        Catch ex As Exception
                            Dim unused = Forms.MessageBox.Show("IOException Handler: {0}", ex.ToString())
                        End Try
                    End If
                End If
            End If

            ' Ajoutez une instruction de débogage pour afficher la valeur de logFilePath.
            'Dim unused2 = Forms.MessageBox.Show("logFilePath : " & logFilePath)

            ' Appel de TracingTest avec le chemin réel du fichier de journalisation.
            TracingTest(logFilePath)

            ' Attendez 1 seconde avant la fermeture de l'application.
            Thread.Sleep(1000)

            CustomLogger.Log("Application closing...")
            ' Code pour gérer la fermeture proprement, par exemple sauvegarder des données ou libérer des ressources

        Catch ex As Exception
            Dim dialogResult1 = Forms.MessageBox.Show(ex.ToString())

        End Try

        Try

        Catch ex As Exception
            ' Gérez les exceptions et enregistrez-les dans le journal.
            My.Application.Log.WriteException(ex, TraceEventType.Error, $"Une erreur s'est produite dans TracingTest : {ex.Message}")

        End Try

        Try

            QuitterApplication()

        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

    Public Sub CleanupResources()

        For Each process As Process In Process.GetProcessesByName("WINWORD")
            Try
                process.Kill() ' Tuer le processus Word
            Catch ex As Exception
                Dim unused = MsgBox($"Impossible de fermer le processus Word : {ex.Message}")
            End Try
        Next

    End Sub

    Private Sub QuitterApplication()

        Try
            CleanupResources()
            Forms.Application.Exit()
        Catch ex As Exception
            Dim unused = MsgBox($"Erreur lors de la fermeture de l'application : {ex.Message}")
        End Try

    End Sub

    Private Sub CréerunfichierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréerunfichierToolStripMenuItem.Click

        Dim oForm As Create
        oForm = New Create()

        InitializeEvents()
        ListView1.SelectedItems.Clear()
        ToolStripStatusLabel3.Text = "Aucun fichier sélectionné"
        ToolStripStatusLabel3.Image = DocumentError_16x

        oForm.Show()

    End Sub

    Private Sub ImporterlibrairiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImporterlibrairiesToolStripMenuItem.Click

        Dim myDirectory As String = String.Empty
        Dim resultat As String = String.Empty
        Dim appPath As String = String.Empty

        Try

            ToolStripStatusLabel4.Text = "IMPORTATION"

            Dim OpenFileDialog1 As New Forms.OpenFileDialog With {
    .InitialDirectory = My.Application.Info.DirectoryPath & "\" & "Téléchargements",
    .Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*|Fichiers librairie (*.librairie)|*.librairie",
    .FilterIndex = 3,
    .RestoreDirectory = True,
    .Multiselect = False
}

            If CType(OpenFileDialog1.ShowDialog(), Global.System.Windows.Forms.DialogResult) = CType(True, Global.System.Windows.Forms.DialogResult) Then
                ' Obtenir le chemin du fichier spécifié.
                myDirectory = OpenFileDialog1.FileName
                resultat = System.IO.Path.GetFileName(myDirectory)
            End If

            If Directory.Exists(myDirectory) Then
                If Directory.GetDirectories(myDirectory).Length = 0 And Directory.GetFiles(myDirectory).Length = 0 Then
                    Dim msgBoxResult = MsgBox(String.Format("{0} est vide", myDirectory))
                End If
            End If

            Dim dialogResult = Forms.MessageBox.Show($"Êtes-vous sûr de vouloir remplacer la librairie {resultat} ?",
                                        "Confirmation de remplacement", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

            If dialogResult = Forms.DialogResult.Yes Then
                appPath = My.Application.Info.DirectoryPath & "\" & "Librairies\" & resultat
                ' Code à exécuter si l'utilisateur a cliqué sur Oui.

                Dim sourceFilePath As String = My.Application.Info.DirectoryPath & "\" & "Téléchargements\" & resultat
                Dim destinationFilePath As String = My.Application.Info.DirectoryPath & "\" & "Librairies\" & resultat

                If Computer.FileSystem.FileExists(destinationFilePath) Then
                    Computer.FileSystem.DeleteFile(destinationFilePath)
                End If

                Computer.FileSystem.CopyFile(My.Application.Info.DirectoryPath & "\" & "Téléchargements\" & resultat, My.Application.Info.DirectoryPath & "\" & "Librairies\" & resultat)

                If Not String.IsNullOrEmpty(appPath) AndAlso CheckExistItem(resultat) Then
                    Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\" & "Téléchargements\" & resultat,
UIOption.AllDialogs,
RecycleOption.DeletePermanently,
UICancelOption.DoNothing)
                End If

            Else

                ' Code à exécuter si l'utilisateur a cliqué sur Non.

                Return

            End If

            ListView1.BeginUpdate()
            Dim applPath As String = My.Application.Info.DirectoryPath & "\" & "Librairies\"
            ListView1.Items.Clear()
            If Not Computer.FileSystem.FileExists(applPath) Then
                For Each fileName As String In Directory.GetFiles(applPath)
                    ImageList1.Images.Add(ImageList1.Images(0))
                    Dim listViewItem = ListView1.Items.Add(text:=System.IO.Path.GetFileName(fileName), ImageList1.Images.Count - 1)
                Next
            End If
            ListView1.EndUpdate()

        Catch ex As Exception
            ' Afficher les messages d'exception.
            Dim dialogResult1 = Forms.MessageBox.Show(ex.Message)

            ' Afficher la trace de la pile, qui est une liste de méthodes en cours d'exécution.
            Dim dialogResult2 = Forms.MessageBox.Show("Stack Trace :    " & vbCrLf & ex.StackTrace)
        Finally
            ' Cette ligne s'exécute dès que l'exception se produit ou non.
            Dim dialogResult1 = Forms.MessageBox.Show("L'exécution du processus est terminée.")

        End Try

    End Sub

    Public Sub ReplaceFile(FileToMoveAndDelete As String, FileToReplace As String, BackupOfFileToReplace As String)

        ' Remplacer le fichier.
        File.Replace(FileToMoveAndDelete, FileToReplace, BackupOfFileToReplace, False)

    End Sub

    Public Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        lit = 1 : modifié = 0 : sauvé = 0 : ajouté = 0 : supprimé = 0
        ListeToolStripMenuItem.Enabled = True : ModifierToolStripMenuItem1.Enabled = False : NouvelleficheToolStripMenuItem.Enabled = False : SupprimerToolStripMenuItem.Enabled = False
        NouveauToolStripButton.Enabled = False : EnregistrerToolStripButton.Enabled = False : ListeToolStripButton.Enabled = True : ToolStripButton5.Enabled = False

        ' Début du processus de création de fichiers temporaires.
        If ListView1.SelectedItems.Count > 0 Then
            EXTListem = System.IO.Path.GetFileName(ListView1.SelectedItems(0).Text)
            Listem = System.IO.Path.GetFileNameWithoutExtension(ListView1.SelectedItems(0).Text)
        End If

        Dim basePath As String = $"{My.Application.Info.DirectoryPath}\Temp\"          'Dim basePath As String = Path.GetTempPath()
        Dim filename As String
        Do
            Dim uniqueId As String = Guid.NewGuid().ToString("N") ' Génère un GUID sans tirets
            filename = System.IO.Path.Combine(basePath, uniqueId + "-" + Listem + ".tmp")
        Loop While File.Exists(filename)

        Dim sourcePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Librairies", EXTListem)
        Dim destinationPath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Temp", filename)

        Try
            Computer.FileSystem.CopyFile(
sourcePath,
destinationPath,
UIOption.OnlyErrorDialogs,
UICancelOption.DoNothing)
        Catch ex As Exception
            Dim unused = Forms.MessageBox.Show("Erreur lors de la copie du fichier: " & ex.Message)
        End Try
        ' Fin du processus de création de fichiers temporaires.

        If ListView1.SelectedItems.Count > 0 Then
            Dim var1 As String
            var1 = ListView1.SelectedItems(0).Text
            ToolStripStatusLabel3.Text = var1 & " : Fichier ouvert"
            Dim chaine As String = ToolStripStatusLabel3.Text
            TexteChaine = chaine.Substring(0, Len(ToolStripStatusLabel3.Text) - 17)
        End If

        Dim sFichier As String = My.Application.Info.DirectoryPath & "\Librairies\" & TexteChaine
        Try
            Dim FS As FileStream = File.Open(sFichier, FileMode.Open,
                                       FileAccess.Read, FileShare.None)
            ' Ouverture Ok, donc non déjà ouvert : referme.
            FS.Close()
            FS.Dispose()
            FS = Nothing

        Catch ex As IOException
            Dim msgBoxResult = MsgBox("""" & sFichier & """ déjà ouvert" & Environment.NewLine & ex.Message)
        Catch ex As Exception
            Dim dialogResult1 = Forms.MessageBox.Show("Erreur inconnue" & Environment.NewLine & ex.Message)
        End Try

        ToolStripStatusLabel3.Image = DocumentOK_16x

        ListBox2.Items.Clear()
        TreeView1.Nodes.Clear()
        TreeView1.Enabled = True

        InitializeEvents()

        ToolStripTextBox1.Text = ""
        ListeToolStripMenuItem.Enabled = True
        ListeToolStripButton.Enabled = True

    End Sub

    Private Sub SupprToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprToolStripMenuItem.Click

        Dim FileToDelete As String

        Try

            If ListView1.SelectedItems.Count = 0 Then
                Dim msgBoxResult As MsgBoxResult = MsgBox("Vous devez sélectionner un élément pour pouvoir le supprimer !", CType(vbOKOnly + vbExclamation, MsgBoxStyle), "Erreur")
                Exit Sub
            ElseIf ListView1.SelectedItems.Count > 0 Then
                Var1 = ListView1.SelectedItems(0).Text
            End If

            If TreeView1.Nodes.Count = Nothing Then
                Dim result = Forms.MessageBox.Show("Êtes-vous sûr de vouloir fermer le formulaire ?",
                                    "Fermeture de l'événement", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = DialogResult.Yes Then
                    Close()
                Else
                    Return
                End If

                FileToDelete = My.Application.Info.DirectoryPath & "\Librairies\" & Var1

                If File.Exists(FileToDelete) Then
                    FileSystem.DeleteFile(FileToDelete, UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing)

                    Dim dialogResult1 = Forms.MessageBox.Show("Fichier supprimé placé dans la corbeille !")

                    ListView1.BeginUpdate()
                    ListView1.Items.Clear()
                    If Not Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Librairies\") Then
                        For Each fileName As String In Directory.GetFiles(My.Application.Info.DirectoryPath & "\Librairies\")
                            ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName))
                            Dim listViewItem = ListView1.Items.Add(System.IO.Path.GetFileName(fileName), 0)
                        Next
                    End If
                    ToolStripStatusLabel1.Text = ListView1.Items.Count & " librairies chargées"
                    ToolStripStatusLabel3.Text = "Aucun fichier sélectionné"
                    ListView1.EndUpdate()
                    ListView1.Refresh()

                    ToolStripStatusLabel1.Text = ListView1.Items.Count & " librairies chargées"
                    ToolStripStatusLabel3.Text = "Aucun fichier sélectionné"

                End If

            Else
                Dim dialogResult1 = Forms.MessageBox.Show("Sélectionnez exclusivement le fichier librairie que vous souhaitez supprimer. Ne développez pas cette librairie.")
                Exit Sub

            End If

            If IsDisposed OrElse Disposing Then
                ' Le formulaire parent est fermé ou en cours de fermeture.
                Return
            End If

            If ListView1 IsNot Nothing AndAlso ToolStripTextBox1 IsNot Nothing Then
                ToolStripTextBox1.Text = CStr(ListView1.Items.Count)
            End If

        Catch ex As Exception
            Dim dialogResult1 = Forms.MessageBox.Show(ex.Message)

            Dim dialogResult2 = Forms.MessageBox.Show("Stack Trace :  " & vbCrLf & ex.StackTrace)

        Finally
            Dim dialogResult1 = Forms.MessageBox.Show("L'exécution du processus est terminée.")

        End Try

    End Sub

    Public Sub InitializeEvents()

        Dim Var1 As String

        Cursor = Cursors.WaitCursor
        ToolStripTextBox1.Text = ""

        ToolStripStatusLabel3.Text = "Ouverture en cours..."
        ToolStripStatusLabel4.Text = "INITIALISATION"

        If ListView1.SelectedItems.Count > 0 Then
            Var1 = ListView1.SelectedItems(0).Text
        Else
            Cursor = Cursors.Default
            Exit Sub
        End If

        TextBox5.Enabled = True

        Try
            Dim textBoxes() As Forms.TextBox = {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}

            For Each txt In textBoxes
                txt.Clear()
            Next
            RichTextBox1.Clear()

            PictureBox1.Image = Nothing
            PictureBox1.ImageLocation = ""

            TreeView1.BeginUpdate()
            TreeView1.SelectedNode = Nothing
            TreeView1.Nodes.Clear()
            TreeView1.EndUpdate()

            ToolStripTextBox1.Text = ""

            Cursor = Cursors.Default

        Catch ex As Exception
            Dim unused = Forms.MessageBox.Show("Une erreur s'est produite lors de la réinitialisation des contrôles : " & ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ToolStripStatusLabel2.Text = Date.Now.ToString("dd/MM/yyyy | HH: mm:ss")

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        TextBox2.Text = CStr(ComboBox1.Items(ComboBox1.SelectedIndex))

        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(New Object() {"Bienheureuse ", "Bienheureuses ", "Bienheureux ", "Fête mariale ", "Fête religieuse ", "Saint ", "Sainte ", "Saintes ", "Saints ", "Sanctuaire marial ", "Servante de Dieu ", "Servantes de Dieu ", "Servants de Dieu ", "Serviteur de Dieu ", "Serviteurs de Dieu ", "Vénérable ", "Vénérables "})

    End Sub

    Private Sub AjouterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterToolStripMenuItem.Click

        Dim form As New Append
        form.Show()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        TextBox15.Text = CStr(ComboBox2.Items(ComboBox2.SelectedIndex))

        ComboBox2.Items.Clear()
        ComboBox2.Items.AddRange(New Object() {"A.A. | Assomptionnistes (Congrégation des Augustins de l'Assomption)", "B. | Barnabites (Clercs réguliers de Saint-Paul)", "Brig. | Brigittin(e)s (Frères et Sœurs du Saint-Sauveur et de Sainte Brigitte)", "C.I.C.M | Scheutistes (Congrégation du Cœur Immaculé de Marie)", "C.J.M | Eudistes (Congrégation de Jésus et Marie)", "Clar. | Clarisses", "C.M. | Lazaristes (Congrégation de la Mission)", "C.M.F. | Missionnaires Clarétains", "C.P. | Passionistes (Congrégation de la Passion de Jésus-Christ)", "C.Ss.R. | Rédemptoristes ou Liguoriens (Congrégation du Très Saint Rédempteur)", "F.C. | Fils de la charité", "F.D.M. | Frères de Notre-Dame de Miséricorde", "F.d.S. | Filles de la Sagesse de Saint-Laurent-sur-Sèvre", "F.E.C. / F.S.C. | Lasalliens (Frères des Écoles Chrétiennes)", "F.M.M. | Franciscaines Missionnaires de Marie (de Rome)", "F.M.S. | Frères Maristes (Petits Frères de Marie)", "I.C.M. | Missionnaires du Cœur Immaculé de Marie", "L.S.N.S. | Apostolines du Très Saint-Sacrement (Dames de Sainte-Julienne)", "M.Afr. | Pères Blancs (Société des Missionnaires d'Afrique)", "M.R. | Société de Marie Réparatrice", "M.S.C. | Missionnaires du Sacré-Cœur de Jésus", "M.S.F. | Missionnaires de la Sainte-Famille", "O.Bas. | Basiliens", "O.C. | Grands carmes (Carmes de l’Antique Observance, Carmélites de la Primitive Observance)", "O.Cart. | Chartreux, chartreuses (ou chartreusines)", "O.C.D. | Carmes Déchaux, carmélites déchaussées", "O.Cist. | Cisterciens, cisterciennes", "O.C.S.O. | Trappistes, trappistines (Ordre Cistercien de la Stricte Observance)", "O.D.V. | Visitandines (Ordre de la Visitation)", "O.F.M. | Franciscain(e)s (sauf clarisses) (Ordre des Frères Mineurs)", "O.F.M.Conv. | Franciscains conventuels (Ordre des Frères Mineurs conventuels)", "O.F.M.Cap. | Capucins (Frères Mineurs Capucins)", "O.H. | Ordre Hospitalier de Saint-Jean de Dieu (Frères de Saint Jean de Dieu)", "O. de M. | Mercédaires (Ordre de Notre-Dame de la Miséricorde)", "O.M.I. | Missionnaires Oblats de Marie Immaculée", "O.M. | Minimes (Ordre des Minimes)", "O.P. | Dominicains, Frères Prêcheurs (Ordre de Prédicateurs)", "O.Praem. | Prémontrés (Chanoines Réguliers de Prémontré)", "Orat. | Oratoriens (Confédération de l’Oratoire de Saint-Philippe Néri)", "O.S.A. | Augustin(e)s (Ordre de Saint-Augustin ou des Augustins)", "O.S.B. | Bénédictin(e)s (Ordre de Saint-Benoît)", "O.S.B.Cam. | Camaldules (Congrégation Bénédictine des Moines-ermites Camaldules)", "O.S.B.Cél. | Célestins (Congrégation Bénédictine des Célestins)", "O.S.B.Sil. | Silvestrins (Congrégation Bénédictine des Silvestrins)", "O.S.B.Val. | Vallombrosans (Congrégation Bénédictine de Vallombreuse)", "O.S.B.Hum. | Humiliés (Congrégation Bénédictine de l’Humiliation)", "O.S.B.Mont | Montevirginiens (Congrégation Bénédictine de Monte Virgine)", "O.S.B.Oliv. | Olivétains (Congrégation Bénédictine de Monte Oliveto)", "O.S.M. | Servites (Ordre des Serviteurs de Marie)", "O.SS.T. | Trinitaires (Ordre de la Très-Sainte-Trinité)", "Paul. | Paulistes (Ordre de Saint-Paul l’Ermite)", "P.F.J. | Petits Frères de Jésus du Père de Foucauld", "P.I.M.E. | Institut pontifical pour les missions étrangères", "P.S.S. | Sulpiciens (Prêtres de Saint-Sulpice)", "R.S.C.J. | Religieuses du Sacré-Cœur de Jésus (Société du Sacré-Cœur de Jésus)", "Sal. / S.D.B. | Salésiens (Congrégation des Salésiens de Don Bosco)", "S.C. | Crucistes (Congrégation de la Sainte-Croix)", "S.C.J. | Prêtres du Sacré-Cœur de Jésus", "S.D.S. | Salvatoriens (Société du Divin Sauveur)", "S.G. | Frères de Saint-Gabriel (Frères de l'Instruction Chrétienne de Saint-Gabriel)", "S.P. | Piaristes (Congrégation des écoles pies)", "S.J. ou d.C.d.G. | Jésuites (Compagnie de Jésus)", "S.M. | Pères Maristes (Société de Marie)", "S.M.A. | Société des Missions Africaines", "S.M.M. | Missionnaires Montfortains", "SS.CC. | Pères des Sacrés-Cœurs / Picpus (Congrégation des Sacrés-Cœurs de Jésus et de Marie et de l'Adoration Perpétuelle du Très-Saint-Sacrement de l'Autel)", "S.U.S.C. | Religieuses de la Sainte-Union des Sacrés-Cœurs", "Urs. | Ursulines (Ordre de Sainte-Ursule)"})

    End Sub

    Private Sub NouvelleficheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NouvelleficheToolStripMenuItem.Click

        ' Réinitialiser PictureBox1 à une image neutre
        PictureBox1.Image = Image_16x_1
        TextBox2.Clear()

        ToolStripStatusLabel4.Text = "CRÉATION d’enregistrement (écriture dans le fichier)"

        Dim bibliotheque As New Article
        Dim NumeroDeLigne As Integer

        bNeedsFurtherProcessing = True

        TextBox1.Clear() : TextBox5.Clear()

        lit = 0 : modifié = 0 : sauvé = 1 : ajouté = 0 : supprimé = 0
        ListeToolStripMenuItem.Enabled = False : ModifierToolStripMenuItem1.Enabled = False : NouvelleficheToolStripMenuItem.Enabled = False : SupprimerToolStripMenuItem.Enabled = False
        NouveauToolStripButton.Enabled = False : EnregistrerToolStripButton.Enabled = True : ListeToolStripButton.Enabled = False : ToolStripButton5.Enabled = False

        ' Si aucun élément n'est sélectionné.
        If ListView1.SelectedItems.Count = 0 Then
            Dim msgBoxResult = MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", CType(vbYes, MsgBoxStyle), "Erreur")

        Else
            Dim messageBoxResult = Forms.MessageBox.Show("Veuillez saisir un nom qui n'apparaît pas dans la zone de liste.")

            ComboBox1.Enabled = True : ComboBox2.Enabled = True : DateTimePicker1.Enabled = True

            For Each txt In {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}
                txt.ReadOnly = False
            Next
            RichTextBox1.ReadOnly = False

            NumeroDeLigne = ListView1.SelectedIndices(0)
            OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NumeroDeLigne).Text

            For I As Integer = 0 To ListView1.Items.Count - 1
                If ListView1.Items(I).Index = NumeroDeLigne Then
                    ListView1.Items(I).Selected = True
                End If
            Next

            InitializeEvents()

            My.Application.DoEvents()

            UpdateAutoComplete()

        End If

    End Sub

    Private Function RemoveDiacritics(input As String) As String

        Dim normalizedString As String = input.Normalize(NormalizationForm.FormD)
        Dim stringBuilder As New StringBuilder()

        For Each c As Char In normalizedString
            If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark Then
                Dim unused = stringBuilder.Append(c)
            End If
        Next

        Return stringBuilder.ToString().Normalize(NormalizationForm.FormC)

    End Function

    Private Sub ListeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListeToolStripMenuItem.Click

        ToolStripStatusLabel4.Text = "LECTURE d’enregistrement (lecture du fichier)"

        Dim bibliotheque As New Article
        Dim NumeroDeLigne As Integer

        lit = 0 : modifié = 1 : sauvé = 0 : ajouté = 1 : supprimé = 1
        ListeToolStripMenuItem.Enabled = False : ModifierToolStripMenuItem1.Enabled = True : NouvelleficheToolStripMenuItem.Enabled = True : SupprimerToolStripMenuItem.Enabled = True
        NouveauToolStripButton.Enabled = True : EnregistrerToolStripButton.Enabled = False : ListeToolStripButton.Enabled = False : ToolStripButton5.Enabled = True

        Dim myFile As New FileInfo(My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.SelectedItems(0).Text.ToString())
        Dim sizeInBytes As Long = myFile.Length
        If sizeInBytes < 3188 Then
            Dim dialogResult1 = Forms.MessageBox.Show("La longueur du fichier n'excède pas 3188 octets (3.188000 Ko) — depuis décembre 1998, l'organisme international IEC a standardisé ces unités : un kilooctet (ko ou kB) = 1000 octets — plus exactement " & sizeInBytes & " octets ; l'application n'examine que les fichiers pourvus d'au moins un enregistrement.", "Prénommer")
            Exit Sub
        End If

        ' Si aucun élément n'est sélectionné.
        If ListView1.SelectedItems.Count = 0 Then
            Dim msgBoxResult = MsgBox("Vous devez sélectionner un élément pour pouvoir le lire !", CType(vbYes, MsgBoxStyle), "Erreur")

        Else

            Cursor = Cursors.WaitCursor

            PictureBox3.Visible = True

            ComboBox1.Enabled = False : ComboBox2.Enabled = False : DateTimePicker1.Enabled = False

            ListeToolStripMenuItem.Enabled = False
            ListeToolStripButton.Enabled = False

            NumeroDeLigne = ListView1.SelectedIndices(0)
            OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NumeroDeLigne).Text
            OuvrirXML = My.Application.Info.DirectoryPath & "\Temp\" & System.IO.Path.GetFileNameWithoutExtension(ListView1.Items(NumeroDeLigne).Text) & ".xml"

            ToolStripProgressBar1.Minimum = 0

            ' Effacer tous les nœuds existants dans TreeView1 avant d'ajouter de nouveaux nœuds
            TreeView1.Nodes.Clear()
            Console.WriteLine("Nœuds existants effacés")

            ' Créer un nouveau nœud "Librairie"
            Dim rootNode As New TreeNode("Librairie") With {
                .Name = "IdentifiantUniqueDeLaFiche"
            }
            Dim unused10 = TreeView1.Nodes.Add(rootNode)
            Console.WriteLine("Nœud 'Librairie' ajouté")

            ' Sauvegarder l'identifiant de la fiche
            My.Settings.LastAddedFicheID = rootNode.Name
            My.Settings.Save()
            Console.WriteLine("Identifiant de la fiche sauvegardé")

            ' Effacer tous les nœuds enfants existants avant d'ajouter les nouvelles fiches
            rootNode.Nodes.Clear()
            Console.WriteLine("Nœuds enfants de 'Librairie' effacés")

            ' Obtenir la liste des fiches
            Dim listeDeFiches As IEnumerable(Of Fiche) = ObtenezLaListeDeFiches()
            If listeDeFiches IsNot Nothing AndAlso listeDeFiches.Any() Then
                For Each fiche As Fiche In listeDeFiches
                    If fiche IsNot Nothing AndAlso Not String.IsNullOrEmpty(fiche.Nom) Then
                        ' Vérifiez si le nœud existe déjà avant de l'ajouter
                        Dim nodeExists As Boolean = False
                        For Each node As TreeNode In rootNode.Nodes
                            If node.Name = fiche.IDUnique OrElse node.Text = fiche.Nom Then
                                nodeExists = True
                                Exit For
                            End If
                        Next

                        If Not nodeExists Then
                            Dim node As New TreeNode(fiche.Nom) With {
                    .Name = fiche.IDUnique
                }
                            Dim unused11 = rootNode.Nodes.Add(node)
                            Console.WriteLine("Fiche ajoutée sous 'Librairie' : " & fiche.Nom)
                        Else
                            Console.WriteLine("Fiche déjà ajoutée : " & fiche.Nom)
                        End If
                    Else
                        Console.WriteLine("Fiche vide ou invalide")
                    End If
                Next

                RechercherEtSelectionnerNoeudDansCollection(TreeView1.Nodes, TextBox1.Text)

                If rootNode.Nodes.Count > 0 Then
                    'Réinitialiser les couleurs des nœuds
                    For Each node As TreeNode In rootNode.Nodes
                        node.BackColor = System.Drawing.Color.White
                    Next

                    'Rechercher la fiche (normalisation des chaînes)
                    Dim targetNode As TreeNode = Nothing
                    Dim searchText = RemoveDiacritics(TextBox1.Text)

                    For Each node As TreeNode In rootNode.Nodes
                        If RemoveDiacritics(node.Text) = searchText Then
                            targetNode = node
                            Exit For
                        End If
                    Next

                    'Sélectionner et surligner la fiche trouvé
                    If targetNode IsNot Nothing Then
                        Dim unused12 = MsgBox("Fiche surlignée : " & targetNode.Text)
                        TreeView1.SelectedNode = targetNode
                        targetNode.BackColor = System.Drawing.Color.Yellow
                        targetNode.EnsureVisible()
                    Else
                        Dim unused13 = MsgBox("Fiche introuvable")
                    End If
                End If

            Else
                Dim unused8 = Forms.MessageBox.Show("La liste de fiches est vide ou n'a pas pu être chargée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Console.WriteLine("Message d'erreur affiché")
            End If

            TreeView1.Sort()

            ' Sauvegarder les références nécessaires aux nœuds avant le tri
            rootNode = If(TreeView1.Nodes.Count > 0, TreeView1.Nodes(0), Nothing)
            TreeView1.Sort()

            ToolStripProgressBar1.Maximum = TreeView1.Nodes.Count
            ToolStripProgressBar1.Step = 1

            Try
                Dim readText() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                Dim s As String
                For Each s In readText
                    If s.Length >= 3188 Then
                        TextBox2.Text = Trim(Mid(s, 1, 18))
                        TextBox1.Text = Trim(Mid(s, 19, 90))
                        TextBox4.Text = Trim(Mid(s, 109, 120))
                        TextBox15.Text = Trim(Mid(s, 229, 120))
                        TextBox5.Text = Trim(Mid(s, 349, 120))
                        TextBox7.Text = Trim(Mid(s, 469, 120))
                        TextBox9.Text = Trim(Mid(s, 589, 120))
                        TextBox13.Text = Trim(Mid(s, 709, 120))
                        TextBox18.Text = Trim(Mid(s, 829, 120))
                        TextBox23.Text = Trim(Mid(s, 949, 120))
                        TextBox24.Text = Trim(Mid(s, 1069, 120))
                        TextBox25.Text = Trim(Mid(s, 1189, 120))
                        TextBox26.Text = Trim(Mid(s, 1309, 120))
                        TextBox28.Text = Trim(Mid(s, 1429, 120))
                        TextBox29.Text = Trim(Mid(s, 1549, 120))
                        TextBox33.Text = Trim(Mid(s, 1669, 120))
                        TextBox31.Text = Trim(Mid(s, 1789, 1200))
                        RichTextBox1.Text = Trim(Mid(s, 2989, 200))

                        ' Ajouter le nœud à TreeView1 et ListBox2
                        Dim node As TreeNode = TreeView1.Nodes(0)
                        Dim v2 = TreeView1.Nodes(0).Nodes.Add(New TreeNode(Trim(TextBox1.Text)))
                        Dim v3 = ListBox2.Items.Add(TextBox1.Text)
                        ToolStripProgressBar1.PerformStep()
                    End If
                Next

                Dim li As List(Of String) = File.ReadAllLines(OuvrirFichier).ToList()
                If String.IsNullOrEmpty(li.Last()) Then
                    li.RemoveAt(li.Count - 1)
                End If
                File.WriteAllLines(OuvrirFichier, li.ToArray())

            Catch ext As IndexOutOfRangeException
                Dim dialogResult1 = Forms.MessageBox.Show(ext.Message)
                Dim dialogResult2 = Forms.MessageBox.Show("Stack Trace : " & vbCrLf & ext.StackTrace)
            Catch exc As ArgumentOutOfRangeException
                Dim dialogResult1 = Forms.MessageBox.Show(exc.Message)
                Dim dialogResult2 = Forms.MessageBox.Show("Stack Trace : " & vbCrLf & exc.StackTrace)
            End Try
            TextBox2.Clear()
            Cursor = Cursors.Default
        End If
        Dim treeNodes As TreeNode() = TreeView1.Nodes.Cast(Of TreeNode)().Where(Function(r) r.Text Is TextBox1.Text).ToArray()
        Dim C As New Class5

        C.SauveTreeView(TreeView1, OuvrirXML)
        C.ChargeTreeView(TreeView1, OuvrirXML)

        Dim FichierInfo As New FileInfo(OuvrirFichier)
        Dim TailleFichier As Integer = CInt(FichierInfo.Length)

        If TailleFichier > 0 Then
            Dim nodeText As String = Trim(TextBox1.Text)
            Dim ctl As Forms.Control = ActiveControl
            Dim treeView As Forms.TreeView = TryCast(ctl, Forms.TreeView)

            If treeView Is Nothing Then
                treeView = If(treeView, New Forms.TreeView()) ' treeView = New Forms.TreeView()
            End If

            Dim searchText As String = "TexteRecherché" ' Déclare et initialise la chaîne recherchée
            Dim rootNode As TreeNode = treeView.TopNode ' Obtenez le nœud racine du TreeView, s'il existe

            If treeView.Nodes.Count > 0 Then
                Dim foundNode As TreeNode = FindNodeByText(treeView.Nodes, "TexteRecherché")
                If foundNode IsNot Nothing Then
                    Dim unused4 = MsgBox($"Nœud trouvé : {foundNode.Text}")
                Else
                    Dim unused7 = MsgBox("Aucun nœud trouvé.")
                End If
            End If

            If treeView.Nodes.Count > 0 Then
                Dim unused14 = MsgBox($"Nombre de nœuds racines : {treeView.Nodes.Count}")
                Dim unused15 = MsgBox($"Nom du premier nœud racine : {treeView.Nodes(0).Text}")
            End If

            If treeView.Nodes.Count > 0 Then
                rootNode = treeView.Nodes(0) ' Assurez-vous que le nœud racine est accessible
                If rootNode IsNot Nothing AndAlso rootNode.Text = "Librairie" Then
                    Dim targetNode As TreeNode = FindNodeByText(rootNode.Nodes, searchText)
                    If targetNode IsNot Nothing Then
                        Dim unused16 = MsgBox($"Nœud trouvé : {targetNode.Text}")
                    Else
                        Dim unused17 = MsgBox("Aucun nœud trouvé.")
                    End If
                Else
                    Dim unused18 = MsgBox("Le nœud racine attendu ('Librairie') n'a pas été trouvé.")
                End If
                'Else
                'MsgBox("Aucun nœud racine trouvé.")
            End If

            If TreeView1 Is Nothing Then
                Dim unused5 = MsgBox("Le TreeView n'a pas été initialisé.")
            ElseIf TreeView1.Nodes.Count = 0 Then
                Dim unused6 = MsgBox("Le TreeView est vide. Aucun nœud disponible.")
            End If

            Dim unused = TreeView1.Focus()
            TextBox31.Clear()
        End If

        Dim lines() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
        Dim newLines As New List(Of String)
        For Each line As String In lines
            If Not String.IsNullOrEmpty(line) Then
                newLines.Add(line)
            End If
        Next
        File.WriteAllLines(OuvrirFichier, newLines.ToArray(), Encoding.UTF8)

        Dim foo As String
        If TreeView1.SelectedNode IsNot Nothing Then
            foo = TreeView1.SelectedNode.Text
        Else
            ' Gestion de l'erreur : Noeud non sélectionné
            foo = String.Empty
        End If
        If Not String.IsNullOrEmpty(OuvrirFichier) AndAlso File.Exists(OuvrirFichier) Then
            Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
            FileOne = monfichier(I).ToString
        Else
            ' Gestion de l'erreur : Fichier introuvable
            FileOne = String.Empty
        End If
        If ListBox2.Items IsNot Nothing Then
            For i As Integer = 0 To ListBox2.Items.Count - 1
                If ListBox2.Items(i).ToString = foo Then
                    ' Lire les lignes du fichier et assigner la valeur à FileOne
                    Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                    FileOne = monfichier(i).ToString
                End If
            Next
        Else
            ' Gestion de l'erreur : Items dans ListBox2 est nul
            Dim unused9 = Forms.MessageBox.Show("Erreur : ListBox2 ne contient aucun élément.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
        Dim t As String

        ' Vérifiez si TreeView1.SelectedNode n'est pas Nothing
        If TreeView1.SelectedNode Is Nothing Then
            Dim unused1 = Forms.MessageBox.Show("Aucun nœud sélectionné dans le TreeView.")
            Exit Sub
        End If

        For Each t In readTexte
            ' Vérifiez si t et FileOne ne sont pas Nothing
            If t IsNot Nothing AndAlso FileOne IsNot Nothing Then
                If t.Contains(TreeView1.SelectedNode.Text) And t.Equals(value:=FileOne.ToString) Then
                    TextBox2.Text = Trim(Mid(t, 1, 18))
                    TextBox1.Text = Trim(Mid(t, 19, 90))
                    TextBox4.Text = Trim(Mid(t, 109, 120))
                    TextBox15.Text = Trim(Mid(t, 229, 120))
                    TextBox5.Text = Trim(Mid(t, 349, 120))
                    TextBox7.Text = Trim(Mid(t, 469, 120))
                    TextBox9.Text = Trim(Mid(t, 589, 120))
                    TextBox13.Text = Trim(Mid(t, 709, 120))
                    TextBox18.Text = Trim(Mid(t, 829, 120))
                    TextBox23.Text = Trim(Mid(t, 949, 120))
                    TextBox24.Text = Trim(Mid(t, 1069, 120))
                    TextBox25.Text = Trim(Mid(t, 1189, 120))
                    TextBox26.Text = Trim(Mid(t, 1309, 120))
                    TextBox28.Text = Trim(Mid(t, 1429, 120))
                    TextBox29.Text = Trim(Mid(t, 1549, 120))
                    TextBox33.Text = Trim(Mid(t, 1669, 120))
                    TextBox31.Text = Trim(Mid(t, 1789, 1200))
                    RichTextBox1.Text = Trim(Mid(t, 2989, 200))
                    Exit For
                End If
            End If
        Next

        If String.IsNullOrEmpty(TextBox33.Text) Then
            PictureBox1.Image = Image_16x_1
        End If

        Dim literal As String = TextBox33.Text

        ' Vérifiez que la chaîne n'est pas vide ou n'a pas moins d'un caractère
        If Not String.IsNullOrEmpty(literal) AndAlso literal.Length >= 1 Then
            Dim subst As String = literal.Substring(0, 1)
            Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst
            Dim filename As String = System.IO.Path.Combine(folder, literal)

            If File.Exists(filename) Then
                Try
                    Using fs As FileStream = File.OpenRead(filename)
                        PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                    End Using
                Catch ex As Exception
                    Dim msg As String = "Erreur lors de l'ouverture du fichier image." & Environment.NewLine &
                    "Nom de fichier : " & filename & Environment.NewLine &
                    "Exception : " & ex.ToString
                    Dim unused2 = Forms.MessageBox.Show(msg, "Erreur")
                End Try
            Else
                Dim unused3 = Forms.MessageBox.Show("Le fichier image '" & literal & "' n'existe pas dans le dossier spécifié.", "Fichier manquant", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Dim NbLine As Integer = 0
        Dim SR As New StreamReader(OuvrirFichier)
        While Not SR.EndOfStream
            Dim v5 = SR.ReadLine()
            NbLine += 1
        End While
        SR.Close()

        ToolStripTextBox1.Text = CStr(NbLine)

        For Each txt In {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}
            txt.ReadOnly = True
        Next
        RichTextBox1.ReadOnly = True

        ToolStripProgressBar1.Value = 0

        TreeView1.ExpandAll()

        PictureBox3.Visible = False

        Computer.FileSystem.DeleteFile(
My.Application.Info.DirectoryPath & "\Temp\" & System.IO.Path.GetFileNameWithoutExtension(ListView1.Items(NumeroDeLigne).Text) & ".xml",
UIOption.OnlyErrorDialogs,
RecycleOption.SendToRecycleBin,
UICancelOption.ThrowException)

    End Sub

    Private Sub HighlightLastRecord()

        ' Déclarez et initialisez rootNode
        If TreeView1.Nodes.Count > 0 Then
            Dim rootNode As TreeNode = TreeView1.Nodes(0) ' Premier nœud racine du TreeView

            ' Réinitialiser les couleurs des nœuds
            For Each node As TreeNode In rootNode.Nodes
                node.BackColor = System.Drawing.Color.White
            Next

            ' Rechercher la fiche (normalisation des chaînes)
            Dim searchText As String = RemoveDiacritics(TextBox1.Text)
            Dim targetNode As TreeNode = FindNodeByText(rootNode.Nodes, searchText)

            ' Sélectionner et surligner la fiche trouvée
            If targetNode IsNot Nothing Then
                TreeView1.SelectedNode = targetNode
                targetNode.BackColor = System.Drawing.Color.Yellow
                targetNode.EnsureVisible()
                'Else
                'MsgBox("Fiche introuvable")
            End If
        Else
            Dim unused = MsgBox("Aucun nœud racine trouvé dans le TreeView")
        End If

    End Sub

    ' Exemple de définition de la méthode ListeDeFiches
    Private Function ObtenezLaListeDeFiches() As IEnumerable(Of Fiche)

        ' Implémentez ici la logique pour obtenir les fiches, par exemple à partir d'une base de données ou d'un fichier.
        ' Par exemple, vous pourriez avoir une collection statique pour l'exemple :

        Dim fiches As New List(Of Fiche) From {
New Fiche() With {.IDUnique = "", .Nom = ""},
New Fiche() With {.IDUnique = "", .Nom = ""}
}

        ' Ajoutez autant de fiches que nécessaire
        Return fiches

    End Function

    Private Function FindNodeByText(value As Object) As TreeNode

        Throw New NotImplementedException()

    End Function

    Private Sub SaveData()

        Try
            ' Valider les contrôles
            If Validate() Then
                'Code pour sauvegarder les données ici...
                '(Exemple de code qui écrit des données ou appelle une méthode spécifique)

                Dim unused = Forms.MessageBox.Show("Données enregistrées avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim unused1 = Forms.MessageBox.Show("Certains champs sont invalides. Veuillez vérifier les informations.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            Dim unused2 = Forms.MessageBox.Show("Erreur lors de la sauvegarde des données : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DesactiverTextBoxesSpecifiques()

        Dim textBoxes() As Forms.TextBox = {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}

        ' Désactiver uniquement les TextBox spécifiés
        For Each txtBox As Forms.TextBox In textBoxes
            txtBox.Enabled = False
        Next

    End Sub

    Private Sub ActiverTextBoxesSpecifiques()

        Dim textBoxes() As Forms.TextBox = {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}

        ' Activer uniquement les TextBox spécifiés
        For Each txtBox As Forms.TextBox In textBoxes
            txtBox.Enabled = True
        Next

    End Sub

    Public Sub Enregistrer(sender As Object, e As EventArgs)

        Dim unused8 = MsgBox("Événement 'Enregistrer' détecté.")
        ' Code de sauvegarde des données

        CurrentNode = New TreeNode(TextBox1.Text)

        ' Placez ici le code pour récupérer ou définir le nœud en utilisant TextBox1.Text
        ' Vérifier si l'enregistrement concerne une nouvelle fiche
        Dim isNewEntry As Boolean = True ' Ajustez cette variable selon votre logique

        Dim nodeToSelect = FindNodeByText(TreeView1.Nodes, TextBox1.Text)

        If nodeToSelect IsNot Nothing Then
            CurrentNode = nodeToSelect
        Else
            ' Afficher le message uniquement si ce n'est pas une nouvelle entrée
            If Not isNewEntry Then
                MsgBox("Aucun nœud trouvé avec ce texte. Vérifiez l’entrée.")
            End If
        End If

        If CurrentNode IsNot Nothing Then
#If DEBUG Then
            MsgBox(CurrentNode.Text) ' Ce message ne s'affichera qu'en mode debug
#End If
        Else
#If DEBUG Then
            MsgBox("Le nœud est vide ou non initialisé !")
#End If
        End If

        If nodeToSelect IsNot Nothing Then
            CurrentNode = nodeToSelect ' Stockez le nœud avant toute autre opération
        End If

        Try

            If Forms.MessageBox.Show("Êtes-vous sûr de vouloir enregistrer les modifications ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    ' Logique d'enregistrement des données uniquement si la réponse est Oui
                    ' Insérer ici le code de sauvegarde effectif

                    'Dim unused5 = ToolStripMenuItem()

                    Dim unused4 = Forms.MessageBox.Show("Enregistrement effectué avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    ' Gestion de l'exception
                    Dim unused7 = Forms.MessageBox.Show("Erreur lors de l'enregistrement des données : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                ' Si l'utilisateur a cliqué sur Non, sortir de la procédure ou afficher un message d'annulation
                Dim unused6 = Forms.MessageBox.Show("Enregistrement annulé par l'utilisateur.", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            SaveData()

            ToolStripStatusLabel4.Text = "CREATION d'enregistrement (écriture dans le fichier)"

            Dim bibliotheque As New Article
            Dim NumeroDeLigne As Integer

            lit = 0 : modifié = 1 : sauvé = 0 : ajouté = 1 : supprimé = 1
            ListeToolStripMenuItem.Enabled = True : ModifierToolStripMenuItem1.Enabled = True : NouvelleficheToolStripMenuItem.Enabled = True : SupprimerToolStripMenuItem.Enabled = True
            NouveauToolStripButton.Enabled = True : EnregistrerToolStripButton.Enabled = False : ListeToolStripButton.Enabled = False : ToolStripButton5.Enabled = True

            ' Si aucun élément n'est sélectionné dans ListView1
            If ListView1.SelectedItems.Count = 0 Then
                ' Afficher un message d'erreur si aucun élément n'est sélectionné
                Dim msgBoxResult = MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", vbExclamation, "Erreur")
                Exit Sub
            End If

            ' Réinitialiser la couleur de fond de TextBox1 à sa couleur par défaut
            TextBox1.BackColor = System.Drawing.SystemColors.Control
            ' Ajouter ici les actions supplémentaires pour modifier la fiche sélectionnée

            ' Si aucun élément n'est sélectionné.
            If ListBox2.Items.Contains(Trim(TextBox1.Text)) Or String.IsNullOrEmpty(Trim(TextBox1.Text)) Then
                TextBox1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192)
                Dim v = TextBox1.Focus()
                TextBox1.Clear()
                EnregistrerToolStripButton.Enabled = True : NouveauToolStripButton.Enabled = False : ToolStripButton5.Enabled = False : NouvelleficheToolStripMenuItem.Enabled = False : ModifierToolStripMenuItem1.Enabled = False
                Exit Sub
            End If

            'TextBox1.BackColor = System.Drawing.SystemColors.Control

            ComboBox1.Enabled = False : ComboBox2.Enabled = False : DateTimePicker1.Enabled = False : TextBox5.Enabled = False
            ListBox2.Items.Clear()

            NumeroDeLigne = ListView1.SelectedIndices(0)
            OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NumeroDeLigne).Text

            Dim MonFichier As New FileInfo(OuvrirFichier)

            With bibliotheque
                .Title = TextBox2.Text
                .Name = TextBox1.Text
                .Charge = TextBox4.Text
                .Institute = TextBox15.Text
                .Celebration = TextBox5.Text
                .Birth = TextBox7.Text
                .Death = TextBox9.Text
                .Otherparties = TextBox13.Text
                .Othernames = TextBox18.Text
                .Venerable = TextBox23.Text
                .Beatified = TextBox24.Text
                .Canonized = TextBox25.Text
                .Heading = TextBox26.Text
                .Patron = TextBox28.Text
                .Link = TextBox29.Text
                .Image = TextBox33.Text
                .Biography = TextBox31.Text
                .Origin = RichTextBox1.Text
            End With

            If bIsModified And Not bNeedsFurtherProcessing And MonFichier.Length > 0 Then

                Dim fileName As String = OuvrirFichier
                Dim lignes As String() = File.ReadAllLines(fileName, Encoding.UTF8)
                Dim found As Integer = -1

                For i As Integer = 0 To lignes.Length - 1
                    If lignes(i).Contains(Trim(lstOfStrings(1))) Then
                        found = i
                        Exit For
                    End If
                Next

                ' Modifier - Si vous souhaitez modifier une ligne dans un fichier, vous devez lire l'intégralité du fichier et le réécrire avec la ligne modifiée.

                RaiseEvent SauvegarderEtat(Me, EventArgs.Empty)
                Dim lines As String() = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                lines(found) = bibliotheque.Title.PadRight(18, " "c).ToString & bibliotheque.Name.PadRight(90, " "c).ToString & bibliotheque.Charge.PadRight(120, " "c).ToString & bibliotheque.Institute.PadRight(120, " "c).ToString & bibliotheque.Celebration.PadRight(120, " "c).ToString & bibliotheque.Birth.PadRight(120, " "c).ToString & bibliotheque.Death.PadRight(120, " "c).ToString & bibliotheque.Otherparties.PadRight(120, " "c).ToString & bibliotheque.Othernames.PadRight(120, " "c).ToString & bibliotheque.Venerable.PadRight(120, " "c).ToString & bibliotheque.Beatified.PadRight(120, " "c).ToString & bibliotheque.Canonized.PadRight(120, " "c).ToString & bibliotheque.Heading.PadRight(120, " "c).ToString & bibliotheque.Patron.PadRight(120, " "c).ToString & bibliotheque.Link.PadRight(120, " "c).ToString & bibliotheque.Image.PadRight(120, " "c).ToString & bibliotheque.Biography.PadRight(1200, " "c).ToString & bibliotheque.Origin.PadRight(200, " "c).ToString

                Dim dialogResult As MessageBoxResult = MessageBox.Show("Enregistrer les données modifiées ?",
                                                                     "Prénommer", MessageBoxButton.OKCancel, MessageBoxImage.Question)

                If dialogResult = MessageBoxResult.OK Then
                    Computer.FileSystem.DeleteFile(OuvrirFichier)
                    File.WriteAllLines(OuvrirFichier, lines, Encoding.UTF8)
                    Using fStream As New FileStream(OuvrirFichier, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                        fStream.SetLength(fStream.Length - Environment.NewLine.Length)
                    End Using

                Else
                    RaiseEvent RestaurerEtat(Me, EventArgs.Empty)
                    RaiseEvent SauvegarderEtat(Me, EventArgs.Empty)
                End If
                bIsModified = False

            Else

                Dim fileName As String = OuvrirFichier
                Dim bt As New Article With {
    .Title = TextBox2.Text,
    .Name = TextBox1.Text,
    .Charge = TextBox4.Text,
    .Institute = TextBox15.Text,
    .Celebration = TextBox5.Text,
    .Birth = TextBox7.Text,
    .Death = TextBox9.Text,
    .Otherparties = TextBox13.Text,
    .Othernames = TextBox18.Text,
    .Venerable = TextBox23.Text,
    .Beatified = TextBox24.Text,
    .Canonized = TextBox25.Text,
    .Heading = TextBox26.Text,
    .Patron = TextBox28.Text,
    .Link = TextBox29.Text,
    .Image = TextBox33.Text,
    .Biography = TextBox31.Text,
    .Origin = RichTextBox1.Text
    }

                Using fs As New FileStream(fileName, FileMode.Append)
                    Using writer As New StreamWriter(fs, Encoding.UTF8)
                        If fs.Length > 0 Then writer.WriteLine()
                        writer.Write($"{bt.Title,-18}{bt.Name,-90}{bt.Charge,-120}{bt.Institute,-120}{bt.Celebration,-120}{bt.Birth,-120}{bt.Death,-120}{bt.Otherparties,-120}{bt.Othernames,-120}{bt.Venerable,-120}{bt.Beatified,-120}{bt.Canonized,-120}{bt.Heading,-120}{bt.Patron,-120}{bt.Link,-120}{bt.Image,-120}{bt.Biography,-1200}{bt.Origin,-200}")
                    End Using
                End Using

                bNeedsFurtherProcessing = False

            End If

            ListBox2.Items.Clear()

            ListeToolStripMenuItem.Enabled = True
            ListeToolStripButton.Enabled = True

            For Each txt In {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}
                txt.ReadOnly = True
            Next
            RichTextBox1.ReadOnly = True

            'Dim dialogResult2 = Forms.MessageBox.Show("Données écrites dans le fichier disque.")

            Dim chain As List(Of String) = File.ReadAllLines(OuvrirFichier).ToList()
            For i As Integer = chain.Count - 1 To 0 Step -1
                If String.IsNullOrWhiteSpace(chain(i)) Then
                    If i < chain.Count - 1 AndAlso IsNumeric(chain(i + 1).Trim().Split(" "c)(0)) Then
                        chain.RemoveAt(i)
                    End If
                End If
            Next
            File.WriteAllLines(OuvrirFichier, chain, Encoding.UTF8)

            InitializeEvents()

            ListeToolStripMenuItem.PerformClick()

            ListeToolStripMenuItem.Enabled = False
            ListeToolStripButton.Enabled = False

            userInput = TextBox1.Text.Trim()

            If bIsModified Then ' Modification
                SelectNodeByText(CurrentNode.Text)
                SelectionNode()
            ElseIf bNeedsFurtherProcessing Then 'Nouvelle fiche
                SelectNodeByText(userInput)
                SelectionNode()
            End If

        Catch ex As IOException
            ' Attrapez l'IOException générée si la partie spécifiée du fichier est verrouillée.
            Forms.MessageBox.Show($"{ex.GetType().Name}: L'opération d'écriture pourrait ne pas être effectuée parce que la partie spécifiée du fichier est verrouillée.")
        Catch ex As NullReferenceException
            Dim unused = Forms.MessageBox.Show("NullReferenceException: " & ex.Message)
            Dim unused1 = Forms.MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        Catch ex As Exception
            ' Code qui réagit à toute autre exception.
            ' Afficher le message de l'exception.
            Dim unused2 = Forms.MessageBox.Show(ex.Message)
        Finally
            ''Cette ligne s'exécute, que l'exception se produise ou non.
            'Dim unused4 = Forms.MessageBox.Show("L'exécution du processus est terminée.")
            'Finally
            'Mise à jour du Label dynamique
            'Dim unused5 = Forms.MessageBox.Show("Vos données ont été enregistrées avec succès !")

            LabelNotification.Text = "L'exécution du processus est terminée."
            LabelNotification.Visible = True

        End Try

    End Sub

    Private Sub SelectionNode()

        ' *** PARTIE 1 : Votre code existant pour récupérer OuvrirFichier et FileOne ***
        Dim NombreDeLignes As Integer
        NombreDeLignes = ListView1.SelectedIndices(0)
        OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

        Dim foo As String
        foo = TreeView1.SelectedNode.Text
        For i As Integer = 0 To ListBox2.Items.Count - 1
            If ListBox2.Items(i).ToString = foo Then
                Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                FileOne = monfichier(i).ToString
            End If
        Next

        If TreeView1.SelectedNode IsNot Nothing Then
            Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
            Dim t As String
            For Each t In readTexte
                If t.Contains(TreeView1.SelectedNode.Text) AndAlso t.Equals(FileOne.ToString) Then
                    TextBox2.Text = Trim(Mid(t, 1, 18))
                    TextBox1.Text = Trim(Mid(t, 19, 90))
                    TextBox4.Text = Trim(Mid(t, 109, 120))
                    TextBox15.Text = Trim(Mid(t, 229, 120))
                    TextBox5.Text = Trim(Mid(t, 349, 120))
                    TextBox7.Text = Trim(Mid(t, 469, 120))
                    TextBox9.Text = Trim(Mid(t, 589, 120))
                    TextBox13.Text = Trim(Mid(t, 709, 120))
                    TextBox18.Text = Trim(Mid(t, 829, 120))
                    TextBox23.Text = Trim(Mid(t, 949, 120))
                    TextBox24.Text = Trim(Mid(t, 1069, 120))
                    TextBox25.Text = Trim(Mid(t, 1189, 120))
                    TextBox26.Text = Trim(Mid(t, 1309, 120))
                    TextBox28.Text = Trim(Mid(t, 1429, 120))
                    TextBox29.Text = Trim(Mid(t, 1549, 120))
                    TextBox33.Text = Trim(Mid(t, 1669, 120))
                    TextBox31.Text = Trim(Mid(t, 1789, 1200))
                    RichTextBox1.Text = Trim(Mid(t, 2989, 200))
                    Exit For ' Ajoutez un Exit For ici une fois la ligne trouvée
                End If
            Next
        End If
        ' *** FIN DE LA PARTIE 1 ***

        ' *** PARTIE 2 : Le nouveau code simplifié pour le PictureBox (CORRIGÉ EN VB.NET) ***
        ' Libérer les ressources de l'image précédente si elle existe
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
        End If

        If Not String.IsNullOrWhiteSpace(TextBox33.Text) Then
            Dim subst As String = TextBox33.Text.Substring(0, 1)
            Dim imagePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images", subst, TextBox33.Text)

            Console.WriteLine($"Chemin de l'image : '{imagePath}'")

            Try
                If File.Exists(imagePath) Then
                    PictureBox1.Image = System.Drawing.Image.FromFile(imagePath)
                Else
                    Dim unused = Forms.MessageBox.Show($"Le fichier image '{imagePath}' n'existe pas.",
                      "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                      MessageBoxDefaultButton.Button1, Forms.MessageBoxOptions.DefaultDesktopOnly)
                    PictureBox1.Image = Image_16x_1 ' Assurez-vous que Image_16x_1 est défini
                End If
            Catch ex As ArgumentException
                Dim unused1 = Forms.MessageBox.Show($"Erreur de format d'image pour '{imagePath}': {ex.Message}",
                      "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error,
                      MessageBoxDefaultButton.Button1, Forms.MessageBoxOptions.DefaultDesktopOnly)
                PictureBox1.Image = Image_16x_1
            Catch ex As OutOfMemoryException
                Dim unused2 = Forms.MessageBox.Show($"Impossible de charger l'image '{imagePath}'. Fichier corrompu ou trop volumineux.",
                      "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error,
                      MessageBoxDefaultButton.Button1, Forms.MessageBoxOptions.DefaultDesktopOnly)
                PictureBox1.Image = Image_16x_1
            Catch ex As Exception
                Dim unused3 = Forms.MessageBox.Show($"Erreur inattendue lors du chargement de '{imagePath}': {ex.Message}",
                      "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error,
                      MessageBoxDefaultButton.Button1, Forms.MessageBoxOptions.DefaultDesktopOnly)
            End Try
        Else
            PictureBox1.Image = Image_16x_1
        End If

    End Sub

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    Private Const WM_LBUTTONDOWN As Integer = &H201
    Private Const WM_LBUTTONUP As Integer = &H202

    Private Sub ForcerSelectionNode(node As TreeNode)

        If node IsNot Nothing Then
            TreeView1.SelectedNode = node ' Sélection du nœud directement
            Dim unused = TreeView1.Focus() ' Force le focus sur le TreeView
            TreeView1.Refresh() ' Rafraîchit l'affichage
        End If

    End Sub

    Private Sub RechercherEtSelectionnerNoeudDansCollection(parentNode As TreeNodeCollection, texteRecherche As String)

        For Each NodX As TreeNode In parentNode
            If NodX.Text = texteRecherche Then
                TreeView1.SelectedNode = NodX ' Sélection du nœud correspondant
                Dim unused = TreeView1.Focus()            ' Mise au focus sur le TreeView
                Exit Sub                     ' Arrêt de la recherche une fois trouvé
            End If

            ' Recherche dans les enfants du nœud actuel
            If NodX.Nodes.Count > 0 Then
                RechercherEtSelectionnerNoeudDansCollection(NodX.Nodes, texteRecherche)
            End If
        Next

    End Sub

    Private Sub HighlightNode(treeView As Forms.TreeView, targetNode As TreeNode)

        ' Réinitialiser les couleurs de tous les nœuds récursivement
        ResetNodeColors(treeView.Nodes)

        ' Surligner le nœud cible
        If targetNode IsNot Nothing Then
            targetNode.BackColor = System.Drawing.Color.Yellow
            treeView.SelectedNode = targetNode
            targetNode.EnsureVisible()
        End If

    End Sub

    ' Méthode pour réinitialiser les couleurs des nœuds (récursive)
    Private Sub ResetNodeColors(nodes As TreeNodeCollection)

        For Each node As TreeNode In nodes
            ' Réinitialiser les couleurs du nœud actuel
            node.BackColor = System.Drawing.Color.White
            node.ForeColor = System.Drawing.Color.Black

            ' Si le nœud a des enfants, réinitialiser leurs couleurs également
            If node.Nodes.Count > 0 Then
                ResetNodeColors(node.Nodes) ' Appel récursif pour les sous-nœuds
            End If
        Next

    End Sub

    Private Sub ModifierToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModifierToolStripMenuItem1.Click

        ToolStripStatusLabel4.Text = "MODIFICATION d'enregistrement (correction dans le fichier)"

        bIsModified = True

        Dim NumeroDeLigne As Integer

        lit = 0 : modifié = 0 : sauvé = 1 : ajouté = 0 : supprimé = 0
        ListeToolStripMenuItem.Enabled = False : ModifierToolStripMenuItem1.Enabled = False : NouvelleficheToolStripMenuItem.Enabled = False : SupprimerToolStripMenuItem.Enabled = False
        NouveauToolStripButton.Enabled = False : EnregistrerToolStripButton.Enabled = True : ListeToolStripButton.Enabled = False : ToolStripButton5.Enabled = False

        ' Si aucun élément n'est sélectionné.
        If ListView1.SelectedItems.Count = 0 Then
            Dim msgBoxResult = MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", CType(vbYes, MsgBoxStyle), "Erreur")

        Else

            ComboBox1.Enabled = True : ComboBox2.Enabled = True : DateTimePicker1.Enabled = True

            For Each txt In {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}
                txt.ReadOnly = False
            Next
            RichTextBox1.ReadOnly = False

            NumeroDeLigne = ListView1.SelectedIndices(0)
            OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NumeroDeLigne).Text

            lstOfStrings = {TextBox2.Text, TextBox1.Text, TextBox4.Text, TextBox15.Text, TextBox5.Text, TextBox7.Text, TextBox9.Text, TextBox13.Text, TextBox18.Text, TextBox23.Text, TextBox24.Text, TextBox25.Text, TextBox26.Text, TextBox28.Text, TextBox29.Text, TextBox33.Text, TextBox31.Text, RichTextBox1.Text}

            ListBox2.Items.Clear()

        End If

    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        Dim NombreDeLignes As Integer
        Dim OuvrirTemporaire As String
        Dim NumeroDeLigne As Integer

        ToolStripStatusLabel4.Text = "SUPPRESSION d'enregistrement (effacement dans le fichier)"

        lit = 0 : modifié = 0 : sauvé = 0 : ajouté = 0 : supprimé = 1
        ListeToolStripMenuItem.Enabled = False : ModifierToolStripMenuItem1.Enabled = False : NouvelleficheToolStripMenuItem.Enabled = False : SupprimerToolStripMenuItem.Enabled = True
        NouveauToolStripButton.Enabled = False : EnregistrerToolStripButton.Enabled = False : ListeToolStripButton.Enabled = False : ToolStripButton5.Enabled = False

        If ListView1.SelectedItems.Count > 0 Then

            If TreeView1.Nodes.Count = 1 Then
                Dim message As String =
"Conseil : supprimez de préférence le fichier à l’aide de l’Explorateur de fichiers ou à partir du menu principal Fichiers de Prénommer, sélectionnez le sous-menu Supprimer."
                Dim caption As String = "Prénommer"
                Dim result As DialogResult = Forms.MessageBox.Show(message, caption,
                     MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ComboBox1.Enabled = False : ComboBox2.Enabled = False : DateTimePicker1.Enabled = False

            NombreDeLignes = ListView1.SelectedIndices(0)
            Position = TreeView1.SelectedNode.Index

            For i As Integer = 0 To ListBox2.Items.Count - 1
                If ListBox2.Items(i).ToString.Contains(Trim(TextBox1.Text)) Then
                    IndexEnreg = i
                    Exit For
                End If
            Next

            ListBox2.SelectedItems.Clear()

            OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text
            OuvrirTemporaire = My.Application.Info.DirectoryPath & "\Temp\" & System.IO.Path.GetFileNameWithoutExtension(ListView1.Items(NombreDeLignes).Text) & ".tmp"

            Dim fileName As String = OuvrirFichier
            Dim someString As String = Trim(TextBox1.Text)
            Dim lignes As String() = File.ReadAllLines(fileName, Encoding.UTF8)
            Dim found As Integer = -1

            For i As Integer = 0 To lignes.Length - 1
                If lignes(i).Contains(someString) Then
                    found = i
                    Exit For
                End If
            Next

            Dim delLine As Integer = found + 1
            Dim lines As List(Of String) = File.ReadAllLines(OuvrirFichier, Encoding.UTF8).ToList
            lines.RemoveAt(delLine - 1)
            File.WriteAllText(OuvrirTemporaire, String.Join(Environment.NewLine, lines), Encoding.UTF8)

            Try

                Computer.FileSystem.DeleteFile(
OuvrirFichier,
UIOption.OnlyErrorDialogs,
RecycleOption.SendToRecycleBin,
UICancelOption.DoNothing)

            Catch ex As Exception
                Dim msgBoxResult = MsgBox(ex.Message)
            End Try

            Computer.FileSystem.RenameFile(OuvrirTemporaire, ListView1.Items(NombreDeLignes).Text)

        Else

            Exit Sub

        End If

        Dim FileToMove As String
        Dim MoveLocation As String

        FileToMove = My.Application.Info.DirectoryPath & "\Temp\" & ListView1.Items(NombreDeLignes).Text
        MoveLocation = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

        If File.Exists(FileToMove) Then
            File.Move(FileToMove, MoveLocation)
        End If

        InitializeEvents()

        NumeroDeLigne = ListView1.SelectedIndices(0)
        OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NumeroDeLigne).Text
        OuvrirXML = My.Application.Info.DirectoryPath & "\Temp\" & System.IO.Path.GetFileNameWithoutExtension(ListView1.Items(NumeroDeLigne).Text) & ".xml"

        Dim root = New TreeNode("Librairie")
        Dim v = TreeView1.Nodes.Add(root)

        ListBox2.Items.Clear()

        Dim readText() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
        Dim s As String
        For Each s In readText
            TextBox2.Text = Trim(Mid(s, 1, 18))
            TextBox1.Text = Trim(Mid(s, 19, 90))
            TextBox4.Text = Trim(Mid(s, 109, 120))
            TextBox15.Text = Trim(Mid(s, 229, 120))
            TextBox5.Text = Trim(Mid(s, 349, 120))
            TextBox7.Text = Trim(Mid(s, 469, 120))
            TextBox9.Text = Trim(Mid(s, 589, 120))
            TextBox13.Text = Trim(Mid(s, 709, 120))
            TextBox18.Text = Trim(Mid(s, 829, 120))
            TextBox23.Text = Trim(Mid(s, 949, 120))
            TextBox24.Text = Trim(Mid(s, 1069, 120))
            TextBox25.Text = Trim(Mid(s, 1189, 120))
            TextBox26.Text = Trim(Mid(s, 1309, 120))
            TextBox28.Text = Trim(Mid(s, 1429, 120))
            TextBox29.Text = Trim(Mid(s, 1549, 120))
            TextBox33.Text = Trim(Mid(s, 1669, 120))
            TextBox31.Text = Trim(Mid(s, 1789, 1200))
            RichTextBox1.Text = Trim(Mid(s, 2989, 200))

            Dim node As TreeNode = TreeView1.Nodes(0)
            Dim v1 = TreeView1.Nodes(0).Nodes.Add(New TreeNode(Trim(TextBox1.Text)))
            Dim v2 = ListBox2.Items.Add(TextBox1.Text)
        Next

        TreeView1.ExpandAll()
        TreeView1.Sort()

        Dim C As New Class5
        C.SauveTreeView(TreeView1, OuvrirXML)
        C.ChargeTreeView(TreeView1, OuvrirXML)

        Dim FichierInfo As New FileInfo(OuvrirFichier)
        Dim TailleFichier As Integer = CInt(FichierInfo.Length)

        If Not TailleFichier = 0 Then
            Dim w = TreeView1.Focus()

            ' Vérifier s'il y a des nœuds dans le TreeView
            If TreeView1.Nodes.Count > 0 Then
                ' Vérifier si le premier nœud parent a des sous-nœuds
                If TreeView1.Nodes(0).Nodes.Count > 0 Then
                    ' Sélectionner le premier sous-nœud du premier nœud parent
                    TreeView1.SelectedNode = TreeView1.Nodes(0).Nodes(0)
                Else
                    ' Si aucun sous-nœud n'existe, sélectionner le premier nœud parent
                    TreeView1.SelectedNode = TreeView1.Nodes(0)
                End If
            Else
                ' Si aucun nœud n'existe, afficher un message ou exécuter une autre logique
                Dim unused = Forms.MessageBox.Show("Aucun nœud disponible pour la sélection.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ' Clear le TextBox après la sélection
            TextBox31.Clear()
        End If

        Dim foo As String
        foo = TreeView1.SelectedNode.Text
        For i As Integer = 0 To ListBox2.Items.Count - 1
            If ListBox2.Items(i).ToString = foo Then
                Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                FileOne = monfichier(i).ToString
            End If
        Next

        If TreeView1.SelectedNode IsNot Nothing Then
            Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
            Dim u As String
            For Each u In readTexte
                If u.Contains(TreeView1.SelectedNode.Text) And u.Equals(value:=FileOne.ToString) Then
                    TextBox2.Text = Trim(Mid(u, 1, 18))
                    TextBox1.Text = Trim(Mid(u, 19, 90))
                    TextBox4.Text = Trim(Mid(u, 109, 120))
                    TextBox15.Text = Trim(Mid(u, 229, 120))
                    TextBox5.Text = Trim(Mid(u, 349, 120))
                    TextBox7.Text = Trim(Mid(u, 469, 120))
                    TextBox9.Text = Trim(Mid(u, 589, 120))
                    TextBox13.Text = Trim(Mid(u, 709, 120))
                    TextBox18.Text = Trim(Mid(u, 829, 120))
                    TextBox23.Text = Trim(Mid(u, 949, 120))
                    TextBox24.Text = Trim(Mid(u, 1069, 120))
                    TextBox25.Text = Trim(Mid(u, 1189, 120))
                    TextBox26.Text = Trim(Mid(u, 1309, 120))
                    TextBox28.Text = Trim(Mid(u, 1429, 120))
                    TextBox29.Text = Trim(Mid(u, 1549, 120))
                    TextBox33.Text = Trim(Mid(u, 1669, 120))
                    TextBox31.Text = Trim(Mid(u, 1789, 1200))
                    RichTextBox1.Text = Trim(Mid(u, 2989, 200))
                    Exit For
                End If
            Next
        End If

        If String.IsNullOrEmpty(TextBox33.Text) Then
            PictureBox1.Image = Image_16x_1
        Else
            Dim literal As String = TextBox33.Text
            Dim subst As String = literal.Substring(0, 1)
            PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst

            Dim id As String = TextBox33.Text
            Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst
            Dim filename As String = System.IO.Path.Combine(folder, id)
            Try

                Using fs As FileStream = File.OpenRead(filename)
                    PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                End Using

            Catch ex As Exception
                Dim msg As String = "Nom de fichier : " & filename &
Environment.NewLine & Environment.NewLine &
                       "Exception : " & ex.ToString
                Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
            End Try

        End If

        For Each txt In {TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33}
            txt.ReadOnly = True
        Next
        RichTextBox1.ReadOnly = True

        NouveauToolStripButton.Enabled = True : ToolStripButton5.Enabled = True : NouvelleficheToolStripMenuItem.Enabled = True : ModifierToolStripMenuItem1.Enabled = True

        Dim NbLine As Integer = 0
        Dim filePath As String = OuvrirFichier ' Assurez-vous que ce chemin est correct

        If File.Exists(filePath) Then
            Using SR As New StreamReader(filePath)
                While Not SR.EndOfStream
                    Dim v5 = SR.ReadLine()
                    If Not String.IsNullOrWhiteSpace(v5) Then
                        NbLine += 1
                    End If
                End While
            End Using
        Else
            Dim unused1 = Forms.MessageBox.Show("Le fichier spécifié n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Mettre à jour le compteur après chaque suppression
        ToolStripTextBox1.Text = CStr(TreeView1.Nodes.Count)

        If Not TailleFichier = 0 Then
            Dim unused3 = TreeView1.Focus()

            If TreeView1.Nodes.Count > 0 Then
                ' Si le TreeView a des nœuds
                Dim SelectedRootNode = TreeView1.Nodes(0) ' Premier nœud parent

                If SelectedRootNode.Nodes.Count > 0 Then
                    ' Sélectionner le premier sous-nœud s'il y en a
                    TreeView1.SelectedNode = SelectedRootNode.Nodes(0)
                Else
                    ' Sinon, sélectionner le nœud parent lui-même
                    TreeView1.SelectedNode = SelectedRootNode
                End If

                TextBox31.Clear()
            Else
                ' Si aucun nœud n'existe, afficher un message ou exécuter une autre logique
                Dim unused2 = Forms.MessageBox.Show("Aucun nœud disponible pour la sélection.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

        If TreeView1.Nodes.Count > 0 Then
            Dim SelectedRootNode = TreeView1.Nodes(0) ' Premier nœud parent "Librairies"

            If SelectedRootNode.Nodes.Count = 0 Then
                ' Si "Librairies" n'a plus de sous-nœuds, on le supprime lui-même
                TreeView1.Nodes.Remove(SelectedRootNode)
            End If
        End If

    End Sub

    Private Sub TreeView1_Click(sender As Object, e As EventArgs) Handles TreeView1.Click

        ' Vérifie si un nœud est sélectionné dans le TreeView
        If TreeView1.SelectedNode IsNot Nothing Then
            ' Affiche le texte du nœud sélectionné dans une MessageBox
            'Forms.MessageBox.Show($"Nœud sélectionné : {TreeView1.SelectedNode.Text}", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Affiche un message si aucun nœud n'est sélectionné
            Dim unused3 = Forms.MessageBox.Show("Aucun nœud n'est sélectionné.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Dim NombreDeLignes As Integer

        If TreeView1.SelectedNode.Level = 0 Or Not Bloqué Then Exit Sub
        Dialogue = False

        If ListView1.SelectedItems.Count > 0 Then

            GenererunfichierdocxToolStripMenuItem.Enabled = True

            ToolStripStatusLabel3.Image = NextDocument_16x1.ToBitmap
            ToolStripStatusLabel3.Text = "Lecture du document..."

            NombreDeLignes = ListView1.SelectedIndices(0)
            OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

            Dim foo As String
            foo = TreeView1.SelectedNode.Text
            For i As Integer = 0 To ListBox2.Items.Count - 1
                If ListBox2.Items(i).ToString = foo Then
                    Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                    FileOne = monfichier(i).ToString
                End If
            Next

            If TreeView1.SelectedNode IsNot Nothing Then
                Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                Dim t As String
                For Each t In readTexte
                    If t.Contains(TreeView1.SelectedNode.Text) And t.Equals(value:=FileOne.ToString) Then
                        TextBox2.Text = Trim(Mid(t, 1, 18))
                        TextBox1.Text = Trim(Mid(t, 19, 90))
                        TextBox4.Text = Trim(Mid(t, 109, 120))
                        TextBox15.Text = Trim(Mid(t, 229, 120))
                        TextBox5.Text = Trim(Mid(t, 349, 120))
                        TextBox7.Text = Trim(Mid(t, 469, 120))
                        TextBox9.Text = Trim(Mid(t, 589, 120))
                        TextBox13.Text = Trim(Mid(t, 709, 120))
                        TextBox18.Text = Trim(Mid(t, 829, 120))
                        TextBox23.Text = Trim(Mid(t, 949, 120))
                        TextBox24.Text = Trim(Mid(t, 1069, 120))
                        TextBox25.Text = Trim(Mid(t, 1189, 120))
                        TextBox26.Text = Trim(Mid(t, 1309, 120))
                        TextBox28.Text = Trim(Mid(t, 1429, 120))
                        TextBox29.Text = Trim(Mid(t, 1549, 120))
                        TextBox33.Text = Trim(Mid(t, 1669, 120))
                        TextBox31.Text = Trim(Mid(t, 1789, 1200))
                        RichTextBox1.Text = Trim(Mid(t, 2989, 200))
                    End If
                Next
            End If

            If String.IsNullOrEmpty(TextBox33.Text) Then
                PictureBox1.Image = Image_16x_1
            Else
                Dim literal As String = TextBox33.Text
                Dim subst As String = literal.Substring(0, 1)
                PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                Dim id As String = TextBox33.Text
                Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                Dim filename As String = System.IO.Path.Combine(folder, id)

                If File.Exists(filename) Then
                    Try
                        Using fs As FileStream = File.OpenRead(filename)
                            PictureBox1.Image = System.Drawing.Image.FromStream(fs)
                        End Using

                        Try
                            If PictureBox1.Image IsNot Nothing Then
                                PictureBox1.Image.Dispose()
                                PictureBox1.Image = Nothing
                            End If
                        Catch ex As Exception
                            Dim unused2 = Forms.MessageBox.Show(ex.Message)
                        End Try

                    Catch ex As Exception
                        Dim msg As String = "Nom de fichier : " & filename & Environment.NewLine & Environment.NewLine & "Exception : " & ex.ToString()
                        Dim unused1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                    End Try
                Else
                    Dim unused = Forms.MessageBox.Show("Le fichier image '" & filename & "' est introuvable.", "Erreur")
                End If
            End If

            Dialogue = False

        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        ' UP - PREVIOUS.

        Dim treeNode As TreeNode

        If TreeView1.SelectedNode Is Nothing Then Exit Sub

        treeNode = TreeView1.SelectedNode.PrevVisibleNode

        If treeNode IsNot Nothing Then
            TreeView1.SelectedNode = treeNode

            Dim bibliotheque As New Article
            Dim NombreDeLignes As Integer

            If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Return

            If ListView1.SelectedItems.Count > 0 Then

                NombreDeLignes = ListView1.SelectedIndices(0)
                OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

                For i As Integer = 0 To ListBox2.Items.Count - 1
                    Foo = TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Text
                    If ListBox2.Items(i).ToString = Foo Then
                        Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                        FileOne = monfichier(i).ToString
                    End If
                Next

                Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                Dim y As String
                For Each y In readTexte
                    If y.Contains(TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Text) And y.Equals(value:=FileOne.ToString) Then
                        TextBox2.Text = Trim(Mid(y, 1, 18))
                        TextBox1.Text = Trim(Mid(y, 19, 90))
                        TextBox4.Text = Trim(Mid(y, 109, 120))
                        TextBox15.Text = Trim(Mid(y, 229, 120))
                        TextBox5.Text = Trim(Mid(y, 349, 120))
                        TextBox7.Text = Trim(Mid(y, 469, 120))
                        TextBox9.Text = Trim(Mid(y, 589, 120))
                        TextBox13.Text = Trim(Mid(y, 709, 120))
                        TextBox18.Text = Trim(Mid(y, 829, 120))
                        TextBox23.Text = Trim(Mid(y, 949, 120))
                        TextBox24.Text = Trim(Mid(y, 1069, 120))
                        TextBox25.Text = Trim(Mid(y, 1189, 120))
                        TextBox26.Text = Trim(Mid(y, 1309, 120))
                        TextBox28.Text = Trim(Mid(y, 1429, 120))
                        TextBox29.Text = Trim(Mid(y, 1549, 120))
                        TextBox33.Text = Trim(Mid(y, 1669, 120))
                        TextBox31.Text = Trim(Mid(y, 1789, 1200))
                        RichTextBox1.Text = Trim(Mid(y, 2989, 200))
                        Exit For
                    End If
                Next

                If TextBox33.Text = "" Then
                    PictureBox1.Image = Image_16x_1
                Else
                    Dim literal As String = TextBox33.Text
                    Dim subst As String = literal.Substring(0, 1)
                    PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                    Dim id As String = TextBox33.Text
                    Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                    Dim filename As String = System.IO.Path.Combine(folder, id)
                    Try
                        Using fs As New FileStream(filename, FileMode.Open)
                            PictureBox1.Image = New Bitmap(System.Drawing.Image.FromStream(fs))
                        End Using
                    Catch ex As Exception
                        Dim msg As String = "Filename: " & filename &
                Environment.NewLine & Environment.NewLine &
                "Exception : " & ex.ToString
                        Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        ' DOWN - NEXT.

        Dim treeNode As TreeNode

        If TreeView1.SelectedNode Is Nothing Then Exit Sub

        treeNode = TreeView1.SelectedNode.NextVisibleNode

        If treeNode IsNot Nothing Then
            TreeView1.SelectedNode = treeNode

            Dim bibliotheque As New Article
            Dim NombreDeLignes As Integer

            If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Return

            If ListView1.SelectedItems.Count > 0 Then

                NombreDeLignes = ListView1.SelectedIndices(0)
                OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

                For i As Integer = 0 To ListBox2.Items.Count - 1
                    Foo = TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Text
                    If ListBox2.Items(i).ToString = Foo Then
                        Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                        FileOne = monfichier(i).ToString
                    End If
                Next

                Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                Dim x As String
                For Each x In readTexte
                    If x.Contains(TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Text) And x.Equals(value:=FileOne.ToString) Then
                        TextBox2.Text = Trim(Mid(x, 1, 18))
                        TextBox1.Text = Trim(Mid(x, 19, 90))
                        TextBox4.Text = Trim(Mid(x, 109, 120))
                        TextBox15.Text = Trim(Mid(x, 229, 120))
                        TextBox5.Text = Trim(Mid(x, 349, 120))
                        TextBox7.Text = Trim(Mid(x, 469, 120))
                        TextBox9.Text = Trim(Mid(x, 589, 120))
                        TextBox13.Text = Trim(Mid(x, 709, 120))
                        TextBox18.Text = Trim(Mid(x, 829, 120))
                        TextBox23.Text = Trim(Mid(x, 949, 120))
                        TextBox24.Text = Trim(Mid(x, 1069, 120))
                        TextBox25.Text = Trim(Mid(x, 1189, 120))
                        TextBox26.Text = Trim(Mid(x, 1309, 120))
                        TextBox28.Text = Trim(Mid(x, 1429, 120))
                        TextBox29.Text = Trim(Mid(x, 1549, 120))
                        TextBox33.Text = Trim(Mid(x, 1669, 120))
                        TextBox31.Text = Trim(Mid(x, 1789, 1200))
                        RichTextBox1.Text = Trim(Mid(x, 2989, 200))
                        Exit For
                    End If
                Next

                If TextBox33.Text = "" Then
                    PictureBox1.Image = Image_16x_1
                Else
                    Dim literal As String = TextBox33.Text
                    Dim subst As String = literal.Substring(0, 1)
                    PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                    Dim id As String = TextBox33.Text
                    Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                    Dim filename As String = System.IO.Path.Combine(folder, id)
                    Try
                        Using fs As New FileStream(filename, FileMode.Open)
                            PictureBox1.Image = New Bitmap(System.Drawing.Image.FromStream(fs))
                        End Using
                    Catch ex As Exception
                        Dim msg As String = "Filename: " & filename &
                Environment.NewLine & Environment.NewLine &
                "Exception : " & ex.ToString
                        Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        Dim st As String
        Dim ndl As Integer
        Dim Ofile As String

        If ListView1.SelectedItems.Count = 0 Then
            Dim msgBoxResult As MsgBoxResult = MsgBox("Vous devez sélectionner un élément pour pouvoir afficher les propriétés de celui-ci !",
                                          MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Erreur")
        Else
            ndl = ListView1.SelectedIndices(0)
            Ofile = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(ndl).Text

            Dim info As FileInfo = Computer.FileSystem.GetFileInfo(Ofile)

            st = "Dossier : " + info.DirectoryName + vbCrLf
            st = st + "Nom complet : " + info.FullName + vbCrLf
            st = st + "Nom du fichier : " + info.Name + vbCrLf
            st = st + "Taille du fichier : " + info.Length.ToString + " octets" + vbCrLf
            st = st + "Attributs : " + info.Attributes.ToString + vbCrLf
            st = st + "Date de création : " + CStr(info.CreationTime) + vbCrLf
            st = st + "Dernier accès : " + CStr(info.LastAccessTime) + vbCrLf
            st = st + "Dernière sauvegarde : " + CStr(info.LastWriteTime) + vbCrLf
            Dim dialogResult1 = Forms.MessageBox.Show(st, My.Application.Info.Title)
        End If

    End Sub

    Private Sub ListeToolStripButton_Click(sender As Object, e As EventArgs) Handles ListeToolStripButton.Click

        TreeView1.Visible = True

        ListeToolStripMenuItem.PerformClick()

    End Sub

    Private Sub NouveauToolStripButton_Click(sender As Object, e As EventArgs) Handles NouveauToolStripButton.Click

        NouvelleficheToolStripMenuItem.PerformClick()

    End Sub

    Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs) Handles TextBox31.TextChanged

        bIsModified = True

        Dim testString As String = TextBox31.Text

        Dim testLen As Integer = Len(testString)
        ToolStripStatusLabel5.Text = $"{Len(TextBox31.Text)} bytes"

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

        If lit = 0 Then
            TextBox5.Text = DateTimePicker1.Value.ToString("d MMMM")
        End If

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        ModifierToolStripMenuItem1.PerformClick()

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick

        If EnregistrerToolStripButton.Enabled Then

            PictureBox1.Image = GetImgOFD(Me, PictureBox1)
            TextBox33.Text = System.IO.Path.GetFileName(FileNameImage)
        Else
            Dim msgBoxResult = MsgBox("Important : veuillez modifier ou éditer les données de l'enregistreement sélectionné !")
            Exit Sub
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        ' Vérifier si une image est actuellement chargée dans le PictureBox
        If IsNothing(PictureBox1.Image) OrElse PictureBox1.Image Is Image_16x_1 Then
            Dim unused = Forms.MessageBox.Show("Aucune image disponible à afficher.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Charger le fichier image en fonction de TextBox33
        Dim literal As String = TextBox33.Text
        Dim subst As String = If(literal.Length > 0, literal.Substring(0, 1), "")
        Sfichier = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

        ' Vérifier si le fichier existe
        If Not File.Exists(Sfichier) Then
            Dim unused2 = Forms.MessageBox.Show("Le fichier image spécifié n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Créer une nouvelle instance de la fenêtre popup et afficher l'image
        Dim frm As New Popup()
        Try
            Dim MyImage As New Bitmap(Sfichier)
            frm.PictureBox1.Image = MyImage
            frm.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom ' Ajuster selon vos besoins
            Dim unused3 = frm.ShowDialog(Me)
        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show("Erreur lors du chargement de l'image : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click

        ' On quitte TOTALEMENT l'application.
        Close()

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click

        ' On cache la fenêtre.
        Hide()

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        ' On affiche la fenêtre.
        Show()

    End Sub

    Private Sub AfficherLaideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherLaideToolStripMenuItem.Click

        'System.Diagnostics.Process.Start(fileName:="C:\Prenommer\Prenommer\Prenommer\bin\Debug\Aide\Prenommer.chm")
        'Dim helpFilePath As String = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Prenommer.chm")

        Dim helpFilePath As String = System.IO.Path.Combine("C:\Prenommer\Prenommer\Prenommer\bin\Debug\Aide\", "Prenommer.chm")
        Try
            Dim unused1 = Process.Start(helpFilePath)
        Catch ex As Exception
            Dim unused = Forms.MessageBox.Show($"Erreur lors de l'ouverture de l'aide : {ex.Message}")
        End Try

    End Sub

    Private Sub TreeView1_KeyDown(sender As Object, e As KeyEventArgs) Handles TreeView1.KeyDown

        If TreeView1.SelectedNode Is Nothing Then Return
        If TreeView1.SelectedNode.Index + 1 >= TreeView1.Nodes.Count Then Return

        Select Case e.KeyCode

            Case Keys.Down

                Dim TotalNodesInTree As Integer = TreeView1.GetNodeCount(True)
                Dim NombreDeLignes As Integer

                If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Return

                If TreeView1.SelectedNode.Index + 1 > ListBox2.Items.Count - 1 Then Exit Sub

                If ListView1.SelectedItems.Count > 0 Then

                    NombreDeLignes = ListView1.SelectedIndices(0)
                    OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

                    Dim lastNode As TreeNode = TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Count - 1)

                    For i As Integer = 0 To ListBox2.Items.Count - 1
                        Foo = TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index + 1).Text
                        If ListBox2.Items(i).ToString = Foo Then
                            Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                            FileOne = monfichier(i).ToString
                        End If
                    Next

                    Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                    Dim t As String
                    For Each t In readTexte
                        If lastNode.IsSelected Then Exit Sub
                        If t.Contains(TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index + 1).Text) And t.Equals(value:=FileOne.ToString) Then
                            TextBox2.Text = Trim(Mid(t, 1, 18))
                            TextBox1.Text = Trim(Mid(t, 19, 90))
                            TextBox4.Text = Trim(Mid(t, 109, 120))
                            TextBox15.Text = Trim(Mid(t, 229, 120))
                            TextBox5.Text = Trim(Mid(t, 349, 120))
                            TextBox7.Text = Trim(Mid(t, 469, 120))
                            TextBox9.Text = Trim(Mid(t, 589, 120))
                            TextBox13.Text = Trim(Mid(t, 709, 120))
                            TextBox18.Text = Trim(Mid(t, 829, 120))
                            TextBox23.Text = Trim(Mid(t, 949, 120))
                            TextBox24.Text = Trim(Mid(t, 1069, 120))
                            TextBox25.Text = Trim(Mid(t, 1189, 120))
                            TextBox26.Text = Trim(Mid(t, 1309, 120))
                            TextBox28.Text = Trim(Mid(t, 1429, 120))
                            TextBox29.Text = Trim(Mid(t, 1549, 120))
                            TextBox33.Text = Trim(Mid(t, 1669, 120))
                            TextBox31.Text = Trim(Mid(t, 1789, 1200))
                            RichTextBox1.Text = Trim(Mid(t, 2989, 200))
                            Exit For
                        End If
                    Next
                End If

                If String.IsNullOrEmpty(TextBox33.Text) Then
                    PictureBox1.Image = Image_16x_1
                Else
                    Dim literal As String = TextBox33.Text
                    Dim subst As String = literal.Substring(0, 1)
                    PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                    Dim id As String = TextBox33.Text
                    Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                    Dim filename As String = System.IO.Path.Combine(folder, id)
                    Try
                        Using fs As New FileStream(filename, FileMode.Open)
                            PictureBox1.Image = New Bitmap(System.Drawing.Image.FromStream(fs))
                        End Using
                    Catch ex As Exception
                        Dim msg As String = "Filename: " & filename &
                                Environment.NewLine & Environment.NewLine &
                                "Exception : " & ex.ToString
                        Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                    End Try

                End If

            Case Keys.Up

                Dim TotalNodesInTree As Integer = TreeView1.GetNodeCount(True)
                Dim NombreDeLignes As Integer

                If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Exit Sub

                If TreeView1.SelectedNode.Index = 0 Then Exit Sub

                If ListView1.SelectedItems.Count > 0 Then

                    NombreDeLignes = ListView1.SelectedIndices(0)
                    OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

                    Dim firstNode As TreeNode = TreeView1.Nodes(0).Nodes(0)

                    For i As Integer = 0 To ListBox2.Items.Count - 1
                        Foo = TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index - 1).Text
                        If ListBox2.Items(i).ToString = Foo Then
                            Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                            FileOne = monfichier(i).ToString
                        End If
                    Next

                    Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                    Dim u As String
                    For Each u In readTexte
                        If firstNode.IsSelected Then Exit Sub
                        If u.Contains(TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index - 1).Text) And u.Equals(value:=FileOne.ToString) Then
                            TextBox2.Text = Trim(Mid(u, 1, 18))
                            TextBox1.Text = Trim(Mid(u, 19, 90))
                            TextBox4.Text = Trim(Mid(u, 109, 120))
                            TextBox15.Text = Trim(Mid(u, 229, 120))
                            TextBox5.Text = Trim(Mid(u, 349, 120))
                            TextBox7.Text = Trim(Mid(u, 469, 120))
                            TextBox9.Text = Trim(Mid(u, 589, 120))
                            TextBox13.Text = Trim(Mid(u, 709, 120))
                            TextBox18.Text = Trim(Mid(u, 829, 120))
                            TextBox23.Text = Trim(Mid(u, 949, 120))
                            TextBox24.Text = Trim(Mid(u, 1069, 120))
                            TextBox25.Text = Trim(Mid(u, 1189, 120))
                            TextBox26.Text = Trim(Mid(u, 1309, 120))
                            TextBox28.Text = Trim(Mid(u, 1429, 120))
                            TextBox29.Text = Trim(Mid(u, 1549, 120))
                            TextBox33.Text = Trim(Mid(u, 1669, 120))
                            TextBox31.Text = Trim(Mid(u, 1789, 1200))
                            RichTextBox1.Text = Trim(Mid(u, 2989, 200))
                            Exit For
                        End If
                    Next

                    If TextBox33.Text = "" Then
                        PictureBox1.Image = Image_16x_1
                    Else
                        Dim literal As String = TextBox33.Text
                        Dim subst As String = literal.Substring(0, 1)
                        PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                        Dim id As String = TextBox33.Text
                        Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                        Dim filename As String = System.IO.Path.Combine(folder, id)
                        Try
                            Using fs As New FileStream(filename, FileMode.Open)
                                PictureBox1.Image = New Bitmap(System.Drawing.Image.FromStream(fs))
                            End Using
                        Catch ex As Exception
                            Dim msg As String = "Filename: " & filename &
                            Environment.NewLine & Environment.NewLine &
                            "Exception : " & ex.ToString
                            Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                        End Try

                    End If

                End If

            Case Keys.Left

                If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Exit Sub
                TreeView1.CollapseAll()

            Case Keys.Right

                If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Exit Sub
                TreeView1.ExpandAll()

            Case Keys.Home

                Dim TotalNodesInTree As Integer = TreeView1.GetNodeCount(True)
                Dim NombreDeLignes As Integer

                If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Exit Sub

                If ListView1.SelectedItems.Count > 0 Then

                    NombreDeLignes = ListView1.SelectedIndices(0)
                    OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

                    Dim firstNode As TreeNode = TreeView1.Nodes(0).Nodes(0)

                    For i As Integer = 0 To ListBox2.Items.Count - 1
                        Foo = firstNode.Text
                        If ListBox2.Items(i).ToString = Foo Then
                            Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                            FileOne = monfichier(i).ToString
                        End If
                    Next

                    Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                    Dim v As String

                    For Each v In readTexte
                        If v.Contains(firstNode.Text) And v.Equals(value:=FileOne.ToString) Then
                            TextBox2.Text = Trim(Mid(v, 1, 18))
                            TextBox1.Text = Trim(Mid(v, 19, 90))
                            TextBox4.Text = Trim(Mid(v, 109, 120))
                            TextBox15.Text = Trim(Mid(v, 229, 120))
                            TextBox5.Text = Trim(Mid(v, 349, 120))
                            TextBox7.Text = Trim(Mid(v, 469, 120))
                            TextBox9.Text = Trim(Mid(v, 589, 120))
                            TextBox13.Text = Trim(Mid(v, 709, 120))
                            TextBox18.Text = Trim(Mid(v, 829, 120))
                            TextBox23.Text = Trim(Mid(v, 949, 120))
                            TextBox24.Text = Trim(Mid(v, 1069, 120))
                            TextBox25.Text = Trim(Mid(v, 1189, 120))
                            TextBox26.Text = Trim(Mid(v, 1309, 120))
                            TextBox28.Text = Trim(Mid(v, 1429, 120))
                            TextBox29.Text = Trim(Mid(v, 1549, 120))
                            TextBox33.Text = Trim(Mid(v, 1669, 120))
                            TextBox31.Text = Trim(Mid(v, 1789, 1200))
                            RichTextBox1.Text = Trim(Mid(v, 2989, 200))
                        End If
                    Next

                    If TextBox33.Text = "" Then
                        PictureBox1.Image = Image_16x_1
                    Else
                        Dim literal As String = TextBox33.Text
                        Dim subst As String = literal.Substring(0, 1)
                        PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                        Dim id As String = TextBox33.Text
                        Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                        Dim filename As String = System.IO.Path.Combine(folder, id)
                        Try
                            Using fs As New FileStream(filename, FileMode.Open)
                                PictureBox1.Image = New Bitmap(System.Drawing.Image.FromStream(fs))
                            End Using
                        Catch ex As Exception
                            Dim msg As String = "Filename: " & filename &
                        Environment.NewLine & Environment.NewLine &
                        "Exception : " & ex.ToString
                            Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                        End Try

                    End If

                End If

            Case Keys.Right

                Dim TotalNodesInTree As Integer = TreeView1.GetNodeCount(True)
                Dim NombreDeLignes As Integer

                If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Dim treeNode = TreeView1.SelectedNode.FirstNode

                If ListView1.SelectedItems.Count > 0 Then

                    NombreDeLignes = ListView1.SelectedIndices(0)
                    OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

                    Dim lastNode As TreeNode = TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes(TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Count - 1)

                    For i As Integer = 0 To ListBox2.Items.Count - 1
                        Foo = lastNode.Text
                        If ListBox2.Items(i).ToString = Foo Then
                            Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                            FileOne = monfichier(i).ToString
                        End If
                    Next

                    Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                    Dim w As String
                    For Each w In readTexte
                        If w.Contains(lastNode.Text) And w.Equals(value:=FileOne.ToString) Then
                            TextBox2.Text = Trim(Mid(w, 1, 18))
                            TextBox1.Text = Trim(Mid(w, 19, 90))
                            TextBox4.Text = Trim(Mid(w, 109, 120))
                            TextBox15.Text = Trim(Mid(w, 229, 120))
                            TextBox5.Text = Trim(Mid(w, 349, 120))
                            TextBox7.Text = Trim(Mid(w, 469, 120))
                            TextBox9.Text = Trim(Mid(w, 589, 120))
                            TextBox13.Text = Trim(Mid(w, 709, 120))
                            TextBox18.Text = Trim(Mid(w, 829, 120))
                            TextBox23.Text = Trim(Mid(w, 949, 120))
                            TextBox24.Text = Trim(Mid(w, 1069, 120))
                            TextBox25.Text = Trim(Mid(w, 1189, 120))
                            TextBox26.Text = Trim(Mid(w, 1309, 120))
                            TextBox28.Text = Trim(Mid(w, 1429, 120))
                            TextBox29.Text = Trim(Mid(w, 1549, 120))
                            TextBox33.Text = Trim(Mid(w, 1669, 120))
                            TextBox31.Text = Trim(Mid(w, 1789, 1200))
                            RichTextBox1.Text = Trim(Mid(w, 2989, 200))
                        End If
                    Next

                    If TextBox33.Text = "" Then
                        PictureBox1.Image = Image_16x_1
                    Else
                        Dim literal As String = TextBox33.Text
                        Dim subst As String = literal.Substring(0, 1)
                        PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                        Dim id As String = TextBox33.Text
                        Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                        Dim filename As String = System.IO.Path.Combine(folder, id)
                        Try
                            Using fs As New FileStream(filename, FileMode.Open)
                                PictureBox1.Image = New Bitmap(System.Drawing.Image.FromStream(fs))
                            End Using
                        Catch ex As Exception
                            Dim msg As String = "Filename: " & filename &
                    Environment.NewLine & Environment.NewLine &
                    "Exception : " & ex.ToString
                            Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                        End Try

                    End If

                End If

            Case Keys.KeyCode
                Exit Select
            Case Keys.Modifiers
                Exit Select
            Case Keys.None
                Exit Select
            Case Keys.LButton
                Exit Select
            Case Keys.RButton
                Exit Select
            Case Keys.Cancel
                Exit Select
            Case Keys.MButton
                Exit Select
            Case Keys.XButton1
                Exit Select
            Case Keys.XButton2
                Exit Select
            Case Keys.Back
                Exit Select
            Case Keys.Tab
                Exit Select
            Case Keys.LineFeed
                Exit Select
            Case Keys.Clear
                Exit Select
            Case Keys.Return
                Exit Select
            Case Keys.ShiftKey
                Exit Select
            Case Keys.ControlKey
                Exit Select
            Case Keys.Menu
                Exit Select
            Case Keys.Pause
                Exit Select
            Case Keys.Capital
                Exit Select
            Case Keys.KanaMode
                Exit Select
            Case Keys.JunjaMode
                Exit Select
            Case Keys.FinalMode
                Exit Select
            Case Keys.HanjaMode
                Exit Select
            Case Keys.Escape
                Exit Select
            Case Keys.IMEConvert
                Exit Select
            Case Keys.IMENonconvert
                Exit Select
            Case Keys.IMEAccept
                Exit Select
            Case Keys.IMEModeChange
                Exit Select
            Case Keys.Space
                Exit Select
            Case Keys.Prior
                Exit Select
            Case Keys.Next
                Exit Select
            Case Keys.Select
                Exit Select
            Case Keys.Print
                Exit Select
            Case Keys.Execute
                Exit Select
            Case Keys.Snapshot
                Exit Select
            Case Keys.Insert
                Exit Select
            Case Keys.Delete
                Exit Select
            Case Keys.Help
                Exit Select
            Case Keys.D0
                Exit Select
            Case Keys.D1
                Exit Select
            Case Keys.D2
                Exit Select
            Case Keys.D3
                Exit Select
            Case Keys.D4
                Exit Select
            Case Keys.D5
                Exit Select
            Case Keys.D6
                Exit Select
            Case Keys.D7
                Exit Select
            Case Keys.D8
                Exit Select
            Case Keys.D9
                Exit Select
            Case Keys.A
                Exit Select
            Case Keys.B
                Exit Select
            Case Keys.C
                Exit Select
            Case Keys.D
                Exit Select
            Case Keys.E
                Exit Select
            Case Keys.F
                Exit Select
            Case Keys.G
                Exit Select
            Case Keys.H
                Exit Select
            Case Keys.I
                Exit Select
            Case Keys.J
                Exit Select
            Case Keys.K
                Exit Select
            Case Keys.L
                Exit Select
            Case Keys.M
                Exit Select
            Case Keys.N
                Exit Select
            Case Keys.O
                Exit Select
            Case Keys.P
                Exit Select
            Case Keys.Q
                Exit Select
            Case Keys.R
                Exit Select
            Case Keys.S
                Exit Select
            Case Keys.T
                Exit Select
            Case Keys.U
                Exit Select
            Case Keys.V
                Exit Select
            Case Keys.W
                Exit Select
            Case Keys.X
                Exit Select
            Case Keys.Y
                Exit Select
            Case Keys.Z
                Exit Select
            Case Keys.LWin
                Exit Select
            Case Keys.RWin
                Exit Select
            Case Keys.Apps
                Exit Select
            Case Keys.Sleep
                Exit Select
            Case Keys.NumPad0
                Exit Select
            Case Keys.NumPad1
                Exit Select
            Case Keys.NumPad2
                Exit Select
            Case Keys.NumPad3
                Exit Select
            Case Keys.NumPad4
                Exit Select
            Case Keys.NumPad5
                Exit Select
            Case Keys.NumPad6
                Exit Select
            Case Keys.NumPad7
                Exit Select
            Case Keys.NumPad8
                Exit Select
            Case Keys.NumPad9
                Exit Select
            Case Keys.Multiply
                Exit Select
            Case Keys.Add
                Exit Select
            Case Keys.Separator
                Exit Select
            Case Keys.Subtract
                Exit Select
            Case Keys.Decimal
                Exit Select
            Case Keys.Divide
                Exit Select
            Case Keys.F1
                Exit Select
            Case Keys.F2
                Exit Select
            Case Keys.F3
                Exit Select
            Case Keys.F4
                Exit Select
            Case Keys.F5
                Exit Select
            Case Keys.F6
                Exit Select
            Case Keys.F7
                Exit Select
            Case Keys.F8
                Exit Select
            Case Keys.F9
                Exit Select
            Case Keys.F10
                Exit Select
            Case Keys.F11
                Exit Select
            Case Keys.F12
                Exit Select
            Case Keys.F13
                Exit Select
            Case Keys.F14
                Exit Select
            Case Keys.F15
                Exit Select
            Case Keys.F16
                Exit Select
            Case Keys.F17
                Exit Select
            Case Keys.F18
                Exit Select
            Case Keys.F19
                Exit Select
            Case Keys.F20
                Exit Select
            Case Keys.F21
                Exit Select
            Case Keys.F22
                Exit Select
            Case Keys.F23
                Exit Select
            Case Keys.F24
                Exit Select
            Case Keys.NumLock
                Exit Select
            Case Keys.Scroll
                Exit Select
            Case Keys.LShiftKey
                Exit Select
            Case Keys.RShiftKey
                Exit Select
            Case Keys.LControlKey
                Exit Select
            Case Keys.RControlKey
                Exit Select
            Case Keys.LMenu
                Exit Select
            Case Keys.RMenu
                Exit Select
            Case Keys.BrowserBack
                Exit Select
            Case Keys.BrowserForward
                Exit Select
            Case Keys.BrowserRefresh
                Exit Select
            Case Keys.BrowserStop
                Exit Select
            Case Keys.BrowserSearch
                Exit Select
            Case Keys.BrowserFavorites
                Exit Select
            Case Keys.BrowserHome
                Exit Select
            Case Keys.VolumeMute
                Exit Select
            Case Keys.VolumeDown
                Exit Select
            Case Keys.VolumeUp
                Exit Select
            Case Keys.MediaNextTrack
                Exit Select
            Case Keys.MediaPreviousTrack
                Exit Select
            Case Keys.MediaStop
                Exit Select
            Case Keys.MediaPlayPause
                Exit Select
            Case Keys.LaunchMail
                Exit Select
            Case Keys.SelectMedia
                Exit Select
            Case Keys.LaunchApplication1
                Exit Select
            Case Keys.LaunchApplication2
                Exit Select
            Case Keys.OemSemicolon
                Exit Select
            Case Keys.Oemplus
                Exit Select
            Case Keys.Oemcomma
                Exit Select
            Case Keys.OemMinus
                Exit Select
            Case Keys.OemPeriod
                Exit Select
            Case Keys.OemQuestion
                Exit Select
            Case Keys.Oemtilde
                Exit Select
            Case Keys.OemOpenBrackets
                Exit Select
            Case Keys.OemPipe
                Exit Select
            Case Keys.OemCloseBrackets
                Exit Select
            Case Keys.OemQuotes
                Exit Select
            Case Keys.Oem8
                Exit Select
            Case Keys.OemBackslash
                Exit Select
            Case Keys.ProcessKey
                Exit Select
            Case Keys.Packet
                Exit Select
            Case Keys.Attn
                Exit Select
            Case Keys.Crsel
                Exit Select
            Case Keys.Exsel
                Exit Select
            Case Keys.EraseEof
                Exit Select
            Case Keys.Play
                Exit Select
            Case Keys.Zoom
                Exit Select
            Case Keys.NoName
                Exit Select
            Case Keys.Pa1
                Exit Select
            Case Keys.OemClear
                Exit Select
            Case Keys.Shift
                Exit Select
            Case Keys.Control
                Exit Select
            Case Keys.Alt
                Exit Select
            Case Keys.End
                Exit Select
            Case Else
                Exit Select

        End Select

    End Sub

    Private Shared Sub CopyDirectory(sourcePath As String, destPath As String)

        If File.Exists(sourcePath) Then

            File.Copy(sourcePath, destPath, overwrite:=False)
            Dim msgBoxResult = MsgBox("Fichier copié vers " & destPath)

        End If

    End Sub

    Public Sub GenererunfichierxmlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenererunfichierxmlToolStripMenuItem.Click

        If TextBox1.Text = "" Then
            Dim messageBoxResult1 = Forms.MessageBox.Show("La zone de texte n'existe pas.")
            Exit Sub
        Else
            Dim messageBoxResult = Forms.MessageBox.Show("La zone de texte existe.")
        End If

        If ListView1.SelectedItems.Count > 0 Then
            Dim msgBoxResult = MsgBox("Générer un fichier XML.")

            ' Créer le XmlDocument.
            Dim XmlDoc As New XmlDocument()

            XmlDoc.LoadXml("<Prénommer></Prénommer>")

            Dim elemFiche As XmlElement

            Dim elemTitle As XmlElement
            elemTitle = XmlDoc.CreateElement("Title")
            elemTitle.InnerText = TextBox2.Text

            Dim elemName As XmlElement
            elemName = XmlDoc.CreateElement("Name")
            elemName.InnerText = TextBox1.Text

            Dim elemCharge As XmlElement
            elemCharge = XmlDoc.CreateElement("Charge")
            elemCharge.InnerText = TextBox4.Text

            Dim elemInstitute As XmlElement
            elemInstitute = XmlDoc.CreateElement("Institute")
            elemInstitute.InnerText = TextBox15.Text

            Dim elemCelebration As XmlElement
            elemCelebration = XmlDoc.CreateElement("Celebration")
            elemCelebration.InnerText = TextBox5.Text

            Dim elemBirth As XmlElement
            elemBirth = XmlDoc.CreateElement("Birth")
            elemBirth.InnerText = TextBox7.Text

            Dim elemDeath As XmlElement
            elemDeath = XmlDoc.CreateElement("Death")
            elemDeath.InnerText = TextBox9.Text

            Dim elemOtherparties As XmlElement
            elemOtherparties = XmlDoc.CreateElement("Otherparties")
            elemOtherparties.InnerText = TextBox13.Text

            Dim elemOthernames As XmlElement
            elemOthernames = XmlDoc.CreateElement("Othernames")
            elemOthernames.InnerText = TextBox18.Text

            Dim elemVenerable As XmlElement
            elemVenerable = XmlDoc.CreateElement("Venerable")
            elemVenerable.InnerText = TextBox23.Text

            Dim elemBeatified As XmlElement
            elemBeatified = XmlDoc.CreateElement("Beatified")
            elemBeatified.InnerText = TextBox24.Text

            Dim elemCanonized As XmlElement
            elemCanonized = XmlDoc.CreateElement("Canonized")
            elemCanonized.InnerText = TextBox25.Text

            Dim elemHeading As XmlElement
            elemHeading = XmlDoc.CreateElement("Heading")
            elemHeading.InnerText = TextBox26.Text

            Dim elemPatron As XmlElement
            elemPatron = XmlDoc.CreateElement("Patron")
            elemPatron.InnerText = TextBox28.Text

            Dim elemLink As XmlElement
            elemLink = XmlDoc.CreateElement("Link")
            elemLink.InnerText = TextBox29.Text

            Dim elemBiography As XmlElement
            elemBiography = XmlDoc.CreateElement("Biography")
            elemBiography.InnerText = TextBox31.Text

            Dim elemImage As XmlElement
            elemImage = XmlDoc.CreateElement("Image")
            elemImage.InnerText = TextBox33.Text

            Dim elemOrigin As XmlElement
            elemOrigin = XmlDoc.CreateElement("Origin")
            elemOrigin.InnerText = RichTextBox1.Text

            elemFiche = XmlDoc.CreateElement("Fiche")

            Dim xmlNode = elemFiche.AppendChild(elemTitle)
            Dim xmlNode1 = elemFiche.AppendChild(elemName)
            Dim xmlNode2 = elemFiche.AppendChild(elemCharge)
            Dim xmlNode3 = elemFiche.AppendChild(elemInstitute)
            Dim xmlNode4 = elemFiche.AppendChild(elemCelebration)
            Dim xmlNode5 = elemFiche.AppendChild(elemBirth)
            Dim xmlNode6 = elemFiche.AppendChild(elemDeath)
            Dim xmlNode7 = elemFiche.AppendChild(elemOtherparties)
            Dim xmlNode8 = elemFiche.AppendChild(elemOthernames)
            Dim xmlNode9 = elemFiche.AppendChild(elemVenerable)
            Dim xmlNode10 = elemFiche.AppendChild(elemBeatified)
            Dim xmlNode11 = elemFiche.AppendChild(elemCanonized)
            Dim xmlNode12 = elemFiche.AppendChild(elemHeading)
            Dim xmlNode13 = elemFiche.AppendChild(elemPatron)
            Dim xmlNode14 = elemFiche.AppendChild(elemLink)
            Dim xmlNode15 = elemFiche.AppendChild(elemBiography)
            Dim xmlNode16 = elemFiche.AppendChild(elemImage)
            Dim xmlNode17 = elemFiche.AppendChild(elemOrigin)

            Dim xmlNode18 = XmlDoc.DocumentElement.AppendChild(elemFiche)

            Dim settings As New XmlWriterSettings With {
        .Indent = True
    }

            ' Enregistrez le document dans un fichier et indentez automatiquement la sortie.

            Dim writer As XmlWriter = XmlWriter.Create(My.Application.Info.DirectoryPath & "\Xml\" & TextBox1.Text & ".xml", settings)
            XmlDoc.Save(writer)
            Dim msgBoxResult1 = MsgBox("Génération et enregistrement du fichier xml standard réussis.")

            Dim v = ToolStripComboBox1.Items.Add(TextBox1.Text & ".xml")

        Else
            Dim msgBoxResult = MsgBox("Afin de créer un fichier xml standard, vous devez sélectionner un document d'un fichier librairie !")
        End If

    End Sub

    Public Sub LireunfichierxmlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LireunfichierxmlToolStripMenuItem.Click

        Try

            ' Création d'une nouvelle instance du membre xmldocument.
            Dim XmlDoc As New XmlDocument()
            Dim filePath As String = ""

            If String.IsNullOrEmpty(ToolStripComboBox1.Text) Then
                Dim msgBoxResult = MsgBox("Aucun fichier .xml sélectionné.")
                Exit Sub
            End If

            If ListView1.SelectedItems.Count > 0 Then

                Dim msgBoxResult = MsgBox("Lire ou créer une fiche à partir d'un fichier XML. Vous devez, au préalable, sélectionner un fichier librairie.")

                FileXml = ToolStripComboBox1.SelectedItem.ToString()
                filePath = My.Application.Info.DirectoryPath & "\Xml\" & FileXml

                Dim dialogResult1 = Forms.MessageBox.Show(FileXml)

                Dim fullFileName As String = ListView1.SelectedItems(0).Text
                Dim fileNameWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(fullFileName)

                If ListView1.SelectedItems.Count > 0 Then
                    Dim var1 As String
                    var1 = ListView1.SelectedItems(0).Text
                    Dim unused = Forms.MessageBox.Show(var1)
                End If

                Dim NbLine As Integer = 0
                Dim SR As New StreamReader(My.Application.Info.DirectoryPath & "\Librairies\" & fullFileName)
                While Not SR.EndOfStream
                    Dim v5 = SR.ReadLine()
                    NbLine += 1
                End While
                SR.Close()

                Dim TotalNodesInTree As Integer = CInt(CStr(NbLine))
                Dim dialogResult2 = Forms.MessageBox.Show("Nombre total de nœuds dans l'arborescence = " & TotalNodesInTree.ToString())
                For Each tn As TreeNode In TreeView1.Nodes
                    For Each child As TreeNode In tn.Nodes
                        If String.Equals(child.Text.Trim(), System.IO.Path.GetFileNameWithoutExtension(FileXml), StringComparison.OrdinalIgnoreCase) Then
                            ' Le nom du fichier XML est en doublon.
                            Dim msgBoxResult2 = MsgBox(child.Text & " : Doublon, veuillez renommer le nom du fichier xml en lui adjoignant une numérotation entre parenthèses ou crochets par exemple !")
                            Exit Sub
                        End If
                    Next
                Next

                NouveauToolStripButton.PerformClick()

                Using fileStream As FileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None)
                    ' Lire le fichier dans un MemoryStream.
                    Dim memoryStream As New MemoryStream()
                    fileStream.CopyTo(memoryStream)

                    ' Charger le document XML depuis la mémoire tampon.
                    Dim unused1 = memoryStream.Seek(0, SeekOrigin.Begin)
                    XmlDoc.Load(memoryStream)
                End Using

                Dim msgBoxResult3 = MsgBox(My.Application.Info.DirectoryPath & "\Xml\" & FileXml)

                Dim element As XmlNodeList
                element = XmlDoc.DocumentElement.GetElementsByTagName("Fiche")

                Dim noeud, noeudEnf As XmlNode

                For Each noeud In element
                    For Each noeudEnf In noeud.ChildNodes
                        If noeudEnf.LocalName = "Title" Then
                            TextBox2.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Name" Then
                            TextBox1.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Charge" Then
                            TextBox4.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Institute" Then
                            TextBox15.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Celebration" Then
                            TextBox5.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Birth" Then
                            TextBox7.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Death" Then
                            TextBox9.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Otherparties" Then
                            TextBox13.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Othernames" Then
                            TextBox18.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Venerable" Then
                            TextBox23.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Beatified" Then
                            TextBox24.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Canonized" Then
                            TextBox25.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Heading" Then
                            TextBox26.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Patron" Then
                            TextBox28.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Link" Then
                            TextBox29.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Biography" Then
                            TextBox31.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Image" Then
                            TextBox33.Text = noeudEnf.InnerText
                        ElseIf noeudEnf.LocalName = "Origin" Then
                            RichTextBox1.Text = noeudEnf.InnerText
                        End If
                    Next
                Next
            End If

            Dim msgBoxResult4 = MsgBox("Important ! Enregistrement du Xml.")

            'EnregistrerToolStripButton.Enabled = True

            TreeView1.ExpandAll()
            TreeView1.Sort()

            ' Après avoir terminé avec le fichier, fermez-le explicitement.
            XmlDoc.Save(filePath)
            XmlDoc = Nothing ' Assurez-vous de libérer la référence au document XML.

            If FileXml IsNot Nothing Then
                Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Xml\" & FileXml)
            End If

            Dim resultat As String
            ToolStripComboBox1.Items.Clear()
            ListBox1.Items.Clear()
            Dim fileNames = Computer.FileSystem.GetFiles(My.Application.Info.DirectoryPath & "\Xml" & "\", FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            For Each fileName As String In fileNames
                resultat = System.IO.Path.GetFileName(fileName)
                Dim v = ToolStripComboBox1.Items.Add(resultat)
                Dim v1 = ListBox1.Items.Add(resultat)
            Next

            ListeToolStripButton.PerformClick()
            ToolStripComboBox1.Text = ""

        Catch ex As IOException
            ' Le fichier est en cours d'utilisation par un autre processus.
            ' Vous pouvez traiter cette situation comme nécessaire.
            Dim unused2 = Forms.MessageBox.Show($"Le fichier est en cours d'utilisation : {ex.Message}")
        End Try

    End Sub

    Private Sub TreeView1_MouseMove(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseMove

        ' Récupération du TreeNode survolé.
        Dim currentNode As TreeNode = TreeView1.GetNodeAt(e.X, e.Y)

        ' Vérification que la souris survole bien un TreeNode.
        If currentNode Is Nothing Then
            GenererunfichierdocxToolStripMenuItem.Enabled = False
        End If

    End Sub

    Public Sub FindMySpecificString(searchString As String)

        ' Assurez-vous que vous avez une chaîne appropriée à rechercher.

        If Not String.IsNullOrEmpty(searchString) Then
            ' Trouver l'élément dans la liste et stocker l'index de l'élément.
            IndexEnreg = ListBox2.FindStringExact(searchString)

            ' Déterminez si un index valide est renvoyé. Sélectionnez l'élément s'il est valide.
            If IndexEnreg <> -1 Then
                ListBox2.SetSelected(IndexEnreg, True)
            Else
                Dim dialogResult1 = Forms.MessageBox.Show("La chaîne de recherche ne correspond à aucun élément de la zone de liste.")
            End If
        End If

    End Sub

    Public Sub TreeView1_MouseDown(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseDown

        Dim hit = TreeView1.HitTest(e.X, e.Y)

        If hit.Node Is Nothing Then
            TreeView1.SelectedNode = Nothing
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim i As Integer = 1
        For Each ItList As String In ListBox2.Items
            Call Forms.MessageBox.Show(ItList.ToString, "Element " & i.ToString, MessageBoxButtons.OK)
            i += 1
        Next

    End Sub

    Public Sub PrintDocumentUsingShellExecute(szPrinter As String, szDocumentPath As String)

        Dim szDefaultPrinter As New StringBuilder(256)
        Dim bufferSize As Integer = szDefaultPrinter.Capacity

        ' Obtenir l'imprimante par défaut.
        Dim v = GetDefaultPrinter(szDefaultPrinter, bufferSize)

        ' Changer l'imprimante par défaut.
        If String.Compare(szPrinter, szDefaultPrinter.ToString(), True) <> 0 Then
            Dim v1 = SetDefaultPrinter(szPrinter)
        End If

        ' Envoyer le document à l'impression.
        Dim printProcess As New Process
        printProcess.StartInfo.FileName = szDocumentPath
        printProcess.StartInfo.Verb = "Print"
        printProcess.StartInfo.CreateNoWindow = True
        Dim v2 = printProcess.Start()

        ' Remettre l'imprimante par défaut.
        If String.Compare(szPrinter, szDefaultPrinter.ToString()) <> 0 Then
            Dim v1 = SetDefaultPrinter(szDefaultPrinter.ToString())
        End If

    End Sub

    Public Sub AddImageToBody(wordDoc As WordprocessingDocument, relationshipId As String)

        'Define the reference of the image. {.Cx = 990000L, .Cy = 792000L}   'Name = "New Bitmap Image.jpg"

        'Dim sz As New Bitmap(My.Application.Info.DirectoryPath & "\Images\" & TextBox1.Text.Substring(0, 1) & "\" & TextBox33.Text)

        'Dim size As New Size(sz.Width, sz.Height) '(584, 361)
        'Dim width As Int64Value = CType(size.Width * 9525 / 2, Int64Value)
        'Dim height As Int64Value = CType(size.Height * 9525 / 2, Int64Value)

        Dim element = New Office.Drawing.Drawing(
New DW.Inline(
              New DW.Extent() With {.Cx = Width, .Cy = Height},
              New DW.EffectExtent() With {.LeftEdge = 0L, .TopEdge = 0L, .RightEdge = 0L, .BottomEdge = 0L},
              New DW.DocProperties() With {.Id = 1UI, .Name = "Picture1"},
              New DW.NonVisualGraphicFrameDrawingProperties(
                  New A.GraphicFrameLocks() With {.NoChangeAspect = True}
                  ),
              New A.Graphic(New A.GraphicData(
                            New PIC.Picture(
                                New PIC.NonVisualPictureProperties(
                                    New PIC.NonVisualDrawingProperties() With {.Id = 0UI, .Name = TextBox33.Text},
                                    New PIC.NonVisualPictureDrawingProperties()
                                    ),
                                New PIC.BlipFill(
                                    New A.Blip(
                                        New A.BlipExtensionList(
                                            New A.BlipExtension() With {.Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"})
                                        ) With {.Embed = relationshipId, .CompressionState = A.BlipCompressionValues.Print},
                                    New A.Stretch(
                                        New A.FillRectangle()
                                        )
                                    ),
                                New PIC.ShapeProperties(
                                    New A.Transform2D(
                                        New A.Offset() With {.X = 0L, .Y = 0L},
                                        New A.Extents() With {.Cx = Width, .Cy = Height}),
                                    New A.PresetGeometry(
                                        New A.AdjustValueList()
                                        ) With {.Preset = A.ShapeTypeValues.Rectangle}
                                    )
                                )
                            ) With {.Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"}
                        )
                    ) With {.DistanceFromTop = 0UI,
                            .DistanceFromBottom = 0UI,
                            .DistanceFromLeft = 0UI,
                            .DistanceFromRight = 0UI}
                )

        ' Ajoutez la référence au corps, l'élément doit être dans un Run.
        Dim paragraph = wordDoc.MainDocumentPart.Document.Body.AppendChild(New Paragraph(New Run(element)))

    End Sub

    Public Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click

        Dim file As StreamWriter

        If Not String.IsNullOrEmpty(TextBox1.Text) Then

            file = Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\" & "Téléchargements\" & TextBox1.Text & ".txt", True)
            file.WriteLine(TextBox2.Text + " " + TextBox1.Text + vbCrLf)
            file.WriteLine(TextBox4.Text + vbCrLf)
            file.WriteLine(TextBox15.Text + vbCrLf)
            file.WriteLine(TextBox5.Text + vbCrLf)
            file.WriteLine(TextBox7.Text + vbCrLf)
            file.WriteLine(TextBox9.Text + vbCrLf)
            file.WriteLine(TextBox13.Text + vbCrLf)
            file.WriteLine(TextBox18.Text + vbCrLf)
            file.WriteLine(TextBox23.Text + vbCrLf)
            file.WriteLine(TextBox24.Text + vbCrLf)
            file.WriteLine(TextBox25.Text + vbCrLf)
            file.WriteLine(TextBox26.Text + vbCrLf)
            file.WriteLine(TextBox28.Text + vbCrLf)
            file.WriteLine(TextBox29.Text + vbCrLf)
            file.WriteLine(TextBox33.Text + vbCrLf)
            file.WriteLine(TextBox31.Text + vbCrLf)
            file.WriteLine(RichTextBox1.Text + vbCrLf)

            file.WriteLine(" ")
            file.Write("Date : ")
            file.WriteLine(Date.Now)

            file.Close()

            Dim msgBoxResult = MsgBox("L'exécution du processus est terminée.")

        Else

            Exit Sub

        End If

    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click

        Dim write As StreamWriter

        Try

            If String.IsNullOrEmpty(TextBox1.Text) Then
                Dim msgBoxResult = MsgBox("Impossible d'accéder à un dossier ou à l'un de ses composants.")
                Exit Sub
            End If

            If Not String.IsNullOrEmpty(TextBox1.Text) Then

                Dim fic = My.Application.Info.DirectoryPath & "\" & "Téléchargements\" & TextBox1.Text & ".rtf"

                write = File.CreateText(My.Application.Info.DirectoryPath & "\" & "Téléchargements\" & TextBox1.Text & ".rtf")

                write.WriteLine((TextBox2.Text + " ") & (TextBox1.Text + vbCrLf))
                write.WriteLine(TextBox4.Text + vbCrLf)
                write.WriteLine(TextBox15.Text + vbCrLf)
                write.WriteLine(TextBox5.Text + vbCrLf)
                write.WriteLine(TextBox7.Text + vbCrLf)
                write.WriteLine(TextBox9.Text + vbCrLf)
                write.WriteLine(TextBox13.Text + vbCrLf)
                write.WriteLine(TextBox18.Text + vbCrLf)
                write.WriteLine(TextBox23.Text + vbCrLf)
                write.WriteLine(TextBox24.Text + vbCrLf)
                write.WriteLine(TextBox25.Text + vbCrLf)
                write.WriteLine(TextBox26.Text + vbCrLf)
                write.WriteLine(TextBox28.Text + vbCrLf)
                write.WriteLine(TextBox29.Text + vbCrLf)
                write.WriteLine(TextBox33.Text + vbCrLf)
                write.WriteLine(TextBox31.Text + vbCrLf)
                write.WriteLine(RichTextBox1.Text + vbCrLf)

                write.WriteLine(" ")
                write.Write("Date : ")
                write.WriteLine(Date.Now)

                write.Close()

            End If

        Catch ex As Exception
            Dim dialogResult1 = Forms.MessageBox.Show(ex.Message)
        Finally
            Dim dialogResult1 = Forms.MessageBox.Show("L'exécution du processus est terminée.")

        End Try

    End Sub

    Public Function GetUserName() As String

        If TypeOf User.CurrentPrincipal Is System.Security.Principal.WindowsPrincipal Then
            ' L'application utilise l'authentification Windows.
            ' Le format du nom est DOMAIN\USERNAME.
            Dim parts() As String = Split(User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' L'application utilise une authentification personnalisée.
            Return User.Name
        End If

    End Function

    Public Async Sub ConsulterMisesJourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsulterMisesJourToolStripMenuItem.Click

        Dim versionLocale As String = "3.7.0.0"
        Dim versionDistante As String = Await RécupérerVersionEnLigne()

        ' Vérifier que la version distante a bien été récupérée
        If versionDistante = "" Then
            Dim unused1 = MsgBox("Impossible de récupérer la version distante.", vbCritical, "Prénommer")
            Exit Sub
        End If

        ' Normaliser les versions pour éviter les différences de format
        Dim versionLocaleNormalisée As String = NormaliserVersion(versionLocale)
        Dim versionDistanteNormalisée As String = NormaliserVersion(versionDistante)

        ' Vérifier si l'application est déjà à jour
        If versionLocaleNormalisée = versionDistanteNormalisée Then
            Dim unused = Forms.MessageBox.Show("Votre application est déjà à jour.", "Prénommer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub ' Arrêter la procédure ici
        End If

        ' Informer l'utilisateur qu'une mise à jour est disponible
        Dim reponse As MsgBoxResult = MsgBox("Une nouvelle version (" & versionDistanteNormalisée & ") est disponible. Voulez-vous la télécharger ?", CType(vbYesNo + vbInformation, MsgBoxStyle), "Prénommer")

        ' Lancer la mise à jour si l'utilisateur accepte
        If reponse = vbYes Then
            VérifierEtMettreAJour()
        End If

    End Sub

    Public Function NormaliserVersion(version As String) As String

        Dim segments() As String = version.Split(CChar("."))
        Return segments(0) & "." & segments(1) ' Conserver les deux premiers segments

    End Function

    Public Async Function VérifierMiseAJour(versionLocale As String) As Task(Of Boolean)

        Dim versionEnLigne As String = Await RécupérerVersionEnLigne()

        If versionEnLigne = "" Then
            Return False ' Erreur ou fichier inaccessible
        End If

        Return versionEnLigne <> versionLocale

    End Function

    Public Sub VérifierEtMettreAJour()

        ' Étape 1 : Télécharger le fichier
        Dim unused = TéléchargerMiseAJour()

        ' Étape 2 : Installer la mise à jour après le téléchargement
        InstallerMiseAJour()

        ' Étape 3 : Assurer la mise à jour de l'affichage et du focus
        Forms.Application.DoEvents()
        Activate()

        ' Étape 4 : Affichage du message final

        Dim unused1 = Forms.MessageBox.Show("Mise à jour terminée.",
                      "Prénommer", MessageBoxButtons.OK,
                      MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub

    Public Async Function TéléchargerMiseAJour() As Tasks.Task

        Using client As New HttpClient()

            Dim urlMiseAJour As String = "https://www.dropbox.com/scl/fi/y1amirpagmv8tjp0ba2or/prenommer_setup_3.7.0.0.7z?rlkey=xbuqy3dnxuny0zbx4w2n47ad2&st=n8ndjav6&dl=1"
            Dim cheminLocal As String = "C:\Prenommer\tmp\prenommer_setup_3.7.0.0.7z"

            Try

                ' Télécharger le contenu en mémoire
                Dim response As HttpResponseMessage = Await client.GetAsync(urlMiseAJour)
                Dim unused1 = response.EnsureSuccessStatusCode()

                ' Lire les données en tant que flux
                Using stream As Stream = Await response.Content.ReadAsStreamAsync(),
                  fileStream As New FileStream(cheminLocal, FileMode.Create, FileAccess.Write, FileShare.None)

                    Await stream.CopyToAsync(fileStream)
                End Using

                If File.Exists("C:\Prenommer\tmp\prenommer_setup_3.7.0.0.7z") Then
                    Dim unused2 = MessageBox.Show("Le fichier a bien été téléchargé !", "Succès")
                Else
                    Dim unused3 = MessageBox.Show("Erreur : le fichier n’a pas été trouvé après téléchargement.", "Erreur")
                End If

                'Forms.MessageBox.Show("Mise à jour téléchargée avec succès !", "Info",
                'MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                Dim unused = Forms.MessageBox.Show("Erreur : " & ex.Message, "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Using

    End Function

    Public Sub CopierFichierViaCMD()

        Dim processInfo As New ProcessStartInfo With {
            .FileName = "cmd.exe",
            .Arguments = "/c copy ""C:\Users\admin\Downloads\prenommer_setup_3.7.0.0.7z"" ""C:\Prenommer\tmp\prenommer_setup_3.7.0.0.7z""",
            .RedirectStandardOutput = True,
            .UseShellExecute = False,
            .CreateNoWindow = True ' Exécuter sans afficher la console
            }

        Try
            Dim process As Process = Process.Start(processInfo)
            process.WaitForExit()

            Dim unused = Forms.MessageBox.Show("Fichier copié avec succès via CMD !", "Succès",
       MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show("Erreur : " & ex.Message, "Erreur",
        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub InstallerMiseAJour()

        Dim cheminArchive As String = "C:\Prenommer\Updates\prenommer_setup_3.7.0.0.7z"
        Dim dossierDestination As String = "C:\Prenommer\Updates\Extraction"
        Dim cheminExe As String = dossierDestination & "\prenommer_setup_3.7.0.0.7z"
        Dim chemin7z As String = "C:\Program Files\7-Zip\7z.exe"

        ' Vérifier si le fichier archive existe
        If Not File.Exists(cheminArchive) Then
            Dim unused = Forms.MessageBox.Show("Erreur : Fichier prenommer_setup_3.7.0.0.7z introuvable !",
         "Prénommer", MessageBoxButtons.OK,
             MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        ' Vérifier ou créer le dossier d'extraction
        If Not Directory.Exists(dossierDestination) Then
            Dim unused5 = Directory.CreateDirectory(dossierDestination)
        End If

        ' Vérifier que 7-Zip est bien installé
        If Not File.Exists(chemin7z) Then
            Dim unused1 = Forms.MessageBox.Show("Erreur : `7z.exe` introuvable. Vérifiez l'installation de 7-Zip",
         "Prénommer", MessageBoxButtons.OK,
             MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        ' Lancer l'extraction en mode caché
        Dim ps As New Process()
        ps.StartInfo.FileName = chemin7z
        ps.StartInfo.Arguments = "x """ & cheminArchive & """ -o""" & dossierDestination & """ -y"
        ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Dim unused6 = ps.Start()
        ps.WaitForExit() ' Attendre la fin complète de l'extraction

        Dim unused2 = Forms.MessageBox.Show("Une mise à jour est en cours. Veuillez patienter...", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Thread.Sleep(3000) ' Attente de 3 secondes avant de démarrer l'installation

        ' Vérifier si `prenommer_setup_3.7.0.0.7z` a bien été extrait
        If File.Exists(cheminExe) Then
            Dim unused3 = Forms.MessageBox.Show("Extraction réussie ! `prenommer_setup_3.7.0.0.7z` est prêt.",
         "Prénommer", MessageBoxButtons.OK,
             MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Dim unused7 = Process.Start(cheminExe) ' Lancer l'installation
        Else
            Dim unused4 = Forms.MessageBox.Show("Erreur : `prenommer_setup_3.7.0.0.7z` introuvable après extraction !",
         "Prénommer", MessageBoxButtons.OK,
             MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Public Sub CopierFichier7z()

        Dim dossierOutput As String = "C:\Output"
        Dim cheminFichierSource As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Téléchargements\prenommer_setup_3.7.0.0.7z"
        Dim cheminFichierDestination As String = dossierOutput & "\prenommer_setup_3.7.0.0.7z"

        ' Vérifier si Output existe, sinon le créer
        If Not Directory.Exists(dossierOutput) Then
            Dim unused = Directory.CreateDirectory(dossierOutput)
        End If

        ' Vérifier si le fichier .7z est complet avant de le copier
        If File.Exists(cheminFichierSource) AndAlso New FileInfo(cheminFichierSource).Length > 1024 Then
            File.Copy(cheminFichierSource, cheminFichierDestination, True) ' Copie sécurisée avec écrasement
            Dim unused1 = MsgBox("Le fichier .7z a été copié dans Output avec succès !", vbInformation, "Prénommer")
        Else
            Dim unused2 = MsgBox("Le fichier .7z semble corrompu ou incomplet. Vérifiez son téléchargement.", vbCritical, "Prénommer")
        End If

    End Sub

    Public Sub DeplacerFichierExe()

        Dim dossierOutput As String = "C:\Output"
        Dim cheminExeSource As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Téléchargements\prenommer_setup_3.7.0.0.exe"
        Dim cheminExeDestination As String = dossierOutput & "\prenommer_setup_3.7.0.0.exe"

        ' Vérifie si le fichier .exe existe avant de le déplacer
        If File.Exists(cheminExeSource) Then
            File.Move(cheminExeSource, cheminExeDestination)
            Dim unused = MsgBox("Le fichier .exe a été déplacé vers Output avec succès !", vbInformation, "Prénommer")
        Else
            Dim unused1 = MsgBox("Le fichier .exe est introuvable dans Téléchargements !", vbCritical, "Prénommer")
        End If

    End Sub

    Public Sub DeplacerFichier7z()

        Dim dossierOutput As String = "C:\Output"
        Dim cheminFichierSource As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Téléchargements\prenommer_setup_3.7.0.0.7z"
        Dim cheminFichierDestination As String = dossierOutput & "\prenommer_setup_3.7.0.0.7z"

        ' Vérifier et créer le dossier Output s'il n'existe pas
        If Not Directory.Exists(dossierOutput) Then
            Dim unused = Directory.CreateDirectory(dossierOutput)
        End If

        ' Déplacer le fichier .7z AVANT l'installation
        If File.Exists(cheminFichierSource) Then
            File.Move(cheminFichierSource, cheminFichierDestination)
            Dim unused1 = MsgBox("Le fichier .7z a été déplacé vers Output avec succès !", vbInformation, "Prénommer")
        Else
            Dim unused2 = MsgBox("Le fichier .7z est introuvable dans Téléchargements !", vbCritical, "Prénommer")
        End If

    End Sub

    Public Sub ExtraireMiseAJour()

        Dim dossierOutput As String = "C:\Output"
        Dim cheminArchive As String = dossierOutput & "\prenommer_setup_3.7.0.0.7z"
        Dim chemin7Zip As String = "C:\Program Files\7-Zip\7z.exe"

        ' Assurer que le fichier .7z est bien copié en Output
        CopierFichier7z()

        ' Vérifier si l'archive est bien présente
        If Not File.Exists(cheminArchive) Then
            Dim unused1 = MsgBox("L'archive .7z est introuvable dans Output !", vbCritical, "Prénommer")
            Exit Sub
        End If

        ' Extraire le fichier .7z après déplacement
        Dim arguments As String = "x """ & cheminArchive & """ -o""" & dossierOutput & """ -y"

        Try
            Dim unused = Process.Start(chemin7Zip, arguments)
            Dim unused2 = MsgBox("Extraction terminée ! Ouvrez '" & dossierOutput & "' pour lancer l'installation.", vbInformation, "Prénommer")
        Catch ex As Exception
            Dim unused3 = MsgBox("Erreur lors de l'extraction : " & ex.Message, vbCritical, "Prénommer")
        End Try

    End Sub

    Public Async Function RécupérerVersionEnLigne() As Task(Of String)

        Using client As New HttpClient()
            Try

                Dim versionEnLigne As String = Await client.GetStringAsync("https://www.dropbox.com/scl/fi/mrdeefvfj82rxw7sgvlpa/version.txt?rlkey=w0duphcqwbk5bq8aj73gs7zq2&st=h3ea0cpj&dl=1")
                Return versionEnLigne     '.Trim()

                'Dim versionEnLigne As String = RécupérerVersionEnLigne()
                Dim unused = MsgBox("Version en ligne détectée : [" & versionEnLigne & "]")

            Catch ex As Exception
                Dim unused1 = MsgBox("Impossible de récupérer la version en ligne : " & ex.Message, vbCritical, "Prénommer")
                Return ""
            End Try
        End Using

    End Function

    Public Sub TéléchargerEtInstallerMiseAJour()

        Dim client As New WebClient()
        Dim urlMiseAJour As String = "https://www.dropbox.com/scl/fi/y1amirpagmv8tjp0ba2or/prenommer_setup_3.7.0.0.7z?rlkey=xbuqy3dnxuny0zbx4w2n47ad2&st=n8ndjav6&dl=1"
        Dim cheminLocal As String = "C:\Prenommer\tmp\prenommer_setup_3.7.0.0.7z"

        Try
            client.DownloadFile(urlMiseAJour, cheminLocal)
            Dim unused = MsgBox("La mise à jour a été téléchargée. Elle va maintenant s’installer.", vbInformation, "Prénommer")
            Dim unused1 = Process.Start(cheminLocal) ' Lance le fichier après le téléchargement
        Catch ex As Exception
            Dim unused2 = MsgBox("Échec du téléchargement de la mise à jour : " & ex.Message, CType(vbYes + vbCritical, MsgBoxStyle), "Prénommer")
        End Try

    End Sub

    Public Function GetDownloadsPath() As String

        Try
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders")
            Dim downloadsPath As String = key.GetValue("Desktop").ToString().Replace("Desktop", "Downloads")
            Return downloadsPath
        Catch ex As Exception
            Dim unused = Forms.MessageBox.Show("Impossible de récupérer le dossier Téléchargements : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try

    End Function

    Public Sub LancerMiseAJour()

        Dim unused = Process.Start("powershell.exe", "-ExecutionPolicy Bypass -File ""C:\Scripts\mise_a_jour.ps1""")

    End Sub

    Public Sub ConvertToHtml(docxPath As String, outputDirectory As String)
        Try
            ' Vérifier l'existence du fichier source
            If Not File.Exists(docxPath) Then
                Throw New FileNotFoundException("Le fichier DOCX spécifié est introuvable.")
            End If

            ' Vérifier et créer le répertoire de sortie
            If Not Directory.Exists(outputDirectory) Then
                Dim unused = Directory.CreateDirectory(outputDirectory)
            End If

            ' Charger le document DOCX avec accès en lecture/écriture
            Using WdDoc As WordprocessingDocument = WordprocessingDocument.Open(docxPath, True)
                ' Configuration des paramètres pour la conversion
                Dim settings As New WmlToHtmlConverterSettings() With {
    .AdditionalCss = "body { margin: 1cm auto; max-width: 20cm; padding: 0; }",
    .PageTitle = "Titre de la page HTML",
    .FabricateCssClasses = True,
    .CssClassPrefix = "pt-",
    .RestrictToSupportedLanguages = False,
    .RestrictToSupportedNumberingFormats = False,
    .ImageHandler = Function(imageInfo)
                        Try
                            Dim extension = imageInfo.ContentType.Split("/"c)(1).ToLower()
                            Dim ImageFileName = $"image{Guid.NewGuid()}.{extension}"
                            Dim imagePath = System.IO.Path.Combine(outputDirectory, ImageFileName)

                            ' Sauvegarder l'image
                            imageInfo.Bitmap.Save(imagePath)
                            Return New XElement("img", New XAttribute("src", ImageFileName))
                        Catch ex As Exception
                            Dim unused1 = MsgBox($"Erreur lors de la sauvegarde de l'image : {ex.Message}")
                            Return Nothing
                        End Try
                    End Function
}

                ' Conversion en HTML
                Dim htmlElement As XElement = WmlToHtmlConverter.ConvertToHtml(WdDoc, settings)

                ' Sauvegarder le fichier HTML
                Dim htmlFileName = System.IO.Path.Combine(outputDirectory, "output.html")
                Dim html = New XDocument(New XDocumentType("html", Nothing, Nothing, Nothing), htmlElement)
                Dim htmlString = html.ToString(SaveOptions.DisableFormatting)
                File.WriteAllText(htmlFileName, htmlString, Encoding.UTF8)

                Dim unused2 = MsgBox($"Conversion réussie. Fichier HTML enregistré à : {htmlFileName}")
            End Using
        Catch ex As Exception
            Dim unused3 = MsgBox($"Erreur : {ex.Message}{vbCrLf}{ex.StackTrace}")
        End Try
    End Sub

    Private Sub UpdateAutoComplete()

        ' Effacer la liste de saisie semi-automatique actuelle.
        TextBox1.AutoCompleteCustomSource.Clear()

        ' Début modification du code.
        Dim col As New AutoCompleteStringCollection

        For Each Str As String In ListBox2.Items
            Dim v = col.Add(Str)
        Next
        TextBox1.AutoCompleteCustomSource = col
        TextBox1.AutoCompleteMode = AutoCompleteMode.Suggest
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        ' Fin de modification du code.

    End Sub

    ' Gestionnaire de l'événement LostFocus du TextBox5
    Private Sub TextBox5_LostFocus(sender As Object, e As EventArgs) Handles TextBox5.LostFocus

        Dim dateString As String = TextBox5.Text
        Dim provider As New CultureInfo("fr-FR")
        Dim validDate As Boolean

        Try
            If Not String.IsNullOrEmpty(dateString) Then
                ' Tenter de parser la date dans différents formats
                Dim formats As String() = {"d MMMM", "dd MMMM"}
                Dim dt As Date

                validDate = Date.TryParseExact(dateString, formats, provider, DateTimeStyles.None, dt)

                ' Validation spéciale pour le 29 février
                If Not validDate AndAlso dateString = "29 février" Then
                    validDate = True
                End If

                If validDate Then
                    validDate = False
                Else
                    Throw New FormatException("La chaîne n'a pas été reconnue comme une date valide.")
                End If
            End If

        Catch ex As Exception
            Dim unused = Forms.MessageBox.Show("La chaîne n'a pas été reconnue comme une date valide.")
            TextBox5.Text = ""

        End Try

    End Sub

    Private Sub ListView1_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListView1.DrawItem

        e.DrawDefault = True

        If e.ItemIndex Mod 2 = 1 Then

            e.Item.BackColor = System.Drawing.Color.FromArgb(230, 230, 255)
            e.Item.UseItemStyleForSubItems = True

        End If

    End Sub

    Private Sub ListView1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader

        e.DrawDefault = True

    End Sub

    Private Sub RichTextBox2_Click(sender As Object, e As EventArgs)

        Try
            Dim unused = Process.Start("https://creativecommons.org/licenses/by/4.0/legalcode.fr")
        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show("Impossible de charger la page Web." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub TreeView1_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles TreeView1.DrawNode

        ' Définir la zone de dessin pour le nœud
        Dim r As New System.Drawing.Rectangle(e.Bounds.Left, e.Bounds.Top, TreeView1.ClientSize.Width, e.Bounds.Height)

        If (e.State And TreeNodeStates.Selected) <> 0 Then
            ' Remplir le fond du nœud sélectionné avec une couleur jaune
            e.Graphics.FillRectangle(Brushes.Yellow, r)
            TextRenderer.DrawText(e.Graphics, e.Node.Text, TreeView1.Font, e.Bounds,
        System.Drawing.Color.Black, TextFormatFlags.VerticalCenter)
        Else
            ' Remplir le fond du nœud non sélectionné avec la couleur de la fenêtre
            e.Graphics.FillRectangle(SystemBrushes.Window, r)
            TextRenderer.DrawText(e.Graphics, e.Node.Text, TreeView1.Font, e.Bounds,
        System.Drawing.SystemColors.WindowText, TextFormatFlags.VerticalCenter)
        End If

    End Sub

    Private Sub FillRectangle(e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(System.Drawing.Color.Blue)

        ' Create rectangle.
        Dim rect As New System.Drawing.Rectangle(0, 0, 200, 200)

        ' Fill rectangle to screen.
        e.Graphics.FillRectangle(blueBrush, rect)

    End Sub

    Private Sub RechercherdanslesfichiersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RechercherdanslesfichiersToolStripMenuItem.Click

        Dim frm As New Class3
        frm.Show()

    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        Dim Node As TreeNode

        Node = TreeView1.GetNodeAt(New System.Drawing.Point(e.X, e.Y))

        If e.Button = Global.System.Windows.Forms.MouseButtons.Left Then
            TreeView1.SelectedNode = e.Node
        End If

        If e.Node.Text = "Librairie" Then Exit Sub

    End Sub

    Private Sub LogMessage(message As String)

        Dim logFilePath As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Resources\logfile.txt"
        Using writer As New StreamWriter(logFilePath, True)
            writer.WriteLine(Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & message)
        End Using

    End Sub

    Private Sub SafeSetClipboardText(text As String)

        Dim attempts As Integer = 10 ' Augmenter le nombre de tentatives
        Dim delay As Integer = 200   ' Augmenter le délai à 200 ms

        For i As Integer = 1 To attempts
            Try
                Clipboard.SetDataObject(text)
                LogMessage("Texte copié dans le presse-papiers : " & text)
                Exit For ' Si l'opération réussit, sortez de la boucle
            Catch ex As COMException
                LogMessage("Erreur lors de l'accès au presse-papiers (tentative " & i & " sur " & attempts & ") : " & ex.Message)
                If i = attempts Then
                    ' Si c'était la dernière tentative, affichez un message d'erreur
                    Dim unused = Forms.MessageBox.Show("Erreur lors de l'accès au presse-papiers : " & ex.Message)
                Else
                    ' Attendez avant de réessayer
                    Thread.Sleep(delay)
                End If
            Catch ex As Exception
                ' Gestion d'autres types d'exception potentiels
                LogMessage("Erreur inattendue lors de l'accès au presse-papiers : " & ex.Message)
                Dim unused1 = Forms.MessageBox.Show("Erreur inattendue lors de l'accès au presse-papiers : " & ex.Message)
                Exit For
            End Try
        Next

    End Sub

    Private Function SafeGetClipboardText() As String

        Dim attempts As Integer = 10 ' Augmenter le nombre de tentatives
        Dim delay As Integer = 200   ' Augmenter le délai à 200 ms
        Dim clipboardText As String = String.Empty

        For i As Integer = 1 To attempts
            Try
                clipboardText = Clipboard.GetText()
                LogMessage("Texte récupéré du presse-papiers : " & clipboardText)
                Exit For ' Si l'opération réussit, sortez de la boucle
            Catch ex As COMException
                LogMessage("Erreur lors de l'accès au presse-papiers (tentative " & i & " sur " & attempts & ") : " & ex.Message)
                If i = attempts Then
                    ' Si c'était la dernière tentative, affichez un message d'erreur
                    Dim unused = Forms.MessageBox.Show("Erreur lors de l'accès au presse-papiers : " & ex.Message)
                Else
                    ' Attendez avant de réessayer
                    Thread.Sleep(delay)
                End If
            Catch ex As Exception
                ' Gestion d'autres types d'exception potentiels
                LogMessage("Erreur inattendue lors de l'accès au presse-papiers : " & ex.Message)
                Dim unused1 = Forms.MessageBox.Show("Erreur inattendue lors de l'accès au presse-papiers : " & ex.Message)
                Exit For
            End Try
        Next

        Return clipboardText

    End Function

    Private Sub CopierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopierToolStripMenuItem.Click

        Dim ctl As Forms.Control = ActiveControl

        If TypeOf ctl Is TextBoxBase Then
            Dim textBox As TextBoxBase = DirectCast(ctl, TextBoxBase)
            If Not String.IsNullOrEmpty(textBox.SelectedText) Then
                TrySetClipboardText(textBox.SelectedText)
            End If
        ElseIf TypeOf ctl Is Forms.RichTextBox Then
            Dim richTextBox As Forms.RichTextBox = DirectCast(ctl, Forms.RichTextBox)
            If Not String.IsNullOrEmpty(richTextBox.SelectedText) Then
                TrySetClipboardText(richTextBox.SelectedText)
            End If
        ElseIf TypeOf ctl Is Forms.TreeView Then
            Dim treeView As Forms.TreeView = DirectCast(ctl, Forms.TreeView)
            If treeView.SelectedNode IsNot Nothing Then
                TrySetClipboardText(treeView.SelectedNode.Text)
            End If
        ElseIf TypeOf ctl Is Forms.ListView Then
            Dim listView As Forms.ListView = DirectCast(ctl, Forms.ListView)
            If listView.SelectedItems.Count > 0 Then
                TrySetClipboardText(listView.SelectedItems(0).Text)
            End If
        End If

    End Sub

    ' Méthode pour essayer de définir le texte dans le presse-papiers
    Private Sub TrySetClipboardText(text As String)
        Dim maxRetries As Integer = 10
        Dim delay As Integer = 100 ' délai en millisecondes

        Dim thread As New Thread(
Sub()
    Dim success As Boolean = False
    Dim attempts As Integer = 0

    While Not success AndAlso attempts < maxRetries
        Try
            Clipboard.SetDataObject(text)
            success = True
        Catch ex As Exception
            attempts += 1
            Thread.Sleep(delay) ' Attendre avant de réessayer
        End Try
    End While

    If Not success Then
        Dim unused = Forms.MessageBox.Show("Impossible de copier le texte dans le presse-papiers après plusieurs tentatives.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
End Sub
)

        thread.SetApartmentState(ApartmentState.STA)
        thread.Start()
        thread.Join() ' Attendre que le thread termine

    End Sub

    Private Sub TrySetClipboardDataObject(data As String)

        Dim thread As New Thread(Sub() SetClipboardDataObject(data))
        thread.SetApartmentState(ApartmentState.STA)
        thread.Start()
        thread.Join()

    End Sub

    Private Sub SetClipboardDataObject(data As String)

        Dim retryCount As Integer = 5
        Dim success As Boolean = False
        Dim exception As Exception = Nothing

        For i As Integer = 1 To retryCount
            Try
                Clipboard.SetDataObject(data)
                success = True
                Exit For
            Catch ex As COMException
                exception = ex
                Thread.Sleep(100)
            End Try
        Next

        If Not success Then
            Throw New Exception("Échec de la définition des données du presse-papiers après plusieurs tentatives.", exception)
        End If

    End Sub

    ' Événement Couper
    Private Sub CouperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CouperToolStripMenuItem.Click

        Dim ctl As Forms.Control = ActiveControl
        If TypeOf ctl Is TextBoxBase Then
            Dim textBox As TextBoxBase = DirectCast(ctl, TextBoxBase)
            If textBox.SelectionLength > 0 Then
                TrySetClipboardText(textBox.SelectedText)
                textBox.SelectedText = ""
            End If
        End If

    End Sub

    ' Méthode pour essayer de définir le texte dans le presse-papiers
    ' Événement Coller
    Private Sub CollerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CollerToolStripMenuItem.Click

        Dim ctl As Forms.Control = ActiveControl

        If TypeOf ctl Is TextBoxBase Then
            Dim textBox As TextBoxBase = DirectCast(ctl, TextBoxBase)
            textBox.Paste()
        ElseIf TypeOf ctl Is Forms.RichTextBox Then
            Dim richTextBox As Forms.RichTextBox = DirectCast(ctl, Forms.RichTextBox)
            richTextBox.Paste()
        End If

    End Sub

    Private Sub AnnulerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnulerToolStripMenuItem.Click

        textBoxHistory.Undo()

    End Sub

    Private Sub SélectionnerToutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SélectionnerToutToolStripMenuItem.Click
        ' Événement Sélectionner Tout

        Dim ctl As Forms.Control = ActiveControl
        If TypeOf ctl Is TextBoxBase Then
            Dim textBox As TextBoxBase = DirectCast(ctl, TextBoxBase)
            textBox.SelectAll()
        ElseIf TypeOf ctl Is Forms.RichTextBox Then
            Dim richTextBox As Forms.RichTextBox = DirectCast(ctl, Forms.RichTextBox)
            richTextBox.SelectAll()
        End If

    End Sub

    Private Sub SelectAllTreeNodes(nodes As TreeNodeCollection)

        For Each node As TreeNode In nodes
            node.BackColor = System.Drawing.SystemColors.Highlight
            node.ForeColor = System.Drawing.SystemColors.HighlightText
            If node.Nodes.Count > 0 Then
                SelectAllTreeNodes(node.Nodes)
            End If
        Next

    End Sub

    Private Sub SelectAllNodes(nodes As TreeNodeCollection)

        For Each node As TreeNode In nodes
            node.BackColor = System.Drawing.SystemColors.Highlight
            node.ForeColor = System.Drawing.SystemColors.HighlightText
            If node.Nodes.Count > 0 Then
                SelectAllNodes(node.Nodes)
            End If
        Next

    End Sub

    Private Sub RétablirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RétablirToolStripMenuItem.Click

        textBoxHistory.Redo()

    End Sub

    Public Sub CreerundocumentjsonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreerundocumentjsonToolStripMenuItem.Click

        If String.IsNullOrEmpty(TextBox1.Text) Then
            Dim unused1 = Forms.MessageBox.Show("Vous devez sélectionner une fiche avant de pouvoir créer ou générer un document au format JSON (.json) !")
            Exit Sub
        Else
            Try
                ' Ajoutez des messages pour vérifier les valeurs des TextBox et RichTextBox
                Dim unused2 = Forms.MessageBox.Show("TextBox2: " & TextBox2.Text)
                Dim unused3 = Forms.MessageBox.Show("TextBox1: " & TextBox1.Text)
                Dim unused4 = Forms.MessageBox.Show("TextBox4: " & TextBox4.Text)
                Dim unused5 = Forms.MessageBox.Show("TextBox15: " & TextBox15.Text)
                Dim unused6 = Forms.MessageBox.Show("TextBox5: " & TextBox5.Text)
                Dim unused7 = Forms.MessageBox.Show("TextBox7: " & TextBox7.Text)
                Dim unused8 = Forms.MessageBox.Show("TextBox9: " & TextBox9.Text)
                Dim unused9 = Forms.MessageBox.Show("TextBox13: " & TextBox13.Text)
                Dim unused10 = Forms.MessageBox.Show("TextBox18: " & TextBox18.Text)
                Dim unused11 = Forms.MessageBox.Show("TextBox23: " & TextBox23.Text)
                Dim unused12 = Forms.MessageBox.Show("TextBox24: " & TextBox24.Text)
                Dim unused13 = Forms.MessageBox.Show("TextBox25: " & TextBox25.Text)
                Dim unused14 = Forms.MessageBox.Show("TextBox26: " & TextBox26.Text)
                Dim unused15 = Forms.MessageBox.Show("TextBox28: " & TextBox28.Text)
                Dim unused16 = Forms.MessageBox.Show("TextBox29: " & TextBox29.Text)
                Dim unused17 = Forms.MessageBox.Show("TextBox33: " & TextBox33.Text)
                Dim unused18 = Forms.MessageBox.Show("TextBox31: " & TextBox31.Text)
                Dim unused19 = Forms.MessageBox.Show("RichTextBox1: " & RichTextBox1.Text)

                Dim account As New Fich With {
    .Titre = TextBox2.Text,
    .Nom = TextBox1.Text,
    .Charge = TextBox4.Text,
    .Institut = TextBox15.Text,
    .Celebration = TextBox5.Text,
    .Naissance = TextBox7.Text,
    .Deces = TextBox9.Text,
    .Autresfetes = TextBox13.Text,
    .Autresnoms = TextBox18.Text,
    .Venerable = TextBox23.Text,
    .Beatification = TextBox24.Text,
    .Canonisation = TextBox25.Text,
    .TitrePrincipal = TextBox26.Text,
    .Patron = TextBox28.Text,
    .Lien = TextBox29.Text,
    .Image = TextBox33.Text,
    .Biographie = TextBox31.Text,
    .Origine = RichTextBox1.Text
}

                Dim jsonString = JsonConvert.SerializeObject(account, CType(System.Xml.Formatting.Indented, Newtonsoft.Json.Formatting))
                Dim filePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources", TextBox1.Text & ".json")

                Dim unused = Forms.MessageBox.Show("Le fichier sera enregistré à : " & filePath)

                Using filejson As StreamWriter = File.CreateText(filePath)
                    Dim serializer As New JsonSerializer()
                    serializer.Serialize(filejson, account)
                End Using

                Dim unused20 = Forms.MessageBox.Show("Le document JSON a été créé avec succès!")
            Catch ex As IOException
                Dim unused21 = Forms.MessageBox.Show("Erreur de lecture/écriture: " & ex.Message)
            Catch ex As JsonException
                Dim unused22 = Forms.MessageBox.Show("Erreur de format JSON: " & ex.Message)
            Catch ex As Exception
                Dim unused23 = Forms.MessageBox.Show("Erreur : " & ex.Message)
                Dim unused24 = Forms.MessageBox.Show("Stack Trace : " & vbCrLf & ex.StackTrace)
            Finally
                Dim unused25 = Forms.MessageBox.Show("L'exécution du processus est terminée.")
            End Try
        End If

    End Sub

    Public Sub LireundocumentjsonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LireundocumentjsonToolStripMenuItem.Click

        Dim filePath As String = String.Empty

        Dim OpenFileDialog1 As New Forms.OpenFileDialog With {
.InitialDirectory = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources"),
.Filter = "Documents Json (*.json)|*.json|Tous les fichiers (*.*)|*.*",
.FilterIndex = 1,
.RestoreDirectory = True,
.Multiselect = False,
.CheckFileExists = True
}

        If CType(OpenFileDialog1.ShowDialog(), Global.System.Windows.Forms.DialogResult) = Global.System.Windows.Forms.DialogResult.OK Then
            Try
                If Not String.IsNullOrWhiteSpace(OpenFileDialog1.FileName) Then
                    Dim unused1 = Forms.MessageBox.Show("Chemin du fichier sélectionné : " & OpenFileDialog1.FileName)
                    NouveauToolStripButton.PerformClick() ' Crée une nouvelle fiche
                    filePath = OpenFileDialog1.FileName
                    Dim rawjson As String = File.ReadAllText(filePath)

                    ' Vérifiez que le JSON est correctement lu
                    If String.IsNullOrWhiteSpace(rawjson) Then
                        Dim unused2 = Forms.MessageBox.Show("Le fichier JSON est vide.")
                        Exit Sub
                    End If

                    Dim unused3 = Forms.MessageBox.Show("Contenu JSON brut : " & rawjson)

                    Dim account As New Fich
                    JsonConvert.PopulateObject(rawjson, account)

                    ' Utilisation de la syntaxe complètement qualifiée pour Formatting
                    Dim unused4 = Forms.MessageBox.Show("Objet account désérialisé : " & JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented))

                    If account Is Nothing Then
                        Dim unused5 = Forms.MessageBox.Show("Le fichier JSON est vide ou ne correspond pas aux attentes")
                        Exit Sub
                    End If

                    ' Assignation des valeurs aux contrôles de l'interface utilisateur
                    TextBox2.Text = If(account.Titre, String.Empty)
                    TextBox1.Text = If(account.Nom, String.Empty)
                    TextBox4.Text = If(account.Charge, String.Empty)
                    TextBox15.Text = If(account.Institut, String.Empty)
                    TextBox5.Text = If(account.Celebration, String.Empty)
                    TextBox7.Text = If(account.Naissance, String.Empty)
                    TextBox9.Text = If(account.Deces, String.Empty)
                    TextBox13.Text = If(account.Autresfetes, String.Empty)
                    TextBox18.Text = If(account.Autresnoms, String.Empty)
                    TextBox23.Text = If(account.Venerable, String.Empty)
                    TextBox24.Text = If(account.Beatification, String.Empty)
                    TextBox25.Text = If(account.Canonisation, String.Empty)
                    TextBox26.Text = If(account.TitrePrincipal, String.Empty)
                    TextBox28.Text = If(account.Patron, String.Empty)
                    TextBox29.Text = If(account.Lien, String.Empty)
                    TextBox33.Text = If(account.Image, String.Empty)
                    TextBox31.Text = If(account.Biographie, String.Empty)
                    RichTextBox1.Text = If(account.Origine, String.Empty)

                    Dim unused6 = Forms.MessageBox.Show("Toutes les valeurs ont été assignées correctement aux contrôles.")
                End If
            Catch ex As IOException
                Dim unused7 = Forms.MessageBox.Show("Erreur de lecture/écriture: " & ex.Message)
            Catch ex As JsonException
                Dim unused8 = Forms.MessageBox.Show("Erreur de format JSON: " & ex.Message)
            Catch ex As Exception
                Dim unused9 = Forms.MessageBox.Show("Erreur : " & ex.Message)
            Finally
                Dim unused = Forms.MessageBox.Show("L'exécution du processus est terminée. Vous êtes invité à enregistrer les modifications apportées au nouveau document.")
            End Try
        End If

    End Sub

    ' Déclaration de l'élément de menu dans le formulaire
    Private WithEvents SupprimerlesfichiersJSONToolStripMenuItem As ToolStripMenuItem

    ' Initialisation de l'élément de menu
    ' Surcharge de constructeur avec un paramètre
    Public Sub New(param As String)

        InitializeComponent()
        SupprimerlesfichiersJSONToolStripMenuItem = New ToolStripMenuItem("Supprimer les fichiers JSON")
        'AddHandler SupprimerlesfichiersJSONToolStripMenuItem.Click, AddressOf SupprimerlesfichiersJSONToolStripMenuItem_Click

        ' Ajouter ce menu au MenuStrip existant
        Dim unused = MenuStrip1.Items.Add(SupprimerlesfichiersJSONToolStripMenuItem)

    End Sub

    ' Ajoute cette vérification pour éviter les duplications
    Private Sub SuppressionDesMessages(sender As Object, e As EventArgs) Handles SupprimerlesfichiersJSONToolStripMenuItem.DropDownOpening

        RemoveHandler SupprimerlesfichiersJSONToolStripMenuItem.Click, AddressOf SupprimerlesfichiersJSONToolStripMenuItem_Click
        ' AddHandler SupprimerlesfichiersJSONToolStripMenuItem.Click, AddressOf SupprimerlesfichiersJSONToolStripMenuItem_Click

    End Sub

    Private Sub SupprimerlesfichiersJSONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerlesfichiersJSONToolStripMenuItem.Click

        Dim directoryName As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Resources"

        ' Suppression des fichiers JSON
        For Each deleteFile In Directory.GetFiles(directoryName, "*.json", System.IO.SearchOption.TopDirectoryOnly)
            File.Delete(deleteFile)
        Next
        Dim unused = MsgBox("Tous les fichiers JSON ont été supprimés.")

        ' Compte des répertoires contenant des fichiers JSON
        Dim count As Integer = Directory.EnumerateFiles(directoryName, "*.json", System.IO.SearchOption.AllDirectories).Count()
        Dim unused1 = MsgBox("Nombre de fichiers JSON restants : " & count)

    End Sub

    Public Function ListeDossiers(Chemin As String) As Integer

        Return Directory.EnumerateFiles(Chemin, "*.json", System.IO.SearchOption.AllDirectories).Count()

    End Function

    Private Sub PictureBox1_LoadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles PictureBox1.LoadCompleted

        If e.Error IsNot Nothing Or PictureBox1.Image.Equals(PictureBox1.ErrorImage) Then
            Dim dialogResult1 = Forms.MessageBox.Show("Une erreur s'est produite lors du chargement de l'image.")
        End If

    End Sub

    Public Sub ToolStripStatusLabel6_MouseMove(sender As Object, e As MouseEventArgs) Handles ToolStripStatusLabel6.MouseMove

        Dim numbers As Long

        Dim di As New DirectoryInfo(My.Application.Info.DirectoryPath & "\Librairies\")
        Dim fiArr As FileInfo() = di.GetFiles()
        Dim fri As FileInfo
        For Each fri In fiArr
            numbers = CLng(numbers + (fri.Length / 3188))
        Next fri
        ToolStripStatusLabel6.Text = "Affichage du nombre total d'enregistrements : " & numbers

    End Sub

    Private Sub ComboBox2_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox2.DrawItem

        If e.Index < 0 Then
            Return
        End If
        Dim text As String = ComboBox2.GetItemText(ComboBox2.Items(e.Index))
        e.DrawBackground()

        Using br As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(text, e.Font, br, e.Bounds)
        End Using

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            ToolTip1.Show(text, ComboBox2, e.Bounds.Right, e.Bounds.Bottom)
        End If

        e.DrawFocusRectangle()

    End Sub

    Private Sub ComboBox2_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox2.DropDownClosed

        ToolTip1.Hide(ComboBox2)

    End Sub

    ' Cet événement se déclenche chaque fois que le texte de TextBox1 change
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        bIsModified = True
        Try
            'Dim unused As String = System.Windows.Forms.Clipboard.GetText()
            Dim unused1 = Forms.Clipboard.GetText()
        Catch ex As Exception
            Dim unused = Forms.MessageBox.Show("Erreur d'accès au presse-papiers : " & ex.Message)
        End Try

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

        bIsModified = True

    End Sub

    Public Sub ConvertWordToPDF(
filename As Object,
directoryPath As String)

        Dim wordApplication As New Word.Application
        Dim wordDocument As Word.Document = Nothing
        Dim outputFilename As String

        Try

            Cursor = Cursors.WaitCursor

            wordDocument = wordApplication.Documents.Open(filename)
            outputFilename = System.IO.Path.ChangeExtension(CStr(filename), "pdf")

            wordDocument.ExportAsFixedFormat(outputFilename, WdExportFormat.wdExportFormatPDF, True, WdExportOptimizeFor.wdExportOptimizeForOnScreen, WdExportRange.wdExportAllDocument, 0, 0, WdExportItem.wdExportDocumentContent, True, True, WdExportCreateBookmarks.wdExportCreateNoBookmarks, True, True, False)

            Cursor = Cursors.Default

        Catch ex As Exception
            ' Afficher le message de l'exception.
            Dim dialogResult2 = Forms.MessageBox.Show(ex.Message)

            ' Affiche la trace de la pile, qui est une liste des méthodes en cours d'exécution.
            Dim dialogResult1 = Forms.MessageBox.Show("Stack Trace : " & vbCrLf & ex.StackTrace)
        Finally
            If wordDocument IsNot Nothing Then
                wordDocument.Close(False)
                wordDocument = Nothing
            End If

            If wordApplication IsNot Nothing Then
                wordApplication.Quit()
                wordApplication = Nothing
            End If
        End Try

    End Sub

    Private Sub CréerundocumentauformatPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréerundocumentauformatPDFToolStripMenuItem.Click

        Dim docxPath As String = $"{My.Application.Info.DirectoryPath}\Téléchargements\{TextBox2.Text} {TextBox1.Text}.docx"
        Dim pdfDirectory As String = $"{My.Application.Info.DirectoryPath}\Téléchargements" ' Par exemple, le même dossier que le .docx

        ' Vérifiez l'existence du fichier .docx
        If Computer.FileSystem.FileExists(docxPath) Then
            Dim unused2 = Forms.MessageBox.Show("Le fichier document existe.", "Prenommer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim unused1 = Forms.MessageBox.Show("Le fichier document n'existe pas. En choisissant de créer un fichier .docx, les données du document pourront alors être exportées vers le nouveau fichier.", "Prenommer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Convertir le document Word en PDF
        ConvertWordToPDF(docxPath, pdfDirectory)

        Dim unused = MessageBox.Show("L'exécution du processus est terminée.", "Prenommer")

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs) Handles TextBox24.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs) Handles TextBox25.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox26_TextChanged(sender As Object, e As EventArgs) Handles TextBox26.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox28_TextChanged(sender As Object, e As EventArgs) Handles TextBox28.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox29_TextChanged(sender As Object, e As EventArgs) Handles TextBox29.TextChanged

        bIsModified = True

    End Sub

    Private Sub TextBox33_TextChanged(sender As Object, e As EventArgs) Handles TextBox33.TextChanged

        bIsModified = True

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

        bIsModified = True

    End Sub

    Public p As New Process
    Private app As Object
    Private htmlContent As String

    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked

        If CheckForInternetConnection() Then

            Try
                ' Utilise le navigateur par défaut
                Dim unused2 = Process.Start(e.LinkText)
            Catch ex As Exception
                Dim unused = Forms.MessageBox.Show("Impossible d'ouvrir le lien : " & ex.Message)
            End Try
        Else
            Dim unused1 = Forms.MessageBox.Show("Vous n'êtes pas connecté à Internet.")
        End If

    End Sub

    Public Sub StopWebProcess()

        p.Kill()

    End Sub

    Public Shared Async Function CheckForInternetConnectionAsync() As Task(Of Boolean)

        Try
            Using client As New HttpClient()
                Dim response = Await client.GetAsync("https://www.google.com")
                Return response.IsSuccessStatusCode
            End Using
        Catch
            Return False
        End Try

    End Function

    Public Async Sub VérifierConnexionInternet()

        Dim estConnecté As Boolean = Await CheckForInternetConnectionAsync()

        If estConnecté Then
            Dim unused = Forms.MessageBox.Show("Connexion Internet disponible.")
        Else
            Dim unused1 = Forms.MessageBox.Show("Pas de connexion Internet.")
        End If

    End Sub

    Public Function TestInternetConnection() As Boolean

        Try
            Using ping As New NetworkInformation.Ping()
                Dim pingReply = ping.Send("google.com", 3000) ' Délai d'attente de 3000 ms (3 secondes)
                If pingReply.Status = NetworkInformation.IPStatus.Success Then
                    Return True
                End If
            End Using
        Catch ex As Exception
            'Vous pouvez éventuellement ajouter une gestion de l'exception ici, par exemple.
            Dim unused = Forms.MessageBox.Show("Erreur : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False

    End Function

    Public Shared Function CheckForInternetConnection() As Boolean

        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("https://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try

    End Function

    Private Sub TextBox31_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox31.KeyUp

        If (e.KeyValue = 13 Or e.KeyValue = 10) And TextBox31.ReadOnly Then

            Exit Sub

        ElseIf (e.KeyValue = 13 Or e.KeyValue = 10) And Not TextBox31.ReadOnly Then

            Dim dialogResult1 = Forms.MessageBox.Show("Attention : Saut de ligne ou retour chariot décelé dans cette zone de texte. Utilisez la souris pour répondre au bouton affiché dans la boîte de message.", "Correction automatique de la mise en forme", MessageBoxButtons.OK)
            TextBox31.Text = New [String](TextBox31.Text.Where(Function(ch, i) i < TextBox31.Text.Length - 2).ToArray())
            TextBox31.SelectionStart = TextBox31.Text.Length

        End If

    End Sub

    Private Sub RichTextBox1_MouseHover(sender As Object, e As EventArgs) Handles RichTextBox1.MouseHover

        Dim s As String = Trim(RichTextBox1.Text)

        If Not String.IsNullOrEmpty(s) And RichTextBox1.ReadOnly Then
            Dim _uri As String = s
            If Not Uri.IsWellFormedUriString(_uri, UriKind.RelativeOrAbsolute) Then
                Dim dialogResult1 = Forms.MessageBox.Show("L'URL n'est pas considérée comme valide.", "Prénommer", MessageBoxButtons.OK)
                Dim v = RichTextBox1.Focus()
                RichTextBox1.Select(0, RichTextBox1.Text.Length)
            End If
        End If

    End Sub

    Private Delegate Function GetFormTitleDelegate(f As Form) As String

    Private Function GetFormTitle(f As Form) As String

        ' Vérifiez si le formulaire est accessible à partir du thread actuel.
        If Not f.InvokeRequired Then
            ' Accéder directement au formulaire.
            Return f.Text
        Else
            ' Marshal to the thread that owns the form.
            Dim del As GetFormTitleDelegate = AddressOf GetFormTitle
            Dim param As Object() = {f}
            Dim result As IAsyncResult = f.BeginInvoke(del, param)
            ' Donnez au thread une chance de traiter la fonction.
            Thread.Sleep(10)
            ' Vérifier le résultat.
            If result.IsCompleted Then
                ' Récupère la valeur de retour de la fonction.
                Return "Different thread : " & f.EndInvoke(result).ToString
            Else
                Return "Unresponsive thread"
            End If
        End If

    End Function

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Try
            Dim unused = Process.Start("https://www.wikipedia.org")

        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show("Impossible de charger la page Web." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PictureBox4_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox4.MouseEnter

        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.Cursor = Cursors.Hand

    End Sub

    Private Sub PictureBox4_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox4.MouseLeave

        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.Cursor = Cursors.Default

    End Sub

    Private Sub UpdateTextPosition()

        Dim g As Graphics = CreateGraphics()
        Dim startingPoint As Double = (Width / 2) - (g.MeasureString(Text.Trim(), Font).Width / 2)
        Dim widthOfASpace As Double = g.MeasureString(" ", Font).Width
        Dim tmp As String = " "
        Dim tmpWidth As Double = 0

        While (tmpWidth + widthOfASpace) < startingPoint
            tmp += " "
            tmpWidth += widthOfASpace
        End While

        Text = tmp + Text.Trim()

    End Sub

    Public Function ReadLineWithNumberFrom(filePath As String, lineNumber As Integer) As String

        Using file As New StreamReader(filePath)
            ' Passer toutes les lignes précédentes.
            For i As Integer = 1 To lineNumber - 1
                If file.ReadLine() Is Nothing Then
                    Throw New ArgumentOutOfRangeException("lineNumber")
                End If
            Next
            ' Essayez de lire la ligne qui vous intéresse.
            Dim line As String = file.ReadLine()
            If line Is Nothing Then
                Throw New ArgumentOutOfRangeException("lineNumber")
            End If
            Return line
        End Using

    End Function

    Private Sub TreeView1_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterExpand

        Dim Url As String = HttpUtility.UrlDecode(str:=RichTextBox1.Text)

        RichTextBox1.ReadOnly = False
        Dim unused As String = RichTextBox1.Text
        RichTextBox1.ReadOnly = True

    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover

        If PictureBox1.Image IsNot Nothing Then
            ' Créer une copie explicite de l'image comme Bitmap
            Using img As New Bitmap(PictureBox1.Image)
                Using copy As New Bitmap(img.Width, img.Height)
                    Using ia As New ImageAttributes()

                        ' Définir la matrice pour passer l'image en niveaux de gris
                        Dim cm As New ColorMatrix(New Single()() {
            New Single() {0.3, 0.3, 0.3, 0, 0},
            New Single() {0.59, 0.59, 0.59, 0, 0},
            New Single() {0.11, 0.11, 0.11, 0, 0},
            New Single() {0, 0, 0, 1, 0},
            New Single() {0, 0, 0, 0, 1}
        })

                        ia.SetColorMatrix(cm)

                        ' Utiliser Graphics pour dessiner l'image
                        Using g As Graphics = Graphics.FromImage(copy)
                            g.DrawImage(
                img,
                New System.Drawing.Rectangle(0, 0, img.Width, img.Height),
                0, 0, img.Width, img.Height,
                GraphicsUnit.Pixel, ia
            )
                        End Using

                        ' Mettre à jour l'image du PictureBox
                        PictureBox1.Image = New Bitmap(copy)
                    End Using
                End Using
            End Using
        Else
            ' Gérer le cas où aucune image n'est présente
            'MsgBox("Aucune image n'est chargée dans le PictureBox.")
            Return
        End If

    End Sub

    Private Sub ContacteznousToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim oForm As Contactform
        oForm = New Contactform()
        oForm.Show()

    End Sub

    'Fonction pour nettoyer le nom du fichier en supprimant les caractères non valides
    Private Function NettoyerNomFichier(nom As String) As String

        Dim invalidCharsPattern As String = Regex.Escape(New String(System.IO.Path.GetInvalidFileNameChars()))
        Dim regexInstance As New Regex("[" & invalidCharsPattern & "]")  ' Correction du nom de variable

        Return regexInstance.Replace(nom, "_")  ' Correction de l'appel à Replace

    End Function

    Public Sub GenererunfichierdocxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenererunfichierdocxToolStripMenuItem.Click

        Dim oWord As New Word.Application
        Dim oDoc As Word.Document
        Dim oPara1 As Word.Paragraph, oPara2 As Word.Paragraph, oPara7 As Word.Paragraph, oPara8 As Word.Paragraph
        Dim oPara3 As Word.Paragraph, oPara4 As Word.Paragraph, oPara9 As Word.Paragraph, oPara10 As Word.Paragraph
        Dim oPara5 As Word.Paragraph, oPara6 As Word.Paragraph, oPara11 As Word.Paragraph, oPara12 As Word.Paragraph
        Dim oPara13 As Word.Paragraph, oPara14 As Word.Paragraph, oPara15 As Word.Paragraph, oPara16 As Word.Paragraph
        Dim oPara17 As Word.Paragraph
        Dim oRng As Range
        Dim fileName As String

        'Try

        ' Démarrez Word et ouvrez le modèle de document
        oWord = CType(CreateObject("Word.Application"), Word.Application)
        oDoc = oWord.Documents.Add

        oWord.Application.ScreenUpdating = False ' Désactiver l'affichage pour optimiser la vitesse

        ' Vérifier si le document est bien initialisé
        If oDoc Is Nothing Then
            oDoc = oWord.Documents.Add()
        End If

        ' Initialiser le paragraphe principal avec le nom encodé
        Dim displayText As String = TextBox2.Text & " " & TextBox1.Text
        Dim unused6 = Forms.MessageBox.Show("Contenu de l'en-tête avant création du fichier : " & displayText, "Vérification", MessageBoxButtons.OK)

        ' Insérez un paragraphe au début du document
        oPara1 = oDoc.Content.Paragraphs.Add
        ' Configurer la police et le texte du paragraphe
        oPara1.Range.Font.Name = "Aptos Corps"
        oPara1.Range.Font.Size = 18
        oPara1.Range.Font.Bold = CInt(False)
        oPara1.Range.Text = TextBox2.Text & " " & TextBox1.Text & ControlChars.Cr
        oPara1.Format.SpaceAfter = 0    '24 pt spacing after paragraph.
        oPara1.Range.InsertParagraphAfter()

        ' Définir le chemin de téléchargement et nettoyer le nom pour le fichier
        fileName = NettoyerNomFichier(displayText) & ".docx"
        Dim filePath As String = System.IO.Path.Combine("C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements", TextBox2.Text & " " & TextBox1.Text)

        ' Si le paragraphe est bien créé, configurez ses propriétés
        If oPara1 IsNot Nothing Then
            ' Insérer un saut de paragraphe et ajuster l'espacement
            oPara1.Range.InsertParagraphAfter()
            oPara1.Format.SpaceAfter = 12
        Else
            Dim unused4 = Forms.MessageBox.Show("Le paragraphe n'a pas pu être créé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Thread.Sleep(1000) ' Pause pendant 1 seconde
        oWord.Application.ScreenUpdating = True ' Réactiver la mise à jour de l'écran

        ' Insérez un paragraphe à la fin du document
        ' ** \endofdoc est un signet prédéfini
        oPara2 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara2.Range.Text = TextBox4.Text & ControlChars.Cr
        oPara1.Range.Font.Bold = CInt(False)
        oPara2.Format.SpaceBefore = 0
        oPara2.Format.SpaceAfter = 0
        oPara2.Range.InsertParagraphAfter()

        ' Insérer un autre paragraphe.
        oPara3 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara3.Range.Text = TextBox15.Text & ControlChars.Cr
        oPara3.Range.Font.Bold = CInt(False)
        oPara3.Format.SpaceBefore = 0
        oPara3.Format.SpaceAfter = 0
        oPara3.Range.InsertParagraphAfter()

        ' Insérer un autre paragraphe.
        oPara4 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara4.Range.Text = TextBox5.Text & ControlChars.Cr
        oPara4.Range.Font.Bold = CInt(False)
        oPara4.Format.SpaceBefore = 0
        oPara4.Format.SpaceAfter = 0
        oPara4.Range.InsertParagraphAfter()

        ' Ajouter du texte après le tableau.
        oPara5 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara5.Range.Text = TextBox7.Text & ControlChars.Cr
        oPara5.Format.SpaceBefore = 0
        oPara5.Format.SpaceAfter = 0
        oPara5.Range.InsertParagraphAfter()

        ' Insérer un autre paragraphe.
        oPara6 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara6.Range.Text = TextBox9.Text & ControlChars.Cr
        oPara6.Range.Font.Bold = CInt(False)
        oPara6.Format.SpaceBefore = 0
        oPara6.Format.SpaceAfter = 0
        oPara6.Range.InsertParagraphAfter()

        ' Insérer un autre paragraphe.
        oPara7 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara7.Range.Text = TextBox13.Text & ControlChars.Cr
        oPara7.Range.Font.Bold = CInt(False)
        oPara7.Format.SpaceBefore = 0
        oPara7.Format.SpaceAfter = 0
        oPara7.Range.InsertParagraphAfter()

        oPara8 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara8.Range.Text = TextBox18.Text & ControlChars.Cr
        oPara8.Range.Font.Bold = CInt(False)
        oPara8.Format.SpaceBefore = 0
        oPara8.Format.SpaceAfter = 0
        oPara8.Range.InsertParagraphAfter()

        oPara9 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara9.Range.Text = TextBox23.Text & ControlChars.Cr
        oPara9.Range.Font.Bold = CInt(False)
        oPara9.Format.SpaceBefore = 0
        oPara9.Format.SpaceAfter = 0
        oPara9.Range.InsertParagraphAfter()

        oPara10 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara10.Range.Text = TextBox24.Text & ControlChars.Cr
        oPara10.Range.Font.Bold = CInt(False)
        oPara10.Format.SpaceBefore = 0
        oPara10.Format.SpaceAfter = 0
        oPara10.Range.InsertParagraphAfter()

        oPara11 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara11.Range.Text = TextBox25.Text & ControlChars.Cr
        oPara11.Range.Font.Bold = CInt(False)
        oPara11.Format.SpaceBefore = 0
        oPara11.Format.SpaceAfter = 0
        oPara11.Range.InsertParagraphAfter()

        oPara12 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara12.Range.Text = TextBox26.Text & ControlChars.Cr
        oPara12.Range.Font.Bold = CInt(False)
        oPara12.Format.SpaceBefore = 0
        oPara12.Format.SpaceAfter = 0
        oPara12.Range.InsertParagraphAfter()

        oPara13 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara13.Range.Text = TextBox28.Text & ControlChars.Cr
        oPara13.Range.Font.Bold = CInt(False)
        oPara13.Format.SpaceBefore = 0
        oPara13.Format.SpaceAfter = 0
        oPara13.Range.InsertParagraphAfter()

        oPara14 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara14.Range.Text = TextBox29.Text & ControlChars.Cr
        oPara14.Range.Font.Bold = CInt(False)
        oPara14.Format.SpaceBefore = 0
        oPara14.Format.SpaceAfter = 0
        oPara14.Range.InsertParagraphAfter()

        oPara15 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara15.Range.Text = TextBox33.Text & ControlChars.Cr
        oPara15.Range.Font.Bold = CInt(False)
        oPara15.Format.SpaceBefore = 0
        oPara15.Format.SpaceAfter = 0
        oPara15.Range.InsertParagraphAfter()

        oPara16 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara16.Range.Text = TextBox31.Text & ControlChars.Cr
        oPara16.Range.Font.Bold = CInt(False)
        oPara16.Format.SpaceBefore = 0
        oPara16.Format.SpaceAfter = 0
        oPara16.Range.InsertParagraphAfter()

        oPara17 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
        oPara17.Range.Text = RichTextBox1.Text & ControlChars.Cr

        With oWord.ActiveDocument.Styles(-1)
            .ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify
        End With

        oPara17.Range.Font.Bold = CInt(False)
        oPara17.Format.SpaceBefore = 0
        oPara17.Format.SpaceAfter = 0
        oPara17.Range.InsertParagraphAfter()
        ' Continuez à insérer du texte. Lorsque vous arrivez à 7 pouces du haut du document, insérez un saut de page définitif.

        ' Assurez-vous que les champs TextBox1 et TextBox33 ne sont pas en lecture seule
        TextBox1.ReadOnly = False
        TextBox33.ReadOnly = False

        ' Définir le chemin de l'image en fonction des valeurs des TextBox
        Dim imagePath As String = $"{My.Application.Info.DirectoryPath}\Images\{TextBox1.Text.Substring(0, 1)}\{TextBox33.Text}"

        ' Vérifier si le champ TextBox33 contient un nom d'image et si le fichier existe
        If Not String.IsNullOrEmpty(TextBox33.Text) AndAlso File.Exists(imagePath) Then
            ' Si l'image existe, l'ajouter au document Word
            Dim unused = oDoc.InlineShapes.AddPicture(FileName:=imagePath, LinkToFile:=False, SaveWithDocument:=True, Range:=oDoc.Bookmarks.Item("\endofdoc").Range)
        Else
            ' Si l'image est introuvable, afficher un message d'avertissement sans bloquer l'application
            Dim unused5 = Forms.MessageBox.Show("L'image spécifiée est introuvable. Un fichier par défaut sera utilisé.", "Image manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' Remettre les champs TextBox1 et TextBox33 en lecture seule
        TextBox1.ReadOnly = True
        TextBox33.ReadOnly = True

        ' Ajouter du texte après l'image
        oRng = oDoc.Bookmarks.Item("\endofdoc").Range
        oRng.InsertParagraphAfter()
        oRng.InsertParagraphAfter()
        oRng.InsertAfter("Prénommer - " & Date.Now)

        If Not String.IsNullOrEmpty(TextBox33.Text) Or Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Images\" & TextBox1.Text.Substring(0, 1) & "\" & TextBox33.Text) Then
            If TextBox33.Text.Substring(0, 1) <> "#" Then
                Dim Téléchargements As String = My.Application.Info.DirectoryPath & "\" & "Téléchargements\" & TextBox1.Text & ".docx"
                fileName = My.Application.Info.DirectoryPath & "\Images\" & TextBox1.Text.Substring(0, 1) & "\" & TextBox33.Text

                ' Déclarez filePath comme une chaîne de texte avec le chemin complet du fichier
                filePath = System.IO.Path.Combine("C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements", TextBox1.Text & ".docx")

                ' Applique le nettoyage au nom de fichier
                fileName = NettoyerNomFichier(TextBox2.Text & " " & TextBox1.Text & ".docx")
                filePath = System.IO.Path.Combine("C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements", fileName)

                ' Assurez-vous que le fichier Word est bien initialisé pour sauvegarder

                ' Enregistrer le document Word avec le chemin défini
                oDoc.SaveAs2(FileName:=CStr(filePath), FileFormat:=WdSaveFormat.wdFormatXMLDocument)

                ' Fermer le document et l'application Word
                Dim unused1 = Forms.MessageBox.Show("Conversion terminée !")

            End If
        End If

        'Informer l'utilisateur que le fichier a été créé sans ouvrir Word
        Dim unused8 = Forms.MessageBox.Show("Le fichier a été généré avec succès dans le dossier Téléchargements.", "Génération réussie", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Try
            oDoc.SaveAs2(FileName:=CStr(filePath), FileFormat:=WdSaveFormat.wdFormatXMLDocument)

            ' Votre code pour ouvrir et manipuler le document Word
        Catch ex As COMException
            Dim unused9 = Forms.MessageBox.Show("Erreur lors de l'enregistrement du document : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Libérer les objets COM
            If oDoc IsNot Nothing Then oDoc.Close(False)
            If oWord IsNot Nothing Then
                oWord.Quit()
                Dim unused2 = Marshal.ReleaseComObject(oWord)
                Dim unused3 = Marshal.ReleaseComObject(oDoc)
            End If
        End Try

    End Sub

    Private Sub ODTToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim myStream As Stream = Nothing
        Dim OpenFileDialog1 As New Forms.OpenFileDialog With {
.InitialDirectory = "c:\",
.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
.FilterIndex = 2,
.RestoreDirectory = True
}

        If CType(OpenFileDialog1.ShowDialog(), Global.System.Windows.Forms.DialogResult) = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = OpenFileDialog1.OpenFile()
                If myStream IsNot Nothing Then
                    ' Insérez le code pour lire le flux ici.
                End If
            Catch Ex As Exception
                Dim unused = Forms.MessageBox.Show("Impossible de lire le fichier à partir du disque. Erreur d'origine : " & Ex.Message)
            Finally
                ' Vérifiez ceci à nouveau, car nous devons nous assurer que nous n'avons pas lancé d'exception à l'ouverture.
                myStream?.Close()
            End Try
        End If

    End Sub

    Public Function CheckExistItem(listText As String) As Boolean

        For Each item As ListViewItem In ListView1.Items
            If item.ToString = listText Then
                Return True
                ' S'il existe.
            End If
        Next

        Return False
        ' S'il n'existe pas après avoir parcouru tous les éléments.

    End Function

    Public Sub CréerUnDocumentMarkDownMDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréerUnDocumentMarkDownMDToolStripMenuItem.Click

        Try

            ' Chemin et fichier Markdown
            Dim outputDir As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Documents\"

            Dim fileName As String = $"{Trim(TextBox2.Text)} {Trim(TextBox1.Text)}.md"
            Dim markdownPath As String = System.IO.Path.Combine(outputDir, fileName)

            ' Copier l'image dans le répertoire du fichier Markdown
            Dim ImageFileName As String = TextBox33.Text.Trim()
            Dim imageSourcePath As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Documents", ImageFileName)

            'Dim imageSourcePath As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Téléchargements\prenommer_setup_3.7.0.0.7z"

            Dim imageTargetPath As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(markdownPath), ImageFileName)

            ' Vérifiez si l'image existe avant de continuer
            If Not File.Exists(imageSourcePath) Then
                Dim unused5 = MsgBox("L'image spécifiée n'existe pas. Veuillez placer l'image dans le répertoire 'C:\Users\admin\Documents' et réessayer.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' Copier l'image si elle n'est pas déjà présente
            If Not File.Exists(imageTargetPath) Then
                File.Copy(imageSourcePath, imageTargetPath)
            End If

            ' Vérifier ou créer le dossier
            If Not Directory.Exists(outputDir) Then
                Dim unused6 = Directory.CreateDirectory(outputDir)
            End If

            ' Contenu Markdown
            Dim markdownContent As New StringBuilder()
            Dim unused7 = markdownContent.AppendLine($"# {TextBox2.Text} {TextBox1.Text}")
            Dim unused8 = markdownContent.AppendLine()
            Dim unused9 = markdownContent.AppendLine($"## Informations générales")
            Dim unused10 = markdownContent.AppendLine()
            Dim unused11 = markdownContent.AppendLine($"- **Nom complet** : {TextBox1.Text}")
            Dim unused12 = markdownContent.AppendLine($"- **Titre** : {TextBox2.Text}")
            Dim unused1 = markdownContent.AppendLine($"- **Représentation** : ![Représentation](./{ImageFileName})")
            Dim unused13 = markdownContent.AppendLine($"- **Date** : {Date.Now:dd/MM/yyyy}")

            ' Écrire dans le fichier Markdown
            File.WriteAllText(markdownPath, markdownContent.ToString(), Encoding.UTF8)
            Dim unused = MsgBox($"Fichier Markdown créé avec succès : {markdownPath}")

            ' Conversion en ODT, DOCX et PDF
            Dim outputFormats As String() = {".odt", ".docx", ".pdf"}
            Dim processName As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\AppData\Local\Pandoc\pandoc.exe"

            For Each format In outputFormats
                Dim OutputFile As String = System.IO.Path.ChangeExtension(markdownPath, format)
                ConvertMarkdownToFormat(markdownPath, OutputFile, processName)
                If File.Exists(OutputFile) Then
                    Dim unused3 = MsgBox($"Fichier généré avec succès : {OutputFile}")
                Else
                    Dim unused2 = MsgBox($"Erreur : le fichier {OutputFile} n'a pas été généré.")
                End If
            Next

        Catch ex As Exception
            Dim unused4 = MsgBox($"Erreur : {ex.Message}")
        End Try

    End Sub

    Private Sub ConvertMarkdownToFormat(inputFile As String, OutputFile As String, processName As String)

        Try

            Dim process As New Process()
            Dim startInfo As New ProcessStartInfo With {
                .FileName = processName,
                .Arguments = $"""{inputFile}"" -o ""{OutputFile}""",
                .UseShellExecute = False,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .CreateNoWindow = True
            }
            process.StartInfo = startInfo
            Dim unused2 = process.Start()

            Dim output As String = process.StandardOutput.ReadToEnd()
            Dim [error] As String = process.StandardError.ReadToEnd()
            process.WaitForExit()

            If process.ExitCode <> 0 Then
                Dim unused = MsgBox($"Erreur lors de la conversion : {[error]}")
            End If
        Catch ex As Exception
            Dim unused1 = MsgBox($"Erreur : {ex.Message}")
        End Try

    End Sub

    Private Sub AppendIfNotEmpty(builder As StringBuilder, label As String, value As String)

        If Not String.IsNullOrWhiteSpace(value) Then

            Dim unused = builder.AppendLine($"{label} {value}")

        End If

    End Sub

    ' Fonction pour générer le contenu HTML
    Private Function GetImageMarkdown(imageName As String) As String

        If String.IsNullOrWhiteSpace(imageName) Then
            Return "![Image non disponible](#)"
        End If

        ' Nettoyer le nom du fichier
        Dim ImageFileName As String = imageName.Trim().Replace(" ", "_") & ".jpg"
        Dim imagePath As String = $"./{ImageFileName}" ' Utilisation d'un chemin relatif

        ' Vérifier si l'image existe dans le répertoire Documents
        Dim absolutePath As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Documents", ImageFileName)

        If Not File.Exists(absolutePath) Then
            Return "![Image non disponible](#)"
        End If

        ' Retourner le Markdown pour l'image
        Return $"![Représentation]({imagePath})"

    End Function

    Public Function GenerateHTML() As String

        Dim sb As New StringBuilder()

        ' Ajoutez le code HTML ici
        Dim unused = sb.AppendLine("<!DOCTYPE html>")
        Dim unused1 = sb.AppendLine("<html>")
        Dim unused2 = sb.AppendLine("<head>")
        Dim unused3 = sb.AppendLine("<style>")
        Dim unused4 = sb.AppendLine(".tooltip { position: relative; display: inline-block; }")
        Dim unused5 = sb.AppendLine(".tooltip .tooltiptext { visibility: hidden; width: 120px; background-color: #555; color: #fff; text-align: center; border-radius: 5px; padding: 5px 0; position: absolute; z-index: 1; bottom: 125%; left: 50%; margin-left: -60px; opacity: 0; transition: opacity 0.3s; }")
        Dim unused6 = sb.AppendLine(".tooltip:hover .tooltiptext { visibility: visible; opacity: 1; }")
        Dim unused7 = sb.AppendLine("</style>")
        Dim unused8 = sb.AppendLine("</head>")
        Dim unused9 = sb.AppendLine("<body>")
        Dim unused11 = sb.AppendLine("<div class='tooltip'>")
        Dim unused10 = sb.AppendLine("<img src='C:\Users\admin\Documents\TextBox33.Text' alt='Prenommer'>")
        Dim unused13 = sb.AppendLine("<span class='tooltiptext'>Texte au survol</span>")
        Dim unused12 = sb.AppendLine("</div>")
        Dim unused14 = sb.AppendLine("</body>")
        Dim unused15 = sb.AppendLine("</html>")

        Return sb.ToString()

    End Function

    Private Function IsValidFileName(fileName As String) As Boolean

        Return Not String.IsNullOrWhiteSpace(fileName) AndAlso fileName.All(Function(c) Char.IsLetterOrDigit(c) OrElse c = "_" OrElse c = "-")

    End Function

    Private Sub SaveFile()

        Dim rawFileName As String = TextBox1.Text.Trim()

        If Not IsValidFileName(rawFileName) Then
            Dim unused = Forms.MessageBox.Show("Nom de fichier invalide. Veuillez entrer un nom de fichier valide.")
            Return
        End If

        Dim fileName As String = $"{rawFileName}.md"
        ' Sauvegarde du fichier
        ' ...

    End Sub

    Private Sub NettoyerLignesVides(filePath As String)

        Try
            ' Lire toutes les lignes non vides et les réécrire
            Dim lignes = File.ReadAllLines(filePath).Where(Function(l) Not String.IsNullOrWhiteSpace(l)).ToArray()
            File.WriteAllLines(filePath, lignes, Encoding.UTF8)
        Catch ex As Exception
            ' Enregistrer les erreurs liées au nettoyage dans le fichier d'erreurs
            File.AppendAllText("audit_erreurs.txt", $"Erreur lors du nettoyage de {filePath} : {ex.Message}{Environment.NewLine}")
        End Try

    End Sub

    Public Sub VerifierFichier(sender As Object, e As EventArgs)

        Dim unused = Forms.MessageBox.Show("Le menu Vérification et sauvegarde fichiers a été activé.")

        Try

            ' Définir les chemins pour les répertoires et le fichier d'erreurs
            Dim directoryPath As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Librairies"
            Dim backupPath As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Librairies_Backup"
            Dim erreurs As New List(Of String)()

            ' Sauvegarder les fichiers si besoin
            If Directory.Exists(directoryPath) Then
                SauvegarderRepertoire(directoryPath, backupPath)
            Else
                Dim unused3 = MsgBox($"Le répertoire {directoryPath} n'existe pas.")
                Return
            End If

            ' Vérification des fichiers
            For Each filePath As String In Directory.GetFiles(directoryPath, "*.librairie")
                Dim lignes = File.ReadAllLines(filePath, Encoding.UTF8)
                If Not VerifierContenuLibrairie(lignes, filePath, erreurs) Then
                    erreurs.Add($"Erreur détectée dans : {System.IO.Path.GetFileName(filePath)}")
                End If
            Next

            ' Écrire les erreurs dans un fichier
            Dim erreursPath As String = System.IO.Path.Combine(directoryPath, "audit_erreurs.txt")
            If erreurs.Count > 0 Then
                File.WriteAllLines(erreursPath, erreurs)
                Dim unused1 = Forms.MessageBox.Show($"Audit terminé avec {erreurs.Count} erreurs. Voir audit_erreurs.txt.", "Audit terminé", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If File.Exists(erreursPath) Then
                    File.Delete(erreursPath)
                End If
                Dim unused2 = Forms.MessageBox.Show("Audit terminé : aucun problème détecté. Pas de fichier généré.", "Audit terminé", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'MsgBox($"Processus terminé. Fichier d'erreurs : {erreursPath}")

        Catch ex As Exception
            Dim unused4 = MsgBox($"Une erreur s'est produite : {ex.Message}")
        End Try

    End Sub

    Private Sub CorrigerFichiersLibrairies(directoryPath As String)

        ' Définir le chemin du répertoire principal
        Dim mainDirectoryPath As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Resources"

        ' Définir le chemin pour stocker les fichiers corrigés
        Dim correctionsPath As String = System.IO.Path.Combine(mainDirectoryPath, "Librairies_Corriges")

        ' Créer le répertoire des corrections s'il n'existe pas
        If Not Directory.Exists(correctionsPath) Then
            Dim unused = Directory.CreateDirectory(correctionsPath)
        End If

        ' Boucle pour parcourir chaque fichier de librairie
        For Each filePath As String In Directory.GetFiles(directoryPath, "*.librairie")
            Try
                ' Lire le contenu du fichier
                Dim content As String = File.ReadAllText(filePath)

                ' Vérification des erreurs
                If DetecterErreurs(content) Then
                    ' Copier le fichier dans le répertoire des corrections
                    Dim correctedFilePath As String = System.IO.Path.Combine(correctionsPath, System.IO.Path.GetFileName(filePath))
                    File.Copy(filePath, correctedFilePath, True)

                    ' Appliquer les corrections
                    content = CorrigerContenu(content)

                    ' Réécrire le fichier corrigé
                    File.WriteAllText(correctedFilePath, content, Encoding.UTF8)
                    Dim unused1 = MsgBox($"Correction appliquée au fichier : {System.IO.Path.GetFileName(filePath)}", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                Dim unused2 = MsgBox($"Erreur lors de la correction du fichier {System.IO.Path.GetFileName(filePath)} : {ex.Message}", MsgBoxStyle.Critical)
            End Try
        Next

        Dim unused3 = MsgBox("Processus de correction terminé.", MsgBoxStyle.Information)

    End Sub

    Private Function DetecterErreurs(content As String) As Boolean

        ' Exemple de détection d'erreurs : vérifier la longueur de certaines lignes
        If content.Length < 50 Then
            Return True ' Simule une erreur
        End If
        Return False

    End Function

    Private Function CorrigerContenu(content As String) As String

        ' Exemple : Appliquer des corrections simples (ajout d'une ligne de correction)
        Return content & vbCrLf & "Correction appliquée automatiquement."

    End Function

    Private Function DiviserLigneEnChamps(ligne As String) As String()

        Dim champs As New List(Of String)()
        Dim position As Integer = 0

        For Each longueur In LongueursChamps
            If position + longueur > ligne.Length Then
                ' Si la ligne est plus courte que prévu, ajouter un champ vide
                champs.Add(String.Empty)
            Else
                ' Extraire le champ selon sa longueur
                champs.Add(ligne.Substring(position, longueur).Trim())
            End If
            position += longueur
        Next

        Return champs.ToArray()

    End Function

    Private Function VerifierContenuLibrairie(lignes As String(), filePath As String, erreurs As List(Of String)) As Boolean

        Dim contenuCorrect As Boolean = True

        For i As Integer = 0 To lignes.Length - 1
            Dim ligne = lignes(i)
            Dim ligneNumero = i + 1

            ' Vérification des lignes vides
            If String.IsNullOrWhiteSpace(ligne) Then
                erreurs.Add($"Fichier {System.IO.Path.GetFileName(filePath)} - Ligne {ligneNumero} : Ligne vide détectée.")
                contenuCorrect = False
                Continue For
            End If

            ' Vérification de la longueur totale de la ligne
            If ligne.Length <> 3188 Then
                erreurs.Add($"Fichier {System.IO.Path.GetFileName(filePath)} - Ligne {ligneNumero} : Longueur totale incorrecte. Longueur attendue : 3188, Longueur trouvée : {ligne.Length}.")
                contenuCorrect = False
            End If

            ' Vérification des champs individuels
            Dim champs = DiviserLigneEnChamps(ligne)
            For j As Integer = 0 To champs.Length - 1
                If champs(j).Length > LongueursChamps(j) Then
                    erreurs.Add($"Fichier {System.IO.Path.GetFileName(filePath)} - Ligne {ligneNumero}, Champ {j + 1} : Le champ dépasse les limites de la ligne.")
                    contenuCorrect = False
                End If
            Next
        Next

        Return contenuCorrect

    End Function

    Private Function ConvertirEnStructure(ligne As String) As Article

        ' Convertir une ligne en structure Article
        ' Note : Utiliser les positions fixes des champs si nécessaire
        ' Exemple d'assignation (ajuster en fonction du format des fichiers)

        Dim article As New Article With {
            .Title = ligne.Substring(0, 18).Trim(),
            .Name = ligne.Substring(18, 90).Trim(),
            .Charge = ligne.Substring(90, 120).Trim(),
            .Institute = ligne.Substring(120, 120).Trim(),
            .Celebration = ligne.Substring(120, 120).Trim(),
            .Birth = ligne.Substring(120, 120).Trim(),
            .Death = ligne.Substring(120, 120).Trim(),
            .Otherparties = ligne.Substring(120, 120).Trim(),
            .Othernames = ligne.Substring(120, 120).Trim(),
            .Venerable = ligne.Substring(120, 120).Trim(),
            .Beatified = ligne.Substring(120, 120).Trim(),
            .Canonized = ligne.Substring(120, 120).Trim(),
            .Heading = ligne.Substring(120, 120).Trim(),
            .Patron = ligne.Substring(120, 120).Trim(),
            .Link = ligne.Substring(120, 120).Trim(),
            .Biography = ligne.Substring(120, 1200).Trim(),
            .Image = ligne.Substring(1200, 120).Trim(),
            .Origin = ligne.Substring(120, 200).Trim()
        }
        ' Compléter avec les autres champs...
        Return article

    End Function

    Private Function ObtenirValeurChamp(article As Article, champ As String) As String

        ' Obtenir la valeur d'un champ donné dans la structure Article
        Select Case champ
            Case "Title" : Return article.Title
            Case "Name" : Return article.Name
            Case "Charge" : Return article.Charge
            Case "Institute" : Return article.Institute
            Case "Celebration" : Return article.Celebration
            Case "Birth" : Return article.Birth
            Case "Death" : Return article.Death
            Case "Otherparties" : Return article.Otherparties
            Case "Othernames" : Return article.Othernames
            Case "Venerable" : Return article.Venerable
            Case "Beatified" : Return article.Beatified
            Case "Canonized" : Return article.Canonized
            Case "Heading" : Return article.Heading
            Case "Patron" : Return article.Patron
            Case "Link" : Return article.Link
            Case "Biography" : Return article.Biography
            Case "Image" : Return article.Image
            Case "Origin" : Return article.Origin
                ' Ajouter les autres champs ici...
            Case Else : Return ""
        End Select

    End Function

    Private Sub CorrigerArticle(ByRef article As Article, taillesMax As Dictionary(Of String, Integer))

        ' Exemple de correction en tronquant les valeurs trop longues
        article.Title = article.Title.Substring(0, System.Math.Min(article.Title.Length, taillesMax("Title")))
        article.Name = article.Name.Substring(0, System.Math.Min(article.Name.Length, taillesMax("Name")))
        article.Charge = article.Charge.Substring(0, System.Math.Min(article.Charge.Length, taillesMax("Charge")))
        article.Institute = article.Institute.Substring(0, System.Math.Min(article.Institute.Length, taillesMax("Institute")))
        article.Celebration = article.Celebration.Substring(0, System.Math.Min(article.Celebration.Length, taillesMax("Celebration")))
        article.Birth = article.Birth.Substring(0, System.Math.Min(article.Birth.Length, taillesMax("Birth")))
        article.Death = article.Death.Substring(0, System.Math.Min(article.Death.Length, taillesMax("Death")))
        article.Otherparties = article.Otherparties.Substring(0, System.Math.Min(article.Otherparties.Length, taillesMax("Otherparties")))
        article.Othernames = article.Othernames.Substring(0, System.Math.Min(article.Othernames.Length, taillesMax("Othernames")))
        article.Venerable = article.Venerable.Substring(0, System.Math.Min(article.Venerable.Length, taillesMax("Venerable")))
        article.Beatified = article.Beatified.Substring(0, System.Math.Min(article.Beatified.Length, taillesMax("Beatified")))
        article.Canonized = article.Canonized.Substring(0, System.Math.Min(article.Canonized.Length, taillesMax("Canonized")))
        article.Heading = article.Heading.Substring(0, System.Math.Min(article.Heading.Length, taillesMax("Heading")))
        article.Patron = article.Patron.Substring(0, System.Math.Min(article.Patron.Length, taillesMax("Patron")))
        article.Link = article.Link.Substring(0, System.Math.Min(article.Link.Length, taillesMax("Link")))
        article.Biography = article.Biography.Substring(0, System.Math.Min(article.Biography.Length, taillesMax("Biography")))
        article.Origin = article.Origin.Substring(0, System.Math.Min(article.Origin.Length, taillesMax("Origin")))
        ' Ajouter des corrections pour les autres champs...

    End Sub

    Private Function ConvertirEnTexte(article As Article) As String
        Try
            ' Assurez-vous que chaque champ n'est pas null avec If/Else ou une valeur par défaut.
            Dim ligne = $"{If(article.Title, String.Empty),-18}" &
        $"{If(article.Name, String.Empty),-90}" &
        $"{If(article.Charge, String.Empty),-120}" &
        $"{If(article.Institute, String.Empty),-120}" &
        $"{If(article.Celebration, String.Empty),-120}" &
        $"{If(article.Birth, String.Empty),-120}" &
        $"{If(article.Death, String.Empty),-120}" &
        $"{If(article.Otherparties, String.Empty),-120}" &
        $"{If(article.Othernames, String.Empty),-120}" &
        $"{If(article.Venerable, String.Empty),-120}" &
        $"{If(article.Beatified, String.Empty),-120}" &
        $"{If(article.Canonized, String.Empty),-120}" &
        $"{If(article.Heading, String.Empty),-120}" &
        $"{If(article.Patron, String.Empty),-120}" &
        $"{If(article.Link, String.Empty),-120}" &
        $"{If(article.Biography, String.Empty),-1200}" &
        $"{If(article.Image, String.Empty),-120}" &
        $"{If(article.Origin, String.Empty),-200}"

            Return ligne
        Catch ex As Exception
            ' Gérer les erreurs ici (exemple : journaliser dans un fichier)
            Dim unused = MsgBox($"Erreur lors de la conversion en texte : {ex.Message}")
            ' Retourner une valeur vide pour éviter une exception
            Return String.Empty
        End Try

    End Function

    Private Function GetTailleStructure() As Dictionary(Of String, Integer)
        ' Retourne un dictionnaire des tailles maximales des champs
        Return New Dictionary(Of String, Integer) From {
{"Title", 18},
{"Name", 90},
{"Charge", 120},
{"Institute", 120},
{"Celebration", 120},
{"Birth", 120},
{"Death", 120},
{"Otherparties", 120},
{"Othernames", 120},
{"Venerable", 120},
{"Beatified", 120},
{"Canonized", 120},
{"Heading", 120},
{"Patron", 120},
{"Link", 120},
{"Biography", 1200},
{"Image", 120},
{"Origin", 200}
}
    End Function

    Public Sub AuditFichiersLibrairies()

        Dim directoryPath As String = My.Application.Info.DirectoryPath & "\Librairies"
        If Not Directory.Exists(directoryPath) Then
            Dim unused = Forms.MessageBox.Show("Le répertoire Librairies est introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim fichiers = Directory.GetFiles(directoryPath, "*.librairie")
        If fichiers.Length = 0 Then
            Dim unused1 = Forms.MessageBox.Show("Aucun fichier .librairie trouvé dans le répertoire.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim erreurs As New List(Of String)()

        For Each fichier In fichiers
            Try
                Dim contenu = File.ReadAllText(fichier)
                ' Exemple d'audit : Vérifier si une ligne dépasse 100 caractères
                Dim lignes = contenu.Split(New String() {vbCrLf}, StringSplitOptions.None)
                For Each ligne In lignes
                    If ligne.Length > 100 Then
                        erreurs.Add($"Fichier : {System.IO.Path.GetFileName(fichier)} -> Ligne trop longue : {ligne.Substring(0, 50)}...")
                    End If
                Next
            Catch ex As Exception
                erreurs.Add($"Erreur lors de la lecture du fichier {System.IO.Path.GetFileName(fichier)} : {ex.Message}")
            End Try
        Next

        If erreurs.Count > 0 Then
            File.WriteAllLines(System.IO.Path.Combine(directoryPath, "audit_erreurs.txt"), erreurs)
            Dim unused2 = Forms.MessageBox.Show($"Audit terminé avec {erreurs.Count} erreurs. Voir audit_erreurs.txt.", "Audit terminé", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim unused3 = Forms.MessageBox.Show("Audit terminé : aucun problème détecté.", "Audit terminé", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub SauvegarderRepertoire(sourcePath As String, destinationPath As String)

        Try

            ' Assurez-vous que le répertoire de destination existe
            If Not Directory.Exists(destinationPath) Then
                Dim unused = Directory.CreateDirectory(destinationPath)
            End If

            ' Copier chaque fichier dans le répertoire source
            For Each filePath As String In Directory.GetFiles(sourcePath, "*.librairie")
                Dim fileName As String = System.IO.Path.GetFileName(filePath)
                Dim destFilePath As String = System.IO.Path.Combine(destinationPath, fileName)

                File.Copy(filePath, destFilePath, overwrite:=True)
            Next

            ' Copier les sous-répertoires si nécessaire
            For Each dirPath As String In Directory.GetDirectories(sourcePath)
                Dim dirName As String = System.IO.Path.GetFileName(dirPath)
                Dim destDirPath As String = System.IO.Path.Combine(destinationPath, dirName)

                SauvegarderRepertoire(dirPath, destDirPath)
            Next

            Dim unused1 = MsgBox("Sauvegarde du répertoire effectuée avec succès.")
        Catch ex As Exception
            Dim unused2 = MsgBox($"Erreur lors de la sauvegarde du répertoire : {ex.Message}")
        End Try

    End Sub

    ' Gestionnaire d'événements pour le clic ListView1.
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click

        Try

            ' Assurez-vous qu'un élément est sélectionné.
            If ListView1.SelectedItems.Count > 0 Then
                ' Obtenez le chemin complet du fichier sélectionné dans ListView.
                Dim selectedFilePath As String = System.IO.Path.Combine("C:\Prenommer\Prenommer\Prenommer\bin\Debug\Librairies", ListView1.SelectedItems(0).Text)

                ' Ouvrez le fichier sélectionné dans TextBox35.
                OpenFile(selectedFilePath)

                ' Ajoutez le fichier à la liste des fichiers récents (en passant le chemin complet).
                AddRecentFile(selectedFilePath)

                'AddFileToRecentList(selectedFilePath)

                ' Mettez à jour le menu "Fichiers récents".
                SetupRecentFilesMenu()

                NumeroEncodage()
            End If

        Catch ex As Exception
            ' Gérez l'exception ici, vous pouvez afficher un message d'erreur ou effectuer d'autres actions.
            Dim unused = Forms.MessageBox.Show("Une erreur s'est produite : " & ex.Message)

        End Try

    End Sub

    Private Sub NumeroEncodage()

        Dim Encodingnumero = ListView1.SelectedIndices(0)
        Dim Encodingpath As String = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(Encodingnumero).Text

        Using reader As New StreamReader(Encodingpath, True)
            Dim encoding As Encoding = reader.CurrentEncoding
            Dim hasBom As Boolean = encoding.GetPreamble().Length > 0
            Dim bomText As String = If(hasBom, "avec BOM", "sans BOM")
            ToolStripStatusLabel7.Text = "Encodage : " & encoding.WebName & " " & bomText
        End Using

    End Sub

    Private Function RechercherFichierDOCX(nomPropre As String, dirPath As String) As String

        Dim files As String() = Directory.GetFiles(dirPath, "*.docx")
        Return files.FirstOrDefault(Function(f) System.IO.Path.GetFileNameWithoutExtension(f).Equals(nomPropre, StringComparison.InvariantCultureIgnoreCase))

    End Function

    Private Function ObtenirCheminDOCX(nom As String) As String

        Dim nomPropre As String = NettoyerTitre(nom)
        Return System.IO.Path.Combine("C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements\", nomPropre & ".docx")

        Dim dossier As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements\"
        nomPropre = NettoyerTitre(nom).Trim()

        Dim unused = MsgBox("nonPropre")

        ' Vérifier si le dossier existe
        If Not Directory.Exists(dossier) Then
            Dim unused1 = MsgBox("Le répertoire spécifié n'existe pas.")
            Return Nothing
        End If

        ' Nettoyer le nom
        nomPropre = Regex.Replace(nomPropre, "[^\w\s]", "")

        ' Construire le chemin
        Dim cheminComplet As String = System.IO.Path.Combine(dossier, nomPropre & ".docx")
        Dim unused2 = MsgBox($"Chemin généré : {cheminComplet}")

        Return cheminComplet

    End Function

    Private Function NettoyerTitre(nomComplet As String) As String

        Dim prefixes As String() = {"Bienheureuse ", "Bienheureuses ", "Bienheureux ", "Fête mariale ", "Fête religieuse ", "Saint ", "Sainte ", "Saintes ", "Saints ", "Sanctuaire marial ", "Servante de Dieu ", "Servantes de Dieu ", "Servants de Dieu ", "Serviteur de Dieu ", "Serviteurs de Dieu ", "Vénérable ", "Vénérables "}

        For Each prefix In prefixes
            If nomComplet.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase) Then
                Return nomComplet.Substring(prefix.Length).Trim()
            End If
        Next

        ' Retourner le titre d'origine si aucun préfixe trouvé
        Return nomComplet.Trim()

    End Function

    Public Sub RenommerFichier(baseDirectory As String, oldFileName As String, newFileName As String)

        Try

            ' Récupérer les noms des fichiers
            oldFileName = Trim(TextBox2.Text) & " " & Trim(TextBox1.Text) & ".docx"
            newFileName = Trim(TextBox1.Text) & ".docx"
            Dim oldFilePath As String = System.IO.Path.Combine(baseDirectory, oldFileName)
            Dim newFilePath As String = System.IO.Path.Combine(baseDirectory, newFileName)

            ' Vérifier l'existence du fichier source
            If Not File.Exists(oldFilePath) Then
                Dim unused = MsgBox($"Fichier source introuvable : {oldFilePath}")
                Return
            End If

            If IsFileLocked(oldFilePath) Then
                Dim unused1 = MsgBox($"Le fichier est verrouillé et ne peut pas être renommé : {oldFilePath}")
                Return
            End If

            ' Renommer le fichier
            File.Move(oldFilePath, newFilePath)

            ' Confirmation du renommage
            Dim unused3 = MsgBox($"Renommage réussi : {newFilePath}")
        Catch ex As Exception
            Dim unused2 = MsgBox($"Erreur lors du renommage : {ex.Message}")
        End Try

    End Sub

    Private Sub GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GénérerUnFichierODTÀPartirDunDocumentDOCXToolStripMenuItem.Click

        Try

            Try
                ' Récupérer les noms des fichiers depuis TextBox
                Dim baseDirectory As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements"
                Dim oldFileName As String = Trim(TextBox2.Text) & " " & Trim(TextBox1.Text) & ".docx"
                Dim newFileName As String = Trim(TextBox1.Text) & ".docx"

                ' Appeler la fonction RenommerFichier
                RenommerFichier(baseDirectory, oldFileName, newFileName)

            Catch ex As Exception
                Dim unused1 = MsgBox($"Erreur : {ex.Message}")
            End Try

            ' Nettoyer le titre
            Dim nomPropre As String = NettoyerTitre(TextBox1.Text)
            Dim unused2 = MsgBox($"Nom nettoyé :          {nomPropre}") ' Vérifiez ici si le préfixe est supprimé

            ' Construire le chemin source pour le fichier DOCX
            Dim sourceFilePath As String = System.IO.Path.Combine("C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements\", nomPropre & ".docx")
            Dim unused3 = MsgBox($"Chemin du fichier DOCX nettoyé : {sourceFilePath}") ' Vérifiez que le chemin est correct

            ' Vérifier si le fichier DOCX existe
            If Not File.Exists(sourceFilePath) Then
                Dim unused = MsgBox($"Fichier introuvable  {sourceFilePath}")
                Return
            End If

            Dim unused4 = MsgBox($"Fichier à convertir : {sourceFilePath}")

            ' Sélectionner un répertoire de sortie pour le fichier ODT
            Dim folderDialog As New FolderBrowserDialog With {
.Description = "Choisissez un répertoire de sortie",
.SelectedPath = "C\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements"
}

            Dim outputDir As String
            If folderDialog.ShowDialog() = DialogResult.OK Then
                outputDir = folderDialog.SelectedPath
            Else
                Dim unused5 = MsgBox("Aucun répertoire sélectionné.")
                Return
            End If

            ' Appeler la méthode de conversion
            ConvertirDocxEnOdt(sourceFilePath, outputDir)

        Catch ex As Exception
            Dim unused6 = MsgBox($"Une exception s'est produite : {ex.Message}")
        End Try

    End Sub

    Private Sub AjouterAuJournal(message As String)

        Dim logFile As String = System.IO.Path.Combine("C:\Prenommer\Logs", "conversion_log.txt")

        ' Vérifier si le dossier existe, sinon le créer
        Dim logDirectory As String = System.IO.Path.GetDirectoryName(logFile)
        If Not Directory.Exists(logDirectory) Then
            Dim unused = Directory.CreateDirectory(logDirectory)
        End If

        ' Ajouter le message au fichier journal
        File.AppendAllText(logFile, $"{Date.Now}: {message}{Environment.NewLine}")

    End Sub

    Public Sub ConvertirDocxEnOdt(sourceFilePath As String, outputDir As String)

        Try
            ' Définir le chemin de LibreOffice et les arguments
            Dim sofficePath As String = "C:\Program Files\LibreOffice\program\soffice.exe"
            Dim arguments As String = $"--headless --convert-to odt ""{sourceFilePath}"" --outdir ""{outputDir}"""

            ' Configurer le processus
            Dim process As New Process()
            process.StartInfo.FileName = sofficePath
            process.StartInfo.Arguments = arguments
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            process.StartInfo.CreateNoWindow = True

            ' Exécuter le processus
            Dim unused2 = process.Start()
            process.WaitForExit()

            ' Lire la sortie et les erreurs
            Dim output As String = process.StandardOutput.ReadToEnd()
            Dim [error] As String = process.StandardError.ReadToEnd()

            ' Gérer les erreurs ou le succès
            If Not String.IsNullOrEmpty([error]) Then
                Dim unused = MsgBox($"Erreur lors de la conversion : {[error]}")
            Else
                Dim unused1 = MsgBox($"Conversion réussie vers : {System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(sourceFilePath) & ".odt")}")
            End If
        Catch ex As Exception
            Dim unused3 = MsgBox($"Une exception s'est produite : {ex.Message}")
        End Try

    End Sub

    Public Sub ConvertToODT(docxFilePath As String)

        Dim libreOfficePath As String = "C\Programmes\LibreOffice\program\soffice.bin"

        ' Définir les arguments de la commande de conversion.
        Dim arguments As String = $"--headless --convert-to odt ""{docxFilePath}"""

        ' Renommer le fichier sans l'extension .docx.
        Dim renamedFilePath As String = System.IO.Path.ChangeExtension(docxFilePath, Nothing)

        ' Lancer LibreOffice en tant que processus.
        Dim processInfo As New ProcessStartInfo(libreOfficePath, arguments) With {
.WorkingDirectory = System.IO.Path.GetDirectoryName(docxFilePath),
.CreateNoWindow = True,
.UseShellExecute = False
}

        Process.Start(processInfo).WaitForExit()

        ' Spécifier le répertoire de destination pour le fichier .odt.
        Dim odtDirectory As String = My.Application.Info.DirectoryPath & "\Téléchargements\"
        Dim odtFileName As String = System.IO.Path.GetFileNameWithoutExtension(renamedFilePath) & ".odt"
        Dim odtFilePath As String = System.IO.Path.Combine(odtDirectory, odtFileName)

        ' Renommer le fichier converti avec l'extension .odt.
        File.Move(renamedFilePath, odtFilePath)

    End Sub

    Public Sub SetupRecentFilesMenu()

        ' Vérifier si le menu "Fichiers récents" existe.
        If EffacerFichiersRecentsMenuItem Is Nothing Then
            EffacerFichiersRecentsMenuItem = New ToolStripMenuItem("Fichiers récents")
        End If

        ' Effacer les anciens éléments de menu.
        EffacerFichiersRecentsMenuItem.DropDownItems.Clear()

        ' Récupérer la liste des fichiers récents à partir du fichier "Recent.txt".
        Dim recentFiles As List(Of String) = GetRecentFiles()

        ' Ajouter les nouveaux éléments de menu pour chaque fichier récent.
        For Each filePath As String In recentFiles
            Dim fileName As String = System.IO.Path.GetFileName(filePath)

            Dim menuItem As New ToolStripMenuItem(fileName)
            ' Ajouter un gestionnaire d'événements pour le clic sur l'élément de menu.
            AddHandler menuItem.Click, AddressOf FichiersRecentsMenuItem_Click
            ' Stocker le chemin du fichier dans la propriété Tag de l'élément de menu.
            menuItem.Tag = System.IO.Path.GetFileName(filePath)

            ' Ajouter l'élément de menu à FichiersRecentsMenuItem.
            Dim unused = EffacerFichiersRecentsMenuItem.DropDownItems.Add(menuItem)
        Next

        ' S'assurer que FichiersRecentsMenuItem n'est pas déjà dans DonnéesToolStripMenuItem1.
        If Not DonnéesToolStripMenuItem1.DropDownItems.Contains(EffacerFichiersRecentsMenuItem) Then
            ' Ajouter FichiersRecentsMenuItem avant "Quitter" dans DonnéesToolStripMenuItem1.
            DonnéesToolStripMenuItem1.DropDownItems.Insert(DonnéesToolStripMenuItem1.DropDownItems.Count - 1, EffacerFichiersRecentsMenuItem)
        End If

    End Sub

    Private Function GetRecentFiles() As List(Of String)

        Dim recentFiles As New List(Of String)

        If My.Settings.RecentFiles IsNot Nothing Then
            recentFiles.AddRange(My.Settings.RecentFiles.Cast(Of String))
        End If

        Return recentFiles

    End Function

    Private Sub OpenFile(selectedFilePath As String)

        ' Vérifier si le chemin du fichier est valide.
        If Not String.IsNullOrEmpty(selectedFilePath) Then
            ' Calculer le chemin complet.
            Dim fullPath As String = System.IO.Path.Combine(Environment.CurrentDirectory, "Librairies", selectedFilePath)

            ' Vérifier si le fichier existe avant d'essayer de l'ouvrir.
            If File.Exists(fullPath) Then
                ' Le fichier existe, vous pouvez appeler OpenFile.
                Dim fileContent As String = File.ReadAllText(fullPath, Encoding.UTF8)
                TextBox35.Text = fileContent

                ' Ajouter le fichier à la liste des fichiers récents.
                AddFileToRecentList(fullPath)
            Else
                ' Le fichier n'existe pas.
                'Dim unused = MessageBox.Show("Le fichier n'existe pas. Chemin du fichier : " & fullPath)
            End If
        Else
            ' Le chemin du fichier n'est pas valide.
            'Dim unused1 = MessageBox.Show("Le chemin du fichier est invalide.")
        End If

    End Sub

    Private Sub AddFileToRecentList(selectedFilePath As String)

        ' Vérifier si la liste des fichiers récents existe.
        If My.Settings.RecentFiles IsNot Nothing Then

            ' Vérifier si le fichier est déjà dans la liste.
            If Not My.Settings.RecentFiles.Contains(selectedFilePath) Then

                ' Le fichier n'est pas déjà dans la liste des fichiers récents, vous pouvez l'ajouter.
                Dim unused = My.Settings.RecentFiles.Add(selectedFilePath)

                ' Si le nombre de fichiers dépasse la limite, enlever le plus ancien.
                If My.Settings.RecentFiles.Count > MAX_RECENT_FILES Then
                    My.Settings.RecentFiles.RemoveAt(0)
                End If

                ' Effectuer d'autres opérations associées à l'ajout d'un fichier récent.
                ' Par exemple, mettre à jour l'interface utilisateur, enregistrer dans Recent.txt, etc.
                UpdateRecentFilesMenu(My.Settings.RecentFiles)
                SaveRecentFiles(My.Settings.RecentFiles.Cast(Of String)().ToList())
            End If
        Else
            ' Initialiser la liste si elle est nulle.
            My.Settings.RecentFiles = New StringCollection()
            Dim unused1 = My.Settings.RecentFiles.Add(selectedFilePath)

            ' Effectuer d'autres opérations associées à l'ajout d'un fichier récent.
            ' Par exemple, mettre à jour l'interface utilisateur, enregistrer dans Recent.txt, etc..
            UpdateRecentFilesMenu(My.Settings.RecentFiles)
            SaveRecentFiles(My.Settings.RecentFiles.Cast(Of String)().ToList())
        End If

    End Sub

    Private Sub AddRecentFile(filePath As String)

        If My.Settings.RecentFiles Is Nothing Then
            My.Settings.RecentFiles = New StringCollection()
        End If

        ' Vérifier si le fichier est déjà dans la liste.
        If My.Settings.RecentFiles.Contains(filePath) Then
            My.Settings.RecentFiles.Remove(filePath)
        End If

        ' Vérifier le nombre maximum autorisé.
        If My.Settings.RecentFiles.Count >= MAX_RECENT_FILES Then
            ' Si la limite est atteinte, retirez le fichier le plus ancien.
            My.Settings.RecentFiles.RemoveAt(0)
        End If

        ' Ajouter le fichier à la liste des fichiers récents.
        Dim unused = My.Settings.RecentFiles.Add(filePath)

    End Sub

    Private Sub SaveRecentFiles(recentFiles As List(Of String))

        Try

            ' Assurez-vous que la liste des fichiers récents n'est pas null.
            If recentFiles IsNot Nothing Then
                ' Construire le chemin du fichier "Recent.txt".
                Dim filePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources", "Recent.txt")
                ' Assurez-vous que le répertoire existe.
                Dim directoryPath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources")
                If Not Directory.Exists(directoryPath) Then
                    Dim unused = Directory.CreateDirectory(directoryPath)
                End If

                ' Écrivez le contenu dans le fichier "Recent.txt" seulement si la liste n'est pas vide.
                If recentFiles.Count > 0 Then
                    Dim fileContent As String = String.Join(Environment.NewLine, recentFiles)
                    File.WriteAllText(filePath, fileContent, Encoding.UTF8)  'Default)
                End If
            Else
                ' Affichez un message si la liste est null.
                Dim unused1 = Forms.MessageBox.Show("La liste des fichiers récents est null.")
            End If
        Catch ex As Exception
            Dim unused2 = Forms.MessageBox.Show($"Erreur lors de l'écriture dans Recent.txt : {ex.Message}")
        End Try

    End Sub

    Private Sub UpdateRecentFilesMenu(recentFiles As StringCollection)

        ' Effacer les anciens éléments de menu.
        EffacerFichiersRecentsMenuItem.DropDownItems.Clear()

        ' Ajouter les nouveaux éléments de menu pour chaque fichier récent.
        For Each filePath As String In recentFiles
            Dim fileName As String = System.IO.Path.GetFileName(filePath)
            Dim menuItem As New ToolStripMenuItem(fileName)

            ' Ajouter un gestionnaire d'événements pour le clic sur l'élément de menu.
            AddHandler menuItem.Click, AddressOf FichiersRecentsMenuItem_Click

            ' Stocker le chemin du fichier dans la propriété Tag de l'élément de menu.
            menuItem.Tag = filePath
            Dim unused = EffacerFichiersRecentsMenuItem.DropDownItems.Add(menuItem)
        Next

    End Sub

    Public Sub FichiersRecentsMenuItem_Click(sender As Object, e As EventArgs) 'Handles FichiersRecentsMenuItem.Click

        Try
            ' ... (autre code)

            ' Assurez-vous que l'élément cliqué est un ToolStripMenuItem.
            If TypeOf sender Is ToolStripMenuItem Then
                ' Récupérer le chemin du fichier associé à l'élément cliqué.

                clickedMenuItem = DirectCast(sender, ToolStripMenuItem)

                ' Assurez-vous que la propriété Tag de ToolStripMenuItem n'est pas nulle.
                If clickedMenuItem?.Tag IsNot Nothing Then
                    ' Convertir la propriété Tag en chaîne.
                    filePath = clickedMenuItem.Tag.ToString()

                    ' Assurez-vous que la chaîne du chemin du fichier n'est pas nulle ou vide.
                    If Not String.IsNullOrEmpty(filePath) Then
                        ' Maintenant, vous pouvez utiliser la variable filePath comme prévu.

                        ' Extraire la lettre alphabétique du chemin du fichier.
                        Dim firstLetter As Char = System.IO.Path.GetFileNameWithoutExtension(filePath)(0)

                        HighlightItemByFirstLetter(firstLetter)

                        ' Rechercher le nœud correspondant dans le TreeView1.
                        Dim node As TreeNode = FindNodeByFirstLetter(TreeView1.Nodes, firstLetter)

                        ' Si le nœud est trouvé, le sélectionner.
                        If node IsNot Nothing Then
                            TreeView1.SelectedNode = node
                        End If

                    Else
                        ' Afficher un message d'erreur si le fichier n'existe pas.
                        Dim unused = Forms.MessageBox.Show($"Le fichier récent n'existe pas : {filePath}")
                    End If

                ElseIf clickedMenuItem.Text = "Effacer fichiers récents" Then
                    ' Code pour effacer les fichiers récents
                    My.Settings.RecentFiles.Clear()
                    My.Settings.Save()
                    ' Mettez à jour l'interface utilisateur si nécessaire.
                    ' ...
                End If
            End If

            'ClearRecentFilesButton.PerformClick()

        Catch ex As NullReferenceException
            ' Gérer l'exception ici, vous pouvez afficher un message d'erreur ou effectuer d'autres actions.
            Dim unused2 = Forms.MessageBox.Show($"Une exception de référence null s'est produite : {ex.Message}")
        End Try

    End Sub

    Private Sub RecentFileMenuItem_Click(sender As Object, e As EventArgs)

        Try
            Dim fileName As String = TryCast(DirectCast(sender, ToolStripMenuItem)?.Tag, String)?.ToString()

            ' Construire le chemin complet du fichier.
            Dim filePath As String = System.IO.Path.Combine(Environment.CurrentDirectory, "Librairies", fileName)

            ' Vérifier si le fichier existe avant de l'ouvrir.
            If File.Exists(filePath) Then
                ' Ouvrir le fichier sélectionné dans le TextBox35.
                OpenFile(filePath)

                ' Ajouter le fichier à la liste des fichiers récents.
                AddRecentFile(filePath:=System.IO.Path.GetFileName(filePath))

                ' Mettre à jour le menu "Fichiers récents".
                SetupRecentFilesMenu()
            Else
                ' Afficher un message d'erreur si le fichier n'existe pas.
                Dim unused = Forms.MessageBox.Show($"Le fichier récent n'existe pas : {filePath}")
            End If

        Catch ex As Exception
            ' Gérer l'exception ici, vous pouvez afficher un message d'erreur ou effectuer d'autres actions.
            Dim unused1 = Forms.MessageBox.Show($"Une erreur s'est produite : {ex.Message}")
        End Try

    End Sub

    Private Sub RechercheAvancéeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RechercheAvancéeToolStripMenuItem.Click

        Dim oForm As Find
        oForm = New Find()
        oForm.Show()

    End Sub

    Public Function ConvertMarkdownToHtml(markdownText As String, Optional useExtensions As Boolean = True) As String

        Try

            Dim unused = MsgBox("Menu Convert Markdown détecté !")

            ' Construire le pipeline avec ou sans extensions avancées
            Dim pipeline As MarkdownPipeline = If(useExtensions,
New MarkdownPipelineBuilder().UseAdvancedExtensions().Build(),
New MarkdownPipelineBuilder().Build())

            ' Convertir Markdown en HTML
            Return Markdown.ToHtml(markdownText, pipeline)

        Catch ex As Exception
            ' Gérer les erreurs et enregistrer dans un journal
            File.AppendAllText("error_log.txt", $"{Date.Now}: {ex.Message}{Environment.NewLine}")
            Return "<p>Une erreur s'est produite lors de la conversion Markdown vers HTML.</p>"
        End Try

    End Function

    Private Sub LisezmoiToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Read.WebBrowser1.Url = New Uri("https://www.prenommer.com")

        Read.Show()

        Dim markdownContent As String = "REMARQUE : Le référentiel est en construction. Il y aura un site Web dédié et une documentation appropriée à un moment donné !" & vbCrLf &
"# Prénommer" & vbCrLf &
"Juste une application pour choisir les prénoms de votre enfant." & vbCrLf & vbCrLf &
"![Logo](https://www.prenommer.com/wp-content/uploads/2023/09/prenommer3_5-preview.png)" & vbCrLf &
"## Caractéristiques" & vbCrLf &
"- Logiciel informatique Code source ouvert, gratuit et sans publicité." & vbCrLf &
"- Licence CC BY-SA 4.0 permet toute exploitation de l'œuvre (partager, copier, reproduire, distribuer, communiquer, réutiliser, adapter) par tous moyens et sous tous formats." & vbCrLf &
"- Libre redistribution, accès au code source et création de travaux dérivés." & vbCrLf & vbCrLf &
"![Logo](https://www.prenommer.com/wp-content/uploads/2023/09/utilisation-libre-cc-by-sa.png)" & vbCrLf & vbCrLf &
"- Ce(tte) œuvre est mise à disposition selon les termes de la Licence Creative Commons Attribution - Partage dans les Mêmes Conditions 4.0 International." & vbCrLf &
"## 🛠️ Installation" & vbCrLf &
"Exécuter l'application en tant qu’administrateur ! **IMPORTANT**." & vbCrLf & vbCrLf &
"Pour exécuter temporairement un programme en tant qu'administrateur, cliquez avec le bouton droit sur l'icône du bureau de l'application ou sur le fichier exécutable dans le dossier d'installation et sélectionnez Exécuter en tant qu'administrateur." & vbCrLf &
"## Liens" & vbCrLf &
"*   Tout mon projet est disponible sur [https://www.prenommer.com](https://www.prenommer.com)" & vbCrLf &
"*   Comment me joindre : _[prenommer@proton.me](mailto:prenommer@orange.fr)_" & vbCrLf &
"## 🍰 Contributeurs, Contributrices" & vbCrLf &
"Toutes les contributions que vous apportez sont **fortement appréciées**. Prénommer est un logiciel gratuit dont la rétribution est laissée à l'appréciation de l'utilisateur, utilisatrice." & vbCrLf &
"## ❤️ Support" & vbCrLf &
"Si vous vous sentez très enthousiasmé par ce projet, faites - le - moi savoir avec un commentaire sur le site de l'application." & vbCrLf &
"Si vous avez des questions, n'hésitez pas à me contacter à cette adresse mail _[prenommer@proton.me](mailto:prenommer@orange.fr)_" & vbCrLf &
"## 🙇 Auteur" & vbCrLf &
"#### C. BLET" & vbCrLf &
"- Github  [@urban-succotash](https://github.com/prenommer/urban-succotash)" & vbCrLf &
"## ➤ Licences" & vbCrLf &
"*   Built with Visual Studio Community 2022" & vbCrLf &
"*   Prénommer © 2023. — Creative Commons License BY-SA 4.0" & vbCrLf &
"*   Copyright © 2023 C. BLET « Ce logiciel utilise l'IA développée par Microsoft Copilot. »" & vbCrLf

        Dim htmlContent As String = ConvertMarkdownToHtml(markdownContent)

        Read.WebBrowser1.DocumentText = htmlContent

    End Sub

    Private Sub VoirSurGithubToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Try
            Dim unused = Process.Start("https://github.com/prenommer/urban-succotash/blob/main/README.md")

        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show("Impossible de charger la page Web." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click

        ' Créez un LinkLabel avec le texte du lien.
        Dim linkLabel1 As New LinkLabel With {
.Text = "CC BY-SA 4.0"
}
        linkLabel1.LinkArea = New LinkArea(0, linkLabel1.Text.Length) ' Rend tout le texte du LinkLabel cliquable.

        ' Gérez l'événement LinkClicked.
        AddHandler linkLabel1.LinkClicked, AddressOf LinkLabel1_Click

        ' Ajoutez le LinkLabel à votre RichTextBox.
        'RichTextBox2.Controls.Add(linkLabel1)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Try
            ' Précisez que le lien a été visité.
            LinkLabel1.LinkVisited = True

            ' Accédez à une URL.
            Dim unused = Process.Start("https://creativecommons.org/licenses/by-sa/4.0/deed.fr")

        Catch ex As Exception
            Dim unused1 = Forms.MessageBox.Show("Impossible de charger la page Web." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub ClearRecentFilesButton_Click(sender As Object, e As EventArgs) Handles ClearRecentFilesButton.Click

        ' Vérifiez si la collection des fichiers récents existe.
        If My.Settings.RecentFiles IsNot Nothing Then
            ' Effacez tous les éléments de la collection.
            My.Settings.RecentFiles?.Clear()

            ' Sauvegardez les changements.
            My.Settings.Save()
        End If

    End Sub

    ' Fonction pour rechercher le nœud du TreeView1 en fonction de la première lettre.
    Public Function FindNodeByFirstLetter(nodes As TreeNodeCollection, firstLetter As Char) As TreeNode

        For Each node As TreeNode In nodes
            If node.Text.Length > 0 AndAlso Char.ToUpper(node.Text(0)) = Char.ToUpper(firstLetter) Then
                Return node
            End If

            ' Rechercher récursivement dans les nœuds enfants.
            Dim foundNode As TreeNode = FindNodeByFirstLetter(node.Nodes, firstLetter)
            If foundNode IsNot Nothing Then
                Return foundNode
            End If
        Next

        ' Aucun nœud correspondant trouvé.
        Return Nothing

    End Function

    Private Sub HighlightItemByFirstLetter(firstLetter As String)

        ' Parcourir tous les éléments dans le ListView.
        For Each item As ListViewItem In ListView1.Items
            ' Récupérer le texte de l'élément.
            Dim itemText As String = item.Text

            ' Vérifier si le texte commence par la première lettre spécifiée.
            If itemText.StartsWith(firstLetter, StringComparison.OrdinalIgnoreCase) Then
                ' Appliquer une mise en forme à l'élément (par exemple, changer la couleur de fond).
                'item.BackColor = System.Drawing.Color.Yellow
                item.Selected = True
                item.EnsureVisible()

                ListeToolStripButton.PerformClick()

            Else
                ' Remettre la mise en forme à la normale pour les autres éléments.
                item.BackColor = System.Drawing.SystemColors.Control    'Window
            End If

        Next

    End Sub

    Public Sub UpdateFileList()

        For Each filePath As String In CreatedFiles
            Dim fileName As String = System.IO.Path.GetFileName(filePath)
            Dim icon As Icon = ExtractIconFromFile(filePath)

            If icon IsNot Nothing Then
                ImageList1.Images.Add(icon.ToBitmap())
                Dim item As New ListViewItem(fileName) With {
        .ImageIndex = ImageList1.Images.Count - 1
    }
                Dim unused = ListView1.Items.Add(item)

                ' Après avoir créé un nouveau fichier.
                SetFileIconAssociation(".librairie", "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Registre\librairie.ico", 0)

                icon.Dispose()

            Else
                ' Si vous ne pouvez pas obtenir l'icône, ajoutez simplement l'élément sans image.
                Dim unused1 = ListView1.Items.Add(fileName)

            End If

        Next

        ' Forcer le rafraîchissement du ListView.
        ListView1.Refresh()

        Create.CreateLibrairieFileList()

    End Sub

    ' Fonction pour obtenir l'icône associée à un fichier.
    Private Function GetFileIcon(filePath As String) As Icon

        Try
            ' SHGetFileInfo nécessite une structure SHFILEINFO pour stocker les informations.
            Dim shinfo As New SHFILEINFO()

            ' Obtenir l'icône associée au fichier.
            Dim flags As UInteger = SHGFI_ICON Or SHGFI_SMALLICON Or SHGFI_USEFILEATTRIBUTES
            Dim unused = SHGetFileInfo(filePath, 0, shinfo, CUInt(Marshal.SizeOf(shinfo)), flags)

            ' Convertir le handle d'icône en objet Icon.
            Dim icon As Icon = Icon.FromHandle(shinfo.hIcon)

            Return icon

        Catch ex As Exception
            ' Gérer l'exception ici (par exemple, l'icône n'a pas pu être obtenue).
            Return Nothing
        End Try

    End Function

    'Fonction pour extraire l'icône associée à un fichier en utilisant l'association par extension.
    Public Function ExtractIconFromFile(filePath As String) As Icon

        Dim extension As String = System.IO.Path.GetExtension(filePath)
        Dim keyName As String = $"Software\Classes\.librairie\DefaultIcon"
        Dim defaultValue As String = ""

        ' Ouvrir la clé du Registre.
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(keyName)
            If key IsNot Nothing Then
                ' Lire la valeur de l'icône par défaut.
                Dim iconPath As String = DirectCast(key.GetValue(Nothing, defaultValue), String)

                If Not String.IsNullOrEmpty(iconPath) Then
                    ' Créer une icône à partir du chemin spécifié.
                    Return New Icon(iconPath)
                End If
            End If
        End Using

        ' Si l'extraction échoue, retourner Nothing.
        Return Nothing

    End Function

    Public Sub SetFileIconAssociation(extension As String, iconPath As String, iconIndex As Integer)

        Dim keyName As String = $"Software\Classes\.librairie\DefaultIcon"

        Using key As RegistryKey = Registry.CurrentUser.CreateSubKey(keyName)
            key.SetValue("", $"{iconPath},{iconIndex}")
        End Using

    End Sub

    Public Sub UpdateForm()

        ' Réinitialisez ou mettez à jour tous les éléments nécessaires.
        ' Par exemple, vous pouvez appeler des fonctions de mise à jour pour différents composants, ListView, etc.
        UpdateFileList() ' Une fonction que vous auriez pour mettre à jour la liste des fichiers.
        ' ... Ajoutez d'autres mises à jour si nécessaire.

    End Sub

    Private Sub RegistryFunction()

        Dim regKey As RegistryKey = Nothing

        Try

            ' Ouverture de la clé du registre.
            regKey = Registry.CurrentUser.OpenSubKey("Prenommer.librairie", True)

            ' Opérations sur le registre.
            Dim extensionKey As String = ".librairie"
            Dim keyPath As String = extensionKey & "\shell\open\command"
            Dim icotouse As String = $"{My.Application.Info.DirectoryPath}\Registre\librairie.ico"

            ' Vérifiez si l'extension est déjà associée à votre application.
            If Registry.ClassesRoot.OpenSubKey(extensionKey) Is Nothing Then
                ' Si ce n'est pas le cas, associez l'extension .librairie à votre application.
                Registry.ClassesRoot.CreateSubKey(extensionKey).SetValue("", "Prenommer", RegistryValueKind.String)
            End If

            ' Associez le chemin d'exécution de votre application aux fichiers .librairie.
            Dim executablePath As String = Forms.Application.ExecutablePath ' Remplacez par le chemin complet de votre exécutable.
            Registry.ClassesRoot.CreateSubKey(keyPath).SetValue("", $" ""{executablePath}"" ""%1"" ", RegistryValueKind.String)

            ' Associez le chemin de l'icône par défaut à votre extension .librairie.
            Registry.ClassesRoot.CreateSubKey(extensionKey & "\DefaultIcon").SetValue("", icotouse, RegistryValueKind.String)

            ' Sauvegarde du registre (exemple).
            BackupRegistry()

            ' Si une exception spécifique au registre peut se produire, ajoutez un bloc Catch pour cette exception.

        Catch secEx As System.Security.SecurityException
            ' Gérer l'exception de sécurité ici.
            Dim unused1 = Forms.MessageBox.Show(secEx.ToString())
        Catch uaEx As UnauthorizedAccessException
            ' Gérer l'exception d'accès non autorisé ici.
            Dim unused2 = Forms.MessageBox.Show(uaEx.ToString())
        Catch ex As Exception
            ' Gérer les autres exceptions ici.
            Dim unused = Forms.MessageBox.Show(ex.ToString())
        Finally
            ' Fermer la clé du registre dans tous les cas.
            regKey?.Close()
        End Try

    End Sub

    Private Sub BackupRegistry()

        ' Créer la clé OpenWithProgids sous la clé .librairie
        Dim librairieKey As RegistryKey = Registry.ClassesRoot.OpenSubKey(".librairie", True)
        If librairieKey IsNot Nothing Then
            Dim openWithProgidsKey As RegistryKey = librairieKey.CreateSubKey("OpenWithProgids")
            openWithProgidsKey.SetValue("Prenommer.librairie", "")
            openWithProgidsKey.Close()
            librairieKey.Close()
        End If

        ' Obtenir le chemin du répertoire d'installation final
        'Dim installDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Prenommer")
        'Dim installDir As String = $"{My.Application.Info.DirectoryPath}\Registre\Prenommer.reg"
        Dim regFilePath As String = $"{My.Application.Info.DirectoryPath}\Registre\Prenommer.reg"
        'Dim regFilePath As String = Path.Combine(installDir, "Registre\Prenommer.reg")F
        Dim regKeyPath As String = "HKEY_CLASSES_ROOT\.librairie"

        ' Supprimer le fichier existant s'il existe déjà pour créer une nouvelle sauvegarde
        If Computer.FileSystem.FileExists(regFilePath) Then
            Try
                Computer.FileSystem.DeleteFile(regFilePath)
            Catch ex As Exception
                Dim unused = Forms.MessageBox.Show("Erreur lors de la suppression du fichier existant :  " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If

        Try
            ' Créer un nouveau processus pour exécuter la commande regedit
            Using proc As New Process()
                proc.StartInfo.FileName = "regedit.exe"
                proc.StartInfo.Arguments = $"/e ""{regFilePath}"" ""{regKeyPath}"""
                proc.StartInfo.UseShellExecute = True ' Changer cette ligne
                Dim unused1 = proc.Start()

                ' Attendre que le processus se termine
                proc.WaitForExit()
            End Using
        Catch ex As FileNotFoundException
            ' Gérer l'exception FileNotFoundException spécifiquement
            Dim unused2 = Forms.MessageBox.Show("Fichier ou assembly introuvable : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Gérer toute autre exception ici
            Dim unused2 = Forms.MessageBox.Show("Erreur lors de la sauvegarde du registre : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub CréerunfichierhtmlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréerunfichierhtmlToolStripMenuItem.Click

        Dim filePathOFD = String.Empty
        Dim myTelechargements As String = My.Application.Info.DirectoryPath & "\Téléchargements"

        Using OpenFileDialog1 As New Forms.OpenFileDialog With {
.InitialDirectory = My.Application.Info.DirectoryPath & "\Téléchargements",
.Filter = "Document Word (*.docx)|*.docx|Tous les fichiers (*.*)|*.*",
.FilterIndex = 1,
.RestoreDirectory = True,
.Multiselect = False
}

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

                ' Obtenir le chemin du fichier spécifié.
                filePathOFD = OpenFileDialog1.FileName

                Try
                    ' Lire le contenu du fichier dans un flux.
                    Using fileStream As FileStream = CType(OpenFileDialog1.OpenFile(), FileStream)
                        Using reader As New StreamReader(fileStream)
                            Dim fileContent As String = reader.ReadToEnd()
                            ' Faites quelque chose avec le contenu du fichier si nécessaire.
                        End Using
                    End Using
                Catch ex As Exception
                    Dim unused = Forms.MessageBox.Show("Impossible de lire le fichier à partir du disque. Erreur d'origine : " & ex.Message)
                    Return
                End Try

            Else
                Return
            End If

        End Using

        ' Convertir le fichier si le dialogue est fermé avec OK.
        ConvertToHtml(filePathOFD, myTelechargements)

    End Sub

    Private Sub EffacerFichiersRecents_Click(sender As Object, e As EventArgs)

        ' Vérifier si le menu Effacer fichiers récents n'a pas déjà été ajouté
        If EffacerFichiersRecentsMenuItem.DropDownItems.ContainsKey("EffacerFichiersRecentsMenuItem") Then
            ' Le menu Effacer fichiers récents a déjà été ajouté, sortir de la méthode
            Return
        End If

        ' Ajouter un séparateur sous le menu Fichiers récents
        Dim unused = EffacerFichiersRecentsMenuItem.DropDownItems.Add(New ToolStripSeparator())

        ' Ajouter le menu Effacer fichiers récents
        Using EffacerFichiersRecentsMenuItem As New ToolStripMenuItem("Effacer fichiers récents") With {
.Name = "EffacerFichiersRecentsMenuItem"
}
            AddHandler EffacerFichiersRecentsMenuItem.Click, AddressOf EffacerFichiersRecentsMenuItem_Click
            Dim unused1 = EffacerFichiersRecentsMenuItem.DropDownItems.Add(EffacerFichiersRecentsMenuItem)

        End Using

    End Sub

    ' Gestionnaire d'événements pour le clic sur EffacerFichiersRecentsMenuItem
    Private Sub EffacerFichiersRecentsMenuItem_Click(sender As Object, e As EventArgs)

        EffacerFichiersRecents()

    End Sub

    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        ' Vérifiez si Ctrl + Suppr est enfoncé
        If e.Control AndAlso e.KeyCode = Forms.Keys.Delete Then
            ' Exécutez le code pour effacer les fichiers récents
            EffacerFichiersRecents()
        End If

    End Sub

    ' Gestionnaire d'événements pour le clic sur EffacerFichiersRecentsMenuItem.
    Private Sub EffacerFichiersRecents()

        ' Code pour effacer les fichiers récents.
        Using writer As New StreamWriter($"{My.Application.Info.DirectoryPath}\Resources\Recent.txt", False)
            ' Le fichier est ouvert avec un StreamWriter qui va écrire dans le fichier.
            ' La deuxième valeur False spécifie que le contenu actuel du fichier doit être effacé.
        End Using

        ' Vous pouvez utiliser My.Settings.RecentFiles.Clear() pour effacer la collection des fichiers récents.
        My.Settings.RecentFiles.Clear()

        ' Sauvegardez les changements.
        My.Settings.Save()

        ' Mettez à jour l'interface utilisateur pour refléter les changements, si nécessaire.
        SetupRecentFilesMenu()

    End Sub

    Private AcroPath As String = $"{My.Application.Info.DirectoryPath}\Aide\CC BY-SA 4.0 DEED.pdf"
    Private directoryPath As String
    Private subst As String

    Private Shared HtmlSettings As WmlToHtmlConverterSettings
    Private arguments As String
    Private outputHtml As String

    Private Sub CreativeCommonsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreativeCommonsToolStripMenuItem.Click

        If Computer.FileSystem.FileExists(AcroPath) Then
            Try
                Dim unused4 = Process.Start("acrobat", AcroPath)
            Catch ex As Exception
                Try
                    Dim unused1 = Process.Start("AcroRd32", AcroPath)
                Catch ex2 As Exception
                    Try
                        Dim unused2 = Process.Start(AcroPath)
                    Catch ex3 As Exception
                        Dim unused3 = Forms.MessageBox.Show("Installer Acrobat Reader")
                    End Try
                End Try
            End Try
        Else
            Dim unused = Forms.MessageBox.Show("Fichier introuvable.")
        End If

    End Sub

    Public Sub ClearTextBoxesAndAttributes(textboxes As IEnumerable(Of UI.WebControls.TextBox))

        For Each t As UI.WebControls.TextBox In textboxes
            t.Attributes.Clear() ' Supprimer les attributs
            t.Text = String.Empty ' Effacer le texte
        Next

    End Sub

    Public Sub ClearTextAttributes(textboxes As IEnumerable(Of UI.WebControls.TextBox))

        For Each t As UI.WebControls.TextBox In textboxes
            ' Vider la collection d'attributs
            t.Attributes.Clear()
        Next

    End Sub

    ' Fonction pour obtenir l'index d'un nœud
    Private Function GetNodeIndex(treeNode As TreeNode) As Integer

        Return treeNode.Index

    End Function

    Public Function FindNodeByText(nodes As TreeNodeCollection, text As String) As TreeNode

        For Each node As TreeNode In nodes
            Debug.Print("Vérification du nœud : " & node.Text)
            If node.Text = text Then
                Return node
            End If
            ' Recherche récursive dans les nœuds enfants
            Dim found = FindNodeByText(node.Nodes, text)
            If found IsNot Nothing Then
                Return found
            End If
        Next
        Return Nothing

    End Function

    Private Function FindNodeRecursive(node As TreeNode, text As String) As TreeNode

        If node.Text = text Then
            Return node
        End If
        For Each childNode As TreeNode In node.Nodes
            Dim foundNode As TreeNode = FindNodeRecursive(childNode, text)
            If foundNode IsNot Nothing Then
                Return foundNode
            End If
        Next
        Return Nothing

    End Function

    Public Shared Function SearchAllTreeNodes(parentNode As TreeNode, match As Func(Of TreeNode, Boolean)) As TreeNode

        If match(parentNode) Then
            Return parentNode
        End If

        For Each childNode As TreeNode In parentNode.Nodes
            Dim foundNode As TreeNode = SearchAllTreeNodes(childNode, match)
            If foundNode IsNot Nothing Then
                Return foundNode
            End If
        Next

        Return Nothing

    End Function

    Private Sub AfficherBiographie(selectedNode As TreeNode)

        If selectedNode IsNot Nothing Then
            ' Mise à jour du texte de TextBox31 avec la biographie liée au nœud sélectionné
            TextBox31.Text = selectedNode.Text     '"Biographie de : " & selectedNode.Text
        Else
            TextBox31.Text = "Aucun nœud sélectionné."
        End If

    End Sub

    ' Méthode pour sélectionner un nœud spécifique (par exemple, lors de la création ou de la modification)
    Public Sub SelectionnerNoeudParTexte(texteRecherche As String)

        ' Fonction récursive pour rechercher un nœud par texte
        RechercherEtSelectionnerNoeud(TreeView1.Nodes, texteRecherche)

    End Sub

    Private Sub RechercherEtSelectionnerNoeud(parentNodes As TreeNodeCollection, texteRecherche As String)

        For Each NodX As TreeNode In parentNodes
            If NodX.Text = texteRecherche Then
                TreeView1.SelectedNode = NodX ' Sélection du nœud correspondant
                Dim unused = TreeView1.Focus()            ' Mise au focus
                Exit Sub                     ' Arrête la recherche dès qu'on trouve
            End If

            ' Recherche dans les enfants du nœud actuel
            If NodX.Nodes.Count > 0 Then
                RechercherEtSelectionnerNoeud(NodX.Nodes, texteRecherche)
            End If
        Next

    End Sub

    Public Shared Function GetAppVersion() As String

        Dim versionInfo As System.Version = Reflection.Assembly.GetExecutingAssembly().GetName().Version
        Dim version As String = $"{versionInfo.Major}.{versionInfo.Minor}.{versionInfo.Build}.{versionInfo.Revision}"

        ' Si une version RC est utilisée, l'ajouter au numéro de version
        If Not String.IsNullOrEmpty(VERSION_RC) Then
            version &= $"-{VERSION_RC}"
        End If

        Return version

    End Function

    Private Function IsFileLocked(filePath As String) As Boolean

        Try
            Using fs As FileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None)
            End Using
            Return False ' Le fichier n'est pas verrouillé
        Catch ex As IOException
            Return True ' Le fichier est verrouillé
        End Try

    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        If TypeOf ActiveControl Is Forms.TextBox Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

        Select Case keyData
            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right
                If keyData = Forms.Keys.Up Then
                    ToolStripButton2.PerformClick()
                ElseIf keyData = Forms.Keys.Down Then
                    ToolStripButton3.PerformClick()
                End If
                Return True
            Case Keys.KeyCode
                Exit Select
            Case Keys.Modifiers
                Exit Select
            Case Keys.None
                Exit Select
            Case Keys.LButton
                Exit Select
            Case Keys.RButton
                Exit Select
            Case Keys.Cancel
                Exit Select
            Case Keys.MButton
                Exit Select
            Case Keys.XButton1
                Exit Select
            Case Keys.XButton2
                Exit Select
            Case Keys.Back
                Exit Select
            Case Keys.Tab
                Exit Select
            Case Keys.LineFeed
                Exit Select
            Case Keys.Clear
                Exit Select
            Case Keys.Return
                Exit Select
            Case Keys.ShiftKey
                Exit Select
            Case Keys.ControlKey
                Exit Select
            Case Keys.Menu
                Exit Select
            Case Keys.Pause
                Exit Select
            Case Keys.Capital
                Exit Select
            Case Keys.KanaMode
                Exit Select
            Case Keys.JunjaMode
                Exit Select
            Case Keys.FinalMode
                Exit Select
            Case Keys.HanjaMode
                Exit Select
            Case Keys.Escape
                Exit Select
            Case Keys.IMEConvert
                Exit Select
            Case Keys.IMENonconvert
                Exit Select
            Case Keys.IMEAccept
                Exit Select
            Case Keys.IMEModeChange
                Exit Select
            Case Keys.Space
                Exit Select
            Case Keys.Prior
                Exit Select
            Case Keys.Next
                Exit Select
            Case Keys.End
                Exit Select
            Case Keys.Home
                Exit Select
            Case Keys.Select
                Exit Select
            Case Keys.Print
                Exit Select
            Case Keys.Execute
                Exit Select
            Case Keys.Snapshot
                Exit Select
            Case Keys.Insert
                Exit Select
            Case Keys.Delete
                Exit Select
            Case Keys.Help
                Exit Select
            Case Keys.D0
                Exit Select
            Case Keys.D1
                Exit Select
            Case Keys.D2
                Exit Select
            Case Keys.D3
                Exit Select
            Case Keys.D4
                Exit Select
            Case Keys.D5
                Exit Select
            Case Keys.D6
                Exit Select
            Case Keys.D7
                Exit Select
            Case Keys.D8
                Exit Select
            Case Keys.D9
                Exit Select
            Case Keys.A
                Exit Select
            Case Keys.B
                Exit Select
            Case Keys.C
                Exit Select
            Case Keys.D
                Exit Select
            Case Keys.E
                Exit Select
            Case Keys.F
                Exit Select
            Case Keys.G
                Exit Select
            Case Keys.H
                Exit Select
            Case Keys.I
                Exit Select
            Case Keys.J
                Exit Select
            Case Keys.K
                Exit Select
            Case Keys.L
                Exit Select
            Case Keys.M
                Exit Select
            Case Keys.N
                Exit Select
            Case Keys.O
                Exit Select
            Case Keys.P
                Exit Select
            Case Keys.Q
                Exit Select
            Case Keys.R
                Exit Select
            Case Keys.S
                Exit Select
            Case Keys.T
                Exit Select
            Case Keys.U
                Exit Select
            Case Keys.V
                Exit Select
            Case Keys.W
                Exit Select
            Case Keys.X
                Exit Select
            Case Keys.Y
                Exit Select
            Case Keys.Z
                Exit Select
            Case Keys.LWin
                Exit Select
            Case Keys.RWin
                Exit Select
            Case Keys.Apps
                Exit Select
            Case Keys.Sleep
                Exit Select
            Case Keys.NumPad0
                Exit Select
            Case Keys.NumPad1
                Exit Select
            Case Keys.NumPad2
                Exit Select
            Case Keys.NumPad3
                Exit Select
            Case Keys.NumPad4
                Exit Select
            Case Keys.NumPad5
                Exit Select
            Case Keys.NumPad6
                Exit Select
            Case Keys.NumPad7
                Exit Select
            Case Keys.NumPad8
                Exit Select
            Case Keys.NumPad9
                Exit Select
            Case Keys.Multiply
                Exit Select
            Case Keys.Add
                Exit Select
            Case Keys.Separator
                Exit Select
            Case Keys.Subtract
                Exit Select
            Case Keys.Decimal
                Exit Select
            Case Keys.Divide
                Exit Select
            Case Keys.F1
                Exit Select
            Case Keys.F2
                Exit Select
            Case Keys.F3
                Exit Select
            Case Keys.F4
                Exit Select
            Case Keys.F5
                Exit Select
            Case Keys.F6
                Exit Select
            Case Keys.F7
                Exit Select
            Case Keys.F8
                Exit Select
            Case Keys.F9
                Exit Select
            Case Keys.F10
                Exit Select
            Case Keys.F11
                Exit Select
            Case Keys.F12
                Exit Select
            Case Keys.F13
                Exit Select
            Case Keys.F14
                Exit Select
            Case Keys.F15
                Exit Select
            Case Keys.F16
                Exit Select
            Case Keys.F17
                Exit Select
            Case Keys.F18
                Exit Select
            Case Keys.F19
                Exit Select
            Case Keys.F20
                Exit Select
            Case Keys.F21
                Exit Select
            Case Keys.F22
                Exit Select
            Case Keys.F23
                Exit Select
            Case Keys.F24
                Exit Select
            Case Keys.NumLock
                Exit Select
            Case Keys.Scroll
                Exit Select
            Case Keys.LShiftKey
                Exit Select
            Case Keys.RShiftKey
                Exit Select
            Case Keys.LControlKey
                Exit Select
            Case Keys.RControlKey
                Exit Select
            Case Keys.LMenu
                Exit Select
            Case Keys.RMenu
                Exit Select
            Case Keys.BrowserBack
                Exit Select
            Case Keys.BrowserForward
                Exit Select
            Case Keys.BrowserRefresh
                Exit Select
            Case Keys.BrowserStop
                Exit Select
            Case Keys.BrowserSearch
                Exit Select
            Case Keys.BrowserFavorites
                Exit Select
            Case Keys.BrowserHome
                Exit Select
            Case Keys.VolumeMute
                Exit Select
            Case Keys.VolumeDown
                Exit Select
            Case Keys.VolumeUp
                Exit Select
            Case Keys.MediaNextTrack
                Exit Select
            Case Keys.MediaPreviousTrack
                Exit Select
            Case Keys.MediaStop
                Exit Select
            Case Keys.MediaPlayPause
                Exit Select
            Case Keys.LaunchMail
                Exit Select
            Case Keys.SelectMedia
                Exit Select
            Case Keys.LaunchApplication1
                Exit Select
            Case Keys.LaunchApplication2
                Exit Select
            Case Keys.OemSemicolon
                Exit Select
            Case Keys.Oemplus
                Exit Select
            Case Keys.Oemcomma
                Exit Select
            Case Keys.OemMinus
                Exit Select
            Case Keys.OemPeriod
                Exit Select
            Case Keys.OemQuestion
                Exit Select
            Case Keys.Oemtilde
                Exit Select
            Case Keys.OemOpenBrackets
                Exit Select
            Case Keys.OemPipe
                Exit Select
            Case Keys.OemCloseBrackets
                Exit Select
            Case Keys.OemQuotes
                Exit Select
            Case Keys.Oem8
                Exit Select
            Case Keys.OemBackslash
                Exit Select
            Case Keys.ProcessKey
                Exit Select
            Case Keys.Packet
                Exit Select
            Case Keys.Attn
                Exit Select
            Case Keys.Crsel
                Exit Select
            Case Keys.Exsel
                Exit Select
            Case Keys.EraseEof
                Exit Select
            Case Keys.Play
                Exit Select
            Case Keys.Zoom
                Exit Select
            Case Keys.NoName
                Exit Select
            Case Keys.Pa1
                Exit Select
            Case Keys.OemClear
                Exit Select
            Case Keys.Shift
                Exit Select
            Case Keys.Control
                Exit Select
            Case Keys.Alt
                Exit Select
            Case Else
                Return False
        End Select

        Return False  ' Ajouté pour couvrir tous les cas

    End Function

    Private Sub CréerUnDocumentAuFormatOOXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CréerUnDocumentAuFormatOOXMLToolStripMenuItem.Click

        If TreeView1.Nodes.Count = 0 OrElse String.IsNullOrEmpty(TextBox1.Text) Then
            Dim unused = Forms.MessageBox.Show("Veuillez sélectionner un élément d'une librairie pour créer un document.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim fileNameWithoutExtension As String = System.IO.Path.GetFileNameWithoutExtension(TextBox33.Text)
            Dim imagePath As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Images\" & subst & "\" & fileNameWithoutExtension

            Cursor = Cursors.WaitCursor

            ' Construire le chemin du fichier avec un titre concaténé
            Dim folderPath As String = "C:\Prenommer\Prenommer\Prenommer\bin\Debug\Téléchargements\"
            If Not Directory.Exists(folderPath) Then
                Dim unused4 = Directory.CreateDirectory(folderPath)
            End If
            Dim title As String = $"{TextBox2.Text} {TextBox1.Text}.docx"
            Dim fullFilePath As String = System.IO.Path.Combine(folderPath, title)

            ' Créer le document OOXML
            Using package As WordprocessingDocument = WordprocessingDocument.Create(fullFilePath, WordprocessingDocumentType.Document)
                Dim mainPart = package.AddMainDocumentPart()
                mainPart.Document = New Document(New Body())

                Dim body As Body = mainPart.Document.Body

                ' Ajouter la première ligne concaténée (titre) avec des propriétés spécifiques
                Dim titleLine As String = $"{TextBox2.Text} {TextBox1.Text}"
                Dim titleRun As New Run(New Text(titleLine))

                ' Définir les propriétés de la police pour la première ligne (titre)
                Dim rPr As New RunProperties With {
    .RunFonts = New RunFonts() With {.Ascii = "Calibri", .HighAnsi = "Calibri"} ' Police Calibri
    }
                rPr.Append(New FontSize() With {.Val = "48"}) ' 24 points en WordprocessingML
                Dim unused3 = titleRun.PrependChild(rPr)

                ' Ajouter le titre avec ses propriétés au document
                Dim titleParagraph As New Paragraph(titleRun)
                body.Append(titleParagraph)

                ' Ajouter un paragraphe vide pour espacer
                body.Append(New Paragraph(New Run(New Text(""))))

                ' Ajouter le contenu provenant des autres TextBox avec des espaces entre les paragraphes
                Dim textBoxes = {TextBox4, TextBox15, TextBox5, TextBox7, TextBox9, TextBox13, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox33, TextBox31}

                For Each txtBox In textBoxes
                    If txtBox IsNot Nothing Then
                        ' Créer un paragraphe
                        Dim paragraph As New Paragraph()

                        If Not String.IsNullOrEmpty(txtBox.Text) Then
                            ' Ajouter le contenu de la TextBox si elle contient du texte
                            Dim contentRun As New Run(New Text(txtBox.Text))
                            Dim contentRPr As New RunProperties With {
                .RunFonts = New RunFonts() With {.Ascii = "Calibri", .HighAnsi = "Calibri"}
            }
                            contentRPr.Append(New FontSize() With {.Val = "24"}) ' 12 points en WordprocessingML
                            Dim unused2 = contentRun.PrependChild(contentRPr)
                            paragraph.Append(contentRun)
                        End If

                        ' Ajouter les propriétés de paragraphe (espacement entre les lignes)
                        Dim paragraphProperties As New ParagraphProperties With {
            .SpacingBetweenLines = New SpacingBetweenLines() With {.After = "200", .LineRule = LineSpacingRuleValues.Auto}
        }
                        Dim unused1 = paragraph.PrependChild(paragraphProperties)

                        ' Ajouter le paragraphe au corps du document
                        body.Append(paragraph)
                    End If
                Next

                ' Ajouter un pied de page

                Dim FooterPart = mainPart.AddNewPart(Of FooterPart)()
                FooterPart.Footer = New Footer(New Paragraph(New Run(New Text($"Prénommer - {Date.Now:dd-MM-yyyy}"))))
                Dim sectionProps = body.Descendants(Of SectionProperties).FirstOrDefault()
                If sectionProps Is Nothing Then
                    sectionProps = New SectionProperties()
                    body.Append(sectionProps)
                End If
                Dim footerRef = New FooterReference() With {.Type = HeaderFooterValues.Default, .Id = mainPart.GetIdOfPart(FooterPart)}
                sectionProps.Append(footerRef)

                ' Enregistrer les modifications
                mainPart.Document.Save()
            End Using

            Dim unused7 = Forms.MessageBox.Show($"Document créé avec succès : {fullFilePath}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Dim unused5 = Forms.MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Function ConvertWebpToPng(webpPath As String) As String

        Dim pngPath As String = System.IO.Path.ChangeExtension(webpPath, ".png")
        FreeImageInterop.FreeImage_Initialise(False)

        Try
            ' Charger l'image WebP
            Dim dib As IntPtr = FreeImageInterop.FreeImage_Load(FreeImageInterop.FIF_WEBP, webpPath, 0)
            If dib = IntPtr.Zero Then
                Throw New Exception("Impossible de charger le fichier WebP.")
            End If

            ' Enregistrer en PNG
            If Not FreeImageInterop.FreeImage_Save(FreeImageInterop.FIF_PNG, dib, pngPath, 0) Then
                Throw New Exception("Impossible d'enregistrer le fichier PNG.")
            End If

            ' Libérer les ressources
            FreeImageInterop.FreeImage_Unload(dib)
        Catch ex As Exception
            Throw New Exception($"Erreur lors de la conversion : {ex.Message}")
        Finally
            FreeImageInterop.FreeImage_DeInitialise()
        End Try

        Return pngPath

    End Function

    Public Sub AnalyserFichierLibrairie(cheminFichier As String)

        Dim lignesVides As Integer = 0

        Using parser As New TextFieldParser(cheminFichier, Encoding.UTF8)
            parser.TextFieldType = FieldType.FixedWidth
            parser.SetFieldWidths(18, 90, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 1200, 120, 200)

            While Not parser.EndOfData
                Try
                    Dim fields As String() = parser.ReadFields()
                    ' Traitez chaque champ ici
                    Console.WriteLine($"Champ 1 {fields(0)}, Champ 2: {fields(1)}, Champ 3: {fields(2)}, Champ 4: {fields(3)}, Champ 5: {fields(4)}, Champ 6: {fields(5)}, Champ 7 : {fields(6)}, Champ 8: {fields(7)}, Champ 9: {fields(8)}, Champ 10: {fields(9)}, Champ 11: {fields(10)}, Champ 12: {fields(11)}, Champ 13: {fields(12)}, Champ 14: {fields(13)}, Champ 15: {fields(14)}, Champ 16: {fields(15)}, Champ 17: {fields(16)}")

                    ' Vérifiez si la ligne est vide
                    If fields.All(Function(field) String.IsNullOrWhiteSpace(field)) Then
                        lignesVides += 1
                    Else
                        lignesVides = 0 ' Réinitialisez le compteur si une ligne non vide est rencontrée
                    End If

                Catch ex As MalformedLineException
                    Console.WriteLine($"Ligne mal formée à {parser.LineNumber} {ex.Message}")
                End Try
            End While
        End Using

        ' Lancez une exception si plus d'une ligne vide est trouvée
        If lignesVides > 1 Then
            Throw New Exception("Le fichier contient plus d'une ligne vide à la fin.")
        End If

    End Sub

    Private WithEvents OpenFileButton As ToolStripMenuItem
    Private imagePath As String

    Private Sub OpenFileButton_Click(sender As Object, e As EventArgs) Handles OpenFileButton.Click

        ' Contrôle de l'ouverture de la boîte de dialogue de fichier
        Dim openFileDialog As New Forms.OpenFileDialog()
        Try
            openFileDialog.Filter = "Fichiers Texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*"
            openFileDialog.Title = "Sélectionnez un fichier de librairie"

            If CType(openFileDialog.ShowDialog(), Global.System.Windows.Forms.DialogResult) = DialogResult.OK Then
                ' Appel de la méthode pour analyser le fichier de librairie
                AnalyserFichierLibrairie(openFileDialog.FileName)
            End If
        Finally
            ' Libérer explicitement la ressource si nécessaire
            openFileDialog.DisposeIfDisposable()
        End Try

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        Debug.Print("AfterSelect déclenché pour : " & e.Node.Text)

        'TreeView1_NodeMouseClick(sender, New TreeNodeMouseClickEventArgs(e.Node, MouseButtons.Left, 0, 0, 0))

        ' Vérifiez si un nœud est sélectionné
        If TreeView1.SelectedNode IsNot Nothing Then
            ' Réinitialiser les couleurs de tous les nœuds avant de surligner
            ResetNodeColors(TreeView1.Nodes)

            ' Appliquer une surbrillance jaune au nœud sélectionné
            TreeView1.SelectedNode.BackColor = System.Drawing.Color.Yellow
            TreeView1.SelectedNode.ForeColor = System.Drawing.Color.Black

            ' Si le nœud sélectionné a des enfants, effectuer le tri
            If TreeView1.SelectedNode.Nodes.Count > 0 Then
                ' Trier les enfants par texte
                Dim sortedNodes = TreeView1.SelectedNode.Nodes.Cast(Of TreeNode).OrderBy(Function(n) n.Text).ToList()

                ' Sélectionner le premier nœud trié
                If sortedNodes.Count > 0 Then
                    TreeView1.SelectedNode = sortedNodes(0)
                    TreeView1.SelectedNode.BackColor = System.Drawing.Color.Yellow
                    TreeView1.SelectedNode.ForeColor = System.Drawing.Color.Black
                End If
            End If
        End If

        'Forms.MessageBox.Show("Nœud sélectionné : " & e.Node.Text) ' Vérifie si l'événement se déclenche

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Dim firstNode As TreeNode
        firstNode = TreeView1.Nodes(0).Nodes(0) ' Premier nœud enfant

        If Not firstNode.IsVisible Then
            TreeView1.SelectedNode = firstNode
            firstNode.BackColor = System.Drawing.Color.Yellow
        End If

        If TreeView1.SelectedNode Is Nothing Then Exit Sub

        If firstNode IsNot Nothing Then
            TreeView1.SelectedNode = firstNode

            Dim bibliotheque As New Article
            Dim NombreDeLignes As Integer

            If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Return

            If ListView1.SelectedItems.Count > 0 Then

                NombreDeLignes = ListView1.SelectedIndices(0)
                OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

                For i As Integer = 0 To ListBox2.Items.Count - 1
                    Foo = TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Text
                    If ListBox2.Items(i).ToString = Foo Then
                        Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                        FileOne = monfichier(i).ToString
                    End If
                Next

                Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                Dim s As String
                For Each s In readTexte
                    If s.Contains(TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Text) And s.Equals(value:=FileOne.ToString) Then
                        TextBox2.Text = Trim(Mid(s, 1, 18))
                        TextBox1.Text = Trim(Mid(s, 19, 90))
                        TextBox4.Text = Trim(Mid(s, 109, 120))
                        TextBox15.Text = Trim(Mid(s, 229, 120))
                        TextBox5.Text = Trim(Mid(s, 349, 120))
                        TextBox7.Text = Trim(Mid(s, 469, 120))
                        TextBox9.Text = Trim(Mid(s, 589, 120))
                        TextBox13.Text = Trim(Mid(s, 709, 120))
                        TextBox18.Text = Trim(Mid(s, 829, 120))
                        TextBox23.Text = Trim(Mid(s, 949, 120))
                        TextBox24.Text = Trim(Mid(s, 1069, 120))
                        TextBox25.Text = Trim(Mid(s, 1189, 120))
                        TextBox26.Text = Trim(Mid(s, 1309, 120))
                        TextBox28.Text = Trim(Mid(s, 1429, 120))
                        TextBox29.Text = Trim(Mid(s, 1549, 120))
                        TextBox33.Text = Trim(Mid(s, 1669, 120))
                        TextBox31.Text = Trim(Mid(s, 1789, 1200))
                        RichTextBox1.Text = Trim(Mid(s, 2989, 200))
                        Exit For
                    End If
                Next

                If TextBox33.Text = "" Then
                    PictureBox1.Image = Image_16x_1
                Else
                    Dim literal As String = TextBox33.Text
                    Dim subst As String = literal.Substring(0, 1)
                    PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                    Dim id As String = TextBox33.Text
                    Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                    Dim filename As String = System.IO.Path.Combine(folder, id)
                    Try
                        Using fs As New FileStream(filename, FileMode.Open)
                            PictureBox1.Image = New Bitmap(System.Drawing.Image.FromStream(fs))
                        End Using
                    Catch ex As Exception
                        Dim msg As String = "Filename: " & filename &
                Environment.NewLine & Environment.NewLine &
                "Exception : " & ex.ToString
                        Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

        Dim lastNode As TreeNode
        lastNode = TreeView1.Nodes(TreeView1.Nodes.Count - 1).
     Nodes(TreeView1.Nodes(TreeView1.Nodes.Count - 1).Nodes.Count - 1)

        If Not lastNode.IsVisible Then

            TreeView1.SelectedNode = lastNode
            lastNode.BackColor = System.Drawing.Color.Yellow

            lastNode.EnsureVisible()

        End If

        If TreeView1.SelectedNode Is Nothing Then Exit Sub

        If lastNode IsNot Nothing Then
            TreeView1.SelectedNode = lastNode

            Dim bibliotheque As New Article
            Dim NombreDeLignes As Integer

            If TreeView1.SelectedNode.Level = 0 Or TreeView1.SelectedNode.Text = "Librairie" Then Return

            If ListView1.SelectedItems.Count > 0 Then

                NombreDeLignes = ListView1.SelectedIndices(0)
                OuvrirFichier = My.Application.Info.DirectoryPath & "\Librairies\" & ListView1.Items(NombreDeLignes).Text

                For i As Integer = 0 To ListBox2.Items.Count - 1
                    Foo = TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Text
                    If ListBox2.Items(i).ToString = Foo Then
                        Dim monfichier() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                        FileOne = monfichier(i).ToString
                    End If
                Next

                Dim readTexte() As String = File.ReadAllLines(OuvrirFichier, Encoding.UTF8)
                Dim x As String
                For Each x In readTexte
                    If x.Contains(TreeView1.Nodes(0).Nodes(TreeView1.SelectedNode.Index).Text) And x.Equals(value:=FileOne.ToString) Then
                        TextBox2.Text = Trim(Mid(x, 1, 18))
                        TextBox1.Text = Trim(Mid(x, 19, 90))
                        TextBox4.Text = Trim(Mid(x, 109, 120))
                        TextBox15.Text = Trim(Mid(x, 229, 120))
                        TextBox5.Text = Trim(Mid(x, 349, 120))
                        TextBox7.Text = Trim(Mid(x, 469, 120))
                        TextBox9.Text = Trim(Mid(x, 589, 120))
                        TextBox13.Text = Trim(Mid(x, 709, 120))
                        TextBox18.Text = Trim(Mid(x, 829, 120))
                        TextBox23.Text = Trim(Mid(x, 949, 120))
                        TextBox24.Text = Trim(Mid(x, 1069, 120))
                        TextBox25.Text = Trim(Mid(x, 1189, 120))
                        TextBox26.Text = Trim(Mid(x, 1309, 120))
                        TextBox28.Text = Trim(Mid(x, 1429, 120))
                        TextBox29.Text = Trim(Mid(x, 1549, 120))
                        TextBox33.Text = Trim(Mid(x, 1669, 120))
                        TextBox31.Text = Trim(Mid(x, 1789, 1200))
                        RichTextBox1.Text = Trim(Mid(x, 2989, 200))
                        Exit For
                    End If
                Next

                If TextBox33.Text = "" Then
                    PictureBox1.Image = Image_16x_1
                Else
                    Dim literal As String = TextBox33.Text
                    Dim subst As String = literal.Substring(0, 1)
                    PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Images\" & subst & "\" & TextBox33.Text

                    Dim id As String = TextBox33.Text
                    Dim folder As String = My.Application.Info.DirectoryPath & "\Images\" & subst & "\"
                    Dim filename As String = System.IO.Path.Combine(folder, id)
                    Try
                        Using fs As New FileStream(filename, FileMode.Open)
                            PictureBox1.Image = New Bitmap(System.Drawing.Image.FromStream(fs))
                        End Using
                    Catch ex As Exception
                        Dim msg As String = "Filename: " & filename &
                Environment.NewLine & Environment.NewLine &
                "Exception : " & ex.ToString
                        Dim dialogResult1 = Forms.MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.")
                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave

        userInput = TextBox1.Text.Trim()
        'MsgBox(userInput)

    End Sub

    Public Function GetVersion() As String

        Dim myFileVersionInfo = FileVersionInfo.GetVersionInfo(Forms.Application.ExecutablePath)
        Return myFileVersionInfo.FileVersion

    End Function

    Public Sub ShowUpdateNotification()

        Dim unused = Forms.MessageBox.Show("Une nouvelle mise à jour est disponible. Souhaitez-vous l'installer ?", "Mise à jour disponible", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

    End Sub

    Public Function AfficherMsgBox(msg As String) As Integer

        Return MsgBox(msg)

    End Function

    Friend Class Fiches
        Inherits Fiche

        Public Shadows Property IDUnique As String
        Public Overloads Property Nom As String

    End Class

End Class

Friend Class Documents
End Class

<DebuggerDisplay("{GetDebuggerDisplay(),nq}")>
Friend Class GetFormTitleDelegate
    Private Function GetDebuggerDisplay() As String
        Return ToString()
    End Function
End Class

Friend Class [Implements]
End Class