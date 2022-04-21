using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

[TypeConverter(typeof(ExpandableObjectConverter))]
public class GClass4
{
    private Pen pen_0 = new Pen(Color.Black);

    public Color Color_0
    {
        get
        {
            return this.pen_0.Color;
        }
        set
        {
            this.pen_0.Color = value;
        }
    }

    public DashStyle DashStyle_0
    {
        get
        {
            return this.pen_0.DashStyle;
        }
        set
        {
            this.pen_0.DashStyle = value;
        }
    }

    public float Single_0
    {
        get
        {
            return this.pen_0.Width;
        }
        set
        {
            this.pen_0.Width = value;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
    public Pen Pen_0
    {
        get
        {
            return this.pen_0;
        }
    }
}

