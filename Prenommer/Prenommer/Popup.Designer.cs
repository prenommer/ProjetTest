using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Prenommer
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Popup : Form
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
            PictureBox1 = new PictureBox();
            PictureBox1.MouseMove += new MouseEventHandler(Popup_MouseMove);
            PictureBox1.MouseUp += new MouseEventHandler(Popup_MouseUp);
            PictureBox1.MouseDown += new MouseEventHandler(Popup_MouseDown);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            PictureBox1.Dock = DockStyle.Fill;
            PictureBox1.Location = new System.Drawing.Point(0, 0);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(800, 600);
            PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // Popup
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(PictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Popup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Popup";
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            KeyPress += new KeyPressEventHandler(Popup_KeyPress);
            Load += new EventHandler(Popup_Load);
            ResumeLayout(false);

        }

        internal PictureBox PictureBox1;
    }
}