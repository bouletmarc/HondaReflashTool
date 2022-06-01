using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;


public class GForm_Warning : DarkForm
{

    public GForm_Warning()
    {
        this.InitializeComponent();
        base.DialogResult = DialogResult.Abort;
    }

    private void method_0(object sender, EventArgs e)
    {
        base.DialogResult = DialogResult.Yes;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GForm_Warning));
            this.darkButton_0 = new DarkUI.Controls.DarkButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // darkButton_0
            // 
            this.darkButton_0.Checked = false;
            this.darkButton_0.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.darkButton_0.Location = new System.Drawing.Point(253, 289);
            this.darkButton_0.Name = "darkButton_0";
            this.darkButton_0.Size = new System.Drawing.Size(163, 23);
            this.darkButton_0.TabIndex = 4;
            this.darkButton_0.Text = "I Agree and Understand";
            this.darkButton_0.Click += new System.EventHandler(this.method_0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 208);
            this.label1.TabIndex = 6;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(105, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "***DANGER ZONE WARNING**";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // darkButton1
            // 
            this.darkButton1.Checked = false;
            this.darkButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.darkButton1.Location = new System.Drawing.Point(22, 289);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Size = new System.Drawing.Size(130, 23);
            this.darkButton1.TabIndex = 11;
            this.darkButton1.Text = "DO NOT PROCEED";
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // GForm_Warning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 334);
            this.Controls.Add(this.darkButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.darkButton_0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GForm_Warning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "** DANGER ** WARNING **";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    [CompilerGenerated]
    private IContainer icontainer_0;
    private DarkButton darkButton_0;
    private Label label1;
    private DarkButton darkButton1;
    private Label label3;

    private void darkButton1_Click(object sender, EventArgs e)
    {
        base.DialogResult = DialogResult.No;
        base.Close();
    }
}
