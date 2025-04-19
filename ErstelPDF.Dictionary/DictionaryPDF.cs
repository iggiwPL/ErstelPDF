using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    internal static class DictionaryPDF
    {
        public static string GetHeaderPDF()
        {
            return "%PDF-1.0";
        }
        public static string GetCatalogObject(ref int currentobjectID)
        {
            int catalogID = currentobjectID;
            int pagesID = currentobjectID + 1;
            int outlinesID = currentobjectID + 2;

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

        public static string GetPageObject(ref int objectID)
        {
            int pagesID = objectID;
            int pageID = objectID + 1;

            string template = $"{pagesID} 0 obj\n" +
                             "<<\n" +
                             $"/Type /Pages /Kids [{pageID} 0 R] /Count 1\n" +
                             ">>\n" +
                             "endobj\n" +
                             $"{pageID} 0 obj\n" +
                             "<<\n" +
                             $"/Type /Page /Parent {pagesID} 0 R /MediaBox [0 0 612 792]\n" +
                             ">>\n" +
                             "endobj\n";

            objectID += 2;  // Increment by 2 since we created 2 objects
            return template;
        }
    }
}
