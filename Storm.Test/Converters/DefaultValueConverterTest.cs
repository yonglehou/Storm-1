using Flyingpie.Storm.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Test.Converters
{
    [TestClass]
    public class DefaultValueConverterTest
    {
        private IValueConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new DefaultValueConverter();
        }

        [TestMethod]
        public void ConvertNull()
        {
            Assert.AreEqual(null, _converter.Convert(null, string.Empty));
        }

        [TestMethod]
        public void ConvertString()
        {
            var str = "Hello";

            Assert.AreEqual(str, _converter.Convert(str, "NVARCHAR"));
        }

        [TestMethod]
        public void ConvertDateTime()
        {
            //TODO: Add more tests for types like time and offset
            Assert.AreEqual("2014-10-16T11:30:32.345", _converter.Convert(new DateTime(2014, 10, 16, 11, 30, 20).AddTicks(123456789), "DATETIME"));
            Assert.AreEqual("2014-10-16T11:30:32.3456789", _converter.Convert(new DateTime(2014, 10, 16, 11, 30, 20).AddTicks(123456789), "DATETIME2"));
        }
    }
}
