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
    private static byte[] _firmware_encrypted = new byte[] { };
    public static UInt32 start = 0U;
    public static UInt32 size = 0U;

    private static GForm_Main GForm_Main_0;

    public static void Load(ref GForm_Main GForm_Main_1)
    {
        GForm_Main_0 = GForm_Main_1;
    }

    public static byte[] Decompress(string ThisFile)
    {
        Stream compressedStream = new MemoryStream(File.ReadAllBytes(ThisFile));
        var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress);
        MemoryStream resultStream = new MemoryStream();
        zipStream.CopyTo(resultStream);
        return resultStream.ToArray();
    }


    public static void LoadRWD(string f_name, bool FullDecrypt)
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

        byte[] firmware = Slice(data, idx, data.Length - 4);
        idx += firmware.Length;

        UInt32 checksum = ReadUInt32BE(data, idx);
        idx += 4;

        if (idx != data.Length) GForm_Main_0.method_1("not at end of file after unpacking");
        if ((headers3.Length / 16) != (headers4.Length / 6)) GForm_Main_0.method_1("different number of versions and security access tokens");

        _firmware_encrypted = firmware;
        _keys = headers5;

        if (FullDecrypt) DecryptRWD(f_name);
    }

    private static void DecryptRWD(string f_name)
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

        if (firmware_candidates.Count > 1) GForm_Main_0.method_1("multiple sets of keys resulted in data containing the part number");

        //###################################################################
        //###################################################################
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
        foreach (byte[] f_data in firmware_candidates)
        //foreach (byte[] f_data in firmware_good)
        {
            uint start_addr = start;
            string ThisPath = Path.GetDirectoryName(f_name) + @"\" + Path.GetFileNameWithoutExtension(f_name).Replace(".rwd", "").Replace(".RWD", "") + ".0x" + start_addr.ToString("X") + ".bin";
            File.Create(ThisPath).Dispose();
            File.WriteAllBytes(ThisPath, f_data);   //-> f_data[start_addr:]
        }
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
        GForm_Main_0.method_1("Searching:");
        GForm_Main_0.method_1(search_value);
        GForm_Main_0.method_1(search_value_padded);

        string search_exact = search_value;
        string search_padded = search_value_padded;
        //string search_exact = re.compile(".*" + search_value + ".*", flags = re.IGNORECASE | re.MULTILINE | re.DOTALL);           //###############################
        //string search_padded = re.compile(".*" + search_value_padded + ".*", flags = re.IGNORECASE | re.MULTILINE | re.DOTALL);   //###############################
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

        List<string> keys = new List<string> { };

        for (int i = 0; i < _keys.Length; i++) {
            string k = _keys[i].ToString("x2");
            keys.Add(String.Format("val:" + k + ",sym:" + "k{0}", i));
        }
        //assert len(keys) == 3, "excatly three keys currently required!";

        List<byte[]> firmware_candidates_0 = new List<byte[]> { };

        string[] key_perms = prnPermut(keys.ToArray());
        string[] op_perms = prnPermutALL(operators);

        //Console.WriteLine(key_perms.Length);
        //Console.WriteLine(op_perms.Length);

        List<string> display_ciphers = new List<string> { };
        List<byte[]> attempted_decoders = new List<byte[]> { };

        int CurrentDone = 0;
        foreach (string Line in key_perms)
        {
            //Console.WriteLine(Line);
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

                int Percent = (CurrentDone * 100) / (key_perms.Length * op_perms.Length);
                GForm_Main_0.method_4(Percent);
                CurrentDone++;

                byte[] decoder = _get_decoder(k1, k2, k3, o1, o2, o3);
                if (decoder != null && !attempted_decoders.Contains(decoder))
                {
                    attempted_decoders.Add(decoder);

                    byte[] candidate = new byte[_firmware_encrypted.Length];
                    char[] decryptedCharArr = new char[_firmware_encrypted.Length];
                    for (int i2 = 0; i2 < _firmware_encrypted.Length; i2++)
                    {
                        byte ThisByte = decoder[_firmware_encrypted[i2]];
                        candidate[i2] = ThisByte;
                        decryptedCharArr[i2] = (char) ThisByte;
                    }
                    string decrypted = new string(decryptedCharArr);

                    if ((decrypted.Contains(search_exact) || decrypted.Contains(search_padded)) && !firmware_candidates_0.Contains(candidate))
                    {
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

        GForm_Main_0.method_1(Environment.NewLine);
        foreach (string cipher in display_ciphers) {
            GForm_Main_0.method_1(String.Format("cipher: {0}", cipher));
        } 
        return firmware_candidates_0;
    }
}
