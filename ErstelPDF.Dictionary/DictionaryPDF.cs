using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    internal class DictionaryPDF
    {
        public string GetHeaderPDF()
        {
            return "%PDF-1.0";
        }
        public string GetCatalogObject(ref int currentobjectID)
        {
            string template = $"{currentobjectID} 0 obj\n" +
                    "<<\n" +
                    "/Type /Catalog\n" +
                    $"/Pages {currentobjectID + 1} 0 R\n" +
                    $"/Outlines {currentobjectID + 2} 0 R\n" +
                    "/PageMode /UseOutlines\n" +
                    ">>\n" +
                    "endobj\n";
            currentobjectID += 3;
            return template;
            
        }
        public string GetOutlinesObject(ref int objectID)
        {
            string template = $"{objectID} 0 obj\n" +
                    "<<\n" +
                    "/Type /Outlines\n" +
                    "/Count 0\n" +
                    ">>\n" +
                    "endobj\n";

            objectID++;

            return template;
        }
    }
}
