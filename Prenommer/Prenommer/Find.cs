using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Prenommer
{

    public partial class Find
    {

        private DataGridView OffsetsDataGridView;

        private string[] testArray;

        public Find()
        {
            OffsetsDataGridView = new DataGridView();
            InitializeComponent();
        }

        public void Button3_Click(object sender, EventArgs e)
        {

            My.MyProject.Forms.Main.Visible = true;
            Close();

        }

        public void Button2_Click(object sender, EventArgs e)
        {

            OffsetsDataGridView.Rows.Clear();
            OffsetsDataGridView.Visible = false;
            Height = 410;
            ListView1.Clear();
            var columnHeader = ListView1.Columns.Add("Noms des fichiers contenant le texte spécifié", 225, HorizontalAlignment.Left);
            var columnHeader5 = ListView1.Columns.Add("Positions", 100, HorizontalAlignment.Center);
            var columnHeader6 = ListView1.Columns.Add("Enregistrements", 90, HorizontalAlignment.Center);
            var columnHeader7 = ListView1.Columns.Add("Octets", 50, HorizontalAlignment.Center);

            bool v = TextBox1.Focus();
            TextBox1.Text = "";

        }

        public void Find_FormClosing(object sender, FormClosingEventArgs e)
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

        public void Button1_Click(object sender, EventArgs e)
        {

            try
            {

                Cursor = Cursors.WaitCursor;

                if (!string.IsNullOrWhiteSpace(Strings.Trim(TextBox1.Text)))
                {
                    string matches = Strings.Trim(TextBox1.Text);
                    System.Collections.ObjectModel.ReadOnlyCollection<string> list;

                    list = My.MyProject.Computer.FileSystem.FindInFiles(My.MyProject.Application.Info.DirectoryPath + @"\Librairies\", matches, true, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly);

                    if (list.Count > 0)
                    {

                        int a;

                        a = 1;
                        int j;
                        int i;
                        foreach (var filename in list)
                        {
                            var ByteBuffer = File.ReadAllBytes(filename);
                            var StringBytes = System.Text.Encoding.UTF8.GetBytes(matches);
                            var offsets = new List<int>();
                            var loopTo = ByteBuffer.Length - StringBytes.Length;
                            for (i = 0; i <= loopTo; i++)
                            {

                                if (ByteBuffer[i] == StringBytes[0])
                                {
                                    j = 1;

                                    while (j < StringBytes.Length && ByteBuffer[i + j] == StringBytes[j])
                                        j += 1;

                                    if (j == StringBytes.Length)
                                    {
                                        // MsgBox("La chaîne a été trouvée à l'offset {0}", i)
                                        offsets.Add(i);
                                    }
                                }
                            }

                            if (offsets.Count > 0)
                            {
                                var listViewItem = ListView1.Items.Add(Path.GetFileName(filename));
                                var listViewSubItem = ListView1.Items[a - 1].SubItems.Add(i.ToString());
                                var listViewSubItem1 = ListView1.Items[a - 1].SubItems.Add(Convert.ToInt32(i / 3188d).ToString());
                                var unused = ListView1.Items[a - 1].SubItems.Add(string.Join(" > ", offsets));
                                a += 1;
                            }

                        }
                    }

                    else
                    {
                        var dialogResult1 = MessageBox.Show("Aucun résultat.");
                    }
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

        public void TextBox1_TextChanged(object sender, EventArgs e)
        {

            OffsetsDataGridView.Rows.Clear();
            OffsetsDataGridView.Visible = false;
            Height = 410;
            ListView1.Clear();
            var columnHeader = ListView1.Columns.Add("Noms des fichiers contenant le texte spécifié", 225, HorizontalAlignment.Left);
            var columnHeader5 = ListView1.Columns.Add("Positions", 100, HorizontalAlignment.Center);
            var columnHeader6 = ListView1.Columns.Add("Enregistrements", 90, HorizontalAlignment.Center);
            var columnHeader7 = ListView1.Columns.Add("Octets", 50, HorizontalAlignment.Center);

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

        private void ListView1_Click(object sender, EventArgs e)
        {

            var testString = new List<int>();
            int NumeroDeLigne;

            try
            {

                // Si aucun élément n'est sélectionné
                if (ListView1.SelectedItems.Count == 0)
                {
                    var msgBoxResult = Interaction.MsgBox("Vous devez sélectionner un élément pour pouvoir le modifier !", (MsgBoxStyle)Constants.vbYes, "Erreur");
                }
                // Sinon, on récupère le numéro de ligne
                else
                {
                    NumeroDeLigne = ListView1.SelectedIndices[0];

                    testArray = Strings.Split(ListView1.Items[NumeroDeLigne].SubItems[3].Text, " > ");

                    SetupDataGridView();

                    PopulateDataGridView();

                }
            }

            catch (Exception ex)
            {
                // Show the exception's message.
                var dialogResult1 = MessageBox.Show(ex.Message);

                // Show the stack trace, which is a list of methods
                // that are currently executing.
                var dialogResult2 = MessageBox.Show("Stack Trace: " + Constants.vbCrLf + ex.StackTrace);
            }
            finally
            {
                // This line executes whether or not the exception occurs.
                var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");
            }

        }

        private void OffsetsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e is not null)
            {

                if (OffsetsDataGridView.Columns[e.ColumnIndex].Name == "Date")
                {
                    if (e.Value is not null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString()).ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("{0} n'est pas une date valide.", e.Value.ToString());
                        }
                    }
                }

            }

        }

        private void SetupDataGridView()
        {

            Height = 470;
            Controls.Add(OffsetsDataGridView);
            OffsetsDataGridView.Visible = true;

            OffsetsDataGridView.ColumnCount = testArray.Length;

            {
                var withBlock = OffsetsDataGridView.ColumnHeadersDefaultCellStyle;
                withBlock.BackColor = Color.Navy;
                withBlock.ForeColor = Color.White;
                withBlock.Font = new System.Drawing.Font(OffsetsDataGridView.Font, FontStyle.Bold);
            }

            {
                var withBlock1 = OffsetsDataGridView;
                withBlock1.Name = "offsetsDataGridView";
                withBlock1.Location = new System.Drawing.Point(13, 376);
                withBlock1.Size = new Size(622, 60);
                withBlock1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                withBlock1.BorderStyle = BorderStyle.None;
                withBlock1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                withBlock1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                withBlock1.GridColor = Color.Black;
                withBlock1.RowHeadersVisible = false;
                withBlock1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                withBlock1.MultiSelect = false;
                withBlock1.ReadOnly = true;
                withBlock1.Dock = DockStyle.Bottom;
            }

            for (int i = 0, loopTo = OffsetsDataGridView.ColumnCount - 1; i <= loopTo; i++)
            {
                OffsetsDataGridView.Columns[i].Name = "Offset " + i;
                OffsetsDataGridView.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font(OffsetsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);
            }

        }

        private void PopulateDataGridView()
        {

            for (int j = 0, loopTo = testArray.Length - 1; j <= loopTo; j++)
                OffsetsDataGridView.Rows[0].Cells[j].Value = testArray[j];

            {
                var withBlock = OffsetsDataGridView;
                withBlock.Columns[0].DisplayIndex = 0;
            }

        }

        private void OffsetsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Dim dgv As String = ListView1.SelectedItems(0).SubItems(0).Text.ToString
            string dgv = ListView1.FocusedItem.Text.ToString();
            string tb = TextBox1.Text;
            double value;

            try
            {

                for (int i = 0, loopTo = My.MyProject.Forms.Main.ListView1.Items.Count - 1; i <= loopTo; i++)
                {
                    if ((My.MyProject.Forms.Main.ListView1.Items[i].Text ?? "") == (dgv ?? ""))
                    {
                        My.MyProject.Forms.Main.ListView1.Items[i].Selected = true;
                        break;
                    }
                }

                My.MyProject.Forms.Main.ListeToolStripButton.PerformClick();

                int posoffset;
                posoffset = Conversions.ToInteger(OffsetsDataGridView.CurrentCell.Value);
                double dub = Convert.ToInt64(Math.Abs(posoffset / 3188d));

                int TotalNodesInTree = My.MyProject.Forms.Main.TreeView1.GetNodeCount(true);
                var aList = new List<string>();
                for (int k = 0, loopTo1 = TotalNodesInTree - 2; k <= loopTo1; k++)
                    aList.Add(My.MyProject.Forms.Main.TreeView1.Nodes[0].Nodes[k].Text);
                aList.Sort();

                string someString = TextBox1.Text;
                var lines = File.ReadAllLines(My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + dgv, System.Text.Encoding.UTF8);
                int found = -1;
                for (int i = 0, loopTo2 = lines.Length - 1; i <= loopTo2; i++)
                {
                    if (lines[i].Contains(someString))
                    {
                        found = i;
                        break;
                    }
                }

                int v;
                var loopTo3 = aList.Count - 1;
                for (v = 0; v <= loopTo3; v++)
                {
                    if (aList[v].Contains(tb.ToString()))
                    {
                        My.MyProject.Forms.Main.TreeView1.SelectedNode = My.MyProject.Forms.Main.TreeView1.Nodes[0].Nodes[v];
                        break;
                    }
                }

                int NombreDeLignes;
                string OuvrirFichier;

                NombreDeLignes = My.MyProject.Forms.Main.ListView1.SelectedIndices[0];
                OuvrirFichier = My.MyProject.Application.Info.DirectoryPath + @"\Librairies\" + My.MyProject.Forms.Main.ListView1.Items[NombreDeLignes].Text;

                if (string.IsNullOrEmpty(My.MyProject.Forms.Main.TextBox33.Text))
                {
                    My.MyProject.Forms.Main.PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                }
                else
                {
                    My.MyProject.Forms.Main.PictureBox1.Image = My.Resources.Resources.Image_16x_1;
                    string literal = My.MyProject.Forms.Main.TextBox33.Text;
                    string subst = literal.Substring(0, 1);
                    My.MyProject.Forms.Main.PictureBox1.ImageLocation = My.MyProject.Application.Info.DirectoryPath + @"\Images\" + subst + @"\" + My.MyProject.Forms.Main.TextBox33.Text;
                }

                MinimizeBox = true;

                for (int p = 0, loopTo4 = testArray.Length - 1; p <= loopTo4; p++)
                {

                    string values = testArray[p] + "." + 0;
                    string valeur = CSD(values).ToString();
                    value = Conversions.ToDouble(valeur) / 3188.0d;
                    value = Math.Truncate(value * Math.Pow(10d, 12d)) / Math.Pow(10d, 12d);

                    if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 18d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 108d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox1.Focus();
                        My.MyProject.Forms.Main.TextBox1.SelectionStart = My.MyProject.Forms.Main.TextBox1.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox1.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox1.ScrollToCaret();
                        System.Threading.Thread.Sleep(1000);
                    }

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 108d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 228d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox4.Focus();
                        My.MyProject.Forms.Main.TextBox4.SelectionStart = My.MyProject.Forms.Main.TextBox4.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox4.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox4.ScrollToCaret();
                        System.Threading.Thread.Sleep(1000);
                    }

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 228d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 348d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox15.Focus();
                        My.MyProject.Forms.Main.TextBox15.SelectionStart = My.MyProject.Forms.Main.TextBox15.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox15.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox15.ScrollToCaret();
                        System.Threading.Thread.Sleep(1000);
                    }

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 348d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 468d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox5.Focus();
                        My.MyProject.Forms.Main.TextBox5.SelectionStart = My.MyProject.Forms.Main.TextBox5.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox5.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox5.ScrollToCaret();
                        System.Threading.Thread.Sleep(1000);
                    }

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 468d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 588d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox7.Focus();
                        My.MyProject.Forms.Main.TextBox7.SelectionStart = My.MyProject.Forms.Main.TextBox7.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox7.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox7.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 588d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 708d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox9.Focus();
                        My.MyProject.Forms.Main.TextBox9.SelectionStart = My.MyProject.Forms.Main.TextBox9.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox9.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox9.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 708d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 828d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox13.Focus();
                        My.MyProject.Forms.Main.TextBox13.SelectionStart = My.MyProject.Forms.Main.TextBox13.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox13.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox13.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 828d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 948d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox18.Focus();
                        My.MyProject.Forms.Main.TextBox18.SelectionStart = My.MyProject.Forms.Main.TextBox18.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox18.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox18.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 948d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 1068d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox23.Focus();
                        My.MyProject.Forms.Main.TextBox23.SelectionStart = My.MyProject.Forms.Main.TextBox23.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox23.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox23.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 1068d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 1188d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox24.Focus();
                        My.MyProject.Forms.Main.TextBox24.SelectionStart = My.MyProject.Forms.Main.TextBox24.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox24.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox24.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 1188d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 1308d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox25.Focus();
                        My.MyProject.Forms.Main.TextBox25.SelectionStart = My.MyProject.Forms.Main.TextBox25.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox25.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox25.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 1308d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 1428d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox26.Focus();
                        My.MyProject.Forms.Main.TextBox26.SelectionStart = My.MyProject.Forms.Main.TextBox26.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox26.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox26.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 1428d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 1548d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox28.Focus();
                        My.MyProject.Forms.Main.TextBox28.SelectionStart = My.MyProject.Forms.Main.TextBox28.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox28.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox28.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 1548d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 1668d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox29.Focus();
                        My.MyProject.Forms.Main.TextBox29.SelectionStart = My.MyProject.Forms.Main.TextBox29.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox29.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox29.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 1668d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 1788d / 3188d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox33.Focus();
                        My.MyProject.Forms.Main.TextBox33.SelectionStart = My.MyProject.Forms.Main.TextBox33.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox33.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox33.ScrollToCaret();
                    }
                    // Threading.Thread.Sleep(1000)

                    else if (Conversions.ToInteger(testArray[p]) / 3188d >= dub + 1788d / 3188d & Conversions.ToInteger(testArray[p]) / 3188d < dub + 1d)
                    {
                        bool v1 = My.MyProject.Forms.Main.TextBox31.Focus();
                        My.MyProject.Forms.Main.TextBox31.SelectionStart = My.MyProject.Forms.Main.TextBox31.Text.IndexOf(TextBox1.Text);
                        My.MyProject.Forms.Main.TextBox31.SelectionLength = TextBox1.TextLength;
                        My.MyProject.Forms.Main.TextBox31.ScrollToCaret();
                        // Threading.Thread.Sleep(1000)
                    }

                }
            }

            catch (Exception ex)
            {
                // Show the exception's message.
                var dialogResult1 = MessageBox.Show(ex.Message);

                // Show the stack trace, which is a list of methods
                // that are currently executing.
                var dialogResult2 = MessageBox.Show("Stack Trace: " + Constants.vbCrLf + ex.StackTrace);
            }
            finally
            {
                // This line executes whether or not the exception occurs.
                var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");
            }

        }

        // Conversion d'une String en Double
        public double CSD(string NombreString)
        {
            double CSDRet = default;

            CSDRet = 0d;
            bool v = double.TryParse(NombreString.Replace(Conversions.ToString('.'), (1d / 2d).ToString().Substring(1, 1)).ToString(), out CSDRet);
            return CSDRet;

        }

    }
}