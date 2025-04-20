using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using ErstelPDF.Stacks;

namespace ErstelPDF.Transforms
{
    internal static class XReferenceTransformer
    {
        private static int RowsCount = 1;
        public static int RowsCountProperty
        {
            get { return RowsCount; }
            set { RowsCount = value; }
        }
        // Calculate a byte offset to every object
        public static void Transform(Queue<LinkedDocumentType> PDFObjects)
        {
            int byteOffset = 0;
            int generationNumber = 0;
            char attributeObject = 'n';

            // Initialise first
            ErstelStacks.XreferenceTable.Enqueue(new XReferenceType("0000000000", "65535", 'f'));

            foreach (LinkedDocumentType PDFObject in PDFObjects)
            {
                // Count every PDF object
                byteOffset += ByteCounter.CountBytesObject(PDFObject.Content);

                // Format numbers to specification
                string byteOffsetFormated = string.Format("{0:0000000000}", byteOffset);
                string generationNumberFormated = string.Format("{0:00000}", generationNumber);

                // Add to the register
                ErstelStacks.XreferenceTable.Enqueue(new XReferenceType(byteOffsetFormated, generationNumberFormated, attributeObject));
                RowsCount++;
            }
        }
    }
}
