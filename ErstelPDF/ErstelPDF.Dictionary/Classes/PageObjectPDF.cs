using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class PageObjectPDF
    {
        // To rewrite
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
    }
}
