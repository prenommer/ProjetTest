using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Prenommer
{
    public partial class Popup
    {

        private bool IsFormBeingDragged = false;
        private int MouseDownX;
        private int MouseDownY;

        public Popup()
        {
            InitializeComponent();
        }

        private void Popup_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Strings.Asc(e.KeyChar) == (int)Keys.Escape)
            {

                // Me.Close()

                Dispose();

            }

        }

        private void Popup_Load(object sender, EventArgs e)
        {

            Height = PictureBox1.Image.Height;
            Width = PictureBox1.Image.Width;

        }

        private void Popup_MouseMove(object sender, MouseEventArgs e)
        {

            if (IsFormBeingDragged)
            {
                var temp = new System.Drawing.Point()
                {
                    X = Location.X + (e.X - MouseDownX),
                    Y = Location.Y + (e.Y - MouseDownY)
                };
                Location = temp;
            }

        }

        private void Popup_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                IsFormBeingDragged = false;
            }

        }

        private void Popup_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                IsFormBeingDragged = true;
                MouseDownX = e.X;
                MouseDownY = e.Y;
            }

        }

    }
}