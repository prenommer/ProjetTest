using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Prenommer
{

    public static class CueBannerText
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        [DllImport("user32", EntryPoint = "FindWindowExA")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);
        private const int EM_SETCUEBANNER = 0x1501;

        public static void SetCueText(Control cntrl, string text)
        {
            if (cntrl is ComboBox)
            {
                string arglpsz1 = "Edit";
                string arglpsz2 = null;
                var Edit_hWnd = CueBannerText.FindWindowEx(cntrl.Handle, IntPtr.Zero, ref arglpsz1, ref arglpsz2);
                if (!(Edit_hWnd == IntPtr.Zero))
                {
                    int unused = SendMessage(Edit_hWnd, EM_SETCUEBANNER, 0, text);
                }
            }
            else if (cntrl is TextBox)
            {
                int unused1 = SendMessage(cntrl.Handle, EM_SETCUEBANNER, 0, text);
            }
        }

    }

    internal static class Module1
    {

        [DllImport("kernel32", EntryPoint = "LoadLibraryA")]
        private static extern long LoadLibrary(string lpLibFileName);
        [DllImport("kernel32")]
        private static extern long FreeLibrary(long hLibModule);
        [DllImport("user32", EntryPoint = "SendMessageA")]
        private static extern long SendMessageByString(long hWnd, long wMsg, long wParam, string lParam);

        [DllImport("kernel32")]
        public static extern long GetTickCount();
        [DllImport("gdi32")]
        public static extern long GetPixel(long hDC, long X, long Y);

        [DllImport("winspool.drv", EntryPoint = "GetDefaultPrinterA")]
        static extern bool GetDefaultPrinter(StringBuilder szPrinter, ref int bufferSize);
        [DllImport("winspool.drv", EntryPoint = "SetDefaultPrinterA")]
        static extern bool SetDefaultPrinter(string szPrinter);

        public static int I, sauvé, modifié, ajouté, quitté, lit, supprimé, itemprevious, progress, Level;
        public static bool enregistré, cboInit;
        public static long locationprevious, FileSize, FileLength;
        public static string preceding, selectionné;

        public static List<string> filenames = new List<string>();
        public static List<string> ListeModules;
        public static string ChercheItem { get; set; }
        public static string StartFolder { get; set; }
        public static long SpecialFolder { get; set; }
        public static string SzDisplay { get; set; }
        public static bool Dialogue { get; set; }
        public static int IndexEnreg { get; set; }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct WIN32_FIND_DATA
        {
            public int dwFileAttributes;
            public long ftCreationTime;
            public long ftLastAccessTime;
            public long ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public int dwReserved0;
            public int dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternate;
        }

        public const long INVALID_HANDLE_VALUE = -1;

        public struct FILETIME
        {
            public long dwLowDateTime;
            public long dwHighDateTime;
        }

        [DllImport("kernel32", EntryPoint = "FindFirstFileA")]
        static extern long FindFirstFile(string lpFileName, WIN32_FIND_DATA lpFindFileData);
        [DllImport("kernel32")]
        public static extern long FindClose(long hFindFile);
        [DllImport("shlwapi.dll", EntryPoint = "PathFileExistsA")]
        public static extern long PathFileExists(string pszPath);

        public struct Article
        {
            [VBFixedString(18)]
            public string Title;
            [VBFixedString(90)]
            public string Name;
            [VBFixedString(120)]
            public string Charge;
            [VBFixedString(120)]
            public string Institute;
            [VBFixedString(120)]
            public string Celebration;
            [VBFixedString(120)]
            public string Birth;
            [VBFixedString(120)]
            public string Death;
            [VBFixedString(120)]
            public string Otherparties;
            [VBFixedString(120)]
            public string Othernames;
            [VBFixedString(120)]
            public string Venerable;
            [VBFixedString(120)]
            public string Beatified;
            [VBFixedString(120)]
            public string Canonized;
            [VBFixedString(120)]
            public string Heading;
            [VBFixedString(120)]
            public string Patron;
            [VBFixedString(120)]
            public string Link;
            [VBFixedString(1200)]
            public string Biography;
            [VBFixedString(120)]
            public string Image;
            [VBFixedString(200)]
            public string Origin;
        }

        public static long ID { get; set; }
        public static int Position { get; set; }
        public static long Pointer { get; set; }
        public static bool Changed { get; set; }
        public static string FileNameImage { get; set; }
        public static bool Bloqué { get; set; }

        public static bool bChanged = false;
        public static bool bFurther = false;

        public static Bitmap GetImgOFD(Form Frm, PictureBox PicBx)
        {

            var _ErrBitmap = My.Resources.Resources.DocumentError_16x;
            Bitmap ChosenBitmap;

            using (var OFD = new OpenFileDialog())
            {
                OFD.Title = "Veuillez sélectionner un fichier";
                OFD.InitialDirectory = My.MyProject.Application.Info.DirectoryPath + @"\Images\";
                OFD.Filter = "Fichiers Image (*.ico;*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png;*.ico";
                OFD.RestoreDirectory = true;
                OFD.Multiselect = false;
                OFD.CheckFileExists = true;
                if (OFD.ShowDialog(Frm) == DialogResult.OK)
                {
                    ChosenBitmap = (Bitmap)Image.FromFile(OFD.FileName);
                    FileNameImage = OFD.FileName;
                }
                else
                {
                    ChosenBitmap = _ErrBitmap;
                }
            }
            return ChosenBitmap;

        }

        public class BgwArguments
        {
            public BgwArguments(int nbrCompteur, int pauseCompteur)
            {

                Nbr = nbrCompteur;
                Pause = pauseCompteur;

            }

            public int Nbr { get; set; }

            public int Pause { get; set; }

        }

        public class BgwProgress
        {
            public BgwProgress(string txt)
            {

                Text = txt;

            }

            public string Text { get; set; }

        }

    }
}