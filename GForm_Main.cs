using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using SAE.J2534;


public class GForm_Main : DarkForm
{
    //bool ECU_Unlocked = false;
    bool VehicleConnected = false;
    private DarkButton darkButton_Unlock01;
    private DarkButton darkButton2;
    private OpenFileDialog openFileDialog1;
    byte Unlocking_Mode = 0x41;
    bool WritingBinaryMode = true;  //if false we are in writing firmware mode, this is set later anyway
    private DarkButton darkButton_FlashFW;
    private GForm_Main GForm_Main_0;
    private DarkGroupBox DarkgroupBox1;
    private DarkButton darkButton4;
    private DarkButton darkButton5;
    private DarkButton darkButton6;
    private DarkButton darkButton3;
    public Editortable Editortable_0;
    public string Version = "v1.1.3";
    private DarkTextBox darkTextBoxJ2534Command;
    private DarkLabel darkLabel1;
    private DarkButton darkButtonJ2534Command;
    public Class_DefinitionMaker Class_DefinitionMaker_0;
    private DarkComboBox darkComboBoxUnlockMode;
    private bool BadResponceReceived = false;

    public GForm_Main()
    {

        this.InitializeComponent();

        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;
        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;
        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;

        GForm_Main_0 = this;

        Editortable_0 = new Editortable(ref GForm_Main_0);

        Class_RWD.Load(ref GForm_Main_0);

        this.Text = this.Text + " (" + Version + ")";

        Class_DefinitionMaker_0 = new Class_DefinitionMaker(ref GForm_Main_0);

        darkComboBoxUnlockMode.SelectedIndex = 0;
    }


    private void method_0(string string_3)
    {
        if (this.darkTextBox_0.InvokeRequired)
        {
            GForm_Main.Delegate0 delegate_ = new GForm_Main.Delegate0(this.method_0);
            this.method_22(delegate_, new object[]
            {
                string_3
            });
            return;
        }
        this.darkTextBox_0.Text = string_3;
        //Console.Write(string_3);
    }

    public void method_Log(string string_3)
    {
        this.darkTextBox_0.Text += string_3;
        //Console.Write(string_3);

        //Send to ROM Editor logs
        Editortable_0.method_Log(string_3);
    }


    public void method_1(string string_3)
    {
        try
        {
            //With newline automaticly added
            Console.WriteLine(string_3);
            GForm_Main.Class5 @class = new GForm_Main.Class5();
            @class.gform0_0 = this;
            @class.string_0 = string_3;
            this.darkTextBox_0.BeginInvoke(new MethodInvoker(@class.method_0));

            //Send to ROM Editor logs
            Editortable_0.method_1(string_3);
        }
        catch { }
    }


    private void method_2(object sender, EventArgs e)
    {
        APIInfo[] apilist = APIFactory.GetAPIList();
        APIInfo apiinfo = apilist[0];
        DarkTextBox darkTextBox = this.darkTextBox_0;
        Console.WriteLine(apiinfo.Name);
        Console.WriteLine("Filename:" + apiinfo.Filename);
        Console.WriteLine(apiinfo.Details);
        darkTextBox.Text = darkTextBox.Text + apiinfo.Name + Environment.NewLine;
        darkTextBox.Text = darkTextBox.Text + "Filename:" + apiinfo.Filename + Environment.NewLine;
        darkTextBox.Text = darkTextBox.Text + apiinfo.Details + Environment.NewLine;
    }


    private void method_3(object sender, EventArgs e)
    {
        GForm_J2534Select gform = new GForm_J2534Select();
        if (gform.ShowDialog() == DialogResult.OK)
        {
            GForm_Main.string_0 = gform.APIInfo_0.Filename;
            gform.Dispose();
            darkButton1.Enabled = true;
            darkButton_4.Enabled = true;
            darkButton_0.Enabled = true;
        }
    }

    private void SetCommandText(byte[] CommandArray)
    {
        try
        {
            darkTextBoxJ2534Command.Text = "";
            for (int i = 0; i < CommandArray.Length; i++)
            {
                darkTextBoxJ2534Command.Text = darkTextBoxJ2534Command.Text + CommandArray[i].ToString("X2");
                if (i < CommandArray.Length - 1) darkTextBoxJ2534Command.Text = darkTextBoxJ2534Command.Text + ",";
            }
        }
        catch { }
    }


    private void darkButton1_Click(object sender, EventArgs e)
    {
        //ECU_Unlocked = false;
        this.darkButton_DownloadROM.Enabled = false;
        this.darkButton_Unlock41.Enabled = false;
        this.darkButton_Unlock01.Enabled = false;
        this.darkButton_FlashRom.Enabled = false;
        this.darkButton_FlashFW.Enabled = false;
        this.darkButtonJ2534Command.Enabled = false;
        VehicleConnected = false;

        using (API api = APIFactory.GetAPI(GForm_Main.string_0))
        {
            try
            {
                using (Device device = api.GetDevice(""))
                {
                    using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false))
                    {
                        LoadJ2534Channel(channel);

                        int num2 = 0;
                        byte[] arraySend1 = new byte[]
                        {
                                34,     //0x22  -> Read Data by ID (F190)
                                241,    //0xF1
                                144     //0x90
                        };
                        byte[] Received = SendJ2534Message(channel, arraySend1, 5);
                        if (BadResponceReceived) return;

                        int num4 = GForm_Main.smethod_0(Received, byte_1);
                        if (num4 != -1)
                        {
                            byte[] bytes = new byte[0x10];
                            Array.Copy(Received, 8, bytes, 0, 0x10);
                            this.darkTextBox_1.Text = Encoding.ASCII.GetString(bytes);  //Display VIN number
                            this.method_1("VIN:" + Encoding.ASCII.GetString(bytes));
                            num2 = 1;
                        }
                        //#############################################################
                        //#############################################################
                        arraySend1 = new byte[]
                        {
                                34,     //0x22  -> Read Data by ID (F181)
                                241,    //0xF1
                                129     //0x81
                        };
                        Received = SendJ2534Message(channel, arraySend1, 5);
                        if (BadResponceReceived) return;

                        int num6 = GForm_Main.smethod_0(Received, byte_0);
                        if (num6 != -1)
                        {
                            byte[] bytes = new byte[0x10];
                            Array.Copy(Received, 7, bytes, 0, 0x10);
                            this.darkTextBox_2.Text = Encoding.ASCII.GetString(bytes);   //Display CAL_ID Number
                            this.method_1("ID:" + Encoding.ASCII.GetString(bytes));
                            this.method_1("Vehicle is Online");
                            num2 = 2;
                        }
                        //#############################################################
                        if (num2 == 1)
                        {
                            this.method_1("Vehicle is in recovery mode?");
                            DarkMessageBox.Show(this, "Failed to retrieve vin number, assuming recovery mode, read disabled", "RECOVERY MODE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (num2 != 2)
                        {
                            DarkMessageBox.Show(this, "ECU was not detected.\n\rMake sure you have selected the correct platform and the vehicle is on and your device is plugged in.\n\rProvided you have checked these things. Please send a message to the discord group or the page with your vehicle \n\rDomestic Market, Make, Model,Year,Transmission, and Device you are using to Connect.", "Failed to detect Ecu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            //this.darkButton_Unlock41.Enabled = true;
                            //this.darkButton_Unlock01.Enabled = true;
                            this.darkButtonJ2534Command.Enabled = true;
                            VehicleConnected = true;
                            SetButtons();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DarkMessageBox.Show(this, ex.Message);
            }
        }
        return;
    }

    public void method_4(int int_0)
    {
        this.darkProgressBar_0.Value = int_0;
        this.darkLabel_7.Text = "Reading: " + int_0.ToString() + "%";
        Application.DoEvents();
    }


    public void method_5(int int_0)
    {
        this.darkProgressBar_0.Value = int_0;
        this.darkLabel_7.Text = "Writing: " + int_0.ToString() + "%";
        Application.DoEvents();
    }

    public void ResetProgressBar()
    {
        this.darkProgressBar_0.Value = 0;
        this.darkLabel_7.Text = "Status";
        Application.DoEvents();
    }


    private void method_6(object sender, ProgressChangedEventArgs e)
    {
        string text = e.UserState as string;
        this.darkLabel_8.Text = text;
        this.method_4(e.ProgressPercentage);
    }

    private void method_7_Nothing(object sender, RunWorkerCompletedEventArgs e)
    {
        /*if (!ECU_Unlocked)
        {

            ECU_Unlocked = false;
            this.darkButton_DownloadROM.Enabled = false;
            this.darkButton_FlashRom.Enabled = false;
            this.darkButton_FlashFW.Enabled = false;
            DarkMessageBox.Show("Failed to Unlock ECU, Check Log");
        }
        if (ECU_Unlocked)
        {
            if (Unlocking_Mode == 0x41)
            {
                //Unlock ALL buttons (Read&Writes) for 0x27,0x41 Unlock
                this.darkButton_DownloadROM.Enabled = true;
                this.darkButton_FlashRom.Enabled = true;
                this.darkButton_FlashFW.Enabled = true;
            }
            else
            {
                //Unlock FlashFW button (Write FW ONLY) for 0x27,0x01 Unlock
                this.darkButton_FlashFW.Enabled = true;
            }
        }*/
    }

    private void method_7(object sender, RunWorkerCompletedEventArgs e)
    {
        if (this.byte_7 != null)
        {
            this.method_8(this.byte_7);
        }
    }


    private void method_8(byte[] byte_12)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.RestoreDirectory = true;
        saveFileDialog.Filter = "Honda Rom Dump|*.Bin";
        saveFileDialog.FileName = this.darkTextBox_2.Text;
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        File.WriteAllBytes(saveFileDialog.FileName, byte_12);
        this.method_1("File saved: " + saveFileDialog.FileName);
        DarkMessageBox.Show(this, "Successfully Saved File!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        /*this.darkButton_DownloadROM.Enabled = false;
        this.darkButton_Unlock41.Enabled = false;
        this.darkButton_Unlock01.Enabled = false;
        this.darkButton_FlashRom.Enabled = false;
        this.darkButton_FlashFW.Enabled = false;*/
    }

    private void darkButton2_Click(object sender, EventArgs e)
    {
        /*if (GForm_Main.string_0.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                return;
            }
            GForm_Main.string_0 = gform.APIInfo_0.Filename;
            gform.Dispose();
        }

        this.Unlocking_Mode = 0x41;

        this.backgroundWorker_1 = new BackgroundWorker();
        this.backgroundWorker_1.WorkerReportsProgress = true;
        this.backgroundWorker_1.DoWork += this.method_UnlockECU;
        this.backgroundWorker_1.ProgressChanged += this.method_6;
        this.backgroundWorker_1.RunWorkerCompleted += this.method_7_Nothing;
        this.backgroundWorker_1.RunWorkerAsync();*/
    }

    private void darkButton_Unlock01_Click(object sender, EventArgs e)
    {
        /*if (GForm_Main.string_0.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                return;
            }
            GForm_Main.string_0 = gform.APIInfo_0.Filename;
            gform.Dispose();
        }

        this.Unlocking_Mode = 0x01;

        this.backgroundWorker_1 = new BackgroundWorker();
        this.backgroundWorker_1.WorkerReportsProgress = true;
        this.backgroundWorker_1.DoWork += this.method_UnlockECU;
        this.backgroundWorker_1.ProgressChanged += this.method_6;
        this.backgroundWorker_1.RunWorkerCompleted += this.method_7_Nothing;
        this.backgroundWorker_1.RunWorkerAsync();*/
    }

    public void method_UnlockECU(object sender, DoWorkEventArgs e)
    {
        //ECU_Unlocked = false;

        /*using (API api = APIFactory.GetAPI(GForm_Main.string_0))
        {
            try
            {
                using (Device device = api.GetDevice(""))
                {
                    using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false))
                    {
                        LoadJ2534Channel(channel);

                        device.SetProgrammingVoltage(Pin.PIN_12, 5000);
                        //################################################################
                        //Unlocking ECU before performing any actions
                        byte[] arraySend1 = new byte[] {0x10, 0x03};
                        byte[] Received = SendJ2534Message(channel, arraySend1, 3);
                        if (BadResponceReceived) return;
                        if (Received != null) this.method_1("Diag Mode Set");
                        //################################################################
                        byte SeedSendByte = this.Unlocking_Mode;
                        arraySend1 = new byte[] {0x27, SeedSendByte};
                        this.method_1("Requesting Seed");
                        Received = SendJ2534Message(channel, arraySend1, 3);
                        if (BadResponceReceived) return;
                        //################################################################
                        byte[] byte_ = new byte[] {0x67, SeedSendByte};
                        byte[] array6 = new byte[4];
                        bool TwoBytesMode = false;
                        byte b = 1;
                        //################################################################
                        if (Received != null)
                        {
                            int num = GForm_Main.smethod_2(Received, byte_, 0);
                            if (num > 0)
                            {
                                if (Received.Length < 10)
                                {
                                    array6 = new byte[2];
                                    TwoBytesMode = true;
                                }
                                int index = 0;
                                while (true)
                                {
                                    if ((!TwoBytesMode && index >= 4) || (TwoBytesMode && index >= 2))
                                    {
                                        if (!TwoBytesMode)
                                        {
                                            b = Received[(index + num) + 2];
                                            Array.Reverse(array6);
                                        }
                                        this.method_1("Security Request - Seed Bytes:" + GForm_Main.smethod_1(array6));
                                        if (!TwoBytesMode) this.method_1("Security Request - Algorithm:" + b.ToString("X2"));
                                        break;
                                    }
                                    array6[index] = Received[(index + num) + 2];
                                    index++;
                                }
                            }
                        }
                        //################################################################
                        if (array6[0] != 0)
                        {
                            uint value = 0;
                            if (!TwoBytesMode) value = Class_Cypher.GetKey41(BitConverter.ToUInt32(array6, 0), b);
                            else value = Class_Cypher.GetKey01(array6, darkTextBox_2.Text);

                            byte[] bytes = BitConverter.GetBytes(value);
                            this.method_1("Security Request - Key to Send:" + GForm_Main.smethod_1(bytes));

                            arraySend1 = new byte[] { 0x27, (byte)(SeedSendByte + 1) };
                            byte[] array8 = new byte[arraySend1.Length + 5];
                            if (TwoBytesMode) array8 = new byte[arraySend1.Length + 2];
                            for (int i = 0; i < arraySend1.Length; i++) array8[i] = arraySend1[i];
                            array8[2] = bytes[0];  //SecurityKey Byte1
                            array8[3] = bytes[1];  //SecurityKey Byte2
                            if (!TwoBytesMode)
                            {
                                array8[2] = bytes[2];  //SecurityKey Byte3
                                array8[3] = bytes[3];  //SecurityKey Byte4
                                array8[4] = b;         //Algorithm Byte
                            }
                            byte[] byte_2 = new byte[] { 0x67, (byte)(SeedSendByte + 1)};
                            Received = SendJ2534Message(channel, array8, 3);
                            if (BadResponceReceived) return;

                            if (Received != null)
                            {
                                int num = GForm_Main.smethod_2(Received, byte_2, 0);       //looking for 0x67, 0x42
                                if (num > 0)
                                {
                                    this.method_1("Security Authorized: ECU Unlocked");
                                    //ECU_Unlocked = true;
                                }
                                else
                                {
                                    this.method_1("Recv:" + GForm_Main.smethod_1(Received));
                                    //ECU_Unlocked = false;
                                }
                            }
                        }
                        else
                        {
                            this.method_1("Result NOT OK!!");
                        }
                        //################################################################
                    }
                }
            }
            catch (Exception ex)
            {
                DarkMessageBox.Show(ex.Message);
            }
        }*/
    }

    public byte[] SendJ2534Message(Channel channel, byte[] MessageBytes, int receivelenght)
    {
        BadResponceReceived = false;

        byte[] arrayCommand = new byte[]
        {
            0x18,
            0xDA,
            GForm_Main.byte_3,  //-> 0x10|0x11
            0xF1
        };

        SetCommandText(MessageBytes);

        //Add the rest of the messages bytes to the final array
        byte[] arrayCommandFinal = new byte[arrayCommand.Length + MessageBytes.Length];
        int MessageIndex = 0;
        for (int i = 0; i < arrayCommand.Length; i++)
        {
            arrayCommandFinal[MessageIndex] = arrayCommand[i];
            MessageIndex++;
        }
        for (int i = 0; i < MessageBytes.Length; i++)
        {
            arrayCommandFinal[MessageIndex] = MessageBytes[i];
            MessageIndex++;
        }

        //Send message
        SAE.J2534.Message messageCommands = new SAE.J2534.Message(arrayCommandFinal, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
        channel.SendMessage(messageCommands);
        this.method_1("Send:" + GForm_Main.smethod_1(messageCommands.Data));

        //Receive message
        bool SendPendingResp = false;
        int RetryCount = 0;
        int RetryMaxCount = (10 * 1000) / 5;   //->Max ~10sec for responce pending, each try take 5ms
        while (true)
        {
            Console.WriteLine("Trying..");
            if (RetryCount >= RetryMaxCount)
            {
                this.method_1("Timeout waiting for response");
                BadResponceReceived = true;
                break;
            }

            //ISSUE HERE, CAUSED ONE BRICKED ECU

            GetMessageResults messagesReceived = channel.GetMessages(receivelenght, 1000);  //may edit receivelenght when RetryCount > 0
            if (messagesReceived.Result.IsOK())
            {
                int IndexReceived = 1;
                foreach (SAE.J2534.Message message3 in messagesReceived.Messages)
                {
                    //Gather Negative Responce
                    int num2 = GForm_Main.smethod_2(message3.Data, this.byte_5, 0); //looking for 0x11, 0x7F
                    if (num2 > 0)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            this.byte_6[k] = message3.Data[k + num2 + 2];   //0x27, 0x35
                        }
                        Class_ODB.Mode mode = (Class_ODB.Mode)this.byte_6[0];
                        string str2 = mode.ToString();
                        Class_ODB.NegativeResponse negativeResponse = (Class_ODB.NegativeResponse)this.byte_6[1];

                        // wait for another message if response pending
                        if (this.byte_6[1] == 0x78)
                        {
                            if (!SendPendingResp) this.method_1("Response pending...");
                            SendPendingResp = true;
                            receivelenght = 1;
                            Thread.Sleep(5);
                            RetryCount++;
                            continue;
                        }
                        else
                        {
                            this.method_1("BAD Response: " + str2 + "|" + negativeResponse.ToString());
                            BadResponceReceived = true;
                            break;
                        }
                    }
                    if (IndexReceived >= receivelenght)
                    {
                        this.method_1("Recv:" + GForm_Main.smethod_1(message3.Data));
                        return message3.Data;
                    }
                    IndexReceived++;
                }
            }
            else
            {
                if (SendPendingResp)
                {
                    Thread.Sleep(5);
                    RetryCount++;
                    continue;
                }
                else
                {
                    this.method_1("Result NOT OK!!");
                    BadResponceReceived = true;
                    break;
                }
            }
            //break;
        }
        return null;
    }

    public void method_ReadROM(object sender, DoWorkEventArgs e)
    {
        using (API api = APIFactory.GetAPI(GForm_Main.string_0))
        {
            try
            {
                using (Device device = api.GetDevice(""))
                {
                    using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false))
                    {
                        LoadJ2534Channel(channel);

                        bool ECU_Unlocked = false;

                        device.SetProgrammingVoltage(Pin.PIN_12, 5000);
                        //################################################################
                        //Unlocking ECU before performing any actions
                        byte[] arraySend1 = new byte[] { 0x10, 0x03 };
                        byte[] Received = SendJ2534Message(channel, arraySend1, 3);
                        if (BadResponceReceived) return;
                        if (Received != null) this.method_1("Diag Mode Set");
                        //################################################################
                        byte SeedSendByte = this.Unlocking_Mode;
                        arraySend1 = new byte[] { 0x27, SeedSendByte };
                        this.method_1("Requesting Seed");
                        Received = SendJ2534Message(channel, arraySend1, 3);
                        if (BadResponceReceived) return;
                        //################################################################
                        byte[] byte_ = new byte[] { 0x67, SeedSendByte };
                        byte[] array6 = new byte[4];
                        bool TwoBytesMode = false;
                        byte b = 1;
                        //################################################################
                        if (Received != null)
                        {
                            int num = GForm_Main.smethod_2(Received, byte_, 0);
                            if (num > 0)
                            {
                                if (Received.Length < 10)
                                {
                                    array6 = new byte[2];
                                    TwoBytesMode = true;
                                }
                                int index = 0;
                                while (true)
                                {
                                    if ((!TwoBytesMode && index >= 4) || (TwoBytesMode && index >= 2))
                                    {
                                        if (!TwoBytesMode)
                                        {
                                            b = Received[(index + num) + 2];
                                            Array.Reverse(array6);
                                        }
                                        this.method_1("Security Request - Seed Bytes:" + GForm_Main.smethod_1(array6));
                                        if (!TwoBytesMode) this.method_1("Security Request - Algorithm:" + b.ToString("X2"));
                                        break;
                                    }
                                    array6[index] = Received[(index + num) + 2];
                                    index++;
                                }
                            }
                        }
                        //################################################################
                        if (array6[0] != 0)
                        {
                            uint value = 0;
                            if (!TwoBytesMode) value = Class_Cypher.GetKey41(BitConverter.ToUInt32(array6, 0), b);
                            else value = Class_Cypher.GetKey01(array6, darkTextBox_2.Text);

                            byte[] bytes = BitConverter.GetBytes(value);
                            this.method_1("Security Request - Key to Send:" + GForm_Main.smethod_1(bytes));

                            arraySend1 = new byte[] { 0x27, (byte)(SeedSendByte + 1) };
                            byte[] array8 = new byte[arraySend1.Length + 5];
                            if (TwoBytesMode) array8 = new byte[arraySend1.Length + 2];
                            for (int i = 0; i < arraySend1.Length; i++) array8[i] = arraySend1[i];
                            array8[2] = bytes[0];  //SecurityKey Byte1
                            array8[3] = bytes[1];  //SecurityKey Byte2
                            if (!TwoBytesMode)
                            {
                                array8[2] = bytes[2];  //SecurityKey Byte3
                                array8[3] = bytes[3];  //SecurityKey Byte4
                                array8[4] = b;         //Algorithm Byte
                            }
                            byte[] byte_2 = new byte[] { 0x67, (byte)(SeedSendByte + 1) };
                            Received = SendJ2534Message(channel, array8, 3);
                            if (BadResponceReceived) return;

                            if (Received != null)
                            {
                                int num = GForm_Main.smethod_2(Received, byte_2, 0);       //looking for 0x67, 0x42
                                if (num > 0)
                                {
                                    this.method_1("Security Authorized: ECU Unlocked");
                                    ECU_Unlocked = true;
                                }
                                else
                                {
                                    this.method_1("Recv:" + GForm_Main.smethod_1(Received));
                                }
                            }
                        }
                        else
                        {
                            this.method_1("Result NOT OK!!");
                        }
                        //################################################################


                        if (!ECU_Unlocked)
                        {
                            this.method_1("ECU is NOT Unlocked!");
                            return;
                        }
                        else
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            this.byte_7 = this.method_10(channel, this.backgroundWorker_1);
                            stopwatch.Stop();
                            TimeSpan timeSpan = TimeSpan.FromMilliseconds((double)stopwatch.ElapsedMilliseconds);
                            this.backgroundWorker_1.ReportProgress(0, "Successfully read " + this.byte_7.Length + "bytes of flash memory in " + timeSpan.Minutes + ":" + timeSpan.Seconds);
                            device.SetProgrammingVoltage(Pin.PIN_12, -1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DarkMessageBox.Show(ex.Message);
            }
        }
    }


    public static int smethod_0(byte[] byte_12, byte[] byte_13)
    {
        if (byte_12 == null) return -1;
        if (byte_13.Length > byte_12.Length)
        {
            return -1;
        }
        for (int i = 0; i < byte_12.Length - byte_13.Length; i++)
        {
            bool flag = true;
            for (int j = 0; j < byte_13.Length; j++)
            {
                if (byte_12[i + j] != byte_13[j])
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                return i;
            }
        }
        return -1;
    }


    public static string smethod_1(byte[] byte_12)
    {
        StringBuilder stringBuilder = new StringBuilder(byte_12.Length * 2);
        foreach (byte b in byte_12)
        {
            stringBuilder.Append("0x");
            stringBuilder.AppendFormat("{0:X2} ", b);
        }
        return stringBuilder.ToString();
    }


    private static int smethod_2(byte[] byte_12, byte[] byte_13, int int_0 = 0)
    {
        int num = byte_12.Length - byte_13.Length;
        byte b = byte_13[0];    //0x67 || 0x11
        while (int_0 <= num)
        {
            if (byte_12[int_0] == b)
            {
                for (int num2 = 1; num2 != byte_13.Length; num2++)
                {
                    if (byte_12[int_0 + num2] != byte_13[num2])     //0x42 || 0x7F
                    {
                        goto IL_32;
                    }
                }
                return int_0;
            }
        IL_32:
            int_0++;
        }
        return -1;
    }


    public byte[] method_10(Channel channel_0, BackgroundWorker backgroundWorker_1 = null)
    {
        GForm_Main.Class6 @class = new GForm_Main.Class6();
        @class.gform0_0 = this;
        @class.byte_0 = new byte[1];
        DateTime now = DateTime.Now;
        @class.uint_0 = 4U;
        this.darkTextBox_0.BeginInvoke(new MethodInvoker(@class.method_0));
        GForm_Main.Class7 class2 = new GForm_Main.Class7();
        class2.class6_0 = @class;
        class2.uint_0 = 0U;
        while ((ulong)class2.uint_0 <= (ulong)((long)GForm_Main.class9_0.ReadingSize))
        {
            Application.DoEvents();
            TimeSpan timeSpan = TimeSpan.FromTicks(DateTime.Now.Subtract(now).Ticks * ((long)GForm_Main.class9_0.ReadingSize - (long)((ulong)(class2.uint_0 + 1U))) / (long)((ulong)(class2.uint_0 + 1U)));
            this.method_12(class2.uint_0, class2.class6_0.uint_0, out class2.class6_0.byte_0, channel_0);
            //string userState = "Time Remaining:" + string.Format("{0:mm:ss}", timeSpan);
            string userState = "Time Remaining:" + string.Format("{0:mm\\:ss}", timeSpan);
            this.method_11((long)((ulong)class2.uint_0));
            if ((long)class2.class6_0.byte_0.Length != (long)((ulong)class2.class6_0.uint_0))
            {
                Control control = this.darkTextBox_0;
                MethodInvoker method;
                if ((method = class2.class6_0.methodInvoker_0) == null)
                {
                    method = (class2.class6_0.methodInvoker_0 = new MethodInvoker(class2.class6_0.method_1));
                }
                control.BeginInvoke(method);
            }
            try
            {
                Buffer.BlockCopy(class2.class6_0.byte_0, 0, this.byte_7, (int)class2.uint_0, class2.class6_0.byte_0.Length);
                goto IL_213;
            }
            catch
            {
                this.darkTextBox_0.BeginInvoke(new MethodInvoker(class2.method_0));
                goto IL_213;
            }
            goto IL_1B4;
        IL_1CD:
            if (backgroundWorker_1 != null)
            {
                backgroundWorker_1.ReportProgress((int)(class2.uint_0 / (float)GForm_Main.class9_0.ReadingSize * 100f), userState);
            }
            class2.uint_0 += class2.class6_0.uint_0;
            continue;
        IL_1B4:
            this.darkTextBox_0.BeginInvoke(new MethodInvoker(class2.method_1));
            goto IL_1CD;
        IL_213:
            if (class2.uint_0 % 256U == 0U)
            {
                goto IL_1B4;
            }
            goto IL_1CD;
        }
        return this.byte_7;
    }


    private void method_11(long long_1)
    {
        GForm_Main.Class8 @class = new GForm_Main.Class8();
        @class.gform0_0 = this;
        if (this.long_0 != 0L)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = now - this.dateTime_0;
            long num = long_1 - this.long_0;
            @class.double_0 = (double)num / timeSpan.TotalSeconds;
            this.long_0 = long_1;
            this.dateTime_0 = now;
            this.darkLabel_5.BeginInvoke(new MethodInvoker(@class.method_0));
            return;
        }
        this.dateTime_0 = DateTime.Now;
        this.long_0 = long_1;
    }


    public void method_12(uint uint_0, uint uint_1, out byte[] byte_12, Channel channel_0)
    {
        byte_12 = new byte[1];

        byte[] arraySend1 = new byte[]
        {
            35,     //0x23 -> Read_data_by_address
            20,     //0x14
            (byte)((uint_0 >> 0x18) & 0xff),
            (byte)((uint_0 >> 0x10) & 0xff),
            (byte)((uint_0 >> 8) & 0xff),
            (byte)(uint_0 & 0xff),
            4
        };
        byte[] byte_13 = new byte[]
        {
            GForm_Main.byte_3,
            99
        };

        byte[] Received = SendJ2534Message(channel_0, arraySend1, 3);
        if (BadResponceReceived) return;

        if (Received != null)
        {
        //if (messages.Result != ResultCode.DEVICE_NOT_CONNECTED)
        //{
            int num = GForm_Main.smethod_2(Received, byte_13, 0);
            if (num > 0)
            {
                num += 2;
                Array.Resize<byte>(ref byte_12, Received.Length - num);
                Array.Copy(Received, num, byte_12, 0, Received.Length - num);
            }
        }
    }


    private void method_13(object sender, EventArgs e)
    {
        if (GForm_Main.string_0.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                return;
            }
            GForm_Main.string_0 = gform.APIInfo_0.Filename;
            gform.Dispose();
        }

        SetUnlockingMode();

        this.backgroundWorker_0 = new BackgroundWorker();
        this.backgroundWorker_0.WorkerReportsProgress = true;
        this.backgroundWorker_0.DoWork += this.method_ReadROM;
        this.backgroundWorker_0.ProgressChanged += this.method_6;
        this.backgroundWorker_0.RunWorkerCompleted += this.method_7;
        this.backgroundWorker_0.RunWorkerAsync();
    }


    private void method_14(object sender, EventArgs e)
    {
        using (API api = APIFactory.GetAPI(GForm_Main.string_0))
        {
            using (Device device = api.GetDevice(""))
            {
                using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false))
                {
                    MessageFilter messageFilter = new MessageFilter();
                    messageFilter.FilterType = Filter.FLOW_CONTROL_FILTER;
                    messageFilter.Mask = new byte[]
                    {
                        byte.MaxValue,
                        byte.MaxValue,
                        byte.MaxValue,
                        byte.MaxValue
                    };
                    messageFilter.Pattern = new byte[]
                    {
                        0,
                        0,
                        126,
                        8
                    };
                    MessageFilter messageFilter2 = messageFilter;
                    byte[] array = new byte[4];
                    array[2] = 126;
                    messageFilter2.FlowControl = array;
                    MessageFilter filter = messageFilter;
                    channel.StartMsgFilter(filter);
                    SConfig[] config = new SConfig[]
                    {
                        new SConfig(Parameter.LOOP_BACK, 1),
                        new SConfig(Parameter.DATA_RATE, 500000)
                    };
                    channel.SetConfig(config);
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    this.byte_7 = this.method_15(channel, this.backgroundWorker_1);
                    stopwatch.Stop();
                    TimeSpan.FromMilliseconds((double)stopwatch.ElapsedMilliseconds);
                    DarkTextBox darkTextBox = this.darkTextBox_0;
                    darkTextBox.Text = darkTextBox.Text + GForm_Main.smethod_1(this.byte_7) + Environment.NewLine;
                }
            }
        }
    }


    public byte[] method_15(Channel channel_0, BackgroundWorker backgroundWorker_1 = null)
    {
        byte[] array = new byte[4];
        byte[] array2 = new byte[1];
        uint num = uint.Parse(this.darkTextBox_4.Text);
        uint uint_ = uint.Parse(this.darkTextBox_3.Text, NumberStyles.HexNumber);
        this.method_12(uint_, num, out array2, channel_0);
        if ((long)array2.Length == (long)((ulong)num))
        {
            Buffer.BlockCopy(array2, 0, array, 0, array2.Length);
        }
        return array;
    }


    private void method_16(object sender, EventArgs e)
    {
        if (GForm_Main.string_0 == string.Empty)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                return;
            }
            GForm_Main.string_0 = gform.APIInfo_0.Filename;
            gform.Dispose();
        }
        try
        {
            using (API api = APIFactory.GetAPI(GForm_Main.string_0))
            {
                using (Device device = api.GetDevice(""))
                {
                    using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.SNIFF_MODE, false))
                    {
                        List<byte[]> list = new List<byte[]>();
                        GetMessageResults messages = channel.GetMessages(10000);
                        if (messages.Result != ResultCode.DEVICE_NOT_CONNECTED)
                        {
                            foreach (SAE.J2534.Message message in messages.Messages)
                            {
                                list.Add(message.Data);
                            }
                        }
                        if (list.Count<byte[]>() > 0)
                        {
                            for (int j = 0; j < list.Count<byte[]>(); j++)
                            {
                                this.darkTextBox_0.AppendText(string.Format("message[{0}]: ", j) + GForm_Main.smethod_1(list[j]) + Environment.NewLine);
                            }
                        }
                    }
                }
            }
        }
        catch
        {
        }
    }

    public byte GetNegativeChecksumFullBin(byte[] byte_1)
    {
        byte b = 0;
        for (int i = 0; i < byte_1.Length; i++)
        {
            if (i != 0x8400)
            {
                b -= byte_1[i];
            }
        }
        return b;
    }

    public byte GetNegativeChecksumArea(byte[] byte_1, int Start, int ChecksumLocation)
    {
        byte b = 0;
        for (int i = Start; i < byte_1.Length; i++)
        {
            if (i != ChecksumLocation)
            {
                b -= byte_1[i];
            }
        }
        return b;
    }

    public byte[] VerifyChecksumFullBin(byte[] BinFileBytes)
    {
        //###############################
        //Get Checksum and Fix it for 0x8400
        byte[] BufferBytes = BinFileBytes;
        int CheckLocation = 0x8400;
        byte num = BufferBytes[CheckLocation];
        byte num2 = GetNegativeChecksumArea(BufferBytes, 0, CheckLocation);
        //byte num2 = this.GetNegativeChecksumFullBin(BufferBytes);
        if (num != num2)
        {
            this.method_1("Checksum miss match.");
            BufferBytes[0x8400] = num2;
            this.method_1("Checksum fixed at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }
        else
        {
            this.method_1("Checksum are good at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }
        //########################################################
        //########################################################
        //Verify for 0x10400
        /*CheckLocation = 0x10400;
        num = BufferBytes[CheckLocation];
        num2 = GetNegativeChecksumArea(BufferBytes, 0x8000, CheckLocation);
        if (num != num2)
        {
            this.method_1("Checksum miss match.");
            BufferBytes[CheckLocation] = num2;
            this.method_1("Checksum fixed at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }
        else
        {
            this.method_1("Checksum are good at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }*/
        //########################################################
        //########################################################
        return BufferBytes;
    }

    public byte[] VerifyChecksumFWBin(byte[] FWFileBytes)
    {
        //###############################
        //Get Checksum and Fix it at 0x400 (0x8400 in full bin)
        byte[] BufferBytes = FWFileBytes;

        byte num = Class_RWD.BootloaderSum;
        byte num2 = Class_RWD.GetNegativeChecksumFWBin(BufferBytes);
        byte ThisSum = num;
        ThisSum -= num2;
        int CheckLocation = 0x400;
        byte chk = BufferBytes[CheckLocation];
        if (chk != ThisSum)
        {
            this.method_1("Checksum miss match.");
            BufferBytes[0x400] = ThisSum;
            this.method_1("Checksum fixed at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }
        else 
        {
            GForm_Main_0.method_1("checksum good at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }
        //########################################################
        //########################################################
        //Verify for 0x8400 (0x10400 in full bin)
        /*CheckLocation = 0x8400;
        num = BufferBytes[CheckLocation];
        num2 = GetNegativeChecksumArea(BufferBytes, 0, CheckLocation);
        if (num != num2)
        {
            this.method_1("Checksum miss match.");
            BufferBytes[CheckLocation] = num2;
            this.method_1("Checksum fixed at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }
        else
        {
            this.method_1("Checksum are good at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }*/
        //########################################################
        //########################################################
        return BufferBytes;
    }


    private void method_17(object sender, EventArgs e)
    {
        if (GForm_Main.string_0.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                return;
            }
            GForm_Main.string_0 = gform.APIInfo_0.Filename;
            gform.Dispose();
        }

        SetUnlockingMode();

        using (OpenFileDialog dialog = new OpenFileDialog())
        {
            dialog.Filter = "Honda Binary ROM File|*.bin";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string string_Filename = dialog.FileName;
                byte_ToWrite = File.ReadAllBytes(string_Filename);
                WritingBinaryMode = true;

                //###############################
                //Get/Fix Checksums
                byte_ToWrite = VerifyChecksumFullBin(byte_ToWrite);

                if (MessageBox.Show("Are you sure you want to write this file to ECU?", "Flash Tool", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.backgroundWorker_0 = new BackgroundWorker();
                    this.backgroundWorker_0.WorkerReportsProgress = true;
                    this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork_1);
                    this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.method_18);
                    this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_19);
                    this.backgroundWorker_0.RunWorkerAsync();
                }
            }
        }
    }

    private void SetUnlockingMode()
    {
        if (darkComboBoxUnlockMode.SelectedIndex == 0) Unlocking_Mode = 0x01;
        if (darkComboBoxUnlockMode.SelectedIndex == 1) Unlocking_Mode = 0x03;
        if (darkComboBoxUnlockMode.SelectedIndex == 2) Unlocking_Mode = 0x05;
        if (darkComboBoxUnlockMode.SelectedIndex == 3) Unlocking_Mode = 0x41;
    }


    private void darkButton3_Click(object sender, EventArgs e)
    {
        if (GForm_Main.string_0.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                return;
            }
            GForm_Main.string_0 = gform.APIInfo_0.Filename;
            gform.Dispose();
        }

        SetUnlockingMode();

        using (OpenFileDialog dialog = new OpenFileDialog())
        {
            dialog.Filter = "Honda Compressed Firmware RWD File|*.gz;*.rwd";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string string_Filename = dialog.FileName;
                if (Path.GetExtension(string_Filename).ToLower().Contains("gz")) byte_ToWrite = Class_RWD.Decompress(string_Filename);
                else byte_ToWrite = File.ReadAllBytes(string_Filename);
                WritingBinaryMode = false;

                //Decrypt firmware file and get needed variable (Decryption byte)
                Class_RWD.LoadRWD(dialog.FileName, false, false);

                //###############################
                //Get Checksum and Fix it -> checksums of rwd files should mostly always be fixed, no need to fix them!
                //###############################

                if (MessageBox.Show("Are you sure you want to write this file to ECU?", "Flash Tool", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.backgroundWorker_0 = new BackgroundWorker();
                    this.backgroundWorker_0.WorkerReportsProgress = true;
                    this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork_1);
                    this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.method_18);
                    this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_19);
                    this.backgroundWorker_0.RunWorkerAsync();
                }
            }
        }
    }

    private Channel LoadJ2534Channel(Channel channel)
    {
        MessageFilter messageFilter = new MessageFilter();
        messageFilter.FilterType = Filter.FLOW_CONTROL_FILTER;
        messageFilter.Mask = new byte[]
        {
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue,
            byte.MaxValue
        };
        messageFilter.Pattern = new byte[]
        {
            24,     //0x18
            218,    //0xDA
            241,    //0xF1
            GForm_Main.byte_3       //0x00
        };
        messageFilter.FlowControl = new byte[]
        {
            24,     //0x18
            218,    //0xDA
            GForm_Main.byte_3,      //0x00  -> 0x10|0x11
            241     //0xF1
        };
        MessageFilter filter = messageFilter;
        channel.StartMsgFilter(filter);
        SConfig[] config = new SConfig[]
        {
            new SConfig(Parameter.LOOP_BACK, 1),
            new SConfig(Parameter.DATA_RATE, 500000)
        };
        channel.SetConfig(config);

        return channel;
    }

    private void backgroundWorker_0_DoWork_1(object sender, DoWorkEventArgs e)
    {
        using (API api = APIFactory.GetAPI(GForm_Main.string_0))
        {
            try
            {
                using (Device device = api.GetDevice(""))
                {
                    using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false))
                    {
                        LoadJ2534Channel(channel);

                        bool ECU_Unlocked = false;

                        device.SetProgrammingVoltage(Pin.PIN_12, 5000);
                        //################################################################
                        //Unlocking ECU before performing any actions
                        byte[] arraySend1 = new byte[] { 0x10, 0x03 };
                        byte[] Received = SendJ2534Message(channel, arraySend1, 3);
                        if (BadResponceReceived) return;
                        if (Received != null) this.method_1("Diag Mode Set");
                        //################################################################
                        byte SeedSendByte = this.Unlocking_Mode;
                        arraySend1 = new byte[] { 0x27, SeedSendByte };
                        this.method_1("Requesting Seed");
                        Received = SendJ2534Message(channel, arraySend1, 3);
                        if (BadResponceReceived) return;
                        //################################################################
                        byte[] byte_ = new byte[] { 0x67, SeedSendByte };
                        byte[] array6 = new byte[4];
                        bool TwoBytesMode = false;
                        byte b = 1;
                        //################################################################
                        if (Received != null)
                        {
                            int num = GForm_Main.smethod_2(Received, byte_, 0);
                            if (num > 0)
                            {
                                if (Received.Length < 10)
                                {
                                    array6 = new byte[2];
                                    TwoBytesMode = true;
                                }
                                int index = 0;
                                while (true)
                                {
                                    if ((!TwoBytesMode && index >= 4) || (TwoBytesMode && index >= 2))
                                    {
                                        if (!TwoBytesMode)
                                        {
                                            b = Received[(index + num) + 2];
                                            Array.Reverse(array6);
                                        }
                                        this.method_1("Security Request - Seed Bytes:" + GForm_Main.smethod_1(array6));
                                        if (!TwoBytesMode) this.method_1("Security Request - Algorithm:" + b.ToString("X2"));
                                        break;
                                    }
                                    array6[index] = Received[(index + num) + 2];
                                    index++;
                                }
                            }
                        }
                        //################################################################
                        if (array6[0] != 0)
                        {
                            uint value = 0;
                            if (!TwoBytesMode) value = Class_Cypher.GetKey41(BitConverter.ToUInt32(array6, 0), b);
                            else value = Class_Cypher.GetKey01(array6, darkTextBox_2.Text);

                            byte[] bytes = BitConverter.GetBytes(value);
                            this.method_1("Security Request - Key to Send:" + GForm_Main.smethod_1(bytes));

                            arraySend1 = new byte[] { 0x27, (byte)(SeedSendByte + 1) };
                            byte[] array8 = new byte[arraySend1.Length + 5];
                            if (TwoBytesMode) array8 = new byte[arraySend1.Length + 2];
                            for (int i = 0; i < arraySend1.Length; i++) array8[i] = arraySend1[i];
                            array8[2] = bytes[0];  //SecurityKey Byte1
                            array8[3] = bytes[1];  //SecurityKey Byte2
                            if (!TwoBytesMode)
                            {
                                array8[2] = bytes[2];  //SecurityKey Byte3
                                array8[3] = bytes[3];  //SecurityKey Byte4
                                array8[4] = b;         //Algorithm Byte
                            }
                            byte[] byte_2 = new byte[] { 0x67, (byte)(SeedSendByte + 1) };
                            Received = SendJ2534Message(channel, array8, 3);
                            if (BadResponceReceived) return;

                            if (Received != null)
                            {
                                int num = GForm_Main.smethod_2(Received, byte_2, 0);       //looking for 0x67, 0x42
                                if (num > 0)
                                {
                                    this.method_1("Security Authorized: ECU Unlocked");
                                    ECU_Unlocked = true;
                                }
                                else
                                {
                                    this.method_1("Recv:" + GForm_Main.smethod_1(Received));
                                }
                            }
                        }
                        else
                        {
                            this.method_1("Result NOT OK!!");
                        }
                        //################################################################


                        if (!ECU_Unlocked)
                        {
                            this.method_1("ECU is NOT Unlocked!");
                            return;
                        }
                        else
                        {
                            device.SetProgrammingVoltage(Pin.PIN_12, 5000);
                            Stopwatch stopwatch = new Stopwatch();

                            //Firmware (.rwd) writing mode
                            if (!WritingBinaryMode)
                            {
                                //###################
                                //Set Programming Mode
                                arraySend1 = new byte[] { 0x10, 0x02 };
                                Received = SendJ2534Message(channel, arraySend1, 3);
                                if (BadResponceReceived) return;
                                if (Received != null) this.method_1("Programming Mode Set!");
                                //###################
                                //Erase Memory
                                arraySend1 = new byte[] {0x31, 0x01, 0xFF, 0x00};
                                Received = SendJ2534Message(channel, arraySend1, 3);
                                if (BadResponceReceived) return;
                                if (Received != null) this.method_1("Memory Erased!");
                                //###################
                                //Set WRITE_DATA_BY_IDENTIFIER
                                arraySend1 = new byte[]
                                {
                                    0x2E,               //0x2E  -> Write Data by ID (F101)
                                    0xF1,               //0xF1
                                    0x01,               //0x01
                                    Class_RWD._keys[0], //Key1
                                    Class_RWD._keys[1], //Key2
                                    Class_RWD._keys[2]  //Key3
                                };

                                Received = SendJ2534Message(channel, arraySend1, 3);
                                if (BadResponceReceived) return;

                                if (Received != null)
                                {
                                    this.method_1("WRITE_DATA_BY_IDENTIFIER Set!");
                                }
                                //###################
                                //Request Download
                                byte memory_address_bytes = 0x04;
                                byte memory_size_bytes = 0x04;
                                uint memory_address = Class_RWD.start;
                                uint memory_size = Class_RWD.size;
                                arraySend1 = new byte[]
                                {
                                    0x34,   //0x34
                                    0x00,   //0x00  data_format=0x00
                                    memory_address_bytes,  //0x04
                                    0x00,   //0x00 -> Set later
                                    0x00,   //0x00 -> Set later
                                    0x00,   //0x00 -> Set later
                                    0x00,   //0x00 -> Set later
                                    0x00,   //0x00 -> Set later
                                    0x00,   //0x00 -> Set later
                                    0x00,   //0x00 -> Set later
                                    0x00    //0x00 -> Set later
                                };
                                arraySend1[2] = (byte) ((memory_size_bytes << 4) | memory_address_bytes);
                                if (memory_address >= Math.Pow(2, memory_address_bytes * 8)) throw new Exception(string.Format("invalid memory_address: 0x{0}", memory_address.ToString("X4")));
                                for (int i = 0; i < memory_address_bytes; i++)
                                {
                                    uint b2 = (memory_address >> ((memory_address_bytes - i - 1) * 8)) & 0xFF;
                                    arraySend1[3 + i] = (byte) b2;
                                }

                                if (memory_size >= Math.Pow(2, memory_size_bytes * 8)) throw new Exception(string.Format("invalid memory_size: 0x{0}", memory_size.ToString("X4")));
                                for (int i = 0; i < memory_size_bytes; i++)
                                {
                                    uint b2 = (memory_size >> ((memory_size_bytes - i - 1) * 8)) & 0xFF;
                                    arraySend1[3 + memory_size_bytes + i] = (byte)b2;
                                }

                                Received = SendJ2534Message(channel, arraySend1, 3);
                                if (BadResponceReceived) return;

                                if (Received != null)
                                {
                                    this.method_1("Request download started");
                                    stopwatch.Start();

                                    var max_num_bytes = 0;
                                    for (int i = 0; i < 4; i++) max_num_bytes = (max_num_bytes << 8) | Received[Received.Length - 5 + i];

                                    // account for service id and block sequence count (one byte each)
                                    var block_size = max_num_bytes;
                                    var chunk_size = block_size - 2;
                                    var cnt = 0;

                                    //Perform Write firmware to ECU
                                    for (int i = 0; i < Class_RWD._firmware_encrypted.Length; i += chunk_size)
                                    {
                                        cnt += 1;
                                        byte[] chunk = Class_RWD.Slice(Class_RWD._firmware_encrypted, i, i + chunk_size);

                                        byte bsct = (byte) (cnt & 0xFF);
                                        arraySend1 = new byte[]
                                        {
                                            0x36,   //0x36  -> TRANSFER_DATA
                                            bsct    //0x00  -> block_sequence_count
                                        };

                                        //Add the rest of the messages bytes to the final array
                                        byte[] arrayCommandFinal = new byte[arraySend1.Length + chunk.Length];
                                        int MessageIndex = 0;
                                        for (int i2 = 0; i2 < arraySend1.Length; i2++)
                                        {
                                            arrayCommandFinal[MessageIndex] = arraySend1[i2];
                                            MessageIndex++;
                                        }
                                        for (int i2 = 0; i2 < chunk.Length; i2++)
                                        {
                                            arrayCommandFinal[MessageIndex] = chunk[i2];
                                            MessageIndex++;
                                        }

                                        Received = SendJ2534Message(channel, arrayCommandFinal, 3);
                                        int Percent = ((i * 100) / Class_RWD._firmware_encrypted.Length);
                                        this.method_5(Percent);
                                        /*if (Received != null)
                                        {
                                            this.method_1("WRITE CHUNK CORRECT!");
                                        }*/
                                    }
                                    stopwatch.Stop();
                                }
                            }

                            if (WritingBinaryMode)
                            {
                                stopwatch.Start();
                                this.WriteROMtoECU(channel, byte_ToWrite, this.backgroundWorker_0);
                                stopwatch.Stop();
                            }

                            if (!WritingBinaryMode)
                            {
                                //Request transfer exit && routine control: check dependencies
                                this.method_13_Close(channel);
                            }

                            TimeSpan timeSpan = TimeSpan.FromMilliseconds((double)stopwatch.ElapsedMilliseconds);
                            this.backgroundWorker_0.ReportProgress(0, "Successfully write " + this.byte_7.Length + "bytes of flash memory in " + timeSpan.Minutes + ":" + timeSpan.Seconds);
                            device.SetProgrammingVoltage(Pin.PIN_12, -1);   //Set 0V on Pin12
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DarkMessageBox.Show(ex.Message);
            }
        }
    }

    public void WriteROMtoECU(Channel channel_0, byte[] byte_5, BackgroundWorker backgroundWorker_X = null)
    {
        //Get valid addresses for Firmware writing (get Start address)

        if (byte_5.Length < 1015808 && WritingBinaryMode)
        {
            return;
        }
        byte b = 1;
        int num = 256;
        for (int i = 0; i < 1015808; i += num)
        {
            this.method_14_Write(channel_0, byte_5, i, b, num, -1);
            if (b == 255)
            {
                b = 0;
            }
            else
            {
                b += 1;
            }
            if (backgroundWorker_X != null)
            {
                backgroundWorker_X.ReportProgress((int)((float)i / 1015808f * 100f));
            }
        }
        this.method_13_Close(channel_0);
    }

    public void method_13_Close(Channel channel_0)
    {
        byte[] arraySend1 = new byte[] {0x37};
        byte[] buffer2 = new byte[] { GForm_Main.byte_3, 0x77 };

        byte[] Received = SendJ2534Message(channel_0, arraySend1, 3);
        if (BadResponceReceived) return;

        if (Received != null)
        {
            int num3 = GForm_Main.smethod_2(Received, buffer2, 0);
            if (num3 > 0) this.method_1("Transfer Exited");

            arraySend1 = new byte[] {0x31, 0x01, 0xff, 0x01};
            Received = SendJ2534Message(channel_0, arraySend1, 3);
            if (BadResponceReceived) return;

            if (Received != null) this.method_1("Routine control check dependencies");
        }
    }

    public void method_14_Write(Channel channel_0, byte[] byte_5X, int int_23, byte byte_6X, int int_24, int int_25 = -1)
    {
        if (int_25 == -1) int_25 = int_24;

        //Transfer Data (0x36)
        byte[] data = new byte[]
        {
            0x18,
            0xDA,
            GForm_Main.byte_3,
            0xF1,
            0x36,
            byte_6X
        };
        Buffer.BlockCopy(byte_5X, int_23, data, 6, int_25);
        SAE.J2534.Message message = new SAE.J2534.Message(data, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
        channel_0.SendMessage(message);
        bool flag = false;
        byte[] buffer2 = new byte[] { GForm_Main.byte_3, 0x76, byte_6X };
        while (!flag)
        {
            GetMessageResults messages = channel_0.GetMessages(5);
            int num = -1;
            if (messages.Result != ResultCode.DEVICE_NOT_CONNECTED)
            {
                foreach (SAE.J2534.Message message2 in messages.Messages)
                {
                    num = GForm_Main.smethod_2(message2.Data, buffer2, 0);
                    if (num > 0)
                    {
                        flag = true;
                        return;
                    }
                }
            }
        }
    }

    private void method_18(object sender, ProgressChangedEventArgs e)
    {
        string text = e.UserState as string;
        this.darkLabel_8.Text = text;
        this.method_5(e.ProgressPercentage);
    }


    private void method_19(object sender, RunWorkerCompletedEventArgs e)
    {
        DarkMessageBox.Show(this, "Flash Finished writing!");
    }


    private void method_20(object sender, EventArgs e)
    {
        GForm_PlatformSelect gform = new GForm_PlatformSelect();
        if (gform.ShowDialog() == DialogResult.OK)
        {
            try
            {
                GForm_Main.class9_0 = gform.Class9_0;
            }
            catch
            {
                return;
            }
            gform.Dispose();
            GForm_Main.byte_3 = GForm_Main.class9_0.ECU_Byte;
            GForm_Main.byte_0[3] = GForm_Main.class9_0.ECU_Byte;
            GForm_Main.byte_1[3] = GForm_Main.class9_0.ECU_Byte;
            GForm_Main.byte_2[3] = GForm_Main.class9_0.ECU_Byte;
            this.byte_5[0] = GForm_Main.class9_0.ECU_Byte;
            Array.Resize<byte>(ref GForm_Main.byte_4, GForm_Main.class9_0.FirmwareSize);
            Array.Resize<byte>(ref this.byte_7, GForm_Main.class9_0.RomSize);
            this.byte_7 = Enumerable.Repeat<byte>(byte.MaxValue, GForm_Main.class9_0.RomSize).ToArray<byte>();
            this.darkButton_2.Enabled = true;
            return;
        }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GForm_Main));
            this.darkTextBox_0 = new DarkUI.Controls.DarkTextBox();
            this.darkButton_3 = new DarkUI.Controls.DarkButton();
            this.darkButton_2 = new DarkUI.Controls.DarkButton();
            this.darkButton_DownloadROM = new DarkUI.Controls.DarkButton();
            this.darkButton_0 = new DarkUI.Controls.DarkButton();
            this.darkGroupBox_0 = new DarkUI.Controls.DarkGroupBox();
            this.darkComboBoxUnlockMode = new DarkUI.Controls.DarkComboBox();
            this.darkButton5 = new DarkUI.Controls.DarkButton();
            this.darkButton_FlashFW = new DarkUI.Controls.DarkButton();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkButton_6 = new DarkUI.Controls.DarkButton();
            this.darkButton_FlashRom = new DarkUI.Controls.DarkButton();
            this.darkButton_Unlock01 = new DarkUI.Controls.DarkButton();
            this.darkButton_Unlock41 = new DarkUI.Controls.DarkButton();
            this.darkButton3 = new DarkUI.Controls.DarkButton();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkTextBox_4 = new DarkUI.Controls.DarkTextBox();
            this.darkTextBox_3 = new DarkUI.Controls.DarkTextBox();
            this.darkLabel_3 = new DarkUI.Controls.DarkLabel();
            this.darkButton_4 = new DarkUI.Controls.DarkButton();
            this.darkLabel_2 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_0 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_1 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_4 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_5 = new DarkUI.Controls.DarkLabel();
            this.darkTextBox_1 = new DarkUI.Controls.DarkTextBox();
            this.darkTextBox_2 = new DarkUI.Controls.DarkTextBox();
            this.darkProgressBar_0 = new DarkUI.Controls.DarkProgressBar();
            this.darkLabel_7 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_8 = new DarkUI.Controls.DarkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DarkgroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.darkButton6 = new DarkUI.Controls.DarkButton();
            this.darkButton4 = new DarkUI.Controls.DarkButton();
            this.darkTextBoxJ2534Command = new DarkUI.Controls.DarkTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkButtonJ2534Command = new DarkUI.Controls.DarkButton();
            this.darkGroupBox_0.SuspendLayout();
            this.DarkgroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkTextBox_0
            // 
            this.darkTextBox_0.Location = new System.Drawing.Point(218, 63);
            this.darkTextBox_0.Multiline = true;
            this.darkTextBox_0.Name = "darkTextBox_0";
            this.darkTextBox_0.Size = new System.Drawing.Size(399, 408);
            this.darkTextBox_0.TabIndex = 55;
            this.darkTextBox_0.Text = "Honda CANBUS Tools";
            // 
            // darkButton_3
            // 
            this.darkButton_3.Checked = false;
            this.darkButton_3.Location = new System.Drawing.Point(6, 19);
            this.darkButton_3.Name = "darkButton_3";
            this.darkButton_3.Size = new System.Drawing.Size(192, 23);
            this.darkButton_3.TabIndex = 47;
            this.darkButton_3.Text = "Scan for J2534 Devices";
            this.darkButton_3.Click += new System.EventHandler(this.method_2);
            // 
            // darkButton_2
            // 
            this.darkButton_2.Checked = false;
            this.darkButton_2.Enabled = false;
            this.darkButton_2.Location = new System.Drawing.Point(6, 77);
            this.darkButton_2.Name = "darkButton_2";
            this.darkButton_2.Size = new System.Drawing.Size(192, 23);
            this.darkButton_2.TabIndex = 48;
            this.darkButton_2.Text = "Select Adapter";
            this.darkButton_2.Click += new System.EventHandler(this.method_3);
            // 
            // darkButton_DownloadROM
            // 
            this.darkButton_DownloadROM.Checked = false;
            this.darkButton_DownloadROM.Enabled = false;
            this.darkButton_DownloadROM.Location = new System.Drawing.Point(6, 162);
            this.darkButton_DownloadROM.Name = "darkButton_DownloadROM";
            this.darkButton_DownloadROM.Size = new System.Drawing.Size(192, 23);
            this.darkButton_DownloadROM.TabIndex = 49;
            this.darkButton_DownloadROM.Text = "Download Rom";
            this.darkButton_DownloadROM.Click += new System.EventHandler(this.method_13);
            // 
            // darkButton_0
            // 
            this.darkButton_0.Checked = false;
            this.darkButton_0.Enabled = false;
            this.darkButton_0.Location = new System.Drawing.Point(695, 24);
            this.darkButton_0.Name = "darkButton_0";
            this.darkButton_0.Size = new System.Drawing.Size(192, 23);
            this.darkButton_0.TabIndex = 50;
            this.darkButton_0.Text = "Read Ram Address";
            this.darkButton_0.Visible = false;
            this.darkButton_0.Click += new System.EventHandler(this.method_14);
            // 
            // darkGroupBox_0
            // 
            this.darkGroupBox_0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkGroupBox_0.Controls.Add(this.darkComboBoxUnlockMode);
            this.darkGroupBox_0.Controls.Add(this.darkButton5);
            this.darkGroupBox_0.Controls.Add(this.darkButton_FlashFW);
            this.darkGroupBox_0.Controls.Add(this.darkButton1);
            this.darkGroupBox_0.Controls.Add(this.darkButton_6);
            this.darkGroupBox_0.Controls.Add(this.darkButton_FlashRom);
            this.darkGroupBox_0.Controls.Add(this.darkButton_3);
            this.darkGroupBox_0.Controls.Add(this.darkButton_DownloadROM);
            this.darkGroupBox_0.Controls.Add(this.darkButton_2);
            this.darkGroupBox_0.Location = new System.Drawing.Point(7, 6);
            this.darkGroupBox_0.Name = "darkGroupBox_0";
            this.darkGroupBox_0.Size = new System.Drawing.Size(204, 284);
            this.darkGroupBox_0.TabIndex = 56;
            this.darkGroupBox_0.TabStop = false;
            this.darkGroupBox_0.Text = "J2534 Controls";
            // 
            // darkComboBoxUnlockMode
            // 
            this.darkComboBoxUnlockMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.darkComboBoxUnlockMode.FormattingEnabled = true;
            this.darkComboBoxUnlockMode.Items.AddRange(new object[] {
            "Unlock mode: 0x27, 0x01",
            "Unlock mode: 0x27, 0x03",
            "Unlock mode: 0x27, 0x05",
            "Unlock mode: 0x27, 0x41"});
            this.darkComboBoxUnlockMode.Location = new System.Drawing.Point(6, 135);
            this.darkComboBoxUnlockMode.Name = "darkComboBoxUnlockMode";
            this.darkComboBoxUnlockMode.Size = new System.Drawing.Size(192, 21);
            this.darkComboBoxUnlockMode.TabIndex = 70;
            this.darkComboBoxUnlockMode.SelectedIndexChanged += new System.EventHandler(this.darkComboBoxUnlockMode_SelectedIndexChanged);
            // 
            // darkButton5
            // 
            this.darkButton5.Checked = false;
            this.darkButton5.Location = new System.Drawing.Point(6, 249);
            this.darkButton5.Name = "darkButton5";
            this.darkButton5.Size = new System.Drawing.Size(192, 23);
            this.darkButton5.TabIndex = 69;
            this.darkButton5.Text = "Open OBD2 Scan Tools";
            this.darkButton5.Click += new System.EventHandler(this.darkButton5_Click);
            // 
            // darkButton_FlashFW
            // 
            this.darkButton_FlashFW.Checked = false;
            this.darkButton_FlashFW.Enabled = false;
            this.darkButton_FlashFW.Location = new System.Drawing.Point(6, 220);
            this.darkButton_FlashFW.Name = "darkButton_FlashFW";
            this.darkButton_FlashFW.Size = new System.Drawing.Size(192, 23);
            this.darkButton_FlashFW.TabIndex = 60;
            this.darkButton_FlashFW.Text = "Flash Firmware (.rwd)";
            this.darkButton_FlashFW.Click += new System.EventHandler(this.darkButton3_Click);
            // 
            // darkButton1
            // 
            this.darkButton1.Checked = false;
            this.darkButton1.Enabled = false;
            this.darkButton1.Location = new System.Drawing.Point(6, 106);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Size = new System.Drawing.Size(192, 23);
            this.darkButton1.TabIndex = 56;
            this.darkButton1.Text = "Connect ECU";
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // darkButton_6
            // 
            this.darkButton_6.Checked = false;
            this.darkButton_6.Location = new System.Drawing.Point(6, 48);
            this.darkButton_6.Name = "darkButton_6";
            this.darkButton_6.Size = new System.Drawing.Size(192, 23);
            this.darkButton_6.TabIndex = 55;
            this.darkButton_6.Text = "Select ECU";
            this.darkButton_6.Click += new System.EventHandler(this.method_20);
            // 
            // darkButton_FlashRom
            // 
            this.darkButton_FlashRom.Checked = false;
            this.darkButton_FlashRom.Enabled = false;
            this.darkButton_FlashRom.Location = new System.Drawing.Point(6, 191);
            this.darkButton_FlashRom.Name = "darkButton_FlashRom";
            this.darkButton_FlashRom.Size = new System.Drawing.Size(192, 23);
            this.darkButton_FlashRom.TabIndex = 54;
            this.darkButton_FlashRom.Text = "Flash Rom (.bin)";
            this.darkButton_FlashRom.Click += new System.EventHandler(this.method_17);
            // 
            // darkButton_Unlock01
            // 
            this.darkButton_Unlock01.Checked = false;
            this.darkButton_Unlock01.Enabled = false;
            this.darkButton_Unlock01.Location = new System.Drawing.Point(313, 228);
            this.darkButton_Unlock01.Name = "darkButton_Unlock01";
            this.darkButton_Unlock01.Size = new System.Drawing.Size(192, 23);
            this.darkButton_Unlock01.TabIndex = 58;
            this.darkButton_Unlock01.Text = "UNLOCK ECU (0x27,0x01)";
            this.darkButton_Unlock01.Visible = false;
            this.darkButton_Unlock01.Click += new System.EventHandler(this.darkButton_Unlock01_Click);
            // 
            // darkButton_Unlock41
            // 
            this.darkButton_Unlock41.Checked = false;
            this.darkButton_Unlock41.Enabled = false;
            this.darkButton_Unlock41.Location = new System.Drawing.Point(313, 267);
            this.darkButton_Unlock41.Name = "darkButton_Unlock41";
            this.darkButton_Unlock41.Size = new System.Drawing.Size(192, 23);
            this.darkButton_Unlock41.TabIndex = 57;
            this.darkButton_Unlock41.Text = "UNLOCK ECU (0x27,0x41)";
            this.darkButton_Unlock41.Visible = false;
            this.darkButton_Unlock41.Click += new System.EventHandler(this.darkButton2_Click);
            // 
            // darkButton3
            // 
            this.darkButton3.Checked = false;
            this.darkButton3.Location = new System.Drawing.Point(6, 48);
            this.darkButton3.Name = "darkButton3";
            this.darkButton3.Size = new System.Drawing.Size(192, 23);
            this.darkButton3.TabIndex = 67;
            this.darkButton3.Text = "Convert Firmware .bin to .rwd";
            this.darkButton3.Click += new System.EventHandler(this.darkButton3_Click_1);
            // 
            // darkButton2
            // 
            this.darkButton2.Checked = false;
            this.darkButton2.Location = new System.Drawing.Point(6, 19);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Size = new System.Drawing.Size(192, 23);
            this.darkButton2.TabIndex = 59;
            this.darkButton2.Text = "Convert Firmware .rwd to .bin";
            this.darkButton2.Click += new System.EventHandler(this.darkButton2_Click_1);
            // 
            // darkTextBox_4
            // 
            this.darkTextBox_4.Location = new System.Drawing.Point(774, 104);
            this.darkTextBox_4.Name = "darkTextBox_4";
            this.darkTextBox_4.Size = new System.Drawing.Size(113, 20);
            this.darkTextBox_4.TabIndex = 66;
            this.darkTextBox_4.Visible = false;
            // 
            // darkTextBox_3
            // 
            this.darkTextBox_3.Location = new System.Drawing.Point(774, 80);
            this.darkTextBox_3.Name = "darkTextBox_3";
            this.darkTextBox_3.Size = new System.Drawing.Size(113, 20);
            this.darkTextBox_3.TabIndex = 65;
            this.darkTextBox_3.Visible = false;
            // 
            // darkLabel_3
            // 
            this.darkLabel_3.AutoSize = true;
            this.darkLabel_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_3.Location = new System.Drawing.Point(713, 106);
            this.darkLabel_3.Name = "darkLabel_3";
            this.darkLabel_3.Size = new System.Drawing.Size(56, 13);
            this.darkLabel_3.TabIndex = 60;
            this.darkLabel_3.Text = "Read Size";
            this.darkLabel_3.Visible = false;
            // 
            // darkButton_4
            // 
            this.darkButton_4.Checked = false;
            this.darkButton_4.Enabled = false;
            this.darkButton_4.Location = new System.Drawing.Point(695, 53);
            this.darkButton_4.Name = "darkButton_4";
            this.darkButton_4.Size = new System.Drawing.Size(192, 23);
            this.darkButton_4.TabIndex = 51;
            this.darkButton_4.Text = "Sniff All Traffic";
            this.darkButton_4.Visible = false;
            this.darkButton_4.Click += new System.EventHandler(this.method_16);
            // 
            // darkLabel_2
            // 
            this.darkLabel_2.AutoSize = true;
            this.darkLabel_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_2.Location = new System.Drawing.Point(696, 83);
            this.darkLabel_2.Name = "darkLabel_2";
            this.darkLabel_2.Size = new System.Drawing.Size(73, 13);
            this.darkLabel_2.TabIndex = 59;
            this.darkLabel_2.Text = "Read address";
            this.darkLabel_2.Visible = false;
            // 
            // darkLabel_0
            // 
            this.darkLabel_0.AutoSize = true;
            this.darkLabel_0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_0.Location = new System.Drawing.Point(218, 14);
            this.darkLabel_0.Name = "darkLabel_0";
            this.darkLabel_0.Size = new System.Drawing.Size(62, 13);
            this.darkLabel_0.TabIndex = 57;
            this.darkLabel_0.Text = "Vin Number";
            // 
            // darkLabel_1
            // 
            this.darkLabel_1.AutoSize = true;
            this.darkLabel_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_1.Location = new System.Drawing.Point(218, 40);
            this.darkLabel_1.Name = "darkLabel_1";
            this.darkLabel_1.Size = new System.Drawing.Size(70, 13);
            this.darkLabel_1.TabIndex = 58;
            this.darkLabel_1.Text = "Calibration ID";
            // 
            // darkLabel_4
            // 
            this.darkLabel_4.AutoSize = true;
            this.darkLabel_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel_4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_4.Location = new System.Drawing.Point(536, 509);
            this.darkLabel_4.Name = "darkLabel_4";
            this.darkLabel_4.Size = new System.Drawing.Size(80, 25);
            this.darkLabel_4.TabIndex = 61;
            this.darkLabel_4.Text = "Credits";
            this.darkLabel_4.Click += new System.EventHandler(this.darkLabel_4_Click);
            // 
            // darkLabel_5
            // 
            this.darkLabel_5.AutoSize = true;
            this.darkLabel_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.darkLabel_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_5.Location = new System.Drawing.Point(12, 512);
            this.darkLabel_5.Name = "darkLabel_5";
            this.darkLabel_5.Size = new System.Drawing.Size(0, 20);
            this.darkLabel_5.TabIndex = 51;
            // 
            // darkTextBox_1
            // 
            this.darkTextBox_1.Location = new System.Drawing.Point(294, 11);
            this.darkTextBox_1.Name = "darkTextBox_1";
            this.darkTextBox_1.ReadOnly = true;
            this.darkTextBox_1.Size = new System.Drawing.Size(323, 20);
            this.darkTextBox_1.TabIndex = 63;
            // 
            // darkTextBox_2
            // 
            this.darkTextBox_2.Location = new System.Drawing.Point(294, 37);
            this.darkTextBox_2.Name = "darkTextBox_2";
            this.darkTextBox_2.ReadOnly = true;
            this.darkTextBox_2.Size = new System.Drawing.Size(323, 20);
            this.darkTextBox_2.TabIndex = 64;
            // 
            // darkProgressBar_0
            // 
            this.darkProgressBar_0.Location = new System.Drawing.Point(98, 537);
            this.darkProgressBar_0.Name = "darkProgressBar_0";
            this.darkProgressBar_0.Size = new System.Drawing.Size(519, 23);
            this.darkProgressBar_0.TabIndex = 67;
            // 
            // darkLabel_7
            // 
            this.darkLabel_7.AutoSize = true;
            this.darkLabel_7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_7.Location = new System.Drawing.Point(14, 542);
            this.darkLabel_7.Name = "darkLabel_7";
            this.darkLabel_7.Size = new System.Drawing.Size(37, 13);
            this.darkLabel_7.TabIndex = 68;
            this.darkLabel_7.Text = "Status";
            // 
            // darkLabel_8
            // 
            this.darkLabel_8.AutoSize = true;
            this.darkLabel_8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_8.Location = new System.Drawing.Point(228, 516);
            this.darkLabel_8.Name = "darkLabel_8";
            this.darkLabel_8.Size = new System.Drawing.Size(0, 13);
            this.darkLabel_8.TabIndex = 69;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.gz";
            this.openFileDialog1.Filter = "Honda Compressed RWD Firmware|*.gz;*.rwd";
            this.openFileDialog1.Title = "Open Honda/Acura File";
            // 
            // DarkgroupBox1
            // 
            this.DarkgroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DarkgroupBox1.Controls.Add(this.darkButton6);
            this.DarkgroupBox1.Controls.Add(this.darkButton4);
            this.DarkgroupBox1.Controls.Add(this.darkButton3);
            this.DarkgroupBox1.Controls.Add(this.darkButton2);
            this.DarkgroupBox1.Location = new System.Drawing.Point(7, 326);
            this.DarkgroupBox1.Name = "DarkgroupBox1";
            this.DarkgroupBox1.Size = new System.Drawing.Size(204, 180);
            this.DarkgroupBox1.TabIndex = 70;
            this.DarkgroupBox1.TabStop = false;
            this.DarkgroupBox1.Text = "File Controls";
            // 
            // darkButton6
            // 
            this.darkButton6.Checked = false;
            this.darkButton6.Location = new System.Drawing.Point(6, 106);
            this.darkButton6.Name = "darkButton6";
            this.darkButton6.Size = new System.Drawing.Size(192, 23);
            this.darkButton6.TabIndex = 69;
            this.darkButton6.Text = "Open ROM Editor";
            this.darkButton6.Click += new System.EventHandler(this.darkButton6_Click);
            // 
            // darkButton4
            // 
            this.darkButton4.Checked = false;
            this.darkButton4.Location = new System.Drawing.Point(6, 77);
            this.darkButton4.Name = "darkButton4";
            this.darkButton4.Size = new System.Drawing.Size(192, 23);
            this.darkButton4.TabIndex = 68;
            this.darkButton4.Text = "Fix Checksums";
            this.darkButton4.Click += new System.EventHandler(this.darkButton4_Click);
            // 
            // darkTextBoxJ2534Command
            // 
            this.darkTextBoxJ2534Command.Location = new System.Drawing.Point(313, 477);
            this.darkTextBoxJ2534Command.Name = "darkTextBoxJ2534Command";
            this.darkTextBoxJ2534Command.Size = new System.Drawing.Size(230, 20);
            this.darkTextBoxJ2534Command.TabIndex = 72;
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(218, 480);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(89, 13);
            this.darkLabel1.TabIndex = 71;
            this.darkLabel1.Text = "J2534 Command:";
            // 
            // darkButtonJ2534Command
            // 
            this.darkButtonJ2534Command.Checked = false;
            this.darkButtonJ2534Command.Enabled = false;
            this.darkButtonJ2534Command.Location = new System.Drawing.Point(549, 475);
            this.darkButtonJ2534Command.Name = "darkButtonJ2534Command";
            this.darkButtonJ2534Command.Size = new System.Drawing.Size(53, 23);
            this.darkButtonJ2534Command.TabIndex = 70;
            this.darkButtonJ2534Command.Text = "Send";
            this.darkButtonJ2534Command.Click += new System.EventHandler(this.darkButtonJ2534Command_Click);
            // 
            // GForm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 571);
            this.Controls.Add(this.darkButtonJ2534Command);
            this.Controls.Add(this.darkTextBoxJ2534Command);
            this.Controls.Add(this.darkButton_Unlock01);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.darkButton_Unlock41);
            this.Controls.Add(this.DarkgroupBox1);
            this.Controls.Add(this.darkLabel_8);
            this.Controls.Add(this.darkLabel_7);
            this.Controls.Add(this.darkProgressBar_0);
            this.Controls.Add(this.darkTextBox_2);
            this.Controls.Add(this.darkTextBox_4);
            this.Controls.Add(this.darkTextBox_1);
            this.Controls.Add(this.darkLabel_5);
            this.Controls.Add(this.darkTextBox_3);
            this.Controls.Add(this.darkLabel_4);
            this.Controls.Add(this.darkLabel_1);
            this.Controls.Add(this.darkLabel_0);
            this.Controls.Add(this.darkGroupBox_0);
            this.Controls.Add(this.darkLabel_3);
            this.Controls.Add(this.darkTextBox_0);
            this.Controls.Add(this.darkButton_4);
            this.Controls.Add(this.darkLabel_2);
            this.Controls.Add(this.darkButton_0);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(645, 610);
            this.Name = "GForm_Main";
            this.Text = "Honda CANBUS Tools";
            this.Load += new System.EventHandler(this.GForm_Main_Load);
            this.darkGroupBox_0.ResumeLayout(false);
            this.DarkgroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }


    // Note: this type is marked as 'beforefieldinit'.
    static GForm_Main()
    {
    }


    IAsyncResult method_22(Delegate delegate_0, object[] object_0)
    {
        return base.BeginInvoke(delegate_0, object_0);
    }


    public static string string_0 = string.Empty;


    public static string string_1 = "";


    private Dictionary<string, byte[]> dictionary_0 = new Dictionary<string, byte[]>();


    private List<string> list_0 = new List<string>();


    public static byte[] byte_0 = new byte[]
    {
        24,
        218,
        241,
        16,
        98,
        241,
        129
    };


    public static byte[] byte_1 = new byte[]
    {
        24,
        218,
        241,
        16,
        98,
        241,
        144
    };


    public static byte[] byte_2 = new byte[]
    {
        24,
        218,
        241,
        16,
        127
    };


    public static byte byte_3 = 16;

    public static byte[] byte_ToWrite = new byte[] { };


    public static byte[] byte_4 = new byte[2097152];


    private byte[] byte_5 = new byte[]
    {
        GForm_Main.byte_3,
        127
    };


    private byte[] byte_6 = new byte[2];


    private byte[] byte_7;


    private static byte[] byte_8 = new byte[]
    {
        GForm_Main.byte_3,
        20
    };


    private string string_2 = string.Empty;


    internal static Class_ECUS class9_0;


    public static byte[] byte_9 = new byte[]
    {
        48,
        6
    };


    public static byte[] byte_10 = new byte[]
    {
        16,
        8
    };


    public static byte[] byte_11 = new byte[]
    {
        18,
        7
    };


    private BackgroundWorker backgroundWorker_0;

    private BackgroundWorker backgroundWorker_1;


    private DateTime dateTime_0;


    private long long_0;


    private IContainer icontainer_0;



    private DarkButton darkButton_0;


    private DarkButton darkButton_DownloadROM;


    private DarkButton darkButton_2;


    private DarkButton darkButton_3;


    private DarkTextBox darkTextBox_0;


    private DarkGroupBox darkGroupBox_0;


    private DarkLabel darkLabel_0;


    private DarkLabel darkLabel_1;


    private DarkLabel darkLabel_2;


    private DarkLabel darkLabel_3;


    private DarkLabel darkLabel_4;


    private DarkLabel darkLabel_5;


    private DarkTextBox darkTextBox_1;


    private DarkTextBox darkTextBox_2;


    private DarkTextBox darkTextBox_3;


    private DarkTextBox darkTextBox_4;


    private DarkButton darkButton_4;



    private DarkButton darkButton_FlashRom;


    private DarkButton darkButton_6;


    private DarkProgressBar darkProgressBar_0;


    private DarkLabel darkLabel_7;


    private DarkLabel darkLabel_8;
    private DarkButton darkButton1;
    private DarkButton darkButton_Unlock41;



    private delegate void Delegate0(string text);


    [CompilerGenerated]
    private sealed class Class5
    {

        public Class5()
        {
        }


        internal void method_0()
        {
            this.gform0_0.darkTextBox_0.AppendText(this.string_0 + Environment.NewLine);
        }


        public GForm_Main gform0_0;


        public string string_0;
    }


    [CompilerGenerated]
    private sealed class Class6
    {

        public Class6()
        {
        }


        internal void method_0()
        {
            this.gform0_0.darkTextBox_0.AppendText("Read Memory Starts" + Environment.NewLine);
        }


        internal void method_1()
        {
            this.gform0_0.darkTextBox_0.AppendText("Invalid Block size detected" + Environment.NewLine + string.Format("Buffer :{0} != blockSize {1} ", this.byte_0.Length, this.uint_0) + Environment.NewLine);
        }


        public GForm_Main gform0_0;


        public byte[] byte_0;


        public uint uint_0;


        public MethodInvoker methodInvoker_0;
    }


    [CompilerGenerated]
    private sealed class Class7
    {

        public Class7()
        {
        }


        internal void method_0()
        {
            this.class6_0.gform0_0.darkTextBox_0.AppendText(string.Format("Failed block read at: {0}", this.uint_0) + Environment.NewLine);
        }


        internal void method_1()
        {
            this.class6_0.gform0_0.darkTextBox_0.AppendText(string.Format("block read at: {0}", this.uint_0) + Environment.NewLine);
        }


        public uint uint_0;


        public GForm_Main.Class6 class6_0;
    }


    [CompilerGenerated]
    private sealed class Class8
    {

        public Class8()
        {
        }


        internal void method_0()
        {
            this.gform0_0.darkLabel_5.Text = "Download Rate: " + this.double_0.ToString();
        }


        public GForm_Main gform0_0;


        public double double_0;
    }

    public void darkButton2_Click_1(object sender, EventArgs e)
    {
        this.openFileDialog1.Filter = "Honda Compressed RWD Firmware|*.gz;*.rwd";
        this.openFileDialog1.DefaultExt = "*.gz";
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            Class_RWD.LoadRWD(openFileDialog1.FileName, true, true);
        }
    }

    private void GForm_Main_Load(object sender, EventArgs e)
    {

    }

    public void darkButton3_Click_1(object sender, EventArgs e)
    {
        GForm_ConvertBIN gform = new GForm_ConvertBIN();
        if (gform.ShowDialog() == DialogResult.OK)
        {
            string ThisB = gform.FileBIN;
            string ThisR = gform.FileRWD;
            gform.Dispose();

            Class_RWD.LoadBIN(ThisB, ThisR);
        }
    }

    private void darkButton4_Click(object sender, EventArgs e)
    {
        //this.openFileDialog1.Filter = "Honda Compressed RWD Firmware|*.gz;*.rwd";
        this.openFileDialog1.Filter = "Honda binary rom file|*.bin";
        this.openFileDialog1.DefaultExt = "*.bin";
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            byte[] FilesBytes = File.ReadAllBytes(openFileDialog1.FileName);
            string FilenameBuffer = openFileDialog1.FileName;

            if ((FilesBytes.Length - 1) == 0xFFFFF)
            {
                byte[] NewFilesBytes = VerifyChecksumFullBin(FilesBytes);
                if (NewFilesBytes != FilesBytes)
                {
                    string NewPath = Path.GetDirectoryName(openFileDialog1.FileName) + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "_FixedChkSum.bin";
                    File.Create(NewPath).Dispose();
                    File.WriteAllBytes(NewPath, NewFilesBytes);
                    this.method_1("File saved: " + NewPath);
                }
            }
            else if ((FilesBytes.Length - 1) == 0xF7FFF)
            {
                int BtSumInt = this.Editortable_0.CheckForBootLoaderSum(this.Editortable_0.ExtractECUNameFromThisFile(FilesBytes));
                if (BtSumInt == -1)
                {
                    DarkMessageBox.Show(this, "Since this decompressed firmware .bin file is missing the bootloader section\nSelect the firmware .rwd file from which is as been decompressed from", "MISSING BOOTLOADER SECTION FOR CHECKSUMS VERIFICATIONS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //Open RWD firmware
                    openFileDialog1.Filter = "Honda Compressed RWD Firmware|*.gz;*.rwd";
                    openFileDialog1.DefaultExt = "*.gz";
                    result = openFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Class_RWD.LoadRWD(openFileDialog1.FileName, true, false);
                    }
                }
                else
                {
                    Class_RWD.BootloaderSum = (byte)BtSumInt;
                }

                byte[] NewFilesBytes = VerifyChecksumFWBin(FilesBytes);
                if (NewFilesBytes != FilesBytes)
                {
                    string NewPath = Path.GetDirectoryName(FilenameBuffer) + @"\" + Path.GetFileNameWithoutExtension(FilenameBuffer) + "_FixedChkSum.bin";
                    File.Create(NewPath).Dispose();
                    File.WriteAllBytes(NewPath, NewFilesBytes);
                    this.method_1("File saved: " + NewPath);
                }
            }
            else
            {
                this.method_1("This file is not compatible!");
            }
        }
    }

    public void darkButton5_Click(object sender, EventArgs e)
    {
        frmOBD2Scan frmOBD2Scan_0 = new frmOBD2Scan();
        frmOBD2Scan_0.Show();
    }

    private void darkLabel_4_Click(object sender, EventArgs e)
    {
        GForm_Credits GForm_Credits_0 = new GForm_Credits();
        GForm_Credits_0.ShowDialog();
    }

    private void darkButton6_Click(object sender, EventArgs e)
    {
        try
        {
            this.Editortable_0.Show();
            this.Editortable_0.Loadingg();
        }
        catch (Exception ex)
        {
            try
            {
                this.Editortable_0 = null;
                this.Editortable_0 = new Editortable(ref GForm_Main_0);
                this.Editortable_0.Show();
                this.Editortable_0.Loadingg();
            }
            catch
            {

            }
        }
    }

    private byte[] GetBytesArrayFromCommandText()
    {
        string CMDText = darkTextBoxJ2534Command.Text;
        byte[] ReturnArray = new byte[0];

        if (CMDText != "")
        {
            if (CMDText.Contains(","))
            {
                string[] SplittedBytes = CMDText.Split(',');
                ReturnArray = new byte[SplittedBytes.Length];

                for (int i = 0; i < SplittedBytes.Length; i++)
                {

                    ReturnArray[i] = (byte) int.Parse(SplittedBytes[i], System.Globalization.NumberStyles.HexNumber);
                }
            }
        }

        return ReturnArray;
    }

    private void darkButtonJ2534Command_Click(object sender, EventArgs e)
    {
        using (API api = APIFactory.GetAPI(GForm_Main.string_0))
        {
            try
            {
                using (Device device = api.GetDevice(""))
                {
                    using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false))
                    {
                        LoadJ2534Channel(channel);

                        SendJ2534Message(channel, GetBytesArrayFromCommandText(), 3);
                    }
                }
            }
            catch (Exception ex)
            {
                DarkMessageBox.Show(ex.Message);
            }
        }
    }


    private void SetButtons() 
    {
        if (darkComboBoxUnlockMode.SelectedIndex == 0)
        {
            //0x27, 0x01
            darkButton_DownloadROM.Enabled = false;
            darkButton_FlashRom.Enabled = false;
            if (VehicleConnected) darkButton_FlashFW.Enabled = true;
            if (!VehicleConnected) darkButton_FlashFW.Enabled = false;
        }
        if (darkComboBoxUnlockMode.SelectedIndex == 1)
        {
            //0x27, 0x03 -> no cypher yet
            darkButton_DownloadROM.Enabled = false;
            darkButton_FlashRom.Enabled = false;
            darkButton_FlashFW.Enabled = false;
            this.method_1("Unlock mode 0x27, 0x03 don't have any cypher function set for the seed/key algorythm");
        }
        if (darkComboBoxUnlockMode.SelectedIndex == 2)
        {
            //0x27, 0x05 -> no cypher yet
            darkButton_DownloadROM.Enabled = false;
            darkButton_FlashRom.Enabled = false;
            darkButton_FlashFW.Enabled = false;
            this.method_1("Unlock mode 0x27, 0x05 don't have any cypher function set for the seed/key algorythm");
        }
        if (darkComboBoxUnlockMode.SelectedIndex == 3)
        {
            //0x27, 0x41
            if (VehicleConnected)
            {
                darkButton_DownloadROM.Enabled = true;
                darkButton_FlashRom.Enabled = true;
                darkButton_FlashFW.Enabled = true;
            }
            if (!VehicleConnected)
            {
                darkButton_DownloadROM.Enabled = false;
                darkButton_FlashRom.Enabled = false;
                darkButton_FlashFW.Enabled = false;
            }
        }
    }

    private void darkComboBoxUnlockMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetButtons();
        if (darkComboBoxUnlockMode.SelectedIndex == 3)
        {
            this.method_1("Unlock mode 0x27, 0x41 is only compatible with these cars for now:");
            this.method_1("-Honda Civic 06-10 (All models??)");
            this.method_1("-Honda Ridgeline 06-13");
            this.method_1("-Honda CR-V 07-10");
        }
    }
}
