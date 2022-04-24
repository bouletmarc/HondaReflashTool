using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;


public class GForm_Credits : DarkForm
{

    public GForm_Credits()
    {
        this.InitializeComponent();
    }

    private void method_0(object sender, EventArgs e)
    {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // darkButton_0
            // 
            this.darkButton_0.Checked = false;
            this.darkButton_0.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.darkButton_0.Location = new System.Drawing.Point(86, 139);
            this.darkButton_0.Name = "darkButton_0";
            this.darkButton_0.Size = new System.Drawing.Size(75, 23);
            this.darkButton_0.TabIndex = 4;
            this.darkButton_0.Text = "Accept";
            this.darkButton_0.Click += new System.EventHandler(this.method_0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(59, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 65);
            this.label1.TabIndex = 6;
            this.label1.Text = "BMDevs (Bouletmarc)\r\nNii-Saan (Romraider)\r\nGreg Hogan\r\nKalisto2002\r\nDmitry";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Credits from Honda community:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Select File";
            // 
            // GForm_Credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 172);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.darkButton_0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GForm_Credits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Credits";
            this.Load += new System.EventHandler(this.method_1);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    [CompilerGenerated]
    private IContainer icontainer_0;
    private DarkButton darkButton_0;
    private Label label1;
    private Label label3;
    private OpenFileDialog openFileDialog1;
}
