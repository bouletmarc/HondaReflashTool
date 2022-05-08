using SAE.J2534;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;

public class frmOBD2Scan : DarkForm
{
    public int int_0;
    public static Color color_0 = Color.PaleVioletRed;
    public static Color color_1 = Color.OrangeRed;
    public static Color color_2 = Color.Azure;
    public static Color color_3 = Color.BlanchedAlmond;
    public static Color color_4 = Color.CornflowerBlue;
    public static Color color_5 = Color.Firebrick;
    public static Color color_6 = Color.PaleGoldenrod;
    public static int int_1 = 15;
    public static bool bool_0;
    public static string string_0;
    public static string string_1;
    private Thread thread_0;
    private string[] string_2;
    private string[] string_3;
    private string[] string_4;
    public static bool bool_1 = false;
    private bool bool_2;
    public static bool bool_3;
    private int int_2;
    private SerialPort serialPort_0;
    private Channel channel_0;
    private API api_0;
    private Device device_0;
    private APIInfo apiinfo_0;
    private int int_3;
    private bool bool_4;
    private StringBuilder stringBuilder_0 = new StringBuilder();
    private string string_5;
    private string string_6 = "";
    private int int_4;
    private ArrayList arrayList_0 = new ArrayList();
    private bool bool_5 = true;
    private int int_5;
    private int int_6;
    private int int_7;
    private int int_8;
    private int int_9;
    private int int_10;
    private int int_11;
    private int int_12;
    private int int_13;
    private int int_14;
    private int int_15;
    private int int_16;
    private int int_17;
    private int int_18;
    private int int_19;
    private int int_20;
    private int int_21;
    private int int_22;
    private int int_23;
    private int int_24;
    private int int_25;
    private int int_26;
    private int int_27;
    private int int_28;
    private int int_29;
    private int int_30;
    private int int_31;
    private int int_32;
    private int int_33;
    private int int_34;
    private int int_35;
    private int int_36;
    private int int_37;
    private int int_38;
    private int int_39;
    private int int_40;
    private int int_41;
    private int int_42;
    private int int_43;
    private int int_44;
    private int int_45;
    private int int_46;
    private int int_47;
    private int int_48;
    private int int_49;
    private int int_50;
    private int int_51;
    private int int_52;
    private int int_53;
    private int int_54;
    private int int_55;
    private int int_56;
    private int int_57;
    private int int_58;
    private int int_59;
    private int int_60;
    private int int_61;
    private int int_62;
    private int int_63;
    private int int_64;
    private int int_65;
    private int int_66;
    private int int_67;
    private int int_68;
    private int int_69;
    private int int_70;
    private int int_71;
    private int int_72;
    private int int_73;
    private int int_74;
    private int int_75;
    private int int_76;
    private int int_77;
    private int int_78;
    private int int_79;
    private int int_80;
    private int int_81;
    private int int_82;
    private int int_83;
    private int int_84;
    private int int_85;
    private int int_86;
    private int int_87;
    private int int_88;
    private int int_89;
    private int int_90;
    private int int_91;
    private int int_92;
    private int int_93;
    private int int_94;
    private int int_95;
    private int int_96;
    private int int_97;
    private int int_98;
    private int int_99;
    private int int_100;
    private int int_101;
    private int int_102;
    private int int_103;
    private int int_104;
    private int int_105;
    private int int_106;
    private int int_107;
    private int int_108;
    private int int_109;
    private int int_110;
    private int int_111;
    private int int_112;
    private int int_113;
    private int int_114;
    private int int_115;
    private int int_116;
    private int int_117;
    private int int_118;
    private int int_119;
    private int int_120;
    private int int_121;
    private int int_122;
    private int int_123;
    private int int_124;
    private int int_125;
    private int int_126;
    private int int_127;
    private int int_128;
    private int int_129;
    private int int_130;
    private int int_131;
    private int int_132;
    private int int_133;
    private int int_134;
    private int int_135;
    private int int_136;
    private int int_137;
    private int int_138;
    private int int_139;
    private int int_140;
    private int int_141;
    private int int_142;
    private int int_143;
    private int int_144;
    private int int_145;
    private int int_146;
    private int int_147;
    private int int_148;
    private int int_149;
    private int int_150;
    private int int_151;
    private int int_152;
    private int int_153;
    private int int_154;
    private int int_155;
    private int int_156;
    private int int_157;
    private int int_158;
    private int int_159;
    private int int_160;
    private int int_161;
    private int int_162;
    private int int_163;
    private int int_164;
    private int int_165;
    private int int_166;
    private int int_167;
    private int int_168;
    private int int_169;
    private int int_170;
    private int int_171;
    private int int_172;
    private int int_173;
    private int int_174;
    private int int_175;
    private int int_176;
    private int int_177;
    private int int_178;
    private int int_179;
    private int int_180;
    private int int_181;
    private int int_182;
    private string string_7 = "000";
    private string string_8 = "000";
    private string string_9;
    private string string_10;
    private string string_11 = "0";
    private string string_12;
    private string string_13;
    private string string_14;
    private string string_15;
    private string string_16;
    private string string_17;
    private string string_18;
    private int int_183;
    private bool bool_6;
    private int int_184;
    private bool bool_7 = true;
    private double double_0;
    private List<string> list_0 = new List<string>();
    private TableLayoutPanel tableLayoutPanel1;
    private TabPage tabPage7;
    private TabPage tabPage5;
    private TabPage tabPage6;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private TableLayoutPanel tableLayoutPanel6;
    private DarkGroupBox groupBox2;
    private DarkButton ClearTable;
    private DarkButton StopTable;
    private DarkComboBox comboV;
    private DarkLabel labelL;
    private DarkComboBox comboY;
    private DarkLabel labely;
    private DarkComboBox comboX;
    private DarkLabel labelx;
    public DarkDataGridView dataGridView_0;
    private TableLayoutPanel tableLayoutPanel5;
    public DarkButton GColourLF;
    private DarkButton GColourL4;
    private DarkButton GColourL3;
    private DarkButton GColourL2;
    private DarkButton GColourL1;
    public DarkButton GColour2;
    private DarkLabel label4;
    public DarkButton GColour1;
    private TableLayoutPanel tableLayoutPanel4;
    private TableLayoutPanel tableLayoutPanel7;
    private IContainer icontainer_0;
    private DarkButton Gstart;
    private PerfChart livegraph1;
    private DarkComboBox Graph4;
    private DarkComboBox Graph3;
    private DarkComboBox Graph2;
    private DarkComboBox Graph1;
    private System.Windows.Forms.Timer timer_0;
    private PerfChart livegraph4;
    private PerfChart livegraph3;
    private DarkLabel label6;
    private DarkLabel label5;
    private DarkButton StartTable;
    private System.Windows.Forms.Timer timer_1;
    private DarkLabel label9;
    private DarkLabel label8;
    private DarkLabel label7;
    private MaskedTextBox maskedTextBox1;
    private DarkComboBox comboBox1;
    private DarkLabel label10;
    private DarkLabel label11;
    private DarkLabel label13;
    private MaskedTextBox maskedTextBox2;
    private DarkLabel label12;
    private DarkComboBox comboBox2;
    private ColorDialog colorDialog_0;
    private DarkLabel label14;
    private DarkComboBox comboBox3;
    private PerfChart livegraph2;
    private string string_19;
    private DarkCheckBox cbJ2534;
    private TableLayoutPanel tableLayoutPanel11;
    private TableLayoutPanel tableLayoutPanel12;
    private DarkLabel G4L;
    private DarkLabel G3L;
    private DarkLabel G2L;
    public static string string_20 = "";
    public static int int_185;
    public static int int_186 = 0;
    private DarkLabel G1L;
    private bool bool_8;
    private bool bool_9;
    private static bool bool_10 = true;
    public static bool bool_11;
    public static float float_0;
    public static float float_1;
    public static float float_2;
    public static int int_187;
    public static float float_3;
    public static float float_4;
    public static float float_5;
    public static float float_6;
    public static int int_188;
    public static float float_7;
    public static float float_8;
    public static float float_9;
    public static float float_10;
    public static int int_189;
    public static float float_11;
    public static float float_12;
    public static float float_13;
    public static float float_14;
    public static float float_15;
    public static int int_190;
    public static int int_191;
    public static int int_192;
    public static int int_193;
    private DarkTabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private DarkGroupBox groupBox1;
    private DarkLabel label3;
    private DarkLabel label2;
    private DarkGroupBox gbConnection;
    private DarkLabel label1;
    private DarkLabel descPort;
    private DarkComboBox cbBaud;
    private DarkComboBox cbPort;
    private DarkGroupBox groupBox4;
    private DarkTextBox txtDTCD;
    private DarkButton ClearDTC;
    private DarkButton ButtonReadCEL;
    private DarkListBox listBoxCEL;
    private DarkGroupBox groupBox5;
    private DarkButton button2;
    private TrackBar trackBar1;
    private ClassListView listViewLive;
    private ColumnHeader columnHeader_0;
    private ColumnHeader columnHeader_1;
    private ColumnHeader columnHeader_2;
    private ColumnHeader columnHeader_3;
    private ColumnHeader columnHeader_4;
    private DarkListBox listBoxPIDs;
    private System.Windows.Forms.Timer timer_2;
    private System.Windows.Forms.Timer timer_3;
    private System.Windows.Forms.Timer timer_4;
    private DarkButton button1;
    private System.Windows.Forms.Timer timer_5;
    private TabPage tabPage4;
    private DarkGroupBox gbStatus;
    private ListView lvLog;
    private ColumnHeader columnHeader_5;
    private DarkButton buttonclear;
    private System.Windows.Forms.Timer timer_6;
    private IContainer components;
    private DarkLabel descRate;
    private ToolTip toolTip_0;

    internal frmOBD2Scan()
    {
        color_0 = Color.PaleVioletRed;
        color_1 = Color.OrangeRed;
        color_2 = Color.Azure;
        color_3 = Color.BlanchedAlmond;
        color_4 = Color.CornflowerBlue;
        color_5 = Color.Firebrick;
        color_6 = Color.PaleGoldenrod;
        this.InitializeComponent();
        this.method_0();

        NewInitit();

        if (bool_3)
        {
            base.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }
        this.method_18();
        this.label1.Text = "To identify the correct port, Unplug device && note available ports" + Environment.NewLine + "Connect device & select the new entry. Then Click Connect button down the bottom.";

    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (!this.bool_8)
        {
            if (this.int_2 == 0)
            {
                this.int_2 = 3;
                this.method_18();
                this.bool_4 = true;
                try
                {
                    this.serialPort_0 = new SerialPort(this.cbPort.Text, int.Parse(this.cbBaud.Text), Parity.None, 8, StopBits.One);
                    this.serialPort_0.Open();
                    this.int_3 = 0;
                    this.stringBuilder_0.Clear();
                    this.timer_2.Enabled = true;
                    this.serialPort_0.Write("ATWS\r");
                    this.timer_5.Enabled = true;
                    this.method_11();
                }
                catch
                {
                    MessageBox.Show("Something Went Wrong Trying To Open Port.");
                    this.int_2 = 0;
                    this.method_18();
                }
            }
            else if (this.int_2 == 1)
            {
                if (!this.bool_8)
                {
                    this.method_9();
                    this.int_2 = 0;
                    this.method_18();
                }
                else
                {
                    this.int_2 = 0;
                    this.method_18();
                    bool_11 = false;
                    this.bool_4 = false;
                    this.method_21("Connection closed automatically.");
                    this.int_2 = 0;
                    this.method_18();
                }
            }
            else
            {
                this.method_9();
                this.int_2 = 0;
                this.method_18();
            }
        }
        else if (this.int_2 == 0)
        {
            this.int_2 = 3;
            this.bool_4 = true;
            if (!bool_10)
            {
                using (API api = APIFactory.GetAPI(this.string_19))
                {
                    using (Device device = api.GetDevice(""))
                    {
                        using (Channel channel = device.GetChannel(Protocol.CAN, Baud.CAN, ConnectFlag.NONE, false))
                        {
                            byte[] match = new byte[4];
                            match[2] = 7;
                            match[3] = 0xe8;
                            channel.StartMsgFilter(new MessageFilter(UserFilterType.PASS, match));
                            SConfig[] sConfig = new SConfig[] { new SConfig(Parameter.LOOP_BACK, 1) };
                            channel.SetConfig(sConfig);
                        }
                    }
                }
            }
            this.timer_2.Enabled = true;
            this.bool_4 = false;
            this.int_2 = 1;
            this.method_18();
        }
        else if (this.int_2 == 1)
        {
            this.int_2 = 0;
            this.method_18();
            bool_11 = false;
            this.timer_6.Enabled = false;
            this.timer_2.Enabled = false;
            Thread.Sleep(0x4b0);
            this.bool_4 = false;
            this.thread_0.Abort();
            this.thread_0 = null;
            this.method_21("Connection closed automatically.");
            this.int_2 = 0;
            this.method_18();
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.timer_4.Interval = int_1;
        if (this.listViewLive.Items.Count != 0)
        {
            if (!this.timer_4.Enabled)
            {
                if (!bool_10)
                {
                    int num = 0;
                    foreach (ListViewItem item1 in this.listViewLive.Items)
                    {
                        this.list_0.Add(this.listViewLive.Items[num].SubItems[0].Text);
                        num++;
                    }
                    this.int_184 = 0;
                }
                this.timer_4.Enabled = true;
                this.timer_6.Enabled = true;
                this.listBoxPIDs.Enabled = false;
                this.button2.Text = "Stop Logging";
            }
            else
            {
                this.int_184 = 0;
                this.timer_4.Enabled = false;
                this.timer_6.Enabled = false;
                this.button2.Text = "Start Logging";
                if (!bool_10)
                {
                    this.listBoxPIDs.Enabled = true;
                }
            }
        }
    }

    private void buttonclear_Click(object sender, EventArgs e)
    {
        this.lvLog.Clear();
    }

    private void ButtonReadCEL_Click(object sender, EventArgs e)
    {
        this.txtDTCD.Text = "";
        this.listBoxCEL.Items.Clear();
        this.method_19("03");
    }

    private void cbJ2534_CheckStateChanged(object sender, EventArgs e)
    {
        if (!this.cbJ2534.Checked)
        {
            this.cbJ2534.Checked = false;
            this.bool_8 = false;
        }
        else
        {
            this.bool_8 = true;
            GForm_J2534Select select = new GForm_J2534Select();
            if (select.ShowDialog() != DialogResult.OK)
            {
                this.cbJ2534.Checked = false;
            }
            else
            {
                try
                {
                    this.string_19 = select.APIInfo_0.Filename;
                }
                catch
                {
                    this.cbJ2534.Checked = false;
                }
            }
            select.Dispose();
        }
        bool_0 = this.cbJ2534.Checked;
    }

    private void cbPort_SelectedValueChanged(object sender, EventArgs e)
    {
        string_1 = this.cbPort.Text;
        string_0 = this.cbBaud.Text;
    }

    private void ClearDTC_Click(object sender, EventArgs e)
    {
        this.method_19("04");
    }

    private void frmOBD2Scan_FormClosing(object sender, FormClosingEventArgs e)
    {
        if ((this.serialPort_0 != null) && this.serialPort_0.IsOpen)
        {
            bool_1 = false;
            this.serialPort_0.Close();
        }
        if (bool_11)
        {
            bool_11 = false;
            this.int_2 = 0;
            this.timer_6.Enabled = false;
            this.timer_2.Enabled = false;
            this.method_18();
            this.bool_4 = false;
            this.method_21("Connection closed automatically.");
            this.int_2 = 0;
            this.method_18();
        }
    }

    private void frmOBD2Scan_Load(object sender, EventArgs e)
    {
        this.cbBaud.Text = string_0;
        this.method_2();
        this.method_1();
        this.groupBox5.Text = "Refresh rate: " + int_1.ToString() + "ms";
        this.trackBar1.Value = int_1;
        this.cbJ2534.Checked = bool_0;
    }

    private void GColour1_Click(object sender, EventArgs e)
    {
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.GColour1.BackColor = this.colorDialog_0.Color;
            this.method_1();
        }
    }

    private void GColour2_Click(object sender, EventArgs e)
    {
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.GColour2.BackColor = this.colorDialog_0.Color;
            this.method_1();
        }
    }

    private void GColourL1_Click(object sender, EventArgs e)
    {
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.GColourL1.BackColor = this.colorDialog_0.Color;
            this.method_1();
        }
    }

    private void GColourL2_Click(object sender, EventArgs e)
    {
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.GColourL2.BackColor = this.colorDialog_0.Color;
            this.method_1();
        }
    }

    private void GColourL3_Click(object sender, EventArgs e)
    {
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.GColourL3.BackColor = this.colorDialog_0.Color;
            this.method_1();
        }
    }

    private void GColourL4_Click(object sender, EventArgs e)
    {
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.GColourL4.BackColor = this.colorDialog_0.Color;
            this.method_1();
        }
    }

    private void GColourLF_Click(object sender, EventArgs e)
    {
        if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
        {
            this.GColourLF.BackColor = this.colorDialog_0.Color;
            this.method_1();
        }
    }

    private void Graph1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.G1L.Text = this.Graph1.Text;
    }

    private void Graph2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.G2L.Text = this.Graph2.Text;
    }

    private void Graph3_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.G3L.Text = this.Graph3.Text;
    }

    private void Graph4_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.G4L.Text = this.Graph4.Text;
    }

    private void Gstart_Click(object sender, EventArgs e)
    {
        if (this.Gstart.Text == "Start")
        {
            this.timer_0.Enabled = true;
            this.Gstart.Text = "Stop";
        }
        else
        {
            this.Gstart.Text = "Start";
            this.timer_0.Enabled = false;
        }
    }

    private void NewInitit()
    {
        GClass4 class2 = new GClass4();
        GClass4 class3 = new GClass4();
        GClass4 class4 = new GClass4();
        GClass4 class5 = new GClass4();
        GClass4 class6 = new GClass4();
        GClass4 class7 = new GClass4();
        GClass4 class8 = new GClass4();
        GClass4 class9 = new GClass4();
        GClass4 class10 = new GClass4();
        GClass4 class11 = new GClass4();
        GClass4 class12 = new GClass4();
        GClass4 class13 = new GClass4();
        GClass4 class14 = new GClass4();
        GClass4 class15 = new GClass4();
        GClass4 class16 = new GClass4();
        GClass4 class17 = new GClass4();

        class2.Color_0 = Color.FromArgb(0xc0, 0xc0, 0);
        class2.DashStyle_0 = DashStyle.Solid;
        class2.Single_0 = 2f;
        class3.Color_0 = Color.Black;
        class3.DashStyle_0 = DashStyle.Solid;
        class3.Single_0 = 5f;
        class4.Color_0 = Color.Black;
        class4.DashStyle_0 = DashStyle.Solid;
        class4.Single_0 = 1f;
        class5.Color_0 = Color.Black;
        class5.DashStyle_0 = DashStyle.Solid;
        class5.Single_0 = 1f;
        class6.Color_0 = Color.Fuchsia;
        class6.DashStyle_0 = DashStyle.Solid;
        class6.Single_0 = 2f;
        class7.Color_0 = Color.Fuchsia;
        class7.DashStyle_0 = DashStyle.Solid;
        class7.Single_0 = 5f;
        class8.Color_0 = Color.Black;
        class8.DashStyle_0 = DashStyle.Solid;
        class8.Single_0 = 1f;
        class9.Color_0 = Color.Black;
        class9.DashStyle_0 = DashStyle.Solid;
        class9.Single_0 = 1f;
        class10.Color_0 = Color.Blue;
        class10.DashStyle_0 = DashStyle.Solid;
        class10.Single_0 = 2f;
        class11.Color_0 = Color.Blue;
        class11.DashStyle_0 = DashStyle.Solid;
        class11.Single_0 = 5f;
        class12.Color_0 = Color.Black;
        class12.DashStyle_0 = DashStyle.Solid;
        class12.Single_0 = 1f;
        class13.Color_0 = Color.Black;
        class13.DashStyle_0 = DashStyle.Solid;
        class13.Single_0 = 1f;
        class14.Color_0 = Color.Turquoise;
        class14.DashStyle_0 = DashStyle.Solid;
        class14.Single_0 = 2f;
        class15.Color_0 = Color.Red;
        class15.DashStyle_0 = DashStyle.Solid;
        class15.Single_0 = 5f;
        class16.Color_0 = Color.Black;
        class16.DashStyle_0 = DashStyle.Solid;
        class16.Single_0 = 1f;
        class17.Color_0 = Color.Black;
        class17.DashStyle_0 = DashStyle.Solid;
        class17.Single_0 = 1f;

        this.livegraph4 = new PerfChart();
        this.livegraph3 = new PerfChart();
        this.livegraph2 = new PerfChart();
        this.livegraph1 = new PerfChart();

        this.tableLayoutPanel11.Controls.Add(this.livegraph4, 1, 3);
        this.tableLayoutPanel11.Controls.Add(this.G4L, 0, 3);
        this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 1, 4);
        this.tableLayoutPanel11.Controls.Add(this.G3L, 0, 2);
        this.tableLayoutPanel11.Controls.Add(this.livegraph3, 1, 2);
        this.tableLayoutPanel11.Controls.Add(this.G2L, 0, 1);
        this.tableLayoutPanel11.Controls.Add(this.livegraph2, 1, 1);
        this.tableLayoutPanel11.Controls.Add(this.G1L, 0, 0);
        this.tableLayoutPanel11.Controls.Add(this.livegraph1, 1, 0);

        this.livegraph4.Border3DStyle_0 = Border3DStyle.Flat;
        this.livegraph4.Dock = DockStyle.Fill;
        this.livegraph4.Font = new Font("Comic Sans MS", 12f, FontStyle.Bold);
        this.livegraph4.Location = new Point(0x3b, 0xf1);
        this.livegraph4.Margin = new Padding(3, 4, 3, 4);
        this.livegraph4.Name = "livegraph4";
        this.livegraph4.GClass3_0.Boolean_3 = true;
        this.livegraph4.GClass3_0.Color_1 = Color.DarkGreen;
        this.livegraph4.GClass3_0.Color_0 = Color.YellowGreen;
        this.livegraph4.GClass3_0.Boolean_2 = false;
        this.livegraph4.GClass3_0.Boolean_1 = true;
        this.livegraph4.GClass3_0.Boolean_0 = true;
        this.livegraph4.GEnum0_0 = GEnum0.Relative;
        this.livegraph4.Size = new Size(0x1f2, 0x47);
        this.livegraph4.TabIndex = 0x11;
        this.livegraph4.Int32_0 = 100;
        this.livegraph4.GEnum1_0 = GEnum1.Disabled;
        this.livegraph4.DoubleClick += new EventHandler(this.livegraph4_DoubleClick);

        this.livegraph3.Border3DStyle_0 = Border3DStyle.Flat;
        this.livegraph3.Dock = DockStyle.Fill;
        this.livegraph3.Font = new Font("Comic Sans MS", 12f, FontStyle.Bold);
        this.livegraph3.Location = new Point(0x3b, 0xa2);
        this.livegraph3.Margin = new Padding(3, 4, 3, 4);
        this.livegraph3.Name = "livegraph3";
        this.livegraph3.GClass3_0.Boolean_3 = true;
        this.livegraph3.GClass3_0.Color_1 = Color.DarkGreen;
        this.livegraph3.GClass3_0.Color_0 = Color.YellowGreen;
        this.livegraph3.GClass3_0.Boolean_2 = false;
        this.livegraph3.GClass3_0.Boolean_1 = true;
        this.livegraph3.GClass3_0.Boolean_0 = true;
        this.livegraph3.GEnum0_0 = GEnum0.Relative;
        this.livegraph3.Size = new Size(0x1f2, 0x47);
        this.livegraph3.TabIndex = 0x10;
        this.livegraph3.Int32_0 = 100;
        this.livegraph3.GEnum1_0 = GEnum1.Disabled;
        this.livegraph3.DoubleClick += new EventHandler(this.livegraph3_DoubleClick);

        this.livegraph2.Border3DStyle_0 = Border3DStyle.Flat;
        this.livegraph2.Dock = DockStyle.Fill;
        this.livegraph2.Font = new Font("Comic Sans MS", 12f, FontStyle.Bold);
        this.livegraph2.Location = new Point(0x3b, 0x53);
        this.livegraph2.Margin = new Padding(3, 4, 3, 4);
        this.livegraph2.Name = "livegraph2";
        this.livegraph2.GClass3_0.Boolean_3 = true;
        this.livegraph2.GClass3_0.Color_1 = Color.DarkGreen;
        this.livegraph2.GClass3_0.Color_0 = Color.YellowGreen;
        this.livegraph2.GClass3_0.Boolean_2 = false;
        this.livegraph2.GClass3_0.Boolean_1 = true;
        this.livegraph2.GClass3_0.Boolean_0 = true;
        this.livegraph2.GEnum0_0 = GEnum0.Relative;
        this.livegraph2.Size = new Size(0x1f2, 0x47);
        this.livegraph2.TabIndex = 15;
        this.livegraph2.Int32_0 = 100;
        this.livegraph2.GEnum1_0 = GEnum1.Disabled;
        this.livegraph2.DoubleClick += new EventHandler(this.livegraph2_DoubleClick);

        this.livegraph1.Border3DStyle_0 = Border3DStyle.Flat;
        this.livegraph1.Dock = DockStyle.Fill;
        this.livegraph1.Font = new Font("Comic Sans MS", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
        this.livegraph1.Location = new Point(0x3b, 4);
        this.livegraph1.Margin = new Padding(3, 4, 3, 4);
        this.livegraph1.Name = "livegraph1";
        this.livegraph1.GClass3_0.Boolean_3 = true;
        this.livegraph1.GClass3_0.Color_1 = Color.DarkGreen;
        this.livegraph1.GClass3_0.Color_0 = Color.YellowGreen;
        this.livegraph1.GClass3_0.Boolean_2 = false;
        this.livegraph1.GClass3_0.Boolean_1 = true;
        this.livegraph1.GClass3_0.Boolean_0 = true;
        this.livegraph1.GEnum0_0 = GEnum0.Relative;
        this.livegraph1.Size = new Size(0x1f2, 0x47);
        this.livegraph1.TabIndex = 10;
        this.livegraph1.Int32_0 = 100;
        this.livegraph1.GEnum1_0 = GEnum1.Disabled;
        this.livegraph1.DoubleClick += new EventHandler(this.livegraph1_DoubleClick);

        this.livegraph4.GClass3_0.GClass4_2 = class2;
        this.livegraph4.GClass3_0.GClass4_3 = class3;
        this.livegraph4.GClass3_0.GClass4_1 = class4;
        this.livegraph4.GClass3_0.GClass4_0 = class5;
        this.livegraph3.GClass3_0.GClass4_2 = class6;
        this.livegraph3.GClass3_0.GClass4_3 = class7;
        this.livegraph3.GClass3_0.GClass4_1 = class8;
        this.livegraph3.GClass3_0.GClass4_0 = class9;
        this.livegraph2.GClass3_0.GClass4_2 = class10;
        this.livegraph2.GClass3_0.GClass4_3 = class11;
        this.livegraph2.GClass3_0.GClass4_1 = class12;
        this.livegraph2.GClass3_0.GClass4_0 = class13;
        this.livegraph1.GClass3_0.GClass4_2 = class14;
        this.livegraph1.GClass3_0.GClass4_3 = class15;
        this.livegraph1.GClass3_0.GClass4_1 = class16;
        this.livegraph1.GClass3_0.GClass4_0 = class17;

        //##################
        this.listViewLive = new ClassListView();
        ColumnHeader[] values = new ColumnHeader[] { this.columnHeader_0, this.columnHeader_1, this.columnHeader_2, this.columnHeader_3, this.columnHeader_4 };
        this.listViewLive.Columns.AddRange(values);
        this.listViewLive.Dock = DockStyle.Fill;
        this.listViewLive.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        this.listViewLive.HideSelection = false;
        this.listViewLive.Location = new Point(0x9b, 3);
        this.listViewLive.Margin = new Padding(2, 3, 2, 3);
        this.listViewLive.Name = "listViewLive";
        this.listViewLive.Size = new Size(0x193, 0x11c);
        this.listViewLive.TabIndex = 3;
        this.listViewLive.UseCompatibleStateImageBehavior = false;
        this.listViewLive.View = View.Details;
        this.listViewLive.KeyDown += new KeyEventHandler(this.listViewLive_KeyDown);
        this.listViewLive.MouseDoubleClick += new MouseEventHandler(this.listViewLive_MouseDoubleClick);

        this.tableLayoutPanel3.Controls.Add(this.button2, 0, 1);
        this.tableLayoutPanel3.Controls.Add(this.listViewLive, 1, 0);
        this.tableLayoutPanel3.Controls.Add(this.listBoxPIDs, 0, 0);
        this.tableLayoutPanel3.Controls.Add(this.groupBox5, 1, 1);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Honda OBD2 Scan Tools Initializing..", 2);
            this.G4L = new DarkUI.Controls.DarkLabel();
            this.G3L = new DarkUI.Controls.DarkLabel();
            this.G2L = new DarkUI.Controls.DarkLabel();
            this.G1L = new DarkUI.Controls.DarkLabel();
            this.Graph4 = new DarkUI.Controls.DarkComboBox();
            this.Graph3 = new DarkUI.Controls.DarkComboBox();
            this.Graph2 = new DarkUI.Controls.DarkComboBox();
            this.Graph1 = new DarkUI.Controls.DarkComboBox();
            this.Gstart = new DarkUI.Controls.DarkButton();
            this.tabControl1 = new DarkUI.Controls.DarkTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbConnection = new DarkUI.Controls.DarkGroupBox();
            this.descRate = new DarkUI.Controls.DarkLabel();
            this.label1 = new DarkUI.Controls.DarkLabel();
            this.descPort = new DarkUI.Controls.DarkLabel();
            this.cbJ2534 = new DarkUI.Controls.DarkCheckBox();
            this.cbBaud = new DarkUI.Controls.DarkComboBox();
            this.cbPort = new DarkUI.Controls.DarkComboBox();
            this.button1 = new DarkUI.Controls.DarkButton();
            this.groupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.label3 = new DarkUI.Controls.DarkLabel();
            this.label2 = new DarkUI.Controls.DarkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDTCD = new DarkUI.Controls.DarkTextBox();
            this.groupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonReadCEL = new DarkUI.Controls.DarkButton();
            this.listBoxCEL = new DarkUI.Controls.DarkListBox(this.components);
            this.ClearDTC = new DarkUI.Controls.DarkButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.label6 = new DarkUI.Controls.DarkLabel();
            this.label5 = new DarkUI.Controls.DarkLabel();
            this.ClearTable = new DarkUI.Controls.DarkButton();
            this.StopTable = new DarkUI.Controls.DarkButton();
            this.StartTable = new DarkUI.Controls.DarkButton();
            this.comboV = new DarkUI.Controls.DarkComboBox();
            this.labelL = new DarkUI.Controls.DarkLabel();
            this.comboY = new DarkUI.Controls.DarkComboBox();
            this.labely = new DarkUI.Controls.DarkLabel();
            this.comboX = new DarkUI.Controls.DarkComboBox();
            this.labelx = new DarkUI.Controls.DarkLabel();
            this.dataGridView_0 = new DarkUI.Controls.DarkDataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new DarkUI.Controls.DarkLabel();
            this.label8 = new DarkUI.Controls.DarkLabel();
            this.GColourLF = new DarkUI.Controls.DarkButton();
            this.GColourL4 = new DarkUI.Controls.DarkButton();
            this.GColourL3 = new DarkUI.Controls.DarkButton();
            this.GColourL2 = new DarkUI.Controls.DarkButton();
            this.GColourL1 = new DarkUI.Controls.DarkButton();
            this.GColour2 = new DarkUI.Controls.DarkButton();
            this.label4 = new DarkUI.Controls.DarkLabel();
            this.GColour1 = new DarkUI.Controls.DarkButton();
            this.label7 = new DarkUI.Controls.DarkLabel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.comboBox1 = new DarkUI.Controls.DarkComboBox();
            this.label10 = new DarkUI.Controls.DarkLabel();
            this.label11 = new DarkUI.Controls.DarkLabel();
            this.label13 = new DarkUI.Controls.DarkLabel();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new DarkUI.Controls.DarkLabel();
            this.comboBox2 = new DarkUI.Controls.DarkComboBox();
            this.label14 = new DarkUI.Controls.DarkLabel();
            this.comboBox3 = new DarkUI.Controls.DarkComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonclear = new DarkUI.Controls.DarkButton();
            this.gbStatus = new DarkUI.Controls.DarkGroupBox();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader_5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new DarkUI.Controls.DarkButton();
            this.columnHeader_0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listBoxPIDs = new DarkUI.Controls.DarkListBox(this.components);
            this.groupBox5 = new DarkUI.Controls.DarkGroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.colorDialog_0 = new System.Windows.Forms.ColorDialog();
            this.timer_2 = new System.Windows.Forms.Timer(this.components);
            this.timer_3 = new System.Windows.Forms.Timer(this.components);
            this.timer_4 = new System.Windows.Forms.Timer(this.components);
            this.timer_5 = new System.Windows.Forms.Timer(this.components);
            this.timer_6 = new System.Windows.Forms.Timer(this.components);
            this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_1 = new System.Windows.Forms.Timer(this.components);
            this.timer_0 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tableLayoutPanel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // G4L
            // 
            this.G4L.AutoSize = true;
            this.G4L.BackColor = System.Drawing.Color.YellowGreen;
            this.G4L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.G4L.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.G4L.ForeColor = System.Drawing.Color.Black;
            this.G4L.Location = new System.Drawing.Point(2, 237);
            this.G4L.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.G4L.Name = "G4L";
            this.G4L.Size = new System.Drawing.Size(52, 79);
            this.G4L.TabIndex = 25;
            this.G4L.Text = ".";
            // 
            // G3L
            // 
            this.G3L.AutoSize = true;
            this.G3L.BackColor = System.Drawing.Color.YellowGreen;
            this.G3L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.G3L.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.G3L.ForeColor = System.Drawing.Color.Fuchsia;
            this.G3L.Location = new System.Drawing.Point(2, 158);
            this.G3L.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.G3L.Name = "G3L";
            this.G3L.Size = new System.Drawing.Size(52, 79);
            this.G3L.TabIndex = 24;
            this.G3L.Text = ".";
            // 
            // G2L
            // 
            this.G2L.AutoSize = true;
            this.G2L.BackColor = System.Drawing.Color.YellowGreen;
            this.G2L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.G2L.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.G2L.ForeColor = System.Drawing.Color.Blue;
            this.G2L.Location = new System.Drawing.Point(2, 79);
            this.G2L.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.G2L.Name = "G2L";
            this.G2L.Size = new System.Drawing.Size(52, 79);
            this.G2L.TabIndex = 23;
            this.G2L.Text = ".";
            // 
            // G1L
            // 
            this.G1L.AutoSize = true;
            this.G1L.BackColor = System.Drawing.Color.YellowGreen;
            this.G1L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.G1L.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.G1L.ForeColor = System.Drawing.Color.Red;
            this.G1L.Location = new System.Drawing.Point(2, 0);
            this.G1L.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.G1L.Name = "G1L";
            this.G1L.Size = new System.Drawing.Size(52, 79);
            this.G1L.TabIndex = 22;
            this.G1L.Text = ".";
            // 
            // Graph4
            // 
            this.Graph4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Graph4.FormattingEnabled = true;
            this.Graph4.Location = new System.Drawing.Point(302, 2);
            this.Graph4.Margin = new System.Windows.Forms.Padding(2);
            this.Graph4.Name = "Graph4";
            this.Graph4.Size = new System.Drawing.Size(96, 21);
            this.Graph4.TabIndex = 14;
            this.Graph4.SelectedIndexChanged += new System.EventHandler(this.Graph4_SelectedIndexChanged);
            // 
            // Graph3
            // 
            this.Graph3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Graph3.FormattingEnabled = true;
            this.Graph3.Location = new System.Drawing.Point(202, 2);
            this.Graph3.Margin = new System.Windows.Forms.Padding(2);
            this.Graph3.Name = "Graph3";
            this.Graph3.Size = new System.Drawing.Size(96, 21);
            this.Graph3.TabIndex = 13;
            this.Graph3.SelectedIndexChanged += new System.EventHandler(this.Graph3_SelectedIndexChanged);
            // 
            // Graph2
            // 
            this.Graph2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Graph2.FormattingEnabled = true;
            this.Graph2.Location = new System.Drawing.Point(102, 2);
            this.Graph2.Margin = new System.Windows.Forms.Padding(2);
            this.Graph2.Name = "Graph2";
            this.Graph2.Size = new System.Drawing.Size(96, 21);
            this.Graph2.TabIndex = 12;
            this.Graph2.SelectedIndexChanged += new System.EventHandler(this.Graph2_SelectedIndexChanged);
            // 
            // Graph1
            // 
            this.Graph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Graph1.FormattingEnabled = true;
            this.Graph1.Location = new System.Drawing.Point(2, 2);
            this.Graph1.Margin = new System.Windows.Forms.Padding(2);
            this.Graph1.Name = "Graph1";
            this.Graph1.Size = new System.Drawing.Size(96, 21);
            this.Graph1.TabIndex = 11;
            this.Graph1.SelectedIndexChanged += new System.EventHandler(this.Graph1_SelectedIndexChanged);
            // 
            // Gstart
            // 
            this.Gstart.Checked = false;
            this.Gstart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gstart.Location = new System.Drawing.Point(402, 2);
            this.Gstart.Margin = new System.Windows.Forms.Padding(2);
            this.Gstart.Name = "Gstart";
            this.Gstart.Size = new System.Drawing.Size(96, 28);
            this.Gstart.TabIndex = 0;
            this.Gstart.Text = "Start";
            this.toolTip_0.SetToolTip(this.Gstart, "Start or Stop live graphs");
            this.Gstart.Click += new System.EventHandler(this.Gstart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tabControl1.ItemSize = new System.Drawing.Size(330, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 381);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(560, 343);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbConnection, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 339);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // gbConnection
            // 
            this.gbConnection.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbConnection.Controls.Add(this.descRate);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.descPort);
            this.gbConnection.Controls.Add(this.cbJ2534);
            this.gbConnection.Controls.Add(this.cbBaud);
            this.gbConnection.Controls.Add(this.cbPort);
            this.gbConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConnection.Location = new System.Drawing.Point(2, 3);
            this.gbConnection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.gbConnection.Size = new System.Drawing.Size(552, 136);
            this.gbConnection.TabIndex = 8;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            this.gbConnection.Enter += new System.EventHandler(this.gbConnection_Enter);
            // 
            // descRate
            // 
            this.descRate.AutoSize = true;
            this.descRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.descRate.Location = new System.Drawing.Point(182, 26);
            this.descRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descRate.Name = "descRate";
            this.descRate.Size = new System.Drawing.Size(58, 13);
            this.descRate.TabIndex = 7;
            this.descRate.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // descPort
            // 
            this.descPort.AutoSize = true;
            this.descPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.descPort.Location = new System.Drawing.Point(13, 26);
            this.descPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descPort.Name = "descPort";
            this.descPort.Size = new System.Drawing.Size(26, 13);
            this.descPort.TabIndex = 2;
            this.descPort.Text = "Port";
            // 
            // cbJ2534
            // 
            this.cbJ2534.AutoSize = true;
            this.cbJ2534.Location = new System.Drawing.Point(385, 25);
            this.cbJ2534.Margin = new System.Windows.Forms.Padding(2);
            this.cbJ2534.Name = "cbJ2534";
            this.cbJ2534.Size = new System.Drawing.Size(55, 17);
            this.cbJ2534.TabIndex = 6;
            this.cbJ2534.Text = "J2534";
            this.cbJ2534.CheckStateChanged += new System.EventHandler(this.cbJ2534_CheckStateChanged);
            // 
            // cbBaud
            // 
            this.cbBaud.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaud.Location = new System.Drawing.Point(266, 23);
            this.cbBaud.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(106, 21);
            this.cbBaud.TabIndex = 1;
            this.cbBaud.SelectedValueChanged += new System.EventHandler(this.cbPort_SelectedValueChanged);
            // 
            // cbPort
            // 
            this.cbPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(54, 23);
            this.cbPort.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(106, 21);
            this.cbPort.TabIndex = 0;
            this.cbPort.SelectedValueChanged += new System.EventHandler(this.cbPort_SelectedValueChanged);
            // 
            // button1
            // 
            this.button1.Checked = false;
            this.button1.Location = new System.Drawing.Point(2, 286);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 49);
            this.button1.TabIndex = 11;
            this.button1.Text = "Connect";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 145);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.groupBox1.Size = new System.Drawing.Size(552, 136);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Features:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Adapter: ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(560, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Codes";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.txtDTCD, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(556, 339);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // txtDTCD
            // 
            this.txtDTCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDTCD.Location = new System.Drawing.Point(155, 3);
            this.txtDTCD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDTCD.Multiline = true;
            this.txtDTCD.Name = "txtDTCD";
            this.txtDTCD.ReadOnly = true;
            this.txtDTCD.Size = new System.Drawing.Size(406, 333);
            this.txtDTCD.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox4.Controls.Add(this.tableLayoutPanel7);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(2, 3);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.groupBox4.Size = new System.Drawing.Size(149, 333);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.ButtonReadCEL, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.listBoxCEL, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.ClearDTC, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(11, 25);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(127, 296);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // ButtonReadCEL
            // 
            this.ButtonReadCEL.Checked = false;
            this.ButtonReadCEL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonReadCEL.Location = new System.Drawing.Point(2, 3);
            this.ButtonReadCEL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonReadCEL.Name = "ButtonReadCEL";
            this.ButtonReadCEL.Size = new System.Drawing.Size(123, 27);
            this.ButtonReadCEL.TabIndex = 1;
            this.ButtonReadCEL.Text = "Read";
            this.ButtonReadCEL.ClientSizeChanged += new System.EventHandler(this.ButtonReadCEL_Click);
            this.ButtonReadCEL.Click += new System.EventHandler(this.ButtonReadCEL_Click);
            // 
            // listBoxCEL
            // 
            this.listBoxCEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.listBoxCEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxCEL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCEL.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxCEL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.listBoxCEL.FormattingEnabled = true;
            this.listBoxCEL.ItemHeight = 18;
            this.listBoxCEL.Location = new System.Drawing.Point(2, 69);
            this.listBoxCEL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxCEL.Name = "listBoxCEL";
            this.listBoxCEL.Size = new System.Drawing.Size(123, 224);
            this.listBoxCEL.TabIndex = 0;
            this.listBoxCEL.SelectedIndexChanged += new System.EventHandler(this.listBoxCEL_SelectedIndexChanged);
            // 
            // ClearDTC
            // 
            this.ClearDTC.Checked = false;
            this.ClearDTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearDTC.Location = new System.Drawing.Point(2, 36);
            this.ClearDTC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ClearDTC.Name = "ClearDTC";
            this.ClearDTC.Size = new System.Drawing.Size(123, 27);
            this.ClearDTC.TabIndex = 2;
            this.ClearDTC.Text = "Clear";
            this.ClearDTC.Click += new System.EventHandler(this.ClearDTC_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(560, 343);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Live Data";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(560, 343);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tabPage7.Controls.Add(this.tableLayoutPanel11);
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(560, 343);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Graphing";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 5;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.44898F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.44898F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.44898F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.44898F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.20408F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(560, 343);
            this.tableLayoutPanel11.TabIndex = 26;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tabPage5.Controls.Add(this.tableLayoutPanel6);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(560, 343);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Datalogging";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.dataGridView_0, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(560, 343);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ClearTable);
            this.groupBox2.Controls.Add(this.StopTable);
            this.groupBox2.Controls.Add(this.StartTable);
            this.groupBox2.Controls.Add(this.comboV);
            this.groupBox2.Controls.Add(this.labelL);
            this.groupBox2.Controls.Add(this.comboY);
            this.groupBox2.Controls.Add(this.labely);
            this.groupBox2.Controls.Add(this.comboX);
            this.groupBox2.Controls.Add(this.labelx);
            this.groupBox2.Location = new System.Drawing.Point(2, 269);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(520, 70);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(51, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 39);
            this.label6.TabIndex = 13;
            this.label6.Text = "20.90";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "AFR";
            // 
            // ClearTable
            // 
            this.ClearTable.Checked = false;
            this.ClearTable.Enabled = false;
            this.ClearTable.Location = new System.Drawing.Point(198, 45);
            this.ClearTable.Margin = new System.Windows.Forms.Padding(2);
            this.ClearTable.Name = "ClearTable";
            this.ClearTable.Size = new System.Drawing.Size(90, 20);
            this.ClearTable.TabIndex = 11;
            this.ClearTable.Text = "Clear Table";
            // 
            // StopTable
            // 
            this.StopTable.Checked = false;
            this.StopTable.Enabled = false;
            this.StopTable.Location = new System.Drawing.Point(292, 45);
            this.StopTable.Margin = new System.Windows.Forms.Padding(2);
            this.StopTable.Name = "StopTable";
            this.StopTable.Size = new System.Drawing.Size(89, 20);
            this.StopTable.TabIndex = 10;
            this.StopTable.Text = "Start Trace";
            this.StopTable.Click += new System.EventHandler(this.StopTable_Click);
            // 
            // StartTable
            // 
            this.StartTable.Checked = false;
            this.StartTable.Location = new System.Drawing.Point(386, 45);
            this.StartTable.Margin = new System.Windows.Forms.Padding(2);
            this.StartTable.Name = "StartTable";
            this.StartTable.Size = new System.Drawing.Size(120, 20);
            this.StartTable.TabIndex = 9;
            this.StartTable.Text = "Load Template";
            this.StartTable.Click += new System.EventHandler(this.StartTable_Click);
            // 
            // comboV
            // 
            this.comboV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboV.Enabled = false;
            this.comboV.FormattingEnabled = true;
            this.comboV.Items.AddRange(new object[] {
            "O2 (Internal)",
            "Knock (Internal)",
            "Final Ignition Timing",
            "MAF g/s",
            "HP",
            "Torque",
            "Commanded AFR",
            "O2 (External)",
            "Knock (External)",
            "EGT (External)"});
            this.comboV.Location = new System.Drawing.Point(386, 21);
            this.comboV.Margin = new System.Windows.Forms.Padding(2);
            this.comboV.Name = "comboV";
            this.comboV.Size = new System.Drawing.Size(120, 21);
            this.comboV.TabIndex = 5;
            // 
            // labelL
            // 
            this.labelL.AutoSize = true;
            this.labelL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelL.Location = new System.Drawing.Point(383, 8);
            this.labelL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelL.Name = "labelL";
            this.labelL.Size = new System.Drawing.Size(70, 13);
            this.labelL.TabIndex = 4;
            this.labelL.Text = "Value Sensor";
            // 
            // comboY
            // 
            this.comboY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboY.Enabled = false;
            this.comboY.FormattingEnabled = true;
            this.comboY.Items.AddRange(new object[] {
            "RPM",
            "SPEED"});
            this.comboY.Location = new System.Drawing.Point(292, 21);
            this.comboY.Margin = new System.Windows.Forms.Padding(2);
            this.comboY.Name = "comboY";
            this.comboY.Size = new System.Drawing.Size(89, 21);
            this.comboY.TabIndex = 3;
            // 
            // labely
            // 
            this.labely.AutoSize = true;
            this.labely.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labely.Location = new System.Drawing.Point(289, 8);
            this.labely.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labely.Name = "labely";
            this.labely.Size = new System.Drawing.Size(50, 13);
            this.labely.TabIndex = 2;
            this.labely.Text = "Y Sensor";
            // 
            // comboX
            // 
            this.comboX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboX.Enabled = false;
            this.comboX.FormattingEnabled = true;
            this.comboX.Items.AddRange(new object[] {
            "MAP",
            "TPS",
            "LOAD %"});
            this.comboX.Location = new System.Drawing.Point(198, 21);
            this.comboX.Margin = new System.Windows.Forms.Padding(2);
            this.comboX.Name = "comboX";
            this.comboX.Size = new System.Drawing.Size(89, 21);
            this.comboX.TabIndex = 1;
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelx.Location = new System.Drawing.Point(195, 8);
            this.labelx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(48, 13);
            this.labelx.TabIndex = 0;
            this.labelx.Text = "X sensor";
            // 
            // dataGridView_0
            // 
            this.dataGridView_0.AllowUserToAddRows = false;
            this.dataGridView_0.AllowUserToDeleteRows = false;
            this.dataGridView_0.ColumnHeadersHeight = 40;
            this.dataGridView_0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_0.Enabled = false;
            this.dataGridView_0.Location = new System.Drawing.Point(4, 5);
            this.dataGridView_0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView_0.Name = "dataGridView_0";
            this.dataGridView_0.ReadOnly = true;
            this.dataGridView_0.RowHeadersWidth = 72;
            this.dataGridView_0.RowTemplate.Height = 24;
            this.dataGridView_0.Size = new System.Drawing.Size(552, 257);
            this.dataGridView_0.TabIndex = 4;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tabPage6.Controls.Add(this.tableLayoutPanel5);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(560, 343);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Settings";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 8;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel5.Controls.Add(this.label9, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.label8, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.GColourLF, 7, 0);
            this.tableLayoutPanel5.Controls.Add(this.GColourL4, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.GColourL3, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.GColourL2, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.GColourL1, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.GColour2, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.GColour1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.maskedTextBox1, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.comboBox1, 4, 1);
            this.tableLayoutPanel5.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label13, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.maskedTextBox2, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.label12, 3, 3);
            this.tableLayoutPanel5.Controls.Add(this.comboBox2, 4, 3);
            this.tableLayoutPanel5.Controls.Add(this.label14, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.comboBox3, 2, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(560, 343);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label9.Location = new System.Drawing.Point(254, 68);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 68);
            this.label9.TabIndex = 46;
            this.label9.Text = "Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label8.Location = new System.Drawing.Point(111, 68);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 68);
            this.label8.TabIndex = 44;
            this.label8.Text = "CANID:";
            // 
            // GColourLF
            // 
            this.GColourLF.BackColor = System.Drawing.Color.AntiqueWhite;
            this.GColourLF.Checked = false;
            this.GColourLF.ForeColor = System.Drawing.Color.Black;
            this.GColourLF.Location = new System.Drawing.Point(493, 2);
            this.GColourLF.Margin = new System.Windows.Forms.Padding(2);
            this.GColourLF.Name = "GColourLF";
            this.GColourLF.Size = new System.Drawing.Size(54, 21);
            this.GColourLF.TabIndex = 36;
            this.GColourLF.Text = "FullLine";
            this.GColourLF.Click += new System.EventHandler(this.GColourLF_Click);
            // 
            // GColourL4
            // 
            this.GColourL4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.GColourL4.Checked = false;
            this.GColourL4.ForeColor = System.Drawing.Color.White;
            this.GColourL4.Location = new System.Drawing.Point(426, 2);
            this.GColourL4.Margin = new System.Windows.Forms.Padding(2);
            this.GColourL4.Name = "GColourL4";
            this.GColourL4.Size = new System.Drawing.Size(51, 21);
            this.GColourL4.TabIndex = 39;
            this.GColourL4.Text = "Line4";
            this.GColourL4.Click += new System.EventHandler(this.GColourL4_Click);
            // 
            // GColourL3
            // 
            this.GColourL3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.GColourL3.Checked = false;
            this.GColourL3.ForeColor = System.Drawing.Color.White;
            this.GColourL3.Location = new System.Drawing.Point(359, 2);
            this.GColourL3.Margin = new System.Windows.Forms.Padding(2);
            this.GColourL3.Name = "GColourL3";
            this.GColourL3.Size = new System.Drawing.Size(51, 21);
            this.GColourL3.TabIndex = 38;
            this.GColourL3.Text = "Line3";
            this.GColourL3.Click += new System.EventHandler(this.GColourL3_Click);
            // 
            // GColourL2
            // 
            this.GColourL2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.GColourL2.Checked = false;
            this.GColourL2.ForeColor = System.Drawing.Color.White;
            this.GColourL2.Location = new System.Drawing.Point(292, 2);
            this.GColourL2.Margin = new System.Windows.Forms.Padding(2);
            this.GColourL2.Name = "GColourL2";
            this.GColourL2.Size = new System.Drawing.Size(51, 21);
            this.GColourL2.TabIndex = 37;
            this.GColourL2.Text = "Line2";
            this.GColourL2.Click += new System.EventHandler(this.GColourL2_Click);
            // 
            // GColourL1
            // 
            this.GColourL1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.GColourL1.Checked = false;
            this.GColourL1.ForeColor = System.Drawing.Color.White;
            this.GColourL1.Location = new System.Drawing.Point(225, 2);
            this.GColourL1.Margin = new System.Windows.Forms.Padding(2);
            this.GColourL1.Name = "GColourL1";
            this.GColourL1.Size = new System.Drawing.Size(51, 21);
            this.GColourL1.TabIndex = 35;
            this.GColourL1.Text = "Line";
            this.GColourL1.Click += new System.EventHandler(this.GColourL1_Click);
            // 
            // GColour2
            // 
            this.GColour2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.GColour2.Checked = false;
            this.GColour2.ForeColor = System.Drawing.Color.White;
            this.GColour2.Location = new System.Drawing.Point(158, 2);
            this.GColour2.Margin = new System.Windows.Forms.Padding(2);
            this.GColour2.Name = "GColour2";
            this.GColour2.Size = new System.Drawing.Size(46, 21);
            this.GColour2.TabIndex = 34;
            this.GColour2.Text = "Top";
            this.GColour2.Click += new System.EventHandler(this.GColour2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label4.Location = new System.Drawing.Point(2, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Graph Colours:";
            // 
            // GColour1
            // 
            this.GColour1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.GColour1.Checked = false;
            this.GColour1.ForeColor = System.Drawing.Color.White;
            this.GColour1.Location = new System.Drawing.Point(91, 2);
            this.GColour1.Margin = new System.Windows.Forms.Padding(2);
            this.GColour1.Name = "GColour1";
            this.GColour1.Size = new System.Drawing.Size(50, 21);
            this.GColour1.TabIndex = 33;
            this.GColour1.Text = "Bottom";
            this.GColour1.Click += new System.EventHandler(this.GColour1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label7.Location = new System.Drawing.Point(2, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 26);
            this.label7.TabIndex = 42;
            this.label7.Text = "External Wideband:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maskedTextBox1.Location = new System.Drawing.Point(158, 70);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(63, 20);
            this.maskedTextBox1.TabIndex = 45;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Spartan3",
            ":Link"});
            this.comboBox1.Location = new System.Drawing.Point(292, 70);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(63, 21);
            this.comboBox1.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label10.Location = new System.Drawing.Point(2, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "External Knock:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label11.Location = new System.Drawing.Point(2, 204);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "External EGT:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label13.Location = new System.Drawing.Point(111, 204);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 68);
            this.label13.TabIndex = 50;
            this.label13.Text = "CANID:";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maskedTextBox2.Location = new System.Drawing.Point(158, 206);
            this.maskedTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(63, 20);
            this.maskedTextBox2.TabIndex = 51;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Right;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label12.Location = new System.Drawing.Point(254, 204);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 68);
            this.label12.TabIndex = 52;
            this.label12.Text = "Type:";
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(292, 206);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(63, 21);
            this.comboBox2.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Right;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label14.Location = new System.Drawing.Point(98, 136);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 68);
            this.label14.TabIndex = 53;
            this.label14.Text = "COM Port:";
            // 
            // comboBox3
            // 
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(158, 138);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(63, 21);
            this.comboBox3.TabIndex = 54;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.tabPage4.Controls.Add(this.tableLayoutPanel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(560, 343);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Status";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.buttonclear, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.gbStatus, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(560, 343);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // buttonclear
            // 
            this.buttonclear.Checked = false;
            this.buttonclear.Location = new System.Drawing.Point(2, 303);
            this.buttonclear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonclear.Name = "buttonclear";
            this.buttonclear.Size = new System.Drawing.Size(87, 37);
            this.buttonclear.TabIndex = 4;
            this.buttonclear.Text = "Clear";
            this.buttonclear.Click += new System.EventHandler(this.buttonclear_Click);
            // 
            // gbStatus
            // 
            this.gbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gbStatus.Controls.Add(this.lvLog);
            this.gbStatus.Location = new System.Drawing.Point(2, 3);
            this.gbStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.gbStatus.Size = new System.Drawing.Size(556, 294);
            this.gbStatus.TabIndex = 10;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // lvLog
            // 
            this.lvLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_5});
            this.lvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLog.HideSelection = false;
            this.lvLog.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.lvLog.Location = new System.Drawing.Point(11, 25);
            this.lvLog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(534, 257);
            this.lvLog.TabIndex = 1;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_5
            // 
            this.columnHeader_5.Text = "Log Details";
            this.columnHeader_5.Width = 466;
            // 
            // button2
            // 
            this.button2.Checked = false;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(2, 293);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 59);
            this.button2.TabIndex = 4;
            this.button2.Text = "Start Log";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // columnHeader_0
            // 
            this.columnHeader_0.Text = "PID";
            // 
            // columnHeader_1
            // 
            this.columnHeader_1.Text = "Description";
            this.columnHeader_1.Width = 101;
            // 
            // columnHeader_2
            // 
            this.columnHeader_2.Text = "Current";
            this.columnHeader_2.Width = 92;
            // 
            // columnHeader_3
            // 
            this.columnHeader_3.Text = "Min";
            // 
            // columnHeader_4
            // 
            this.columnHeader_4.Text = "Max";
            // 
            // listBoxPIDs
            // 
            this.listBoxPIDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.listBoxPIDs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxPIDs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPIDs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxPIDs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.listBoxPIDs.FormattingEnabled = true;
            this.listBoxPIDs.ItemHeight = 18;
            this.listBoxPIDs.Location = new System.Drawing.Point(2, 3);
            this.listBoxPIDs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxPIDs.Name = "listBoxPIDs";
            this.listBoxPIDs.Size = new System.Drawing.Size(149, 284);
            this.listBoxPIDs.TabIndex = 0;
            this.listBoxPIDs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxPIDs_KeyDown);
            this.listBoxPIDs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPIDs_MouseDoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox5.Controls.Add(this.trackBar1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(155, 293);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.groupBox5.Size = new System.Drawing.Size(403, 59);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Refresh rate:";
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.White;
            this.trackBar1.Location = new System.Drawing.Point(0, 16);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(159, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 250;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 5;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel12.Controls.Add(this.Graph1, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.Graph2, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.Graph4, 3, 0);
            this.tableLayoutPanel12.Controls.Add(this.Gstart, 4, 0);
            this.tableLayoutPanel12.Controls.Add(this.Graph3, 2, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(58, 321);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(500, 32);
            this.tableLayoutPanel12.TabIndex = 18;
            // 
            // timer_2
            // 
            this.timer_2.Interval = 250;
            this.timer_2.Tick += new System.EventHandler(this.timer_2_Tick);
            // 
            // timer_3
            // 
            this.timer_3.Enabled = true;
            this.timer_3.Interval = 1000;
            this.timer_3.Tick += new System.EventHandler(this.timer_3_Tick);
            // 
            // timer_4
            // 
            this.timer_4.Interval = 200;
            this.timer_4.Tick += new System.EventHandler(this.timer_4_Tick);
            // 
            // timer_5
            // 
            this.timer_5.Interval = 5000;
            // 
            // timer_6
            // 
            this.timer_6.Interval = 1000;
            this.timer_6.Tick += new System.EventHandler(this.timer_6_Tick);
            // 
            // timer_0
            // 
            this.timer_0.Interval = 50;
            this.timer_0.Tick += new System.EventHandler(this.timer_0_Tick);
            // 
            // frmOBD2Scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 381);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOBD2Scan";
            this.ShowIcon = false;
            this.Text = "Honda OBD2 Scan Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOBD2Scan_FormClosing);
            this.Load += new System.EventHandler(this.frmOBD2Scan_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    private void listBoxCEL_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.txtDTCD.Text = this.method_36(this.listBoxCEL.SelectedItem.ToString());
            if (this.txtDTCD.Text == "Unknown Code")
            {
                this.listBoxCEL.Items.Remove(this.listBoxCEL.SelectedItem);
                this.txtDTCD.Text = "No Codes";
            }
        }
        catch
        {
        }
    }

    private void listBoxPIDs_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void listBoxPIDs_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        this.method_26();
    }

    private void listViewLive_KeyDown(object sender, KeyEventArgs e)
    {
        if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Enter))
        {
            this.method_20();
        }
    }

    private void listViewLive_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        this.method_27();
    }

    private void livegraph1_DoubleClick(object sender, EventArgs e)
    {
        this.method_15(this.Graph1.Text, 1);
    }

    private void livegraph2_DoubleClick(object sender, EventArgs e)
    {
        this.method_15(this.Graph2.Text, 2);
    }

    private void livegraph3_DoubleClick(object sender, EventArgs e)
    {
        this.method_15(this.Graph3.Text, 3);
    }

    private void livegraph4_DoubleClick(object sender, EventArgs e)
    {
        this.method_15(this.Graph4.Text, 4);
    }

    private void method_0()
    {
        color_0 = this.GColour1.BackColor = color_0;
        color_1 = this.GColour2.BackColor = color_1;
        color_2 = this.GColourLF.BackColor = color_2;
        color_3 = this.GColourL1.BackColor = color_3;
        color_4 = this.GColourL2.BackColor = color_4;
        color_5 = this.GColourL3.BackColor = color_5;
        color_6 = this.GColourL4.BackColor = color_6;
    }

    private void method_1()
    {
        this.livegraph1.GClass3_0.Color_1 = this.GColour1.BackColor;
        this.livegraph1.GClass3_0.Color_0 = this.GColour2.BackColor;
        this.livegraph2.GClass3_0.Color_1 = this.GColour1.BackColor;
        this.livegraph2.GClass3_0.Color_0 = this.GColour2.BackColor;
        this.livegraph3.GClass3_0.Color_1 = this.GColour1.BackColor;
        this.livegraph3.GClass3_0.Color_0 = this.GColour2.BackColor;
        this.livegraph4.GClass3_0.Color_1 = this.GColour1.BackColor;
        this.livegraph4.GClass3_0.Color_0 = this.GColour2.BackColor;
        this.livegraph1.GClass3_0.GClass4_3.Color_0 = this.GColourL1.BackColor;
        this.livegraph2.GClass3_0.GClass4_3.Color_0 = this.GColourL2.BackColor;
        this.livegraph3.GClass3_0.GClass4_3.Color_0 = this.GColourL3.BackColor;
        this.livegraph4.GClass3_0.GClass4_3.Color_0 = this.GColourL4.BackColor;
        color_0 = this.GColour1.BackColor;
        color_1 = this.GColour2.BackColor;
        color_2 = this.GColourLF.BackColor;
        color_3 = this.GColourL1.BackColor;
        color_4 = this.GColourL2.BackColor;
        color_5 = this.GColourL3.BackColor;
        color_6 = this.GColourL4.BackColor;
    }

    private void method_10()
    {
        this.cbBaud.Visible = true;
        this.cbPort.Visible = true;
        this.label1.Visible = true;
        this.descPort.Text = "Port Name";
        this.descRate.Text = "Baud Rate";
    }

    private void method_11()
    {
        this.cbBaud.Visible = false;
        this.cbPort.Visible = false;
        this.label1.Visible = false;
    }

    public void method_12(string string_21)
    {
        try
        {
            string[] strArray = Regex.Split(string_21, "43");
            for (int i = 1; i < strArray.Length; i++)
            {
                this.method_16(strArray[i]);
            }
        }
        catch
        {
        }
    }

    public string method_13(string string_21, string string_22) => 
        Regex.Split(string_21, string_22)[1].Replace(" ", string.Empty).Replace(" ", string.Empty).Substring(0, 8).Replace("0", "0000").Replace("1", "0001").Replace("2", "0010").Replace("3", "0011").Replace("4", "0100").Replace("5", "0101").Replace("6", "0110").Replace("7", "0111").Replace("8", "1000").Replace("9", "1001").Replace("A", "1010").Replace("B", "1011").Replace("C", "1100").Replace("D", "1101").Replace("E", "1110").Replace("F", "1111");

    public void method_14(string string_21, int int_194)
    {
        if (int_194 == 0)
        {
            try
            {
                string str = this.method_13(string_21, "41 00 ");
                this.int_6 = int.Parse(str.Substring(0, 1));
                this.int_7 = int.Parse(str.Substring(1, 1));
                this.int_8 = int.Parse(str.Substring(2, 1));
                this.int_9 = int.Parse(str.Substring(3, 1));
                this.int_10 = int.Parse(str.Substring(4, 1));
                this.int_11 = int.Parse(str.Substring(5, 1));
                this.int_12 = int.Parse(str.Substring(6, 1));
                this.int_13 = int.Parse(str.Substring(7, 1));
                this.int_14 = int.Parse(str.Substring(8, 1));
                this.int_15 = int.Parse(str.Substring(9, 1));
                this.int_16 = int.Parse(str.Substring(10, 1));
                this.int_17 = int.Parse(str.Substring(11, 1));
                this.int_18 = int.Parse(str.Substring(12, 1));
                this.int_19 = int.Parse(str.Substring(13, 1));
                this.int_20 = int.Parse(str.Substring(14, 1));
                this.int_21 = int.Parse(str.Substring(15, 1));
                this.int_22 = int.Parse(str.Substring(0x10, 1));
                this.int_23 = int.Parse(str.Substring(0x11, 1));
                this.int_24 = int.Parse(str.Substring(0x12, 1));
                this.int_25 = int.Parse(str.Substring(0x13, 1));
                this.int_26 = int.Parse(str.Substring(20, 1));
                this.int_27 = int.Parse(str.Substring(0x15, 1));
                this.int_28 = int.Parse(str.Substring(0x16, 1));
                this.int_29 = int.Parse(str.Substring(0x17, 1));
                this.int_30 = int.Parse(str.Substring(0x18, 1));
                this.int_31 = int.Parse(str.Substring(0x19, 1));
                this.int_32 = int.Parse(str.Substring(0x1a, 1));
                this.int_33 = int.Parse(str.Substring(0x1b, 1));
                this.int_34 = int.Parse(str.Substring(0x1c, 1));
                this.int_35 = int.Parse(str.Substring(0x1d, 1));
                this.int_36 = int.Parse(str.Substring(30, 1));
            }
            catch
            {
            }
        }
        if (int_194 == 1)
        {
            try
            {
                string str2 = this.method_13(string_21, "41 20 ");
                this.int_38 = int.Parse(str2.Substring(0, 1));
                this.int_39 = int.Parse(str2.Substring(1, 1));
                this.int_40 = int.Parse(str2.Substring(2, 1));
                this.int_41 = int.Parse(str2.Substring(3, 1));
                this.int_42 = int.Parse(str2.Substring(4, 1));
                this.int_43 = int.Parse(str2.Substring(5, 1));
                this.int_44 = int.Parse(str2.Substring(6, 1));
                this.int_45 = int.Parse(str2.Substring(7, 1));
                this.int_46 = int.Parse(str2.Substring(8, 1));
                this.int_47 = int.Parse(str2.Substring(9, 1));
                this.int_48 = int.Parse(str2.Substring(10, 1));
                this.int_49 = int.Parse(str2.Substring(11, 1));
                this.int_50 = int.Parse(str2.Substring(12, 1));
                this.int_51 = int.Parse(str2.Substring(13, 1));
                this.int_52 = int.Parse(str2.Substring(14, 1));
                this.int_53 = int.Parse(str2.Substring(15, 1));
                this.int_54 = int.Parse(str2.Substring(0x10, 1));
                this.int_55 = int.Parse(str2.Substring(0x11, 1));
                this.int_56 = int.Parse(str2.Substring(0x12, 1));
                this.int_57 = int.Parse(str2.Substring(0x13, 1));
                this.int_58 = int.Parse(str2.Substring(20, 1));
                this.int_59 = int.Parse(str2.Substring(0x15, 1));
                this.int_60 = int.Parse(str2.Substring(0x16, 1));
                this.int_61 = int.Parse(str2.Substring(0x17, 1));
                this.int_62 = int.Parse(str2.Substring(0x18, 1));
                this.int_63 = int.Parse(str2.Substring(0x19, 1));
                this.int_64 = int.Parse(str2.Substring(0x1a, 1));
                this.int_65 = int.Parse(str2.Substring(0x1b, 1));
                this.int_66 = int.Parse(str2.Substring(0x1c, 1));
                this.int_67 = int.Parse(str2.Substring(0x1d, 1));
                this.int_68 = int.Parse(str2.Substring(30, 1));
            }
            catch
            {
            }
        }
        if (int_194 == 2)
        {
            try
            {
                string str3 = this.method_13(string_21, "41 40 ");
                this.int_70 = int.Parse(str3.Substring(0, 1));
                this.int_71 = int.Parse(str3.Substring(1, 1));
                this.int_72 = int.Parse(str3.Substring(2, 1));
                this.int_73 = int.Parse(str3.Substring(3, 1));
                this.int_74 = int.Parse(str3.Substring(4, 1));
                this.int_75 = int.Parse(str3.Substring(5, 1));
                this.int_76 = int.Parse(str3.Substring(6, 1));
                this.int_77 = int.Parse(str3.Substring(7, 1));
                this.int_78 = int.Parse(str3.Substring(8, 1));
                this.int_79 = int.Parse(str3.Substring(9, 1));
                this.int_80 = int.Parse(str3.Substring(10, 1));
                this.int_81 = int.Parse(str3.Substring(11, 1));
                this.int_82 = int.Parse(str3.Substring(12, 1));
                this.int_83 = int.Parse(str3.Substring(13, 1));
                this.int_84 = int.Parse(str3.Substring(14, 1));
                this.int_85 = int.Parse(str3.Substring(15, 1));
                this.int_86 = int.Parse(str3.Substring(0x10, 1));
                this.int_87 = int.Parse(str3.Substring(0x11, 1));
                this.int_88 = int.Parse(str3.Substring(0x12, 1));
                this.int_89 = int.Parse(str3.Substring(0x13, 1));
                this.int_90 = int.Parse(str3.Substring(20, 1));
                this.int_91 = int.Parse(str3.Substring(0x15, 1));
                this.int_92 = int.Parse(str3.Substring(0x16, 1));
                this.int_93 = int.Parse(str3.Substring(0x17, 1));
                this.int_94 = int.Parse(str3.Substring(0x18, 1));
                this.int_95 = int.Parse(str3.Substring(0x19, 1));
                this.int_96 = int.Parse(str3.Substring(0x1a, 1));
                this.int_97 = int.Parse(str3.Substring(0x1b, 1));
                this.int_98 = int.Parse(str3.Substring(0x1c, 1));
                this.int_99 = int.Parse(str3.Substring(0x1d, 1));
                this.int_100 = int.Parse(str3.Substring(30, 1));
            }
            catch
            {
            }
        }
        if (int_194 == 3)
        {
            try
            {
                string str4 = this.method_13(string_21, "41 60 ");
                this.int_102 = int.Parse(str4.Substring(0, 1));
                this.int_103 = int.Parse(str4.Substring(1, 1));
                this.int_104 = int.Parse(str4.Substring(2, 1));
                this.int_105 = int.Parse(str4.Substring(3, 1));
                this.int_106 = int.Parse(str4.Substring(4, 1));
                this.int_107 = int.Parse(str4.Substring(5, 1));
                this.int_108 = int.Parse(str4.Substring(6, 1));
                this.int_109 = int.Parse(str4.Substring(7, 1));
                this.int_110 = int.Parse(str4.Substring(8, 1));
                this.int_111 = int.Parse(str4.Substring(9, 1));
                this.int_112 = int.Parse(str4.Substring(10, 1));
                this.int_113 = int.Parse(str4.Substring(11, 1));
                this.int_114 = int.Parse(str4.Substring(12, 1));
                this.int_115 = int.Parse(str4.Substring(13, 1));
                this.int_116 = int.Parse(str4.Substring(14, 1));
                this.int_117 = int.Parse(str4.Substring(15, 1));
                this.int_118 = int.Parse(str4.Substring(0x10, 1));
                this.int_119 = int.Parse(str4.Substring(0x11, 1));
                this.int_120 = int.Parse(str4.Substring(0x12, 1));
                this.int_121 = int.Parse(str4.Substring(0x13, 1));
                this.int_122 = int.Parse(str4.Substring(20, 1));
                this.int_123 = int.Parse(str4.Substring(0x15, 1));
                this.int_124 = int.Parse(str4.Substring(0x16, 1));
                this.int_125 = int.Parse(str4.Substring(0x17, 1));
                this.int_126 = int.Parse(str4.Substring(0x18, 1));
                this.int_127 = int.Parse(str4.Substring(0x19, 1));
                this.int_128 = int.Parse(str4.Substring(0x1a, 1));
                this.int_129 = int.Parse(str4.Substring(0x1b, 1));
                this.int_130 = int.Parse(str4.Substring(0x1c, 1));
                this.int_131 = int.Parse(str4.Substring(0x1d, 1));
                this.int_132 = int.Parse(str4.Substring(30, 1));
            }
            catch
            {
            }
        }
        if (int_194 == 4)
        {
            try
            {
                string str5 = this.method_13(string_21, "41 80 ");
                this.int_134 = int.Parse(str5.Substring(0, 1));
                this.int_135 = int.Parse(str5.Substring(1, 1));
                this.int_136 = int.Parse(str5.Substring(2, 1));
                this.int_137 = int.Parse(str5.Substring(3, 1));
                this.int_138 = int.Parse(str5.Substring(4, 1));
                this.int_139 = int.Parse(str5.Substring(5, 1));
                this.int_140 = int.Parse(str5.Substring(6, 1));
                this.int_141 = int.Parse(str5.Substring(7, 1));
                this.int_142 = int.Parse(str5.Substring(8, 1));
                this.int_143 = int.Parse(str5.Substring(9, 1));
                this.int_144 = int.Parse(str5.Substring(10, 1));
                this.int_145 = int.Parse(str5.Substring(11, 1));
                this.int_146 = int.Parse(str5.Substring(12, 1));
                this.int_147 = int.Parse(str5.Substring(13, 1));
                this.int_148 = int.Parse(str5.Substring(14, 1));
                this.int_149 = int.Parse(str5.Substring(15, 1));
                this.int_150 = int.Parse(str5.Substring(0x10, 1));
                this.int_151 = int.Parse(str5.Substring(0x11, 1));
                this.int_152 = int.Parse(str5.Substring(0x12, 1));
                this.int_153 = int.Parse(str5.Substring(0x13, 1));
                this.int_154 = int.Parse(str5.Substring(20, 1));
                this.int_155 = int.Parse(str5.Substring(0x15, 1));
                this.int_156 = int.Parse(str5.Substring(0x16, 1));
                this.int_157 = int.Parse(str5.Substring(0x17, 1));
                this.int_158 = int.Parse(str5.Substring(0x18, 1));
                this.int_159 = int.Parse(str5.Substring(0x19, 1));
                this.int_160 = int.Parse(str5.Substring(0x1a, 1));
                this.int_161 = int.Parse(str5.Substring(0x1b, 1));
                this.int_162 = int.Parse(str5.Substring(0x1c, 1));
                this.int_163 = int.Parse(str5.Substring(0x1d, 1));
                this.int_164 = int.Parse(str5.Substring(30, 1));
            }
            catch
            {
            }
        }
        if (int_194 == 5)
        {
            try
            {
                string str6 = this.method_13(string_21, "41 A0 ");
                this.int_166 = int.Parse(str6.Substring(0, 1));
                this.int_167 = int.Parse(str6.Substring(1, 1));
                this.int_168 = int.Parse(str6.Substring(2, 1));
                this.int_169 = int.Parse(str6.Substring(3, 1));
                this.int_170 = int.Parse(str6.Substring(4, 1));
                this.int_171 = int.Parse(str6.Substring(5, 1));
                this.int_172 = int.Parse(str6.Substring(6, 1));
                this.int_173 = int.Parse(str6.Substring(7, 1));
                this.int_174 = int.Parse(str6.Substring(8, 1));
                this.int_175 = int.Parse(str6.Substring(9, 1));
                this.int_176 = int.Parse(str6.Substring(10, 1));
                this.int_177 = int.Parse(str6.Substring(11, 1));
                this.int_178 = int.Parse(str6.Substring(12, 1));
                this.int_179 = int.Parse(str6.Substring(13, 1));
                this.int_180 = int.Parse(str6.Substring(14, 1));
            }
            catch
            {
            }
        }
    }

    private void method_15(string string_21, int int_194)
    {
        if (this.timer_0.Enabled && (int_186 == 0))
        {
            string_20 = string_21;
            int_186 = int_194;
            LineG eg1 = new LineG();
            eg1.StartPosition = FormStartPosition.Manual;
            eg1.Location = new Point(base.Location.X, base.Location.Y);
            eg1.Show();
        }
    }

    private void method_16(string string_21)
    {
        char[] separator = new char[] { ' ' };
        string[] strArray = string_21.Split(separator);
        string str = "NO DATA";
        string str2 = "NO DATA";
        string str3 = "NO DATA";
        try
        {
            str = "P" + strArray[1] + strArray[2];
        }
        catch
        {
            str = "P0000";
        }
        try
        {
            str2 = "P" + strArray[3] + strArray[4];
        }
        catch
        {
            str2 = "P0000";
        }
        try
        {
            str3 = "P" + strArray[5] + strArray[6];
        }
        catch
        {
            str3 = "P0000";
        }
        if (!this.listBoxCEL.Items.Contains(str) && !str.Contains("P0000"))
        {
            this.listBoxCEL.Items.Add(str);
        }
        if (!this.listBoxCEL.Items.Contains(str2) && !str2.Contains("P0000"))
        {
            this.listBoxCEL.Items.Add(str2);
        }
        if (!this.listBoxCEL.Items.Contains(str3) && !str3.Contains("P0000"))
        {
            this.listBoxCEL.Items.Add(str3);
        }
    }

    private void method_17()
    {
        this.bool_5 = true;
        this.int_5 = 0;
        this.int_37 = 0;
        this.int_69 = 0;
        this.int_101 = 0;
        this.int_133 = 0;
        this.int_165 = 0;
        this.int_181 = 0;
        this.int_182 = 0;
        this.int_6 = 0;
        this.int_7 = 0;
        this.int_8 = 0;
        this.int_9 = 0;
        this.int_10 = 0;
        this.int_11 = 0;
        this.int_12 = 0;
        this.int_13 = 0;
        this.int_14 = 0;
        this.int_15 = 0;
        this.int_16 = 0;
        this.int_17 = 0;
        this.int_18 = 0;
        this.int_19 = 0;
        this.int_20 = 0;
        this.int_21 = 0;
        this.int_22 = 0;
        this.int_23 = 0;
        this.int_24 = 0;
        this.int_25 = 0;
        this.int_26 = 0;
        this.int_27 = 0;
        this.int_28 = 0;
        this.int_29 = 0;
        this.int_30 = 0;
        this.int_31 = 0;
        this.int_32 = 0;
        this.int_33 = 0;
        this.int_34 = 0;
        this.int_35 = 0;
        this.int_36 = 0;
        this.int_38 = 0;
        this.int_39 = 0;
        this.int_40 = 0;
        this.int_41 = 0;
        this.int_42 = 0;
        this.int_43 = 0;
        this.int_44 = 0;
        this.int_45 = 0;
        this.int_46 = 0;
        this.int_47 = 0;
        this.int_48 = 0;
        this.int_49 = 0;
        this.int_50 = 0;
        this.int_51 = 0;
        this.int_52 = 0;
        this.int_53 = 0;
        this.int_54 = 0;
        this.int_55 = 0;
        this.int_56 = 0;
        this.int_57 = 0;
        this.int_58 = 0;
        this.int_59 = 0;
        this.int_60 = 0;
        this.int_61 = 0;
        this.int_62 = 0;
        this.int_63 = 0;
        this.int_64 = 0;
        this.int_65 = 0;
        this.int_66 = 0;
        this.int_67 = 0;
        this.int_68 = 0;
        this.int_70 = 0;
        this.int_71 = 0;
        this.int_72 = 0;
        this.int_73 = 0;
        this.int_74 = 0;
        this.int_75 = 0;
        this.int_76 = 0;
        this.int_77 = 0;
        this.int_78 = 0;
        this.int_79 = 0;
        this.int_80 = 0;
        this.int_81 = 0;
        this.int_82 = 0;
        this.int_83 = 0;
        this.int_84 = 0;
        this.int_85 = 0;
        this.int_86 = 0;
        this.int_87 = 0;
        this.int_88 = 0;
        this.int_89 = 0;
        this.int_90 = 0;
        this.int_91 = 0;
        this.int_92 = 0;
        this.int_93 = 0;
        this.int_94 = 0;
        this.int_95 = 0;
        this.int_96 = 0;
        this.int_97 = 0;
        this.int_98 = 0;
        this.int_99 = 0;
        this.int_100 = 0;
        this.int_102 = 0;
        this.int_103 = 0;
        this.int_104 = 0;
        this.int_105 = 0;
        this.int_106 = 0;
        this.int_107 = 0;
        this.int_108 = 0;
        this.int_109 = 0;
        this.int_110 = 0;
        this.int_111 = 0;
        this.int_112 = 0;
        this.int_113 = 0;
        this.int_114 = 0;
        this.int_115 = 0;
        this.int_116 = 0;
        this.int_117 = 0;
        this.int_118 = 0;
        this.int_119 = 0;
        this.int_120 = 0;
        this.int_121 = 0;
        this.int_122 = 0;
        this.int_123 = 0;
        this.int_124 = 0;
        this.int_125 = 0;
        this.int_126 = 0;
        this.int_127 = 0;
        this.int_128 = 0;
        this.int_129 = 0;
        this.int_130 = 0;
        this.int_131 = 0;
        this.int_132 = 0;
        this.int_134 = 0;
        this.int_135 = 0;
        this.int_136 = 0;
        this.int_137 = 0;
        this.int_138 = 0;
        this.int_139 = 0;
        this.int_140 = 0;
        this.int_141 = 0;
        this.int_142 = 0;
        this.int_143 = 0;
        this.int_144 = 0;
        this.int_145 = 0;
        this.int_146 = 0;
        this.int_147 = 0;
        this.int_148 = 0;
        this.int_149 = 0;
        this.int_150 = 0;
        this.int_151 = 0;
        this.int_152 = 0;
        this.int_153 = 0;
        this.int_154 = 0;
        this.int_155 = 0;
        this.int_156 = 0;
        this.int_157 = 0;
        this.int_158 = 0;
        this.int_159 = 0;
        this.int_160 = 0;
        this.int_161 = 0;
        this.int_162 = 0;
        this.int_163 = 0;
        this.int_164 = 0;
        this.int_166 = 0;
        this.int_167 = 0;
        this.int_168 = 0;
        this.int_169 = 0;
        this.int_170 = 0;
        this.int_171 = 0;
        this.int_172 = 0;
        this.int_173 = 0;
        this.int_174 = 0;
        this.int_175 = 0;
        this.int_176 = 0;
        this.int_177 = 0;
        this.int_178 = 0;
        this.int_179 = 0;
        this.int_180 = 0;
        this.int_181 = 0;
        this.int_182 = 0;
    }

    private void method_18()
    {
        if (this.int_2 == 0)
        {
            this.cbBaud.Enabled = true;
            this.cbPort.Enabled = true;
            this.button1.Text = "Connect";
            this.cbJ2534.Visible = true;
            this.Text = "OBD2 Scan Tool: Disconnected: ";
            this.timer_6.Enabled = false;
            this.timer_4.Enabled = false;
            this.method_17();
        }
        else if (this.int_2 == 1)
        {
            this.button1.Text = "Disconnect";
            this.gbStatus.Visible = true;
            this.cbJ2534.Visible = false;
            this.Text = "OBD2 Scan Tool: Connected: ";
        }
        else
        {
            this.button1.Text = "Connecting";
            this.gbStatus.Visible = true;
            this.Text = "OBD2 Scan Tool: Connecting....";
            this.method_17();
        }
    }

    private void method_19(string string_21)
    {
        if (!this.bool_8)
        {
            this.string_6 = string_21 + "\r";
            if (string_21 != null)
            {
                if (!(string_21 == "03"))
                {
                    if (string_21 == "04")
                    {
                        this.string_6 = "CLEARDTC";
                    }
                }
                else
                {
                    this.string_6 = "CEL";
                }
            }
            try
            {
                this.serialPort_0.Write(string_21 + "\r");
                return;
            }
            catch (Exception)
            {
                return;
            }
        }
        try
        {
            byte[] array = frmOBD2Scan.smethod_1(string_21);
            Channel channel = this.channel_0;
            byte[] array2 = new byte[]
            {
            0,
            0,
            7,
            224,
            2,
            0,
            0,
            0,
            0,
            0,
            0,
            0
            };
            array2[5] = array[0];
            array2[6] = array[1];
            channel.SendMessage(array2);
        }
        catch
        {
        }
    }

    private void method_2()
    {
        this.Graph1.Items.Clear();
        this.Graph2.Items.Clear();
        this.Graph3.Items.Clear();
        this.Graph4.Items.Clear();
        this.comboV.Items.Clear();
        try
        {
            if (bool_10)
            {
                for (int i = 0; i < this.listViewLive.Items.Count; i++)
                {
                    this.Graph1.Items.Add(this.listViewLive.Items[i].SubItems[0].Text);
                    this.Graph2.Items.Add(this.listViewLive.Items[i].SubItems[0].Text);
                    this.Graph3.Items.Add(this.listViewLive.Items[i].SubItems[0].Text);
                    this.Graph4.Items.Add(this.listViewLive.Items[i].SubItems[0].Text);
                    this.comboV.Items.Add(this.listViewLive.Items[i].SubItems[0].Text);
                }
            }
            else
            {
                for (int i = 0; i < this.listViewLive.Items.Count; i++)
                {
                    this.Graph1.Items.Add(this.listViewLive.Items[i].SubItems[1].Text);
                    this.Graph2.Items.Add(this.listViewLive.Items[i].SubItems[1].Text);
                    this.Graph3.Items.Add(this.listViewLive.Items[i].SubItems[1].Text);
                    this.Graph4.Items.Add(this.listViewLive.Items[i].SubItems[1].Text);
                    this.comboV.Items.Add(this.listViewLive.Items[i].SubItems[1].Text);
                }
            }
        }
        catch
        {
        }
    }

    private void method_20()
    {
        int num = 0;
        foreach (ListViewItem item1 in this.listViewLive.Items)
        {
            this.listViewLive.Items[num].SubItems[3].Text = "000";
            this.listViewLive.Items[num].SubItems[4].Text = "000";
            num++;
        }
    }

    private void method_21(string string_21)
    {
        this.lvLog.Items.Add(new ListViewItem(string_21, 2));
    }

    private void method_22(string string_21)
    {
        this.lvLog.Items.Add(new ListViewItem(string_21, 1));
    }

    private void method_23(string string_21)
    {
        this.lvLog.Items.Add(new ListViewItem(string_21, 0));
    }

    private void method_24(string string_21, int int_194)
    {
        this.lvLog.Items.Add(new ListViewItem(string_21, int_194));
    }

    private void method_25(string string_21)
    {
        this.lvLog.Items.Add(new ListViewItem(string_21, 3));
    }

    private void method_26()
    {
        if (!this.timer_4.Enabled)
        {
            int num = 0;
            foreach (object obj in this.listViewLive.Items)
            {
                ListViewItem listViewItem = (ListViewItem)obj;
                StringBuilder stringBuilder = new StringBuilder(this.listViewLive.Items[num].SubItems[1].Text);
                string value = stringBuilder.Replace("BTDC", "Timing Advance").Replace("Load%", "Engine Load").Replace("STFT", "Short Term Fuel").ToString();
                if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem).Contains(value))
                {
                    return;
                }
                num++;
            }
            if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "MAP")
            {
                string[] items = new string[]
                {
                "MAP",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("0B").SubItems.AddRange(items);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "RPM")
            {
                string[] items2 = new string[]
                {
                "RPM",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("0C").SubItems.AddRange(items2);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "TPS")
            {
                string[] items3 = new string[]
                {
                "TPS",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("11").SubItems.AddRange(items3);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Speed")
            {
                string[] items4 = new string[]
                {
                "Speed",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("0D").SubItems.AddRange(items4);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "O2")
            {
                string[] items5 = new string[]
                {
                "O2",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("14").SubItems.AddRange(items5);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "IAT")
            {
                string[] items6 = new string[]
                {
                "IAT",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("0F").SubItems.AddRange(items6);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "ECT")
            {
                string[] items7 = new string[]
                {
                "ECT",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("05").SubItems.AddRange(items7);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Short Term Fuel Trim")
            {
                string[] items8 = new string[]
                {
                "STFT",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("06").SubItems.AddRange(items8);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Timing Advance")
            {
                string[] items9 = new string[]
                {
                "BTDC",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("0E").SubItems.AddRange(items9);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Engine Load")
            {
                string[] items10 = new string[]
                {
                "Load%",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("04").SubItems.AddRange(items10);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Battery")
            {
                string[] items11 = new string[]
                {
                "Battery",
                "000",
                "000",
                "000"
                };
                this.listViewLive.Items.Add("9A").SubItems.AddRange(items11);
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Fuel System Status")
            {
                this.bool_6 = true;
                this.method_19("0103");
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Oxygen Sensors Present")
            {
                this.bool_6 = true;
                this.method_19("0113");
            }
            else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "OBD Compliance")
            {
                this.bool_6 = true;
                this.method_19("011C");
            }
        }
        this.method_2();
    }

    private void method_27()
    {
        if (!this.timer_4.Enabled)
        {
            try
            {
                this.listViewLive.SelectedItems[0].Remove();
            }
            catch
            {
            }
        }
    }

    private void method_28(object sender, EventArgs e)
    {
        this.method_27();
    }

    private void method_29()
    {
        this.timer_6.Enabled = true;
        SAE.J2534.Message message = new SAE.J2534.Message(new byte[] { 0x18, 0xda, 0x10, 0xf1, 0x22, 0x26, 0x10 }, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
        SAE.J2534.Message message2 = new SAE.J2534.Message(new byte[] { 0x18, 0xda, 0x10, 0xf1, 0x22, 0x26, 0x11 }, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
        SAE.J2534.Message message3 = new SAE.J2534.Message(new byte[] { 0x18, 0xda, 0x10, 0xf1, 0x22, 0x26, 0x12 }, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
        SAE.J2534.Message message4 = new SAE.J2534.Message(new byte[] { 0x18, 0xda, 0x10, 0xf1, 0x22, 0x26, 0x62 }, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
        SAE.J2534.Message message5 = new SAE.J2534.Message(new byte[] { 0x18, 0xda, 0x10, 0xf1, 0x22, 0x26, 0x68 }, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
        if (!bool_10)
        {
            while (bool_11)
            {
                GetMessageResults messages = this.channel_0.GetMessages(2, 5);
                if (!messages.Result.IsOK())
                {
                    Thread.Sleep(5);
                    continue;
                }
                foreach (SAE.J2534.Message message6 in messages.Messages)
                {
                    this.int_0++;
                    string str = smethod_2(message6.Data);
                    this.method_32(str);
                    this.method_35(str);
                }
            }
        }
        else
        {
            using (API api = APIFactory.GetAPI(this.string_19))
            {
                using (Device device = api.GetDevice(""))
                {
                    using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false))
                    {
                        MessageFilter filter = new MessageFilter {
                            FilterType = Filter.FLOW_CONTROL_FILTER,
                            Mask = new byte[] { 
                                0xff,
                                0xff,
                                0xff,
                                0xff
                            },
                            Pattern = new byte[] { 
                                0x18,
                                0xda,
                                0xf1,
                                0x10
                            },
                            FlowControl = new byte[] { 
                                0x18,
                                0xda,
                                0x10,
                                0xf1
                            }
                        };
                        channel.StartMsgFilter(filter);
                        SConfig[] sConfig = new SConfig[] { new SConfig(Parameter.LOOP_BACK, 1), new SConfig(Parameter.DATA_RATE, 0x7a120) };
                        channel.SetConfig(sConfig);
                        while (bool_11)
                        {
                            Application.DoEvents();
                            try
                            {
                                channel.SendMessage(message);
                                if (!channel.IsDisposed)
                                {
                                    GetMessageResults messages = channel.GetMessages(5, 50);
                                    if (messages.Result.IsOK())
                                    {
                                        foreach (SAE.J2534.Message message7 in messages.Messages)
                                        {
                                            string str2 = smethod_2(message7.Data).TrimEnd(new char[0]);
                                            if (str2.Length > 0x18)
                                            {
                                                this.int_0++;
                                                this.method_44(str2);
                                            }
                                        }
                                    }
                                    channel.SendMessage(message2);
                                    if (!channel.IsDisposed)
                                    {
                                        messages = channel.GetMessages(5, 50);
                                        if (messages.Result.IsOK())
                                        {
                                            foreach (SAE.J2534.Message message8 in messages.Messages)
                                            {
                                                string str3 = smethod_2(message8.Data).TrimEnd(new char[0]);
                                                if (str3.Length > 0x18)
                                                {
                                                    this.int_0++;
                                                    this.method_44(str3);
                                                }
                                            }
                                        }
                                        channel.SendMessage(message3);
                                        if (!channel.IsDisposed)
                                        {
                                            messages = channel.GetMessages(5, 50);
                                            if (messages.Result.IsOK())
                                            {
                                                foreach (SAE.J2534.Message message9 in messages.Messages)
                                                {
                                                    string str4 = smethod_2(message9.Data).TrimEnd(new char[0]);
                                                    if (str4.Length > 0x18)
                                                    {
                                                        this.int_0++;
                                                        this.method_44(str4);
                                                    }
                                                }
                                            }
                                            channel.SendMessage(message4);
                                            if (!channel.IsDisposed)
                                            {
                                                messages = channel.GetMessages(5, 50);
                                                if (messages.Result.IsOK())
                                                {
                                                    foreach (SAE.J2534.Message message10 in messages.Messages)
                                                    {
                                                        string str5 = smethod_2(message10.Data).TrimEnd(new char[0]);
                                                        if (str5.Length > 0x18)
                                                        {
                                                            this.int_0++;
                                                            this.method_44(str5);
                                                        }
                                                    }
                                                }
                                                channel.SendMessage(message5);
                                                if (!channel.IsDisposed)
                                                {
                                                    messages = channel.GetMessages(5, 50);
                                                    if (messages.Result.IsOK())
                                                    {
                                                        foreach (SAE.J2534.Message message11 in messages.Messages)
                                                        {
                                                            string str6 = smethod_2(message11.Data).TrimEnd(new char[0]);
                                                            if (str6.Length > 0x18)
                                                            {
                                                                this.int_0++;
                                                                this.method_44(str6);
                                                            }
                                                        }
                                                    }
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }

    private void method_3()
    {
        int num = 0;
        foreach (ListViewItem item1 in this.listViewLive.Items)
        {
            string text = this.listViewLive.Items[num].SubItems[0].Text;
            if (text != null)
            {
                if (text == "06")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_17;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "14")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_12;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "11")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_9;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "04")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_16;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "05")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_14;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "0E")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_15;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "0F")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_13;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "0D")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_10;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "0B")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_7;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
                else if (text == "0C")
                {
                    try
                    {
                        this.listViewLive.Items[num].SubItems[2].Text = this.string_8;
                        if ((this.listViewLive.Items[num].SubItems[3].Text == "000") || (this.listViewLive.Items[num].SubItems[3].Text == ""))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) <= int.Parse(this.listViewLive.Items[num].SubItems[3].Text))
                        {
                            this.listViewLive.Items[num].SubItems[3].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                        if (int.Parse(this.listViewLive.Items[num].SubItems[2].Text) >= int.Parse(this.listViewLive.Items[num].SubItems[4].Text))
                        {
                            this.listViewLive.Items[num].SubItems[4].Text = this.listViewLive.Items[num].SubItems[2].Text;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            num++;
        }
    }

    private void method_30()
    {
        while (this.serialPort_0.IsOpen)
        {
            while (this.serialPort_0.IsOpen && this.serialPort_0.BytesToRead > 0)
            {
                this.method_11();
                string text = Encoding.ASCII.GetChars(new byte[]
                {
                (byte)this.serialPort_0.ReadByte()
                })[0].ToString();
                if (text == ">")
                {
                    this.method_33(this.stringBuilder_0.ToString());
                    this.stringBuilder_0.Clear();
                }
                else
                {
                    this.stringBuilder_0.Append(text);
                }
                string a = Regex.Replace(this.stringBuilder_0.ToString(), "\\t|\\n|\\r", "");
                if (this.stringBuilder_0.ToString().Length > 1)
                {
                    if (!this.bool_5)
                    {
                        this.method_34();
                    }
                    if (a == this.string_5)
                    {
                        this.int_0++;
                        this.method_22(this.stringBuilder_0.ToString());
                        this.method_32(this.stringBuilder_0.ToString());
                        this.method_35(this.stringBuilder_0.ToString());
                        this.string_5 = "";
                    }
                    else
                    {
                        this.string_5 = a;
                    }
                }
            }
            Thread.Sleep(200);
        }
    }

    private void method_31()
    {
        string[] items = new string[] { "Battery", "000", "000", "000" };
        ListViewItem item = new ListViewItem(items, -1);
        string[] textArray2 = new string[] { "RPM", "000", "000", "000" };
        ListViewItem item2 = new ListViewItem(textArray2, -1);
        string[] textArray3 = new string[] { "RPM2", "000", "000", "000" };
        ListViewItem item3 = new ListViewItem(textArray3, -1);
        string[] textArray4 = new string[] { "RPMRAW", "000", "000", "000" };
        ListViewItem item4 = new ListViewItem(textArray4, -1);
        string[] textArray5 = new string[] { "AFM", "000", "000", "000" };
        ListViewItem item5 = new ListViewItem(textArray5, -1);
        string[] textArray6 = new string[] { "Map", "000", "000", "000" };
        ListViewItem item6 = new ListViewItem(textArray6, -1);
        string[] textArray7 = new string[] { "Ignition Timing", "000", "000", "000" };
        ListViewItem item7 = new ListViewItem(textArray7, -1);
        string[] textArray8 = new string[] { "Pulsewidth", "000", "000", "000" };
        ListViewItem item8 = new ListViewItem(textArray8, -1);
        string[] textArray9 = new string[] { "IAT", "000", "000", "000" };
        ListViewItem item9 = new ListViewItem(textArray9, -1);
        string[] textArray10 = new string[] { "ECT", "000", "000", "000" };
        ListViewItem item10 = new ListViewItem(textArray10, -1);
        string[] textArray11 = new string[] { "VTS", "000", "000", "000" };
        ListViewItem item11 = new ListViewItem(textArray11, -1);
        string[] textArray12 = new string[] { "Wideband", "000", "000", "000" };
        ListViewItem item12 = new ListViewItem(textArray12, -1);
        string[] textArray13 = new string[] { "Target AFR", "000", "000", "000" };
        ListViewItem item13 = new ListViewItem(textArray13, -1);
        string[] textArray14 = new string[] { "STFT", "000", "000", "000" };
        ListViewItem item14 = new ListViewItem(textArray14, -1);
        string[] textArray15 = new string[] { "LTFT", "000", "000", "000" };
        ListViewItem item15 = new ListViewItem(textArray15, -1);
        string[] textArray16 = new string[] { "TPlate", "000", "000", "000" };
        ListViewItem item16 = new ListViewItem(textArray16, -1);
        string[] textArray17 = new string[] { "VSS", "000", "000", "000" };
        ListViewItem item17 = new ListViewItem(textArray17, -1);
        string[] textArray18 = new string[] { "Target Cam Angle", "000", "000", "000" };
        ListViewItem item18 = new ListViewItem(textArray18, -1);
        string[] textArray19 = new string[] { "Cam Angle", "000", "000", "000" };
        ListViewItem item19 = new ListViewItem(textArray19, -1);
        string[] textArray20 = new string[] { "Knock 1", "000", "000", "000" };
        ListViewItem item20 = new ListViewItem(textArray20, -1);
        string[] textArray21 = new string[] { "Knock 2", "000", "000", "000" };
        ListViewItem item21 = new ListViewItem(textArray21, -1);
        string[] textArray22 = new string[] { "Knock 3", "000", "000", "000" };
        ListViewItem item22 = new ListViewItem(textArray22, -1);
        string[] textArray23 = new string[] { "Knock 4", "000", "000", "000" };
        ListViewItem item23 = new ListViewItem(textArray23, -1);
        string[] textArray24 = new string[] { "Knock Sum", "000", "000", "000" };
        ListViewItem item24 = new ListViewItem(textArray24, -1);
        this.listViewLive.Items.Add(item);
        this.listViewLive.Items.Add(item2);
        this.listViewLive.Items.Add(item5);
        this.listViewLive.Items.Add(item6);
        this.listViewLive.Items.Add(item7);
        this.listViewLive.Items.Add(item8);
        this.listViewLive.Items.Add(item9);
        this.listViewLive.Items.Add(item10);
        this.listViewLive.Items.Add(item11);
        this.listViewLive.Items.Add(item12);
        this.listViewLive.Items.Add(item13);
        this.listViewLive.Items.Add(item14);
        this.listViewLive.Items.Add(item15);
        this.listViewLive.Items.Add(item16);
        this.listViewLive.Items.Add(item17);
        this.listViewLive.Items.Add(item18);
        this.listViewLive.Items.Add(item19);
        this.listViewLive.Items.Add(item20);
        this.listViewLive.Items.Add(item21);
        this.listViewLive.Items.Add(item22);
        this.listViewLive.Items.Add(item23);
        this.listViewLive.Items.Add(item24);
        this.listViewLive.Items.Add(item3);
        this.listViewLive.Items.Add(item4);
    }

    public void method_32(string string_21)
    {
        string_21 = string_21.ToUpper();
        try
        {
            if (string_21.ToString().Contains("ELM327"))
            {
                this.string_6 = "ELM";
            }
            if (string_21.ToString().Contains("V"))
            {
                this.string_11 = string_21.Replace("V", "").ToString();
                this.string_11 = float.Parse(Regex.Match(this.string_11, @"\d+").Value).ToString();
            }
            if (string_21.ToString().Contains("41 0B"))
            {
                this.string_6 = "MAP";
            }
            if (string_21.ToString().Contains("41 0C"))
            {
                this.string_6 = "RPM";
            }
            if (string_21.ToString().Contains("41 11"))
            {
                this.string_6 = "TPS";
            }
            if (string_21.ToString().Contains("41 0D"))
            {
                this.string_6 = "Speed";
            }
            if (string_21.ToString().Contains("41 14"))
            {
                this.string_6 = "O2";
            }
            if (string_21.ToString().Contains("41 05"))
            {
                this.string_6 = "ECT";
            }
            if (string_21.ToString().Contains("41 0F"))
            {
                this.string_6 = "IAT";
            }
            if (string_21.ToString().Contains("41 01"))
            {
                this.string_6 = "CEL";
            }
            if (string_21.ToString().Contains("41 0E"))
            {
                this.string_6 = "TA";
            }
            if (string_21.ToString().Contains("41 04"))
            {
                this.string_6 = "EL";
            }
            if (string_21.ToString().Contains("41 03"))
            {
                this.string_6 = "FSS";
            }
            if (string_21.ToString().Contains("41 13"))
            {
                this.string_6 = "OSP";
            }
            if (string_21.ToString().Contains("41 1C"))
            {
                this.string_6 = "OC";
            }
            if (string_21.ToString().Contains("41 06"))
            {
                this.string_6 = "FT";
            }
            if (string_21.ToString().Contains("STOPPED"))
            {
                this.string_6 = "BUFFEROF";
            }
            if (string_21.ToString().Contains("41 00"))
            {
                this.string_6 = "PIDLIST";
            }
            if (string_21.ToString().Contains("41 20"))
            {
                this.string_6 = "PIDLIST2";
            }
            if (string_21.ToString().Contains("41 40"))
            {
                this.string_6 = "PIDLIST4";
            }
            if (string_21.ToString().Contains("41 60"))
            {
                this.string_6 = "PIDLIST6";
            }
            if (string_21.ToString().Contains("41 80"))
            {
                this.string_6 = "PIDLIST8";
            }
            if (string_21.ToString().Contains("41 A0"))
            {
                this.string_6 = "PIDLISTA";
            }
            if (string_21.ToString().Contains("41 C0"))
            {
                this.string_6 = "PIDLISTC";
            }
            if (string_21.ToString().Contains("41 E0"))
            {
                this.string_6 = "PIDLISTE";
            }
        }
        catch
        {
        }
    }

    public void method_33(string string_21)
    {
        this.bool_5 = true;
        this.int_3++;
        if (this.int_3 == 1)
        {
            this.serialPort_0.Write("ATZ\r");
        }
        else if (this.int_3 == 2)
        {
            if (string_21.ToString().Contains("ELM327"))
            {
                this.timer_5.Enabled = false;
                this.serialPort_0.Write("ATE0\r");
            }
        }
        else if (this.int_3 == 3)
        {
            this.serialPort_0.Write("ATL0\r");
        }
        else if (this.int_3 == 4)
        {
            this.serialPort_0.Write("ATH1\r");
        }
        else if (this.int_3 == 5)
        {
            this.serialPort_0.Write("ATSP0\r");
        }
        else if (this.int_3 == 6)
        {
            this.serialPort_0.Write("ATI\r");
        }
        else if (this.int_3 == 7)
        {
            if (string_21.ToString().Contains("ELM327"))
            {
                this.method_21("Connected to " + string_21.ToString());
                this.serialPort_0.Write("AT@1\r");
            }
            else
            {
                this.method_25("No compatible ELM327 device available on " + this.cbPort.Text);
                this.method_9();
            }
        }
        else if (this.int_3 == 8)
        {
            this.method_21("Device Description: " + string_21.ToString());
            this.descPort.Text = "ECU: " + string_21.ToString();
            this.serialPort_0.Write("ATRV\r");
        }
        else if (this.int_3 == 9)
        {
            this.method_21("Vehicle Voltage: " + string_21.ToString());
            this.descRate.Text = "Voltage: " + string_21.ToString();
            this.method_19("0100");
        }
        else if (this.int_3 == 10)
        {
            if (string_21.ToString().Contains("UNABLE TO CONNECT"))
            {
                this.method_25("ECU not detected! Check OBD2 connection, or if vehicle is switched ON");
                this.method_9();
            }
            else
            {
                this.method_21("ECU Ready for OBD actions");
                this.int_2 = 1;
                this.method_18();
                this.serialPort_0.Write("ATDP\r");
            }
        }
        else if (this.int_3 == 11)
        {
            this.method_21("Communicating with ECU via " + string_21.ToString());
            this.Text = "Connected: Protocol " + smethod_0(string_21.ToString());
            this.serialPort_0.Write("0101\r");
        }
        else if (this.int_3 == 12)
        {
            string str = string_21.ToString().Replace("\r", " ").Trim();
            char[] separator = new char[] { ' ' };
            string[] strArray = str.Split(separator);
            if (strArray.Length != 8)
            {
                this.method_22("MIL Data could not be parsed");
                this.method_22("log: " + str);
            }
            else
            {
                byte num = byte.Parse(strArray[4], (NumberStyles) NumberStyles.HexNumber);
                int num2 = num & 0x7f;
                if ((num & 0x80) > 0)
                {
                    this.method_22("MIL (Check Engine Light) is ON. Number of Errors: " + num2.ToString());
                }
                else
                {
                    this.method_23("MIL (Check Engine Light) is OFF");
                }
            }
            this.bool_5 = false;
            this.method_19("0100");
        }
    }

    public void method_34()
    {
        if (this.int_5 == 0)
        {
            this.int_5 = 1;
            this.method_19("0100");
        }
        else if (this.int_37 == 0)
        {
            this.int_37 = 1;
            this.method_19("0120");
        }
        else if (this.int_69 == 0)
        {
            this.int_69 = 1;
            this.method_19("0140");
        }
        else if (this.int_101 == 0)
        {
            this.int_101 = 1;
            this.method_19("0160");
        }
        else if (this.int_133 == 0)
        {
            this.int_133 = 1;
            this.method_19("0180");
        }
        else if (this.int_165 == 0)
        {
            this.int_165 = 1;
            this.method_19("01A0");
        }
        else if (this.int_181 == 0)
        {
            this.int_181 = 1;
            this.method_19("01C0");
        }
        else if (this.int_182 == 0)
        {
            this.int_182 = 1;
            this.method_19("01E0");
        }
        if (((this.int_5 == 1) && ((this.int_37 == 1) && ((this.int_69 == 1) && ((this.int_101 == 1) && ((this.int_133 == 1) && ((this.int_165 == 1) && (this.int_181 == 1))))))) && (this.int_182 == 1))
        {
            this.bool_5 = true;
        }
    }

    public void method_35(string string_21)
    {
        string_21 = string_21.ToUpper();
        try
        {
            string text = this.string_6;
            if (text != null)
            {
                uint num = ClassDecryptString.DecryptThisString(text);
                if (num <= 2380580039U)
                {
                    if (num <= 516690212U)
                    {
                        if (num <= 401953830U)
                        {
                            if (num != 145730807U)
                            {
                                if (num != 174817312U)
                                {
                                    if (num == 401953830U)
                                    {
                                        if (text == "TA")
                                        {
                                            string[] array = Regex.Split(string_21.ToString(), "41 0E ");
                                            this.string_15 = int.Parse(array[1].Substring(0, 2), NumberStyles.HexNumber).ToString();
                                            this.string_15 = (int.Parse(this.string_15) / 2 - 64).ToString();
                                        }
                                    }
                                }
                                else if (text == "Speed")
                                {
                                    string[] array2 = Regex.Split(string_21.ToString(), "41 0D ");
                                    this.string_10 = array2[1].Substring(0, 2);
                                    this.string_10 = Convert.ToInt32(this.string_10, 16).ToString();
                                }
                            }
                            else if (text == "FSS")
                            {
                                string[] array3 = Regex.Split(string_21.ToString(), "41 03 ");
                                if (this.bool_6)
                                {
                                    this.bool_6 = false;
                                    string text2 = array3[1].Substring(0, 2);
                                    if (text2 != null)
                                    {
                                        if (!(text2 == "01"))
                                        {
                                            if (!(text2 == "02"))
                                            {
                                                if (!(text2 == "04"))
                                                {
                                                    if (!(text2 == "08"))
                                                    {
                                                        if (text2 == "16")
                                                        {
                                                            MessageBox.Show("Closed loop, using at least one oxygen sensor but there is a fault in the feedback system.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Open loop due to system failure.");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Open loop due to engine load OR fuel cut due to deceleration.");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Closed loop, using oxygen sensor feedback to determine fuel mix.");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Open loop due to insufficient engine temperature.");
                                        }
                                    }
                                }
                            }
                        }
                        else if (num != 448213361U)
                        {
                            if (num != 484709092U)
                            {
                                if (num == 516690212U)
                                {
                                    if (text == "EL")
                                    {
                                        string[] array4 = Regex.Split(string_21.ToString(), "41 04 ");
                                        this.string_16 = int.Parse(array4[1].Substring(0, 2), NumberStyles.HexNumber).ToString();
                                        this.string_16 = ((double)float.Parse(this.string_16) / 2.55).ToString("0.##");
                                    }
                                }
                            }
                            else if (text == "O2")
                            {
                                string[] array5 = Regex.Split(string_21.ToString(), "41 14 ");
                                this.string_12 = int.Parse(array5[1].Substring(0, 2), NumberStyles.HexNumber).ToString();
                                this.string_12 = ((double)float.Parse(this.string_12) / 200.0).ToString();
                            }
                        }
                        else if (text == "IAT")
                        {
                            string[] array6 = Regex.Split(string_21.ToString(), "41 0F ");
                            this.string_13 = array6[1].Substring(0, 2);
                            this.string_13 = (Convert.ToInt32(this.string_13, 16) - 40).ToString();
                        }
                    }
                    else
                    {
                        if (num <= 878530254U)
                        {
                            if (num != 609853201U)
                            {
                                if (num != 795761117U)
                                {
                                    if (num != 878530254U)
                                    {
                                        goto IL_C78;
                                    }
                                    if (!(text == "TPS"))
                                    {
                                        goto IL_C78;
                                    }
                                }
                                else if (!(text == "TPlate"))
                                {
                                    goto IL_C78;
                                }
                                string[] array7 = Regex.Split(string_21.ToString(), "41 11 ");
                                this.string_9 = array7[1].Substring(0, 2);
                                this.string_9 = (Convert.ToInt32(this.string_9, 16) * 100 / 255).ToString();
                                goto IL_C78;
                            }
                            if (!(text == "MAP"))
                            {
                                goto IL_C78;
                            }
                        }
                        else if (num <= 1364790555U)
                        {
                            if (num != 1151856721U)
                            {
                                if (num != 1364790555U)
                                {
                                    goto IL_C78;
                                }
                                if (!(text == "CEL"))
                                {
                                    goto IL_C78;
                                }
                                if (this.string_5 == "NO DATA")
                                {
                                    this.listBoxCEL.Items.Clear();
                                    this.listBoxCEL.Items.Add("No CEL Codes");
                                    goto IL_C78;
                                }
                                this.method_12(string_21.ToString());
                                goto IL_C78;
                            }
                            else if (!(text == "Map"))
                            {
                                goto IL_C78;
                            }
                        }
                        else if (num != 2027117207U)
                        {
                            if (num != 2380580039U)
                            {
                                goto IL_C78;
                            }
                            if (!(text == "OC"))
                            {
                                goto IL_C78;
                            }
                            string[] array8 = Regex.Split(string_21.ToString(), "41 1C ");
                            if (this.bool_6)
                            {
                                this.bool_6 = false;
                                MessageBox.Show("OBD Compliance: " + array8[1].Substring(0, 2));
                                goto IL_C78;
                            }
                            goto IL_C78;
                        }
                        else
                        {
                            if (text == "FT")
                            {
                                string[] array9 = Regex.Split(string_21.ToString(), "41 06 ");
                                this.string_17 = int.Parse(array9[1].Substring(0, 2), NumberStyles.HexNumber).ToString();
                                this.string_17 = ((double)int.Parse(this.string_17) / 1.28 - 100.0).ToString();
                                goto IL_C78;
                            }
                            goto IL_C78;
                        }
                        string[] array10 = Regex.Split(string_21.ToString(), "41 0B ");
                        this.string_7 = array10[1].Substring(0, 2);
                        this.string_7 = Convert.ToInt32(this.string_7, 16).ToString();
                    }
                }
                else if (num <= 3353824088U)
                {
                    if (num <= 3169270279U)
                    {
                        if (num != 2595094142U)
                        {
                            if (num != 3135715041U)
                            {
                                if (num == 3169270279U)
                                {
                                    if (text == "PIDLISTC" && string_21.ToString().Length > 7)
                                    {
                                        this.listBoxPIDs.Items.Clear();
                                        this.method_14(string_21.ToString(), 6);
                                        this.method_5();
                                    }
                                }
                            }
                            else if (text == "PIDLISTE" && string_21.ToString().Length > 7)
                            {
                                this.listBoxPIDs.Items.Clear();
                                this.method_14(string_21.ToString(), 7);
                                this.method_5();
                            }
                        }
                        else if (text == "PIDLIST" && string_21.ToString().Length > 7)
                        {
                            this.listBoxPIDs.Items.Clear();
                            this.method_14(string_21.ToString(), 0);
                            this.method_5();
                        }
                    }
                    else if (num != 3202825517U)
                    {
                        if (num != 3320268850U)
                        {
                            if (num == 3353824088U)
                            {
                                if (text == "PIDLIST6" && string_21.ToString().Length > 7)
                                {
                                    this.listBoxPIDs.Items.Clear();
                                    this.method_14(string_21.ToString(), 3);
                                    this.method_5();
                                }
                            }
                        }
                        else if (text == "PIDLIST8" && string_21.ToString().Length > 7)
                        {
                            this.listBoxPIDs.Items.Clear();
                            this.method_14(string_21.ToString(), 4);
                            this.method_5();
                        }
                    }
                    else if (text == "PIDLISTA" && string_21.ToString().Length > 7)
                    {
                        this.listBoxPIDs.Items.Clear();
                        this.method_14(string_21.ToString(), 5);
                        this.method_5();
                    }
                }
                else if (num <= 3427275971U)
                {
                    if (num != 3387379326U)
                    {
                        if (num != 3420934564U)
                        {
                            if (num == 3427275971U)
                            {
                                if (text == "CLEARDTC")
                                {
                                    this.method_23("Erase acknowledged by ECU");
                                    this.method_22("Restart vehicle to reflect changes");
                                    this.txtDTCD.Text = "Codes Cleared";
                                    this.listBoxCEL.Items.Clear();
                                }
                            }
                        }
                        else if (text == "PIDLIST2" && string_21.ToString().Length > 7)
                        {
                            this.listBoxPIDs.Items.Clear();
                            this.method_14(string_21.ToString(), 1);
                            this.method_5();
                        }
                    }
                    else if (text == "PIDLIST4" && string_21.ToString().Length > 7)
                    {
                        this.listBoxPIDs.Items.Clear();
                        this.method_14(string_21.ToString(), 2);
                        this.method_5();
                    }
                }
                else if (num <= 3829360715U)
                {
                    if (num != 3501406902U)
                    {
                        if (num == 3829360715U)
                        {
                            if (text == "ELM")
                            {
                                if (string_21.ToString().Contains("ELM327 v1.0"))
                                {
                                    this.double_0 = 1.0;
                                }
                                else if (string_21.ToString().Contains("ELM327 v1.3a"))
                                {
                                    this.double_0 = 1.3;
                                }
                                else if (string_21.ToString().Contains("ELM327 v1.4b"))
                                {
                                    this.double_0 = 1.4;
                                }
                                else if (string_21.ToString().Contains("ELM327 v1.5"))
                                {
                                    this.double_0 = 1.5;
                                }
                                else if (string_21.ToString().Contains("ELM327 v2.1"))
                                {
                                    this.double_0 = 2.1;
                                }
                                else if (string_21.ToString().Contains("ELM327 v2.2"))
                                {
                                    this.double_0 = 2.2;
                                }
                                else
                                {
                                    this.double_0 = 1.1;
                                }
                                string str = "";
                                double num2 = this.double_0;
                                if (num2 != 1.0)
                                {
                                    if (num2 != 1.1)
                                    {
                                        if (num2 != 1.3)
                                        {
                                            if (num2 != 1.4)
                                            {
                                                if (num2 != 1.5)
                                                {
                                                    if (num2 != 2.1)
                                                    {
                                                        if (num2 == 2.2)
                                                        {
                                                            str = " (Genuine  ELM 2.2 should work with 100ms refresh rate)";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        str = " (Genuine  ELM 2.1 should work with 100ms refresh rate)";
                                                    }
                                                }
                                                else
                                                {
                                                    str = " (Chinese Clone dont exceed 300ms refresh rate)";
                                                }
                                            }
                                            else
                                            {
                                                str = "b (Old ELM dont exceed 250ms refresh rate)";
                                            }
                                        }
                                        else
                                        {
                                            str = "a (Old ELM dont exceed 250ms refresh rate)";
                                        }
                                    }
                                    else
                                    {
                                        str = " (Chinese Clone dont exceed 300ms refresh rate)";
                                    }
                                }
                                else
                                {
                                    str = " (Orignal ELM dont exceed 250ms refresh rate)";
                                }
                                this.label2.Text = "ELM Adapter: " + this.double_0.ToString() + str;
                                this.label3.Text = "Features: Scan Only";
                                this.string_6 = "";
                            }
                        }
                    }
                    else if (text == "RPM")
                    {
                        string[] array11 = Regex.Split(string_21.ToString(), "41 0C ");
                        int num3 = Convert.ToInt32(array11[1].Substring(0, 2), 16) * 256 + Convert.ToInt32(array11[1].Substring(3, 2), 16);
                        this.string_8 = (num3 / 4).ToString();
                    }
                }
                else if (num != 4126829125U)
                {
                    if (num == 4247270999U)
                    {
                        if (text == "ECT")
                        {
                            string[] array12 = Regex.Split(string_21.ToString(), "41 05 ");
                            this.string_14 = array12[1].Substring(0, 2);
                            this.string_14 = (Convert.ToInt32(this.string_14, 16) - 40).ToString();
                        }
                    }
                }
                else if (text == "OSP")
                {
                    string[] array13 = Regex.Split(string_21.ToString(), "41 13 ");
                    if (this.bool_6)
                    {
                        this.bool_6 = false;
                        MessageBox.Show("Number of O2 sensors: " + array13[1].Substring(0, 2));
                    }
                }
            }
        IL_C78:;
        }
        catch
        {
        }
    }

    private string GetOBD2_Text()
    {
        string ReturnStr = "";
        string Filename = "OBD2.txt";
        /*string ZipFolder = "Others";
        string WholePath = Application.StartupPath + @"\" + ZipFolder + @"\" + Filename;
        if (!File.Exists(WholePath)) this.Class34_Zip_0.UnZipFile(Application.StartupPath, ZipFolder);
        if (File.Exists(WholePath)) ReturnStr = File.ReadAllText(WholePath);*/

        string WholePath = Application.StartupPath + @"\" + Filename;
        if (File.Exists(WholePath)) ReturnStr = File.ReadAllText(WholePath);
        return ReturnStr;
    }

    private string method_36(string string_21)
    {
        string str;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        try
        {
            string[] textArray1 = new string[] { "\r\n", "\r", "\n" };
            string[] strArray = GetOBD2_Text().Split(textArray1, (StringSplitOptions) StringSplitOptions.None);
            int index = 0;
            string[] strArray2 = strArray;
            for (int i = 0; i < strArray2.Length; i++)
            {
                string[] textArray2 = new string[] { "," };
                string[] strArray3 = strArray[index].Split(textArray2, (StringSplitOptions) StringSplitOptions.None);
                dictionary.Add(strArray3[0], strArray3[1]);
                index++;
            }
        }
        catch
        {
        }
        return (!dictionary.TryGetValue(string_21, out str) ? "Unknown Code" : str);
    }

    private void method_37()
    {
        foreach (object obj in ((IEnumerable) this.dataGridView_0.Rows))
        {
            DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
            foreach (object obj2 in dataGridViewRow.Cells)
            {
                DataGridViewCell dataGridViewCell = (DataGridViewCell)obj2;
                dataGridViewCell.Value = 0;
            }
        }
    }

    private void method_4(int int_194)
    {
        frmOBD2Scan.Class35 Class35_0 = new frmOBD2Scan.Class35();
        Class35_0.frmOBD2Scan_0 = this;
        Class35_0.int_0 = int_194;
        this.gbStatus.Invoke(new MethodInvoker(Class35_0.method_0));
    }

    private void method_40(int int_194, int int_195, double double_1)
    {
        try
        {
            if (int_195 == 0x3e7)
            {
                foreach (DataGridViewRow row in (IEnumerable) dataGridView_0.Rows)
                {
                    double_1 = double.Parse(row.Cells[int_194].Value.ToString());
                    if (double_1 < double.Parse(this.string_4[0]))
                    {
                        row.Cells[int_194].Style.BackColor = Color.AliceBlue;
                        continue;
                    }
                    if (double_1 < int.Parse(this.string_4[1]))
                    {
                        row.Cells[int_194].Style.BackColor = Color.LightBlue;
                        continue;
                    }
                    if (double_1 < int.Parse(this.string_4[2]))
                    {
                        row.Cells[int_194].Style.BackColor = Color.LightGreen;
                        continue;
                    }
                    if (double_1 < int.Parse(this.string_4[3]))
                    {
                        row.Cells[int_194].Style.BackColor = Color.LightGoldenrodYellow;
                        continue;
                    }
                    if (double_1 < int.Parse(this.string_4[4]))
                    {
                        row.Cells[int_194].Style.BackColor = Color.LightPink;
                        continue;
                    }
                    if (double_1 < int.Parse(this.string_4[5]))
                    {
                        row.Cells[int_194].Style.BackColor = Color.LightSalmon;
                    }
                }
            }
            else if (double_1 < int.Parse(this.string_4[0]))
            {
                dataGridView_0.Rows[int_195].Cells[int_194].Style.BackColor = Color.AliceBlue;
            }
            else if (double_1 < int.Parse(this.string_4[1]))
            {
                dataGridView_0.Rows[int_195].Cells[int_194].Style.BackColor = Color.LightBlue;
            }
            else if (double_1 < int.Parse(this.string_4[2]))
            {
                dataGridView_0.Rows[int_195].Cells[int_194].Style.BackColor = Color.LightGreen;
            }
            else if (double_1 < int.Parse(this.string_4[3]))
            {
                dataGridView_0.Rows[int_195].Cells[int_194].Style.BackColor = Color.LightGoldenrodYellow;
            }
            else if (double_1 < int.Parse(this.string_4[4]))
            {
                dataGridView_0.Rows[int_195].Cells[int_194].Style.BackColor = Color.LightPink;
            }
            else if (double_1 < int.Parse(this.string_4[5]))
            {
                dataGridView_0.Rows[int_195].Cells[int_194].Style.BackColor = Color.LightSalmon;
            }
        }
        catch
        {
        }
    }

    private void method_41()
    {
        while (bool_1)
        {
            try
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                if (bool_10)
                {
                    num4 = (this.comboX.Text != "MAP") ? ((this.comboX.Text != "Tplate") ? int.Parse(this.string_7) : ((int) Math.Round(double.Parse(this.string_9)))) : ((int) Math.Round((double) (double.Parse(this.string_11) * 70.0)));
                    if (this.comboY.Text == "RPM")
                    {
                        num3 = int.Parse(Math.Round((double) (Convert.ToDouble(this.string_11) * 500.0)).ToString());
                    }
                }
                else
                {
                    if (this.comboX.Text == "Map")
                    {
                        num4 = int.Parse(Math.Round((double) (Convert.ToDouble(this.string_7) * 10.0)).ToString());
                    }
                    else if (this.comboX.Text == "Tplate")
                    {
                        num4 = int.Parse(Math.Round(Convert.ToDouble(this.string_9)).ToString());
                    }
                    else
                    {
                        num4 = int.Parse(this.string_7);
                    }
                    if (this.comboY.Text == "RPM")
                    {
                        num3 = int.Parse(Math.Round(Convert.ToDouble(this.string_8)).ToString());
                    }
                }
                int num5 = 0;
                bool flag = false;
                string[] strArray = this.string_3;
                int index = 0;
                while (true)
                {
                    if (index >= strArray.Length)
                    {
                        num5 = 0;
                        bool flag2 = false;
                        string[] strArray2 = this.string_2;
                        int num10 = 0;
                        while (true)
                        {
                            if (num10 >= strArray2.Length)
                            {
                                dataGridView_0.CurrentCell = dataGridView_0.Rows[num2].Cells[num];
                                double num6 = double.Parse(dataGridView_0.Rows[num2].Cells[num].Value.ToString());
                                if (num6 == 0.0)
                                {
                                    num6 = Math.Round(this.method_42(this.comboV.Text), 2);
                                }
                                double num7 = (Math.Round(this.method_42(this.comboV.Text), 2) + num6) / 2.0;
                                dataGridView_0.Rows[num2].Cells[num].Value = Math.Round(num7, 2);
                                this.label6.Text = (num7 * 14.7).ToString();
                                this.method_40(num, num2, num7 * 14.7);
                                break;
                            }
                            string str2 = strArray2[num10];
                            if ((num4 <= int.Parse(str2)) && !flag2)
                            {
                                num = num5;
                                flag2 = true;
                            }
                            num5++;
                            num10++;
                        }
                        break;
                    }
                    string s = strArray[index];
                    if ((num3 <= int.Parse(s)) && !flag)
                    {
                        num2 = num5;
                        flag = true;
                    }
                    num5++;
                    index++;
                }
            }
            catch
            {
            }
        }
    }

    private double method_42(string string_21)
    {
        double num3;
        try
        {
            double result = 0.0;
            if (string_21 == null)
            {
                goto TR_0002;
            }
            else
            {
                if (string_21 == "Load%")
                {
                    return (double.TryParse(this.string_16, out result) ? result : 0.0);
                }
                else if (string_21 == "ECT")
                {
                    return (double.TryParse(this.string_14, out result) ? result : 0.0);
                }
                else if (string_21 == "RPM")
                {
                    return (double.TryParse(this.string_8, out result) ? result : 0.0);
                }
                else if (string_21 == "BATTERY")
                {
                    return (double.TryParse(this.string_11, out result) ? result : 0.0);
                }
                else if (string_21 == "BTDC")
                {
                    return (double.TryParse(this.string_15, out result) ? result : 0.0);
                }
                else if (string_21 == "Battery")
                {
                    return (double.TryParse(this.string_11, out result) ? result : 0.0);
                }
                else if (string_21 == "STFT")
                {
                    return (double.TryParse(this.string_17, out result) ? result : 0.0);
                }
                else if (string_21 == "TPS")
                {
                    goto TR_000C;
                }
                else if (string_21 == "Map")
                {
                    goto TR_000F;
                }
                else if (string_21 == "MAP")
                {
                    goto TR_000F;
                }
                else if (string_21 == "TPlate")
                {
                    goto TR_000C;
                }
                else if (string_21 == "Speed")
                {
                    return (double.TryParse(this.string_10, out result) ? result : 0.0);
                }
                else if (string_21 == "IAT")
                {
                    return (double.TryParse(this.string_13, out result) ? result : 0.0);
                }
                else if (string_21 == "O2")
                {
                    return (double.TryParse(this.string_12, out result) ? result : 0.0);
                }
                goto TR_0002;
            }
            goto TR_000F;
        TR_0002:
            return double.Parse("00");
        TR_000C:
            return (double.TryParse(this.string_9, out result) ? result : 0.0);
        TR_000F:
            num3 = double.TryParse(this.string_7, out result) ? result : 0.0;
        }
        catch
        {
            num3 = double.Parse("00");
        }
        return num3;
    }

    private void method_43()
    {
        if (base.InvokeRequired)
        {
            try
            {
                base.Invoke((Delegate) new MethodInvoker(this.method_52));
            }
            catch (Exception)
            {
            }
        }
        else
        {
            Application.DoEvents();
            foreach (ListViewItem item in this.listViewLive.Items)
            {
                string text = item.Text;
                if (text != null)
                {
                    uint num = ClassDecryptString.DecryptThisString(text);
                    if (num <= 0x712db33a)
                    {
                        if (num <= 0x414daa91)
                        {
                            if (num <= 0x2f6e59dd)
                            {
                                if (num == 0xe251dcc)
                                {
                                    if (text != "RPM2")
                                    {
                                        continue;
                                    }
                                    try
                                    {
                                        item.SubItems[1].Text = int_188.ToString("F0");
                                        if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                        {
                                            item.SubItems[2].Text = item.SubItems[1].Text;
                                        }
                                        if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                        {
                                            item.SubItems[2].Text = item.SubItems[1].Text;
                                        }
                                        if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                        {
                                            item.SubItems[3].Text = item.SubItems[1].Text;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    continue;
                                }
                                if (num == 0x1ab73171)
                                {
                                    if (text != "IAT")
                                    {
                                        continue;
                                    }
                                    try
                                    {
                                        item.SubItems[1].Text = float_9.ToString("F1");
                                        if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                        {
                                            item.SubItems[2].Text = item.SubItems[1].Text;
                                        }
                                        if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                        {
                                            item.SubItems[2].Text = item.SubItems[1].Text;
                                        }
                                        if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                        {
                                            item.SubItems[3].Text = item.SubItems[1].Text;
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    continue;
                                }
                                if (num != 0x2f6e59dd)
                                {
                                    continue;
                                }
                                if (text != "TPlate")
                                {
                                    continue;
                                }
                                try
                                {
                                    item.SubItems[1].Text = float_4.ToString("F2");
                                    if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                    {
                                        item.SubItems[3].Text = item.SubItems[1].Text;
                                    }
                                }
                                catch
                                {
                                }
                                continue;
                            }
                            if (num == 0x309a9e94)
                            {
                                if (text != "Ignition Timing")
                                {
                                    continue;
                                }
                                try
                                {
                                    item.SubItems[1].Text = float_7.ToString("F1");
                                    if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                    {
                                        item.SubItems[3].Text = item.SubItems[1].Text;
                                    }
                                }
                                catch
                                {
                                }
                                continue;
                            }
                            if (num == 0x398852df)
                            {
                                if (text != "Cam Angle")
                                {
                                    continue;
                                }
                                try
                                {
                                    item.SubItems[1].Text = float_14.ToString("F1");
                                    if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                    {
                                        item.SubItems[3].Text = item.SubItems[1].Text;
                                    }
                                }
                                catch
                                {
                                }
                                continue;
                            }
                            if (num != 0x414daa91)
                            {
                                continue;
                            }
                            if (text != "Wideband")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = float_2.ToString("F2");
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num <= 0x6c2dab5b)
                        {
                            if (num == 0x418b28c8)
                            {
                                if (text != "Target Cam Angle")
                                {
                                    continue;
                                }
                                try
                                {
                                    item.SubItems[1].Text = int_187.ToString("F1");
                                    if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                    {
                                        item.SubItems[3].Text = item.SubItems[1].Text;
                                    }
                                }
                                catch
                                {
                                }
                                continue;
                            }
                            if (num == 0x44a7f051)
                            {
                                if (text != "Map")
                                {
                                    continue;
                                }
                                try
                                {
                                    item.SubItems[1].Text = float_0.ToString("F1");
                                    if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                    {
                                        item.SubItems[3].Text = item.SubItems[1].Text;
                                    }
                                }
                                catch
                                {
                                }
                                continue;
                            }
                            if (num != 0x6c2dab5b)
                            {
                                continue;
                            }
                            if (text != "Knock 4")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = int_193.ToString();
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num == 0x6d4873af)
                        {
                            if (text != "Target AFR")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = float_3.ToString("F2");
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num == 0x6f2db014)
                        {
                            if (text != "Knock 1")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = int_190.ToString();
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num != 0x712db33a)
                        {
                            continue;
                        }
                        if (text != "Knock 3")
                        {
                            continue;
                        }
                        try
                        {
                            item.SubItems[1].Text = int_192.ToString();
                            if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                            {
                                item.SubItems[3].Text = item.SubItems[1].Text;
                            }
                        }
                        catch
                        {
                        }
                        continue;
                    }
                    if (num <= 0xc635623c)
                    {
                        if (num <= 0x8c46c47f)
                        {
                            if (num == 0x722db4cd)
                            {
                                if (text != "Knock 2")
                                {
                                    continue;
                                }
                                try
                                {
                                    item.SubItems[1].Text = int_191.ToString();
                                    if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                    {
                                        item.SubItems[3].Text = item.SubItems[1].Text;
                                    }
                                }
                                catch
                                {
                                }
                                continue;
                            }
                            if (num == 0x840ae12e)
                            {
                                if (text != "Battery")
                                {
                                    continue;
                                }
                                try
                                {
                                    item.SubItems[1].Text = float_1.ToString("F2");
                                    if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                    {
                                        item.SubItems[2].Text = item.SubItems[1].Text;
                                    }
                                    if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                    {
                                        item.SubItems[3].Text = item.SubItems[1].Text;
                                    }
                                }
                                catch
                                {
                                }
                                continue;
                            }
                            if (num != 0x8c46c47f)
                            {
                                continue;
                            }
                            if (text != "LTFT")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = float_12.ToString("F2");
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num == 0xa413489a)
                        {
                            if (text != "Pulsewidth")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = float_8.ToString("F2");
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num == 0xba7a3609)
                        {
                            if (text != "AFM")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = float_15.ToString("F2");
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num != 0xc635623c)
                        {
                            continue;
                        }
                        if (text != "VTS")
                        {
                            continue;
                        }
                        try
                        {
                            item.SubItems[1].Text = int_189.ToString();
                            if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                            {
                                item.SubItems[3].Text = item.SubItems[1].Text;
                            }
                        }
                        catch
                        {
                        }
                        continue;
                    }
                    if (num <= 0xd62d2ca7)
                    {
                        if (num == 0xce8f3e48)
                        {
                            if (text != "STFT")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = float_11.ToString("F2");
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num == 0xd0b33ab6)
                        {
                            if (text != "RPM")
                            {
                                continue;
                            }
                            try
                            {
                                item.SubItems[1].Text = float_5.ToString("F0");
                                if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                                {
                                    item.SubItems[2].Text = item.SubItems[1].Text;
                                }
                                if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                                {
                                    item.SubItems[3].Text = item.SubItems[1].Text;
                                }
                            }
                            catch
                            {
                            }
                            continue;
                        }
                        if (num != 0xd62d2ca7)
                        {
                            continue;
                        }
                        if (text != "VSS")
                        {
                            continue;
                        }
                        try
                        {
                            item.SubItems[1].Text = float_13.ToString("F0");
                            if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                            {
                                item.SubItems[3].Text = item.SubItems[1].Text;
                            }
                        }
                        catch
                        {
                        }
                        continue;
                    }
                    if (num == 0xe5eb0400)
                    {
                        if (text != "RPMRAW")
                        {
                            continue;
                        }
                        try
                        {
                            item.SubItems[1].Text = float_6.ToString("F0");
                            if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                            {
                                item.SubItems[3].Text = item.SubItems[1].Text;
                            }
                        }
                        catch
                        {
                        }
                        continue;
                    }
                    if (num == 0xfcb427b0)
                    {
                        if (text != "Knock Sum")
                        {
                            continue;
                        }
                        try
                        {
                            item.SubItems[1].Text = this.int_183.ToString();
                            if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                            {
                                item.SubItems[3].Text = item.SubItems[1].Text;
                            }
                        }
                        catch
                        {
                        }
                        continue;
                    }
                    if ((num == 0xfd283657) && (text == "ECT"))
                    {
                        try
                        {
                            item.SubItems[1].Text = float_10.ToString("F1");
                            if ((item.SubItems[2].Text == "000") || (item.SubItems[2].Text == ""))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) <= float.Parse(item.SubItems[2].Text))
                            {
                                item.SubItems[2].Text = item.SubItems[1].Text;
                            }
                            if (float.Parse(item.SubItems[1].Text) >= float.Parse(item.SubItems[3].Text))
                            {
                                item.SubItems[3].Text = item.SubItems[1].Text;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
    }

    private void method_44(string string_21)
    {
        try
        {
            int num = 0;
            if (string_21.Length >= 0x18)
            {
                char[] separator = new char[] { ' ' };
                byte[] buffer = string_21.Replace(",", "").Split(separator).Select<string, byte>((TestClass.Testval2 ?? (TestClass.Testval2 = new Func<string, byte>(TestClass.Testval.method_1)))).ToArray<byte>();
                num = int.Parse(buffer[5].ToString("X2") + buffer[6].ToString("X2"));
                if (num > 0xa64)
                {
                    if (num == 0xa66)
                    {
                        this.method_50(buffer);
                    }
                    else if (num == 0xa6c)
                    {
                        this.method_51(buffer);
                    }
                }
                else
                {
                    switch (num)
                    {
                        case 0xa32:
                            this.method_45(buffer);
                            break;

                        case 0xa33:
                            this.method_46(buffer);
                            break;

                        case 0xa34:
                            this.method_47(buffer);
                            break;

                        case 0xa35:
                            this.method_48(buffer);
                            break;

                        default:
                            if (num == 0xa64)
                            {
                                this.method_49(buffer);
                            }
                            break;
                    }
                }
                this.method_43();
            }
        }
        catch
        {
        }
    }

    private void method_45(byte[] byte_0)
    {
        byte[] buffer1 = new byte[] { byte_0[14], byte_0[13] };
        float_5 = ((BitConverter.ToInt16(buffer1, 0) * 4) * 0.667f) / 10f;
        byte[] buffer2 = new byte[] { byte_0[14], byte_0[13] };
        float_6 = BitConverter.ToInt16(buffer2, 0) / 10;
        this.string_8 = float_5.ToString("F0");
        float_13 = ((float) byte_0[0x19]) / 1.609f;
        float_1 = (byte_0[0x1d] * 10f) / 100f;
        this.string_11 = float_1.ToString("00.0");
        float_10 = (((byte_0[0x12] - 40f) * 9f) / 5f) + 32f;
        this.string_14 = float_10.ToString("F1");
        float_9 = (((byte_0[20] - 40f) * 9f) / 5f) + 32f;
        this.string_13 = float_9.ToString("F1");
        float_0 = (byte_0[0x16] * 100f) / 100f;
        this.string_7 = float_0.ToString("F1");
        float_7 = ((byte_0[0x1c] * 2f) - 128f) / 10f;
        byte[] buffer3 = new byte[] { byte_0[0x20], byte_0[0x1f] };
        float_8 = (BitConverter.ToInt16(buffer3, 0) * 250f) / 1000f;
        byte[] buffer4 = new byte[] { byte_0[0x2a], byte_0[0x29] };
        float_15 = BitConverter.ToInt16(buffer4, 0);
    }

    private void method_46(byte[] byte_0)
    {
        byte[] buffer1 = new byte[] { byte_0[14], byte_0[13] };
        float single1 = BitConverter.ToInt16(buffer1, 0) * 32768f;
        byte[] buffer2 = new byte[] { byte_0[0x10], byte_0[15] };
        float_2 = (((float) BitConverter.ToInt16(buffer2, 0)) / 32768f) * 14.7f;
        float_11 = (byte_0[0x11] * 1.28f) - 128f;
        float_12 = (byte_0[0x12] * 1.28f) - 128f;
        byte[] buffer3 = new byte[] { byte_0[20], byte_0[0x13] };
        float_3 = (((float) BitConverter.ToInt16(buffer3, 0)) / 32768f) * 14.7f;
    }

    private void method_47(byte[] byte_0)
    {
        byte[] buffer1 = new byte[] { byte_0[0x10], byte_0[15] };
        float single1 = ((float) BitConverter.ToInt16(buffer1, 0)) / 234f;
        byte[] buffer2 = new byte[] { byte_0[20], byte_0[0x13] };
        float_4 = ((float) BitConverter.ToInt16(buffer2, 0)) / 164f;
        this.string_9 = float_4.ToString();
        byte[] buffer3 = new byte[] { byte_0[0x16], byte_0[0x15] };
        int_188 = BitConverter.ToInt16(buffer3, 0);
        int.TryParse(new BitArray(byte_0[30])[0].ToString(), out int_189);
        float_14 = byte_0[0x1f];
        int_187 = byte_0[0x20];
    }

    private void method_48(byte[] byte_0)
    {
    }

    private void method_49(byte[] byte_0)
    {
    }

    private void method_5()
    {
        this.listBoxPIDs.Items.Clear();
        if (this.int_16 == 1)
        {
            this.listBoxPIDs.Items.Add("MAP");
        }
        if (this.int_17 == 1)
        {
            this.listBoxPIDs.Items.Add("RPM");
        }
        if (this.int_25 == 1)
        {
            this.listBoxPIDs.Items.Add("O2");
        }
        if (this.int_22 == 1)
        {
            this.listBoxPIDs.Items.Add("TPS");
        }
        if (this.int_18 == 1)
        {
            this.listBoxPIDs.Items.Add("Speed");
        }
        if (this.int_20 == 1)
        {
            this.listBoxPIDs.Items.Add("IAT");
        }
        if (this.int_10 == 1)
        {
            this.listBoxPIDs.Items.Add("ECT");
        }
        if (this.int_19 == 1)
        {
            this.listBoxPIDs.Items.Add("Timing Advance");
        }
        if (this.int_9 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine Load");
        }
        if (this.int_11 == 1)
        {
            this.listBoxPIDs.Items.Add("Short Term Fuel Trim");
        }
        this.listBoxPIDs.Items.Add("--Status--");
        if (this.int_6 == 1)
        {
            this.listBoxPIDs.Items.Add("DTC Status");
        }
        if (this.int_7 == 1)
        {
            this.listBoxPIDs.Items.Add("Freeze DTC");
        }
        if (this.int_8 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel System Status");
        }
        if (this.int_12 == 1)
        {
            this.listBoxPIDs.Items.Add("Long term fuel trim—Bank 1");
        }
        if (this.int_13 == 1)
        {
            this.listBoxPIDs.Items.Add("Short term fuel trim—Bank 2");
        }
        if (this.int_14 == 1)
        {
            this.listBoxPIDs.Items.Add("Long term fuel trim—Bank 2 ");
        }
        if (this.int_15 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel pressure");
        }
        if (this.int_21 == 1)
        {
            this.listBoxPIDs.Items.Add("Air flow rate ");
        }
        if (this.int_23 == 1)
        {
            this.listBoxPIDs.Items.Add("Commanded secondary air status ");
        }
        if (this.int_24 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensors Present");
        }
        if (this.int_26 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 2");
        }
        if (this.int_27 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 3");
        }
        if (this.int_28 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 4");
        }
        if (this.int_29 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 5");
        }
        if (this.int_30 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 6");
        }
        if (this.int_31 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 7");
        }
        if (this.int_32 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 8");
        }
        if (this.int_33 == 1)
        {
            this.listBoxPIDs.Items.Add("OBD Compliance");
        }
        if (this.int_34 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen sensors present");
        }
        if (this.int_35 == 1)
        {
            this.listBoxPIDs.Items.Add("Auxiliary input status");
        }
        if (this.int_36 == 1)
        {
            this.listBoxPIDs.Items.Add("Run time since engine start");
        }
        if (this.int_38 == 1)
        {
            this.listBoxPIDs.Items.Add("Distance traveled with malfunction indicator lamp (MIL) on");
        }
        if (this.int_39 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel Rail Pressure (relative to manifold vacuum)");
        }
        if (this.int_40 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel Rail Gauge Pressure (diesel, or gasoline direct injection) ");
        }
        if (this.int_41 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 1 AB: Fuel–Air Equivalence Ratio CD: Voltage ");
        }
        if (this.int_42 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 2 AB: Fuel–Air Equivalence Ratio CD: Voltage ");
        }
        if (this.int_43 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 3 AB: Fuel–Air Equivalence Ratio CD: Voltage");
        }
        if (this.int_44 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 4 AB: Fuel–Air Equivalence Ratio CD: Voltage ");
        }
        if (this.int_45 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 5 AB: Fuel–Air Equivalence Ratio CD: Voltage ");
        }
        if (this.int_46 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 6 AB: Fuel–Air Equivalence Ratio CD: Voltage");
        }
        if (this.int_47 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 7 AB: Fuel–Air Equivalence Ratio CD: Voltage ");
        }
        if (this.int_48 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 8 AB: Fuel–Air Equivalence Ratio CD: Voltage ");
        }
        if (this.int_49 == 1)
        {
            this.listBoxPIDs.Items.Add("Commanded EGR");
        }
        if (this.int_50 == 1)
        {
            this.listBoxPIDs.Items.Add("EGR Error ");
        }
        if (this.int_51 == 1)
        {
            this.listBoxPIDs.Items.Add("Commanded evaporative purge");
        }
        if (this.int_52 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel Tank Level Input");
        }
        if (this.int_53 == 1)
        {
            this.listBoxPIDs.Items.Add("Warm-ups since codes cleared");
        }
        if (this.int_54 == 1)
        {
            this.listBoxPIDs.Items.Add("Distance traveled since codes cleared");
        }
        if (this.int_55 == 1)
        {
            this.listBoxPIDs.Items.Add("Evap. System Vapor Pressure");
        }
        if (this.int_56 == 1)
        {
            this.listBoxPIDs.Items.Add("Absolute Barometric Pressure");
        }
        if (this.int_57 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 1 AB: Fuel–Air Equivalence Ratio CD: Current");
        }
        if (this.int_58 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 2 AB: Fuel–Air Equivalence Ratio CD: Current");
        }
        if (this.int_59 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 3 AB: Fuel–Air Equivalence Ratio CD: Current");
        }
        if (this.int_60 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 4 AB: Fuel–Air Equivalence Ratio CD: Current");
        }
        if (this.int_61 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 5 AB: Fuel–Air Equivalence Ratio CD: Current");
        }
        if (this.int_62 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 6 AB: Fuel–Air Equivalence Ratio CD: Current");
        }
        if (this.int_63 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 7 AB: Fuel–Air Equivalence Ratio CD: Current");
        }
        if (this.int_64 == 1)
        {
            this.listBoxPIDs.Items.Add("Oxygen Sensor 8 AB: Fuel–Air Equivalence Ratio CD: Current");
        }
        if (this.int_65 == 1)
        {
            this.listBoxPIDs.Items.Add("Catalyst Temperature: Bank 1, Sensor 1");
        }
        if (this.int_66 == 1)
        {
            this.listBoxPIDs.Items.Add("Catalyst Temperature: Bank 2, Sensor 1");
        }
        if (this.int_67 == 1)
        {
            this.listBoxPIDs.Items.Add("Catalyst Temperature: Bank 1, Sensor 2");
        }
        if (this.int_68 == 1)
        {
            this.listBoxPIDs.Items.Add("Catalyst Temperature: Bank 2, Sensor 2");
        }
        if (this.int_70 == 1)
        {
            this.listBoxPIDs.Items.Add("Monitor status this drive cycle");
        }
        if (this.int_71 == 1)
        {
            this.listBoxPIDs.Items.Add("Control module voltage ");
        }
        if (this.int_72 == 1)
        {
            this.listBoxPIDs.Items.Add("Absolute load value");
        }
        if (this.int_73 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel–Air commanded equivalence ratio");
        }
        if (this.int_74 == 1)
        {
            this.listBoxPIDs.Items.Add("Relative throttle position");
        }
        if (this.int_75 == 1)
        {
            this.listBoxPIDs.Items.Add("Ambient air temperature");
        }
        if (this.int_76 == 1)
        {
            this.listBoxPIDs.Items.Add("Absolute throttle position B");
        }
        if (this.int_77 == 1)
        {
            this.listBoxPIDs.Items.Add("Absolute throttle position C");
        }
        if (this.int_78 == 1)
        {
            this.listBoxPIDs.Items.Add("Accelerator pedal position D");
        }
        if (this.int_79 == 1)
        {
            this.listBoxPIDs.Items.Add("Accelerator pedal position E");
        }
        if (this.int_80 == 1)
        {
            this.listBoxPIDs.Items.Add("Accelerator pedal position F");
        }
        if (this.int_81 == 1)
        {
            this.listBoxPIDs.Items.Add("Commanded throttle actuator");
        }
        if (this.int_82 == 1)
        {
            this.listBoxPIDs.Items.Add("Time run with MIL on");
        }
        if (this.int_83 == 1)
        {
            this.listBoxPIDs.Items.Add("Time since trouble codes cleared");
        }
        if (this.int_84 == 1)
        {
            this.listBoxPIDs.Items.Add("Maximum value for Fuel–Air equivalence ratio, oxygen sensor voltage, oxygen sensor current, and intake manifold absolute pressure");
        }
        if (this.int_85 == 1)
        {
            this.listBoxPIDs.Items.Add("Maximum value for air flow rate from mass air flow sensor");
        }
        if (this.int_86 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel Type");
        }
        if (this.int_87 == 1)
        {
            this.listBoxPIDs.Items.Add("Ethanol fuel %");
        }
        if (this.int_88 == 1)
        {
            this.listBoxPIDs.Items.Add("Absolute Evap system Vapor Pressure");
        }
        if (this.int_89 == 1)
        {
            this.listBoxPIDs.Items.Add("Evap system vapor pressure");
        }
        if (this.int_90 == 1)
        {
            this.listBoxPIDs.Items.Add("Short term secondary oxygen sensor trim, A: bank 1, B: bank 3");
        }
        if (this.int_91 == 1)
        {
            this.listBoxPIDs.Items.Add("Long term secondary oxygen sensor trim, A: bank 1, B: bank 3");
        }
        if (this.int_92 == 1)
        {
            this.listBoxPIDs.Items.Add("Short term secondary oxygen sensor trim, A: bank 2, B: bank 4");
        }
        if (this.int_93 == 1)
        {
            this.listBoxPIDs.Items.Add("Long term secondary oxygen sensor trim, A: bank 2, B: bank 4");
        }
        if (this.int_94 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel rail absolute pressure");
        }
        if (this.int_95 == 1)
        {
            this.listBoxPIDs.Items.Add("Relative accelerator pedal position");
        }
        if (this.int_96 == 1)
        {
            this.listBoxPIDs.Items.Add("Hybrid battery pack remaining life");
        }
        if (this.int_97 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine oil temperature");
        }
        if (this.int_98 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel injection timing");
        }
        if (this.int_99 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine fuel rate");
        }
        if (this.int_100 == 1)
        {
            this.listBoxPIDs.Items.Add("Emission requirements to which vehicle is designed");
        }
        if (this.int_102 == 1)
        {
            this.listBoxPIDs.Items.Add("Driver's demand engine - percent torque");
        }
        if (this.int_103 == 1)
        {
            this.listBoxPIDs.Items.Add("Actual engine - percent torque");
        }
        if (this.int_104 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine reference torque");
        }
        if (this.int_105 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine percent torque data");
        }
        if (this.int_106 == 1)
        {
            this.listBoxPIDs.Items.Add("Auxiliary input / output supported");
        }
        if (this.int_107 == 1)
        {
            this.listBoxPIDs.Items.Add("Mass air flow sensor");
        }
        if (this.int_108 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine coolant temperature");
        }
        if (this.int_109 == 1)
        {
            this.listBoxPIDs.Items.Add("Intake air temperature sensor");
        }
        if (this.int_110 == 1)
        {
            this.listBoxPIDs.Items.Add("Commanded EGR and EGR Error");
        }
        if (this.int_111 == 1)
        {
            this.listBoxPIDs.Items.Add("Commanded Diesel intake air flow control and relative intake air flow position");
        }
        if (this.int_112 == 1)
        {
            this.listBoxPIDs.Items.Add("Exhaust gas recirculation temperature");
        }
        if (this.int_113 == 1)
        {
            this.listBoxPIDs.Items.Add("Commanded throttle actuator control and relative throttle position");
        }
        if (this.int_114 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel pressure control system");
        }
        if (this.int_115 == 1)
        {
            this.listBoxPIDs.Items.Add("Injection pressure control system");
        }
        if (this.int_116 == 1)
        {
            this.listBoxPIDs.Items.Add("Turbocharger compressor inlet pressure");
        }
        if (this.int_117 == 1)
        {
            this.listBoxPIDs.Items.Add("Boost pressure control");
        }
        if (this.int_118 == 1)
        {
            this.listBoxPIDs.Items.Add("Variable Geometry turbo (VGT) control");
        }
        if (this.int_119 == 1)
        {
            this.listBoxPIDs.Items.Add("Wastegate control");
        }
        if (this.int_120 == 1)
        {
            this.listBoxPIDs.Items.Add("Exhaust pressure");
        }
        if (this.int_121 == 1)
        {
            this.listBoxPIDs.Items.Add("Turbocharger RPM");
        }
        if (this.int_122 == 1)
        {
            this.listBoxPIDs.Items.Add("Turbocharger temperature");
        }
        if (this.int_123 == 1)
        {
            this.listBoxPIDs.Items.Add("Turbocharger temperature");
        }
        if (this.int_124 == 1)
        {
            this.listBoxPIDs.Items.Add("Charge air cooler temperature (CACT)");
        }
        if (this.int_125 == 1)
        {
            this.listBoxPIDs.Items.Add("Exhaust Gas temperature (EGT) Bank 1");
        }
        if (this.int_126 == 1)
        {
            this.listBoxPIDs.Items.Add("Exhaust Gas temperature (EGT) Bank 2");
        }
        if (this.int_127 == 1)
        {
            this.listBoxPIDs.Items.Add("Diesel particulate filter (DPF)");
        }
        if (this.int_128 == 1)
        {
            this.listBoxPIDs.Items.Add("Diesel particulate filter (DPF)");
        }
        if (this.int_129 == 1)
        {
            this.listBoxPIDs.Items.Add("Diesel Particulate filter (DPF) temperature");
        }
        if (this.int_130 == 1)
        {
            this.listBoxPIDs.Items.Add("NOx NTE (Not-To-Exceed) control area status");
        }
        if (this.int_131 == 1)
        {
            this.listBoxPIDs.Items.Add("PM NTE (Not-To-Exceed) control area status");
        }
        if (this.int_132 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine run time");
        }
        if (this.int_134 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine run time for Auxiliary Emissions Control Device(AECD)");
        }
        if (this.int_135 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine run time for Auxiliary Emissions Control Device(AECD)");
        }
        if (this.int_136 == 1)
        {
            this.listBoxPIDs.Items.Add("NOx sensor");
        }
        if (this.int_137 == 1)
        {
            this.listBoxPIDs.Items.Add("Manifold surface temperature");
        }
        if (this.int_138 == 1)
        {
            this.listBoxPIDs.Items.Add("NOx reagent system");
        }
        if (this.int_139 == 1)
        {
            this.listBoxPIDs.Items.Add("Particulate matter (PM) sensor");
        }
        if (this.int_140 == 1)
        {
            this.listBoxPIDs.Items.Add("Intake manifold absolute pressure");
        }
        if (this.int_141 == 1)
        {
            this.listBoxPIDs.Items.Add("SCR Induce System");
        }
        if (this.int_142 == 1)
        {
            this.listBoxPIDs.Items.Add("Run Time for AECD #11-#15");
        }
        if (this.int_143 == 1)
        {
            this.listBoxPIDs.Items.Add("Run Time for AECD #16-#20");
        }
        if (this.int_144 == 1)
        {
            this.listBoxPIDs.Items.Add("Diesel Aftertreatment");
        }
        if (this.int_145 == 1)
        {
            this.listBoxPIDs.Items.Add("O2 Sensor (Wide Range)");
        }
        if (this.int_146 == 1)
        {
            this.listBoxPIDs.Items.Add("Throttle Position G");
        }
        if (this.int_147 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine Friction - Percent Torque");
        }
        if (this.int_148 == 1)
        {
            this.listBoxPIDs.Items.Add("PM Sensor Bank 1 & 2");
        }
        if (this.int_149 == 1)
        {
            this.listBoxPIDs.Items.Add("WWH-OBD Vehicle OBD System Information");
        }
        if (this.int_150 == 1)
        {
            this.listBoxPIDs.Items.Add("WWH-OBD Vehicle OBD System Information");
        }
        if (this.int_151 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel System Control");
        }
        if (this.int_152 == 1)
        {
            this.listBoxPIDs.Items.Add("WWH-OBD Vehicle OBD Counters support");
        }
        if (this.int_153 == 1)
        {
            this.listBoxPIDs.Items.Add("NOx Warning And Inducement System");
        }
        if (this.int_154 == 1)
        {
            this.listBoxPIDs.Items.Add("PID95");
        }
        if (this.int_155 == 1)
        {
            this.listBoxPIDs.Items.Add("PID96");
        }
        if (this.int_156 == 1)
        {
            this.listBoxPIDs.Items.Add("PID97");
        }
        if (this.int_157 == 1)
        {
            this.listBoxPIDs.Items.Add("Exhaust Gas Temperature Sensor");
        }
        if (this.int_158 == 1)
        {
            this.listBoxPIDs.Items.Add("Exhaust Gas Temperature Sensor");
        }
        if (this.int_159 == 1)
        {
            this.listBoxPIDs.Items.Add("Hybrid/EV Vehicle System Data, Battery, Voltage");
        }
        if (this.int_160 == 1)
        {
            this.listBoxPIDs.Items.Add("Diesel Exhaust Fluid Sensor Data");
        }
        if (this.int_161 == 1)
        {
            this.listBoxPIDs.Items.Add("O2 Sensor Data");
        }
        if (this.int_162 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine Fuel Rate");
        }
        if (this.int_163 == 1)
        {
            this.listBoxPIDs.Items.Add("Engine Exhaust Flow Rate");
        }
        if (this.int_164 == 1)
        {
            this.listBoxPIDs.Items.Add("Fuel System Percentage Use");
        }
        if (this.int_166 == 1)
        {
            this.listBoxPIDs.Items.Add("NOx Sensor Corrected Data");
        }
        if (this.int_167 == 1)
        {
            this.listBoxPIDs.Items.Add("Cylinder Fuel Rate");
        }
        if (this.int_168 == 1)
        {
            this.listBoxPIDs.Items.Add("Evap System Vapor Pressure");
        }
        if (this.int_169 == 1)
        {
            this.listBoxPIDs.Items.Add("Transmission Actual Gear");
        }
        if (this.int_170 == 1)
        {
            this.listBoxPIDs.Items.Add("Diesel Exhaust Fluid Dosing");
        }
        if (this.int_171 == 1)
        {
            this.listBoxPIDs.Items.Add("Odometer");
        }
    }

    private void method_50(byte[] byte_0)
    {
    }

    private void method_51(byte[] byte_0)
    {
        this.string_12 = float_2.ToString("F1");
        byte[] buffer1 = new byte[] { byte_0[0x17], byte_0[0x16] };
        int_190 = BitConverter.ToInt16(buffer1, 0);
        byte[] buffer2 = new byte[] { byte_0[0x19], byte_0[0x18] };
        int_191 = BitConverter.ToInt16(buffer2, 0);
        byte[] buffer3 = new byte[] { byte_0[0x1a], byte_0[0x19] };
        int_192 = BitConverter.ToInt16(buffer3, 0);
        byte[] buffer4 = new byte[] { byte_0[0x1c], byte_0[0x1b] };
        int_193 = BitConverter.ToInt16(buffer4, 0);
        this.int_183 = ((int_190 + int_191) + int_192) + int_193;
        this.string_18 = this.int_183.ToString();
        byte[] buffer5 = new byte[] { byte_0[0x2d], byte_0[0x2c] };
        int num1 = BitConverter.ToInt16(buffer5, 0) * 10;
    }

    [CompilerGenerated]
    private void method_52()
    {
        this.method_43();
    }

    private void method_6(object sender, EventArgs e)
    {
        this.list_0.Clear();
        int num = 0;
        foreach (object obj in this.listViewLive.Items)
        {
            ListViewItem listViewItem = (ListViewItem)obj;
            if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem).Contains(this.listViewLive.Items[num].SubItems[1].Text))
            {
                return;
            }
            num++;
        }
        if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "MAP")
        {
            string[] items = new string[] { "MAP", "000", "000", "000" };
            this.listViewLive.Items.Add("0B").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "RPM")
        {
            string[] items = new string[] { "RPM", "000", "000", "000" };
            this.listViewLive.Items.Add("0C").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "TPS")
        {
            string[] items = new string[] { "TPS", "000", "000", "000" };
            this.listViewLive.Items.Add("11").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Speed")
        {
            string[] items = new string[] { "Speed", "000", "000", "000" };
            this.listViewLive.Items.Add("0D").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "O2")
        {
            string[] items = new string[] { "O2", "000", "000", "000" };
            this.listViewLive.Items.Add("14").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "IAT")
        {
            string[] items = new string[] { "IAT", "000", "000", "000" };
            this.listViewLive.Items.Add("0F").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "ECT")
        {
            string[] items = new string[] { "ECT", "000", "000", "000" };
            this.listViewLive.Items.Add("05").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Short Term Fuel Trim")
        {
            string[] items = new string[] { "STFT", "000", "000", "000" };
            this.listViewLive.Items.Add("06").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Timing Advance")
        {
            string[] items = new string[] { "BTDC", "000", "000", "000" };
            this.listViewLive.Items.Add("0E").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Engine Load")
        {
            string[] items = new string[] { "Load%", "000", "000", "000" };
            this.listViewLive.Items.Add("04").SubItems.AddRange(items);
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Fuel System Status")
        {
            this.bool_6 = true;
            this.method_19("0103");
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "Oxygen Sensors Present")
        {
            this.bool_6 = true;
            this.method_19("0113");
        }
        else if (this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) == "OBD Compliance")
        {
            this.bool_6 = true;
            this.method_19("011C");
        }
        else
        {
            MessageBox.Show(this.listBoxPIDs.GetItemText(this.listBoxPIDs.SelectedItem) + " Doesnt Support logging at the moment");
        }
    }

    private void method_7(object sender, EventArgs e)
    {
        this.list_0.Clear();
        try
        {
            this.listViewLive.SelectedItems[0].Remove();
        }
        catch
        {
        }
    }

    private void method_9()
    {
        if (!this.bool_8)
        {
            this.serialPort_0.Close();
            this.stringBuilder_0.Clear();
            this.bool_4 = false;
            this.method_21("Connection closed automatically.");
            this.int_2 = 0;
            this.method_18();
            this.method_10();
        }
    }

    public static string smethod_0(string string_21)
    {
        StringBuilder builder = new StringBuilder();
        foreach (char ch in string_21)
        {
            if ((((ch >= '0') && (ch <= '9')) || (((ch >= 'A') && (ch <= 'Z')) || (((ch >= 'a') && (ch <= 'z')) || (ch == '.')))) || (ch == '_'))
            {
                builder.Append(ch);
            }
        }
        return builder.ToString();
    }

    public static byte[] smethod_1(string string_21)
    {
        Class36 class2 = new Class36 {
            string_0 = string_21
        };
        return Enumerable.Range(0, class2.string_0.Length).Where<int>((TestClass.Testval1 ?? (TestClass.Testval1 = new Func<int, bool>(TestClass.Testval.method_0)))).Select<int, byte>(new Func<int, byte>(class2.method_0)).ToArray<byte>();
    }

    public static string smethod_2(byte[] byte_0)
    {
        StringBuilder builder = new StringBuilder(byte_0.Length * 2);
        foreach (byte num2 in byte_0)
        {
            builder.AppendFormat("{0:x2} ", num2);
        }
        return builder.ToString();
    }

    private void StartTable_Click(object sender, EventArgs e)
    {
        if (this.bool_2)
        {
            this.ClearTable.Enabled = false;
            this.StopTable.Enabled = false;
            this.comboX.Enabled = false;
            this.comboY.Enabled = false;
            this.comboV.Enabled = false;
            dataGridView_0.Enabled = true;
            this.StartTable.Text = "Load Template";
            this.bool_2 = false;
            dataGridView_0.DataSource = null;
            dataGridView_0.Rows.Clear();
            dataGridView_0.Refresh();
        }
        else
        {
            OpenFileDialog dialog1 = new OpenFileDialog();
            dialog1.Filter = "Scan Template File|*.STEMPLATE";
            dialog1.Title = "Load table template";
            OpenFileDialog dialog = dialog1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.comboV.SelectedIndex = 0;
                this.comboX.SelectedIndex = 0;
                this.comboY.SelectedIndex = 0;
                DataTable table = new DataTable();
                string[] textArray1 = new string[] { "\r\n", "\r", "\n" };
                string[] strArray = File.ReadAllText(dialog.FileName).Split(textArray1, (StringSplitOptions) StringSplitOptions.None);
                char[] separator = new char[] { '|' };
                this.string_2 = strArray[0].Split(separator);
                char[] chArray2 = new char[] { '|' };
                this.string_3 = strArray[1].Split(chArray2);
                char[] chArray3 = new char[] { '|' };
                this.string_4 = strArray[2].Split(chArray3);
                int index = 0;
                string[] strArray2 = this.string_2;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    table.Columns.Add(new DataColumn(this.string_2[index], typeof(string)));
                    index++;
                }
                index = 0;
                string[] strArray3 = this.string_3;
                for (int j = 0; j < strArray3.Length; j++)
                {
                    object[] values = new object[] { "0" };
                    table.Rows.Add(values);
                    index++;
                }
                dataGridView_0.DataSource = table;
                dataGridView_0.RowHeadersWidth = 90;
                index = 0;
                string[] strArray4 = this.string_3;
                for (int k = 0; k < strArray4.Length; k++)
                {
                    dataGridView_0.Rows[index].HeaderCell.Value = this.string_3[index];
                    index++;
                }
                foreach (DataGridViewColumn column in dataGridView_0.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.Width = 0x23;
                }
                this.ClearTable.Enabled = true;
                this.StopTable.Enabled = true;
                this.comboX.Enabled = true;
                this.comboY.Enabled = true;
                this.comboV.Enabled = true;
                dataGridView_0.Enabled = true;
                this.method_37();
                foreach (DataGridViewColumn column2 in dataGridView_0.Columns)
                {
                    column2.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridView_0.TopLeftHeaderCell.Value = "RPM/MAP";
                index = 0;
                string[] strArray5 = this.string_2;
                for (int m = 0; m < strArray5.Length; m++)
                {
                    this.method_40(index, 0x3e7, 0.0);
                    index++;
                }
                this.StartTable.Text = "Save and Close";
                this.bool_2 = true;
            }
        }
    }

    private void StopTable_Click(object sender, EventArgs e)
    {
        if (bool_1)
        {
            this.timer_1.Enabled = false;
            this.StartTable.Enabled = true;
            this.StopTable.Text = "Start Trace";
            bool_1 = false;
        }
        else
        {
            this.StartTable.Enabled = false;
            this.StopTable.Text = "Stop Trace";
            bool_1 = true;
            this.thread_0 = new Thread(new ThreadStart(this.method_41));
            this.thread_0.Start();
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
        try
        {
            this.livegraph1.method_1(Convert.ToInt32(this.method_42(this.Graph1.Text)));
        }
        catch
        {
        }
        try
        {
            this.livegraph2.method_1(Convert.ToInt32(this.method_42(this.Graph2.Text)));
        }
        catch
        {
        }
        try
        {
            this.livegraph3.method_1(Convert.ToInt32(this.method_42(this.Graph3.Text)));
        }
        catch
        {
        }
        try
        {
            this.livegraph4.method_1(Convert.ToInt32(this.method_42(this.Graph4.Text)));
        }
        catch
        {
        }
        switch (frmOBD2Scan.int_186)
        {
            case 1:
                try
                {
                    frmOBD2Scan.int_185 = Convert.ToInt32(this.method_42(this.Graph1.Text));
                    return;
                }
                catch
                {
                    return;
                }
                break;
            case 2:
                break;
            case 3:
                goto IL_110;
            case 4:
                goto IL_131;
            default:
                return;
        }
        try
        {
            frmOBD2Scan.int_185 = Convert.ToInt32(this.method_42(this.Graph2.Text));
            return;
        }
        catch
        {
            return;
        }
    IL_110:
        try
        {
            frmOBD2Scan.int_185 = Convert.ToInt32(this.method_42(this.Graph3.Text));
            return;
        }
        catch
        {
            return;
        }
    IL_131:
        try
        {
            frmOBD2Scan.int_185 = Convert.ToInt32(this.method_42(this.Graph4.Text));
        }
        catch
        {
        }
    }

    private void timer_2_Tick(object sender, EventArgs e)
    {
        if (!this.bool_8)
        {
            if (this.serialPort_0 == null)
            {
                this.method_10();
            }
            else if (!this.serialPort_0.IsOpen)
            {
                this.method_10();
            }
            else
            {
                this.timer_2.Enabled = false;
                if (this.thread_0 == null)
                {
                    this.thread_0 = new Thread(new ThreadStart(this.method_30));
                    this.thread_0.Start();
                }
            }
        }
        else if (bool_10)
        {
            this.label2.Text = "J2534 Adapter: OpenPort 2.0";
            this.label3.Text = "Features: Extended CANBUS";
            if (!this.bool_9)
            {
                ColumnHeader column = this.listViewLive.Columns[0];
                this.listViewLive.Columns.Remove(column);
                this.method_31();
                this.method_2();
                this.bool_9 = true;
            }
            this.listBoxPIDs.Enabled = false;
            bool_11 = true;
            this.timer_6.Enabled = true;
            if (this.thread_0 == null)
            {
                this.thread_0 = new Thread(new ThreadStart(this.method_29));
                this.thread_0.Start();
            }
            this.timer_2.Enabled = false;
        }
        else
        {
            if (!bool_11)
            {
                this.label2.Text = "J2534 Adapter: OpenPort 2.0";
                this.label3.Text = "Features: ALL SUPPORTED";
                this.method_10();
                this.method_19("0100");
            }
            try
            {
                GetMessageResults messages = this.channel_0.GetMessages(2, 5);
                if (messages.Result.IsOK())
                {
                    foreach (SAE.J2534.Message message in messages.Messages)
                    {
                        string str = smethod_2(message.Data);
                        if (str.Contains("41 00"))
                        {
                            this.bool_5 = false;
                            bool_11 = true;
                            this.timer_2.Interval = 50;
                        }
                        if (!this.bool_5)
                        {
                            this.method_34();
                        }
                        else
                        {
                            this.timer_2.Enabled = false;
                            if (this.thread_0 == null)
                            {
                                this.thread_0 = new Thread(new ThreadStart(this.method_29));
                                this.thread_0.Start();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }

    private void timer_3_Tick(object sender, EventArgs e)
    {
        List<string> list = new List<string>(SerialPort.GetPortNames());
        list.Sort();
        bool flag = false;
        if (list.Count != this.cbPort.Items.Count)
        {
            flag = true;
        }
        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != this.cbPort.Items[i].ToString())
                {
                    flag = true;
                }
            }
        }
        if (flag)
        {
            this.cbPort.Items.Clear();
            this.cbPort.Items.AddRange(list.ToArray());
            this.cbPort.SelectedIndex = this.cbPort.Items.Count - 1;
        }
    }

    private void timer_4_Tick(object sender, EventArgs e)
    {
        if (this.int_184 > (this.listViewLive.Items.Count - 1))
        {
            this.bool_7 = !this.bool_7;
            this.int_184 = 0;
        }
        string text = this.listViewLive.Items[this.int_184].SubItems[0].Text;
        if (this.bool_7)
        {
            this.method_19("01" + text);
            this.method_3();
        }
        else if ((!this.bool_7 && ((text != "05") && (text != "0A"))) && (text != "0F"))
        {
            this.method_19("01" + text);
            this.method_3();
        }
        this.int_184++;
    }

    private void timer_6_Tick(object sender, EventArgs e)
    {
        try
        {
            this.method_4(this.int_0);
            this.int_0 = 0;
        }
        catch
        {
            this.timer_6.Enabled = false;
        }
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        this.groupBox5.Text = "Refresh Rate: " + this.trackBar1.Value.ToString();
        frmOBD2Scan.int_1 = this.trackBar1.Value;
        this.timer_4.Interval = frmOBD2Scan.int_1;
    }

    [Serializable, CompilerGenerated]
    private sealed class TestClass //<>c
    {
        public static readonly frmOBD2Scan.TestClass Testval = new frmOBD2Scan.TestClass(); //<>9
        public static Func<int, bool> Testval1;       //<>9__413_0
        public static Func<string, byte> Testval2;    //<>9__452_0

        internal bool method_0(int int_0) => 
            ((int_0 % 2) == 0);

        internal byte method_1(string string_0) => 
            Convert.ToByte(string_0, 0x10);
    }

    [CompilerGenerated]
    private sealed class Class35
    {
        public frmOBD2Scan frmOBD2Scan_0;
        public int int_0;

        internal void method_0()
        {
            this.frmOBD2Scan_0.gbStatus.Text = "Status: FPS " + this.int_0.ToString();
        }
    }

    [CompilerGenerated]
    private sealed class Class36
    {
        public string string_0;

        internal byte method_0(int int_0) => 
            Convert.ToByte(this.string_0.Substring(int_0, 2), 0x10);
    }

    private void gbConnection_Enter(object sender, EventArgs e)
    {

    }
}

