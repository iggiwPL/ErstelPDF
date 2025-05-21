using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using ErstelPDF.Stacks;

namespace ErstelPDF.Transforms
{
    public class XReferenceTransformer : IXReferenceTransformer
    {
        private int RowsCount = 1;
        private int byteOffset = 0;
        private int generationNumber = 0;
        private char attributeObject = 'n';

        public int RowsCountProperty
        {
            get { return RowsCount; }
            set { RowsCount = value; }
        }
        public void InitialiseTable(Queue<XReferenceType> XrefTable)
        {
            // Initialise first
            XrefTable.Enqueue(new XReferenceType("0000000000", "65535", 'f'));
        }
        public string FormatOffset(int byteOffset)
        {
            return string.Format("{0:0000000000}", byteOffset);
        }
        public string FormatGenerationNumber(int generationNumber)
        {
            return string.Format("{0:00000}", generationNumber);
        }
        public void AddToRegisterXref(Queue<XReferenceType> XrefTable, int ByteOffset, int genNumber, char attributeObj)
        {
            XrefTable.Enqueue(new XReferenceType(FormatOffset(ByteOffset), FormatGenerationNumber(genNumber), attributeObj));
        }
        public void AddBytestoXrefOffset(IByteCounter IbyteCounter,LinkedDocumentType PDFObject, ref int XrefOffset)
        {
            XrefOffset += IbyteCounter.CountBytesObject(PDFObject.Content);
        }
        // Calculate a byte offset to every object
        public void Transform(IByteCounter IbyteCounter,Queue<LinkedDocumentType> PDFObjects, Queue<XReferenceType> XrefTable)
        {
            InitialiseTable(XrefTable);

            foreach (LinkedDocumentType PDFObject in PDFObjects)
            {
                // Count every PDF object
                AddBytestoXrefOffset(IbyteCounter,PDFObject, ref byteOffset);

                // Add to the register
                AddToRegisterXref(XrefTable, byteOffset, generationNumber, attributeObject);

                RowsCount++;
            }
        }
    }
}
