using ErstelPDF.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstelPDF.Tests
{
    [TestFixture]
    internal class ByteCounterTest
    {
        ByteCounter _byteCounter;

        [SetUp]
        public void Setup()
        {
            _byteCounter = new ByteCounter();
        }

        [TestCase("n", 2)]
        [TestCase("n\n", 3)]
        public void CountBytesObjectTest(string content, int expected)
        {
            int output = _byteCounter.CountBytesObject(content);
            Assert.That(output, Is.EqualTo(expected));
        }
    }
}
