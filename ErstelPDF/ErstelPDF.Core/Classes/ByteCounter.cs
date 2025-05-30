﻿using System.Text;

namespace ErstelPDF.Core
{
    // Used for generating cross reference table and trailer
    public class ByteCounter : IByteCounter
    {
        public int CountBytesObject(string content)
        {
            return Encoding.ASCII.GetBytes(content + "\n").Length;
        }
    }
}
