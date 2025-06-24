using ErstelPDF.Core;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Transforms
{
    public class TrailerTransformer : ITrailerTransformer
    {
        
        private int XrefByteBegin = 0;

        public int XrefByteBeginProperty
        {
            get { return XrefByteBegin; }
            set { XrefByteBegin = value; }
        }

        public void Transform(IByteCounter IbyteCounter,Queue<LinkedDocumentType> PDFObjects)
        {
            foreach (var PDFObject in PDFObjects)
            {
                XrefByteBegin += IbyteCounter.CountBytesObject(PDFObject.Content);
            }
        }
    }
}
