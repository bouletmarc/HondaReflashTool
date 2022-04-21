using System;
using System.Windows.Forms;

internal class ClassListView : ListView
{
    public ClassListView()
    {
        base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        base.SetStyle(ControlStyles.EnableNotifyMessage, true);
    }

    protected virtual void OnNotifyMessage(Message m)
    {
        if (m.Msg != 20)
        {
            base.OnNotifyMessage(m);
        }
    }
}

