using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Prenommer
{

    public partial class Query
    {
        public Query()
        {
            InitializeComponent();
        }

        // Read the contents of the file. This is done in a separate
        // function in order to handle potential file system errors.
        public string GetFileText(string name)
        {

            // If the file has been deleted, the right thing
            // to do in this case is return an empty string.
            string fileContents = string.Empty;

            // If the file has been deleted since we took
            // the snapshot, ignore it and return the empty string.
            if (File.Exists(name))
            {
                fileContents = File.ReadAllText(name);
            }

            return fileContents;

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            // Modify this path as necessary.  
            string startFolder = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\";

            // Take a snapshot of the folder contents.
            var dir = new DirectoryInfo(startFolder);
            var fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

            string searchTerm = TextBox1.Text;

            // Search the contents of each file.
            // A regular expression created with the RegEx class
            // could be used instead of the Contains method.
            var queryMatchingFiles = from file in fileList
                                     where file.Extension == ".librairie"
                                     let fileText = GetFileText(file.FullName)
                                     where fileText.Contains(searchTerm)
                                     select file.FullName;

            int a;

            a = 0;

            // Execute the query.
            foreach (var filename in queryMatchingFiles)
            {
                var listViewItem = ListView1.Items.Add(Path.GetFileName(filename));
                int lineCount = File.ReadAllLines(filename, System.Text.Encoding.UTF8).Length;
                var listViewSubItem = ListView1.Items[a].SubItems.Add(lineCount.ToString());
                a += 1;
            }

            if (ListView1.Items.Count == 0)
                var dialogResult1 = MessageBox.Show("Aucun résultat lors de l'exécution de la requête...");

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            My.MyProject.Forms.Main.Visible = true;
            Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            ListView1.Clear();
            var columnHeader = ListView1.Columns.Add("Noms des fichiers contenant le texte spécifié", 250, HorizontalAlignment.Left);
            var columnHeader6 = ListView1.Columns.Add("Nombre d'enregistrements", 200, HorizontalAlignment.Center);

            // Dim v = TextBox1.Focus()
            TextBox1.Clear();
            CueBannerText.SetCueText(TextBox1, "Rechercher");


        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, PictureBox1.ClientRectangle, Color.LightBlue, ButtonBorderStyle.Solid);

        }

        private void Query_FormClosing(object sender, FormClosingEventArgs e)
        {

            switch (MessageBox.Show("Êtes-vous sûr de vouloir quitter ?", "Prénommer", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    {
                        break;
                    }
                // nothing to do here the form is already closing
                case DialogResult.No:
                    {
                        e.Cancel = true; // cancel the form closing event
                        break;
                    }
                case DialogResult.None:
                    {
                        break;
                    }
                case DialogResult.OK:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
                case DialogResult.Abort:
                    {
                        break;
                    }
                case DialogResult.Retry:
                    {
                        break;
                    }
                case DialogResult.Ignore:
                    {
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            ListView1.Clear();
            var columnHeader = ListView1.Columns.Add("Noms des fichiers contenant le texte spécifié", 250, HorizontalAlignment.Left);
            var columnHeader6 = ListView1.Columns.Add("Nombre d'enregistrements", 200, HorizontalAlignment.Center);

        }

        private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

            e.DrawDefault = true;

            if (e.ItemIndex % 2 == 1)
            {
                e.Item.BackColor = Color.AliceBlue; // .FromArgb(230, 230, 255)
                e.Item.UseItemStyleForSubItems = true;
            }

        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {

            // 'e.DrawDefault = True

            using (var sf = new StringFormat())
            {

                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular))
                {
                    e.Graphics.FillRectangle(Brushes.Lavender, e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf);
                }
            }

        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {

            var info = ListView1.HitTest(e.X, e.Y);
            var msgBoxResult = Interaction.MsgBox(info.SubItem.Text);

            string dgv;
            dgv = info.SubItem.Text;

            for (int i = 0, loopTo = My.MyProject.Forms.Main.ListView1.Items.Count - 1; i <= loopTo; i++)
            {
                if ((My.MyProject.Forms.Main.ListView1.Items[i].Text ?? "") == (dgv ?? ""))
                {
                    My.MyProject.Forms.Main.ListView1.Items[i].Selected = true;
                    break;
                }
            }

            My.MyProject.Forms.Main.ListeToolStripButton.PerformClick();

        }

        private void Query_Load(object sender, EventArgs e)
        {

            CueBannerText.SetCueText(TextBox1, "Rechercher");
            // Dim v = TextBox1.Focus()
            // TextBox1.Select()

        }

    }
}