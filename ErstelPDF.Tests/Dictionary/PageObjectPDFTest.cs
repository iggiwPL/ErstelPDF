using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.DataTypes;
using ErstelPDF.Dictionary;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class PageObjectPDFTest
    {
        [TestCase(1, 0, 0, 612, 792)]
        [TestCase(4, 0, 0, 612, 792)]
        [TestCase(2, 0, 0, 612, 792)]
        public void GetArgumentMatchTest(int CurrentObject, int x_low, int y_low, int x_up, int y_up)
        {
            PageFormatType Format = new PageFormatType(x_low, y_low, x_up, y_up);
            PageObjectPDF pageObjectPDF = new PageObjectPDF(CurrentObject, Format);

            Assert.That(Is.Equals(pageObjectPDF.ObjectCounter, CurrentObject));

            Assert.That(Is.Equals(pageObjectPDF.pageFormat.x_lower, x_low));
            Assert.That(Is.Equals(pageObjectPDF.pageFormat.y_lower, y_low));
            Assert.That(Is.Equals(pageObjectPDF.pageFormat.x_upper, x_up));
            Assert.That(Is.Equals(pageObjectPDF.pageFormat.y_upper, y_up));
        }
        [Test]
        public void CountObjectsTest()
        {
            int CurrentObject = 1;
            PageFormatType pageFormat = new PageFormatType(0, 0, 612, 792);

            PageObjectPDF pageObjectPDF = new PageObjectPDF(CurrentObject, pageFormat);

            pageObjectPDF.CountObjects();

            Assert.That(Is.Equals(pageObjectPDF.PagesObject, 0));
            Assert.That(Is.Equals(pageObjectPDF.PageObject, 1));
            Assert.That(Is.Equals(pageObjectPDF.ObjectCounter, 1));
        }
        [Test]
        public void SyncMainCounterTest()
        {
            int CurrentObject = 1;
            PageFormatType pageFormat = new PageFormatType(0, 0, 612, 792);

            PageObjectPDF pageObjectPDF = new PageObjectPDF(CurrentObject, pageFormat);

            pageObjectPDF.CountObjects();
            pageObjectPDF.SyncMainCounter(ref CurrentObject);

            Assert.That(Is.Equals(CurrentObject, 2));
            Assert.That(Is.Equals(pageObjectPDF.SyncCounterTransition, 2));
        }
    }
}
