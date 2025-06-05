using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Prenommer
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class About : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            CmdSysInfo = new Button();
            CmdSysInfo.Click += new EventHandler(CmdSysInfo_Click);
            CmdOK = new Button();
            CmdOK.Click += new EventHandler(CmdOK_Click);
            Label1 = new Label();
            Label5 = new Label();
            Label8 = new Label();
            Panel1 = new Panel();
            LinkLabel1 = new LinkLabel();
            LinkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked);
            Label6 = new Label();
            PictureBox5 = new PictureBox();
            Label4 = new Label();
            Label3 = new Label();
            PictureBox4 = new PictureBox();
            TextBox3 = new TextBox();
            TextBox2 = new TextBox();
            PictureBox3 = new PictureBox();
            TextBox1 = new TextBox();
            Label9 = new Label();
            PictureBox2 = new PictureBox();
            PictureBox1 = new PictureBox();
            Label2 = new Label();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CmdSysInfo
            // 
            CmdSysInfo.Location = new System.Drawing.Point(514, 354);
            CmdSysInfo.Name = "CmdSysInfo";
            CmdSysInfo.Size = new Size(141, 38);
            CmdSysInfo.TabIndex = 2;
            CmdSysInfo.Text = "Informations système";
            CmdSysInfo.UseVisualStyleBackColor = true;
            // 
            // CmdOK
            // 
            CmdOK.FlatStyle = FlatStyle.Flat;
            CmdOK.Location = new System.Drawing.Point(514, 404);
            CmdOK.Name = "CmdOK";
            CmdOK.Size = new Size(141, 34);
            CmdOK.TabIndex = 3;
            CmdOK.Text = "OK";
            CmdOK.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new System.Drawing.Point(0, 3);
            Label1.Name = "Label1";
            Label1.Size = new Size(53, 13);
            Label1.TabIndex = 4;
            Label1.Text = "Contact : ";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new System.Drawing.Point(0, 157);
            Label5.Name = "Label5";
            Label5.Size = new Size(117, 13);
            Label5.TabIndex = 8;
            Label5.Text = "Système d'exploitation :";
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Location = new System.Drawing.Point(0, 178);
            Label8.Name = "Label8";
            Label8.Size = new Size(79, 13);
            Label8.TabIndex = 11;
            Label8.Text = "Avertissement :";
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.White;
            Panel1.Controls.Add(LinkLabel1);
            Panel1.Controls.Add(Label6);
            Panel1.Controls.Add(PictureBox5);
            Panel1.Controls.Add(Label4);
            Panel1.Controls.Add(Label3);
            Panel1.Controls.Add(PictureBox4);
            Panel1.Controls.Add(TextBox3);
            Panel1.Controls.Add(TextBox2);
            Panel1.Controls.Add(PictureBox3);
            Panel1.Controls.Add(TextBox1);
            Panel1.Controls.Add(Label9);
            Panel1.Controls.Add(Label8);
            Panel1.Controls.Add(Label1);
            Panel1.Controls.Add(Label5);
            Panel1.Location = new System.Drawing.Point(12, 197);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(580, 241);
            Panel1.TabIndex = 12;
            // 
            // LinkLabel1
            // 
            LinkLabel1.AutoSize = true;
            LinkLabel1.Location = new System.Drawing.Point(52, 55);
            LinkLabel1.Name = "LinkLabel1";
            LinkLabel1.Size = new Size(145, 13);
            LinkLabel1.TabIndex = 25;
            LinkLabel1.TabStop = true;
            LinkLabel1.Text = "https://www.prenommer.com";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new System.Drawing.Point(0, 55);
            Label6.Name = "Label6";
            Label6.Size = new Size(57, 13);
            Label6.TabIndex = 23;
            Label6.Text = "Site Web :";
            // 
            // PictureBox5
            // 
            PictureBox5.BackColor = SystemColors.Control;
            PictureBox5.Location = new System.Drawing.Point(255, 3);
            PictureBox5.Name = "PictureBox5";
            PictureBox5.Size = new Size(3, 138);
            PictureBox5.TabIndex = 22;
            PictureBox5.TabStop = false;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new System.Drawing.Point(54, 29);
            Label4.Name = "Label4";
            Label4.Size = new Size(0, 13);
            Label4.TabIndex = 21;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new System.Drawing.Point(0, 29);
            Label3.Name = "Label3";
            Label3.Size = new Size(48, 13);
            Label3.TabIndex = 20;
            Label3.Text = "Version :";
            // 
            // PictureBox4
            // 
            PictureBox4.BackColor = Color.White;
            PictureBox4.Location = new System.Drawing.Point(55, 20);
            PictureBox4.Name = "PictureBox4";
            PictureBox4.Size = new Size(203, 93);
            PictureBox4.TabIndex = 18;
            PictureBox4.TabStop = false;
            // 
            // TextBox3
            // 
            TextBox3.BorderStyle = BorderStyle.None;
            TextBox3.Font = new System.Drawing.Font("Montserrat", 8.249999f, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBox3.Location = new System.Drawing.Point(265, 3);
            TextBox3.Multiline = true;
            TextBox3.Name = "TextBox3";
            TextBox3.Size = new Size(310, 110);
            TextBox3.TabIndex = 17;
            TextBox3.Text = resources.GetString("TextBox3.Text");
            // 
            // TextBox2
            // 
            TextBox2.BorderStyle = BorderStyle.None;
            TextBox2.Font = new System.Drawing.Font("Montserrat", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            TextBox2.Location = new System.Drawing.Point(265, 110);
            TextBox2.Multiline = true;
            TextBox2.Name = "TextBox2";
            TextBox2.Size = new Size(310, 27);
            TextBox2.TabIndex = 16;
            TextBox2.Text = "À la mémoire de Guillaume";
            TextBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // PictureBox3
            // 
            PictureBox3.Image = My.Resources.Resources.address;
            PictureBox3.InitialImage = null;
            PictureBox3.Location = new System.Drawing.Point(55, 3);
            PictureBox3.Name = "PictureBox3";
            PictureBox3.Size = new Size(203, 138);
            PictureBox3.TabIndex = 15;
            PictureBox3.TabStop = false;
            // 
            // TextBox1
            // 
            TextBox1.BorderStyle = BorderStyle.None;
            TextBox1.Location = new System.Drawing.Point(126, 178);
            TextBox1.Multiline = true;
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(370, 63);
            TextBox1.TabIndex = 14;
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Location = new System.Drawing.Point(123, 157);
            Label9.Name = "Label9";
            Label9.Size = new Size(39, 13);
            Label9.TabIndex = 12;
            Label9.Text = "Label9";
            // 
            // PictureBox2
            // 
            PictureBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PictureBox2.Location = new System.Drawing.Point(12, 188);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new Size(643, 3);
            PictureBox2.TabIndex = 1;
            PictureBox2.TabStop = false;
            // 
            // PictureBox1
            // 
            PictureBox1.BackColor = Color.White;
            PictureBox1.Dock = DockStyle.Fill;
            PictureBox1.Image = My.Resources.Resources.prenommer2_2;
            PictureBox1.Location = new System.Drawing.Point(0, 0);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(665, 450);
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.BackColor = SystemColors.Window;
            Label2.Location = new System.Drawing.Point(99, 172);
            Label2.Name = "Label2";
            Label2.Size = new Size(0, 13);
            Label2.TabIndex = 13;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 450);
            Controls.Add(Label2);
            Controls.Add(CmdOK);
            Controls.Add(CmdSysInfo);
            Controls.Add(Panel1);
            Controls.Add(PictureBox2);
            Controls.Add(PictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "About";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "À propos de Prénommer";
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            Load += new EventHandler(About_Load);
            KeyPress += new KeyPressEventHandler(About_KeyPress);
            ResumeLayout(false);
            PerformLayout();

        }

        internal PictureBox PictureBox1;
        internal PictureBox PictureBox2;
        internal Button CmdSysInfo;
        internal Button CmdOK;
        internal Label Label1;
        internal Label Label5;
        internal Label Label8;
        internal Panel Panel1;
        internal Label Label9;
        internal TextBox TextBox1;
        internal PictureBox PictureBox3;
        internal TextBox TextBox2;
        internal TextBox TextBox3;
        internal Label Label2;
        internal PictureBox PictureBox4;
        internal Label Label3;
        internal Label Label4;
        internal PictureBox PictureBox5;
        internal Label Label6;
        internal LinkLabel LinkLabel1;
    }
}