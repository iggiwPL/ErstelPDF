using System.IO;
using System.Text;
using System.Runtime.CompilerServices;
using ErstelPDF.Stacks;
using ErstelPDF.Dictionary;

namespace ErstelPDF.Core
{
    public class ErstelCore
    {
        // Reference classes
        DictionaryPDF dictionaryPDF = new DictionaryPDF();
        ErstelStacks  erstelStacks = new ErstelStacks();

        int objectID = 1;
        public void CreateEmptyFile(string path)
        {
            // For testing adding content
            erstelStacks.DocumentTextContent.Enqueue(dictionaryPDF.GetHeaderPDF());
            erstelStacks.DocumentTextContent.Enqueue(dictionaryPDF.GetCatalogObject(ref objectID));

            using (BinaryWriter writer = new BinaryWriter(File.Create(path)))
            {
                for(int i = 0; i <= erstelStacks.DocumentTextContent.Count; i++)
                {
                    writer.WriteLine(erstelStacks.DocumentTextContent.Dequeue());
                }
            }
        }
        
    }

    // Used for generating cross reference table - byte offsets calculating. This will be used in newer version.
    internal static class ByteCounter
    {
        static int CountBytesObject(string content, ref int totalBytes)
        {
            return Encoding.UTF8.GetByteCount(content) + 1;
        }
    }


    // Used for content of the PDF
    internal static class BinaryWriter_Extension
    {
        public static void WriteLine(this BinaryWriter writer,string text)
        {
            writer.Write(text);
            writer.Write('\n'); // Test
        }
    }

    
}
