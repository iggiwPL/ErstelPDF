using System.Text;

namespace ErstelPDF.Core
{
    // Used for generating cross reference table and trailer
    public class ByteCounter : IByteCounter
    {
        // This should be rewritten in C++ and attached because it processes strings in time higher than 5 ms or above. So 
        // this will be deprecated soon.

        public int CountBytesObject(string content)
        {
            return Encoding.ASCII.GetBytes(content + "\n").Length;
        }
    }
}
