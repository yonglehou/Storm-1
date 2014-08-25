using Flyingpie.Storm.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyingpie.Storm.Test.Converters
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
            Assert.AreEqual("IA", _nameConverter.ConvertSchemaToInterface("a"));
            Assert.AreEqual(string.Empty, _nameConverter.ConvertSchemaToInterface(string.Empty));
            Assert.AreEqual(null, _nameConverter.ConvertSchemaToInterface(null));
        }

        [TestMethod]
        public void ConvertSchemaToClassTest()
        {
            Assert.AreEqual("Dbo", _nameConverter.ConvertSchemaToClass("dbo"));
            Assert.AreEqual("Orm", _nameConverter.ConvertSchemaToClass("orm"));
            Assert.AreEqual("A", _nameConverter.ConvertSchemaToClass("a"));
            Assert.AreEqual("SchemaName", _nameConverter.ConvertSchemaToClass("SchemaName"));
            Assert.AreEqual("A", _nameConverter.ConvertSchemaToClass("a"));
            Assert.AreEqual(string.Empty, _nameConverter.ConvertSchemaToClass(string.Empty));
            Assert.AreEqual(null, _nameConverter.ConvertSchemaToClass(null));
        }

        [TestMethod]
        public void ConvertSchemaToNamespaceTest()
        {
            Assert.AreEqual("Dbo", _nameConverter.ConvertSchemaToNamespace("dbo"));
            Assert.AreEqual("Orm", _nameConverter.ConvertSchemaToNamespace("orm"));
            Assert.AreEqual("A", _nameConverter.ConvertSchemaToNamespace("a"));
            Assert.AreEqual("SchemaName", _nameConverter.ConvertSchemaToNamespace("SchemaName"));
            Assert.AreEqual("A", _nameConverter.ConvertSchemaToNamespace("a"));
            Assert.AreEqual(string.Empty, _nameConverter.ConvertSchemaToNamespace(string.Empty));
            Assert.AreEqual(null, _nameConverter.ConvertSchemaToNamespace(null));
        }

        [TestMethod]
        public void ConvertStoredProcedureToMethodTest()
        {
            Assert.AreEqual("GetVendors", _nameConverter.ConvertStoredProcedureToMethod("get_vendors"));
            Assert.AreEqual("Orm", _nameConverter.ConvertStoredProcedureToMethod("orm"));
            Assert.AreEqual("A", _nameConverter.ConvertStoredProcedureToMethod("a"));
            Assert.AreEqual("AddProduct", _nameConverter.ConvertStoredProcedureToMethod("addProduct"));
            Assert.AreEqual("A", _nameConverter.ConvertStoredProcedureToMethod("a"));
            Assert.AreEqual(string.Empty, _nameConverter.ConvertStoredProcedureToMethod(string.Empty));
            Assert.AreEqual(null, _nameConverter.ConvertStoredProcedureToMethod(null));
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
            Assert.AreEqual("a", _nameConverter.ConvertParameter("@a"));
            Assert.AreEqual(string.Empty, _nameConverter.ConvertParameter(string.Empty));
            Assert.AreEqual(null, _nameConverter.ConvertParameter(null));
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
            Assert.AreEqual("A", _nameConverter.ConvertColumnToProperty("a"));
            Assert.AreEqual(string.Empty, _nameConverter.ConvertColumnToProperty(string.Empty));
            Assert.AreEqual(null, _nameConverter.ConvertColumnToProperty(null));
        }

        [TestMethod]
        public void ConvertUserDefinedTypeToClassTest()
        {
            Assert.AreEqual("Dbo", _nameConverter.ConvertUserDefinedTypeToClass("dbo"));
            Assert.AreEqual("Orm", _nameConverter.ConvertUserDefinedTypeToClass("orm"));
            Assert.AreEqual("A", _nameConverter.ConvertUserDefinedTypeToClass("a"));
            Assert.AreEqual("UdtName", _nameConverter.ConvertUserDefinedTypeToClass("udtName"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertUserDefinedTypeToClass("PRODUCT_NAME"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertUserDefinedTypeToClass("ProductName"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertUserDefinedTypeToClass("product_name"));
            Assert.AreEqual("ProductName", _nameConverter.ConvertUserDefinedTypeToClass("product__name"));
            Assert.AreEqual("A", _nameConverter.ConvertUserDefinedTypeToClass("a"));
            Assert.AreEqual(string.Empty, _nameConverter.ConvertUserDefinedTypeToClass(string.Empty));
            Assert.AreEqual(null, _nameConverter.ConvertUserDefinedTypeToClass(null));
        }
    }
}
