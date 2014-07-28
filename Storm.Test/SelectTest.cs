using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flyingpie.Storm.Executors;
using Flyingpie.Storm.Dapper;
using Database;
using Storm.Test.Dto;
using System.Collections.Generic;
using System.Diagnostics;
using Database.UserDefinedTypes.Orm;

namespace Storm.Test
{
    [TestClass]
    public class SelectTest
    {
        private ISqlExecutor _executor;

        private IOrm _orm;

        [TestInitialize]
        public void Initialize()
        {
            _executor = DapperSqlExecutor.FromConnectionStringName("TestDatabase");

            _orm = new Orm(_executor);
        }

        [TestMethod]
        public void Select()
        {
            var result = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null);

            Assert.AreEqual(10, result.Items.Count());

            Assert.IsTrue(result.Items.Any(i => i.Name == "Audi" && i.Description == "The steering wheel is an option"));
            Assert.IsTrue(result.Items.Any(i => i.Name == "Volvo" && i.Description == "The search for perfection ends here"));
        }

        [TestMethod]
        public void Update()
        {
            _orm.AddVendors<SqlResponse>(new List<Vendor>() { new Vendor() { Name = "a", Description = "b" } });
        }

        [TestMethod]
        public void TableValuedParameter()
        {

        }

        [TestMethod]
        public void TransactionRollback()
        {

        }

        [TestMethod]
        public void TransactionCommit()
        {

        }
    }
}
