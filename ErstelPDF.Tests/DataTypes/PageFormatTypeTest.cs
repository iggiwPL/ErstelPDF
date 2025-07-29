using ErstelPDF.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class PageFormatTypeTest
    {

        [Test]
        public void CheckEqualsReturnsFalseOnInvalidObj()
        {
            PageFormatType page_format = new PageFormatType(0, 0, 612, 792);

            Assert.That(false, Is.EqualTo(page_format.Equals(new PageFormatType(0, 0, 600, 700))));
        }
        [Test]
        public void AreSameObjectsHashEqual()
        {
            PageFormatType page_format = new PageFormatType(0, 0, 612, 792);

            int hash1 = page_format.GetHashCode();
            int hash2 = page_format.GetHashCode();

            Assert.That(hash2, Is.EqualTo(hash1));

        }
        [Test]
        public void AreBothDifferentObjectsNotEqualHash()
        {
            PageFormatType page_format = new PageFormatType(0, 0, 612, 792);
            PageFormatType page_format1 = new PageFormatType(0, 0, 600, 700);

            int hash1 = page_format.GetHashCode();
            int hash2 = page_format1.GetHashCode();

            Assert.That(hash1, Is.Not.EqualTo(hash2));

        }

        [Test]
        public void EqualContent_EqualsReturnsTrue()
        {
            var obj1 = new PageFormatType(0, 0, 612, 792);
            var obj2 = new PageFormatType(0, 0, 612, 792);

            Assert.That(obj1.Equals(obj2), Is.True);
        }

        [Test]
        public void EqualContent_SameHashCode()
        {
            var obj1 = new PageFormatType(0, 0, 612, 792);
            var obj2 = new PageFormatType(0, 0, 612, 792);

            Assert.That(obj1.GetHashCode(), Is.EqualTo(obj2.GetHashCode()));
        }

    }
}
