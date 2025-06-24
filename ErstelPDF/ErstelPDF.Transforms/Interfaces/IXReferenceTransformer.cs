using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Transforms
{
    public interface IXReferenceTransformer
    {
        public int RowsCountProperty { get; set; }   
        public void Transform(IByteCounter IbyteCounter, Queue<LinkedDocumentType> PDFObjects, Queue<XReferenceType> XrefTable);

        public void AddToRegisterXref(Queue<XReferenceType> XrefTable, int ByteOffset, int genNumber, char attributeObj);

        public void InitialiseTable(Queue<XReferenceType> XrefTable);

        public string FormatOffset(int byteOffset);

        public string FormatGenerationNumber(int generationNumber);

        public void AddBytestoXrefOffset(IByteCounter IbyteCounter, LinkedDocumentType PDFObject, ref int XrefOffset);

    }
}
