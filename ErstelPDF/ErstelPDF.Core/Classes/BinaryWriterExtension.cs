using System.Text;

namespace ErstelPDF.Core
{
    // Used for content of the PDF
    public static class BinaryWriterExtension
    {

        // This should be rewritten in C++ and attached because it processes strings in time higher than 5 ms or above. So 
        // this will be deprecated soon.
        public static void WriteStringAsASCII(this BinaryWriter writer, string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            writer.Write(bytes);
        }
    }
}
