using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Core
{
    // Used for generating cross reference table - byte offsets calculating. This will be used in newer version.
    internal static class ByteCounter
    {
        static int CountBytesObject(string content, ref int totalBytes)
        {
            return Encoding.UTF8.GetByteCount(content) + 1;
        }
    }
}
