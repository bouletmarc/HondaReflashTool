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

            int ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 0A 00 0A 00 C8 00"), 16);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "VTEC Engagement", ThisAddr);

            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("FA 01 2C FF FF 40"), 71);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Revlimiter", ThisAddr);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 1", ThisAddr + 8);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 2", ThisAddr + 16);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 3", ThisAddr + 24);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 4", ThisAddr + 32);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 5", ThisAddr + 36);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 6", ThisAddr + 52);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "--Revlimiter 7", ThisAddr + 60);

            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 32 00 1E 01 2C 00 00 08 66 66 00 00"), -2);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Speedlimiter", ThisAddr);

            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("0C 80 0F A0 12 C0 19 00"), 8);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "Injector Voltage Compensation", ThisAddr);

            //ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 1E 00 00 00 03 00 05 00 C8"), -8);
            ThisAddr = CheckForBytesAndGetAddress(AllBytes, StringToByteArray("00 1E 00 00 00 03 00 05 00"), -8);
            if (ThisAddr != -1) AddToList(Path.GetFileNameWithoutExtension(ThisFile), "MAF Load Limit", ThisAddr);
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

    private int CheckForBytesAndGetAddress(byte[] ThisFileBytes, byte[] CheckThisBytes, int AddressOffset)
    {
        for (int i=0; i < ThisFileBytes.Length; i++)
        {
            bool FoundSameBytes = true;
            for (int i2 = 0; i2 < CheckThisBytes.Length; i2++)
            {
                if (ThisFileBytes[i + i2] != CheckThisBytes[i2])
                {
                    FoundSameBytes = false;
                    i2 = CheckThisBytes.Length;
                }
            }

            if (FoundSameBytes)
            {
                return i + AddressOffset;
            }
        }

        return -1;
    }
}
