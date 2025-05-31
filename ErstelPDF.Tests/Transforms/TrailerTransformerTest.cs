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

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class TrailerTransformerTest
    {
        [Test]
        public void TransformTest()
        {
            ErstelStacks erstelStacks = new ErstelStacks();
            DictionaryPDF dictionaryPDF = new DictionaryPDF();


            ITrailerTransformer trailerTransformer = new TrailerTransformer();
            IByteCounter _ByteCounter = new ByteCounter();
            

            erstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(dictionaryPDF.GetHeaderPDF()));
            trailerTransformer.Transform(_ByteCounter, erstelStacks.DocumentTextContent);

            // Why 10? return "%PDF-1.0\n"; Count characters are with new line 9 and plus one that is pointing to newline
            Assert.That(trailerTransformer.XrefByteBeginProperty, Is.EqualTo(10));


        }
    }
}
