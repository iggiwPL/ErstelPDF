using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Dictionary;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class PagesObjectPDFTest
    {
        [TestCase(3, 1)]
        [TestCase(6, 2)]
        [TestCase(9, 4)]
        public void GetArgumentMatchingTest(int CurrentObject, int CountPages)
        {
            PagesObjectPDF pagesObjectPDF = new PagesObjectPDF(CurrentObject, CountPages);

            Assert.That(Is.Equals(pagesObjectPDF.ObjectCounter, CurrentObject));
            Assert.That(Is.Equals(pagesObjectPDF.CountPages, CountPages));
        }
        [Test]
        public void CountObjectsTest()
        {
            int currentObject = 1;
            int countPages = 1;

            PagesObjectPDF pagesObjectPDF = new PagesObjectPDF(currentObject, countPages);

            pagesObjectPDF.CountObjects();


            Assert.That(Is.Equals(pagesObjectPDF.PagesObject, 1));
            Assert.That(Is.Equals(pagesObjectPDF.PageObject, 2));
        }
        [Test]
        public void SyncMainCounterTest()
        {
            int currentObject = 1;
            int countPages = 1;

            PagesObjectPDF pagesObjectPDF = new PagesObjectPDF(currentObject, countPages);

            pagesObjectPDF.CountObjects();
            pagesObjectPDF.SyncMainCounter(ref currentObject);
            Assert.That(Is.Equals(currentObject, 2));
            Assert.That(Is.Equals(pagesObjectPDF.SyncCounterTransition, 2));
        }
    }
}
