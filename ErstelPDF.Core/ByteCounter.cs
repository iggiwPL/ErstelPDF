using System.Text;

namespace ErstelPDF.Core
{
    // Used for generating cross reference table and trailer
    internal static class ByteCounter
    {
        public static int CountBytesObject(string content)
        {
            return Encoding.ASCII.GetBytes(content + "\n").Length;
        }
    }
}
