using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class Class_DefinitionMaker
{
    List<string> AllECUS = new List<string>();
    List<string> AllFoundFunctions = new List<string>();
    List<int> AllFoundAddress = new List<int>();


    List<string> AllFileNames = new List<string>();
    List<byte> AllBootLoaderSumBytes = new List<byte>();

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void CreateDefinitionsFiles()
    {
        //##########################################################################################################################
        //string FirmwareFolder = Application.StartupPath + @"\Firmwares";
        string FirmwareFolder = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\RWD_2_BIN\bin\Debug\Firmwares";
        //##########################################################################################################################

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
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "VTEC Engagement", ThisAddr);
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("FA 01 2C FF FF 40"), 71, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Revlimiter", ThisAddr);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 1", ThisAddr + 8);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 2", ThisAddr + 16);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 3", ThisAddr + 24);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 4", ThisAddr + 32);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 5", ThisAddr + 36);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 6", ThisAddr + 52);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 7", ThisAddr + 60);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("FA 01 2C FF FF 3A"), 71, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Revlimiter", ThisAddr);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 1", ThisAddr + 8);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 2", ThisAddr + 16);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 3", ThisAddr + 24);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 4", ThisAddr + 32);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 5", ThisAddr + 36);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 6", ThisAddr + 52);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 7", ThisAddr + 60);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 00 00 00 80 00 80 00 00 00 00 00 00"), 84, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Revlimiter", ThisAddr);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 1", ThisAddr + 8);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 2", ThisAddr + 16);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 3", ThisAddr + 24);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 4", ThisAddr + 32);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 5", ThisAddr + 36);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 6", ThisAddr + 52);
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 7", ThisAddr + 60);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 32 00 1E 01 2C 00 00 08 66 66 00 00"), -2, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 32 00 1E 02 BC 02 DC 01 2C"), -2, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("01 90 00 14 01 2C 00 00 08 66 66 00 00"), -2, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("01 2C 00 00 08 66 66 00 00"), -6, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("0C 80 0F A0 12 C0 19 00"), 8, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Injector Voltage Compensation", ThisAddr);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("FC 18 FF 38 80 00 80 00"), -92, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Injector Voltage Compensation", ThisAddr);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            //MISSING ON SOME ROMS, HAVE TO CHECK FOR OTHERS BYTES ARRAY
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 1E 00 00 00 03 00 05 00"), -8, false);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "MAF Load Limit", ThisAddr);
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("7F FF F0 60 EF 98"), 181, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Minimum IPW", ThisAddr);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("05 66 05 66 02 00 00 00 00 01"), 36, true);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Minimum IPW", ThisAddr);
                DoneParameter = true;
            }
            //#######################################################################################################################
            //#######################################################################################################################
            DoneParameter = false;
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 00 00 00 00 00 00 01 00 1E"), 16, false);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Idle Speed", ThisAddr);
                DoneParameter = true;
            }
            if (ThisAddr == -1 && !DoneParameter) ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("C8 01 90 03 20 61 A8 00"), -75, true);
            if (ThisAddr != -1 && !DoneParameter)
            {
                AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Idle Speed", ThisAddr);
                DoneParameter = true;
            }
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

            if (FoundFunc == "Idle Speed")
            {
                AllStringFile = AllStringFile + "ROMLocationTable:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                //AllStringFile = AllStringFile + "ROMLocationY:0x" + FoundAddr.ToString("X") + Environment.NewLine;
                AllStringFile = AllStringFile + "Name:" + FoundFunc + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit1:Coolant Temp" + Environment.NewLine;
                AllStringFile = AllStringFile + "Unit2:RPM" + Environment.NewLine;
                AllStringFile = AllStringFile + "TableSize:8x1" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMin:-1000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ValueMax:4000" + Environment.NewLine;
                AllStringFile = AllStringFile + "ChangeAmount:50" + Environment.NewLine;
                //AllStringFile = AllStringFile + "MathY:X/10" + Environment.NewLine;
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

    private void AddToList(string ThisECUName, string ThisFunction, int ThisAddr)
    {
        AllECUS.Add(ThisECUName);
        AllFoundFunctions.Add(ThisFunction);
        AllFoundAddress.Add(ThisAddr);
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
            else
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
        //##########################################################################################################################
        //string FirmwareFolder = Application.StartupPath + @"\Firmwares";
        string FirmwareFolder = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\RWD_2_BIN\bin\Debug\Firmwares";
        //##########################################################################################################################

        string[] AllFiles = Directory.GetFiles(FirmwareFolder, "*.bin");
        string SavingText = "#######################################################################" + Environment.NewLine;
        SavingText = SavingText + "# SHOWING THE AMOUNT OF BYTES DIFFERENCES BETWEEN 2 ECU FILE" + Environment.NewLine;
        SavingText = SavingText + "# IF THERE WERE MORE THAN 500 DIFFERENCES, THE 2 FILES ARE NOT LISTED" + Environment.NewLine;
        SavingText = SavingText + "#######################################################################" + Environment.NewLine;


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
                            Console.WriteLine(Path.GetFileNameWithoutExtension(ThisFile) + " && " + Path.GetFileNameWithoutExtension(ThisFile2) + " > " + ByteDiffCount);
                            SavingText = SavingText + Path.GetFileNameWithoutExtension(ThisFile) + " && " + Path.GetFileNameWithoutExtension(ThisFile2) + " > " + ByteDiffCount + Environment.NewLine;
                        }

                        AllFileDiffChecked.Add(ThisFile2 + "|" + ThisFile);
                        AllFileDiffChecked.Add(ThisFile + "|" + ThisFile2);
                    }

                    Application.DoEvents();
                }
            }
        }


        string SavingPath = Application.StartupPath + @"\DifferencesCountInECUFiles.txt";
        File.Create(SavingPath).Dispose();
        File.WriteAllText(SavingPath, SavingText);
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void ExtractAllBootLoaderSum_1Mb()
    {
        //##########################################################################################################################
        //string FirmwareFolder = Application.StartupPath + @"\Firmwares";
        string FirmwareFolder = @"C:\Users\boule\Documents\Visual Studio 2019\Projects\RWD_2_BIN\bin\Debug\Firmwares";
        //##########################################################################################################################

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
