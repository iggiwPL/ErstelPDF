using ErstelPDF.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class CatalogObjectPDF
    {

        public bool VisibleOutlines { get; set; } = false;
        public bool VisibleThumbnails { get; set; } = false;

        public string AppendProperties(IErstelConfig erstelConfig)
        {
            string output = "";

            if (erstelConfig.EnableOutlines == true)
            {
                if (VisibleOutlines == true)
                {
                    output += "/UseOutlines ";
                }
                if (VisibleThumbnails == true)
                {
                    output += "/UseThumbs ";
                }
            }
            return output;
        }



        // To rewrite
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

    }
}
