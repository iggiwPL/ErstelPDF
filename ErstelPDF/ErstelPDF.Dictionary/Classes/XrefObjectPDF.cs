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
    public class XrefObjectPDF
    {
        // To rewrite
        public string GetXrefObject(IXReferenceTransformer IxReferenceTransformer, IByteCounter IbyteCounter, Queue<LinkedDocumentType> PDFObjects, Queue<XReferenceType> XrefTable)
        {
            IxReferenceTransformer.Transform(IbyteCounter, PDFObjects, XrefTable);

            string xref_header = $"xref 0 {IxReferenceTransformer.RowsCountProperty}\n";
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
    }
}
