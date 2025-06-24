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
    public class XrefObjectPDF : IXrefObjectPDF
    {
        public string Template { get; set; }

        public IXReferenceTransformer IXREFTransformer { get; set; }
        public Queue<LinkedDocumentType> PDFObjects { get; set; }
        public Queue<XReferenceType> XrefTable { get; set; }


        public XrefObjectPDF(IXReferenceTransformer IxReferenceTransformer, Queue<LinkedDocumentType> PDFObjects, Queue<XReferenceType> XrefTable)
        {
            this.IXREFTransformer = IxReferenceTransformer;
            this.PDFObjects = PDFObjects;
            this.XrefTable = XrefTable;
        }
        public string GetObject()
        {
            IByteCounter byteCounter = new ByteCounter();
            this.IXREFTransformer.Transform(byteCounter, PDFObjects, XrefTable);

            GetConstants(this.IXREFTransformer);
            CalculateOffsets(XrefTable);


            return this.Template;
        }
        public void GetConstants(IXReferenceTransformer IxReferenceTransformer)
        {
            this.Template += $"xref 0 {IxReferenceTransformer.RowsCountProperty}\n";
        }
        public void CalculateOffsets(Queue<XReferenceType> XrefTable)
        {
            foreach (XReferenceType elem in XrefTable)
            {
                this.Template += $"{elem.ByteOffset} {elem.GenerationNumber} {elem.AttributeObject}\n";
            }
        }
    }
}
