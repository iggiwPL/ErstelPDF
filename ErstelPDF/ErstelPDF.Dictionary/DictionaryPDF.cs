using ErstelPDF.Transforms;
using ErstelPDF.Stacks;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Dictionary
{
    public class DictionaryPDF
    {
        XReferenceTransformer _xreftransformer;
        TrailerTransformer _trailertransformer;

        public DictionaryPDF()
        {
            _xreftransformer = new XReferenceTransformer();
            _trailertransformer = new TrailerTransformer();
        }
        public string GetHeaderPDF()
        {
            return "%PDF-1.0\n";
        }
        public string GetCatalogObject(ref int currentobjectID, ref int rootObjectID)
        {
            rootObjectID = currentobjectID;

            int catalogID = currentobjectID;
            int pagesID = currentobjectID + 2;
            int outlinesID = currentobjectID + 1;
            

            string template = $"{catalogID} 0 obj\n" +
                    "<<\n" +
                    "/Type /Catalog\n" +
                    $"/Pages {pagesID} 0 R\n" +
                    $"/Outlines {outlinesID} 0 R\n" +
                    "/PageMode /UseOutlines\n" +
                    ">>\n" +
                    "endobj\n";

            currentobjectID++;
            return template;
        }

        public string GetOutlinesObject(ref int objectID)
        {
            int outlinesID = objectID;

            string template = $"{outlinesID} 0 obj\n" +
                    "<<\n" +
                    "/Type /Outlines\n" +
                    "/Count 0\n" +
                    ">>\n" +
                    "endobj\n";

            objectID++;
            return template;
        }
        public string GetPagesObject(ref int objectID)
        {
            int pagesID = objectID;
            int pageID = objectID + 1;

            string template = $"{pagesID} 0 obj\n" +
                            "<<\n" +
                            $"/Type /Pages /Kids [{pageID} 0 R] /Count 1\n" +
                            ">>\n" +
                            "endobj\n";
            objectID++;
            return template;
        }
        public string GetPageObject(ref int objectID)
        {
            int pagesID = objectID - 1;
            int pageID = objectID;

            string template = $"{pageID} 0 obj\n" +
                              "<<\n" +
                              $"/Type /Page /Parent {pagesID} 0 R /MediaBox [0 0 612 792]\n" +
                              ">>\n" +
                             "endobj\n";

            objectID++;  
            return template;
        }
        public string GetXrefObject(Queue<LinkedDocumentType> PDFObjects, Queue<XReferenceType> XrefTable)
        {
            _xreftransformer.Transform(PDFObjects, XrefTable);

            string xref_header = $"xref 0 {_xreftransformer.RowsCountProperty}\n";
            string xref_offsets = "";
            string template = "";

            foreach (XReferenceType elem in XrefTable)
            {
                xref_offsets = xref_offsets + $"{elem.ByteOffset} {elem.GenerationNumber} {elem.AttributeObject}\n";
            }

            // Merge xref header and offsets to one
            template += xref_header;
            template += xref_offsets;

            return template;
        }
        public string GetTrailerObject(Queue<LinkedDocumentType> PDFObjects, int rootObjectID)
        {
            _trailertransformer.Transform(PDFObjects);

            string template = "trailer\n" +
                              "<<\n" + 
                              $"/Size {_xreftransformer.RowsCountProperty}\n" +
                              $"/Root {rootObjectID} 0 R\n" +
                              ">>\n" +
                              "startxref\n" +
                              $"{_trailertransformer.XrefByteBeginProperty}\n" +
                              "%%EOF\n";
            return template;
        }
    }
}
