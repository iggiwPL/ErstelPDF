using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErstelPDF.DataTypes;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class LinkedDocumentTypeTest
    {
        LinkedDocumentType _linkeddoctype;

        [SetUp]
        public void Setup()
        {
            _linkeddoctype = new LinkedDocumentType("Testcoontent");
            
        }
        [Test]
        public void CheckEqualsReturnsFalseOnNull()
        {
            Assert.That(false, Is.EqualTo(_linkeddoctype.Equals(null)));
        }
        [Test]
        public void CheckEqualsReturnsFalseOnInvalidObj()
        {
            Assert.That(false, Is.EqualTo(_linkeddoctype.Equals("hello")));
        }
        [Test]
        public void AreSameObjectsHashEqual()
        {
            LinkedDocumentType linkeddoc = new LinkedDocumentType("Test");
            int hash1 = linkeddoc.GetHashCode();
            int hash2 = linkeddoc.GetHashCode();
            Assert.That(hash2, Is.EqualTo(hash1));

        }
        [Test]
        public void AreBothDifferentObjectsNotEqualHash()
        {
            LinkedDocumentType linkedoc_obj = new LinkedDocumentType("test");
            LinkedDocumentType linkedoc_obj1 = new LinkedDocumentType("example");
            int hash1 = linkedoc_obj.GetHashCode();
            int hash2 = linkedoc_obj1.GetHashCode();
            Assert.That(hash1, Is.Not.EqualTo(hash2));

        }

        [Test]
        public void EqualContent_EqualsReturnsTrue()
        {
            var obj1 = new LinkedDocumentType("SameContent");
            var obj2 = new LinkedDocumentType("SameContent");

            Assert.That(obj1.Equals(obj2), Is.True);
        }

        [Test]
        public void EqualContent_SameHashCode()
        {
            var obj1 = new LinkedDocumentType("SameContent");
            var obj2 = new LinkedDocumentType("SameContent");

            Assert.That(obj1.GetHashCode(), Is.EqualTo(obj2.GetHashCode()));
        }

        [Test]
        public void NullContent_HandledGracefully()
        {
            var obj = new LinkedDocumentType(null);

            Assert.DoesNotThrow(() => obj.GetHashCode());
        }
    }
}
