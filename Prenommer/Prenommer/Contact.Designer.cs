using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Prenommer
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Contact : Form
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
            TextBox1 = new TextBox();
            TextBox2 = new TextBox();
            TextBox3 = new TextBox();
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            Button2 = new Button();
            Button2.Click += new EventHandler(Button2_Click);
            SuspendLayout();
            // 
            // TextBox1
            // 
            TextBox1.Font = new System.Drawing.Font("Roboto", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBox1.Location = new System.Drawing.Point(61, 106);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(300, 27);
            TextBox1.TabIndex = 0;
            TextBox1.Text = "" + '\r' + '\n';
            // 
            // TextBox2
            // 
            TextBox2.Font = new System.Drawing.Font("Roboto", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBox2.Location = new System.Drawing.Point(61, 154);
            TextBox2.Name = "TextBox2";
            TextBox2.Size = new Size(300, 27);
            TextBox2.TabIndex = 1;
            // 
            // TextBox3
            // 
            TextBox3.Font = new System.Drawing.Font("Roboto", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextBox3.Location = new System.Drawing.Point(61, 208);
            TextBox3.Multiline = true;
            TextBox3.Name = "TextBox3";
            TextBox3.ScrollBars = ScrollBars.Vertical;
            TextBox3.Size = new Size(600, 180);
            TextBox3.TabIndex = 2;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label1.Location = new System.Drawing.Point(12, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(80, 24);
            Label1.TabIndex = 3;
            Label1.Text = "Contact";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new System.Drawing.Point(13, 48);
            Label2.Name = "Label2";
            Label2.Size = new Size(300, 13);
            Label2.TabIndex = 4;
            Label2.Text = "Une remarque ? une suggestion ? N'hésitez-pas à nous écrire.";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new System.Drawing.Point(61, 89);
            Label3.Name = "Label3";
            Label3.Size = new Size(99, 13);
            Label3.TabIndex = 5;
            Label3.Text = "Courriel (obligatoire)";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new System.Drawing.Point(58, 138);
            Label4.Name = "Label4";
            Label4.Size = new Size(31, 13);
            Label4.TabIndex = 6;
            Label4.Text = "Sujet";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new System.Drawing.Point(61, 191);
            Label5.Name = "Label5";
            Label5.Size = new Size(77, 13);
            Label5.TabIndex = 7;
            Label5.Text = "Votre message";
            // 
            // Button1
            // 
            Button1.Location = new System.Drawing.Point(61, 407);
            Button1.Name = "Button1";
            Button1.Size = new Size(119, 27);
            Button1.TabIndex = 8;
            Button1.Text = "Envoyer";
            Button1.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            Button2.Location = new System.Drawing.Point(194, 407);
            Button2.Name = "Button2";
            Button2.Size = new Size(119, 27);
            Button2.TabIndex = 9;
            Button2.Text = "Quitter";
            Button2.UseVisualStyleBackColor = true;
            // 
            // Contact
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 450);
            Controls.Add(Button2);
            Controls.Add(Button1);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(TextBox3);
            Controls.Add(TextBox2);
            Controls.Add(TextBox1);
            MaximizeBox = false;
            Name = "Contact";
            Text = "Formulaire de contact";
            Load += new EventHandler(Contact_Load);
            ResumeLayout(false);
            PerformLayout();

        }

        internal TextBox TextBox1;
        internal TextBox TextBox2;
        internal TextBox TextBox3;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal Button Button1;
        internal Button Button2;
    }
}