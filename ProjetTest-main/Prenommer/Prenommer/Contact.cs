using System;
using System.Windows.Forms;

namespace Prenommer
{
    public partial class Contact
    {
        public Contact()
        {
            InitializeComponent();
        }

        private void Contact_Load(object sender, EventArgs e)
        {

            TextBox1.Clear();

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            using (var _Message = new System.Net.Mail.MailMessage())
            {
                // Paramètres SMTP
                using (var _SMTP = new System.Net.Mail.SmtpClient()
                {
                    Credentials = new System.Net.NetworkCredential("Prénommer", "6bLezQr3T54r"),
                    Host = "smtp.orange.fr",
                    Port = 25,
                    EnableSsl = false
                })
                {

                    // Configuration des messages
                    _Message.To.Add(TextBox1.Text.ToString());
                    _Message.From = new System.Net.Mail.MailAddress(address: "prenomen@orange.fr", displayName: "Prénommer", displayNameEncoding: System.Text.Encoding.UTF8);
                    _Message.Subject = TextBox2.Text.ToString();
                    _Message.SubjectEncoding = System.Text.Encoding.UTF8;
                    _Message.Body = TextBox3.Text.ToString();
                    _Message.BodyEncoding = System.Text.Encoding.UTF8;
                    _Message.Priority = System.Net.Mail.MailPriority.Normal;
                    _Message.IsBodyHtml = true; // False

                    try
                    {

                        _SMTP.Send(_Message);
                        var unused = MessageBox.Show("Message envoyé avec succès.", caption: "Prénommer", MessageBoxButtons.OK);
                        foreach (var txt in new[] { TextBox1, TextBox2, TextBox3 })
                            txt.Clear();
                    }

                    catch (System.Net.Mail.SmtpException ex)
                    {
                        var unused1 = MessageBox.Show(ex.ToString(), "Erreur !", MessageBoxButtons.OK);

                    }
                }
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            foreach (Control g in Controls)
            {
                if (g is GroupBox)
                {
                    foreach (Control t in g.Controls)
                    {
                        if (t is TextBox)
                            ((TextBox)t).Clear();
                    }
                }
            }

            Close();

        }

    }
}