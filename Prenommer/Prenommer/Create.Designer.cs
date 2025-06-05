using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Prenommer
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Create : Form
    {

        // Form remplace la méthode Dispose pour nettoyer la liste des composants.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Requise par le Concepteur Windows Form
        private System.ComponentModel.IContainer components;

        // REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
        // Elle peut être modifiée à l'aide du Concepteur Windows Form.  
        // Ne la modifiez pas à l'aide de l'éditeur de code.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TabPage1 = new TabPage();
            Button3 = new Button();
            Button3.Click += new EventHandler(Button3_Click);
            Label5 = new Label();
            Label1 = new Label();
            Label4 = new Label();
            Button6 = new Button();
            Button6.Click += new EventHandler(Button6_Click);
            ListView1 = new ListView();
            ListView1.SelectedIndexChanged += new EventHandler(ListView1_SelectedIndexChanged);
            ImageList1 = new ImageList(components);
            Button7 = new Button();
            Button7.Click += new EventHandler(Button7_Click);
            TabControl1 = new TabControl();
            TabPage2 = new TabPage();
            RichTextBox1 = new RichTextBox();
            Button2 = new Button();
            Button2.Click += new EventHandler(Button2_Click);
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            Button4 = new Button();
            Button4.Click += new EventHandler(Button4_Click);
            Button5 = new Button();
            Button5.Click += new EventHandler(Button5_Click);
            Label3 = new Label();
            TextBox1 = new TextBox();
            TextBox1.TextChanged += new EventHandler(TextBox1_TextChanged);
            Label2 = new Label();
            GroupBox1 = new GroupBox();
            GroupBox1.Paint += new PaintEventHandler(GroupBox1_Paint);
            TabControl2 = new TabControl();
            OpenFileDialog1 = new OpenFileDialog();
            FolderBrowserDialog1 = new FolderBrowserDialog();
            TabPage1.SuspendLayout();
            TabControl1.SuspendLayout();
            TabPage2.SuspendLayout();
            TabControl2.SuspendLayout();
            SuspendLayout();
            // 
            // TabPage1
            // 
            TabPage1.Controls.Add(Button3);
            TabPage1.Controls.Add(Label5);
            TabPage1.Controls.Add(Label1);
            TabPage1.Controls.Add(Label4);
            TabPage1.Controls.Add(Button6);
            TabPage1.Controls.Add(ListView1);
            TabPage1.Controls.Add(Button7);
            TabPage1.Location = new System.Drawing.Point(4, 22);
            TabPage1.Name = "TabPage1";
            TabPage1.Padding = new Padding(3);
            TabPage1.Size = new Size(755, 142);
            TabPage1.TabIndex = 0;
            TabPage1.Text = "FIchiers de données";
            TabPage1.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            Button3.Location = new System.Drawing.Point(586, 64);
            Button3.Name = "Button3";
            Button3.Size = new Size(163, 54);
            Button3.TabIndex = 10;
            Button3.Text = "Déplacer";
            Button3.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new System.Drawing.Point(709, 123);
            Label5.Name = "Label5";
            Label5.Size = new Size(0, 13);
            Label5.TabIndex = 9;
            Label5.Visible = false;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new System.Drawing.Point(123, 123);
            Label1.Name = "Label1";
            Label1.Size = new Size(39, 13);
            Label1.TabIndex = 8;
            Label1.Text = "Label1";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new System.Drawing.Point(6, 123);
            Label4.Name = "Label4";
            Label4.Size = new Size(122, 13);
            Label4.TabIndex = 5;
            Label4.Text = "Répertoire sélectionné : ";
            // 
            // Button6
            // 
            Button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Button6.Location = new System.Drawing.Point(586, 6);
            Button6.Name = "Button6";
            Button6.Size = new Size(163, 52);
            Button6.TabIndex = 2;
            Button6.Text = "Actualiser";
            Button6.UseVisualStyleBackColor = true;
            // 
            // ListView1
            // 
            ListView1.FullRowSelect = true;
            ListView1.HideSelection = false;
            ListView1.LargeImageList = ImageList1;
            ListView1.Location = new System.Drawing.Point(6, 6);
            ListView1.MultiSelect = false;
            ListView1.Name = "ListView1";
            ListView1.ShowItemToolTips = true;
            ListView1.Size = new Size(574, 112);
            ListView1.SmallImageList = ImageList1;
            ListView1.Sorting = SortOrder.Ascending;
            ListView1.StateImageList = ImageList1;
            ListView1.TabIndex = 6;
            ListView1.UseCompatibleStateImageBehavior = false;
            ListView1.View = System.Windows.Forms.View.Details;
            // 
            // ImageList1
            // 
            ImageList1.ColorDepth = ColorDepth.Depth32Bit;
            ImageList1.ImageSize = new Size(16, 16);
            ImageList1.TransparentColor = Color.Transparent;
            // 
            // Button7
            // 
            Button7.Enabled = false;
            Button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Button7.Location = new System.Drawing.Point(586, 64);
            Button7.Name = "Button7";
            Button7.Size = new Size(163, 54);
            Button7.TabIndex = 3;
            Button7.Text = "Indexer fichier";
            Button7.UseVisualStyleBackColor = true;
            Button7.Visible = false;
            // 
            // TabControl1
            // 
            TabControl1.Controls.Add(TabPage1);
            TabControl1.Location = new System.Drawing.Point(12, 12);
            TabControl1.Name = "TabControl1";
            TabControl1.SelectedIndex = 0;
            TabControl1.Size = new Size(763, 168);
            TabControl1.TabIndex = 2;
            // 
            // TabPage2
            // 
            TabPage2.Controls.Add(RichTextBox1);
            TabPage2.Controls.Add(Button2);
            TabPage2.Controls.Add(Button1);
            TabPage2.Controls.Add(Button4);
            TabPage2.Controls.Add(Button5);
            TabPage2.Controls.Add(Label3);
            TabPage2.Controls.Add(TextBox1);
            TabPage2.Controls.Add(Label2);
            TabPage2.Controls.Add(GroupBox1);
            TabPage2.Location = new System.Drawing.Point(4, 22);
            TabPage2.Name = "TabPage2";
            TabPage2.Padding = new Padding(3);
            TabPage2.Size = new Size(755, 147);
            TabPage2.TabIndex = 0;
            TabPage2.Text = "Nouveau fichier";
            TabPage2.UseVisualStyleBackColor = true;
            // 
            // RichTextBox1
            // 
            RichTextBox1.BorderStyle = BorderStyle.None;
            RichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            RichTextBox1.Location = new System.Drawing.Point(347, 32);
            RichTextBox1.Name = "RichTextBox1";
            RichTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            RichTextBox1.Size = new Size(401, 106);
            RichTextBox1.TabIndex = 18;
            RichTextBox1.Text = "";
            // 
            // Button2
            // 
            Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Button2.Location = new System.Drawing.Point(9, 88);
            Button2.Name = "Button2";
            Button2.Size = new Size(163, 50);
            Button2.TabIndex = 16;
            Button2.Text = "Renommer fichier";
            Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Button1.Location = new System.Drawing.Point(178, 88);
            Button1.Name = "Button1";
            Button1.Size = new Size(163, 50);
            Button1.TabIndex = 12;
            Button1.Text = "Fermer";
            Button1.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Button4.Location = new System.Drawing.Point(178, 32);
            Button4.Name = "Button4";
            Button4.Size = new Size(163, 50);
            Button4.TabIndex = 10;
            Button4.Text = "Effacer fichier";
            Button4.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Button5.Location = new System.Drawing.Point(9, 32);
            Button5.Name = "Button5";
            Button5.Size = new Size(163, 50);
            Button5.TabIndex = 9;
            Button5.Text = "Créer fichier";
            Button5.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new System.Drawing.Point(400, 9);
            Label3.Name = "Label3";
            Label3.Size = new Size(140, 13);
            Label3.TabIndex = 8;
            Label3.Text = "Extension du fichier : librairie";
            // 
            // TextBox1
            // 
            TextBox1.Location = new System.Drawing.Point(92, 6);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(300, 20);
            TextBox1.TabIndex = 7;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new System.Drawing.Point(6, 9);
            Label2.Name = "Label2";
            Label2.Size = new Size(88, 13);
            Label2.TabIndex = 6;
            Label2.Text = "Nouveau fichier :";
            // 
            // GroupBox1
            // 
            GroupBox1.Location = new System.Drawing.Point(92, 6);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(302, 20);
            GroupBox1.TabIndex = 15;
            GroupBox1.TabStop = false;
            // 
            // TabControl2
            // 
            TabControl2.Controls.Add(TabPage2);
            TabControl2.Location = new System.Drawing.Point(12, 180);
            TabControl2.Name = "TabControl2";
            TabControl2.SelectedIndex = 0;
            TabControl2.Size = new Size(763, 173);
            TabControl2.TabIndex = 3;
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // Create
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 363);
            Controls.Add(TabControl2);
            Controls.Add(TabControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Create";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Créer un fichier";
            TabPage1.ResumeLayout(false);
            TabPage1.PerformLayout();
            TabControl1.ResumeLayout(false);
            TabPage2.ResumeLayout(false);
            TabPage2.PerformLayout();
            TabControl2.ResumeLayout(false);
            Load += new EventHandler(Form1_Load);
            ResumeLayout(false);

        }
        internal TabPage TabPage1;
        internal TabControl TabControl1;
        internal Button Button7;
        internal Button Button6;
        internal ListView ListView1;
        internal Label Label4;
        internal TabPage TabPage2;
        internal Button Button4;
        internal Button Button5;
        internal Label Label3;
        internal TextBox TextBox1;
        internal Label Label2;
        internal TabControl TabControl2;
        internal Button Button1;
        internal ImageList ImageList1;
        internal Label Label1;
        internal GroupBox GroupBox1;
        internal Button Button2;
        internal RichTextBox RichTextBox1;
        internal Label Label5;
        internal Button Button3;
        internal OpenFileDialog OpenFileDialog1;
        internal FolderBrowserDialog FolderBrowserDialog1;
    }
}