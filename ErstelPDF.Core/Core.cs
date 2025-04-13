using System.IO;
using System.Runtime.CompilerServices;
using ErstelPDF.Stacks;

namespace ErstelPDF.Core
{
    public class ErstelCore
    {
        public void CreateEmptyFile(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
            {
                writer.WriteLine("%PDF-1.0");
            }
        }
        
    }




    // Used for header of the PDF
    internal static class BinaryWriter_Extension
    {
        public static void WriteLine(this BinaryWriter writer,string text)
        {
            writer.Write(text);
            writer.Write('\n'); // Test
        }
    }

    
}
