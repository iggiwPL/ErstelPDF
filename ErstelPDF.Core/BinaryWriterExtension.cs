using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Core
{
    // Used for content of the PDF
    internal static class BinaryWriterExtension
    {
        public static void WriteASCIIAsString(this BinaryWriter writer, string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            writer.Write(bytes);
        }
    }
}
