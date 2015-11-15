//using System;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Flyingpie.Storm.Dapper;
//using Database;
//using System.Collections.Generic;
//using System.Diagnostics;
//using Database.UserDefinedTypes.Cars;
//using Flyingpie.Storm.Execution;
//using Storm.Test.Dto;

//namespace Storm.Test
//{
//    [TestClass]
//    public class SelectTest
//    {
//        private ISqlExecutor _executor;

//        private IIntegrationTest _orm;
//        private IUtility _utility;

//        [TestInitialize]
//        public void Initialize()
//        {
//            _executor = DapperSqlExecutor.FromConnectionStringName("TestDatabase");

//            _orm = new Cars(_executor);
//            _utility = new Utility(_executor);
//        }

//        [TestMethod]
//        public void Select()
//        {
//            var result = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null);

//            Assert.AreEqual(10, result.Items.Count());

//            Assert.IsTrue(result.Items.Any(i => i.Name == "Audi" && i.Description == "The steering wheel is an option"));
//            Assert.IsTrue(result.Items.Any(i => i.Name == "Volvo" && i.Description == "The search for perfection ends here"));
//        }

//        [TestMethod]
//        public void Update()
//        {
//            var vendor1 = new Brand() { Name = "Vendor1", Description = "Vendor1 description", HorsePower = 120, Image = new byte[] { 0x01, 0x02 } };
//            var vendor2 = new Brand() { Name = "Vendor2", Description = "Vendor2 description", HorsePower = 140, Image = new byte[] { 0x01, 0x02 } };

//            using (var transaction = _executor.BeginTransaction())
//            {
//                var vendorsBefore = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null);
                
//                Assert.IsFalse(vendorsBefore.Items.Any(v => v.Name == vendor1.Name && v.Description == vendor1.Description));
//                Assert.IsFalse(vendorsBefore.Items.Any(v => v.Name == vendor2.Name && v.Description == vendor2.Description));

//                _orm.AddBrand<SqlResponse>(new List<Brand>() { vendor1, vendor2 });

//                var vendorsAfter = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null);

//                Assert.IsTrue(vendorsAfter.Items.Any(v => v.Name == vendor1.Name && v.Description == vendor1.Description));
//                Assert.IsTrue(vendorsAfter.Items.Any(v => v.Name == vendor2.Name && v.Description == vendor2.Description));
//            }
//        }

//        [TestMethod]
//        public void UpdateDelayed()
//        {
//            // We've encountered an issue where the executor threw the exception 'Object does not match target type',
//            // which disappeared after adding ToList()
//            var vendor1 = new Brand() { Name = "Vendor1", Description = "Vendor1 description", HorsePower = 120, Image = new byte[] { 0x01, 0x02 } };
//            var vendor2 = new Brand() { Name = "Vendor2", Description = "Vendor2 description", HorsePower = 140, Image = new byte[] { 0x01, 0x02 } };
//            var vendors = new List<Brand>()
//            {
//                vendor1,
//                vendor2
//            };

//            using (var transaction = _executor.BeginTransaction())
//            {
//                var vendorsBefore = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null);

//                Assert.IsFalse(vendorsBefore.Items.Any(v => v.Name == vendor1.Name && v.Description == vendor1.Description));
//                Assert.IsFalse(vendorsBefore.Items.Any(v => v.Name == vendor2.Name && v.Description == vendor2.Description));

//                _orm.AddBrand<SqlResponse>(vendors.Select(v => new Brand()
//                {
//                    Description = v.Description,
//                    HorsePower = v.HorsePower,
//                    Image = v.Image,
//                    Name = v.Name
//                }));

//                var vendorsAfter = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null);

//                Assert.IsTrue(vendorsAfter.Items.Any(v => v.Name == vendor1.Name && v.Description == vendor1.Description));
//                Assert.IsTrue(vendorsAfter.Items.Any(v => v.Name == vendor2.Name && v.Description == vendor2.Description));
//            }
//        }

//        [TestMethod]
//        public void TableValuedParameter()
//        {

//        }

//        [TestMethod]
//        public void EmptyTableValuedParameter()
//        {
//            using(var transaction = _executor.BeginTransaction())
//            {
//                _orm.AddBrand<SqlResponse>(new List<Brand>());
//            }
//        }

//        [TestMethod]
//        public void Scalar()
//        {
//            var a = 1;
//            var b = 2;

//            var c = _utility.GetAddition<SqlResponseScalar>(a, b);

//            Assert.AreEqual(a + b, c.Result);
//        }

//        [TestMethod]
//        public void MultipleResultSets()
//        {
//            var a = _orm.GetBrandsAndModels<SqlResponse<Dto.Brand>>();

//            var b = _orm.GetBrandsAndModels<SqlResponse<Dto.Brand, Dto.Model>>();
//        }

//        [TestMethod]
//        public void TransactionRollbackMultiple()
//        {
//            var vendor1 = new Brand() { Name = "Vendor1", Description = "Vendor1 description", HorsePower = 1 };
//            var vendor2 = new Brand() { Name = "Vendor2", Description = "Vendor2 description", HorsePower = 2 };
//            var vendor3 = new Brand() { Name = "Vendor3", Description = "Vendor3 description", HorsePower = 3 };

//            using (var transaction = _executor.BeginTransaction())
//            {
//                _orm.AddBrand<SqlResponse>(new List<Brand>() { vendor1 });
//                transaction.Rollback();
//            }

//            var result = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null);
//            Assert.IsFalse(result.Items.Any(i => i.Name == vendor1.Name && i.Description == vendor1.Description));

//            using (var transaction = _executor.BeginTransaction())
//            {
//                _orm.AddBrand<SqlResponse>(new List<Brand>() { vendor2 });
//                transaction.Rollback();
//            }

//            var result2 = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null);
//            Assert.IsFalse(result.Items.Any(i => i.Name == vendor2.Name && i.Description == vendor2.Description));

//            using (var transaction = _executor.BeginTransaction())
//            {
//                _orm.AddBrand<SqlResponse>(new List<Brand>() { vendor3 });
//                transaction.Rollback();
//            }

//            var result3 = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null);
//            Assert.IsFalse(result.Items.Any(i => i.Name == vendor3.Name && i.Description == vendor3.Description));
//        }

//        [TestMethod]
//        public void TransactionException()
//        {
//            bool isExceptionThrown = false;

//            var vendorCountBefore = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null).Items.Count();

//            try
//            {
//                using (var transaction = _executor.BeginTransaction())
//                {
//                    _orm.AddBrand<SqlResponse>(new List<Brand>() { new Brand()
//                    {
//                        Name = "From Exception",
//                        Description = "Description",
//                        HorsePower = 1
//                    }});

//                    var vendorCountTransaction = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null).Items.Count();

//                    Assert.AreEqual(vendorCountBefore + 1, vendorCountTransaction);

//                    throw new InvalidOperationException();
//                }
//            }
//            catch (InvalidOperationException e)
//            {
//                isExceptionThrown = true;
//            }

//            Assert.IsTrue(isExceptionThrown);

//            var vendorCountAfter = _orm.GetBrands<SqlResponse<Dto.Brand>>(null, null).Items.Count();

//            Assert.AreEqual(vendorCountBefore, vendorCountAfter);
//        }

//        [TestMethod]
//        public void DateTimePrecision()
//        {
//            var input = new DateTime(2014, 10, 16, 11, 30, 2, 232);
//            input = input.AddTicks(123456789);
            
//            var output = _utility.EchoDateTime<SqlResponse<DateTime>>(input).Items.First();

//            Assert.AreEqual(input, output);
//        }
//    }
//}
