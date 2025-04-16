using System.IO;
using System.Runtime.CompilerServices;
using ErstelPDF.Stacks;
using ErstelPDF.Dictionary;

namespace ErstelPDF.Core
{
    public class ErstelCore
    {
        DictionaryPDF dictionaryPDF = new DictionaryPDF();

        public void CreateEmptyFile(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
            {
                writer.WriteLine(dictionaryPDF.GetHeaderPDF());
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
