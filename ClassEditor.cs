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
    public List<string> Ecus_Definitions_Compatible = new List<string>();

    //Variables for loaded rom definition
    public List<string> DefinitionsLocationsX = new List<string>();
    public List<string> DefinitionsLocationsY = new List<string>();
    public List<string> DefinitionsLocationsTable = new List<string>();
    public List<string> DefinitionsMathX = new List<string>();
    public List<string> DefinitionsMathY = new List<string>();
    public List<string> DefinitionsMathTable = new List<string>();
    public List<string> DefinitionsFormatX = new List<string>();
    public List<string> DefinitionsFormatY = new List<string>();
    public List<string> DefinitionsFormatTable = new List<string>();
    public List<bool> DefinitionsIsSingleByteX = new List<bool>();
    public List<bool> DefinitionsIsSingleByteY = new List<bool>();
    public List<bool> DefinitionsIsSingleByteTable = new List<bool>();

    public List<string> DefinitionsName = new List<string>();
    public List<string> DefinitionsUnit1 = new List<string>();
    public List<string> DefinitionsUnit2 = new List<string>();
    public List<string> DefinitionsTableSize = new List<string>();
    public List<float> DefinitionsValueMin = new List<float>();
    public List<float> DefinitionsValueMax = new List<float>();
    public List<double> DefinitionsChangeAmount = new List<double>();
    public List<string> DefinitionsHeaders = new List<string>();
    public List<bool> DefinitionsIsXYInverted = new List<bool>();
    public List<bool> DefinitionsIsTableInverted = new List<bool>();

    private Editortable Editortable_0;

    internal ClassEditor(ref Editortable Editortable_1)
    {
        Editortable_0 = Editortable_1;
    }

    public float smethod_1()
    {
        return Editortable.float_0;
    }

    public string ValueIncDec(int RowIndex, int CellIndex, bool Increasing, bool Multiply4x)
    {
        float num = this.smethod_1();
        string format = "0";
        string text = Editortable_0.dataGridView_0.Rows[RowIndex].Cells[CellIndex].Value.ToString();
        if (text.Contains("."))
        {
            format = "0.000";
        }
        if (Multiply4x)
        {
            num *= 4f;
        }
        if (Increasing)
        {
            return (float.Parse(text) + num).ToString(format);
        }
        return (float.Parse(text) - num).ToString(format);
    }

    public void IncDecreaseSelection(bool Decreasing, bool HoldShift)
    {
        if (!Decreasing)
        {
            int num3 = 0;
            int num4 = 0;
            int j = 0;
            while (j < Editortable_0.dataGridView_0.Rows.Count)
            {
                if (Editortable_0.dataGridView_0.Rows[j].Cells[num4].Selected)
                {
                    Editortable_0.dataGridView_0.Rows[j].Cells[num4].Value = this.ValueIncDec(j, num4, true, HoldShift);
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
        else
        {
            int num5 = 0;
            int num6 = 0;
            int k = 0;
            while (k < Editortable_0.dataGridView_0.Rows.Count)
            {
                if (Editortable_0.dataGridView_0.Rows[k].Cells[num6].Selected)
                {
                    Editortable_0.dataGridView_0.Rows[k].Cells[num6].Value = this.ValueIncDec(k, num6, false, HoldShift);
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
    }

    public void ShortcutsCommand(KeyEventArgs keyEventArgs_0, int int_232)
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
            IncDecreaseSelection(false, bool_);
        }
        if (keyEventArgs_0.KeyCode == Keys.S || int_232 == 3)
        {
            IncDecreaseSelection(true, bool_);
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

    public void GetChanges()
    {
        int num = this.SelectedROMLocation;
        int multiplier = 2;
        if (this.IsSingleByteX || this.IsSingleByteY || this.IsSingleByteTable) multiplier = 1; //###############################


        Editortable_0.GForm_Main_0.method_1("Checking for differences...");

        //Get all Tables values
        double[,] ReadBufferarray = new double[this.BufferTableSize[0], this.BufferTableSize[1]];
        for (int i = 0; i < this.BufferTableSize[0]; i++)   //10columns
        {
            for (int j = 0; j < this.BufferTableSize[1]; j++)   //20rows
            {
                //calculate value inversed to make bytes
                double ThisValue = double.Parse(Editortable_0.dataGridView_0.Rows[j].Cells[i].Value.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                ThisValue = DoMath(ThisValue, BufferMath, true);
                ReadBufferarray[i, j] = (Int16)ThisValue;
            }
        }

        //#############
        double[] ValuesBufferarray = new double[this.SelectedTableSize];
        for (int i = 0; i < this.BufferTableSize[0]; i++)
        {
            for (int j = 0; j < this.BufferTableSize[1]; j++)
            {
                ValuesBufferarray[i * this.BufferTableSize[1] + j] = ReadBufferarray[i, j];
            }
        }
        //#############
        byte[] BytesBufferarray = new byte[this.SelectedTableSize * multiplier];
        for (int i = 0; i < this.SelectedTableSize; i++)
        {
            if (multiplier == 2)
            {
                byte[] ThisBytesToChange = BitConverter.GetBytes((Int16) ValuesBufferarray[i]);
                BytesBufferarray[(i * 2)] = ThisBytesToChange[1];
                BytesBufferarray[(i * 2) + 1] = ThisBytesToChange[0];
            }
            else
            {
                BytesBufferarray[i] = (byte) ValuesBufferarray[i];
            }
        }
        //#############
        byte[] array = new byte[this.SelectedTableSize * multiplier];
        for (int i = 0; i < this.SelectedTableSize * multiplier; i++)
        {
            array[i] = this.byte_0[num + i];
            //Apply Changes
            this.byte_0[num + i] = BytesBufferarray[i];
        }

        int num3 = 0;
        string text = null;
        bool DiffDetected = false;
        foreach (int num4 in BytesBufferarray)
        {
            if (num4.ToString() != array[num3].ToString())
            {
                string BufText = "Change at line: " + num3.ToString() + "[" + array[num3].ToString("X2") + "->" + num4.ToString("X2") + "] | At: 0x" + (this.SelectedROMLocation + num3).ToString("X");
                text = text + BufText + Environment.NewLine;
                Editortable_0.GForm_Main_0.method_1(BufText);
                DiffDetected = true;
            }
            num3++;
        }
        if (!DiffDetected) Editortable_0.GForm_Main_0.method_1("No differences detected");
        this.string_3 = this.string_3 + "Address: " + this.SelectedROMLocation.ToString() + Environment.NewLine + text;
        //this.string_3 = this.string_3 + "Table: " + TableSize + Environment.NewLine + "Address: " + this.SelectedROMLocation.ToString() + Environment.NewLine + text;
    }

    public void SaveROMBytes(string string_4)
    {
        try
        {
            if (this.bool_2 && this.SelectedTableSize != 0 && this.SelectedROMLocation != 0)
            {
                this.GetChanges();
                this.string_2 = this.string_2 + this.string_3 + Environment.NewLine;
            }
            this.bool_2 = false;

            //################################################
            byte[] SavingBytes = this.byte_0;

            //Remove fake bootloader section if it's a partial firmware .bin file
            if (!this.Editortable_0.IsFullBinary)
            {
                byte[] BufferBytes = new byte[SavingBytes.Length - 0x8000];
                for (int i = 0; i < SavingBytes.Length; i++) BufferBytes[i] = SavingBytes[i + 0x8000];

                SavingBytes = BufferBytes;
            }

            //Fix Checksums
            FixChecksums();

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

    public void FixChecksums()
    {
        if (!this.Editortable_0.IsFullBinary) this.byte_0 = this.Editortable_0.GForm_Main_0.VerifyChecksumFWBin(this.byte_0);
        if (this.Editortable_0.IsFullBinary) this.byte_0 = this.Editortable_0.GForm_Main_0.VerifyChecksumFullBin(this.byte_0);

    }

    public void SetTableValues(int[] TableSize, int ROMLocationX, string TopLeftString, string RowHeaderString, string[] HeaderStringList, string ThisMathX, string ThisFormatX, bool IsXYInverted, int ROMLocationTable, string ThisMathTable, string ThisTableFormat, bool IsTableInverted)
    {
        try
        {
            this.SelectedTableSize = TableSize[0] * TableSize[1];
            BufferValuesArray = new int[SelectedTableSize];
            BufferTableSize = TableSize;

            Editortable_0.dataGridView_0.Rows.Clear();
            Editortable_0.dataGridView_0.Columns.Clear();
            Editortable_0.dataGridView_0.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Editortable_0.dataGridView_0.TopLeftHeaderCell.Value = TopLeftString;
            Editortable_0.dataGridView_0.AllowUserToAddRows = false;

            //Correct the Table Orientation if Bad
            /*if ((TableSize[1] == 1 && IsInverted) || (TableSize[0] == 1 && !IsInverted))
            {
                int Buf0 = TableSize[1];
                int Buf1 = TableSize[0];
                TableSize[0] = Buf0;
                TableSize[1] = Buf1;
            }*/

            SelectedROMLocation = ROMLocationTable;
            BufferMath = ThisMathTable;

            //Apply Columns(Y)
            if (IsXYInverted)
            {
                for (int i = 0; i < TableSize[1]; i++)
                {
                    if (ROMLocationX != 0)
                    {
                        double num = 0;
                        if (IsSingleByteX) num = (double)this.GetSingleByteValue(ROMLocationX + i);
                        else num = (double)this.GetIntValue(ROMLocationX + i * 2);

                        string HeaderStr = "";
                        if (ThisFormatX != "") HeaderStr = DoMath(num, ThisMathX, false).ToString(ThisFormatX);
                        if (ThisFormatX == "") HeaderStr = DoMath(num, ThisMathX, false).ToString();
                        Editortable_0.dataGridView_0.Columns.Add(HeaderStr, HeaderStr);
                    }
                    else
                    {
                        Editortable_0.dataGridView_0.Columns.Add(RowHeaderString, RowHeaderString);
                    }
                }
            }
            else
            {
                for (int j = 0; j < TableSize[0]; j++) Editortable_0.dataGridView_0.Columns.Add(HeaderStringList[j], HeaderStringList[j]);
            }

            int index = 0;
            while (true)
            {
                if (index >= SelectedTableSize) // More than TableSize (ex: 10x20.. more than 200)
                {
                    int[,] numArray2 = smethod_35<int>(BufferValuesArray, TableSize[0], TableSize[1]);
                    int rowIndex = 0;
                    while (true)
                    {
                        if ((rowIndex >= TableSize[1] && !IsXYInverted) || (rowIndex >= TableSize[0] && IsXYInverted))   //More than Y (make the 3D table)
                        {
                            int num10 = 0;
                            while (true)
                            {
                                if ((num10 >= TableSize[1] && !IsXYInverted) || (num10 >= TableSize[0] && IsXYInverted))   //Another More than Y (set X Header)
                                {
                                    if (!IsXYInverted) SetBackColor(TableSize[0], Editortable.float_1[0], Editortable.float_1[1]);
                                    if (IsXYInverted) SetBackColor(TableSize[1], Editortable.float_1[0], Editortable.float_1[1]);
                                    break;
                                }
                                //Rows(X) Math
                                if (IsXYInverted)
                                {
                                    string ThisHeaderVal = HeaderStringList[num10];
                                    if (ThisHeaderVal == "") ThisHeaderVal = RowHeaderString;
                                    Editortable_0.dataGridView_0.Rows[num10].HeaderCell.Value = ThisHeaderVal;
                                }
                                else
                                {
                                    if (ROMLocationX != 0)
                                    {
                                        double num = 0;
                                        if (IsSingleByteX) num = (double)this.GetSingleByteValue(ROMLocationX + num10);
                                        else num = (double)this.GetIntValue(ROMLocationX + num10 * 2);
                                        if (ThisFormatX != "") Editortable_0.dataGridView_0.Rows[num10].HeaderCell.Value = DoMath(num, ThisMathX, false).ToString(ThisFormatX);
                                        if (ThisFormatX == "") Editortable_0.dataGridView_0.Rows[num10].HeaderCell.Value = DoMath(num, ThisMathX, false).ToString();
                                    }
                                    else
                                    {
                                        Editortable_0.dataGridView_0.Rows[num10].HeaderCell.Value = RowHeaderString;
                                    }
                                }
                                num10++;
                            }
                            break;
                        }

                        //TableMath (Get full 1full row of value at a time)
                        object[] values = new object[0];
                        if (IsXYInverted)
                        {
                            values = new object[TableSize[1]];
                            for (int i = 0; i < TableSize[1]; i++)
                            {
                                if (ThisTableFormat != "") values[i] = DoMath((double)numArray2[rowIndex, i], ThisMathTable, false).ToString(ThisTableFormat);
                                if (ThisTableFormat == "") values[i] = DoMath((double)numArray2[rowIndex, i], ThisMathTable, false).ToString();
                            }
                        }
                        else
                        {
                            values = new object[TableSize[0]];
                            for (int i = 0; i < TableSize[0]; i++)
                            {
                                if (ThisTableFormat != "") values[i] = DoMath((double)numArray2[i, rowIndex], ThisMathTable, false).ToString(ThisTableFormat);
                                if (ThisTableFormat == "") values[i] = DoMath((double)numArray2[i, rowIndex], ThisMathTable, false).ToString();
                            }
                        }
                        Editortable_0.dataGridView_0.Rows.Insert(rowIndex, values);
                        rowIndex++;
                    }
                    break;
                }

                //Math perfomed just above
                if (IsSingleByteTable) BufferValuesArray[index] = GetSingleByteValue(SelectedROMLocation + index);
                else BufferValuesArray[index] = GetIntValue(SelectedROMLocation + (index * 2));

                index++;
            }

            //##############################################################################################################
            //Invert inner tables values X and Y
            if (IsTableInverted)
            {
                int[,] numArray2 = smethod_35<int>(BufferValuesArray, TableSize[1], TableSize[0]);

                for (int i = 0; i < Editortable_0.dataGridView_0.ColumnCount; i++)
                {
                    for (int i2 = 0; i2 < Editortable_0.dataGridView_0.RowCount; i2++)
                    {
                        string valueinner = "";
                        if (IsXYInverted)
                        {
                            if (ThisTableFormat != "") valueinner = DoMath((double)numArray2[i, i2], ThisMathTable, false).ToString(ThisTableFormat);
                            if (ThisTableFormat == "") valueinner = DoMath((double)numArray2[i, i2], ThisMathTable, false).ToString();
                        }
                        else
                        {
                            if (ThisTableFormat != "") valueinner = DoMath((double)numArray2[i2, i], ThisMathTable, false).ToString(ThisTableFormat);
                            if (ThisTableFormat == "") valueinner = DoMath((double)numArray2[i2, i], ThisMathTable, false).ToString();
                        }

                        Editortable_0.dataGridView_0.Rows[i2].Cells[i].Value = valueinner;
                    }
                }
            }
            //##############################################################################################################

            foreach (object obj in Editortable_0.dataGridView_0.Columns)
            {
                DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
                dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                //dataGridViewColumn.Width = 50;
            }
            foreach (object obj2 in ((IEnumerable)Editortable_0.dataGridView_0.Rows))
            {
                DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
                dataGridViewRow2.Height = 20;
            }
            this.SetBackColor(TableSize[0], Editortable.float_1[0], Editortable.float_1[1]);
            this.bool_0 = true;
        }
        catch (Exception ex)
        {
            this.bool_0 = false;
            DarkMessageBox.Show("Failed to load table. " + ex.ToString());
        }
    }

    private int GetNearestMathIndex(string ThisMath)
    {
        int IndexOfNearest = -1;
        int IndexOfMathDiv = ThisMath.IndexOf('/');
        int IndexOfMathMul = ThisMath.IndexOf('*');
        int IndexOfMathAdd = ThisMath.IndexOf('+');
        //int IndexOfMathSub = ThisMath.IndexOf('-'); //don't check for sub, this is causing issue with negative number

        if (IndexOfMathDiv == 0) return 0;
        if (IndexOfMathMul == 0) return 0;
        if (IndexOfMathAdd == 0) return 0;

        if (IndexOfMathDiv == -1) IndexOfMathDiv = 99;
        if (IndexOfMathMul == -1) IndexOfMathMul = 99;
        if (IndexOfMathAdd == -1) IndexOfMathAdd = 99;

        if (IndexOfMathDiv > 0 && IndexOfMathDiv < IndexOfMathMul && IndexOfMathDiv < IndexOfMathAdd) IndexOfNearest = IndexOfMathDiv;
        if (IndexOfMathMul > 0 && IndexOfMathMul < IndexOfMathDiv && IndexOfMathMul < IndexOfMathAdd) IndexOfNearest = IndexOfMathMul;
        if (IndexOfMathAdd > 0 && IndexOfMathAdd < IndexOfMathMul && IndexOfMathAdd < IndexOfMathDiv) IndexOfNearest = IndexOfMathAdd;

        if (IndexOfNearest == 99) IndexOfNearest = -1;

        return IndexOfNearest;
    }

    private char GetNextMath(string ThisMath)
    {
        int Thisindex = GetNearestMathIndex(ThisMath);
        return ThisMath.Substring(Thisindex, 1)[0];
    }

    private double GetNextValue(string ThisMath)
    {
        double Value = 0;

        int Nearestindex = GetNearestMathIndex(ThisMath);
        if (Nearestindex == 0) ThisMath = ThisMath.Substring(1);

        if (Nearestindex == -1)
        {
            Value = double.Parse(ThisMath.Replace(',', '.'), CultureInfo.InvariantCulture);
        }
        else
        {
            string ThisVarStr = ThisMath.Substring(0, Nearestindex);
            Value = double.Parse(ThisVarStr.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        return Value;
    }

    public string InvertMathString(string ThisMath)
    {
        string ReturnStr = "";
        List<double> ValuesList = new List<double>();
        List<char> MathFuncList = new List<char>();
        bool WeHaveVal1 = false;
        while (ThisMath != "")
        {
            if (!WeHaveVal1) ValuesList.Add(GetNextValue(ThisMath));
            MathFuncList.Add(GetNextMath(ThisMath));
            ThisMath = ThisMath.Substring(GetNearestMathIndex(ThisMath) + 1);
            ValuesList.Add(GetNextValue(ThisMath));

            int NearestIndex = GetNearestMathIndex(ThisMath);
            if (NearestIndex != -1) ThisMath = ThisMath.Substring(GetNearestMathIndex(ThisMath));

            WeHaveVal1 = true;

            if (!ThisMath.Contains("/") && !ThisMath.Contains("*") && !ThisMath.Contains("+"))
            {
                ThisMath = ""; //No remaining maths to perform
            }
        }

        //Create inverted math function
        for (int i = ValuesList.Count - 1; i >= 0; i--)
        {
            ReturnStr = ReturnStr + ValuesList[i];
            if (i > 0)
            {
                if (MathFuncList[i - 1] == '*') ReturnStr = ReturnStr + "/";
                if (MathFuncList[i - 1] == '/') ReturnStr = ReturnStr + "*";
                if (MathFuncList[i - 1] == '+') ReturnStr = ReturnStr + "+-";
            }
        }

        return ReturnStr;
    }


    public double DoMath(double ThisValueCheck, string ThisMath, bool Reverse)
    {
        double ReturnVal = DoMathFinal(ThisValueCheck, ThisMath, Reverse);

        //Confirm Math function in reverse
        if (!Reverse)
        {
            double ReversedVal = DoMathFinal(ReturnVal, ThisMath, true);
            if (((int) ReversedVal).ToString() != ((int) ThisValueCheck).ToString()
                && ((int)ReversedVal + 1).ToString() != ((int)ThisValueCheck).ToString()
                && ((int)ReversedVal - 1).ToString() != ((int)ThisValueCheck).ToString())
            {
                Editortable_0.GForm_Main_0.method_1("Problem with math: " + ThisMath + " | Values: " + ((int)ThisValueCheck).ToString() + " != " + ((int)ReversedVal).ToString());
            }
        }

        return ReturnVal;
    }

    //public double DoMath(double ThisValue, string ThisMath, bool Reverse)
    public double DoMathFinal(double ThisValue, string ThisMath, bool Reverse)
    {
        double ReturnVal = ThisValue;

        //No Math found, return value with no math calculation
        if (ThisMath == "X" || ThisMath == "") return ReturnVal;

        //Put X at the end in reverse
        bool IsDivXValFirst = false;
        if (Reverse)
        {
            if (ThisMath.Contains("X/")) IsDivXValFirst = true;

            if (ThisMath[ThisMath.Length - 1] != 'X')
            {
                string XandMath = ThisMath.Substring(ThisMath.IndexOf('X'), 2);
                ThisMath = ThisMath.Replace(XandMath, "") + XandMath[1].ToString() + XandMath[0].ToString();
            }
        }

        ThisMath = ThisMath.Replace("X", ThisValue.ToString());

        if (Reverse) ThisMath = InvertMathString(ThisMath);

        bool WeHaveVal1 = false;
        double Val1 = 0;
        while (ThisMath != "")
        {
            if (!WeHaveVal1) Val1 = GetNextValue(ThisMath);
            char MathChar = GetNextMath(ThisMath);
            ThisMath = ThisMath.Substring(GetNearestMathIndex(ThisMath) + 1);
            double Val2 = GetNextValue(ThisMath);

            if (MathChar == '*') ReturnVal = Val1 * Val2;
            if (MathChar == '/') ReturnVal = Val1 / Val2;
            if (MathChar == '+') ReturnVal = Val1 + Val2;
            if (MathChar == '-') ReturnVal = Val1 - Val2;

            if (Reverse && MathChar == '*' && !IsDivXValFirst) ReturnVal = Val2 / Val1;

            int NearestIndex = GetNearestMathIndex(ThisMath);
            if (NearestIndex != -1) ThisMath = ThisMath.Substring(GetNearestMathIndex(ThisMath));

            WeHaveVal1 = true;
            Val1 = ReturnVal;

            //Check for remaining maths
            //if (!ThisMath.Contains("/") && !ThisMath.Contains("*") && !ThisMath.Contains("+") && !ThisMath.Contains("-"))
            if (!ThisMath.Contains("/") && !ThisMath.Contains("*") && !ThisMath.Contains("+"))
            {
                ThisMath = ""; //No remaining maths to perform
            }
        }
        return ReturnVal;
    }

    public string[] GetAdvancedHeader(int ValuesCount, int ThisLocation, string ThisMath, string HeaderFormat)
    {
        string[] strArray = new string[ValuesCount];
        for (int i = 0; i < ValuesCount; i++)
        {
            int Valuue = 0;
            if (IsSingleByteY) Valuue = GetSingleByteValue(ThisLocation + i);
            else Valuue = GetIntValue(ThisLocation + (i * 2));

            if (HeaderFormat == "") strArray[i] = DoMath((double) Valuue, ThisMath, false).ToString();
            if (HeaderFormat != "") strArray[i] = DoMath((double) Valuue, ThisMath, false).ToString(HeaderFormat);
        }
        return strArray;
    }

    public byte[] StringToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                            .ToArray();
    }

    /*public Int16 ToInt16BE(byte[] TwoBytes)
    {
        Int16 k0 = BitConverter.ToInt16(TwoBytes, 0);
        Int16 k1 = BitConverter.ToInt16(BitConverter.GetBytes(k0).Reverse().ToArray(), 0);
        return k1;
    }

    public Int32 ToInt32BE(byte[] FourBytes)
    {
        Int32 k0 = BitConverter.ToInt32(FourBytes, 0);
        Int32 k1 = BitConverter.ToInt32(BitConverter.GetBytes(k0).Reverse().ToArray(), 0);
        return k1;
    }*/

    public int HexStringToInt(string hex)
    {
        string ThisStr = hex.Replace("0x", "");
        if (ThisStr.Length == 1 || ThisStr.Length == 3 || ThisStr.Length == 5 || ThisStr.Length == 7)
        {
            ThisStr = "0" + ThisStr;
        }
        byte[] ThisBytes = StringToByteArray(ThisStr);
        Array.Reverse(ThisBytes);

        //Add Empty Bytes
        if (ThisBytes.Length == 3)
        {
            byte[] buffArray = new byte[4];
            buffArray[3] = 0;
            for (int i = 0; i < ThisBytes.Length; i++) buffArray[i] = ThisBytes[i];
            ThisBytes = buffArray;
        }

        if (ThisBytes.Length == 2) return BitConverter.ToUInt16(ThisBytes, 0);
        if (ThisBytes.Length == 4) return BitConverter.ToInt32(ThisBytes, 0);
        //if (ThisBytes.Length == 8) return BitConverter.ToUInt64(ThisBytes, 0);
        return 0;
    }

    public bool LoadROMbytes(string string_4)
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
                this.string_ECU_Name = "";
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
                            this.string_ECU_Name += (char)this.byte_0[i + i2];
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

    public int GetIntValue(int int_232)
    {
        return (int)((short)((int)this.byte_0[int_232] << 8 | (int)this.byte_0[int_232 + 1]));
    }

    public int GetSingleByteValue(int int_232)
    {
        return (int)this.byte_0[int_232];
    }

    public void SetBackColor(int int_232, float float_0, float float_1)
    {
        for (int i = 0; i < int_232; i++)
        {
            foreach (object obj in ((IEnumerable)Editortable_0.dataGridView_0.Rows))
            {
                DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                try
                {
                    float float_2 = float.Parse(dataGridViewRow.Cells[i].Value.ToString());
                    dataGridViewRow.Cells[i].Style.BackColor = this.GetColor(float_2, float_1, float_0);
                }
                catch
                {
                    dataGridViewRow.Cells[i].Style.BackColor = System.Drawing.SystemColors.ControlLight;
                    //dataGridViewRow.Cells[i].Style.BackColor = Color.White;
                }
            }
        }
    }

    public Color GetColor(float float_0, float float_1, float float_2)
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

                                //Buffer        10      x       20
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

    public void LoadSupportedECUDefinitions()
    {
        try
        {
            Ecus_Definitions_Compatible = new List<string>();

            Editortable_0.CheckDefinitionFolderExist();

            string Folderpath = Application.StartupPath + @"\Definitions";
            if (Directory.Exists(Folderpath))
            {
                string[] AllDefinitionFiles = Directory.GetFiles(Folderpath, "*.txt", SearchOption.AllDirectories);

                Editortable_0.GForm_Main_0.method_1("Loading definitions files...");
                foreach (string ThisFilePath in AllDefinitionFiles)
                {
                    string[] AllLines = File.ReadAllLines(ThisFilePath);
                    bool GettingEcuList = true;
                    for (int i = 0; i < AllLines.Length; i++)
                    {
                        string Thisline = AllLines[i];
                        if (Thisline.Contains("ROM Parameters")) GettingEcuList = false; //make sure we are not reading false contents

                        if (Thisline[0] != '#' && Thisline != "")
                        {
                            if (GettingEcuList)
                            {
                                Ecus_Definitions_Compatible.Add(Thisline);
                                Editortable_0.GForm_Main_0.method_1("Definitions found for ecu: " + Thisline);
                            }
                        }

                        if (!GettingEcuList) i = AllLines.Length;
                    }
                }
            }
            else
            {
                DarkMessageBox.Show("Failed to find definitions folder.");
            }
        }
        catch (Exception ex)
        {
            DarkMessageBox.Show("Failed to load definitions. " + ex.ToString());
        }
    }

    public void LoadThisECUDefinitions(string ThisECU)
    {
        try
        {
            Editortable_0.CheckDefinitionFolderExist();

            string Folderpath = Application.StartupPath + @"\Definitions";
            if (Directory.Exists(Folderpath))
            {
                string[] AllDefinitionFiles = Directory.GetFiles(Folderpath, "*.txt", SearchOption.AllDirectories);

                DefinitionsLocationsX = new List<string>();
                DefinitionsLocationsY = new List<string>();
                DefinitionsLocationsTable = new List<string>();
                DefinitionsName = new List<string>();
                DefinitionsUnit1 = new List<string>();
                DefinitionsUnit2 = new List<string>();
                DefinitionsTableSize = new List<string>();
                DefinitionsMathX = new List<string>();
                DefinitionsMathY = new List<string>();
                DefinitionsValueMin = new List<float>();
                DefinitionsValueMax = new List<float>();
                DefinitionsChangeAmount = new List<double>();
                DefinitionsIsSingleByteX = new List<bool>();
                DefinitionsIsSingleByteY = new List<bool>();
                DefinitionsIsSingleByteTable = new List<bool>();
                DefinitionsFormatX = new List<string>();
                DefinitionsHeaders = new List<string>();
                DefinitionsFormatY = new List<string>();
                DefinitionsIsXYInverted = new List<bool>();
                DefinitionsIsTableInverted = new List<bool>();

                Editortable_0.GForm_Main_0.method_1("Loading ECU definitions for: " + ThisECU);
                bool ECUFound = false;
                foreach (string ThisFilePath in AllDefinitionFiles)
                {
                    string[] AllLines = File.ReadAllLines(ThisFilePath);
                    bool GettingEcuList = true;

                    string CurrentLocationX = "";
                    string CurrentLocationY = "";
                    string CurrentLocationTable = "";
                    string CurrentName = "";
                    string CurrentUnit1 = "";
                    string CurrentUnit2 = "";
                    string CurrentTableSize = "";
                    string CurrentMathX = "";
                    string CurrentMathY = "";
                    string CurrentMathTable = "";
                    float CurrentValueMin = 0f;
                    float CurrentValueMax = 255f;
                    double CurrentChangeAmount = 1;
                    bool CurrentIsSingleByteX = false;
                    bool CurrentIsSingleByteY = false;
                    bool CurrentIsSingleByteTable = false;
                    string CurrentFormatX = "";
                    string CurrentFormatY = "";
                    string CurrentFormatTable = "";
                    string CurrentHeaders = "";
                    bool CurrentIsXYInverted = false;
                    bool CurrentIsTableInverted = false;

                    for (int i = 0; i < AllLines.Length; i++)
                    {
                        string Thisline = AllLines[i];
                        if (Thisline.Contains("ROM Parameters")) GettingEcuList = false; //make sure we are not reading false contents

                        if (Thisline.Contains("THIS FILE AS BEEN GENERATED")) DarkMessageBox.Show("This Definitions file as been generated to get the ROM Locations.\nThe ROM Locations can possibly be wrong and\nthe tables can display corrupted values!");

                        //Get supported ecu list from file and check if it's match
                        if (Thisline[0] != '#' && Thisline != "")
                        {
                            if (GettingEcuList && Thisline == ThisECU) ECUFound = true;
                        }

                        if (!GettingEcuList && !ECUFound) i = AllLines.Length;
                        if (!GettingEcuList && ECUFound)
                        {
                            //Get Definitions parameters
                            if (Thisline[0] != '#' && Thisline != "")
                            {
                                //ROMLocation Name Unit1 Unit2 TableSize  Math  ValueMin  ValueMax ChangeAmount IsWord  Format  Headers
                                if (Thisline.Contains(":"))
                                {
                                    string[] Commands = Thisline.Split(':');
                                    if (Commands[0] == "ROMLocationX") CurrentLocationX = Commands[1];
                                    if (Commands[0] == "ROMLocationY") CurrentLocationY = Commands[1];
                                    if (Commands[0] == "ROMLocationTable") CurrentLocationTable = Commands[1];
                                    if (Commands[0] == "Name") CurrentName = Commands[1];
                                    if (Commands[0] == "Unit1") CurrentUnit1 = Commands[1];
                                    if (Commands[0] == "Unit2") CurrentUnit2 = Commands[1];
                                    if (Commands[0] == "TableSize") CurrentTableSize = Commands[1];
                                    if (Commands[0] == "MathX") CurrentMathX = Commands[1];
                                    if (Commands[0] == "MathY") CurrentMathY = Commands[1];
                                    if (Commands[0] == "MathTable") CurrentMathTable = Commands[1];
                                    if (Commands[0] == "ValueMin") CurrentValueMin = (float) double.Parse(Commands[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                                    if (Commands[0] == "ValueMax") CurrentValueMax = (float) double.Parse(Commands[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                                    if (Commands[0] == "ChangeAmount") CurrentChangeAmount = double.Parse(Commands[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                                    if (Commands[0] == "IsSingleByteX") CurrentIsSingleByteX = bool.Parse(Commands[1].ToLower());
                                    if (Commands[0] == "IsSingleByteY") CurrentIsSingleByteY = bool.Parse(Commands[1].ToLower());
                                    if (Commands[0] == "IsSingleByteTable") CurrentIsSingleByteTable = bool.Parse(Commands[1].ToLower());
                                    if (Commands[0] == "FormatX") CurrentFormatX = Commands[1];
                                    if (Commands[0] == "FormatY") CurrentFormatY = Commands[1];
                                    if (Commands[0] == "FormatTable") CurrentFormatTable = Commands[1];
                                    if (Commands[0] == "Headers") CurrentHeaders = Commands[1];
                                    if (Commands[0] == "IsXYInverted") CurrentIsXYInverted = bool.Parse(Commands[1].ToLower());
                                    if (Commands[0] == "IsTableInverted") CurrentIsTableInverted = bool.Parse(Commands[1].ToLower());
                                }
                            }

                            //Insert Definitions
                            //if (Thisline.Contains("######") || Thisline == "")
                            if (Thisline.Contains("######"))
                            {
                                if (CurrentName != "")
                                {
                                    CurrentName = CurrentName.Replace("\\x00b0", "°");
                                    DefinitionsLocationsX.Add(CurrentLocationX);
                                    DefinitionsLocationsY.Add(CurrentLocationY);
                                    DefinitionsLocationsTable.Add(CurrentLocationTable);
                                    DefinitionsName.Add(CurrentName);
                                    DefinitionsUnit1.Add(CurrentUnit1);
                                    DefinitionsUnit2.Add(CurrentUnit2);
                                    DefinitionsTableSize.Add(CurrentTableSize);
                                    DefinitionsMathX.Add(CurrentMathX);
                                    DefinitionsMathY.Add(CurrentMathY);
                                    DefinitionsMathTable.Add(CurrentMathTable);
                                    DefinitionsValueMin.Add(CurrentValueMin);
                                    DefinitionsValueMax.Add(CurrentValueMax);
                                    DefinitionsChangeAmount.Add(CurrentChangeAmount);
                                    DefinitionsIsSingleByteX.Add(CurrentIsSingleByteX);
                                    DefinitionsIsSingleByteY.Add(CurrentIsSingleByteY);
                                    DefinitionsIsSingleByteTable.Add(CurrentIsSingleByteTable);
                                    DefinitionsFormatX.Add(CurrentFormatX);
                                    DefinitionsFormatY.Add(CurrentFormatY);
                                    DefinitionsFormatTable.Add(CurrentFormatTable);
                                    DefinitionsHeaders.Add(CurrentHeaders);
                                    DefinitionsIsXYInverted.Add(CurrentIsXYInverted);
                                    DefinitionsIsTableInverted.Add(CurrentIsTableInverted);

                                    //Reset values to default
                                    CurrentLocationX = "";
                                    CurrentLocationY = "";
                                    CurrentLocationTable = "";
                                    CurrentName = "";
                                    CurrentUnit1 = "";
                                    CurrentUnit2 = "";
                                    CurrentTableSize = "";
                                    CurrentMathX = "";
                                    CurrentMathY = "";
                                    CurrentMathTable = "";
                                    CurrentValueMin = 0f;
                                    CurrentValueMax = 255f;
                                    CurrentChangeAmount = 1f;
                                    CurrentIsSingleByteX = false;
                                    CurrentIsSingleByteY = false;
                                    CurrentIsSingleByteTable = false;
                                    CurrentFormatX = "";
                                    CurrentHeaders = "";
                                    CurrentFormatY = "";
                                    CurrentFormatTable = "";
                                    CurrentIsXYInverted = false;
                                    CurrentIsTableInverted = false;
                                }
                            }
                        }
                    }
                    Editortable_0.GForm_Main_0.method_1("Definitions loaded!");

                    if (ECUFound) return;
                }

                if (!ECUFound) Editortable_0.GForm_Main_0.method_1("Definitions NOT loaded!");
            }
            else
            {
                DarkMessageBox.Show("Failed to find definitions folder.");
            }
        }
        catch (Exception ex)
        {
            DarkMessageBox.Show("Failed to load definitions. " + ex.ToString());
        }
    }

    public int SelectedROMLocation;
    public int SelectedTableSize;
    public bool bool_0 = false;
    public bool bool_1 = false;
    public string string_ECU_Name;
    public byte[] byte_0;
    public string string_2;
    public string string_3;
    public bool bool_2 = false;
    public bool IsSingleByteX = false;
    public bool IsSingleByteY = false;
    public bool IsSingleByteTable = false;

    public int[] BufferValuesArray = new int[200];
    //public byte[] BufferBytesArray = new byte[400];
    public int[] BufferTableSize = new int[2];
    public string BufferMath = "";

    public int[] int_219 = new int[400];
    public int[] int_220 = new int[128];
    public int[] int_221 = new int[30];
    public int[] int_222 = new int[16];
    public int[] int_223 = new int[14];
    public int[] int_224 = new int[12];
    public int[] int_225 = new int[10];
    public int[] int_226 = new int[8];
    public int[] int_231 = new int[2];

    [CompilerGenerated]
    private sealed class Class40
    {
        internal Class40()
        {
        }

        internal void method_0(object object_0)
        {
            this.taskCompletionSource_0.SetResult(null);
        }

        public TaskCompletionSource<object> taskCompletionSource_0;
    }

    //########################################################################################################################################
    //########################################################################################################################################
    //########################################################################################################################################
    //########################################################################################################################################

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

    /*public bool smethod_22(string TableSize)
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
    }*/

    /*public bool smethod_31()
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
    }*/

    /*public void smethod_32()
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
    }*/
}
