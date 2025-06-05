using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Prenommer
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Append : Form
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
            GroupBox1 = new GroupBox();
            Button5 = new Button();
            Button5.Click += new EventHandler(Button5_Click);
            Button4 = new Button();
            Button4.Click += new EventHandler(Button4_Click);
            CheckBox1 = new System.Windows.Forms.CheckBox();
            CheckBox1.CheckStateChanged += new EventHandler(CheckBox1_CheckStateChanged);
            Button3 = new Button();
            Button3.Click += new EventHandler(Button3_Click);
            ListBox1 = new ListBox();
            ListBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);
            Button2 = new Button();
            Button2.Click += new EventHandler(Button2_Click);
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            TextBox2 = new TextBox();
            TextBox1 = new TextBox();
            Label2 = new Label();
            Label1 = new Label();
            GroupBox2 = new GroupBox();
            Button13 = new Button();
            Button13.Click += new EventHandler(Button13_Click);
            Button12 = new Button();
            Button12.Click += new EventHandler(Button12_Click);
            Button11 = new Button();
            Button11.Click += new EventHandler(Button11_Click);
            Button10 = new Button();
            Button10.Click += new EventHandler(Button10_Click);
            Button9 = new Button();
            Button9.Click += new EventHandler(Button9_Click);
            Button8 = new Button();
            Button8.Click += new EventHandler(Button8_Click);
            FolderBrowserDialog1 = new FolderBrowserDialog();
            OpenFileDialog1 = new OpenFileDialog();
            GroupBox1.SuspendLayout();
            GroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(Button5);
            GroupBox1.Controls.Add(Button4);
            GroupBox1.Controls.Add(CheckBox1);
            GroupBox1.Controls.Add(Button3);
            GroupBox1.Controls.Add(ListBox1);
            GroupBox1.Controls.Add(Button2);
            GroupBox1.Controls.Add(Button1);
            GroupBox1.Controls.Add(TextBox2);
            GroupBox1.Controls.Add(TextBox1);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Location = new System.Drawing.Point(10, 10);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(765, 245);
            GroupBox1.TabIndex = 0;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Navigation";
            // 
            // Button5
            // 
            Button5.Location = new System.Drawing.Point(610, 181);
            Button5.Name = "Button5";
            Button5.Size = new Size(140, 25);
            Button5.TabIndex = 10;
            Button5.Text = "Réinitialiser";
            Button5.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            Button4.Location = new System.Drawing.Point(610, 141);
            Button4.Name = "Button4";
            Button4.Size = new Size(140, 25);
            Button4.TabIndex = 9;
            Button4.Text = "Fermer";
            Button4.UseVisualStyleBackColor = true;
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Checked = true;
            CheckBox1.CheckState = CheckState.Checked;
            CheckBox1.Location = new System.Drawing.Point(88, 220);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(183, 17);
            CheckBox1.TabIndex = 8;
            CheckBox1.Text = "Afficher les informations du fichier";
            CheckBox1.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            Button3.Location = new System.Drawing.Point(610, 102);
            Button3.Name = "Button3";
            Button3.Size = new Size(140, 25);
            Button3.TabIndex = 7;
            Button3.Text = "Journal";
            Button3.UseVisualStyleBackColor = true;
            // 
            // ListBox1
            // 
            ListBox1.BorderStyle = BorderStyle.None;
            ListBox1.FormattingEnabled = true;
            ListBox1.HorizontalScrollbar = true;
            ListBox1.Location = new System.Drawing.Point(88, 102);
            ListBox1.Name = "ListBox1";
            ListBox1.Size = new Size(510, 104);
            ListBox1.Sorted = true;
            ListBox1.TabIndex = 6;
            // 
            // Button2
            // 
            Button2.Location = new System.Drawing.Point(610, 64);
            Button2.Name = "Button2";
            Button2.Size = new Size(140, 25);
            Button2.TabIndex = 5;
            Button2.Text = "Sélectionner le dossier";
            Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            Button1.Location = new System.Drawing.Point(610, 27);
            Button1.Name = "Button1";
            Button1.Size = new Size(140, 25);
            Button1.TabIndex = 4;
            Button1.Text = "Parcourir";
            Button1.UseVisualStyleBackColor = true;
            // 
            // TextBox2
            // 
            TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBox2.Location = new System.Drawing.Point(88, 65);
            TextBox2.Name = "TextBox2";
            TextBox2.Size = new Size(510, 22);
            TextBox2.TabIndex = 3;
            // 
            // TextBox1
            // 
            TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBox1.Location = new System.Drawing.Point(88, 28);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(510, 22);
            TextBox1.TabIndex = 2;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new System.Drawing.Point(12, 70);
            Label2.Name = "Label2";
            Label2.Size = new Size(60, 13);
            Label2.TabIndex = 1;
            Label2.Text = "Destination";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new System.Drawing.Point(12, 31);
            Label1.Name = "Label1";
            Label1.Size = new Size(41, 13);
            Label1.TabIndex = 0;
            Label1.Text = "Source";
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(Button13);
            GroupBox2.Controls.Add(Button12);
            GroupBox2.Controls.Add(Button11);
            GroupBox2.Controls.Add(Button10);
            GroupBox2.Controls.Add(Button9);
            GroupBox2.Controls.Add(Button8);
            GroupBox2.Location = new System.Drawing.Point(10, 261);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(765, 80);
            GroupBox2.TabIndex = 1;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Opérations";
            // 
            // Button13
            // 
            Button13.Location = new System.Drawing.Point(380, 46);
            Button13.Name = "Button13";
            Button13.Size = new Size(140, 25);
            Button13.TabIndex = 16;
            Button13.Text = "Fermer";
            Button13.UseVisualStyleBackColor = true;
            // 
            // Button12
            // 
            Button12.Location = new System.Drawing.Point(88, 46);
            Button12.Name = "Button12";
            Button12.Size = new Size(140, 25);
            Button12.TabIndex = 15;
            Button12.Text = "Supprimer";
            Button12.UseVisualStyleBackColor = true;
            // 
            // Button11
            // 
            Button11.Location = new System.Drawing.Point(234, 46);
            Button11.Name = "Button11";
            Button11.Size = new Size(140, 25);
            Button11.TabIndex = 14;
            Button11.Text = "Mise à jour";
            Button11.UseVisualStyleBackColor = true;
            // 
            // Button10
            // 
            Button10.Location = new System.Drawing.Point(380, 15);
            Button10.Name = "Button10";
            Button10.Size = new Size(140, 25);
            Button10.TabIndex = 13;
            Button10.Text = "Renommer";
            Button10.UseVisualStyleBackColor = true;
            // 
            // Button9
            // 
            Button9.Location = new System.Drawing.Point(234, 15);
            Button9.Name = "Button9";
            Button9.Size = new Size(140, 25);
            Button9.TabIndex = 12;
            Button9.Text = "Déplacer";
            Button9.UseVisualStyleBackColor = true;
            // 
            // Button8
            // 
            Button8.Location = new System.Drawing.Point(88, 14);
            Button8.Name = "Button8";
            Button8.Size = new Size(140, 25);
            Button8.TabIndex = 11;
            Button8.Text = "Copier";
            Button8.UseVisualStyleBackColor = true;
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // Append
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 349);
            Controls.Add(GroupBox2);
            Controls.Add(GroupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Append";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ajouter un fichier";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            GroupBox2.ResumeLayout(false);
            Load += new EventHandler(Append_Load);
            ResumeLayout(false);

        }

        internal GroupBox GroupBox1;
        internal GroupBox GroupBox2;
        internal Button Button2;
        internal Button Button1;
        internal TextBox TextBox2;
        internal TextBox TextBox1;
        internal Label Label2;
        internal Label Label1;
        internal FolderBrowserDialog FolderBrowserDialog1;
        internal ListBox ListBox1;
        internal Button Button3;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal Button Button5;
        internal Button Button4;
        internal Button Button13;
        internal Button Button12;
        internal Button Button11;
        internal Button Button10;
        internal Button Button9;
        internal Button Button8;
        internal OpenFileDialog OpenFileDialog1;
    }
}