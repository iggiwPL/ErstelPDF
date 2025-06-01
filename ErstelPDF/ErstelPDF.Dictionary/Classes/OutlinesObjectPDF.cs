using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class OutlinesObjectPDF
    {

        // To rewrite

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

    }
}
