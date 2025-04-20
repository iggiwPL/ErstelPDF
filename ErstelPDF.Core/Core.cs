using System.Text;
using ErstelPDF.Stacks;
using ErstelPDF.Dictionary;
using ErstelPDF.DataTypes;


namespace ErstelPDF.Core
{
    public class ErstelCore
    {
        int objectID = 1;
        int rootObjectID = 0;
        
        
        public void CreateEmptyFile(string path)
        {
            try
            {
                // For testing adding content
                StacksAliases.AddContentToLinked(DictionaryPDF.GetHeaderPDF());
                StacksAliases.AddContentToLinked(DictionaryPDF.GetCatalogObject(ref objectID, ref rootObjectID));
                StacksAliases.AddContentToLinked(DictionaryPDF.GetOutlinesObject(ref objectID));
                StacksAliases.AddContentToLinked(DictionaryPDF.GetPagesObject(ref objectID));
                StacksAliases.AddContentToLinked(DictionaryPDF.GetPageObject(ref objectID));

                StacksAliases.AddContentToLinked(DictionaryPDF.GetXrefObject(ErstelStacks.DocumentTextContent));
                StacksAliases.AddContentToLinked(DictionaryPDF.GetTrailerObject(ErstelStacks.DocumentTextContent, rootObjectID));


                using (BinaryWriter writer = new BinaryWriter(File.Create(path), Encoding.ASCII))
                {
                    foreach (LinkedDocumentType PDFObject in ErstelStacks.DocumentTextContent)
                    {
                        writer.WriteStringAsASCII(PDFObject.Content);
                    }
                }

                StacksAliases.ReleaseAllContent();
            }
            catch(Exception ex) 
            {
                throw new Exception($"Failed to create PDF file: {ex.Message}");
            }
        }
        
    }


    
}
