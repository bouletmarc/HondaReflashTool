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
    public string Version = "v1.1.7";
    private DarkTextBox darkTextBoxJ2534Command;
    private DarkLabel darkLabel1;
    private DarkButton darkButtonJ2534Command;
    private DarkComboBox darkComboBoxUnlockMode;
    private bool BadResponceReceived = false;
    public Class_Checksums Class_Checksums_0;
    public System.Windows.Forms.Timer Timer1 = new System.Windows.Forms.Timer();
    //public System.Windows.Forms.Timer TimerJ2534 = new System.Windows.Forms.Timer();
    public API api;
    public Device device;
    public Channel channel;
    public bool J2534Connected = false;
    private int SelectedPlatformIndex = 0;
    private DarkGroupBox darkGroupBox2;
    private DarkCheckBox darkCheckBoxLogsCommands;
    private IContainer components;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem clearLogsToolStripMenuItem;
    public string LastFileOpenedEditor = "";

    public GForm_Main()
    {
        this.Enabled = false;

        this.InitializeComponent();

        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;
        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;
        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;

        darkLabel_5.Text = "";
        darkLabel_8.Text = "";
        GForm_Main_0 = this;

        Timer1.Interval = 1000;
        Timer1.Tick += new EventHandler(TimerEventProcessor);
        Timer1.Start();

        //label1.Text = "";
        //TimerJ2534.Interval = 1000;
        //TimerJ2534.Tick += new EventHandler(TimerEventProcessorJ2534);
    }

    public void LoadSettings()
    {
        try
        {
            string TFilePath = Application.StartupPath + @"\Settings.txt";
            if (File.Exists(TFilePath))
            {
                string[] AllLines = File.ReadAllLines(TFilePath);
                for (int i = 0; i < AllLines.Length; i++)
                {
                    if (AllLines[i].Contains("J2534AdapterName=") && AllLines[i][0] != '#') J2534AdapterName = AllLines[i].Split('=')[1];
                    if (AllLines[i].Contains("SelectedPlatformIndex=") && AllLines[i][0] != '#') SelectedPlatformIndex = int.Parse(AllLines[i].Split('=')[1]);
                    if (AllLines[i].Contains("LastFileOpenedEditor=") && AllLines[i][0] != '#') LastFileOpenedEditor = AllLines[i].Split('=')[1];
                    if (AllLines[i].Contains("LogsCommands=") && AllLines[i][0] != '#') darkCheckBoxLogsCommands.Checked = bool.Parse(AllLines[i].Split('=')[1]);
                }

                if (J2534AdapterName != "") LoadAdapter();
                LoadPlatform();
            }
        }
        catch (Exception ex)
        {
            this.method_1("--------------------------------------");
            this.method_1("Could not load Settings.txt with error: " + Environment.NewLine + ex);
        }
    }

    public void SaveSettings()
    {
        string SettingTxt = "";
        SettingTxt = SettingTxt + "J2534AdapterName=" + J2534AdapterName + Environment.NewLine;
        SettingTxt = SettingTxt + "SelectedPlatformIndex=" + SelectedPlatformIndex.ToString() + Environment.NewLine;
        SettingTxt = SettingTxt + "LastFileOpenedEditor=" + LastFileOpenedEditor + Environment.NewLine;
        SettingTxt = SettingTxt + "LogsCommands=" + darkCheckBoxLogsCommands.Checked.ToString() + Environment.NewLine;
        string TFilePath = Application.StartupPath + @"\Settings.txt";
        File.Create(TFilePath).Dispose();
        File.WriteAllText(TFilePath, SettingTxt);
    }

    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
    {
        Timer1.Stop();

        DarkMessageBox.Show(this, "To access the most lastest updates and features, purchase the software at:" + Environment.NewLine + "https://www.bmdevs-shop.com/", "Outdated!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        Editortable_0 = new Editortable(ref GForm_Main_0);
        Class_Checksums_0 = new Class_Checksums();
        Class_Checksums_0.Load(ref GForm_Main_0);
        Class_RWD.Load(ref GForm_Main_0);
        this.Text = this.Text + " (" + Version + ")";
        Editortable_0.ClassEditor_0.LoadSupportedECUDefinitions();
        darkComboBoxUnlockMode.SelectedIndex = 0;
        LoadSettings();

        this.method_1("--------------------------------------");
        this.Enabled = true;
    }

    /*private void TimerEventProcessorJ2534(Object myObject, EventArgs myEventArgs)
    {
        CheckConnected();
    }*/

    private void method_0(string string_3)
    {
        if (this.darkTextBox_0.InvokeRequired)
        {
            Delegate0 delegate_ = new Delegate0(this.method_0);
            this.method_22(delegate_, new object[]
            {
                string_3
            });
            return;
        }
        this.darkTextBox_0.Text = string_3;
    }

    public void method_Log(string string_3)
    {
        this.darkTextBox_0.Text += string_3;

        //Send to ROM Editor logs
        Editortable_0.method_Log(string_3);
    }

    public void ClearLogs()
    {
        this.darkTextBox_0.Text = "";
    }

    public void method_1(string string_3)
    {
        try
        {
            Console.WriteLine(string_3);
            Class5 @class = new Class5();
            @class.gform0_0 = this;
            @class.string_0 = string_3;
            this.darkTextBox_0.BeginInvoke(new MethodInvoker(@class.method_0));

            //Send to ROM Editor logs
            Editortable_0.method_1(string_3);
            Application.DoEvents();
        }
        catch { }
    }


    private void method_2(object sender, EventArgs e)
    {
        APIInfo[] apilist = APIFactory.GetAPIList();
        for (int i = 0; i < apilist.Length; i++)
        {
            APIInfo apiinfo = apilist[i];
            this.method_1("--------------------------------------");
            this.method_1("Adapter name:" + apiinfo.Name);
            this.method_1("File name:" + apiinfo.Filename);
            this.method_1("API details: " + apiinfo.Details);
        }
    }

    public void LoadAdapter()
    {
        APIInfo[] apilist = APIFactory.GetAPIList();
        for (int i = 0; i < apilist.Length; i++)
        {
            APIInfo apiinfo = apilist[i];
            if (apiinfo.Filename == J2534AdapterName)
            {
                this.method_1("J2534 adapter selected: " + apiinfo.Name);
                i = apilist.Length;
            }
        }

        darkButton1.Enabled = true;
        darkButton_4.Enabled = true;
        darkButton_0.Enabled = true;
    }

    private void method_3(object sender, EventArgs e)
    {
        GForm_J2534Select gform = new GForm_J2534Select();
        if (gform.ShowDialog() == DialogResult.OK)
        {
            J2534AdapterName = gform.APIInfo_0.Filename;
            GForm_Main_0.SaveSettings();
            gform.Dispose();
            LoadAdapter();
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

    /*public void ConnectJ2534()
    {
        if (J2534Connected) return;

        try
        {
            api = APIFactory.GetAPI(J2534AdapterName);
            device = api.GetDevice("");
            channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false);
            LoadJ2534Channel(channel);
            J2534Connected = true;
            TimerJ2534.Start();
            this.method_1("J2534 adapter connected");
            label1.ForeColor = Color.DarkGreen;
            label1.Text = "Connected";
        }
        catch
        {
            Disconnect();
        }
    }

    public void Disconnect()
    {
        this.method_1("J2534 adapter disconnected!");
        channel = null;
        device = null;
        api = null;
        J2534Connected = false;

        TimerJ2534.Stop();

        this.darkButton_DownloadROM.Enabled = false;
        this.darkButton_Unlock41.Enabled = false;
        this.darkButton_Unlock01.Enabled = false;
        this.darkButton_FlashRom.Enabled = false;
        this.darkButton_FlashFW.Enabled = false;
        this.darkButtonJ2534Command.Enabled = false;
        VehicleConnected = false;

        label1.ForeColor = Color.Red;
        label1.Text = "Disconnected";
    }

    public void CheckConnected() 
    {
        if (J2534Connected)
        {
            //Console.WriteLine("checking");
            try
            {
                //Console.WriteLine(device.);
            }
            catch(Exception ex)
            {
                this.method_1("ERROR: " + ex);
                Disconnect();
                return;
            }

            if (channel.IsDisposed || device.IsDisposed || api.IsDisposed)
            {
                Disconnect();
            }
        }
    }*/

    private void darkButton1_Click(object sender, EventArgs e)
    {
        //ECU_Unlocked = false;
        this.Enabled = false;
        this.darkButton_DownloadROM.Enabled = false;
        this.darkButton_FlashRom.Enabled = false;
        this.darkButton_FlashFW.Enabled = false;
        this.darkButtonJ2534Command.Enabled = false;
        VehicleConnected = false;

        this.darkTextBox_1.Text = "";
        this.darkTextBox_2.Text = "";

        //ConnectJ2534();
        //darkButtonJ2534Command.Enabled = true;  //########
        //darkButton_FlashFW.Enabled = true;  //########

        using (API api = APIFactory.GetAPI(J2534AdapterName))
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
                            0x22,     //Read Data by ID (F190)
                            0xF1,
                            0x90
                        };
                        byte[] Received = SendJ2534Message(channel, arraySend1, 5, true);
                        if (BadResponceReceived)
                        {
                            Class_ODB.NegativeResponse negativeResponse = (Class_ODB.NegativeResponse)Received[6];
                            if (negativeResponse == Class_ODB.NegativeResponse.REQUEST_OUT_OF_RANGE)
                            {
                                //we have responce from ecu, it mean the ecu is connected but just cant proceed to reading VIN
                                //enable other buttons (read/write & j2534 commands for further use)
                                this.method_1("We detected the ECU but could not read the VIN!");
                                this.darkButtonJ2534Command.Enabled = true;
                                VehicleConnected = true;
                                SetButtons();
                            }
                            this.Enabled = true;
                            return;
                        }

                        int num4 = smethod_0(Received, byte_1);
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
                            0x22,    //Read Data by ID (F181)
                            0xF1,
                            0x81
                        };
                        Received = SendJ2534Message(channel, arraySend1, 5, true);
                        if (BadResponceReceived)
                        {
                            this.Enabled = true;
                            return;
                        }

                        int num6 = smethod_0(Received, byte_0);
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
                            this.darkButtonJ2534Command.Enabled = true;
                            VehicleConnected = true;
                            SetButtons();
                            this.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                DarkMessageBox.Show(this, ex.Message);
            }
        }
        this.Enabled = true;
        return;
    }

    public void method_4(int int_0)
    {
        try
        {
            Class5_Status @class = new Class5_Status();
            @class.gform0_0 = this;
            @class.string_0 = "Reading: " + int_0.ToString() + "%";
            this.darkLabel_7.BeginInvoke(new MethodInvoker(@class.method_0));

            Class5_Percent @class2 = new Class5_Percent();
            @class2.gform0_0 = this;
            @class2.Percentt = int_0;
            this.darkProgressBar_0.BeginInvoke(new MethodInvoker(@class2.method_0));
        }
        catch { }
        Application.DoEvents();
    }


    public void method_5(int int_0)
    {
        try
        {
            Class5_Status @class = new Class5_Status();
            @class.gform0_0 = this;
            @class.string_0 = "Writing: " + int_0.ToString() + "%";
            this.darkLabel_7.BeginInvoke(new MethodInvoker(@class.method_0));

            Class5_Percent @class2 = new Class5_Percent();
            @class2.gform0_0 = this;
            @class2.Percentt = int_0;
            this.darkProgressBar_0.BeginInvoke(new MethodInvoker(@class2.method_0));
        }
        catch { }
        Application.DoEvents();
    }

    public void ResetProgressBar()
    {
        Class5_Status @class = new Class5_Status();
        @class.gform0_0 = this;
        @class.string_0 = "Status";
        this.darkLabel_7.BeginInvoke(new MethodInvoker(@class.method_0));

        Class5_Percent @class2 = new Class5_Percent();
        @class2.gform0_0 = this;
        @class2.Percentt = 0;
        this.darkProgressBar_0.BeginInvoke(new MethodInvoker(@class2.method_0));

        Application.DoEvents();
    }


    private void method_6(object sender, ProgressChangedEventArgs e)
    {
        string text = e.UserState as string;
        this.darkLabel_8.Text = text;
        this.method_4(e.ProgressPercentage);
    }

    private void method_7(object sender, RunWorkerCompletedEventArgs e)
    {
        if (this.byte_7 != null)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Honda Rom Dump|*.Bin";
            saveFileDialog.FileName = this.darkTextBox_2.Text;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                this.Enabled = true;
                return;
            }
            File.WriteAllBytes(saveFileDialog.FileName, this.byte_7);
            this.method_1("File saved: " + saveFileDialog.FileName);
            DarkMessageBox.Show(this, "Successfully Saved File!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        this.Enabled = true;
    }

    public byte[] SendJ2534Message(Channel channel, byte[] MessageBytes, int receivelenght, bool Logs)
    {
        try
        {
            BadResponceReceived = false;

            byte[] arrayCommand = new byte[]
            {
                0x18,
                0xDA,
                ECU_Byte,  //-> 0x10|0x11
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
            if (Logs && darkCheckBoxLogsCommands.Checked) this.method_1("Send: " + smethod_1(messageCommands.Data));

            //Receive message
            bool SendPendingResp = false;
            int RetryCount = 0;
            int RetryMaxCount = (10 * 1000) / 5;   //->Max ~10sec for responce pending, each try take 5ms
            while (true)
            {
                if (SendPendingResp && Logs) this.method_1("Waiting for responce..");
                if (RetryCount >= RetryMaxCount)
                {
                    this.method_1("Timeout waiting for response");
                    BadResponceReceived = true;
                    break;
                }

                GetMessageResults messagesReceived = channel.GetMessages(receivelenght, 1000);

                if (messagesReceived.Result.IsOK() ||
                    (messagesReceived.Result.IsNotOK() && messagesReceived.Messages.Length > 0 && messagesReceived.Messages.Length != receivelenght))
                {
                    int IndexReceived = 1;
                    foreach (SAE.J2534.Message message3 in messagesReceived.Messages)
                    {
                        //Gather Negative Responce
                        int num2 = smethod_2(message3.Data, this.byte_5, 0); //looking for 0x11, 0x7F
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
                                if (Logs && darkCheckBoxLogsCommands.Checked) this.method_1("Received:" + smethod_1(message3.Data));
                                if (!SendPendingResp && Logs) this.method_1("Response pending...");
                                SendPendingResp = true;
                                receivelenght = 1;
                                Thread.Sleep(5);
                                RetryCount++;
                                continue;
                            }
                            else
                            {
                                if (Logs && darkCheckBoxLogsCommands.Checked) this.method_1("Received:" + smethod_1(message3.Data));
                                this.method_1("BAD Response: " + str2 + "|" + negativeResponse.ToString());
                                BadResponceReceived = true;
                                //break;
                                return message3.Data; //still return the responce
                            }
                        }
                        if (IndexReceived >= receivelenght)
                        {
                            if (Logs && darkCheckBoxLogsCommands.Checked) this.method_1("Received:" + smethod_1(message3.Data));
                            return message3.Data;
                        }
                        IndexReceived++;
                    }
                }


                if (messagesReceived.Result.IsNotOK())
                {
                    if (SendPendingResp)
                    {
                        Thread.Sleep(5);
                        RetryCount++;
                        continue;
                    }
                    else
                    {
                        //Retry receiving 1x responce before fully return null responce
                        if (receivelenght > 1 && messagesReceived.Messages.Length == 0)
                        {
                            receivelenght = 1;
                            continue;
                        }
                        //return null responce
                        this.method_1("Result NOT OK!!");
                        BadResponceReceived = true;
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.method_1("--------------------------------------");
            this.method_1("Could not send J2534 message with error: " + Environment.NewLine + ex);
        }
        return null;
    }

    public void method_ReadROM(object sender, DoWorkEventArgs e)
    {
        using (API api = APIFactory.GetAPI(J2534AdapterName))
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
                        byte[] Received = SendJ2534Message(channel, arraySend1, 3, true);
                        if (BadResponceReceived) return;
                        if (Received != null) this.method_1("Diag Mode Set");
                        //################################################################
                        byte SeedSendByte = this.Unlocking_Mode;
                        arraySend1 = new byte[] { 0x27, SeedSendByte };
                        this.method_1("Requesting Seed");
                        Received = SendJ2534Message(channel, arraySend1, 3, true);
                        if (BadResponceReceived) return;
                        //################################################################
                        byte[] byte_ = new byte[] { 0x67, SeedSendByte };
                        byte[] array6 = new byte[4];
                        bool TwoBytesMode = false;
                        byte b = 1;
                        //################################################################
                        if (Received != null)
                        {
                            int num = smethod_2(Received, byte_, 0);
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
                                        this.method_1("Security Request - Seed Bytes:" + smethod_1(array6));
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
                            this.method_1("Security Request - Key to Send:" + smethod_1(bytes));

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
                            Received = SendJ2534Message(channel, array8, 3, true);
                            if (BadResponceReceived) return;

                            if (Received != null)
                            {
                                int num = smethod_2(Received, byte_2, 0);       //looking for 0x67, 0x42
                                if (num > 0)
                                {
                                    this.method_1("Security Authorized: ECU Unlocked");
                                    ECU_Unlocked = true;
                                }
                                else
                                {
                                    this.method_1("Recv:" + smethod_1(Received));
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
                            this.byte_7 = this.method_10(channel, this.backgroundWorker_1); //READ ECU ROM
                            stopwatch.Stop();
                            TimeSpan timeSpan = TimeSpan.FromMilliseconds((double)stopwatch.ElapsedMilliseconds);
                            this.method_1("Successfully read " + this.byte_7.Length + " bytes within flash memory in " + timeSpan.Minutes + ":" + timeSpan.Seconds);
                            this.backgroundWorker_1.ReportProgress(0);
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
        //READ ECU ROM FUNCTION
        DateTime now = DateTime.Now;

        Class6 class6 = new Class6();
        class6.gform0_0 = this;
        class6.byte_0 = new byte[1];
        class6.uint_0 = 4U;
        this.darkTextBox_0.BeginInvoke(new MethodInvoker(class6.method_0));

        Class7 class7 = new Class7();
        class7.class6_0 = class6;
        class7.uint_0 = 0U;

        while ((ulong)class7.uint_0 <= (ulong)((long)class9_0.ReadingSize))
        {
            Application.DoEvents();
            TimeSpan timeSpan = TimeSpan.FromTicks(DateTime.Now.Subtract(now).Ticks * ((long)class9_0.ReadingSize - (long)((ulong)(class7.uint_0 + 1U))) / (long)((ulong)(class7.uint_0 + 1U)));
            this.method_12(class7.uint_0, class7.class6_0.uint_0, out class7.class6_0.byte_0, channel_0);
            string userState = "Time Remaining:" + string.Format("{0:mm\\:ss}", timeSpan);
            this.SetDownloadRate((long)((ulong)class7.uint_0));
            if ((long)class7.class6_0.byte_0.Length != (long)((ulong)class7.class6_0.uint_0))
            {
                Control control = this.darkTextBox_0;
                MethodInvoker method;
                if ((method = class7.class6_0.methodInvoker_0) == null)
                {
                    method = (class7.class6_0.methodInvoker_0 = new MethodInvoker(class7.class6_0.method_1));
                }
                control.BeginInvoke(method);
            }
            try
            {
                Buffer.BlockCopy(class7.class6_0.byte_0, 0, this.byte_7, (int)class7.uint_0, class7.class6_0.byte_0.Length);
                goto IL_213;
            }
            catch
            {
                this.darkTextBox_0.BeginInvoke(new MethodInvoker(class7.method_0));
                goto IL_213;
            }
            goto IL_1B4;
        IL_1CD:
            if (backgroundWorker_1 != null)
            {
                backgroundWorker_1.ReportProgress((int)(class7.uint_0 / (float)class9_0.ReadingSize * 100f), userState);
            }
            class7.uint_0 += class7.class6_0.uint_0;
            continue;
        IL_1B4:
            this.darkTextBox_0.BeginInvoke(new MethodInvoker(class7.method_1));
            goto IL_1CD;
        IL_213:
            if (class7.uint_0 % 256U == 0U)
            {
                goto IL_1B4;
            }
            goto IL_1CD;
        }
        return this.byte_7;
    }

    private void SetText1(string Texxxt) 
    {
        Class8_Text1 @class = new Class8_Text1();
        @class.gform0_0 = this;
        @class.ThisText = Texxxt;
        this.darkLabel_5.BeginInvoke(new MethodInvoker(@class.method_0));
    }

    private void SetText2(string Texxxt)
    {
        Class8_Text2 @class = new Class8_Text2();
        @class.gform0_0 = this;
        @class.ThisText = Texxxt;
        this.darkLabel_8.BeginInvoke(new MethodInvoker(@class.method_0));
    }

    private void SetDownloadRate(long long_1)
    {
        Class8 @class = new Class8();
        @class.gform0_0 = this;
        if (this.long_0 != 0L)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = now - this.dateTime_0;
            long num = long_1 - this.long_0;
            @class.double_0 = (double)num / timeSpan.TotalSeconds;
            @class.TotalSeconds_0 = timeSpan.TotalSeconds;
            this.long_0 = long_1;
            this.dateTime_0 = now;
            this.darkLabel_5.BeginInvoke(new MethodInvoker(@class.method_0));
            return;
        }
        this.dateTime_0 = DateTime.Now;
        this.long_0 = long_1;
    }

    private void SetUploadRate(long long_1)
    {
        Class8_Upload @class = new Class8_Upload();
        @class.gform0_0 = this;
        if (this.long_0 != 0L)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = now - this.dateTime_0;
            long num = long_1 - this.long_0;
            @class.double_0 = (double)num / timeSpan.TotalSeconds;
            @class.TotalSeconds_0 = timeSpan.TotalSeconds;
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
            ECU_Byte,
            99
        };

        byte[] Received = SendJ2534Message(channel_0, arraySend1, 3, true);
        if (BadResponceReceived) return;

        if (Received != null)
        {
        //if (messages.Result != ResultCode.DEVICE_NOT_CONNECTED)
        //{
            int num = smethod_2(Received, byte_13, 0);
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
        this.Enabled = false;
        if (J2534AdapterName.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                this.Enabled = true;
                return;
            }
            J2534AdapterName = gform.APIInfo_0.Filename;
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
        using (API api = APIFactory.GetAPI(J2534AdapterName))
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
                    //DarkTextBox darkTextBox = this.darkTextBox_0;
                    //darkTextBox.Text = darkTextBox.Text + smethod_1(this.byte_7) + Environment.NewLine;
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
        if (J2534AdapterName == string.Empty)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                return;
            }
            J2534AdapterName = gform.APIInfo_0.Filename;
            gform.Dispose();
        }
        try
        {
            using (API api = APIFactory.GetAPI(J2534AdapterName))
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
                                this.darkTextBox_0.AppendText(string.Format("message[{0}]: ", j) + smethod_1(list[j]) + Environment.NewLine);
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

    private void method_17(object sender, EventArgs e)
    {
        this.Enabled = false;
        if (J2534AdapterName.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                this.Enabled = true;
                return;
            }
            J2534AdapterName = gform.APIInfo_0.Filename;
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
                byte_ToWrite = Class_Checksums_0.VerifyChecksumFullBin(byte_ToWrite);

                GForm_Warning GForm_Warning_0 = new GForm_Warning();
                if (GForm_Warning_0.ShowDialog() == DialogResult.Yes)
                //if (DarkMessageBox.Show("Are you sure you want to write this file to ECU?", "Flash Tool", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GForm_Warning_0 = null;
                    this.backgroundWorker_0 = new BackgroundWorker();
                    this.backgroundWorker_0.WorkerReportsProgress = true;
                    this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork_1);
                    this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.method_18);
                    this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_19);
                    this.backgroundWorker_0.RunWorkerAsync();
                }
            }
            else
            {
                this.Enabled = true;
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
        this.Enabled = false;
        if (J2534AdapterName.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                this.Enabled = true;
                return;
            }
            J2534AdapterName = gform.APIInfo_0.Filename;
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
                if (Path.GetExtension(string_Filename).ToLower().Contains("gz"))
                {
                    byte_ToWrite = Class_RWD.Decompress(string_Filename);
                }
                else if (Path.GetExtension(string_Filename).ToLower().Contains("bin"))
                {
                    byte_ToWrite = File.ReadAllBytes(string_Filename);

                    //remake bin to rwd
                    string ThisECU = this.Editortable_0.ExtractECUNameFromThisFile(byte_ToWrite);
                    string ThissPathh = Application.StartupPath + @"\RWDFileMaker.txt";
                    if (File.Exists(ThissPathh))
                    {
                        string[] AllLines = File.ReadAllLines(ThissPathh);
                        bool FoundData = false;
                        for (int i = 0; i < AllLines.Length; i++)
                        {
                            if (AllLines[i].Contains("|"))
                            {
                                string[] SplittedParm = AllLines[i].Split('|');
                                for (int k = 0; k < SplittedParm.Length; k++)
                                {
                                    if (SplittedParm[k] == ThisECU)
                                    {
                                        string StartFileBytesString = SplittedParm[SplittedParm.Length - 2];
                                        string EncoderBytesString = SplittedParm[SplittedParm.Length - 1];
                                        if (StartFileBytesString.Contains(",") && EncoderBytesString.Contains(","))
                                        {
                                            string[] AllBytesString = StartFileBytesString.Split(',');
                                            string[] AllEncoderBytesString = EncoderBytesString.Split(',');

                                            byte[] AllStartBytes = new byte[AllBytesString.Length];
                                            byte[] AllEncoderBytes = new byte[AllEncoderBytesString.Length];

                                            for (int m = 0; m < AllBytesString.Length; m++)
                                            {
                                                AllStartBytes[m] = (byte) int.Parse(AllBytesString[m], System.Globalization.NumberStyles.HexNumber);
                                            }
                                            for (int m = 0; m < AllEncoderBytesString.Length; m++)
                                            {
                                                AllEncoderBytes[m] = (byte)int.Parse(AllEncoderBytesString[m], System.Globalization.NumberStyles.HexNumber);
                                            }

                                            Class_RWD.RWD_encrypted_StartFile = AllStartBytes;
                                            Class_RWD.EncodersBytes = AllEncoderBytes;
                                            Class_RWD._firmware_encrypted = Class_RWD.ConvertBIN2RWD_EncryptedFirmware(byte_ToWrite);
                                            Class_RWD.LoadRWDHeadersFromStartBytesArray(AllStartBytes);

                                            FoundData = true;
                                        }
                                        else
                                        {
                                            this.method_1("Problem while getting RWD start file byte array");
                                            return;
                                        }

                                        k = SplittedParm.Length;
                                        i = AllLines.Length;
                                    }
                                }
                            }
                        }

                        if (!FoundData)
                        {
                            this.method_1("Problem while trying to convert .bin into .rwd!");
                            this.method_1("Try to convert manually the .bin to .rwd and then flash the .rwd file!");
                            return;
                        }
                    }
                    else
                    {
                        this.method_1("Can't find the file: " + ThissPathh);
                        return;
                    }
                }
                else
                {
                    byte_ToWrite = File.ReadAllBytes(string_Filename);
                }
                WritingBinaryMode = false;

                //Decrypt firmware file and get needed variable (Decryption byte)
                Class_RWD.LoadRWD(dialog.FileName, false, false, true, true);

                //###############################
                //Get Checksum and Fix it -> checksums of rwd files should mostly always be fixed, no need to fix them!
                //###############################

                GForm_Warning GForm_Warning_0 = new GForm_Warning();
                if (GForm_Warning_0.ShowDialog() == DialogResult.Yes)
                //if (DarkMessageBox.Show("Are you sure you want to write this file to ECU?", "Flash Tool", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GForm_Warning_0 = null;
                    this.backgroundWorker_0 = new BackgroundWorker();
                    this.backgroundWorker_0.WorkerReportsProgress = true;
                    this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork_1);
                    this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.method_18);
                    this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.method_19);
                    this.backgroundWorker_0.RunWorkerAsync();
                }
            }
            else
            {
                this.Enabled = true;
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
            ECU_Byte       //0x00
        };
        messageFilter.FlowControl = new byte[]
        {
            24,     //0x18
            218,    //0xDA
            ECU_Byte,      //0x00  -> 0x10|0x11
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
        using (API api = APIFactory.GetAPI(J2534AdapterName))
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
                        byte[] Received = SendJ2534Message(channel, arraySend1, 3, true);
                        if (BadResponceReceived) return;
                        if (Received != null) this.method_1("Diag Mode Set");
                        //################################################################
                        byte SeedSendByte = this.Unlocking_Mode;
                        arraySend1 = new byte[] { 0x27, SeedSendByte };
                        this.method_1("Requesting Seed");
                        Received = SendJ2534Message(channel, arraySend1, 3, true);
                        if (BadResponceReceived) return;
                        //################################################################
                        byte[] byte_ = new byte[] { 0x67, SeedSendByte };
                        byte[] array6 = new byte[4];
                        bool TwoBytesMode = false;
                        byte b = 1;
                        //################################################################
                        if (Received != null)
                        {
                            int num = smethod_2(Received, byte_, 0);
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
                                        this.method_1("Security Request - Seed Bytes:" + smethod_1(array6));
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
                            this.method_1("Security Request - Key to Send:" + smethod_1(bytes));

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
                            Received = SendJ2534Message(channel, array8, 3, true);
                            if (BadResponceReceived) return;

                            if (Received != null)
                            {
                                int num = smethod_2(Received, byte_2, 0);       //looking for 0x67, 0x42
                                if (num > 0)
                                {
                                    this.method_1("Security Authorized: ECU Unlocked");
                                    ECU_Unlocked = true;
                                }
                                else
                                {
                                    this.method_1("Recv:" + smethod_1(Received));
                                }
                            }
                        }
                        else
                        {
                            this.method_1("Result NOT OK!!");
                        }
                        //################################################################
                        //Better to throw the exception before we proceed to erasing the ecu
                        uint memory_address = Class_RWD.start;
                        uint memory_size = Class_RWD.size;
                        byte memory_address_bytes = 0x04;
                        byte memory_size_bytes = 0x04;
                        if (memory_address >= Math.Pow(2, memory_address_bytes * 8)) throw new Exception(string.Format("invalid memory_address: 0x{0}", memory_address.ToString("X4")));
                        if (memory_size >= Math.Pow(2, memory_size_bytes * 8)) throw new Exception(string.Format("invalid memory_size: 0x{0}", memory_size.ToString("X4")));


                        if (!ECU_Unlocked)
                        {
                            this.method_1("ECU is NOT Unlocked!");
                            return;
                        }
                        else
                        {
                            device.SetProgrammingVoltage(Pin.PIN_12, 5000);
                            Stopwatch stopwatch = new Stopwatch();

                            bool FlashedECU = false;

                            //Firmware (.rwd) writing mode
                            if (!WritingBinaryMode)
                            {
                                //###################
                                //Set Programming Mode
                                arraySend1 = new byte[] { 0x10, 0x02 };
                                Received = SendJ2534Message(channel, arraySend1, 3, true);
                                if (BadResponceReceived) return;
                                if (Received != null) this.method_1("Programming Mode Set!");
                                //###################
                                //Erase Memory
                                arraySend1 = new byte[] {0x31, 0x01, 0xFF, 0x00};
                                Received = SendJ2534Message(channel, arraySend1, 3, true);
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

                                Received = SendJ2534Message(channel, arraySend1, 3, true);
                                if (BadResponceReceived) return;

                                if (Received != null)
                                {
                                    this.method_1("Write data by identifier Set!");
                                }
                                //###################
                                //Request Download
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
                                for (int i = 0; i < memory_address_bytes; i++)
                                {
                                    uint b2 = (memory_address >> ((memory_address_bytes - i - 1) * 8)) & 0xFF;
                                    arraySend1[3 + i] = (byte) b2;
                                }

                                for (int i = 0; i < memory_size_bytes; i++)
                                {
                                    uint b2 = (memory_size >> ((memory_size_bytes - i - 1) * 8)) & 0xFF;
                                    arraySend1[3 + memory_address_bytes + i] = (byte)b2;
                                }

                                Received = SendJ2534Message(channel, arraySend1, 3, true);
                                if (BadResponceReceived) return;

                                if (Received != null)
                                {
                                    this.method_1("Request download started");

                                    int MaxBytesLenght = Received.Length - 6;
                                    var max_num_bytes = 0;
                                    if (MaxBytesLenght >= 1 && MaxBytesLenght <= 4)
                                    {
                                        for (int i = 0; i < MaxBytesLenght; i++) max_num_bytes = (max_num_bytes << 8) | Received[6 + i];
                                    }
                                    else
                                    {
                                        throw new Exception("invalid max_num_bytes_len: " + MaxBytesLenght);
                                    }

                                    // account for service id and block sequence count (one byte each)
                                    var block_size = max_num_bytes;
                                    var chunk_size = block_size - 2;
                                    var cnt = 0;

                                    //Perform Write firmware to ECU
                                    this.method_1("Flash started...");
                                    stopwatch.Start();
                                    DateTime now = DateTime.Now;
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

                                        Received = SendJ2534Message(channel, arrayCommandFinal, 3, false);
                                        int Percent = ((i * 100) / Class_RWD._firmware_encrypted.Length);
                                        this.method_5(Percent);

                                        TimeSpan timeSpanRemain = TimeSpan.FromTicks(DateTime.Now.Subtract(now).Ticks * ((long)Class_RWD._firmware_encrypted.Length - (long)((ulong)(i + 1U))) / (long)((ulong)(i + 1U)));
                                        SetText2("Time Remaining:" + string.Format("{0:mm\\:ss}", timeSpanRemain));
                                        SetUploadRate(i);
                                    }
                                    this.method_1("Flash finished!");
                                    FlashedECU = true;
                                    stopwatch.Stop();
                                }
                            }

                            SetText2("");

                            if (WritingBinaryMode)
                            {
                                stopwatch.Start();
                                this.WriteROMtoECU(channel, byte_ToWrite, this.backgroundWorker_0);
                                FlashedECU = true;
                                stopwatch.Stop();
                            }

                            if (!WritingBinaryMode)
                            {
                                //Request transfer exit && routine control: check dependencies
                                this.method_13_Close(channel);
                            }

                            if (FlashedECU)
                            {
                                TimeSpan timeSpan = TimeSpan.FromMilliseconds((double)stopwatch.ElapsedMilliseconds);
                                this.method_1("Successfully write " + this.byte_7.Length + " bytes within flash memory in " + timeSpan.Minutes + ":" + timeSpan.Seconds);
                            }
                            this.backgroundWorker_0.ReportProgress(0);
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
        byte[] buffer2 = new byte[] { ECU_Byte, 0x77 };

        byte[] Received = SendJ2534Message(channel_0, arraySend1, 3, true);
        if (BadResponceReceived) return;

        if (Received != null)
        {
            int num3 = smethod_2(Received, buffer2, 0);
            if (num3 > 0) this.method_1("Transfer Exited");

            arraySend1 = new byte[] {0x31, 0x01, 0xff, 0x01};
            Received = SendJ2534Message(channel_0, arraySend1, 3, true);
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
            ECU_Byte,
            0xF1,
            0x36,
            byte_6X
        };
        Buffer.BlockCopy(byte_5X, int_23, data, 6, int_25);
        SAE.J2534.Message message = new SAE.J2534.Message(data, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
        channel_0.SendMessage(message);
        bool flag = false;
        byte[] buffer2 = new byte[] { ECU_Byte, 0x76, byte_6X };
        while (!flag)
        {
            GetMessageResults messages = channel_0.GetMessages(5);
            int num = -1;
            if (messages.Result != ResultCode.DEVICE_NOT_CONNECTED)
            {
                foreach (SAE.J2534.Message message2 in messages.Messages)
                {
                    num = smethod_2(message2.Data, buffer2, 0);
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
        try
        {
            this.darkLabel_5.Text = "";
        }
        catch { }
        this.method_1("Waiting ~4sec before closing flashing");
        /*int Waited = 0;
        while (Waited < 7000)
        {
            Thread.Sleep(1);
            Waited++;
            Application.DoEvents();
        }*/
        Thread.Sleep(4000);
        this.Enabled = true;
        DarkMessageBox.Show(this, "Flash Finished writing!");

        //Connect again to ecu
        darkButton1_Click(null, null);
    }

    public void LoadPlatform()
    {
        GForm_PlatformSelect gform = new GForm_PlatformSelect();
        gform.GetPlatformAt(SelectedPlatformIndex);
        try
        {
            class9_0 = gform.Class9_0;
        }
        catch
        {
            return;
        }
        gform.Dispose();
        ECU_Byte = class9_0.ECU_Byte;
        byte_0[3] = class9_0.ECU_Byte;
        byte_1[3] = class9_0.ECU_Byte;
        byte_2[3] = class9_0.ECU_Byte;
        this.byte_5[0] = class9_0.ECU_Byte;
        //Array.Resize<byte>(ref byte_4, class9_0.FirmwareSize);
        Array.Resize<byte>(ref this.byte_7, class9_0.RomSize);
        this.byte_7 = Enumerable.Repeat<byte>(byte.MaxValue, class9_0.RomSize).ToArray<byte>();
        this.darkButton_2.Enabled = true;

        this.method_1("Platform selected: " + class9_0.Processor + "-" + class9_0.RomSize_String + " | " + class9_0.TransmissionType + " (" + class9_0.ECU_Byte_String + ")");
    }


    private void method_20(object sender, EventArgs e)
    {
        GForm_PlatformSelect gform = new GForm_PlatformSelect();
        if (gform.ShowDialog() == DialogResult.OK)
        {
            try
            {
                class9_0 = gform.Class9_0;
            }
            catch
            {
                return;
            }
            gform.Dispose();
            SelectedPlatformIndex = class9_0.PlatformIndex;
            GForm_Main_0.SaveSettings();
            LoadPlatform();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GForm_Main));
            this.darkTextBox_0 = new DarkUI.Controls.DarkTextBox();
            this.darkButton_3 = new DarkUI.Controls.DarkButton();
            this.darkButton_2 = new DarkUI.Controls.DarkButton();
            this.darkButton_DownloadROM = new DarkUI.Controls.DarkButton();
            this.darkButton_0 = new DarkUI.Controls.DarkButton();
            this.darkGroupBox_0 = new DarkUI.Controls.DarkGroupBox();
            this.darkCheckBoxLogsCommands = new DarkUI.Controls.DarkCheckBox();
            this.darkComboBoxUnlockMode = new DarkUI.Controls.DarkComboBox();
            this.darkButton5 = new DarkUI.Controls.DarkButton();
            this.darkButton_FlashFW = new DarkUI.Controls.DarkButton();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkButton_FlashRom = new DarkUI.Controls.DarkButton();
            this.darkButton_6 = new DarkUI.Controls.DarkButton();
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
            this.darkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkGroupBox_0.SuspendLayout();
            this.DarkgroupBox1.SuspendLayout();
            this.darkGroupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkTextBox_0
            // 
            this.darkTextBox_0.ContextMenuStrip = this.contextMenuStrip1;
            this.darkTextBox_0.Location = new System.Drawing.Point(218, 63);
            this.darkTextBox_0.Multiline = true;
            this.darkTextBox_0.Name = "darkTextBox_0";
            this.darkTextBox_0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.darkTextBox_0.Size = new System.Drawing.Size(399, 372);
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
            this.darkButton_DownloadROM.Location = new System.Drawing.Point(6, 75);
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
            this.darkGroupBox_0.Controls.Add(this.darkCheckBoxLogsCommands);
            this.darkGroupBox_0.Controls.Add(this.darkComboBoxUnlockMode);
            this.darkGroupBox_0.Controls.Add(this.darkButton5);
            this.darkGroupBox_0.Controls.Add(this.darkButton_FlashFW);
            this.darkGroupBox_0.Controls.Add(this.darkButton1);
            this.darkGroupBox_0.Controls.Add(this.darkButton_FlashRom);
            this.darkGroupBox_0.Controls.Add(this.darkButton_DownloadROM);
            this.darkGroupBox_0.Location = new System.Drawing.Point(7, 116);
            this.darkGroupBox_0.Name = "darkGroupBox_0";
            this.darkGroupBox_0.Size = new System.Drawing.Size(204, 215);
            this.darkGroupBox_0.TabIndex = 56;
            this.darkGroupBox_0.TabStop = false;
            this.darkGroupBox_0.Text = "J2534 OBD2 Adapter Controls";
            // 
            // darkCheckBoxLogsCommands
            // 
            this.darkCheckBoxLogsCommands.AutoSize = true;
            this.darkCheckBoxLogsCommands.Location = new System.Drawing.Point(39, 192);
            this.darkCheckBoxLogsCommands.Name = "darkCheckBoxLogsCommands";
            this.darkCheckBoxLogsCommands.Size = new System.Drawing.Size(136, 17);
            this.darkCheckBoxLogsCommands.TabIndex = 71;
            this.darkCheckBoxLogsCommands.Text = "Logs J2534 Commands";
            this.darkCheckBoxLogsCommands.CheckedChanged += new System.EventHandler(this.darkCheckBoxLogsCommands_CheckedChanged);
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
            this.darkComboBoxUnlockMode.Location = new System.Drawing.Point(6, 48);
            this.darkComboBoxUnlockMode.Name = "darkComboBoxUnlockMode";
            this.darkComboBoxUnlockMode.Size = new System.Drawing.Size(192, 21);
            this.darkComboBoxUnlockMode.TabIndex = 70;
            this.darkComboBoxUnlockMode.SelectedIndexChanged += new System.EventHandler(this.darkComboBoxUnlockMode_SelectedIndexChanged);
            // 
            // darkButton5
            // 
            this.darkButton5.Checked = false;
            this.darkButton5.Location = new System.Drawing.Point(6, 162);
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
            this.darkButton_FlashFW.Location = new System.Drawing.Point(6, 133);
            this.darkButton_FlashFW.Name = "darkButton_FlashFW";
            this.darkButton_FlashFW.Size = new System.Drawing.Size(192, 23);
            this.darkButton_FlashFW.TabIndex = 60;
            this.darkButton_FlashFW.Text = "Flash Firmware (.bin|.rwd|.gz)";
            this.darkButton_FlashFW.Click += new System.EventHandler(this.darkButton3_Click);
            // 
            // darkButton1
            // 
            this.darkButton1.Checked = false;
            this.darkButton1.Enabled = false;
            this.darkButton1.Location = new System.Drawing.Point(6, 19);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Size = new System.Drawing.Size(192, 23);
            this.darkButton1.TabIndex = 56;
            this.darkButton1.Text = "Connect ECU";
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // darkButton_FlashRom
            // 
            this.darkButton_FlashRom.Checked = false;
            this.darkButton_FlashRom.Enabled = false;
            this.darkButton_FlashRom.Location = new System.Drawing.Point(6, 104);
            this.darkButton_FlashRom.Name = "darkButton_FlashRom";
            this.darkButton_FlashRom.Size = new System.Drawing.Size(192, 23);
            this.darkButton_FlashRom.TabIndex = 54;
            this.darkButton_FlashRom.Text = "Flash Full Rom (.bin)";
            this.darkButton_FlashRom.Click += new System.EventHandler(this.method_17);
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
            this.darkLabel_0.Location = new System.Drawing.Point(218, 13);
            this.darkLabel_0.Name = "darkLabel_0";
            this.darkLabel_0.Size = new System.Drawing.Size(68, 13);
            this.darkLabel_0.TabIndex = 57;
            this.darkLabel_0.Text = "Vin Number: ";
            // 
            // darkLabel_1
            // 
            this.darkLabel_1.AutoSize = true;
            this.darkLabel_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_1.Location = new System.Drawing.Point(218, 39);
            this.darkLabel_1.Name = "darkLabel_1";
            this.darkLabel_1.Size = new System.Drawing.Size(76, 13);
            this.darkLabel_1.TabIndex = 58;
            this.darkLabel_1.Text = "Calibration ID: ";
            // 
            // darkLabel_4
            // 
            this.darkLabel_4.AutoSize = true;
            this.darkLabel_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel_4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_4.Location = new System.Drawing.Point(536, 474);
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
            this.darkLabel_5.Location = new System.Drawing.Point(12, 480);
            this.darkLabel_5.Name = "darkLabel_5";
            this.darkLabel_5.Size = new System.Drawing.Size(49, 20);
            this.darkLabel_5.TabIndex = 51;
            this.darkLabel_5.Text = "TEXT";
            // 
            // darkTextBox_1
            // 
            this.darkTextBox_1.Location = new System.Drawing.Point(294, 10);
            this.darkTextBox_1.Name = "darkTextBox_1";
            this.darkTextBox_1.ReadOnly = true;
            this.darkTextBox_1.Size = new System.Drawing.Size(323, 20);
            this.darkTextBox_1.TabIndex = 63;
            // 
            // darkTextBox_2
            // 
            this.darkTextBox_2.Location = new System.Drawing.Point(294, 36);
            this.darkTextBox_2.Name = "darkTextBox_2";
            this.darkTextBox_2.ReadOnly = true;
            this.darkTextBox_2.Size = new System.Drawing.Size(323, 20);
            this.darkTextBox_2.TabIndex = 64;
            // 
            // darkProgressBar_0
            // 
            this.darkProgressBar_0.Location = new System.Drawing.Point(98, 504);
            this.darkProgressBar_0.Name = "darkProgressBar_0";
            this.darkProgressBar_0.Size = new System.Drawing.Size(519, 23);
            this.darkProgressBar_0.TabIndex = 67;
            // 
            // darkLabel_7
            // 
            this.darkLabel_7.AutoSize = true;
            this.darkLabel_7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_7.Location = new System.Drawing.Point(14, 509);
            this.darkLabel_7.Name = "darkLabel_7";
            this.darkLabel_7.Size = new System.Drawing.Size(37, 13);
            this.darkLabel_7.TabIndex = 68;
            this.darkLabel_7.Text = "Status";
            // 
            // darkLabel_8
            // 
            this.darkLabel_8.AutoSize = true;
            this.darkLabel_8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_8.Location = new System.Drawing.Point(228, 483);
            this.darkLabel_8.Name = "darkLabel_8";
            this.darkLabel_8.Size = new System.Drawing.Size(35, 13);
            this.darkLabel_8.TabIndex = 69;
            this.darkLabel_8.Text = "TEXT";
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
            this.DarkgroupBox1.Controls.Add(this.darkButton3);
            this.DarkgroupBox1.Controls.Add(this.darkButton2);
            this.DarkgroupBox1.Location = new System.Drawing.Point(7, 337);
            this.DarkgroupBox1.Name = "DarkgroupBox1";
            this.DarkgroupBox1.Size = new System.Drawing.Size(204, 109);
            this.DarkgroupBox1.TabIndex = 70;
            this.DarkgroupBox1.TabStop = false;
            this.DarkgroupBox1.Text = "File Controls";
            // 
            // darkButton6
            // 
            this.darkButton6.Checked = false;
            this.darkButton6.Location = new System.Drawing.Point(6, 77);
            this.darkButton6.Name = "darkButton6";
            this.darkButton6.Size = new System.Drawing.Size(192, 23);
            this.darkButton6.TabIndex = 69;
            this.darkButton6.Text = "Open ROM Editor";
            this.darkButton6.Click += new System.EventHandler(this.darkButton6_Click);
            // 
            // darkButton4
            // 
            this.darkButton4.Checked = false;
            this.darkButton4.Location = new System.Drawing.Point(695, 135);
            this.darkButton4.Name = "darkButton4";
            this.darkButton4.Size = new System.Drawing.Size(192, 23);
            this.darkButton4.TabIndex = 68;
            this.darkButton4.Text = "Fix Checksums(broken)";
            this.darkButton4.Visible = false;
            this.darkButton4.Click += new System.EventHandler(this.darkButton4_Click);
            // 
            // darkTextBoxJ2534Command
            // 
            this.darkTextBoxJ2534Command.Location = new System.Drawing.Point(313, 443);
            this.darkTextBoxJ2534Command.Name = "darkTextBoxJ2534Command";
            this.darkTextBoxJ2534Command.Size = new System.Drawing.Size(230, 20);
            this.darkTextBoxJ2534Command.TabIndex = 72;
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(218, 446);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(92, 13);
            this.darkLabel1.TabIndex = 71;
            this.darkLabel1.Text = "J2534 Command: ";
            // 
            // darkButtonJ2534Command
            // 
            this.darkButtonJ2534Command.Checked = false;
            this.darkButtonJ2534Command.Enabled = false;
            this.darkButtonJ2534Command.Location = new System.Drawing.Point(549, 441);
            this.darkButtonJ2534Command.Name = "darkButtonJ2534Command";
            this.darkButtonJ2534Command.Size = new System.Drawing.Size(68, 23);
            this.darkButtonJ2534Command.TabIndex = 70;
            this.darkButtonJ2534Command.Text = "Send";
            this.darkButtonJ2534Command.Click += new System.EventHandler(this.darkButtonJ2534Command_Click);
            // 
            // darkGroupBox2
            // 
            this.darkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkGroupBox2.Controls.Add(this.darkButton_3);
            this.darkGroupBox2.Controls.Add(this.darkButton_2);
            this.darkGroupBox2.Controls.Add(this.darkButton_6);
            this.darkGroupBox2.Location = new System.Drawing.Point(7, 4);
            this.darkGroupBox2.Name = "darkGroupBox2";
            this.darkGroupBox2.Size = new System.Drawing.Size(204, 108);
            this.darkGroupBox2.TabIndex = 73;
            this.darkGroupBox2.TabStop = false;
            this.darkGroupBox2.Text = "OBD2 Adapter & Car Platform";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // clearLogsToolStripMenuItem
            // 
            this.clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem";
            this.clearLogsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.clearLogsToolStripMenuItem.Text = "Clear Logs";
            this.clearLogsToolStripMenuItem.Click += new System.EventHandler(this.clearLogsToolStripMenuItem_Click);
            // 
            // GForm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 536);
            this.Controls.Add(this.darkButton4);
            this.Controls.Add(this.darkGroupBox2);
            this.Controls.Add(this.darkButtonJ2534Command);
            this.Controls.Add(this.darkTextBoxJ2534Command);
            this.Controls.Add(this.darkLabel1);
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
            this.MinimumSize = new System.Drawing.Size(645, 575);
            this.Name = "GForm_Main";
            this.Text = "Honda&Acura CANBUS/J2534/OBD2 Reflash Tools";
            this.Load += new System.EventHandler(this.GForm_Main_Load);
            this.darkGroupBox_0.ResumeLayout(false);
            this.darkGroupBox_0.PerformLayout();
            this.DarkgroupBox1.ResumeLayout(false);
            this.darkGroupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }


    static GForm_Main()
    {
    }


    IAsyncResult method_22(Delegate delegate_0, object[] object_0)
    {
        return base.BeginInvoke(delegate_0, object_0);
    }


    public static string J2534AdapterName = string.Empty;
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


    public static byte ECU_Byte = 16;
    public static byte[] byte_ToWrite = new byte[] { };
    //public static byte[] byte_4 = new byte[2097152];


    private byte[] byte_5 = new byte[]
    {
        ECU_Byte,
        127
    };

    private byte[] byte_6 = new byte[2];
    private byte[] byte_7;

    private static byte[] byte_8 = new byte[]
    {
        ECU_Byte,
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



    private delegate void Delegate0(string text);


    [CompilerGenerated]
    private sealed class Class5
    {
        public Class5()
        {
        }
        internal void method_0()
        {
            try
            {
                this.gform0_0.darkTextBox_0.AppendText(this.string_0 + Environment.NewLine);
            }
            catch
            {
                this.gform0_0.darkTextBox_0.Clear();
                this.gform0_0.darkTextBox_0.AppendText(this.string_0 + Environment.NewLine);
            }
        }
        public GForm_Main gform0_0;
        public string string_0;
    }


    [CompilerGenerated]
    private sealed class Class5_Status
    {
        public Class5_Status()
        {
        }
        internal void method_0()
        {
            try
            {
                this.gform0_0.darkLabel_7.Text = this.string_0 + "  ";
            }
            catch
            {
            }
        }
        public GForm_Main gform0_0;
        public string string_0;
    }

    [CompilerGenerated]
    private sealed class Class5_Percent
    {
        public Class5_Percent()
        {
        }
        internal void method_0()
        {
            try
            {
                this.gform0_0.darkProgressBar_0.Value = this.Percentt;
            }
            catch
            {
            }
        }
        public GForm_Main gform0_0;
        public int Percentt;
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
        public Class6 class6_0;
    }


    [CompilerGenerated]
    private sealed class Class8
    {
        public Class8()
        {
        }
        internal void method_0()
        {
            double RatePerSecond = (this.double_0 / TotalSeconds_0) / 100;
            this.gform0_0.darkLabel_5.Text = "Download Rate: " + RatePerSecond.ToString("0") + " bytes/s  ";
        }
        public GForm_Main gform0_0;
        public double double_0;
        public double TotalSeconds_0;
    }

    [CompilerGenerated]
    private sealed class Class8_Upload
    {
        public Class8_Upload()
        {
        }
        internal void method_0()
        {
            double RatePerSecond = (this.double_0 / TotalSeconds_0) / 100;
            this.gform0_0.darkLabel_5.Text = "Upload Rate: " + RatePerSecond.ToString("0") + " bytes/s  ";
        }
        public GForm_Main gform0_0;
        public double double_0;
        public double TotalSeconds_0;
    }

    [CompilerGenerated]
    private sealed class Class8_Text1
    {
        public Class8_Text1()
        {
        }
        internal void method_0()
        {
            this.gform0_0.darkLabel_5.Text = ThisText + "  ";
        }
        public GForm_Main gform0_0;
        public string ThisText;
    }

    [CompilerGenerated]
    private sealed class Class8_Text2
    {
        public Class8_Text2()
        {
        }
        internal void method_0()
        {
            this.gform0_0.darkLabel_8.Text = ThisText + "  ";
        }
        public GForm_Main gform0_0;
        public string ThisText;
    }

    public void darkButton2_Click_1(object sender, EventArgs e)
    {
        this.openFileDialog1.Filter = "Honda Compressed RWD Firmware|*.gz;*.rwd";
        this.openFileDialog1.DefaultExt = "*.gz";
        DialogResult result = openFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            Class_RWD.LoadRWD(openFileDialog1.FileName, true, true, true, true);
        }
    }

    private void GForm_Main_Load(object sender, EventArgs e)
    {

    }

    public void darkButton3_Click_1(object sender, EventArgs e)
    {
        //Add a function to convert full bin to rwd also????

        GForm_ConvertBIN gform = new GForm_ConvertBIN();
        if (gform.ShowDialog() == DialogResult.OK)
        {
            string ThisB = gform.FileBIN;
            string ThisR = gform.FileRWD;
            gform.Dispose();

            Class_RWD.ConvertBIN2RWD(ThisB, ThisR);
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
                byte[] NewFilesBytes = Class_Checksums_0.VerifyChecksumFullBin(FilesBytes);
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
                        Class_RWD.LoadRWD(openFileDialog1.FileName, true, false, true, true);
                    }
                }
                else
                {
                    Class_RWD.BootloaderSum = (byte)BtSumInt;
                }

                byte[] NewFilesBytes = Class_Checksums_0.VerifyChecksumFWBin(FilesBytes);
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
        using (API api = APIFactory.GetAPI(J2534AdapterName))
        {
            try
            {
                using (Device device = api.GetDevice(""))
                {
                    using (Channel channel = device.GetChannel(Protocol.ISO15765, Baud.CAN, ConnectFlag.CAN_29BIT_ID, false))
                    {
                        LoadJ2534Channel(channel);

                        SendJ2534Message(channel, GetBytesArrayFromCommandText(), 3, true);
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

    private void darkCheckBoxLogsCommands_CheckedChanged(object sender, EventArgs e)
    {
        SaveSettings();
    }

    private void clearLogsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ClearLogs();
        this.Editortable_0.ClearLogs();
    }

    /*READ_DATA_BY_IDENTIFIER
    UDS_SVC_PARAM_DI_BSIDID         0xF180  // bootSoftwareIdentificationDataIdentifier
    UDS_SVC_PARAM_DI_ASIDID         0xF181  // applicationSoftwareIdentificationDataIdentifier
    UDS_SVC_PARAM_DI_ADIDID         0xF182  // applicationDataIdentificationDataIdentifier
    UDS_SVC_PARAM_DI_BSFPDID        0xF183  // bootSoftwareIdentificationDataIdentifier
    UDS_SVC_PARAM_DI_ASFPDID        0xF184  // applicationSoftwareFingerprintDataIdentifier
    UDS_SVC_PARAM_DI_ADFPDID        0xF185  // applicationDataFingerprintDataIdentifier
    UDS_SVC_PARAM_DI_ADSDID         0xF186  // activeDiagnosticSessionDataIdentifier
    UDS_SVC_PARAM_DI_VMSPNDID       0xF187  // vehicleManufacturerSparePartNumberDataIdentifier
    UDS_SVC_PARAM_DI_VMECUSNDID     0xF188  // vehicleManufacturerECUSoftwareNumberDataIdentifier
    UDS_SVC_PARAM_DI_VMECUSVNDID    0xF189  // vehicleManufacturerECUSoftwareVersionNumberDataIdentifier
    UDS_SVC_PARAM_DI_SSIDDID        0xF18A  // systemSupplierIdentifierDataIdentifier
    UDS_SVC_PARAM_DI_ECUMDDID       0xF18B  // ECUManufacturingDateDataIdentifier
    UDS_SVC_PARAM_DI_ECUSNDID       0xF18C  // ECUSerialNumberDataIdentifier
    UDS_SVC_PARAM_DI_SFUDID         0xF18D  // supportedFunctionalUnitsDataIdentifier
    UDS_SVC_PARAM_DI_VMKAPNDID      0xF18E  // vehicleManufacturerKitAssemblyPartNumberDataIdentifier
    UDS_SVC_PARAM_DI_VINDID         0xF190  // VINDataIdentifier
    UDS_SVC_PARAM_DI_VMECUHNDID     0xF191  // vehicleManufacturerECUHardwareNumberDataIdentifier
    UDS_SVC_PARAM_DI_SSECUHWNDID    0xF192  // systemSupplierECUHardwareNumberDataIdentifier
    UDS_SVC_PARAM_DI_SSECUHWVNDID   0xF193  // systemSupplierECUHardwareVersionNumberDataIdentifier
    UDS_SVC_PARAM_DI_SSECUSWNDID    0xF194  // systemSupplierECUSoftwareNumberDataIdentifier
    UDS_SVC_PARAM_DI_SSECUSWVNDID   0xF195  // systemSupplierECUSoftwareVersionNumberDataIdentifier
    UDS_SVC_PARAM_DI_EROTANDID      0xF196  // exhaustRegulationOrTypeApprovalNumberDataIdentifier
    UDS_SVC_PARAM_DI_SNOETDID       0xF197  // systemNameOrEngineTypeDataIdentifier
    UDS_SVC_PARAM_DI_RSCOTSNDID     0xF198  // repairShopCodeOrTesterSerialNumberDataIdentifier
    UDS_SVC_PARAM_DI_PDDID          0xF199  // programmingDateDataIdentifier
    UDS_SVC_PARAM_DI_CRSCOCESNDID   0xF19A  // calibrationRepairShopCodeOrCalibrationEquipmentSerialNumberDataIdentifier
    UDS_SVC_PARAM_DI_CDDID          0xF19B  // calibrationDateDataIdentifier
    UDS_SVC_PARAM_DI_CESWNDID       0xF19C  // calibrationEquipmentSoftwareNumberDataIdentifier
    UDS_SVC_PARAM_DI_EIDDID         0xF19D  // ECUInstallationDateDataIdentifier
    UDS_SVC_PARAM_DI_ODXFDID        0xF19E  // ODXFileDataIdentifier
    UDS_SVC_PARAM_DI_EDID           0xF19F  // entityDataIdentifier*/
}
