using System.Text;
using ErstelPDF.Stacks;
using ErstelPDF.Dictionary;
using ErstelPDF.DataTypes;
using System.IO;
using ErstelPDF.Transforms;


namespace ErstelPDF.Core
{
    public class ErstelCore
    {

        ErstelStacks _erstelStacks;
        DictionaryPDF _dictionaryPDF; 

        IByteCounter _ByteCounter;
        IXReferenceTransformer _xReferenceTransformer;
        ITrailerTransformer _trailerTransformer;

        public void AddObject(string content)
        {
            _erstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(content));
        }
        
        public void AddEmptyPageStructure(IByteCounter IbyteCounter,IXReferenceTransformer IxReferenceTransformer, ITrailerTransformer ItrailerTransformer,ErstelStacks erstelStacks, ref int objectID, ref int rootObjectID)
        {
            AddObject(_dictionaryPDF.GetHeaderPDF());
            AddObject(_dictionaryPDF.GetCatalogObject(ref objectID, ref rootObjectID));
            AddObject(_dictionaryPDF.GetOutlinesObject(ref objectID));
            AddObject(_dictionaryPDF.GetPagesObject(ref objectID));
            AddObject(_dictionaryPDF.GetPageObject(ref objectID));

            AddObject(_dictionaryPDF.GetXrefObject(IxReferenceTransformer,IbyteCounter,erstelStacks.DocumentTextContent, erstelStacks.XreferenceTable));
            AddObject(_dictionaryPDF.GetTrailerObject(IbyteCounter, ItrailerTransformer,IxReferenceTransformer, erstelStacks.DocumentTextContent, rootObjectID));
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


        // Now thi is self contained
        public void CompileToPDF(string path)
        {
            int objectID = 1;
            int rootObjectID = 0;


            _erstelStacks = new ErstelStacks();
            _dictionaryPDF = new DictionaryPDF();

            // Interfaces dependencies
            _ByteCounter = new ByteCounter();
            _xReferenceTransformer = new XReferenceTransformer();
            _trailerTransformer = new TrailerTransformer();

            try
            {

                // Adds empty page structure to registers
                AddEmptyPageStructure(_ByteCounter, _xReferenceTransformer, _trailerTransformer, _erstelStacks, ref objectID, ref rootObjectID);

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
