using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class PagesObjectPDF
    {

        // To rewrite
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
    }
}
