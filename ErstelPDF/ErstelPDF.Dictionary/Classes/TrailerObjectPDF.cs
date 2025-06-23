using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using ErstelPDF.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Dictionary
{
    public class TrailerObjectPDF
    {
        // To rewrite
        public string GetTrailerObject(IByteCounter IbyteCounter, ITrailerTransformer ItrailerTransformer, IXReferenceTransformer IxReferenceTransformer, Queue<LinkedDocumentType> PDFObjects, int rootObjectID)
        {
            ItrailerTransformer.Transform(IbyteCounter, PDFObjects);

            string template = "trailer\n" +
                              "<<\n" +
                              $"/Size {IxReferenceTransformer.RowsCountProperty}\n" +
                              $"/Root {rootObjectID} 0 R\n" +
                              ">>\n" +
                              "startxref\n" +
                              $"{ItrailerTransformer.XrefByteBeginProperty}\n" +
                              "%%EOF\n";
            return template;
        }
    }
}
