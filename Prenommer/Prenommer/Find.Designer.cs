using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Prenommer
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Find : Form
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
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            ListView1 = new ListView();
            ListView1.DrawItem += new DrawListViewItemEventHandler(ListView1_DrawItem);
            ListView1.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(ListView1_DrawColumnHeader);
            ListView1.Click += new EventHandler(ListView1_Click);
            ColumnHeader1 = new ColumnHeader();
            ColumnHeader2 = new ColumnHeader();
            ColumnHeader3 = new ColumnHeader();
            ColumnHeader4 = new ColumnHeader();
            Button2 = new Button();
            Button2.Click += new EventHandler(Button2_Click);
            Label1 = new Label();
            Label2 = new Label();
            PictureBox1 = new PictureBox();
            TextBox1 = new TextBox();
            TextBox1.TextChanged += new EventHandler(TextBox1_TextChanged);
            Button3 = new Button();
            Button3.Click += new EventHandler(Button3_Click);
            TextBox2 = new TextBox();
            TextBox3 = new TextBox();
            ColorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Button1
            // 
            Button1.Location = new System.Drawing.Point(494, 323);
            Button1.Name = "Button1";
            Button1.Size = new Size(141, 36);
            Button1.TabIndex = 0;
            Button1.Text = "Rechercher";
            Button1.UseVisualStyleBackColor = true;
            // 
            // ListView1
            // 
            ListView1.BackColor = SystemColors.Window;
            ListView1.Columns.AddRange(new ColumnHeader[] { ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4 });
            ListView1.FullRowSelect = true;
            ListView1.GridLines = true;
            ListView1.HideSelection = false;
            ListView1.Location = new System.Drawing.Point(12, 59);
            ListView1.MultiSelect = false;
            ListView1.Name = "ListView1";
            ListView1.OwnerDraw = true;
            ListView1.ShowItemToolTips = true;
            ListView1.Size = new Size(473, 300);
            ListView1.TabIndex = 2;
            ListView1.UseCompatibleStateImageBehavior = false;
            ListView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Text = "Noms des fichiers contenant le texte spécifié";
            ColumnHeader1.Width = 225;
            // 
            // ColumnHeader2
            // 
            ColumnHeader2.Text = "Positions";
            ColumnHeader2.TextAlign = HorizontalAlignment.Center;
            ColumnHeader2.Width = 100;
            // 
            // ColumnHeader3
            // 
            ColumnHeader3.Text = "Enregistrements";
            ColumnHeader3.TextAlign = HorizontalAlignment.Center;
            ColumnHeader3.Width = 90;
            // 
            // ColumnHeader4
            // 
            ColumnHeader4.Text = "Octets";
            ColumnHeader4.TextAlign = HorizontalAlignment.Center;
            ColumnHeader4.Width = 50;
            // 
            // Button2
            // 
            Button2.Location = new System.Drawing.Point(494, 281);
            Button2.Name = "Button2";
            Button2.Size = new Size(141, 36);
            Button2.TabIndex = 3;
            Button2.Text = "Mettre à jour";
            Button2.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new System.Drawing.Point(491, 73);
            Label1.Name = "Label1";
            Label1.Size = new Size(82, 13);
            Label1.TabIndex = 4;
            Label1.Text = "Type de fichiers";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new System.Drawing.Point(584, 73);
            Label2.Name = "Label2";
            Label2.Size = new Size(51, 13);
            Label2.TabIndex = 5;
            Label2.Text = "/*.librairie";
            // 
            // PictureBox1
            // 
            PictureBox1.BackColor = SystemColors.Window;
            PictureBox1.Location = new System.Drawing.Point(12, 12);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(623, 31);
            PictureBox1.TabIndex = 6;
            PictureBox1.TabStop = false;
            // 
            // TextBox1
            // 
            TextBox1.BorderStyle = BorderStyle.None;
            TextBox1.Location = new System.Drawing.Point(21, 21);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(605, 13);
            TextBox1.TabIndex = 7;
            // 
            // Button3
            // 
            Button3.Location = new System.Drawing.Point(494, 239);
            Button3.Name = "Button3";
            Button3.Size = new Size(141, 36);
            Button3.TabIndex = 8;
            Button3.Text = "Fermer";
            Button3.UseVisualStyleBackColor = true;
            // 
            // TextBox2
            // 
            TextBox2.BorderStyle = BorderStyle.None;
            TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            TextBox2.Location = new System.Drawing.Point(495, 103);
            TextBox2.Name = "TextBox2";
            TextBox2.ReadOnly = true;
            TextBox2.Size = new Size(139, 13);
            TextBox2.TabIndex = 11;
            TextBox2.Text = "<Expression exacte>";
            TextBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // TextBox3
            // 
            TextBox3.BorderStyle = BorderStyle.None;
            TextBox3.Location = new System.Drawing.Point(496, 125);
            TextBox3.Name = "TextBox3";
            TextBox3.ReadOnly = true;
            TextBox3.Size = new Size(138, 13);
            TextBox3.TabIndex = 12;
            TextBox3.Text = "Sensible à la casse";
            TextBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // Find
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 371);
            Controls.Add(TextBox3);
            Controls.Add(TextBox2);
            Controls.Add(Button3);
            Controls.Add(TextBox1);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(Button2);
            Controls.Add(ListView1);
            Controls.Add(Button1);
            Controls.Add(PictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Find";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rechercher dans les fichiers";
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            FormClosing += new FormClosingEventHandler(Find_FormClosing);
            ResumeLayout(false);
            PerformLayout();

        }

        internal Button Button1;
        internal ListView ListView1;
        internal ColumnHeader ColumnHeader1;
        internal Button Button2;
        internal Label Label1;
        internal Label Label2;
        internal ColumnHeader ColumnHeader2;
        internal PictureBox PictureBox1;
        internal TextBox TextBox1;
        internal Button Button3;
        internal ColumnHeader ColumnHeader3;
        internal TextBox TextBox2;
        internal TextBox TextBox3;
        internal ColumnHeader ColumnHeader4;
        internal ColorDialog ColorDialog1;
    }
}