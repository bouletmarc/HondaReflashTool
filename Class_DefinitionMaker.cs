using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

    List<int> EcuIndexInList = new List<int>();
    List<string> AllCompatiblesECUS = new List<string>();
    List<int> AllChecksumsLocations = new List<int>();
    private int ThisIndex = 0;
    public string FirmwareFolder = "";


    //############
    List<string> AllFileNames = new List<string>();
    List<byte> AllBootLoaderSumBytes = new List<byte>();

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
        AllECUS = new List<string>();
        AllFoundFunctions = new List<string>();
        AllFoundAddress = new List<int>();
        AllFoundAddressX = new List<int>();
        AllFoundAddressY = new List<int>();
        EcuIndexInList = new List<int>();
        AllCompatiblesECUS = new List<string>();
        AllChecksumsLocations = new List<int>();
        ThisIndex = 0;

        string[] AllFiles = Directory.GetFiles(FirmwareFolder, "*.gz");
        foreach (string ThisFile in AllFiles)
        {
            if (ThisFile.Contains("37805"))
            {
                //########
                Class_RWD.LoadRWD(ThisFile, true, false, false, false);
                if (Class_RWD.firmware_candidates.Count == 0)
                {
                    Console.WriteLine(Path.GetFileNameWithoutExtension(ThisFile));
                    continue;
                }

                byte[] AllBytes = Class_RWD.firmware_candidates[0];
                if ((AllBytes.Length - 1) != 0xF7FFF) continue; //################

                string AllCompECU = "";
                for (int m = 0; m < Class_RWD.SuppportedVersions.Length; m++)
                {
                    AllCompECU += Class_RWD.SuppportedVersions[m];
                    if (m < Class_RWD.SuppportedVersions.Length - 1) AllCompECU += "|";
                }
                AllCompatiblesECUS.Add(AllCompECU);
                //EcuIndexInList.Add(ThisIndex);
                //########
                //byte[] AllBytes = File.ReadAllBytes(ThisFile);

                //Create a fake bootloader section
                if ((AllBytes.Length - 1) == 0xF7FFF)
                {
                    byte[] BufferBytes = new byte[0x8000 + AllBytes.Length];
                    for (int i = 0; i < 0x8000; i++) BufferBytes[i] = 0xff;
                    for (int i = 0; i < AllBytes.Length; i++) BufferBytes[0x8000 + i] = AllBytes[i];
                    AllBytes = BufferBytes;

                    //Get checksum locations
                    if (AllBytes[0x83F8] != 0xff) AllChecksumsLocations.Add(0x83F8);
                    else AllChecksumsLocations.Add(0x8400);
                }
                else
                {
                    byte[] BufferBytes = new byte[0x10000 + AllBytes.Length];
                    for (int i = 0; i < 0x10000; i++) BufferBytes[i] = 0xff;
                    for (int i = 0; i < AllBytes.Length; i++) BufferBytes[0x10000 + i] = AllBytes[i];
                    AllBytes = BufferBytes;

                    //Get checksum locations

                    //NOT DEFINIED ...
                }

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



                ThisIndex++;
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
                //#############
                List<string> AllEcuList = new List<string>();
                string ThisEcussList = AllCompatiblesECUS[EcuIndexInList[i]];
                if (ThisEcussList.Contains("|"))
                {
                    string[] Splitt = ThisEcussList.Split('|');
                    for (int i2 = 0; i2 < Splitt.Length; i2++) AllEcuList.Add(Splitt[i2]);
                }
                else
                {
                    AllEcuList.Add(ThisEcussList);
                }
                AllStringFile = GenerateNewHeader("", AllEcuList, "0x" + AllChecksumsLocations[EcuIndexInList[i]].ToString("X"));
                //#############
                //AllStringFile = GenerateNewHeader(BufECUName, new List<string>(), "0x8400");
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

    private string GenerateNewHeader(string ThisEECU, List<string> AllEcuCompatible, string ChecksumLocation)
    {
        string ReturnStr = "";
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "# THIS FILE AS BEEN GENERATED AUTOMATICLY, ROM LOCATIONS CAN BE WRONG" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        ReturnStr = ReturnStr + "# Supported ECU:" + Environment.NewLine;
        ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
        if (ThisEECU != "") ReturnStr = ReturnStr + ThisEECU + Environment.NewLine;
        if (AllEcuCompatible.Count > 0)
        {
            for (int i = 0; i < AllEcuCompatible.Count; i++) ReturnStr = ReturnStr + AllEcuCompatible[i] + Environment.NewLine;
        }
        //###############################
        if (ChecksumLocation != "")
        {
            ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
            ReturnStr = ReturnStr + "# Checksum Address Location:" + Environment.NewLine;
            ReturnStr = ReturnStr + "#######################################################################" + Environment.NewLine;
            ReturnStr = ReturnStr + "ChecksumAddress:" + ChecksumLocation + Environment.NewLine;
        }
        //###############################
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
        EcuIndexInList.Add(ThisIndex);
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

                    List<string> AllIndexName = new List<string>();
                    List<string> AllIndexShortName = new List<string>();
                    List<string> AllIndexLocations = new List<string>();

                    string CurrentParam = "";
                    //string ThisECUName = "";
                    int ParamCount = 0;
                    int TableCount = 0;
                    List<string> AllEcuCompatible = new List<string>();
                    int NumberOfEcus = 0;
                    string ChecksumLocation = "";

                    //#########################################
                    if (AllLines[2].Contains("NumBinaries="))
                    {
                        NumberOfEcus = int.Parse(AllLines[2].Split('=')[1]);

                        for (int i2 = 0; i2 < NumberOfEcus; i2++)
                        {
                            AllEcuCompatible.Add(AllLines[3 + (i2 * 3) + 1].Split('=')[1]);
                        }

                        SavingPath = ThisEndPath + AllEcuCompatible[0] + ".txt";
                    }

                    if (AllLines[1].Contains("FileName=") && !AllLines[2].Contains("NumBinaries="))
                    {
                        string ThisECUName = AllLines[1].Split('=')[1];
                        if (ThisECUName.Contains(".")) ThisECUName = ThisECUName.Split('.')[0];
                        ThisECUName = "37805-" + ThisECUName.Substring(ThisECUName.Length - 8);

                        SavingPath = ThisEndPath + ThisECUName + ".txt";
                        AllEcuCompatible.Add(ThisECUName);
                    }
                    //#########################################

                    for (int i = 0; i < AllLines.Length; i++)
                    {
                        try
                        {
                            //#########################################
                            /*ParameterCount=40
                            IndexCount=53
                            TableCount=49
                            ChecksumAddress=0x001FFFFA
                            ChecksumAddress=0x00008400
                            ChecksumAddress=0x001FFFFA*/
                            if (ChecksumLocation == "") if(AllLines[i].Contains("ChecksumAddress=")) ChecksumLocation = AllLines[i].Split('=')[1];
                            if (AllLines[i].Contains("ParameterCount=")) ParamCount = int.Parse(AllLines[i].Split('=')[1]);
                            if (AllLines[i].Contains("TableCount=") && !AllLines[i].Contains("DevTableCount")) TableCount = int.Parse(AllLines[i].Split('=')[1]);

                            //#########################################
                            if (AllLines[i].Contains("[Parameter"))
                            {
                                if (AllLines[i] != CurrentParam)
                                {
                                    CurrentParam = AllLines[i];

                                    bool DoneThisParameter = false;
                                    try
                                    {
                                        string ParamNamee = AllLines[i + 2].Split('=')[1];

                                        for (int i2 = 0; i2 < AllParamName.Count; i2++) if (AllParamName[i2] == ParamNamee) DoneThisParameter = true;
                                    }
                                    catch
                                    {
                                        DoneThisParameter = true;
                                    }

                                    if (!DoneThisParameter)
                                    {
                                        //############################
                                        AllParamName.Add("");
                                        AllParamLocations.Add("");
                                        AllParamReadOnly.Add(false);
                                        AllParamUntested.Add(false);
                                        //############################

                                        try
                                        {
                                            AllParamName[AllParamName.Count - 1] = AllLines[i + 2].Split('=')[1];
                                            AllParamLocations[AllParamLocations.Count - 1] = AllLines[i + 7].Split('=')[1];
                                            if (AllLines[i + 17].Split('=')[1] == "0") AllParamReadOnly[AllParamReadOnly.Count - 1] = false;
                                            if (AllLines[i + 17].Split('=')[1] == "1") AllParamReadOnly[AllParamReadOnly.Count - 1] = true;
                                            if (AllLines[i + 18].Split('=')[1] == "0") AllParamUntested[AllParamUntested.Count - 1] = false;
                                            if (AllLines[i + 18].Split('=')[1] == "1") AllParamUntested[AllParamUntested.Count - 1] = true;

                                            //Check for issues
                                            bool IssueEncountered = false;
                                            if (!AllParamLocations[AllParamLocations.Count - 1].Contains("0x")) IssueEncountered = true;
                                            if (AllParamLocations[AllParamLocations.Count - 1] == "0") IssueEncountered = true;
                                            if (AllParamName[AllParamName.Count - 1].Contains("0x")) IssueEncountered = true;

                                            if (IssueEncountered)
                                            {
                                                AllParamName.RemoveAt(AllParamName.Count - 1);
                                                AllParamLocations.RemoveAt(AllParamLocations.Count - 1);
                                                AllParamReadOnly.RemoveAt(AllParamReadOnly.Count - 1);
                                                AllParamUntested.RemoveAt(AllParamUntested.Count - 1);
                                            }
                                            else
                                            {
                                                GForm_Main_0.method_1("Added parameter: " + AllParamName[AllParamName.Count - 1]);
                                            }
                                        }
                                        catch
                                        {
                                            //issue extracing parameters, remove from list to avoid issue creating definition
                                            AllParamName.RemoveAt(AllParamName.Count - 1);
                                            AllParamLocations.RemoveAt(AllParamLocations.Count - 1);
                                            AllParamReadOnly.RemoveAt(AllParamReadOnly.Count - 1);
                                            AllParamUntested.RemoveAt(AllParamUntested.Count - 1);
                                        }
                                    }
                                }
                            }
                            //#########################################
                            if (AllLines[i].Contains("[Table"))
                            {
                                if (AllLines[i] != CurrentParam)
                                {
                                    CurrentParam = AllLines[i];

                                    bool DoneThisParameter = false;
                                    try
                                    {
                                        string ParamNamee = AllLines[i + 2].Split('=')[1];
                                        for (int i2 = 0; i2 < AllTableName.Count; i2++) if (AllTableName[i2] == ParamNamee) DoneThisParameter = true;
                                    }
                                    catch
                                    {
                                        DoneThisParameter = true;
                                    }

                                    if (!DoneThisParameter)
                                    {
                                        //############################
                                        AllTableName.Add("");
                                        AllTableLocations.Add("");
                                        AllColCount.Add(0);
                                        AllRowCount.Add(0);
                                        AllTableLocationsX.Add("");
                                        AllTableLocationsY.Add("");
                                        AllTableReadOnly.Add(false);
                                        AllTableUntested.Add(false);
                                        //############################

                                        try
                                        {
                                            AllTableName[AllTableName.Count - 1] = AllLines[i + 2].Split('=')[1];
                                            AllTableLocations[AllTableLocations.Count - 1] = AllLines[i + 5].Split('=')[1];
                                            AllColCount[AllColCount.Count - 1] = int.Parse(AllLines[i + 10].Split('=')[1]);

                                            if (AllLines[i + 18].Split('=')[1] == "1") AllRowCount[AllRowCount.Count - 1] = 1;
                                            if (AllLines[i + 18].Split('=')[1] == "0") AllRowCount[AllRowCount.Count - 1] = 20; //#####

                                            if (AllLines[i + 6].Split('=')[1] != "0x00000") AllTableLocationsX[AllTableLocationsX.Count - 1] = AllLines[i + 6].Split('=')[1];
                                            if (AllLines[i + 6].Split('=')[1] == "0x00000") AllTableLocationsX[AllTableLocationsX.Count - 1] = "";

                                            if (AllLines[i + 7].Split('=')[1] != "0x00000") AllTableLocationsY[AllTableLocationsY.Count - 1] = AllLines[i + 7].Split('=')[1];
                                            if (AllLines[i + 7].Split('=')[1] == "0x00000") AllTableLocationsY[AllTableLocationsY.Count - 1] = "";

                                            if (AllLines[i + 15].Split('=')[1] == "0") AllTableReadOnly[AllTableReadOnly.Count - 1] = false;
                                            if (AllLines[i + 15].Split('=')[1] == "1") AllTableReadOnly[AllTableReadOnly.Count - 1] = true;

                                            if (AllLines[i + 16].Split('=')[1] == "0") AllTableUntested[AllTableUntested.Count - 1] = false;
                                            if (AllLines[i + 16].Split('=')[1] == "1") AllTableUntested[AllTableUntested.Count - 1] = true;

                                            //Check for issues
                                            bool IssueEncountered = false;
                                            if (!AllTableLocations[AllTableLocations.Count - 1].Contains("0x")) IssueEncountered = true;
                                            if (AllTableLocations[AllTableLocations.Count - 1] == "0") IssueEncountered = true;
                                            if (AllTableName[AllTableName.Count - 1].Contains("0x")) IssueEncountered = true;

                                            if (IssueEncountered)
                                            {
                                                AllTableName.RemoveAt(AllTableName.Count - 1);
                                                AllTableLocations.RemoveAt(AllTableLocations.Count - 1);
                                                AllColCount.RemoveAt(AllColCount.Count - 1);
                                                AllRowCount.RemoveAt(AllRowCount.Count - 1);
                                                AllTableLocationsX.RemoveAt(AllTableLocationsX.Count - 1);
                                                AllTableLocationsY.RemoveAt(AllTableLocationsY.Count - 1);
                                                AllTableReadOnly.RemoveAt(AllTableReadOnly.Count - 1);
                                                AllTableUntested.RemoveAt(AllTableUntested.Count - 1);
                                            }
                                            else
                                            {
                                                GForm_Main_0.method_1("Added table: " + AllTableName[AllTableName.Count - 1]);
                                            }
                                        }
                                        catch
                                        {
                                            //issue extracing parameters, remove from list to avoid issue creating definition
                                            AllTableName.RemoveAt(AllTableName.Count - 1);
                                            AllTableLocations.RemoveAt(AllTableLocations.Count - 1);
                                            AllColCount.RemoveAt(AllColCount.Count - 1);
                                            AllRowCount.RemoveAt(AllRowCount.Count - 1);
                                            AllTableLocationsX.RemoveAt(AllTableLocationsX.Count - 1);
                                            AllTableLocationsY.RemoveAt(AllTableLocationsY.Count - 1);
                                            AllTableReadOnly.RemoveAt(AllTableReadOnly.Count - 1);
                                            AllTableUntested.RemoveAt(AllTableUntested.Count - 1);
                                        }
                                    }
                                }
                            }
                            //########################
                            if (AllLines[i].Contains("[Index"))
                            {
                                //AllIndexName
                                //AllIndexLocations
                                if (AllLines[i] != CurrentParam)
                                {
                                    CurrentParam = AllLines[i];

                                    bool DoneThisParameter = false;
                                    try
                                    {
                                        string ParamNamee = AllLines[i + 2].Split('=')[1];
                                        for (int i2 = 0; i2 < AllIndexName.Count; i2++) if (AllIndexName[i2] == ParamNamee) DoneThisParameter = true;
                                    }
                                    catch
                                    {
                                        DoneThisParameter = true;
                                    }

                                    if (!DoneThisParameter)
                                    {
                                        AllIndexName.Add("");
                                        AllIndexShortName.Add("");
                                        AllIndexLocations.Add("");

                                        try
                                        {
                                            AllIndexName[AllIndexName.Count - 1] = AllLines[i + 2].Split('=')[1];
                                            AllIndexShortName[AllIndexShortName.Count - 1] = AllLines[i + 5].Split('=')[1];
                                            AllIndexLocations[AllIndexLocations.Count - 1] = AllLines[i + 6].Split('=')[1];

                                            // XXX index
                                            AllIndexName[AllIndexName.Count - 1] = AllIndexName[AllIndexName.Count - 1].Replace(" " + AllIndexShortName[AllIndexShortName.Count - 1], "");
                                            AllIndexName[AllIndexName.Count - 1] = AllIndexName[AllIndexName.Count - 1].Replace(" index", "");

                                            //Check for issues
                                            bool IssueEncountered = false;
                                            if (!AllIndexLocations[AllIndexLocations.Count - 1].Contains("0x")) IssueEncountered = true;
                                            if (AllIndexLocations[AllIndexLocations.Count - 1] == "0") IssueEncountered = true;
                                            if (AllIndexName[AllIndexName.Count - 1].Contains("0x")) IssueEncountered = true;

                                            if (IssueEncountered)
                                            {
                                                AllIndexName.RemoveAt(AllIndexName.Count - 1);
                                                AllIndexShortName.RemoveAt(AllIndexShortName.Count - 1);
                                                AllIndexLocations.RemoveAt(AllIndexLocations.Count - 1);
                                            }
                                            else
                                            {
                                                GForm_Main_0.method_1("Added index: " + AllIndexName[AllIndexName.Count - 1]);
                                            }
                                        }
                                        catch
                                        {
                                            //issue extracing parameters, remove from list to avoid issue creating definition
                                            AllIndexName.RemoveAt(AllIndexName.Count - 1);
                                            AllIndexShortName.RemoveAt(AllIndexShortName.Count - 1);
                                            AllIndexLocations.RemoveAt(AllIndexLocations.Count - 1);
                                        }
                                    }
                                }
                            }
                            //########################
                        }
                        catch (Exception ex)
                        {
                            GForm_Main_0.method_1("PROBLEM OCCURED while Generating Definitions file: " + ex);
                        }
                    }


                    //ChecksumAddress = 0x001FFFFA
                    //ChecksumAddress = 0x00008400
                    //ChecksumAddress = 0x001FFFFA
                    if (ChecksumLocation != "")
                    {
                        ChecksumLocation = ChecksumLocation.Replace("0x00", "0x");
                        ChecksumLocation = ChecksumLocation.Replace("0x00", "0x");
                        GForm_Main_0.method_1("Checksum address: " + ChecksumLocation);
                    }

                    //Check Counts
                    GForm_Main_0.method_1("Parameters existing in FPM: " + ParamCount);
                    GForm_Main_0.method_1("Parameters extracted: " + AllParamName.Count);
                    GForm_Main_0.method_1("Tables existing in FPM: " + TableCount);
                    GForm_Main_0.method_1("Tables extracted: " + AllTableName.Count);


                    //string SavingStr = GenerateNewHeader(ThisECUName);
                    string SavingStr = GenerateNewHeader("", AllEcuCompatible, ChecksumLocation);
                    for (int i = 0; i < AllParamName.Count; i++)
                    {
                        SavingStr = SavingStr + "ROMLocationTable:" + AllParamLocations[i] + Environment.NewLine;
                        SavingStr = SavingStr + "Name:" + AllParamName[i] + Environment.NewLine;
                        SavingStr = SavingStr + "TableSize:1x1" + Environment.NewLine;
                        SavingStr = SavingStr + "IsSingleByteTable:true" + Environment.NewLine;
                        for (int m = 0; m < AllIndexName.Count; m++)
                        {
                            if (AllIndexName[m].ToLower() == AllParamName[i].ToLower())
                            {
                                SavingStr = SavingStr + "ROMLocationY:" + AllIndexLocations[m] + Environment.NewLine;
                                SavingStr = SavingStr + "Unit1:" + AllIndexShortName[m] + Environment.NewLine;
                                m = AllIndexName.Count;
                            }
                        }
                        SavingStr = SavingStr + "IsNotDefined:true" + Environment.NewLine;
                        if (AllParamReadOnly[i]) SavingStr = SavingStr + "IsReadOnly:true" + Environment.NewLine;
                        if (AllParamUntested[i]) SavingStr = SavingStr + "IsUntested:true" + Environment.NewLine;
                        if (i < AllParamName.Count - 1) SavingStr = SavingStr + "#############################" + Environment.NewLine;
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
                        for (int m = 0; m < AllIndexName.Count; m++)
                        {
                            if (AllIndexName[m].ToLower() == AllTableName[i].ToLower())
                            {
                                SavingStr = SavingStr + "ROMLocationY:" + AllIndexLocations[m] + Environment.NewLine;
                                SavingStr = SavingStr + "Unit1:" + AllIndexShortName[m] + Environment.NewLine;
                                m = AllIndexName.Count;
                            }
                        }
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
    //const int PAGE_READWRITE = 0x04;
    const int PROCESS_WM_READ = 0x0010;

    const int PAGE_EXECUTE = 0x10;
    const int PAGE_EXECUTE_READ = 0x20;
    const int PAGE_EXECUTE_READWRITE = 0x40;
    const int PAGE_EXECUTE_WRITECOPY = 0x80;
    const int PAGE_NOACCESS = 0x01;
    const int PAGE_READONLY = 0x02;
    const int PAGE_READWRITE = 0x04;
    const int PAGE_WRITECOPY = 0x08;
    const int PAGE_GUARD = 0x100;
    const int PAGE_NOCACHE = 0x200;
    const int PAGE_WRITECOMBINE = 0x400;

    // REQUIRED METHODS
    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(int hProcess, uint lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

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
    public int ExtractMemorySize = 0;

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

    public bool Extract(string ExtractMode)
    {
        try
        {
            SYSTEM_INFO sys_info = new SYSTEM_INFO();
            GetSystemInfo(out sys_info);
            CurrentIndex = 0;
            Done = false;
            ExtractedBlockDone = 1;
            CurrentExtractedDumps = 1;

            if (!Directory.Exists(ThisEndPath)) Directory.CreateDirectory(ThisEndPath);
            RemovePastDump();

            long MaxIndex = (CurrentIndex + BlockSizeExtracted);

            proc_min_address = (IntPtr)CurrentIndex;
            proc_max_address = (IntPtr)MaxIndex;
            proc_min_address_l = (long)proc_min_address;
            proc_max_address_l = (long)proc_max_address;

            GForm_Main_0.method_1("------------------------------------------");
            GForm_Main_0.method_1("Extracting...");

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

                string ReloadDump = "";
                if (ExtractMode == "Bin")
                {
                    //This function will extract datas present in 'system space memory' (kernel/protected area)
                    //32Bit applications have 4Gb of memory split into 2sections of 2Gb, 
                    //    ->the first section 0x00000000 to 0x7FFFFFFF are 'user space memory'
                    //    ->the second section 0x80000000 to 0xFFFFFFFF are 'system space memory'
                    ExtractBINFromMemory();
                }

                if (ExtractMode == "Definition")
                {
                    //This function will extract datas present in 'user space memory' (unprotected area)
                    //32Bit applications have 4Gb of memory split into 2sections of 2Gb, 
                    //    ->the first section 0x00000000 to 0x7FFFFFFF are 'user space memory'
                    //    ->the second section 0x80000000 to 0xFFFFFFFF are 'system space memory'
                    while (!Done)
                    {
                        int Percent = (int)(((CurrentIndex) * 100) / (Int64.Parse(sys_info.maximumApplicationAddress.ToString()) - 1));
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

                            ExtractMemoryBlock();

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
                                GForm_Main_0.method_1("Extracted Definitions file created: " + Environment.NewLine + SaveDefPath);
                                File.Create(SaveDefPath).Dispose();
                                File.WriteAllText(SaveDefPath, DumpedDefinition);
                            }
                        }

                        CurrentIndex += BlockSizeExtracted;
                        ExtractedBlockDone++;
                    }
                }

                RemovePastDump();
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

    void ExtractBINFromMemory()
    {
        int bytesRead = 0;
        uint ThisLocation = 0xFAFF0000; //0xFCD180BB FD0100C3 FD2A00C3  //C60000
        uint MaxLocation = 0xFE000000;
        uint ExtractingSize = 0xFFFFF;
        //int BINSize = ExtractMemorySize + 1;
        int BINSize = 0x26FFFF + 1;
        IntPtr processHandle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, process.Id);
        byte[] buffer = new byte[ExtractingSize];

        uint StartAddr = 0;
        uint StartLocation = ThisLocation;
        while (ThisLocation < MaxLocation && StartAddr == 0)
        {
            int Percent = (int)(((ThisLocation - StartLocation) * 100) / ((MaxLocation - StartLocation) - 1));
            GForm_Main_0.method_4(Percent);

            ReadProcessMemory((int)processHandle, ThisLocation, buffer, buffer.Length, ref bytesRead);

            //D0 02 40 0B 00 09 AF FE ->works for 1Mb & 2Mb ROM
            //0D 00 40 02 00 80 00 90 ->works for 4Mb ROM
            //20 00 00 03 B4 C0 FF FF ->works for some 1Mb ROM
            //FF FF FF FF FF FF FF XX -> NOT SUGGESTED
            for (int i = 0; i < buffer.Length - 8; i++)
            {
                if (buffer[i] == 0xd0
                    && buffer[i + 1] == 0x02
                    && buffer[i + 2] == 0x40
                    && buffer[i + 3] == 0x0b
                    && buffer[i + 4] == 0x00
                    && buffer[i + 5] == 0x09
                    && buffer[i + 6] == 0xaf
                    && buffer[i + 7] == 0xfe)
                {
                    StartAddr = (uint)i - 8;
                    i = buffer.Length;
                    Console.WriteLine("Bin method#1");
                }

                if (StartAddr == 0)
                {
                    if (buffer[i] == 0x0d
                        && buffer[i + 1] == 0x00
                        && buffer[i + 2] == 0x40
                        && buffer[i + 3] == 0x02
                        && buffer[i + 4] == 0x00
                        && buffer[i + 5] == 0x80
                        && buffer[i + 6] == 0x00
                        && buffer[i + 7] == 0x90)
                    {
                        StartAddr = (uint)i - 8;
                        i = buffer.Length;
                        Console.WriteLine("Bin method#2");
                    }
                }

                if (StartAddr == 0)
                {
                    if (buffer[i] == 0x20
                        && buffer[i + 1] == 0x00
                        && buffer[i + 2] == 0x00
                        && buffer[i + 3] == 0x03
                        && buffer[i + 4] == 0xb4
                        && buffer[i + 5] == 0xc0
                        && buffer[i + 6] == 0xff
                        && buffer[i + 7] == 0xff)
                    {
                        StartAddr = (uint)i - 6; //fixed
                        i = buffer.Length;
                        Console.WriteLine("Bin method#3");
                    }
                }

                /*if (StartAddr == 0)
                {
                    if (buffer[i] == 0x20
                        && buffer[i + 1] == 0x00
                        && buffer[i + 2] == 0x00
                        && buffer[i + 3] == 0xd0
                        && buffer[i + 4] == 0x3f
                        && buffer[i + 5] == 0x87
                        && buffer[i + 6] == 0x01
                        && buffer[i + 7] == 0xd0)
                    {
                        StartAddr = (uint)i - 8;
                        i = buffer.Length;
                        Console.WriteLine("Bin method#4");
                    }
                }*/
                //20 00 00 D0 4F 28 01 D0
                //20 00 00 D0 3F 87 01 D0
                //01 D0 00 00 00 B0 B7 06

                //NOT SUGGESTED
                /*if (buffer[i] == 0xff
                    && buffer[i + 1] == 0xff
                    && buffer[i + 2] == 0xff
                    && buffer[i + 3] == 0xff
                    && buffer[i + 4] == 0xff
                    && buffer[i + 5] == 0xff
                    && buffer[i + 6] == 0xff
                    && buffer[i + 7] != 0xff)
                {
                    StartAddr = (uint)i + 15;
                    i = buffer.Length;
                }*/
            }

            if (StartAddr == 0)
            {
                ThisLocation += ExtractingSize;
                //ThisLocation += 1;
            }
        }

        GForm_Main_0.ResetProgressBar();

        if (StartAddr != 0)
        {
            //Console.WriteLine("address: 0x" + (StartAddr + ThisLocation).ToString("X"));
            buffer = new byte[BINSize];
            ReadProcessMemory((int)processHandle, (StartAddr + ThisLocation), buffer, buffer.Length, ref bytesRead);

            //Remake buffer for appropriate size rom (1mb/2mb/4mb)
            int NameLocation = GForm_Main_0.Editortable_0.ExtractECUNameLocationFromThisFile(buffer);
            int Count0x00 = 0;
            int BinFormatSize = 0x26FFFF + 1;

            //Console.WriteLine("name location: 0x" + NameLocation.ToString("X"));
            if (NameLocation < 0x1EFFFF)
            {
                for (int i = 0xF7FFF; i < buffer.Length; i++)
                {
                    if (buffer[i] == 0x00) Count0x00++;
                    if (buffer[i] != 0x00) Count0x00 = 0;

                    if (Count0x00 >= (16 * 150))
                    {
                        if (i >= 0xF7FFF && i < 0x1EFFFF)
                        {
                            BinFormatSize = 0xF7FFF + 1;
                            //Console.WriteLine("too much 0x00 at: 0x" + i.ToString("X"));
                            i = buffer.Length;
                        }
                        if (i >= 0x1EFFFF && i < 0x26FFFF)
                        {
                            BinFormatSize = 0x1EFFFF + 1;
                            i = buffer.Length;
                        }
                    }
                }
            }
            if (BinFormatSize == (0xF7FFF + 1))
            {
                //remake 1mb
                GForm_Main_0.method_1("1Mb .bin format detected");
                byte[] newwbuffer = new byte[0xF7FFF + 1];
                for (int k = 0; k < newwbuffer.Length; k++) newwbuffer[k] = buffer[k];
                buffer = newwbuffer;
            }
            if (BinFormatSize == (0x1EFFFF + 1))
            {
                //remake 2mb
                GForm_Main_0.method_1("2Mb .bin format detected");
                byte[] newwbuffer = new byte[0x1EFFFF + 1];
                for (int k = 0; k < newwbuffer.Length; k++) newwbuffer[k] = buffer[k];
                buffer = newwbuffer;
            }
            if (BinFormatSize == (0x26FFFF + 1))
            {
                GForm_Main_0.method_1("4Mb .bin format detected");
            }

            string ECUFilename = GForm_Main_0.Editortable_0.ExtractECUNameFromThisFile(buffer);
            if (ECUFilename != "")
            {
                string SavePathh = ThisEndPath + ECUFilename + ".bin";
                File.Create(SavePathh).Dispose();
                File.WriteAllBytes(SavePathh, buffer);
                GForm_Main_0.method_1("Extracted Binary file created: " + Environment.NewLine + SavePathh);
                CurrentExtractedDumps++;
            }
            else
            {
                GForm_Main_0.method_1("Something went wrong while extracting .bin:" + Environment.NewLine + "Could not find 'ECU name' inside the extracted data");
                string SavePathh = ThisEndPath + "DumpHex1";
                File.Create(SavePathh).Dispose();
                File.WriteAllBytes(SavePathh, buffer);
            }
        }
        /*else
        {
            string SavePathh = ThisEndPath + "DumpHex1";
            File.Create(SavePathh).Dispose();
            File.WriteAllBytes(SavePathh, buffer);
        }*/
    }

    void ExtractMemoryBlock()
    {
        int bytesRead = 0;
        IntPtr processHandle = OpenProcess(PROCESS_QUERY_INFORMATION | PROCESS_WM_READ, false, process.Id);
        MEMORY_BASIC_INFORMATION mem_basic_info = new MEMORY_BASIC_INFORMATION();
        StreamWriter sw2 = new StreamWriter(ThisEndPath + "DumpHex" + ExtractedBlockDone);

        while (proc_min_address_l < proc_max_address_l)
        {
            VirtualQueryEx(processHandle, proc_min_address, out mem_basic_info, 28);

            if ((mem_basic_info.Protect == PAGE_READWRITE && mem_basic_info.State == MEM_COMMIT) || mem_basic_info.Protect == PAGE_WRITECOPY)
            {
                byte[] buffer = new byte[mem_basic_info.RegionSize];

                ReadProcessMemory((int)processHandle, (uint) mem_basic_info.BaseAddress, buffer, mem_basic_info.RegionSize, ref bytesRead);

                for (int i = 0; i < mem_basic_info.RegionSize; i++)
                {
                    sw2.Write((char)buffer[i]);
                }
            }

            proc_min_address_l += mem_basic_info.RegionSize;
            proc_min_address = new IntPtr(proc_min_address_l);
        }

        sw2.Close();

        byte[] AllBytes = File.ReadAllBytes(ThisEndPath + "DumpHex" + ExtractedBlockDone);
        List<byte> AllBytesList = new List<byte>();
        for (int i = 0; i < AllBytes.Length; i++)
        {
            if (AllBytes[i] >= 0x20 && AllBytes[i] <= 0x7E) AllBytesList.Add(AllBytes[i]);
            if (AllBytes[i] == 0x0D || AllBytes[i] == 0x0A) AllBytesList.Add(AllBytes[i]);
        }
        AllBytes = new byte[AllBytesList.Count];
        for (int i = 0; i < AllBytesList.Count; i++) AllBytes[i] = AllBytesList[i];

        File.WriteAllBytes(ThisEndPath + "DumpHex" + ExtractedBlockDone, AllBytes);

        /*if (ExtractMode == "Bin")
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
        }*/
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void RemakeDefinitionsFromEditedFunctions()
    {
        string DoThisPathFunctions = Application.StartupPath + @"\DefinitionsAllFunctionsEDITTHISFILE.txt";
        string Folderpath = Application.StartupPath + @"\Definitions\Generated";
        string[] AllDefinitionFiles = Directory.GetFiles(Folderpath, "*.txt", SearchOption.AllDirectories);
        string[] AllFunctionsLines = File.ReadAllLines(DoThisPathFunctions);

        foreach (string ThisFilePath in AllDefinitionFiles)
        {
            string[] AllLines = File.ReadAllLines(ThisFilePath);
            bool GettingEcuList = true;
            //string CurrentName = "";
            GForm_Main_0.method_1("Doing: " + Path.GetFileName(ThisFilePath));

            List<string> SavingTextLines = new List<string>();

            for (int i = 0; i < AllLines.Length; i++)
            {
                string Thisline = AllLines[i];
                SavingTextLines.Add(Thisline);

                if (Thisline.Contains("ROM Parameters") || Thisline.Contains("Checksum ")) GettingEcuList = false; //make sure we are not reading false contents

                if (Thisline != "")
                {
                    if (!GettingEcuList)
                    {
                        //Get Definitions parameters
                        if (Thisline != "")
                        {
                            if (Thisline[0] != '#')
                            {
                                if (Thisline.Contains(":"))
                                {
                                    string[] Commands = Thisline.Split(':');
                                    if (Commands[0] == "Name")
                                    {
                                        string CurrentName = Commands[1];

                                        //make sure to add tablesize
                                        int ThissIndex = i + 1;
                                        while(true)
                                        {
                                            string[] CMDS = AllLines[ThissIndex].Split(':');
                                            if (CMDS[0] == "TableSize")
                                            {
                                                SavingTextLines.Add(AllLines[ThissIndex]);
                                                break;
                                            }
                                            ThissIndex++;
                                            if (AllLines[ThissIndex][0] == '#') break;
                                        }

                                        for (int m = 0; m < AllFunctionsLines.Length; m++)
                                        {
                                            if (AllFunctionsLines[m].ToLower() == "name:" + CurrentName.ToLower())
                                            {
                                                m++;
                                                while (true)
                                                {
                                                    if (AllFunctionsLines[m][0] == '#') break;
                                                    if (AllFunctionsLines[m][0] != '#') SavingTextLines.Add(AllFunctionsLines[m]);
                                                    m++;
                                                }

                                                m = AllFunctionsLines.Length;
                                            }
                                        }

                                        //roll to next '#'
                                        while (true)
                                        {
                                            i++;
                                            if (AllLines[i][0] == '#')
                                            {
                                                i--;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //Insert Definitions
                        /*if (Thisline.Contains("######"))
                        {
                            if (CurrentName != "")
                            {

                                //Reset values to default
                                CurrentName = "";
                            }
                        }*/
                    }
                }
            }

            string[] SavingText = new string[SavingTextLines.Count];
            for (int i = 0; i < SavingTextLines.Count; i++) SavingText[i] = SavingTextLines[i];
            File.Create(ThisFilePath).Dispose();
            File.WriteAllLines(ThisFilePath, SavingText);
        }

        GForm_Main_0.method_1("DONE!");
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void ExtractAllDefinitionsParametersFound()
    {
        string DoThisPath = Application.StartupPath + @"\DefinitionsAllParametersNames.txt";
        string Folderpath = Application.StartupPath + @"\Definitions\Generated";
        string[] AllDefinitionFiles = Directory.GetFiles(Folderpath, "*.txt", SearchOption.AllDirectories);
        string EcuListText = "";
        List<string> AllParamNames = new List<string>();
        List<string> AllSavingLines = new List<string>();
        List<string> AllSavingLinesReadOnly = new List<string>();

        foreach (string ThisFilePath in AllDefinitionFiles)
        {
            string[] AllLines = File.ReadAllLines(ThisFilePath);
            bool GettingEcuList = true;
            string CurrentName = "";
            //bool CurrentIsReadOnly = false;
            EcuListText = "";

            for (int i = 0; i < AllLines.Length; i++)
            {
                string Thisline = AllLines[i];
                if (Thisline.Contains("ROM Parameters") || Thisline.Contains("Checksum ")) GettingEcuList = false; //make sure we are not reading false contents

                if (Thisline != "")
                {
                    if (GettingEcuList)
                    {
                        if (Thisline[0] != '#')
                        {
                            if (EcuListText != "") EcuListText += "|";
                            EcuListText += Thisline;
                        }
                    }

                    if (!GettingEcuList)
                    {
                        //Get Definitions parameters
                        if (Thisline != "")
                        {
                            if (Thisline[0] != '#')
                            {
                                if (Thisline.Contains(":"))
                                {
                                    string[] Commands = Thisline.Split(':');
                                    if (Commands[0] == "Name") CurrentName = Commands[1];
                                    //if (Commands[0] == "IsReadOnly") CurrentIsReadOnly = bool.Parse(Commands[1].ToLower());
                                }
                            }
                        }

                        //Insert Definitions
                        if (Thisline.Contains("######"))
                        {
                            if (CurrentName != "")
                            {
                                CurrentName = CurrentName.Replace("\\x00b0", "°");
                                if (!IsParamExistInList(AllParamNames, CurrentName))
                                {
                                    //if (!CurrentIsReadOnly)
                                    //{
                                        AllParamNames.Add(CurrentName);
                                        AllSavingLines.Add(CurrentName + " | FOUND IN: " + EcuListText);
                                    //}
                                }
                                else
                                {
                                    for (int i2 = 0; i2 < AllParamNames.Count; i2++)
                                    {
                                        if (AllParamNames[i2].ToLower() == CurrentName.ToLower())
                                        {
                                            AllSavingLines[i2] += "|" + EcuListText;
                                        }
                                    }
                                }

                                //Reset values to default
                                CurrentName = "";
                            }
                        }
                    }
                }

                //if (!GettingEcuList) i = AllLines.Length;
            }
        }

        AllSavingLines.Sort();

        string SavingText = "";
        for (int i = 0; i < AllSavingLines.Count; i++)
        {
            SavingText += AllSavingLines[i] + Environment.NewLine;
        }
        File.Create(DoThisPath).Dispose();
        File.WriteAllText(DoThisPath, SavingText);
    }

    private bool IsParamExistInList(List<string> AllParamN, string CurrentNameP)
    {
        bool Existing = false;
        for (int i = 0; i < AllParamN.Count; i++)
        {
            if (AllParamN[i].ToLower() == CurrentNameP.ToLower()) Existing = true;
        }
        return Existing;
    }

    public void ExtractMathFunctionsFromDefinitionsNames()
    {
        string DoThisPath = Application.StartupPath + @"\DefinitionsAllParametersNames.txt";
        string DoThisPathFunctions = Application.StartupPath + @"\DefinitionsAllFunctions.txt";
        string Folderpath = Application.StartupPath + @"\Definitions";
        string[] AllDefinitionFiles = Directory.GetFiles(Folderpath, "*.txt", SearchOption.AllDirectories);
        string[] AllLinesNames = File.ReadAllLines(DoThisPath);
        List<string> AllSavingLines = new List<string>();
        AllSavingLines.Add("#############################");

        for (int i = 0; i < AllLinesNames.Length; i++)
        {
            if (AllLinesNames[i].Contains(" | FOUND IN: "))
            {
                string[] Splitted = AllLinesNames[i].Split('|');
                string ThisParamName = Splitted[0].Substring(0, Splitted[0].Length - 1);
                string SearchInThisDef = Splitted[1].Substring(11, 14);

                if (Splitted.Length > 2)
                {
                    for (int i2 = 2; i2 < Splitted.Length; i2++)
                    {
                        if (Splitted[i2] == "37805-RRB-A140") SearchInThisDef = "37805-RRB-A140";
                        if (Splitted[i2] == "37805-RWC-A620") SearchInThisDef = "37805-RWC-A620";
                    }
                }
                Application.DoEvents();
                //Console.WriteLine(SearchInThisDef);

                bool FunctionsInserted = false;

                for (int i2 = 0; i2 < AllDefinitionFiles.Length; i2++)
                {
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
                    string CurrentMathXInverted = "";
                    string CurrentMathYInverted = "";
                    string CurrentMathTableInverted = "";
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
                    bool CurrentIsReadOnly = false;
                    bool CurrentIsUntested = false;
                    bool CurrentIsNotDefined = false;

                    bool SameDefFile = false;

                    string[] AllLinesDef = File.ReadAllLines(AllDefinitionFiles[i2]);

                    for (int k = 0; k < AllLinesDef.Length; k++)
                    {
                        string Thisline = AllLinesDef[k];
                        if (Thisline.Contains("ROM Parameters") || Thisline.Contains("Checksum ")) GettingEcuList = false; //make sure we are not reading false contents

                        if (Thisline != "")
                        {
                            if (GettingEcuList)
                            {
                                if (Thisline[0] != '#')
                                {
                                    if (Thisline == SearchInThisDef) SameDefFile = true;
                                    //if (EcuListText != "") EcuListText += "|";
                                    //EcuListText += Thisline;
                                }
                            }

                            if (!GettingEcuList)
                            {
                                if (!SameDefFile) continue;

                                //Get Definitions parameters
                                if (Thisline != "")
                                {
                                    if (Thisline[0] != '#')
                                    {
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
                                            if (Commands[0] == "MathXInverted") CurrentMathXInverted = Commands[1];
                                            if (Commands[0] == "MathYInverted") CurrentMathYInverted = Commands[1];
                                            if (Commands[0] == "MathTableInverted") CurrentMathTableInverted = Commands[1];
                                            if (Commands[0] == "ValueMin") CurrentValueMin = (float)double.Parse(Commands[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                                            if (Commands[0] == "ValueMax") CurrentValueMax = (float)double.Parse(Commands[1].Replace(',', '.'), CultureInfo.InvariantCulture);
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
                                            if (Commands[0] == "IsReadOnly") CurrentIsReadOnly = bool.Parse(Commands[1].ToLower());
                                            if (Commands[0] == "IsUntested") CurrentIsUntested = bool.Parse(Commands[1].ToLower());
                                            if (Commands[0] == "IsNotDefined") CurrentIsNotDefined = bool.Parse(Commands[1].ToLower());
                                        }
                                    }
                                }

                                //Insert Definitions
                                if (Thisline.Contains("######"))
                                {
                                    if (CurrentName != "")
                                    {
                                        if (CurrentName == ThisParamName)
                                        {
                                            //AllSavingLines.Add("#############################");
                                            AllSavingLines.Add("# " + AllLinesNames[i] + " ######");
                                            //if (CurrentLocationTable != "") AllSavingLines.Add("ROMLocationTable:" + CurrentLocationTable);
                                            //if (CurrentLocationX != "") AllSavingLines.Add("ROMLocationX:" + CurrentLocationX);
                                            //if (CurrentLocationY != "") AllSavingLines.Add("ROMLocationY:" + CurrentLocationY);
                                            AllSavingLines.Add("Name:" + CurrentName);
                                            if (CurrentUnit1 != "") AllSavingLines.Add("Unit1:" + CurrentUnit1);
                                            if (CurrentUnit2 != "") AllSavingLines.Add("Unit2:" + CurrentUnit2);

                                            if (CurrentUnit2 == "" && (CurrentName.Contains(" enabled") || CurrentName.Contains("Enable "))) AllSavingLines.Add("Unit2:Enabled");

                                            //if (CurrentTableSize != "") AllSavingLines.Add("TableSize:" + CurrentTableSize);
                                            if (CurrentMathX != "") AllSavingLines.Add("MathX:" + CurrentMathX);
                                            if (CurrentMathY != "") AllSavingLines.Add("MathY:" + CurrentMathY);
                                            if (CurrentMathTable != "") AllSavingLines.Add("MathTable:" + CurrentMathTable);
                                            if (CurrentMathXInverted != "") AllSavingLines.Add("MathXInverted:" + CurrentMathXInverted);
                                            if (CurrentMathYInverted != "") AllSavingLines.Add("MathYInverted:" + CurrentMathYInverted);
                                            if (CurrentMathTableInverted != "") AllSavingLines.Add("MathTableInverted:" + CurrentMathTableInverted);

                                            if (CurrentValueMin != 0f) AllSavingLines.Add("ValueMin:" + CurrentValueMin);
                                            if (CurrentValueMax != 255f) AllSavingLines.Add("ValueMax:" + CurrentValueMax);
                                            if (CurrentChangeAmount != 1) AllSavingLines.Add("ChangeAmount:" + CurrentChangeAmount);

                                            if (CurrentIsSingleByteX != false) AllSavingLines.Add("IsSingleByteX:" + true);
                                            if (CurrentIsSingleByteY != false) AllSavingLines.Add("IsSingleByteY:" + true);
                                            if (CurrentIsSingleByteTable != false) AllSavingLines.Add("IsSingleByteTable:" + true);
                                            if (CurrentFormatX != "") AllSavingLines.Add("FormatX:" + CurrentFormatX);
                                            if (CurrentFormatY != "") AllSavingLines.Add("FormatY:" + CurrentFormatY);
                                            if (CurrentFormatTable != "") AllSavingLines.Add("FormatTable:" + CurrentFormatTable);
                                            if (CurrentHeaders != "") AllSavingLines.Add("Headers:" + CurrentHeaders);
                                            if (CurrentIsXYInverted != false) AllSavingLines.Add("IsXYInverted:" + true);
                                            if (CurrentIsTableInverted != false) AllSavingLines.Add("IsTableInverted:" + true);
                                            if (CurrentIsReadOnly != false) AllSavingLines.Add("IsReadOnly:" + true);
                                            if (CurrentIsUntested != false) AllSavingLines.Add("IsUntested:" + true);
                                            if (CurrentIsNotDefined != false) AllSavingLines.Add("IsNotDefined:" + true);
                                            AllSavingLines.Add("#############################");

                                            FunctionsInserted = true;
                                        }

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
                                        CurrentMathXInverted = "";
                                        CurrentMathYInverted = "";
                                        CurrentMathTableInverted = "";
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
                                        CurrentIsReadOnly = false;
                                        CurrentIsUntested = false;
                                        CurrentIsNotDefined = false;
                                    }
                                }
                            }
                        }

                        if (FunctionsInserted) k = AllLinesDef.Length;
                    }

                    if (FunctionsInserted) i2 = AllDefinitionFiles.Length;
                }
            }
        }

        string[] SavingText = new string[AllSavingLines.Count];
        for (int i = 0; i < AllSavingLines.Count; i++)
        {
            SavingText[i] = AllSavingLines[i];
        }
        File.Create(DoThisPathFunctions).Dispose();
        File.WriteAllLines(DoThisPathFunctions, SavingText);
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void ExtractAllRWDStartFileBytes()
    {
        string DoThisPath = Application.StartupPath + @"\RWDFileMaker.txt";
        string AllRWDPath = @"C:\Program Files (x86)\Honda\J2534 Pass Thru\CalibFiles";
        string[] AllFiles = Directory.GetFiles(AllRWDPath, "*.gz"); //Get all RWD files
        //List<byte[]> ListBytesArray = new List<byte[]>();
        string SavingText = "";
        for (int i = 0; i < AllFiles.Length; i++)
        {
            if (AllFiles[i].Contains("37805"))
            {
                //Console.WriteLine("Doing: " + Path.GetFileNameWithoutExtension(AllFiles[i]));
                Class_RWD.LoadRWD(AllFiles[i], true, false, false, false);

                if (Class_RWD.SuppportedVersions.Length == 0)
                {
                    Console.WriteLine("Problem with: " + Path.GetFileNameWithoutExtension(AllFiles[i]));
                    continue;
                }
                //if (Class_RWD.SuppportedVersions.Length == 0) SavingText += Path.GetFileNameWithoutExtension(AllFiles[i]);

                for (int i2 = 0; i2 < Class_RWD.SuppportedVersions.Length; i2++) SavingText += Class_RWD.SuppportedVersions[i2] + "|";
                for (int i2 = 0; i2 < Class_RWD.RWD_encrypted_StartFile.Length; i2++) SavingText += Class_RWD.RWD_encrypted_StartFile[i2].ToString("X2") + ",";
                SavingText = SavingText.Substring(0, SavingText.Length - 1);
                SavingText += "|";
                for (int i2 = 0; i2 < Class_RWD.EncodersBytes.Length; i2++) SavingText += Class_RWD.EncodersBytes[i2].ToString("X2") + ",";
                SavingText = SavingText.Substring(0, SavingText.Length - 1);

                SavingText += Environment.NewLine;
            }
        }

        File.Create(DoThisPath).Dispose();
        File.WriteAllText(DoThisPath, SavingText);
    }

    /*private byte[] GetNamesToBytesArray()
    {
        List<byte> ListBytess = new List<byte>();
        for (int i = 0; i < Class_RWD.SuppportedVersions.Length; i++)
        {
            for (int k = 0; k < Class_RWD.SuppportedVersions[i].Length; k++)
            {
                ListBytess.Add((byte) Class_RWD.SuppportedVersions[i][k]);
            }
            ListBytess.Add((byte) '|');
        }

        byte[] ThisArray = new byte[ListBytess.Count];
        for (int i = 0; i < ListBytess.Count; i++) ThisArray[i] = ListBytess[i];

        return ThisArray;
    }*/

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void ExtracHondaAcuraECUCodesList()
    {
        string DoThisPath = Application.StartupPath + @"\HondaAcuraCodesList2.txt";
        string AllRWDPath = @"C:\Program Files (x86)\Honda\J2534 Pass Thru\CalibFiles";
        string[] AllFiles = Directory.GetFiles(AllRWDPath, "*.gz"); //Get all RWD files
        string[] AllLines = File.ReadAllLines(DoThisPath);
        for (int i = 0; i < AllLines.Length; i++)
        {
            if (AllLines[i].Contains("_"))
            {
                if (AllLines[i][0] != '#')
                {
                    string[] Splittedcmds = AllLines[i].Split('_');
                    for (int i2 = 0; i2 < Splittedcmds.Length; i2++)
                    {
                        if (Splittedcmds[i2].Contains("37820"))
                        {
                            string SearchFor = Splittedcmds[i2];
                            SearchFor = SearchFor.Replace("37820", "37805");
                            SearchFor = SearchFor.Substring(0, SearchFor.Length - 1);
                            SearchFor = SearchFor.Replace("XX", "");
                            if (SearchFor[SearchFor.Length - 1] == 'X') SearchFor = SearchFor.Substring(0, SearchFor.Length - 1);

                            Console.WriteLine(SearchFor);

                            for (int k = 0; k < AllFiles.Length; k++)
                            {
                                if (AllFiles[k].Contains(SearchFor))
                                {
                                    Class_RWD.LoadRWD(AllFiles[k], true, false, false, false);

                                    string TheseRWDFiles = "";
                                    for (int m = 0; m < Class_RWD.SuppportedVersions.Length; m++)
                                    {
                                        TheseRWDFiles += Class_RWD.SuppportedVersions[m];
                                        if (m < Class_RWD.SuppportedVersions.Length - 1) TheseRWDFiles += "_";
                                    }

                                    //Remake Current line
                                    string CurrentLineText = "";
                                    for (int m = 0; m < Splittedcmds.Length; m++) CurrentLineText += Splittedcmds[m] + "_";
                                    CurrentLineText += TheseRWDFiles;

                                    Console.WriteLine("Remadeline: " + CurrentLineText);
                                    AllLines[i] = CurrentLineText;
                                }
                            }
                        }
                    }
                }
            }
        }

        File.WriteAllLines(DoThisPath, AllLines);
    }

    //##########################################

    public void SetHondaAcuraCodesToDefinitionsFiles()
    {
        string DoThisPath = Application.StartupPath + @"\HondaAcuraCodesList.txt";
        string DoThisPath2 = Application.StartupPath + @"\HondaAcuraCodesList2.txt";
        string Folderpath = Application.StartupPath + @"\Definitions\Generated";
        string[] AllDefinitionFiles = Directory.GetFiles(Folderpath, "*.txt", SearchOption.AllDirectories);
        string[] AllLines1 = File.ReadAllLines(DoThisPath);
        string[] AllLines2 = File.ReadAllLines(DoThisPath2);
        List<string> FileToDelete = new List<string>();

        for (int i = 0; i < AllDefinitionFiles.Length; i++)
        {
            try
            {
                //37805-RWC-A620-M1.rwd.txt
                string EcuNamee = Path.GetFileNameWithoutExtension(AllDefinitionFiles[i]).Substring(0, 13);


                Console.WriteLine("Doing: " + EcuNamee);

                bool FoundParam = false;
                for (int k = 0; k < AllLines1.Length; k++)
                {
                    if (AllLines1[k].Contains(EcuNamee))
                    {
                        Console.WriteLine("Found#1");
                        //Honda_Accord_2013_EX, EX-L_2.4L L4 - Gas, 3.5L V6 - Gas
                        string ParamLine = AllLines1[k - 1];
                        if (ParamLine.Contains(","))
                        {
                            string[] SplittedP = ParamLine.Split(',');
                            string DescText = SplittedP[0];
                            DescText += GetProccesorAndSize(AllLines2, EcuNamee);
                            string NewFileName = Path.GetDirectoryName(AllDefinitionFiles[i]) + @"\" + Path.GetFileNameWithoutExtension(AllDefinitionFiles[i]).Substring(0, 14) + "_" + DescText + ".txt";
                            File.Create(NewFileName).Dispose();
                            File.WriteAllBytes(NewFileName, File.ReadAllBytes(AllDefinitionFiles[i]));

                            if (NewFileName != AllDefinitionFiles[i]) FileToDelete.Add(AllDefinitionFiles[i]);
                            Console.WriteLine("Created: " + Path.GetFileNameWithoutExtension(NewFileName));

                            //#####################
                            string[] AllThisLines = File.ReadAllLines(NewFileName);
                            AllThisLines[0] = "# " + ParamLine + " | " + GetOtherDesc(AllLines2, EcuNamee);
                            AllThisLines[1] = "#######################################################################";
                            File.WriteAllLines(NewFileName, AllThisLines);
                        }

                        FoundParam = true;
                        k = AllLines1.Length;
                    }
                }

                if (!FoundParam)
                {
                    //ECU_Acura_RLX_3.5_16v_310Hp_KEIHIN_37820-R9S-A8X_SH72543_2Mb_37805-R9S-A840_37805-R9S-A830_37805-R9S-A820_37805-R9S-A810_37805-R9S-A590_37805-R9S-A580_37805-R9S-A570_37805-R9S-A560_37805-R9S-A550_37805-R9S-A540_37805-R9S-A530_37805-R9S-A520_37805-R9S-A510
                    for (int k = 0; k < AllLines2.Length; k++)
                    {
                        if (AllLines2[k].Contains(EcuNamee))
                        {
                            Console.WriteLine("Found#2");
                            string ParamLine = AllLines2[k];

                            if (ParamLine.Contains("_"))
                            {
                                string[] SplittedP = ParamLine.Split('_');
                                string DescText = SplittedP[1] + "_" + SplittedP[2] + "_" + SplittedP[3] + "_" + SplittedP[4];
                                DescText += GetProccesorAndSize(AllLines2, EcuNamee);
                                string NewFileName = Path.GetDirectoryName(AllDefinitionFiles[i]) + @"\" + Path.GetFileNameWithoutExtension(AllDefinitionFiles[i]).Substring(0, 14) + "_" + DescText + ".txt";
                                File.Create(NewFileName).Dispose();
                                File.WriteAllBytes(NewFileName, File.ReadAllBytes(AllDefinitionFiles[i]));

                                if (NewFileName != AllDefinitionFiles[i]) FileToDelete.Add(AllDefinitionFiles[i]);
                                Console.WriteLine("Created: " + Path.GetFileNameWithoutExtension(NewFileName));

                                //#####################
                                string[] AllThisLines = File.ReadAllLines(NewFileName);
                                AllThisLines[0] = "# " + ParamLine;
                                AllThisLines[1] = "#######################################################################";
                                File.WriteAllLines(NewFileName, AllThisLines);
                            }

                            FoundParam = true;
                            k = AllLines2.Length;
                        }
                    }
                }
            }
            catch { }
        }

        for (int i = 0; i < FileToDelete.Count; i++)
        {
            File.Delete(FileToDelete[i]);
            Console.WriteLine("Deleted: " + Path.GetFileNameWithoutExtension(FileToDelete[i]));
        }
    }

    string GetOtherDesc(string[] AllLines2, string EcuNamee)
    {
        string ReturnText = "";
        for (int k = 0; k < AllLines2.Length; k++)
        {
            if (AllLines2[k].Contains(EcuNamee))
            {
                ReturnText = AllLines2[k];

                k = AllLines2.Length;
            }
        }
        return ReturnText;
    }

    string GetProccesorAndSize(string[] AllLines2, string EcuNamee)
    {
        string ReturnText = "";
        for (int k = 0; k < AllLines2.Length; k++)
        {
            if (AllLines2[k].Contains(EcuNamee))
            {
                string ParamLine = AllLines2[k];

                if (ParamLine.Contains("_"))
                {
                    string[] SplittedP = ParamLine.Split('_');
                    for (int m = 0; m < SplittedP.Length; m++)
                    {
                        if (SplittedP[m].Contains("SH72543") || SplittedP[m].Contains("SH7058") || SplittedP[m].Contains("MPC5554") ||
                            SplittedP[m].Contains("MPC5566") || SplittedP[m].Contains("SH7055"))
                        {
                            ReturnText += "_" + SplittedP[m] + "_" + SplittedP[m + 1];
                            m = SplittedP.Length;
                        }
                    }
                }

                k = AllLines2.Length;
            }
        }
        return ReturnText;
    }

    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################
    //##########################################################################################################################

    public void ExtractAllBootLoaderSum()
    {
        AllFileNames = new List<string>();
        AllBootLoaderSumBytes = new List<byte>();

        string[] AllFiles = Directory.GetFiles(FirmwareFolder, "*.gz"); //Get all RWD files
        for (int i = 0; i < GForm_Main_0.Editortable_0.ClassEditor_0.Ecus_Definitions_Compatible.Count; i++)    //Check within all ecus that has a definitions file
        {
            string ThisEcu = GForm_Main_0.Editortable_0.ClassEditor_0.Ecus_Definitions_Compatible[i];
            string ThisEcuReducedName2 = "?????";
            if (ThisEcu.Length >= 12) ThisEcuReducedName2 = ThisEcu.Substring(0, 12);

            //if (ThisEcu != "37805-RWC-A620") continue;

            bool RWDFileFound = false;
            for (int k = 0; k < AllFiles.Length; k++)   //check within all RWD files
            {
                /*bool MatchingInside = false;
                if (AllFiles[k].Contains(ThisEcuReducedName2))
                {
                    Class_RWD.LoadRWD(AllFiles[k], false, false, false, false);
                    for (int m = 0; m < Class_RWD.SuppportedVersions.Length; m++)
                    {
                        if (Class_RWD.SuppportedVersions[m] == ThisEcu) MatchingInside = true;
                    }
                }*/
                Application.DoEvents();

                if (AllFiles[k].Contains(ThisEcu))
                //if (AllFiles[k].Contains(ThisEcu) || MatchingInside)
                {
                    RWDFileFound = true;
                    Console.WriteLine("DOING: " + ThisEcu);
                    GForm_Main_0.ClearLogs();

                    //Decrypt firmware file and get needed variable (Decryption byte)
                    Class_RWD.LoadRWD(AllFiles[k], true, false, false, true);

                    byte BootSumByte = 0;
                    for (int m = 0; m < Class_RWD.SuppportedVersions.Length; m++)
                    {
                        if (Class_RWD.SuppportedVersions[m] == ThisEcu) //Matching ecu definition and RWD file
                        {
                            BootSumByte = Class_RWD.BootloaderSum;
                            if (BootSumByte == 0) Console.WriteLine("ERROR BOOTSUM FOR: " + ThisEcu);

                            m = Class_RWD.SuppportedVersions.Length;
                            //k = AllFiles.Length;
                        }
                    }

                    if (BootSumByte != 0)
                    {
                        for (int m = 0; m < Class_RWD.SuppportedVersions.Length; m++)
                        {
                            AllFileNames.Add(Class_RWD.SuppportedVersions[m]);
                            AllBootLoaderSumBytes.Add(BootSumByte);
                        }
                    }

                    k = AllFiles.Length;
                }
            }
            if (!RWDFileFound) Console.WriteLine("RWD NOT FOUND FOR: " + ThisEcu);
        }

        string SavingText = "";
        for (int i = 0; i < AllFileNames.Count; i++) SavingText = SavingText + AllFileNames[i] + "|" + AllBootLoaderSumBytes[i] + Environment.NewLine;

        string SavingPath = Application.StartupPath + @"\BootLoaderSumBytesList2.txt";
        File.Create(SavingPath).Dispose();
        File.WriteAllText(SavingPath, SavingText);

        GForm_Main_0.method_1("File saved:" + SavingPath);
    }

    /*public void ExtractAllBootLoaderSum_1Mb()
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
    }*/
}
