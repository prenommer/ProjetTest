using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Prenommer
{

    public partial class Create
    {
        public Create()
        {
            InitializeComponent();
        }
        [DllImport("shlwapi.dll", EntryPoint = "PathFileExistsA")]
        public static extern long PathFileExists(string pszPath);
        public Cursor CursorsWaitCursor { get; set; }
        public string Path { get; set; }
        public string StrShortPath { get; set; }
        public string Extension { get; set; }
        public string Library { get; set; }
        public string GetExtension { get; set; }
        public string FullPath { get; set; }
        public int Ligne { get; set; }
        public int NumberOfLine { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {

            string PathLibrairies;

            Cursor = CursorsWaitCursor;

            StrShortPath = My.MyProject.Application.Info.DirectoryPath;

            Label1.Text = StrShortPath + @"\Librairies";
            PathLibrairies = Label1.Text;

            Button2.Enabled = false;
            Button5.Enabled = false;
            Button4.Enabled = false;
            Button7.Enabled = false;

            Initialise();
            Path = Label1.Text;

            var columnHeader = ListView1.Columns.Add("Librairies ", 200, HorizontalAlignment.Left);
            ListView1.View = System.Windows.Forms.View.Details;
            ListView1.GridLines = true;
            var columnHeader1 = ListView1.Columns.Add("Taille", 125, HorizontalAlignment.Left);
            var columnHeader2 = ListView1.Columns.Add("Date de création", 150, HorizontalAlignment.Left);

            ExtractAssociatedIconEx();

            int comptage = ListView1.Items.Count;

            switch (ListView1.Items.Count)
            {

                case 0:
                    {
                        TabPage1.Text = " Aucun fichier de données ";
                        break;
                    }

                case 1:
                    {
                        TabPage1.Text = comptage + " fichier de données ";
                        break;
                    }

                default:
                    {
                        TabPage1.Text = comptage + " fichiers de données ";
                        break;
                    }
            }

            ListView1.ShowItemToolTips = true;
            foreach (ListViewItem item in ListView1.Items)
                item.ToolTipText = item.Text;

            Button5.Enabled = false;

            Cursor = Cursors.Default;

        }

        private void Initialise()
        {

            ListView1.Items.Clear();
            ListView1.ArrangeIcons();

            ListView1.SmallImageList = null;
            ImageList1.Images.Clear();

        }

        private void Button4_Click(object sender, EventArgs e)
        {

            string id = TextBox1.Text;

            if (ListView1.SelectedItems.Count == 0)
            {
                var msgBoxResult = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir le supprimer !", (MsgBoxStyle)Constants.vbYes, My.MyProject.Application.Info.Title);
            }
            else
            {

                string sFichier = StrShortPath + @"\Librairies\" + id;
                var msgBoxResult = Interaction.MsgBox(sFichier);
                try
                {
                    var FS = File.Open(sFichier, FileMode.Open, FileAccess.Read, FileShare.None);
                    // Ouverture Ok, donc non déjà ouvert : referme
                    FS.Close();
                    FS.Dispose();
                    FS = null;
                    var msgBoxResult1 = Interaction.MsgBox("Fichier non ouvert");
                }
                catch (IOException ex)
                {
                    var msgBoxResult1 = Interaction.MsgBox("\"" + sFichier + "\" déjà ouvert" + Environment.NewLine + ex.Message);
                }
                catch (Exception ex)
                {
                    var dialogResult1 = MessageBox.Show("Erreur inconnue" + Environment.NewLine + ex.Message);
                }

                int NumeroDeLigne;
                NumeroDeLigne = ListView1.SelectedIndices[0];

                var pProcess = Process.GetProcessesByName(id);

                foreach (Process p in pProcess)
                {
                    if (p.MainWindowTitle.Contains(id))
                    {
                        p.Kill();
                    }
                }

                var msgBoxResult2 = Interaction.MsgBox(StrShortPath + @"\Librairies\" + id);

                File.Delete(StrShortPath + @"\Librairies\" + id, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);

                Button6_Click(Button6, null);

                TextBox1.Text = "";

                My.MyProject.Forms.Main.ListView1.BeginUpdate();
                My.MyProject.Forms.Main.ListView1.Items.Clear();
                if (!File.Exists(Path))
                {
                    foreach (string fileName in Directory.GetFiles(Path))
                    {
                        My.MyProject.Forms.Main.ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName));
                        var listViewItem = My.MyProject.Forms.Main.ListView1.Items.Add(System.IO.Path.GetFileName(fileName), My.MyProject.Forms.Main.ImageList1.Images.Count - 1);
                    }
                }
                My.MyProject.Forms.Main.ToolStripStatusLabel1.Text = My.MyProject.Forms.Main.ListView1.Items.Count + " librairies chargées";
                My.MyProject.Forms.Main.ListView1.EndUpdate();

                int comptage = ListView1.Items.Count;
                switch (ListView1.Items.Count)
                {

                    case 0:
                        {
                            TabPage1.Text = " Aucun fichier de données ";
                            break;
                        }

                    case 1:
                        {
                            TabPage1.Text = comptage + " fichier de données ";
                            break;
                        }

                    default:
                        {
                            TabPage1.Text = comptage + " fichiers de données ";
                            break;
                        }
                }

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            My.MyProject.Forms.Main.Visible = true;
            Close();

        }

        public void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Button4.Enabled = true;
            if (ListView1.SelectedItems.Count > 0)
            {
                Label1.Text = StrShortPath + @"\Librairies";
                Label5.Text = ListView1.SelectedItems[0].Text;
                RichTextBox1.Text = "";
                Button2.Enabled = true;
                Button7.Enabled = true;
            }

            // Me.TextBox2.Text = Me.ListView1.SelectedItems(0).Text

            if (ListView1.SelectedIndices.Count > 0) // ON verifie d'abord s'il y a eu une ligne selectionnée
            {
                // Dim Ligne As Integer ' Cette variable stockera le numéro de la ligne selectionnée;
                Ligne = Conversions.ToInteger(ListView1.SelectedIndices[0].ToString()); // Recuperation de la ligne selectionné

                TextBox1.Text = ListView1.Items[Ligne].SubItems[0].Text;  // Recuperation de données se trouvant dans la première colonne et le mettre dans mon textbox1

                var msgBoxResult = Interaction.MsgBox("Ligne sélectionnée : " + Ligne);
            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {

            var msgBoxResult = Interaction.MsgBox("Actualisation des données");

            ListView1.BeginUpdate();
            Initialise();
            ExtractAssociatedIconEx();

            if (Interaction.MsgBox("Fichiers des librairies actualisés (" + ListView1.Items.Count + " médias) !", (MsgBoxStyle)((int)Constants.vbYes + (int)Constants.vbDirectory), My.MyProject.Application.Info.Title) == Constants.vbYes)
            {
                System.Threading.Thread.Sleep(500); // 500 milliseconds = 0.5 seconds
            }

            My.MyProject.Forms.Main.ListView1.Items.Clear();
            if (!File.Exists(Path))
            {
                foreach (string fileName in Directory.GetFiles(Path))
                {
                    My.MyProject.Forms.Main.ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName));
                    var listViewItem = My.MyProject.Forms.Main.ListView1.Items.Add(System.IO.Path.GetFileName(fileName), My.MyProject.Forms.Main.ImageList1.Images.Count - 1);
                }
            }

            ListView1.EndUpdate();
            ListView1.Refresh();
            Label1.Text = StrShortPath + @"\Librairies";
            Button5.Enabled = true;
            Button7.Enabled = true;
            Button2.Enabled = false;

        }

        public void ExtractAssociatedIconEx()
        {

            ListView1.LargeImageList = ImageList1;
            ListView1.SmallImageList = ImageList1;

            DirectoryInfo dirInfo;
            Icon exeIcon;
            int I;

            dirInfo = new DirectoryInfo(StrShortPath + @"\Librairies");
            I = 0;

            foreach (var fileInfo in dirInfo.GetFiles())
            {

                if (!string.IsNullOrEmpty(fileInfo.Extension))
                {
                    exeIcon = Icon.ExtractAssociatedIcon(fileInfo.FullName);
                    if (ImageList1.Images.ContainsKey(fileInfo.FullName))
                    {
                        var listViewItem = ListView1.Items.Add(fileInfo.Name, fileInfo.FullName);
                    }
                    else if (exeIcon is not null)
                    {
                        ImageList1.Images.Add(fileInfo.FullName, exeIcon);
                        var listViewItem = ListView1.Items.Add(fileInfo.Name, fileInfo.FullName);
                        var listViewSubItem = ListView1.Items[I].SubItems.Add(fileInfo.Length + " octects");
                        var listViewSubItem1 = ListView1.Items[I].SubItems.Add(Conversions.ToString(fileInfo.CreationTime));
                    }
                    else
                    {
                        var listViewItem = ListView1.Items.Add(fileInfo.Name);
                    }
                }
                I += 1;

            }

        }

        public void Button7_Click(object sender, EventArgs e)
        {

            if (ListView1.SelectedItems.Count == 0)
            {
                var msgBoxResult1 = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", (MsgBoxStyle)Constants.vbYes, "Erreur");
                return;
            }

            else
            {

                if (ListView1.SelectedItems.Count > 0)
                {
                    Module1.ChercheItem = ListView1.SelectedItems[0].Text;
                }

                string ArticleRecherché;
                ArticleRecherché = System.IO.Path.GetFileNameWithoutExtension(Module1.ChercheItem);
                var msgBoxResult1 = Interaction.MsgBox(ArticleRecherché);

                long localPathFileExists() { string argpszPath = StrShortPath + @"\Index\" + ArticleRecherché + ".article"; var ret = Create.PathFileExists(ref argpszPath); return ret; }

                long localPathFileExists1() { string argpszPath = StrShortPath + @"\Index\" + ArticleRecherché + ".article"; var ret = Create.PathFileExists(ref argpszPath); return ret; }

                if (Conversions.ToBoolean(localPathFileExists1()))
                {
                    var msgBoxResult = Interaction.MsgBox("L'objet " + ArticleRecherché + ".article" + " est un réperoire ou fichier valide");
                    return;
                }
                else
                {

                    NumberOfLine = ListView1.SelectedIndices[0];

                    string Msg;
                    string Style, Title;
                    double Response;
                    string MyString;
                    Msg = "Indexer le fichier ?" + ListView1.Items[ListView1.FocusedItem.Index].Text + " ?";
                    Style = ((int)Constants.vbYesNo + (int)Constants.vbCritical + (int)Constants.vbDefaultButton2).ToString();
                    Title = My.MyProject.Application.Info.Title;
                    Response = Conversions.ToDouble(((int)Interaction.MsgBox(Msg, (MsgBoxStyle)Conversions.ToInteger(Style), Title)).ToString());
                    MyString = Response == (double)Constants.vbYes ? "Oui" : "Non";

                    if (ReferenceEquals(MyString, "Oui"))
                    {
                        Cursor = Cursors.WaitCursor;

                        if (!Directory.Exists("Index"))
                        {
                            My.MyProject.Computer.FileSystem.CreateDirectory("Index");
                        }

                        string fileWExt = System.IO.Path.GetFileNameWithoutExtension(ListView1.Items[ListView1.FocusedItem.Index].Text);

                        string path = StrShortPath + @"\Index\" + fileWExt + ".article";
                        var fs = File.Create(path);
                        fs.Close();

                        var msgBoxResult = Interaction.MsgBox("Fichier article créé !");

                        string resultat;
                        My.MyProject.Forms.Main.ToolStripComboBox1.Items.Clear();
                        var fileNames = My.MyProject.Computer.FileSystem.GetFiles(StrShortPath + @"\Index\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*");
                        foreach (string fileName in fileNames)
                        {
                            resultat = System.IO.Path.GetFileName(fileName);
                            int v = My.MyProject.Forms.Main.ToolStripComboBox1.Items.Add(resultat);
                        }


                        Button7.Enabled = false;

                        var ContrôleLV = My.MyProject.Forms.Main.ListView1;

                        int index;
                        if (ListView1.SelectedIndices.Count != 0)
                        {
                            index = ListView1.SelectedIndices[0];
                            var dialogResult1 = MessageBox.Show(index.ToString());
                        }

                        Module1.selectionné = ListView1.Items[ListView1.FocusedItem.Index].Text;

                        if (ListView1.Items[Ligne].Selected)
                        {
                            var listViewSubItem = ContrôleLV.Items[My.MyProject.Forms.Main.ListView1.Items.Count - 1].SubItems.Add(Module1.selectionné);
                        }
                        var msgBoxResult2 = Interaction.MsgBox(Ligne);
                        ContrôleLV.Refresh();

                        TextBox1.Text = "";

                        Cursor = Cursors.Default;
                    }

                    else if (ReferenceEquals(MyString, "Non"))
                    {
                        return;

                    }
                }
            }

            Button2.Enabled = true;
            Cursor = Cursors.Default;

        }

        public void Button5_Click(object sender, EventArgs e)
        {

            string chaine = TextBox1.Text;

            Button7.Enabled = true;
            var msgBoxResult = Interaction.MsgBox(chaine.Length, (MsgBoxStyle)Constants.vbYes, "Longueur de chaîne de caractères");

            if (chaine.Length < 11)
            {
                TextBox1.Text = "";
                return;
            }

            if (!GetIsValidName(chaine))
            {
                var msgBoxResult1 = Interaction.MsgBox("NOM DU FICHIER INVALIDE !");
                return;
            }

            if (chaine.Substring(chaine.Length - 10) == ".librairie")
            {
                GetExtension = "librairie";
            }

            else if (chaine.Substring(chaine.Length - 10) != ".librairie")
            {

                var msgBoxResult1 = Interaction.MsgBox("Nommage .librairie de l'extension du fichier !");
                string Nouveau = System.IO.Path.GetExtension(chaine);
                string FullPath = chaine;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(FullPath);

                FullPath = fileName + ".librairie";
                TextBox1.Text = FullPath;
            }

            if (FileExists(Path + @"\" + chaine))
            {
                const string Prompt = "Le nom du fichier à créer existe déjà !";
                var msgBoxResult1 = Interaction.MsgBox(Prompt);

                Cursor = Cursors.WaitCursor;

                TextBox1.Text = "";
                bool v = TextBox1.Focus();
                TextBox1.Select();
                return;
            }

            else
            {

                var msgBoxResult1 = Interaction.MsgBox("Le fichier n'existe pas !");
                var listViewItem = ListView1.Items.Add(TextBox1.Text);

                string path = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\";
                var msgBoxResult2 = Interaction.MsgBox(path + FullPath);

                string NewFile = path + TextBox1.Text;

                // If Not File.Exists(NewFile) Then
                // Using sw As StreamWriter = New StreamWriter(NewFile, True, Encoding.UTF8)

                // End Using
                // End If


                using (var sw = File.CreateText(NewFile))
                {

                }

                Button5.Enabled = false;
                Button6.Enabled = true;
                Library = TextBox1.Text;
                Extension = GetExtension;

                Button6_Click(Button6, null);
                TextBox1.Text = "";
                My.MyProject.Forms.Main.ToolStripStatusLabel1.Text = My.MyProject.Forms.Main.ListView1.Items.Count + " librairies chargées";

                int comptage = ListView1.Items.Count;
                switch (ListView1.Items.Count)
                {

                    case 0:
                        {
                            TabPage1.Text = " Aucun fichier de données ";
                            break;
                        }

                    case 1:
                        {
                            TabPage1.Text = comptage + " fichier de données ";
                            break;
                        }

                    default:
                        {
                            TabPage1.Text = comptage + " fichiers de données ";
                            break;
                        }
                }

            }
            Cursor = Cursors.Default;

            Button7.Enabled = false;

        }

        public bool FileExists(string sSource)
        {
            bool FileExistsRet = default;

            FileExistsRet = Create.PathFileExists(ref sSource) == 1L;
            return FileExistsRet;

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            Button5.Enabled = true;
            if (string.IsNullOrEmpty(TextBox1.Text))
                Button5.Enabled = false;

        }

        private bool GetIsValidName(string strFileName)
        {
            bool GetIsValidNameRet = default;

            long lngI;
            const string strInterdit = @"\/:*?""<>|";

            var loopTo = (long)Strings.Len(strInterdit);
            for (lngI = 1L; lngI <= loopTo; lngI++)
            {
                if (Conversions.ToBoolean(Strings.InStr(strFileName, Strings.Mid(strInterdit, (int)lngI, 0x1))))
                {
                    GetIsValidNameRet = true;
                    break;
                }
            }
            GetIsValidNameRet = !GetIsValidNameRet;
            return GetIsValidNameRet;

        }

        private void GroupBox1_Paint(object sender, PaintEventArgs e)
        {

            var g = e.Graphics;
            var pen = new Pen(Color.LightGray, 2.0f);

            g.DrawRectangle(pen, new System.Drawing.Rectangle(TextBox1.Location, TextBox1.Size));
            pen.Dispose();

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            string tmpContenu = "";

            foreach (ListViewItem I in ListView1.Items)
                tmpContenu = tmpContenu + I.Text + Constants.vbCrLf;

            RichTextBox1.Text = tmpContenu;

            string TextRecherche = Label5.Text;

            RichTextBox1.WordWrap = false;
            RichTextBox1.SelectAll();
            RichTextBox1.SelectionBackColor = RichTextBox1.BackColor;

            int indexof = RichTextBox1.Find(TextRecherche, RichTextBoxFinds.WholeWord);
            if (indexof >= 0)
            {
                int idxline = RichTextBox1.GetLineFromCharIndex(indexof);
                RichTextBox1.SelectionStart = indexof;
                RichTextBox1.SelectionLength = RichTextBox1.Lines[idxline].Length;
                RichTextBox1.SelectionBackColor = Color.Yellow;
            }

            string message, title, defaultValue;
            object myValue;

            message = "Entrez une valeur avec extension (.librairie)";

            title = "Zone de saisie";
            defaultValue = ".librairie";

            myValue = Interaction.InputBox(message, title, defaultValue);
            if (ReferenceEquals(myValue, ""))
            {
                // myValue = defaultValue
                return;
            }

            string fileExtension = System.IO.Path.GetExtension(Conversions.ToString(myValue));
            if (fileExtension != ".librairie")
            {
                var msgBoxResult = Interaction.MsgBox("L’extension de nom de fichier ne correspond pas au format de fichier réel. Le fichier a une extension de nom de fichier .librairie");
                return;
            }

            string fileWExt = System.IO.Path.GetFileNameWithoutExtension(Conversions.ToString(myValue));
            if (string.IsNullOrEmpty(fileWExt))
                return;
            if (FileExists(Conversions.ToString(myValue)))
                return;

            if (!GetIsValidName(Conversions.ToString(myValue)))
                return;

            My.MyProject.Computer.FileSystem.RenameFile(StrShortPath + @"\Librairies\" + Label5.Text, Conversions.ToString(myValue));

            Button6_Click(Button6, null);
            RichTextBox1.Text = "";

            My.MyProject.Forms.Main.ListView1.BeginUpdate();
            My.MyProject.Forms.Main.ListView1.Items.Clear();
            if (!File.Exists(Path))
            {
                foreach (string fileName in Directory.GetFiles(Path))
                {
                    My.MyProject.Forms.Main.ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName));
                    var listViewItem = My.MyProject.Forms.Main.ListView1.Items.Add(System.IO.Path.GetFileName(fileName), My.MyProject.Forms.Main.ImageList1.Images.Count - 1);
                }
            }
            My.MyProject.Forms.Main.ToolStripStatusLabel1.Text = My.MyProject.Forms.Main.ListView1.Items.Count + " librairies chargées";
            My.MyProject.Forms.Main.ListView1.EndUpdate();

        }

        public bool IsValidFileNameOrPath(string name)
        {
            // Determines if the name is Nothing.
            if (name is null)
            {
                return false;
            }

            // Determines if there are bad characters in the name.
            foreach (char badChar in System.IO.Path.GetInvalidPathChars())
            {
                if (Strings.InStr(name, Conversions.ToString(badChar)) > 0)
                {
                    return false;
                }
            }

            // The name passes basic validation.
            return true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            string filePath = string.Empty;

            using (var openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|Fichiers librairie (*.librairie)|*.librairie";
                openFileDialog1.FilterIndex = 3;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Multiselect = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    filePath = openFileDialog1.FileName;

                    // Read the contents of the file into a stream
                    var fileStream = openFileDialog1.OpenFile();

                    using (var reader = new StreamReader(fileStream))
                    {
                        string fileContent = reader.ReadToEnd();
                    }
                }
                else if (Conversions.ToBoolean(DialogResult.Cancel))
                {
                    TextBox1.Text = "";
                    return;
                }
            }

            var dialogResult1 = MessageBox.Show("Nom et chemin d'accès du fichier : " + filePath, "Prénommer", MessageBoxButtons.OK, (MessageBoxIcon)System.Windows.MessageBoxImage.Information);

            // Set the help text description for the FolderBrowserDialog.
            FolderBrowserDialog1.Description = "Sélectionnez le répertoire que vous souhaitez utiliser par défaut.";

            // Do not allow the user to create new files via the FolderBrowserDialog.
            FolderBrowserDialog1.ShowNewFolderButton = false;

            string MoveLocation;
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                MoveLocation = FolderBrowserDialog1.SelectedPath;
            }
            else
            {
                return;
            }

            MoveLocation = MoveLocation + @"\" + System.IO.Path.GetFileName(filePath);

            if (!File.Exists(filePath))
            {

                // This statement ensures that the file is created,
                // but the handle is not kept.
                using (var fs = File.Create(filePath))
                {
                }
            }

            // Ensure that the target does not exist.
            if (File.Exists(MoveLocation))
                File.Delete(MoveLocation);

            // Move the file.
            File.Move(filePath, MoveLocation);
            var msgBoxResult = Interaction.MsgBox(filePath + " a été déplacé vers " + MoveLocation + ".");

            // See if the original exists now.
            if (File.Exists(filePath))
            {
                var msgBoxResult1 = Interaction.MsgBox("Le fichier d'origine existe toujours, ce qui est inattendu.");
            }
            else
            {
                var msgBoxResult1 = Interaction.MsgBox("Le fichier d'origine n'existe plus, ce qui est attendu.");
            }

            // 'Actualisation ListView1 Bouton 6

        }

    }
}