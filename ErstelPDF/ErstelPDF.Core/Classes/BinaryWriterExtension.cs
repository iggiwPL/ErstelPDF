using System.Text;

namespace ErstelPDF.Core
{
    // Used for content of the PDF
    public static class BinaryWriterExtension
    {
        public static void WriteStringAsASCII(this BinaryWriter writer, string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            writer.Write(bytes);
        }
    }
}
