using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;


public class GForm_SeveralDef : DarkForm
{
    public GForm_Main GForm_Main_0;

    public GForm_SeveralDef()
    {
        this.InitializeComponent();
    }

    public void LoadSetValues(ref GForm_Main GForm_Main_1, string ThisEcuName, List<int> IndexxList)
    {
        GForm_Main_0 = GForm_Main_1;
        label3.Text = "More than one Definition file as been found for '" + ThisEcuName + "', please select which one we use:";

        for (int i = 0; i < IndexxList.Count; i++)
        {
            int ThisIndeex = IndexxList[i];
            string ThisItem = GForm_Main_0.Editortable_0.ClassEditor_0.Ecus_Definitions_Compatible[ThisIndeex] + " in: " + GForm_Main_0.Editortable_0.ClassEditor_0.Ecus_Definitions_Compatible_filename[ThisIndeex].Replace(Application.StartupPath, "");
            comboBox1.Items.Add(ThisItem);
        }
        //comboBox1.Items.Add();
        comboBox1.SelectedIndex = 0;
    }

    private void method_0(object sender, EventArgs e)
    {
        base.DialogResult = DialogResult.OK;
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // darkButton_0
            // 
            this.darkButton_0.Checked = false;
            this.darkButton_0.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.darkButton_0.Location = new System.Drawing.Point(206, 70);
            this.darkButton_0.Name = "darkButton_0";
            this.darkButton_0.Size = new System.Drawing.Size(75, 23);
            this.darkButton_0.TabIndex = 4;
            this.darkButton_0.Text = "Accept";
            this.darkButton_0.Click += new System.EventHandler(this.method_0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "More than one Definition file as been found for \'\', please select which one we us" +
    "e:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(471, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // GForm_SeveralDef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 110);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.darkButton_0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GForm_SeveralDef";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Several Definitions Found!";
            this.Load += new System.EventHandler(this.method_1);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    [CompilerGenerated]
    private IContainer icontainer_0;
    private DarkButton darkButton_0;
    private Label label3;
    public ComboBox comboBox1;
}
