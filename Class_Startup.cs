using System;
using System.Windows.Forms;

internal static class Class_Startup
{

    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new GForm_Main());
    }
}
