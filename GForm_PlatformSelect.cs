using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;


public class GForm_PlatformSelect : DarkForm
{



    internal Class_ECUS Class9_0 { get; set; }


    public GForm_PlatformSelect()
    {
        this.InitializeComponent();
        method_0();
    }


    private void method_0()
    {
        this.method_1();
        for (int i = 0; i < this.list_0.Count; i++)
        {
            DataGridViewRow dataGridViewRow = (DataGridViewRow)this.dataGridView_0.RowTemplate.Clone();
            dataGridViewRow.CreateCells(this.dataGridView_0, new object[]
            {
                this.list_0[i].Processor,
                this.list_0[i].RomSize_String,
                this.list_0[i].ECU_Byte_String,
                this.list_0[i].TransmissionType
            });
            this.dataGridView_0.Rows.Add(dataGridViewRow);
        }
        this.dataGridView_0.AutoResizeColumns();
    }


    private void method_1()
    {
        this.list_0.Add(new Class_ECUS("1MB", "SH7058", 16, "0x10", 1048576, 1015808, "Manual"));
        this.list_0.Add(new Class_ECUS("1MB", "SH7058", 17, "0x11", 1048576, 1015808, "Automatic"));
        this.list_0.Add(new Class_ECUS("1MB", "SH7058", 14, "0x0E", 1048576, 1015808, "CVT(maybe?)"));
        this.list_0.Add(new Class_ECUS("2MB", "SH72531", 16, "0x10", 2097152, 2031616, "Manual"));
        this.list_0.Add(new Class_ECUS("2MB", "SH72531", 17, "0x11", 2097152, 2031616, "Automatic"));
        this.list_0.Add(new Class_ECUS("2MB", "SH72531", 14, "0x0E", 2097152, 2031616, "CVT(maybe?)"));
    }


    private void method_2(object sender, EventArgs e)
    {
        if (this.dataGridView_0.SelectedCells[0].RowIndex != -1)
        {
            this.Class9_0 = this.list_0[this.dataGridView_0.SelectedCells[0].RowIndex];
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            base.Close();
            return;
        }
        MessageBox.Show("You have to select a platform before closing");
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.darkButton_0 = new DarkUI.Controls.DarkButton();
            this.dataGridView_0 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransmissionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).BeginInit();
            this.SuspendLayout();
            // 
            // darkButton_0
            // 
            this.darkButton_0.Checked = false;
            this.darkButton_0.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.darkButton_0.Location = new System.Drawing.Point(460, 196);
            this.darkButton_0.Name = "darkButton_0";
            this.darkButton_0.Size = new System.Drawing.Size(101, 23);
            this.darkButton_0.TabIndex = 1;
            this.darkButton_0.Text = "Accept";
            this.darkButton_0.Click += new System.EventHandler(this.method_2);
            // 
            // dataGridView_0
            // 
            this.dataGridView_0.AllowUserToAddRows = false;
            this.dataGridView_0.AllowUserToDeleteRows = false;
            this.dataGridView_0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_0.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.TransmissionType});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_0.EnableHeadersVisualStyles = false;
            this.dataGridView_0.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dataGridView_0.Location = new System.Drawing.Point(8, 8);
            this.dataGridView_0.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_0.Name = "dataGridView_0";
            this.dataGridView_0.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_0.RowHeadersVisible = false;
            this.dataGridView_0.RowHeadersWidth = 80;
            this.dataGridView_0.RowTemplate.Height = 28;
            this.dataGridView_0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_0.Size = new System.Drawing.Size(436, 211);
            this.dataGridView_0.TabIndex = 4;
            this.dataGridView_0.DoubleClick += new System.EventHandler(this.method_2);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 67.67797F;
            this.Column1.HeaderText = "Processor Type";
            this.Column1.MinimumWidth = 35;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 71.06599F;
            this.Column2.HeaderText = "Rom Size";
            this.Column2.MinimumWidth = 35;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 68.42973F;
            this.Column3.HeaderText = "ECUID";
            this.Column3.MinimumWidth = 35;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // TransmissionType
            // 
            this.TransmissionType.FillWeight = 192.8263F;
            this.TransmissionType.HeaderText = "Transmission Type";
            this.TransmissionType.MinimumWidth = 35;
            this.TransmissionType.Name = "TransmissionType";
            this.TransmissionType.ReadOnly = true;
            // 
            // GForm_PlatformSelect
            // 
            this.AcceptButton = this.darkButton_0;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 225);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_0);
            this.Controls.Add(this.darkButton_0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GForm_PlatformSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Platform";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_0)).EndInit();
            this.ResumeLayout(false);

    }


    internal List<Class_ECUS> list_0 = new List<Class_ECUS>();


    [CompilerGenerated]
    private Class_ECUS class9_0;


    private IContainer icontainer_0;


    private DarkButton darkButton_0;


    private DataGridView dataGridView_0;


    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;


    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private DataGridViewTextBoxColumn Column3;
    private DataGridViewTextBoxColumn TransmissionType;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

}
