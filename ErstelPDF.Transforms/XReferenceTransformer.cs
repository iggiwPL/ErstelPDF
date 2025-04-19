using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using ErstelPDF.Stacks;

namespace ErstelPDF.Transforms
{
    internal class XReferenceTransformer
    {
        ByteCounter byteCounter = new ByteCounter();

        // Calculate a byte offset to every object
        public void Transform(Queue<string> PDFObjects)
        {
            int byteOffset = 0;
            int generationNumber = 0;
            char attributeObject = 'n';

            // Initialise first
            ErstelStacks.XreferenceTable.Enqueue(new XReferenceType("0000000000", "65535", 'f'));

            foreach (string PDFObject in PDFObjects)
            {
                // Count every PDF object
                byteOffset += byteCounter.CountBytesObject(PDFObject);

                // Format numbers to specification
                string byteOffsetFormated = string.Format("{0:0000000000}", byteOffset);
                string generationNumberFormated = string.Format("{0:00000}", generationNumber);

                // Add to the register
                ErstelStacks.XreferenceTable.Enqueue(new XReferenceType(byteOffsetFormated, generationNumberFormated, attributeObject));
            }
        }
    }
}
