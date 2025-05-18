using System.Text;
using ErstelPDF.Stacks;
using ErstelPDF.Dictionary;
using ErstelPDF.DataTypes;
using System.IO;


namespace ErstelPDF.Core
{
    public class ErstelCore
    {
        int objectID = 1;
        int rootObjectID = 0;

        ErstelStacks _erstelStacks;
        DictionaryPDF _dictionaryPDF; 

        public ErstelCore()
        {
            _erstelStacks = new ErstelStacks();
            _dictionaryPDF = new DictionaryPDF();
        }

        public void AddObject(string content)
        {
            _erstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(content));
        }
        
        public void AddEmptyPageStructure()
        {
            AddObject(_dictionaryPDF.GetHeaderPDF());
            AddObject(_dictionaryPDF.GetCatalogObject(ref objectID, ref rootObjectID));
            AddObject(_dictionaryPDF.GetOutlinesObject(ref objectID));
            AddObject(_dictionaryPDF.GetPagesObject(ref objectID));
            AddObject(_dictionaryPDF.GetPageObject(ref objectID));

            AddObject(_dictionaryPDF.GetXrefObject(_erstelStacks.DocumentTextContent, _erstelStacks.XreferenceTable));
            AddObject(_dictionaryPDF.GetTrailerObject(_erstelStacks.DocumentTextContent, rootObjectID));
        }
        public void WriteAllObjects(BinaryWriter writer)
        {
            foreach (LinkedDocumentType PDFObject in _erstelStacks.DocumentTextContent)
            {
                writer.WriteStringAsASCII(PDFObject.Content);
            }
        }
        public void CreateFile(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(path), Encoding.ASCII))
            {
                WriteAllObjects(writer);
            }
        }

        public void CompileToPDF(string path)
        {
            try
            {
                // Adds empty page structure to registers
                AddEmptyPageStructure();

                // For testing adding contet
                CreateFile(path);

                
            }
            catch(Exception ex) 
            {
                throw new Exception($"Failed to create PDF file: {ex.Message}");
            }
        }
        
    }


    
}
