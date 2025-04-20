using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Transforms;
using ErstelPDF.Core;
using ErstelPDF.Stacks;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Dictionary
{
    internal static class DictionaryPDF
    {

        public static string GetHeaderPDF()
        {
            return "%PDF-1.0\n";
        }
        public static string GetCatalogObject(ref int currentobjectID, ref int rootObjectID)
        {
            int catalogID = currentobjectID;
            rootObjectID = currentobjectID;

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

            currentobjectID++;  // Only increment by 1, as we're only creating one object here
            return template;
        }

        public static string GetOutlinesObject(ref int objectID)
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
        public static string GetPagesObject(ref int objectID)
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
        public static string GetPageObject(ref int objectID)
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
        public static string GetXrefObject(Queue<string> PDFObjects)
        {
            XReferenceTransformer.Transform(PDFObjects);
            string xref_header = $"xref 0 {XReferenceTransformer.RowsCountProperty}\n";
            string xref_offsets = "";
            string template = "";

            foreach (XReferenceType elem in ErstelStacks.XreferenceTable)
            {
                xref_offsets = xref_offsets + $"{elem.ByteOffset} {elem.GenerationNumber} {elem.AttributeObject}\n";
            }

            template = template + xref_header;
            template = template + xref_offsets;

            return template;
        }
        public static string GetTrailerObject(Queue<string> PDFObjects, int rootObjectID)
        {
            TrailerTransformer.Transform(PDFObjects);
            string template = "trailer\n" +
                              "<<\n" + 
                              $"/Size {XReferenceTransformer.RowsCountProperty}\n" +
                              $"/Root {rootObjectID} 0 R\n" +
                              ">>\n" +
                              "startxref\n" +
                              $"{TrailerTransformer.XrefByteBeginProperty}\n" +
                              "%%EOF\n";
            return template;
        }
    }
}
