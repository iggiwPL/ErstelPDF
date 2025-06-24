using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Dictionary;
using ErstelPDF.Stacks;
using ErstelPDF.Transforms;
using ErstelPDF.DataTypes;
using ErstelPDF.Core;
using static ErstelPDF.Dictionary.HeaderPDF.VersionPDF;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class TrailerTransformerTest
    {
        [Test]
        public void TransformTest()
        {
            ErstelStacks erstelStacks = new ErstelStacks();
            IHeaderPDF headerPDF = new HeaderPDF();


            ITrailerTransformer trailerTransformer = new TrailerTransformer();
            IByteCounter _ByteCounter = new ByteCounter();
            

            erstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(headerPDF.GetHeader(HeaderPDF.VersionPDF.PDF_1_0)));
            trailerTransformer.Transform(_ByteCounter, erstelStacks.DocumentTextContent);

            // Why 10? return "%PDF-1.0\n"; Count characters are with new line 9 and plus one that is pointing to newline
            Assert.That(trailerTransformer.XrefByteBeginProperty, Is.EqualTo(10));


        }
    }
}
