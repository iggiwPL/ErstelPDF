using ErstelPDF.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class HeaderPDFTest
    {
        [TestCase(HeaderPDF.VersionPDF.PDF_1_0, "1.0")]
        public void GetVersionOnlyTest(HeaderPDF.VersionPDF VersionPDF, string expected)
        {
            HeaderPDF headerPDF = new HeaderPDF();
            string text = headerPDF.GetVersion(VersionPDF);

            Assert.That(text, Is.EqualTo(expected));
        }
        [TestCase(HeaderPDF.VersionPDF.PDF_1_0, "%PDF-1.0\n")]
        public void GetHeaderTest(HeaderPDF.VersionPDF VersionPDF, string expected)
        {
            HeaderPDF headerPDF = new HeaderPDF();
            string text = headerPDF.GetHeader(VersionPDF);

            Assert.That(text, Is.EqualTo(expected));
        }
    }
}
