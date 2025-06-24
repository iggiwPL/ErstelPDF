using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.Dictionary;
using static ErstelPDF.Dictionary.CatalogObjectPDF.PageOutlineMode;


namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class CatalogObjectTest
    {
        // args: current object, root object
        [TestCase(4, 1)]
        [TestCase(1, 4)]
        [TestCase(8, 8)]
        public void GetArgumentsMatchingTest(int currentObject, int rootObject)
        {
            CatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(currentObject, rootObject, CatalogObjectPDF.PageOutlineMode.Outlines);

            Assert.That(Is.Equals(catalogObjectPDF.ObjectCounter, currentObject));
            Assert.That(Is.Equals(catalogObjectPDF.RootObject, rootObject));
        }

        [Test]
        public void CountObjectsTest()
        {
            // Basic initialised
            int rootObj = 0;
            int currentObj = 1;
            // Injected class
            CatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(currentObj, rootObj, CatalogObjectPDF.PageOutlineMode .Outlines);

            catalogObjectPDF.CountObjects();

            Assert.That(Is.Equals(catalogObjectPDF.CatalogObject, 1));
            Assert.That(Is.Equals(catalogObjectPDF.OutlinesObject, 2));
            Assert.That(Is.Equals(catalogObjectPDF.PagesObject, 3));
            



        }
        [TestCase(CatalogObjectPDF.PageOutlineMode.Outlines)]
        [TestCase(CatalogObjectPDF.PageOutlineMode.Thumbnails)]
        [TestCase(CatalogObjectPDF.PageOutlineMode.None)]
        public void PageModePropertyEqualsTest(CatalogObjectPDF.PageOutlineMode PageMode)
        {
            // Basic initialised
            int rootObj = 0;
            int currentObj = 1;
            // Injected class
            CatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(currentObj, rootObj, PageMode);

            string propertyChoosen = catalogObjectPDF.GetAttribObject(PageMode);

            Assert.That(Is.Equals(propertyChoosen, catalogObjectPDF.PageMode));
            
        }
        [Test]
        public void TestSyncBufferCounter()
        {
            // Basic initialised
            int rootObj = 0;
            int currentObj = 1;
            // Injected class
            CatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(currentObj, rootObj, CatalogObjectPDF.PageOutlineMode.Outlines);

            catalogObjectPDF.CountObjects();
            catalogObjectPDF.SyncMainCounter(ref currentObj, ref rootObj);

            Assert.That(Is.Equals(catalogObjectPDF.SyncCounterTransition, 2));
        }
        [Test]
        public void TestSyncCounter()
        {
            // Basic initialised
            int rootObj = 0;
            int currentObj = 1;
            // Injected class
            CatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(currentObj, rootObj, CatalogObjectPDF.PageOutlineMode.Outlines);

            catalogObjectPDF.CountObjects();
            catalogObjectPDF.SyncMainCounter(ref currentObj, ref rootObj);

            Assert.That(Is.Equals(currentObj, 2));
        }

        [TestCase(CatalogObjectPDF.PageOutlineMode.Thumbnails, "/UseThumbs")]
        [TestCase(CatalogObjectPDF.PageOutlineMode.Outlines, "/UseOutlines")]
        [TestCase(CatalogObjectPDF.PageOutlineMode.None, "/UseNone")]
        public void GetAttributesTest(CatalogObjectPDF.PageOutlineMode PageMode, string Expected)
        {
            // Basic initialised
            int rootObj = 0;
            int currentObj = 1;
            // Injected class
            CatalogObjectPDF catalogObjectPDF = new CatalogObjectPDF(currentObj, rootObj, CatalogObjectPDF.PageOutlineMode.Outlines);

            Assert.That(Is.Equals(catalogObjectPDF.GetAttribObject(PageMode), Expected));
        }
    }
}
