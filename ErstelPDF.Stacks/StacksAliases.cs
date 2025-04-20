using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Stacks
{
    internal static class StacksAliases
    {
        public static void AddContentToLinked(string PDFObject)
        {
            ErstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(PDFObject));
        }
        public static void ReleaseAllContent()
        {
            ErstelStacks.DocumentTextContent.Clear();
            ErstelStacks.XreferenceTable.Clear();
        }
    }
}
