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
        public void AddObject(string content, ErstelStacks erstelStacks)
        {
            erstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(content));
        }
        
        public void AddEmptyPageStructure(IByteCounter IbyteCounter,IXReferenceTransformer IxReferenceTransformer, 
            ITrailerTransformer ItrailerTransformer,ErstelStacks erstelStacks,DictionaryPDF dictionaryPDF, 
            ref int objectID, ref int rootObjectID)
        {
            IHeaderPDF headerPDF = new HeaderPDF();
            AddObject(headerPDF.GetHeader(HeaderPDF.VersionPDF.PDF_1_0), erstelStacks);


            // Calling order for every object: 1. Call constructor 2. count objects 3. synchronise with main counter 4. get this object
            ICatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(objectID, rootObjectID, CatalogObjectPDF.PageOutlineMode.Outlines);
            catalogObjectPDF.CountObjects();
            catalogObjectPDF.SyncMainCounter(ref objectID, ref rootObjectID);
            AddObject(catalogObjectPDF.GetObject(), erstelStacks);

            //AddObject(dictionaryPDF.GetCatalogObject(ref objectID, ref rootObjectID), erstelStacks);
            //AddObject(dictionaryPDF.GetOutlinesObject(ref objectID), erstelStacks);

            IOutlinesObjectPDF outlinesObjectPDF = new OutlinesObjectPDF(objectID);
            outlinesObjectPDF.CountObjects();
            outlinesObjectPDF.SyncMainCounter(ref objectID);
            AddObject(outlinesObjectPDF.GetObject(), erstelStacks);



            //AddObject(dictionaryPDF.GetPagesObject(ref objectID), erstelStacks);
            IPagesObjectPDF pagesObjectPDF = new PagesObjectPDF(objectID, 1);
            pagesObjectPDF.CountObjects();
            pagesObjectPDF.SyncMainCounter(ref objectID);
            AddObject(pagesObjectPDF.GetObject(), erstelStacks);

            IPageObjectPDF pageObjectPDF = new PageObjectPDF(objectID);
            pageObjectPDF.CountObjects();
            pageObjectPDF.SyncMainCounter(ref objectID);
            AddObject(pageObjectPDF.GetObject(), erstelStacks);

            //AddObject(dictionaryPDF.GetPageObject(ref objectID), erstelStacks);

            AddObject(dictionaryPDF.GetXrefObject(IxReferenceTransformer,IbyteCounter,erstelStacks.DocumentTextContent,
                erstelStacks.XreferenceTable), erstelStacks);
            AddObject(dictionaryPDF.GetTrailerObject(IbyteCounter, ItrailerTransformer,IxReferenceTransformer, 
                erstelStacks.DocumentTextContent, rootObjectID), erstelStacks);
        }
        public void WriteAllObjects(BinaryWriter writer, ErstelStacks erstelStacks)
        {
            foreach (LinkedDocumentType PDFObject in erstelStacks.DocumentTextContent)
            {
                writer.WriteStringAsASCII(PDFObject.Content);
            }
        }
        public void CreateFile(string path, ErstelStacks erstelStacks)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Create(path), Encoding.ASCII))
            {
                WriteAllObjects(writer, erstelStacks);
            }
        }


        // Now this is self contained
        public void CompileToPDF(string path)
        {
            int objectID = 1;
            int rootObjectID = 0;


            var _erstelStacks = new ErstelStacks();
            var _dictionaryPDF = new DictionaryPDF();

            // Interfaces dependencies
            var _ByteCounter = new ByteCounter();
            var _xReferenceTransformer = new XReferenceTransformer();
            var _trailerTransformer = new TrailerTransformer();

            try
            {

                // Adds empty page structure to registers
                AddEmptyPageStructure(_ByteCounter, _xReferenceTransformer, _trailerTransformer,
                    _erstelStacks,_dictionaryPDF ,ref objectID, ref rootObjectID);

                // For testing adding contet
                CreateFile(path, _erstelStacks);


            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create PDF file: {ex.Message}");
            }
        }
        public async Task CompileToPDFAsync(string path)
        {
            await Task.Run(() => {
                int objectID = 1;
                int rootObjectID = 0;


                var _erstelStacks = new ErstelStacks();
                var _dictionaryPDF = new DictionaryPDF();

                // Interfaces dependencies
                var _ByteCounter = new ByteCounter();
                var _xReferenceTransformer = new XReferenceTransformer();
                var _trailerTransformer = new TrailerTransformer();

                try
                {

                    // Adds empty page structure to registers
                    AddEmptyPageStructure(_ByteCounter, _xReferenceTransformer, _trailerTransformer, 
                        _erstelStacks, _dictionaryPDF, ref objectID, ref rootObjectID);

                    // For testing adding contet
                    CreateFile(path, _erstelStacks);


                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to create PDF file: {ex.Message}");
                }

            });

        }


    }


    
}
