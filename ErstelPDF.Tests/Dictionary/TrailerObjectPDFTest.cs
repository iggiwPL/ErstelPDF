using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Dictionary;
using ErstelPDF.Transforms;
using ErstelPDF.Stacks;
using ErstelPDF.DataTypes;
using ErstelPDF.Core;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class TrailerObjectPDFTest
    {
        [Test]
        public void SizeMatchingTest()
        {
            IByteCounter byteCounter = new ByteCounter();
            IXReferenceTransformer xreftransformer = new XReferenceTransformer();
            ITrailerTransformer xtrailertransformer = new TrailerTransformer();
            int rootObject = 0;
            int currentObject = 1;

            ErstelStacks erstelStacks = new ErstelStacks();


            CatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(currentObject, rootObject, CatalogObjectPDF.PageOutlineMode.Outlines);
            erstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(catalogObjectPDF.GetObject()));
            xreftransformer.Transform(byteCounter, erstelStacks.DocumentTextContent, erstelStacks.XreferenceTable);

            TrailerObjectPDF trailerObjectPDF = new TrailerObjectPDF(xtrailertransformer, xreftransformer, erstelStacks.DocumentTextContent, rootObject);
            trailerObjectPDF.GetSize(xreftransformer);

            Assert.That(Is.Equals(trailerObjectPDF.Size, 2));

        }
        [Test]
        public void GetArgumentMatchingTest()
        {
            IByteCounter byteCounter = new ByteCounter();
            IXReferenceTransformer xreftransformer = new XReferenceTransformer();
            ITrailerTransformer xtrailertransformer = new TrailerTransformer();
            int rootObject = 0;
            

            ErstelStacks erstelStacks = new ErstelStacks();

            TrailerObjectPDF trailerObjectPDF = new TrailerObjectPDF(xtrailertransformer, xreftransformer, erstelStacks.DocumentTextContent, rootObject);

            Assert.That(Is.Equals(trailerObjectPDF.RootObject, rootObject));


        }
        /*
        [Test]
        public void BeginByteMatchTest()
        {
            
            

        }
        */
    } 
}
