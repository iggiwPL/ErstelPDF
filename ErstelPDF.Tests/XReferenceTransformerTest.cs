using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.DataTypes;
using ErstelPDF.Dictionary;
using ErstelPDF.Stacks;
using ErstelPDF.Transforms;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class XReferenceTransformerTest
    {
        XReferenceTransformer _transformer;

        [SetUp]
        public void Setup()
        {
            _transformer = new XReferenceTransformer();
        }
        [Test]
        public void InitialiseTableRecordFind()
        {
            ErstelStacks _stacks = new ErstelStacks();

            _transformer.InitialiseTable(_stacks.XreferenceTable);

            foreach(var element in _stacks.XreferenceTable)
            {
                Assert.That(element.ByteOffset, Is.EqualTo("0000000000"));
                Assert.That(element.GenerationNumber, Is.EqualTo("65535"));
                Assert.That(element.AttributeObject, Is.EqualTo('f'));
            }

        }
        [TestCase("0000000000", "65535", 'f')]
        [TestCase("0000000009", "00000", 'n')]
        public void AddToRegisterXrefElementPresent(int ByteOffset, int genNumber, char attributeObj)
        {
            ErstelStacks _stacks = new ErstelStacks();
            _transformer.AddToRegisterXref(_stacks.XreferenceTable, ByteOffset, genNumber, attributeObj);
            Assert.That(_stacks.XreferenceTable.Count, Is.GreaterThan(0));
        }
        [Test]
        public void FormatOffsetCorectnessFormat()
        {
            string output = _transformer.FormatOffset(5);

            Assert.That(output, Is.EqualTo("0000000005"));
        }
        [Test]
        public void FormatGenerationNumberCorectnessFormat()
        {
            string output = _transformer.FormatGenerationNumber(5);
            Assert.That(output, Is.EqualTo("00005"));
        }
        [Test]
        public void ProperDocumentsCountingTransform()
        {
            ErstelStacks _stacks = new ErstelStacks();

            _stacks.DocumentTextContent.Enqueue(new LinkedDocumentType("h1"));
            _stacks.DocumentTextContent.Enqueue(new LinkedDocumentType("h2"));

            _transformer.Transform(_stacks.DocumentTextContent, _stacks.XreferenceTable);

            // Includinng the start record
            Assert.That(_stacks.XreferenceTable.Count(), Is.EqualTo(3));
        }
        [Test]
        public void ProperOffsetsAddingTransform()
        {
            ErstelStacks _stacks = new ErstelStacks();
            int result = 0;

            _stacks.DocumentTextContent.Enqueue(new LinkedDocumentType("h1"));

            foreach(LinkedDocumentType PDFObject in _stacks.DocumentTextContent)
            {
                _transformer.AddBytestoXrefOffset(PDFObject, ref result);
            }
            Assert.That(result, Is.EqualTo(3));

        }
    }
}
