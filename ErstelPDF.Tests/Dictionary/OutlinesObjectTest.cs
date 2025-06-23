using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Dictionary;

namespace ErstelPDF.Tests.Dictionary
{
    [TestFixture]
    internal class OutlinesObjectTest
    {
        [TestCase(4)]
        public void GetArgumentMatchingTest(int Expected)
        {
            OutlinesObjectPDF outlinesObjectPDF = new OutlinesObjectPDF(Expected);

            Assert.That(Is.Equals(outlinesObjectPDF.ObjectCounter, Expected));
        }

        [Test]
        public void CountObjectTest()
        {
            int currentObj = 1;

            OutlinesObjectPDF outlinesObjectPDF = new OutlinesObjectPDF(currentObj);

            outlinesObjectPDF.CountObjects();

            Assert.That(Is.Equals(outlinesObjectPDF.OutlinesObject, currentObj));
        }
        [Test]
        public void SyncMainCounterTest()
        {
            int currentObj = 1;

            OutlinesObjectPDF outlinesObjectPDF = new OutlinesObjectPDF(currentObj);

            outlinesObjectPDF.CountObjects();
            outlinesObjectPDF.SyncMainCounter(ref currentObj);

            Assert.That(Is.Equals(currentObj, 2));
            Assert.That(Is.Equals(outlinesObjectPDF.SyncCounterTransition, 2));
        }
    }
}
