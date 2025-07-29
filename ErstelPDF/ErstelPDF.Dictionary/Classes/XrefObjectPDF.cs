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
        // Arguments
        public Queue<LinkedDocumentType> PDFObjects { get; set; }
        public IXReferenceTransformer IXREFTransformer { get; set; }

        // Active processed objects
        public string Template { get; set; }
        public Queue<XReferenceType> XrefTable { get; set; }


        public XrefObjectPDF(IXReferenceTransformer IxReferenceTransformer, Queue<LinkedDocumentType> PDFObjects, Queue<XReferenceType> XrefTable)
        {
            this.IXREFTransformer = IxReferenceTransformer;
            this.PDFObjects = PDFObjects;
            this.XrefTable = XrefTable;
        }
        // Unit testing for the function GetObject() not requied.
        public string GetObject()
        {
            IByteCounter byteCounter = new ByteCounter();
            this.IXREFTransformer.Transform(byteCounter, PDFObjects, XrefTable);

            GetRowsCount(this.IXREFTransformer);
            CalculateOffsets(XrefTable);


            return this.Template;
        }
        public void GetRowsCount(IXReferenceTransformer IxReferenceTransformer)
        {
            this.Template += $"xref 0 {IxReferenceTransformer.RowsCountProperty}\n";
        }
        // Tested already in file XReferenceTransformerTest.cs
        public void CalculateOffsets(Queue<XReferenceType> XrefTable)
        {
            foreach (XReferenceType elem in XrefTable)
            {
                this.Template += $"{elem.ByteOffset} {elem.GenerationNumber} {elem.AttributeObject}\n";
            }
        }
    }
}
