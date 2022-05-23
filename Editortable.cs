using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using System.Runtime.CompilerServices;

public class Editortable : DarkForm
{
    private string vssUnits_0 = "KPH";
    private Editortable Editortable_0;
    private IContainer icontainer_0;
    private IContainer icontainer_1;
    public bool bool_0 = true;
    public static float float_0 = 1f;
    public static float[] float_1 = new float[2];
    private DarkTreeView treeView1;
    private DarkGroupBox groupBox1;
    public DataGridView dataGridView_0;
    internal ClassEditor ClassEditor_0;
    public string LoadedFilename;
    public bool IsFullBinary = true;
    public static ImageList imageList_0;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    public GForm_Main GForm_Main_0;
    private DarkToolStrip darkToolStrip1;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripMenuItem openbinToolStripMenuItem;
    private ToolStripMenuItem savebinToolStripMenuItem;
    private ToolStripMenuItem fixChecksumsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem openDefinitionsFolderToolStripMenuItem;
    private ToolStripDropDownButton toolStripDropDownButton2;
    private ToolStripMenuItem undoToolStripMenuItem;
    public ToolStripMenuItem redoToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem increaseSelectionToolStripMenuItem;
    private SplitContainer splitContainer1;
    private SplitContainer splitContainer2;
    private DarkTextBox darkTextBox_0;
    private ToolStripDropDownButton toolStripDropDownButton3;
    private ToolStripMenuItem developpersToolsToolStripMenuItem;
    private ToolStripMenuItem generateDefinitionsFilesToolStripMenuItem;
    private ToolStripMenuItem getDifferencesInAllFirmwaresFilesToolStripMenuItem;
    private ToolStripMenuItem extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem;
    private ToolStripMenuItem extractDefinitionToolStripMenuItem;
    private FolderBrowserDialog folderBrowserDialog1;
    private ToolStripMenuItem removeBootloaderInbinToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem generateDefinitionFileFromExtractedDefinitionToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem extractbinFileFromFPMToolStripMenuItem;
    private ToolStripMenuItem convertrwdTobinToolStripMenuItem;
    private ToolStripMenuItem convertbinTorwdToolStripMenuItem;
    private ToolStripMenuItem openOBD2ScanToolToolStripMenuItem;
    private ToolStripMenuItem decreaseSelectionToolStripMenuItem;

    internal Editortable(ref GForm_Main GForm_Main_1)
    {
        GForm_Main_0 = GForm_Main_1;

        this.InitializeComponent();

        Editortable_0 = this;

        if (this.ClassEditor_0 != null) this.ClassEditor_0 = null;
        this.ClassEditor_0 = new ClassEditor(ref Editortable_0);

        this.Text = "Honda Rom Tables Editor (" + this.GForm_Main_0.Version + ")";
    }

    public void Loadingg() 
    {
        string LastOpenFilePath = Application.StartupPath + @"\LastFileOpened.txt";
        if (File.Exists(LastOpenFilePath))
        {
            DialogResult result = DarkMessageBox.Show(this, "Do you want to reopen the last file you have worked on?", "Reopen last file used", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                LoadThisFile(File.ReadAllText(LastOpenFilePath));
            }
        }
    }

    public void method_Log(string string_3)
    {
        this.darkTextBox_0.Text += string_3;
        //Console.Write(string_3);
    }

    public void method_1(string string_3)
    {
        try
        {
            //With newline automaticly added
            //Console.WriteLine(string_3);
            Editortable.Class5 @class = new Editortable.Class5();
            @class.Editortable_0 = this;
            @class.string_0 = string_3;
            this.darkTextBox_0.BeginInvoke(new MethodInvoker(@class.method_0));
        }
        catch { }
    }

    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editortable));
            this.treeView1 = new DarkUI.Controls.DarkTreeView();
            this.groupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.dataGridView_0 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.darkToolStrip1 = new DarkUI.Controls.DarkToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openbinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savebinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixChecksumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openDefinitionsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openOBD2ScanToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertrwdTobinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertbinTorwdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBootloaderInbinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.developpersToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDefinitionsFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDifferencesInAllFirmwaresFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.extractDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractbinFileFromFPMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.darkTextBox_0 = new DarkUI.Controls.DarkTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).BeginInit();
            this.darkToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.EvenNodeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.treeView1.FocusedNodeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = null;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.MaxDragChange = 20;
            this.treeView1.Name = "treeView1";
            this.treeView1.NonFocusedNodeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.treeView1.OddNodeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.SelectWithArrowKeys = false;
            this.treeView1.Size = new System.Drawing.Size(297, 517);
            this.treeView1.TabIndex = 2;
            this.treeView1.SelectedNodesChanged += new System.EventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox1.Controls.Add(this.dataGridView_0);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(799, 361);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table:";
            // 
            // dataGridView_0
            // 
            this.dataGridView_0.AllowUserToAddRows = false;
            this.dataGridView_0.AllowUserToDeleteRows = false;
            this.dataGridView_0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_0.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_0.ColumnHeadersHeight = 20;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_0.EnableHeadersVisualStyles = false;
            this.dataGridView_0.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_0.Location = new System.Drawing.Point(2, 15);
            this.dataGridView_0.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_0.Name = "dataGridView_0";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_0.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_0.RowTemplate.Height = 31;
            this.dataGridView_0.Size = new System.Drawing.Size(795, 344);
            this.dataGridView_0.TabIndex = 4;
            this.dataGridView_0.TabStop = false;
            this.dataGridView_0.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellValueChanged);
            this.dataGridView_0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.method_4);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.bin";
            this.openFileDialog1.Filter = "Honda binary rom file|*.bin";
            this.openFileDialog1.Title = "Open File";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.bin";
            this.saveFileDialog1.Filter = "Honda binary file|*.bin";
            this.saveFileDialog1.Title = "Save File";
            // 
            // darkToolStrip1
            // 
            this.darkToolStrip1.AutoSize = false;
            this.darkToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkToolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3});
            this.darkToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.darkToolStrip1.Name = "darkToolStrip1";
            this.darkToolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.darkToolStrip1.Size = new System.Drawing.Size(1100, 28);
            this.darkToolStrip1.TabIndex = 2;
            this.darkToolStrip1.Text = "darkToolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openbinToolStripMenuItem,
            this.savebinToolStripMenuItem,
            this.fixChecksumsToolStripMenuItem,
            this.toolStripSeparator1,
            this.openDefinitionsFolderToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 25);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // openbinToolStripMenuItem
            // 
            this.openbinToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.openbinToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openbinToolStripMenuItem.Name = "openbinToolStripMenuItem";
            this.openbinToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openbinToolStripMenuItem.Text = "Open .bin";
            this.openbinToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // savebinToolStripMenuItem
            // 
            this.savebinToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.savebinToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.savebinToolStripMenuItem.Name = "savebinToolStripMenuItem";
            this.savebinToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.savebinToolStripMenuItem.Text = "Save .bin";
            this.savebinToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // fixChecksumsToolStripMenuItem
            // 
            this.fixChecksumsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.fixChecksumsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fixChecksumsToolStripMenuItem.Name = "fixChecksumsToolStripMenuItem";
            this.fixChecksumsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.fixChecksumsToolStripMenuItem.Text = "Fix Checksums";
            this.fixChecksumsToolStripMenuItem.Click += new System.EventHandler(this.fixChecksumsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // openDefinitionsFolderToolStripMenuItem
            // 
            this.openDefinitionsFolderToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.openDefinitionsFolderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openDefinitionsFolderToolStripMenuItem.Name = "openDefinitionsFolderToolStripMenuItem";
            this.openDefinitionsFolderToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openDefinitionsFolderToolStripMenuItem.Text = "Open Definitions Folder";
            this.openDefinitionsFolderToolStripMenuItem.Click += new System.EventHandler(this.openDefinitionsFolderToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator2,
            this.increaseSelectionToolStripMenuItem,
            this.decreaseSelectionToolStripMenuItem});
            this.toolStripDropDownButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(40, 25);
            this.toolStripDropDownButton2.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.undoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // increaseSelectionToolStripMenuItem
            // 
            this.increaseSelectionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.increaseSelectionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.increaseSelectionToolStripMenuItem.Name = "increaseSelectionToolStripMenuItem";
            this.increaseSelectionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.increaseSelectionToolStripMenuItem.Text = "Increase Selection";
            this.increaseSelectionToolStripMenuItem.Click += new System.EventHandler(this.increaseSelectionToolStripMenuItem_Click);
            // 
            // decreaseSelectionToolStripMenuItem
            // 
            this.decreaseSelectionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.decreaseSelectionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.decreaseSelectionToolStripMenuItem.Name = "decreaseSelectionToolStripMenuItem";
            this.decreaseSelectionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.decreaseSelectionToolStripMenuItem.Text = "Decrease Selection";
            this.decreaseSelectionToolStripMenuItem.Click += new System.EventHandler(this.decreaseSelectionToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openOBD2ScanToolToolStripMenuItem,
            this.convertrwdTobinToolStripMenuItem,
            this.convertbinTorwdToolStripMenuItem,
            this.removeBootloaderInbinToolStripMenuItem,
            this.toolStripSeparator3,
            this.developpersToolsToolStripMenuItem});
            this.toolStripDropDownButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(47, 25);
            this.toolStripDropDownButton3.Text = "Tools";
            // 
            // openOBD2ScanToolToolStripMenuItem
            // 
            this.openOBD2ScanToolToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.openOBD2ScanToolToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openOBD2ScanToolToolStripMenuItem.Name = "openOBD2ScanToolToolStripMenuItem";
            this.openOBD2ScanToolToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.openOBD2ScanToolToolStripMenuItem.Text = "Open OBD2 Scan Tool";
            this.openOBD2ScanToolToolStripMenuItem.Click += new System.EventHandler(this.openOBD2ScanToolToolStripMenuItem_Click);
            // 
            // convertrwdTobinToolStripMenuItem
            // 
            this.convertrwdTobinToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.convertrwdTobinToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.convertrwdTobinToolStripMenuItem.Name = "convertrwdTobinToolStripMenuItem";
            this.convertrwdTobinToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.convertrwdTobinToolStripMenuItem.Text = "Convert .rwd to .bin";
            this.convertrwdTobinToolStripMenuItem.Click += new System.EventHandler(this.convertrwdTobinToolStripMenuItem_Click);
            // 
            // convertbinTorwdToolStripMenuItem
            // 
            this.convertbinTorwdToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.convertbinTorwdToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.convertbinTorwdToolStripMenuItem.Name = "convertbinTorwdToolStripMenuItem";
            this.convertbinTorwdToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.convertbinTorwdToolStripMenuItem.Text = "Convert .bin to .rwd";
            this.convertbinTorwdToolStripMenuItem.Click += new System.EventHandler(this.convertbinTorwdToolStripMenuItem_Click);
            // 
            // removeBootloaderInbinToolStripMenuItem
            // 
            this.removeBootloaderInbinToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.removeBootloaderInbinToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.removeBootloaderInbinToolStripMenuItem.Name = "removeBootloaderInbinToolStripMenuItem";
            this.removeBootloaderInbinToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.removeBootloaderInbinToolStripMenuItem.Text = "Remove Bootloader in .bin";
            this.removeBootloaderInbinToolStripMenuItem.Click += new System.EventHandler(this.removeBootloaderInbinToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(211, 6);
            // 
            // developpersToolsToolStripMenuItem
            // 
            this.developpersToolsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.developpersToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateDefinitionsFilesToolStripMenuItem,
            this.getDifferencesInAllFirmwaresFilesToolStripMenuItem,
            this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem,
            this.toolStripSeparator4,
            this.extractDefinitionToolStripMenuItem,
            this.extractbinFileFromFPMToolStripMenuItem,
            this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem});
            this.developpersToolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.developpersToolsToolStripMenuItem.Name = "developpersToolsToolStripMenuItem";
            this.developpersToolsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.developpersToolsToolStripMenuItem.Text = "Developpers Tools";
            // 
            // generateDefinitionsFilesToolStripMenuItem
            // 
            this.generateDefinitionsFilesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.generateDefinitionsFilesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.generateDefinitionsFilesToolStripMenuItem.Name = "generateDefinitionsFilesToolStripMenuItem";
            this.generateDefinitionsFilesToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.generateDefinitionsFilesToolStripMenuItem.Text = "Generate Definitions files from all firmwares files";
            this.generateDefinitionsFilesToolStripMenuItem.Click += new System.EventHandler(this.generateDefinitionsFilesToolStripMenuItem_Click);
            // 
            // getDifferencesInAllFirmwaresFilesToolStripMenuItem
            // 
            this.getDifferencesInAllFirmwaresFilesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.getDifferencesInAllFirmwaresFilesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.getDifferencesInAllFirmwaresFilesToolStripMenuItem.Name = "getDifferencesInAllFirmwaresFilesToolStripMenuItem";
            this.getDifferencesInAllFirmwaresFilesToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.getDifferencesInAllFirmwaresFilesToolStripMenuItem.Text = "Get differences count in all firmwares files";
            this.getDifferencesInAllFirmwaresFilesToolStripMenuItem.Click += new System.EventHandler(this.getDifferencesInAllFirmwaresFilesToolStripMenuItem_Click);
            // 
            // extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem
            // 
            this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem.Name = "extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem";
            this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem.Text = "Extract all bootloader \'sum\' byte from all firmwares files";
            this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem.Click += new System.EventHandler(this.extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(364, 6);
            // 
            // extractDefinitionToolStripMenuItem
            // 
            this.extractDefinitionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.extractDefinitionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.extractDefinitionToolStripMenuItem.Name = "extractDefinitionToolStripMenuItem";
            this.extractDefinitionToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.extractDefinitionToolStripMenuItem.Text = "Extract Definition file from FPM";
            this.extractDefinitionToolStripMenuItem.Click += new System.EventHandler(this.extractDefinitionToolStripMenuItem_Click);
            // 
            // extractbinFileFromFPMToolStripMenuItem
            // 
            this.extractbinFileFromFPMToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.extractbinFileFromFPMToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.extractbinFileFromFPMToolStripMenuItem.Name = "extractbinFileFromFPMToolStripMenuItem";
            this.extractbinFileFromFPMToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.extractbinFileFromFPMToolStripMenuItem.Text = "Extract .bin file from FPM";
            this.extractbinFileFromFPMToolStripMenuItem.Click += new System.EventHandler(this.extractbinFileFromFPMToolStripMenuItem_Click);
            // 
            // generateDefinitionFileFromExtractedDefinitionToolStripMenuItem
            // 
            this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem.Name = "generateDefinitionFileFromExtractedDefinitionToolStripMenuItem";
            this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem.Size = new System.Drawing.Size(367, 22);
            this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem.Text = "Generate Definition file from Extracted Definition";
            this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem.Click += new System.EventHandler(this.generateDefinitionFileFromExtractedDefinitionToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1100, 517);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.darkTextBox_0);
            this.splitContainer2.Size = new System.Drawing.Size(799, 517);
            this.splitContainer2.SplitterDistance = 361;
            this.splitContainer2.TabIndex = 0;
            // 
            // darkTextBox_0
            // 
            this.darkTextBox_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkTextBox_0.Location = new System.Drawing.Point(0, 0);
            this.darkTextBox_0.Multiline = true;
            this.darkTextBox_0.Name = "darkTextBox_0";
            this.darkTextBox_0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.darkTextBox_0.Size = new System.Drawing.Size(799, 152);
            this.darkTextBox_0.TabIndex = 56;
            this.darkTextBox_0.Text = "Honda CANBUS Tools";
            // 
            // Editortable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 545);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.darkToolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Editortable";
            this.Text = "Honda Rom Tables Editor";
            this.Load += new System.EventHandler(this.Editortable_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).EndInit();
            this.darkToolStrip1.ResumeLayout(false);
            this.darkToolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    public void Editortable_Load(object sender, EventArgs e)
    {
        this.CreateRightClicMenu();
    }

    public bool LoadDefinitionsFor(string string_9)
    {
        //ClassEditor_0.LoadSupportedECUDefinitions();

        int DefinitionsFilesCount = 0;
        List<int> IndexLisst = new List<int>();
        for (int i = 0; i < ClassEditor_0.Ecus_Definitions_Compatible.Count; i++)
        {
            if (ClassEditor_0.Ecus_Definitions_Compatible[i] == string_9)
            {
                DefinitionsFilesCount++;
                IndexLisst.Add(i);
                //ClassEditor_0.LoadThisECUDefinitions(string_9);
                //return true;
            }
        }

        if (DefinitionsFilesCount > 1)
        {
            GForm_SeveralDef GForm_SeveralDef_0 = new GForm_SeveralDef();
            GForm_SeveralDef_0.LoadSetValues(ref GForm_Main_0, string_9, IndexLisst);
            DialogResult result = GForm_SeveralDef_0.ShowDialog();
            if (result == DialogResult.OK)
            {
                ClassEditor_0.LoadThisECUDefinitions(string_9, IndexLisst[GForm_SeveralDef_0.comboBox1.SelectedIndex]);
                return true;
            }

            //HERE
            //ClassEditor_0.LoadThisECUDefinitions(string_9, IndexLisst[0]);
            //return true;
        }
        if (DefinitionsFilesCount == 1)
        {
            ClassEditor_0.LoadThisECUDefinitions(string_9, IndexLisst[0]);
            return true;
        }

        return false;
    }

    public void method_1()
    {
        ClassEditor_0.CanReloadTablesValues = false;
        if (!ClassEditor_0.LoadROMbytes(LoadedFilename))
        {
            DarkMessageBox.Show("Failed to open Binary file.");
        }
        else if (!this.LoadDefinitionsFor(ClassEditor_0.string_ECU_Name))
        {
            DarkMessageBox.Show("No definition found for " + ClassEditor_0.string_ECU_Name);
        }
        else
        {
            this.CreateNodes();
        }
        ClassEditor_0.CanReloadTablesValues = true;
    }

    private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (ClassEditor_0.CanReloadTablesValues)
        {
            ClassEditor_0.ValuesChanged = true;
            ClassEditor_0.SetBackColor(dataGridView_0.Columns.Count, float_1[0], float_1[1]);
        }
    }

    public void CreateNodes()
    {
        this.treeView1.Nodes.Clear();
        int num = 0;

        List<string> AllUndefininedNodes = new List<string>();
        List<string> AllUntestedNodes = new List<string>();
        List<string> AllReadOnlyNodes = new List<string>();

        //Makes Nodes
        for (int i = 0; i < ClassEditor_0.DefinitionsName.Count; i++)
        {
            //#############################################
            if (ClassEditor_0.DefinitionsIsReadOnly[i])
            {
                AllReadOnlyNodes.Add(ClassEditor_0.DefinitionsName[i]);
            }
            if (ClassEditor_0.DefinitionsIsUntested[i] && !ClassEditor_0.DefinitionsIsReadOnly[i])
            {
                AllUntestedNodes.Add(ClassEditor_0.DefinitionsName[i]);
            }
            if (ClassEditor_0.DefinitionsIsNotDefined[i] && !ClassEditor_0.DefinitionsIsUntested[i] && !ClassEditor_0.DefinitionsIsReadOnly[i])
            {
                AllUndefininedNodes.Add(ClassEditor_0.DefinitionsName[i]);
            }
            //#############################################

            if (!ClassEditor_0.DefinitionsIsNotDefined[i] && !ClassEditor_0.DefinitionsIsUntested[i] && !ClassEditor_0.DefinitionsIsReadOnly[i])
            {
                string str = ClassEditor_0.DefinitionsName[i];
                DarkTreeNode ThisNode = new DarkTreeNode();
                if (str.ToString().Contains("----"))
                {
                    ThisNode.Text = str.Replace("----", "");
                    this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes[this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Count - 1].Nodes.Add(ThisNode);
                    continue;
                }
                if (str.ToString().Contains("--"))
                {
                    ThisNode.Text = str.Replace("--", "");
                    this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Add(ThisNode);
                    continue;
                }
                num++;

                ThisNode.Text = str;
                this.treeView1.Nodes.Add(ThisNode);
            }
        }

        //Make Undefined Nodes
        DarkTreeNode ThisNodeUnDefined = new DarkTreeNode();
        ThisNodeUnDefined.Text = "Undefined parameters";
        if (AllUndefininedNodes.Count > 0) this.treeView1.Nodes.Add(ThisNodeUnDefined);
        for (int i = 0; i < AllUndefininedNodes.Count; i++)
        {
            string str = AllUndefininedNodes[i];
            DarkTreeNode ThisNode = new DarkTreeNode();
            if (str.ToString().Contains("--"))
            {
                ThisNode.Text = str.Replace("--", "");
                this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Add(ThisNode);
                //this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes[this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Count - 1].Nodes.Add(ThisNode);
                continue;
            }
            num++;

            ThisNode.Text = str;
            this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Add(ThisNode);
        }

        //Make Untested Nodes
        DarkTreeNode ThisNodeUnTested = new DarkTreeNode();
        ThisNodeUnTested.Text = "Untested parameters";
        if (AllUntestedNodes.Count > 0) this.treeView1.Nodes.Add(ThisNodeUnTested);
        for (int i = 0; i < AllUntestedNodes.Count; i++)
        {
            string str = AllUntestedNodes[i];
            DarkTreeNode ThisNode = new DarkTreeNode();
            if (str.ToString().Contains("--"))
            {
                ThisNode.Text = str.Replace("--", "");
                this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Add(ThisNode);
                //this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes[this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Count - 1].Nodes.Add(ThisNode);
                continue;
            }
            num++;

            ThisNode.Text = str;
            this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Add(ThisNode);
        }

        //Make ReadOnly Nodes
        DarkTreeNode ThisNodeReadOnly = new DarkTreeNode();
        ThisNodeReadOnly.Text = "ReadOnly parameters";
        if (AllUntestedNodes.Count > 0) this.treeView1.Nodes.Add(ThisNodeReadOnly);
        for (int i = 0; i < AllReadOnlyNodes.Count; i++)
        {
            string str = AllReadOnlyNodes[i];
            DarkTreeNode ThisNode = new DarkTreeNode();
            if (str.ToString().Contains("--"))
            {
                ThisNode.Text = str.Replace("--", "");
                this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Add(ThisNode);
                //this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes[this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Count - 1].Nodes.Add(ThisNode);
                continue;
            }
            num++;

            ThisNode.Text = str;
            this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Add(ThisNode);
        }

        //####################################################################################
        /*foreach (DarkTreeNode node in this.treeView1.Nodes)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (DarkTreeNode node2 in node.Nodes)
                {
                    if (node.Text.Contains("limiter"))
                    {
                        node2.ImageKey = "Normal";
                        node2.SelectedImageKey = "Normal";
                        continue;
                    }
                }
            }
            if ((node.Text.Contains("Revlimiter") || node.Text.Contains("Speedlimiter")) || node.Text.Contains("Limit"))
            {
                node.ImageKey = "Normal";
                node.SelectedImageKey = "Normal";
            }
            else if (node.Text.Contains("00\x00b0"))
            {
                node.ImageKey = "Degree";
                node.SelectedImageKey = "Degree";
            }//...
        }*/
        //####################################################################################
    }

    private void method_4(object sender, KeyEventArgs e)
    {
        ClassEditor_0.ShortcutsCommand(e, 0);
    }

    public void CreateRightClicMenu()
    {
        ContextMenu menu = new ContextMenu {
            MenuItems = { 
                { 
                    "Increase selection",
                    new EventHandler(this.method_6)
                },
                { 
                    "Decrease selection",
                    new EventHandler(this.method_7)
                }
            }
        };
        this.ContextMenu = menu;
    }

    private void method_6(object sender, EventArgs e)
    {
        ClassEditor_0.ShortcutsCommand(new KeyEventArgs(Keys.None), 2);
    }

    private void method_7(object sender, EventArgs e)
    {
        ClassEditor_0.ShortcutsCommand(new KeyEventArgs(Keys.None), 3);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    /*public static ImageList ImageList_0
    {
        get
        {
            if (imageList_0 == null)
            {
                imageList_0 = new ImageList();
                imageList_0.Images.Add("HighCam", global::Properties.Resources.Lightning2);
                imageList_0.Images.Add("LowCam", global::Properties.Resources.Lightning);
                imageList_0.Images.Add("HighFuel", global::Properties.Resources.injector2);
                imageList_0.Images.Add("LowFuel", global::Properties.Resources.injector1);
                imageList_0.Images.Add("Table", global::Properties.Resources.Script1);
                imageList_0.Images.Add("Degree", global::Properties.Resources.Target);
                imageList_0.Images.Add("Red", global::Properties.Resources.Report);
                imageList_0.Images.Add("Normal", global::Properties.Resources.Wrench);
                imageList_0.Images.Add("Vtec", global::Properties.Resources.Pinion);
                imageList_0.Images.Add("Knock", global::Properties.Resources.Problem);
                imageList_0.Images.Add("Bang", global::Properties.Resources.Disaster);
            }
            return imageList_0;
        }
    }*/

    private int GetNodeParameterIndex(string text, string ParentNode)
    {
        //return within parent
        if (ParentNode != "")
        {
            bool ParentFound = false;
            for (int i = 0; i < ClassEditor_0.DefinitionsName.Count; i++)
            {
                if (ClassEditor_0.DefinitionsName[i] == ParentNode) ParentFound = true;
                if (ParentFound)
                {
                    if (ClassEditor_0.DefinitionsName[i] == text || ClassEditor_0.DefinitionsName[i] == "--" + text) return i;
                }
            }
        }

        //return exact
        for (int i = 0; i < ClassEditor_0.DefinitionsName.Count; i++)
        {
            if (ClassEditor_0.DefinitionsName[i] == text)
            {
                return i;
            }
        }
        //return approximative
        for (int i = 0; i < ClassEditor_0.DefinitionsName.Count; i++)
        {
            if (ClassEditor_0.DefinitionsName[i].Contains(text))
            {
                return i;
            }
        }
        //return error
        return -1;
    }

    private void treeView1_AfterSelect(object sender, EventArgs e)
    {
        if (this.treeView1.SelectedNodes.Count == 0) return;

        if ((this.treeView1.SelectedNode != null) && ClassEditor_0.CanReloadTablesValues)
        {
            ClassEditor_0.CanReloadTablesValues = false;
            //##################################################################################
            if (ClassEditor_0.ValuesChanged && ClassEditor_0.SelectedTableSize != 0 && ClassEditor_0.SelectedROMLocation != 0)
            {
                ClassEditor_0.GetChanges();
            }
            ClassEditor_0.ValuesChanged = false;
            //##################################################################################

            this.groupBox1.Text = "Table: " + this.treeView1.SelectedNode.Text;
            string text = this.treeView1.SelectedNode.Text;
            if (text != null)
            {
                string ParentNode = "";
                if (this.treeView1.SelectedNode.ParentNode != null) ParentNode = this.treeView1.SelectedNode.ParentNode.Text;
                int NodeIndex = GetNodeParameterIndex(text, ParentNode);

                if (NodeIndex == -1)
                {
                    Editortable_0.GForm_Main_0.method_1("ROM Indexing error with Nodes!");
                    ClassEditor_0.CanReloadTablesValues = true;
                    return;
                }

                //Empty 'Main' Node -> Select first child node
                if (ClassEditor_0.DefinitionsTableSize[NodeIndex] == "")
                {
                    try
                    {
                        ClassEditor_0.CanReloadTablesValues = true;
                        this.treeView1.SelectNode(this.treeView1.SelectedNode.Nodes[0]);
                    }
                    catch { }
                    return;
                }

                float_1[0] = ClassEditor_0.DefinitionsValueMin[NodeIndex];
                float_1[1] = ClassEditor_0.DefinitionsValueMax[NodeIndex];
                float_0 = (float) ClassEditor_0.DefinitionsChangeAmount[NodeIndex];
                ClassEditor_0.IsSingleByteX = ClassEditor_0.DefinitionsIsSingleByteX[NodeIndex];
                ClassEditor_0.IsSingleByteY = ClassEditor_0.DefinitionsIsSingleByteY[NodeIndex];
                ClassEditor_0.IsSingleByteTable = ClassEditor_0.DefinitionsIsSingleByteTable[NodeIndex];

                //Set TableSize
                string TableSizeStr = ClassEditor_0.DefinitionsTableSize[NodeIndex].ToLower();
                string[] TableSizeStrSplit = TableSizeStr.Split('x');
                int[] TableSizze = new int[] { int.Parse(TableSizeStrSplit[0]), int.Parse(TableSizeStrSplit[1]) };

                if (ClassEditor_0.DefinitionsLocationsX[NodeIndex].Length >= 10) ClassEditor_0.DefinitionsLocationsX[NodeIndex] = ClassEditor_0.DefinitionsLocationsX[NodeIndex].Replace("0x80", "0x");
                if (ClassEditor_0.DefinitionsLocationsY[NodeIndex].Length >= 10) ClassEditor_0.DefinitionsLocationsY[NodeIndex] = ClassEditor_0.DefinitionsLocationsY[NodeIndex].Replace("0x80", "0x");
                if (ClassEditor_0.DefinitionsLocationsTable[NodeIndex].Length >= 10) ClassEditor_0.DefinitionsLocationsTable[NodeIndex] = ClassEditor_0.DefinitionsLocationsTable[NodeIndex].Replace("0x80", "0x");

                //Set X rom location
                long ParamLocation = ClassEditor_0.HexStringToInt(ClassEditor_0.DefinitionsLocationsX[NodeIndex]);

                //Set Y Headers (normal header mode)
                int DoingThisSize = TableSizze[0];
                if (ClassEditor_0.DefinitionsIsXYInverted[NodeIndex]) DoingThisSize = TableSizze[1];

                string[] textArray1 = new string[DoingThisSize];
                if (ClassEditor_0.DefinitionsHeaders[NodeIndex] != "" && ClassEditor_0.DefinitionsHeaders[NodeIndex].Contains(","))
                {
                    string[] AllHeaders = ClassEditor_0.DefinitionsHeaders[NodeIndex].Split(',');
                    if (AllHeaders.Length != DoingThisSize) Editortable_0.GForm_Main_0.method_1("Headers length not matching Table Size");
                    if (AllHeaders.Length == DoingThisSize)
                    {
                        for (int i = 0; i < AllHeaders.Length; i++)
                        {
                            textArray1[i] = AllHeaders[i];
                        }
                    }
                }

                //Set Y Advanced Header (values from 'DefinitionsLocationsHeader' with mathematical function 'MathHeader')
                string NewHeaderLocation = ClassEditor_0.DefinitionsLocationsY[NodeIndex];
                if (NewHeaderLocation != "")
                {
                    long ParamHeaderLocation = ClassEditor_0.HexStringToInt(NewHeaderLocation);
                    textArray1 = ClassEditor_0.GetAdvancedHeader(TableSizze[0], ParamHeaderLocation, ClassEditor_0.DefinitionsMathY[NodeIndex], ClassEditor_0.DefinitionsFormatY[NodeIndex]);
                }

                this.groupBox1.Text = "Table: " + this.treeView1.SelectedNode.Text + " (" + ClassEditor_0.DefinitionsLocationsTable[NodeIndex] + ")";

                ClassEditor_0.SelectedTableIndexInDefinitions = NodeIndex;

                //Show Value in Datagridview
                ClassEditor_0.SetTableValues(TableSizze,
                                            ParamLocation,
                                            ClassEditor_0.DefinitionsUnit1[NodeIndex],
                                            ClassEditor_0.DefinitionsUnit2[NodeIndex],
                                            textArray1, ClassEditor_0.DefinitionsMathX[NodeIndex],
                                            ClassEditor_0.DefinitionsFormatX[NodeIndex],
                                            ClassEditor_0.DefinitionsIsXYInverted[NodeIndex],
                                            ClassEditor_0.HexStringToInt(ClassEditor_0.DefinitionsLocationsTable[NodeIndex]),
                                            ClassEditor_0.DefinitionsMathTable[NodeIndex], ClassEditor_0.DefinitionsFormatTable[NodeIndex],
                                            ClassEditor_0.DefinitionsIsTableInverted[NodeIndex],
                                            ClassEditor_0.DefinitionsIsReadOnly[NodeIndex]);
            }
        }

        ClassEditor_0.CanReloadTablesValues = true;
    }

    public int CheckForBootLoaderSum(string ThisECUName)
    {
        string BLSumPath = Application.StartupPath + @"\BootLoaderSumBytesList.txt";
        if (File.Exists(BLSumPath))
        {
            string[] AllLines = File.ReadAllLines(BLSumPath);

            for (int i = 0; i < AllLines.Length; i++)
            {
                if (AllLines[i].Contains("|"))
                {
                    string[] SplittedCommands = AllLines[i].Split('|');

                    if (SplittedCommands[0] == ThisECUName)
                    {
                        return int.Parse(SplittedCommands[1]);
                    }
                }
            }
        }

        return -1;
    }

    public string ExtractECUNameFromThisFile(byte[] ThisFileBytes)
    {
        string ECUName = "";
        for (int i = 0; i < ThisFileBytes.Length - 12; i++)
        {
            //37805-
            if ((char) ThisFileBytes[i] == '3'
                && (char)ThisFileBytes[i + 1] == '7'
                && (char)ThisFileBytes[i + 2] == '8'
                && (char)ThisFileBytes[i + 3] == '0'
                && (char)ThisFileBytes[i + 4] == '5'
                && (char)ThisFileBytes[i + 5] == '-'
                && (char)ThisFileBytes[i + 10] != 'Z')
            {
                ECUName = "";
                ECUName = ECUName + ((char)ThisFileBytes[i]).ToString();        //3
                ECUName = ECUName + ((char)ThisFileBytes[i + 1]).ToString();    //7
                ECUName = ECUName + ((char)ThisFileBytes[i + 2]).ToString();    //8
                ECUName = ECUName + ((char)ThisFileBytes[i + 3]).ToString();    //0
                ECUName = ECUName + ((char)ThisFileBytes[i + 4]).ToString();    //5
                ECUName = ECUName + ((char)ThisFileBytes[i + 5]).ToString();    //-
                ECUName = ECUName + ((char)ThisFileBytes[i + 6]).ToString();    //X
                ECUName = ECUName + ((char)ThisFileBytes[i + 7]).ToString();    //X
                ECUName = ECUName + ((char)ThisFileBytes[i + 8]).ToString();    //X
                ECUName = ECUName + ((char)ThisFileBytes[i + 9]).ToString();    //-
                ECUName = ECUName + ((char)ThisFileBytes[i + 10]).ToString();   //X
                ECUName = ECUName + ((char)ThisFileBytes[i + 11]).ToString();   //X
                ECUName = ECUName + ((char)ThisFileBytes[i + 12]).ToString();   //X
                ECUName = ECUName + ((char)ThisFileBytes[i + 13]).ToString();   //X
            }
        }

        return ECUName;
    }

    public int ExtractECUNameLocationFromThisFile(byte[] ThisFileBytes)
    {
        int Locationn = -1;
        for (int i = 0; i < ThisFileBytes.Length - 12; i++)
        {
            //37805-
            if ((char)ThisFileBytes[i] == '3'
                && (char)ThisFileBytes[i + 1] == '7'
                && (char)ThisFileBytes[i + 2] == '8'
                && (char)ThisFileBytes[i + 3] == '0'
                && (char)ThisFileBytes[i + 4] == '5'
                && (char)ThisFileBytes[i + 5] == '-'
                && (char)ThisFileBytes[i + 10] != 'Z')
            {
                Locationn = i;
            }
        }

        return Locationn;
    }


    public void LoadThisFile(string ThisFilePath)
    {
        this.Text = "Honda Rom Tables Editor (" + this.GForm_Main_0.Version + ") | " + Path.GetFileName(ThisFilePath);

        string LastOpenFilePath = Application.StartupPath + @"\LastFileOpened.txt";
        File.Create(LastOpenFilePath).Dispose();
        File.WriteAllText(LastOpenFilePath, ThisFilePath);
        this.IsFullBinary = false;

        byte[] FilesBytes = File.ReadAllBytes(ThisFilePath);
        this.Editortable_0.LoadedFilename = ThisFilePath;
        if ((FilesBytes.Length - 1) == 0xFFFFF) this.IsFullBinary = true;
        if ((FilesBytes.Length - 1) == 0x1FFFFF) this.IsFullBinary = true;
        if ((FilesBytes.Length - 1) == 0x27FFFF) this.IsFullBinary = true;
        //if ((FilesBytes.Length - 1) == 0x3FFFFF) this.IsFullBinary = true;

        ClassEditor_0.SetFileFormat(FilesBytes);

        //Console.WriteLine("calib: " + (FilesBytes.Length - 1).ToString("X"));
        //Console.WriteLine("full: " + (FilesBytes.Length - 1 + 0xA0010000).ToString("X"));

        //Load BootLoader Sum byte for decrypted firmware (not a full binary rom)    
        if ((FilesBytes.Length - 1) == 0xF7FFF || (FilesBytes.Length - 1) == 0x1EFFFF || (FilesBytes.Length - 1) == 0x26FFFF)
        {
            int BtSumInt = CheckForBootLoaderSum(ExtractECUNameFromThisFile(FilesBytes));
            if (BtSumInt == -1)
            {
                DarkMessageBox.Show(this, "Since this decompressed firmware .bin file is missing the bootloader section\nSelect the firmware .rwd file from which is as been decompressed from", "MISSING BOOTLOADER SECTION FOR CHECKSUMS VERIFICATIONS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //Open RWD firmware
                openFileDialog1.Filter = "Honda Compressed RWD Firmware|*.gz;*.rwd";
                openFileDialog1.DefaultExt = "*.gz";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Class_RWD.LoadRWD(openFileDialog1.FileName, true, false, true);
                }
            }
            else
            {
                Class_RWD.BootloaderSum = (byte)BtSumInt;
            }
        }

        //Load File
        if ((FilesBytes.Length - 1) == 0xF7FFF
            || (FilesBytes.Length - 1) == 0xFFFFF
            || (FilesBytes.Length - 1) == 0x1EFFFF
            || (FilesBytes.Length - 1) == 0x1FFFFF
            || (FilesBytes.Length - 1) == 0x26FFFF
            || (FilesBytes.Length - 1) == 0x27FFFF)     //0x3FFFFF
        {
            //Load Binary into ROM Table Editor
            this.method_1();
        }
        else
        {
            //Console.WriteLine((FilesBytes.Length - 1).ToString("X"));
            DarkMessageBox.Show(this, "This file is not compatible!");
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            LoadThisFile(openFileDialog1.FileName);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        DialogResult result = saveFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            this.ClassEditor_0.SaveROMBytes(saveFileDialog1.FileName);
        }
    }

    public void CheckDefinitionFolderExist()
    {
        string Paath = Application.StartupPath + @"\Definitions";
        if (!Directory.Exists(Paath))
        {
            Directory.CreateDirectory(Paath);
            File.WriteAllBytes(Paath + @"\37805_RRB_A140.txt", FlashToolTest.Properties.Resources._37805_RRB_A140);
            File.WriteAllBytes(Paath + @"\37805_RWC_A620.txt", FlashToolTest.Properties.Resources._37805_RWC_A620);
            File.WriteAllBytes(Paath + @"\37805_S2K.txt", FlashToolTest.Properties.Resources._37805_S2K);
            File.WriteAllBytes(Paath + @"\DefinitionsGuide.txt", FlashToolTest.Properties.Resources.DefinitionsGuide);
        }
    }

    private void openDefinitionsFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CheckDefinitionFolderExist();
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
        {
            FileName = Application.StartupPath + @"\Definitions",
            UseShellExecute = true,
            Verb = "open"
        });
    }

    private void increaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ClassEditor_0.IncDecreaseSelection(false, false);
    }

    private void decreaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ClassEditor_0.IncDecreaseSelection(true, false);
    }

    private void fixChecksumsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ClassEditor_0.FixChecksums();
    }



    private void generateDefinitionsFilesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DarkMessageBox.Show(this, "Select the folder where all decrypted firmwares .bin are located.", "Select firmwares folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        DialogResult result = folderBrowserDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            GForm_Main_0.Class_DefinitionMaker_0.FirmwareFolder = folderBrowserDialog1.SelectedPath;
            GForm_Main_0.Class_DefinitionMaker_0.CreateDefinitionsFiles();
        }
    }

    private void getDifferencesInAllFirmwaresFilesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DarkMessageBox.Show(this, "Select the folder where all decrypted firmwares .bin are located.", "Select firmwares folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        DialogResult result = folderBrowserDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            GForm_Main_0.Class_DefinitionMaker_0.FirmwareFolder = folderBrowserDialog1.SelectedPath;
            GForm_Main_0.Class_DefinitionMaker_0.GetFilesDifferenceCount();
        }
    }

    private void extractAllBootloadersumByteFromAllFirmwaresFilesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //DarkMessageBox.Show(this, "Select the folder where all decrypted firmwares .bin are located.", "Select firmwares folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        DarkMessageBox.Show(this, "Select the folder where all RWD(.gz) files are located.", "Select firmwares folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        DialogResult result = folderBrowserDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            GForm_Main_0.Class_DefinitionMaker_0.FirmwareFolder = folderBrowserDialog1.SelectedPath;
            GForm_Main_0.Class_DefinitionMaker_0.ExtractAllBootLoaderSum();
        }
    }

    private void extractDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GForm_Main_0.Class_DefinitionMaker_0.Extract("Definition");
        if (GForm_Main_0.Class_DefinitionMaker_0.CurrentExtractedDumps > 1) GForm_Main_0.Class_DefinitionMaker_0.CreateExtractedDefinition();
    }

    [CompilerGenerated]
    private sealed class Class5
    {

        public Class5()
        {
        }


        internal void method_0()
        {
            this.Editortable_0.darkTextBox_0.AppendText(this.string_0 + Environment.NewLine);
        }


        public Editortable Editortable_0;


        public string string_0;
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //this.ClassEditor_0.AllROMDifferences.Contains(Environment.NewLine)
        if (this.ClassEditor_0.AllROMDifferences != "")
        {
            string[] lines = this.ClassEditor_0.AllROMDifferences.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (lines.Length > 0)
            {
                for (int i = lines.Length - 1; i >= 0; i--)
                {
                    if (lines[i] != "")
                    {
                        string CommandsLine = lines[i].Replace(" ", "");
                        if (CommandsLine.Contains(":"))
                        {
                            string[] CmdsSpli1 = CommandsLine.Split(':');
                            int Index = int.Parse(CmdsSpli1[1].Split('[')[0]);
                            string RemainingCmds = CmdsSpli1[1].Split('[')[1].Replace("->", ";");
                            int num1 = int.Parse(RemainingCmds.Split(';')[0]);
                            int num2 = int.Parse(RemainingCmds.Split(';')[1].Split(']')[0]);
                            int intLocationnValue = int.Parse(CmdsSpli1[2].Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                            //Apply Changes
                            this.ClassEditor_0.ROM_Bytes[intLocationnValue] = (byte)num1;

                            //Send Logs
                            string BufText = "Undo change at line: " + Index.ToString() + "[" + num2.ToString("X2") + "->" + num1.ToString("X2") + "] | At: 0x" + (intLocationnValue).ToString("X") + Environment.NewLine;
                            GForm_Main_0.method_1(BufText);

                            //Remove from rom differences (string list)
                            string BufferROMDiff = "";
                            if (i > 0)
                            {
                                for (int i2 = 0; i2 < i; i2++) BufferROMDiff = BufferROMDiff + lines[i2];
                                this.ClassEditor_0.AllROMDifferences = BufferROMDiff;
                            }

                            //add to Redo list
                            this.ClassEditor_0.AllROMDifferencesRedo = this.ClassEditor_0.AllROMDifferencesRedo + lines[i] + Environment.NewLine;
                            redoToolStripMenuItem.Enabled = true;

                            //return
                            i = -1;
                        }
                    }
                }
            }
        }
    }

    private void redoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.ClassEditor_0.AllROMDifferencesRedo != "")
        {
            string[] lines = this.ClassEditor_0.AllROMDifferencesRedo.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (lines.Length > 0)
            {
                for (int i = lines.Length - 1; i >= 0; i--)
                {
                    if (lines[i] != "")
                    {
                        string CommandsLine = lines[i].Replace(" ", "");
                        if (CommandsLine.Contains(":"))
                        {
                            string[] CmdsSpli1 = CommandsLine.Split(':');
                            int Index = int.Parse(CmdsSpli1[1].Split('[')[0]);
                            string RemainingCmds = CmdsSpli1[1].Split('[')[1].Replace("->", ";");
                            int num1 = int.Parse(RemainingCmds.Split(';')[0]);
                            int num2 = int.Parse(RemainingCmds.Split(';')[1].Split(']')[0]);
                            int intLocationnValue = int.Parse(CmdsSpli1[2].Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

                            //Apply Changes
                            this.ClassEditor_0.ROM_Bytes[intLocationnValue] = (byte)num2;

                            //Send Logs
                            string BufText = "Redo change at line: " + Index.ToString() + "[" + num1.ToString("X2") + "->" + num2.ToString("X2") + "] | At: 0x" + (intLocationnValue).ToString("X") + Environment.NewLine;
                            GForm_Main_0.method_1(BufText);

                            //Remove from Redo list
                            string BufferROMDiff = "";
                            if (i > 0)
                            {
                                for (int i2 = 0; i2 < i; i2++) BufferROMDiff = BufferROMDiff + lines[i2];
                                this.ClassEditor_0.AllROMDifferencesRedo = BufferROMDiff;
                            }

                            //add to rom differences (string list)
                            this.ClassEditor_0.AllROMDifferences = this.ClassEditor_0.AllROMDifferences + lines[i] + Environment.NewLine;

                            if (this.ClassEditor_0.AllROMDifferencesRedo == "") redoToolStripMenuItem.Enabled = false;

                            //return
                            i = -1;
                        }
                    }
                }
            }
        }
    }

    private void removeBootloaderInbinToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DarkMessageBox.Show(this, "Select the file to remove the Bootloader(Start) section from\nThe created .bin with removed bootloader can now be used as a 'decrypted firmware .bin'\nYou can also remake a firmware .rwd update file from this .bin and use it to flash on the ECU!", "Select full binary rom .bin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            byte[] FilesBytes = File.ReadAllBytes(openFileDialog1.FileName);
            ClassEditor_0.SetFileFormat(FilesBytes);

            if (ClassEditor_0.FileFormat == "1mb-full" || ClassEditor_0.FileFormat == "2mb-full" || ClassEditor_0.FileFormat == "4mb-full")
            {
                byte[] FilesBytesRWD = new byte[] { };
                if (ClassEditor_0.FileFormat == "1mb-full")
                {
                    FilesBytesRWD = new byte[FilesBytes.Length - 0x8000];
                    for (int i = 0; i < FilesBytesRWD.Length; i++) FilesBytesRWD[i] = FilesBytes[i + 0x8000];
                }
                if (ClassEditor_0.FileFormat == "2mb-full" || ClassEditor_0.FileFormat == "4mb-full")
                {
                    FilesBytesRWD = new byte[FilesBytes.Length - 0x10000];
                    for (int i = 0; i < FilesBytesRWD.Length; i++) FilesBytesRWD[i] = FilesBytes[i + 0x10000];
                }

                string SaveeePath = Path.GetDirectoryName(openFileDialog1.FileName) + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "_NoBootloader.bin";
                File.Create(SaveeePath).Dispose();
                File.WriteAllBytes(SaveeePath, FilesBytesRWD);

                GForm_Main_0.method_1("Removed Bootloader file created: " + SaveeePath);
            }
            else
            {
                Console.WriteLine((FilesBytes.Length - 1).ToString("X"));
                DarkMessageBox.Show(this, "This file is not compatible!");
            }
        }
    }

    private void generateDefinitionFileFromExtractedDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GForm_Main_0.Class_DefinitionMaker_0.CurrentExtractedDumps = 2;
        GForm_Main_0.Class_DefinitionMaker_0.CreateExtractedDefinition();
    }

    private void extractbinFileFromFPMToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*GForm_ExtractSize GForm_ExtractSize_0 = new GForm_ExtractSize();
        DialogResult result = GForm_ExtractSize_0.ShowDialog();
        if (result == DialogResult.OK)
        {
            if (GForm_ExtractSize_0.comboBox1.SelectedIndex == 0) GForm_Main_0.Class_DefinitionMaker_0.ExtractMemorySize = 0xF7FFF;
            if (GForm_ExtractSize_0.comboBox1.SelectedIndex == 1) GForm_Main_0.Class_DefinitionMaker_0.ExtractMemorySize = 0x1EFFFF;
            if (GForm_ExtractSize_0.comboBox1.SelectedIndex == 2) GForm_Main_0.Class_DefinitionMaker_0.ExtractMemorySize = 0x26FFFF;
            GForm_Main_0.Class_DefinitionMaker_0.Extract("Bin");
        }*/
        GForm_Main_0.Class_DefinitionMaker_0.Extract("Bin");
    }

    private void convertrwdTobinToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GForm_Main_0.darkButton2_Click_1(sender, e);
    }

    private void convertbinTorwdToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GForm_Main_0.darkButton3_Click_1(sender, e);
    }

    private void openOBD2ScanToolToolStripMenuItem_Click(object sender, EventArgs e)
    {
        GForm_Main_0.darkButton5_Click(sender, e);
    }
}

