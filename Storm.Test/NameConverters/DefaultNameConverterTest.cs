using Flyingpie.Storm.NameConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Test.NameConverters
{
    [TestClass]
    public class DefaultNameConverterTest
    {
        private INameConverter _nameConverter;

        [TestInitialize]
        public void Initialize()
        {
            _nameConverter = new DefaultNameConverter();
        }

        [TestMethod]
        public void ConvertSchemaToInterfaceTest()
        {
            Assert.AreEqual("IDbo", _nameConverter.ConvertSchemaToInterface("dbo"));
            Assert.AreEqual("IOrm", _nameConverter.ConvertSchemaToInterface("orm"));
            Assert.AreEqual("IA", _nameConverter.ConvertSchemaToInterface("a"));
            Assert.AreEqual("ISchemaName", _nameConverter.ConvertSchemaToInterface("SchemaName"));
        }

        [TestMethod]
        public void ConvertSchemaToClassTest()
        {
            Assert.AreEqual("Dbo", _nameConverter.ConvertSchemaToClass("dbo"));
            Assert.AreEqual("Orm", _nameConverter.ConvertSchemaToClass("orm"));
            Assert.AreEqual("A", _nameConverter.ConvertSchemaToClass("a"));
            Assert.AreEqual("SchemaName", _nameConverter.ConvertSchemaToClass("SchemaName"));
        }

        [TestMethod]
        public void ConvertStoredProcedureToMethodTest()
        {
            Assert.AreEqual("GetVendors", _nameConverter.ConvertStoredProcedureToMethod("get_vendors"));
            Assert.AreEqual("Orm", _nameConverter.ConvertStoredProcedureToMethod("orm"));
            Assert.AreEqual("A", _nameConverter.ConvertStoredProcedureToMethod("a"));
            Assert.AreEqual("AddProduct", _nameConverter.ConvertStoredProcedureToMethod("addProduct"));
        }

        [TestMethod]
        public void ConvertParameterTest()
        {
            Assert.AreEqual("id", _nameConverter.ConvertParameter("@ID"));
            Assert.AreEqual("someId", _nameConverter.ConvertParameter("@SomeID"));
            Assert.AreEqual("productName", _nameConverter.ConvertParameter("@PRODUCT_NAME"));
            Assert.AreEqual("productName", _nameConverter.ConvertParameter("@ProductName"));
            Assert.AreEqual("productName", _nameConverter.ConvertParameter("@product_name"));
            Assert.AreEqual("productName", _nameConverter.ConvertParameter("@product__name"));
        }

        [TestMethod]
        public void ConvertColumnToPropertyTest()
        {
            Assert.AreEqual("VendorName", _nameConverter.ConvertColumnToProperty("vendor_name"));
            Assert.AreEqual("Orm", _nameConverter.ConvertColumnToProperty("orm"));
            Assert.AreEqual("A", _nameConverter.ConvertColumnToProperty("a"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertColumnToProperty("PRODUCT_NAME"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertColumnToProperty("ProductName"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertColumnToProperty("product_name"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertColumnToProperty("product__name"));
        }

        [TestMethod]
        public void ConvertUserDefinedTypeToClassTest()
        {
            Assert.AreEqual("Dbo", _nameConverter.ConvertSchemaToClass("dbo"));
            Assert.AreEqual("Orm", _nameConverter.ConvertSchemaToClass("orm"));
            Assert.AreEqual("A", _nameConverter.ConvertSchemaToClass("a"));
            Assert.AreEqual("UdtName", _nameConverter.ConvertSchemaToClass("udtName"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertColumnToProperty("PRODUCT_NAME"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertColumnToProperty("ProductName"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertColumnToProperty("product_name"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertColumnToProperty("product__name"));
        }
    }
}
