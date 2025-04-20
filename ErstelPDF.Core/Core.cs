using System.Text;
using ErstelPDF.Stacks;
using ErstelPDF.Dictionary;


namespace ErstelPDF.Core
{
    public class ErstelCore
    {
        int objectID = 1;
        int rootObjectID = 0;
        
        
        public void CreateEmptyFile(string path)
        {
            // For testing adding content
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetHeaderPDF());
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetCatalogObject(ref objectID, ref rootObjectID));
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetOutlinesObject(ref objectID));
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetPagesObject(ref objectID));
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetPageObject(ref objectID));

            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetXrefObject(ErstelStacks.DocumentTextContent));
            ErstelStacks.DocumentTextContent.Enqueue(DictionaryPDF.GetTrailerObject(ErstelStacks.DocumentTextContent, rootObjectID));


            using (BinaryWriter writer = new BinaryWriter(File.Create(path), Encoding.ASCII))
            {
                foreach(string PDFObject in ErstelStacks.DocumentTextContent)
                {
                    writer.WriteASCIIAsString(PDFObject);
                }
            }
        }
        
    }


    
}
