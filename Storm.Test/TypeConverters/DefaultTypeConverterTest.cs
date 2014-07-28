using Flyingpie.Storm.Model;
using Flyingpie.Storm.TypeConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Test.TypeConverters
{
    [TestClass]
    public class DefaultTypeConverterTest
    {
        private ITypeConverter _typeConverter;

        [TestInitialize]
        public void Initialize()
        {
            _typeConverter = new DefaultTypeConverter();
        }

        [TestMethod]
        public void Strings()
        {
            var str = "string";
            var inp = ParameterDirection.Input;

            Assert.AreEqual(str, Convert("char", inp));
            Assert.AreEqual(str, Convert("text", inp));
            Assert.AreEqual(str, Convert("varchar", inp));

            Assert.AreEqual(str, Convert("nchar", inp));
            Assert.AreEqual(str, Convert("ntext", inp));
            Assert.AreEqual(str, Convert("nvarchar", inp));
        }

        [TestMethod]
        public void DateTimes()
        {
            var dt = "DateTime?";
            var inp = ParameterDirection.Input;

            Assert.AreEqual(dt, Convert("date", inp));
            Assert.AreEqual(dt, Convert("datetime", inp));
            Assert.AreEqual(dt, Convert("datetime2", inp));
            Assert.AreEqual(dt, Convert("datetimeoffset", inp));
            Assert.AreEqual(dt, Convert("smalldatetime", inp));
            Assert.AreEqual(dt, Convert("time", inp));
        }

        [TestMethod]
        public void Numbers()
        {
            var inp = ParameterDirection.Input;

            Assert.AreEqual("int?", Convert("int", inp));
            Assert.AreEqual("int?", Convert("smallint", inp));
            Assert.AreEqual("int?", Convert("tinyint", inp));

            Assert.AreEqual("float?", Convert("float", inp));
            Assert.AreEqual("float?", Convert("real", inp));

            Assert.AreEqual("long?", Convert("bigint", inp));

            Assert.AreEqual("decimal?", Convert("decimal", inp));
            Assert.AreEqual("decimal?", Convert("money", inp));
            Assert.AreEqual("decimal?", Convert("smallmoney", inp));
            Assert.AreEqual("decimal?", Convert("numeric", inp));

            Assert.AreEqual("bool?", Convert("bit", inp));
        }

        [TestMethod]
        public void Binary()
        {
            var inp = ParameterDirection.Input;
            var bin = "byte[]";

            Assert.AreEqual(bin, Convert("binary", inp));
            Assert.AreEqual(bin, Convert("varbinary", inp));
            Assert.AreEqual(bin, Convert("image", inp));
        }

        [TestMethod]
        public void Various()
        {
            var inp = ParameterDirection.Input;

            Assert.AreEqual("long?", Convert("timestamp", inp));
            Assert.AreEqual("long?", Convert("rowversion", inp));

            Assert.AreEqual("Guid?", Convert("uniqueidentifier", inp));
        }

        [TestMethod]
        public void Refs()
        {
            Assert.AreEqual("int?", Convert("int", ParameterDirection.Input));
            Assert.AreEqual("ref int?", Convert("int", ParameterDirection.InputOutput));
            Assert.AreEqual("out int?", Convert("int", ParameterDirection.Output));
        }

        private string Convert(string typeName, ParameterDirection direction)
        {
            return _typeConverter.ConvertSqlType(new ParameterInfo()
            {
                Type = typeName,
                ParameterModeEnum = direction
            });
        }
    }
}
