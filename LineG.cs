using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class LineG : Form
{
    private IContainer icontainer_0;
    private PerfChart perfChart1;
    private Label sensorname;
    private Timer timer_0;

    public LineG()
    {
        this.InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.icontainer_0 = new Container();
        GClass4 class2 = new GClass4();
        GClass4 class3 = new GClass4();
        GClass4 class4 = new GClass4();
        GClass4 class5 = new GClass4();
        this.sensorname = new Label();
        this.timer_0 = new Timer(this.icontainer_0);
        this.perfChart1 = new PerfChart();
        base.SuspendLayout();
        this.sensorname.AutoSize = true;
        this.sensorname.BackColor = Color.Green;
        this.sensorname.Font = new Font("Microsoft Sans Serif", 16.875f, FontStyle.Bold);
        this.sensorname.ForeColor = Color.White;
        this.sensorname.Location = new Point(0x1a, 0x187);
        this.sensorname.Name = "sensorname";
        this.sensorname.Size = new Size(0x143, 0x34);
        this.sensorname.TabIndex = 1;
        this.sensorname.Text = "Sensor Name:";
        this.timer_0.Interval = 50;
        this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        this.perfChart1.Border3DStyle_0 = Border3DStyle.Flat;
        this.perfChart1.Font = new Font("Segoe UI", 72f, FontStyle.Regular, GraphicsUnit.Point, 0);
        this.perfChart1.Location = new Point(0x10, 0x11);
        this.perfChart1.Margin = new Padding(7, 8, 7, 8);
        this.perfChart1.Name = "perfChart1";
        this.perfChart1.GClass3_0.Boolean_3 = true;
        class2.Color_0 = Color.Black;
        class2.DashStyle_0 = DashStyle.Solid;
        class2.Single_0 = 1f;
        this.perfChart1.GClass3_0.GClass4_2 = class2;
        this.perfChart1.GClass3_0.Color_1 = Color.Green;
        this.perfChart1.GClass3_0.Color_0 = Color.YellowGreen;
        class3.Color_0 = Color.White;
        class3.DashStyle_0 = DashStyle.Solid;
        class3.Single_0 = 15f;
        this.perfChart1.GClass3_0.GClass4_3 = class3;
        class4.Color_0 = Color.Black;
        class4.DashStyle_0 = DashStyle.Solid;
        class4.Single_0 = 1f;
        this.perfChart1.GClass3_0.GClass4_1 = class4;
        this.perfChart1.GClass3_0.Boolean_2 = false;
        this.perfChart1.GClass3_0.Boolean_1 = true;
        this.perfChart1.GClass3_0.Boolean_0 = true;
        class5.Color_0 = Color.Black;
        class5.DashStyle_0 = DashStyle.Solid;
        class5.Single_0 = 1f;
        this.perfChart1.GClass3_0.GClass4_0 = class5;
        this.perfChart1.GEnum0_0 = GEnum0.Relative;
        this.perfChart1.Size = new Size(0x218, 0x16e);
        this.perfChart1.TabIndex = 0;
        this.perfChart1.Int32_0 = 100;
        this.perfChart1.GEnum1_0 = GEnum1.Disabled;
        this.perfChart1.Click += new EventHandler(this.perfChart1_Click);
        this.perfChart1.DoubleClick += new EventHandler(this.perfChart1_DoubleClick);
        this.perfChart1.KeyDown += new KeyEventHandler(this.perfChart1_KeyDown);
        base.AutoScaleDimensions = new SizeF(12f, 25f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.ClientSize = new Size(800, 450);
        base.Controls.Add(this.sensorname);
        base.Controls.Add(this.perfChart1);
        base.FormBorderStyle = FormBorderStyle.None;
        base.MaximizeBox = false;
        base.MinimizeBox = false;
        base.Name = "LineG";
        this.Text = "Form1";
        base.Load += new EventHandler(this.LineG_Load);
        base.ResumeLayout(false);
        base.PerformLayout();
    }

    private void LineG_Load(object sender, EventArgs e)
    {
        base.FormBorderStyle = FormBorderStyle.None;
        base.WindowState = FormWindowState.Maximized;
        this.perfChart1.Top = 0;
        this.perfChart1.Left = 0;
        this.sensorname.Left = 10;
        this.sensorname.Top = base.Height - 50;
        this.perfChart1.Size = new Size(base.Width, base.Height);
        this.sensorname.Text = "Sensor: " + frmOBD2Scan.string_20;
        this.timer_0.Enabled = true;
        this.perfChart1.GClass3_0.Color_1 = frmOBD2Scan.color_0;
        this.perfChart1.GClass3_0.Color_0 = frmOBD2Scan.color_0;
        this.perfChart1.GClass3_0.GClass4_3.Color_0 = frmOBD2Scan.color_2;
    }

    private void perfChart1_Click(object sender, EventArgs e)
    {
        if (this.timer_0.Enabled)
        {
            this.timer_0.Enabled = false;
        }
        else
        {
            this.timer_0.Enabled = true;
        }
    }

    private void perfChart1_DoubleClick(object sender, EventArgs e)
    {
        this.timer_0.Enabled = false;
        frmOBD2Scan.int_186 = 0;
        base.Close();
    }

    private void perfChart1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            e.SuppressKeyPress = true;
            this.timer_0.Enabled = false;
            frmOBD2Scan.int_186 = 0;
            base.Close();
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
        this.perfChart1.method_1((decimal) frmOBD2Scan.int_185);
    }
}

