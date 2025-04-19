using System.IO;
using System.Text;
using System.Runtime.CompilerServices;
using ErstelPDF.Stacks;
using ErstelPDF.Dictionary;
using ErstelPDF.Transforms;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Core
{
    public class ErstelCore
    {
        // Reference classes
        

        int objectID = 1;
        int rootObjectID = 0;
        
        
        public void CreateEmptyFile(string path)
        {
            // For testing adding content
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetHeaderPDF());
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetCatalogObject(ref objectID, ref rootObjectID));
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetOutlinesObject(ref objectID));

            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetPageObject(ref objectID));

            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetXrefObject(ErstelStacks.DocumentTextContent));
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetTrailerObject(ErstelStacks.DocumentTextContent, rootObjectID));


            using (BinaryWriter writer = new BinaryWriter(File.Create(path), Encoding.ASCII))
            {
                // Process all items in the queue
                /*
                while (erstelStacks.DocumentTextContent.Count > 0)
                {
                    string PDFObject = erstelStacks.DocumentTextContent.Dequeue();
                    PDFObjectBytes += byteCounter.CountBytesObject(PDFObject);
                    

                    writer.WriteLine(PDFObject);
                }
                */
                // xrefTransformer.Transform(ErstelStacks.DocumentTextContent);

                /*
                foreach(XReferenceType elem in ErstelStacks.XreferenceTable)
                {
                    writer.WriteLine($"{elem.ByteOffset} {elem.GenerationNumber} {elem.AttributeObject}");
                }
                */
                foreach(string PDFObject in ErstelStacks.DocumentTextContent)
                {
                    writer.WriteLine(PDFObject);
                }
                // writer.WriteLine(DictionaryPDF.GetXrefObject(ErstelStacks.DocumentTextContent));
            }
        }
        
    }


    
}
