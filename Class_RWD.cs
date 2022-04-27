using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

static class Class_RWD
{
    private static string part_number_prefix = "";
    private static List<byte[]> firmware_candidates = new List<byte[]>();
    public static byte[] _keys = new byte[] { };
    public static byte[] _firmware_encrypted = new byte[] { };
    public static UInt32 start = 0U;
    public static UInt32 size = 0U;
    private static string[] SuppportedVersions = new string[] { };
    private static string[] SuppportedFWKeys = new string[] { };
    private static string CanAddress = "";
    private static byte[] DecodersBytes = new byte[] { };   //Used to decode rwd to bin
    private static byte[] EncodersBytes = new byte[] { };   //Used to encode bin to rwd
    private static byte[] RWD_encrypted_StartFile = new byte[] { };   //Used to encode bin to rwd
    public static byte BootloaderSum = 0;

    private static GForm_Main GForm_Main_0;

    public static void Load(ref GForm_Main GForm_Main_1)
    {
        GForm_Main_0 = GForm_Main_1;
    }

    public static void CompressFile(string ThisFile, string CompressedName)
    {
        FileStream originalFileStream = File.Open(ThisFile, FileMode.Open);
        FileStream compressedFileStream = File.Create(CompressedName);
        GZipStream compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
        originalFileStream.CopyTo(compressor);
    }

    public static byte[] Decompress(string ThisFile)
    {
        Stream compressedStream = new MemoryStream(File.ReadAllBytes(ThisFile));
        GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Decompress);
        MemoryStream resultStream = new MemoryStream();
        zipStream.CopyTo(resultStream);
        return resultStream.ToArray();
    }

    public static UInt16 ToUInt16BE(byte[] TwoBytes)
    {
        UInt16 k0 = BitConverter.ToUInt16(TwoBytes, 0);
        UInt16 k1 = BitConverter.ToUInt16(BitConverter.GetBytes(k0).Reverse().ToArray(), 0);
        return k1;
    }

    public static UInt32 ToUInt32BE(byte[] FourBytes)
    {
        int k0 = BitConverter.ToInt32(FourBytes, 0);
        int k1 = BitConverter.ToInt32(BitConverter.GetBytes(k0).Reverse().ToArray(), 0);
        return (UInt32) k1;
    }

    /*public static UInt16 checksum_by_sum(byte[] fw, uint start, uint end)
    {
        int s = 0;
        uint valuescount = (end - start) / 2;
        for (int i = 0; i < valuescount; i++)
        {
            byte[] ThisTwoBytes = new byte[2] { fw[start + (i*2)], fw[start + (i * 2) + 1] };
            s += ToUInt16BE(ThisTwoBytes);

            if (s > 0xFFFF) s -= 0xFFFF;
        }
        return (UInt16) s;
    }

    private static UInt16 checksum_by_negative_sum(byte[] fw, uint start, uint end)
    {
        int s = 0;
        uint valuescount = (end - start) / 2;
        for (int i = 0; i < valuescount; i++)
        {
            byte[] ThisTwoBytes = new byte[2] { fw[start + (i * 2)], fw[start + (i * 2) + 1] };
            s -= ToUInt16BE(ThisTwoBytes);

            if (s < 0) s += 0xFFFF;
        }
        return (UInt16) s;
    }*/

    private static UInt32 Get_rwd_checksum(byte[] data, uint start, uint end)
    {
        uint s = 0;
        uint valuescount = (end - start);
        for (int i = 0; i < valuescount; i++)
        {
            byte ThisValuee = data[start + i];
            s += ThisValuee;

            if (s > 0xFFFFFFFF) s -= 0xFFFFFFFF;
        }
        s = ToUInt32BE(BitConverter.GetBytes(s));
        return (UInt32)s;
    }

    //######################################################################################################
    //######################################################################################################
    public static void LoadBIN(string f_name, string f_nameFW)
    {
        byte[] data = File.ReadAllBytes(f_name);
        GForm_Main_0.method_1("Encrypting file: " + f_name);

        //Load .rwd file for obtaining 'encryption' method and then encrypt the .bin using the same method.
        LoadRWD(f_nameFW, true, false);

        //Copy Start file bytes from the selected rwd file, then add the dat aand checksum bytes
        byte[] dataEncrypted = new byte[RWD_encrypted_StartFile.Length + data.Length + 4];
        for (int i = 0; i < RWD_encrypted_StartFile.Length; i++) dataEncrypted[i] = RWD_encrypted_StartFile[i];

        //Encrypt .bin data bytes to .rwd format
        for (int i = 0; i < data.Length; i++)
        {
            byte ThisByte = data[i];
            dataEncrypted[RWD_encrypted_StartFile.Length + i] = EncodersBytes[ThisByte];
        }

        //Fix Checksums
        UInt32 ChecksumValue = Get_rwd_checksum(dataEncrypted, 0, (uint)dataEncrypted.Length);
        byte[] ChecksumBytes = BitConverter.GetBytes(ChecksumValue);
        if (ChecksumBytes.Length == 4)
        {
            for (int i = 0; i < ChecksumBytes.Length; i++)
            {
                dataEncrypted[((dataEncrypted.Length - 1) - 4) + i] = ChecksumBytes[i];
            }
            GForm_Main_0.method_1("Checksum bytes fixed!");
        }
        else
        {
            GForm_Main_0.method_1("Checksum is not 4bytes long!");
        }

        //Save Encrypted rwd firmware
        string ThisPath = Path.GetDirectoryName(f_name) + @"\" + Path.GetFileNameWithoutExtension(f_name) + ".rwd";
        File.Create(ThisPath).Dispose();
        File.WriteAllBytes(ThisPath, dataEncrypted);
        GForm_Main_0.method_1("Saved encrypted firmware file: " + ThisPath);

        //Save ZIPPED Encrypted firmware
        CompressFile(ThisPath, ThisPath + ".gz");
    }

    //######################################################################################################
    //######################################################################################################
    public static void LoadRWD(string f_name, bool FullDecrypt, bool Saving)
    {
        byte[] data = new byte[] { };
        if (Path.GetExtension(f_name).ToLower().Contains("gz")) data = Decompress(f_name);
        else data = File.ReadAllBytes(f_name);

        GForm_Main_0.method_1("Decrypting file: " + f_name);

        string indicatorBytes = data[0].ToString("x2") + data[1].ToString("x2") + data[2].ToString("x2");
        if (indicatorBytes != "5a0d0a")
        {
            GForm_Main_0.method_1("Not Compatible file!");
            return;
        }

        byte[] headers0 = { };
        byte[] headers1 = { };
        byte[] headers2 = { };
        byte[] headers3 = { };
        byte[] headers4 = { };
        byte[] headers5 = { };
        int idx = 0;
        idx += 3;
        for (int i = 0; i < 6; i++)
        {
            // first byte is number of values
            var count = data[idx];
            idx += 1;

            byte[] header = { };
            for (int j = 0; j < count; j++)
            {
                // first byte is length of value
                int length = data[idx];
                idx += 1;

                byte[] v = Slice(data, idx, idx + length);
                idx += length;

                header = Push(header, v);
            }

            if (i == 0) headers0 = header;
            if (i == 1) headers1 = header;
            if (i == 2) headers2 = header;  //ECU Type (Auto/Manual)
            if (i == 3) headers3 = header;  //Versions
            if (i == 4) headers4 = header;  //Security Keys
            if (i == 5) headers5 = header;  //Firmware Keys
        }

        start = ReadUInt32BE(data, idx);
        idx += 4;

        size = ReadUInt32BE(data, idx);
        idx += 4;

        //Get Start file bytes array
        RWD_encrypted_StartFile = new byte[idx];
        for (int i = 0; i < idx; i++) RWD_encrypted_StartFile[i] = data[i];

        byte[] firmware = Slice(data, idx, data.Length - 4);
        idx += firmware.Length;

        UInt32 checksum = ReadUInt32BE(data, idx);
        idx += 4;

        if (idx != data.Length) GForm_Main_0.method_1("not at end of file after unpacking");
        if ((headers3.Length / 16) != (headers4.Length / 6)) GForm_Main_0.method_1("different number of versions and security access tokens");

        _firmware_encrypted = firmware;
        _keys = headers5;

        //Get supported versions and supported firmwares keys
        int VersionsCount = (headers3.Length / 16);
        SuppportedVersions = new string[VersionsCount];
        SuppportedFWKeys = new string[VersionsCount];
        string SoftwareKey = _keys[0].ToString("X2") + _keys[1].ToString("X2") + _keys[2].ToString("X2");
        for (int i = 0; i < VersionsCount; i++)
        {
            //Get Supported versions
            byte[] buf = new byte[16];
            int EmptyCount = 0;
            for (int i2 = 0; i2 < 16; i2++)
            {
                buf[i2] = headers3[(i * 16) + i2];
                if (buf[i2] == 0)
                {
                    buf[i2] = 0x2E;
                    EmptyCount++;
                }
            }

            //Remove Empty chars
            byte[] bufRedo = new byte[16 - EmptyCount];
            for (int i2 = 0; i2 < bufRedo.Length; i2++) bufRedo[i2] = buf[i2];
            SuppportedVersions[i] = System.Text.Encoding.ASCII.GetString(bufRedo);

            //Get supported Firmwares keys according to the supported versions
            byte[] bufkey = new byte[6];
            for (int i2 = 0; i2 < 6; i2++)
            {
                bufkey[i2] = headers4[(i * 6) + i2];
            }
            SuppportedFWKeys[i] = bufkey[0].ToString("X2") + bufkey[1].ToString("X2") + bufkey[2].ToString("X2") + bufkey[3].ToString("X2") + bufkey[4].ToString("X2") + bufkey[5].ToString("X2");
        }

        //Get CanAddress Infos
        CanAddress = "18DA" + headers2[0].ToString("X2") + "F1";
        string AdditionnalCanInfos = "";
        if (headers2[0] == 0x0e) AdditionnalCanInfos = " (CVT Transmission (maybe?))";
        if (headers2[0] == 0x10) AdditionnalCanInfos = " (Manual Transmission)";
        if (headers2[0] == 0x11) AdditionnalCanInfos = " (Automatics Transmission)";
        if (headers2[0] == 0x30) AdditionnalCanInfos = " (Electric Power Sterring)";

        //Print/Log Informations
        GForm_Main_0.method_1("Firmware Start: 0x" + start.ToString("X"));
        GForm_Main_0.method_1("Firmware Size: 0x" + size.ToString("X"));
        GForm_Main_0.method_1("CanAddress: 0x" + CanAddress + AdditionnalCanInfos);
        GForm_Main_0.method_1("Software Keys: 0x" + SoftwareKey);
        GForm_Main_0.method_1("Supported Versions (and keys): ");
        for (int i = 0; i < SuppportedVersions.Length; i++) GForm_Main_0.method_1(SuppportedVersions[i] + " (0x" + SuppportedFWKeys[i] + ")");

        //Perform FULL decryption (convert .rwd to .bin)
        if (FullDecrypt) DecryptRWD(f_name, Saving);
    }

    private static void DecryptRWD(string f_name, bool Saving)
    {
        part_number_prefix = get_part_number_prefix(f_name);
        firmware_candidates = decrypt(part_number_prefix);

        if (firmware_candidates.Count == 0)
        {
            //try with a shorter part number
            GForm_Main_0.method_1("failed on long part number, trying truncated part number ...");
            part_number_prefix = get_part_number_prefix(f_name, true);
            firmware_candidates = decrypt(part_number_prefix);
        }

        if (firmware_candidates.Count == 0)
        {
            GForm_Main_0.method_1("decryption failed!");
            GForm_Main_0.method_1("(could not find a cipher that results in the part number being in the data)");
            return;
        }

        //Remove duplicated Candidates
        if (firmware_candidates.Count > 1)
        {
            List<byte[]> firmware_candidatesBUFFER = firmware_candidates;
            firmware_candidates = new List<byte[]>();

            byte[] LastCandidate = firmware_candidatesBUFFER[firmware_candidatesBUFFER.Count - 1];
            for (int i = 0; i < firmware_candidatesBUFFER.Count - 1; i++)
            {
                byte[] CurrentCandidate = firmware_candidatesBUFFER[i];
                if (CurrentCandidate != LastCandidate)
                {
                    firmware_candidates.Add(CurrentCandidate);
                }
            }
            firmware_candidates.Add(LastCandidate);
        }

        if (firmware_candidates.Count > 1) GForm_Main_0.method_1("multiple sets of keys resulted in data containing the part number");

        //###################################################################
        //###################################################################
        foreach (byte[] fc in firmware_candidates)
        {
            //Checksum location for SH7058 1mb rom file are located at 0x8400, it's a 1byte sum calculated from negative sum of the full binary
            //Since we are missing the bootloader section of the full binary we have to remove the section 0x0000 to 0x8000(Start_Address)
            //we can calculate what was the 'sum' of the bootloader by subtracting the 'sum' of the decrypted firmware!

            if (start == 0x8000) //Only SH7058 1mb file
            {
                byte num = GetBootloaderSum(fc);
                byte num2 = GetNegativeChecksumFWBin(fc);
                byte ThisSum = num;
                ThisSum -= num2;
                byte chk = fc[0x400];
                if (chk == ThisSum)
                {
                    GForm_Main_0.method_1("checksums good!");
                    BootloaderSum = num;
                    GForm_Main_0.method_1("Bootloader Sum are 0x" + BootloaderSum.ToString("X"));
                }
            }
        }

        //###############################################
        /*List<byte[]> firmware_good = new List<byte[]>();
        idx = 0;

        foreach (byte[] fc in firmware_candidates)
        {
            //# concat all address blocks to allow checksum validation using memory addresses
            byte[] firmwareBLK = new byte[] { };
            foreach (int block in xrange(fc.Length)) {
                start = firmware_blocks[block]["start"];
                //# fill gaps with \x00;
                if (firmwareBLK.Length < start) {
                    firmwareBLK += '\x00' * (start - firmwareBLK.Length);
                }
                firmwareBLK += fc[block];
            }

            //# validate known checksums
            if (f_base in checksums.keys())
            {
                GForm_Main_0.method_1(string.Format("firmware[{0}] checksums:", idx));
                bool match = true;
                foreach (start, end in checksums[f_base])
                {
                    byte sum = ord(get_checksum(firmwareBLK[start: end]));
                    byte chk = ord(firmwareBLK[end]);
                    string Value2 = "";
                    if (chk == sum) Value2 = "=";
                    else Value2 = "!=";
                    GForm_Main_0.method_1(string.Format("{0} {1} {2}", chk.ToString("X2"), Value2, sum.ToString("X2")));
                    if (sum != chk) match = false;
                }
                if (match)
                {
                    GForm_Main_0.method_1("checksums good!");
                    firmware_good.append(firmwareBLK);
                }
                else
                {
                    GForm_Main_0.method_1("checksums bad!");
                }
            }
            else
            {
                //# no checksums so assume good
                firmware_good.append(firmwareBLK);
            }

            idx += 1;
        }*/
        //###################################################################
        //###################################################################

        //Saving Decrypted Firmwares
        if (Saving)
        {
            bool AsSavedFile = false;
            int FileCount = 1;
            foreach (byte[] f_data in firmware_candidates)
            {
                string FileNumber = "";
                if (firmware_candidates.Count > 1) FileNumber = "_" + FileCount;
                string ThisPath = Path.GetDirectoryName(f_name) + @"\" + Path.GetFileNameWithoutExtension(f_name).Replace(".rwd", "").Replace(".RWD", "") + ".0x" + start.ToString("X") + FileNumber + ".bin";
                File.Create(ThisPath).Dispose();
                File.WriteAllBytes(ThisPath, f_data);   //-> f_data[start_addr:]
                GForm_Main_0.method_1("Saved decrypted firmware file: " + ThisPath);
                AsSavedFile = true;
                FileCount++;
            }

            if (AsSavedFile) GForm_Main_0.method_1("Note: The decrypted firmware file (.bin), is not a complete .bin file! It cannot be used to perform a 'Flash Rom' to the ECU, the bootloader section from 0x0000 to 0x" + start.ToString("X") + " of the rom is Missing.");
        }
    }

    public static byte GetBootloaderSum(byte[] FWFileBytes)
    {
        //###############################
        //Get Checksum (sum)
        byte[] BufferBytes = FWFileBytes;
        byte num = BufferBytes[0x400];
        byte num2 = GetNegativeChecksumFWBin(BufferBytes);
        byte BTSum = num;
        BTSum += num2;
        return BTSum;
        //BootloaderSum = BTSum;
        //GForm_Main_0.method_1("Bootloader Sum are 0x" + BootloaderSum.ToString("X"));
    }

    public static byte GetNegativeChecksumFWBin(byte[] byte_1)
    {
        byte b = 0;
        for (int i = 0; i < byte_1.Length; i++)
        {
            if (i != 0x400)
            {
                b -= byte_1[i];
            }
        }
        return b;
    }

    public static byte[] Push(byte[] bArray, byte[] newBytes)
    {
        byte[] newArray = new byte[bArray.Length + newBytes.Length];
        bArray.CopyTo(newArray, newBytes.Length);
        for (int i = 0; i < newBytes.Length; i++)
        {
            newArray[i] = newBytes[i];
        }
        return newArray;
    }

    public static  byte[] Slice(byte[] bArray, int StartInd, int EndInd)
    {
        int Lenght = (EndInd - StartInd);
        byte[] newArray = new byte[Lenght];
        for (int i = 0; i < Lenght; i++)
        {
            newArray[i] = bArray[StartInd + i];
        }
        return newArray;
    }

    public static  UInt32 ReadUInt32BE(byte[] buffer, int StartInd)
    {
        var value = BitConverter.ToUInt32(buffer, StartInd);
        var rs = BitConverter.ToUInt32(BitConverter.GetBytes(value).Reverse().ToArray(), 0);
        return rs;
    }

    private static string get_part_number_prefix(string fn, bool Short = false)
    {
        string f_name = Path.GetFileNameWithoutExtension(fn);
        f_name = f_name.Replace("-", "").Replace("_", "");

        string prefix = f_name.Substring(0, 5) + "-" + f_name.Substring(5, 3);
        if (!Short) prefix += '-' + f_name.Substring(8, 4);

        return prefix;
    }

    public static byte[] StringToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                            .ToArray();
    }

    public static int HexStringToInt(string hex)
    {
        byte[] ThisBytes = StringToByteArray(hex);
        if (ThisBytes.Length == 2) return BitConverter.ToInt16(ThisBytes, 0);
        if (ThisBytes.Length == 4) return BitConverter.ToInt32(ThisBytes, 0);
        //if (ThisBytes.Length == 8) return BitConverter.ToInt64(ThisBytes, 0);
        return 0;
    }

    static byte[] _get_decoder(string key1, string key2, string key3, string op1, string op2, string op3) {
        byte[] decoder = new byte[256];
        List<byte> values = new List<byte> { };

        for (int e = 0; e < 256; e++) {
            byte KB1 = StringToByteArray(key1)[0];
            byte KB2 = StringToByteArray(key2)[0];
            byte KB3 = StringToByteArray(key3)[0];
            uint d = GetCalc(op3, GetCalc(op2, GetCalc(op1, (uint)e, KB1), KB2), KB3) & 0xFF;
            decoder[e] = (byte)d;
            values.Add((byte) d);
        }
        if (values.Count == 256) return decoder;
        return null;
    }

    private static uint GetCalc(string ThisOperator, uint V1, uint V2)
    {
        if (ThisOperator == "^") return CalcXOR(V1, V2);
        if (ThisOperator == "&") return CalcAND(V1, V2);
        if (ThisOperator == "|") return CalcOR(V1, V2);
        if (ThisOperator == "+") return CalcADD(V1, V2);
        if (ThisOperator == "-") return CalcSUB(V1, V2);
        if (ThisOperator == "*") return CalcMUL(V1, V2);
        if (ThisOperator == "/") return CalcDIV(V1, V2);
        if (ThisOperator == "%") return CalcMOD(V1, V2);
        return 0;
    }

    private static uint CalcXOR(uint V1, uint V2)
    {
        return V1 ^ V2;
    }

    private static uint CalcAND(uint V1, uint V2)
    {
        return V1 & V2;
    }

    private static uint CalcOR(uint V1, uint V2)
    {
        return V1 | V2;
    }

    private static uint CalcADD(uint V1, uint V2)
    {
        return V1 + V2;
    }

    private static uint CalcSUB(uint V1, uint V2)
    {
        return V1 - V2;
    }

    private static uint CalcMUL(uint V1, uint V2)
    {
        return V1 * V2;
    }

    private static uint CalcDIV(uint V1, uint V2)
    {
        return V1 / V2;
    }

    private static uint CalcMOD(uint V1, uint V2)
    {
        return V1 % V2;
    }

    private static string[] swapTwoNumber(string[] list, int k, int i)
    {
        string[] BufferedContent = new string[list.Length];
        for (int i2 = 0; i2 < list.Length; i2++) BufferedContent[i2] = list[i2];

        string temp = BufferedContent[k];
        BufferedContent[k] = BufferedContent[i];
        BufferedContent[i] = temp;
        return BufferedContent;
    }

    private static string[] CheckIntegrity(string[] Bufferedlist, string[] BufferedDone)
    {
        string OutputLine = "";
        for (int i = 0; i < Bufferedlist.Length; i++) OutputLine += Bufferedlist[i] + "|";

        bool Founded = false;
        for (int i = 0; i < BufferedDone.Length; i++)
        {
            if (BufferedDone[i] == OutputLine) Founded = true;
        }
        if (!Founded)
        {
            string[] NewBuffer = new string[BufferedDone.Length + 1];
            for (int i = 0; i < BufferedDone.Length; i++) NewBuffer[i] = BufferedDone[i];
            NewBuffer[BufferedDone.Length] = OutputLine;
            BufferedDone = NewBuffer;
        }
        return BufferedDone;
    }

    public static string[] prnPermut(string[] list)
    {
        string[] DoThisList = list;
        string[] BufferedContent = new string[] { };

        string[] Bufferedlist = { DoThisList[0], DoThisList[1], DoThisList[2] };  //A-B-C
        BufferedContent = CheckIntegrity(Bufferedlist, BufferedContent);

        for (int i = 0; i < DoThisList.Length; i++)
        {
            //A-B-C
            //B-A-C
            //A-C-B
            //C-B-A
            Bufferedlist = swapTwoNumber(DoThisList, 0, i); //SWAP A & XX
            BufferedContent = CheckIntegrity(Bufferedlist, BufferedContent);
            Bufferedlist = swapTwoNumber(DoThisList, 1, i); //SWAP B & XX
            BufferedContent = CheckIntegrity(Bufferedlist, BufferedContent);
        }
        //A-B-c -> B-C-A
        Bufferedlist = swapTwoNumber(DoThisList, 0, 2); //SWAP A & C
        Bufferedlist = swapTwoNumber(Bufferedlist, 0, 1); //SWAP A & B
        BufferedContent = CheckIntegrity(Bufferedlist, BufferedContent);
        //A-B-c -> C-A-B
        Bufferedlist = swapTwoNumber(DoThisList, 0, 1); //SWAP A & B
        Bufferedlist = swapTwoNumber(Bufferedlist, 0, 2); //SWAP A & C
        BufferedContent = CheckIntegrity(Bufferedlist, BufferedContent);

        return BufferedContent;
    }

    public static string[] prnPermutALL(string[] list)
    {
        string[] DoThisList = list;
        string[] BufferedContent = new string[] { };
        int StartInd = 0;

        string[] Bufferedlist = new string[]{};
        //BufferedContent = CheckIntegrity(Bufferedlist, BufferedContent);

        for (int i4 = StartInd; i4 < DoThisList.Length; i4++)
        {
            for (int i3 = StartInd; i3 < DoThisList.Length; i3++)
            {
                for (int i2 = StartInd; i2 < DoThisList.Length; i2++)
                {
                    string[] OperatorsList = new string[3] { DoThisList[i2], DoThisList[i3], DoThisList[i4] };
                    BufferedContent = CheckIntegrity(OperatorsList, BufferedContent);

                    for (int i = StartInd; i < 3; i++)
                    {
                        Bufferedlist = swapTwoNumber(OperatorsList, StartInd, i); //SWAP A & XX
                        BufferedContent = CheckIntegrity(Bufferedlist, BufferedContent);
                        Bufferedlist = swapTwoNumber(OperatorsList, StartInd + 1, i); //SWAP B & XX
                        BufferedContent = CheckIntegrity(Bufferedlist, BufferedContent);
                    }
                }
            }
        }

        return BufferedContent;
    }

    private static void MakeEncoderArray()
    {
        EncodersBytes = new byte[256];
        if (DecodersBytes.Length != EncodersBytes.Length)
        {
            GForm_Main_0.method_1("Something went wrong getting Encoders bytes!");
        }
        else
        {
            for (int i = 0; i < EncodersBytes.Length; i++)
            {
                EncodersBytes[DecodersBytes[i]] = (byte) i;
            }
        }
    }

    private static List<byte[]> decrypt(string search_value)
    {
        //# sometimes there is an extra character after each character
        //# 37805-RBB-J530 -> 3377880550--RRBCBA--JA503000
        //string search_value_padded = search_value.Join(".", search_value);
        string search_value_padded = "";
        foreach (char ThisChar in search_value)
        {
            search_value_padded += ThisChar + ".";
        }

        string search_exact = search_value.ToUpper();
        string search_padded = search_value_padded.ToUpper();
        GForm_Main_0.method_1("Searching:");
        GForm_Main_0.method_1("'" + search_exact + "' and '" + search_padded + "'");

        string[] operators = new string[8] {
            "fn:^", //XOR
            "fn:&", //AND
            "fn:|", //OR
            "fn:+", //ADD
            "fn:-", //SUB
            "fn:*", //MUL
            "fn:/", //DIV
            "fn:%", //MOD
        };

        if (_keys.Length != 3)
        {
            GForm_Main_0.method_1("excatly three keys currently required, cannot perform decryption!");
            return new List<byte[]> { };
        }

        //#####################################################################################################
        //This code is for trying all Keys and cypher methods to find the correct decrypting cypher
        /*List<string> keys = new List<string> { };
        for (int i = 0; i < _keys.Length; i++) {
            string k = _keys[i].ToString("x2");
            keys.Add(String.Format("val:" + k + ",sym:" + "k{0}", i));
        }
        string[] key_perms = prnPermut(keys.ToArray());
        string[] op_perms = prnPermutALL(operators);*/
        //#####################################################################################################
        //BUT the cypher seem to always be: (((i ^ k2) + k1) - k0) & 0xFF so use this code instead for 1000x faster decryption
        string KeyPermStr = "";
        for (int i = _keys.Length - 1; i >= 0; i--)
        {
            string k = _keys[i].ToString("x2");
            KeyPermStr += String.Format("val:" + k + ",sym:" + "k{0}", i) + "|";
        }
        string OPPermStr = "fn:^,o1|fn:+,o2|fn:-,o3|";
        string[] key_perms = new string[] { KeyPermStr };
        string[] op_perms = new string[] { OPPermStr };
        //#####################################################################################################

        List<string> display_ciphers = new List<string> { };
        List<byte[]> firmware_candidates_0 = new List<byte[]> { };
        List<byte[]> attempted_decoders = new List<byte[]> { };

        int CurrentDone = 0;
        foreach (string Line in key_perms)
        {
            string k1 = "";
            string k2 = "";
            string k3 = "";
            string o1 = "";
            string o2 = "";
            string o3 = "";
            string k1_CMD = "";
            string k2_CMD = "";
            string k3_CMD = "";
            string[] SplittedParams = Line.Split('|');
            int DoneCount = 0;

            //Get keys values
            foreach (string Commands in SplittedParams)
            {
                string[] SplittedParamsValue = Commands.Split(',');

                if (SplittedParamsValue[0].Contains("val"))
                {
                    string thisvalue = SplittedParamsValue[0].Split(':')[1];
                    string thiscommand = SplittedParamsValue[1].Split(':')[1];
                    if (DoneCount == 0)
                    {
                        k1 = thisvalue;
                        k1_CMD = thiscommand;
                    }
                    if (DoneCount == 1)
                    {
                        k2 = thisvalue;
                        k2_CMD = thiscommand;
                    }
                    if (DoneCount == 2)
                    {
                        k3 = thisvalue;
                        k3_CMD = thiscommand;
                    }
                    DoneCount++;
                }
            }

            //Get operators values
            foreach (string LineOP in op_perms)
            {
                string[] SplittedParamsOP = LineOP.Split('|');
                DoneCount = 0;
                foreach (string Commands in SplittedParamsOP)
                {
                    string[] SplittedParamsValue = Commands.Split(',');

                    if (SplittedParamsValue[0].Contains("fn"))
                    {
                        string thisvalue = SplittedParamsValue[0].Split(':')[1];
                        if (DoneCount == 0) o1 = thisvalue;
                        if (DoneCount == 1) o2 = thisvalue;
                        if (DoneCount == 2) o3 = thisvalue;
                        DoneCount++;
                    }
                }

                //Perform decoding of bytes and search for ECU name string
                int Percent = (CurrentDone * 100) / (key_perms.Length * op_perms.Length);
                GForm_Main_0.method_4(Percent);
                CurrentDone++;

                DecodersBytes = _get_decoder(k1, k2, k3, o1, o2, o3);
                //MakeEncoderArray();
                if (DecodersBytes != null && !attempted_decoders.Contains(DecodersBytes))
                {
                    attempted_decoders.Add(DecodersBytes);

                    byte[] candidate = new byte[_firmware_encrypted.Length];
                    char[] decryptedCharArr = new char[_firmware_encrypted.Length];
                    for (int i2 = 0; i2 < _firmware_encrypted.Length; i2++)
                    {
                        byte ThisByte = DecodersBytes[_firmware_encrypted[i2]];
                        candidate[i2] = ThisByte;
                        decryptedCharArr[i2] = (char) ThisByte;
                    }
                    string decrypted = new string(decryptedCharArr);

                    if ((decrypted.Contains(search_exact) || decrypted.Contains(search_padded)) && !firmware_candidates_0.Contains(candidate))
                    {
                        MakeEncoderArray();
                        GForm_Main_0.method_Log("X");
                        firmware_candidates_0.Add(candidate);
                        display_ciphers.Add(string.Format("(((i {0} {1}) {2} {3}) {4} {5}) & 0xFF",
                                o1, k1_CMD,
                                o2, k2_CMD,
                                o3, k3_CMD));
                    }
                    else
                    {
                        GForm_Main_0.method_Log(".");
                    }
                    Application.DoEvents();
                }
            }
        }

        GForm_Main_0.ResetProgressBar();

        foreach (string cipher in display_ciphers) {
            GForm_Main_0.method_1(String.Format("cipher: {0}", cipher));
        } 
        return firmware_candidates_0;
    }
}
