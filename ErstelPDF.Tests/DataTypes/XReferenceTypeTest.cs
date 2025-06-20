using ErstelPDF.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class XReferenceTypeTest
    {
        [Test]
        public void CheckEqualsReturnsFalseOnNull()
        {
            XReferenceType xref_obj = new XReferenceType();

            Assert.That(false, Is.EqualTo(xref_obj.Equals(null)));
        }
        [Test]
        public void CheckEqualsReturnsFalseOnInvalidObj()
        {
            XReferenceType xref_obj = new XReferenceType();

            Assert.That(false, Is.EqualTo(xref_obj.Equals("hello")));
        }
        [Test]
        public void AreSameObjectsHashEqual()
        {
            XReferenceType xref_obj = new XReferenceType("0000000000", "65535", 'f');

            int hash1 = xref_obj.GetHashCode();
            int hash2 = xref_obj.GetHashCode();

            Assert.That(hash2, Is.EqualTo(hash1));

        }
        [Test]
        public void AreBothDifferentObjectsNotEqualHash()
        {
            XReferenceType xref_obj = new XReferenceType("0000000000", "65535", 'f');
            XReferenceType xref_obj1 = new XReferenceType("0000000009", "0", 'n');

            int hash1 = xref_obj.GetHashCode();
            int hash2 = xref_obj1.GetHashCode();

            Assert.That(hash1, Is.Not.EqualTo(hash2));

        }

        [Test]
        public void EqualContent_EqualsReturnsTrue()
        {
            var obj1 = new XReferenceType("0000000000", "65535", 'f');
            var obj2 = new XReferenceType("0000000000", "65535", 'f');

            Assert.That(obj1.Equals(obj2), Is.True);
        }

        [Test]
        public void EqualContent_SameHashCode()
        {
            var obj1 = new XReferenceType("0000000000", "65535", 'f');
            var obj2 = new XReferenceType("0000000000", "65535", 'f');

            Assert.That(obj1.GetHashCode(), Is.EqualTo(obj2.GetHashCode()));
        }

        [Test]
        public void NullContent_HandledGracefully()
        {
            var obj = new XReferenceType(null, null, '\0');

            Assert.DoesNotThrow(() => obj.GetHashCode());
        }
    }
}
