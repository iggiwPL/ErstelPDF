using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Transforms
{
    public interface ITrailerTransformer
    {
        public int XrefByteBeginProperty { get; set; }
        public void Transform(IByteCounter IbyteCounter, Queue<LinkedDocumentType> PDFObjects);
    }
}
