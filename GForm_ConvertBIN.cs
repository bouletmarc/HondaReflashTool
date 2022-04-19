using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;


public class GForm_ConvertBIN : DarkForm
{

    public GForm_ConvertBIN()
    {
        this.InitializeComponent();
    }

    public string FileBIN { get; set; }
    public string FileRWD { get; set; }

    private void method_0(object sender, EventArgs e)
    {
        this.FileBIN = this.textBox_bin.Text;
        this.FileRWD = this.textBox_rwd.Text;
        base.Close();
    }

    private void method_1(object sender, EventArgs e)
    {

    }

    private void method_2(object sender, EventArgs e)
    {
        base.DialogResult = DialogResult.Abort;
        base.Close();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && this.icontainer_0 != null)
        {
            this.icontainer_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.darkButton_0 = new DarkUI.Controls.DarkButton();
            this.darkButton_1 = new DarkUI.Controls.DarkButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_bin = new System.Windows.Forms.TextBox();
            this.textBox_rwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // darkButton_0
            // 
            this.darkButton_0.Checked = false;
            this.darkButton_0.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.darkButton_0.Location = new System.Drawing.Point(257, 154);
            this.darkButton_0.Name = "darkButton_0";
            this.darkButton_0.Size = new System.Drawing.Size(75, 23);
            this.darkButton_0.TabIndex = 4;
            this.darkButton_0.Text = "Accept";
            this.darkButton_0.Click += new System.EventHandler(this.method_0);
            // 
            // darkButton_1
            // 
            this.darkButton_1.Checked = false;
            this.darkButton_1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.darkButton_1.Location = new System.Drawing.Point(12, 154);
            this.darkButton_1.Name = "darkButton_1";
            this.darkButton_1.Size = new System.Drawing.Size(75, 23);
            this.darkButton_1.TabIndex = 5;
            this.darkButton_1.Text = "Cancel";
            this.darkButton_1.Click += new System.EventHandler(this.method_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select decrypted firmware .bin file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select encrypted firmware .rwd file:";
            // 
            // textBox_bin
            // 
            this.textBox_bin.Location = new System.Drawing.Point(12, 79);
            this.textBox_bin.Name = "textBox_bin";
            this.textBox_bin.Size = new System.Drawing.Size(320, 20);
            this.textBox_bin.TabIndex = 8;
            this.textBox_bin.DoubleClick += new System.EventHandler(this.textBox_bin_DoubleClick);
            // 
            // textBox_rwd
            // 
            this.textBox_rwd.Location = new System.Drawing.Point(12, 124);
            this.textBox_rwd.Name = "textBox_rwd";
            this.textBox_rwd.Size = new System.Drawing.Size(320, 20);
            this.textBox_rwd.TabIndex = 9;
            this.textBox_rwd.DoubleClick += new System.EventHandler(this.textBox_rwd_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 39);
            this.label3.TabIndex = 10;
            this.label3.Text = "To create a firmware .rwd file from a decrypted .bin, you must select\r\nthe .rwd f" +
    "irmware from which it has been decrypted from in\r\norder to use the same encrypti" +
    "on method";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Select File";
            // 
            // GForm_ConvertBIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 187);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_rwd);
            this.Controls.Add(this.textBox_bin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.darkButton_1);
            this.Controls.Add(this.darkButton_0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GForm_ConvertBIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convert .bin to .rwd";
            this.Load += new System.EventHandler(this.method_1);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    [CompilerGenerated]
    private IContainer icontainer_0;
    private DarkButton darkButton_0;
    private Label label1;
    private Label label2;
    private TextBox textBox_bin;
    private TextBox textBox_rwd;
    private Label label3;
    private OpenFileDialog openFileDialog1;
    private DarkButton darkButton_1;

    private void textBox_bin_DoubleClick(object sender, EventArgs e)
    {
        this.openFileDialog1.Filter = "Honda decompressed firmware binary|*.bin";
        this.openFileDialog1.DefaultExt = "*.bin";

        DialogResult result = this.openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            this.textBox_bin.Text = this.openFileDialog1.FileName;
        }
    }

    private void textBox_rwd_DoubleClick(object sender, EventArgs e)
    {
        this.openFileDialog1.Filter = "Honda compressed firmware file|*.rwd;*.gz";
        this.openFileDialog1.DefaultExt = "*.gz";

        DialogResult result = this.openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            this.textBox_rwd.Text = this.openFileDialog1.FileName;
        }
    }
}
