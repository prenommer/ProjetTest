using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using DocumentFormat.OpenXml;
using A = DocumentFormat.OpenXml.Drawing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using RunProperties = DocumentFormat.OpenXml.Wordprocessing.RunProperties;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json;
using OpenXmlPowerTools;

namespace Prenommer
{

    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    public partial class Main
    {

        public string Var1 { get; set; }
        public string TexteChaine { get; set; }
        public string OuvrirFichier { get; set; }
        public string OuvrirXML { get; set; }
        public string Sfichier { get; set; }
        public string Helpfile { get; set; }
        public string FileXml { get; set; }
        public string Listem { get; set; }
        public string EXTListem { get; set; }
        public string AuxFile { get; set; }
        public string Json { get; set; }
        public Class2.Fich Account { get; set; }
        public string[] lstOfStrings = new string[18];
        public string FileOne { get; set; }
        public string Foo { get; set; }
        public bool Bxister { get; set; }

        private void Main_Load(object sender, EventArgs e)
        {

            try
            {

                string path = $@"{My.MyProject.Application.Info.DirectoryPath}\Librairies\";
                string chemin = $@"{My.MyProject.Application.Info.DirectoryPath}\Xml\";
                string pathway = $@"{My.MyProject.Application.Info.DirectoryPath}\Images\";
                string Helpfile = $@"{My.MyProject.Application.Info.DirectoryPath}\Aide\";
                string records = $@"{My.MyProject.Application.Info.DirectoryPath}\Archives\";

                if (Registry.ClassesRoot.OpenSubKey(".librairie", true) is null)
                {
                    string icotouse = My.MyProject.Application.Info.DirectoryPath + @"\Registre\" + "librairie.ico";
                    string response = ((int)Interaction.MsgBox(Prompt: "Les fichiers librairie ne sont pas associés à Prénommer, les associer maintenant ?", Buttons: Constants.vbYesNo)).ToString();
                    if (Conversions.ToInteger(response) == Constants.vbYes)
                    {
                        // My.Computer.Registry.ClassesRoot.CreateSubKey(".librairie").SetValue("", "Prenommer", Microsoft.Win32.RegistryValueKind.String)
                        // My.Computer.Registry.ClassesRoot.CreateSubKey("librairie\shell\open\command").SetValue("", My.Application.StartupPath & " ""%l"" ", Microsoft.Win32.RegistryValueKind.String)
                        My.MyProject.Computer.Registry.ClassesRoot.CreateSubKey(@".librairie\DefaultIcon", RegistryKeyPermissionCheck.Default).SetValue("", icotouse);
                    }
                }

                ToolStripStatusLabel1.Text = "";
                ToolStripStatusLabel4.Text = "";

                if (Directory.Exists(My.MyProject.Application.Info.DirectoryPath + @"\Temp") == false)
                {
                    My.MyProject.Computer.FileSystem.CreateDirectory(My.MyProject.Application.Info.DirectoryPath + @"\Temp");
                }

                if (Directory.Exists(pathway) == false)
                {
                    var msgBoxResult = Interaction.MsgBox("Le dossier Images n'existe pas. Est-ce que le répertoire doit être recréé dans le chemin d'accès spécifié ?", Constants.vbYesNo, My.MyProject.Application.Info.Title);
                    if (Conversions.ToBoolean(Constants.vbOK))
                    {
                        My.MyProject.Computer.FileSystem.CreateDirectory(pathway);
                    }
                }

                ListView1.BeginUpdate();
                if (!File.Exists(path))
                {
                    foreach (string fileName in Directory.GetFiles(path))
                    {
                        ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName));
                        if (Path.GetExtension(fileName) == ".librairie")
                        {
                            var listViewItem = ListView1.Items.Add(Path.GetFileName(fileName), ImageList1.Images.Count - 1);
                            ListView1.Refresh();
                        }
                    }
                }
                ListView1.EndUpdate();

                string resultat;
                ToolStripComboBox1.Items.Clear();
                var fileNames = My.MyProject.Computer.FileSystem.GetFiles(chemin + @"\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*");
                foreach (string fileName in fileNames)
                {
                    resultat = Path.GetFileName(fileName);
                    int v = ToolStripComboBox1.Items.Add(resultat);
                    int v1 = ListBox1.Items.Add(resultat);
                }

                ToolStripStatusLabel1.Text = ListView1.Items.Count + " librairies chargées";
                ToolStripStatusLabel3.Text = "Aucun fichier sélectionné";
                ToolStripStatusLabel5.Text = "";

                ToolStripStatusLabel3.Image = ToolStripStatusLabel3.Text == "Aucun fichier sélectionné" ? My.Resources.Resources.DocumentError_16x : My.Resources.Resources.DocumentOK_16x;

                ComboBox1.Items.AddRange(new object[] { "Saint", "Sainte", "Saints", "Saintes", "Vénérable", "Vénérables", "Serviteur de Dieu", "Servante de Dieu", "Serviteurs de Dieu", "Servants de Dieu", "Servantes de Dieu", "Bienheureux", "Bienheureuse", "Bienheureuses", "Fête mariale", "Sanctuaire marial", "Fête religieuse" });
                ComboBox2.Items.AddRange(new object[] { "A.A. | Assomptionnistes (Congrégation des Augustins de l'Assomption)", "B. | Barnabites (Clercs réguliers de Saint-Paul)", "Brig. | Brigittin(e)s (Frères et Sœurs du Saint-Sauveur et de Sainte Brigitte)", "C.I.C.M | Scheutistes (Congrégation du Cœur Immaculé de Marie)", "C.J.M | Eudistes (Congrégation de Jésus et Marie)", "Clar. | Clarisses", "C.M. | Lazaristes (Congrégation de la Mission)", "C.M.F. | Missionnaires Clarétains", "C.P. | Passionistes (Congrégation de la Passion de Jésus-Christ)", "C.Ss.R. | Rédemptoristes ou Liguoriens (Congrégation du Très Saint Rédempteur)", "F.C. | Fils de la charité", "F.D.M. | Frères de Notre-Dame de Miséricorde", "F.d.S. | Filles de la Sagesse de Saint-Laurent-sur-Sèvre", "F.E.C. / F.S.C. | Lasalliens (Frères des Écoles Chrétiennes)", "F.M.M. | Franciscaines Missionnaires de Marie (de Rome)", "F.M.S. | Frères Maristes (Petits Frères de Marie)", "I.C.M. | Missionnaires du Cœur Immaculé de Marie", "L.S.N.S. | Apostolines du Très Saint-Sacrement (Dames de Sainte-Julienne)", "M.Afr. | Pères Blancs (Société des Missionnaires d'Afrique)", "M.R. | Société de Marie Réparatrice", "M.S.C. | Missionnaires du Sacré-Cœur de Jésus", "M.S.F. | Missionnaires de la Sainte-Famille", "O.Bas. | Basiliens", "O.C. | Grands carmes (Carmes de l’Antique Observance, Carmélites de la Primitive Observance)", "O.Cart. | Chartreux, chartreuses (ou chartreusines)", "O.C.D. | Carmes Déchaux, carmélites déchaussées", "O.Cist. | Cisterciens, cisterciennes", "O.C.S.O. | Trappistes, trappistines (Ordre Cistercien de la Stricte Observance)", "O.D.V. | Visitandines (Ordre de la Visitation)", "O.F.M. | Franciscain(e)s (sauf clarisses) (Ordre des Frères Mineurs)", "O.F.M.Conv. | Franciscains conventuels (Ordre des Frères Mineurs conventuels)", "O.F.M.Cap. | Capucins (Frères Mineurs Capucins)", "O.H. | Ordre Hospitalier de Saint-Jean de Dieu (Frères de Saint Jean de Dieu)", "O. de M. | Mercédaires (Ordre de Notre-Dame de la Miséricorde)", "O.M.I. | Missionnaires Oblats de Marie Immaculée", "O.M. | Minimes (Ordre des Minimes)", "O.P. | Dominicains, Frères Prêcheurs (Ordre de Prédicateurs)", "O.Praem. | Prémontrés (Chanoines Réguliers de Prémontré)", "Orat. | Oratoriens (Confédération de l’Oratoire de Saint-Philippe Néri)", "O.S.A. | Augustin(e)s (Ordre de Saint-Augustin ou des Augustins)", "O.S.B. | Bénédictin(e)s (Ordre de Saint-Benoît)", "O.S.B.Cam. | Camaldules (Congrégation Bénédictine des Moines-ermites Camaldules)", "O.S.B.Cél. | Célestins (Congrégation Bénédictine des Célestins)", "O.S.B.Sil. | Silvestrins (Congrégation Bénédictine des Silvestrins)", "O.S.B.Val. | Vallombrosans (Congrégation Bénédictine de Vallombreuse)", "O.S.B.Hum. | Humiliés (Congrégation Bénédictine de l’Humiliation)", "O.S.B.Mont | Montevirginiens (Congrégation Bénédictine de Monte Virgine)", "O.S.B.Oliv. | Olivétains (Congrégation Bénédictine de Monte Oliveto)", "O.S.M. | Servites (Ordre des Serviteurs de Marie)", "O.SS.T. | Trinitaires (Ordre de la Très-Sainte-Trinité)", "Paul. | Paulistes (Ordre de Saint-Paul l’Ermite)", "P.F.J. | Petits Frères de Jésus du Père de Foucauld", "P.I.M.E. | Institut pontifical pour les missions étrangères", "P.S.S. | Sulpiciens (Prêtres de Saint-Sulpice)", "R.S.C.J. | Religieuses du Sacré-Cœur de Jésus (Société du Sacré-Cœur de Jésus)", "Sal. / S.D.B. | Salésiens (Congrégation des Salésiens de Don Bosco)", "S.C. | Crucistes (Congrégation de la Sainte-Croix)", "S.C.J. | Prêtres du Sacré-Cœur de Jésus", "S.D.S. | Salvatoriens (Société du Divin Sauveur)", "S.G. | Frères de Saint-Gabriel (Frères de l'Instruction Chrétienne de Saint-Gabriel)", "S.P. | Piaristes (Congrégation des écoles pies)", "S.J. ou d.C.d.G. | Jésuites (Compagnie de Jésus)", "S.M. | Pères Maristes (Société de Marie)", "S.M.A. | Société des Missions Africaines", "S.M.M. | Missionnaires Montfortains", "SS.CC. | Pères des Sacrés-Cœurs / Picpus (Congrégation des Sacrés-Cœurs de Jésus et de Marie et de l'Adoration Perpétuelle du Très-Saint-Sacrement de l'Autel)", "S.U.S.C. | Religieuses de la Sainte-Union des Sacrés-Cœurs", "Urs. | Ursulines (Ordre de Sainte-Ursule)" });

                DateTimePicker1.CustomFormat = "d MMMM";
                DateTimePicker1.Value = DateTime.Now;
                TextBox5.Text = "";

                foreach (var txt in new[] { TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33 })
                    txt.ReadOnly = true;
                RichTextBox1.ReadOnly = true;

                Module1.lit = 0;
                Module1.modifié = 0;
                Module1.sauvé = 0;
                Module1.ajouté = 0;
                Module1.supprimé = 0;
                ListeToolStripMenuItem.Enabled = false;
                ModifierToolStripMenuItem1.Enabled = false;
                EnregistrerToolStripMenuItem.Enabled = false;
                NouvelleficheToolStripMenuItem.Enabled = false;
                SupprimerToolStripMenuItem.Enabled = false;
                NouveauToolStripButton.Enabled = false;
                EnregistrerToolStripButton.Enabled = false;
                ListeToolStripButton.Enabled = false;
                ToolStripButton5.Enabled = false;

                ComboBox1.Enabled = false;
                ComboBox2.Enabled = false;
                DateTimePicker1.Enabled = false;
                GenererunfichierdocxToolStripMenuItem.Enabled = false;

                ComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
                PictureBox2.Image = My.Resources.Resources._80x15;

                NotifyIcon1.Icon = Icon;
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                NotifyIcon1.BalloonTipTitle = "Prénommer";
                NotifyIcon1.BalloonTipText = "Bonjour " + Environment.UserName + " !";
                NotifyIcon1.ShowBalloonTip(0);

                var numbers = default(long);
                var di = new DirectoryInfo(My.MyProject.Application.Info.DirectoryPath + @"\Librairies\");
                var fiArr = di.GetFiles();
                foreach (var fri in fiArr)
                    numbers = (long)Math.Round(numbers + fri.Length / 3188d);
                ToolStripStatusLabel6.Text = $"Affichage du nombre total d'enregistrements : {numbers}";
            }

            catch (FileNotFoundException exc)
            {
                var dialogResult1 = MessageBox.Show($"Le fichier n'a pas été trouvé : '{e}'");
                var dialogResult2 = MessageBox.Show($"Stack Trace : {Constants.vbCrLf}{exc.StackTrace}");
            }
            catch (DirectoryNotFoundException exc)
            {
                var dialogResult1 = MessageBox.Show($"Le répertoire n'a pas été trouvé : '{e}'");
            }
            catch (IOException exc)
            {
                var dialogResult1 = MessageBox.Show($"Le fichier n'a pas pu être ouvert : '{e}'");
            }
            catch (Exception exc)
            {
                var dialogResult = MessageBox.Show(exc.ToString());

                // Finally
                // Dim dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.")

            }

        }

        private void ÀproposdeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int number = 4;
            switch (number)
            {
                case 1:
                    {
                        break;
                    }

                case 2:
                    {
                        break;
                    }

                case 3:
                    {
                        break;
                    }

                default:
                    {
                        About oForm;
                        oForm = new About();
                        oForm.Show();
                        break;
                    }
            }

        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

            int efface, SUPPRIME;
            string Msg;
            bool Cancel;

            object UnloadMode = null;
            object vbFormControlMenu = null;
            object vbAppWindows = null;
            object vbAppTaskManager = null;

            try
            {

                if (ReferenceEquals(UnloadMode, vbFormControlMenu) | ReferenceEquals(UnloadMode, vbAppWindows) | ReferenceEquals(UnloadMode, vbAppTaskManager))
                {
                    Msg = "Voulez-vous vraiment quitter l'application en cours ?";
                    if (Interaction.MsgBox(Msg, (MsgBoxStyle)((int)Constants.vbYesNo + (int)Constants.vbQuestion), My.MyProject.Application.Info.Title) == Constants.vbNo)
                    {
                        Cancel = true;

                        foreach (Form f in My.MyProject.Application.OpenForms)
                        {
                            if (f.Name == "Main")
                            {
                                e.Cancel = true;
                            }
                        }
                    }

                    else
                    {

                        Cancel = false;
                        Module1.quitté = 1;

                        var formTitles = new Collection();
                        try
                        {
                            foreach (Form f in My.MyProject.Application.OpenForms)
                                // Use a thread-safe method to get all form titles.
                                formTitles.Add(GetFormTitle(f));
                        }
                        catch (Exception ex)
                        {
                            formTitles.Add("Erreur : " + ex.Message);
                        }
                        ListBox3.DataSource = formTitles;

                        if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                        {
                            efface = (int)Interaction.MsgBox("Voulez-vous effacer les données de type texte du Presse-papiers ?", (MsgBoxStyle)(4 + 48 + 0), "Effacer le Presse-papiers");
                            if (efface == 6)
                                Clipboard.Clear();
                        }

                        string directoryPath1 = My.MyProject.Application.Info.DirectoryPath;

                        if (Directory.Exists(directoryPath1 + @"\Temp\"))
                        {
                            var msgBoxResult = Interaction.MsgBox("Voulez-vous supprimer les fichiers temporaires créés par le programme ?", (MsgBoxStyle)(4 + 48 + 0), My.MyProject.Application.Info.Title);
                            SUPPRIME = (int)msgBoxResult;

                            try
                            {
                                if (SUPPRIME == 6)
                                {
                                    string PATHDOSSIER = My.MyProject.Application.Info.DirectoryPath + @"\Temp\";
                                    // Dim x As Integer
                                    var paths = Directory.GetFiles(PATHDOSSIER, "*.*");
                                    if (paths.Length > 0)
                                    {
                                        // For x = 0 To paths.Length - 1
                                        // File.Delete(paths(x))
                                        // Next
                                        foreach (string f in paths)
                                            File.Delete(f);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                var unused = MessageBox.Show("IOException Handler: {0}", ex.ToString());
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                var dialogResult1 = MessageBox.Show(ex.ToString());

            }

        }

        private void CréerunfichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Create oForm;
            oForm = new Create();

            Initialize();
            ListView1.SelectedItems.Clear();
            ToolStripStatusLabel3.Text = "Aucun fichier sélectionné";
            ToolStripStatusLabel3.Image = My.Resources.Resources.DocumentError_16x;

            oForm.Show();

        }

        private void ImporterlibrairiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string fileContent = string.Empty;
            string filePath = string.Empty;
            string sourcePath = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\";

            try
            {

                ToolStripStatusLabel4.Text = "IMPORTATION";

                var openFileDialog1 = new Microsoft.Win32.OpenFileDialog()
                {
                    InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
                    Filter = "Fichiers texte (*.txt) Then|*.txt|Tous les fichiers (*.*)|*.*|Fichiers librairie (*.librairie)|*.librairie",
                    FilterIndex = 3,
                    RestoreDirectory = true,
                    Multiselect = false
                };

                if (Conversions.ToBoolean((DialogResult)Conversions.ToInteger(openFileDialog1.ShowDialog().Value)))
                {
                    // Get the path of specified file
                    filePath = openFileDialog1.FileName;

                    // 'Read the contents of the file into a stream
                    var fileStream = openFileDialog1.OpenFile();

                    using (var reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
                else
                {
                    return;
                }

                foreach (ListViewItem item in ListView1.Items)
                {
                    if (item.Text.Contains(Path.GetFileName(filePath)))
                    {
                        Bxister = true;
                        break;
                    }
                    else
                    {
                        Bxister = false;
                    }
                }

                if (Bxister == false)
                {

                    // MessageBox.Show(fileContent, "File Content at path : " & filePath, MessageBoxButtons.OK)
                    string destinationFileName = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + Path.GetFileName(filePath);

                    My.MyProject.Computer.FileSystem.MoveFile(filePath, destinationFileName, true);

                    ListView1.Items.Clear();
                    if (!File.Exists(sourcePath))
                    {
                        foreach (string fileName in Directory.GetFiles(sourcePath))
                        {
                            ImageList1.Images.Add(ImageList1.Images[0]);
                            var listViewItem = ListView1.Items.Add(Path.GetFileName(fileName), ImageList1.Images.Count - 1);
                        }
                    }

                    ListView1.EndUpdate();
                    ListView1.Refresh();
                }

                else if (Bxister)
                {
                    var Buttons = MessageBoxButtons.YesNo;
                    DialogResult Result;

                    Result = MessageBox.Show("Le fichier spécifié portant le même nom existe déjà. Souhaitez-vous le remplacer ?", "Prénommer", Buttons, MessageBoxIcon.Question);

                    if (Result == DialogResult.Yes)
                    {

                        string destinationFileName = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + Path.GetFileName(filePath);
                        string BackUpOfFileToReplace = My.MyProject.Application.Info.DirectoryPath + @"\Temp\" + Path.GetFileName(destinationFileName);
                        ReplaceFile(filePath, destinationFileName, BackUpOfFileToReplace);
                    }

                    else
                    {
                        return;
                    }

                }
            }

            catch (Exception ex)
            {
                // Show the exception's message.
                var dialogResult1 = MessageBox.Show(ex.Message);

                // Show the stack trace, which is a list of methods
                // that are currently executing.
                var dialogResult2 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + ex.StackTrace);
            }
            finally
            {
                // This line executes whether or not the exception occurs.
                var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");
            }

        }

        public void ReplaceFile(string FileToMoveAndDelete, string FileToReplace, string BackupOfFileToReplace)
        {

            // Replace the file.
            File.Replace(FileToMoveAndDelete, FileToReplace, BackupOfFileToReplace, false);

        }

        public void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Module1.lit = 1;
            Module1.modifié = 0;
            Module1.sauvé = 0;
            Module1.ajouté = 0;
            Module1.supprimé = 0;
            ListeToolStripMenuItem.Enabled = true;
            ModifierToolStripMenuItem1.Enabled = false;
            EnregistrerToolStripMenuItem.Enabled = false;
            NouvelleficheToolStripMenuItem.Enabled = false;
            SupprimerToolStripMenuItem.Enabled = false;
            NouveauToolStripButton.Enabled = false;
            EnregistrerToolStripButton.Enabled = false;
            ListeToolStripButton.Enabled = true;
            ToolStripButton5.Enabled = false;

            // Début du processus de création de fichiers temporaires
            if (ListView1.SelectedItems.Count > 0)
            {
                EXTListem = Path.GetFileName(ListView1.SelectedItems[0].Text);
                Listem = Path.GetFileNameWithoutExtension(ListView1.SelectedItems[0].Text);
            }

            string filename;
            do
            {
                filename = Guid.NewGuid().ToString("D") + "-" + Listem + ".tmp";
                filename = filename.Replace("-", "_");
            }
            // filename = Guid.NewGuid().ToString("D").GetHashCode().ToString("x") + "-" + Listem + ".tmp"
            while (File.Exists(filename));

            My.MyProject.Computer.FileSystem.CopyFile(My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + EXTListem, My.MyProject.Application.Info.DirectoryPath + @"\Temp\" + filename, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            // Fin du processus de création de fichiers temporaires

            if (ListView1.SelectedItems.Count > 0)
            {
                string var1;
                var1 = ListView1.SelectedItems[0].Text;
                ToolStripStatusLabel3.Text = var1 + " : Fichier ouvert";
                string chaine = ToolStripStatusLabel3.Text;
                TexteChaine = chaine.Substring(0, Strings.Len(ToolStripStatusLabel3.Text) - 17);
            }

            string sFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + TexteChaine;
            try
            {
                var FS = File.Open(sFichier, FileMode.Open, FileAccess.Read, FileShare.None);
                // Ouverture Ok, donc non déjà ouvert : referme
                FS.Close();
                FS.Dispose();
                FS = null;
            }
            // MsgBox("Fichier non ouvert")
            catch (IOException ex)
            {
                var msgBoxResult = Interaction.MsgBox("\"" + sFichier + "\" déjà ouvert" + Environment.NewLine + ex.Message);
            }
            catch (Exception ex)
            {
                var dialogResult1 = MessageBox.Show("Erreur inconnue" + Environment.NewLine + ex.Message);
            }

            ToolStripStatusLabel3.Image = My.Resources.Resources.DocumentOK_16x;

            ListBox2.Items.Clear();
            TreeView1.Nodes.Clear();
            TreeView1.Enabled = true;

            Initialize();

            ToolStripTextBox1.Text = "";
            ListeToolStripMenuItem.Enabled = true;
            ListeToolStripButton.Enabled = true;

        }

        private void SupprToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string FileToDelete;

            try
            {

                if (ListView1.SelectedItems.Count == 0)
                {
                    var msgBoxResult = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir le supprimer !", (MsgBoxStyle)Constants.vbYes, "Erreur");
                    return;
                }
                else if (ListView1.SelectedItems.Count > 0)
                {
                    Var1 = ListView1.SelectedItems[0].Text;
                }

                if (TreeView1.Nodes.Count == default)
                {

                    FileToDelete = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + Var1;

                    if (File.Exists(FileToDelete))
                    {
                        File.Delete(FileToDelete, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                        var dialogResult1 = MessageBox.Show("Fichier supprimé placé dans la corbeille !");

                        ListView1.BeginUpdate();
                        ListView1.Items.Clear();
                        if (!File.Exists(My.MyProject.Application.Info.DirectoryPath + @"\Librairies\"))
                        {
                            foreach (string fileName in Directory.GetFiles(My.MyProject.Application.Info.DirectoryPath + @"\Librairies\"))
                            {
                                ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName));
                                var listViewItem = ListView1.Items.Add(Path.GetFileName(fileName), ImageList1.Images.Count - 1);
                            }
                        }
                        ToolStripStatusLabel1.Text = ListView1.Items.Count + " librairies chargées";
                        ToolStripStatusLabel3.Text = "Aucun fichier sélectionné";
                        ListView1.EndUpdate();
                    }
                }

                else
                {
                    var dialogResult1 = MessageBox.Show("Sélectionnez exclusivement le fichier librairie que vous souhaitez supprimer. Ne développez pas cette librairie.");
                    return;

                }
            }

            catch (Exception ex)
            {
                var dialogResult1 = MessageBox.Show(ex.Message);

                var dialogResult2 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + ex.StackTrace);
            }

            finally
            {
                var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");

            }

        }

        public void Initialize()
        {

            string Var1;

            Cursor = Cursors.WaitCursor;
            ToolStripTextBox1.Text = "";

            ToolStripStatusLabel3.Text = "Ouverture en cours...";
            ToolStripStatusLabel4.Text = "INITIALISATION";

            if (ListView1.SelectedItems.Count > 0)
            {
                Var1 = ListView1.SelectedItems[0].Text;
            }
            else
            {
                Cursor = Cursors.Default;
                return;
            }

            TextBox5.Enabled = true;

            foreach (var txt in new[] { TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33 })
                txt.Clear();
            RichTextBox1.Clear();

            PictureBox1.Image = null;
            PictureBox1.ImageLocation = "";

            TreeView1.BeginUpdate();
            TreeView1.SelectedNode = null;
            TreeView1.Nodes.Clear();
            TreeView1.EndUpdate();

            ToolStripTextBox1.Text = "";

            Cursor = Cursors.Default;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            ToolStripStatusLabel2.Text = DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss");

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBox2.Text = Conversions.ToString(ComboBox1.Items[ComboBox1.SelectedIndex]);

            ComboBox1.Items.Clear();
            ComboBox1.Items.AddRange(new object[] { "Saint", "Sainte", "Saints", "Saintes", "Vénérable", "Vénérables", "Serviteur de Dieu", "Servante de Dieu", "Serviteurs de Dieu", "Servants de Dieu", "Servantes de Dieu", "Bienheureux", "Bienheureuse", "Bienheureuses", "Fête mariale", "Sanctuaire marial", "Fête religieuse" });

        }

        private void AjouterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var form = new Append();
            form.Show();

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBox15.Text = Conversions.ToString(ComboBox2.Items[ComboBox2.SelectedIndex]);

            ComboBox2.Items.Clear();
            ComboBox2.Items.AddRange(new object[] { "A.A. | Assomptionnistes (Congrégation des Augustins de l'Assomption)", "B. | Barnabites (Clercs réguliers de Saint-Paul)", "Brig. | Brigittin(e)s (Frères et Sœurs du Saint-Sauveur et de Sainte Brigitte)", "C.I.C.M | Scheutistes (Congrégation du Cœur Immaculé de Marie)", "C.J.M | Eudistes (Congrégation de Jésus et Marie)", "Clar. | Clarisses", "C.M. | Lazaristes (Congrégation de la Mission)", "C.M.F. | Missionnaires Clarétains", "C.P. | Passionistes (Congrégation de la Passion de Jésus-Christ)", "C.Ss.R. | Rédemptoristes ou Liguoriens (Congrégation du Très Saint Rédempteur)", "F.C. | Fils de la charité", "F.D.M. | Frères de Notre-Dame de Miséricorde", "F.d.S. | Filles de la Sagesse de Saint-Laurent-sur-Sèvre", "F.E.C. / F.S.C. | Lasalliens (Frères des Écoles Chrétiennes)", "F.M.M. | Franciscaines Missionnaires de Marie (de Rome)", "F.M.S. | Frères Maristes (Petits Frères de Marie)", "I.C.M. | Missionnaires du Cœur Immaculé de Marie", "L.S.N.S. | Apostolines du Très Saint-Sacrement (Dames de Sainte-Julienne)", "M.Afr. | Pères Blancs (Société des Missionnaires d'Afrique)", "M.R. | Société de Marie Réparatrice", "M.S.C. | Missionnaires du Sacré-Cœur de Jésus", "M.S.F. | Missionnaires de la Sainte-Famille", "O.Bas. | Basiliens", "O.C. | Grands carmes (Carmes de l’Antique Observance, Carmélites de la Primitive Observance)", "O.Cart. | Chartreux, chartreuses (ou chartreusines)", "O.C.D. | Carmes Déchaux, carmélites déchaussées", "O.Cist. | Cisterciens, cisterciennes", "O.C.S.O. | Trappistes, trappistines (Ordre Cistercien de la Stricte Observance)", "O.D.V. | Visitandines (Ordre de la Visitation)", "O.F.M. | Franciscain(e)s (sauf clarisses) (Ordre des Frères Mineurs)", "O.F.M.Conv. | Franciscains conventuels (Ordre des Frères Mineurs conventuels)", "O.F.M.Cap. | Capucins (Frères Mineurs Capucins)", "O.H. | Ordre Hospitalier de Saint-Jean de Dieu (Frères de Saint Jean de Dieu)", "O. de M. | Mercédaires (Ordre de Notre-Dame de la Miséricorde)", "O.M.I. | Missionnaires Oblats de Marie Immaculée", "O.M. | Minimes (Ordre des Minimes)", "O.P. | Dominicains, Frères Prêcheurs (Ordre de Prédicateurs)", "O.Praem. | Prémontrés (Chanoines Réguliers de Prémontré)", "Orat. | Oratoriens (Confédération de l’Oratoire de Saint-Philippe Néri)", "O.S.A. | Augustin(e)s (Ordre de Saint-Augustin ou des Augustins)", "O.S.B. | Bénédictin(e)s (Ordre de Saint-Benoît)", "O.S.B.Cam. | Camaldules (Congrégation Bénédictine des Moines-ermites Camaldules)", "O.S.B.Cél. | Célestins (Congrégation Bénédictine des Célestins)", "O.S.B.Sil. | Silvestrins (Congrégation Bénédictine des Silvestrins)", "O.S.B.Val. | Vallombrosans (Congrégation Bénédictine de Vallombreuse)", "O.S.B.Hum. | Humiliés (Congrégation Bénédictine de l’Humiliation)", "O.S.B.Mont | Montevirginiens (Congrégation Bénédictine de Monte Virgine)", "O.S.B.Oliv. | Olivétains (Congrégation Bénédictine de Monte Oliveto)", "O.S.M. | Servites (Ordre des Serviteurs de Marie)", "O.SS.T. | Trinitaires (Ordre de la Très-Sainte-Trinité)", "Paul. | Paulistes (Ordre de Saint-Paul l’Ermite)", "P.F.J. | Petits Frères de Jésus du Père de Foucauld", "P.I.M.E. | Institut pontifical pour les missions étrangères", "P.S.S. | Sulpiciens (Prêtres de Saint-Sulpice)", "R.S.C.J. | Religieuses du Sacré-Cœur de Jésus (Société du Sacré-Cœur de Jésus)", "Sal. / S.D.B. | Salésiens (Congrégation des Salésiens de Don Bosco)", "S.C. | Crucistes (Congrégation de la Sainte-Croix)", "S.C.J. | Prêtres du Sacré-Cœur de Jésus", "S.D.S. | Salvatoriens (Société du Divin Sauveur)", "S.G. | Frères de Saint-Gabriel (Frères de l'Instruction Chrétienne de Saint-Gabriel)", "S.P. | Piaristes (Congrégation des écoles pies)", "S.J. ou d.C.d.G. | Jésuites (Compagnie de Jésus)", "S.M. | Pères Maristes (Société de Marie)", "S.M.A. | Société des Missions Africaines", "S.M.M. | Missionnaires Montfortains", "SS.CC. | Pères des Sacrés-Cœurs / Picpus (Congrégation des Sacrés-Cœurs de Jésus et de Marie et de l'Adoration Perpétuelle du Très-Saint-Sacrement de l'Autel)", "S.U.S.C. | Religieuses de la Sainte-Union des Sacrés-Cœurs", "Urs. | Ursulines (Ordre de Sainte-Ursule)" });

        }

        private void NouvelleficheToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripStatusLabel4.Text = "CRÉATION d’enregistrement (écriture dans le fichier)";

            var bibliotheque = new Module1.Article();
            int NumeroDeLigne;

            Module1.bFurther = true;

            Module1.lit = 0;
            Module1.modifié = 0;
            Module1.sauvé = 1;
            Module1.ajouté = 0;
            Module1.supprimé = 0;
            ListeToolStripMenuItem.Enabled = false;
            ModifierToolStripMenuItem1.Enabled = false;
            EnregistrerToolStripMenuItem.Enabled = true;
            NouvelleficheToolStripMenuItem.Enabled = false;
            SupprimerToolStripMenuItem.Enabled = false;
            NouveauToolStripButton.Enabled = false;
            EnregistrerToolStripButton.Enabled = true;
            ListeToolStripButton.Enabled = false;
            ToolStripButton5.Enabled = false;


            // Si aucun élément n'est sélectionné
            if (ListView1.SelectedItems.Count == 0)
            {
                var msgBoxResult = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", (MsgBoxStyle)Constants.vbYes, "Erreur");
            }

            else
            {
                // MessageBox.Show("Veuillez saisir un nom qui n'apparaît pas dans la zone de liste.")

                ComboBox1.Enabled = true;
                ComboBox2.Enabled = true;
                DateTimePicker1.Enabled = true;

                foreach (var txt in new[] { TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33 })
                    txt.ReadOnly = false;
                RichTextBox1.ReadOnly = false;

                NumeroDeLigne = ListView1.SelectedIndices[0];
                OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NumeroDeLigne].Text;

                for (int I = 0, loopTo = ListView1.Items.Count - 1; I <= loopTo; I++)
                {
                    if (ListView1.Items[I].Index == NumeroDeLigne)
                    {
                        ListView1.Items[I].Selected = true;
                    }
                }

                Initialize();

                My.MyProject.Application.DoEvents();

                UpdateAutoComplete();

            }

        }

        private void ListeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripStatusLabel4.Text = "LECTURE d’enregistrement (lecture du fichier)";

            var bibliotheque = new Module1.Article();
            int NumeroDeLigne;

            Module1.lit = 0;
            Module1.modifié = 1;
            Module1.sauvé = 0;
            Module1.ajouté = 1;
            Module1.supprimé = 1;
            ListeToolStripMenuItem.Enabled = false;
            ModifierToolStripMenuItem1.Enabled = true;
            EnregistrerToolStripMenuItem.Enabled = false;
            NouvelleficheToolStripMenuItem.Enabled = true;
            SupprimerToolStripMenuItem.Enabled = true;
            NouveauToolStripButton.Enabled = true;
            EnregistrerToolStripButton.Enabled = false;
            ListeToolStripButton.Enabled = false;
            ToolStripButton5.Enabled = true;

            var myFile = new FileInfo(My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.SelectedItems[0].Text.ToString());
            long sizeInBytes = myFile.Length;
            if (sizeInBytes < 3188L) // = 0
            {
                var dialogResult1 = MessageBox.Show("La longueur du fichier n'excède pas 3188 octets (3.188000 Ko) — depuis décembre 1998, l'organisme international IEC a standardisé ces unités : un kilooctet (ko ou kB) = 1000 octets — plus exactement " + sizeInBytes + " octets ; l'application n'examine que les fichiers pourvus d'au moins un enregistrement.", "Prénommer");
                return;
            }

            // Si aucun élément n'est sélectionné
            if (ListView1.SelectedItems.Count == 0)
            {
                var msgBoxResult = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir le lire !", (MsgBoxStyle)Constants.vbYes, "Erreur");
            }
            // Sinon, on récupère le numéro de ligne

            else
            {

                Cursor = Cursors.WaitCursor;

                PictureBox3.Visible = true;

                ComboBox1.Enabled = false;
                ComboBox2.Enabled = false;
                DateTimePicker1.Enabled = false;

                ListeToolStripMenuItem.Enabled = false;
                ListeToolStripButton.Enabled = false;

                NumeroDeLigne = ListView1.SelectedIndices[0];
                OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NumeroDeLigne].Text;
                OuvrirXML = My.MyProject.Application.Info.DirectoryPath + @"\Temp\" + Path.GetFileNameWithoutExtension(ListView1.Items[NumeroDeLigne].Text) + ".xml";

                ToolStripProgressBar1.Minimum = 0;

                var root = new TreeNode("Librairie");
                int v = TreeView1.Nodes.Add(root);

                TreeView1.Sort();

                ToolStripProgressBar1.Maximum = TreeView1.Nodes.Count;
                ToolStripProgressBar1.Step = 1;

                try
                {

                    var readText = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                    foreach (var s in readText)
                    {
                        TextBox2.Text = Strings.Trim(s.Substring(0, 18));
                        TextBox1.Text = Strings.Trim(s.Substring(18, 90));
                        TextBox4.Text = Strings.Trim(s.Substring(108, 120));
                        TextBox15.Text = Strings.Trim(s.Substring(228, 120));
                        TextBox5.Text = Strings.Trim(s.Substring(348, 120));
                        TextBox7.Text = Strings.Trim(s.Substring(468, 120));
                        TextBox9.Text = Strings.Trim(s.Substring(588, 120));
                        TextBox13.Text = Strings.Trim(s.Substring(708, 120));
                        TextBox18.Text = Strings.Trim(s.Substring(828, 120));
                        TextBox23.Text = Strings.Trim(s.Substring(948, 120));
                        TextBox24.Text = Strings.Trim(s.Substring(1068, 120));
                        TextBox25.Text = Strings.Trim(s.Substring(1188, 120));
                        TextBox26.Text = Strings.Trim(s.Substring(1308, 120));
                        TextBox28.Text = Strings.Trim(s.Substring(1428, 120));
                        TextBox29.Text = Strings.Trim(s.Substring(1548, 120));
                        TextBox33.Text = Strings.Trim(s.Substring(1668, 120));
                        TextBox31.Text = Strings.Trim(s.Substring(1788, 1200));
                        RichTextBox1.Text = Strings.Trim(s.Substring(2988, 200));
                        var node = TreeView1.Nodes[0];
                        int v1 = TreeView1.Nodes[0].Nodes.Add(new TreeNode(Strings.Trim(TextBox1.Text)));
                        int v2 = ListBox2.Items.Add(TextBox1.Text);
                        ToolStripProgressBar1.PerformStep();
                    }
                }

                catch (IndexOutOfRangeException ext)
                {
                    var dialogResult1 = MessageBox.Show(ext.Message);
                    var dialogResult2 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + ext.StackTrace);
                }

                catch (ArgumentOutOfRangeException exc)
                {
                    var dialogResult1 = MessageBox.Show(exc.Message);
                    var dialogResult2 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + exc.StackTrace);

                }

                TextBox2.Clear();

                Cursor = Cursors.Default;

            }

            var C = new Class1();
            C.SauveTreeView(TreeView1, OuvrirXML);
            C.ChargeTreeView(TreeView1, OuvrirXML);

            var FichierInfo = new FileInfo(OuvrirFichier);
            int TailleFichier = (int)FichierInfo.Length;

            if (!(TailleFichier == 0))
            {
                bool v = TreeView1.Focus();
                TreeView1.SelectedNode = TreeView1.Nodes[0].Nodes[0];
                TextBox31.Clear();
            }

            string foo;
            foo = TreeView1.SelectedNode.Text;
            for (int i = 0, loopTo = ListBox2.Items.Count - 1; i <= loopTo; i++)
            {
                if ((ListBox2.Items[i].ToString() ?? "") == (foo ?? ""))
                {
                    var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                    FileOne = monfichier[i].ToString();
                }
            }

            var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
            foreach (var t in readTexte)
            {
                if (t.Contains(TreeView1.SelectedNode.Text) & t.Equals(value: FileOne.ToString()))
                {
                    TextBox2.Text = Strings.Trim(t.Substring(0, 18));
                    TextBox1.Text = Strings.Trim(t.Substring(18, 90));
                    TextBox4.Text = Strings.Trim(t.Substring(108, 120));
                    TextBox15.Text = Strings.Trim(t.Substring(228, 120));
                    TextBox5.Text = Strings.Trim(t.Substring(348, 120));
                    TextBox7.Text = Strings.Trim(t.Substring(468, 120));
                    TextBox9.Text = Strings.Trim(t.Substring(588, 120));
                    TextBox13.Text = Strings.Trim(t.Substring(708, 120));
                    TextBox18.Text = Strings.Trim(t.Substring(828, 120));
                    TextBox23.Text = Strings.Trim(t.Substring(948, 120));
                    TextBox24.Text = Strings.Trim(t.Substring(1068, 120));
                    TextBox25.Text = Strings.Trim(t.Substring(1188, 120));
                    TextBox26.Text = Strings.Trim(t.Substring(1308, 120));
                    TextBox28.Text = Strings.Trim(t.Substring(1428, 120));
                    TextBox29.Text = Strings.Trim(t.Substring(1548, 120));
                    TextBox33.Text = Strings.Trim(t.Substring(1668, 120));
                    TextBox31.Text = Strings.Trim(t.Substring(1788, 1200));
                    RichTextBox1.Text = Strings.Trim(t.Substring(2988, 200));
                    break;
                }
            }

            if (string.IsNullOrEmpty(TextBox33.Text))
            {
                PictureBox1.Image = My.Resources.Resources.Image_16x_1;
            }
            else
            {
                string literal = TextBox33.Text;
                string subst = literal.Substring(0, 1);
                PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                string id = TextBox33.Text;
                string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                string filename = Path.Combine(folder, id);
                try
                {

                    using (var fs = File.OpenRead(filename))
                    {
                        PictureBox1.Image = Image.FromStream(fs);
                    }
                }

                catch (Exception ex)
                {
                    string msg = "Nom de fichier : " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                    var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                }
            }

            int NbLine = 0;
            var SR = new StreamReader(OuvrirFichier);
            while (!SR.EndOfStream)
            {
                string v = SR.ReadLine();
                NbLine += 1;
            }
            SR.Close();

            // 'Dim lastLine As String = File.ReadLines(OuvrirFichier, Encoding.UTF8) _
            // '.Where(Function(f As String) (Not String.IsNullOrEmpty(f))).Last.ToString

            ToolStripTextBox1.Text = NbLine.ToString();

            foreach (var txt in new[] { TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33 })
                txt.ReadOnly = true;
            RichTextBox1.ReadOnly = true;

            ToolStripProgressBar1.Value = 0;

            TreeView1.ExpandAll();
            PictureBox3.Visible = false;

        }

        private void EnregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripStatusLabel4.Text = "CREATION d'enregistrement (écriture dans le fichier)";

            var bibliotheque = new Module1.Article();
            int NumeroDeLigne;

            Module1.lit = 0;
            Module1.modifié = 1;
            Module1.sauvé = 0;
            Module1.ajouté = 1;
            Module1.supprimé = 1;
            ListeToolStripMenuItem.Enabled = true;
            ModifierToolStripMenuItem1.Enabled = true;
            EnregistrerToolStripMenuItem.Enabled = false;
            NouvelleficheToolStripMenuItem.Enabled = true;
            SupprimerToolStripMenuItem.Enabled = true;
            NouveauToolStripButton.Enabled = true;
            EnregistrerToolStripButton.Enabled = false;
            ListeToolStripButton.Enabled = false;
            ToolStripButton5.Enabled = true;

            // Si aucun élément n'est sélectionné
            if (ListView1.SelectedItems.Count == 0)
            {
                var msgBoxResult = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", (MsgBoxStyle)Constants.vbYes, "Erreur");
            }
            else
            {
                if (ListBox2.Items.Contains(Strings.Trim(TextBox1.Text)) | string.IsNullOrEmpty(Strings.Trim(TextBox1.Text)))
                {
                    TextBox1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                    bool v = TextBox1.Focus();
                    EnregistrerToolStripButton.Enabled = true;
                    EnregistrerToolStripMenuItem.Enabled = true;
                    NouveauToolStripButton.Enabled = false;
                    ToolStripButton5.Enabled = false;
                    NouvelleficheToolStripMenuItem.Enabled = false;
                    ModifierToolStripMenuItem1.Enabled = false;
                    return;
                }

                TextBox1.BackColor = SystemColors.Control;
                ComboBox1.Enabled = false;
                ComboBox2.Enabled = false;
                DateTimePicker1.Enabled = false;
                TextBox5.Enabled = false;
                ListBox2.Items.Clear();

                NumeroDeLigne = ListView1.SelectedIndices[0];
                OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NumeroDeLigne].Text;

                var MonFichier = new FileInfo(OuvrirFichier);

                bibliotheque.Title = TextBox2.Text;
                bibliotheque.Name = TextBox1.Text;
                bibliotheque.Charge = TextBox4.Text;
                bibliotheque.Institute = TextBox15.Text;
                bibliotheque.Celebration = TextBox5.Text;
                bibliotheque.Birth = TextBox7.Text;
                bibliotheque.Death = TextBox9.Text;
                bibliotheque.Otherparties = TextBox13.Text;
                bibliotheque.Othernames = TextBox18.Text;
                bibliotheque.Venerable = TextBox23.Text;
                bibliotheque.Beatified = TextBox24.Text;
                bibliotheque.Canonized = TextBox25.Text;
                bibliotheque.Heading = TextBox26.Text;
                bibliotheque.Patron = TextBox28.Text;
                bibliotheque.Link = TextBox29.Text;
                bibliotheque.Image = TextBox33.Text;
                bibliotheque.Biography = TextBox31.Text;
                bibliotheque.Origin = RichTextBox1.Text;

                if (Module1.bChanged & !Module1.bFurther & MonFichier.Length > 0L)
                {

                    string fileName = OuvrirFichier;
                    var lignes = File.ReadAllLines(fileName, Encoding.UTF8);
                    int found = -1;

                    for (int i = 0, loopTo = lignes.Length - 1; i <= loopTo; i++)
                    {
                        if (lignes[i].Contains(Strings.Trim(lstOfStrings[1])))
                        {
                            found = i;
                            break;
                        }
                    }

                    // Modifier - Si vous souhaitez modifier une ligne dans un fichier, vous devez lire l'intégralité du fichier et le réécrire avec la ligne modifiée.

                    var lines = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                    lines[found] = bibliotheque.Title.PadRight(18, ' ').ToString() + bibliotheque.Name.PadRight(90, ' ').ToString() + bibliotheque.Charge.PadRight(120, ' ').ToString() + bibliotheque.Institute.PadRight(120, ' ').ToString() + bibliotheque.Celebration.PadRight(120, ' ').ToString() + bibliotheque.Birth.PadRight(120, ' ').ToString() + bibliotheque.Death.PadRight(120, ' ').ToString() + bibliotheque.Otherparties.PadRight(120, ' ').ToString() + bibliotheque.Othernames.PadRight(120, ' ').ToString() + bibliotheque.Venerable.PadRight(120, ' ').ToString() + bibliotheque.Beatified.PadRight(120, ' ').ToString() + bibliotheque.Canonized.PadRight(120, ' ').ToString() + bibliotheque.Heading.PadRight(120, ' ').ToString() + bibliotheque.Patron.PadRight(120, ' ').ToString() + bibliotheque.Link.PadRight(120, ' ').ToString() + bibliotheque.Image.PadRight(120, ' ').ToString() + bibliotheque.Biography.PadRight(1200, ' ').ToString() + bibliotheque.Origin.PadRight(200, ' ').ToString();

                    var dialogResult1 = MessageBox.Show("Enregistrer les données modifiées ?", "Prénommer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Conversions.ToBoolean(DialogResult.OK))
                    {
                        File.Delete(OuvrirFichier);
                        File.WriteAllLines(OuvrirFichier, lines, Encoding.UTF8);
                        using (var fStream = new FileStream(OuvrirFichier, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                            fStream.SetLength(fStream.Length - Environment.NewLine.Length);
                        }
                    }
                    else
                    {
                        return;
                    }
                    Module1.bChanged = false;
                }

                else
                {

                    string fileName = OuvrirFichier;
                    var bt = new Module1.Article()
                    {
                        Title = TextBox2.Text,
                        Name = TextBox1.Text,
                        Charge = TextBox4.Text,
                        Institute = TextBox15.Text,
                        Celebration = TextBox5.Text,
                        Birth = TextBox7.Text,
                        Death = TextBox9.Text,
                        Otherparties = TextBox13.Text,
                        Othernames = TextBox18.Text,
                        Venerable = TextBox23.Text,
                        Beatified = TextBox24.Text,
                        Canonized = TextBox25.Text,
                        Heading = TextBox26.Text,
                        Patron = TextBox28.Text,
                        Link = TextBox29.Text,
                        Image = TextBox33.Text,
                        Biography = TextBox31.Text,
                        Origin = RichTextBox1.Text
                    };

                    using (var fs = new FileStream(fileName, FileMode.Append))
                    {
                        using (var writer = new StreamWriter(fs, Encoding.UTF8))
                        {
                            if (fs.Length > 0L)
                                writer.WriteLine();
                            writer.Write($"{bt.Title,-18}{bt.Name,-90}{bt.Charge,-120}{bt.Institute,-120}{bt.Celebration,-120}{bt.Birth,-120}{bt.Death,-120}{bt.Otherparties,-120}{bt.Othernames,-120}{bt.Venerable,-120}{bt.Beatified,-120}{bt.Canonized,-120}{bt.Heading,-120}{bt.Patron,-120}{bt.Link,-120}{bt.Image,-120}{bt.Biography,-1200}{bt.Origin,-200}");
                        }
                    }

                    Module1.bFurther = false;

                }

                ListBox2.Items.Clear();

            }

            ListeToolStripMenuItem.Enabled = true;
            ListeToolStripButton.Enabled = true;

            foreach (var txt in new[] { TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33 })
                txt.ReadOnly = true;
            RichTextBox1.ReadOnly = true;

            var dialogResult2 = MessageBox.Show("Données écrites dans le fichier disque.");

            Initialize();

            ListeToolStripMenuItem.PerformClick();

            ListeToolStripMenuItem.Enabled = false;
            ListeToolStripButton.Enabled = false;

        }

        private void ModifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ToolStripStatusLabel4.Text = "MODIFICATION d'enregistrement (correction dans le fichier)";

            Module1.bChanged = true;

            int NumeroDeLigne;

            Module1.lit = 0;
            Module1.modifié = 0;
            Module1.sauvé = 1;
            Module1.ajouté = 0;
            Module1.supprimé = 0;
            ListeToolStripMenuItem.Enabled = false;
            ModifierToolStripMenuItem1.Enabled = false;
            EnregistrerToolStripMenuItem.Enabled = true;
            NouvelleficheToolStripMenuItem.Enabled = false;
            SupprimerToolStripMenuItem.Enabled = false;
            NouveauToolStripButton.Enabled = false;
            EnregistrerToolStripButton.Enabled = true;
            ListeToolStripButton.Enabled = false;
            ToolStripButton5.Enabled = false;

            // Si aucun élément n'est sélectionné
            if (ListView1.SelectedItems.Count == 0)
            {
                var msgBoxResult = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", (MsgBoxStyle)Constants.vbYes, "Erreur");
            }

            else
            {

                ComboBox1.Enabled = true;
                ComboBox2.Enabled = true;
                DateTimePicker1.Enabled = true;

                foreach (var txt in new[] { TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33 })
                    txt.ReadOnly = false;
                RichTextBox1.ReadOnly = false;

                NumeroDeLigne = ListView1.SelectedIndices[0];
                OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NumeroDeLigne].Text;

                lstOfStrings = new[] { TextBox2.Text, TextBox1.Text, TextBox4.Text, TextBox15.Text, TextBox5.Text, TextBox7.Text, TextBox9.Text, TextBox13.Text, TextBox18.Text, TextBox23.Text, TextBox24.Text, TextBox25.Text, TextBox26.Text, TextBox28.Text, TextBox29.Text, TextBox33.Text, TextBox31.Text, RichTextBox1.Text };

                ListBox2.Items.Clear();
                // 'Me.ListBox1.Items.Add(System.IO.File.ReadAllLines(OuvrirFichier, System.Text.Encoding.UTF8))

            }

        }

        private void SupprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int NombreDeLignes;
            string OuvrirTemporaire;
            int NumeroDeLigne;

            ToolStripStatusLabel4.Text = "SUPPRESSION d'enregistrement (effacement dans le fichier)";

            Module1.lit = 0;
            Module1.modifié = 0;
            Module1.sauvé = 0;
            Module1.ajouté = 0;
            Module1.supprimé = 1;
            ListeToolStripMenuItem.Enabled = false;
            ModifierToolStripMenuItem1.Enabled = false;
            EnregistrerToolStripMenuItem.Enabled = false;
            NouvelleficheToolStripMenuItem.Enabled = false;
            SupprimerToolStripMenuItem.Enabled = true;
            NouveauToolStripButton.Enabled = false;
            EnregistrerToolStripButton.Enabled = false;
            ListeToolStripButton.Enabled = false;
            ToolStripButton5.Enabled = false;

            if (ListView1.SelectedItems.Count > 0)
            {

                if (TreeView1.Nodes.Count == 1)
                {
                    string message = "Conseil : Supprimez de préférence le fichier à l’aide de l’Explorateur de fichiers ou à partir du menu principal Fichiers de Prénommer, sélectionnez le sous-menu Supprimer.";
                    string caption = "Prénommer";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // If result = DialogResult.OK Then Exit Sub
                }

                ComboBox1.Enabled = false;
                ComboBox2.Enabled = false;
                DateTimePicker1.Enabled = false;

                NombreDeLignes = ListView1.SelectedIndices[0];
                Module1.Position = TreeView1.SelectedNode.Index;

                for (int i = 0, loopTo = ListBox2.Items.Count - 1; i <= loopTo; i++)
                {
                    if (ListBox2.Items[i].ToString().Contains(Strings.Trim(TextBox1.Text)))
                    {
                        Module1.IndexEnreg = i;
                        break;
                    }
                }

                ListBox2.SelectedItems.Clear();

                OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;
                OuvrirTemporaire = My.MyProject.Application.Info.DirectoryPath + @"\Temp\" + Path.GetFileNameWithoutExtension(ListView1.Items[NombreDeLignes].Text) + ".tmp";

                string fileName = OuvrirFichier;
                string someString = Strings.Trim(TextBox1.Text);
                var lignes = File.ReadAllLines(fileName, Encoding.UTF8);
                int found = -1;

                for (int i = 0, loopTo1 = lignes.Length - 1; i <= loopTo1; i++)
                {
                    if (lignes[i].Contains(someString))
                    {
                        found = i;
                        break;
                    }
                }

                int delLine = found + 1; // 10
                var lines = File.ReadAllLines(OuvrirFichier, Encoding.UTF8).ToList();
                lines.RemoveAt(delLine - 1); // index starts at 0 
                File.WriteAllText(OuvrirTemporaire, string.Join(Environment.NewLine, lines), Encoding.UTF8);

                try
                {

                    File.Delete(OuvrirFichier, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                }

                catch (Exception ex)
                {
                    var msgBoxResult = Interaction.MsgBox(ex.Message);
                }

                My.MyProject.Computer.FileSystem.RenameFile(OuvrirTemporaire, ListView1.Items[NombreDeLignes].Text);
            }

            else
            {

                return;

            }

            string FileToMove;
            string MoveLocation;

            FileToMove = My.MyProject.Application.Info.DirectoryPath + @"\Temp\" + ListView1.Items[NombreDeLignes].Text;
            MoveLocation = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;

            if (File.Exists(FileToMove))
            {
                File.Move(FileToMove, MoveLocation);
            }

            Initialize();

            NumeroDeLigne = ListView1.SelectedIndices[0];
            OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NumeroDeLigne].Text;
            OuvrirXML = My.MyProject.Application.Info.DirectoryPath + @"\Temp\" + Path.GetFileNameWithoutExtension(ListView1.Items[NumeroDeLigne].Text) + ".xml";

            var root = new TreeNode("Librairie");
            int v = TreeView1.Nodes.Add(root);

            ListBox2.Items.Clear();

            var readText = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
            foreach (var s in readText)
            {
                TextBox2.Text = Strings.Trim(s.Substring(0, 18));
                TextBox1.Text = Strings.Trim(s.Substring(18, 90));
                TextBox4.Text = Strings.Trim(s.Substring(108, 120));
                TextBox15.Text = Strings.Trim(s.Substring(228, 120));
                TextBox5.Text = Strings.Trim(s.Substring(348, 120));
                TextBox7.Text = Strings.Trim(s.Substring(468, 120));
                TextBox9.Text = Strings.Trim(s.Substring(588, 120));
                TextBox13.Text = Strings.Trim(s.Substring(708, 120));
                TextBox18.Text = Strings.Trim(s.Substring(828, 120));
                TextBox23.Text = Strings.Trim(s.Substring(948, 120));
                TextBox24.Text = Strings.Trim(s.Substring(1068, 120));
                TextBox25.Text = Strings.Trim(s.Substring(1188, 120));
                TextBox26.Text = Strings.Trim(s.Substring(1308, 120));
                TextBox28.Text = Strings.Trim(s.Substring(1428, 120));
                TextBox29.Text = Strings.Trim(s.Substring(1548, 120));
                TextBox33.Text = Strings.Trim(s.Substring(1668, 120));
                TextBox31.Text = Strings.Trim(s.Substring(1788, 1200));
                RichTextBox1.Text = Strings.Trim(s.Substring(2988, 200));
                var node = TreeView1.Nodes[0];
                int v1 = TreeView1.Nodes[0].Nodes.Add(new TreeNode(Strings.Trim(TextBox1.Text)));
                int v2 = ListBox2.Items.Add(TextBox1.Text);
            }

            TreeView1.ExpandAll();
            TreeView1.Sort();

            var C = new Class1();
            C.SauveTreeView(TreeView1, OuvrirXML);
            C.ChargeTreeView(TreeView1, OuvrirXML);

            var FichierInfo = new FileInfo(OuvrirFichier);
            int TailleFichier = (int)FichierInfo.Length;

            if (!(TailleFichier == 0))
            {
                TreeView1.SelectedNode = TreeView1.Nodes[0].Nodes[0];
                TreeView1.Select();

                string foo;
                foo = TreeView1.SelectedNode.Text;
                for (int i = 0, loopTo2 = ListBox2.Items.Count - 1; i <= loopTo2; i++)
                {
                    if ((ListBox2.Items[i].ToString() ?? "") == (foo ?? ""))
                    {
                        var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                        FileOne = monfichier[i].ToString();
                    }
                }

                if (TreeView1.SelectedNode is not null)
                {
                    var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                    foreach (var u in readTexte)
                    {
                        if (u.Contains(TreeView1.SelectedNode.Text) & u.Equals(value: FileOne.ToString()))
                        {
                            TextBox2.Text = Strings.Trim(u.Substring(0, 18));
                            TextBox1.Text = Strings.Trim(u.Substring(18, 90));
                            TextBox4.Text = Strings.Trim(u.Substring(108, 120));
                            TextBox15.Text = Strings.Trim(u.Substring(228, 120));
                            TextBox5.Text = Strings.Trim(u.Substring(348, 120));
                            TextBox7.Text = Strings.Trim(u.Substring(468, 120));
                            TextBox9.Text = Strings.Trim(u.Substring(588, 120));
                            TextBox13.Text = Strings.Trim(u.Substring(708, 120));
                            TextBox18.Text = Strings.Trim(u.Substring(828, 120));
                            TextBox23.Text = Strings.Trim(u.Substring(948, 120));
                            TextBox24.Text = Strings.Trim(u.Substring(1068, 120));
                            TextBox25.Text = Strings.Trim(u.Substring(1188, 120));
                            TextBox26.Text = Strings.Trim(u.Substring(1308, 120));
                            TextBox28.Text = Strings.Trim(u.Substring(1428, 120));
                            TextBox29.Text = Strings.Trim(u.Substring(1548, 120));
                            TextBox33.Text = Strings.Trim(u.Substring(1668, 120));
                            TextBox31.Text = Strings.Trim(u.Substring(1788, 1200));
                            RichTextBox1.Text = Strings.Trim(u.Substring(2988, 200));
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(TextBox33.Text))
                {
                    PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                }
                else
                {
                    string literal = TextBox33.Text;
                    string subst = literal.Substring(0, 1);
                    PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                    string id = TextBox33.Text;
                    string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                    string filename = Path.Combine(folder, id);
                    try
                    {

                        using (var fs = File.OpenRead(filename))
                        {
                            PictureBox1.Image = Image.FromStream(fs);
                        }
                    }

                    catch (Exception ex)
                    {
                        string msg = "Nom de fichier : " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                        var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                    }

                }

            }

            foreach (var txt in new[] { TextBox1, TextBox2, TextBox4, TextBox5, TextBox7, TextBox9, TextBox13, TextBox15, TextBox18, TextBox23, TextBox24, TextBox25, TextBox26, TextBox28, TextBox29, TextBox31, TextBox33 })
                txt.ReadOnly = true;
            RichTextBox1.ReadOnly = true;

            NouveauToolStripButton.Enabled = true;
            ToolStripButton5.Enabled = true;
            NouvelleficheToolStripMenuItem.Enabled = true;
            ModifierToolStripMenuItem1.Enabled = true;

        }

        private void TreeView1_Click(object sender, EventArgs e)
        {

            int NombreDeLignes;

            // TreeView1.SelectedNode = TreeView1.GetNodeAt(TreeView1.PointToClient(Cursor.Position))
            if (TreeView1.SelectedNode.Level == 0 | Module1.Bloqué == false)
                return;
            Module1.Dialogue = false;

            // MessageBox.Show(TreeView1.SelectedNode.Index & " " & TreeView1.SelectedNode.Text, My.Application.Info.Title)

            if (ListView1.SelectedItems.Count > 0)
            {

                GenererunfichierdocxToolStripMenuItem.Enabled = true;

                ToolStripStatusLabel3.Image = My.Resources.Resources.NextDocument_16x.ToBitmap();
                ToolStripStatusLabel3.Text = "Lecture du document...";

                NombreDeLignes = ListView1.SelectedIndices[0];
                OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;

                string foo;
                foo = TreeView1.SelectedNode.Text;
                for (int i = 0, loopTo = ListBox2.Items.Count - 1; i <= loopTo; i++)
                {
                    if ((ListBox2.Items[i].ToString() ?? "") == (foo ?? ""))
                    {
                        var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                        FileOne = monfichier[i].ToString();
                    }
                }

                if (TreeView1.SelectedNode is not null)
                {
                    var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                    foreach (var t in readTexte)
                    {
                        if (t.Contains(TreeView1.SelectedNode.Text) & t.Equals(value: FileOne.ToString()))
                        {
                            TextBox2.Text = Strings.Trim(t.Substring(0, 18));
                            TextBox1.Text = Strings.Trim(t.Substring(18, 90));
                            TextBox4.Text = Strings.Trim(t.Substring(108, 120));
                            TextBox15.Text = Strings.Trim(t.Substring(228, 120));
                            TextBox5.Text = Strings.Trim(t.Substring(348, 120));
                            TextBox7.Text = Strings.Trim(t.Substring(468, 120));
                            TextBox9.Text = Strings.Trim(t.Substring(588, 120));
                            TextBox13.Text = Strings.Trim(t.Substring(708, 120));
                            TextBox18.Text = Strings.Trim(t.Substring(828, 120));
                            TextBox23.Text = Strings.Trim(t.Substring(948, 120));
                            TextBox24.Text = Strings.Trim(t.Substring(1068, 120));
                            TextBox25.Text = Strings.Trim(t.Substring(1188, 120));
                            TextBox26.Text = Strings.Trim(t.Substring(1308, 120));
                            TextBox28.Text = Strings.Trim(t.Substring(1428, 120));
                            TextBox29.Text = Strings.Trim(t.Substring(1548, 120));
                            TextBox33.Text = Strings.Trim(t.Substring(1668, 120));
                            TextBox31.Text = Strings.Trim(t.Substring(1788, 1200));
                            RichTextBox1.Text = Strings.Trim(t.Substring(2988, 200));
                        }
                    }
                }

                // MsgBox(String.Join(vbCrLf, Me.ListBox2.Items.Cast(Of String).ToArray))

                if (string.IsNullOrEmpty(TextBox33.Text))
                {
                    PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                }
                else
                {
                    string literal = TextBox33.Text;
                    string subst = literal.Substring(0, 1);
                    PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                    string id = TextBox33.Text;
                    string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                    string filename = Path.Combine(folder, id);
                    try
                    {

                        using (var fs = File.OpenRead(filename))
                        {
                            PictureBox1.Image = Image.FromStream(fs);
                            fs.Close();

                            try
                            {
                                if (PictureBox1.Image is not null)
                                {
                                    PictureBox1.Image.Dispose();
                                    PictureBox1.Image = null;
                                }
                            }

                            catch (Exception ex)
                            {
                                var unused = MessageBox.Show(ex.Message);
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        string msg = "Nom de fichier : " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                        var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                    }

                }

            }

            Module1.Dialogue = false;

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

            TreeView1.CollapseAll();

        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {

            TreeView1.ExpandAll();

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {

            // UP - PREVIOUS

            TreeNode treeNode;

            if (TreeView1.SelectedNode is null)
                return;

            treeNode = TreeView1.SelectedNode.PrevVisibleNode;

            if (treeNode is not null)
            {
                TreeView1.SelectedNode = treeNode;

                var bibliotheque = new Module1.Article();
                int NombreDeLignes;

                if (TreeView1.SelectedNode.Level == 0 | TreeView1.SelectedNode.Text == "Librairie")
                    return;

                if (ListView1.SelectedItems.Count > 0)
                {

                    NombreDeLignes = ListView1.SelectedIndices[0];
                    OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;

                    for (int i = 0, loopTo = ListBox2.Items.Count - 1; i <= loopTo; i++)
                    {
                        Foo = TreeView1.Nodes[0].Nodes[TreeView1.SelectedNode.Index].Text;
                        if ((ListBox2.Items[i].ToString() ?? "") == (Foo ?? ""))
                        {
                            var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                            FileOne = monfichier[i].ToString();
                        }
                    }

                    var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                    foreach (var y in readTexte)
                    {
                        if (y.Contains(TreeView1.Nodes[0].Nodes[TreeView1.SelectedNode.Index].Text) & y.Equals(value: FileOne.ToString()))
                        {
                            TextBox2.Text = Strings.Trim(y.Substring(0, 18));
                            TextBox1.Text = Strings.Trim(y.Substring(18, 90));
                            TextBox4.Text = Strings.Trim(y.Substring(108, 120));
                            TextBox15.Text = Strings.Trim(y.Substring(228, 120));
                            TextBox5.Text = Strings.Trim(y.Substring(348, 120));
                            TextBox7.Text = Strings.Trim(y.Substring(468, 120));
                            TextBox9.Text = Strings.Trim(y.Substring(588, 120));
                            TextBox13.Text = Strings.Trim(y.Substring(708, 120));
                            TextBox18.Text = Strings.Trim(y.Substring(828, 120));
                            TextBox23.Text = Strings.Trim(y.Substring(948, 120));
                            TextBox24.Text = Strings.Trim(y.Substring(1068, 120));
                            TextBox25.Text = Strings.Trim(y.Substring(1188, 120));
                            TextBox26.Text = Strings.Trim(y.Substring(1308, 120));
                            TextBox28.Text = Strings.Trim(y.Substring(1428, 120));
                            TextBox29.Text = Strings.Trim(y.Substring(1548, 120));
                            TextBox33.Text = Strings.Trim(y.Substring(1668, 120));
                            TextBox31.Text = Strings.Trim(y.Substring(1788, 1200));
                            RichTextBox1.Text = Strings.Trim(y.Substring(2988, 200));
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(TextBox33.Text))
                    {
                        PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                    }
                    else
                    {
                        string literal = TextBox33.Text;
                        string subst = literal.Substring(0, 1);
                        PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                        string id = TextBox33.Text;
                        string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                        string filename = Path.Combine(folder, id);
                        try
                        {
                            using (var fs = new FileStream(filename, FileMode.Open))
                            {
                                PictureBox1.Image = new Bitmap(Image.FromStream(fs));
                            }
                        }
                        catch (Exception ex)
                        {
                            string msg = "Filename: " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                            var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                        }

                    }

                }

            }

        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {

            // DOWN - NEXT

            TreeNode treeNode;

            if (TreeView1.SelectedNode is null)
                return;

            treeNode = TreeView1.SelectedNode.NextVisibleNode;

            if (treeNode is not null)
            {
                TreeView1.SelectedNode = treeNode;

                var bibliotheque = new Module1.Article();
                int NombreDeLignes;

                if (TreeView1.SelectedNode.Level == 0 | TreeView1.SelectedNode.Text == "Librairie")
                    return;

                if (ListView1.SelectedItems.Count > 0)
                {

                    NombreDeLignes = ListView1.SelectedIndices[0];
                    OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;

                    for (int i = 0, loopTo = ListBox2.Items.Count - 1; i <= loopTo; i++)
                    {
                        Foo = TreeView1.Nodes[0].Nodes[TreeView1.SelectedNode.Index].Text;
                        if ((ListBox2.Items[i].ToString() ?? "") == (Foo ?? ""))
                        {
                            var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                            FileOne = monfichier[i].ToString();
                        }
                    }

                    var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                    foreach (var x in readTexte)
                    {
                        if (x.Contains(TreeView1.Nodes[0].Nodes[TreeView1.SelectedNode.Index].Text) & x.Equals(value: FileOne.ToString()))
                        {
                            TextBox2.Text = Strings.Trim(x.Substring(0, 18));
                            TextBox1.Text = Strings.Trim(x.Substring(18, 90));
                            TextBox4.Text = Strings.Trim(x.Substring(108, 120));
                            TextBox15.Text = Strings.Trim(x.Substring(228, 120));
                            TextBox5.Text = Strings.Trim(x.Substring(348, 120));
                            TextBox7.Text = Strings.Trim(x.Substring(468, 120));
                            TextBox9.Text = Strings.Trim(x.Substring(588, 120));
                            TextBox13.Text = Strings.Trim(x.Substring(708, 120));
                            TextBox18.Text = Strings.Trim(x.Substring(828, 120));
                            TextBox23.Text = Strings.Trim(x.Substring(948, 120));
                            TextBox24.Text = Strings.Trim(x.Substring(1068, 120));
                            TextBox25.Text = Strings.Trim(x.Substring(1188, 120));
                            TextBox26.Text = Strings.Trim(x.Substring(1308, 120));
                            TextBox28.Text = Strings.Trim(x.Substring(1428, 120));
                            TextBox29.Text = Strings.Trim(x.Substring(1548, 120));
                            TextBox33.Text = Strings.Trim(x.Substring(1668, 120));
                            TextBox31.Text = Strings.Trim(x.Substring(1788, 1200));
                            RichTextBox1.Text = Strings.Trim(x.Substring(2988, 200));
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(TextBox33.Text))
                    {
                        PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                    }
                    else
                    {
                        string literal = TextBox33.Text;
                        string subst = literal.Substring(0, 1);
                        PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                        string id = TextBox33.Text;
                        string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                        string filename = Path.Combine(folder, id);
                        try
                        {
                            using (var fs = new FileStream(filename, FileMode.Open))
                            {
                                PictureBox1.Image = new Bitmap(Image.FromStream(fs));
                            }
                        }
                        catch (Exception ex)
                        {
                            string msg = "Filename: " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                            var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                        }

                    }

                }

            }

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            string st;
            int ndl;
            string Ofile;

            if (ListView1.SelectedItems.Count == 0)
            {
                var msgBoxResult = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir afficher les propriétés de celui-ci !", (MsgBoxStyle)Constants.vbYes, "Erreur");
            }
            // Sinon, on récupère le numéro de ligne
            else
            {
                ndl = ListView1.SelectedIndices[0];
                Ofile = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[ndl].Text;

                var info = new FileInfo(Ofile);

                st = "Dossier : " + info.DirectoryName + Constants.vbCrLf;
                st = st + "Nom complet : " + info.FullName + Constants.vbCrLf;
                st = st + "Nom du fichier : " + info.Name + Constants.vbCrLf;
                st = st + "Taille du fichier : " + info.Length.ToString() + " octets" + Constants.vbCrLf;
                st = st + "Attributs : " + info.Attributes.ToString() + Constants.vbCrLf;
                st = st + "Date de création : " + Conversions.ToString(info.CreationTime) + Constants.vbCrLf;
                st = st + "Dernier accès : " + Conversions.ToString(info.LastAccessTime) + Constants.vbCrLf;
                st = st + "Dernière sauvegarde : " + Conversions.ToString(info.LastWriteTime) + Constants.vbCrLf;
                var dialogResult1 = MessageBox.Show(st, My.MyProject.Application.Info.Title);
            }

        }

        private void ListeToolStripButton_Click(object sender, EventArgs e)
        {

            ListeToolStripMenuItem.PerformClick();

        }

        private void NouveauToolStripButton_Click(object sender, EventArgs e)
        {

            NouvelleficheToolStripMenuItem.PerformClick();

        }

        private void EnregistrerToolStripButton_Click(object sender, EventArgs e)
        {

            EnregistrerToolStripMenuItem.PerformClick();

        }

        private void TextBox31_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

            string testString = TextBox31.Text;

            int testLen = Strings.Len(testString);
            ToolStripStatusLabel5.Text = $"{Strings.Len(TextBox31.Text)} bytes";

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            if (Module1.lit == 0)
            {
                TextBox5.Text = DateTimePicker1.Value.ToString("d MMMM");
            }

        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {

            ModifierToolStripMenuItem1.PerformClick();

        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {

            if (EnregistrerToolStripMenuItem.Enabled | EnregistrerToolStripButton.Enabled)
            {

                PictureBox1.Image = Module1.GetImgOFD(this, PictureBox1);
                TextBox33.Text = Path.GetFileName(Module1.FileNameImage);
            }
            else
            {
                var msgBoxResult = Interaction.MsgBox("Important : veuillez modifier ou éditer les données de l'enregistreement sélectionné !");
                return;
            }

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

            var frm = new Popup();
            Bitmap MyImage;

            if (string.IsNullOrWhiteSpace(PictureBox1.ImageLocation) | PictureBox1.ImageLocation == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(TextBox33.Text) & !PictureBox1.Image.Equals(PictureBox1.ErrorImage))
            {
                string literal = TextBox33.Text;
                string subst = literal.Substring(0, 1);
                Sfichier = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;
            }
            else if (PictureBox1.Image.Equals(PictureBox1.ErrorImage))
            {
                return;
            }
            else
            {
                var msgBoxResult = Interaction.MsgBox("Aucune image n'est enregistrée dans la zone d'écran correspondante.");
                return;
            }

            MyImage = new Bitmap(Sfichier);

            // remplissage du PictureBox avec cette image
            frm.PictureBox1.Image = MyImage;

            // mettre l'image la propriété sizemode qui convient
            var dialogResult1 = frm.ShowDialog(this);

        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {

            Close(); // On quitte TOTALEMENT l'application.

        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {

            Hide(); // On cache la fenêtre.

        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            Show(); // On affiche la fenêtre.

        }

        private void AfficherLaideToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Help.ShowHelp(this, Helpfile + @"\Prenommer.chm");

        }

        private void TreeView1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {

                case Keys.Down:
                    {

                        int TotalNodesInTree = TreeView1.GetNodeCount(true);
                        int NombreDeLignes;

                        if (TreeView1.SelectedNode.Level == 0 | TreeView1.SelectedNode.Text == "Librairie")
                            return;

                        if (TreeView1.SelectedNode.Index + 1 > ListBox2.Items.Count - 1)
                            return;

                        if (ListView1.SelectedItems.Count > 0)
                        {

                            NombreDeLignes = ListView1.SelectedIndices[0];
                            OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;

                            var lastNode = TreeView1.Nodes[TreeView1.Nodes.Count - 1].Nodes[TreeView1.Nodes[TreeView1.Nodes.Count - 1].Nodes.Count - 1];

                            // MessageBox.Show("Total nodes in tree = " & TotalNodesInTree - CInt(1.ToString()))

                            for (int i = 0, loopTo = ListBox2.Items.Count - 1; i <= loopTo; i++)
                            {
                                Foo = TreeView1.Nodes[0].Nodes[TreeView1.SelectedNode.Index + 1].Text;
                                if ((ListBox2.Items[i].ToString() ?? "") == (Foo ?? ""))
                                {
                                    var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                                    FileOne = monfichier[i].ToString();
                                }
                            }

                            var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                            foreach (var t in readTexte)
                            {
                                if (lastNode.IsSelected)
                                    return;
                                if (t.Contains(TreeView1.Nodes[0].Nodes[TreeView1.SelectedNode.Index + 1].Text) & t.Equals(value: FileOne.ToString()))
                                {
                                    TextBox2.Text = Strings.Trim(t.Substring(0, 18));
                                    TextBox1.Text = Strings.Trim(t.Substring(18, 90));
                                    TextBox4.Text = Strings.Trim(t.Substring(108, 120));
                                    TextBox15.Text = Strings.Trim(t.Substring(228, 120));
                                    TextBox5.Text = Strings.Trim(t.Substring(348, 120));
                                    TextBox7.Text = Strings.Trim(t.Substring(468, 120));
                                    TextBox9.Text = Strings.Trim(t.Substring(588, 120));
                                    TextBox13.Text = Strings.Trim(t.Substring(708, 120));
                                    TextBox18.Text = Strings.Trim(t.Substring(828, 120));
                                    TextBox23.Text = Strings.Trim(t.Substring(948, 120));
                                    TextBox24.Text = Strings.Trim(t.Substring(1068, 120));
                                    TextBox25.Text = Strings.Trim(t.Substring(1188, 120));
                                    TextBox26.Text = Strings.Trim(t.Substring(1308, 120));
                                    TextBox28.Text = Strings.Trim(t.Substring(1428, 120));
                                    TextBox29.Text = Strings.Trim(t.Substring(1548, 120));
                                    TextBox33.Text = Strings.Trim(t.Substring(1668, 120));
                                    TextBox31.Text = Strings.Trim(t.Substring(1788, 1200));
                                    RichTextBox1.Text = Strings.Trim(t.Substring(2988, 200));
                                    break;
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(TextBox33.Text))
                        {
                            PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                        }
                        else
                        {
                            string literal = TextBox33.Text;
                            string subst = literal.Substring(0, 1);
                            PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                            string id = TextBox33.Text;
                            string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                            string filename = Path.Combine(folder, id);
                            try
                            {
                                using (var fs = new FileStream(filename, FileMode.Open))
                                {
                                    PictureBox1.Image = new Bitmap(Image.FromStream(fs));
                                }
                            }
                            catch (Exception ex)
                            {
                                string msg = "Filename: " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                                var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                            }

                        }

                        break;
                    }

                case Keys.Up:
                    {

                        int TotalNodesInTree = TreeView1.GetNodeCount(true);
                        int NombreDeLignes;

                        if (TreeView1.SelectedNode.Level == 0 | TreeView1.SelectedNode.Text == "Librairie")
                            return;

                        if (TreeView1.SelectedNode.Index == 0)
                            return;

                        if (ListView1.SelectedItems.Count > 0)
                        {

                            NombreDeLignes = ListView1.SelectedIndices[0];
                            OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;

                            var firstNode = TreeView1.Nodes[0].Nodes[0];

                            for (int i = 0, loopTo1 = ListBox2.Items.Count - 1; i <= loopTo1; i++)
                            {
                                Foo = TreeView1.Nodes[0].Nodes[TreeView1.SelectedNode.Index - 1].Text;
                                if ((ListBox2.Items[i].ToString() ?? "") == (Foo ?? ""))
                                {
                                    var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                                    FileOne = monfichier[i].ToString();
                                }
                            }

                            var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                            foreach (var u in readTexte)
                            {
                                if (firstNode.IsSelected)
                                    return;
                                if (u.Contains(TreeView1.Nodes[0].Nodes[TreeView1.SelectedNode.Index - 1].Text) & u.Equals(value: FileOne.ToString()))
                                {
                                    TextBox2.Text = Strings.Trim(u.Substring(0, 18));
                                    TextBox1.Text = Strings.Trim(u.Substring(18, 90));
                                    TextBox4.Text = Strings.Trim(u.Substring(108, 120));
                                    TextBox15.Text = Strings.Trim(u.Substring(228, 120));
                                    TextBox5.Text = Strings.Trim(u.Substring(348, 120));
                                    TextBox7.Text = Strings.Trim(u.Substring(468, 120));
                                    TextBox9.Text = Strings.Trim(u.Substring(588, 120));
                                    TextBox13.Text = Strings.Trim(u.Substring(708, 120));
                                    TextBox18.Text = Strings.Trim(u.Substring(828, 120));
                                    TextBox23.Text = Strings.Trim(u.Substring(948, 120));
                                    TextBox24.Text = Strings.Trim(u.Substring(1068, 120));
                                    TextBox25.Text = Strings.Trim(u.Substring(1188, 120));
                                    TextBox26.Text = Strings.Trim(u.Substring(1308, 120));
                                    TextBox28.Text = Strings.Trim(u.Substring(1428, 120));
                                    TextBox29.Text = Strings.Trim(u.Substring(1548, 120));
                                    TextBox33.Text = Strings.Trim(u.Substring(1668, 120));
                                    TextBox31.Text = Strings.Trim(u.Substring(1788, 1200));
                                    RichTextBox1.Text = Strings.Trim(u.Substring(2988, 200));
                                    break;
                                }
                            }

                            if (string.IsNullOrEmpty(TextBox33.Text))
                            {
                                PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                            }
                            else
                            {
                                string literal = TextBox33.Text;
                                string subst = literal.Substring(0, 1);
                                PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                                string id = TextBox33.Text;
                                string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                                string filename = Path.Combine(folder, id);
                                try
                                {
                                    using (var fs = new FileStream(filename, FileMode.Open))
                                    {
                                        PictureBox1.Image = new Bitmap(Image.FromStream(fs));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string msg = "Filename: " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                                    var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                                }

                            }

                        }

                        break;
                    }

                case Keys.Left:
                    {

                        if (TreeView1.SelectedNode.Level == 0 | TreeView1.SelectedNode.Text == "Librairie")
                            return;
                        TreeView1.CollapseAll();
                        break;
                    }

                case Keys.Right:
                    {

                        if (TreeView1.SelectedNode.Level == 0 | TreeView1.SelectedNode.Text == "Librairie")
                            return;
                        TreeView1.ExpandAll();
                        break;
                    }

                case Keys.Home:
                    {

                        int TotalNodesInTree = TreeView1.GetNodeCount(true);
                        int NombreDeLignes;

                        if (TreeView1.SelectedNode.Level == 0 | TreeView1.SelectedNode.Text == "Librairie")
                            return;

                        if (ListView1.SelectedItems.Count > 0)
                        {

                            NombreDeLignes = ListView1.SelectedIndices[0];
                            OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;

                            var firstNode = TreeView1.Nodes[0].Nodes[0];

                            for (int i = 0, loopTo2 = ListBox2.Items.Count - 1; i <= loopTo2; i++)
                            {
                                Foo = firstNode.Text;
                                if ((ListBox2.Items[i].ToString() ?? "") == (Foo ?? ""))
                                {
                                    var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                                    FileOne = monfichier[i].ToString();
                                }
                            }

                            var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                            foreach (var v in readTexte)
                            {
                                if (v.Contains(firstNode.Text) & v.Equals(value: FileOne.ToString()))
                                {
                                    TextBox2.Text = Strings.Trim(v.Substring(0, 18));
                                    TextBox1.Text = Strings.Trim(v.Substring(18, 90));
                                    TextBox4.Text = Strings.Trim(v.Substring(108, 120));
                                    TextBox15.Text = Strings.Trim(v.Substring(228, 120));
                                    TextBox5.Text = Strings.Trim(v.Substring(348, 120));
                                    TextBox7.Text = Strings.Trim(v.Substring(468, 120));
                                    TextBox9.Text = Strings.Trim(v.Substring(588, 120));
                                    TextBox13.Text = Strings.Trim(v.Substring(708, 120));
                                    TextBox18.Text = Strings.Trim(v.Substring(828, 120));
                                    TextBox23.Text = Strings.Trim(v.Substring(948, 120));
                                    TextBox24.Text = Strings.Trim(v.Substring(1068, 120));
                                    TextBox25.Text = Strings.Trim(v.Substring(1188, 120));
                                    TextBox26.Text = Strings.Trim(v.Substring(1308, 120));
                                    TextBox28.Text = Strings.Trim(v.Substring(1428, 120));
                                    TextBox29.Text = Strings.Trim(v.Substring(1548, 120));
                                    TextBox33.Text = Strings.Trim(v.Substring(1668, 120));
                                    TextBox31.Text = Strings.Trim(v.Substring(1788, 1200));
                                    RichTextBox1.Text = Strings.Trim(v.Substring(2988, 200));
                                }
                            }

                            if (string.IsNullOrEmpty(TextBox33.Text))
                            {
                                PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                            }
                            else
                            {
                                string literal = TextBox33.Text;
                                string subst = literal.Substring(0, 1);
                                PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                                string id = TextBox33.Text;
                                string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                                string filename = Path.Combine(folder, id);
                                try
                                {
                                    using (var fs = new FileStream(filename, FileMode.Open))
                                    {
                                        PictureBox1.Image = new Bitmap(Image.FromStream(fs));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string msg = "Filename: " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                                    var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                                }

                            }

                        }

                        break;
                    }

                case Keys.End:
                    {

                        int TotalNodesInTree = TreeView1.GetNodeCount(true);
                        int NombreDeLignes;

                        if (TreeView1.SelectedNode.Level == 0 | TreeView1.SelectedNode.Text == "Librairie")
                            var treeNode = TreeView1.SelectedNode.FirstNode;

                        if (ListView1.SelectedItems.Count > 0)
                        {

                            NombreDeLignes = ListView1.SelectedIndices[0];
                            OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + ListView1.Items[NombreDeLignes].Text;

                            var lastNode = TreeView1.Nodes[TreeView1.Nodes.Count - 1].Nodes[TreeView1.Nodes[TreeView1.Nodes.Count - 1].Nodes.Count - 1];

                            for (int i = 0, loopTo3 = ListBox2.Items.Count - 1; i <= loopTo3; i++)
                            {
                                Foo = lastNode.Text;
                                if ((ListBox2.Items[i].ToString() ?? "") == (Foo ?? ""))
                                {
                                    var monfichier = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                                    FileOne = monfichier[i].ToString();
                                }
                            }

                            var readTexte = File.ReadAllLines(OuvrirFichier, Encoding.UTF8);
                            foreach (var w in readTexte)
                            {
                                if (w.Contains(lastNode.Text) & w.Equals(value: FileOne.ToString()))
                                {
                                    TextBox2.Text = Strings.Trim(w.Substring(0, 18));
                                    TextBox1.Text = Strings.Trim(w.Substring(18, 90));
                                    TextBox4.Text = Strings.Trim(w.Substring(108, 120));
                                    TextBox15.Text = Strings.Trim(w.Substring(228, 120));
                                    TextBox5.Text = Strings.Trim(w.Substring(348, 120));
                                    TextBox7.Text = Strings.Trim(w.Substring(468, 120));
                                    TextBox9.Text = Strings.Trim(w.Substring(588, 120));
                                    TextBox13.Text = Strings.Trim(w.Substring(708, 120));
                                    TextBox18.Text = Strings.Trim(w.Substring(828, 120));
                                    TextBox23.Text = Strings.Trim(w.Substring(948, 120));
                                    TextBox24.Text = Strings.Trim(w.Substring(1068, 120));
                                    TextBox25.Text = Strings.Trim(w.Substring(1188, 120));
                                    TextBox26.Text = Strings.Trim(w.Substring(1308, 120));
                                    TextBox28.Text = Strings.Trim(w.Substring(1428, 120));
                                    TextBox29.Text = Strings.Trim(w.Substring(1548, 120));
                                    TextBox33.Text = Strings.Trim(w.Substring(1668, 120));
                                    TextBox31.Text = Strings.Trim(w.Substring(1788, 1200));
                                    RichTextBox1.Text = Strings.Trim(w.Substring(2988, 200));
                                }
                            }

                            if (string.IsNullOrEmpty(TextBox33.Text))
                            {
                                PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                            }
                            else
                            {
                                string literal = TextBox33.Text;
                                string subst = literal.Substring(0, 1);
                                PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + TextBox33.Text;

                                string id = TextBox33.Text;
                                string folder = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\";
                                string filename = Path.Combine(folder, id);
                                try
                                {
                                    using (var fs = new FileStream(filename, FileMode.Open))
                                    {
                                        PictureBox1.Image = new Bitmap(Image.FromStream(fs));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string msg = "Filename: " + filename + Environment.NewLine + Environment.NewLine + "Exception : " + ex.ToString();
                                    var dialogResult1 = MessageBox.Show(msg, "Erreur lors de l'ouverture du fichier image.");
                                }

                            }

                        }

                        break;
                    }

                case Keys.KeyCode:
                    {
                        break;
                    }
                case Keys.Modifiers:
                    {
                        break;
                    }
                case Keys.None:
                    {
                        break;
                    }
                case Keys.LButton:
                    {
                        break;
                    }
                case Keys.RButton:
                    {
                        break;
                    }
                case Keys.Cancel:
                    {
                        break;
                    }
                case Keys.MButton:
                    {
                        break;
                    }
                case Keys.XButton1:
                    {
                        break;
                    }
                case Keys.XButton2:
                    {
                        break;
                    }
                case Keys.Back:
                    {
                        break;
                    }
                case Keys.Tab:
                    {
                        break;
                    }
                case Keys.LineFeed:
                    {
                        break;
                    }
                case Keys.Clear:
                    {
                        break;
                    }
                case Keys.Return:
                    {
                        break;
                    }
                case Keys.ShiftKey:
                    {
                        break;
                    }
                case Keys.ControlKey:
                    {
                        break;
                    }
                case Keys.Menu:
                    {
                        break;
                    }
                case Keys.Pause:
                    {
                        break;
                    }
                case Keys.Capital:
                    {
                        break;
                    }
                case Keys.KanaMode:
                    {
                        break;
                    }
                case Keys.JunjaMode:
                    {
                        break;
                    }
                case Keys.FinalMode:
                    {
                        break;
                    }
                case Keys.HanjaMode:
                    {
                        break;
                    }
                case Keys.Escape:
                    {
                        break;
                    }
                case Keys.IMEConvert:
                    {
                        break;
                    }
                case Keys.IMENonconvert:
                    {
                        break;
                    }
                case Keys.IMEAccept:
                    {
                        break;
                    }
                case Keys.IMEModeChange:
                    {
                        break;
                    }
                case Keys.Space:
                    {
                        break;
                    }
                case Keys.Prior:
                    {
                        break;
                    }
                case Keys.Next:
                    {
                        break;
                    }
                case Keys.Select:
                    {
                        break;
                    }
                case Keys.Print:
                    {
                        break;
                    }
                case Keys.Execute:
                    {
                        break;
                    }
                case Keys.Snapshot:
                    {
                        break;
                    }
                case Keys.Insert:
                    {
                        break;
                    }
                case Keys.Delete:
                    {
                        break;
                    }
                case Keys.Help:
                    {
                        break;
                    }
                case Keys.D0:
                    {
                        break;
                    }
                case Keys.D1:
                    {
                        break;
                    }
                case Keys.D2:
                    {
                        break;
                    }
                case Keys.D3:
                    {
                        break;
                    }
                case Keys.D4:
                    {
                        break;
                    }
                case Keys.D5:
                    {
                        break;
                    }
                case Keys.D6:
                    {
                        break;
                    }
                case Keys.D7:
                    {
                        break;
                    }
                case Keys.D8:
                    {
                        break;
                    }
                case Keys.D9:
                    {
                        break;
                    }
                case Keys.A:
                    {
                        break;
                    }
                case Keys.B:
                    {
                        break;
                    }
                case Keys.C:
                    {
                        break;
                    }
                case Keys.D:
                    {
                        break;
                    }
                case Keys.E:
                    {
                        break;
                    }
                case Keys.F:
                    {
                        break;
                    }
                case Keys.G:
                    {
                        break;
                    }
                case Keys.H:
                    {
                        break;
                    }
                case Keys.I:
                    {
                        break;
                    }
                case Keys.J:
                    {
                        break;
                    }
                case Keys.K:
                    {
                        break;
                    }
                case Keys.L:
                    {
                        break;
                    }
                case Keys.M:
                    {
                        break;
                    }
                case Keys.N:
                    {
                        break;
                    }
                case Keys.O:
                    {
                        break;
                    }
                case Keys.P:
                    {
                        break;
                    }
                case Keys.Q:
                    {
                        break;
                    }
                case Keys.R:
                    {
                        break;
                    }
                case Keys.S:
                    {
                        break;
                    }
                case Keys.T:
                    {
                        break;
                    }
                case Keys.U:
                    {
                        break;
                    }
                case Keys.V:
                    {
                        break;
                    }
                case Keys.W:
                    {
                        break;
                    }
                case Keys.X:
                    {
                        break;
                    }
                case Keys.Y:
                    {
                        break;
                    }
                case Keys.Z:
                    {
                        break;
                    }
                case Keys.LWin:
                    {
                        break;
                    }
                case Keys.RWin:
                    {
                        break;
                    }
                case Keys.Apps:
                    {
                        break;
                    }
                case Keys.Sleep:
                    {
                        break;
                    }
                case Keys.NumPad0:
                    {
                        break;
                    }
                case Keys.NumPad1:
                    {
                        break;
                    }
                case Keys.NumPad2:
                    {
                        break;
                    }
                case Keys.NumPad3:
                    {
                        break;
                    }
                case Keys.NumPad4:
                    {
                        break;
                    }
                case Keys.NumPad5:
                    {
                        break;
                    }
                case Keys.NumPad6:
                    {
                        break;
                    }
                case Keys.NumPad7:
                    {
                        break;
                    }
                case Keys.NumPad8:
                    {
                        break;
                    }
                case Keys.NumPad9:
                    {
                        break;
                    }
                case Keys.Multiply:
                    {
                        break;
                    }
                case Keys.Add:
                    {
                        break;
                    }
                case Keys.Separator:
                    {
                        break;
                    }
                case Keys.Subtract:
                    {
                        break;
                    }
                case Keys.Decimal:
                    {
                        break;
                    }
                case Keys.Divide:
                    {
                        break;
                    }
                case Keys.F1:
                    {
                        break;
                    }
                case Keys.F2:
                    {
                        break;
                    }
                case Keys.F3:
                    {
                        break;
                    }
                case Keys.F4:
                    {
                        break;
                    }
                case Keys.F5:
                    {
                        break;
                    }
                case Keys.F6:
                    {
                        break;
                    }
                case Keys.F7:
                    {
                        break;
                    }
                case Keys.F8:
                    {
                        break;
                    }
                case Keys.F9:
                    {
                        break;
                    }
                case Keys.F10:
                    {
                        break;
                    }
                case Keys.F11:
                    {
                        break;
                    }
                case Keys.F12:
                    {
                        break;
                    }
                case Keys.F13:
                    {
                        break;
                    }
                case Keys.F14:
                    {
                        break;
                    }
                case Keys.F15:
                    {
                        break;
                    }
                case Keys.F16:
                    {
                        break;
                    }
                case Keys.F17:
                    {
                        break;
                    }
                case Keys.F18:
                    {
                        break;
                    }
                case Keys.F19:
                    {
                        break;
                    }
                case Keys.F20:
                    {
                        break;
                    }
                case Keys.F21:
                    {
                        break;
                    }
                case Keys.F22:
                    {
                        break;
                    }
                case Keys.F23:
                    {
                        break;
                    }
                case Keys.F24:
                    {
                        break;
                    }
                case Keys.NumLock:
                    {
                        break;
                    }
                case Keys.Scroll:
                    {
                        break;
                    }
                case Keys.LShiftKey:
                    {
                        break;
                    }
                case Keys.RShiftKey:
                    {
                        break;
                    }
                case Keys.LControlKey:
                    {
                        break;
                    }
                case Keys.RControlKey:
                    {
                        break;
                    }
                case Keys.LMenu:
                    {
                        break;
                    }
                case Keys.RMenu:
                    {
                        break;
                    }
                case Keys.BrowserBack:
                    {
                        break;
                    }
                case Keys.BrowserForward:
                    {
                        break;
                    }
                case Keys.BrowserRefresh:
                    {
                        break;
                    }
                case Keys.BrowserStop:
                    {
                        break;
                    }
                case Keys.BrowserSearch:
                    {
                        break;
                    }
                case Keys.BrowserFavorites:
                    {
                        break;
                    }
                case Keys.BrowserHome:
                    {
                        break;
                    }
                case Keys.VolumeMute:
                    {
                        break;
                    }
                case Keys.VolumeDown:
                    {
                        break;
                    }
                case Keys.VolumeUp:
                    {
                        break;
                    }
                case Keys.MediaNextTrack:
                    {
                        break;
                    }
                case Keys.MediaPreviousTrack:
                    {
                        break;
                    }
                case Keys.MediaStop:
                    {
                        break;
                    }
                case Keys.MediaPlayPause:
                    {
                        break;
                    }
                case Keys.LaunchMail:
                    {
                        break;
                    }
                case Keys.SelectMedia:
                    {
                        break;
                    }
                case Keys.LaunchApplication1:
                    {
                        break;
                    }
                case Keys.LaunchApplication2:
                    {
                        break;
                    }
                case Keys.OemSemicolon:
                    {
                        break;
                    }
                case Keys.Oemplus:
                    {
                        break;
                    }
                case Keys.Oemcomma:
                    {
                        break;
                    }
                case Keys.OemMinus:
                    {
                        break;
                    }
                case Keys.OemPeriod:
                    {
                        break;
                    }
                case Keys.OemQuestion:
                    {
                        break;
                    }
                case Keys.Oemtilde:
                    {
                        break;
                    }
                case Keys.OemOpenBrackets:
                    {
                        break;
                    }
                case Keys.OemPipe:
                    {
                        break;
                    }
                case Keys.OemCloseBrackets:
                    {
                        break;
                    }
                case Keys.OemQuotes:
                    {
                        break;
                    }
                case Keys.Oem8:
                    {
                        break;
                    }
                case Keys.OemBackslash:
                    {
                        break;
                    }
                case Keys.ProcessKey:
                    {
                        break;
                    }
                case Keys.Packet:
                    {
                        break;
                    }
                case Keys.Attn:
                    {
                        break;
                    }
                case Keys.Crsel:
                    {
                        break;
                    }
                case Keys.Exsel:
                    {
                        break;
                    }
                case Keys.EraseEof:
                    {
                        break;
                    }
                case Keys.Play:
                    {
                        break;
                    }
                case Keys.Zoom:
                    {
                        break;
                    }
                case Keys.NoName:
                    {
                        break;
                    }
                case Keys.Pa1:
                    {
                        break;
                    }
                case Keys.OemClear:
                    {
                        break;
                    }
                case Keys.Shift:
                    {
                        break;
                    }
                case Keys.Control:
                    {
                        break;
                    }
                case Keys.Alt:
                    {
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

        }

        private static void CopyDirectory(string sourcePath, string destPath)
        {

            if (File.Exists(sourcePath))
            {

                File.Copy(sourcePath, destPath, overwrite: false);
                var msgBoxResult = Interaction.MsgBox("Fiché copié vers " + destPath);

            }

        }

        public void GenererunfichierxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ListView1.SelectedItems.Count > 0)
            {
                var msgBoxResult = Interaction.MsgBox("Générer un fichier XML.");

                // Create the XmlDocument.
                var XmlDoc = new XmlDocument();

                XmlDoc.LoadXml("<Prénommer></Prénommer>");

                // Dim root As XmlNode = XmlDoc.DocumentElement

                XmlElement elemFiche; // ElemSite pour le nœud [Fiche][/Fiche]

                XmlElement elemTitle; // ElemSite pour le nœud [Title][/Title]
                elemTitle = XmlDoc.CreateElement("Title");
                elemTitle.InnerText = TextBox2.Text;

                XmlElement elemName; // ElemSite pour le nœud [Name][/Name]
                elemName = XmlDoc.CreateElement("Name");
                elemName.InnerText = TextBox1.Text;

                XmlElement elemCharge;
                elemCharge = XmlDoc.CreateElement("Charge");
                elemCharge.InnerText = TextBox4.Text;

                XmlElement elemInstitute;
                elemInstitute = XmlDoc.CreateElement("Institute");
                elemInstitute.InnerText = TextBox15.Text;

                XmlElement elemCelebration;
                elemCelebration = XmlDoc.CreateElement("Celebration");
                elemCelebration.InnerText = TextBox5.Text;

                XmlElement elemBirth;
                elemBirth = XmlDoc.CreateElement("Birth");
                elemBirth.InnerText = TextBox7.Text;

                XmlElement elemDeath;
                elemDeath = XmlDoc.CreateElement("Death");
                elemDeath.InnerText = TextBox9.Text;

                XmlElement elemOtherparties;
                elemOtherparties = XmlDoc.CreateElement("Otherparties");
                elemOtherparties.InnerText = TextBox13.Text;

                XmlElement elemOthernames;
                elemOthernames = XmlDoc.CreateElement("Othernames");
                elemOthernames.InnerText = TextBox18.Text;

                XmlElement elemVenerable;
                elemVenerable = XmlDoc.CreateElement("Venerable");
                elemVenerable.InnerText = TextBox23.Text;

                XmlElement elemBeatified;
                elemBeatified = XmlDoc.CreateElement("Beatified");
                elemBeatified.InnerText = TextBox24.Text;

                XmlElement elemCanonized;
                elemCanonized = XmlDoc.CreateElement("Canonized");
                elemCanonized.InnerText = TextBox25.Text;

                XmlElement elemHeading;
                elemHeading = XmlDoc.CreateElement("Heading");
                elemHeading.InnerText = TextBox26.Text;

                XmlElement elemPatron;
                elemPatron = XmlDoc.CreateElement("Patron");
                elemPatron.InnerText = TextBox28.Text;

                XmlElement elemLink;
                elemLink = XmlDoc.CreateElement("Link");
                elemLink.InnerText = TextBox29.Text;

                XmlElement elemBiography;
                elemBiography = XmlDoc.CreateElement("Biography");
                elemBiography.InnerText = TextBox31.Text;

                XmlElement elemImage;
                elemImage = XmlDoc.CreateElement("Image");
                elemImage.InnerText = TextBox33.Text;

                XmlElement elemOrigin;
                elemOrigin = XmlDoc.CreateElement("Origin");
                elemOrigin.InnerText = RichTextBox1.Text;

                elemFiche = XmlDoc.CreateElement("Fiche");

                var xmlNode = elemFiche.AppendChild(elemTitle);
                var xmlNode1 = elemFiche.AppendChild(elemName);
                var xmlNode2 = elemFiche.AppendChild(elemCharge);
                var xmlNode3 = elemFiche.AppendChild(elemInstitute);
                var xmlNode4 = elemFiche.AppendChild(elemCelebration);
                var xmlNode5 = elemFiche.AppendChild(elemBirth);
                var xmlNode6 = elemFiche.AppendChild(elemDeath);
                var xmlNode7 = elemFiche.AppendChild(elemOtherparties);
                var xmlNode8 = elemFiche.AppendChild(elemOthernames);
                var xmlNode9 = elemFiche.AppendChild(elemVenerable);
                var xmlNode10 = elemFiche.AppendChild(elemBeatified);
                var xmlNode11 = elemFiche.AppendChild(elemCanonized);
                var xmlNode12 = elemFiche.AppendChild(elemHeading);
                var xmlNode13 = elemFiche.AppendChild(elemPatron);
                var xmlNode14 = elemFiche.AppendChild(elemLink);
                var xmlNode15 = elemFiche.AppendChild(elemBiography);
                var xmlNode16 = elemFiche.AppendChild(elemImage);
                var xmlNode17 = elemFiche.AppendChild(elemOrigin);

                var xmlNode18 = XmlDoc.DocumentElement.AppendChild(elemFiche);

                var settings = new XmlWriterSettings() { Indent = true };

                // Save the document to a file and auto-indent the output.

                var writer = XmlWriter.Create(My.MyProject.Application.Info.DirectoryPath + @"\Xml\" + TextBox1.Text + ".xml", settings);
                XmlDoc.Save(writer);
                var msgBoxResult1 = Interaction.MsgBox("Génération et enregistrement du fichier xml standard réussis.");

                int v = ToolStripComboBox1.Items.Add(TextBox1.Text + ".xml");
            }

            else
            {
                var msgBoxResult = Interaction.MsgBox("Afin de créer un fichier xml standard, vous devez sélectionner un document d'un fichier librairie !");
            }

        }

        public void LireunfichierxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(ToolStripComboBox1.Text))
            {
                var msgBoxResult = Interaction.MsgBox("Aucun fichier .xml sélectionné.");
                return;
            }

            if (ListView1.SelectedItems.Count > 0)
            {

                var msgBoxResult = Interaction.MsgBox("Lire ou créer une fiche à partir d'un fichier XML. Vous devez, au préalable, sélectionner un fichier librairie.");

                // creation d'une nouvelle instance du membre xmldocument
                var XmlDoc = new XmlDocument();

                FileXml = ToolStripComboBox1.SelectedText.ToString();
                var dialogResult1 = MessageBox.Show(FileXml);
                var msgBoxResult1 = Interaction.MsgBox(Strings.Trim(Path.GetFileNameWithoutExtension(FileXml)));

                TreeView1.SelectedNode = null;

                int TotalNodesInTree = TreeView1.Nodes[0].GetNodeCount(true);
                var dialogResult2 = MessageBox.Show("Nombre total de nœuds dans l'arborescence = " + TotalNodesInTree.ToString());

                foreach (TreeNode tn in TreeView1.Nodes)
                {
                    foreach (TreeNode child in tn.Nodes)
                    {
                        if ((Strings.Trim(child.Text) ?? "") == (Path.GetFileNameWithoutExtension(FileXml) ?? ""))
                        {
                            var msgBoxResult2 = Interaction.MsgBox(child.Text + " : Doublon, veuillez renommer le nom du fichier xml en lui adjoignant une numérotation entre parenthèses ou crochets par exemple !");
                            return;
                        }
                    }
                }

                NouveauToolStripButton.PerformClick();

                XmlDoc.Load(My.MyProject.Application.Info.DirectoryPath + @"\Xml\" + FileXml);

                var msgBoxResult3 = Interaction.MsgBox(My.MyProject.Application.Info.DirectoryPath + @"\Xml\" + FileXml);

                XmlNodeList element;
                element = XmlDoc.DocumentElement.GetElementsByTagName("Fiche");

                foreach (XmlNode noeud in element)
                {
                    foreach (XmlNode noeudEnf in noeud.ChildNodes)
                    {
                        if (noeudEnf.LocalName == "Title")
                        {
                            TextBox2.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Name")
                        {
                            TextBox1.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Charge")
                        {
                            TextBox4.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Institute")
                        {
                            TextBox15.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Celebration")
                        {
                            TextBox5.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Birth")
                        {
                            TextBox7.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Death")
                        {
                            TextBox9.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Otherparties")
                        {
                            TextBox13.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Othernames")
                        {
                            TextBox18.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Venerable")
                        {
                            TextBox23.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Beatified")
                        {
                            TextBox24.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Canonized")
                        {
                            TextBox25.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Heading")
                        {
                            TextBox26.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Patron")
                        {
                            TextBox28.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Link")
                        {
                            TextBox29.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Biography")
                        {
                            TextBox31.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Image")
                        {
                            TextBox33.Text = noeudEnf.InnerText;
                        }
                        else if (noeudEnf.LocalName == "Origin")
                        {
                            RichTextBox1.Text = noeudEnf.InnerText;
                        }
                    }
                }
            }
            var msgBoxResult4 = Interaction.MsgBox("Important ! Enregistrement du Xml.");
            EnregistrerToolStripMenuItem.Enabled = true;
            EnregistrerToolStripButton.Enabled = true;

            File.Delete(My.MyProject.Application.Info.DirectoryPath + @"\Xml\" + FileXml);

            string resultat;
            ToolStripComboBox1.Items.Clear();
            ListBox1.Items.Clear();
            var fileNames = My.MyProject.Computer.FileSystem.GetFiles(My.MyProject.Application.Info.DirectoryPath + @"\Xml" + @"\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*");
            foreach (string fileName in fileNames)
            {
                resultat = Path.GetFileName(fileName);
                int v = ToolStripComboBox1.Items.Add(resultat);
                int v1 = ListBox1.Items.Add(resultat);
            }
            ToolStripComboBox1.Text = "";

        }

        public void GenererunfichierdocxToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (TreeView1.SelectedNode.Text == "Librairie" | TreeView1.Nodes.Count == 0)
            {

                var msgBoxResult1 = Interaction.MsgBox("Vous devez sélectionner une fiche avant de pouvoir créer ou générer un fichier au format de document Office Open XML pour Word (.docx) !");
                return;
            }

            else
            {

                try
                {

                    const string stOD_SUBKEY = @"\Word.Application\CurVer";
                    RegistryKey rkVersionKey = null;
                    rkVersionKey = Registry.ClassesRoot.OpenSubKey(name: stOD_SUBKEY, writable: false);

                    if (rkVersionKey is null)
                    {
                        var msgBoxResult = Interaction.MsgBox("La lecture d'un document .docx nécessite notamment que Word soit installé.");
                    }

                    string filepath = My.MyProject.Application.Info.DirectoryPath + @"\" + TextBox1.Text + ".docx";

                    // Create a document by supplying the filepath.
                    using (var wordDocument = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
                    {

                        // Add a main document part. 
                        var mainPart = wordDocument.AddMainDocumentPart();

                        // Create the document structure and add some text.
                        mainPart.Document = new Document();
                        var body = mainPart.Document.AppendChild(new Body());
                        var para = body.AppendChild(new Paragraph());
                        var run = para.AppendChild(new Run());
                        var text2 = run.AppendChild(new Text(TextBox2.Text + " " + TextBox1.Text + ControlChars.Cr));

                        var run1Properties = new RunProperties();
                        run1Properties.Append(new Bold());

                        var size = new FontSize() { Val = new StringValue("36") };
                        run1Properties.Append(size);
                        run.RunProperties = run1Properties;

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text3 = run.AppendChild(new Text(TextBox4.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text5 = run.AppendChild(new Text(TextBox15.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text6 = run.AppendChild(new Text(TextBox5.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text7 = run.AppendChild(new Text(TextBox7.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text8 = run.AppendChild(new Text(TextBox9.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text9 = run.AppendChild(new Text(TextBox13.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text10 = run.AppendChild(new Text(TextBox18.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text11 = run.AppendChild(new Text(TextBox23.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text12 = run.AppendChild(new Text(TextBox24.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text13 = run.AppendChild(new Text(TextBox25.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text14 = run.AppendChild(new Text(TextBox26.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text15 = run.AppendChild(new Text(TextBox28.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text16 = run.AppendChild(new Text(TextBox29.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text4 = run.AppendChild(new Text(TextBox33.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text17 = run.AppendChild(new Text(TextBox31.Text + ControlChars.Cr));

                        para = body.AppendChild(new Paragraph());
                        run = para.AppendChild(new Run());
                        var text18 = run.AppendChild(new Text(RichTextBox1.Text + ControlChars.Cr));

                        var mainDocPart = wordDocument.MainDocumentPart;
                        var footerPart1 = mainDocPart.AddNewPart<FooterPart>("r98");
                        var footer1 = new Footer();
                        var paragraph1 = new Paragraph();

                        var run1 = new Run();
                        var text1 = new Text() { Text = "Prénommer - " + DateTime.Now.ToString() };
                        run1.Append(text1);
                        paragraph1.Append(run1);
                        footer1.Append(paragraph1);
                        footerPart1.Footer = footer1;
                        var sectionProperties1 = mainDocPart.Document.Body.Descendants<SectionProperties>().FirstOrDefault();
                        if (sectionProperties1 is null)
                        {
                            sectionProperties1 = new SectionProperties();
                            mainDocPart.Document.Body.Append(sectionProperties1);
                        }
                        var footerReference1 = new FooterReference()
                        {
                            Type = HeaderFooterValues.Default,
                            Id = "r98"
                        };
                        var footerReference = sectionProperties1.InsertAt(footerReference1, 0);

                        wordDocument.Close();

                        if (!string.IsNullOrEmpty(TextBox33.Text) | File.Exists(My.MyProject.Application.Info.DirectoryPath + @"\Images\" + TextBox1.Text.Substring(0, 1) + @"\" + TextBox33.Text))
                        {
                            if (TextBox33.Text.Substring(0, 1) != "#")
                            {
                                string document = My.MyProject.Application.Info.DirectoryPath + @"\" + TextBox1.Text + ".docx";
                                string fileName = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + TextBox1.Text.Substring(0, 1) + @"\" + TextBox33.Text;
                                InsertAPicture(document, fileName);
                            }
                        }

                        ConvToDocx(filepath);

                        // wordDocument.MainDocumentPart.Document.Save()
                        // wordDocument.Close()

                        Cursor = Cursors.WaitCursor;
                        // MsgBox("Veuillez maintenant exporter le fichier Word (modifier le type de fichier) en document (.docx) sous Word notamment, puis enregister sous ce format. Les fichiers (.docx) peuvent être visualisés par les utilisateurs d’ordinateurs avec Microsoft Word 2007 ou une version ultérieure.")

                        if (rkVersionKey is not null)
                        {
                            var unused = Process.Start(filepath);

                            System.Windows.Forms.Application.DoEvents();

                            // For Each p As Process In Process.GetProcessesByName("winword")

                            // Try
                            // P.Kill()
                            // P.WaitForExit() ' possibly with a timeout
                            // ' process was terminating or can't be terminated - deal with it
                            // Catch winException As Win32Exception
                            // Catch invalidException As InvalidOperationException
                            // ' process has already exited - might be able to let this one go
                            // End Try
                            // Next

                            var proc = Process.GetProcessesByName("winword");
                            for (int i = 0, loopTo = proc.Count() - 1; i <= loopTo; i++)
                                bool v = proc[i].CloseMainWindow();
                        }

                        else
                        {
                            var msgBoxResult = Interaction.MsgBox("LibreOffice prend notamment en charge les formats Open XML de Microsoft Office (.docx, .xlsx, .pptx).");
                        }
                        Cursor = Cursors.Default;

                    }
                }

                catch (Exception ex)
                {
                    // Show the exception's message.
                    var dialogResult2 = MessageBox.Show(ex.Message);

                    // Show the stack trace, which is a list of methods
                    // that are currently executing.
                    var dialogResult1 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + ex.StackTrace);
                }
                finally
                {
                    // This line executes whether or not the exception occurs.
                    var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");
                }

            }

        }

        private void TreeView1_MouseMove(object sender, MouseEventArgs e)
        {

            // Récupération du TreeNode survolé 
            var currentNode = TreeView1.GetNodeAt(e.X, e.Y);

            // Vérification que la souris survole bien un TreeNode 
            if (currentNode is null)
            {
                GenererunfichierdocxToolStripMenuItem.Enabled = false;
            }

        }

        public void FindMySpecificString(string searchString)
        {

            // Ensure we have a proper string to search for.
            if (!string.IsNullOrEmpty(searchString))
            {
                // Find the item in the list and store the index to the item.
                Module1.IndexEnreg = ListBox2.FindStringExact(searchString);

                // Determine if a valid index is returned. Select the item if it is valid.
                if (Module1.IndexEnreg != -1)
                {
                    ListBox2.SetSelected(Module1.IndexEnreg, true);
                }
                else
                {
                    var dialogResult1 = MessageBox.Show("La chaîne de recherche ne correspond à aucun élément de la zone de liste.");
                }
            }

        }

        private void TreeView1_MouseDown(object sender, MouseEventArgs e)
        {

            var hit = TreeView1.HitTest(e.X, e.Y);

            if (hit.Node is null)
            {
                TreeView1.SelectedNode = null;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            int i = 1;
            foreach (string ItList in ListBox2.Items)
            {
                MessageBox.Show(ItList.ToString(), "Element " + i.ToString(), MessageBoxButtons.OK);
                i += 1;
            }

        }

        public void PrintDocumentUsingShellExecute(string szPrinter, string szDocumentPath)
        {

            var szDefaultPrinter = new StringBuilder(256);
            int bufferSize = szDefaultPrinter.Capacity;

            // get the default printer
            bool v = Module1.GetDefaultPrinter(szDefaultPrinter, ref bufferSize);

            // change the default printer
            if (string.Compare(szPrinter, szDefaultPrinter.ToString(), true) != 0)
            {
                bool v1 = Module1.SetDefaultPrinter(ref szPrinter);
            }

            // send the document  to the print 
            var printProcess = new Process();
            printProcess.StartInfo.FileName = szDocumentPath;
            printProcess.StartInfo.Verb = "Print";
            printProcess.StartInfo.CreateNoWindow = true;
            bool v2 = printProcess.Start();

            // set default printer back to original
            if (string.Compare(szPrinter, szDefaultPrinter.ToString()) != 0)
            {
                string argszPrinter = szDefaultPrinter.ToString();
                bool v1 = Module1.SetDefaultPrinter(ref argszPrinter);
            }

        }

        public void InsertAPicture(string document, string fileName)
        {

            using (var wordprocessingDocument = WordprocessingDocument.Open(document, true))
            {
                var mainPart = wordprocessingDocument.MainDocumentPart;

                var imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }

                AddImageToBody(wordprocessingDocument, mainPart.GetIdOfPart(imagePart));
            }

        }

        public void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the reference of the image. {.Cx = 990000L, .Cy = 792000L}   'Name = "New Bitmap Image.jpg"

            var sz = new Bitmap(My.MyProject.Application.Info.DirectoryPath + @"\Images\" + TextBox1.Text.Substring(0, 1) + @"\" + TextBox33.Text);

            var size = new Size(sz.Width, sz.Height); // (584, 361)
            Int64Value width = (Int64Value)(size.Width * 9525 / 2d);
            Int64Value height = (Int64Value)(size.Height * 9525 / 2d);

            var element = new Drawing(new DW.Inline(new DW.Extent() { Cx = width, Cy = height }, new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L }, new DW.DocProperties() { Id = 1U, Name = "Picture1" }, new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks() { NoChangeAspect = true }), new A.Graphic(new A.GraphicData(new PIC.Picture(new PIC.NonVisualPictureProperties(new PIC.NonVisualDrawingProperties() { Id = 0U, Name = TextBox33.Text }, new PIC.NonVisualPictureDrawingProperties()), new PIC.BlipFill(new A.Blip(new A.BlipExtensionList(new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" })) { Embed = relationshipId, CompressionState = A.BlipCompressionValues.Print }, new A.Stretch(new A.FillRectangle())), new PIC.ShapeProperties(new A.Transform2D(new A.Offset() { X = 0L, Y = 0L }, new A.Extents() { Cx = width, Cy = height }), new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle }))) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }))
            {
                DistanceFromTop = 0U,
                DistanceFromBottom = 0U,
                DistanceFromLeft = 0U,
                DistanceFromRight = 0U
            });

            // Append the reference to body, the element should be in a Run.
            var paragraph = wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));

        }

        public void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {

            StreamWriter file;

            if (!string.IsNullOrEmpty(TextBox1.Text))
            {

                file = My.MyProject.Computer.FileSystem.OpenTextFileWriter(My.MyProject.Application.Info.DirectoryPath + @"\" + TextBox1.Text + ".txt", true);
                file.WriteLine(TextBox2.Text + " " + TextBox1.Text + Constants.vbCrLf);
                file.WriteLine(TextBox4.Text + Constants.vbCrLf);
                file.WriteLine(TextBox15.Text + Constants.vbCrLf);
                file.WriteLine(TextBox5.Text + Constants.vbCrLf);
                file.WriteLine(TextBox7.Text + Constants.vbCrLf);
                file.WriteLine(TextBox9.Text + Constants.vbCrLf);
                file.WriteLine(TextBox13.Text + Constants.vbCrLf);
                file.WriteLine(TextBox18.Text + Constants.vbCrLf);
                file.WriteLine(TextBox23.Text + Constants.vbCrLf);
                file.WriteLine(TextBox24.Text + Constants.vbCrLf);
                file.WriteLine(TextBox25.Text + Constants.vbCrLf);
                file.WriteLine(TextBox26.Text + Constants.vbCrLf);
                file.WriteLine(TextBox28.Text + Constants.vbCrLf);
                file.WriteLine(TextBox29.Text + Constants.vbCrLf);
                file.WriteLine(TextBox33.Text + Constants.vbCrLf);
                file.WriteLine(TextBox31.Text + Constants.vbCrLf);
                file.WriteLine(RichTextBox1.Text + Constants.vbCrLf);

                file.WriteLine(" ");
                file.Write("Date : ");
                file.WriteLine(DateTime.Now);

                file.Close();

                var msgBoxResult = Interaction.MsgBox("L'exécution du processus est terminée.");
            }

            else
            {
                return;
            }

        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {

            StreamWriter write;

            try
            {

                if (string.IsNullOrEmpty(TextBox1.Text))
                {
                    var msgBoxResult = Interaction.MsgBox("Impossible d'accéder à un dossier ou à l'un de ses composants.");
                    return;
                }

                if (!string.IsNullOrEmpty(TextBox1.Text))
                {

                    string fic = My.MyProject.Application.Info.DirectoryPath + @"\" + TextBox1.Text + ".rtf";

                    write = File.CreateText(My.MyProject.Application.Info.DirectoryPath + @"\" + TextBox1.Text + ".rtf");

                    write.WriteLine(TextBox2.Text + " " + TextBox1.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox4.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox15.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox5.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox7.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox9.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox13.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox18.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox23.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox24.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox25.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox26.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox28.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox29.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox33.Text + Constants.vbCrLf);
                    write.WriteLine(TextBox31.Text + Constants.vbCrLf);
                    write.WriteLine(RichTextBox1.Text + Constants.vbCrLf);

                    write.WriteLine(" ");
                    write.Write("Date : ");
                    write.WriteLine(DateTime.Now);

                    write.Close();

                }
            }

            catch (Exception ex)
            {
                var dialogResult1 = MessageBox.Show(ex.Message);
            }
            finally
            {
                var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");
            }

        }

        public string GetUserName()
        {

            if (My.MyProject.User.CurrentPrincipal is System.Security.Principal.WindowsPrincipal)
            {
                // The application is using Windows authentication.
                // The name format is DOMAIN\USERNAME.
                var parts = Strings.Split(My.MyProject.User.Name, @"\");
                string username = parts[1];
                return username;
            }
            else
            {
                // The application is using custom authentication.
                return My.MyProject.User.Name;
            }

        }

        public void RechercherlesmisesajourToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (TestInternetConnection())
            {
                var unused = Process.Start(default
#error Cannot convert LiteralExpressionSyntax - see comment for details
    /* Cannot convert LiteralExpressionSyntax, System.ArgumentOutOfRangeException: La longueur ne peut pas être inférieure à zéro.
    Nom du paramètre : length
       à System.String.Substring(Int32 startIndex, Int32 length)
       à ICSharpCode.CodeConverter.CSharp.LiteralConversions.Unquote(String quotedText)
       à ICSharpCode.CodeConverter.CSharp.LiteralConversions.GetQuotedStringTextForUser(String textForUser, String valueTextForCompiler)
       à ICSharpCode.CodeConverter.CSharp.LiteralConversions.GetLiteralExpression(Object value, String textForUser, ITypeSymbol convertedType)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitLiteralExpression>d__45.MoveNext()
    --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
       à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

    Input:
    “https://www.prenommer.com/bases-de-donnees/"
     */
    );
            }
            else
            {
                var msgBoxResult = Interaction.MsgBox("Prénommer ne peut pas charger le site web de l'application. La connexion a échoué.", (MsgBoxStyle)((int)Constants.vbYes + (int)Constants.vbCritical), "Prénommer");
            }

        }
        // Ping Google to see if the user has Internet Connected
        public bool TestInternetConnection()
        {

            try
            {
                using (var ping = new System.Net.NetworkInformation.Ping())
                {
                    var pingReply = ping.Send("google.com");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public void CréerunfichierhtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string fileContent = string.Empty;
            string filePathOFD = string.Empty;

            using (var openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {

                openFileDialog.InitialDirectory = My.MyProject.Application.Info.DirectoryPath + @"\";
                openFileDialog.Filter = "Document Word (*.docx)|*.docx|Tous les fichiers (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    filePathOFD = openFileDialog.FileName;

                    // Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (var reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
                else
                {
                    return;
                }

            }

            ConvertToHtml(filePathOFD);

        }

        public void ConvertToHtml(string strofd)
        {

            try
            {

                string sourceDocumentFileName = strofd;
                var fileInfo = new FileInfo(sourceDocumentFileName);
                string imageDirectoryName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length) + "_files";
                var dirInfo = new DirectoryInfo(imageDirectoryName);

                if (dirInfo.Exists)
                {

                    // Delete the directory and files.
                    foreach (var f in dirInfo.GetFiles())
                        f.Delete();

                    dirInfo.Delete();
                }

                int imageCounter = 0;
                var byteArray = File.ReadAllBytes(strofd);

                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(byteArray, 0, byteArray.Length);

                    using (var doc = WordprocessingDocument.Open(memoryStream, true))
                    {
                        var settings = new HtmlConverterSettings()
                        {
                            PageTitle = "Prénommer",
                            ImageHandler = new Func<ImageInfo, XElement>(imageInfo =>
                                {
                                    var localDirInfo = new DirectoryInfo(imageDirectoryName);
                                    if (!localDirInfo.Exists)
                                        localDirInfo.Create();
                                    int v = System.Threading.Interlocked.Increment(ref imageCounter);
                                    string extension = imageInfo.ContentType.Split('/')[1].ToLower();
                                    ImageFormat imageFormat = null;

                                    if (Equals(extension, "png"))
                                    {
                                    // Convert the .png file to a .jpeg file.
                                    // extension = "jpeg"
                                    imageFormat = ImageFormat.Png;
                                    }
                                    else if (Equals(extension, "bmp"))
                                    {
                                        imageFormat = ImageFormat.Bmp;
                                    }
                                    else if (Equals(extension, "jpeg"))
                                    {
                                        imageFormat = ImageFormat.Jpeg;
                                    }
                                    else if (Equals(extension, "tiff"))
                                    {
                                        imageFormat = ImageFormat.Tiff;
                                    }

                                // If the image format is not one that you expect, ignore it,
                                // and do not return markup for the link.
                                if (imageFormat is null)
                                        return null;
                                    string imageFileName = imageDirectoryName + "/image" + imageCounter.ToString() + "." + extension;

                                    try
                                    {
                                        imageInfo.Bitmap.Save(imageFileName, imageFormat);
                                    }
                                    catch (System.Runtime.InteropServices.ExternalException __unusedExternalException1__)
                                    {
                                        return null;
                                    }

                                    var img = new XElement(Xhtml.img, new XAttribute(NoNamespace.src, imageFileName), imageInfo.ImgStyleAttribute, imageInfo.AltText is not null ? new XAttribute(NoNamespace.alt, imageInfo.AltText) : null);
                                    return img;
                                })
                        };

                        var htmlX = HtmlConverter.ConvertToHtml(wDoc: doc, htmlConverterSettings: settings);

                        // Note: the XHTML returned by ConvertToHtmlTransform contains objects of type
                        // XEntity. PtOpenXmlUtil.cs defines the XEntity class. See
                        // http://blogs.msdn.com/ericwhite/archive/2010/01/21/writing-entity-references-using-linq-to-xml.aspx
                        // for detailed explanation.
                        // 
                        // If you further transform the XML tree returned by ConvertToHtmlTransform, you
                        // must do it correctly, or entities do not serialize properly.
                        // If System.IO.File.Exists(SavePath) Then

                        string result = Path.GetFileNameWithoutExtension(strofd) + ".html";

                        File.WriteAllText(result, htmlX.ToStringNewLineOnAttributes(), Encoding.UTF8);

                    }
                }
            }

            catch (Exception ex)
            {
                // Show the exception's message.
                var dialogResult1 = MessageBox.Show(ex.Message);

                // Show the stack trace, which is a list of methods
                // that are currently executing.
                var dialogResult2 = MessageBox.Show("Stack Trace :  " + Constants.vbCrLf + ex.StackTrace);
            }
            finally
            {
                // This line executes whether or not the exception occurs.
                var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");
            }

        }

        private void UpdateAutoComplete()
        {

            // Clear current autocomplete list
            TextBox1.AutoCompleteCustomSource.Clear();

            // Début Modification du code
            var col = new AutoCompleteStringCollection();

            foreach (string Str in ListBox2.Items)
                int v = col.Add(Str);
            TextBox1.AutoCompleteCustomSource = col;
            TextBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            // Fin de modification du code

            // Loop through each listbox item and add it to the Autocomplete source
            // For i As Integer = 0 To ListBox2.Items.Count - 1
            // TextBox1.AutoCompleteCustomSource.Add(ListBox2.Items(i))
            // Next

        }

        private void ConvToDocx(string filedocs)
        {

            var saveFileDialog1 = new Microsoft.Win32.SaveFileDialog()
            {
                Filter = "Document Word (*.docx)|*.docx|Document Word 97-2003 (*.doc)|*.doc|Plain Text (*.txt)|*.txt",
                FilterIndex = 1,
                RestoreDirectory = true,
                OverwritePrompt = false,
                FileName = Path.GetFileName(filedocs)
            };

            if (Conversions.ToInteger(saveFileDialog1.ShowDialog().Value) == DialogResult.OK)
            {

                AuxFile = Path.GetFileNameWithoutExtension(filedocs) + ".docx";
                My.MyProject.Computer.FileSystem.RenameFile(filedocs, AuxFile);
            }

            else if (Conversions.ToBoolean(DialogResult.Cancel))
            {

                saveFileDialog1.FileName = "";

            }

            Cursor = Cursors.WaitCursor;

            var wrdApp = new Word.Application();
            wrdApp = (Word.Application)Interaction.CreateObject("Word.Application");

            wrdApp.Visible = false;

            Word.Document docNew;
            docNew = default
#error Cannot convert MemberAccessExpressionSyntax - see comment for details
    /* Cannot convert MemberAccessExpressionSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
       à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateArgList(ISymbol invocationSymbol)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.AddEmptyArgumentListIfImplicit(SyntaxNode node, ExpressionSyntax id)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<AdjustForImplicitInvocationAsync>d__113.MoveNext()
    --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitMemberAccessExpression>d__54.MoveNext()
    --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
       à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

    Input:
    wrdApp.Documents.Add

     */
    ;

            default
#error Cannot convert InvocationExpressionSyntax - see comment for details
               /* Cannot convert ArgumentListSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
                  à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
                  à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
                  à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
                  à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
                  à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
                  à System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
                  à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
                  à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitArgumentList>d__56.MoveNext()
               --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
                  à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

               Input: (filedocs)

               Context:

                       docNew.Range.InsertFile(filedocs)

                */
               ;

            object argDirection = 0;
            wrdApp.Selection.Collapse(Direction: ref argDirection); // wdCollapseEnd)
            default
#error Cannot convert InvocationExpressionSyntax - see comment for details
    /* Cannot convert ArgumentListSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
       à System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
       à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitArgumentList>d__56.MoveNext()
    --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
       à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

    Input: (FileName:=filedocs)

    Context:
            wrdApp.Selection.InsertFile(FileName:=filedocs)

     */
    ;

            object argFileName = "filedocs";
            default
#error Cannot convert InvocationExpressionSyntax - see comment for details
/* Cannot convert ArgumentListSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
   à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
   à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
   à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
   à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
   à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
   à System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
   à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitArgumentList>d__56.MoveNext()
--- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
   à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

Input: ("filedocs")

Context:

        docNew.SaveAs("filedocs")

 */
;
            default
#error Cannot convert InvocationExpressionSyntax - see comment for details
               /* Cannot convert ArgumentListSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
                  à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
                  à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
                  à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
                  à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
                  à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
                  à System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
                  à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
                  à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitArgumentList>d__56.MoveNext()
               --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
                  à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

               Input: ()

               Context:
                       wrdApp.Quit()

                */
               ;

            docNew = null;
            wrdApp = null;

            Cursor = Cursors.Default;

        }

        public void TextBox5_LostFocus(object sender, EventArgs e)
        {

            string dateString = TextBox5.Text;
            // 'Dim dateFormat As String = "d MMMM"
            // 'Dim dateValue As Date
            var provider = new CultureInfo("fr-FR");

            do
            {
                try
                {
                    if (!string.IsNullOrEmpty(TextBox5.Text))
                    {
                        var dt = DateTime.ParseExact(dateString, "d MMMM", provider);
                        // 'dateValue = Date.ParseExact(dateString, dateFormat, provider)
                    }
                }

                catch (Exception ex)
                {
                    if (TextBox5.Text == "29 février")
                    {
                        break;
                    }
                    var dialogResult1 = MessageBox.Show("La chaîne n'a pas été reconnue comme une date valide.");
                    TextBox5.Text = "";
                }
            }

            while (false);

        }

        private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

            e.DrawDefault = true;

            if (e.ItemIndex % 2 == 1)
            {
                e.Item.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
                e.Item.UseItemStyleForSubItems = true;
            }

        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {

            e.DrawDefault = true;

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

            var unused = Process.Start("https://creativecommons.org/licenses/by-sa/3.0/deed.fr");

        }

        private void PictureBox2_MouseEnter(object sender, EventArgs e)
        {

            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.Cursor = Cursors.Hand;

        }

        private void PictureBox2_MouseLeave(object sender, EventArgs e)
        {

            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox2.Cursor = Cursors.Default;

        }

        private void TreeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

            var r = new System.Drawing.Rectangle(e.Bounds.Left, e.Bounds.Top, TreeView1.ClientSize.Width + 350, e.Bounds.Height);

            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.Yellow, r);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.NodeFont, e.Bounds, System.Drawing.Color.Black, System.Drawing.Color.Empty, TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, r);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.NodeFont, e.Bounds, SystemColors.WindowText, System.Drawing.Color.Empty, TextFormatFlags.VerticalCenter);
            }

        }

        private void RechercherdanslesfichiersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frm = new Query();
            frm.Show();

        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            TreeNode Node;

            Node = TreeView1.GetNodeAt(new System.Drawing.Point(e.X, e.Y));

            if (e.Button == MouseButtons.Left)
            {
                TreeView1.SelectedNode = e.Node;
            }

            // If e.Node.Text = "Librairie" Then Exit Sub

        }

        private void CopierToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var main = this;
            TextBoxBase ctl = main.ActiveControl as TextBoxBase;

            if (ctl is not null && ctl.SelectionLength > 0)
                ctl.Copy();
            ctl.SelectionStart = Strings.Len(ctl.Text);

        }

        private void CouperToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TextBoxBase ctl = ActiveControl as TextBoxBase;

            if (!string.IsNullOrEmpty(ctl.SelectedText))
            {
                ctl.Cut();
            }

        }

        private void CollerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TextBoxBase ctl = ActiveControl as TextBoxBase;

            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                if (ctl.SelectionLength > 0)
                {
                    if (MessageBox.Show("Voulez-vous coller sur la sélection actuelle ?", "Prénommer", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        ctl.SelectionStart = TextBox1.SelectionStart + ctl.SelectionLength;
                    }
                }

                ctl.Paste();

            }

        }

        private void AnnulerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TextBoxBase ctl = ActiveControl as TextBoxBase;

            if (ctl.CanUndo)
            {
                ctl.Undo();

                // ctl.ClearUndo()
            }

        }

        private void SélectionnerToutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TextBoxBase ctl = ActiveControl as TextBoxBase;

            if (ctl.SelectionLength == 0)
            {
                ctl.SelectAll();
                bool v = ctl.Focus();
            }

            ctl.Copy();

        }

        private void RétablirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TextBoxBase ctl = ActiveControl as TextBoxBase;

            ctl.Undo();

        }

        public void CreerundocumentjsonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                var dialogResult1 = MessageBox.Show("Vous devez sélectionner une fiche avant de pouvoir créer ou générer un document au format JSON (.json) !");
                return;
            }

            else
            {

                try
                {

                    var account = new Class2.Fich()
                    {
                        Title = TextBox2.Text,
                        Name = TextBox1.Text,
                        Charge = TextBox4.Text,
                        Institute = TextBox15.Text,
                        Celebration = TextBox5.Text,
                        Birth = TextBox7.Text,
                        Death = TextBox9.Text,
                        Otherparties = TextBox13.Text,
                        Othernames = TextBox18.Text,
                        Venerable = TextBox23.Text,
                        Beatified = TextBox24.Text,
                        Canonized = TextBox25.Text,
                        Heading = TextBox26.Text,
                        Patron = TextBox28.Text,
                        Link = TextBox29.Text,
                        Image = TextBox33.Text,
                        Biography = TextBox31.Text,
                        Origin = RichTextBox1.Text
                    };

                    Json = JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);

                    using (var filejson = File.CreateText(My.MyProject.Application.Info.DirectoryPath + @"\" + TextBox1.Text + ".json"))
                    {
                        var serializer = new JsonSerializer();
                        serializer.Serialize(filejson, account);
                    }
                }

                catch (Exception ex)
                {
                    // Show the exception's message.
                    var dialogResult1 = MessageBox.Show(ex.Message);

                    // Show the stack trace, which is a list of methods
                    // that are currently executing.
                    var dialogResult2 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + ex.StackTrace);
                }
                finally
                {
                    // This line executes whether or not the exception occurs.
                    var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");
                }

            }

        }

        public void LireundocumentjsonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string fileContent = string.Empty;
            string filePath = string.Empty;

            OpenFileDialog1.InitialDirectory = My.MyProject.Application.Info.DirectoryPath + @"\";
            OpenFileDialog1.Filter = "Documents Json (*.json)|*.json|Tous les fichiers (*.*)|*.*";
            OpenFileDialog1.FilterIndex = 1;
            OpenFileDialog1.RestoreDirectory = true;
            OpenFileDialog1.Multiselect = false;

            OpenFileDialog1.CheckFileExists = true;

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    if (!ReferenceEquals(OpenFileDialog1.FileName.Trim(), string.Empty))
                    {

                        NouveauToolStripButton.PerformClick();

                        filePath = OpenFileDialog1.FileName;

                        string rawjson = File.ReadAllText(OpenFileDialog1.FileName);

                        Account = JsonConvert.DeserializeObject<Class2.Fich>(rawjson);

                        JsonConvert.PopulateObject(rawjson, Account);
                        TextBox2.Text = Account.Title.ToString();
                        TextBox1.Text = Account.Name.ToString();
                        TextBox4.Text = Account.Charge.ToString();
                        TextBox15.Text = Account.Institute.ToString();
                        TextBox5.Text = Account.Celebration.ToString();
                        TextBox7.Text = Account.Birth.ToString();
                        TextBox9.Text = Account.Death.ToString();
                        TextBox13.Text = Account.Otherparties.ToString();
                        TextBox18.Text = Account.Othernames.ToString();
                        TextBox23.Text = Account.Venerable.ToString();
                        TextBox24.Text = Account.Beatified.ToString();
                        TextBox25.Text = Account.Canonized.ToString();
                        TextBox26.Text = Account.Heading.ToString();
                        TextBox28.Text = Account.Patron.ToString();
                        TextBox29.Text = Account.Link.ToString();
                        TextBox33.Text = Account.Image.ToString();
                        TextBox31.Text = Account.Biography.ToString();
                        RichTextBox1.Text = Account.Origin.ToString();
                    }
                }

                catch (Exception Ex)
                {
                    var dialogResult1 = MessageBox.Show("Impossible de lire le fichier à partir du disque. Erreur d'origine : " + Ex.Message);
                }
                finally
                {
                    var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée. Vous êtes invité à enregistrer les modifications apportées au nouveau document.");
                }
            }
            else
            {
                return;
            }

        }

        private void PictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

            if (e.Error is not null | PictureBox1.Image.Equals(PictureBox1.ErrorImage))
            {
                var dialogResult1 = MessageBox.Show("Une erreur s'est produite lors du chargement de l'image.");
            }

        }

        public void ToolStripStatusLabel6_MouseMove(object sender, MouseEventArgs e)
        {

            var numbers = default(long);

            var di = new DirectoryInfo(My.MyProject.Application.Info.DirectoryPath + @"\Librairies\");
            var fiArr = di.GetFiles();
            foreach (var fri in fiArr)
                numbers = (long)Math.Round(numbers + fri.Length / 3188d);
            ToolStripStatusLabel6.Text = "Affichage du nombre total d'enregistrements : " + numbers;

        }

        private void ComboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (e.Index < 0)
            {
                return;
            } // added this line thanks to Andrew's comment
            string text = ComboBox2.GetItemText(ComboBox2.Items[e.Index]);
            e.DrawBackground();

            using (var br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, e.Font, br, e.Bounds);
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                ToolTip1.Show(text, ComboBox2, e.Bounds.Right, e.Bounds.Bottom);
            }

            e.DrawFocusRectangle();

        }

        private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {

            ToolTip1.Hide(ComboBox2);

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void CréerundocumentauformatooxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (TreeView1.Nodes.Count == 0 | string.IsNullOrEmpty(TextBox1.Text))
            {

                var dialogResult1 = MessageBox.Show("Afin de créer un document au format ooxml, vous devez d'abord sélectionner un élément d'une librairie.");
                return;
            }

            else
            {

                try
                {

                    Cursor = Cursors.WaitCursor;
                    // Create a Wordprocessing document (OOXML)
                    using (var package = WordprocessingDocument.Create(TextBox1.Text + ".docx", WordprocessingDocumentType.Document))
                    {
                        // Add a new main document part. 
                        var mainDocumentPart = package.AddMainDocumentPart();

                        // Create the Document DOM.
                        package.MainDocumentPart.Document = new Document(new Body(new Paragraph(new Run(new Text(TextBox2.Text + " " + TextBox1.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox4.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox15.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox5.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox7.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox9.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox13.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox18.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox23.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox24.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox25.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox26.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox28.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox29.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox33.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(TextBox31.Text + ControlChars.Cr)))));
                        package.MainDocumentPart.Document.Append(new Body(new Paragraph(new Run(new Text(RichTextBox1.Text + ControlChars.Cr)))));

                        // Set the font to Calibri to the first Run.
                        var rPr = new RunProperties(new RunFonts() { Ascii = "Calibri", HighAnsi = "Calibri" });
                        rPr.Append(new Bold());
                        rPr.Append(new FontSize() { Val = "36" });
                        var r = package.MainDocumentPart.Document.Descendants<Run>().First();

                        var runProperties = r.PrependChild(rPr);

                        var mainDocPart = package.MainDocumentPart;
                        var footerPart1 = mainDocPart.AddNewPart<FooterPart>("r98");
                        var footer1 = new Footer();
                        var paragraph1 = new Paragraph();

                        var run1 = new Run();
                        var text1 = new Text() { Text = "Prénommer - " + DateTime.Now.ToString() };
                        run1.Append(text1);
                        paragraph1.Append(run1);
                        footer1.Append(paragraph1);
                        footerPart1.Footer = footer1;
                        var sectionProperties1 = mainDocPart.Document.Body.Descendants<SectionProperties>().FirstOrDefault();
                        if (sectionProperties1 is null)
                        {
                            sectionProperties1 = new SectionProperties();
                            mainDocPart.Document.Body.Append(sectionProperties1);
                        }
                        var footerReference1 = new FooterReference()
                        {
                            Type = HeaderFooterValues.Default,
                            Id = "r98"
                        };
                        var footerReference = sectionProperties1.InsertAt(footerReference1, 0);

                        // Save changes to the main document part. 
                        package.MainDocumentPart.Document.Save();

                    }

                    Cursor = Cursors.Default;
                }

                catch (Exception ex)
                {
                    // Show the exception's message.
                    var dialogResult1 = MessageBox.Show(ex.Message);

                    // Show the stack trace, which is a list of methods
                    // that are currently executing.
                    var dialogResult2 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + ex.StackTrace);
                }
                finally
                {
                    // This line executes whether or not the exception occurs.
                    var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");
                }

            }

        }

        public void ConvertWordToPDF(object filename, string directoryPath)
        {

            var wordApplication = new Word.Application();
            Word.Document wordDocument = null;
            string outputFilename;

            try
            {

                Cursor = Cursors.WaitCursor;

                wordDocument = default
#error Cannot convert InvocationExpressionSyntax - see comment for details
    /* Cannot convert ArgumentListSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
       à System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
       à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitArgumentList>d__56.MoveNext()
    --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
       à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

    Input: (filename)

    Context:
    wordApplication.Documents.Open(filename)

     */
    ;
                outputFilename = Path.ChangeExtension(Conversions.ToString(filename), "pdf");

                if (wordDocument is not null)
                {
                    default
#error Cannot convert InvocationExpressionSyntax - see comment for details
    /* Cannot convert ArgumentListSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
       à System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
       à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitArgumentList>d__56.MoveNext()
    --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
       à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

    Input: (outputFilename, Global.Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, True, Global.Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Global.Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0, 0, Global.Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent, True, True, Global.Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, True, True, False)

    Context:
                    wordDocument.ExportAsFixedFormat(outputFilename, Global.Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, True, Global.Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Global.Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0, 0, Global.Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent, True, True, Global.Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, True, True, False)

     */
    ;
                }

                Cursor = Cursors.Default;
            }

            catch (Exception ex)
            {
                // Show the exception's message.
                var dialogResult2 = MessageBox.Show(ex.Message);

                // Show the stack trace, which is a list of methods
                // that are currently executing.
                var dialogResult1 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + ex.StackTrace);
            }
            finally
            {
                if (wordDocument is not null)
                {
                    object argSaveChanges = (object)false;
                    default
#error Cannot convert InvocationExpressionSyntax - see comment for details
/* Cannot convert ArgumentListSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
   à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
   à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
   à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
   à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
   à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
   à System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
   à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
   à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitArgumentList>d__56.MoveNext()
--- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
   à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

Input: (False)

Context:
                wordDocument.Close(False)

 */
;
                    wordDocument = null;
                }

                if (wordApplication is not null)
                {
                    default
#error Cannot convert InvocationExpressionSyntax - see comment for details
    /* Cannot convert ArgumentListSyntax, System.InvalidOperationException: L'opération n'est pas valide en raison de l'état actuel de l'objet.
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_ExplicitDefaultValue()
       à Microsoft.CodeAnalysis.VisualBasic.Symbols.ParameterSymbol.get_IParameterSymbol_DefaultValue()
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateOptionalRefArg(IParameterSymbol p, RefKind refKind)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.CreateExtraArgOrNull(IParameterSymbol p, Boolean requiresCompareMethod, Boolean expandOptionalArgs)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<GetAdditionalRequiredArgs>d__129.MoveNext()
       à System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
       à Microsoft.CodeAnalysis.CSharp.SyntaxFactory.SeparatedList[TNode](IEnumerable`1 nodes)
       à ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.<VisitArgumentList>d__56.MoveNext()
    --- Fin de la trace de la pile à partir de l'emplacement précédent au niveau duquel l'exception a été levée ---
       à ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

    Input: ()

    Context:
                    wordApplication.Quit()

     */
    ;
                    wordApplication = null;
                }
            }

        }

        private void CréerundocumentauformatPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!File.Exists(My.MyProject.Application.Info.DirectoryPath + @"\" + TextBox1.Text + ".docx"))
            {
                var msgBoxResult1 = Interaction.MsgBox("Le fichier document n'existe pas. En choisissant de créer un fichier .docx, les données du document pourront alors être exportées vers le nouveau fichier.");
                return;
            }

            ConvertWordToPDF(My.MyProject.Application.Info.DirectoryPath + @"\" + TextBox1.Text + ".docx", My.MyProject.Application.Info.DirectoryPath);

            var msgBoxResult = Interaction.MsgBox("L'exécution du processus est terminée.");

        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox18_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox23_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox24_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox25_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox26_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox28_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox29_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void TextBox33_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

            Module1.bChanged = true;

        }

        public Process p = new Process();
        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {

            // Call Process.Start method to open a browser
            // with link text as URL.
            p = Process.Start("IExplore.exe", e.LinkText);

        }

        private void TextBox31_KeyUp(object sender, KeyEventArgs e)
        {

            if ((e.KeyValue == 13 | e.KeyValue == 10) & TextBox31.ReadOnly)
            {

                return;
            }

            else if ((e.KeyValue == 13 | e.KeyValue == 10) & TextBox31.ReadOnly == false)
            {

                var dialogResult1 = MessageBox.Show("Attention : Saut de ligne ou retour chariot décelé dans cette zone de texte. Utilisez la souris pour répondre au bouton affiché dans la boîte de message.", "Correction automatique de la mise en forme", MessageBoxButtons.OK);
                TextBox31.Text = new string(TextBox31.Text.Where((ch, i) => i < TextBox31.Text.Length - 2).ToArray());
                TextBox31.SelectionStart = TextBox31.Text.Length;

            }

        }

        private void RichTextBox1_MouseHover(object sender, EventArgs e)
        {

            string s = Strings.Trim(RichTextBox1.Text);

            if (!string.IsNullOrEmpty(s) & RichTextBox1.ReadOnly)
            {
                string _uri = s;
                if (Uri.IsWellFormedUriString(_uri, UriKind.RelativeOrAbsolute) == false)
                {
                    var dialogResult1 = MessageBox.Show("L'URL n'est pas considérée comme valide.", "Prénommer", (MessageBoxButtons)Conversions.ToInteger(((int)MessageBoxButtons.OK).ToString()));

                    bool v = RichTextBox1.Focus();
                    RichTextBox1.Select(0, RichTextBox1.Text.Length);
                }
            }

        }

        private delegate string GetFormTitleDelegate(Form f);

        private string GetFormTitle(Form f)
        {
            // Check if the form can be accessed from the current thread.
            if (!f.InvokeRequired)
            {
                // Access the form directly.
                return f.Text;
            }
            else
            {
                // Marshal to the thread that owns the form. 
                GetFormTitleDelegate del = GetFormTitle;
                var param = new[] { f };
                var result = f.BeginInvoke(del, param);
                // Give the form's thread a chance process function.
                System.Threading.Thread.Sleep(10);
                // Check the result.
                if (result.IsCompleted)
                {
                    // Get the function's return value.
                    return "Different thread : " + f.EndInvoke(result).ToString();
                }
                else
                {
                    return "Unresponsive thread";
                }
            }

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

            var unused = Process.Start("https://www.wikipedia.org");

        }

        private void PictureBox4_MouseEnter(object sender, EventArgs e)
        {

            PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox4.Cursor = Cursors.Hand;

        }

        private void PictureBox4_MouseLeave(object sender, EventArgs e)
        {

            PictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox4.Cursor = Cursors.Default;

        }

        private void UpdateTextPosition()
        {

            var g = CreateGraphics();
            double startingPoint = Width / 2d - g.MeasureString(Text.Trim(), Font).Width / 2f;
            double widthOfASpace = g.MeasureString(" ", Font).Width;
            string tmp = " ";
            double tmpWidth = 0d;

            while (tmpWidth + widthOfASpace < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            Text = tmp + Text.Trim();

        }

        private void NousContacterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Contact oForm;
            oForm = new Contact();
            oForm.Show();

        }

        public string ReadLineWithNumberFrom(string filePath, int lineNumber)
        {

            using (var file = new StreamReader(filePath))
            {
                // Skip all preceding lines:
                for (int i = 1, loopTo = lineNumber - 1; i <= loopTo; i++)
                {
                    if (file.ReadLine() is null)
                    {
                        throw new ArgumentOutOfRangeException("lineNumber");
                    }
                }
                // Attempt to read the line you're interested in:
                string line = file.ReadLine();
                if (line is null)
                {
                    throw new ArgumentOutOfRangeException("lineNumber");
                }
                return line;
            }

        }

        private void TreeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {

            string Url = HttpUtility.UrlDecode(str: RichTextBox1.Text);

            RichTextBox1.ReadOnly = false;
            string unused = RichTextBox1.Text;
            RichTextBox1.ReadOnly = true;

        }

        private void PictureBox1_MouseHover(object sender, EventArgs e)
        {

            using (var img = PictureBox1.Image)
            {
                var copy = new Bitmap(img.Width, img.Height);
                var ia = new ImageAttributes();

                var cm = new ColorMatrix(new float[][] { new float[] { 0.3f, 0.3f, 0.3f, 0f, 0f }, new float[] { 0.59f, 0.59f, 0.59f, 0f, 0f }, new float[] { 0.11f, 0.11f, 0.11f, 0f, 0f }, new float[] { 0f, 0f, 0f, 1f, 0f }, new float[] { 0f, 0f, 0f, 0f, 1f } });

                ia.SetColorMatrix(cm);

                Graphics g;
                g = Graphics.FromImage(copy);
                g.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

                PictureBox1.Image = copy;
                g.Dispose();
                img.Dispose();

            }

        }

        private static bool IsGrayScale(Bitmap img)
        {

            bool result = true;

            for (int h = 0, loopTo = img.Height - 1; h <= loopTo; h++)
            {

                for (int w = 0, loopTo1 = img.Width - 1; w <= loopTo1; w++)
                {
                    var color = img.GetPixel(w, h);

                    if ((color.R != color.G || color.G != color.B || color.R != color.B) && color.A != 0)
                    {
                        result = false;
                        return result;
                    }
                }
            }

            return result;

        }

        private static bool IIsGrayScale(Image image)
        {

            var bmp = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(image, 0, 0);
            var data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            int pt = (int)data.Scan0;
            bool res = true;
            int i = 0;
            int v = data.Height * data.Width;

            while (i < v)
            {
                var color = System.Drawing.Color.FromArgb(pt(i));

                if (color.A != 0 && (color.R != color.G || color.G != color.B))

                {
                    res = false;
                    // Exit For
                }

                i += 1;
            }

            bmp.UnlockBits(data);
            return res;

        }

    }
}