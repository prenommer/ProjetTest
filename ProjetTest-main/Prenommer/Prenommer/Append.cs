using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Prenommer
{
    public partial class Append
    {
        public Append()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // List files in the folder.
                ListFiles(FolderBrowserDialog1.SelectedPath);
                SetEnabled();
            }

        }

        private void Append_Load(object sender, EventArgs e)
        {

            // Set the default directory of the folder browser to the current directory.
            FolderBrowserDialog1.SelectedPath = System.IO.Directory.GetCurrentDirectory();

            SetEnabled();

        }

        private void ListFiles(string folderPath)
        {

            ListBox1.Enabled = true;
            ListBox1.Items.Clear();

            var fileNames = System.IO.Directory.GetFiles(folderPath, "*.*", System.IO.SearchOption.TopDirectoryOnly);

            foreach (string fileName in fileNames)
                int v = ListBox1.Items.Add(fileName);

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (ListBox1.SelectedItem is null)
            {
                var dialogResult1 = MessageBox.Show("Veuillez sélectionner un fichier.");
                return;
            }

            // Obtain the file path from the list box selection.
            string filePath = ListBox1.SelectedItem.ToString();

            // Verify that the file was not removed since the
            // Browse button was clicked.
            if (System.IO.File.Exists(filePath) == false)
            {
                var dialogResult1 = MessageBox.Show("Fichier non trouvé : " + filePath);
                return;
            }

            // Obtain file information in a string.
            string fileInfoText = GetTextForOutput(filePath);

            // Show the file information.
            var dialogResult2 = MessageBox.Show(fileInfoText);

            if (CheckBox1.Checked)
            {
                // Place the log file in the same folder as the examined file.
                string logFolder = System.IO.Path.GetDirectoryName(filePath);
                string logFilePath = System.IO.Path.Combine(logFolder, "log.txt");

                // Append text to the log file.
                string logText = "Enregistré le : " + DateTime.Now.ToString() + Constants.vbCrLf + fileInfoText + Constants.vbCrLf + Constants.vbCrLf;

                System.IO.File.AppendAllText(logFilePath, logText);
            }

        }

        private string GetTextForOutput(string filePath)
        {

            // Verify that the file exists.
            if (System.IO.File.Exists(filePath) == false)
            {
                throw new Exception("Fichier non trouvé : " + filePath);
            }

            // Create a new StringBuilder, which is used
            // to efficiently build strings.
            var sb = new System.Text.StringBuilder();

            // Obtain file information.
            var thisFile = new System.IO.FileInfo(filePath);

            // Add file attributes.
            var stringBuilder = sb.Append("File: " + thisFile.FullName);
            var stringBuilder1 = sb.Append(Constants.vbCrLf);
            var stringBuilder2 = sb.Append("Modified: " + thisFile.LastWriteTime.ToString());
            var stringBuilder3 = sb.Append(Constants.vbCrLf);
            var stringBuilder4 = sb.Append("Size: " + thisFile.Length.ToString() + " bytes");
            var stringBuilder5 = sb.Append(Constants.vbCrLf);

            // Open the text file.
            var sr = System.IO.File.OpenText(filePath);

            // Add the first line from the file.
            if (sr.Peek() >= 0)
            {
                var stringBuilder6 = sb.Append("Première ligne : " + sr.ReadLine());
            }
            sr.Close();

            return sb.ToString();

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetEnabled();

            TextBox1.Text = ListBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                var msgBoxResult = Interaction.MsgBox("Veuillez sélectionner un fichier, avant de continuer !", Constants.vbCritical, "Erreur");
            }

            else if (!(CheckBox1.CheckState == CheckState.Unchecked))
            {
                int unmega = 1024 * 1024;
                int ungiga = 1024 * 1024 * 1024;

                var info = new System.IO.FileInfo(TextBox1.Text);
                var msgBoxResult = Interaction.MsgBox(info.Name + Constants.vbCrLf + info.Extension + Constants.vbCrLf + (info.Length / (double)unmega).ToString("0.00") + " Mo" + Constants.vbCrLf + Conversions.ToString(info.CreationTime) + Constants.vbCrLf + Conversions.ToString(info.LastAccessTime) + Constants.vbCrLf + info.DirectoryName, Constants.vbOKOnly, My.MyProject.Application.Info.Title);

            }

        }

        private void SetEnabled()
        {

            bool anySelected = ListBox1.SelectedItem is not null;

            Button3.Enabled = anySelected;
            CheckBox1.Enabled = anySelected;

        }

        private void CheckBox1_CheckStateChanged(object sender, EventArgs e)
        {

            Button3.Enabled = CheckState.Unchecked == Conversions.ToInteger(true);

        }

        private void Button4_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void Button5_Click(object sender, EventArgs e)
        {

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox2.Enabled = true;
            ListBox1.Items.Clear();

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            var myDialog = new FolderBrowserDialog();
            string path;

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                path = myDialog.SelectedPath;
            }
            else
            {
                return;
            }
            ListBox1.Items.Clear();
            int v = ListBox1.Items.Add(path);
            TextBox2.Text = path;
            ListBox1.Enabled = false;

        }

        private static void CopyDirectory(string sourcePath, string destPath)
        {

            if (System.IO.File.Exists(sourcePath))
            {

                System.IO.File.Copy(sourcePath, destPath);
                var msgBoxResult = Interaction.MsgBox("Fichier copié");

            }

        }

        private void Button8_Click(object sender, EventArgs e)
        {

            string SourceFile, DestinationFile;
            SourceFile = TextBox1.Text;
            DestinationFile = TextBox2.Text;
            string Msg, Style, Title;
            int Réponse;

            Msg = "Etes-vous sûr de vouloir copier ce fichier ?";
            Style = ((int)Constants.vbYesNo + (int)Constants.vbQuestion + (int)Constants.vbDefaultButton1).ToString();
            Title = My.MyProject.Application.Info.Title;

            if (System.IO.File.Exists(SourceFile))
            {
                Réponse = (int)Interaction.MsgBox(Msg, (MsgBoxStyle)Conversions.ToInteger(Style), Title);
                if (Réponse == (int)Constants.vbYes)
                {
                    My.MyProject.Computer.FileSystem.CopyFile(SourceFile, DestinationFile + @"\" + System.IO.Path.GetFileName(SourceFile), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                    Visible = true;
                }
            }
            else
            {
                return;
            }

            Button5_Click(Button5, null);

        }

        private void Button9_Click(object sender, EventArgs e)
        {

            string SourceFile, DestinationFile;
            SourceFile = TextBox1.Text;
            DestinationFile = TextBox2.Text;

            if (System.IO.File.Exists(SourceFile))
            {
                if (Interaction.MsgBox("Êtes-vous sûr de vouloir déplacer le fichier ?", MsgBoxStyle.YesNo, My.MyProject.Application.Info.Title) == MsgBoxResult.Yes)
                {
                    My.MyProject.Computer.FileSystem.MoveFile(SourceFile, DestinationFile + @"\" + System.IO.Path.GetFileName(SourceFile), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
                }
            }
            else
            {
                return;
            }

            Button5_Click(Button5, null);

        }

        private void Button12_Click(object sender, EventArgs e)
        {

            string SourceFile;
            SourceFile = TextBox1.Text;
            TextBox2.Enabled = false;

            if (System.IO.File.Exists(SourceFile))
            {
                if (Interaction.MsgBox("Êtes-vous sûr de vouloir supprimer le fichier ?", MsgBoxStyle.YesNo, My.MyProject.Application.Info.Title) == MsgBoxResult.Yes)
                {
                    System.IO.File.Delete(SourceFile, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                }
            }
            else
            {
                return;
            }

            Button5_Click(Button5, null);

        }

        private void Button13_Click(object sender, EventArgs e)
        {

            My.MyProject.Forms.Main.Visible = true;
            Close();

        }

        private void Button10_Click(object sender, EventArgs e)
        {

            string filePath = TextBox1.Text;
            TextBox2.Enabled = false;

            if (System.IO.File.Exists(filePath))
            {

                string message, title, defaultValue;
                object myValue;
                message = "Etes-vous sûr de vouloir renommer ce fichier ?";
                title = My.MyProject.Application.Info.Title;
                defaultValue = "*.*";

                myValue = Interaction.InputBox(message, title, defaultValue);
                if (ReferenceEquals(myValue, ""))
                    myValue = defaultValue;

                if (ReferenceEquals(myValue, ""))
                    myValue = defaultValue;

                string strNewFileName = Conversions.ToString(myValue);
                My.MyProject.Computer.FileSystem.RenameFile(filePath, strNewFileName);
            }
            else
            {
                return;
            }
            Button5_Click(Button5, null);

        }

        private void Button11_Click(object sender, EventArgs e)
        {

            Visible = false;
            My.MyProject.Forms.Main.Show();
            System.Windows.Forms.Application.Restart();

        }

    }
}