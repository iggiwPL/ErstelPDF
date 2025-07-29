using ErstelPDF.Core;
using ErstelPDF.DataTypes;
using ErstelPDF.Dictionary;
using ErstelPDF.Stacks;
using ErstelPDF.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class XrefObjectPDFTest
    {
        [Test]
        public void RowsCountMatchingTest()
        {
            string Expected = "xref 0 2\n";

            ErstelStacks erstelStacks = new ErstelStacks();
            IXReferenceTransformer xReferenceTransformer = new XReferenceTransformer();
            int rootObject = 0;
            int currentObject = 1;

            ICatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(currentObject, rootObject, CatalogObjectPDF.PageOutlineMode.Outlines);
            erstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(catalogObjectPDF.GetObject()));

            XrefObjectPDF xrefObjectPDF = new XrefObjectPDF(xReferenceTransformer, erstelStacks.DocumentTextContent, erstelStacks.XreferenceTable);

            IByteCounter byteCounter = new ByteCounter();
            xReferenceTransformer.Transform(byteCounter, erstelStacks.DocumentTextContent, erstelStacks.XreferenceTable);

            xrefObjectPDF.GetRowsCount(xReferenceTransformer);

            Assert.That(Is.Equals(xrefObjectPDF.Template, Expected));
        }
    }
}
