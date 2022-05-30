using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;

public class Class_Checksums
{
    private GForm_Main GForm_Main_0;
    public int LastChecksumLocationLoaded = 0;
    public string LastChecksumECUName = "";

    public void Load(ref GForm_Main GForm_Main_1)
    {
        GForm_Main_0 = GForm_Main_1;
    }

    public byte GetChecksumArea(byte[] byte_1, int Start, int ChecksumLocation)
    {
        int BB = 0;
        for (int i = Start; i < byte_1.Length; i++)
        {
            if (i != ChecksumLocation)
            {
                BB -= byte_1[i];
                if (BB < 0) BB += 255;
            }
        }
        return (byte) BB;
    }

    public int GetChecksumLocationThisECU(string ThisECU)
    {
        int CheckLocation = 0;
        if (GForm_Main_0.Editortable_0.LoadDefinitionsFor(ThisECU))
        {
            if (GForm_Main_0.Editortable_0.ClassEditor_0.DefinitionsChecksumLocation != "")
            {
                CheckLocation = int.Parse(GForm_Main_0.Editortable_0.ClassEditor_0.DefinitionsChecksumLocation.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);
            }
        }
        return CheckLocation;
    }

    public int GetChecksumLocation(byte[] BinFileBytes)
    {
        byte[] BufferBytes = BinFileBytes;
        int CheckLocation = 0;

        string Thisecuu = GForm_Main_0.Editortable_0.ExtractECUNameFromThisFile(BinFileBytes);
        if (Thisecuu != "")
        {
            if (Thisecuu == LastChecksumECUName)
            {
                return LastChecksumLocationLoaded;
            }

            if (GForm_Main_0.Editortable_0.LoadDefinitionsFor(Thisecuu))
            {
                if (GForm_Main_0.Editortable_0.ClassEditor_0.DefinitionsChecksumLocation != "")
                {
                    CheckLocation = int.Parse(GForm_Main_0.Editortable_0.ClassEditor_0.DefinitionsChecksumLocation.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);
                }
            }
        }

        if (CheckLocation == 0)
        {
            //HERE
            //GForm_Main_0.method_1("Checksum location not definied for '" + Thisecuu + "', using known checksum location but can possibly be wrong on some ecu!");
            
            DialogResult result = DarkMessageBox.Show("Checksum location not definied for '" + Thisecuu + "'" + Environment.NewLine + "Do you want to use 'known good' checksum location but they still can possibly be wrong on some ecu?", "Checksum location", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                if (BufferBytes.Length - 1 == 0xF7FFF) CheckLocation = 0x8400;      //1mb-fw  -> 0x8400 in full bin but we dont have the bootloader 0x0000 to 0x8000
                if (BufferBytes.Length - 1 == 0xFFFFF) CheckLocation = 0x8400;      //1mb-full
                if (BufferBytes.Length - 1 == 0x1EFFFF) CheckLocation = 0x10012;    //2mb-fw
                if (BufferBytes.Length - 1 == 0x1FFFFF) CheckLocation = 0x10012;    //2mb-full
                if (BufferBytes.Length - 1 == 0x26FFFF) CheckLocation = 0x2003E6;   //4mb-fw
                if (BufferBytes.Length - 1 == 0x27FFFF) CheckLocation = 0x2003E6;   //4mb-full       //0x3FFFFF
            }
        }

        LastChecksumECUName = Thisecuu;
        LastChecksumLocationLoaded = CheckLocation;
        return CheckLocation;
    }

    public byte[] VerifyChecksumFullBin(byte[] BinFileBytes)
    {
        //###############################
        //Get Checksum and Fix it
        byte[] BufferBytes = BinFileBytes;
        int CheckLocation = GetChecksumLocation(BinFileBytes);

        if (CheckLocation == 0)
        {
            GForm_Main_0.method_1("Checksum location not found!");
            return BufferBytes;
        }

        byte num = BufferBytes[CheckLocation];
        byte num2 = GetChecksumArea(BufferBytes, 0, CheckLocation);
        if (num != num2)
        {
            GForm_Main_0.method_1("Checksum miss match.");
            BufferBytes[CheckLocation] = num2;
            GForm_Main_0.method_1("Checksum fixed at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }
        else
        {
            GForm_Main_0.method_1("Checksum are good at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + num2.ToString("X2"));
        }
        return BufferBytes;
    }

    public byte[] VerifyChecksumFWBin(byte[] FWFileBytes)
    {
        //###############################
        //Get Checksum and Fix it
        byte[] BufferBytes = FWFileBytes;
        int CheckLocation = GetChecksumLocation(FWFileBytes);

        if (CheckLocation == 0)
        {
            GForm_Main_0.method_1("Checksum location not found!");
            return BufferBytes;
        }
        int CheckLocationInBIN = CheckLocation;

        if (FWFileBytes.Length - 1 == 0xF7FFF || FWFileBytes.Length - 1 == 0xFFFFF) CheckLocation -= 0x8000;
        if (FWFileBytes.Length - 1 == 0x1EFFFF || FWFileBytes.Length - 1 == 0x1FFFFF ||
            FWFileBytes.Length - 1 == 0x26FFFF || FWFileBytes.Length - 1 == 0x27FFFF) CheckLocation -= 0x10000;

        if (FWFileBytes.Length - 1 == 0xF7FFF) CheckLocationInBIN -= 0x8000;
        if (FWFileBytes.Length - 1 == 0x1EFFFF || FWFileBytes.Length - 1 == 0x1FFFFF) CheckLocationInBIN -= 0x10000;

        //Console.WriteLine("Checksum location: " + CheckLocation.ToString("X"));
        //Console.WriteLine("Checksum locationin bin: " + CheckLocationInBIN.ToString("X"));

        //Remake/remove bootloader section in case the bytes array is a full binary
        byte[] BufferBytesForChecking = new byte[] { };
        if (FWFileBytes.Length - 1 == 0xFFFFF)
        {
            BufferBytesForChecking = new byte[FWFileBytes.Length - 0x8000];
            for (int i = 0; i < BufferBytesForChecking.Length; i++) BufferBytesForChecking[i] = FWFileBytes[i + 0x8000];
        }
        if (FWFileBytes.Length - 1 == 0x26FFFF || FWFileBytes.Length - 1 == 0x27FFFF)
        {
            BufferBytesForChecking = new byte[FWFileBytes.Length - 0x10000];
            for (int i = 0; i < BufferBytesForChecking.Length; i++) BufferBytesForChecking[i] = FWFileBytes[i + 0x10000];
        }

        byte num = Class_RWD.BootloaderSum;
        byte num2 = Class_RWD.GetChecksumFWBin(BufferBytesForChecking, CheckLocation);

        int ThisSum = num;
        ThisSum += num2;
        if (ThisSum >= 256) ThisSum -= 255;

        byte chk = BufferBytes[CheckLocationInBIN];
        /*Console.WriteLine("Bootsum: " + num.ToString("X"));
        Console.WriteLine("FileSum: " + num2.ToString("X"));
        Console.WriteLine("ThisSum: " + ThisSum.ToString("X"));
        Console.WriteLine("ThisCheck: " + chk.ToString("X"));*/
        if (chk != (byte) ThisSum)
        {
            GForm_Main_0.method_1("Checksum miss match.");
            BufferBytes[CheckLocationInBIN] = (byte) ThisSum;
            GForm_Main_0.method_1("Checksum fixed at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + ThisSum.ToString("X2"));
        }
        else
        {
            GForm_Main_0.method_1("Checksum good at 0x" + CheckLocation.ToString("X") + " | Checksum: 0x" + ThisSum.ToString("X2"));
        }
        return BufferBytes;
    }
}
