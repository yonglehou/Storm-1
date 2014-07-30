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
            var vendor1 = new Vendor() { Name = "Vendor1", Description = "Vendor1 description" };
            var vendor2 = new Vendor() { Name = "Vendor2", Description = "Vendor2 description" };

            using (var transaction = _executor.BeginTransaction())
            {
                var vendorsBefore = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null);

                Assert.IsFalse(vendorsBefore.Items.Any(v => v.Name == vendor1.Name && v.Description == vendor1.Description));
                Assert.IsFalse(vendorsBefore.Items.Any(v => v.Name == vendor2.Name && v.Description == vendor2.Description));

                _orm.AddVendors<SqlResponse>(new List<Vendor>() { vendor1, vendor2 });

                var vendorsAfter = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null);

                Assert.IsTrue(vendorsAfter.Items.Any(v => v.Name == vendor1.Name && v.Description == vendor1.Description));
                Assert.IsTrue(vendorsAfter.Items.Any(v => v.Name == vendor2.Name && v.Description == vendor2.Description));
            }
        }

        [TestMethod]
        public void TableValuedParameter()
        {

        }

        [TestMethod]
        public void TransactionRollbackMultiple()
        {
            var vendor1 = new Vendor() { Name = "Vendor1", Description = "Vendor1 description" };
            var vendor2 = new Vendor() { Name = "Vendor2", Description = "Vendor2 description" };
            var vendor3 = new Vendor() { Name = "Vendor3", Description = "Vendor3 description" };

            using (var transaction = _executor.BeginTransaction())
            {
                _orm.AddVendors<SqlResponse>(new List<Vendor>() { vendor1 });
                transaction.Rollback();
            }

            var result = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null);
            Assert.IsFalse(result.Items.Any(i => i.Name == vendor1.Name && i.Description == vendor1.Description));

            using (var transaction = _executor.BeginTransaction())
            {
                _orm.AddVendors<SqlResponse>(new List<Vendor>() { vendor2 });
                transaction.Rollback();
            }

            var result2 = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null);
            Assert.IsFalse(result.Items.Any(i => i.Name == vendor2.Name && i.Description == vendor2.Description));

            using (var transaction = _executor.BeginTransaction())
            {
                _orm.AddVendors<SqlResponse>(new List<Vendor>() { vendor3 });
                transaction.Rollback();
            }

            var result3 = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null);
            Assert.IsFalse(result.Items.Any(i => i.Name == vendor3.Name && i.Description == vendor3.Description));
        }

        [TestMethod]
        public void TransactionException()
        {
            bool isExceptionThrown = false;

            var vendorCountBefore = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null).Items.Count();

            try
            {
                using (var transaction = _executor.BeginTransaction())
                {
                    _orm.AddVendors<SqlResponse>(new List<Vendor>() { new Vendor()
                    {
                        Name = "From Exception",
                        Description = "Description"
                    }});

                    var vendorCountTransaction = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null).Items.Count();

                    Assert.AreEqual(vendorCountBefore + 1, vendorCountTransaction);

                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException e)
            {
                isExceptionThrown = true;
            }

            Assert.IsTrue(isExceptionThrown);

            var vendorCountAfter = _orm.GetSmallTable<SqlResponse<SmallTableRow>>(null, null).Items.Count();

            Assert.AreEqual(vendorCountBefore, vendorCountAfter);
        }
    }
}
