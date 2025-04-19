using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Core
{
    // Used for generating cross reference table
    internal static class ByteCounter
    {
        public static int CountBytesObject(string content)
        {
            return Encoding.ASCII.GetBytes(content + "\n").Length;
        }
    }
}
