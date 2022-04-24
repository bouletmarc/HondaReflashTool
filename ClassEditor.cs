using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;

internal class ClassEditor
{

    private Editortable Editortable_0;

    internal ClassEditor(ref Editortable Editortable_1)
    {
        Editortable_0 = Editortable_1;
    }

    /*public string smethod_0(ZipArchiveEntry zipArchiveEntry_0)
    {
        string text = "";
        using (Stream stream = zipArchiveEntry_0.Open())
        {
            using (StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-1")))
            {
                text += streamReader.ReadToEnd();
            }
        }
        return text;
    }*/

    public float smethod_1()
    {
        return Editortable.float_0;
    }

    public string smethod_2(int int_232, int int_233, bool bool_5, bool bool_6)
    {
        float num = this.smethod_1();
        string format = "0";
        string text = Editortable_0.dataGridView_0.Rows[int_232].Cells[int_233].Value.ToString();
        if (text.Contains("."))
        {
            format = "0.000";
        }
        if (bool_6)
        {
            num *= 4f;
        }
        if (bool_5)
        {
            return (float.Parse(text) + num).ToString(format);
        }
        return (float.Parse(text) - num).ToString(format);
    }

    public void smethod_3(KeyEventArgs keyEventArgs_0, int int_232)
    {
        bool bool_ = false;
        if (Control.ModifierKeys == Keys.Shift)
        {
            bool_ = true;
        }
        if (keyEventArgs_0.KeyCode == Keys.Delete || int_232 == 1)
        {
            int num = 0;
            int num2 = 0;
            int i = 0;
            //if (Editortable_0.frmOBD2Scan_0 != null)
            //{
                while (i < Editortable_0.dataGridView_0.Rows.Count)
                {
                    if (Editortable_0.dataGridView_0.Rows[i].Cells[num2].Selected)
                    {
                        Editortable_0.dataGridView_0.Rows[i].Cells[num2].Value = 0;
                    }
                    if (num2 == Editortable_0.dataGridView_0.Columns.Count - 1)
                    {
                        num2 = 0;
                        i++;
                    }
                    else
                    {
                        num2++;
                    }
                    num++;
                }
            //}
        }
        if (keyEventArgs_0.KeyCode == Keys.W || int_232 == 2)
        {
            int num3 = 0;
            int num4 = 0;
            int j = 0;
            while (j < Editortable_0.dataGridView_0.Rows.Count)
            {
                if (Editortable_0.dataGridView_0.Rows[j].Cells[num4].Selected)
                {
                    Editortable_0.dataGridView_0.Rows[j].Cells[num4].Value = this.smethod_2(j, num4, true, bool_);
                }
                if (num4 == Editortable_0.dataGridView_0.Columns.Count - 1)
                {
                    num4 = 0;
                    j++;
                }
                else
                {
                    num4++;
                }
                num3++;
            }
        }
        if (keyEventArgs_0.KeyCode == Keys.S || int_232 == 3)
        {
            int num5 = 0;
            int num6 = 0;
            int k = 0;
            while (k < Editortable_0.dataGridView_0.Rows.Count)
            {
                if (Editortable_0.dataGridView_0.Rows[k].Cells[num6].Selected)
                {
                    Editortable_0.dataGridView_0.Rows[k].Cells[num6].Value = this.smethod_2(k, num6, false, bool_);
                }
                if (num6 == Editortable_0.dataGridView_0.Columns.Count - 1)
                {
                    num6 = 0;
                    k++;
                }
                else
                {
                    num6++;
                }
                num5++;
            }
        }
        Class40 class40_0 = new Class40();
        //this.smethod_4(200).ContinueWith(new Action<Task>(this.<> c.<> 9.method_0));
        this.smethod_4(200, class40_0).ContinueWith(new Action<Task>(class40_0.method_0));
    }

    private Task smethod_4(int int_232, Class40 class40_0)
    {
        //Class40 class40_0 = new Class40();
        class40_0.taskCompletionSource_0 = new TaskCompletionSource<object>();
        new System.Threading.Timer(new TimerCallback(class40_0.method_0)).Change(int_232, -1);
        return class40_0.taskCompletionSource_0.Task;
    }

    public void smethod_5(string TableSize)
    {
        int[] array = new int[0];
        int[] tablearray = new int[0];
        bool Is1x20Table = false;

        if (TableSize == "10X20")
        {
            int num = 2;
            if (this.bool_3) num = 1;
            int num2 = this.int_0;
            array = new int[this.int_1 * num];
            for (int i = 0; i < this.int_1 * num; i++)
            {
                array[i] = (int)this.byte_0[num2];
                this.byte_0[num2] = (byte)this.int_219[i];
                num2++;
            }
            tablearray = this.int_219;
            Is1x20Table = true;
        }
        else
        {
            int num = this.int_0;
            array = new int[this.int_1 * 2];
            for (int i = 0; i < this.int_1 * 2; i++)
            {
                array[i] = (int)this.byte_0[num];
                if (TableSize == "1X64") this.byte_0[num] = (byte)this.int_220[i];
                if (TableSize == "1X15") this.byte_0[num] = (byte)this.int_221[i];
                if (TableSize == "1X8") this.byte_0[num] = (byte)this.int_222[i];
                if (TableSize == "1X7") this.byte_0[num] = (byte)this.int_223[i];
                if (TableSize == "1X6") this.byte_0[num] = (byte)this.int_224[i];
                if (TableSize == "1X5") this.byte_0[num] = (byte)this.int_225[i];
                if (TableSize == "1X4") this.byte_0[num] = (byte)this.int_226[i];
                if (TableSize == "1X2") this.byte_0[num] = (byte)this.int_231[i];
                if (TableSize == "1X1") this.byte_0[num] = (byte)this.int_231[i];
                num++;
            }
            if (TableSize == "1X64") tablearray = this.int_220;
            if (TableSize == "1X15") tablearray = this.int_221;
            if (TableSize == "1X8") tablearray = this.int_222;
            if (TableSize == "1X7") tablearray = this.int_223;
            if (TableSize == "1X6") tablearray = this.int_224;
            if (TableSize == "1X5") tablearray = this.int_225;
            if (TableSize == "1X4") tablearray = this.int_226;
            if (TableSize == "1X2") tablearray = this.int_231;
            if (TableSize == "1X1") tablearray = this.int_231;
        }


        int num3 = 0;
        string text = null;
        foreach (int num4 in tablearray)
        {
            //if ((!this.bool_3 || num3 < 200) && num4.ToString() != array[num3].ToString())
            if (((Is1x20Table && (!this.bool_3 || num3 < 200)) || (!Is1x20Table)) && num4.ToString() != array[num3].ToString())
            {
                text = string.Concat(new string[]
                {
                    text,
                    "Change at line: ",
                    num3.ToString(),
                    "[",
                    array[num3].ToString(),
                    " : ",
                    num4.ToString(),
                    "]",
                    Environment.NewLine
                });
                Editortable_0.GForm_Main_0.method_1(string.Concat(new string[]
                {
                    "Change at line: ",
                    num3.ToString(),
                    "[",
                    array[num3].ToString(),
                    " : ",
                    num4.ToString(),
                    "]"
                }));
            }
            num3++;
        }
        this.string_3 = string.Concat(new string[]
        {
            this.string_3,
            "Table: ",
            TableSize,
            Environment.NewLine,
            "Address: ",
            this.int_0.ToString(),
            Environment.NewLine,
            text
        });
    }

    public void smethod_15(string string_4)
    {
        try
        {
            if (this.bool_2 && this.int_1 != 0 && this.int_0 != 0)
            {
                if (this.int_1 == 200)
                {
                    this.smethod_5("10X20");
                }
                else if (this.int_1 == 64)
                {
                    this.smethod_5("1X64");
                }
                else if (this.int_1 == 15)
                {
                    this.smethod_5("1X15");
                }
                else if (this.int_1 == 8)
                {
                    this.smethod_5("1X8");
                }
                else if (this.int_1 == 7)
                {
                    this.smethod_5("1X7");
                    //this.smethod_5("1X5");
                }
                else if (this.int_1 == 6)
                {
                    this.smethod_5("1X6");
                    //this.smethod_5("1X5");
                }
                else if (this.int_1 == 5)
                {
                    this.smethod_5("1X5");
                }
                else if (this.int_1 == 4)
                {
                    this.smethod_5("1X4");
                }
                else if (this.int_1 == 2)
                {
                    this.smethod_5("1X2");
                }
                else if (this.int_1 == 1)
                {
                    this.smethod_5("1X1");
                }
                this.string_2 = this.string_2 + this.string_3 + Environment.NewLine;
            }
            this.bool_2 = false;

            //################################################
            byte[] SavingBytes = this.byte_0;

            //Remove fake bootloader section
            if (!this.Editortable_0.IsFullBinary)
            {
                byte[] BufferBytes = new byte[SavingBytes.Length - 0x8000];
                for (int i = 0; i < SavingBytes.Length; i++) BufferBytes[i] = SavingBytes[i + 0x8000];

                SavingBytes = BufferBytes;
            }

            //Fix Checksums
            if (!this.Editortable_0.IsFullBinary) SavingBytes = this.Editortable_0.GForm_Main_0.VerifyChecksumFWBin(SavingBytes);
            if (this.Editortable_0.IsFullBinary) SavingBytes = this.Editortable_0.GForm_Main_0.VerifyChecksumFullBin(SavingBytes);

            File.Create(string_4).Dispose();
            File.WriteAllBytes(string_4, SavingBytes);
            //################################################
            //string text = string_4 + "~temp";
            //string text2 = string_4 + "~temp2";
            /*File.WriteAllBytes(text, this.byte_0);
            File.WriteAllText(text2, this.string_2);
            using (FileStream fileStream = new FileStream(string_4, FileMode.OpenOrCreate))
            {
                FlashGUI.smethod_1(this.string_0 + Environment.NewLine + this.string_1, fileStream);
            }
            using (ZipArchive zipArchive = ZipFile.Open(string_4, ZipArchiveMode.Update))
            {
                zipArchive.CreateEntryFromFile(text, this.string_1);
                zipArchive.CreateEntryFromFile(text2, "CLOG");
            }
            File.Delete(text);
            File.Delete(text2);*/
            DarkMessageBox.Show("Successfully Saved File!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        catch
        {
            DarkMessageBox.Show("Failed to save file!.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    public void smethod_16(int[] int_232, int int_233, string string_4, string string_5, string[] string_6, Editortable.GEnum2 genum2_0, bool bool_5)
    {
        try
        {
            this.int_1 = int_232[0] * int_232[1];
            this.int_0 = int_233;
            Editortable_0.dataGridView_0.Rows.Clear();
            Editortable_0.dataGridView_0.Columns.Clear();
            Editortable_0.dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Editortable_0.dataGridView_0.TopLeftHeaderCell.Value = string_4;
            if (bool_5)
            {
                Editortable_0.dataGridView_0.ColumnCount = int_232[0];
                for (int i = 0; i < int_232[1]; i++)
                {
                    Editortable_0.dataGridView_0.Rows.Add(new object[]
                    {
                        this.smethod_18(int_233 + i * 2).ToString()
                    });
                    Editortable_0.dataGridView_0.Rows[i].HeaderCell.Value = string_6[i].ToString();
                }
            }
            else
            {
                for (int j = 0; j < int_232[0]; j++)
                {
                    Editortable_0.dataGridView_0.Columns.Add(string_6[j].ToString(), string_6[j].ToString());
                }
                List<string> list = new List<string>();
                if (genum2_0 == Editortable.GEnum2.LAF_VOLTAGE)
                {
                    for (int k = 0; k < int_232[0]; k++)
                    {
                        ushort num = (ushort)this.smethod_18(int_233 + k * 2);
                        list.Add((32767f / (float)num).ToString("0.00"));
                    }
                }
                else
                {
                    if (genum2_0 != Editortable.GEnum2.INJ_DEADTIME)
                    {
                        if (genum2_0 != Editortable.GEnum2.MIN_IPW)
                        {
                            if (genum2_0 == Editortable.GEnum2.WOT_MAP)
                            {
                                for (int l = 0; l < int_232[0]; l++)
                                {
                                    ushort num2 = (ushort)this.smethod_18(int_233 + l * 2);
                                    list.Add(((double)num2 * 0.01).ToString("0.00"));
                                }
                                goto IL_258;
                            }
                            if (genum2_0 == Editortable.GEnum2.THROTTLE_REQ)
                            {
                                for (int m = 0; m < int_232[0]; m++)
                                {
                                    ushort num3 = (ushort)this.smethod_18(int_233 + m * 2);
                                    list.Add(((double)num3 * 0.005).ToString("0.00"));
                                }
                                goto IL_258;
                            }
                            for (int n = 0; n < int_232[0]; n++)
                            {
                                list.Add(this.smethod_18(int_233 + n * 2).ToString());
                            }
                            goto IL_258;
                        }
                    }
                    for (int num4 = 0; num4 < int_232[0]; num4++)
                    {
                        ushort num5 = (ushort)this.smethod_18(int_233 + num4 * 2);
                        list.Add(((double)num5 * 0.002).ToString("0.000"));
                    }
                }
            IL_258:
                Editortable_0.dataGridView_0.Rows.Add();
                for (int num6 = 0; num6 < int_232[0]; num6++)
                {
                    DataGridViewRow dataGridViewRow = Editortable_0.dataGridView_0.Rows[0];
                    dataGridViewRow.Cells[num6].Value = list[num6];
                }
                Editortable_0.dataGridView_0.Rows[0].HeaderCell.Value = string_5;
            }
            Editortable_0.dataGridView_0.AllowUserToAddRows = false;
            foreach (object obj in Editortable_0.dataGridView_0.Columns)
            {
                DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewColumn.Width = 50;
            }
            if (!bool_5)
            {
                foreach (object obj2 in ((IEnumerable)Editortable_0.dataGridView_0.Rows))
                {
                    DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
                    dataGridViewRow2.Height = 20;
                }
            }
            this.smethod_33(int_232[0], Editortable.float_1[0], Editortable.float_1[1]);
            this.bool_0 = true;
        }
        catch (Exception ex)
        {
            this.bool_0 = false;
            DarkMessageBox.Show("Failed to load table. " + ex.ToString());
        }
    }

    public bool smethod_17(string string_4)
    {
        if (File.Exists(string_4))
        {
            try
            {
                this.byte_0 = File.ReadAllBytes(string_4);

                //Create a fake bootloader section
                if (!Editortable_0.IsFullBinary)
                {
                    byte[] BufferBytes = new byte[0x8000 + this.byte_0.Length];
                    for (int i = 0; i < 0x8000; i++) BufferBytes[i] = 0xff;
                    for (int i = 0; i < this.byte_0.Length; i++) BufferBytes[0x8000 + i] = this.byte_0[i];

                    this.byte_0 = BufferBytes;
                }

                //Get ECU filename  (33 37 38 30 35 2D  ->  37805- 'in ASCII chars')  (37805-RRB-A140)
                this.string_0 = "";
                for (int i = 0; i < this.byte_0.Length; i++)
                {
                    if (this.byte_0[i] == 0x33 &&
                        this.byte_0[i + 1] == 0x37 &&
                        this.byte_0[i + 2] == 0x38 &&
                        this.byte_0[i + 3] == 0x30 &&
                        (this.byte_0[i + 4] == 0x35 || this.byte_0[i + 4] == 0x36) &&
                        this.byte_0[i + 5] == 0x2D)
                    {
                        for (int i2 = 0; i2 < 14; i2++)
                        {
                            this.string_0 += (char)this.byte_0[i + i2];
                        }
                        break;
                    }
                }
                return true;

                /*this.string_0 = array[0];     //37805-RRB-A140
                this.string_1 = array[1];     //Unused

                using (FileStream fileStream = new FileStream(string_4, FileMode.Open))
                {
                    using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                        {
                            if (zipArchiveEntry.Name == "CALID")
                            {
                                //string[] array = File.ReadAllLines(Application.StartupPath + @"\CALID\" + string_4);
                                string[] array = this.smethod_0(zipArchiveEntry).Split(new string[]
                                {
                                    Environment.NewLine
                                }, StringSplitOptions.None);
                                this.string_0 = array[0];
                                this.string_1 = array[1];
                                foreach (ZipArchiveEntry zipArchiveEntry2 in zipArchive.Entries)
                                {
                                    if (zipArchiveEntry2.Name == "CLOG")
                                    {
                                        this.string_2 = this.smethod_0(zipArchiveEntry2);
                                    }
                                    if (zipArchiveEntry2.Name == array[1])
                                    {
                                        using (Stream stream = zipArchiveEntry2.Open())
                                        {
                                            using (BinaryReader binaryReader = new BinaryReader(stream))
                                            {
                                                this.byte_0 = binaryReader.ReadBytes((int)zipArchiveEntry2.Length);
                                                return true;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                Editortable_0.GForm_Main_0.method_1("Cannot load Error#1");
                return false;*/
            }
            catch
            {
                return false;
            }
        }
        return false;
    }

    public int smethod_18(int int_232)
    {
        return (int)((short)((int)this.byte_0[int_232] << 8 | (int)this.byte_0[int_232 + 1]));
    }

    public int smethod_19(int int_232)
    {
        return (int)this.byte_0[int_232];
    }

    public bool smethod_21()
    {
        int num = 0;
        int num2 = 2;
        bool flag = false;
        string[] array = new string[200];
        if (this.bool_3)
        {
            num2 = 1;
        }
        if (Editortable_0.dataGridView_0.ColumnCount == 20)
        {
            flag = true;
            int num3 = 0;
            for (int i = 0; i < Editortable_0.dataGridView_0.RowCount; i++)
            {
                array[num3] = Editortable_0.dataGridView_0.Rows[i].Cells[0].Value.ToString();
                array[num3 + 1] = Editortable_0.dataGridView_0.Rows[i].Cells[1].Value.ToString();
                array[num3 + 2] = Editortable_0.dataGridView_0.Rows[i].Cells[2].Value.ToString();
                array[num3 + 3] = Editortable_0.dataGridView_0.Rows[i].Cells[3].Value.ToString();
                array[num3 + 4] = Editortable_0.dataGridView_0.Rows[i].Cells[4].Value.ToString();
                array[num3 + 5] = Editortable_0.dataGridView_0.Rows[i].Cells[5].Value.ToString();
                array[num3 + 6] = Editortable_0.dataGridView_0.Rows[i].Cells[6].Value.ToString();
                array[num3 + 7] = Editortable_0.dataGridView_0.Rows[i].Cells[7].Value.ToString();
                array[num3 + 8] = Editortable_0.dataGridView_0.Rows[i].Cells[8].Value.ToString();
                array[num3 + 9] = Editortable_0.dataGridView_0.Rows[i].Cells[9].Value.ToString();
                array[num3 + 10] = Editortable_0.dataGridView_0.Rows[i].Cells[10].Value.ToString();
                array[num3 + 11] = Editortable_0.dataGridView_0.Rows[i].Cells[11].Value.ToString();
                array[num3 + 12] = Editortable_0.dataGridView_0.Rows[i].Cells[12].Value.ToString();
                array[num3 + 13] = Editortable_0.dataGridView_0.Rows[i].Cells[13].Value.ToString();
                array[num3 + 14] = Editortable_0.dataGridView_0.Rows[i].Cells[14].Value.ToString();
                array[num3 + 15] = Editortable_0.dataGridView_0.Rows[i].Cells[15].Value.ToString();
                array[num3 + 16] = Editortable_0.dataGridView_0.Rows[i].Cells[16].Value.ToString();
                array[num3 + 17] = Editortable_0.dataGridView_0.Rows[i].Cells[17].Value.ToString();
                array[num3 + 18] = Editortable_0.dataGridView_0.Rows[i].Cells[18].Value.ToString();
                array[num3 + 19] = Editortable_0.dataGridView_0.Rows[i].Cells[19].Value.ToString();
                num3 += 20;
            }
        }
        else if (Editortable_0.dataGridView_0.ColumnCount == 10)
        {
            object[,] array2 = new object[Editortable_0.dataGridView_0.ColumnCount, Editortable_0.dataGridView_0.RowCount];
            for (int j = 0; j < Editortable_0.dataGridView_0.RowCount; j++)
            {
                array2[0, j] = Editortable_0.dataGridView_0.Rows[j].Cells[0].Value.ToString();
                array2[1, j] = Editortable_0.dataGridView_0.Rows[j].Cells[1].Value.ToString();
                array2[2, j] = Editortable_0.dataGridView_0.Rows[j].Cells[2].Value.ToString();
                array2[3, j] = Editortable_0.dataGridView_0.Rows[j].Cells[3].Value.ToString();
                array2[4, j] = Editortable_0.dataGridView_0.Rows[j].Cells[4].Value.ToString();
                array2[5, j] = Editortable_0.dataGridView_0.Rows[j].Cells[5].Value.ToString();
                array2[6, j] = Editortable_0.dataGridView_0.Rows[j].Cells[6].Value.ToString();
                array2[7, j] = Editortable_0.dataGridView_0.Rows[j].Cells[7].Value.ToString();
                array2[8, j] = Editortable_0.dataGridView_0.Rows[j].Cells[8].Value.ToString();
                array2[9, j] = Editortable_0.dataGridView_0.Rows[j].Cells[9].Value.ToString();
            }
            array = array2.Cast<string>().ToArray<string>();
        }
        foreach (string s in array)
        {
            try
            {
                if (!this.bool_3)
                {
                    int num4 = (int)(float.Parse(s, CultureInfo.InvariantCulture) * 10f);
                    this.int_219[num + 1] = (int)((byte)num4);
                    this.int_219[num] = (int)((byte)(num4 >> 8));
                    num += 2;
                }
                else
                {
                    int num5;
                    if (flag)
                    {
                        num5 = (int)(128f / (float.Parse(s, CultureInfo.InvariantCulture) / 14.7f));
                    }
                    else
                    {
                        num5 = (int)(float.Parse(s, CultureInfo.InvariantCulture) * 10f);
                    }
                    this.int_219[num] = (int)((byte)num5);
                    num++;
                }
            }
            catch
            {
                return false;
            }
        }
        int num6 = this.int_0;
        int[] array4 = new int[this.int_1 * num2];
        for (int l = 0; l < this.int_1 * num2; l++)
        {
            array4[l] = (int)this.byte_0[num6];
            num6++;
        }
        int num7 = 0;
        foreach (int num8 in this.int_219)
        {
            if ((!this.bool_3 || num7 < 200) && num8.ToString() != array4[num7].ToString())
            {
                this.bool_2 = true;
            }
            num7++;
        }
        return true;
    }

    public bool smethod_22(string TableSize)
    {
        int[] arraytableint = new int[0];
        if (TableSize == "1X64") arraytableint = this.int_220;
        if (TableSize == "1X15") arraytableint = this.int_221;
        if (TableSize == "1X8") arraytableint = this.int_222;
        if (TableSize == "1X7") arraytableint = this.int_223;
        if (TableSize == "1X6") arraytableint = this.int_224;
        if (TableSize == "1X5") arraytableint = this.int_225;
        if (TableSize == "1X4") arraytableint = this.int_226;
        if (TableSize == "1X2") arraytableint = this.int_230;
        if (TableSize == "1X1") arraytableint = this.int_231;

        int num = 0;
        int num2 = 0;
        for (int i = 0; i < Editortable_0.dataGridView_0.ColumnCount; i++)
        {
            try
            {
                if (TableSize == "1X64") num2 = (int)float.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[i].Value.ToString(), CultureInfo.InvariantCulture);
                if (TableSize == "1X15") num2 = (int)(32767f / float.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[i].Value.ToString(), CultureInfo.InvariantCulture));
                if (TableSize == "1X8") num2 = (int)(float.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[i].Value.ToString(), CultureInfo.InvariantCulture) / 0.002f);
                if (TableSize == "1X7") num2 = (int)(float.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[i].Value.ToString(), CultureInfo.InvariantCulture) / 0.01f);
                if (TableSize == "1X6") num2 = (int)(float.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[i].Value.ToString(), CultureInfo.InvariantCulture) / 0.005f);
                if (TableSize == "1X5")
                {
                    if (Editortable.genum2_0 == Editortable.GEnum2.INJ_DEADTIME)
                    {
                        num2 = (int)((double)float.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[i].Value.ToString(), CultureInfo.InvariantCulture) / 0.002);
                    }
                    else
                    {
                        num2 = (int)float.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[i].Value.ToString(), CultureInfo.InvariantCulture);
                    }
                }
                if (TableSize == "1X4")
                {
                    if (Editortable.genum2_0 == Editortable.GEnum2.VTEC_PARAMS)
                    {
                        num2 = (int)float.Parse(Editortable_0.dataGridView_0.Rows[i].Cells[0].Value.ToString(), CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        num2 = (int)float.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[i].Value.ToString(), CultureInfo.InvariantCulture);
                    }
                }
                if (TableSize == "1X2")
                {
                    double numBuf = double.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[0].Value.ToString(), CultureInfo.InvariantCulture);
                    if (Editortable_0.dataGridView_0.Columns[0].HeaderText == "MPH") numBuf = Math.Floor(numBuf * 1.609344);
                    num2 = (int)numBuf;
                }
                if (TableSize == "1X1")
                {
                    if (Editortable.genum2_0 == Editortable.GEnum2.MIN_IPW)
                    {
                        double numBuf = double.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[0].Value.ToString(), CultureInfo.InvariantCulture) / 0.002;
                        num2 = (int)numBuf;
                    }
                    else
                    {
                        double numBuf = double.Parse(Editortable_0.dataGridView_0.Rows[0].Cells[0].Value.ToString(), CultureInfo.InvariantCulture);
                        if (Editortable_0.dataGridView_0.Columns[0].HeaderText == "MPH") numBuf = Math.Floor(num * 1.609344);
                        num2 = (int)num;
                    }
                }

                if (TableSize == "1X2" || TableSize == "1X1") num = 0;

                arraytableint[num + 1] = (int)((byte) num2);
                arraytableint[num] = (int)((byte)(num2 >> 8));

                num += 2;
            }
            catch
            {
                return false;
            }
        }

        int num3 = this.int_0;
        int[] array = new int[this.int_1 * 2];
        for (int j = 0; j < this.int_1 * 2; j++)
        {
            array[j] = (int)this.byte_0[num3];
            num3++;
        }

        int num4 = 0;
        foreach (int num5 in arraytableint)
        {
            if (num5.ToString() != array[num4].ToString()) this.bool_2 = true;
            num4++;
        }
        return true;
    }

    public bool smethod_31()
    {
        if (this.int_1 != 0 && this.int_0 != 0)
        {
            if (this.int_1 == 200)
            {
                return this.smethod_21();
            }
            if (this.int_1 == 64)
            {
                return this.smethod_22("1X64");
            }
            if (this.int_1 == 15)
            {
                return this.smethod_22("1X15");
            }
            if (this.int_1 == 8)
            {
                return this.smethod_22("1X8");
            }
            if (this.int_1 == 7)
            {
                return this.smethod_22("1X7");
            }
            if (this.int_1 == 6)
            {
                return this.smethod_22("1X6");
            }
            if (this.int_1 == 5)
            {
                return this.smethod_22("1X5");
            }
            if (this.int_1 == 4)
            {
                return this.smethod_22("1X4");
            }
            if (this.int_1 == 2)
            {
                return this.smethod_22("1X2");
            }
            if (this.int_1 == 1)
            {
                return this.smethod_22("1X1");
            }
        }
        return false;
    }

    public void smethod_32()
    {
        Editortable_0.dataGridView_0.ReadOnly = true;
        if (this.bool_0)
        {
            if (this.string_0.Contains("RRB"))
            {
                if (!this.smethod_31())
                {
                    this.bool_2 = false;
                    DarkMessageBox.Show("Table changes fail");
                    return;
                }
            }
            else if (this.string_0.Contains("S2K") && !this.smethod_31())
            {
                this.bool_2 = false;
                DarkMessageBox.Show("Table changes fail");
            }
        }
    }

    public void smethod_33(int int_232, float float_0, float float_1)
    {
        for (int i = 0; i < int_232; i++)
        {
            foreach (object obj in ((IEnumerable)Editortable_0.dataGridView_0.Rows))
            {
                DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                try
                {
                    float float_2 = float.Parse(dataGridViewRow.Cells[i].Value.ToString());
                    dataGridViewRow.Cells[i].Style.BackColor = this.smethod_34(float_2, float_1, float_0);
                }
                catch
                {
                    dataGridViewRow.Cells[i].Style.BackColor = System.Drawing.SystemColors.ControlLight;
                    //dataGridViewRow.Cells[i].Style.BackColor = Color.White;
                }
            }
        }
    }

    public Color smethod_34(float float_0, float float_1, float float_2)
    {
        Color result;
        try
        {
            int num = (int)(1023f * (float_0 - float_1) / (float_2 - float_1));
            if (num < 256)
            {
                result = Color.FromArgb(255, num, 0);
            }
            else if (num < 512)
            {
                num -= 256;
                result = Color.FromArgb(255 - num, 255, 0);
            }
            else if (num < 768)
            {
                num -= 512;
                result = Color.FromArgb(0, 255, num);
            }
            else
            {
                num -= 768;
                result = Color.FromArgb(0, 255 - num, 255);
            }
        }
        catch
        {
            result = Color.White;
        }
        return result;
    }

    public T[,] smethod_35<T>(T[] gparam_0, int int_232, int int_233)
    {
        T[,] array = new T[int_232, int_233];
        for (int i = 0; i < int_232; i++)
        {
            for (int j = 0; j < int_233; j++)
            {
                array[i, j] = gparam_0[i * int_233 + j];
            }
        }
        return array;
    }

    public void smethod_36()
    {
        this.int_2 = 47458;
        this.int_3 = 0;
        this.int_4 = 0;
        this.int_5 = new int[]
        {
            1,
            4
        };
        this.int_6 = 85312;
        this.int_25 = 0;
        this.int_26 = 0;
        this.int_27 = new int[]
        {
            2,
            1
        };
        this.int_30 = 90452;
        this.int_31 = 0;
        this.int_32 = 0;
        this.int_33 = new int[]
        {
            5,
            1
        };
        this.int_99 = 94604;
        this.int_100 = 78380;
        this.int_101 = 96212;
        this.int_102 = new int[]
        {
            10,
            20
        };
        this.int_103 = 94164;
        this.int_104 = 78380;
        this.int_105 = 94104;
        this.int_106 = new int[]
        {
            10,
            20
        };
        this.int_107 = 89972;
        this.int_108 = 78380;
        this.int_109 = 96212;
        this.int_110 = new int[]
        {
            10,
            20
        };
        this.int_111 = 89572;
        this.int_112 = 78380;
        this.int_113 = 94104;
        this.int_114 = new int[]
        {
            10,
            20
        };
    }

    public void smethod_37()
    {
        //Load RRB ROM
        this.int_2 = 46530;     //vtec engagement??
        this.int_3 = 0;
        this.int_4 = 0;
        this.int_5 = new int[]
        {
            1,
            4
        };
        this.int_6 = 71296;
        this.int_7 = 71304;
        this.int_8 = 71312;
        this.int_9 = 71320;
        this.int_10 = 71328;
        this.int_11 = 71332;
        this.int_12 = 71348;
        this.int_13 = 71356;
        this.int_14 = 46216;
        this.int_23 = 46216;
        this.int_24 = 46218;
        this.int_25 = 0;
        this.int_26 = 0;
        this.int_27 = new int[]
        {
            2,
            1
        };
        this.int_28 = 47690;
        this.int_29 = new int[]
        {
            1,
            1
        };
        this.int_30 = 76020;
        this.int_31 = 0;
        this.int_32 = 0;
        this.int_33 = new int[]
        {
            5,
            1
        };
        this.int_34 = 66002;
        this.int_35 = 0;
        this.int_36 = 66258;
        this.int_37 = new int[]
        {
            64,
            1
        };
        this.int_38 = 101836;
        this.int_39 = 87668;
        this.int_40 = 87628;
        this.int_41 = new int[]
        {
            10,
            20
        };
        this.int_42 = 102236;
        this.int_43 = 87668;
        this.int_44 = 87588;
        this.int_45 = new int[]
        {
            10,
            20
        };
        this.int_46 = 102636;
        this.int_47 = 0;
        this.int_48 = 102716;
        this.int_49 = new int[]
        {
            10,
            20
        };
        this.int_50 = 102676;
        this.int_51 = 0;
        this.int_52 = 102756;
        this.int_53 = new int[]
        {
            10,
            20
        };
        this.int_54 = 85588;
        this.int_55 = 87668;
        this.int_56 = 102716;
        this.int_57 = new int[]
        {
            10,
            20
        };
        this.int_58 = 85988;
        this.int_59 = 87668;
        this.int_60 = 102716;
        this.int_61 = new int[]
        {
            10,
            20
        };
        this.int_62 = 86388;
        this.int_63 = 87668;
        this.int_64 = 102716;
        this.int_65 = new int[]
        {
            10,
            20
        };
        this.int_66 = 86788;
        this.int_67 = 87668;
        this.int_68 = 102716;
        this.int_69 = new int[]
        {
            10,
            20
        };
        this.int_70 = 87188;
        this.int_71 = 87668;
        this.int_72 = 102716;
        this.int_73 = new int[]
        {
            10,
            20
        };
        this.int_74 = 83588;
        this.int_75 = 87668;
        this.int_76 = 102756;
        this.int_77 = new int[]
        {
            10,
            20
        };
        this.int_78 = 83988;
        this.int_79 = 87668;
        this.int_80 = 102756;
        this.int_81 = new int[]
        {
            10,
            20
        };
        this.int_82 = 84388;
        this.int_83 = 87668;
        this.int_84 = 102756;
        this.int_85 = new int[]
        {
            10,
            20
        };
        this.int_86 = 84788;
        this.int_87 = 87668;
        this.int_88 = 102756;
        this.int_89 = new int[]
        {
            10,
            20
        };
        this.int_90 = 85188;
        this.int_91 = 87668;
        this.int_92 = 102756;
        this.int_93 = new int[]
        {
            10,
            20
        };
        this.int_115 = 0;
        this.int_116 = 72672;
        this.int_119 = 0;
        this.int_120 = 75908;
        this.int_117 = 72688;
        this.int_118 = new int[]
        {
            8,
            1
        };
        this.int_121 = 75924;
        this.int_122 = new int[]
        {
            8,
            1
        };
        this.int_123 = 102756;
        this.int_124 = 87668;
        this.int_125 = 102716;
        this.int_126 = 87668;
        this.int_127 = 74034;
        this.int_128 = new int[]
        {
            20,
            10
        };
        this.int_129 = 74434;
        this.int_130 = new int[]
        {
            20,
            10
        };
        this.int_131 = 75034;
        this.int_132 = new int[]
        {
            20,
            10
        };
        this.int_133 = 74234;
        this.int_134 = new int[]
        {
            20,
            10
        };
        this.int_135 = 74634;
        this.int_136 = new int[]
        {
            20,
            10
        };
        this.int_137 = 74834;
        this.int_138 = new int[]
        {
            20,
            10
        };
        this.int_139 = 71540;
        this.int_140 = new int[]
        {
            15,
            1
        };
        this.int_141 = 79456;
        this.int_142 = 87668;
        this.int_143 = 102716;
        this.int_144 = new int[]
        {
            10,
            20
        };
        this.int_145 = 79856;
        this.int_146 = 87668;
        this.int_147 = 102716;
        this.int_148 = new int[]
        {
            10,
            20
        };
        this.int_149 = 80256;
        this.int_150 = 87668;
        this.int_151 = 102716;
        this.int_152 = new int[]
        {
            10,
            20
        };
        this.int_153 = 80656;
        this.int_154 = 87668;
        this.int_155 = 102716;
        this.int_156 = new int[]
        {
            10,
            20
        };
        this.int_157 = 81056;
        this.int_158 = 87668;
        this.int_159 = 102716;
        this.int_160 = new int[]
        {
            10,
            20
        };
        this.int_161 = 77456;
        this.int_162 = 87668;
        this.int_163 = 102756;
        this.int_164 = new int[]
        {
            10,
            20
        };
        this.int_165 = 77856;
        this.int_166 = 87668;
        this.int_167 = 102756;
        this.int_168 = new int[]
        {
            10,
            20
        };
        this.int_169 = 78256;
        this.int_170 = 87668;
        this.int_171 = 102756;
        this.int_172 = new int[]
        {
            10,
            20
        };
        this.int_173 = 78656;
        this.int_174 = 87668;
        this.int_175 = 102756;
        this.int_176 = new int[]
        {
            10,
            20
        };
        this.int_177 = 79056;
        this.int_178 = 87668;
        this.int_179 = 102756;
        this.int_180 = new int[]
        {
            10,
            20
        };
        this.int_189 = 89604;
        this.int_190 = 87668;
        this.int_191 = 102716;
        this.int_192 = new int[]
        {
            10,
            20
        };
        this.int_193 = 89204;
        this.int_194 = 87668;
        this.int_195 = 102756;
        this.int_196 = new int[]
        {
            10,
            20
        };
        this.int_181 = 77056;
        this.int_182 = 87668;
        this.int_183 = 102716;
        this.int_184 = new int[]
        {
            10,
            20
        };
        this.int_185 = 77256;
        this.int_186 = 87668;
        this.int_187 = 102756;
        this.int_188 = new int[]
        {
            10,
            20
        };
        this.int_197 = 64620;
        this.int_199 = 64636;
        this.int_201 = 65076;
        this.int_203 = 65100;
        this.int_205 = 65636;
        this.int_207 = 68956;
        this.int_211 = 69056;
        this.int_198 = new int[]
        {
            8,
            1
        };
        this.int_200 = new int[]
        {
            8,
            1
        };
        this.int_202 = new int[]
        {
            6,
            1
        };
        this.int_204 = new int[]
        {
            6,
            1
        };
        this.int_206 = new int[]
        {
            7,
            1
        };
        this.int_208 = new int[]
        {
            10,
            5
        };
        this.int_207 = 68956;
        this.int_209 = 69506;
        this.int_210 = 69556;
        this.int_214 = new int[]
        {
            15,
            15
        };
        this.int_211 = 69056;
        this.int_212 = 69526;
        this.int_213 = 69566;
        this.int_215 = 70982;
        this.int_216 = 44674;
        this.int_217 = 49780;
    }

    public int int_0;
    public int int_1;
    public bool bool_0 = false;
    public bool bool_1 = false;
    public string string_0;
    public string string_1;
    public byte[] byte_0;
    public string string_2;
    public string string_3;
    public bool bool_2 = false;
    public bool bool_3 = false;
    public int int_2;
    public int int_3;
    public int int_4;
    public int[] int_5;
    public int int_6;
    public int int_7;
    public int int_8;
    public int int_9;
    public int int_10;
    public int int_11;
    public int int_12;
    public int int_13;
    public int int_14;
    public int int_15;
    public int int_16;
    public int int_17;
    public int int_18;
    public int int_19;
    public int int_20;
    public int int_21;
    public int int_22;
    public int int_23;
    public int int_24;
    public int int_25;
    public int int_26;
    public int[] int_27;
    public int int_28;
    public int[] int_29;
    public int int_30;
    public int int_31;
    public int int_32;
    public int[] int_33;
    public int int_34;
    public int int_35;
    public int int_36;
    public int[] int_37;
    public int int_38;
    public int int_39;
    public int int_40;
    public int[] int_41;
    public int int_42;
    public int int_43;
    public int int_44;
    public int[] int_45;
    public int int_46;
    public int int_47;
    public int int_48;
    public int[] int_49;
    public int int_50;
    public int int_51;
    public int int_52;
    public int[] int_53;
    public int int_54;
    public int int_55;
    public int int_56;
    public int[] int_57;
    public int int_58;
    public int int_59;
    public int int_60;
    public int[] int_61;
    public int int_62;
    public int int_63;
    public int int_64;
    public int[] int_65;
    public int int_66;
    public int int_67;
    public int int_68;
    public int[] int_69;
    public int int_70;
    public int int_71;
    public int int_72;
    public int[] int_73;
    public int int_74;
    public int int_75;

    // Token: 0x040016A7 RID: 5799
    public int int_76;

    // Token: 0x040016A8 RID: 5800
    public int[] int_77;

    // Token: 0x040016A9 RID: 5801
    public int int_78;

    // Token: 0x040016AA RID: 5802
    public int int_79;

    // Token: 0x040016AB RID: 5803
    public int int_80;

    // Token: 0x040016AC RID: 5804
    public int[] int_81;

    // Token: 0x040016AD RID: 5805
    public int int_82;

    // Token: 0x040016AE RID: 5806
    public int int_83;

    // Token: 0x040016AF RID: 5807
    public int int_84;

    // Token: 0x040016B0 RID: 5808
    public int[] int_85;

    // Token: 0x040016B1 RID: 5809
    public int int_86;

    // Token: 0x040016B2 RID: 5810
    public int int_87;

    // Token: 0x040016B3 RID: 5811
    public int int_88;

    // Token: 0x040016B4 RID: 5812
    public int[] int_89;

    // Token: 0x040016B5 RID: 5813
    public int int_90;

    // Token: 0x040016B6 RID: 5814
    public int int_91;

    // Token: 0x040016B7 RID: 5815
    public int int_92;

    // Token: 0x040016B8 RID: 5816
    public int[] int_93;

    // Token: 0x040016B9 RID: 5817
    public int[] int_94 = new int[200];

    // Token: 0x040016BA RID: 5818
    public int[] int_95 = new int[200];

    // Token: 0x040016BB RID: 5819
    public int[] int_96 = new int[200];

    // Token: 0x040016BC RID: 5820
    public int[] int_97 = new int[50];

    // Token: 0x040016BD RID: 5821
    public int[] int_98 = new int[225];

    // Token: 0x040016BE RID: 5822
    public int int_99;

    // Token: 0x040016BF RID: 5823
    public int int_100;

    // Token: 0x040016C0 RID: 5824
    public int int_101;

    // Token: 0x040016C1 RID: 5825
    public int[] int_102;

    // Token: 0x040016C2 RID: 5826
    public int int_103;

    // Token: 0x040016C3 RID: 5827
    public int int_104;

    // Token: 0x040016C4 RID: 5828
    public int int_105;

    // Token: 0x040016C5 RID: 5829
    public int[] int_106;

    // Token: 0x040016C6 RID: 5830
    public int int_107;

    // Token: 0x040016C7 RID: 5831
    public int int_108;

    // Token: 0x040016C8 RID: 5832
    public int int_109;

    // Token: 0x040016C9 RID: 5833
    public int[] int_110;

    // Token: 0x040016CA RID: 5834
    public int int_111;

    // Token: 0x040016CB RID: 5835
    public int int_112;

    // Token: 0x040016CC RID: 5836
    public int int_113;

    // Token: 0x040016CD RID: 5837
    public int[] int_114;

    // Token: 0x040016CE RID: 5838
    public int int_115;

    // Token: 0x040016CF RID: 5839
    public int int_116;

    // Token: 0x040016D0 RID: 5840
    public int int_117;

    // Token: 0x040016D1 RID: 5841
    public int[] int_118;

    // Token: 0x040016D2 RID: 5842
    public int int_119;

    // Token: 0x040016D3 RID: 5843
    public int int_120;

    // Token: 0x040016D4 RID: 5844
    public int int_121;

    // Token: 0x040016D5 RID: 5845
    public int[] int_122;

    // Token: 0x040016D6 RID: 5846
    public int int_123;

    // Token: 0x040016D7 RID: 5847
    public int int_124;

    // Token: 0x040016D8 RID: 5848
    public int int_125;

    // Token: 0x040016D9 RID: 5849
    public int int_126;

    // Token: 0x040016DA RID: 5850
    public int int_127;

    // Token: 0x040016DB RID: 5851
    public int[] int_128;

    // Token: 0x040016DC RID: 5852
    public int int_129;

    // Token: 0x040016DD RID: 5853
    public int[] int_130;

    // Token: 0x040016DE RID: 5854
    public int int_131;

    // Token: 0x040016DF RID: 5855
    public int[] int_132;

    // Token: 0x040016E0 RID: 5856
    public int int_133;

    // Token: 0x040016E1 RID: 5857
    public int[] int_134;

    // Token: 0x040016E2 RID: 5858
    public int int_135;

    // Token: 0x040016E3 RID: 5859
    public int[] int_136;

    // Token: 0x040016E4 RID: 5860
    public int int_137;

    // Token: 0x040016E5 RID: 5861
    public int[] int_138;

    // Token: 0x040016E6 RID: 5862
    public int int_139;

    // Token: 0x040016E7 RID: 5863
    public int[] int_140;

    // Token: 0x040016E8 RID: 5864
    public int int_141;

    // Token: 0x040016E9 RID: 5865
    public int int_142;

    // Token: 0x040016EA RID: 5866
    public int int_143;

    // Token: 0x040016EB RID: 5867
    public int[] int_144;

    // Token: 0x040016EC RID: 5868
    public int int_145;

    // Token: 0x040016ED RID: 5869
    public int int_146;

    // Token: 0x040016EE RID: 5870
    public int int_147;

    // Token: 0x040016EF RID: 5871
    public int[] int_148;

    // Token: 0x040016F0 RID: 5872
    public int int_149;

    // Token: 0x040016F1 RID: 5873
    public int int_150;

    // Token: 0x040016F2 RID: 5874
    public int int_151;

    // Token: 0x040016F3 RID: 5875
    public int[] int_152;

    // Token: 0x040016F4 RID: 5876
    public int int_153;

    // Token: 0x040016F5 RID: 5877
    public int int_154;

    // Token: 0x040016F6 RID: 5878
    public int int_155;

    // Token: 0x040016F7 RID: 5879
    public int[] int_156;

    // Token: 0x040016F8 RID: 5880
    public int int_157;

    // Token: 0x040016F9 RID: 5881
    public int int_158;

    // Token: 0x040016FA RID: 5882
    public int int_159;

    // Token: 0x040016FB RID: 5883
    public int[] int_160;

    // Token: 0x040016FC RID: 5884
    public int int_161;

    // Token: 0x040016FD RID: 5885
    public int int_162;

    // Token: 0x040016FE RID: 5886
    public int int_163;

    // Token: 0x040016FF RID: 5887
    public int[] int_164;

    // Token: 0x04001700 RID: 5888
    public int int_165;

    // Token: 0x04001701 RID: 5889
    public int int_166;

    // Token: 0x04001702 RID: 5890
    public int int_167;

    // Token: 0x04001703 RID: 5891
    public int[] int_168;

    // Token: 0x04001704 RID: 5892
    public int int_169;

    // Token: 0x04001705 RID: 5893
    public int int_170;

    // Token: 0x04001706 RID: 5894
    public int int_171;

    // Token: 0x04001707 RID: 5895
    public int[] int_172;

    // Token: 0x04001708 RID: 5896
    public int int_173;

    // Token: 0x04001709 RID: 5897
    public int int_174;

    // Token: 0x0400170A RID: 5898
    public int int_175;

    // Token: 0x0400170B RID: 5899
    public int[] int_176;

    // Token: 0x0400170C RID: 5900
    public int int_177;

    // Token: 0x0400170D RID: 5901
    public int int_178;

    // Token: 0x0400170E RID: 5902
    public int int_179;

    // Token: 0x0400170F RID: 5903
    public int[] int_180;

    // Token: 0x04001710 RID: 5904
    public int int_181;

    // Token: 0x04001711 RID: 5905
    public int int_182;

    // Token: 0x04001712 RID: 5906
    public int int_183;

    // Token: 0x04001713 RID: 5907
    public int[] int_184;

    // Token: 0x04001714 RID: 5908
    public int int_185;

    // Token: 0x04001715 RID: 5909
    public int int_186;

    // Token: 0x04001716 RID: 5910
    public int int_187;

    // Token: 0x04001717 RID: 5911
    public int[] int_188;

    // Token: 0x04001718 RID: 5912
    public int int_189;

    // Token: 0x04001719 RID: 5913
    public int int_190;

    // Token: 0x0400171A RID: 5914
    public int int_191;

    // Token: 0x0400171B RID: 5915
    public int[] int_192;

    // Token: 0x0400171C RID: 5916
    public int int_193;

    // Token: 0x0400171D RID: 5917
    public int int_194;

    // Token: 0x0400171E RID: 5918
    public int int_195;

    // Token: 0x0400171F RID: 5919
    public int[] int_196;

    // Token: 0x04001720 RID: 5920
    public int int_197;

    // Token: 0x04001721 RID: 5921
    public int[] int_198;

    // Token: 0x04001722 RID: 5922
    public int int_199;

    // Token: 0x04001723 RID: 5923
    public int[] int_200;

    // Token: 0x04001724 RID: 5924
    public int int_201;

    // Token: 0x04001725 RID: 5925
    public int[] int_202;

    // Token: 0x04001726 RID: 5926
    public int int_203;

    // Token: 0x04001727 RID: 5927
    public int[] int_204;

    // Token: 0x04001728 RID: 5928
    public int int_205;

    // Token: 0x04001729 RID: 5929
    public int[] int_206;

    // Token: 0x0400172A RID: 5930
    public int int_207;

    // Token: 0x0400172B RID: 5931
    public int[] int_208;

    // Token: 0x0400172C RID: 5932
    public int int_209;

    // Token: 0x0400172D RID: 5933
    public int int_210;

    // Token: 0x0400172E RID: 5934
    public int int_211;

    // Token: 0x0400172F RID: 5935
    public int int_212;

    // Token: 0x04001730 RID: 5936
    public int int_213;

    // Token: 0x04001731 RID: 5937
    public int[] int_214;

    // Token: 0x04001732 RID: 5938
    public int int_215;

    // Token: 0x04001733 RID: 5939
    public int int_216;

    // Token: 0x04001734 RID: 5940
    public int int_217;

    // Token: 0x04001735 RID: 5941
    public bool bool_4 = false;

    // Token: 0x04001736 RID: 5942
    public int[] int_218 = new int[450];

    // Token: 0x04001737 RID: 5943
    public int[] int_219 = new int[400];

    // Token: 0x04001738 RID: 5944
    public int[] int_220 = new int[128];

    // Token: 0x04001739 RID: 5945
    public int[] int_221 = new int[30];

    // Token: 0x0400173A RID: 5946
    public int[] int_222 = new int[16];

    // Token: 0x0400173B RID: 5947
    public int[] int_223 = new int[14];

    // Token: 0x0400173C RID: 5948
    public int[] int_224 = new int[12];

    // Token: 0x0400173D RID: 5949
    public int[] int_225 = new int[10];

    // Token: 0x0400173E RID: 5950
    public int[] int_226 = new int[8];

    // Token: 0x0400173F RID: 5951
    public int[] int_227 = new int[7];

    // Token: 0x04001740 RID: 5952
    public int[] int_228 = new int[6];

    // Token: 0x04001741 RID: 5953
    public int[] int_229 = new int[5];

    // Token: 0x04001742 RID: 5954
    public int[] int_230 = new int[4];

    // Token: 0x04001743 RID: 5955
    public int[] int_231 = new int[2];

    // Token: 0x020000F8 RID: 248
    [CompilerGenerated]
    private sealed class Class40
    {
        // Token: 0x06000F06 RID: 3846 RVA: 0x00004E37 File Offset: 0x00003037
        internal Class40()
        {
        }

        // Token: 0x06000F07 RID: 3847 RVA: 0x0000B4B5 File Offset: 0x000096B5
        internal void method_0(object object_0)
        {
            this.taskCompletionSource_0.SetResult(null);
        }

        // Token: 0x04001746 RID: 5958
        public TaskCompletionSource<object> taskCompletionSource_0;
    }
}
