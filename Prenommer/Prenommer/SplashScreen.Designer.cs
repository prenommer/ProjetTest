using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Prenommer
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class SplashScreen : Form
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
            Label1 = new Label();
            Label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            PictureBox1.Dock = DockStyle.Fill;
            PictureBox1.Image = My.Resources.Resources._800px_Beato_angelico__predella_della_pala_di_fiesole_02;
            PictureBox1.Location = new System.Drawing.Point(0, 0);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(784, 425);
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label1.Location = new System.Drawing.Point(670, 405);
            Label1.Name = "Label1";
            Label1.Size = new Size(105, 13);
            Label1.TabIndex = 3;
            Label1.Text = "PRÉNOMMER 2021";
            Label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label2.Location = new System.Drawing.Point(12, 405);
            Label2.Name = "Label2";
            Label2.Size = new Size(388, 13);
            Label2.TabIndex = 4;
            Label2.Text = "Fra Angelico, Les précurseurs du Christ avec les saints et les martyrs, 1423-1424" + ".";
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 425);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(PictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashScreen";
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        internal PictureBox PictureBox1;
        internal Label Label1;
        internal Label Label2;
    }
}