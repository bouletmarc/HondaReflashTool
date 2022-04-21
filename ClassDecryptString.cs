using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x020001FD RID: 509
internal class ClassDecryptString
{
    // Token: 0x0600163F RID: 5695 RVA: 0x0016A828 File Offset: 0x00168A28
    internal static uint DecryptThisString(string string_0)
    {
        uint num = 0;
        if (string_0 != null)
        {
            num = 2166136261U;
            for (int i = 0; i < string_0.Length; i++)
            {
                num = ((uint)string_0[i] ^ num) * 16777619U;
            }
        }
        return num;
    }
}
