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

public class Editortable : DarkForm
{
    private string vssUnits_0 = "KPH";
    private Editortable Editortable_0;
    private IContainer icontainer_0;
    private IContainer icontainer_1;
    public bool bool_0 = true;
    public static float float_0 = 1f;
    private List<string> list_0 = new List<string>();
    public static float[] float_1 = new float[2];
    private TableLayoutPanel tableLayoutPanel1;
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
    private ToolStripMenuItem redoToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem increaseSelectionToolStripMenuItem;
    private ToolStripMenuItem decreaseSelectionToolStripMenuItem;

    internal Editortable(ref GForm_Main GForm_Main_1)
    {
        GForm_Main_0 = GForm_Main_1;

        this.InitializeComponent();

        Editortable_0 = this;

        if (this.ClassEditor_0 != null) this.ClassEditor_0 = null;
        this.ClassEditor_0 = new ClassEditor(ref Editortable_0);


        this.Text = this.Text + " (" + this.GForm_Main_0.Version + ")";
    }

    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editortable));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).BeginInit();
            this.darkToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 517F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1100, 517);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.EvenNodeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.treeView1.FocusedNodeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = null;
            this.treeView1.Location = new System.Drawing.Point(2, 2);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.MaxDragChange = 20;
            this.treeView1.Name = "treeView1";
            this.treeView1.NonFocusedNodeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.treeView1.OddNodeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.SelectWithArrowKeys = false;
            this.treeView1.Size = new System.Drawing.Size(256, 513);
            this.treeView1.TabIndex = 2;
            this.treeView1.SelectedNodesChanged += new System.EventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox1.Controls.Add(this.dataGridView_0);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(262, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(836, 513);
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
            this.dataGridView_0.ReadOnly = true;
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
            this.dataGridView_0.Size = new System.Drawing.Size(832, 496);
            this.dataGridView_0.TabIndex = 4;
            this.dataGridView_0.TabStop = false;
            this.dataGridView_0.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellValueChanged);
            this.dataGridView_0.DoubleClick += new System.EventHandler(this.method_3);
            this.dataGridView_0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.method_4);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.bin";
            this.openFileDialog1.Filter = "Honda full binary rom file|*.bin|Honda decompressed firmware binary|*.bin";
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
            this.toolStripDropDownButton2});
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
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.redoToolStripMenuItem.Text = "Redo";
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
            // Editortable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 545);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.darkToolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Editortable";
            this.Text = "Honda Rom Tables Editor";
            this.Load += new System.EventHandler(this.Editortable_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).EndInit();
            this.darkToolStrip1.ResumeLayout(false);
            this.darkToolStrip1.PerformLayout();
            this.ResumeLayout(false);

    }

    public void Editortable_Load(object sender, EventArgs e)
    {
        this.CreateRightClicMenu();
    }

    public bool LoadDefinitionsFor(string string_9)
    {
        ClassEditor_0.LoadSupportedECUDefinitions();

        for (int i = 0; i < ClassEditor_0.Ecus_Definitions_Compatible.Count; i++)
        {
            if (ClassEditor_0.Ecus_Definitions_Compatible[i] == string_9)
            {
                ClassEditor_0.LoadThisECUDefinitions(string_9);

                foreach (string str2 in ClassEditor_0.DefinitionsName)
                {
                    this.list_0.Add(str2);
                }
                return true;
            }
        }

        return false;
    }

    public void method_1()
    {
        ClassEditor_0.bool_1 = false;
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
            this.SetNodesImages();
        }
        ClassEditor_0.bool_1 = true;
    }

    private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (ClassEditor_0.bool_1)
        {
            ClassEditor_0.bool_2 = true;
            ClassEditor_0.SetBackColor(dataGridView_0.Columns.Count, float_1[0], float_1[1]);
        }
    }

    public void SetNodesImages()
    {
        this.treeView1.Nodes.Clear();
        int num = 0;

        //Makes Nodes
        foreach (string str in this.list_0)
        {
            DarkTreeNode ThisNode = new DarkTreeNode();
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
    }

    private void method_3(object sender, EventArgs e)
    {
        dataGridView_0.ReadOnly = false;
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

        if ((this.treeView1.SelectedNode != null) && ClassEditor_0.bool_1)
        {
            ClassEditor_0.bool_1 = false;
            //##################################################################################
            if (ClassEditor_0.bool_2 && ClassEditor_0.SelectedTableSize != 0 && ClassEditor_0.SelectedROMLocation != 0)
            {
                ClassEditor_0.GetChanges();
                ClassEditor_0.string_2 = ClassEditor_0.string_2 + ClassEditor_0.string_3 + Environment.NewLine;
            }
            ClassEditor_0.bool_2 = false;
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
                    ClassEditor_0.bool_1 = true;
                    return;
                }

                //Empty 'Main' Node -> Select first child node
                if (ClassEditor_0.DefinitionsTableSize[NodeIndex] == "")
                {
                    try
                    {
                        ClassEditor_0.bool_1 = true;
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

                //Set X rom location
                int ParamLocation = ClassEditor_0.HexStringToInt(ClassEditor_0.DefinitionsLocationsX[NodeIndex]);

                //Set Y Headers (normal header mode)
                int DoingThisSize = TableSizze[0];
                if (ClassEditor_0.DefinitionsIsInverted[NodeIndex]) DoingThisSize = TableSizze[1];

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
                    int ParamHeaderLocation = ClassEditor_0.HexStringToInt(NewHeaderLocation);
                    textArray1 = ClassEditor_0.GetAdvancedHeader(TableSizze[0], ParamHeaderLocation, ClassEditor_0.DefinitionsMathY[NodeIndex], ClassEditor_0.DefinitionsFormatY[NodeIndex]);
                }

                //Show Value in Datagridview
                ClassEditor_0.SetTableValues(TableSizze, ParamLocation, ClassEditor_0.DefinitionsUnit1[NodeIndex], ClassEditor_0.DefinitionsUnit2[NodeIndex], textArray1, ClassEditor_0.DefinitionsMathX[NodeIndex], ClassEditor_0.DefinitionsFormatX[NodeIndex], ClassEditor_0.DefinitionsIsInverted[NodeIndex], ClassEditor_0.HexStringToInt(ClassEditor_0.DefinitionsLocationsTable[NodeIndex]), ClassEditor_0.DefinitionsMathTable[NodeIndex], ClassEditor_0.DefinitionsFormatTable[NodeIndex]);
            }
        }

        ClassEditor_0.bool_1 = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            if (openFileDialog1.FilterIndex == 1)
            {
                byte[] FilesBytes = File.ReadAllBytes(openFileDialog1.FileName);
                if ((FilesBytes.Length - 1) == 0xFFFFF)
                {
                    this.Editortable_0.LoadedFilename = openFileDialog1.FileName;
                    this.IsFullBinary = true;

                    //Load Binary into ROM Table Editor
                    this.Editortable_0.method_1();
                }
                else
                {
                    DarkMessageBox.Show(this, "This file is not compatible!");
                }
            }
            if (openFileDialog1.FilterIndex == 2)
            {
                byte[] FilesBytes = File.ReadAllBytes(openFileDialog1.FileName);
                if ((FilesBytes.Length - 1) == 0xF7FFF)
                {
                    this.Editortable_0.LoadedFilename = openFileDialog1.FileName;
                    this.IsFullBinary = false;

                    DarkMessageBox.Show(this, "Since this decompressed firmware .bin file is missing the bootloader section\nSelect the firmware .rwd file from which is as been decompressed from", "MISSING BOOTLOADER SECTION FOR CHECKSUMS VERIFICATIONS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //Open RWD firmware
                    openFileDialog1.Filter = "Honda Compressed RWD Firmware|*.gz;*.rwd";
                    openFileDialog1.DefaultExt = "*.gz";
                    result = openFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Class_RWD.LoadRWD(openFileDialog1.FileName, true, false);
                    }

                    //Load Binary into ROM Table Editor
                    this.Editortable_0.method_1();
                }
                else
                {
                    Console.WriteLine((FilesBytes.Length - 1).ToString("X"));
                    DarkMessageBox.Show(this, "This file is not compatible!");
                }
            }
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
}

