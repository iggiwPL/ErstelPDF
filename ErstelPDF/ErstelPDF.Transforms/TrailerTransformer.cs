using ErstelPDF.Core;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Transforms
{
    public class TrailerTransformer
    {
        ByteCounter _byteCounter;
        private static int XrefByteBegin = 0;
        public TrailerTransformer()
        {
            _byteCounter = new ByteCounter();
        }
        public int XrefByteBeginProperty
        {
            get { return XrefByteBegin; }
            set { XrefByteBegin = value; }
        }

        public void Transform(Queue<LinkedDocumentType> PDFObjects)
        {
            foreach (var PDFObject in PDFObjects)
            {
                XrefByteBegin += _byteCounter.CountBytesObject(PDFObject.Content);
            }
        }
    }
}
