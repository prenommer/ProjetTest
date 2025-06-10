using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Prenommer
{
    [DesignerGenerated()]
    public partial class Main : Form
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            StatusStrip1 = new StatusStrip();
            ToolStripProgressBar1 = new ToolStripProgressBar();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel2 = new ToolStripStatusLabel();
            ToolStripStatusLabel3 = new ToolStripStatusLabel();
            ToolStripStatusLabel4 = new ToolStripStatusLabel();
            ToolStripStatusLabel5 = new ToolStripStatusLabel();
            ToolStripStatusLabel6 = new ToolStripStatusLabel();
            ToolStripStatusLabel6.MouseMove += new MouseEventHandler(ToolStripStatusLabel6_MouseMove);
            PnlContenuLeft = new Panel();
            ToolStrip3 = new ToolStrip();
            ToolStripButton1 = new ToolStripButton();
            ToolStripButton1.Click += new EventHandler(ToolStripButton1_Click);
            ToolStripButton2 = new ToolStripButton();
            ToolStripButton2.Click += new EventHandler(ToolStripButton2_Click);
            ToolStripSeparator9 = new ToolStripSeparator();
            ToolStripButton3 = new ToolStripButton();
            ToolStripButton3.Click += new EventHandler(ToolStripButton3_Click);
            ToolStripButton4 = new ToolStripButton();
            ToolStripButton4.Click += new EventHandler(ToolStripButton4_Click);
            ToolStripSeparator10 = new ToolStripSeparator();
            NouveauToolStripButton = new ToolStripButton();
            NouveauToolStripButton.Click += new EventHandler(NouveauToolStripButton_Click);
            EnregistrerToolStripButton = new ToolStripButton();
            EnregistrerToolStripButton.Click += new EventHandler(EnregistrerToolStripButton_Click);
            ListeToolStripButton = new ToolStripButton();
            ListeToolStripButton.Click += new EventHandler(ListeToolStripButton_Click);
            ToolStripButton5 = new ToolStripButton();
            ToolStripButton5.Click += new EventHandler(ToolStripButton5_Click);
            ToolStripSeparator5 = new ToolStripSeparator();
            TreeView1 = new TreeView();
            TreeView1.Click += new EventHandler(TreeView1_Click);
            TreeView1.KeyDown += new KeyEventHandler(TreeView1_KeyDown);
            TreeView1.MouseMove += new MouseEventHandler(TreeView1_MouseMove);
            TreeView1.MouseDown += new MouseEventHandler(TreeView1_MouseDown);
            TreeView1.DrawNode += new DrawTreeNodeEventHandler(TreeView1_DrawNode);
            TreeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(TreeView1_NodeMouseClick);
            TreeView1.AfterExpand += new TreeViewEventHandler(TreeView1_AfterExpand);
            ListView1 = new ListView();
            ListView1.SelectedIndexChanged += new EventHandler(ListView1_SelectedIndexChanged);
            ListView1.DrawItem += new DrawListViewItemEventHandler(ListView1_DrawItem);
            ListView1.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(ListView1_DrawColumnHeader);
            ColumnHeader1 = new ColumnHeader();
            ImageList1 = new ImageList(components);
            ToolStrip1 = new ToolStrip();
            ToolStripComboBox1 = new ToolStripComboBox();
            ToolStripSeparator6 = new ToolStripSeparator();
            ToolStripTextBox1 = new ToolStripTextBox();
            ToolStripSeparator1 = new ToolStripSeparator();
            PnlContenuRight = new Panel();
            PictureBox4 = new PictureBox();
            PictureBox4.Click += new EventHandler(PictureBox4_Click);
            PictureBox4.MouseEnter += new EventHandler(PictureBox4_MouseEnter);
            PictureBox4.MouseLeave += new EventHandler(PictureBox4_MouseLeave);
            ListBox3 = new ListBox();
            PictureBox2 = new PictureBox();
            PictureBox2.Click += new EventHandler(PictureBox2_Click);
            PictureBox2.MouseEnter += new EventHandler(PictureBox2_MouseEnter);
            PictureBox2.MouseLeave += new EventHandler(PictureBox2_MouseLeave);
            PictureBox3 = new PictureBox();
            RichTextBox1 = new RichTextBox();
            RichTextBox1.TextChanged += new EventHandler(RichTextBox1_TextChanged);
            RichTextBox1.LinkClicked += new LinkClickedEventHandler(RichTextBox1_LinkClicked);
            RichTextBox1.MouseHover += new EventHandler(RichTextBox1_MouseHover);
            TextBox34 = new TextBox();
            TextBox28 = new TextBox();
            TextBox28.TextChanged += new EventHandler(TextBox28_TextChanged);
            Label2 = new Label();
            TextBox33 = new TextBox();
            TextBox33.TextChanged += new EventHandler(TextBox33_TextChanged);
            TextBox32 = new TextBox();
            PictureBox1 = new PictureBox();
            PictureBox1.DoubleClick += new EventHandler(PictureBox1_DoubleClick);
            PictureBox1.Click += new EventHandler(PictureBox1_Click);
            PictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(PictureBox1_LoadCompleted);
            PictureBox1.MouseHover += new EventHandler(PictureBox1_MouseHover);
            TextBox31 = new TextBox();
            TextBox31.TextChanged += new EventHandler(TextBox31_TextChanged);
            TextBox31.KeyUp += new KeyEventHandler(TextBox31_KeyUp);
            TextBox30 = new TextBox();
            TextBox29 = new TextBox();
            TextBox29.TextChanged += new EventHandler(TextBox29_TextChanged);
            TextBox27 = new TextBox();
            TextBox26 = new TextBox();
            TextBox26.TextChanged += new EventHandler(TextBox26_TextChanged);
            TextBox25 = new TextBox();
            TextBox25.TextChanged += new EventHandler(TextBox25_TextChanged);
            TextBox24 = new TextBox();
            TextBox24.TextChanged += new EventHandler(TextBox24_TextChanged);
            TextBox23 = new TextBox();
            TextBox23.TextChanged += new EventHandler(TextBox23_TextChanged);
            ComboBox2 = new ComboBox();
            ComboBox2.SelectedIndexChanged += new EventHandler(ComboBox2_SelectedIndexChanged);
            ComboBox2.DrawItem += new DrawItemEventHandler(ComboBox2_DrawItem);
            ComboBox2.DropDownClosed += new EventHandler(ComboBox2_DropDownClosed);
            TextBox22 = new TextBox();
            TextBox21 = new TextBox();
            TextBox20 = new TextBox();
            TextBox19 = new TextBox();
            TextBox18 = new TextBox();
            TextBox18.TextChanged += new EventHandler(TextBox18_TextChanged);
            TextBox17 = new TextBox();
            TextBox15 = new TextBox();
            TextBox15.TextChanged += new EventHandler(TextBox15_TextChanged);
            TextBox14 = new TextBox();
            DateTimePicker1 = new DateTimePicker();
            DateTimePicker1.ValueChanged += new EventHandler(DateTimePicker1_ValueChanged);
            TextBox13 = new TextBox();
            TextBox13.TextChanged += new EventHandler(TextBox13_TextChanged);
            TextBox12 = new TextBox();
            TextBox11 = new TextBox();
            TextBox10 = new TextBox();
            Label1 = new Label();
            ComboBox1 = new ComboBox();
            ComboBox1.SelectedIndexChanged += new EventHandler(ComboBox1_SelectedIndexChanged);
            TextBox8 = new TextBox();
            TextBox9 = new TextBox();
            TextBox9.TextChanged += new EventHandler(TextBox9_TextChanged);
            TextBox6 = new TextBox();
            TextBox7 = new TextBox();
            TextBox7.TextChanged += new EventHandler(TextBox7_TextChanged);
            TextBox3 = new TextBox();
            TextBox5 = new TextBox();
            TextBox5.LostFocus += new EventHandler(TextBox5_LostFocus);
            TextBox5.TextChanged += new EventHandler(TextBox5_TextChanged);
            TextBox4 = new TextBox();
            TextBox4.TextChanged += new EventHandler(TextBox4_TextChanged);
            TextBox2 = new TextBox();
            TextBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
            TextBox1 = new TextBox();
            TextBox1.TextChanged += new EventHandler(TextBox1_TextChanged);
            TextBox16 = new TextBox();
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            ListBox2 = new ListBox();
            DonnéesToolStripMenuItem1 = new ToolStripMenuItem();
            NouvelleficheToolStripMenuItem = new ToolStripMenuItem();
            NouvelleficheToolStripMenuItem.Click += new EventHandler(NouvelleficheToolStripMenuItem_Click);
            ModifierToolStripMenuItem1 = new ToolStripMenuItem();
            ModifierToolStripMenuItem1.Click += new EventHandler(ModifierToolStripMenuItem1_Click);
            ListeToolStripMenuItem = new ToolStripMenuItem();
            ListeToolStripMenuItem.Click += new EventHandler(ListeToolStripMenuItem_Click);
            EnregistrerToolStripMenuItem = new ToolStripMenuItem();
            EnregistrerToolStripMenuItem.Click += new EventHandler(EnregistrerToolStripMenuItem_Click);
            SupprimerToolStripMenuItem = new ToolStripMenuItem();
            SupprimerToolStripMenuItem.Click += new EventHandler(SupprimerToolStripMenuItem_Click);
            toolStripSeparator2 = new ToolStripSeparator();
            ToolStripMenuItem2 = new ToolStripMenuItem();
            ToolStripMenuItem2.Click += new EventHandler(ToolStripMenuItem2_Click);
            ToolStripSeparator3 = new ToolStripSeparator();
            QuitterToolStripMenuItem = new ToolStripMenuItem();
            QuitterToolStripMenuItem.Click += new EventHandler(QuitterToolStripMenuItem_Click);
            FichiersToolStripMenuItem = new ToolStripMenuItem();
            CréerunfichierToolStripMenuItem = new ToolStripMenuItem();
            CréerunfichierToolStripMenuItem.Click += new EventHandler(CréerunfichierToolStripMenuItem_Click);
            AjouterToolStripMenuItem = new ToolStripMenuItem();
            AjouterToolStripMenuItem.Click += new EventHandler(AjouterToolStripMenuItem_Click);
            SupprToolStripMenuItem = new ToolStripMenuItem();
            SupprToolStripMenuItem.Click += new EventHandler(SupprToolStripMenuItem_Click);
            toolStripSeparator4 = new ToolStripSeparator();
            GenererunfichierxmlToolStripMenuItem = new ToolStripMenuItem();
            GenererunfichierxmlToolStripMenuItem.Click += new EventHandler(GenererunfichierxmlToolStripMenuItem_Click);
            LireunfichierxmlToolStripMenuItem = new ToolStripMenuItem();
            LireunfichierxmlToolStripMenuItem.Click += new EventHandler(LireunfichierxmlToolStripMenuItem_Click);
            ToolStripSeparator15 = new ToolStripSeparator();
            RechercherdanslesfichiersToolStripMenuItem = new ToolStripMenuItem();
            RechercherdanslesfichiersToolStripMenuItem.Click += new EventHandler(RechercherdanslesfichiersToolStripMenuItem_Click);
            ProcessusdetraitementdesdonnéesToolStripMenuItem = new ToolStripMenuItem();
            ToolStripSeparator19 = new ToolStripSeparator();
            CreerundocumentjsonToolStripMenuItem = new ToolStripMenuItem();
            CreerundocumentjsonToolStripMenuItem.Click += new EventHandler(CreerundocumentjsonToolStripMenuItem_Click);
            LireundocumentjsonToolStripMenuItem = new ToolStripMenuItem();
            LireundocumentjsonToolStripMenuItem.Click += new EventHandler(LireundocumentjsonToolStripMenuItem_Click);
            OutilsToolStripMenuItem = new ToolStripMenuItem();
            ImporterlibrairiesToolStripMenuItem = new ToolStripMenuItem();
            ImporterlibrairiesToolStripMenuItem.Click += new EventHandler(ImporterlibrairiesToolStripMenuItem_Click);
            ToolStripMenuItem7 = new ToolStripMenuItem();
            ToolStripMenuItem7.Click += new EventHandler(ToolStripMenuItem7_Click);
            ToolStripMenuItem6 = new ToolStripMenuItem();
            ToolStripMenuItem6.Click += new EventHandler(ToolStripMenuItem6_Click);
            GenererunfichierdocxToolStripMenuItem = new ToolStripMenuItem();
            GenererunfichierdocxToolStripMenuItem.Click += new EventHandler(GenererunfichierdocxToolStripMenuItem_Click);
            ToolStripSeparator12 = new ToolStripSeparator();
            CréerundocumentauformatooxmlfToolStripMenuItem = new ToolStripMenuItem();
            CréerundocumentauformatooxmlfToolStripMenuItem.Click += new EventHandler(CréerundocumentauformatooxmlToolStripMenuItem_Click);
            CréerunfichierhtmlToolStripMenuItem = new ToolStripMenuItem();
            CréerunfichierhtmlToolStripMenuItem.Click += new EventHandler(CréerunfichierhtmlToolStripMenuItem_Click);
            CréerundocumentauformatPDFToolStripMenuItem = new ToolStripMenuItem();
            CréerundocumentauformatPDFToolStripMenuItem.Click += new EventHandler(CréerundocumentauformatPDFToolStripMenuItem_Click);
            AideToolStripMenuItem = new ToolStripMenuItem();
            ÀproposdeToolStripMenuItem = new ToolStripMenuItem();
            ÀproposdeToolStripMenuItem.Click += new EventHandler(ÀproposdeToolStripMenuItem_Click);
            ToolStripSeparator7 = new ToolStripSeparator();
            AfficherLaideToolStripMenuItem = new ToolStripMenuItem();
            AfficherLaideToolStripMenuItem.Click += new EventHandler(AfficherLaideToolStripMenuItem_Click);
            RechercherlesmisesajourToolStripMenuItem = new ToolStripMenuItem();
            RechercherlesmisesajourToolStripMenuItem.Click += new EventHandler(RechercherlesmisesajourToolStripMenuItem_Click);
            NousContacterToolStripMenuItem = new ToolStripMenuItem();
            NousContacterToolStripMenuItem.Click += new EventHandler(NousContacterToolStripMenuItem_Click);
            MenuStrip1 = new MenuStrip();
            EditionToolStripMenuItem = new ToolStripMenuItem();
            AnnulerToolStripMenuItem = new ToolStripMenuItem();
            AnnulerToolStripMenuItem.Click += new EventHandler(AnnulerToolStripMenuItem_Click);
            RétablirToolStripMenuItem = new ToolStripMenuItem();
            RétablirToolStripMenuItem.Click += new EventHandler(RétablirToolStripMenuItem_Click);
            ToolStripSeparator17 = new ToolStripSeparator();
            CouperToolStripMenuItem = new ToolStripMenuItem();
            CouperToolStripMenuItem.Click += new EventHandler(CouperToolStripMenuItem_Click);
            CopierToolStripMenuItem = new ToolStripMenuItem();
            CopierToolStripMenuItem.Click += new EventHandler(CopierToolStripMenuItem_Click);
            CollerToolStripMenuItem = new ToolStripMenuItem();
            CollerToolStripMenuItem.Click += new EventHandler(CollerToolStripMenuItem_Click);
            ToolStripSeparator18 = new ToolStripSeparator();
            SélectionnerToutToolStripMenuItem = new ToolStripMenuItem();
            SélectionnerToutToolStripMenuItem.Click += new EventHandler(SélectionnerToutToolStripMenuItem_Click);
            ImageList2 = new ImageList(components);
            Timer1 = new Timer(components);
            Timer1.Tick += new EventHandler(Timer1_Tick);
            OpenFileDialog1 = new OpenFileDialog();
            NotifyIcon1 = new NotifyIcon(components);
            ContextMenuStrip1 = new ContextMenuStrip(components);
            ToolStripMenuItem3 = new ToolStripMenuItem();
            ToolStripMenuItem3.Click += new EventHandler(ToolStripMenuItem3_Click);
            ToolStripSeparator8 = new ToolStripSeparator();
            ToolStripMenuItem4 = new ToolStripMenuItem();
            ToolStripMenuItem4.Click += new EventHandler(ToolStripMenuItem4_Click);
            ToolStripMenuItem5 = new ToolStripMenuItem();
            ToolStripMenuItem5.Click += new EventHandler(ToolStripMenuItem5_Click);
            HelpProvider1 = new HelpProvider();
            ListBox1 = new ListBox();
            SaveFileDialog1 = new SaveFileDialog();
            PrintDialog1 = new PrintDialog();
            DataSet1 = new DataSet();
            ToolTip1 = new ToolTip(components);
            StatusStrip1.SuspendLayout();
            PnlContenuLeft.SuspendLayout();
            ToolStrip3.SuspendLayout();
            ToolStrip1.SuspendLayout();
            PnlContenuRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            MenuStrip1.SuspendLayout();
            ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataSet1).BeginInit();
            SuspendLayout();
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripProgressBar1, ToolStripStatusLabel1, ToolStripStatusLabel2, ToolStripStatusLabel3, ToolStripStatusLabel4, ToolStripStatusLabel5, ToolStripStatusLabel6 });
            resources.ApplyResources(StatusStrip1, "StatusStrip1");
            StatusStrip1.Name = "StatusStrip1";
            HelpProvider1.SetShowHelp(StatusStrip1, Conversions.ToBoolean(resources.GetObject("StatusStrip1.ShowHelp")));
            StatusStrip1.ShowItemToolTips = true;
            // 
            // ToolStripProgressBar1
            // 
            ToolStripProgressBar1.Name = "ToolStripProgressBar1";
            resources.ApplyResources(ToolStripProgressBar1, "ToolStripProgressBar1");
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Image = My.Resources.Resources.FolderOpened_16x_1;
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            resources.ApplyResources(ToolStripStatusLabel1, "ToolStripStatusLabel1");
            // 
            // ToolStripStatusLabel2
            // 
            ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            resources.ApplyResources(ToolStripStatusLabel2, "ToolStripStatusLabel2");
            // 
            // ToolStripStatusLabel3
            // 
            ToolStripStatusLabel3.Image = My.Resources.Resources.DocumentError_16x;
            ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            resources.ApplyResources(ToolStripStatusLabel3, "ToolStripStatusLabel3");
            ToolStripStatusLabel3.Tag = "";
            // 
            // ToolStripStatusLabel4
            // 
            ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
            resources.ApplyResources(ToolStripStatusLabel4, "ToolStripStatusLabel4");
            // 
            // ToolStripStatusLabel5
            // 
            ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            resources.ApplyResources(ToolStripStatusLabel5, "ToolStripStatusLabel5");
            // 
            // ToolStripStatusLabel6
            // 
            ToolStripStatusLabel6.AutoToolTip = true;
            ToolStripStatusLabel6.Name = "ToolStripStatusLabel6";
            resources.ApplyResources(ToolStripStatusLabel6, "ToolStripStatusLabel6");
            // 
            // PnlContenuLeft
            // 
            PnlContenuLeft.Controls.Add(ToolStrip3);
            PnlContenuLeft.Controls.Add(TreeView1);
            PnlContenuLeft.Controls.Add(ListView1);
            PnlContenuLeft.Controls.Add(ToolStrip1);
            resources.ApplyResources(PnlContenuLeft, "PnlContenuLeft");
            PnlContenuLeft.Name = "PnlContenuLeft";
            HelpProvider1.SetShowHelp(PnlContenuLeft, Conversions.ToBoolean(resources.GetObject("PnlContenuLeft.ShowHelp")));
            // 
            // ToolStrip3
            // 
            ToolStrip3.ImageScalingSize = new Size(32, 32);
            ToolStrip3.Items.AddRange(new ToolStripItem[] { ToolStripButton1, ToolStripButton2, ToolStripSeparator9, ToolStripButton3, ToolStripButton4, ToolStripSeparator10, NouveauToolStripButton, EnregistrerToolStripButton, ListeToolStripButton, ToolStripButton5, ToolStripSeparator5 });
            resources.ApplyResources(ToolStrip3, "ToolStrip3");
            ToolStrip3.Name = "ToolStrip3";
            HelpProvider1.SetShowHelp(ToolStrip3, Conversions.ToBoolean(resources.GetObject("ToolStrip3.ShowHelp")));
            // 
            // ToolStripButton1
            // 
            ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(ToolStripButton1, "ToolStripButton1");
            ToolStripButton1.Name = "ToolStripButton1";
            // 
            // ToolStripButton2
            // 
            ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(ToolStripButton2, "ToolStripButton2");
            ToolStripButton2.Name = "ToolStripButton2";
            // 
            // ToolStripSeparator9
            // 
            ToolStripSeparator9.Name = "ToolStripSeparator9";
            resources.ApplyResources(ToolStripSeparator9, "ToolStripSeparator9");
            // 
            // ToolStripButton3
            // 
            ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(ToolStripButton3, "ToolStripButton3");
            ToolStripButton3.Name = "ToolStripButton3";
            // 
            // ToolStripButton4
            // 
            ToolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(ToolStripButton4, "ToolStripButton4");
            ToolStripButton4.Name = "ToolStripButton4";
            // 
            // ToolStripSeparator10
            // 
            ToolStripSeparator10.Name = "ToolStripSeparator10";
            resources.ApplyResources(ToolStripSeparator10, "ToolStripSeparator10");
            // 
            // NouveauToolStripButton
            // 
            NouveauToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(NouveauToolStripButton, "NouveauToolStripButton");
            NouveauToolStripButton.Name = "NouveauToolStripButton";
            // 
            // EnregistrerToolStripButton
            // 
            EnregistrerToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(EnregistrerToolStripButton, "EnregistrerToolStripButton");
            EnregistrerToolStripButton.Name = "EnregistrerToolStripButton";
            // 
            // ListeToolStripButton
            // 
            ListeToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(ListeToolStripButton, "ListeToolStripButton");
            ListeToolStripButton.Name = "ListeToolStripButton";
            // 
            // ToolStripButton5
            // 
            ToolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ToolStripButton5.Image = My.Resources.Resources.EditDocument_16x;
            resources.ApplyResources(ToolStripButton5, "ToolStripButton5");
            ToolStripButton5.Name = "ToolStripButton5";
            // 
            // ToolStripSeparator5
            // 
            ToolStripSeparator5.Name = "ToolStripSeparator5";
            resources.ApplyResources(ToolStripSeparator5, "ToolStripSeparator5");
            // 
            // TreeView1
            // 
            TreeView1.BorderStyle = BorderStyle.None;
            TreeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            resources.ApplyResources(TreeView1, "TreeView1");
            TreeView1.Name = "TreeView1";
            TreeView1.Nodes.AddRange(new TreeNode[] { (TreeNode)resources.GetObject("TreeView1.Nodes") });
            HelpProvider1.SetShowHelp(TreeView1, Conversions.ToBoolean(resources.GetObject("TreeView1.ShowHelp")));
            TreeView1.ShowNodeToolTips = true;
            // 
            // ListView1
            // 
            ListView1.BackColor = SystemColors.Window;
            ListView1.BorderStyle = BorderStyle.None;
            ListView1.Columns.AddRange(new ColumnHeader[] { ColumnHeader1 });
            resources.ApplyResources(ListView1, "ListView1");
            ListView1.FullRowSelect = true;
            ListView1.HideSelection = false;
            ListView1.LargeImageList = ImageList1;
            ListView1.MultiSelect = false;
            ListView1.Name = "ListView1";
            ListView1.OwnerDraw = true;
            HelpProvider1.SetShowHelp(ListView1, Conversions.ToBoolean(resources.GetObject("ListView1.ShowHelp")));
            ListView1.ShowItemToolTips = true;
            ListView1.SmallImageList = ImageList1;
            ListView1.Sorting = SortOrder.Ascending;
            ListView1.StateImageList = ImageList1;
            ListView1.UseCompatibleStateImageBehavior = false;
            ListView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            resources.ApplyResources(ColumnHeader1, "ColumnHeader1");
            // 
            // ImageList1
            // 
            ImageList1.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(ImageList1, "ImageList1");
            ImageList1.TransparentColor = Color.Transparent;
            // 
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { ToolStripComboBox1, ToolStripSeparator6, ToolStripTextBox1, ToolStripSeparator1 });
            resources.ApplyResources(ToolStrip1, "ToolStrip1");
            ToolStrip1.Name = "ToolStrip1";
            HelpProvider1.SetShowHelp(ToolStrip1, Conversions.ToBoolean(resources.GetObject("ToolStrip1.ShowHelp")));
            // 
            // ToolStripComboBox1
            // 
            ToolStripComboBox1.Name = "ToolStripComboBox1";
            resources.ApplyResources(ToolStripComboBox1, "ToolStripComboBox1");
            ToolStripComboBox1.Sorted = true;
            // 
            // ToolStripSeparator6
            // 
            ToolStripSeparator6.Name = "ToolStripSeparator6";
            resources.ApplyResources(ToolStripSeparator6, "ToolStripSeparator6");
            // 
            // ToolStripTextBox1
            // 
            ToolStripTextBox1.BackColor = SystemColors.Window;
            resources.ApplyResources(ToolStripTextBox1, "ToolStripTextBox1");
            ToolStripTextBox1.Name = "ToolStripTextBox1";
            ToolStripTextBox1.ReadOnly = true;
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            resources.ApplyResources(ToolStripSeparator1, "ToolStripSeparator1");
            // 
            // PnlContenuRight
            // 
            PnlContenuRight.BackColor = SystemColors.Control;
            PnlContenuRight.Controls.Add(PictureBox4);
            PnlContenuRight.Controls.Add(ListBox3);
            PnlContenuRight.Controls.Add(PictureBox2);
            PnlContenuRight.Controls.Add(PictureBox3);
            PnlContenuRight.Controls.Add(RichTextBox1);
            PnlContenuRight.Controls.Add(TextBox34);
            PnlContenuRight.Controls.Add(TextBox28);
            PnlContenuRight.Controls.Add(Label2);
            PnlContenuRight.Controls.Add(TextBox33);
            PnlContenuRight.Controls.Add(TextBox32);
            PnlContenuRight.Controls.Add(PictureBox1);
            PnlContenuRight.Controls.Add(TextBox31);
            PnlContenuRight.Controls.Add(TextBox30);
            PnlContenuRight.Controls.Add(TextBox29);
            PnlContenuRight.Controls.Add(TextBox27);
            PnlContenuRight.Controls.Add(TextBox26);
            PnlContenuRight.Controls.Add(TextBox25);
            PnlContenuRight.Controls.Add(TextBox24);
            PnlContenuRight.Controls.Add(TextBox23);
            PnlContenuRight.Controls.Add(ComboBox2);
            PnlContenuRight.Controls.Add(TextBox22);
            PnlContenuRight.Controls.Add(TextBox21);
            PnlContenuRight.Controls.Add(TextBox20);
            PnlContenuRight.Controls.Add(TextBox19);
            PnlContenuRight.Controls.Add(TextBox18);
            PnlContenuRight.Controls.Add(TextBox17);
            PnlContenuRight.Controls.Add(TextBox15);
            PnlContenuRight.Controls.Add(TextBox14);
            PnlContenuRight.Controls.Add(DateTimePicker1);
            PnlContenuRight.Controls.Add(TextBox13);
            PnlContenuRight.Controls.Add(TextBox12);
            PnlContenuRight.Controls.Add(TextBox11);
            PnlContenuRight.Controls.Add(TextBox10);
            PnlContenuRight.Controls.Add(Label1);
            PnlContenuRight.Controls.Add(ComboBox1);
            PnlContenuRight.Controls.Add(TextBox8);
            PnlContenuRight.Controls.Add(TextBox9);
            PnlContenuRight.Controls.Add(TextBox6);
            PnlContenuRight.Controls.Add(TextBox7);
            PnlContenuRight.Controls.Add(TextBox3);
            PnlContenuRight.Controls.Add(TextBox5);
            PnlContenuRight.Controls.Add(TextBox4);
            PnlContenuRight.Controls.Add(TextBox2);
            PnlContenuRight.Controls.Add(TextBox1);
            resources.ApplyResources(PnlContenuRight, "PnlContenuRight");
            PnlContenuRight.Name = "PnlContenuRight";
            HelpProvider1.SetShowHelp(PnlContenuRight, Conversions.ToBoolean(resources.GetObject("PnlContenuRight.ShowHelp")));
            // 
            // PictureBox4
            // 
            resources.ApplyResources(PictureBox4, "PictureBox4");
            PictureBox4.Name = "PictureBox4";
            PictureBox4.TabStop = false;
            // 
            // ListBox3
            // 
            ListBox3.FormattingEnabled = true;
            resources.ApplyResources(ListBox3, "ListBox3");
            ListBox3.Name = "ListBox3";
            // 
            // PictureBox2
            // 
            resources.ApplyResources(PictureBox2, "PictureBox2");
            PictureBox2.Name = "PictureBox2";
            HelpProvider1.SetShowHelp(PictureBox2, Conversions.ToBoolean(resources.GetObject("PictureBox2.ShowHelp")));
            PictureBox2.TabStop = false;
            // 
            // PictureBox3
            // 
            resources.ApplyResources(PictureBox3, "PictureBox3");
            PictureBox3.Name = "PictureBox3";
            PictureBox3.TabStop = false;
            // 
            // RichTextBox1
            // 
            RichTextBox1.AutoWordSelection = true;
            RichTextBox1.BackColor = SystemColors.Control;
            RichTextBox1.BorderStyle = BorderStyle.None;
            resources.ApplyResources(RichTextBox1, "RichTextBox1");
            RichTextBox1.Name = "RichTextBox1";
            // 
            // TextBox34
            // 
            TextBox34.BackColor = SystemColors.Window;
            TextBox34.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox34, "TextBox34");
            TextBox34.Name = "TextBox34";
            TextBox34.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox34, Conversions.ToBoolean(resources.GetObject("TextBox34.ShowHelp")));
            // 
            // TextBox28
            // 
            TextBox28.BackColor = SystemColors.Control;
            TextBox28.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox28, "TextBox28");
            TextBox28.HideSelection = false;
            TextBox28.Name = "TextBox28";
            TextBox28.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox28, Conversions.ToBoolean(resources.GetObject("TextBox28.ShowHelp")));
            // 
            // Label2
            // 
            resources.ApplyResources(Label2, "Label2");
            Label2.Name = "Label2";
            HelpProvider1.SetShowHelp(Label2, Conversions.ToBoolean(resources.GetObject("Label2.ShowHelp")));
            // 
            // TextBox33
            // 
            TextBox33.BackColor = SystemColors.Control;
            TextBox33.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox33, "TextBox33");
            TextBox33.HideSelection = false;
            TextBox33.Name = "TextBox33";
            HelpProvider1.SetShowHelp(TextBox33, Conversions.ToBoolean(resources.GetObject("TextBox33.ShowHelp")));
            // 
            // TextBox32
            // 
            TextBox32.BackColor = SystemColors.Window;
            TextBox32.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox32, "TextBox32");
            TextBox32.Name = "TextBox32";
            TextBox32.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox32, Conversions.ToBoolean(resources.GetObject("TextBox32.ShowHelp")));
            // 
            // PictureBox1
            // 
            PictureBox1.BackColor = SystemColors.Window;
            PictureBox1.Image = My.Resources.Resources.Image_16x_1;
            resources.ApplyResources(PictureBox1, "PictureBox1");
            PictureBox1.Name = "PictureBox1";
            HelpProvider1.SetShowHelp(PictureBox1, Conversions.ToBoolean(resources.GetObject("PictureBox1.ShowHelp")));
            PictureBox1.TabStop = false;
            // 
            // TextBox31
            // 
            TextBox31.BackColor = SystemColors.Control;
            TextBox31.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox31, "TextBox31");
            TextBox31.HideSelection = false;
            TextBox31.Name = "TextBox31";
            HelpProvider1.SetShowHelp(TextBox31, Conversions.ToBoolean(resources.GetObject("TextBox31.ShowHelp")));
            // 
            // TextBox30
            // 
            TextBox30.BackColor = SystemColors.Window;
            TextBox30.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox30, "TextBox30");
            TextBox30.Name = "TextBox30";
            TextBox30.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox30, Conversions.ToBoolean(resources.GetObject("TextBox30.ShowHelp")));
            // 
            // TextBox29
            // 
            TextBox29.BackColor = SystemColors.Control;
            TextBox29.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox29, "TextBox29");
            TextBox29.HideSelection = false;
            TextBox29.Name = "TextBox29";
            HelpProvider1.SetShowHelp(TextBox29, Conversions.ToBoolean(resources.GetObject("TextBox29.ShowHelp")));
            // 
            // TextBox27
            // 
            TextBox27.BackColor = SystemColors.Window;
            TextBox27.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox27, "TextBox27");
            TextBox27.Name = "TextBox27";
            TextBox27.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox27, Conversions.ToBoolean(resources.GetObject("TextBox27.ShowHelp")));
            // 
            // TextBox26
            // 
            TextBox26.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("TextBox26.AutoCompleteCustomSource"), resources.GetString("TextBox26.AutoCompleteCustomSource1"), resources.GetString("TextBox26.AutoCompleteCustomSource2"), resources.GetString("TextBox26.AutoCompleteCustomSource3"), resources.GetString("TextBox26.AutoCompleteCustomSource4") });
            TextBox26.AutoCompleteMode = AutoCompleteMode.Suggest;
            TextBox26.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextBox26.BackColor = SystemColors.Control;
            TextBox26.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox26, "TextBox26");
            TextBox26.HideSelection = false;
            TextBox26.Name = "TextBox26";
            HelpProvider1.SetShowHelp(TextBox26, Conversions.ToBoolean(resources.GetObject("TextBox26.ShowHelp")));
            // 
            // TextBox25
            // 
            TextBox25.BackColor = SystemColors.Control;
            TextBox25.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox25, "TextBox25");
            TextBox25.HideSelection = false;
            TextBox25.Name = "TextBox25";
            HelpProvider1.SetShowHelp(TextBox25, Conversions.ToBoolean(resources.GetObject("TextBox25.ShowHelp")));
            // 
            // TextBox24
            // 
            TextBox24.BackColor = SystemColors.Control;
            TextBox24.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox24, "TextBox24");
            TextBox24.HideSelection = false;
            TextBox24.Name = "TextBox24";
            HelpProvider1.SetShowHelp(TextBox24, Conversions.ToBoolean(resources.GetObject("TextBox24.ShowHelp")));
            // 
            // TextBox23
            // 
            TextBox23.BackColor = SystemColors.Control;
            TextBox23.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox23, "TextBox23");
            TextBox23.HideSelection = false;
            TextBox23.Name = "TextBox23";
            HelpProvider1.SetShowHelp(TextBox23, Conversions.ToBoolean(resources.GetObject("TextBox23.ShowHelp")));
            // 
            // ComboBox2
            // 
            ComboBox2.FormattingEnabled = true;
            resources.ApplyResources(ComboBox2, "ComboBox2");
            ComboBox2.Name = "ComboBox2";
            HelpProvider1.SetShowHelp(ComboBox2, Conversions.ToBoolean(resources.GetObject("ComboBox2.ShowHelp")));
            ComboBox2.Sorted = true;
            // 
            // TextBox22
            // 
            TextBox22.BackColor = SystemColors.Window;
            TextBox22.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox22, "TextBox22");
            TextBox22.Name = "TextBox22";
            TextBox22.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox22, Conversions.ToBoolean(resources.GetObject("TextBox22.ShowHelp")));
            // 
            // TextBox21
            // 
            TextBox21.BackColor = SystemColors.Window;
            TextBox21.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox21, "TextBox21");
            TextBox21.Name = "TextBox21";
            TextBox21.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox21, Conversions.ToBoolean(resources.GetObject("TextBox21.ShowHelp")));
            // 
            // TextBox20
            // 
            TextBox20.BackColor = SystemColors.Window;
            TextBox20.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox20, "TextBox20");
            TextBox20.Name = "TextBox20";
            TextBox20.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox20, Conversions.ToBoolean(resources.GetObject("TextBox20.ShowHelp")));
            // 
            // TextBox19
            // 
            TextBox19.BackColor = SystemColors.Window;
            TextBox19.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox19, "TextBox19");
            TextBox19.Name = "TextBox19";
            TextBox19.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox19, Conversions.ToBoolean(resources.GetObject("TextBox19.ShowHelp")));
            // 
            // TextBox18
            // 
            TextBox18.BackColor = SystemColors.Control;
            TextBox18.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox18, "TextBox18");
            TextBox18.HideSelection = false;
            TextBox18.Name = "TextBox18";
            HelpProvider1.SetShowHelp(TextBox18, Conversions.ToBoolean(resources.GetObject("TextBox18.ShowHelp")));
            // 
            // TextBox17
            // 
            TextBox17.BackColor = SystemColors.Window;
            TextBox17.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox17, "TextBox17");
            TextBox17.Name = "TextBox17";
            TextBox17.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox17, Conversions.ToBoolean(resources.GetObject("TextBox17.ShowHelp")));
            // 
            // TextBox15
            // 
            TextBox15.BackColor = SystemColors.Control;
            TextBox15.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox15, "TextBox15");
            TextBox15.HideSelection = false;
            TextBox15.Name = "TextBox15";
            HelpProvider1.SetShowHelp(TextBox15, Conversions.ToBoolean(resources.GetObject("TextBox15.ShowHelp")));
            // 
            // TextBox14
            // 
            TextBox14.BackColor = SystemColors.Window;
            TextBox14.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox14, "TextBox14");
            TextBox14.Name = "TextBox14";
            TextBox14.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox14, Conversions.ToBoolean(resources.GetObject("TextBox14.ShowHelp")));
            // 
            // DateTimePicker1
            // 
            resources.ApplyResources(DateTimePicker1, "DateTimePicker1");
            DateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTimePicker1.Name = "DateTimePicker1";
            HelpProvider1.SetShowHelp(DateTimePicker1, Conversions.ToBoolean(resources.GetObject("DateTimePicker1.ShowHelp")));
            DateTimePicker1.Value = new DateTime(2020, 10, 12, 12, 44, 53, 0);
            // 
            // TextBox13
            // 
            TextBox13.BackColor = SystemColors.Control;
            TextBox13.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox13, "TextBox13");
            TextBox13.HideSelection = false;
            TextBox13.Name = "TextBox13";
            HelpProvider1.SetShowHelp(TextBox13, Conversions.ToBoolean(resources.GetObject("TextBox13.ShowHelp")));
            // 
            // TextBox12
            // 
            TextBox12.BackColor = SystemColors.Window;
            TextBox12.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox12, "TextBox12");
            TextBox12.Name = "TextBox12";
            TextBox12.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox12, Conversions.ToBoolean(resources.GetObject("TextBox12.ShowHelp")));
            // 
            // TextBox11
            // 
            TextBox11.BackColor = SystemColors.Window;
            TextBox11.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox11, "TextBox11");
            TextBox11.Name = "TextBox11";
            TextBox11.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox11, Conversions.ToBoolean(resources.GetObject("TextBox11.ShowHelp")));
            // 
            // TextBox10
            // 
            TextBox10.BackColor = SystemColors.Window;
            TextBox10.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox10, "TextBox10");
            TextBox10.ForeColor = Color.Green;
            TextBox10.Name = "TextBox10";
            TextBox10.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox10, Conversions.ToBoolean(resources.GetObject("TextBox10.ShowHelp")));
            // 
            // Label1
            // 
            resources.ApplyResources(Label1, "Label1");
            Label1.Name = "Label1";
            HelpProvider1.SetShowHelp(Label1, Conversions.ToBoolean(resources.GetObject("Label1.ShowHelp")));
            // 
            // ComboBox1
            // 
            resources.ApplyResources(ComboBox1, "ComboBox1");
            ComboBox1.FormattingEnabled = true;
            ComboBox1.Name = "ComboBox1";
            HelpProvider1.SetShowHelp(ComboBox1, Conversions.ToBoolean(resources.GetObject("ComboBox1.ShowHelp")));
            ComboBox1.Sorted = true;
            // 
            // TextBox8
            // 
            TextBox8.BackColor = SystemColors.Window;
            TextBox8.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox8, "TextBox8");
            TextBox8.ForeColor = SystemColors.MenuHighlight;
            TextBox8.Name = "TextBox8";
            TextBox8.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox8, Conversions.ToBoolean(resources.GetObject("TextBox8.ShowHelp")));
            // 
            // TextBox9
            // 
            TextBox9.BackColor = SystemColors.Control;
            TextBox9.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox9, "TextBox9");
            TextBox9.HideSelection = false;
            TextBox9.Name = "TextBox9";
            HelpProvider1.SetShowHelp(TextBox9, Conversions.ToBoolean(resources.GetObject("TextBox9.ShowHelp")));
            // 
            // TextBox6
            // 
            TextBox6.BackColor = SystemColors.Window;
            TextBox6.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox6, "TextBox6");
            TextBox6.Name = "TextBox6";
            TextBox6.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox6, Conversions.ToBoolean(resources.GetObject("TextBox6.ShowHelp")));
            // 
            // TextBox7
            // 
            TextBox7.BackColor = SystemColors.Control;
            TextBox7.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox7, "TextBox7");
            TextBox7.HideSelection = false;
            TextBox7.Name = "TextBox7";
            HelpProvider1.SetShowHelp(TextBox7, Conversions.ToBoolean(resources.GetObject("TextBox7.ShowHelp")));
            // 
            // TextBox3
            // 
            TextBox3.BackColor = SystemColors.Window;
            TextBox3.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox3, "TextBox3");
            TextBox3.Name = "TextBox3";
            TextBox3.ReadOnly = true;
            HelpProvider1.SetShowHelp(TextBox3, Conversions.ToBoolean(resources.GetObject("TextBox3.ShowHelp")));
            // 
            // TextBox5
            // 
            TextBox5.BackColor = SystemColors.Control;
            TextBox5.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox5, "TextBox5");
            TextBox5.HideSelection = false;
            TextBox5.Name = "TextBox5";
            HelpProvider1.SetShowHelp(TextBox5, Conversions.ToBoolean(resources.GetObject("TextBox5.ShowHelp")));
            // 
            // TextBox4
            // 
            TextBox4.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("TextBox4.AutoCompleteCustomSource"), resources.GetString("TextBox4.AutoCompleteCustomSource1"), resources.GetString("TextBox4.AutoCompleteCustomSource2"), resources.GetString("TextBox4.AutoCompleteCustomSource3"), resources.GetString("TextBox4.AutoCompleteCustomSource4"), resources.GetString("TextBox4.AutoCompleteCustomSource5"), resources.GetString("TextBox4.AutoCompleteCustomSource6"), resources.GetString("TextBox4.AutoCompleteCustomSource7"), resources.GetString("TextBox4.AutoCompleteCustomSource8"), resources.GetString("TextBox4.AutoCompleteCustomSource9"), resources.GetString("TextBox4.AutoCompleteCustomSource10"), resources.GetString("TextBox4.AutoCompleteCustomSource11"), resources.GetString("TextBox4.AutoCompleteCustomSource12"), resources.GetString("TextBox4.AutoCompleteCustomSource13"), resources.GetString("TextBox4.AutoCompleteCustomSource14"), resources.GetString("TextBox4.AutoCompleteCustomSource15"), resources.GetString("TextBox4.AutoCompleteCustomSource16"), resources.GetString("TextBox4.AutoCompleteCustomSource17"), resources.GetString("TextBox4.AutoCompleteCustomSource18"), resources.GetString("TextBox4.AutoCompleteCustomSource19"), resources.GetString("TextBox4.AutoCompleteCustomSource20"), resources.GetString("TextBox4.AutoCompleteCustomSource21"), resources.GetString("TextBox4.AutoCompleteCustomSource22"), resources.GetString("TextBox4.AutoCompleteCustomSource23"), resources.GetString("TextBox4.AutoCompleteCustomSource24"), resources.GetString("TextBox4.AutoCompleteCustomSource25"), resources.GetString("TextBox4.AutoCompleteCustomSource26"), resources.GetString("TextBox4.AutoCompleteCustomSource27"), resources.GetString("TextBox4.AutoCompleteCustomSource28"), resources.GetString("TextBox4.AutoCompleteCustomSource29"), resources.GetString("TextBox4.AutoCompleteCustomSource30"), resources.GetString("TextBox4.AutoCompleteCustomSource31"), resources.GetString("TextBox4.AutoCompleteCustomSource32"), resources.GetString("TextBox4.AutoCompleteCustomSource33"), resources.GetString("TextBox4.AutoCompleteCustomSource34"), resources.GetString("TextBox4.AutoCompleteCustomSource35"), resources.GetString("TextBox4.AutoCompleteCustomSource36"), resources.GetString("TextBox4.AutoCompleteCustomSource37"), resources.GetString("TextBox4.AutoCompleteCustomSource38"), resources.GetString("TextBox4.AutoCompleteCustomSource39"), resources.GetString("TextBox4.AutoCompleteCustomSource40"), resources.GetString("TextBox4.AutoCompleteCustomSource41"), resources.GetString("TextBox4.AutoCompleteCustomSource42"), resources.GetString("TextBox4.AutoCompleteCustomSource43"), resources.GetString("TextBox4.AutoCompleteCustomSource44"), resources.GetString("TextBox4.AutoCompleteCustomSource45"), resources.GetString("TextBox4.AutoCompleteCustomSource46"), resources.GetString("TextBox4.AutoCompleteCustomSource47"), resources.GetString("TextBox4.AutoCompleteCustomSource48"), resources.GetString("TextBox4.AutoCompleteCustomSource49"), resources.GetString("TextBox4.AutoCompleteCustomSource50"), resources.GetString("TextBox4.AutoCompleteCustomSource51"), resources.GetString("TextBox4.AutoCompleteCustomSource52"), resources.GetString("TextBox4.AutoCompleteCustomSource53"), resources.GetString("TextBox4.AutoCompleteCustomSource54"), resources.GetString("TextBox4.AutoCompleteCustomSource55"), resources.GetString("TextBox4.AutoCompleteCustomSource56"), resources.GetString("TextBox4.AutoCompleteCustomSource57"), resources.GetString("TextBox4.AutoCompleteCustomSource58"), resources.GetString("TextBox4.AutoCompleteCustomSource59"), resources.GetString("TextBox4.AutoCompleteCustomSource60"), resources.GetString("TextBox4.AutoCompleteCustomSource61"), resources.GetString("TextBox4.AutoCompleteCustomSource62"), resources.GetString("TextBox4.AutoCompleteCustomSource63"), resources.GetString("TextBox4.AutoCompleteCustomSource64"), resources.GetString("TextBox4.AutoCompleteCustomSource65"), resources.GetString("TextBox4.AutoCompleteCustomSource66") });
            TextBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            TextBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextBox4.BackColor = SystemColors.Control;
            TextBox4.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox4, "TextBox4");
            TextBox4.HideSelection = false;
            TextBox4.Name = "TextBox4";
            HelpProvider1.SetShowHelp(TextBox4, Conversions.ToBoolean(resources.GetObject("TextBox4.ShowHelp")));
            // 
            // TextBox2
            // 
            TextBox2.BackColor = SystemColors.Window;
            TextBox2.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox2, "TextBox2");
            TextBox2.ForeColor = Color.Red;
            TextBox2.Name = "TextBox2";
            HelpProvider1.SetShowHelp(TextBox2, Conversions.ToBoolean(resources.GetObject("TextBox2.ShowHelp")));
            // 
            // TextBox1
            // 
            TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TextBox1.BackColor = SystemColors.Control;
            TextBox1.BorderStyle = BorderStyle.None;
            resources.ApplyResources(TextBox1, "TextBox1");
            TextBox1.ForeColor = SystemColors.WindowText;
            TextBox1.HideSelection = false;
            TextBox1.Name = "TextBox1";
            HelpProvider1.SetShowHelp(TextBox1, Conversions.ToBoolean(resources.GetObject("TextBox1.ShowHelp")));
            // 
            // TextBox16
            // 
            resources.ApplyResources(TextBox16, "TextBox16");
            TextBox16.Name = "TextBox16";
            HelpProvider1.SetShowHelp(TextBox16, Conversions.ToBoolean(resources.GetObject("TextBox16.ShowHelp")));
            // 
            // Button1
            // 
            resources.ApplyResources(Button1, "Button1");
            Button1.Name = "Button1";
            HelpProvider1.SetShowHelp(Button1, Conversions.ToBoolean(resources.GetObject("Button1.ShowHelp")));
            Button1.UseVisualStyleBackColor = true;
            // 
            // ListBox2
            // 
            ListBox2.BorderStyle = BorderStyle.None;
            ListBox2.FormattingEnabled = true;
            resources.ApplyResources(ListBox2, "ListBox2");
            ListBox2.Name = "ListBox2";
            HelpProvider1.SetShowHelp(ListBox2, Conversions.ToBoolean(resources.GetObject("ListBox2.ShowHelp")));
            // 
            // DonnéesToolStripMenuItem1
            // 
            DonnéesToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { NouvelleficheToolStripMenuItem, ModifierToolStripMenuItem1, ListeToolStripMenuItem, EnregistrerToolStripMenuItem, SupprimerToolStripMenuItem, toolStripSeparator2, ToolStripMenuItem2, ToolStripSeparator3, QuitterToolStripMenuItem });
            DonnéesToolStripMenuItem1.Name = "DonnéesToolStripMenuItem1";
            resources.ApplyResources(DonnéesToolStripMenuItem1, "DonnéesToolStripMenuItem1");
            // 
            // NouvelleficheToolStripMenuItem
            // 
            resources.ApplyResources(NouvelleficheToolStripMenuItem, "NouvelleficheToolStripMenuItem");
            NouvelleficheToolStripMenuItem.Name = "NouvelleficheToolStripMenuItem";
            // 
            // ModifierToolStripMenuItem1
            // 
            ModifierToolStripMenuItem1.Image = My.Resources.Resources.EditDocument_16x;
            resources.ApplyResources(ModifierToolStripMenuItem1, "ModifierToolStripMenuItem1");
            ModifierToolStripMenuItem1.Name = "ModifierToolStripMenuItem1";
            // 
            // ListeToolStripMenuItem
            // 
            resources.ApplyResources(ListeToolStripMenuItem, "ListeToolStripMenuItem");
            ListeToolStripMenuItem.Name = "ListeToolStripMenuItem";
            // 
            // EnregistrerToolStripMenuItem
            // 
            resources.ApplyResources(EnregistrerToolStripMenuItem, "EnregistrerToolStripMenuItem");
            EnregistrerToolStripMenuItem.Name = "EnregistrerToolStripMenuItem";
            // 
            // SupprimerToolStripMenuItem
            // 
            resources.ApplyResources(SupprimerToolStripMenuItem, "SupprimerToolStripMenuItem");
            SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem";
            SupprimerToolStripMenuItem.Tag = "";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Image = My.Resources.Resources.InformationSymbol_16x;
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            resources.ApplyResources(ToolStripMenuItem2, "ToolStripMenuItem2");
            // 
            // ToolStripSeparator3
            // 
            ToolStripSeparator3.Name = "ToolStripSeparator3";
            resources.ApplyResources(ToolStripSeparator3, "ToolStripSeparator3");
            // 
            // QuitterToolStripMenuItem
            // 
            QuitterToolStripMenuItem.Image = My.Resources.Resources.Exit_16x;
            QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem";
            resources.ApplyResources(QuitterToolStripMenuItem, "QuitterToolStripMenuItem");
            // 
            // FichiersToolStripMenuItem
            // 
            FichiersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CréerunfichierToolStripMenuItem, AjouterToolStripMenuItem, SupprToolStripMenuItem, toolStripSeparator4, GenererunfichierxmlToolStripMenuItem, LireunfichierxmlToolStripMenuItem, ToolStripSeparator15, RechercherdanslesfichiersToolStripMenuItem, ProcessusdetraitementdesdonnéesToolStripMenuItem, ToolStripSeparator19, CreerundocumentjsonToolStripMenuItem, LireundocumentjsonToolStripMenuItem });
            FichiersToolStripMenuItem.Name = "FichiersToolStripMenuItem";
            resources.ApplyResources(FichiersToolStripMenuItem, "FichiersToolStripMenuItem");
            // 
            // CréerunfichierToolStripMenuItem
            // 
            resources.ApplyResources(CréerunfichierToolStripMenuItem, "CréerunfichierToolStripMenuItem");
            CréerunfichierToolStripMenuItem.Name = "CréerunfichierToolStripMenuItem";
            // 
            // AjouterToolStripMenuItem
            // 
            resources.ApplyResources(AjouterToolStripMenuItem, "AjouterToolStripMenuItem");
            AjouterToolStripMenuItem.Name = "AjouterToolStripMenuItem";
            // 
            // SupprToolStripMenuItem
            // 
            resources.ApplyResources(SupprToolStripMenuItem, "SupprToolStripMenuItem");
            SupprToolStripMenuItem.Name = "SupprToolStripMenuItem";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
            // 
            // GenererunfichierxmlToolStripMenuItem
            // 
            GenererunfichierxmlToolStripMenuItem.Image = My.Resources.Resources.XMLFile_16x;
            GenererunfichierxmlToolStripMenuItem.Name = "GenererunfichierxmlToolStripMenuItem";
            resources.ApplyResources(GenererunfichierxmlToolStripMenuItem, "GenererunfichierxmlToolStripMenuItem");
            // 
            // LireunfichierxmlToolStripMenuItem
            // 
            LireunfichierxmlToolStripMenuItem.Name = "LireunfichierxmlToolStripMenuItem";
            resources.ApplyResources(LireunfichierxmlToolStripMenuItem, "LireunfichierxmlToolStripMenuItem");
            // 
            // ToolStripSeparator15
            // 
            ToolStripSeparator15.Name = "ToolStripSeparator15";
            resources.ApplyResources(ToolStripSeparator15, "ToolStripSeparator15");
            // 
            // RechercherdanslesfichiersToolStripMenuItem
            // 
            RechercherdanslesfichiersToolStripMenuItem.Name = "RechercherdanslesfichiersToolStripMenuItem";
            resources.ApplyResources(RechercherdanslesfichiersToolStripMenuItem, "RechercherdanslesfichiersToolStripMenuItem");
            // 
            // ProcessusdetraitementdesdonnéesToolStripMenuItem
            // 
            ProcessusdetraitementdesdonnéesToolStripMenuItem.Image = My.Resources.Resources.Process_16x;
            ProcessusdetraitementdesdonnéesToolStripMenuItem.Name = "ProcessusdetraitementdesdonnéesToolStripMenuItem";
            resources.ApplyResources(ProcessusdetraitementdesdonnéesToolStripMenuItem, "ProcessusdetraitementdesdonnéesToolStripMenuItem");
            // 
            // ToolStripSeparator19
            // 
            ToolStripSeparator19.Name = "ToolStripSeparator19";
            resources.ApplyResources(ToolStripSeparator19, "ToolStripSeparator19");
            // 
            // CreerundocumentjsonToolStripMenuItem
            // 
            CreerundocumentjsonToolStripMenuItem.Name = "CreerundocumentjsonToolStripMenuItem";
            resources.ApplyResources(CreerundocumentjsonToolStripMenuItem, "CreerundocumentjsonToolStripMenuItem");
            // 
            // LireundocumentjsonToolStripMenuItem
            // 
            LireundocumentjsonToolStripMenuItem.Name = "LireundocumentjsonToolStripMenuItem";
            resources.ApplyResources(LireundocumentjsonToolStripMenuItem, "LireundocumentjsonToolStripMenuItem");
            // 
            // OutilsToolStripMenuItem
            // 
            OutilsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ImporterlibrairiesToolStripMenuItem, ToolStripMenuItem7, ToolStripMenuItem6, GenererunfichierdocxToolStripMenuItem, ToolStripSeparator12, CréerundocumentauformatooxmlfToolStripMenuItem, CréerunfichierhtmlToolStripMenuItem, CréerundocumentauformatPDFToolStripMenuItem });
            OutilsToolStripMenuItem.Name = "OutilsToolStripMenuItem";
            resources.ApplyResources(OutilsToolStripMenuItem, "OutilsToolStripMenuItem");
            // 
            // ImporterlibrairiesToolStripMenuItem
            // 
            ImporterlibrairiesToolStripMenuItem.Image = My.Resources.Resources.ImportFile_16x;
            ImporterlibrairiesToolStripMenuItem.Name = "ImporterlibrairiesToolStripMenuItem";
            resources.ApplyResources(ImporterlibrairiesToolStripMenuItem, "ImporterlibrairiesToolStripMenuItem");
            // 
            // ToolStripMenuItem7
            // 
            ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            resources.ApplyResources(ToolStripMenuItem7, "ToolStripMenuItem7");
            // 
            // ToolStripMenuItem6
            // 
            ToolStripMenuItem6.Image = My.Resources.Resources.TextFile_16x;
            ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            resources.ApplyResources(ToolStripMenuItem6, "ToolStripMenuItem6");
            // 
            // GenererunfichierdocxToolStripMenuItem
            // 
            GenererunfichierdocxToolStripMenuItem.Image = My.Resources.Resources.GenerateFile_16x;
            GenererunfichierdocxToolStripMenuItem.Name = "GenererunfichierdocxToolStripMenuItem";
            resources.ApplyResources(GenererunfichierdocxToolStripMenuItem, "GenererunfichierdocxToolStripMenuItem");
            // 
            // ToolStripSeparator12
            // 
            ToolStripSeparator12.Name = "ToolStripSeparator12";
            resources.ApplyResources(ToolStripSeparator12, "ToolStripSeparator12");
            // 
            // CréerundocumentauformatooxmlfToolStripMenuItem
            // 
            CréerundocumentauformatooxmlfToolStripMenuItem.Name = "CréerundocumentauformatooxmlfToolStripMenuItem";
            resources.ApplyResources(CréerundocumentauformatooxmlfToolStripMenuItem, "CréerundocumentauformatooxmlfToolStripMenuItem");
            // 
            // CréerunfichierhtmlToolStripMenuItem
            // 
            CréerunfichierhtmlToolStripMenuItem.Image = My.Resources.Resources.HTMLFile_16x_1;
            CréerunfichierhtmlToolStripMenuItem.Name = "CréerunfichierhtmlToolStripMenuItem";
            resources.ApplyResources(CréerunfichierhtmlToolStripMenuItem, "CréerunfichierhtmlToolStripMenuItem");
            // 
            // CréerundocumentauformatPDFToolStripMenuItem
            // 
            CréerundocumentauformatPDFToolStripMenuItem.Name = "CréerundocumentauformatPDFToolStripMenuItem";
            resources.ApplyResources(CréerundocumentauformatPDFToolStripMenuItem, "CréerundocumentauformatPDFToolStripMenuItem");
            // 
            // AideToolStripMenuItem
            // 
            AideToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ÀproposdeToolStripMenuItem, ToolStripSeparator7, AfficherLaideToolStripMenuItem, RechercherlesmisesajourToolStripMenuItem, NousContacterToolStripMenuItem });
            AideToolStripMenuItem.Name = "AideToolStripMenuItem";
            resources.ApplyResources(AideToolStripMenuItem, "AideToolStripMenuItem");
            // 
            // ÀproposdeToolStripMenuItem
            // 
            ÀproposdeToolStripMenuItem.Name = "ÀproposdeToolStripMenuItem";
            resources.ApplyResources(ÀproposdeToolStripMenuItem, "ÀproposdeToolStripMenuItem");
            // 
            // ToolStripSeparator7
            // 
            ToolStripSeparator7.Name = "ToolStripSeparator7";
            resources.ApplyResources(ToolStripSeparator7, "ToolStripSeparator7");
            // 
            // AfficherLaideToolStripMenuItem
            // 
            AfficherLaideToolStripMenuItem.Image = My.Resources.Resources.MSHelpIndexFile_16x;
            AfficherLaideToolStripMenuItem.Name = "AfficherLaideToolStripMenuItem";
            resources.ApplyResources(AfficherLaideToolStripMenuItem, "AfficherLaideToolStripMenuItem");
            // 
            // RechercherlesmisesajourToolStripMenuItem
            // 
            RechercherlesmisesajourToolStripMenuItem.Image = My.Resources.Resources.RunUpdate_16x;
            RechercherlesmisesajourToolStripMenuItem.Name = "RechercherlesmisesajourToolStripMenuItem";
            resources.ApplyResources(RechercherlesmisesajourToolStripMenuItem, "RechercherlesmisesajourToolStripMenuItem");
            // 
            // NousContacterToolStripMenuItem
            // 
            NousContacterToolStripMenuItem.Name = "NousContacterToolStripMenuItem";
            resources.ApplyResources(NousContacterToolStripMenuItem, "NousContacterToolStripMenuItem");
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { DonnéesToolStripMenuItem1, EditionToolStripMenuItem, FichiersToolStripMenuItem, OutilsToolStripMenuItem, AideToolStripMenuItem });
            resources.ApplyResources(MenuStrip1, "MenuStrip1");
            MenuStrip1.Name = "MenuStrip1";
            HelpProvider1.SetShowHelp(MenuStrip1, Conversions.ToBoolean(resources.GetObject("MenuStrip1.ShowHelp")));
            // 
            // EditionToolStripMenuItem
            // 
            EditionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AnnulerToolStripMenuItem, RétablirToolStripMenuItem, ToolStripSeparator17, CouperToolStripMenuItem, CopierToolStripMenuItem, CollerToolStripMenuItem, ToolStripSeparator18, SélectionnerToutToolStripMenuItem });
            EditionToolStripMenuItem.Name = "EditionToolStripMenuItem";
            resources.ApplyResources(EditionToolStripMenuItem, "EditionToolStripMenuItem");
            // 
            // AnnulerToolStripMenuItem
            // 
            AnnulerToolStripMenuItem.Name = "AnnulerToolStripMenuItem";
            resources.ApplyResources(AnnulerToolStripMenuItem, "AnnulerToolStripMenuItem");
            // 
            // RétablirToolStripMenuItem
            // 
            RétablirToolStripMenuItem.Name = "RétablirToolStripMenuItem";
            resources.ApplyResources(RétablirToolStripMenuItem, "RétablirToolStripMenuItem");
            // 
            // ToolStripSeparator17
            // 
            ToolStripSeparator17.Name = "ToolStripSeparator17";
            resources.ApplyResources(ToolStripSeparator17, "ToolStripSeparator17");
            // 
            // CouperToolStripMenuItem
            // 
            resources.ApplyResources(CouperToolStripMenuItem, "CouperToolStripMenuItem");
            CouperToolStripMenuItem.Name = "CouperToolStripMenuItem";
            // 
            // CopierToolStripMenuItem
            // 
            resources.ApplyResources(CopierToolStripMenuItem, "CopierToolStripMenuItem");
            CopierToolStripMenuItem.Name = "CopierToolStripMenuItem";
            // 
            // CollerToolStripMenuItem
            // 
            resources.ApplyResources(CollerToolStripMenuItem, "CollerToolStripMenuItem");
            CollerToolStripMenuItem.Name = "CollerToolStripMenuItem";
            // 
            // ToolStripSeparator18
            // 
            ToolStripSeparator18.Name = "ToolStripSeparator18";
            resources.ApplyResources(ToolStripSeparator18, "ToolStripSeparator18");
            // 
            // SélectionnerToutToolStripMenuItem
            // 
            SélectionnerToutToolStripMenuItem.Name = "SélectionnerToutToolStripMenuItem";
            resources.ApplyResources(SélectionnerToutToolStripMenuItem, "SélectionnerToutToolStripMenuItem");
            // 
            // ImageList2
            // 
            ImageList2.ImageStream = (ImageListStreamer)resources.GetObject("ImageList2.ImageStream");
            ImageList2.TransparentColor = Color.Transparent;
            ImageList2.Images.SetKeyName(0, "FolderOpened_16x-1.ico");
            // 
            // Timer1
            // 
            Timer1.Enabled = true;
            Timer1.Interval = 1000;
            // 
            // OpenFileDialog1
            // 
            OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // NotifyIcon1
            // 
            NotifyIcon1.ContextMenuStrip = ContextMenuStrip1;
            resources.ApplyResources(NotifyIcon1, "NotifyIcon1");
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem3, ToolStripSeparator8, ToolStripMenuItem4, ToolStripMenuItem5 });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            HelpProvider1.SetShowHelp(ContextMenuStrip1, Conversions.ToBoolean(resources.GetObject("ContextMenuStrip1.ShowHelp")));
            resources.ApplyResources(ContextMenuStrip1, "ContextMenuStrip1");
            // 
            // ToolStripMenuItem3
            // 
            ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            resources.ApplyResources(ToolStripMenuItem3, "ToolStripMenuItem3");
            // 
            // ToolStripSeparator8
            // 
            ToolStripSeparator8.Name = "ToolStripSeparator8";
            resources.ApplyResources(ToolStripSeparator8, "ToolStripSeparator8");
            // 
            // ToolStripMenuItem4
            // 
            ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            resources.ApplyResources(ToolStripMenuItem4, "ToolStripMenuItem4");
            // 
            // ToolStripMenuItem5
            // 
            ToolStripMenuItem5.Image = My.Resources.Resources.VBLightSwitch_16x;
            ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            resources.ApplyResources(ToolStripMenuItem5, "ToolStripMenuItem5");
            // 
            // ListBox1
            // 
            ListBox1.BorderStyle = BorderStyle.None;
            ListBox1.FormattingEnabled = true;
            resources.ApplyResources(ListBox1, "ListBox1");
            ListBox1.Name = "ListBox1";
            HelpProvider1.SetShowHelp(ListBox1, Conversions.ToBoolean(resources.GetObject("ListBox1.ShowHelp")));
            // 
            // PrintDialog1
            // 
            PrintDialog1.UseEXDialog = true;
            // 
            // DataSet1
            // 
            DataSet1.DataSetName = "NewDataSet";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Button1);
            Controls.Add(TextBox16);
            Controls.Add(ListBox2);
            Controls.Add(ListBox1);
            Controls.Add(PnlContenuRight);
            Controls.Add(PnlContenuLeft);
            Controls.Add(StatusStrip1);
            Controls.Add(MenuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            KeyPreview = true;
            MainMenuStrip = MenuStrip1;
            MaximizeBox = false;
            Name = "Main";
            HelpProvider1.SetShowHelp(this, Conversions.ToBoolean(resources.GetObject("$this.ShowHelp")));
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            PnlContenuLeft.ResumeLayout(false);
            PnlContenuLeft.PerformLayout();
            ToolStrip3.ResumeLayout(false);
            ToolStrip3.PerformLayout();
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            PnlContenuRight.ResumeLayout(false);
            PnlContenuRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataSet1).EndInit();
            Load += new EventHandler(Main_Load);
            FormClosing += new FormClosingEventHandler(Main_FormClosing);
            ResumeLayout(false);
            PerformLayout();

        }

        public Main()
        {

            // Cet appel est requis par le concepteur.
            InitializeComponent();

            // Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        }
        internal StatusStrip StatusStrip1;
        internal ToolStripProgressBar ToolStripProgressBar1;
        internal Panel PnlContenuLeft;
        internal Panel PnlContenuRight;
        internal ToolStrip ToolStrip1;
        internal ToolStripComboBox ToolStripComboBox1;
        internal ToolStripSeparator ToolStripSeparator6;
        internal ToolStripMenuItem DonnéesToolStripMenuItem1;
        internal ToolStripMenuItem NouvelleficheToolStripMenuItem;
        internal ToolStripMenuItem ModifierToolStripMenuItem1;
        internal ToolStripMenuItem EnregistrerToolStripMenuItem;
        internal ToolStripMenuItem SupprimerToolStripMenuItem;
        internal ToolStripSeparator toolStripSeparator2;
        internal ToolStripMenuItem QuitterToolStripMenuItem;
        internal ToolStripMenuItem FichiersToolStripMenuItem;
        internal ToolStripMenuItem CréerunfichierToolStripMenuItem;
        internal ToolStripMenuItem AjouterToolStripMenuItem;
        internal ToolStripMenuItem SupprToolStripMenuItem;
        internal ToolStripSeparator toolStripSeparator4;
        internal ToolStripMenuItem OutilsToolStripMenuItem;
        internal ToolStripMenuItem ImporterlibrairiesToolStripMenuItem;
        internal ToolStripMenuItem GenererunfichierdocxToolStripMenuItem;
        internal ToolStripMenuItem AideToolStripMenuItem;
        internal ToolStripMenuItem ÀproposdeToolStripMenuItem;
        internal MenuStrip MenuStrip1;
        internal ToolStripTextBox ToolStripTextBox1;
        internal ListView ListView1;
        internal ToolStripSeparator ToolStripSeparator1;
        internal TextBox TextBox1;
        internal TextBox TextBox2;
        internal TextBox TextBox4;
        internal TextBox TextBox6;
        internal TextBox TextBox7;
        internal TextBox TextBox3;
        internal TextBox TextBox5;
        internal TextBox TextBox8;
        internal TextBox TextBox9;
        internal TreeView TreeView1;
        internal ToolStrip ToolStrip3;
        internal ToolStripButton ToolStripButton1;
        internal ToolStripButton ToolStripButton2;
        internal ToolStripSeparator ToolStripSeparator9;
        internal ToolStripButton ToolStripButton3;
        internal ToolStripButton ToolStripButton4;
        internal ToolStripSeparator ToolStripSeparator10;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ComboBox ComboBox1;
        internal Label Label1;
        internal ColumnHeader ColumnHeader1;
        internal ImageList ImageList1;
        internal ImageList ImageList2;
        internal ToolStripStatusLabel ToolStripStatusLabel2;
        internal Timer Timer1;
        internal ToolStripStatusLabel ToolStripStatusLabel3;
        internal ToolStripStatusLabel ToolStripStatusLabel4;
        internal TextBox TextBox10;
        internal TextBox TextBox12;
        internal TextBox TextBox11;
        internal TextBox TextBox13;
        internal DateTimePicker DateTimePicker1;
        internal TextBox TextBox14;
        internal TextBox TextBox15;
        internal ToolStripMenuItem GenererunfichierxmlToolStripMenuItem;
        internal TextBox TextBox19;
        internal TextBox TextBox18;
        internal TextBox TextBox17;
        internal TextBox TextBox20;
        internal TextBox TextBox21;
        internal TextBox TextBox22;
        internal ComboBox ComboBox2;
        internal TextBox TextBox26;
        internal TextBox TextBox25;
        internal TextBox TextBox24;
        internal TextBox TextBox23;
        internal TextBox TextBox31;
        internal TextBox TextBox30;
        internal TextBox TextBox29;
        internal TextBox TextBox28;
        internal TextBox TextBox27;
        internal PictureBox PictureBox1;
        internal ToolStripMenuItem ListeToolStripMenuItem;
        internal ToolStripMenuItem ToolStripMenuItem2;
        internal ToolStripSeparator ToolStripSeparator3;
        internal ToolStripButton NouveauToolStripButton;
        internal ToolStripButton ListeToolStripButton;
        internal ToolStripButton EnregistrerToolStripButton;
        internal ToolStripStatusLabel ToolStripStatusLabel5;
        internal TextBox TextBox32;
        internal TextBox TextBox33;
        internal ToolStripSeparator ToolStripSeparator5;
        internal ToolStripButton ToolStripButton5;
        internal OpenFileDialog OpenFileDialog1;
        internal ToolStripSeparator ToolStripSeparator7;
        internal ToolStripMenuItem AfficherLaideToolStripMenuItem;
        internal NotifyIcon NotifyIcon1;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem ToolStripMenuItem3;
        internal ToolStripSeparator ToolStripSeparator8;
        internal ToolStripMenuItem ToolStripMenuItem4;
        internal ToolStripMenuItem ToolStripMenuItem5;
        internal HelpProvider HelpProvider1;
        internal Label Label2;
        internal ToolStripMenuItem LireunfichierxmlToolStripMenuItem;
        internal SaveFileDialog SaveFileDialog1;
        internal ListBox ListBox2;
        internal ListBox ListBox1;
        internal Button Button1;
        internal ToolStripSeparator ToolStripSeparator12;
        internal PrintDialog PrintDialog1;
        internal ToolStripMenuItem ToolStripMenuItem6;
        internal ToolStripMenuItem ToolStripMenuItem7;
        internal DataSet DataSet1;
        internal TextBox TextBox16;
        internal ToolStripMenuItem CréerundocumentauformatooxmlfToolStripMenuItem;
        internal ToolStripMenuItem RechercherlesmisesajourToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator15;
        internal ToolStripMenuItem ProcessusdetraitementdesdonnéesToolStripMenuItem;
        internal ToolStripMenuItem CréerunfichierhtmlToolStripMenuItem;
        internal PictureBox PictureBox2;
        internal ToolStripMenuItem RechercherdanslesfichiersToolStripMenuItem;
        internal ToolStripMenuItem EditionToolStripMenuItem;
        internal ToolStripMenuItem AnnulerToolStripMenuItem;
        internal ToolStripMenuItem RétablirToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator17;
        internal ToolStripMenuItem CouperToolStripMenuItem;
        internal ToolStripMenuItem CopierToolStripMenuItem;
        internal ToolStripMenuItem CollerToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator18;
        internal ToolStripMenuItem SélectionnerToutToolStripMenuItem;
        internal ToolStripMenuItem CreerundocumentjsonToolStripMenuItem;
        internal ToolStripSeparator ToolStripSeparator19;
        internal ToolStripMenuItem LireundocumentjsonToolStripMenuItem;
        internal ToolStripStatusLabel ToolStripStatusLabel6;
        internal ToolTip ToolTip1;
        internal PictureBox PictureBox3;
        internal ToolStripMenuItem CréerundocumentauformatPDFToolStripMenuItem;
        internal TextBox TextBox34;
        internal RichTextBox RichTextBox1;
        internal ListBox ListBox3;
        internal PictureBox PictureBox4;
        internal ToolStripMenuItem NousContacterToolStripMenuItem;
    }
}