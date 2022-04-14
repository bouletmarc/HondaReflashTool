using System;
using System.Runtime.CompilerServices;

internal class Class_ECUS
{
    internal Class_ECUS(string string_4, string string_5, byte byte_1, string string_6, int int_4, int int_6)
    {
        this.RomSize_String = string_4;
        this.ECU_Byte = byte_1;
        this.ECU_Byte_String = string_6;
        this.Processor = string_5;
        this.ReadingSize = int_4 - 1;
        this.FirmwareSize = int_6;
        this.RomSize = int_4;
    }

    public string RomSize_String { get; set; }
    public byte ECU_Byte { get; set; }
    public string ECU_Byte_String { get; set; }
    public string Processor { get; set; }
    public int ReadingSize { get; set; }
    public int FirmwareSize { get; set; }
    public int RomSize { get; set; }
}

