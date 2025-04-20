using ErstelPDF.Core;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Transforms
{
    internal static class TrailerTransformer
    {
        private static int XrefByteBegin = 0;
        public static int XrefByteBeginProperty
        {
            get { return XrefByteBegin; }
            set { XrefByteBegin = value; }
        }

        public static void Transform(Queue<LinkedDocumentType> PDFObjects)
        {
            foreach (var PDFObject in PDFObjects)
            {
                XrefByteBegin += ByteCounter.CountBytesObject(PDFObject.Content);
            }
        }
    }
}
