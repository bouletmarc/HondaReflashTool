using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class Class_DefinitionMaker
{
    List<string> AllECUS = new List<string>();
    List<string> AllFoundFunctions = new List<string>();
    List<int> AllFoundAddress = new List<int>();
    List<int> AllFoundAddressX = new List<int>();
    List<int> AllFoundAddressY = new List<int>();


    List<string> AllFileNames = new List<string>();
    List<byte> AllBootLoaderSumBytes = new List<byte>();

    public string FirmwareFolder = "";

    GForm_Main GForm_Main_0;

    public Class_DefinitionMaker(ref GForm_Main GForm_Main_1)
    {
        GForm_Main_0 = GForm_Main_1;
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void CreateDefinitionsFiles()
    {
        string[] AllFiles = Directory.GetFiles(FirmwareFolder, "*.bin");
        foreach (string ThisFile in AllFiles)
        {
            byte[] AllBytes = File.ReadAllBytes(ThisFile);

            //Create a fake bootloader section
            byte[] BufferBytes = new byte[0x8000 + AllBytes.Length];
            for (int i = 0; i < 0x8000; i++) BufferBytes[i] = 0xff;
            for (int i = 0; i < AllBytes.Length; i++) BufferBytes[0x8000 + i] = AllBytes[i];
            AllBytes = BufferBytes;

            bool DoneParameter = false;

            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            int ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 0A 00 0A 00 C8 00"), 16, false);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "VTEC Engagement", ThisAddr, -1, -1);
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("FA 01 2C FF FF 40"), 71, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Revlimiter", ThisAddr, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 1", ThisAddr + 8, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 2", ThisAddr + 16, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 3", ThisAddr + 24, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 4", ThisAddr + 32, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 5", ThisAddr + 36, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 6", ThisAddr + 52, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 7", ThisAddr + 60, -1, -1);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("FA 01 2C FF FF 3A"), 71, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Revlimiter", ThisAddr, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 1", ThisAddr + 8, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 2", ThisAddr + 16, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 3", ThisAddr + 24, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 4", ThisAddr + 32, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 5", ThisAddr + 36, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 6", ThisAddr + 52, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 7", ThisAddr + 60, -1, -1);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 00 00 00 80 00 80 00 00 00 00 00 00"), 84, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Revlimiter", ThisAddr, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 1", ThisAddr + 8, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 2", ThisAddr + 16, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 3", ThisAddr + 24, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 4", ThisAddr + 32, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 5", ThisAddr + 36, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 6", ThisAddr + 52, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 7", ThisAddr + 60, -1, -1);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 32 00 1E 01 2C 00 00 08 66 66 00 00"), -2, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr, -1, -1);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 32 00 1E 02 BC 02 DC 01 2C"), -2, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr, -1, -1);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("01 90 00 14 01 2C 00 00 08 66 66 00 00"), -2, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr, -1, -1);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("01 2C 00 00 08 66 66 00 00"), -6, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr, -1, -1);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("0C 80 0F A0 12 C0 19 00"), 8, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Injector Voltage Compensation", ThisAddr, -1, -1);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("FC 18 FF 38 80 00 80 00"), -92, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Injector Voltage Compensation", ThisAddr, -1, -1);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            //MISSING ON SOME ROMS, HAVE TO CHECK FOR OTHERS BYTES ARRAY
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 1E 00 00 00 03 00 05 00"), -8, false);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "MAF Load Limit", ThisAddr, -1, -1);
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("7F FF F0 60 EF 98"), 182, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Minimum IPW", ThisAddr, -1, -1);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("05 66 05 66 02 00 00 00 00 01"), 36, true);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Minimum IPW", ThisAddr, -1, -1);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            //GET COOLANT TEMP LOCATION
            DoneParameter = false;
            int ThisAddrY = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("01 C2 02 12 02 53 03 20 27 10"), 166, false);
            if (ThisAddrY != -1 && !DoneParameter) DoneParameter = true;
            if (ThisAddrY == -1 && !DoneParameter) ThisAddrY = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("80 00 7F FF 7F FF 7F FF 7F FF"), 286, false);
            if (ThisAddrY != -1 && !DoneParameter) DoneParameter = true;
            if (ThisAddrY == -1 && !DoneParameter) ThisAddrY = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("80 00 FE D4 FF"), 174, false); //MAY CAUSE CERTAIN ISSUE
            if (ThisAddrY != -1 && !DoneParameter) DoneParameter = true;
            //####################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 00 00 00 00 00 00 01 00 1E"), 16, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Idle Speed", ThisAddr, -1, ThisAddrY);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Post Start Idle Speed", ThisAddr + 16, -1, ThisAddrY);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("C8 01 90 03 20 61 A8 00"), -75, true);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Idle Speed", ThisAddr, -1, ThisAddrY);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Post Start Idle Speed", ThisAddr + 16, -1, ThisAddrY);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("01 90 01 90 01 90 FF 38"), 48, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "WOT Determiniation 1(TPS)", ThisAddr, -1, -1);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "WOT Determiniation 2(TPS)", ThisAddr + 24, -1, -1);
                DoneParameter = true;
            }
            //MISSING: WOT Determiniation (MAP)
            //#######################################################################################################################
            //#######################################################################################################################
        }

        GenerateDefinitions();
    }

    private void GenerateDefinitions()
    {
        string BufECUName = "";

        string AllStringFile = "";
        for (int i = 0; i < AllECUS.Count; i++)
        {
            if (BufECUName != AllECUS[i])
            {
                if (BufECUName != "") CreateFile(AllStringFile, BufECUName);
                BufECUName = AllECUS[i];
                AllStringFile = GenerateNewHeader(BufECUName);
                //Console.WriteLine(AllECUS[i] + " | 0x" + AllFoundAddress[i].ToString("X") + " | " + AllFoundFunctions[i]);
            }

            string FoundFunc = AllFoundFunctions[i];
            int FoundAddr = AllFoundAddress[i];
            int FoundAddrX = AllFoundAddressX[i];
            int FoundAddrY = AllFoundAddressY[i];

            if (FoundFunc == "VTEC Engagement")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit2:RPM" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:4x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMin:-10000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:30000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ChangeAmount:10" + Environment.NewLine;
                AllStringFile = AllStringFile + "Headers:Enable Low,Disable Low,Enable High,Disable High" + Environment.NewLine;
                AllStringFile = AllStringFile + "#############################" + Environment.NewLine;
            }

            if (FoundFunc == "Revlimiter" || FoundFunc == "--Revlimiter 1" || FoundFunc == "--Revlimiter 2"
                || FoundFunc == "--Revlimiter 3" || FoundFunc == "--Revlimiter 4" || FoundFunc == "--Revlimiter 5"
                || FoundFunc == "--Revlimiter 6" || FoundFunc == "--Revlimiter 7")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit2:RPM" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:2x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:10000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ChangeAmount:50" + Environment.NewLine;
                AllStringFile = AllStringFile + "#############################" + Environment.NewLine;
            }

            if (FoundFunc == "Speedlimiter")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit2:KPH" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:1x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:255" + Environment.NewLine;
                AllStringFile = AllStringFile + "# MathTable:X/1.609" + Environment.NewLine;
                AllStringFile = AllStringFile + "#############################" + Environment.NewLine;
            }

            if (FoundFunc == "Injector Voltage Compensation")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit1:Volts" + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit2:ms" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:5x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "MathTable:X*0.002" + Environment.NewLine;
                AllStringFile = AllStringFile + "FormatTable:0.00" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMin:-1000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:3000" + Environment.NewLine;
                AllStringFile = AllStringFile + "Headers:6.00,8.00,12.00,14.00,16.00" + Environment.NewLine;
                AllStringFile = AllStringFile + "#############################" + Environment.NewLine;
            }

            if (FoundFunc == "MAF Load Limit")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit1:Mg/Stroke" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:4x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMin:-1000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:4000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ChangeAmount:50" + Environment.NewLine;
                AllStringFile = AllStringFile + "#############################" + Environment.NewLine;
            }

            if (FoundFunc == "Minimum IPW")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit1:Min IPW" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:1x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMin:-6" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:5" + Environment.NewLine;
                AllStringFile = AllStringFile + "ChangeAmount:0.001" + Environment.NewLine;
                AllStringFile = AllStringFile + "MathTable:X*0.002" + Environment.NewLine;
                AllStringFile = AllStringFile + "FormatTable:0.000" + Environment.NewLine;
                AllStringFile = AllStringFile + "#############################" + Environment.NewLine;
            }

            if (FoundFunc == "Idle Speed" || FoundFunc == "Post Start Idle Speed")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                if (FoundAddrY != -1) AllStringFile = AllStringFile + "ROMLocationY:0x" + FoundAddrY.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit1:Coolant Temp" + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit2:RPM" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:8x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMin:-1000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:4000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ChangeAmount:50" + Environment.NewLine;
                if (FoundAddrY != -1) AllStringFile = AllStringFile + "MathY:X/10" + Environment.NewLine;
                AllStringFile = AllStringFile + "#############################" + Environment.NewLine;
            }

            if (FoundFunc == "WOT Determiniation 1(TPS)" || FoundFunc == "WOT Determiniation 2(TPS)")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit1:RPM" + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit2:TPS(%)" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:6x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMin:-50" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:200" + Environment.NewLine;
                AllStringFile = AllStringFile + "MathTable:X*0.005" + Environment.NewLine;
                AllStringFile = AllStringFile + "FormatTable:0.00" + Environment.NewLine;
                AllStringFile = AllStringFile + "ChangeAmount:1" + Environment.NewLine;
                AllStringFile = AllStringFile + "Headers:1000,2000,3000,4000,5000,6000" + Environment.NewLine;
                AllStringFile = AllStringFile + "#############################" + Environment.NewLine;
            }
        }

        CreateFile(AllStringFile, BufECUName);
    }

    private void CreateFile(string AllString, string ThisFile)
    {
        string DirectoryPath = Application.StartupPath + @"\Definitions\Generated";

        if (!Directory.Exists(DirectoryPath)) Directory.CreateDirectory(DirectoryPath);

        File.Create(DirectoryPath + @"\" + ThisFile + ".txt").Dispose();
        File.WriteAllText(DirectoryPath + @"\" + ThisFile + ".txt", AllString);

        GForm_Main_0.method_1("File saved:" + DirectoryPath + @"\" + ThisFile + ".txt");
    }

    private string GenerateNewHeader(string ThisEECU)
    {
        string ReturnStr = "";
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "# THIS FILE AS BEEN GENERATED AUTOMATICLY, ROM LOCATIONS CAN BE WRONG" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "# Supported ECU:" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + ThisEECU + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "# ROM Parameters Definitions:" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;

        return ReturnStr;
    }

    private void AddToList(string ThisECUName, string ThisFunction, int ThisAddr, int ThisAddrX, int ThisAddrY)
    {
        AllECUS.Add(ThisECUName);
        AllFoundFunctions.Add(ThisFunction);
        AllFoundAddress.Add(ThisAddr);
        AllFoundAddressX.Add(ThisAddrX);
        AllFoundAddressY.Add(ThisAddrY);
    }

    public byte[] StringToByteArray(string hex)
    {
        hex = hex.Replace(" ", "");
        return Enumerable.Range(0, hex.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                            .ToArray();
    }

    private int CheckForBytesAndGetAddress(byte[] ThisFileBytes, byte[] CheckThisBytes, int AddressOffset, bool GetLastInstance)
    {
        bool FoundSameBytes = true;
        int LastIndexFound = -1;
        for (int i=0; i < ThisFileBytes.Length; i++)
        {
            FoundSameBytes = true;
            for (int i2 = 0; i2 < CheckThisBytes.Length; i2++)
            {
                try
                {
                    if (ThisFileBytes[i + i2] != CheckThisBytes[i2])
                    {
                        FoundSameBytes = false;
                        i2 = CheckThisBytes.Length;
                    }
                }
                catch
                {
                    //Generally at end of file if causing issue
                    i2 = CheckThisBytes.Length;
                }
            }

            if (FoundSameBytes && !GetLastInstance)
            {
                return i + AddressOffset;
            }
            if (FoundSameBytes && GetLastInstance)
            {
                LastIndexFound = i + AddressOffset;
            }
        }

        return LastIndexFound;
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void GetFilesDifferenceCount()
    {
        string[] AllFiles = Directory.GetFiles(FirmwareFolder, "*.bin");
        string SavingText = "#######################################################################" + Environment.NewLine;
        SavingText = SavingText + "# SHOWING THE AMOUNT OF BYTES DIFFERENCES BETWEEN 2 ECU FILE" + Environment.NewLine;
        SavingText = SavingText + "# IF THERE WERE MORE THAN 500 DIFFERENCES, THE 2 FILES ARE NOT LISTED" + Environment.NewLine;
        SavingText = SavingText + "#######################################################################" + Environment.NewLine;

        GForm_Main_0.method_1(SavingText);

        List<string> AllFileDiffChecked = new List<string>();

        foreach (string ThisFile in AllFiles)
        {
            byte[] AllBytes = File.ReadAllBytes(ThisFile);

            foreach (string ThisFile2 in AllFiles)
            {
                if (ThisFile2 != ThisFile)
                {
                    bool CheckedThose2Files = false;
                    string CheckString = ThisFile2 + "|" + ThisFile;
                    for (int i = 0; i < AllFileDiffChecked.Count; i++)
                    {
                        if (AllFileDiffChecked[i] == CheckString) CheckedThose2Files = true;
                    }

                    if (!CheckedThose2Files)
                    {
                        int ByteDiffCount = 0;
                        byte[] AllBytes2 = File.ReadAllBytes(ThisFile2);
                        for (int i = 0; i < AllBytes2.Length; i++)
                        {
                            if (AllBytes2[i] != AllBytes[i]) ByteDiffCount++;

                            if (ByteDiffCount >= 500) i = AllBytes2.Length;
                        }

                        if (ByteDiffCount < 500)
                        {
                            GForm_Main_0.method_1(Path.GetFileNameWithoutExtension(ThisFile) + " && " + Path.GetFileNameWithoutExtension(ThisFile2) + " > " + ByteDiffCount);
                            //SavingText = SavingText + Path.GetFileNameWithoutExtension(ThisFile) + " && " + Path.GetFileNameWithoutExtension(ThisFile2) + " > " + ByteDiffCount + Environment.NewLine;
                        }

                        AllFileDiffChecked.Add(ThisFile2 + "|" + ThisFile);
                        AllFileDiffChecked.Add(ThisFile + "|" + ThisFile2);
                    }

                    Application.DoEvents();
                }
            }
        }


        //string SavingPath = Application.StartupPath + @"\DifferencesCountInECUFiles.txt";
        //File.Create(SavingPath).Dispose();
        //File.WriteAllText(SavingPath, SavingText);
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void CreateExtractedDefinition()
    {
        //string ExtractedDefinitionFile = @"C:\Users\boule\Desktop\Kserie\roms\hondata\37805-RWC-A620_Definition.txt";
        //string SavingPath = Application.StartupPath + @"\37805-RWC-A620_Definition.txt";

        int DumpsCount = CurrentExtractedDumps - 1;
        if (DumpsCount >= 1)
        {
            for (int k = 0; k < DumpsCount; k++)
            {
                string ExtractedDefinitionFile = ThisEndPath + "ExtractedDefinition" + (k + 1).ToString() + ".txt";
                string SavingPath = ThisEndPath + "GeneratedDefinition" + (k + 1).ToString() + ".txt";

                if (File.Exists(ExtractedDefinitionFile))
                {
                    string[] AllLines = File.ReadAllLines(ExtractedDefinitionFile);

                    List<string> AllParamName = new List<string>();
                    List<string> AllParamLocations = new List<string>();
                    List<bool> AllParamReadOnly = new List<bool>();
                    List<bool> AllParamUntested = new List<bool>();

                    List<string> AllTableName = new List<string>();
                    List<string> AllTableLocations = new List<string>();
                    List<string> AllTableLocationsX = new List<string>();
                    List<string> AllTableLocationsY = new List<string>();
                    List<int> AllRowCount = new List<int>();
                    List<int> AllColCount = new List<int>();
                    List<bool> AllTableReadOnly = new List<bool>();
                    List<bool> AllTableUntested = new List<bool>();

                    string CurrentParam = "";
                    for (int i = 0; i < AllLines.Length; i++)
                    {
                        try
                        {
                            if (AllLines[i].Contains("[Parameter"))
                            {
                                if (AllLines[i] != CurrentParam)
                                {
                                    CurrentParam = AllLines[i];

                                    AllParamName.Add(AllLines[i + 2].Split('=')[1]);
                                    AllParamLocations.Add(AllLines[i + 7].Split('=')[1]);
                                    if (AllLines[i + 17].Split('=')[1] == "0") AllParamReadOnly.Add(false);
                                    if (AllLines[i + 17].Split('=')[1] == "1") AllParamReadOnly.Add(true);
                                    if (AllLines[i + 18].Split('=')[1] == "0") AllParamUntested.Add(false);
                                    if (AllLines[i + 18].Split('=')[1] == "1") AllParamUntested.Add(true);
                                }
                            }

                            if (AllLines[i].Contains("[Table"))
                            {
                                if (AllLines[i] != CurrentParam)
                                {
                                    CurrentParam = AllLines[i];

                                    AllTableName.Add(AllLines[i + 2].Split('=')[1]);
                                    AllTableLocations.Add(AllLines[i + 5].Split('=')[1]);
                                    AllColCount.Add(int.Parse(AllLines[i + 10].Split('=')[1]));

                                    if (AllLines[i + 18].Split('=')[1] == "1") AllRowCount.Add(1);
                                    if (AllLines[i + 18].Split('=')[1] == "0") AllRowCount.Add(20); //#####

                                    if (AllLines[i + 6].Split('=')[1] != "0x00000") AllTableLocationsX.Add(AllLines[i + 6].Split('=')[1]);
                                    if (AllLines[i + 6].Split('=')[1] == "0x00000") AllTableLocationsX.Add("");

                                    if (AllLines[i + 7].Split('=')[1] != "0x00000") AllTableLocationsY.Add(AllLines[i + 7].Split('=')[1]);
                                    if (AllLines[i + 7].Split('=')[1] == "0x00000") AllTableLocationsY.Add("");

                                    if (AllLines[i + 15].Split('=')[1] == "0") AllTableReadOnly.Add(false);
                                    if (AllLines[i + 15].Split('=')[1] == "1") AllTableReadOnly.Add(true);

                                    if (AllLines[i + 16].Split('=')[1] == "0") AllTableUntested.Add(false);
                                    if (AllLines[i + 16].Split('=')[1] == "1") AllTableUntested.Add(true);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            GForm_Main_0.method_1("PROBLEM OCCURED while Generating Definitions file: " + ex);
                        }
                    }

                    string SavingStr = "";
                    for (int i = 0; i < AllParamName.Count; i++)
                    {
                        SavingStr = SavingStr + "ROMLocationTable:" + AllParamLocations[i] + Environment.NewLine;
                        SavingStr = SavingStr + "Name:" + AllParamName[i] + Environment.NewLine;
                        SavingStr = SavingStr + "TableSize:1x1" + Environment.NewLine;
                        SavingStr = SavingStr + "IsSingleByteTable:true" + Environment.NewLine;
                        SavingStr = SavingStr + "IsNotDefined:true" + Environment.NewLine;
                        if (AllParamReadOnly[i]) SavingStr = SavingStr + "IsReadOnly:true" + Environment.NewLine;
                        if (AllParamUntested[i]) SavingStr = SavingStr + "IsUntested:true" + Environment.NewLine;
                        if (i < AllParamName.Count - 2) SavingStr = SavingStr + "#############################" + Environment.NewLine;
                    }

                    SavingStr = SavingStr + "#############################################################" + Environment.NewLine;
                    SavingStr = SavingStr + "#############################################################" + Environment.NewLine;
                    SavingStr = SavingStr + "#############################################################" + Environment.NewLine;

                    for (int i = 0; i < AllTableName.Count; i++)
                    {
                        SavingStr = SavingStr + "ROMLocationTable:" + AllTableLocations[i] + Environment.NewLine;
                        if (AllTableLocationsX[i] != "") SavingStr = SavingStr + "ROMLocationX:" + AllTableLocationsX[i] + Environment.NewLine;
                        if (AllTableLocationsY[i] != "") SavingStr = SavingStr + "ROMLocationY:" + AllTableLocationsY[i] + Environment.NewLine;
                        SavingStr = SavingStr + "Name:" + AllTableName[i] + Environment.NewLine;
                        SavingStr = SavingStr + "TableSize:" + AllColCount[i] + "x" + AllRowCount[i] + Environment.NewLine;
                        SavingStr = SavingStr + "ValueMin:-32768" + Environment.NewLine;
                        SavingStr = SavingStr + "ValueMax:32768" + Environment.NewLine;
                        //SavingStr = SavingStr + "IsSingleByteTable:true" + Environment.NewLine;
                        SavingStr = SavingStr + "IsNotDefined:true" + Environment.NewLine;
                        if (AllTableReadOnly[i]) SavingStr = SavingStr + "IsReadOnly:true" + Environment.NewLine;
                        if (AllTableUntested[i]) SavingStr = SavingStr + "IsUntested:true" + Environment.NewLine;
                        SavingStr = SavingStr + "#############################" + Environment.NewLine;
                    }

                    File.Create(SavingPath).Dispose();
                    File.WriteAllText(SavingPath, SavingStr);
                    GForm_Main_0.method_1("Generated Definitions file created: " + SavingPath);
                }
            }
        }
    }

    // REQUIRED CONSTS
    const int PROCESS_QUERY_INFORMATION = 0x0400;
    const int MEM_COMMIT = 0x00001000;
    const int PAGE_READWRITE = 0x04;
    const int PROCESS_WM_READ = 0x0010;

    // REQUIRED METHODS
    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

    public int BlockSizeExtracted = 30000000;
    public Int64 CurrentIndex = 4000000;
    public IntPtr proc_min_address;
    public IntPtr proc_max_address;
    public long proc_min_address_l;
    public long proc_max_address_l;
    public Process process;

    public bool Done = false;
    public string ThisEndPath = Application.StartupPath + @"\Extracted\";
    public int CurrentExtractedDumps = 1;
    public int ExtractedBlockDone = 1;

    // REQUIRED STRUCTS
    public struct MEMORY_BASIC_INFORMATION
    {
        public int BaseAddress;
        public int AllocationBase;
        public int AllocationProtect;
        public int RegionSize;
        public int State;
        public int Protect;
        public int lType;
    }

    public struct SYSTEM_INFO
    {
        public ushort processorArchitecture;
        ushort reserved;
        public uint pageSize;
        public IntPtr minimumApplicationAddress;
        public IntPtr maximumApplicationAddress;
        public IntPtr activeProcessorMask;
        public uint numberOfProcessors;
        public uint processorType;
        public uint allocationGranularity;
        public ushort processorLevel;
        public ushort processorRevision;
    }

    private int AllBytesContains(byte[] AllBytesCheck, byte[] CheckArray)
    {
        for (int i = 0; i < AllBytesCheck.Length; i++)
        {
            int Index2 = 0;
            try
            {
                while (AllBytesCheck[i + Index2] == CheckArray[Index2])
                {
                    Index2++;
                }
            }
            catch
            {
                return -1;
            }
            if (Index2 >= CheckArray.Length) return i;
        }

        return -1;
    }

    public bool Extract(string ExtractMode)
    {
        try
        {
            SYSTEM_INFO sys_info = new SYSTEM_INFO();
            GetSystemInfo(out sys_info);
            //CurrentIndex = 4000000;
            CurrentIndex = 0;
            Done = false;
            ExtractedBlockDone = 1;
            CurrentExtractedDumps = 1;
            RemovePastDump();

            long MaxIndex = (CurrentIndex + BlockSizeExtracted);

            proc_min_address = (IntPtr)CurrentIndex;
            proc_max_address = (IntPtr)MaxIndex;
            proc_min_address_l = (long)proc_min_address;
            proc_max_address_l = (long)proc_max_address;

            GForm_Main_0.method_1("------------------------------------------");
            GForm_Main_0.method_1("Extracting...");

            if (!Directory.Exists(ThisEndPath)) Directory.CreateDirectory(ThisEndPath);

            Process[] ProcList = Process.GetProcessesByName("FlashProManager");
            if (ProcList.Length == 0)
            {
                GForm_Main_0.method_1("FlashProManager is not running");
                return false;
            }
            else
            {
                process = Process.GetProcessesByName("FlashProManager")[0];
                GForm_Main_0.method_1("FlashProManager is running...");

                //RemovePastDump();
                string ReloadDump = "";

                while (!Done)
                {
                    int Percent = (int)(((CurrentIndex - 4000000) * 100) / (Int64.Parse(sys_info.maximumApplicationAddress.ToString()) - 1));
                    //Console.Write("\nSEARCH #" + SearchID + " " + Percent + "%");
                    GForm_Main_0.method_4(Percent);

                    if ((CurrentIndex + BlockSizeExtracted) > Int64.Parse(sys_info.maximumApplicationAddress.ToString()))
                    {
                        Done = true;
                    }
                    else
                    {
                        MaxIndex = (CurrentIndex + BlockSizeExtracted);

                        proc_min_address = (IntPtr)CurrentIndex;
                        proc_max_address = (IntPtr)MaxIndex;
                        proc_min_address_l = (long)proc_min_address;
                        proc_max_address_l = (long)proc_max_address;

                        ExtractMemoryBlock(ExtractMode);
                        //ReloadDump = ReloadDumpFile();
                        //ReloadDump = File.ReadAllText(ThisEndPath + "DumpHex" + ExtractedBlockDone);

                        //5B446566696E6974696F6E5D  ->[Definition]
                        if (ExtractMode == "Definition")
                        {
                            ReloadDump = File.ReadAllText(ThisEndPath + "DumpHex" + ExtractedBlockDone);
                            if (ReloadDump.Contains("[Definition]"))
                            {
                                //GForm_Main_0.method_1("Found Definition in DumpHex" + ExtractedBlockDone);
                                Console.WriteLine("Found Definition in DumpHex" + ExtractedBlockDone);

                                CurrentExtractedDumps++;
                                string DumpedDefinition = ReloadDump.Substring(ReloadDump.IndexOf("[Definition]"));
                                DumpedDefinition = DumpedDefinition.Substring(0, DumpedDefinition.LastIndexOf("ConditionalEnableValue=") + 24);

                                DumpedDefinition = DumpedDefinition.Replace("..", "\n");


                                string SaveDefPath = ThisEndPath + "ExtractedDefinition" + (CurrentExtractedDumps - 1).ToString() + ".txt";
                                GForm_Main_0.method_1("Extracted Definitions file created: " + SaveDefPath);
                                File.Create(SaveDefPath).Dispose();
                                File.WriteAllText(SaveDefPath, DumpedDefinition);
                            }
                        }
                        if (ExtractMode == "Bin")
                        {
                            byte[] AllBytesArray = File.ReadAllBytes(ThisEndPath + "DumpHex" + ExtractedBlockDone);
                            byte[] CheckBytes = new byte[] { 0xD0, 0x02, 0x40, 0x0B, 0x00, 0x09, 0xAF, 0xFE, 0x00, 0x09, 0x00, 0x00, 0x00 };
                            //D0 02 40 0B 00 09 AF FE 00 09 00 00 00

                            if (AllBytesContains(AllBytesArray, CheckBytes) != -1)
                            {
                                Console.WriteLine("Found Bin in DumpHex" + ExtractedBlockDone);
                            }
                        }
                    }

                    CurrentIndex += BlockSizeExtracted;
                    ExtractedBlockDone++;
                }

                //RemovePastDump();
                GForm_Main_0.ResetProgressBar();

                if (CurrentExtractedDumps == 1)
                {
                    GForm_Main_0.method_1("No " + ExtractMode + " found loaded in memory" + Environment.NewLine + "Try saving your calibration in FlashProManager with small changes and retry this feature");
                    return false;
                }
                else
                {
                    GForm_Main_0.method_1((CurrentExtractedDumps - 1) + " " + ExtractMode + " found!");
                    return true;
                }
            }
        }
        catch (Exception message)
        {
            GForm_Main_0.ResetProgressBar();
            GForm_Main_0.method_1("Cannot extract! Error:" + Environment.NewLine + message);
            return false;

        }
    }

    void RemovePastDump()
    {
        string[] FileList = Directory.GetFiles(ThisEndPath, "Dump*");
        if (FileList.Length > 0)
        {
            for (int i = 0; i < FileList.Length; i++)
            {
                File.Delete(FileList[i]);
            }
        }
    }

    /*string ReloadDumpFile()
    {
        string ReloadDump = File.ReadAllText(ThisEndPath + "Dump" + ExtractedBlockDone + ".txt");
        ReloadDump = ReloadDump.Replace("\n", "");
        ReloadDump = ReloadDump.Replace("\r", "");
        ReloadDump = ReloadDump.Replace(" ", "");
        File.WriteAllText(ThisEndPath + "Dump" + ExtractedBlockDone + ".txt", ReloadDump);

        //ExtractedBytes = File.ReadAllBytes(ThisEndPath + "DumpHex");
        return ReloadDump;
    }*/

    void ExtractMemoryBlock(string ExtractMode)
    {
        int bytesRead = 0;
        IntPtr processHandle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, process.Id);
        MEMORY_BASIC_INFORMATION mem_basic_info = new MEMORY_BASIC_INFORMATION();
        //StreamWriter sw = new StreamWriter(ThisEndPath + "Dump" + ExtractedBlockDone + ".txt");
        StreamWriter sw2 = new StreamWriter(ThisEndPath + "DumpHex" + ExtractedBlockDone);

        while (proc_min_address_l < proc_max_address_l)
        {
            VirtualQueryEx(processHandle, proc_min_address, out mem_basic_info, 28);

            if (mem_basic_info.Protect == PAGE_READWRITE && mem_basic_info.State == MEM_COMMIT)
            {
                byte[] buffer = new byte[mem_basic_info.RegionSize];

                ReadProcessMemory((int)processHandle, mem_basic_info.BaseAddress, buffer, mem_basic_info.RegionSize, ref bytesRead);

                for (int i = 0; i < mem_basic_info.RegionSize; i++)
                {
                    if (ExtractMode == "Bin") sw2.Write(buffer[i].ToString("X2") + " ");
                    else sw2.Write((char)buffer[i]);
                }
            }

            proc_min_address_l += mem_basic_info.RegionSize;
            proc_min_address = new IntPtr(proc_min_address_l);
        }

        //sw.Close();
        sw2.Close();

        if (ExtractMode == "Bin")
        {
            byte[] AllBytesChar = File.ReadAllBytes(ThisEndPath + "DumpHex" + ExtractedBlockDone);
            byte[] AllReturnBytes = new byte[AllBytesChar.Length / 3];
            for (int i = 0; i < AllReturnBytes.Length; i++)
            {
                char char1 = (char) AllBytesChar[(i * 3)];
                char char2 = (char) AllBytesChar[(i * 3) + 1];
                string ByteHex = char1.ToString() + char2.ToString();

                AllReturnBytes[i] = (byte) int.Parse(ByteHex, System.Globalization.NumberStyles.HexNumber);
            }

            File.WriteAllBytes(ThisEndPath + "DumpHex" + ExtractedBlockDone, AllReturnBytes);
        }
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void ExtractAllBootLoaderSum_1Mb()
    {
        AllFileNames = new List<string>();
        AllBootLoaderSumBytes = new List<byte>();

        string[] AllFiles = Directory.GetFiles(FirmwareFolder, "*.bin");
        foreach (string ThisFile in AllFiles)
        {
            byte[] AllBytes = File.ReadAllBytes(ThisFile);
            byte BootLoaderSumByte = GetBootloaderSum(AllBytes);

            AllFileNames.Add(Path.GetFileNameWithoutExtension(ThisFile));
            AllBootLoaderSumBytes.Add(BootLoaderSumByte);
        }

        string SavingText = "";
        for (int i = 0; i < AllFileNames.Count; i++) SavingText = SavingText + AllFileNames[i] + "|" + AllBootLoaderSumBytes[i] + Environment.NewLine;

        string SavingPath = Application.StartupPath + @"\BootLoaderSumBytesList.txt";
        File.Create(SavingPath).Dispose();
        File.WriteAllText(SavingPath, SavingText);

        GForm_Main_0.method_1("File saved:" + SavingPath);
    }

    public byte GetBootloaderSum(byte[] FWFileBytes)
    {
        //###############################
        //Get Checksum (sum)
        byte[] BufferBytes = FWFileBytes;
        byte num = BufferBytes[0x400];
        byte num2 = GetNegativeChecksumFWBin(BufferBytes);
        byte BTSum = num;
        BTSum += num2;
        return BTSum;
    }


    public byte GetNegativeChecksumFWBin(byte[] byte_1)
    {
        byte b = 0;
        for (int i = 0; i < byte_1.Length; i++)
        {
            if (i != 0x400) b -= byte_1[i];
        }
        return b;
    }
}
