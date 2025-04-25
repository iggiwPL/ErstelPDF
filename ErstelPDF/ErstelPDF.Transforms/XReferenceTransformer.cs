using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using ErstelPDF.Stacks;

namespace ErstelPDF.Transforms
{
    public class XReferenceTransformer
    {
        ByteCounter _byteCounter;

        private int RowsCount = 1;
        private int byteOffset = 0;
        private int generationNumber = 0;
        private char attributeObject = 'n';

        public XReferenceTransformer()
        {
            _byteCounter = new ByteCounter();
        }
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
        public  string FormatOffset(int byteOffset)
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
        public void AddBytestoXrefOffset(LinkedDocumentType PDFObject, ref int XrefOffset)
        {
            XrefOffset += _byteCounter.CountBytesObject(PDFObject.Content);
        }
        // Calculate a byte offset to every object
        public void Transform(Queue<LinkedDocumentType> PDFObjects, Queue<XReferenceType> XrefTable)
        {
            InitialiseTable(XrefTable);

            foreach (LinkedDocumentType PDFObject in PDFObjects)
            {
                // Count every PDF object
                AddBytestoXrefOffset(PDFObject, ref byteOffset);

                // Add to the register
                AddToRegisterXref(XrefTable, byteOffset, generationNumber, attributeObject);

                RowsCount++;
            }
        }
    }
}
