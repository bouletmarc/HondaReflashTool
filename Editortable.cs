using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    private Timer timer_0 = new Timer();
    private List<string> list_0 = new List<string>();
    public string[] string_0 = new string[] { "6.00", "8.00", "12.00", "14.00", "16.00" };
    public string[] string_1;
    public string[] string_2;
    public string string_3;
    public string[] string_4;
    public string[] string_5;
    private string[] string_6;
    private string[] string_7;
    public static float[] float_1 = new float[2];
    private TableLayoutPanel tableLayoutPanel1;
    private DarkTreeView treeView1;
    private DarkGroupBox groupBox1;
    private DarkGroupBox groupBox2;
    public DataGridView dataGridView_0;
    internal ClassEditor ClassEditor_0;
    public string string_8;
    public bool IsFullBinary = true;
    public static ImageList imageList_0;
    public static GEnum2 genum2_0 = GEnum2.TIMING_LOW;
    public int int_0;
    public int int_1;
    public int LastPackageChecksum;
    private SplitContainer splitContainer1;
    private DarkButton button2;
    private DarkButton button1;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    public GForm_Main GForm_Main_0;
    public System.Windows.Forms.Timer timer_1 = new System.Windows.Forms.Timer();

    //internal Editortable(ref Class10_settings class10_1, ref Class39 Class39_1)
    internal Editortable(ref GForm_Main GForm_Main_1)
    {
        GForm_Main_0 = GForm_Main_1;

        this.timer_1.Interval = 0xbb8;
        this.timer_1.Tick += new EventHandler(this.timer_1_Tick);

        string[] textArray2 = new string[15];
        textArray2[0] = "1233";
        textArray2[1] = "1669";
        textArray2[2] = "2037";
        textArray2[3] = "2495";
        textArray2[4] = "2750";
        textArray2[5] = "2890";
        textArray2[6] = "3015";
        textArray2[7] = "3126";
        textArray2[8] = "3225";
        textArray2[9] = "3356";
        textArray2[10] = "3505";
        textArray2[11] = "3629";
        textArray2[12] = "3736";
        textArray2[13] = "4009";
        textArray2[14] = "4188";
        this.string_1 = textArray2;
        this.string_2 = new string[] { "1", "2", "3", "4", "5-6" };
        this.string_3 = "Speed Limiter";
        this.string_4 = new string[] { "Enable Low", "Disable Low", "Enable High", "Disable High" };
        this.string_5 = new string[] { "Rev Limit" };
        string[] textArray6 = new string[0x42];
        textArray6[0] = "Mass Airflow Conversion Curve";
        textArray6[1] = "LAF Voltage to Lambda";
        textArray6[2] = "MAF Load Limit";
        textArray6[3] = "AFM Fuel";
        textArray6[4] = "--Fuel Value 1";
        textArray6[5] = "--Fuel Value 2";
        textArray6[6] = "Injector Voltage Compensation";
        textArray6[7] = "Minimum IPW";
        textArray6[8] = "Lambda Target Low Cam";
        textArray6[9] = "--Target 1";
        textArray6[10] = "--Target 2";
        textArray6[11] = "--Target 3";
        textArray6[12] = "Lambda Target High Cam";
        textArray6[13] = "--Target 1";
        textArray6[14] = "--Target 2";
        textArray6[15] = "--Target 3";
        textArray6[0x10] = "Cam Angle VTC Low";
        textArray6[0x11] = "Ignition Timing VTC Low";
        textArray6[0x12] = "--00\x00b0";
        textArray6[0x13] = "--10\x00b0";
        textArray6[20] = "--20\x00b0";
        textArray6[0x15] = "--30\x00b0";
        textArray6[0x16] = "--40\x00b0";
        textArray6[0x17] = "Knock Limit Low";
        textArray6[0x18] = "--00\x00b0";
        textArray6[0x19] = "--10\x00b0";
        textArray6[0x1a] = "--20\x00b0";
        textArray6[0x1b] = "--30\x00b0";
        textArray6[0x1c] = "--40\x00b0";
        textArray6[0x1d] = "Knock Retard Low";
        textArray6[30] = "Knock Sensitivity Low";
        textArray6[0x1f] = "Cam Angle VTC High";
        textArray6[0x20] = "Ignition Timing VTC High";
        textArray6[0x21] = "--00\x00b0";
        textArray6[0x22] = "--10\x00b0";
        textArray6[0x23] = "--20\x00b0";
        textArray6[0x24] = "--30\x00b0";
        textArray6[0x25] = "--40\x00b0";
        textArray6[0x26] = "Knock Limit High";
        textArray6[0x27] = "--00\x00b0";
        textArray6[40] = "--10\x00b0";
        textArray6[0x29] = "--20\x00b0";
        textArray6[0x2a] = "--30\x00b0";
        textArray6[0x2b] = "--40\x00b0";
        textArray6[0x2c] = "Knock Retard High";
        textArray6[0x2d] = "Knock Sensitivity High";
        textArray6[0x2e] = "VTEC Engagement";
        textArray6[0x2f] = "Revlimiter";
        textArray6[0x30] = "--Revlimiter 2";
        textArray6[0x31] = "--Revlimiter 3";
        textArray6[50] = "--Revlimiter 4";
        textArray6[0x33] = "--Revlimiter 5";
        textArray6[0x34] = "--Revlimiter 6";
        textArray6[0x35] = "--Revlimiter 7";
        textArray6[0x36] = "--Revlimiter 8";
        textArray6[0x37] = "--Revlimiter 9";
        textArray6[0x38] = "--Revlimiter 10";
        textArray6[0x39] = "Speedlimiter";
        textArray6[0x3a] = "Idle Speed";
        textArray6[0x3b] = "Post Start Idle Speed";
        textArray6[60] = "WOT Determiniation (MAP)";
        textArray6[0x3d] = "WOT Determiniation 1(TPS)";
        textArray6[0x3e] = "WOT Determiniation 2(TPS)";
        textArray6[0x3f] = "Overrun Fuel Cut(Gear Determiniation)";
        textArray6[0x40] = "Throttle Response 1";
        textArray6[0x41] = "Throttle Response 2";
        this.string_6 = textArray6;
        this.string_7 = new string[] { "Fuel Low Cam", "Fuel High Cam", "Ignition Timing Low Cam", "Ignition Timing High Cam", "VTEC Engagement", "Revlimiter", "Injector Voltage Compensation" };
        this.int_1 = 1;
        this.InitializeComponent();

        //Class39_0 = Class39_1;
        Editortable_0 = this;

        if (this.ClassEditor_0 != null) this.ClassEditor_0 = null;
        this.ClassEditor_0 = new ClassEditor(ref Editortable_0);
    }

    private void timer_1_Tick(object sender, EventArgs e)
    {
    }

    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editortable));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.dataGridView_0 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.button2 = new DarkUI.Controls.DarkButton();
            this.button1 = new DarkUI.Controls.DarkButton();
            this.treeView1 = new DarkUI.Controls.DarkTreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 433);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.groupBox1.Size = new System.Drawing.Size(601, 429);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table:";
            // 
            // dataGridView_0
            // 
            this.dataGridView_0.AllowUserToAddRows = false;
            this.dataGridView_0.AllowUserToDeleteRows = false;
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
            this.dataGridView_0.RowHeadersWidth = 72;
            this.dataGridView_0.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_0.RowTemplate.Height = 31;
            this.dataGridView_0.Size = new System.Drawing.Size(597, 412);
            this.dataGridView_0.TabIndex = 4;
            this.dataGridView_0.TabStop = false;
            this.dataGridView_0.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.method_2);
            this.dataGridView_0.DoubleClick += new System.EventHandler(this.method_3);
            this.dataGridView_0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.method_4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(254, 427);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(254, 68);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File:";
            // 
            // button2
            // 
            this.button2.Checked = false;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(2, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save .bin file";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Checked = false;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(2, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open .bin file";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.ControlDark;
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
            this.treeView1.Size = new System.Drawing.Size(254, 355);
            this.treeView1.TabIndex = 2;
            this.treeView1.SelectedNodesChanged += new System.EventHandler(this.treeView1_AfterSelect);
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
            // Editortable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Editortable";
            this.Text = "Honda Rom Tables Editor";
            this.Load += new System.EventHandler(this.Editortable_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    public void Editortable_Load(object sender, EventArgs e)
    {
        this.Text = "Honda Rom Tables Editor";
        this.timer_0.Interval = 500;
        this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        this.method_5();
    }

    public bool method_0(string string_9)
    {
        if (string_9.Contains("RRB"))
        {
            ClassEditor_0.smethod_37();
            this.method_34(GEnum3.RRB140);
            return true;
        }
        if (!string_9.Contains("S2K"))
        {
            return false;
        }
        ClassEditor_0.smethod_36();
        this.method_34(GEnum3.S2K);
        return true;
    }

    public void method_1()
    {
        if (!ClassEditor_0.smethod_17(string_8))
        {
            DarkMessageBox.Show("Failed to open Binary file.");
            ClassEditor_0.bool_1 = false;
        }
        else if (!this.method_0(ClassEditor_0.string_0))
        {
            DarkMessageBox.Show("No definition found for " + ClassEditor_0.string_0);
            ClassEditor_0.bool_1 = false;
        }
        else
        {
            this.method_28();
            if (ClassEditor_0.string_0.Contains("RRB"))
            {
                this.method_24();
            }
            if (ClassEditor_0.string_0.Contains("S2K"))
            {
                this.method_22();
            }
            ClassEditor_0.bool_1 = true;
        }
    }

    private void method_10(int int_2)
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = this.method_32(int_2, genum2_0);
            int num = ClassEditor_0.int_76;
            int num2 = ClassEditor_0.int_75;
            int num3 = this.method_29(int_2, genum2_0);
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    //dataGridView_0.TopLeftHeaderCell.DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDark;
                    int num6 = 0;
                    while (true)
                    {
                        if (num6 >= numArray[0])
                        {
                            int num4 = 0;
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = 10f;
                                            float_1[1] = 14.8f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = true;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        int num11 = ClassEditor_0.smethod_18(num2 + (num10 * 2));
                                        dataGridView_0.Rows[num10].HeaderCell.Value = (num11 * 0.013334).ToString("0.0");
                                        //dataGridView_0.Rows[num10].HeaderCell.DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDark;
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[20];
                                values[0] = ((128f / ((float) ClassEditor_0.int_95[num4])) * 14.7f).ToString("0.00");
                                values[1] = ((128f / ((float) ClassEditor_0.int_95[num4 + 1])) * 14.7f).ToString("0.00");
                                values[2] = ((128f / ((float) ClassEditor_0.int_95[num4 + 2])) * 14.7f).ToString("0.00");
                                values[3] = ((128f / ((float) ClassEditor_0.int_95[num4 + 3])) * 14.7f).ToString("0.00");
                                values[4] = ((128f / ((float) ClassEditor_0.int_95[num4 + 4])) * 14.7f).ToString("0.00");
                                values[5] = ((128f / ((float) ClassEditor_0.int_95[num4 + 5])) * 14.7f).ToString("0.00");
                                values[6] = ((128f / ((float) ClassEditor_0.int_95[num4 + 6])) * 14.7f).ToString("0.00");
                                values[7] = ((128f / ((float) ClassEditor_0.int_95[num4 + 7])) * 14.7f).ToString("0.00");
                                values[8] = ((128f / ((float) ClassEditor_0.int_95[num4 + 8])) * 14.7f).ToString("0.00");
                                values[9] = ((128f / ((float) ClassEditor_0.int_95[num4 + 9])) * 14.7f).ToString("0.00");
                                values[10] = ((128f / ((float) ClassEditor_0.int_95[num4 + 10])) * 14.7f).ToString("0.00");
                                values[11] = ((128f / ((float) ClassEditor_0.int_95[num4 + 11])) * 14.7f).ToString("0.00");
                                values[12] = ((128f / ((float) ClassEditor_0.int_95[num4 + 12])) * 14.7f).ToString("0.00");
                                values[13] = ((128f / ((float) ClassEditor_0.int_95[num4 + 13])) * 14.7f).ToString("0.00");
                                values[14] = ((128f / ((float) ClassEditor_0.int_95[num4 + 14])) * 14.7f).ToString("0.00");
                                values[15] = ((128f / ((float) ClassEditor_0.int_95[num4 + 15])) * 14.7f).ToString("0.00");
                                values[0x10] = ((128f / ((float) ClassEditor_0.int_95[num4 + 0x10])) * 14.7f).ToString("0.00");
                                values[0x11] = ((128f / ((float) ClassEditor_0.int_95[num4 + 0x11])) * 14.7f).ToString("0.00");
                                values[0x12] = ((128f / ((float) ClassEditor_0.int_95[num4 + 0x12])) * 14.7f).ToString("0.00");
                                values[0x13] = ((128f / ((float) ClassEditor_0.int_95[num4 + 0x13])) * 14.7f).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                num4 += 20;
                                rowIndex++;
                            }
                            break;
                        }
                        int num7 = ClassEditor_0.smethod_18(num + (num6 * 2));
                        dataGridView_0.Columns.Add(ClassEditor_0.smethod_18(num + (num6 * 2)).ToString(), num7.ToString());
                        num6++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_19(num3 + index);
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_11(int int_2)
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = this.method_32(int_2, genum2_0);
            int num = this.method_31(int_2, genum2_0);
            int num2 = this.method_30(int_2, genum2_0);
            int num3 = this.method_29(int_2, genum2_0);
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -10f;
                                            float_1[1] = 55f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_12(int int_2)
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = this.method_32(int_2, genum2_0);
            int num = this.method_31(int_2, genum2_0);
            int num2 = this.method_30(int_2, genum2_0);
            int num3 = this.method_29(int_2, genum2_0);
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -10f;
                                            float_1[1] = 55f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_13(int int_2)
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = this.method_32(int_2, genum2_0);
            int num = this.method_31(int_2, genum2_0);
            int num2 = this.method_30(int_2, genum2_0);
            int num3 = this.method_29(int_2, genum2_0);
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -25f;
                                            float_1[1] = 60f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_14(int int_2)
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = this.method_32(int_2, genum2_0);
            int num = this.method_31(int_2, genum2_0);
            int num2 = this.method_30(int_2, genum2_0);
            int num3 = this.method_29(int_2, genum2_0);
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -25f;
                                            float_1[1] = 80f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_15()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_192;
            int num = ClassEditor_0.int_182;
            int num2 = ClassEditor_0.int_183;
            int num3 = ClassEditor_0.int_189;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -5f;
                                            float_1[1] = 205f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_16()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_196;
            int num = ClassEditor_0.int_186;
            int num2 = ClassEditor_0.int_187;
            int num3 = ClassEditor_0.int_193;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -5f;
                                            float_1[1] = 205f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_17()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_184;
            int num = ClassEditor_0.int_182;
            int num2 = ClassEditor_0.int_183;
            int num3 = ClassEditor_0.int_181;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -5f;
                                            float_1[1] = 20f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = true;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_19(num3 + index);
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_18()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_188;
            int num = ClassEditor_0.int_186;
            int num2 = ClassEditor_0.int_187;
            int num3 = ClassEditor_0.int_185;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -5f;
                                            float_1[1] = 20f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = true;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_19(num3 + index);
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_19()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_102;
            int num = ClassEditor_0.int_100;
            int num2 = ClassEditor_0.int_101;
            int num3 = ClassEditor_0.int_99;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -10f;
                                            float_1[1] = 55f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_2(object sender, DataGridViewCellEventArgs e)
    {
        this.timer_0.Enabled = false;
        if (ClassEditor_0.bool_0)
        {
            this.timer_0.Enabled = true;
        }
    }

    private void method_20()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_106;
            int num = ClassEditor_0.int_104;
            int num2 = ClassEditor_0.int_105;
            int num3 = ClassEditor_0.int_103;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_95, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -10f;
                                            float_1[1] = 55f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_21()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_110;
            int num = ClassEditor_0.int_108;
            int num2 = ClassEditor_0.int_109;
            int num3 = ClassEditor_0.int_107;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_94, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        int num6;
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num9 = 0;
                                    while (true)
                                    {
                                        if (num9 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = 0f;
                                            float_1[1] = 500f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        num6 = ClassEditor_0.smethod_18(num2 + (num9 * 2));
                                        dataGridView_0.Rows[num9].HeaderCell.Value = num6.ToString();
                                        num9++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        dataGridView_0.Columns.Add(ClassEditor_0.smethod_18(num + (num5 * 2)).ToString(), num6.ToString());
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_94[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_22()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_114;
            int num = ClassEditor_0.int_112;
            int num2 = ClassEditor_0.int_113;
            int num3 = ClassEditor_0.int_111;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_94, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        int num6;
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num9 = 0;
                                    while (true)
                                    {
                                        if (num9 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = 0f;
                                            float_1[1] = 500f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        num6 = ClassEditor_0.smethod_18(num2 + (num9 * 2));
                                        dataGridView_0.Rows[num9].HeaderCell.Value = num6.ToString();
                                        num9++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        dataGridView_0.Columns.Add(ClassEditor_0.smethod_18(num + (num5 * 2)).ToString(), num6.ToString());
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_94[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_23()
    {
        try
        {
            int[] numArray = ClassEditor_0.int_41;
            int num = ClassEditor_0.int_39;
            int num2 = ClassEditor_0.int_40;
            int num3 = ClassEditor_0.int_38;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_94, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -10f;
                                            float_1[1] = 40f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.5f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_94[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_24()
    {
        try
        {
            int[] numArray = ClassEditor_0.int_45;
            int num = ClassEditor_0.int_43;
            int num2 = ClassEditor_0.int_44;
            int num3 = ClassEditor_0.int_42;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_94, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -10f;
                                            float_1[1] = 40f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.5f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num10].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num10 * 2)).ToString();
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[0, rowIndex] * 0.1).ToString("0.00");
                                values[1] = (numArray2[1, rowIndex] * 0.1).ToString("0.00");
                                values[2] = (numArray2[2, rowIndex] * 0.1).ToString("0.00");
                                values[3] = (numArray2[3, rowIndex] * 0.1).ToString("0.00");
                                values[4] = (numArray2[4, rowIndex] * 0.1).ToString("0.00");
                                values[5] = (numArray2[5, rowIndex] * 0.1).ToString("0.00");
                                values[6] = (numArray2[6, rowIndex] * 0.1).ToString("0.00");
                                values[7] = (numArray2[7, rowIndex] * 0.1).ToString("0.00");
                                values[8] = (numArray2[8, rowIndex] * 0.1).ToString("0.00");
                                values[9] = (numArray2[9, rowIndex] * 0.1).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        int num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        double num7 = num6 * 0.013334;
                        dataGridView_0.Columns.Add(num7.ToString("0.0"), num7.ToString("0.0"));
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_94[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_25()
    {
        try
        {
            int[] numArray = ClassEditor_0.int_29;
            int num = ClassEditor_0.int_28;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num;
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_0.ColumnCount = numArray[0];
            if (this.vssUnits_0 == "MPH")
            {
                dataGridView_0.Columns[0].HeaderText = "MPH";
                for (int i = 0; i < numArray[1]; i++)
                {
                    double num3 = Math.Floor((double) (((double) ClassEditor_0.smethod_18(num + (i * 2))) / 1.609));
                    object[] values = new object[] { num3.ToString() };
                    dataGridView_0.Rows.Add(values);
                    dataGridView_0.Rows[i].HeaderCell.Value = this.string_3.ToString();
                }
            }
            else
            {
                dataGridView_0.Columns[0].HeaderText = "KPH";
                for (int i = 0; i < numArray[1]; i++)
                {
                    int num5 = ClassEditor_0.smethod_18(num + (i * 2));
                    object[] values = new object[] { num5.ToString() };
                    dataGridView_0.Rows.Add(values);
                    dataGridView_0.Rows[i].HeaderCell.Value = this.string_3.ToString();
                }
            }
            dataGridView_0.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dataGridView_0.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = 80;
            }
            float_0 = 1f;
            ClassEditor_0.bool_3 = false;
            ClassEditor_0.bool_0 = true;
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_26()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_208;
            int num = ClassEditor_0.int_209;
            int num2 = ClassEditor_0.int_210;
            int num3 = ClassEditor_0.int_207;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_97, numArray[1], numArray[0]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num5 = 0;
                    while (true)
                    {
                        int num6;
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num9 = 0;
                                    while (true)
                                    {
                                        if (num9 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -50f;
                                            float_1[1] = 200f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        num6 = ClassEditor_0.smethod_18(num2 + (num9 * 2));
                                        dataGridView_0.Rows[num9].HeaderCell.Value = num6.ToString();
                                        num9++;
                                    }
                                    break;
                                }
                                object[] values = new object[10];
                                values[0] = (numArray2[rowIndex, 0] * 0.006).ToString("0.00");
                                values[1] = (numArray2[rowIndex, 1] * 0.006).ToString("0.00");
                                values[2] = (numArray2[rowIndex, 2] * 0.006).ToString("0.00");
                                values[3] = (numArray2[rowIndex, 3] * 0.006).ToString("0.00");
                                values[4] = (numArray2[rowIndex, 4] * 0.006).ToString("0.00");
                                values[5] = (numArray2[rowIndex, 5] * 0.006).ToString("0.00");
                                values[6] = (numArray2[rowIndex, 6] * 0.006).ToString("0.00");
                                values[7] = (numArray2[rowIndex, 7] * 0.006).ToString("0.00");
                                values[8] = (numArray2[rowIndex, 8] * 0.006).ToString("0.00");
                                values[9] = (numArray2[rowIndex, 9] * 0.006).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        num6 = ClassEditor_0.smethod_18(num + (num5 * 2));
                        dataGridView_0.Columns.Add(ClassEditor_0.smethod_18(num + (num5 * 2)).ToString(), num6.ToString());
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_97[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_27()
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = ClassEditor_0.int_214;
            int num = ClassEditor_0.int_212;
            int num2 = ClassEditor_0.int_213;
            int num3 = ClassEditor_0.int_211;
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    int[,] numArray2 = ClassEditor_0.smethod_35<int>(ClassEditor_0.int_98, numArray[0], numArray[1]);
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/KPH";
                    int num5 = 0;
                    while (true)
                    {
                        double num6;
                        if (num5 >= numArray[0])
                        {
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num8 = 0;
                                    while (true)
                                    {
                                        if (num8 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = -50f;
                                            float_1[1] = 200f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 1f;
                                            ClassEditor_0.bool_3 = false;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        dataGridView_0.Rows[num8].HeaderCell.Value = ClassEditor_0.smethod_18(num2 + (num8 * 2)).ToString();
                                        num8++;
                                    }
                                    break;
                                }
                                object[] values = new object[15];
                                values[0] = (numArray2[rowIndex, 0] * 0.006).ToString("0.00");
                                values[1] = (numArray2[rowIndex, 1] * 0.006).ToString("0.00");
                                values[2] = (numArray2[rowIndex, 2] * 0.006).ToString("0.00");
                                values[3] = (numArray2[rowIndex, 3] * 0.006).ToString("0.00");
                                values[4] = (numArray2[rowIndex, 4] * 0.006).ToString("0.00");
                                values[5] = (numArray2[rowIndex, 5] * 0.006).ToString("0.00");
                                values[6] = (numArray2[rowIndex, 6] * 0.006).ToString("0.00");
                                values[7] = (numArray2[rowIndex, 7] * 0.006).ToString("0.00");
                                values[8] = (numArray2[rowIndex, 8] * 0.006).ToString("0.00");
                                values[9] = (numArray2[rowIndex, 9] * 0.006).ToString("0.00");
                                values[10] = (numArray2[rowIndex, 10] * 0.006).ToString("0.00");
                                values[11] = (numArray2[rowIndex, 11] * 0.006).ToString("0.00");
                                values[12] = (numArray2[rowIndex, 12] * 0.006).ToString("0.00");
                                values[13] = (numArray2[rowIndex, 13] * 0.006).ToString("0.00");
                                num6 = numArray2[rowIndex, 14] * 0.006;
                                values[14] = num6.ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                rowIndex++;
                            }
                            break;
                        }
                        num6 = ClassEditor_0.smethod_18(num + (num5 * 2)) * 0.01;
                        dataGridView_0.Columns.Add((ClassEditor_0.smethod_18(num + (num5 * 2)) * 0.01).ToString(), num6.ToString());
                        num5++;
                    }
                    break;
                }
                ClassEditor_0.int_98[index] = ClassEditor_0.smethod_18(num3 + (index * 2));
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    public void method_28()
    {
        this.treeView1.Nodes.Clear();
        int num = 0;
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
        foreach (DarkTreeNode node in this.treeView1.Nodes)
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
                    if (node.Text.Contains("Fuel"))
                    {
                        node2.ImageKey = "Table";
                        node2.SelectedImageKey = "Table";
                        continue;
                    }
                    if (node.Text.Contains("Target"))
                    {
                        node2.ImageKey = "Table";
                        node2.SelectedImageKey = "Table";
                        continue;
                    }
                    node2.ImageKey = "Degree";
                    node2.SelectedImageKey = "Degree";
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
            }
            else if (node.Text.Contains("VTC High") || node.Text.Contains("Timing High Cam"))
            {
                node.ImageKey = "HighCam";
                node.SelectedImageKey = "HighCam";
            }
            else if (node.Text.Contains("VTC Low") || node.Text.Contains("Timing Low Cam"))
            {
                node.ImageKey = "LowCam";
                node.SelectedImageKey = "LowCam";
            }
            else if (node.Text.Contains("Fuel High"))
            {
                node.ImageKey = "HighFuel";
                node.SelectedImageKey = "HighFuel";
            }
            else if (node.Text.Contains("Fuel Low"))
            {
                node.ImageKey = "LowFuel";
                node.SelectedImageKey = "LowFuel";
            }
            else if (node.Text.Contains("Target High"))
            {
                node.ImageKey = "HighFuel";
                node.SelectedImageKey = "HighFuel";
            }
            else if (node.Text.Contains("Target Low"))
            {
                node.ImageKey = "LowFuel";
                node.SelectedImageKey = "LowFuel";
            }
            else if (node.Text.Contains("AFM Fuel"))
            {
                node.ImageKey = "LowFuel";
                node.SelectedImageKey = "LowFuel";
            }
            else if ((node.Text.Contains("VTEC") || node.Text.Contains("Idle")) || node.Text.Contains("WOT"))
            {
                node.ImageKey = "Vtec";
                node.SelectedImageKey = "Vtec";
            }
            else if (node.Text.Contains("Knock"))
            {
                node.ImageKey = "Knock";
                node.SelectedImageKey = "Knock";
            }
            else if (node.Text.Contains("Overrun"))
            {
                node.ImageKey = "Bang";
                node.SelectedImageKey = "Bang";
            }
            else if ((node.Text.Contains("Compensation") || node.Text.Contains("Conversion")) || node.Text.Contains("LAF"))
            {
                node.ImageKey = "Red";
                node.SelectedImageKey = "Red";
            }
        }
    }

    private int method_29(int int_2, GEnum2 genum2_1)
    {
        int num = 0;
        if (int_2 > 10)
        {
            if (int_2 == 20)
            {
                if (genum2_1 == GEnum2.TIMING_HIGH)
                {
                    num = ClassEditor_0.int_62;
                }
                else if (genum2_1 == GEnum2.TIMING_LOW)
                {
                    num = ClassEditor_0.int_82;
                }
                else if (genum2_1 == GEnum2.KNOCK_HIGH)
                {
                    num = ClassEditor_0.int_149;
                }
                else if (genum2_1 == GEnum2.KNOCK_LOW)
                {
                    num = ClassEditor_0.int_169;
                }
            }
            else if (int_2 == 30)
            {
                if (genum2_1 == GEnum2.TIMING_HIGH)
                {
                    num = ClassEditor_0.int_66;
                }
                else if (genum2_1 == GEnum2.TIMING_LOW)
                {
                    num = ClassEditor_0.int_86;
                }
                else if (genum2_1 == GEnum2.KNOCK_HIGH)
                {
                    num = ClassEditor_0.int_153;
                }
                else if (genum2_1 == GEnum2.KNOCK_LOW)
                {
                    num = ClassEditor_0.int_173;
                }
            }
            else if (int_2 == 40)
            {
                if (genum2_1 == GEnum2.TIMING_HIGH)
                {
                    num = ClassEditor_0.int_70;
                }
                else if (genum2_1 == GEnum2.TIMING_LOW)
                {
                    num = ClassEditor_0.int_90;
                }
                else if (genum2_1 == GEnum2.KNOCK_HIGH)
                {
                    num = ClassEditor_0.int_157;
                }
                else if (genum2_1 == GEnum2.KNOCK_LOW)
                {
                    num = ClassEditor_0.int_177;
                }
            }
        }
        else
        {
            switch (int_2)
            {
                case 0:
                    if (genum2_1 == GEnum2.TIMING_HIGH)
                    {
                        num = ClassEditor_0.int_54;
                    }
                    else if (genum2_1 == GEnum2.TIMING_LOW)
                    {
                        num = ClassEditor_0.int_74;
                    }
                    else if (genum2_1 == GEnum2.KNOCK_HIGH)
                    {
                        num = ClassEditor_0.int_141;
                    }
                    else if (genum2_1 == GEnum2.KNOCK_LOW)
                    {
                        num = ClassEditor_0.int_161;
                    }
                    break;

                case 1:
                    if (genum2_1 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        num = ClassEditor_0.int_127;
                    }
                    else if (genum2_1 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        num = ClassEditor_0.int_133;
                    }
                    else if (genum2_1 == GEnum2.AFM_FUEL)
                    {
                        num = ClassEditor_0.int_117;
                    }
                    break;

                case 2:
                    if (genum2_1 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        num = ClassEditor_0.int_129;
                    }
                    else if (genum2_1 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        num = ClassEditor_0.int_135;
                    }
                    else if (genum2_1 == GEnum2.AFM_FUEL)
                    {
                        num = ClassEditor_0.int_121;
                    }
                    break;

                case 3:
                    if (genum2_1 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        num = ClassEditor_0.int_131;
                    }
                    else if (genum2_1 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        num = ClassEditor_0.int_137;
                    }
                    break;

                default:
                    if (int_2 == 10)
                    {
                        if (genum2_1 == GEnum2.TIMING_HIGH)
                        {
                            num = ClassEditor_0.int_58;
                        }
                        else if (genum2_1 == GEnum2.TIMING_LOW)
                        {
                            num = ClassEditor_0.int_78;
                        }
                        else if (genum2_1 == GEnum2.KNOCK_HIGH)
                        {
                            num = ClassEditor_0.int_145;
                        }
                        else if (genum2_1 == GEnum2.KNOCK_LOW)
                        {
                            num = ClassEditor_0.int_165;
                        }
                    }
                    break;
            }
        }
        return num;
    }

    private void method_3(object sender, EventArgs e)
    {
        dataGridView_0.ReadOnly = false;
    }

    private int method_30(int int_2, GEnum2 genum2_1)
    {
        int num = 0;
        if (int_2 > 10)
        {
            if (int_2 == 20)
            {
                if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
                {
                    num = ClassEditor_0.int_64;
                }
                else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
                {
                    num = ClassEditor_0.int_84;
                }
            }
            else if (int_2 == 30)
            {
                if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
                {
                    num = ClassEditor_0.int_68;
                }
                else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
                {
                    num = ClassEditor_0.int_88;
                }
            }
            else if (int_2 == 40)
            {
                if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
                {
                    num = ClassEditor_0.int_72;
                }
                else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
                {
                    num = ClassEditor_0.int_92;
                }
            }
        }
        else
        {
            switch (int_2)
            {
                case 0:
                    if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
                    {
                        num = ClassEditor_0.int_56;
                    }
                    else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
                    {
                        num = ClassEditor_0.int_76;
                    }
                    break;

                case 1:
                    if (genum2_1 == GEnum2.AFM_FUEL)
                    {
                        num = ClassEditor_0.int_116;
                    }
                    break;

                case 2:
                    if (genum2_1 == GEnum2.AFM_FUEL)
                    {
                        num = ClassEditor_0.int_120;
                    }
                    break;

                default:
                    if (int_2 == 10)
                    {
                        if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
                        {
                            num = ClassEditor_0.int_60;
                        }
                        else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
                        {
                            num = ClassEditor_0.int_80;
                        }
                    }
                    break;
            }
        }
        return num;
    }

    private int method_31(int int_2, GEnum2 genum2_1)
    {
        int num = 0;
        if (int_2 <= 10)
        {
            if (int_2 == 0)
            {
                if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
                {
                    num = ClassEditor_0.int_55;
                }
                else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
                {
                    num = ClassEditor_0.int_75;
                }
            }
            else if (int_2 == 10)
            {
                if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
                {
                    num = ClassEditor_0.int_59;
                }
                else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
                {
                    num = ClassEditor_0.int_79;
                }
            }
        }
        else if (int_2 == 20)
        {
            if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
            {
                num = ClassEditor_0.int_63;
            }
            else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
            {
                num = ClassEditor_0.int_83;
            }
        }
        else if (int_2 == 30)
        {
            if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
            {
                num = ClassEditor_0.int_67;
            }
            else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
            {
                num = ClassEditor_0.int_87;
            }
        }
        else if (int_2 == 40)
        {
            if ((genum2_1 == GEnum2.TIMING_HIGH) || (genum2_1 == GEnum2.KNOCK_HIGH))
            {
                num = ClassEditor_0.int_71;
            }
            else if ((genum2_1 == GEnum2.TIMING_LOW) || (genum2_1 == GEnum2.KNOCK_LOW))
            {
                num = ClassEditor_0.int_91;
            }
        }
        return num;
    }

    private int[] method_32(int int_2, GEnum2 genum2_1)
    {
        int[] numArray = new int[0];
        if (int_2 > 10)
        {
            if (int_2 == 20)
            {
                if (genum2_1 == GEnum2.TIMING_HIGH)
                {
                    numArray = ClassEditor_0.int_65;
                }
                else if (genum2_1 == GEnum2.TIMING_LOW)
                {
                    numArray = ClassEditor_0.int_85;
                }
                else if (genum2_1 == GEnum2.KNOCK_HIGH)
                {
                    numArray = ClassEditor_0.int_152;
                }
                else if (genum2_1 == GEnum2.KNOCK_LOW)
                {
                    numArray = ClassEditor_0.int_172;
                }
            }
            else if (int_2 == 30)
            {
                if (genum2_1 == GEnum2.TIMING_HIGH)
                {
                    numArray = ClassEditor_0.int_69;
                }
                else if (genum2_1 == GEnum2.TIMING_LOW)
                {
                    numArray = ClassEditor_0.int_89;
                }
                else if (genum2_1 == GEnum2.KNOCK_HIGH)
                {
                    numArray = ClassEditor_0.int_156;
                }
                else if (genum2_1 == GEnum2.KNOCK_LOW)
                {
                    numArray = ClassEditor_0.int_176;
                }
            }
            else if (int_2 == 40)
            {
                if (genum2_1 == GEnum2.TIMING_HIGH)
                {
                    numArray = ClassEditor_0.int_73;
                }
                else if (genum2_1 == GEnum2.TIMING_LOW)
                {
                    numArray = ClassEditor_0.int_93;
                }
                else if (genum2_1 == GEnum2.KNOCK_HIGH)
                {
                    numArray = ClassEditor_0.int_160;
                }
                else if (genum2_1 == GEnum2.KNOCK_LOW)
                {
                    numArray = ClassEditor_0.int_180;
                }
            }
        }
        else
        {
            switch (int_2)
            {
                case 0:
                    if (genum2_1 == GEnum2.TIMING_HIGH)
                    {
                        numArray = ClassEditor_0.int_57;
                    }
                    else if (genum2_1 == GEnum2.TIMING_LOW)
                    {
                        numArray = ClassEditor_0.int_77;
                    }
                    else if (genum2_1 == GEnum2.KNOCK_HIGH)
                    {
                        numArray = ClassEditor_0.int_144;
                    }
                    else if (genum2_1 == GEnum2.KNOCK_LOW)
                    {
                        numArray = ClassEditor_0.int_164;
                    }
                    break;

                case 1:
                    if (genum2_1 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        numArray = ClassEditor_0.int_128;
                    }
                    else if (genum2_1 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        numArray = ClassEditor_0.int_134;
                    }
                    else if (genum2_1 == GEnum2.AFM_FUEL)
                    {
                        numArray = ClassEditor_0.int_118;
                    }
                    break;

                case 2:
                    if (genum2_1 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        numArray = ClassEditor_0.int_130;
                    }
                    else if (genum2_1 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        numArray = ClassEditor_0.int_136;
                    }
                    else if (genum2_1 == GEnum2.AFM_FUEL)
                    {
                        numArray = ClassEditor_0.int_122;
                    }
                    break;

                case 3:
                    if (genum2_1 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        numArray = ClassEditor_0.int_132;
                    }
                    else if (genum2_1 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        numArray = ClassEditor_0.int_138;
                    }
                    break;

                default:
                    if (int_2 == 10)
                    {
                        if (genum2_1 == GEnum2.TIMING_HIGH)
                        {
                            numArray = ClassEditor_0.int_61;
                        }
                        else if (genum2_1 == GEnum2.TIMING_LOW)
                        {
                            numArray = ClassEditor_0.int_81;
                        }
                        else if (genum2_1 == GEnum2.KNOCK_HIGH)
                        {
                            numArray = ClassEditor_0.int_148;
                        }
                        else if (genum2_1 == GEnum2.KNOCK_LOW)
                        {
                            numArray = ClassEditor_0.int_168;
                        }
                    }
                    break;
            }
        }
        return numArray;
    }

    private void method_34(GEnum3 genum3_0)
    {
        this.list_0.Clear();
        if (genum3_0 == GEnum3.RRB140)
        {
            foreach (string str in this.string_6)
            {
                this.list_0.Add(str);
            }
        }
        else if (genum3_0 == GEnum3.S2K)
        {
            foreach (string str2 in this.string_7)
            {
                this.list_0.Add(str2);
            }
        }
    }

    public string[] method_35(int int_2, int int_3)
    {
        string[] strArray = new string[int_2];
        for (int i = 0; i < int_2; i++)
        {
            strArray[i] = (ClassEditor_0.smethod_18(int_3 + (i * 2)) * 0.0048828125).ToString();
        }
        return strArray;
    }

    public string[] method_36(int int_2, int int_3)
    {
        string[] strArray = new string[int_2];
        for (int i = 0; i < int_2; i++)
        {
            strArray[i] = (ClassEditor_0.smethod_18(int_3 + (i * 2)) / 10).ToString();
        }
        return strArray;
    }

    private void method_4(object sender, KeyEventArgs e)
    {
        ClassEditor_0.smethod_3(e, 0);
    }

    public void method_5()
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
        ClassEditor_0.smethod_3(new KeyEventArgs(Keys.None), 2);
    }

    private void method_7(object sender, EventArgs e)
    {
        ClassEditor_0.smethod_3(new KeyEventArgs(Keys.None), 3);
    }

    private void method_8(int int_2)
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = this.method_32(int_2, genum2_0);
            int num = this.method_30(int_2, genum2_0);
            int num2 = this.method_29(int_2, genum2_0);
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num2;
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_0.TopLeftHeaderCell.Value = "AirMass (mg)";
            int num3 = 0;
            while (true)
            {
                double num4;
                if (num3 >= numArray[0])
                {
                    List<string> list = new List<string>();
                    int num5 = 0;
                    while (true)
                    {
                        if (num5 >= numArray[0])
                        {
                            object[] values = new object[] { list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7] };
                            dataGridView_0.Rows.Add(values);
                            dataGridView_0.Rows[0].HeaderCell.Value = "IPW (ms)";
                            dataGridView_0.AllowUserToAddRows = false;
                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                column.Width = 50;
                            }
                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                            {
                                row.Height = 20;
                            }
                            float_1[0] = 0f;
                            float_1[1] = 14f;
                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                            float_0 = 0.1f;
                            ClassEditor_0.bool_3 = false;
                            ClassEditor_0.bool_0 = true;
                            break;
                        }
                        num4 = ClassEditor_0.smethod_18(num2 + (num5 * 2)) * 0.002;
                        list.Add(num4.ToString("0.00"));
                        num5++;
                    }
                    break;
                }
                num4 = ClassEditor_0.smethod_18(num + (num3 * 2)) * 0.1;
                dataGridView_0.Columns.Add((ClassEditor_0.smethod_18(num + (num3 * 2)) * 0.1).ToString(), num4.ToString());
                num3++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    private void method_9(int int_2)
    {
        try
        {
            dataGridView_0.Rows.Clear();
            dataGridView_0.Columns.Clear();
            dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int[] numArray = this.method_32(int_2, genum2_0);
            int num = ClassEditor_0.int_56;
            int num2 = ClassEditor_0.int_55;
            int num3 = this.method_29(int_2, genum2_0);
            ClassEditor_0.int_1 = numArray[0] * numArray[1];
            ClassEditor_0.int_0 = num3;
            int index = 0;
            while (true)
            {
                if (index >= (numArray[0] * numArray[1]))
                {
                    dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                    int num6 = 0;
                    while (true)
                    {
                        if (num6 >= numArray[0])
                        {
                            int num4 = 0;
                            int rowIndex = 0;
                            while (true)
                            {
                                if (rowIndex >= numArray[1])
                                {
                                    int num10 = 0;
                                    while (true)
                                    {
                                        if (num10 >= numArray[1])
                                        {
                                            dataGridView_0.AllowUserToAddRows = false;
                                            foreach (DataGridViewColumn column in dataGridView_0.Columns)
                                            {
                                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                                                column.Width = 0x2a;
                                            }
                                            foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                                            {
                                                row.Height = 20;
                                            }
                                            float_1[0] = 10f;
                                            float_1[1] = 14.8f;
                                            ClassEditor_0.smethod_33(numArray[0], float_1[0], float_1[1]);
                                            float_0 = 0.1f;
                                            ClassEditor_0.bool_3 = true;
                                            ClassEditor_0.bool_0 = true;
                                            break;
                                        }
                                        int num11 = ClassEditor_0.smethod_18(num2 + (num10 * 2));
                                        dataGridView_0.Rows[num10].HeaderCell.Value = (num11 * 0.013334).ToString("0.0");
                                        num10++;
                                    }
                                    break;
                                }
                                object[] values = new object[20];
                                values[0] = ((128f / ((float) ClassEditor_0.int_95[num4])) * 14.7f).ToString("0.00");
                                values[1] = ((128f / ((float) ClassEditor_0.int_95[num4 + 1])) * 14.7f).ToString("0.00");
                                values[2] = ((128f / ((float) ClassEditor_0.int_95[num4 + 2])) * 14.7f).ToString("0.00");
                                values[3] = ((128f / ((float) ClassEditor_0.int_95[num4 + 3])) * 14.7f).ToString("0.00");
                                values[4] = ((128f / ((float) ClassEditor_0.int_95[num4 + 4])) * 14.7f).ToString("0.00");
                                values[5] = ((128f / ((float) ClassEditor_0.int_95[num4 + 5])) * 14.7f).ToString("0.00");
                                values[6] = ((128f / ((float) ClassEditor_0.int_95[num4 + 6])) * 14.7f).ToString("0.00");
                                values[7] = ((128f / ((float) ClassEditor_0.int_95[num4 + 7])) * 14.7f).ToString("0.00");
                                values[8] = ((128f / ((float) ClassEditor_0.int_95[num4 + 8])) * 14.7f).ToString("0.00");
                                values[9] = ((128f / ((float) ClassEditor_0.int_95[num4 + 9])) * 14.7f).ToString("0.00");
                                values[10] = ((128f / ((float) ClassEditor_0.int_95[num4 + 10])) * 14.7f).ToString("0.00");
                                values[11] = ((128f / ((float) ClassEditor_0.int_95[num4 + 11])) * 14.7f).ToString("0.00");
                                values[12] = ((128f / ((float) ClassEditor_0.int_95[num4 + 12])) * 14.7f).ToString("0.00");
                                values[13] = ((128f / ((float) ClassEditor_0.int_95[num4 + 13])) * 14.7f).ToString("0.00");
                                values[14] = ((128f / ((float) ClassEditor_0.int_95[num4 + 14])) * 14.7f).ToString("0.00");
                                values[15] = ((128f / ((float) ClassEditor_0.int_95[num4 + 15])) * 14.7f).ToString("0.00");
                                values[0x10] = ((128f / ((float) ClassEditor_0.int_95[num4 + 0x10])) * 14.7f).ToString("0.00");
                                values[0x11] = ((128f / ((float) ClassEditor_0.int_95[num4 + 0x11])) * 14.7f).ToString("0.00");
                                values[0x12] = ((128f / ((float) ClassEditor_0.int_95[num4 + 0x12])) * 14.7f).ToString("0.00");
                                values[0x13] = ((128f / ((float) ClassEditor_0.int_95[num4 + 0x13])) * 14.7f).ToString("0.00");
                                dataGridView_0.Rows.Insert(rowIndex, values);
                                num4 += 20;
                                rowIndex++;
                            }
                            break;
                        }
                        int num7 = ClassEditor_0.smethod_18(num + (num6 * 2));
                        dataGridView_0.Columns.Add(ClassEditor_0.smethod_18(num + (num6 * 2)).ToString(), num7.ToString());
                        num6++;
                    }
                    break;
                }
                ClassEditor_0.int_95[index] = ClassEditor_0.smethod_19(num3 + index);
                index++;
            }
        }
        catch
        {
            ClassEditor_0.bool_0 = false;
            DarkMessageBox.Show("Failed to load table.");
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
        ClassEditor_0.smethod_33(dataGridView_0.Columns.Count, float_1[0], float_1[1]);
        this.timer_0.Enabled = false;
    }

    private void treeView1_AfterSelect(object sender, EventArgs e)
    {
        if (this.treeView1.SelectedNodes.Count == 0) return;

        if ((this.treeView1.SelectedNode != null) && ClassEditor_0.bool_1)
        {
            if ((ClassEditor_0.bool_2 && (ClassEditor_0.int_1 != 0)) && (ClassEditor_0.int_0 != 0))
            {
                if (ClassEditor_0.int_1 == 200)
                {
                    ClassEditor_0.smethod_5("10X20");
                }
                else if (ClassEditor_0.int_1 == 0x40)
                {
                    ClassEditor_0.smethod_5("1X64");
                }
                else if (ClassEditor_0.int_1 == 15)
                {
                    ClassEditor_0.smethod_5("1X15");
                }
                else if (ClassEditor_0.int_1 == 8)
                {
                    ClassEditor_0.smethod_5("1X8");
                }
                else if (ClassEditor_0.int_1 == 7)
                {
                    ClassEditor_0.smethod_5("1X7");
                }
                else if (ClassEditor_0.int_1 == 6)
                {
                    ClassEditor_0.smethod_5("1X6");
                }
                else if (ClassEditor_0.int_1 == 5)
                {
                    ClassEditor_0.smethod_5("1X5");
                }
                else if (ClassEditor_0.int_1 == 4)
                {
                    ClassEditor_0.smethod_5("1X4");
                }
                else if (ClassEditor_0.int_1 == 2)
                {
                    ClassEditor_0.smethod_5("1X2");
                }
                else if (ClassEditor_0.int_1 == 1)
                {
                    ClassEditor_0.smethod_5("1X1");
                }
                ClassEditor_0.string_2 = ClassEditor_0.string_2 + ClassEditor_0.string_3 + Environment.NewLine;
            }
            ClassEditor_0.bool_2 = false;
            if (this.treeView1.SelectedNode.FullPath.Contains("Ignition Timing VTC High") || this.treeView1.SelectedNode.FullPath.Contains("Ignition Timing High"))
            {
                genum2_0 = GEnum2.TIMING_HIGH;
            }
            else if (this.treeView1.SelectedNode.FullPath.Contains("Ignition Timing VTC Low") || this.treeView1.SelectedNode.FullPath.Contains("Ignition Timing Low"))
            {
                genum2_0 = GEnum2.TIMING_LOW;
            }
            else
            {
                genum2_0 = !this.treeView1.SelectedNode.FullPath.Contains("Knock Limit High") ? (!this.treeView1.SelectedNode.FullPath.Contains("Knock Limit Low") ? (!this.treeView1.SelectedNode.FullPath.Contains("Lambda Target High") ? (!this.treeView1.SelectedNode.FullPath.Contains("Lambda Target Low") ? (!this.treeView1.SelectedNode.FullPath.Contains("AFM Fuel") ? GEnum2.NOT_SELECTED : GEnum2.AFM_FUEL) : GEnum2.LAMBDA_TGT_LOW) : GEnum2.LAMBDA_TGT_HIGH) : GEnum2.KNOCK_LOW) : GEnum2.KNOCK_HIGH;
            }
            this.groupBox1.Text = "Table: " + this.treeView1.SelectedNode.Text;
            string text = this.treeView1.SelectedNode.Text;
            if (text != null)
            {
                if (text == "Knock Sensitivity Low")
                {
                    this.method_16();
                }
                if (text == "Fuel High Cam")
                {
                    genum2_0 = GEnum2.VE_HIGH;
                    this.method_21();
                }
                if (text == "Speedlimiter")
                {
                    this.method_25();
                }
                if (text == "WOT Determiniation 2(TPS)")
                {
                    float_1[0] = -50f;
                    float_1[1] = 200f;
                    float_0 = 1f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray1 = new string[] { "1000", "2000", "3000", "4000", "5000", "6000" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_204, ClassEditor_0.int_203, "RPM", "TPS(%)", textArray1, GEnum2.THROTTLE_REQ, false);
                }
                if (text == "Cam Angle VTC High")
                {
                    this.method_23();
                }
                if (text == "Ignition Timing Low Cam")
                {
                    genum2_0 = GEnum2.TIMING_LOW;
                    this.method_20();
                }
                if (text == "AFM Fuel")
                {
                    genum2_0 = GEnum2.AFM_FUEL;
                    this.method_8(1);
                }
                if (text == "Knock Retard Low")
                {
                    this.method_18();
                }
                if (text == "20\x00b0")
                {
                    this.int_0 = 20;
                    if (genum2_0 == GEnum2.TIMING_HIGH)
                    {
                        this.method_11(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.TIMING_LOW)
                    {
                        this.method_12(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_HIGH)
                    {
                        this.method_13(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_LOW)
                    {
                        this.method_14(this.int_0);
                    }
                }
                if (text == "VTEC Engagement")
                {
                    float_1[0] = -10000f;
                    float_1[1] = 30000f;
                    float_0 = 10f;
                    ClassEditor_0.bool_3 = false;
                    ClassEditor_0.smethod_16(ClassEditor_0.int_5, ClassEditor_0.int_2, "", "RPM", this.string_4, GEnum2.TIMING_HIGH, true);
                    genum2_0 = GEnum2.VTEC_PARAMS;
                }
                if (text == "Ignition Timing VTC Low")
                {
                    genum2_0 = GEnum2.TIMING_LOW;
                    this.method_12(0);
                }
                if (text == "40\x00b0")
                {
                    this.int_0 = 40;
                    if (genum2_0 == GEnum2.TIMING_HIGH)
                    {
                        this.method_11(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.TIMING_LOW)
                    {
                        this.method_12(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_HIGH)
                    {
                        this.method_13(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_LOW)
                    {
                        this.method_14(this.int_0);
                    }
                }
                if (text == "Throttle Response 1")
                {
                    this.method_26();
                }
                if (text == "Throttle Response 2")
                {
                    this.method_27();
                }
                if (text == "Knock Limit High")
                {
                    genum2_0 = GEnum2.KNOCK_HIGH;
                    this.method_13(0);
                }
                if (text == "MAF Load Limit")
                {
                    float_1[0] = -1000f;
                    float_1[1] = 4000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    int[] numArray1 = new int[] { 4, 1 };
                    string[] textArray3 = new string[] { "", "", "", "" };
                    ClassEditor_0.smethod_16(numArray1, ClassEditor_0.int_216, "Mg/Stroke", "", textArray3, GEnum2.TIMING_HIGH, false);
                }
                if (text == "LAF Voltage to Lambda")
                {
                    float_1[0] = 0f;
                    float_1[1] = 4f;
                    float_0 = 0.01f;
                    ClassEditor_0.bool_3 = false;
                    ClassEditor_0.smethod_16(ClassEditor_0.int_140, ClassEditor_0.int_139, "Volts(mv)", "λ", this.string_1, GEnum2.LAF_VOLTAGE, false);
                }
                if (text == "Fuel Value 1")
                {
                    this.int_1 = 1;
                    if (genum2_0 == GEnum2.AFM_FUEL)
                    {
                        this.method_8(this.int_1);
                    }
                }
                if (text == "Fuel Value 2")
                {
                    this.int_1 = 2;
                    if (genum2_0 == GEnum2.AFM_FUEL)
                    {
                        this.method_8(this.int_1);
                    }
                }
                if (text == "Target 1")
                {
                    this.int_1 = 1;
                    if (genum2_0 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        this.method_9(this.int_1);
                    }
                    else if (genum2_0 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        this.method_10(this.int_1);
                    }
                }
                if (text == "Target 2")
                {
                    this.int_1 = 2;
                    if (genum2_0 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        this.method_9(this.int_1);
                    }
                    else if (genum2_0 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        this.method_10(this.int_1);
                    }
                }
                if (text == "Target 3")
                {
                    this.int_1 = 3;
                    if (genum2_0 == GEnum2.LAMBDA_TGT_HIGH)
                    {
                        this.method_9(this.int_1);
                    }
                    else if (genum2_0 == GEnum2.LAMBDA_TGT_LOW)
                    {
                        this.method_10(this.int_1);
                    }
                }
                if (text == "Post Start Idle Speed")
                {
                    float_1[0] = -1000f;
                    float_1[1] = 4000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    ClassEditor_0.smethod_16(ClassEditor_0.int_200, ClassEditor_0.int_199, "Coolant Temp", "RPM", this.method_36(ClassEditor_0.int_200[0], 0xfa90), GEnum2.TIMING_HIGH, false);
                }
                if (text == "WOT Determiniation 1(TPS)")
                {
                    float_1[0] = -50f;
                    float_1[1] = 200f;
                    float_0 = 1f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray2 = new string[] { "1000", "2000", "3000", "4000", "5000", "6000" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_202, ClassEditor_0.int_201, "RPM", "TPS(%)", textArray2, GEnum2.THROTTLE_REQ, false);
                }
                if (text == "00\x00b0")
                {
                    this.int_0 = 0;
                    if (genum2_0 == GEnum2.TIMING_HIGH)
                    {
                        this.method_11(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.TIMING_LOW)
                    {
                        this.method_12(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_HIGH)
                    {
                        this.method_13(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_LOW)
                    {
                        this.method_14(this.int_0);
                    }
                }
                if (text == "Knock Retard High")
                {
                    this.method_17();
                }
                if (text == "Ignition Timing VTC High")
                {
                    genum2_0 = GEnum2.TIMING_HIGH;
                    this.method_11(0);
                }
                if (text == "Revlimiter 8")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray4 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_14, "", "RPM", textArray4, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Revlimiter 6")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray6 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_12, "", "RPM", textArray6, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Cam Angle VTC Low")
                {
                    this.method_24();
                }
                if (text == "Revlimiter 7")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray5 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_13, "", "RPM", textArray5, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Idle Speed")
                {
                    float_1[0] = -1000f;
                    float_1[1] = 4000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    ClassEditor_0.smethod_16(ClassEditor_0.int_198, ClassEditor_0.int_197, "Coolant Temp", "RPM", this.method_36(ClassEditor_0.int_198[0], 0xfa70), GEnum2.TIMING_HIGH, false);
                }
                if (text == "Fuel Low Cam")
                {
                    genum2_0 = GEnum2.VE_LOW;
                    this.method_22();
                }
                if (text == "Revlimiter 4")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray7 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_10, "", "RPM", textArray7, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Revlimiter 5")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray9 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_11, "", "RPM", textArray9, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Revlimiter 2")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray8 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_8, "", "RPM", textArray8, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Revlimiter 3")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray11 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_9, "", "RPM", textArray11, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Revlimiter 1")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray10 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_7, "", "RPM", textArray10, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Lambda Target High Cam")
                {
                    genum2_0 = GEnum2.LAMBDA_TGT_HIGH;
                    this.method_9(1);
                }
                if (text == "Knock Limit Low")
                {
                    genum2_0 = GEnum2.KNOCK_LOW;
                    this.method_14(0);
                }
                if (text == "Lambda Target Low Cam")
                {
                    genum2_0 = GEnum2.LAMBDA_TGT_LOW;
                    this.method_10(1);
                }
                if (text == "Revlimiter")
                {
                    float_1[0] = 0f;
                    float_1[1] = 10000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray14 = new string[] { "", "" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_27, ClassEditor_0.int_6, "", "RPM", textArray14, GEnum2.TIMING_HIGH, false);
                }
                if (text == "Injector Voltage Compensation")
                {
                    float_1[0] = -1000f;
                    float_1[1] = 3000f;
                    float_0 = 1f;
                    ClassEditor_0.bool_3 = false;
                    ClassEditor_0.smethod_16(ClassEditor_0.int_33, ClassEditor_0.int_30, "Volts", "ms", this.string_0, GEnum2.INJ_DEADTIME, false);
                    genum2_0 = GEnum2.INJ_DEADTIME;
                }
                if (text == "Knock Sensitivity High")
                {
                    this.method_15();
                }
                if (text == "10\x00b0")
                {
                    this.int_0 = 10;
                    if (genum2_0 == GEnum2.TIMING_HIGH)
                    {
                        this.method_11(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.TIMING_LOW)
                    {
                        this.method_12(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_HIGH)
                    {
                        this.method_13(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_LOW)
                    {
                        this.method_14(this.int_0);
                    }
                }
                if (text == "WOT Determiniation (MAP)")
                {
                    float_1[0] = 0f;
                    float_1[1] = 120f;
                    float_0 = 1f;
                    ClassEditor_0.bool_3 = false;
                    string[] textArray13 = new string[] { "1000", "2000", "3000", "4000", "5000", "6000", "7000" };
                    ClassEditor_0.smethod_16(ClassEditor_0.int_206, ClassEditor_0.int_205, "RPM", "MAP(kpa)", textArray13, GEnum2.WOT_MAP, false);
                }
                if (text == "Mass Airflow Conversion Curve")
                {
                    float_1[0] = -10000f;
                    float_1[1] = 30000f;
                    float_0 = 1f;
                    ClassEditor_0.bool_3 = false;
                    ClassEditor_0.smethod_16(ClassEditor_0.int_37, ClassEditor_0.int_34, "Volts", "g/s", this.method_35(ClassEditor_0.int_37[0], ClassEditor_0.int_36), GEnum2.TIMING_HIGH, false);
                }
                if (text == "Minimum IPW")
                {
                    float_1[0] = -6f;
                    float_1[1] = 5f;
                    float_0 = 0.001f;
                    genum2_0 = GEnum2.MIN_IPW;
                    ClassEditor_0.bool_3 = false;
                    int[] numArray3 = new int[] { 1, 1 };
                    string[] textArray12 = new string[] { "" };
                    ClassEditor_0.smethod_16(numArray3, ClassEditor_0.int_217, "Min IPW", "", textArray12, GEnum2.MIN_IPW, false);
                }
                if (text == "Ignition Timing High Cam")
                {
                    genum2_0 = GEnum2.TIMING_HIGH;
                    this.method_19();
                }
                if (text == "Overrun Fuel Cut(Gear Determiniation)")
                {
                    float_1[0] = -1000f;
                    float_1[1] = 5000f;
                    float_0 = 50f;
                    ClassEditor_0.bool_3 = false;
                    int[] numArray2 = new int[] { 5, 1 };
                    ClassEditor_0.smethod_16(numArray2, ClassEditor_0.int_215, "Gear", "Delay(ms)", this.string_2, GEnum2.TIMING_HIGH, false);
                }
                if (text == "30\x00b0")
                {
                    this.int_0 = 30;
                    if (genum2_0 == GEnum2.TIMING_HIGH)
                    {
                        this.method_11(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.TIMING_LOW)
                    {
                        this.method_12(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_HIGH)
                    {
                        this.method_13(this.int_0);
                    }
                    else if (genum2_0 == GEnum2.KNOCK_LOW)
                    {
                        this.method_14(this.int_0);
                    }
                }
            }
        }
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

    public enum GEnum2
    {
        TIMING_HIGH = 0,
        TIMING_LOW = 1,
        VE_HIGH = 2,
        VE_LOW = 3,
        KNOCK_HIGH = 4,
        KNOCK_LOW = 5,
        LAMBDA_TGT_HIGH = 6,
        LAMBDA_TGT_LOW = 7,
        AFM_FUEL = 8,
        LAF_VOLTAGE = 9,
        INJ_DEADTIME = 10,
        THROTTLE_REQ = 11,
        WOT_MAP = 12,
        VTEC_PARAMS = 13,
        MIN_IPW = 14,
        NOT_SELECTED = 0xff
    }

    public enum GEnum3
    {
        RRB140,
        S2K
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
                    this.Editortable_0.string_8 = openFileDialog1.FileName;
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
                    this.Editortable_0.string_8 = openFileDialog1.FileName;
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
            this.ClassEditor_0.smethod_15(saveFileDialog1.FileName);
        }
    }
}

