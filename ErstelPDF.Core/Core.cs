using System.IO;
using System.Runtime.CompilerServices;
using ErstelPDF.Stacks;
using ErstelPDF.Dictionary;

namespace ErstelPDF.Core
{
    public class ErstelCore
    {
        DictionaryPDF dictionaryPDF = new DictionaryPDF();
        int objectID = 1;
        public void CreateEmptyFile(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
            {
                writer.WriteLine(dictionaryPDF.GetHeaderPDF());
                writer.WriteLine(dictionaryPDF.GetCatalogObject(ref objectID));
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
