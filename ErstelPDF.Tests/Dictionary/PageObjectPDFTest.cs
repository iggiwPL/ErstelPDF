using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Dictionary;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class PageObjectPDFTest
    {
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(2)]
        public void GetArgumentMatchTest(int CurrentObject)
        {
            PageObjectPDF pageObjectPDF = new PageObjectPDF(CurrentObject);

            Assert.That(Is.Equals(pageObjectPDF.ObjectCounter, CurrentObject));
        }
        [Test]
        public void CountObjectsTest()
        {
            int CurrentObject = 1;
            PageObjectPDF pageObjectPDF = new PageObjectPDF(CurrentObject);

            pageObjectPDF.CountObjects();

            Assert.That(Is.Equals(pageObjectPDF.PagesObject, 0));
            Assert.That(Is.Equals(pageObjectPDF.PageObject, 1));
            Assert.That(Is.Equals(pageObjectPDF.ObjectCounter, 1));
        }
        [Test]
        public void SyncMainCounterTest()
        {
            int CurrentObject = 1;
            PageObjectPDF pageObjectPDF = new PageObjectPDF(CurrentObject);

            pageObjectPDF.CountObjects();
            pageObjectPDF.SyncMainCounter(ref CurrentObject);

            Assert.That(Is.Equals(CurrentObject, 2));
            Assert.That(Is.Equals(pageObjectPDF.SyncCounterTransition, 2));
        }
    }
}
