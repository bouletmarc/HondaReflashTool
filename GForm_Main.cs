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
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using SAE.J2534;


public class GForm_Main : DarkForm
{
    public GForm_Main()
    {
        //Console.WriteLine(379890608U.ToString("X8"));
        //Console.WriteLine(3219675757U.ToString("X8"));
        //Console.WriteLine(BitConverter.ToUInt32(new byte[] { 0x23, 0xff, 0x0d, 0xae }, 0).ToString());

        this.InitializeComponent();

        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;
        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;
        this.darkTextBox_0.Text = this.darkTextBox_0.Text + Environment.NewLine;
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


    private void method_1(string string_3)
    {
        Console.Write(string_3);
        GForm_Main.Class5 @class = new GForm_Main.Class5();
        @class.gform0_0 = this;
        @class.string_0 = string_3;
        this.darkTextBox_0.BeginInvoke(new MethodInvoker(@class.method_0));
    }


    private void method_2(object sender, EventArgs e)
    {
        APIInfo[] apilist = APIFactory.GetAPIList();
        APIInfo apiinfo = apilist[0];
        DarkTextBox darkTextBox = this.darkTextBox_0;
        Console.Write(apiinfo.Name + Environment.NewLine);
        Console.Write("Filename:" + apiinfo.Filename + Environment.NewLine);
        Console.Write(apiinfo.Details + Environment.NewLine);
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
            return;
        }
        this.darkTextBox_0.Text = "Couldn't open device selection form";
    }


    private void darkButton1_Click(object sender, EventArgs e)
    {
        using (API api = APIFactory.GetAPI(GForm_Main.string_0))
        {
            try
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


                        byte[] array2 = new byte[]
                        {
                                24,     //0x18
                                218,    //0xDA
                                0,      //0x00  -> 0x10|0x11
                                241,    //0xF1
                                34,     //0x22  -> Read Data by ID (F181)
                                241,    //0xF1
                                129     //0x81
                        };
                        array2[2] = GForm_Main.byte_3;
                        SAE.J2534.Message message = new SAE.J2534.Message(array2, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
                        byte[] array3 = new byte[]
                        {
                                24,     //0x18
                                218,    //0xDA
                                0,      //0x00  -> 0x10|0x11
                                241,    //0xF1
                                34,     //0x22  -> Read Data by ID (F190)
                                241,    //0xF1
                                144     //0x90
                        };
                        array3[2] = GForm_Main.byte_3;
                        SAE.J2534.Message message2 = new SAE.J2534.Message(array3, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
                        SConfig[] config = new SConfig[]
                        {
                                new SConfig(Parameter.LOOP_BACK, 1),
                                new SConfig(Parameter.DATA_RATE, 500000)
                        };
                        channel.SetConfig(config);
                        int i = 0;
                        int num = 0;
                        int num2 = 0;
                        this.method_1(Environment.NewLine);
                        this.method_1("Send:" + GForm_Main.smethod_1(message2.Data) + Environment.NewLine);
                        channel.SendMessage(message2);

                        //#############################################################
                        while (true)
                        {
                            if (num >= 5)
                            {
                                num = 0;
                                channel.SendMessage(message);
                                this.method_1("Send:" + GForm_Main.smethod_1(message.Data) + Environment.NewLine);
                                while (true)
                                {
                                    if (num >= 5)
                                    {
                                        if (num2 == 1)
                                        {
                                            this.method_1("Vehicle is in recovery mode?" + Environment.NewLine);
                                            DarkMessageBox.Show(this, "Failed to retrieve vin number, assuming recovery mode, read disabled", "RECOVERY MODE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                            //this.darkButton_1.Enabled = false;
                                        }
                                        else if (num2 != 2)
                                        {
                                            DarkMessageBox.Show(this, "ECU was not detected. \n\rMake sure you have selected the correct platform and the vehicle is on and your device is plugged in.\n\rProvided you have checked these things. Please send a message to the discord group or the page with your vehicle \n\rDomestic Market, Make, Model,Year,Transmission, and Device you are using to Connect.", "Failed to detect Ecu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                        else
                                        {
                                            this.darkButton_1.Enabled = true;
                                            this.darkButton2.Enabled = true;
                                        }
                                        break;
                                    }

                                    GetMessageResults messages = channel.GetMessages(1, 0x3e8);
                                    if (messages.Result.IsOK())
                                    {
                                        foreach (SAE.J2534.Message message4 in messages.Messages)
                                        {
                                            this.method_1("Recv:" + GForm_Main.smethod_1(message4.Data) + Environment.NewLine);

                                            int num6 = GForm_Main.smethod_0(message4.Data, byte_0);
                                            if (num6 != -1)
                                            {
                                                byte[] bytes = new byte[0x10];
                                                Array.Copy(message4.Data, 7, bytes, 0, 0x10);//error here
                                                this.darkTextBox_2.Text = Encoding.ASCII.GetString(bytes);   //Display CAL_ID Number
                                                this.method_1("ID:" + Encoding.ASCII.GetString(bytes) + Environment.NewLine);
                                                this.method_1("Vehicle is Online" + Environment.NewLine);
                                                num2 = 2;
                                                num = 5;
                                            }
                                        }
                                    }
                                    num++;
                                }
                                break;
                            }

                            GetMessageResults results = channel.GetMessage();
                            if (results.Result.IsOK())
                            {
                                foreach (SAE.J2534.Message message3 in results.Messages)
                                {
                                    this.method_1("Recv:" + GForm_Main.smethod_1(message3.Data) + Environment.NewLine);

                                    int num4 = GForm_Main.smethod_0(message3.Data, byte_1);
                                    if (num4 != -1)
                                    {
                                        byte[] bytes = new byte[0x10];
                                        Array.Copy(message3.Data, 8, bytes, 0, 0x10);
                                        this.darkTextBox_1.Text = Encoding.ASCII.GetString(bytes);  //Display VIN number
                                        this.method_1("VIN:" + Encoding.ASCII.GetString(bytes) + Environment.NewLine);
                                        num2 = 1;
                                        num = 5;
                                    }
                                }
                            }
                            num++;
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
    }


    public void method_5(int int_0)
    {
        this.darkProgressBar_0.Value = int_0;
        this.darkLabel_7.Text = "Writing: " + int_0.ToString() + "%";
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
        DarkMessageBox.Show(this, "Successfully Saved File!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.darkButton_1.Enabled = true;
        this.darkButton2.Enabled = true;
    }

    private void darkButton2_Click(object sender, EventArgs e)
    {

    }

    public void method_9(object sender, DoWorkEventArgs e)
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
                    byte[] array2 = new byte[]
                    {
                        24,     //0x18
                        218,    //0xDA
                        0,      //0x00  -> 0x10|0x11
                        241,    //0xF1
                        16,     //0x10
                        3       //0x03      Not supposed to be 02 or FB?? ##########################################
                    };
                    array2[2] = GForm_Main.byte_3;
                    SAE.J2534.Message message = new SAE.J2534.Message(array2, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
                    byte[] array3 = new byte[]
                    {
                        24,     //0x18
                        218,    //0xDA
                        0,      //0x00  -> 0x10|0x11
                        241,    //0xF1
                        39,     //0x27
                        65      //0x41     Not supposed to be 05?? -> could be 0x01 0x03 0x05 0x07 or 0x41
                    };
                    //byte SeedSendByte = 0x01;
                    byte SeedSendByte = 0x41;
                    array3[2] = GForm_Main.byte_3;
                    array3[5] = SeedSendByte;
                    SAE.J2534.Message message2 = new SAE.J2534.Message(array3, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
                    SConfig[] config = new SConfig[]
                    {
                        new SConfig(Parameter.LOOP_BACK, 1),
                        new SConfig(Parameter.DATA_RATE, 500000)
                    };
                    channel.SetConfig(config);
                    device.SetProgrammingVoltage(Pin.PIN_12, 5000);
                    channel.SendMessage(message);
                    this.backgroundWorker_0.ReportProgress(0, "TX Bytes:" + GForm_Main.smethod_1(message.Data) + Environment.NewLine);

                    this.method_1("Send:" +GForm_Main.smethod_1(message.Data) + Environment.NewLine);
                    GetMessageResults messages = channel.GetMessages(3, 1000);
                    if (messages.Result.IsOK())
                    {
                        this.method_1("Diag Mode Set" + Environment.NewLine);
                        this.backgroundWorker_0.ReportProgress(0, "Diag Mode Set" + Environment.NewLine);
                        foreach (SAE.J2534.Message message3 in messages.Messages)
                        {
                            this.backgroundWorker_0.ReportProgress(0, "RX Bytes:" + GForm_Main.smethod_1(message3.Data) + Environment.NewLine);
                            this.method_1("Recv:" + GForm_Main.smethod_1(message3.Data) + Environment.NewLine);
                        }
                    }
                    else
                    {
                        this.method_1("Result NOT OK(#1)!!" + Environment.NewLine);
                    }
                    channel.SendMessage(message2);
                    this.method_1("Requesting Seed" + Environment.NewLine);
                    this.backgroundWorker_0.ReportProgress(0, "Requesting Seed");
                    this.backgroundWorker_0.ReportProgress(0, "TX Bytes:" + GForm_Main.smethod_1(message2.Data));
                    this.method_1("Send:" + GForm_Main.smethod_1(message2.Data) + Environment.NewLine);
                    byte[] byte_ = new byte[]
                    {
                        103,    //0x67
                        65      //0x41
                    };
                    byte_[1] = SeedSendByte;    //########################
                    byte[] array6 = new byte[4];
                    bool TwoBytesMode = false;
                    byte b = 1;
                    messages = channel.GetMessages(3, 1000);
                    if (messages.Result.IsOK())
                    {
                        foreach (SAE.J2534.Message message4 in messages.Messages)
                        {
                            this.method_1("Recv:" + GForm_Main.smethod_1(message4.Data) + Environment.NewLine);
                            int num = GForm_Main.smethod_2(message4.Data, byte_, 0);
                            if (num > 0)
                            {
                                if (message4.Data.Length < 10)
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
                                            b = message4.Data[(index + num) + 2];
                                            Array.Reverse(array6);
                                        }

                                        this.method_1("Security Request - Seed Bytes:" + GForm_Main.smethod_1(array6) + Environment.NewLine);
                                        this.backgroundWorker_0.ReportProgress(0, "Security Request - Seed Bytes:" + GForm_Main.smethod_1(array6));
                                        if (!TwoBytesMode)
                                        {
                                            this.method_1("Security Request - Algorithm:" + b.ToString("X2") + Environment.NewLine);
                                            this.backgroundWorker_0.ReportProgress(0, "Security Request - Algorithm:" + b.ToString("X2"));
                                        }
                                        break;
                                    }
                                    array6[index] = message4.Data[(index + num) + 2];
                                    index++;
                                }
                            }
                            this.backgroundWorker_0.ReportProgress(0, "RX Bytes:" + GForm_Main.smethod_1(message4.Data) + Environment.NewLine);
                        }
                    }
                    else
                    {
                        this.method_1("Result NOT OK(#2)!!" + Environment.NewLine);
                    }
                    if (array6[0] != 0)
                    {
                        uint value = 0;
                        if (!TwoBytesMode) 
                        {
                            value = Class_Cypher.GetKey41(BitConverter.ToUInt32(array6, 0), b);
                        }
                        else
                        {
                            value = Class_Cypher.GetKey01(array6, darkTextBox_2.Text);
                        }
                        byte[] bytes = BitConverter.GetBytes(value);

                        this.backgroundWorker_0.ReportProgress(0, "Security Request - Key Bytes from app:"  + GForm_Main.smethod_1(bytes));
                        this.method_1("Security Request - Key to Send:" + GForm_Main.smethod_1(bytes) + Environment.NewLine);

                        byte[] bytes2 = BitConverter.GetBytes(value);

                        byte[] array7 = new byte[]
                        {
                            24,     //0x18
                            218,    //0xDA
                            0,      //0x00  -> 0x10|0x11
                            241,    //0xF1
                            39,     //0x27
                            66      //0x42
                        };
                        array7[2] = GForm_Main.byte_3;
                        array7[5] = (byte) (SeedSendByte + 1);  //####################
                        byte[] array8 = array7;
                        if (!TwoBytesMode) Array.Resize<byte>(ref array8, array8.Length + 5);
                        if (TwoBytesMode) Array.Resize<byte>(ref array8, array8.Length + 2);
                        array8[6] = bytes2[0];  //SecurityKey Byte1
                        array8[7] = bytes2[1];  //SecurityKey Byte2
                        if (!TwoBytesMode)
                        {
                            array8[8] = bytes2[2];  //SecurityKey Byte3
                            array8[9] = bytes2[3];  //SecurityKey Byte4
                            array8[10] = b;         //Algorithm Byte
                        }
                        byte[] byte_2 = new byte[]
                        {
                            103,    //0x67
                            66      //0x42
                        };
                        byte_2[1] = (byte)(SeedSendByte + 1);  //####################
                        SAE.J2534.Message message5 = new SAE.J2534.Message(array8, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
                        this.backgroundWorker_0.ReportProgress(0, "TX Bytes:" +GForm_Main.smethod_1(message5.Data));
                        this.method_1("Send:" +GForm_Main.smethod_1(message5.Data) + Environment.NewLine);
                        channel.SendMessage(message5);
                        bool flag = false;
                        messages = channel.GetMessages(3);
                        if (messages.Result.IsOK())
                        {
                            foreach (SAE.J2534.Message message6 in messages.Messages)
                            {
                                int num = GForm_Main.smethod_2(message6.Data, byte_2, 0);       //looking for 0x67, 0x42
                                int num2 = GForm_Main.smethod_2(message6.Data, this.byte_5, 0); //looking for 0x11, 0x7F
                                if (num2 > 0)
                                {
                                    for (int k = 0; k < 2; k++)
                                    {
                                        this.byte_6[k] = message6.Data[k + num2 + 2];   //0x27, 0x35
                                    }
                                    string str = "Response:" ;
                                    Class_ODB.Mode mode = (Class_ODB.Mode)this.byte_6[0];
                                    string str2 = mode.ToString();
                                    Class_ODB.NegativeResponse negativeResponse = (Class_ODB.NegativeResponse)this.byte_6[1];
                                    this.method_1(str + "|" + str2 + "|" + negativeResponse.ToString() + Environment.NewLine);
                                }
                                if (num > 0)
                                {
                                    this.backgroundWorker_0.ReportProgress(0, "Security Authorized: ECU Unlocked" + Environment.NewLine);
                                    this.method_1("Security Authorized: ECU Unlocked" + Environment.NewLine);
                                    flag = true;
                                }
                                else
                                {
                                    this.method_1("Recv:" +GForm_Main.smethod_1(message6.Data) + Environment.NewLine);
                                    this.backgroundWorker_0.ReportProgress(0, "RX Bytes:" +GForm_Main.smethod_1(message6.Data) + Environment.NewLine);
                                }
                            }
                        }
                        else
                        {
                            this.method_1("Result NOT OK(#3)!!" + Environment.NewLine);
                        }
                        if (!flag)
                        {
                            MessageBox.Show("Failed to Unlock ECU, Check Log");
                        }
                        else
                        {
                            //##################################################################################
                            //##################################################################################
                            if (TwoBytesMode)
                            {
                                byte[] arrayProgrammingCommand = new byte[]
                                {
                                    24,             //0x18
                                    218,            //0xDA
                                    GForm_Main.byte_3,  //0x00  -> 0x10|0x11
                                    241,            //0xF1
                                    16,             //0x10
                                    2               //0x02
                                };
                                SAE.J2534.Message messageProgramming = new SAE.J2534.Message(arrayProgrammingCommand, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
                                channel.SendMessage(messageProgramming);
                                this.method_1("Send:" + GForm_Main.smethod_1(messageProgramming.Data) + Environment.NewLine);

                                GetMessageResults messagesProgramming = channel.GetMessages(3, 1000);
                                if (messagesProgramming.Result.IsOK())
                                {
                                    this.method_1("Programming Mode Set" + Environment.NewLine);
                                    foreach (SAE.J2534.Message message3 in messagesProgramming.Messages)
                                    {
                                        this.method_1("Recv:" + GForm_Main.smethod_1(message3.Data) + Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    this.method_1("Result NOT OK(#1)!!" + Environment.NewLine);
                                }
                                //#################################
                                /*UInt16 testval = 0xF101;
                                byte[] BytesVal = BitConverter.GetBytes(testval);
                                UInt16 Val16 = ToUInt16BE(BytesVal);
                                BytesVal = BitConverter.GetBytes(Val16);*/

                                /*byte[] arrayReadDataIDCommand = new byte[]
                                {
                                    24,             //0x18
                                    218,            //0xDA
                                    GForm0.byte_3,  //0x00  -> 0x10|0x11
                                    241,            //0xF1
                                    0x22,           //0x22  -> Read Data by ID (F101)
                                    0xF1,   //BytesVal[0],    //0xXX
                                    0x01    //BytesVal[1],    //0xXX
                                };
                                SAE.J2534.Message messageReadID = new SAE.J2534.Message(arrayReadDataIDCommand, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);
                                channel.SendMessage(messageReadID);
                                this.method_1("Send:" + GForm0.smethod_1(messageReadID.Data) + Environment.NewLine);

                                GetMessageResults messagesReadID = channel.GetMessages(3, 1000);
                                if (messagesReadID.Result.IsOK())
                                {
                                    this.method_1("read_data_by_identifier Set" + Environment.NewLine);
                                    foreach (SAE.J2534.Message message3 in messagesReadID.Messages)
                                    {
                                        this.method_1("Recv:" + GForm0.smethod_1(message3.Data) + Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    this.method_1("Result NOT OK(#1)!!" + Environment.NewLine);
                                }*/
                            }
                            //##################################################################################
                            //##################################################################################

                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            this.byte_7 = this.method_10(channel, this.backgroundWorker_0);
                            stopwatch.Stop();
                            TimeSpan timeSpan = TimeSpan.FromMilliseconds((double)stopwatch.ElapsedMilliseconds);
                            this.backgroundWorker_0.ReportProgress(0, "Successfully read "+ this.byte_7.Length + "bytes of flash memory in " + timeSpan.Minutes + ":"+ timeSpan.Seconds);
                            device.SetProgrammingVoltage(Pin.PIN_12, -1);
                        }
                    }
                    else
                    {
                        this.method_1("Result NOT OK(#4)!!" + Environment.NewLine);
                    }
                }
            }
        }
    }


    public static int smethod_0(byte[] byte_12, byte[] byte_13)
    {
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
        SAE.J2534.Message message = new SAE.J2534.Message(new byte[]
        {
            24,     //0x18
            218,    //0xDA
            GForm_Main.byte_3,
            241,    //0xF1
            35,     //0x23 -> Read_data_by_address
            20,     //0x14
            (byte)((uint_0 >> 0x18) & 0xff),
            (byte)((uint_0 >> 0x10) & 0xff),
            (byte)((uint_0 >> 8) & 0xff),
            (byte)(uint_0 & 0xff),
            4
        }, TxFlag.CAN_29BIT_ID | TxFlag.ISO15765_FRAME_PAD);

        channel_0.SendMessage(message);
        this.method_1("Send:" + GForm_Main.smethod_1(message.Data) + Environment.NewLine);
        GetMessageResults messages = channel_0.GetMessages(3);
        byte[] byte_13 = new byte[]
        {
            GForm_Main.byte_3,
            99
        };
        if (messages.Result != ResultCode.DEVICE_NOT_CONNECTED)
        {
            foreach (SAE.J2534.Message message2 in messages.Messages)
            {
                this.method_1("Recv:" + GForm_Main.smethod_1(message2.Data) + Environment.NewLine);
                int num = GForm_Main.smethod_2(message2.Data, byte_13, 0);
                if (num > 0)
                {
                    num += 2;
                    Array.Resize<byte>(ref byte_12, message2.Data.Length - num);
                    Array.Copy(message2.Data, num, byte_12, 0, message2.Data.Length - num);
                }
            }
        }
    }


    private void method_13(object sender, EventArgs e)
    {
        //this.darkButton_2.Enabled = false;
        if (GForm_Main.string_0.Length == 0)
        {
            GForm_J2534Select gform = new GForm_J2534Select();
            this.darkButton_1.Enabled = true;
            this.darkButton2.Enabled = true;
            if (gform.ShowDialog() != DialogResult.OK)
            {
                this.darkTextBox_0.Text = "Couldn't open device selection form";
                return;
            }
            GForm_Main.string_0 = gform.APIInfo_0.Filename;
            gform.Dispose();
        }
        this.darkButton_1.Enabled = false;
        this.darkButton2.Enabled = false;
        this.backgroundWorker_0 = new BackgroundWorker();
        this.backgroundWorker_0.WorkerReportsProgress = true;
        this.backgroundWorker_0.DoWork += this.method_9;
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
                    this.byte_7 = this.method_15(channel, this.backgroundWorker_0);
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
            this.darkButton_1.Enabled = true;
            this.darkButton2.Enabled = true;
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


    private void method_17(object sender, EventArgs e)
    {
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
            this.pictureBox_0 = new System.Windows.Forms.PictureBox();
            this.darkTextBox_0 = new DarkUI.Controls.DarkTextBox();
            this.darkButton_3 = new DarkUI.Controls.DarkButton();
            this.darkButton_2 = new DarkUI.Controls.DarkButton();
            this.darkButton_1 = new DarkUI.Controls.DarkButton();
            this.darkButton_0 = new DarkUI.Controls.DarkButton();
            this.darkGroupBox_0 = new DarkUI.Controls.DarkGroupBox();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkButton_6 = new DarkUI.Controls.DarkButton();
            this.darkButton_5 = new DarkUI.Controls.DarkButton();
            this.darkLabel_6 = new DarkUI.Controls.DarkLabel();
            this.darkButton_4 = new DarkUI.Controls.DarkButton();
            this.darkLabel_0 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_1 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_2 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_3 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_4 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_5 = new DarkUI.Controls.DarkLabel();
            this.darkTextBox_1 = new DarkUI.Controls.DarkTextBox();
            this.darkTextBox_2 = new DarkUI.Controls.DarkTextBox();
            this.darkTextBox_3 = new DarkUI.Controls.DarkTextBox();
            this.darkTextBox_4 = new DarkUI.Controls.DarkTextBox();
            this.darkProgressBar_0 = new DarkUI.Controls.DarkProgressBar();
            this.darkLabel_7 = new DarkUI.Controls.DarkLabel();
            this.darkLabel_8 = new DarkUI.Controls.DarkLabel();
            this.darkCheckBox_0 = new DarkUI.Controls.DarkCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_0)).BeginInit();
            this.darkGroupBox_0.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_0
            // 
            this.pictureBox_0.Location = new System.Drawing.Point(11, 337);
            this.pictureBox_0.Name = "pictureBox_0";
            this.pictureBox_0.Size = new System.Drawing.Size(204, 169);
            this.pictureBox_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_0.TabIndex = 52;
            this.pictureBox_0.TabStop = false;
            // 
            // darkTextBox_0
            // 
            this.darkTextBox_0.Location = new System.Drawing.Point(218, 90);
            this.darkTextBox_0.Multiline = true;
            this.darkTextBox_0.Name = "darkTextBox_0";
            this.darkTextBox_0.Size = new System.Drawing.Size(461, 416);
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
            this.darkButton_2.Location = new System.Drawing.Point(6, 97);
            this.darkButton_2.Name = "darkButton_2";
            this.darkButton_2.Size = new System.Drawing.Size(192, 23);
            this.darkButton_2.TabIndex = 48;
            this.darkButton_2.Text = "Select Adapter";
            this.darkButton_2.Click += new System.EventHandler(this.method_3);
            // 
            // darkButton_1
            // 
            this.darkButton_1.Checked = false;
            this.darkButton_1.Enabled = false;
            this.darkButton_1.Location = new System.Drawing.Point(6, 184);
            this.darkButton_1.Name = "darkButton_1";
            this.darkButton_1.Size = new System.Drawing.Size(192, 23);
            this.darkButton_1.TabIndex = 49;
            this.darkButton_1.Text = "Download Honda Rom";
            this.darkButton_1.Click += new System.EventHandler(this.method_13);
            // 
            // darkButton_0
            // 
            this.darkButton_0.Checked = false;
            this.darkButton_0.Enabled = false;
            this.darkButton_0.Location = new System.Drawing.Point(6, 242);
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
            this.darkGroupBox_0.Controls.Add(this.darkButton2);
            this.darkGroupBox_0.Controls.Add(this.darkButton1);
            this.darkGroupBox_0.Controls.Add(this.darkButton_6);
            this.darkGroupBox_0.Controls.Add(this.darkButton_5);
            this.darkGroupBox_0.Controls.Add(this.darkLabel_6);
            this.darkGroupBox_0.Controls.Add(this.darkButton_4);
            this.darkGroupBox_0.Controls.Add(this.darkButton_0);
            this.darkGroupBox_0.Controls.Add(this.darkButton_3);
            this.darkGroupBox_0.Controls.Add(this.darkButton_1);
            this.darkGroupBox_0.Controls.Add(this.darkButton_2);
            this.darkGroupBox_0.Location = new System.Drawing.Point(11, 90);
            this.darkGroupBox_0.Name = "darkGroupBox_0";
            this.darkGroupBox_0.Size = new System.Drawing.Size(204, 416);
            this.darkGroupBox_0.TabIndex = 56;
            this.darkGroupBox_0.TabStop = false;
            this.darkGroupBox_0.Text = "J2534 Controls";
            // 
            // darkButton2
            // 
            this.darkButton2.Checked = false;
            this.darkButton2.Enabled = false;
            this.darkButton2.Location = new System.Drawing.Point(6, 155);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Size = new System.Drawing.Size(192, 23);
            this.darkButton2.TabIndex = 57;
            this.darkButton2.Text = "UNLOCK ECU";
            this.darkButton2.Visible = false;
            this.darkButton2.Click += new System.EventHandler(this.darkButton2_Click);
            // 
            // darkButton1
            // 
            this.darkButton1.Checked = false;
            this.darkButton1.Enabled = false;
            this.darkButton1.Location = new System.Drawing.Point(6, 126);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Size = new System.Drawing.Size(192, 23);
            this.darkButton1.TabIndex = 56;
            this.darkButton1.Text = "Connect ECU";
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // darkButton_6
            // 
            this.darkButton_6.Checked = false;
            this.darkButton_6.Location = new System.Drawing.Point(6, 68);
            this.darkButton_6.Name = "darkButton_6";
            this.darkButton_6.Size = new System.Drawing.Size(192, 23);
            this.darkButton_6.TabIndex = 55;
            this.darkButton_6.Text = "Select ECU";
            this.darkButton_6.Click += new System.EventHandler(this.method_20);
            // 
            // darkButton_5
            // 
            this.darkButton_5.Checked = false;
            this.darkButton_5.Enabled = false;
            this.darkButton_5.Location = new System.Drawing.Point(6, 213);
            this.darkButton_5.Name = "darkButton_5";
            this.darkButton_5.Size = new System.Drawing.Size(192, 23);
            this.darkButton_5.TabIndex = 54;
            this.darkButton_5.Text = "Flash Rom";
            this.darkButton_5.Visible = false;
            this.darkButton_5.Click += new System.EventHandler(this.method_17);
            // 
            // darkLabel_6
            // 
            this.darkLabel_6.AutoSize = true;
            this.darkLabel_6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_6.Location = new System.Drawing.Point(32, 52);
            this.darkLabel_6.Name = "darkLabel_6";
            this.darkLabel_6.Size = new System.Drawing.Size(133, 13);
            this.darkLabel_6.TabIndex = 53;
            this.darkLabel_6.Text = "Read Size(Select Platform)";
            // 
            // darkButton_4
            // 
            this.darkButton_4.Checked = false;
            this.darkButton_4.Enabled = false;
            this.darkButton_4.Location = new System.Drawing.Point(6, 271);
            this.darkButton_4.Name = "darkButton_4";
            this.darkButton_4.Size = new System.Drawing.Size(192, 23);
            this.darkButton_4.TabIndex = 51;
            this.darkButton_4.Text = "Sniff All Traffic";
            this.darkButton_4.Visible = false;
            this.darkButton_4.Click += new System.EventHandler(this.method_16);
            // 
            // darkLabel_0
            // 
            this.darkLabel_0.AutoSize = true;
            this.darkLabel_0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_0.Location = new System.Drawing.Point(8, 13);
            this.darkLabel_0.Name = "darkLabel_0";
            this.darkLabel_0.Size = new System.Drawing.Size(62, 13);
            this.darkLabel_0.TabIndex = 57;
            this.darkLabel_0.Text = "Vin Number";
            // 
            // darkLabel_1
            // 
            this.darkLabel_1.AutoSize = true;
            this.darkLabel_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_1.Location = new System.Drawing.Point(8, 41);
            this.darkLabel_1.Name = "darkLabel_1";
            this.darkLabel_1.Size = new System.Drawing.Size(70, 13);
            this.darkLabel_1.TabIndex = 58;
            this.darkLabel_1.Text = "Calibration ID";
            // 
            // darkLabel_2
            // 
            this.darkLabel_2.AutoSize = true;
            this.darkLabel_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_2.Location = new System.Drawing.Point(109, 67);
            this.darkLabel_2.Name = "darkLabel_2";
            this.darkLabel_2.Size = new System.Drawing.Size(202, 13);
            this.darkLabel_2.TabIndex = 59;
            this.darkLabel_2.Text = "Read address (in hex with preceeding 0x)";
            this.darkLabel_2.Visible = false;
            // 
            // darkLabel_3
            // 
            this.darkLabel_3.AutoSize = true;
            this.darkLabel_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_3.Location = new System.Drawing.Point(457, 67);
            this.darkLabel_3.Name = "darkLabel_3";
            this.darkLabel_3.Size = new System.Drawing.Size(116, 13);
            this.darkLabel_3.TabIndex = 60;
            this.darkLabel_3.Text = "Read Size (Also in hex)";
            this.darkLabel_3.Visible = false;
            // 
            // darkLabel_4
            // 
            this.darkLabel_4.AutoSize = true;
            this.darkLabel_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.darkLabel_4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_4.Location = new System.Drawing.Point(404, 509);
            this.darkLabel_4.Name = "darkLabel_4";
            this.darkLabel_4.Size = new System.Drawing.Size(272, 25);
            this.darkLabel_4.TabIndex = 61;
            this.darkLabel_4.Text = "Copyright 2022 @ BMDevs";
            // 
            // darkLabel_5
            // 
            this.darkLabel_5.AutoSize = true;
            this.darkLabel_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.darkLabel_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel_5.Location = new System.Drawing.Point(214, 514);
            this.darkLabel_5.Name = "darkLabel_5";
            this.darkLabel_5.Size = new System.Drawing.Size(0, 20);
            this.darkLabel_5.TabIndex = 51;
            // 
            // darkTextBox_1
            // 
            this.darkTextBox_1.Location = new System.Drawing.Point(83, 11);
            this.darkTextBox_1.Name = "darkTextBox_1";
            this.darkTextBox_1.ReadOnly = true;
            this.darkTextBox_1.Size = new System.Drawing.Size(596, 20);
            this.darkTextBox_1.TabIndex = 63;
            // 
            // darkTextBox_2
            // 
            this.darkTextBox_2.Location = new System.Drawing.Point(83, 39);
            this.darkTextBox_2.Name = "darkTextBox_2";
            this.darkTextBox_2.ReadOnly = true;
            this.darkTextBox_2.Size = new System.Drawing.Size(596, 20);
            this.darkTextBox_2.TabIndex = 64;
            // 
            // darkTextBox_3
            // 
            this.darkTextBox_3.Location = new System.Drawing.Point(351, 64);
            this.darkTextBox_3.Name = "darkTextBox_3";
            this.darkTextBox_3.Size = new System.Drawing.Size(100, 20);
            this.darkTextBox_3.TabIndex = 65;
            this.darkTextBox_3.Visible = false;
            // 
            // darkTextBox_4
            // 
            this.darkTextBox_4.Location = new System.Drawing.Point(579, 65);
            this.darkTextBox_4.Name = "darkTextBox_4";
            this.darkTextBox_4.Size = new System.Drawing.Size(100, 20);
            this.darkTextBox_4.TabIndex = 66;
            this.darkTextBox_4.Visible = false;
            // 
            // darkProgressBar_0
            // 
            this.darkProgressBar_0.Location = new System.Drawing.Point(98, 537);
            this.darkProgressBar_0.Name = "darkProgressBar_0";
            this.darkProgressBar_0.Size = new System.Drawing.Size(581, 23);
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
            this.darkLabel_8.Location = new System.Drawing.Point(220, 518);
            this.darkLabel_8.Name = "darkLabel_8";
            this.darkLabel_8.Size = new System.Drawing.Size(0, 13);
            this.darkLabel_8.TabIndex = 69;
            // 
            // darkCheckBox_0
            // 
            this.darkCheckBox_0.AutoSize = true;
            this.darkCheckBox_0.Location = new System.Drawing.Point(11, 66);
            this.darkCheckBox_0.Name = "darkCheckBox_0";
            this.darkCheckBox_0.Size = new System.Drawing.Size(81, 17);
            this.darkCheckBox_0.TabIndex = 70;
            this.darkCheckBox_0.Text = "Large Write";
            this.darkCheckBox_0.Visible = false;
            // 
            // GForm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 571);
            this.Controls.Add(this.darkCheckBox_0);
            this.Controls.Add(this.darkLabel_8);
            this.Controls.Add(this.darkLabel_7);
            this.Controls.Add(this.darkProgressBar_0);
            this.Controls.Add(this.darkTextBox_4);
            this.Controls.Add(this.darkTextBox_3);
            this.Controls.Add(this.darkTextBox_2);
            this.Controls.Add(this.darkTextBox_1);
            this.Controls.Add(this.darkLabel_5);
            this.Controls.Add(this.darkLabel_4);
            this.Controls.Add(this.darkLabel_3);
            this.Controls.Add(this.darkLabel_2);
            this.Controls.Add(this.darkLabel_1);
            this.Controls.Add(this.darkLabel_0);
            this.Controls.Add(this.darkGroupBox_0);
            this.Controls.Add(this.darkTextBox_0);
            this.Controls.Add(this.pictureBox_0);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(710, 573);
            this.Name = "GForm_Main";
            this.Text = "Honda CANBUS Tools";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_0)).EndInit();
            this.darkGroupBox_0.ResumeLayout(false);
            this.darkGroupBox_0.PerformLayout();
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


    private DateTime dateTime_0;


    private long long_0;


    private IContainer icontainer_0;


    private PictureBox pictureBox_0;


    private DarkButton darkButton_0;


    private DarkButton darkButton_1;


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


    private DarkLabel darkLabel_6;


    private DarkButton darkButton_5;


    private DarkButton darkButton_6;


    private DarkProgressBar darkProgressBar_0;


    private DarkLabel darkLabel_7;


    private DarkLabel darkLabel_8;
    private DarkButton darkButton1;
    private DarkButton darkButton2;
    private DarkCheckBox darkCheckBox_0;



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
}
