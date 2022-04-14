using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using SAE.J2534;


public class GForm_J2534Select : DarkForm
{

    public GForm_J2534Select()
    {
        this.InitializeComponent();
    }

    public APIInfo APIInfo_0 { get; set; }

    private void method_0(object sender, EventArgs e)
    {
        this.APIInfo_0 = (APIInfo)this.darkComboBox_0.SelectedItem;
        base.Close();
    }

    private void method_1(object sender, EventArgs e)
    {
        this.darkComboBox_0.DataSource = APIFactory.GetAPIList();
        this.darkComboBox_0.DisplayMember = "Name";
        if (this.darkComboBox_0.Items.Count == 0)
        {
            MessageBox.Show("No supported J2534 Driver found!");
            this.darkButton_0.Enabled = false;
        }
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
            this.darkComboBox_0 = new DarkUI.Controls.DarkComboBox();
            this.SuspendLayout();
            // 
            // darkButton_0
            // 
            this.darkButton_0.Checked = false;
            this.darkButton_0.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.darkButton_0.Location = new System.Drawing.Point(257, 41);
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
            this.darkButton_1.Location = new System.Drawing.Point(12, 41);
            this.darkButton_1.Name = "darkButton_1";
            this.darkButton_1.Size = new System.Drawing.Size(75, 23);
            this.darkButton_1.TabIndex = 5;
            this.darkButton_1.Text = "Cancel";
            this.darkButton_1.Click += new System.EventHandler(this.method_2);
            // 
            // darkComboBox_0
            // 
            this.darkComboBox_0.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.darkComboBox_0.FormattingEnabled = true;
            this.darkComboBox_0.Location = new System.Drawing.Point(12, 12);
            this.darkComboBox_0.Name = "darkComboBox_0";
            this.darkComboBox_0.Size = new System.Drawing.Size(320, 21);
            this.darkComboBox_0.TabIndex = 6;
            // 
            // GForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 76);
            this.ControlBox = false;
            this.Controls.Add(this.darkComboBox_0);
            this.Controls.Add(this.darkButton_1);
            this.Controls.Add(this.darkButton_0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select J2534 Interface";
            this.Load += new System.EventHandler(this.method_1);
            this.ResumeLayout(false);

    }

    [CompilerGenerated]
    private APIInfo apiinfo_0;
    private IContainer icontainer_0;
    private DarkButton darkButton_0;
    private DarkButton darkButton_1;
    private DarkComboBox darkComboBox_0;

}
