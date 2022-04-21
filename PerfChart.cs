using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class PerfChart : UserControl
{
    private const int int_0 = 0x200;
    private const int int_1 = 8;
    private int int_2;
    private int int_3 = 4;
    private decimal decimal_0;
    private decimal decimal_1;
    private int int_4;
    private decimal decimal_2;
    private Border3DStyle border3DStyle_0 = Border3DStyle.Flat;
    private GEnum0 genum0_0;
    private GEnum1 genum1_0;
    private List<decimal> list_0 = new List<decimal>(0x200);
    private Queue<decimal> queue_0 = new Queue<decimal>();
    private GClass3 gclass3_0;
    private IContainer icontainer_0;
    private Timer timer_0;

    public PerfChart()
    {
        this.InitializeComponent();
        this.gclass3_0 = new GClass3();
        base.SetStyle(ControlStyles.UserPaint, true);
        base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        base.SetStyle(ControlStyles.ResizeRedraw, true);
        this.Font = SystemInformation.MenuFont;
    }

    private void InitializeComponent()
    {
        this.icontainer_0 = new Container();
        this.timer_0 = new Timer(this.icontainer_0);
        base.SuspendLayout();
        this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
        base.AutoScaleDimensions = new SizeF(6f, 13f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.Name = "PerfChart";
        base.Size = new Size(0xeb, 0x57);
        base.ResumeLayout(false);
    }

    public void method_0()
    {
        this.list_0.Clear();
        base.Invalidate();
    }

    public void method_1(decimal decimal_3)
    {
        if ((this.genum0_0 == GEnum0.Absolute) && (decimal_3 > 100M))
        {
            throw new Exception($"Values greater then 100 not allowed in ScaleMode: Absolute ({decimal_3})");
        }
        GEnum1 enum2 = this.genum1_0;
        if (enum2 == GEnum1.Disabled)
        {
            this.method_3(decimal_3);
            base.Invalidate();
        }
        else
        {
            if ((enum2 - 1) > GEnum1.SynchronizedAverage)
            {
                throw new Exception($"Unsupported TimerMode: {this.genum1_0}");
            }
            this.method_2(decimal_3);
        }
    }

    private void method_10(Graphics graphics_0)
    {
        Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
        using (Brush brush = new LinearGradientBrush(rect, this.gclass3_0.Color_0, this.gclass3_0.Color_1, LinearGradientMode.Vertical))
        {
            graphics_0.FillRectangle(brush, rect);
        }
        if (this.gclass3_0.Boolean_0)
        {
            for (int i = base.Width - this.int_4; i >= 0; i -= 8)
            {
                graphics_0.DrawLine(this.gclass3_0.GClass4_0.Pen_0, i, 0, i, base.Height);
            }
        }
        if (this.gclass3_0.Boolean_1)
        {
            for (int i = 0; i < base.Height; i += 8)
            {
                graphics_0.DrawLine(this.gclass3_0.GClass4_1.Pen_0, 0, i, base.Width, i);
            }
        }
    }

    private void method_11(object sender, EventArgs e)
    {
        base.Invalidate();
    }

    private void method_2(decimal decimal_3)
    {
        this.queue_0.Enqueue(decimal_3);
    }

    private void method_3(decimal decimal_3)
    {
        this.list_0.Insert(0, Math.Max(decimal_3, 0M));
        if (this.list_0.Count > 0x200)
        {
            this.list_0.RemoveAt(0x200);
        }
        this.int_4 += this.int_3;
        if (this.int_4 > 8)
        {
            this.int_4 = this.int_4 % 8;
        }
    }

    private void method_4()
    {
        if (this.queue_0.Count <= 0)
        {
            this.method_3(0M);
        }
        else if (this.genum1_0 == GEnum1.Simple)
        {
            while (this.queue_0.Count > 0)
            {
                this.method_3(this.queue_0.Dequeue());
            }
        }
        else if ((this.genum1_0 == GEnum1.SynchronizedAverage) || (this.genum1_0 == GEnum1.SynchronizedSum))
        {
            decimal num = 0M;
            int count = this.queue_0.Count;
            while (true)
            {
                if (this.queue_0.Count <= 0)
                {
                    if (this.genum1_0 == GEnum1.SynchronizedAverage)
                    {
                        num = (decimal) (num / count);
                    }
                    if (num > 88M)
                    {
                        num = (decimal) (num - 10M);
                    }
                    if (num < 10M)
                    {
                        num = (decimal) (num + 10M);
                    }
                    this.method_3(num);
                    break;
                }
                num = (decimal) (num + this.queue_0.Dequeue());
            }
        }
        base.Invalidate();
    }

    private int method_5(decimal decimal_3)
    {
        decimal num = 0M;
        if (this.genum0_0 == GEnum0.Absolute)
        {
            num = (decimal) ((decimal_3 * base.Height) / 100M);
        }
        else if (this.genum0_0 == GEnum0.Relative)
        {
            num = (this.decimal_0 > 0M) ? ((decimal) ((decimal_3 * base.Height) / this.decimal_0)) : 0M;
        }
        return Convert.ToInt32(Math.Round((decimal) ((base.Height - num) + 6M)));
    }

    private decimal method_6()
    {
        decimal num = 0M;
        for (int i = 0; i < this.int_2; i++)
        {
            if (this.list_0[i] > num)
            {
                num = this.list_0[i];
            }
        }
        return num;
    }

    private decimal method_7()
    {
        try
        {
            return this.list_0[0];
        }
        catch
        {
        }
        try
        {
            return this.list_0[1];
        }
        catch
        {
            return 0M;
        }
    }

    private void method_8(Graphics graphics_0)
    {
        this.int_2 = Math.Min(base.Width / this.int_3, this.list_0.Count);
        if (this.genum0_0 == GEnum0.Relative)
        {
            this.decimal_0 = this.method_6();
        }
        this.decimal_1 = this.method_7();
        Point point = new Point(base.Width + this.int_3, base.Height);
        Point point2 = new Point();
        if ((this.int_2 > 0) && this.gclass3_0.Boolean_2)
        {
            this.decimal_2 = 0M;
            this.method_9(graphics_0);
        }
        for (int i = 0; i < this.int_2; i++)
        {
            point2.X = point.X - this.int_3;
            point2.Y = this.method_5(this.list_0[i]);
            graphics_0.DrawLine(this.gclass3_0.GClass4_3.Pen_0, point, point2);
            point = point2;
        }
        if (this.genum0_0 == GEnum0.Relative)
        {
            SolidBrush brush = new SolidBrush(this.gclass3_0.GClass4_3.Color_0);
            string[] textArray1 = new string[] { "Max: ", this.decimal_0.ToString(), Environment.NewLine, "Current: ", this.decimal_1.ToString() };
            graphics_0.DrawString(string.Concat(textArray1), this.Font, brush, (float) 4f, (float) 2f);
        }
        ControlPaint.DrawBorder3D(graphics_0, 0, 0, base.Width, base.Height, this.border3DStyle_0);
    }

    private void method_9(Graphics graphics_0)
    {
        for (int i = 0; i < this.int_2; i++)
        {
            this.decimal_2 = (decimal) (this.decimal_2 + this.list_0[i]);
        }
        this.decimal_2 = (decimal) (this.decimal_2 / this.int_2);
        int num = this.method_5(this.decimal_2);
        graphics_0.DrawLine(this.gclass3_0.GClass4_2.Pen_0, 0, num, base.Width, num);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.icontainer_0 != null))
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    protected virtual void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (this.gclass3_0.Boolean_3)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }
        this.method_10(e.Graphics);
        this.method_8(e.Graphics);
    }

    protected virtual void OnResize(EventArgs e)
    {
        base.OnResize(e);
        base.Invalidate();
    }

    private void timer_0_Tick(object sender, EventArgs e)
    {
        if (!base.DesignMode)
        {
            this.method_4();
        }
    }

    [Description("Appearance and Style"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
    public GClass3 GClass3_0
    {
        get
        {
            return this.gclass3_0;
        }
        set
        {
            this.gclass3_0 = value;
        }
    }

    [Description("BorderStyle"), DefaultValue(typeof(Border3DStyle), "Sunken"), Category("Appearance")]
    public Border3DStyle Border3DStyle_0
    {
        get
        {
            return this.border3DStyle_0;
        }
        set
        {
            this.border3DStyle_0 = value;
            base.Invalidate();
        }
    }

    public GEnum0 GEnum0_0
    {
        get
        {
            return this.genum0_0;
        }
        set
        {
            this.genum0_0 = value;
        }
    }

    public GEnum1 GEnum1_0
    {
        get
        {
            return this.genum1_0;
        }
        set
        {
            if (value == GEnum1.Disabled)
            {
                if (this.genum1_0 != GEnum1.Disabled)
                {
                    this.genum1_0 = value;
                    this.timer_0.Stop();
                    this.method_4();
                    return;
                }
            }
            else
            {
                this.genum1_0 = value;
                this.timer_0.Start();
            }
        }
    }

    public int Int32_0
    {
        get
        {
            return this.timer_0.Interval;
        }
        set
        {
            if (value < 15)
            {
                throw new ArgumentOutOfRangeException("TimerInterval", value, "The Timer interval must be greater then 15");
            }
            this.timer_0.Interval = value;
        }
    }
}

