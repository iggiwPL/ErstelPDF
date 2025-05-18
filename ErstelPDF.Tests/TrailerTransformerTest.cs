using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Dictionary;
using ErstelPDF.Stacks;
using ErstelPDF.Transforms;
using ErstelPDF.DataTypes;

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
            TrailerTransformer transformer = new TrailerTransformer();

            erstelStacks.DocumentTextContent.Enqueue(new LinkedDocumentType(dictionaryPDF.GetHeaderPDF()));
            transformer.Transform(erstelStacks.DocumentTextContent);

            // Why 10? return "%PDF-1.0\n"; Count characters are with new line 9 and plus one that is pointing to newline
            Assert.That(transformer.XrefByteBeginProperty, Is.EqualTo(10));


        }
    }
}
