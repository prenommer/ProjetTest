using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Prenommer
{

    public partial class About
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                {
                    var withBlock = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                    Label2.Text = "V" + withBlock.Major + "." + withBlock.Minor + "." + withBlock.Build;
                }
            }

            Label9.Text = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            TextBox1.Text = "LE PROGRAMME ET LA DOCUMENTATION ASSOCIÉS VOUS SONT FOURNIS « EN L'ÉTAT », AVEC LEURS DEFAUTS ET SANS GARANTIE D’AUCUNE SORTE.";

            // Dim unused = FileVersionInfo.GetVersionInfo(Path.Combine(My.Application.Info.DirectoryPath, "Prenommer.exe"))
            // Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(My.Application.Info.DirectoryPath + "\Prenommer.exe")
            // Label4.Text = myFileVersionInfo.FileVersion

            var myFileVersionInfo = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.ExecutablePath);
            Label4.Text = myFileVersionInfo.FileVersion;

        }

        private void CmdSysInfo_Click(object sender, EventArgs e)
        {

            var key = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Shared Tools\MSInfo", "Path", null);

            if (key is not null)
            {
                var unused = Process.Start(key.ToString());
            }

        }

        private void CmdOK_Click(object sender, EventArgs e)
        {

            int iCount;
            for (iCount = 90; iCount >= 10; iCount -= 10)
            {
                Opacity = iCount / 100d;
                Refresh();
                System.Threading.Thread.Sleep(50);
            }

            Close();

        }

        private void About_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool v = ProcessDialogKey(Keys.Escape);

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Close();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            LinkLabel1.LinkVisited = true;
            var process = Process.Start("https://www.prenommer.com");

        }

    }
}